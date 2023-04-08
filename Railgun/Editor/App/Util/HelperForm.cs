using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railgun.Editor.App.Util
{
    public partial class HelperForm : Form
    {
        private HelperForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The singleton instance of this Helper Form
        /// </summary>
        public static HelperForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HelperForm();
                }
                return instance;
            }
        }
        private static HelperForm instance;
    }
}
