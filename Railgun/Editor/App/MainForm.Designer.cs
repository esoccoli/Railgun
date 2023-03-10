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
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate90CWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate90CCWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipVerticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maximizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainEditorPanel = new Railgun.Editor.App.Controls.MainEditorPanel();
            this.leftSideTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.editPanel = new System.Windows.Forms.Panel();
            this.editLabel = new System.Windows.Forms.Label();
            this.objectsLabel = new System.Windows.Forms.Label();
            this.objectsPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mouseXStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mouseXStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.mouseYStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mouseYStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.camZoomStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.camZoomStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.leftSideTableLayoutPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.maximizeToolStripMenuItem,
            this.minimizeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(675, 44);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            this.menuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuStrip_MouseDown);
            // 
            // logoToolStripMenuItem
            // 
            this.logoToolStripMenuItem.AutoSize = false;
            this.logoToolStripMenuItem.Enabled = false;
            this.logoToolStripMenuItem.Image = global::Railgun.Editor.Properties.Resources.railgun_transparent;
            this.logoToolStripMenuItem.Name = "logoToolStripMenuItem";
            this.logoToolStripMenuItem.Size = new System.Drawing.Size(40, 40);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 40);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newMapToolStripMenuItem
            // 
            this.newMapToolStripMenuItem.Name = "newMapToolStripMenuItem";
            this.newMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMapToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newMapToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotate90CWToolStripMenuItem,
            this.rotate90CCWToolStripMenuItem,
            this.flipHorizontallyToolStripMenuItem,
            this.flipVerticallyToolStripMenuItem,
            this.deselectToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 40);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // rotate90CWToolStripMenuItem
            // 
            this.rotate90CWToolStripMenuItem.Name = "rotate90CWToolStripMenuItem";
            this.rotate90CWToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.rotate90CWToolStripMenuItem.Text = "Rotate 90 CW";
            // 
            // rotate90CCWToolStripMenuItem
            // 
            this.rotate90CCWToolStripMenuItem.Name = "rotate90CCWToolStripMenuItem";
            this.rotate90CCWToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.rotate90CCWToolStripMenuItem.Text = "Rotate 90 CCW";
            // 
            // flipHorizontallyToolStripMenuItem
            // 
            this.flipHorizontallyToolStripMenuItem.Name = "flipHorizontallyToolStripMenuItem";
            this.flipHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.flipHorizontallyToolStripMenuItem.Text = "Flip Horizontally";
            // 
            // flipVerticallyToolStripMenuItem
            // 
            this.flipVerticallyToolStripMenuItem.Name = "flipVerticallyToolStripMenuItem";
            this.flipVerticallyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.flipVerticallyToolStripMenuItem.Text = "Flip Vertically";
            // 
            // deselectToolStripMenuItem
            // 
            this.deselectToolStripMenuItem.Name = "deselectToolStripMenuItem";
            this.deselectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.deselectToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.deselectToolStripMenuItem.Text = "Deselect";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetZoomToolStripMenuItem,
            this.resetCameraToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 40);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // resetZoomToolStripMenuItem
            // 
            this.resetZoomToolStripMenuItem.Name = "resetZoomToolStripMenuItem";
            this.resetZoomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D0)));
            this.resetZoomToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.resetZoomToolStripMenuItem.Text = "Reset Zoom";
            this.resetZoomToolStripMenuItem.Click += new System.EventHandler(this.ResetZoom_Click);
            // 
            // resetCameraToolStripMenuItem
            // 
            this.resetCameraToolStripMenuItem.Name = "resetCameraToolStripMenuItem";
            this.resetCameraToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.resetCameraToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.resetCameraToolStripMenuItem.Text = "Reset Camera";
            this.resetCameraToolStripMenuItem.Click += new System.EventHandler(this.ResetCamera_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 40);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitToolStripMenuItem.AutoSize = false;
            this.exitToolStripMenuItem.Image = global::Railgun.Editor.Properties.Resources.Exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(40, 40);
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // maximizeToolStripMenuItem
            // 
            this.maximizeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.maximizeToolStripMenuItem.AutoSize = false;
            this.maximizeToolStripMenuItem.Image = global::Railgun.Editor.Properties.Resources.Maximize;
            this.maximizeToolStripMenuItem.Name = "maximizeToolStripMenuItem";
            this.maximizeToolStripMenuItem.Size = new System.Drawing.Size(40, 40);
            this.maximizeToolStripMenuItem.Click += new System.EventHandler(this.MaximizeToolStripMenuItem_Click);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.minimizeToolStripMenuItem.AutoSize = false;
            this.minimizeToolStripMenuItem.Image = global::Railgun.Editor.Properties.Resources.Minimize;
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(40, 40);
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.MinimizeToolStripMenuItem_Click);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.mainEditorPanel, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.leftSideTableLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 44);
            this.mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(675, 362);
            this.mainTableLayoutPanel.TabIndex = 3;
            // 
            // mainEditorPanel
            // 
            this.mainEditorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.mainEditorPanel.CurrentMap = null;
            this.mainEditorPanel.CurrentMode = Railgun.Editor.App.Controls.EditorMode.Placing;
            this.mainEditorPanel.CurrentTile = null;
            this.mainEditorPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mainEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainEditorPanel.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainEditorPanel.ForeColor = System.Drawing.Color.White;
            this.mainEditorPanel.Location = new System.Drawing.Point(300, 2);
            this.mainEditorPanel.Margin = new System.Windows.Forms.Padding(0, 2, 0, 4);
            this.mainEditorPanel.MouseHoverUpdatesOnly = false;
            this.mainEditorPanel.Name = "mainEditorPanel";
            this.mainEditorPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainEditorPanel.Size = new System.Drawing.Size(375, 335);
            this.mainEditorPanel.TabIndex = 0;
            this.mainEditorPanel.Text = "mainEditorPanel";
            // 
            // leftSideTableLayoutPanel
            // 
            this.leftSideTableLayoutPanel.ColumnCount = 1;
            this.leftSideTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftSideTableLayoutPanel.Controls.Add(this.editPanel, 0, 3);
            this.leftSideTableLayoutPanel.Controls.Add(this.editLabel, 0, 2);
            this.leftSideTableLayoutPanel.Controls.Add(this.objectsLabel, 0, 0);
            this.leftSideTableLayoutPanel.Controls.Add(this.objectsPanel, 0, 1);
            this.leftSideTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftSideTableLayoutPanel.Location = new System.Drawing.Point(0, 2);
            this.leftSideTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.leftSideTableLayoutPanel.Name = "leftSideTableLayoutPanel";
            this.leftSideTableLayoutPanel.RowCount = 4;
            this.leftSideTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.leftSideTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftSideTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.leftSideTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftSideTableLayoutPanel.Size = new System.Drawing.Size(300, 337);
            this.leftSideTableLayoutPanel.TabIndex = 1;
            // 
            // editPanel
            // 
            this.editPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editPanel.Location = new System.Drawing.Point(0, 186);
            this.editPanel.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(298, 149);
            this.editPanel.TabIndex = 3;
            // 
            // editLabel
            // 
            this.editLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.editLabel.Location = new System.Drawing.Point(0, 168);
            this.editLabel.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.editLabel.Name = "editLabel";
            this.editLabel.Size = new System.Drawing.Size(298, 16);
            this.editLabel.TabIndex = 2;
            this.editLabel.Text = "Edit";
            this.editLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // objectsLabel
            // 
            this.objectsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectsLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.objectsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.objectsLabel.Location = new System.Drawing.Point(0, 0);
            this.objectsLabel.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.objectsLabel.Name = "objectsLabel";
            this.objectsLabel.Size = new System.Drawing.Size(298, 16);
            this.objectsLabel.TabIndex = 0;
            this.objectsLabel.Text = "Objects";
            this.objectsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // objectsPanel
            // 
            this.objectsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectsPanel.Location = new System.Drawing.Point(0, 18);
            this.objectsPanel.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.objectsPanel.Name = "objectsPanel";
            this.objectsPanel.Size = new System.Drawing.Size(298, 148);
            this.objectsPanel.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mouseXStatusLabel,
            this.mouseXStatus,
            this.mouseYStatusLabel,
            this.mouseYStatus,
            this.camZoomStatusLabel,
            this.camZoomStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 384);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(675, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip";
            // 
            // mouseXStatusLabel
            // 
            this.mouseXStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mouseXStatusLabel.Name = "mouseXStatusLabel";
            this.mouseXStatusLabel.Size = new System.Drawing.Size(17, 17);
            this.mouseXStatusLabel.Text = "X:";
            // 
            // mouseXStatus
            // 
            this.mouseXStatus.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mouseXStatus.Name = "mouseXStatus";
            this.mouseXStatus.Size = new System.Drawing.Size(28, 17);
            this.mouseXStatus.Text = "000";
            // 
            // mouseYStatusLabel
            // 
            this.mouseYStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mouseYStatusLabel.Margin = new System.Windows.Forms.Padding(20, 4, 0, 2);
            this.mouseYStatusLabel.Name = "mouseYStatusLabel";
            this.mouseYStatusLabel.Size = new System.Drawing.Size(17, 16);
            this.mouseYStatusLabel.Text = "Y:";
            // 
            // mouseYStatus
            // 
            this.mouseYStatus.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mouseYStatus.Name = "mouseYStatus";
            this.mouseYStatus.Size = new System.Drawing.Size(28, 17);
            this.mouseYStatus.Text = "000";
            // 
            // camZoomStatusLabel
            // 
            this.camZoomStatusLabel.Margin = new System.Windows.Forms.Padding(20, 4, 0, 2);
            this.camZoomStatusLabel.Name = "camZoomStatusLabel";
            this.camZoomStatusLabel.Size = new System.Drawing.Size(42, 16);
            this.camZoomStatusLabel.Text = "Zoom:";
            this.camZoomStatusLabel.ToolTipText = "Reset Camera Zoom";
            // 
            // camZoomStatus
            // 
            this.camZoomStatus.Font = new System.Drawing.Font("Courier New", 9F);
            this.camZoomStatus.Name = "camZoomStatus";
            this.camZoomStatus.Size = new System.Drawing.Size(35, 17);
            this.camZoomStatus.Text = "0.00";
            this.camZoomStatus.ToolTipText = "Reset Camera Zoom";
            this.camZoomStatus.Click += new System.EventHandler(this.ResetZoom_Click);
            this.camZoomStatus.MouseEnter += new System.EventHandler(this.HighlightStatus_mouseEnter);
            this.camZoomStatus.MouseLeave += new System.EventHandler(this.UnHighlightStatus_mouseExit);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 406);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(679, 409);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.leftSideTableLayoutPanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private Controls.MainEditorPanel mainEditorPanel;
        private System.Windows.Forms.TableLayoutPanel leftSideTableLayoutPanel;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel mouseXStatus;
        private System.Windows.Forms.ToolStripStatusLabel mouseYStatus;
        private System.Windows.Forms.ToolStripStatusLabel camZoomStatus;
        private System.Windows.Forms.Label objectsLabel;
        private System.Windows.Forms.Panel objectsPanel;
        private System.Windows.Forms.Label editLabel;
        private System.Windows.Forms.Panel editPanel;
        private System.Windows.Forms.ToolStripStatusLabel mouseXStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel mouseYStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel camZoomStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem logoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate90CWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate90CCWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipHorizontallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipVerticallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetZoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maximizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
    }
}