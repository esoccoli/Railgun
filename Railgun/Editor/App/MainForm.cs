﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Railgun.Editor.App.Objects;
using Railgun.Editor.App.Objects.Visuals;
using Railgun.Editor.App.Util;
using static Railgun.Editor.App.DarkTheme;

namespace Railgun.Editor.App
{
    /// <summary>
    /// The form that contains everything in the editor
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/6/2023
    /// </summary>
    public partial class MainForm : Form
    {
        #region Properties and Fields EMPTY

        /// <summary>
        /// The name of the current project
        /// </summary>
        public string ProjectName { get; set; }

        #endregion

        #region Initial Methods

        /// <summary>
        /// Instantiate this form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when the form is loaded
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Subscribe input update to main editor update event
            mapEditor.OnUpdate += InputManager.Instance.Update;

            //Subscribe update status to update event in main editor control
            mapEditor.OnUpdate += UpdateStatus;

            //Subscribe current tile change to current tile display
            TileManager.Instance.OnCurrentTileChange += currentTileDisplay.Update;

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
        }

        /// <summary>
        /// Colors each control based on its type
        /// </summary>
        /// <param name="controls"></param>
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
                //If button
                //else if (control is Button)
                //{
                //    Button button = control as Button;
                //    button.BackColor = DarkTheme.Panel;
                //    button.ForeColor = DarkTheme.Label;
                //    button.FlatStyle = FlatStyle.System;
                //    button.FlatAppearance.BorderColor = Color.Red;
                //    button.FlatAppearance.MouseOverBackColor = Color.Blue;
                //    button.FlatAppearance.MouseDownBackColor = Color.Yellow;
                //    //button.FlatAppearance. = Color.Yellow;


                //    // Create your custom renderer
                //    DarkTheme.DarkMenuStripRenderer customRenderer = new DarkMenuStripRenderer();

                //    // Set the button's flat style to system
                //    button.FlatStyle = FlatStyle.System;

                //    // Set the renderer of the button's visual style renderer to your custom renderer
                //    button.FlatAppearance.BorderSize = 0;
                //    button.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 255, 255, 255);
                //    button.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 255, 255, 255);
                //    button.FlatAppearance.CheckedBackColor = Color.FromArgb(200, 255, 255, 255);
                //    VisualStyleRenderer renderer = new VisualStyleRenderer(VisualStyleElement.Button.PushButton.Normal);
                //    renderer.SetParameters(VisualStyleElement);
                //    button.FlatAppearance.MouseOverBackColor = customRenderer.Colors[(int)CustomButtonColor.MouseOver];
                //    button.FlatAppearance.MouseDownBackColor = customRenderer.Colors[(int)CustomButtonColor.MouseDown];
                //    button.FlatAppearance.CheckedBackColor = customRenderer.Colors[(int)CustomButtonColor.Checked];
                //    button.FlatAppearance.BorderColor = customRenderer.Colors[(int)CustomButtonColor.BorderColor];
                //}
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
                else
                {
                    control.BackColor = DarkTheme.Base;
                    control.ForeColor = DarkTheme.Label;
                }

                //Recurse for any child controls inside this control
                ColorControls(control.Controls);
            }

            //Set background color as an outline
            BackColor = DarkTheme.Outline;
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

        #region Menustrip Events

        //Edit

        /// <summary>
        /// Rotates the current tile 90 degrees clockwise OR
        /// rotates the current selection by 90 degrees clockwise
        /// </summary>
        private void Menu_Edit_Rotate90CW_Click(object sender, EventArgs e)
        {
            TileManager.Instance.RotateCW();
        }

        /// <summary>
        /// Rotates the current tile 90 degrees counter-clockwise OR
        /// rotates the current selection by 90 degrees counter-clockwise
        /// </summary>
        private void Menu_Edit_Rotate90CCW_Click(object sender, EventArgs e)
        {
            TileManager.Instance.RotateCCW();
        }

        /// <summary>
        /// Flips the current tile horizontally OR
        /// Flips the current selection horizontally
        /// </summary>
        private void Menu_Edit_FlipHorizontally_Click(object sender, EventArgs e)
        {
            TileManager.Instance.FlipHorizontal();
        }

        /// <summary>
        /// Flips the current tile vertically OR
        /// Flips the current selection vertically
        /// </summary>
        private void Menu_Edit_FlipVertically_Click(object sender, EventArgs e)
        {
            TileManager.Instance.FlipVertical();
        }

        /// <summary>
        /// Moves the current tile up OR
        /// Moves the current selection up
        /// </summary>
        private void Menu_Edit_MoveUp_Click(object sender, EventArgs e)
        {
            TileManager.Instance.MoveUp();
        }

        /// <summary>
        /// Moves the current tile down OR
        /// Moves the current selection down
        /// </summary>
        private void Menu_Edit_MoveDown_Click(object sender, EventArgs e)
        {
            TileManager.Instance.MoveDown();
        }

        /// <summary>
        /// Moves the current tile left OR
        /// Moves the current selection left
        /// </summary>
        private void Menu_Edit_MoveLeft_Click(object sender, EventArgs e)
        {
            TileManager.Instance.MoveLeft();
        }

        /// <summary>
        /// Moves the current tile right OR
        /// Moves the current selection right
        /// </summary>
        private void Menu_Edit_MoveRight_Click(object sender, EventArgs e)
        {
            TileManager.Instance.MoveRight();
        }

        //View

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

        //Window

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

        #endregion

        #region Tile Picker Events

        /// <summary>
        /// Changes the tile size when the text box is changed
        /// </summary>
        private void TileSize_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            //If valid, set the tile size
            if(int.TryParse(textBox.Text, out int tileSize) && tileSize > 0)
            {
                tilePicker.GridSize = tileSize;
            }
            //If not valid number an not empty, set it to previous valid number
            else if (textBox.Text != string.Empty)
            {
                textBox.Text = tilePicker.GridSize.ToString();
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
            (sender as TextBox).Text = tilePicker.GridSize.ToString();
        }


        #endregion

        #region File Events

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

        #endregion
    }
}
