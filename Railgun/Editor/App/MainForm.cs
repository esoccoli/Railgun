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
        //Color theme
        Color baseColor = Color.FromArgb(31, 31, 31);
        Color labelColor = Color.FromArgb(128, 128, 128);
        Color contrastColor = Color.White;
        Color panelColor = Color.FromArgb(51, 51, 51);
        Color highlightColor = Color.FromArgb(80, 80, 80);



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



            //Set color scheme
            //BackColor = baseColor;
            //Set each color
            foreach (Control control in Controls)
            {
                if (control is MenuStrip)
                {
                    MenuStrip menuStrip = control as MenuStrip;
                    //menuStrip.BackColor = baseColor;
                    //menuStrip.ForeColor = contrastColor;
                    menuStrip.Renderer = new DarkMenuStripRenderer();
                }
            }
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
            mouseXStatus.Text = "X: " + 
                InputManager.Instance.CurrentMouseState
                .Position.X.ToString("##000");
            mouseYStatus.Text = "Y: " +
                InputManager.Instance.CurrentMouseState
                .Position.Y.ToString("##000");
            //Set zoom amount
            camZoomStatus.Text = "Zoom: " +
                mainEditorPanel.Editor.Cam.Zoom
                .ToString("0.00");
        }

        //General control events

        /// <summary>
        /// Un-highlight when stop hovering over
        /// </summary>
        private void UnHighlightStatus_mouseExit(object sender, EventArgs e)
        {
            //Set color to darker
            (sender as ToolStripStatusLabel).BackColor = highlightColor;
        }

        /// <summary>
        /// Highlight when hovering over
        /// </summary>
        private void HighlightStatus_mouseEnter(object sender, EventArgs e)
        {
            //Set color to brighter
            (sender as ToolStripStatusLabel).BackColor = baseColor;
        }

        //Status events

        /// <summary>
        /// Resets the zoom when zoom in status is clicked
        /// </summary>
        private void CamZoomStatus_Click(object sender, EventArgs e)
        {
            mainEditorPanel.Editor.Cam.Zoom = 1f;
        }

    }
}
