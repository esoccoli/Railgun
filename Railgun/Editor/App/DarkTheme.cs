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
        public static Color Base => Color.FromArgb(31, 31, 31);
        public static Color Outline => Color.FromArgb(128, 128, 128);
        public static Color Label => Color.White;//Color.FromArgb(224, 224, 224);
        public static Color Panel => Color.FromArgb(51, 51, 51);
        public static Color Highlight => Color.FromArgb(80, 80, 80);
        //public static Color Button => Color.FromArgb(64, 64, 64);

        //Set color table
        public override Color MenuItemSelected => Highlight;
        public override Color MenuItemSelectedGradientBegin => Highlight;
        public override Color MenuItemSelectedGradientEnd => Highlight;
        public override Color MenuItemBorder => Outline;
        public override Color MenuStripGradientBegin => Base;
        public override Color MenuStripGradientEnd => Base;
        public override Color MenuItemPressedGradientBegin => Highlight;
        public override Color MenuItemPressedGradientEnd => Highlight;
        public override Color ToolStripBorder => Outline;
        public override Color MenuBorder => Outline;

        //Create custom renderers

        /// <summary>
        /// The menustrip rendering theme for the editor
        /// </summary>
        public class DarkMenuStripRenderer : ToolStripProfessionalRenderer
        {
            public DarkMenuStripRenderer() : base(new DarkTheme()) { }
        }


    }
}
