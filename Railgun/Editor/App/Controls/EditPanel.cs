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
    /// A user control of the edit panel
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 4/30/2023
    /// </summary>
    public partial class EditPanel : UserControl
    {
        public EditPanel()
        {
            InitializeComponent();
            tileManager = TileManager.Instance;
        }

        /// <summary>
        /// The tile manager
        /// </summary>
        private TileManager tileManager;

        /// <summary>
        /// Sets the current hitbox to the check
        /// </summary>
        private void CheckBox_Solid_CheckedChanged(object sender, EventArgs e)
        {
            tileManager.IsPlacingHitbox = (sender as CheckBox).Checked;
        }

        /// <summary>
        /// Rotates the current tile 90 degrees clockwise OR
        /// rotates the current selection by 90 degrees clockwise
        /// </summary>
        private void Button_Rotate90CW_Click(object sender, EventArgs e)
        {
            tileManager.RotateCW();
        }

        /// <summary>
        /// Rotates the current tile 90 degrees counter-clockwise OR
        /// rotates the current selection by 90 degrees counter-clockwise
        /// </summary>
        private void Button_Rotate90CCW_Click(object sender, EventArgs e)
        {
            tileManager.RotateCCW();
        }

        /// <summary>
        /// Flips the current tile horizontally OR
        /// Flips the current selection horizontally
        /// </summary>
        private void Button_FlipHorizontally_Click(object sender, EventArgs e)
        {
            tileManager.FlipHorizontal();
        }

        /// <summary>
        /// Flips the current tile vertically OR
        /// Flips the current selection vertically
        /// </summary>
        private void Button_Edit_FlipVertically_Click(object sender, EventArgs e)
        {
            tileManager.FlipVertical();
        }

        /// <summary>
        /// Moves the current tile up OR
        /// Moves the current selection up
        /// </summary>
        private void Button_MoveUp_Click(object sender, EventArgs e)
        {
            tileManager.MoveUp();
        }

        /// <summary>
        /// Moves the current tile down OR
        /// Moves the current selection down
        /// </summary>
        private void Button_MoveDown_Click(object sender, EventArgs e)
        {
            tileManager.MoveDown();
        }

        /// <summary>
        /// Moves the current tile left OR
        /// Moves the current selection left
        /// </summary>
        private void Button_MoveLeft_Click(object sender, EventArgs e)
        {
            tileManager.MoveLeft();
        }

        /// <summary>
        /// Moves the current tile right OR
        /// Moves the current selection right
        /// </summary>
        private void Button_MoveRight_Click(object sender, EventArgs e)
        {
            tileManager.MoveRight();
        }
    }
}
