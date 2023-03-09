using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railgun.Editor.App
{
    /// <summary>
    /// The color table of theme colors and renderes to be used for the editor
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/9/2023
    /// </summary>
    public class DarkTheme : ProfessionalColorTable
    {
        //Color theme
        public static Color BaseColor => Color.FromArgb(31, 31, 31);
        public static Color LabelColor => Color.FromArgb(128, 128, 128);
        public static Color ContrastColor => Color.White;
        public static Color PanelColor => Color.FromArgb(51, 51, 51);
        public static Color HighlightColor => Color.FromArgb(80, 80, 80);

        //Set color table
        public override Color MenuItemSelected => HighlightColor;
        public override Color MenuItemSelectedGradientBegin => HighlightColor;
        public override Color MenuItemSelectedGradientEnd => HighlightColor;
        public override Color MenuItemBorder => LabelColor;
        public override Color MenuStripGradientBegin => BaseColor;
        public override Color MenuStripGradientEnd => BaseColor;
        public override Color MenuItemPressedGradientBegin => HighlightColor;
        public override Color MenuItemPressedGradientEnd => HighlightColor;
        public override Color ToolStripBorder => LabelColor;
        public override Color MenuBorder => LabelColor;

        //Create custom renderers

        /// <summary>
        /// The menustrip rendering theme for the editor
        /// <para>Author: Jonathan Jan</para>
        /// Date Created: 3/9/2023
        /// </summary>
        public class DarkMenuStripRenderer : ToolStripProfessionalRenderer
        {
            public DarkMenuStripRenderer() : base(new DarkTheme()) { }
        }
    }
}
