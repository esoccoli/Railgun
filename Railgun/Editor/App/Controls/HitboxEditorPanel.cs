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
    /// A user control of the hitbox editor panel
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 4/30/2023
    /// </summary>
    public partial class HitboxEditorPanel : UserControl
    {
        public HitboxEditorPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the current hitbox to the check
        /// </summary>
        private void CheckBox_Solid_CheckedChanged(object sender, EventArgs e)
        {
            TileManager.Instance.IsPlacingHitbox = (sender as CheckBox).Checked;
        }
    }
}
