using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Railgun.Editor.App.Controls;
using Railgun.Editor.App.Objects;
using Railgun.Editor.App.Util;

namespace Railgun.Editor.App
{
    /// <summary>
    /// The form that contains everything in the editor
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/6/2023
    /// </summary>
    public partial class MainForm : Form
    {
        #region Properties and Fields

        /// <summary>
        /// The name of the current project
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// The tile manager without the instance
        /// </summary>
        private TileManager tileManager;

        /// <summary>
        /// Returns the current tile picker control
        /// </summary>
        public TilePicker CurrentTileset
            => tabControl_Tileset.SelectedTab.Controls[0] as TilePicker;

        #endregion

        #region Initial Methods

        /// <summary>
        /// Instantiate this form
        /// </summary>
        public MainForm()
        {
            //Initialize components from designer
            InitializeComponent();

            try
            {
                //Create tile pickers for every tileset in the tiles folder
                string[] fileNames = Directory.GetFiles(Path.GetFullPath("../../Content/Tiles/"));

                //If there are any files within Tiles
                if (fileNames.Length > 0)
                {
                    for (int i = 0; i < fileNames.Length; i++)
                    {
                        string tilesetName = FileManager.GetFileNameNoExtension(fileNames[i]);

                        TilePicker picker = new TilePicker("Tiles/" + tilesetName)
                        {
                            Dock = DockStyle.Fill
                        };

                        //Add tileset to tab control
                        tabControl_Tileset.TabPages.Add(tilesetName);
                        tabControl_Tileset.TabPages[i + 1].Controls.Add(picker);

                    }
                    //Remove landing page
                    tabControl_Tileset.TabPages.RemoveAt(0);
                }
            }
            catch { }//If error, it will show the error landing page
        }

        /// <summary>
        /// Called when the form is loaded
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Add tile manager singelton to field
            tileManager = TileManager.Instance;

            //Subscribe input update to main editor update event
            mapEditor.OnUpdate += InputManager.Instance.Update;

            //Subscribe update status to update event in main editor control
            mapEditor.OnUpdate += UpdateStatus;

            //Subscribe invalidation events
            tileManager.OnTileChange += currentTileDisplay.Update;
            tileManager.OnHitboxChange += UpdateCurrentHitbox;
            tileManager.OnHitboxChange += currentTileDisplay.Update;
            tileManager.OnViewHitboxesChange += UpdateViewHitbox;
            tileManager.OnViewHitboxesChange += currentTileDisplay.Update;
            tileManager.OnLayerChange += UpdateLayerDisplay;

            //Subscribe modify event
            FileManager.OnModifyInvalidate += ModifyTitle;

            //Color the controls to a darker scheme
            ColorControls(Controls);

            //Set maximized bounds to working area (not cover taskbar)
            //Inflate a bit to make the borders not show
            MaximizedBounds = Rectangle.Inflate(Screen.GetWorkingArea(this),10,10);
            WindowState = FormWindowState.Maximized;

            //Set tile size to 16 pixels
            textBox_TileSize.Text = "16";

            //Resize square buttons since the designer doesn't understand how since
            //it sets the size before it changes the margin size. Also for the display
            button_Edit_Up.Size = new Size(50, 50);
            button_Edit_Down.Size = new Size(50, 50);
            button_Edit_Left.Size = new Size(50, 50);
            button_Edit_Right.Size = new Size(50, 50);
            button_Edit_FlipHorizontal.Size = new Size(50, 50);
            button_Edit_FlipVertical.Size = new Size(50, 50);
            button_Edit_RotateCW.Size = new Size(50, 50);
            button_Edit_RotateCCW.Size = new Size(50, 50);
            currentTileDisplay.Size = new Size(150, 150);

