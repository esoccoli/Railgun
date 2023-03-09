namespace Railgun.Editor.App
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.logoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftSideTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mouseXStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.mouseYStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.camZoomStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tilePanelLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.editPanelLabel = new System.Windows.Forms.Label();
            this.mainEditorPanel = new Railgun.Editor.App.Controls.MainEditorPanel();
            this.menuStrip.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.leftSideTableLayoutPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.saveStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(900, 30);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // logoToolStripMenuItem
            // 
            this.logoToolStripMenuItem.Enabled = false;
            this.logoToolStripMenuItem.Image = global::Railgun.Editor.Properties.Resources.railgun_transparent;
            this.logoToolStripMenuItem.Name = "logoToolStripMenuItem";
            this.logoToolStripMenuItem.Size = new System.Drawing.Size(34, 26);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newMapToolStripMenuItem
            // 
            this.newMapToolStripMenuItem.Name = "newMapToolStripMenuItem";
            this.newMapToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newMapToolStripMenuItem.Text = "New";
            this.newMapToolStripMenuItem.Click += new System.EventHandler(this.newMap_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // saveStripMenuItem
            // 
            this.saveStripMenuItem.Name = "saveStripMenuItem";
            this.saveStripMenuItem.Size = new System.Drawing.Size(54, 26);
            this.saveStripMenuItem.Text = "Save";
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.mainEditorPanel, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.leftSideTableLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 30);
            this.mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(900, 470);
            this.mainTableLayoutPanel.TabIndex = 3;
            // 
            // leftSideTableLayoutPanel
            // 
            this.leftSideTableLayoutPanel.ColumnCount = 1;
            this.leftSideTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftSideTableLayoutPanel.Controls.Add(this.panel2, 0, 1);
            this.leftSideTableLayoutPanel.Controls.Add(this.panel1, 0, 0);
            this.leftSideTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftSideTableLayoutPanel.Location = new System.Drawing.Point(4, 4);
            this.leftSideTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.leftSideTableLayoutPanel.Name = "leftSideTableLayoutPanel";
            this.leftSideTableLayoutPanel.RowCount = 2;
            this.leftSideTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftSideTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftSideTableLayoutPanel.Size = new System.Drawing.Size(392, 462);
            this.leftSideTableLayoutPanel.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mouseXStatus,
            this.mouseYStatus,
            this.camZoomStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 474);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(900, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip";
            // 
            // mouseXStatus
            // 
            this.mouseXStatus.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mouseXStatus.Name = "mouseXStatus";
            this.mouseXStatus.Size = new System.Drawing.Size(26, 20);
            this.mouseXStatus.Text = "X:";
            // 
            // mouseYStatus
            // 
            this.mouseYStatus.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mouseYStatus.Margin = new System.Windows.Forms.Padding(20, 4, 0, 2);
            this.mouseYStatus.Name = "mouseYStatus";
            this.mouseYStatus.Size = new System.Drawing.Size(26, 20);
            this.mouseYStatus.Text = "Y:";
            // 
            // camZoomStatus
            // 
            this.camZoomStatus.Margin = new System.Windows.Forms.Padding(20, 4, 0, 2);
            this.camZoomStatus.Name = "camZoomStatus";
            this.camZoomStatus.Size = new System.Drawing.Size(52, 20);
            this.camZoomStatus.Text = "Zoom:";
            this.camZoomStatus.Click += new System.EventHandler(this.CamZoomStatus_Click);
            this.camZoomStatus.MouseEnter += new System.EventHandler(this.HighlightStatus_mouseEnter);
            this.camZoomStatus.MouseLeave += new System.EventHandler(this.UnHighlightStatus_mouseExit);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tilePanelLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 225);
            this.panel1.TabIndex = 0;
            // 
            // tilePanelLabel
            // 
            this.tilePanelLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tilePanelLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tilePanelLabel.Location = new System.Drawing.Point(0, 0);
            this.tilePanelLabel.Name = "tilePanelLabel";
            this.tilePanelLabel.Size = new System.Drawing.Size(386, 16);
            this.tilePanelLabel.TabIndex = 0;
            this.tilePanelLabel.Text = "Tiles";
            this.tilePanelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.editPanelLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 234);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 225);
            this.panel2.TabIndex = 1;
            // 
            // editPanelLabel
            // 
            this.editPanelLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.editPanelLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPanelLabel.Location = new System.Drawing.Point(0, 0);
            this.editPanelLabel.Name = "editPanelLabel";
            this.editPanelLabel.Size = new System.Drawing.Size(386, 16);
            this.editPanelLabel.TabIndex = 0;
            this.editPanelLabel.Text = "Edit";
            this.editPanelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mainEditorPanel
            // 
            this.mainEditorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mainEditorPanel.CurrentMode = Railgun.Editor.App.Controls.EditorMode.Placing;
            this.mainEditorPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mainEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainEditorPanel.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainEditorPanel.ForeColor = System.Drawing.Color.White;
            this.mainEditorPanel.Location = new System.Drawing.Point(404, 4);
            this.mainEditorPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainEditorPanel.MouseHoverUpdatesOnly = false;
            this.mainEditorPanel.Name = "mainEditorPanel";
            this.mainEditorPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainEditorPanel.Size = new System.Drawing.Size(492, 462);
            this.mainEditorPanel.TabIndex = 0;
            this.mainEditorPanel.Text = "mainEditorPanel";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.leftSideTableLayoutPanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private Controls.MainEditorPanel mainEditorPanel;
        private System.Windows.Forms.TableLayoutPanel leftSideTableLayoutPanel;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel mouseXStatus;
        private System.Windows.Forms.ToolStripStatusLabel mouseYStatus;
        private System.Windows.Forms.ToolStripStatusLabel camZoomStatus;
        private System.Windows.Forms.ToolStripMenuItem logoToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label editPanelLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label tilePanelLabel;
    }
}