using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railgun.Editor.App
{
    internal class DarkTheme
    {
        //Color theme
        public static Color BaseColor => Color.FromArgb(31, 31, 31);
        public static Color LabelColor => Color.FromArgb(128, 128, 128);
        public static Color ContrastColor => Color.White;
        public static Color PanelColor => Color.FromArgb(51, 51, 51);
        public static Color HighlightColor => Color.FromArgb(80, 80, 80);
    }

    public class DarkMenuStripRenderer : ToolStripProfessionalRenderer
    {
        public DarkMenuStripRenderer() : base(new MenuStringColorTable()) { }
    }

    public class MenuStringColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected => DarkTheme.HighlightColor;
        public override Color MenuItemSelectedGradientBegin => DarkTheme.HighlightColor;
        public override Color MenuItemSelectedGradientEnd => DarkTheme.HighlightColor;
    }
}