            //Add shortcut strings for single key presses
            toolStripMenuItem_Rotate90CW.ShortcutKeyDisplayString = "E";
            toolStripMenuItem_Rotate90CCW.ShortcutKeyDisplayString = "Q";
            toolStripMenuItem_MoveUp.ShortcutKeyDisplayString = "W";
            toolStripMenuItem_MoveDown.ShortcutKeyDisplayString = "S";
            toolStripMenuItem_MoveLeft.ShortcutKeyDisplayString = "A";
            toolStripMenuItem_MoveRight.ShortcutKeyDisplayString = "D";
            toolStripMenuItem_ShowHitboxes.ShortcutKeyDisplayString = "X";
            toolStripMenuItem_PlaceHitbox.ShortcutKeyDisplayString = "C";

            //Set selected layer to tiles
            comboBox_Layers.SelectedIndex = comboBox_Layers.Items.Count - 1;

            //Set hitboxes to checked
            checkBox_ShowHitboxes.Checked = true;
            checkBox_Solid.Checked = true;

            //Re-arrange temporary holder panels
            panel_Entities.Visible = false;
            tableLayoutPanel_MainEditor.Controls.Remove(panel_Big_Holder);
            tableLayoutPanel_MainEditor.Controls.Add(mapEditor, 0, 1);
            panel_Objects.Controls.Add(tableLayoutPanel_EntityPicker);

            //Set current entity to enterence
            listBox_EntityPicker.SelectedIndex = 1;
        }

        /// <summary>
        /// Colors each control based on its type
        /// </summary>
        /// <param name="controls">The controls to color</param>
        private void ColorControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                //If menu
                if (control is MenuStrip)
                {
                    MenuStrip menuStrip = control as MenuStrip;
                    menuStrip.BackColor = DarkTheme.Base;
                    menuStrip.ForeColor = DarkTheme.Label;
                    //Also set theme for each item
                    foreach (ToolStripMenuItem item in menuStrip.Items)
                    {
                        item.BackColor = DarkTheme.Base;
                        item.ForeColor = DarkTheme.Label;
                        //Same for subItems
                        foreach (ToolStripMenuItem subItem in item.DropDownItems)
                        {
                            subItem.BackColor = DarkTheme.Base;
                            subItem.ForeColor = DarkTheme.Label;
                        }
                    }
                    menuStrip.Renderer = new DarkTheme.DarkMenuStripRenderer();
                }
                //If label
                else if (control is Label)
                {
                    Label label = control as Label;
                    //Ignore if transparent
                    if(label.BackColor != Color.Transparent)
                    {
                        label.BackColor = DarkTheme.Base;
                    }
                    label.ForeColor = DarkTheme.Label;
                }
                //If a table layout and not invisible
                else if (control is TableLayoutPanel
                    && control.BackColor != Color.Transparent)
                {
                    //These act as borders that surround controls
                    TableLayoutPanel table = control as TableLayoutPanel;
                    table.BackColor = DarkTheme.Outline;
                }
                //If a split container layout
                else if (control is SplitContainer)
                {
                    //These act as borders that surround controls
                    SplitContainer splitContainer = control as SplitContainer;
                    splitContainer.BackColor = DarkTheme.Outline;
                }
                //If a panel
                else if (control is Panel)
                {
                    Panel panel = control as Panel;
                    panel.BackColor = DarkTheme.Panel;
                }
                //If checkbox
                else if (control is CheckBox)
                {
                    CheckBox checkBox = control as CheckBox;
                    checkBox.BackColor = DarkTheme.Panel;
                    checkBox.ForeColor = DarkTheme.Label;
                    checkBox.FlatAppearance.BorderColor = DarkTheme.Base;
                    checkBox.FlatAppearance.MouseOverBackColor = DarkTheme.Highlight;
                    checkBox.FlatAppearance.MouseDownBackColor = DarkTheme.Base;
                }
                //If combobox
                else if (control is ComboBox)
                {
                    ComboBox comboBox = control as ComboBox;
                    comboBox.BackColor = DarkTheme.Base;
                    comboBox.ForeColor = DarkTheme.Label;
                }
                //If button
                else if (control is Button)
                {
                    Button button = control as Button;
                    button.BackColor = DarkTheme.Panel;
                    button.ForeColor = DarkTheme.Label;
                    button.FlatAppearance.BorderColor = DarkTheme.Highlight;
                    button.FlatAppearance.MouseOverBackColor = DarkTheme.Highlight;
                    button.FlatAppearance.MouseDownBackColor = DarkTheme.Base;
                }
                else if(control is ListView)
                {
                    ListView list = control as ListView;
                    list.BackColor = DarkTheme.Panel;
                    list.ForeColor = DarkTheme.Label;
                }
                else
                {
                    control.BackColor = DarkTheme.Base;
                    control.ForeColor = DarkTheme.Label;
                }

