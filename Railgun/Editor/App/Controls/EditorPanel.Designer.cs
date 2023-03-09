﻿namespace Railgun.Editor.App.Controls
{
    partial class EditorPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tilePanelLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tilePanelLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 410);
            this.panel1.TabIndex = 1;
            // 
            // tilePanelLabel
            // 
            this.tilePanelLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tilePanelLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tilePanelLabel.Location = new System.Drawing.Point(0, 0);
            this.tilePanelLabel.Name = "tilePanelLabel";
            this.tilePanelLabel.Size = new System.Drawing.Size(449, 16);
            this.tilePanelLabel.TabIndex = 0;
            this.tilePanelLabel.Text = "Tiles";
            this.tilePanelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EditorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "EditorPanel";
            this.Size = new System.Drawing.Size(449, 410);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label tilePanelLabel;
    }
}
