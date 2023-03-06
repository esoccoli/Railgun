﻿using System;
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            editorPanel.Size = new Size(100, 100);
            Controls.Add(editorPanel);

        }
    }
}
