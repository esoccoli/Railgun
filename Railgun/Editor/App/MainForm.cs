using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Railgun.Editor.App.Controls;
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
            mainEditorPanel.OnUpdate += InputManager.Instance.Update;

            //Subscribe update status to update event in main editor control
            mainEditorPanel.OnUpdate += UpdateStatus;


            ColorControls(Controls);
        }

        private void newMap_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Updates the status strip with useful info
        /// </summary>
        private void UpdateStatus()
        {
            //Set positions with these digits
            mouseXStatus.Text = mainEditorPanel.MouseGridPosition.X.ToString(" 000;-000");
            mouseYStatus.Text = mainEditorPanel.MouseGridPosition.Y.ToString(" 000;-000");
            //Set zoom amount
            camZoomStatus.Text = mainEditorPanel.Editor.Cam.Zoom
                .ToString("0.00");
        }

        //General control events

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
                //If label
                else if (control is Label)
                {
                    Label label = control as Label;
                    label.BackColor = DarkTheme.Base;
                    label.ForeColor = DarkTheme.Label;
                }
                //If a table layout
                else if (control is TableLayoutPanel)
                {
                    //These act as borders that surround controls
                    TableLayoutPanel table = control as TableLayoutPanel;
                    table.BackColor = DarkTheme.Outline;
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
        }

        //View delagates

        /// <summary>
        /// Resets the camera of the editor
        /// </summary>
        private void ResetCamera_Click(object sender, EventArgs e)
        {
            mainEditorPanel.ResetCamera();
        }

        /// <summary>
        /// Resets the zoom when zoom in status or menu bar is clicked
        /// </summary>
        private void ResetZoom_Click(object sender, EventArgs e)
        {
            mainEditorPanel.Editor.Cam.Zoom = 1f;
        }
    }
}
