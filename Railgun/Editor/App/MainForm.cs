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
        /// The entity panel of the editor
        /// </summary>
        private EntityPanel entityPanel;

        /// <summary>
        /// The hitbox editing panel of the editor
        /// </summary>
        private HitboxEditorPanel hitboxEditor;

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
                        tilePanel.tabControl_Tileset.TabPages.Add(tilesetName);
                        tilePanel.tabControl_Tileset.TabPages[i + 1].Controls.Add(picker);

                    }
                    //Remove landing page
                    tilePanel.tabControl_Tileset.TabPages.RemoveAt(0);
                }
            }
            catch { }//If error, it will show the error landing page

            //Initialize user controls
            entityPanel = new EntityPanel();
            entityPanel.Dock = DockStyle.Fill;
            entityPanel.Margin = new Padding(0);
            entityPanel.Visible = false;
            hitboxEditor = new HitboxEditorPanel();
            hitboxEditor.Dock = DockStyle.Fill;
            hitboxEditor.Margin = new Padding(0);
            hitboxEditor.Visible = false;
        }

        /// <summary>
        /// Called when the form is loaded
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Add tile manager singelton to field
            tileManager = TileManager.Instance;

            //Subscribe input update to main editor update event
            mapPanel.mapEditor.OnUpdate += InputManager.Instance.Update;

            //Subscribe update status to update event in main editor control
            mapPanel.mapEditor.OnUpdate += UpdateStatus;

            //Subscribe invalidation events
            tileManager.OnTileChange += editPanel.currentTileDisplay.Update;
            tileManager.OnTileChange += hitboxEditor.currentTileDisplay.Update;
            tileManager.OnHitboxChange += UpdateCurrentHitbox;
            tileManager.OnHitboxChange += editPanel.currentTileDisplay.Update;
            tileManager.OnHitboxChange += hitboxEditor.currentTileDisplay.Update;
            tileManager.OnViewHitboxesChange += UpdateViewHitbox;
            tileManager.OnViewHitboxesChange += editPanel.currentTileDisplay.Update;
            tileManager.OnViewHitboxesChange += hitboxEditor.currentTileDisplay.Update;
            tileManager.OnViewGridChange += UpdateViewGrid;
            tileManager.OnLayerChange += UpdateLayerDisplay;

            //Subscribe modify event
            FileManager.OnModifyInvalidate += ModifyTitle;

            //Set maximized bounds to working area (not cover taskbar)
            //Inflate a bit to make the borders not show
            MaximizedBounds = Rectangle.Inflate(Screen.GetWorkingArea(this),10,10);
            WindowState = FormWindowState.Maximized;

            //Set tile size to 16 pixels
            tilePanel.numericUpDown_TileSize.Value = 16;

            //Resize square buttons since the designer doesn't understand how since
            //it sets the size before it changes the margin size. Also for the display
            Size buttonSize = new Size(50, 50);
            Size displaySize = new Size(150, 150);
            editPanel.button_Edit_Up.Size = buttonSize;
            editPanel.button_Edit_Down.Size = buttonSize;
            editPanel.button_Edit_Left.Size = buttonSize;
            editPanel.button_Edit_Right.Size = buttonSize;
            editPanel.button_Edit_FlipHorizontal.Size = buttonSize;
            editPanel.button_Edit_FlipVertical.Size = buttonSize;
            editPanel.button_Edit_RotateCW.Size = buttonSize;
            editPanel.button_Edit_RotateCCW.Size = buttonSize;
            editPanel.currentTileDisplay.Size = displaySize;
            hitboxEditor.currentTileDisplay.Size = displaySize;

            //Add shortcut strings for single key presses
            toolStripMenuItem_Rotate90CW.ShortcutKeyDisplayString = "E";
            toolStripMenuItem_Rotate90CCW.ShortcutKeyDisplayString = "Q";
            toolStripMenuItem_MoveUp.ShortcutKeyDisplayString = "W";
            toolStripMenuItem_MoveDown.ShortcutKeyDisplayString = "S";
            toolStripMenuItem_MoveLeft.ShortcutKeyDisplayString = "A";
            toolStripMenuItem_MoveRight.ShortcutKeyDisplayString = "D";
            toolStripMenuItem_ShowHitboxes.ShortcutKeyDisplayString = "X";
            toolStripMenuItem_PlaceHitbox.ShortcutKeyDisplayString = "C";
            toolStripMenuItem_ShowGrid.ShortcutKeyDisplayString = "G";

            //Set selected layer to tiles
            mapPanel.comboBox_Layers.SelectedIndex = mapPanel.comboBox_Layers.Items.Count - 2;

            //Set hitboxes to checked
            mapPanel.checkBox_ShowHitboxes.Checked = true;
            editPanel.checkBox_Solid.Checked = true;
            hitboxEditor.checkBox_Solid.Checked = true;
            mapPanel.checkBox_ShowGrid.Checked = true;

            //Add user controls
            splitContainer_MainEditor.Panel1.Controls.Add(entityPanel);
            splitContainer_MainEditor.Panel1.Controls.Add(hitboxEditor);

            //Color the controls to a darker scheme
            ColorControls(Controls);
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
            tilePanel.label_NoTilesets.BackColor = DarkTheme.Panel;
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
            toolStripStatusLabel_ValueX.Text = mapPanel.mapEditor.MouseGridPosition.X.ToString(" 000;-000");
            toolStripStatusLabel_ValueY.Text = mapPanel.mapEditor.MouseGridPosition.Y.ToString(" 000;-000");
            //Set zoom amount
            toolStripStatusLabel_ValueZoom.Text = mapPanel.mapEditor.Editor.Cam.Zoom
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
                mapPanel.mapEditor.Editor.GetFrameRate.ToString("#00");
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
            toolStripMenuItem_PlaceHitbox.Checked = tileManager.IsPlacingHitbox;
            editPanel.checkBox_Solid.Checked = tileManager.IsPlacingHitbox;
            hitboxEditor.checkBox_Solid.Checked = tileManager.IsPlacingHitbox;
        }

        /// <summary>
        /// Sets the current hitbox to the check
        /// </summary>
        private void Menu_Edit_Solid_CheckedChanged(object sender, EventArgs e)
        {
            tileManager.IsPlacingHitbox = (sender as ToolStripMenuItem).Checked;
        }

        #endregion

        #region View Events

        /// <summary>
        /// Resets the camera of the editor
        /// </summary>
        private void Menu_View_ResetCamera_Click(object sender, EventArgs e)
        {
            mapPanel.mapEditor.ResetCamera();
        }

        /// <summary>
        /// Resets the zoom when zoom in status or menu bar is clicked
        /// </summary>
        private void Menu_View_ResetZoom_Click(object sender, EventArgs e)
        {
            mapPanel.mapEditor.Editor.Cam.Zoom = 1f;
        }

        /// <summary>
        /// Updates the checkboxes of the hitbox view
        /// </summary>
        private void UpdateViewHitbox()
        {
            toolStripMenuItem_ShowHitboxes.Checked = tileManager.ViewHitboxes;
            mapPanel.checkBox_ShowHitboxes.Checked = tileManager.ViewHitboxes;
        }

        /// <summary>
        /// Sets showing the hitbox to the check
        /// </summary>
        private void Menu_View_ShowHitboxes_CheckedChanged(object sender, EventArgs e)
        {
            tileManager.ViewHitboxes = (sender as ToolStripMenuItem).Checked;
        }

        /// <summary>
        /// Updates the checkboxes of the grid view
        /// </summary>
        private void UpdateViewGrid()
        {
            toolStripMenuItem_ShowGrid.Checked = tileManager.ShowGrid;
            mapPanel.checkBox_ShowGrid.Checked = tileManager.ShowGrid;
        }

        /// <summary>
        /// Sets showing the grid to the check
        /// </summary>
        private void Menu_View_ShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            tileManager.ShowGrid = (sender as ToolStripMenuItem).Checked;
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
        /// Changes the tile size when the number box is changed
        /// </summary>
        private void TileSize_TextChanged(object sender, EventArgs e)
        {
            tilePanel.CurrentTileset.GridSize = (float)(sender as NumericUpDown).Value;
        }

        /// <summary>
        /// Updates the tile display based on the layer
        /// </summary>
        private void UpdateLayerDisplay()
        {
            switch(tileManager.CurrentLayer)
            {
                case -2://Entity layer

                    //Show entity picker, hide everything else
                    splitContainer_TileEditing.Visible = false;
                    entityPanel.Visible = true;
                    hitboxEditor.Visible = false;

                    //Set current tile to none
                    tileManager.CurrentTile = Tile.Empty;

                    break;
                case -1://Hitbox layer

                    //Show hitbox editor, hide everything else
                    splitContainer_TileEditing.Visible = false;
                    entityPanel.Visible = false;
                    hitboxEditor.Visible = true;

                    //Set current tile to none
                    tileManager.CurrentTile = Tile.Empty;

                    break;
                default://Tile layer

                    //Show tile picker and edit, hide everything else
                    splitContainer_TileEditing.Visible = true;
                    entityPanel.Visible = false;
                    hitboxEditor.Visible = false;

                    //Set current selection
                    tilePanel.CurrentTileset.CreateTileSelection();
                    break;
            }
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
            //Create 2 layers
            newMap.Layers.Add(new Dictionary<Microsoft.Xna.Framework.Vector2, Tile>());
            newMap.Layers.Add(new Dictionary<Microsoft.Xna.Framework.Vector2, Tile>());

            //Prompt user to save as (allowing them to name), if cancel, return
            if (!FileManager.SaveMapAs(newMap))
                return;

            //If they do save, set Set current map to new map
            mapPanel.mapEditor.CurrentMap = newMap;
        }

        /// <summary>
        /// Saves the current map if possible, if not it will prompt the user to save as
        /// </summary>
        private void Menu_Save_Click(object sender, EventArgs e)
        {
            FileManager.SaveMap(mapPanel.mapEditor.CurrentMap);
        }

        /// <summary>
        /// Prompts the user to save the current map
        /// </summary>
        private void Menu_SaveAs_Click(object sender, EventArgs e)
        {
            FileManager.SaveMapAs(mapPanel.mapEditor.CurrentMap);
        }

        /// <summary>
        /// Prompts the user to open a map
        /// </summary>
        private void Menu_Open_Click(object sender, EventArgs e)
        {
            //Save current map just in case nothing is loaded, get map path
            Map loadedMap = FileManager.LoadMap(mapPanel.mapEditor.Editor.Content);

            //If a map was loaded, set current map to that map
            if(loadedMap != null)
            {
                mapPanel.mapEditor.CurrentMap = loadedMap;

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
