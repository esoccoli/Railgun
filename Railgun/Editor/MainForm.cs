using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Railgun.Editor.Controls;

namespace Railgun.Editor
{
    /// <summary>
    /// The form that contains everything in the editor
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/6/2023
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when the form is loaded
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Add update status to update event in main editor control
            mainEditorPanel.OnUpdate += UpdateStatus;
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
                mainEditorPanel.PrevMousePosition.X.ToString("##000.00");
            mouseYStatus.Text = "Y: " + 
                mainEditorPanel.PrevMousePosition.Y.ToString("##000.00");
        }
    }
}