                //Recurse for any child controls inside this control
                ColorControls(control.Controls);
            }

            //Set other colors manually
            BackColor = DarkTheme.Outline;
            label_NoTilesets.BackColor = DarkTheme.Panel;
        }

        #endregion

        #region Making the window dragable by the menustrip

        //Thanks to https://stackoverflow.com/a/4580843/14951726 and
        //https://stackoverflow.com/a/24691094/14951726 answer for
        //guiding me in the right direction on how to use the windows api

        //Helpful resources for windows api messages regarding dragging
        //0xA1 = WM_NCLBUTTONDOWN https://learn.microsoft.com/en-us/windows/win32/inputdev/wm-nclbuttondown
        //0x2 = HT_CAPTION https://learn.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest

        //Import windows api message sending method
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// Allows the menu strip to drag the window when dragging inside the menu strip
        /// </summary>
        private void MenuStrip_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Release capture so that next frame will call this method again
                menuStrip.Capture = false;
                //Send api message to call window dragging,
                //as if this was a normal window border
                SendMessage(Handle, 0xA1, 0x2, 0);

            }
        }

        #endregion

        #region Status Bar Events

        /// <summary>
        /// Updates the status strip with useful info
        /// </summary>
        private void UpdateStatus()
        {
            //Set positions with these digits
            toolStripStatusLabel_ValueX.Text = mapEditor.MouseGridPosition.X.ToString(" 000;-000");
            toolStripStatusLabel_ValueY.Text = mapEditor.MouseGridPosition.Y.ToString(" 000;-000");
            //Set zoom amount
            toolStripStatusLabel_ValueZoom.Text = mapEditor.Editor.Cam.Zoom
                .ToString("0.00");
            //Rotation of current tile in degrees
            toolStripStatusLabel_ValueRotation.Text = 
                Microsoft.Xna.Framework.MathHelper.ToDegrees(
                    tileManager.CurrentTile.Rotation).ToString(" 000;-000");
            //Current flip of tile
            toolStripStatusLabel_ValueFlip.Text =
                tileManager.CurrentTile.SpriteEffect.ToString().PadRight(16);
            //Current fps
            toolStripStatusLabel_ValueFPS.Text = 
                mapEditor.Editor.GetFrameRate.ToString("#00");
        }

        /// <summary>
        /// Un-highlight when stop hovering over
        /// </summary>
        private void UnHighlightStatus_mouseExit(object sender, EventArgs e)
        {
            //Set color to darker
            (sender as ToolStripStatusLabel).BackColor = DarkTheme.Base;
        }

        /// <summary>
        /// Highlight when hovering over
        /// </summary>
        private void HighlightStatus_mouseEnter(object sender, EventArgs e)
        {
            //Set color to brighter
            (sender as ToolStripStatusLabel).BackColor = DarkTheme.Highlight;
        }

        #endregion

        #region Edit Events

        /// <summary>
        /// Rotates the current tile 90 degrees clockwise OR
        /// rotates the current selection by 90 degrees clockwise
        /// </summary>
        private void Menu_Edit_Rotate90CW_Click(object sender, EventArgs e)
        {
            tileManager.RotateCW();
        }

        /// <summary>
        /// Rotates the current tile 90 degrees counter-clockwise OR
        /// rotates the current selection by 90 degrees counter-clockwise
        /// </summary>
        private void Menu_Edit_Rotate90CCW_Click(object sender, EventArgs e)
        {
            tileManager.RotateCCW();
        }

        /// <summary>
        /// Flips the current tile horizontally OR
        /// Flips the current selection horizontally
        /// </summary>
        private void Menu_Edit_FlipHorizontally_Click(object sender, EventArgs e)
        {
            tileManager.FlipHorizontal();
        }

        /// <summary>
        /// Flips the current tile vertically OR
        /// Flips the current selection vertically
        /// </summary>
        private void Menu_Edit_FlipVertically_Click(object sender, EventArgs e)
        {
            tileManager.FlipVertical();
        }

        /// <summary>
        /// Moves the current tile up OR
        /// Moves the current selection up
        /// </summary>
        private void Menu_Edit_MoveUp_Click(object sender, EventArgs e)
        {
            tileManager.MoveUp();
        }

        /// <summary>
        /// Moves the current tile down OR
        /// Moves the current selection down
        /// </summary>
        private void Menu_Edit_MoveDown_Click(object sender, EventArgs e)
        {
            tileManager.MoveDown();
        }

        /// <summary>
        /// Moves the current tile left OR
        /// Moves the current selection left
        /// </summary>
        private void Menu_Edit_MoveLeft_Click(object sender, EventArgs e)
        {
            tileManager.MoveLeft();
        }

        /// <summary>
        /// Moves the current tile right OR
        /// Moves the current selection right
        /// </summary>
        private void Menu_Edit_MoveRight_Click(object sender, EventArgs e)
        {
            tileManager.MoveRight();
        }

        /// <summary>
        /// Updates the checkboxes of the current hitbox
        /// </summary>
        private void UpdateCurrentHitbox()
        {
            toolStripMenuItem_PlaceHitbox.Checked = tileManager.PlaceHitbox;
            checkBox_Solid.Checked = tileManager.PlaceHitbox;
        }

        /// <summary>
        /// Sets the current hitbox to the check
        /// </summary>
        private void CheckBox_Solid_CheckedChanged(object sender, EventArgs e)
        {
            tileManager.PlaceHitbox = (sender as CheckBox).Checked;
        }

        /// <summary>
        /// Sets the current hitbox to the check
        /// </summary>
        private void Menu_Edit_Solid_CheckedChanged(object sender, EventArgs e)
        {
            tileManager.PlaceHitbox = (sender as ToolStripMenuItem).Checked;
        }

        #endregion

        #region View Events

        /// <summary>
        /// Resets the camera of the editor
        /// </summary>
        private void Menu_View_ResetCamera_Click(object sender, EventArgs e)
        {
            mapEditor.ResetCamera();
        }

        /// <summary>
        /// Resets the zoom when zoom in status or menu bar is clicked
        /// </summary>
        private void Menu_View_ResetZoom_Click(object sender, EventArgs e)
        {
            mapEditor.Editor.Cam.Zoom = 1f;
        }

        /// <summary>
        /// Updates the checkboxes of the hitbox view
        /// </summary>
        private void UpdateViewHitbox()
        {
            toolStripMenuItem_ShowHitboxes.Checked = tileManager.ViewHitboxes;
            checkBox_ShowHitboxes.Checked = tileManager.ViewHitboxes;
        }

        /// <summary>
        /// Sets showing the hitbox to the check
        /// </summary>
        private void CheckBox_ShowHitboxes_CheckedChanged(object sender, EventArgs e)
        {
            tileManager.ViewHitboxes = (sender as CheckBox).Checked;
        }

        /// <summary>
        /// Sets showing the hitbox to the check
        /// </summary>
        private void Menu_View_ShowHitboxes_CheckedChanged(object sender, EventArgs e)
        {
            tileManager.ViewHitboxes = (sender as ToolStripMenuItem).Checked;
        }

        #endregion

        #region Fake Control Box Events

        /// <summary>
        /// Called when the exit button is clicked
        /// </summary>
        private void Menu_Exit_Click(object sender, EventArgs e)
        {
            //Try to close, if unsaved, then close event will handle it
            Close();
        }

        /// <summary>
        /// Called when the maximize/minimize button is clicked
        /// </summary>
        private void Menu_Maximize_Click(object sender, EventArgs e)
        {
            //Switch based on the current state of the window
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// Minimizes the window to the taskbar
        /// </summary>
        private void Menu_Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Called when the menu strip resisizes, adjusts the margin on the title
        /// </summary>
        private void Menu_Resize(object sender, EventArgs e)
        {
            CenterTitle();
        }

        /// <summary>
        /// Adjusts the margin on the title
        /// </summary>
        private void CenterTitle()
        {
            Padding oldMargin = toolStripMenuItem_Title.Margin;

            //Change the margin to center the title
            toolStripMenuItem_Title.Margin =
                new Padding(oldMargin.Left,
                    oldMargin.Top,
                    menuStrip.Width / 2 - //Compute margin distance
                        (toolStripMenuItem_Exit.Width + toolStripMenuItem_Maximize.Width +
                        toolStripMenuItem_Minimize.Width + toolStripMenuItem_Title.Width / 2),
                    oldMargin.Bottom);
        }

        /// <summary>
        /// Called when the help button is clicked and shows help window
        /// </summary>
        private void ToolStripMenuItem_Help_Click(object sender, EventArgs e)
        {
            HelperForm.Instance.ShowDialog();
        }

        #endregion

        #region Tile Picker and Related Events

        /// <summary>
        /// Changes the tile size when the text box is changed
        /// </summary>
        private void TileSize_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            //If valid, set the tile size
            if(int.TryParse(textBox.Text, out int tileSize) && tileSize > 0)
            {
                CurrentTileset.GridSize = tileSize;
            }
            //If not valid number an not empty, set it to previous valid number
            else if (textBox.Text != string.Empty)
            {
                textBox.Text = CurrentTileset.GridSize.ToString();
                //Set cursor to end of text
                textBox.SelectionStart = textBox.TextLength;
            }
        }

        /// <summary>
        /// Called when the text box has lost focus and
        /// makes sure it has the correct number
        /// </summary>
        private void TileSize_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).Text = CurrentTileset.GridSize.ToString();
        }

        /// <summary>
        /// Called when the tileset tab is changed
        /// </summary>
        private void TabControl_Tileset_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set tile size to current tileset's tile size
            textBox_TileSize.Text = CurrentTileset.GridSize.ToString();
        }

        /// <summary>
        /// Updates the tile display based on the layer
        /// </summary>
        private void UpdateLayerDisplay()
        {
            //Set current tile to nothing if on a non-tile layer
            if(tileManager.CurrentLayer < 0)
            {
                //If hitbox layer
                if(tileManager.CurrentLayer == -1)
                {
                    //Hide tile picker
                    tableLayoutPanel_TilePicker.Visible = false;
                    tileManager.CurrentTile = Tile.Empty;
                    //Hide entity picker
                    tableLayoutPanel_EntityPicker.Visible = false;
                    
                }
                //If entity layer
                else if(tileManager.CurrentLayer == -2)
                {
                    //Hide tile picker
                    tableLayoutPanel_TilePicker.Visible = false;
                    tileManager.CurrentTile = Tile.Empty;
                    //Hide entity picker
                    tableLayoutPanel_EntityPicker.Visible = true;
                }

                return;
            }

            //Show tile picker
            tableLayoutPanel_TilePicker.Visible = true;
            //Hide entity picker
            tableLayoutPanel_EntityPicker.Visible = false;

            //Else set to current selection
            CurrentTileset.CreateTileSelection();
        }

        /// <summary>
        /// Called when the layer is changed
        /// </summary>
        private void ComboBox_Layers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set current layer where the hitbox layer is -1
            tileManager.CurrentLayer = comboBox_Layers.SelectedIndex - 2;
        }

        /// <summary>
        /// Called when the entity picker is changed
        /// </summary>
        private void ListBox_EntityPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            EntityManager.Instance.CurrentEntity = listView_Entities.SelectedItems[0].Index;
        }

        #endregion

        #region File Events

        /// <summary>
        /// Creates a new Map and prompts user if the current map is unsaved
        /// </summary>
        private void Menu_New_Click(object sender, EventArgs e)
        {
            //Prompt if there are unsaved changes
            if (FileManager.Modified)
            {
                //Made a local var here just to make it easier to read
                DialogResult choice = MessageBox.Show(
                    $"The current map has unsaved changes. Are you sure you want to create a new map?",
                    "Unsaved Changes:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //If not yes, return
                if (choice != DialogResult.Yes)
                    return;
            }
            else
            {
                //Set modified to true to allow for invalidation
                FileManager.Modified = true;
            }

            //Create new map
            Map newMap = new Map(128);
            newMap.Layers.Add(new Dictionary<Microsoft.Xna.Framework.Vector2, Tile>());

            //Prompt user to save as (allowing them to name), if cancel, return
            if (!FileManager.SaveMapAs(newMap))
                return;

            //If they do save, set Set current map to new map
            mapEditor.CurrentMap = newMap;
        }

        /// <summary>
        /// Saves the current map if possible, if not it will prompt the user to save as
        /// </summary>
        private void Menu_Save_Click(object sender, EventArgs e)
        {
            FileManager.SaveMap(mapEditor.CurrentMap);
        }

        /// <summary>
        /// Prompts the user to save the current map
        /// </summary>
        private void Menu_SaveAs_Click(object sender, EventArgs e)
        {
            FileManager.SaveMapAs(mapEditor.CurrentMap);
        }

        /// <summary>
        /// Prompts the user to open a map
        /// </summary>
        private void Menu_Open_Click(object sender, EventArgs e)
        {
            //Save current map just in case nothing is loaded, get map path
            Map loadedMap = FileManager.LoadMap(mapEditor.Editor.Content);

            //If a map was loaded, set current map to that map
            if(loadedMap != null)
            {
                mapEditor.CurrentMap = loadedMap;

                //Set current map name on the title
                toolStripMenuItem_Title.Text =
                    FileManager.GetFileNameNoExtension(FileManager.CurrentMapPath);
            }
        }

        /// <summary>
        /// Gives the title a star when the map is changed to modified
        /// </summary>
        private void ModifyTitle()
        {
            //If just changed to modified, add a star
            if(FileManager.Modified)
            {
                //Change to italics
                toolStripMenuItem_Title.Font = new Font(toolStripMenuItem_Title.Font, FontStyle.Italic);
                //Add star
                toolStripMenuItem_Title.Text = "*" + toolStripMenuItem_Title.Text;
            }
            else
            {
                //Change to regular
                toolStripMenuItem_Title.Font = new Font(toolStripMenuItem_Title.Font, FontStyle.Regular);
                //If not, set the title to the current map name
                toolStripMenuItem_Title.Text =
                    FileManager.GetFileNameNoExtension(FileManager.CurrentMapPath);

            }

            //Center the new title
            CenterTitle();
        }

        /// <summary>
        /// Called when the form is closing, prompts the user if there are unsaved changes
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FileManager.Modified)
            {
                //Made a local var here just to make it easier to read
                DialogResult choice = MessageBox.Show(
                    $"The current map has unsaved changes. Are you sure you want to exit?",
                    "Unsaved Changes:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //If not yes, close the form
                if (choice != DialogResult.Yes)
                    e.Cancel = true;
            }
        }

        #endregion

    }
}
