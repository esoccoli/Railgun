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
    /// A user control of the tile panel
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 4/30/2023
    /// </summary>
    public partial class TilePanel : UserControl
    {
        public TilePanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Returns the current tile picker control
        /// </summary>
        public TilePicker CurrentTileset
            => tabControl_Tileset.SelectedTab.Controls[0] as TilePicker;

        /// <summary>
        /// Called when the tileset tab is changed
        /// </summary>
        private void TabControl_Tileset_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set tile size to current tileset's tile size
            numericUpDown_TileSize.Value = (decimal) CurrentTileset.GridSize;
        }
    }
}
