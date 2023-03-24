namespace Railgun.Editor.App
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.toolStripMenuItem_Logo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_New = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Rotate90CW = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Rotate90CCW = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FlipHorizontally = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FlipVertically = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Deselect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_View = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ResetZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ResetCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Maximize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Minimize = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_LabelX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ValueX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_LabelY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ValueY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_LabelZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ValueZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer_MainEditor = new System.Windows.Forms.SplitContainer();
            this.splitContainer_LeftSideBar = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel_Objects = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Objects = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_TilePicker = new System.Windows.Forms.TableLayoutPanel();
            this.tilePicker = new Railgun.Editor.App.Controls.TilePicker();
            this.panel_TileSettings = new System.Windows.Forms.Panel();
            this.label_TileSize = new System.Windows.Forms.Label();
            this.textBox_TileSize = new System.Windows.Forms.TextBox();
            this.label_Objects = new System.Windows.Forms.Label();
            this.tableLayoutPanel_Edit = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Edit = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_EditTable = new System.Windows.Forms.TableLayoutPanel();
            this.currentTileContol = new Railgun.Editor.App.Controls.CurrentTileDisplay();
            this.label_Edit = new System.Windows.Forms.Label();
            this.mapEditor = new Railgun.Editor.App.Controls.MapEditor();
            this.tableLayoutPanel_MainOutline = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MainEditor)).BeginInit();
            this.splitContainer_MainEditor.Panel1.SuspendLayout();
            this.splitContainer_MainEditor.Panel2.SuspendLayout();
            this.splitContainer_MainEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_LeftSideBar)).BeginInit();
            this.splitContainer_LeftSideBar.Panel1.SuspendLayout();
            this.splitContainer_LeftSideBar.Panel2.SuspendLayout();
            this.splitContainer_LeftSideBar.SuspendLayout();
            this.tableLayoutPanel_Objects.SuspendLayout();
            this.panel_Objects.SuspendLayout();
            this.tableLayoutPanel_TilePicker.SuspendLayout();
            this.panel_TileSettings.SuspendLayout();
            this.tableLayoutPanel_Edit.SuspendLayout();
            this.panel_Edit.SuspendLayout();
            this.tableLayoutPanel_EditTable.SuspendLayout();
            this.tableLayoutPanel_MainOutline.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Logo,
            this.toolStripMenuItem_File,
            this.toolStripMenuItem_Edit,
            this.toolStripMenuItem_View,
            this.toolStripMenuItem_Help,
            this.toolStripMenuItem_Exit,
            this.toolStripMenuItem_Maximize,
            this.toolStripMenuItem_Minimize});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 0);
            this.menuStrip.Size = new System.Drawing.Size(1007, 41);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            this.menuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuStrip_MouseDown);
            // 
            // toolStripMenuItem_Logo
            // 
            this.toolStripMenuItem_Logo.AutoSize = false;
            this.toolStripMenuItem_Logo.Enabled = false;
            this.toolStripMenuItem_Logo.Image = global::Railgun.Editor.Properties.Resources.Logo;
            this.toolStripMenuItem_Logo.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.toolStripMenuItem_Logo.Name = "toolStripMenuItem_Logo";
            this.toolStripMenuItem_Logo.Size = new System.Drawing.Size(36, 36);
            // 
            // toolStripMenuItem_File
            // 
            this.toolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_New,
            this.toolStripMenuItem_Open,
            this.toolStripMenuItem_Save,
            this.toolStripMenuItem_SaveAs,
            this.toolStripMenuItem_Export});
            this.toolStripMenuItem_File.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.toolStripMenuItem_File.Name = "toolStripMenuItem_File";
            this.toolStripMenuItem_File.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem_File.Text = "File";
            // 
            // toolStripMenuItem_New
            // 
            this.toolStripMenuItem_New.Name = "toolStripMenuItem_New";
            this.toolStripMenuItem_New.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItem_New.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem_New.Text = "New";
            // 
            // toolStripMenuItem_Open
            // 
            this.toolStripMenuItem_Open.Name = "toolStripMenuItem_Open";
            this.toolStripMenuItem_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItem_Open.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem_Open.Text = "Open";
            // 
            // toolStripMenuItem_Save
            // 
            this.toolStripMenuItem_Save.Name = "toolStripMenuItem_Save";
            this.toolStripMenuItem_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem_Save.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem_Save.Text = "Save";
            // 
            // toolStripMenuItem_SaveAs
            // 
            this.toolStripMenuItem_SaveAs.Name = "toolStripMenuItem_SaveAs";
            this.toolStripMenuItem_SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem_SaveAs.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem_SaveAs.Text = "Save As";
            // 
            // toolStripMenuItem_Export
            // 
            this.toolStripMenuItem_Export.Name = "toolStripMenuItem_Export";
            this.toolStripMenuItem_Export.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem_Export.Text = "Export";
            // 
            // toolStripMenuItem_Edit
            // 
            this.toolStripMenuItem_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Rotate90CW,
            this.toolStripMenuItem_Rotate90CCW,
            this.toolStripMenuItem_FlipHorizontally,
            this.toolStripMenuItem_FlipVertically,
            this.toolStripMenuItem_Deselect,
            this.toolStripMenuItem_Delete});
            this.toolStripMenuItem_Edit.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.toolStripMenuItem_Edit.Name = "toolStripMenuItem_Edit";
            this.toolStripMenuItem_Edit.Size = new System.Drawing.Size(39, 20);
            this.toolStripMenuItem_Edit.Text = "Edit";
            // 
            // toolStripMenuItem_Rotate90CW
            // 
            this.toolStripMenuItem_Rotate90CW.Name = "toolStripMenuItem_Rotate90CW";
            this.toolStripMenuItem_Rotate90CW.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem_Rotate90CW.Text = "Rotate 90 CW";
            // 
            // toolStripMenuItem_Rotate90CCW
            // 
            this.toolStripMenuItem_Rotate90CCW.Name = "toolStripMenuItem_Rotate90CCW";
            this.toolStripMenuItem_Rotate90CCW.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem_Rotate90CCW.Text = "Rotate 90 CCW";
            // 
            // toolStripMenuItem_FlipHorizontally
            // 
            this.toolStripMenuItem_FlipHorizontally.Name = "toolStripMenuItem_FlipHorizontally";
            this.toolStripMenuItem_FlipHorizontally.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem_FlipHorizontally.Text = "Flip Horizontally";
            // 
            // toolStripMenuItem_FlipVertically
            // 
            this.toolStripMenuItem_FlipVertically.Name = "toolStripMenuItem_FlipVertically";
            this.toolStripMenuItem_FlipVertically.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem_FlipVertically.Text = "Flip Vertically";
            // 
            // toolStripMenuItem_Deselect
            // 
            this.toolStripMenuItem_Deselect.Name = "toolStripMenuItem_Deselect";
            this.toolStripMenuItem_Deselect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.toolStripMenuItem_Deselect.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem_Deselect.Text = "Deselect";
            // 
            // toolStripMenuItem_Delete
            // 
            this.toolStripMenuItem_Delete.Name = "toolStripMenuItem_Delete";
            this.toolStripMenuItem_Delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.toolStripMenuItem_Delete.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem_Delete.Text = "Delete";
            // 
            // toolStripMenuItem_View
            // 
            this.toolStripMenuItem_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ResetZoom,
            this.toolStripMenuItem_ResetCamera});
            this.toolStripMenuItem_View.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.toolStripMenuItem_View.Name = "toolStripMenuItem_View";
            this.toolStripMenuItem_View.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem_View.Text = "View";
            // 
            // toolStripMenuItem_ResetZoom
            // 
            this.toolStripMenuItem_ResetZoom.Name = "toolStripMenuItem_ResetZoom";
            this.toolStripMenuItem_ResetZoom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D0)));
            this.toolStripMenuItem_ResetZoom.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem_ResetZoom.Text = "Reset Zoom";
            this.toolStripMenuItem_ResetZoom.Click += new System.EventHandler(this.ResetZoom_Click);
            // 
            // toolStripMenuItem_ResetCamera
            // 
            this.toolStripMenuItem_ResetCamera.Name = "toolStripMenuItem_ResetCamera";
            this.toolStripMenuItem_ResetCamera.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.toolStripMenuItem_ResetCamera.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem_ResetCamera.Text = "Reset Camera";
            this.toolStripMenuItem_ResetCamera.Click += new System.EventHandler(this.ResetCamera_Click);
            // 
            // toolStripMenuItem_Help
            // 
            this.toolStripMenuItem_Help.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.toolStripMenuItem_Help.Name = "toolStripMenuItem_Help";
            this.toolStripMenuItem_Help.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem_Help.Text = "Help";
            // 
            // toolStripMenuItem_Exit
            // 
            this.toolStripMenuItem_Exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem_Exit.AutoSize = false;
            this.toolStripMenuItem_Exit.Image = global::Railgun.Editor.Properties.Resources.Exit;
            this.toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
            this.toolStripMenuItem_Exit.Size = new System.Drawing.Size(45, 40);
            this.toolStripMenuItem_Exit.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_Maximize
            // 
            this.toolStripMenuItem_Maximize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem_Maximize.AutoSize = false;
            this.toolStripMenuItem_Maximize.Image = global::Railgun.Editor.Properties.Resources.Maximize;
            this.toolStripMenuItem_Maximize.Name = "toolStripMenuItem_Maximize";
            this.toolStripMenuItem_Maximize.Size = new System.Drawing.Size(45, 40);
            this.toolStripMenuItem_Maximize.Click += new System.EventHandler(this.MaximizeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_Minimize
            // 
            this.toolStripMenuItem_Minimize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem_Minimize.AutoSize = false;
            this.toolStripMenuItem_Minimize.Image = global::Railgun.Editor.Properties.Resources.Minimize;
            this.toolStripMenuItem_Minimize.Name = "toolStripMenuItem_Minimize";
            this.toolStripMenuItem_Minimize.Size = new System.Drawing.Size(45, 40);
            this.toolStripMenuItem_Minimize.Click += new System.EventHandler(this.MinimizeToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_LabelX,
            this.toolStripStatusLabel_ValueX,
            this.toolStripStatusLabel_LabelY,
            this.toolStripStatusLabel_ValueY,
            this.toolStripStatusLabel_LabelZoom,
            this.toolStripStatusLabel_ValueZoom});
            this.statusStrip.Location = new System.Drawing.Point(0, 662);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip.Size = new System.Drawing.Size(1007, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel_LabelX
            // 
            this.toolStripStatusLabel_LabelX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabel_LabelX.Name = "toolStripStatusLabel_LabelX";
            this.toolStripStatusLabel_LabelX.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel_LabelX.Text = "X:";
            // 
            // toolStripStatusLabel_ValueX
            // 
            this.toolStripStatusLabel_ValueX.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel_ValueX.Name = "toolStripStatusLabel_ValueX";
            this.toolStripStatusLabel_ValueX.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel_ValueX.Text = "000";
            // 
            // toolStripStatusLabel_LabelY
            // 
            this.toolStripStatusLabel_LabelY.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabel_LabelY.Margin = new System.Windows.Forms.Padding(20, 4, 0, 2);
            this.toolStripStatusLabel_LabelY.Name = "toolStripStatusLabel_LabelY";
            this.toolStripStatusLabel_LabelY.Size = new System.Drawing.Size(17, 16);
            this.toolStripStatusLabel_LabelY.Text = "Y:";
            // 
            // toolStripStatusLabel_ValueY
            // 
            this.toolStripStatusLabel_ValueY.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel_ValueY.Name = "toolStripStatusLabel_ValueY";
            this.toolStripStatusLabel_ValueY.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel_ValueY.Text = "000";
            // 
            // toolStripStatusLabel_LabelZoom
            // 
            this.toolStripStatusLabel_LabelZoom.Margin = new System.Windows.Forms.Padding(20, 4, 0, 2);
            this.toolStripStatusLabel_LabelZoom.Name = "toolStripStatusLabel_LabelZoom";
            this.toolStripStatusLabel_LabelZoom.Size = new System.Drawing.Size(42, 16);
            this.toolStripStatusLabel_LabelZoom.Text = "Zoom:";
            this.toolStripStatusLabel_LabelZoom.ToolTipText = "Reset Camera Zoom";
            // 
            // toolStripStatusLabel_ValueZoom
            // 
            this.toolStripStatusLabel_ValueZoom.Font = new System.Drawing.Font("Courier New", 9F);
            this.toolStripStatusLabel_ValueZoom.Name = "toolStripStatusLabel_ValueZoom";
            this.toolStripStatusLabel_ValueZoom.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel_ValueZoom.Text = "0.00";
            this.toolStripStatusLabel_ValueZoom.ToolTipText = "Reset Camera Zoom";
            this.toolStripStatusLabel_ValueZoom.Click += new System.EventHandler(this.ResetZoom_Click);
            this.toolStripStatusLabel_ValueZoom.MouseEnter += new System.EventHandler(this.HighlightStatus_mouseEnter);
            this.toolStripStatusLabel_ValueZoom.MouseLeave += new System.EventHandler(this.UnHighlightStatus_mouseExit);
            // 
            // splitContainer_MainEditor
            // 
            this.splitContainer_MainEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_MainEditor.Location = new System.Drawing.Point(0, 3);
            this.splitContainer_MainEditor.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.splitContainer_MainEditor.Name = "splitContainer_MainEditor";
            // 
            // splitContainer_MainEditor.Panel1
            // 
            this.splitContainer_MainEditor.Panel1.Controls.Add(this.splitContainer_LeftSideBar);
            this.splitContainer_MainEditor.Panel1MinSize = 200;
            // 
            // splitContainer_MainEditor.Panel2
            // 
            this.splitContainer_MainEditor.Panel2.Controls.Add(this.mapEditor);
            this.splitContainer_MainEditor.Panel2MinSize = 400;
            this.splitContainer_MainEditor.Size = new System.Drawing.Size(1007, 615);
            this.splitContainer_MainEditor.SplitterDistance = 294;
            this.splitContainer_MainEditor.SplitterWidth = 3;
            this.splitContainer_MainEditor.TabIndex = 5;
            // 
            // splitContainer_LeftSideBar
            // 
            this.splitContainer_LeftSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_LeftSideBar.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_LeftSideBar.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer_LeftSideBar.Name = "splitContainer_LeftSideBar";
            this.splitContainer_LeftSideBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_LeftSideBar.Panel1
            // 
            this.splitContainer_LeftSideBar.Panel1.Controls.Add(this.tableLayoutPanel_Objects);
            this.splitContainer_LeftSideBar.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer_LeftSideBar.Panel2
            // 
            this.splitContainer_LeftSideBar.Panel2.Controls.Add(this.tableLayoutPanel_Edit);
            this.splitContainer_LeftSideBar.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer_LeftSideBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer_LeftSideBar.Size = new System.Drawing.Size(294, 615);
            this.splitContainer_LeftSideBar.SplitterDistance = 298;
            this.splitContainer_LeftSideBar.SplitterWidth = 3;
            this.splitContainer_LeftSideBar.TabIndex = 0;
            // 
            // tableLayoutPanel_Objects
            // 
            this.tableLayoutPanel_Objects.ColumnCount = 1;
            this.tableLayoutPanel_Objects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Objects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel_Objects.Controls.Add(this.panel_Objects, 0, 1);
            this.tableLayoutPanel_Objects.Controls.Add(this.label_Objects, 0, 0);
            this.tableLayoutPanel_Objects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Objects.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Objects.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel_Objects.Name = "tableLayoutPanel_Objects";
            this.tableLayoutPanel_Objects.RowCount = 2;
            this.tableLayoutPanel_Objects.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel_Objects.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Objects.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel_Objects.Size = new System.Drawing.Size(294, 298);
            this.tableLayoutPanel_Objects.TabIndex = 6;
            // 
            // panel_Objects
            // 
            this.panel_Objects.Controls.Add(this.tableLayoutPanel_TilePicker);
            this.panel_Objects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Objects.Location = new System.Drawing.Point(0, 16);
            this.panel_Objects.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Objects.Name = "panel_Objects";
            this.panel_Objects.Size = new System.Drawing.Size(294, 282);
            this.panel_Objects.TabIndex = 4;
            // 
            // tableLayoutPanel_TilePicker
            // 
            this.tableLayoutPanel_TilePicker.ColumnCount = 1;
            this.tableLayoutPanel_TilePicker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_TilePicker.Controls.Add(this.tilePicker, 0, 1);
            this.tableLayoutPanel_TilePicker.Controls.Add(this.panel_TileSettings, 0, 0);
            this.tableLayoutPanel_TilePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_TilePicker.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_TilePicker.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_TilePicker.Name = "tableLayoutPanel_TilePicker";
            this.tableLayoutPanel_TilePicker.RowCount = 2;
            this.tableLayoutPanel_TilePicker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel_TilePicker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_TilePicker.Size = new System.Drawing.Size(294, 282);
            this.tableLayoutPanel_TilePicker.TabIndex = 1;
            // 
            // tilePicker
            // 
            this.tilePicker.BackColor = System.Drawing.SystemColors.Control;
            this.tilePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilePicker.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold);
            this.tilePicker.ForeColor = System.Drawing.Color.Black;
            this.tilePicker.GridSize = 0F;
            this.tilePicker.Location = new System.Drawing.Point(0, 41);
            this.tilePicker.Margin = new System.Windows.Forms.Padding(0);
            this.tilePicker.MaxZoom = 0.1F;
            this.tilePicker.MinZoom = 0.1F;
            this.tilePicker.MouseHoverUpdatesOnly = false;
            this.tilePicker.Name = "tilePicker";
            this.tilePicker.Size = new System.Drawing.Size(294, 241);
            this.tilePicker.TabIndex = 1;
            this.tilePicker.Text = "tilePicker1";
            // 
            // panel_TileSettings
            // 
            this.panel_TileSettings.Controls.Add(this.label_TileSize);
            this.panel_TileSettings.Controls.Add(this.textBox_TileSize);
            this.panel_TileSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_TileSettings.Location = new System.Drawing.Point(0, 0);
            this.panel_TileSettings.Margin = new System.Windows.Forms.Padding(0);
            this.panel_TileSettings.Name = "panel_TileSettings";
            this.panel_TileSettings.Size = new System.Drawing.Size(294, 41);
            this.panel_TileSettings.TabIndex = 0;
            // 
            // label_TileSize
            // 
            this.label_TileSize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_TileSize.AutoSize = true;
            this.label_TileSize.BackColor = System.Drawing.Color.Transparent;
            this.label_TileSize.Location = new System.Drawing.Point(53, 7);
            this.label_TileSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_TileSize.Name = "label_TileSize";
            this.label_TileSize.Size = new System.Drawing.Size(50, 13);
            this.label_TileSize.TabIndex = 4;
            this.label_TileSize.Text = "Tile Size:";
            // 
            // textBox_TileSize
            // 
            this.textBox_TileSize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox_TileSize.Location = new System.Drawing.Point(115, 7);
            this.textBox_TileSize.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_TileSize.Name = "textBox_TileSize";
            this.textBox_TileSize.Size = new System.Drawing.Size(32, 20);
            this.textBox_TileSize.TabIndex = 3;
            this.textBox_TileSize.TextChanged += new System.EventHandler(this.TileSize_TextChanged);
            this.textBox_TileSize.Leave += new System.EventHandler(this.TileSize_Leave);
            // 
            // label_Objects
            // 
            this.label_Objects.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Objects.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_Objects.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Objects.Location = new System.Drawing.Point(0, 0);
            this.label_Objects.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label_Objects.Name = "label_Objects";
            this.label_Objects.Size = new System.Drawing.Size(294, 13);
            this.label_Objects.TabIndex = 3;
            this.label_Objects.Text = "Objects";
            this.label_Objects.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel_Edit
            // 
            this.tableLayoutPanel_Edit.ColumnCount = 1;
            this.tableLayoutPanel_Edit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Edit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel_Edit.Controls.Add(this.panel_Edit, 0, 1);
            this.tableLayoutPanel_Edit.Controls.Add(this.label_Edit, 0, 0);
            this.tableLayoutPanel_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Edit.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Edit.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel_Edit.Name = "tableLayoutPanel_Edit";
            this.tableLayoutPanel_Edit.RowCount = 2;
            this.tableLayoutPanel_Edit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel_Edit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Edit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel_Edit.Size = new System.Drawing.Size(294, 314);
            this.tableLayoutPanel_Edit.TabIndex = 7;
            // 
            // panel_Edit
            // 
            this.panel_Edit.Controls.Add(this.tableLayoutPanel_EditTable);
            this.panel_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Edit.Location = new System.Drawing.Point(0, 16);
            this.panel_Edit.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Edit.Name = "panel_Edit";
            this.panel_Edit.Size = new System.Drawing.Size(294, 298);
            this.panel_Edit.TabIndex = 5;
            // 
            // tableLayoutPanel_EditTable
            // 
            this.tableLayoutPanel_EditTable.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel_EditTable.ColumnCount = 3;
            this.tableLayoutPanel_EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel_EditTable.Controls.Add(this.currentTileContol, 1, 1);
            this.tableLayoutPanel_EditTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_EditTable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel_EditTable.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_EditTable.Name = "tableLayoutPanel_EditTable";
            this.tableLayoutPanel_EditTable.RowCount = 3;
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel_EditTable.Size = new System.Drawing.Size(294, 298);
            this.tableLayoutPanel_EditTable.TabIndex = 0;
            // 
            // currentTileContol
            // 
            this.currentTileContol.BackColor = System.Drawing.SystemColors.Control;
            this.currentTileContol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentTileContol.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold);
            this.currentTileContol.ForeColor = System.Drawing.Color.Black;
            this.currentTileContol.Location = new System.Drawing.Point(98, 100);
            this.currentTileContol.Margin = new System.Windows.Forms.Padding(2);
            this.currentTileContol.Name = "currentTileContol";
            this.currentTileContol.Size = new System.Drawing.Size(96, 96);
            this.currentTileContol.TabIndex = 1;
            this.currentTileContol.Text = "currentTileContol1";
            // 
            // label_Edit
            // 
            this.label_Edit.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Edit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_Edit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Edit.Location = new System.Drawing.Point(0, 0);
            this.label_Edit.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label_Edit.Name = "label_Edit";
            this.label_Edit.Size = new System.Drawing.Size(294, 13);
            this.label_Edit.TabIndex = 4;
            this.label_Edit.Text = "Edit";
            this.label_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mapEditor
            // 
            this.mapEditor.BackColor = System.Drawing.SystemColors.Control;
            this.mapEditor.CurrentMap = null;
            this.mapEditor.CurrentTile = null;
            this.mapEditor.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mapEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapEditor.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapEditor.ForeColor = System.Drawing.Color.Black;
            this.mapEditor.GridSize = 0F;
            this.mapEditor.Location = new System.Drawing.Point(0, 0);
            this.mapEditor.Margin = new System.Windows.Forms.Padding(0, 2, 0, 4);
            this.mapEditor.MaxZoom = 0.1F;
            this.mapEditor.MinZoom = 0.1F;
            this.mapEditor.MouseHoverUpdatesOnly = false;
            this.mapEditor.Name = "mapEditor";
            this.mapEditor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mapEditor.Size = new System.Drawing.Size(710, 615);
            this.mapEditor.TabIndex = 1;
            this.mapEditor.Text = "mainEditorPanel";
            // 
            // tableLayoutPanel_MainOutline
            // 
            this.tableLayoutPanel_MainOutline.ColumnCount = 1;
            this.tableLayoutPanel_MainOutline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_MainOutline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel_MainOutline.Controls.Add(this.splitContainer_MainEditor, 0, 0);
            this.tableLayoutPanel_MainOutline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_MainOutline.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel_MainOutline.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel_MainOutline.Name = "tableLayoutPanel_MainOutline";
            this.tableLayoutPanel_MainOutline.RowCount = 1;
            this.tableLayoutPanel_MainOutline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_MainOutline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 621F));
            this.tableLayoutPanel_MainOutline.Size = new System.Drawing.Size(1007, 621);
            this.tableLayoutPanel_MainOutline.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 684);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel_MainOutline);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(700, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer_MainEditor.Panel1.ResumeLayout(false);
            this.splitContainer_MainEditor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MainEditor)).EndInit();
            this.splitContainer_MainEditor.ResumeLayout(false);
            this.splitContainer_LeftSideBar.Panel1.ResumeLayout(false);
            this.splitContainer_LeftSideBar.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_LeftSideBar)).EndInit();
            this.splitContainer_LeftSideBar.ResumeLayout(false);
            this.tableLayoutPanel_Objects.ResumeLayout(false);
            this.panel_Objects.ResumeLayout(false);
            this.tableLayoutPanel_TilePicker.ResumeLayout(false);
            this.panel_TileSettings.ResumeLayout(false);
            this.panel_TileSettings.PerformLayout();
            this.tableLayoutPanel_Edit.ResumeLayout(false);
            this.panel_Edit.ResumeLayout(false);
            this.tableLayoutPanel_EditTable.ResumeLayout(false);
            this.tableLayoutPanel_MainOutline.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_New;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Open;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Export;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SaveAs;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ValueX;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ValueY;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ValueZoom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_LabelX;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_LabelY;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_LabelZoom;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Logo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Edit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Rotate90CW;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Rotate90CCW;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_FlipHorizontally;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_FlipVertically;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_View;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ResetZoom;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ResetCamera;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Deselect;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Delete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Save;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Maximize;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Minimize;
        private System.Windows.Forms.SplitContainer splitContainer_MainEditor;
        private System.Windows.Forms.SplitContainer splitContainer_LeftSideBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Objects;
        private System.Windows.Forms.Panel panel_Objects;
        private System.Windows.Forms.Label label_Objects;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Edit;
        private System.Windows.Forms.Panel panel_Edit;
        private System.Windows.Forms.Label label_Edit;
        private Controls.MapEditor mapEditor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_MainOutline;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_TilePicker;
        private Controls.TilePicker tilePicker;
        private System.Windows.Forms.Panel panel_TileSettings;
        private System.Windows.Forms.Label label_TileSize;
        private System.Windows.Forms.TextBox textBox_TileSize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_EditTable;
        private Controls.CurrentTileDisplay currentTileContol;
    }
}