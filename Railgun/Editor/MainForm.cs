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
    public partial class MainForm : Form
    {

        //Try adding it from here
        MainEditorPanel editorPanel = new MainEditorPanel();


        public MainForm()
        {
            InitializeComponent();
        }

        private void newMap_Click(object sender, EventArgs e)
        {

        }
    }
}
