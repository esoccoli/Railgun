using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            mouseXStatus.Text = 
                InputManager.Instance.CurrentMouseState
                .Position.X.ToString(" 000;-000");
            mouseYStatus.Text =
                InputManager.Instance.CurrentMouseState
                .Position.Y.ToString(" 000;-000");
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
            (sender as ToolStripStatusLabel).BackColor = DarkTheme.BaseColor;
        }

        /// <summary>
        /// Highlight when hovering over
        /// </summary>
        private void HighlightStatus_mouseEnter(object sender, EventArgs e)
        {
            //Set color to brighter
            (sender as ToolStripStatusLabel).BackColor = DarkTheme.HighlightColor;
        }

        //Status events

        /// <summary>
        /// Resets the zoom when zoom in status is clicked
        /// </summary>
        private void CamZoomStatus_Click(object sender, EventArgs e)
        {
            mainEditorPanel.Editor.Cam.Zoom = 1f;
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
                    menuStrip.BackColor = DarkTheme.BaseColor;
                    menuStrip.ForeColor = DarkTheme.ContrastColor;
                    //Also set theme for each item
                    foreach (ToolStripMenuItem item in menuStrip.Items)
                    {
                        item.BackColor = DarkTheme.BaseColor;
                        item.ForeColor = DarkTheme.ContrastColor;
                        //Same for subItems
                        foreach (ToolStripMenuItem subItem in item.DropDownItems)
                        {
                            subItem.BackColor = DarkTheme.BaseColor;
                            subItem.ForeColor = DarkTheme.ContrastColor;
                        }
                    }
                    menuStrip.Renderer = new DarkTheme.DarkMenuStripRenderer();
                }
                //If label
                else if (control is Label)
                {
                    Label label = control as Label;
                    label.BackColor = DarkTheme.BaseColor;
                    label.ForeColor = DarkTheme.LabelColor;
                }
                //If a table layout
                else if (control is TableLayoutPanel)
                {
                    //These act as borders that surround controls
                    TableLayoutPanel table = control as TableLayoutPanel;
                    table.BackColor = DarkTheme.LabelColor;
                }
                //If a panel
                else if (control is Panel)
                {
                    Panel panel = control as Panel;
                    panel.BackColor = DarkTheme.PanelColor;
                }
                else
                {
                    control.BackColor = DarkTheme.BaseColor;
                    control.ForeColor = DarkTheme.LabelColor;
                }

                //Recurse for any child controls inside this control
                ColorControls(control.Controls);
            }
        }

    }
}
