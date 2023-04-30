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
            this.toolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_New = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_PlaceHitbox = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Rotate90CW = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Rotate90CCW = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FlipHorizontally = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FlipVertically = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_MoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_MoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_MoveLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_MoveRight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Deselect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_View = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ResetZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ResetCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ShowHitboxes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ShowGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Title = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_LabelX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ValueX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_LabelY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ValueY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_LabelZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ValueZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_LabelRotation = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ValueRotation = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_LabelFlip = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ValueFlip = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Spring = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_LabelFPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ValueFPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_End = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer_MainEditor = new System.Windows.Forms.SplitContainer();
            this.splitContainer_TileEditing = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel_MainOutline = new System.Windows.Forms.TableLayoutPanel();
            this.tilePanel = new Railgun.Editor.App.Controls.TilePanel();
            this.mapPanel = new Railgun.Editor.App.Controls.MapPanel();
            this.toolStripMenuItem_Logo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Maximize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Minimize = new System.Windows.Forms.ToolStripMenuItem();
            this.editPanel = new Railgun.Editor.App.Controls.EditPanel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MainEditor)).BeginInit();
            this.splitContainer_MainEditor.Panel1.SuspendLayout();
            this.splitContainer_MainEditor.Panel2.SuspendLayout();
            this.splitContainer_MainEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_TileEditing)).BeginInit();
            this.splitContainer_TileEditing.Panel1.SuspendLayout();
            this.splitContainer_TileEditing.Panel2.SuspendLayout();
            this.splitContainer_TileEditing.SuspendLayout();
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
            this.toolStripMenuItem_Minimize,
            this.toolStripMenuItem_Title});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 1, 0, 0);
            this.menuStrip.Size = new System.Drawing.Size(1529, 45);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            this.menuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuStrip_MouseDown);
            this.menuStrip.Resize += new System.EventHandler(this.Menu_Resize);
            // 
            // toolStripMenuItem_File
            // 
            this.toolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_New,
            this.toolStripMenuItem_Open,
            this.toolStripMenuItem_Save,
            this.toolStripMenuItem_SaveAs});
            this.toolStripMenuItem_File.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.toolStripMenuItem_File.Name = "toolStripMenuItem_File";
            this.toolStripMenuItem_File.Size = new System.Drawing.Size(46, 24);
            this.toolStripMenuItem_File.Text = "File";
            // 
            // toolStripMenuItem_New
            // 
            this.toolStripMenuItem_New.Name = "toolStripMenuItem_New";
            this.toolStripMenuItem_New.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItem_New.Size = new System.Drawing.Size(233, 26);
            this.toolStripMenuItem_New.Text = "New";
            this.toolStripMenuItem_New.Click += new System.EventHandler(this.Menu_New_Click);
            // 
            // toolStripMenuItem_Open
            // 
            this.toolStripMenuItem_Open.Name = "toolStripMenuItem_Open";
            this.toolStripMenuItem_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItem_Open.Size = new System.Drawing.Size(233, 26);
            this.toolStripMenuItem_Open.Text = "Open";
            this.toolStripMenuItem_Open.Click += new System.EventHandler(this.Menu_Open_Click);
            // 
            // toolStripMenuItem_Save
            // 
            this.toolStripMenuItem_Save.Name = "toolStripMenuItem_Save";
            this.toolStripMenuItem_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem_Save.Size = new System.Drawing.Size(233, 26);
            this.toolStripMenuItem_Save.Text = "Save";
            this.toolStripMenuItem_Save.Click += new System.EventHandler(this.Menu_Save_Click);
            // 
            // toolStripMenuItem_SaveAs
            // 
            this.toolStripMenuItem_SaveAs.Name = "toolStripMenuItem_SaveAs";
            this.toolStripMenuItem_SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem_SaveAs.Size = new System.Drawing.Size(233, 26);
            this.toolStripMenuItem_SaveAs.Text = "Save As";
            this.toolStripMenuItem_SaveAs.Click += new System.EventHandler(this.Menu_SaveAs_Click);
            // 
            // toolStripMenuItem_Edit
            // 
            this.toolStripMenuItem_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_PlaceHitbox,
            this.toolStripMenuItem_Rotate90CW,
            this.toolStripMenuItem_Rotate90CCW,
            this.toolStripMenuItem_FlipHorizontally,
            this.toolStripMenuItem_FlipVertically,
            this.toolStripMenuItem_MoveUp,
            this.toolStripMenuItem_MoveDown,
            this.toolStripMenuItem_MoveLeft,
            this.toolStripMenuItem_MoveRight,
            this.toolStripMenuItem_Deselect,
            this.toolStripMenuItem_Delete});
            this.toolStripMenuItem_Edit.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.toolStripMenuItem_Edit.Name = "toolStripMenuItem_Edit";
            this.toolStripMenuItem_Edit.Size = new System.Drawing.Size(49, 24);
            this.toolStripMenuItem_Edit.Text = "Edit";
            // 
            // toolStripMenuItem_PlaceHitbox
            // 
            this.toolStripMenuItem_PlaceHitbox.CheckOnClick = true;
            this.toolStripMenuItem_PlaceHitbox.Name = "toolStripMenuItem_PlaceHitbox";
            this.toolStripMenuItem_PlaceHitbox.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem_PlaceHitbox.Text = "Place Hitbox";
            this.toolStripMenuItem_PlaceHitbox.CheckedChanged += new System.EventHandler(this.Menu_Edit_Solid_CheckedChanged);
            // 
            // toolStripMenuItem_Rotate90CW
            // 
            this.toolStripMenuItem_Rotate90CW.Name = "toolStripMenuItem_Rotate90CW";
            this.toolStripMenuItem_Rotate90CW.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem_Rotate90CW.Text = "Rotate 90 CW";
            this.toolStripMenuItem_Rotate90CW.Click += new System.EventHandler(this.Menu_Edit_Rotate90CW_Click);
            // 
            // toolStripMenuItem_Rotate90CCW
            // 
            this.toolStripMenuItem_Rotate90CCW.Name = "toolStripMenuItem_Rotate90CCW";
            this.toolStripMenuItem_Rotate90CCW.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem_Rotate90CCW.Text = "Rotate 90 CCW";
            this.toolStripMenuItem_Rotate90CCW.Click += new System.EventHandler(this.Menu_Edit_Rotate90CCW_Click);
            // 
            // toolStripMenuItem_FlipHorizontally
            // 
            this.toolStripMenuItem_FlipHorizontally.Name = "toolStripMenuItem_FlipHorizontally";
            this.toolStripMenuItem_FlipHorizontally.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.toolStripMenuItem_FlipHorizontally.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem_FlipHorizontally.Text = "Flip Horizontally";
            this.toolStripMenuItem_FlipHorizontally.Click += new System.EventHandler(this.Menu_Edit_FlipHorizontally_Click);
            // 
            // toolStripMenuItem_FlipVertically
            // 
            this.toolStripMenuItem_FlipVertically.Name = "toolStripMenuItem_FlipVertically";
            this.toolStripMenuItem_FlipVertically.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.toolStripMenuItem_FlipVertically.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem_FlipVertically.Text = "Flip Vertically";
            this.toolStripMenuItem_FlipVertically.Click += new System.EventHandler(this.Menu_Edit_FlipVertically_Click);
            // 
            // toolStripMenuItem_MoveUp
            // 
            this.toolStripMenuItem_MoveUp.Enabled = false;
            this.toolStripMenuItem_MoveUp.Name = "toolStripMenuItem_MoveUp";
            this.toolStripMenuItem_MoveUp.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem_MoveUp.Text = "Move Up";
            this.toolStripMenuItem_MoveUp.Click += new System.EventHandler(this.Menu_Edit_MoveUp_Click);
            // 
            // toolStripMenuItem_MoveDown
            // 
            this.toolStripMenuItem_MoveDown.Enabled = false;
            this.toolStripMenuItem_MoveDown.Name = "toolStripMenuItem_MoveDown";
            this.toolStripMenuItem_MoveDown.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem_MoveDown.Text = "Move Down";
            this.toolStripMenuItem_MoveDown.Click += new System.EventHandler(this.Menu_Edit_MoveDown_Click);
            // 
            // toolStripMenuItem_MoveLeft
            // 
            this.toolStripMenuItem_MoveLeft.Enabled = false;
            this.toolStripMenuItem_MoveLeft.Name = "toolStripMenuItem_MoveLeft";
            this.toolStripMenuItem_MoveLeft.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem_MoveLeft.Text = "Move Left";
            this.toolStripMenuItem_MoveLeft.Click += new System.EventHandler(this.Menu_Edit_MoveLeft_Click);
            // 
            // toolStripMenuItem_MoveRight
            // 
            this.toolStripMenuItem_MoveRight.Enabled = false;
            this.toolStripMenuItem_MoveRight.Name = "toolStripMenuItem_MoveRight";
            this.toolStripMenuItem_MoveRight.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem_MoveRight.Text = "Move Right";
            this.toolStripMenuItem_MoveRight.Click += new System.EventHandler(this.Menu_Edit_MoveRight_Click);
            // 
            // toolStripMenuItem_Deselect
            // 
            this.toolStripMenuItem_Deselect.Enabled = false;
            this.toolStripMenuItem_Deselect.Name = "toolStripMenuItem_Deselect";
            this.toolStripMenuItem_Deselect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.toolStripMenuItem_Deselect.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem_Deselect.Text = "Deselect";
            // 
            // toolStripMenuItem_Delete
            // 
            this.toolStripMenuItem_Delete.Enabled = false;
            this.toolStripMenuItem_Delete.Name = "toolStripMenuItem_Delete";
            this.toolStripMenuItem_Delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.toolStripMenuItem_Delete.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem_Delete.Text = "Delete";
            // 
            // toolStripMenuItem_View
            // 
            this.toolStripMenuItem_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ResetZoom,
            this.toolStripMenuItem_ResetCamera,
            this.toolStripMenuItem_ShowHitboxes,
            this.toolStripMenuItem_ShowGrid});
            this.toolStripMenuItem_View.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.toolStripMenuItem_View.Name = "toolStripMenuItem_View";
            this.toolStripMenuItem_View.Size = new System.Drawing.Size(55, 24);
            this.toolStripMenuItem_View.Text = "View";
            // 
            // toolStripMenuItem_ResetZoom
            // 
            this.toolStripMenuItem_ResetZoom.Name = "toolStripMenuItem_ResetZoom";
            this.toolStripMenuItem_ResetZoom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D0)));
            this.toolStripMenuItem_ResetZoom.Size = new System.Drawing.Size(233, 26);
            this.toolStripMenuItem_ResetZoom.Text = "Reset Zoom";
            this.toolStripMenuItem_ResetZoom.Click += new System.EventHandler(this.Menu_View_ResetZoom_Click);
            // 
            // toolStripMenuItem_ResetCamera
            // 
            this.toolStripMenuItem_ResetCamera.Name = "toolStripMenuItem_ResetCamera";
            this.toolStripMenuItem_ResetCamera.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.toolStripMenuItem_ResetCamera.Size = new System.Drawing.Size(233, 26);
            this.toolStripMenuItem_ResetCamera.Text = "Reset Camera";
            this.toolStripMenuItem_ResetCamera.Click += new System.EventHandler(this.Menu_View_ResetCamera_Click);
            // 
            // toolStripMenuItem_ShowHitboxes
            // 
            this.toolStripMenuItem_ShowHitboxes.CheckOnClick = true;
            this.toolStripMenuItem_ShowHitboxes.Name = "toolStripMenuItem_ShowHitboxes";
            this.toolStripMenuItem_ShowHitboxes.Size = new System.Drawing.Size(233, 26);
            this.toolStripMenuItem_ShowHitboxes.Text = "Show Hitboxes";
            this.toolStripMenuItem_ShowHitboxes.CheckedChanged += new System.EventHandler(this.Menu_View_ShowHitboxes_CheckedChanged);
            // 
            // toolStripMenuItem_ShowGrid
            // 
            this.toolStripMenuItem_ShowGrid.CheckOnClick = true;
            this.toolStripMenuItem_ShowGrid.Name = "toolStripMenuItem_ShowGrid";
            this.toolStripMenuItem_ShowGrid.Size = new System.Drawing.Size(233, 26);
            this.toolStripMenuItem_ShowGrid.Text = "Show Grid";
            this.toolStripMenuItem_ShowGrid.CheckedChanged += new System.EventHandler(this.Menu_View_ShowGrid_CheckedChanged);
            // 
            // toolStripMenuItem_Help
            // 
            this.toolStripMenuItem_Help.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.toolStripMenuItem_Help.Name = "toolStripMenuItem_Help";
            this.toolStripMenuItem_Help.Size = new System.Drawing.Size(55, 24);
            this.toolStripMenuItem_Help.Text = "Help";
            this.toolStripMenuItem_Help.Click += new System.EventHandler(this.ToolStripMenuItem_Help_Click);
            // 
            // toolStripMenuItem_Title
            // 
            this.toolStripMenuItem_Title.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem_Title.CheckOnClick = true;
            this.toolStripMenuItem_Title.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripMenuItem_Title.Margin = new System.Windows.Forms.Padding(0, 10, 300, 10);
            this.toolStripMenuItem_Title.Name = "toolStripMenuItem_Title";
            this.toolStripMenuItem_Title.Padding = new System.Windows.Forms.Padding(0);
            this.toolStripMenuItem_Title.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripMenuItem_Title.Size = new System.Drawing.Size(100, 24);
            this.toolStripMenuItem_Title.Text = "Untitled Map";
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
            this.toolStripStatusLabel_ValueZoom,
            this.toolStripStatusLabel_LabelRotation,
            this.toolStripStatusLabel_ValueRotation,
            this.toolStripStatusLabel_LabelFlip,
            this.toolStripStatusLabel_ValueFlip,
            this.toolStripStatusLabel_Spring,
            this.toolStripStatusLabel_LabelFPS,
            this.toolStripStatusLabel_ValueFPS,
            this.toolStripStatusLabel_End});
            this.statusStrip.Location = new System.Drawing.Point(0, 1058);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip.Size = new System.Drawing.Size(1529, 26);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel_LabelX
            // 
            this.toolStripStatusLabel_LabelX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabel_LabelX.Name = "toolStripStatusLabel_LabelX";
            this.toolStripStatusLabel_LabelX.Size = new System.Drawing.Size(69, 20);
            this.toolStripStatusLabel_LabelX.Text = "Mouse X:";
            // 
            // toolStripStatusLabel_ValueX
            // 
            this.toolStripStatusLabel_ValueX.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel_ValueX.Name = "toolStripStatusLabel_ValueX";
            this.toolStripStatusLabel_ValueX.Size = new System.Drawing.Size(35, 20);
            this.toolStripStatusLabel_ValueX.Text = "000";
            // 
            // toolStripStatusLabel_LabelY
            // 
            this.toolStripStatusLabel_LabelY.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabel_LabelY.Margin = new System.Windows.Forms.Padding(20, 4, 0, 2);
            this.toolStripStatusLabel_LabelY.Name = "toolStripStatusLabel_LabelY";
            this.toolStripStatusLabel_LabelY.Size = new System.Drawing.Size(68, 20);
            this.toolStripStatusLabel_LabelY.Text = "Mouse Y:";
            // 
            // toolStripStatusLabel_ValueY
            // 
            this.toolStripStatusLabel_ValueY.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel_ValueY.Name = "toolStripStatusLabel_ValueY";
            this.toolStripStatusLabel_ValueY.Size = new System.Drawing.Size(35, 20);
            this.toolStripStatusLabel_ValueY.Text = "000";
            // 
            // toolStripStatusLabel_LabelZoom
            // 
            this.toolStripStatusLabel_LabelZoom.Margin = new System.Windows.Forms.Padding(20, 4, 0, 2);
            this.toolStripStatusLabel_LabelZoom.Name = "toolStripStatusLabel_LabelZoom";
            this.toolStripStatusLabel_LabelZoom.Size = new System.Drawing.Size(52, 20);
            this.toolStripStatusLabel_LabelZoom.Text = "Zoom:";
            // 
            // toolStripStatusLabel_ValueZoom
            // 
            this.toolStripStatusLabel_ValueZoom.Font = new System.Drawing.Font("Courier New", 9F);
            this.toolStripStatusLabel_ValueZoom.Name = "toolStripStatusLabel_ValueZoom";
            this.toolStripStatusLabel_ValueZoom.Size = new System.Drawing.Size(44, 20);
            this.toolStripStatusLabel_ValueZoom.Text = "0.00";
            this.toolStripStatusLabel_ValueZoom.ToolTipText = "Reset Camera Zoom";
            this.toolStripStatusLabel_ValueZoom.Click += new System.EventHandler(this.Menu_View_ResetZoom_Click);
            this.toolStripStatusLabel_ValueZoom.MouseEnter += new System.EventHandler(this.HighlightStatus_mouseEnter);
            this.toolStripStatusLabel_ValueZoom.MouseLeave += new System.EventHandler(this.UnHighlightStatus_mouseExit);
            // 
            // toolStripStatusLabel_LabelRotation
            // 
            this.toolStripStatusLabel_LabelRotation.Margin = new System.Windows.Forms.Padding(20, 4, 0, 2);
            this.toolStripStatusLabel_LabelRotation.Name = "toolStripStatusLabel_LabelRotation";
            this.toolStripStatusLabel_LabelRotation.Size = new System.Drawing.Size(121, 20);
            this.toolStripStatusLabel_LabelRotation.Text = "Current Rotation:";
            // 
            // toolStripStatusLabel_ValueRotation
            // 
            this.toolStripStatusLabel_ValueRotation.Font = new System.Drawing.Font("Courier New", 9F);
            this.toolStripStatusLabel_ValueRotation.Name = "toolStripStatusLabel_ValueRotation";
            this.toolStripStatusLabel_ValueRotation.Size = new System.Drawing.Size(35, 20);
            this.toolStripStatusLabel_ValueRotation.Text = "000";
            // 
            // toolStripStatusLabel_LabelFlip
            // 
            this.toolStripStatusLabel_LabelFlip.Margin = new System.Windows.Forms.Padding(20, 4, 0, 2);
            this.toolStripStatusLabel_LabelFlip.Name = "toolStripStatusLabel_LabelFlip";
            this.toolStripStatusLabel_LabelFlip.Size = new System.Drawing.Size(88, 20);
            this.toolStripStatusLabel_LabelFlip.Text = "Current Flip:";
            // 
            // toolStripStatusLabel_ValueFlip
            // 
            this.toolStripStatusLabel_ValueFlip.Font = new System.Drawing.Font("Courier New", 9F);
            this.toolStripStatusLabel_ValueFlip.Name = "toolStripStatusLabel_ValueFlip";
            this.toolStripStatusLabel_ValueFlip.Size = new System.Drawing.Size(44, 20);
            this.toolStripStatusLabel_ValueFlip.Text = "None";
            // 
            // toolStripStatusLabel_Spring
            // 
            this.toolStripStatusLabel_Spring.Name = "toolStripStatusLabel_Spring";
            this.toolStripStatusLabel_Spring.Size = new System.Drawing.Size(739, 20);
            this.toolStripStatusLabel_Spring.Spring = true;
            // 
            // toolStripStatusLabel_LabelFPS
            // 
            this.toolStripStatusLabel_LabelFPS.Margin = new System.Windows.Forms.Padding(20, 4, 0, 2);
            this.toolStripStatusLabel_LabelFPS.Name = "toolStripStatusLabel_LabelFPS";
            this.toolStripStatusLabel_LabelFPS.Size = new System.Drawing.Size(35, 20);
            this.toolStripStatusLabel_LabelFPS.Text = "FPS:";
            // 
            // toolStripStatusLabel_ValueFPS
            // 
            this.toolStripStatusLabel_ValueFPS.Font = new System.Drawing.Font("Courier New", 9F);
            this.toolStripStatusLabel_ValueFPS.Name = "toolStripStatusLabel_ValueFPS";
            this.toolStripStatusLabel_ValueFPS.Size = new System.Drawing.Size(35, 20);
            this.toolStripStatusLabel_ValueFPS.Text = "000";
            // 
            // toolStripStatusLabel_End
            // 
            this.toolStripStatusLabel_End.Name = "toolStripStatusLabel_End";
            this.toolStripStatusLabel_End.Size = new System.Drawing.Size(15, 20);
            this.toolStripStatusLabel_End.Text = "-";
            // 
            // splitContainer_MainEditor
            // 
            this.splitContainer_MainEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_MainEditor.Location = new System.Drawing.Point(0, 4);
            this.splitContainer_MainEditor.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.splitContainer_MainEditor.Name = "splitContainer_MainEditor";
            // 
            // splitContainer_MainEditor.Panel1
            // 
            this.splitContainer_MainEditor.Panel1.Controls.Add(this.splitContainer_TileEditing);
            this.splitContainer_MainEditor.Panel1MinSize = 300;
            // 
            // splitContainer_MainEditor.Panel2
            // 
            this.splitContainer_MainEditor.Panel2.Controls.Add(this.mapPanel);
            this.splitContainer_MainEditor.Panel2MinSize = 700;
            this.splitContainer_MainEditor.Size = new System.Drawing.Size(1529, 1005);
            this.splitContainer_MainEditor.SplitterDistance = 453;
            this.splitContainer_MainEditor.TabIndex = 5;
            // 
            // splitContainer_LeftSideBar
            // 
            this.splitContainer_TileEditing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_TileEditing.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_TileEditing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer_TileEditing.Name = "splitContainer_LeftSideBar";
            this.splitContainer_TileEditing.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_LeftSideBar.Panel1
            // 
            this.splitContainer_TileEditing.Panel1.Controls.Add(this.tilePanel);
            this.splitContainer_TileEditing.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer_TileEditing.Panel1MinSize = 350;
            // 
            // splitContainer_LeftSideBar.Panel2
            // 
            this.splitContainer_TileEditing.Panel2.Controls.Add(this.editPanel);
            this.splitContainer_TileEditing.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer_TileEditing.Panel2MinSize = 350;
            this.splitContainer_TileEditing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer_TileEditing.Size = new System.Drawing.Size(453, 1005);
            this.splitContainer_TileEditing.SplitterDistance = 433;
            this.splitContainer_TileEditing.TabIndex = 0;
            // 
            // tableLayoutPanel_MainOutline
            // 
            this.tableLayoutPanel_MainOutline.ColumnCount = 1;
            this.tableLayoutPanel_MainOutline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_MainOutline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_MainOutline.Controls.Add(this.splitContainer_MainEditor, 0, 0);
            this.tableLayoutPanel_MainOutline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_MainOutline.Location = new System.Drawing.Point(0, 45);
            this.tableLayoutPanel_MainOutline.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel_MainOutline.Name = "tableLayoutPanel_MainOutline";
            this.tableLayoutPanel_MainOutline.RowCount = 1;
            this.tableLayoutPanel_MainOutline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_MainOutline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1013F));
            this.tableLayoutPanel_MainOutline.Size = new System.Drawing.Size(1529, 1013);
            this.tableLayoutPanel_MainOutline.TabIndex = 6;
            // 
            // tilePanel
            // 
            this.tilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilePanel.Location = new System.Drawing.Point(0, 0);
            this.tilePanel.Name = "tilePanel";
            this.tilePanel.Size = new System.Drawing.Size(453, 433);
            this.tilePanel.TabIndex = 0;
            // 
            // mapPanel
            // 
            this.mapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPanel.Location = new System.Drawing.Point(0, 0);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(1072, 1005);
            this.mapPanel.TabIndex = 0;
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
            // toolStripMenuItem_Exit
            // 
            this.toolStripMenuItem_Exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem_Exit.AutoSize = false;
            this.toolStripMenuItem_Exit.Image = global::Railgun.Editor.Properties.Resources.Exit;
            this.toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
            this.toolStripMenuItem_Exit.Size = new System.Drawing.Size(45, 40);
            this.toolStripMenuItem_Exit.Click += new System.EventHandler(this.Menu_Exit_Click);
            // 
            // toolStripMenuItem_Maximize
            // 
            this.toolStripMenuItem_Maximize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem_Maximize.AutoSize = false;
            this.toolStripMenuItem_Maximize.Image = global::Railgun.Editor.Properties.Resources.Maximize;
            this.toolStripMenuItem_Maximize.Name = "toolStripMenuItem_Maximize";
            this.toolStripMenuItem_Maximize.Size = new System.Drawing.Size(45, 40);
            this.toolStripMenuItem_Maximize.Click += new System.EventHandler(this.Menu_Maximize_Click);
            // 
            // toolStripMenuItem_Minimize
            // 
            this.toolStripMenuItem_Minimize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem_Minimize.AutoSize = false;
            this.toolStripMenuItem_Minimize.Image = global::Railgun.Editor.Properties.Resources.Minimize;
            this.toolStripMenuItem_Minimize.Name = "toolStripMenuItem_Minimize";
            this.toolStripMenuItem_Minimize.Size = new System.Drawing.Size(45, 40);
            this.toolStripMenuItem_Minimize.Click += new System.EventHandler(this.Menu_Minimize_Click);
            // 
            // editPanel
            // 
            this.editPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editPanel.Location = new System.Drawing.Point(0, 0);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(453, 568);
            this.editPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1529, 1084);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel_MainOutline);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1197, 850);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer_MainEditor.Panel1.ResumeLayout(false);
            this.splitContainer_MainEditor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MainEditor)).EndInit();
            this.splitContainer_MainEditor.ResumeLayout(false);
            this.splitContainer_TileEditing.Panel1.ResumeLayout(false);
            this.splitContainer_TileEditing.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_TileEditing)).EndInit();
            this.splitContainer_TileEditing.ResumeLayout(false);
            this.tableLayoutPanel_MainOutline.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_New;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Open;
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
        private System.Windows.Forms.SplitContainer splitContainer_TileEditing;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_MainOutline;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_MoveUp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_MoveDown;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_MoveLeft;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_MoveRight;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Title;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_PlaceHitbox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowHitboxes;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_LabelRotation;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ValueRotation;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_LabelFlip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ValueFlip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Spring;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_LabelFPS;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ValueFPS;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_End;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowGrid;
        private Controls.MapPanel mapPanel;
        private Controls.TilePanel tilePanel;
        private Controls.EditPanel editPanel;
    }
}