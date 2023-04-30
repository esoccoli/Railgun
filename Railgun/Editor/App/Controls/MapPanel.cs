using Railgun.Editor.App.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railgun.Editor.App.Controls
{
    /// <summary>
    /// A user control that contains the map panel and its settings
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 4/20/2023
    /// </summary>
    public partial class MapPanel : UserControl
    {
        public MapPanel()
        {
            InitializeComponent();
        }

        //Events

        /// <summary>
        /// Called when the layer is changed
        /// </summary>
        private void ComboBox_Layers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set current layer where the hitbox layer is -1
            TileManager.Instance.CurrentLayer = comboBox_Layers.SelectedIndex - 2;
        }

        /// <summary>
        /// Sets showing the grid to the check
        /// </summary>
        private void CheckBox_ShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            TileManager.Instance.ShowGrid = (sender as CheckBox).Checked;
        }

        /// <summary>
        /// Sets showing the hitbox to the check
        /// </summary>
        private void CheckBox_ShowHitboxes_CheckedChanged(object sender, EventArgs e)
        {
            TileManager.Instance.ViewHitboxes = (sender as CheckBox).Checked;
        }
    }
}
