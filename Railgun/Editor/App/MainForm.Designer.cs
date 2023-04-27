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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Eraser", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Entrence", 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Exit", 2);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Skeleton", 3);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Gas Man", 4);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Enemy 3", 5);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_Logo = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Maximize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Minimize = new System.Windows.Forms.ToolStripMenuItem();
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
            this.splitContainer_LeftSideBar = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel_Tiles = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Objects = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_TilePicker = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_ObjectSettings = new System.Windows.Forms.TableLayoutPanel();
            this.panel_TileSizeSettings = new System.Windows.Forms.Panel();
            this.label_TileSize = new System.Windows.Forms.Label();
            this.textBox_TileSize = new System.Windows.Forms.TextBox();
            this.panel_TilePicker = new System.Windows.Forms.Panel();
            this.tabControl_Tileset = new System.Windows.Forms.TabControl();
            this.tabPage_EmptyTileset = new System.Windows.Forms.TabPage();
            this.tilePicker_Empty = new Railgun.Editor.App.Controls.TilePicker();
            this.label_NoTilesets = new System.Windows.Forms.Label();
            this.label_TilePicker = new System.Windows.Forms.Label();
            this.tableLayoutPanel_Edit = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Edit = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_EditTable = new System.Windows.Forms.TableLayoutPanel();
            this.button_Edit_FlipHorizontal = new System.Windows.Forms.Button();
            this.button_Edit_FlipVertical = new System.Windows.Forms.Button();
            this.button_Edit_RotateCW = new System.Windows.Forms.Button();
            this.button_Edit_RotateCCW = new System.Windows.Forms.Button();
            this.currentTileDisplay = new Railgun.Editor.App.Controls.CurrentTileDisplay();
            this.button_Edit_Up = new System.Windows.Forms.Button();
            this.button_Edit_Left = new System.Windows.Forms.Button();
            this.button_Edit_Down = new System.Windows.Forms.Button();
            this.button_Edit_Right = new System.Windows.Forms.Button();
            this.label_Edit = new System.Windows.Forms.Label();
            this.tableLayoutPanel_EditSettings = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_Solid = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel_MainEditor = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_MainEditorSettings = new System.Windows.Forms.TableLayoutPanel();
            this.panel_LayerSettings = new System.Windows.Forms.Panel();
            this.label_Layers = new System.Windows.Forms.Label();
            this.comboBox_Layers = new System.Windows.Forms.ComboBox();
            this.panel_Big_Holder = new System.Windows.Forms.Panel();
            this.panel_EntityPickerHolder = new System.Windows.Forms.Panel();
            this.panel_Entities = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_EntityPicker = new System.Windows.Forms.TableLayoutPanel();
            this.panel_EntityPicker = new System.Windows.Forms.Panel();
            this.listView_Entities = new System.Windows.Forms.ListView();
            this.imageList_Entities = new System.Windows.Forms.ImageList(this.components);
            this.panel_MapEditorHolder = new System.Windows.Forms.Panel();
            this.mapEditor = new Railgun.Editor.App.Controls.MapEditor();
            this.tableLayoutPanel_MainOutline = new System.Windows.Forms.TableLayoutPanel();
            this.label_EntityPicker = new System.Windows.Forms.Label();
            this.tableLayoutPanel_EntitySettings = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_ShowGrid = new System.Windows.Forms.CheckBox();
            this.checkBox_ShowHitboxes = new System.Windows.Forms.CheckBox();
            this.toolStripMenuItem_ShowGrid = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tableLayoutPanel_Tiles.SuspendLayout();
            this.panel_Objects.SuspendLayout();
            this.tableLayoutPanel_TilePicker.SuspendLayout();
            this.tableLayoutPanel_ObjectSettings.SuspendLayout();
            this.panel_TileSizeSettings.SuspendLayout();
            this.panel_TilePicker.SuspendLayout();
            this.tabControl_Tileset.SuspendLayout();
            this.tabPage_EmptyTileset.SuspendLayout();
            this.tableLayoutPanel_Edit.SuspendLayout();
            this.panel_Edit.SuspendLayout();
            this.tableLayoutPanel_EditTable.SuspendLayout();
            this.tableLayoutPanel_EditSettings.SuspendLayout();
            this.tableLayoutPanel_MainEditor.SuspendLayout();
            this.tableLayoutPanel_MainEditorSettings.SuspendLayout();
            this.panel_LayerSettings.SuspendLayout();
            this.panel_Big_Holder.SuspendLayout();
            this.panel_EntityPickerHolder.SuspendLayout();
            this.panel_Entities.SuspendLayout();
            this.tableLayoutPanel_EntityPicker.SuspendLayout();
            this.panel_EntityPicker.SuspendLayout();
            this.panel_MapEditorHolder.SuspendLayout();
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
            // toolStripMenuItem_Help
            // 
            this.toolStripMenuItem_Help.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.toolStripMenuItem_Help.Name = "toolStripMenuItem_Help";
            this.toolStripMenuItem_Help.Size = new System.Drawing.Size(55, 24);
            this.toolStripMenuItem_Help.Text = "Help";
            this.toolStripMenuItem_Help.Click += new System.EventHandler(this.ToolStripMenuItem_Help_Click);
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
            this.splitContainer_MainEditor.Panel1.Controls.Add(this.splitContainer_LeftSideBar);
            this.splitContainer_MainEditor.Panel1MinSize = 300;
            // 
            // splitContainer_MainEditor.Panel2
            // 
            this.splitContainer_MainEditor.Panel2.Controls.Add(this.tableLayoutPanel_MainEditor);
            this.splitContainer_MainEditor.Panel2MinSize = 400;
            this.splitContainer_MainEditor.Size = new System.Drawing.Size(1529, 1005);
            this.splitContainer_MainEditor.SplitterDistance = 454;
            this.splitContainer_MainEditor.TabIndex = 5;
            // 
            // splitContainer_LeftSideBar
            // 
            this.splitContainer_LeftSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_LeftSideBar.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_LeftSideBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer_LeftSideBar.Name = "splitContainer_LeftSideBar";
            this.splitContainer_LeftSideBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_LeftSideBar.Panel1
            // 
            this.splitContainer_LeftSideBar.Panel1.Controls.Add(this.tableLayoutPanel_Tiles);
            this.splitContainer_LeftSideBar.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer_LeftSideBar.Panel1MinSize = 350;
            // 
            // splitContainer_LeftSideBar.Panel2
            // 
            this.splitContainer_LeftSideBar.Panel2.Controls.Add(this.tableLayoutPanel_Edit);
            this.splitContainer_LeftSideBar.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer_LeftSideBar.Panel2MinSize = 350;
            this.splitContainer_LeftSideBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer_LeftSideBar.Size = new System.Drawing.Size(454, 1005);
            this.splitContainer_LeftSideBar.SplitterDistance = 384;
            this.splitContainer_LeftSideBar.TabIndex = 0;
            // 
            // tableLayoutPanel_Tiles
            // 
            this.tableLayoutPanel_Tiles.ColumnCount = 1;
            this.tableLayoutPanel_Tiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Tiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_Tiles.Controls.Add(this.label_TilePicker, 0, 0);
            this.tableLayoutPanel_Tiles.Controls.Add(this.panel_Objects, 0, 1);
            this.tableLayoutPanel_Tiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Tiles.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Tiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel_Tiles.Name = "tableLayoutPanel_Tiles";
            this.tableLayoutPanel_Tiles.RowCount = 2;
            this.tableLayoutPanel_Tiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_Tiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Tiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_Tiles.Size = new System.Drawing.Size(454, 384);
            this.tableLayoutPanel_Tiles.TabIndex = 6;
            // 
            // panel_Objects
            // 
            this.panel_Objects.Controls.Add(this.tableLayoutPanel_TilePicker);
            this.panel_Objects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Objects.Location = new System.Drawing.Point(0, 20);
            this.panel_Objects.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Objects.Name = "panel_Objects";
            this.panel_Objects.Size = new System.Drawing.Size(454, 364);
            this.panel_Objects.TabIndex = 4;
            // 
            // tableLayoutPanel_TilePicker
            // 
            this.tableLayoutPanel_TilePicker.ColumnCount = 1;
            this.tableLayoutPanel_TilePicker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_TilePicker.Controls.Add(this.tableLayoutPanel_ObjectSettings, 0, 0);
            this.tableLayoutPanel_TilePicker.Controls.Add(this.panel_TilePicker, 0, 1);
            this.tableLayoutPanel_TilePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_TilePicker.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_TilePicker.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_TilePicker.Name = "tableLayoutPanel_TilePicker";
            this.tableLayoutPanel_TilePicker.RowCount = 2;
            this.tableLayoutPanel_TilePicker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_TilePicker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_TilePicker.Size = new System.Drawing.Size(454, 364);
            this.tableLayoutPanel_TilePicker.TabIndex = 1;
            // 
            // tableLayoutPanel_ObjectSettings
            // 
            this.tableLayoutPanel_ObjectSettings.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel_ObjectSettings.ColumnCount = 1;
            this.tableLayoutPanel_ObjectSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_ObjectSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_ObjectSettings.Controls.Add(this.panel_TileSizeSettings, 0, 0);
            this.tableLayoutPanel_ObjectSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_ObjectSettings.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_ObjectSettings.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_ObjectSettings.Name = "tableLayoutPanel_ObjectSettings";
            this.tableLayoutPanel_ObjectSettings.RowCount = 1;
            this.tableLayoutPanel_ObjectSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_ObjectSettings.Size = new System.Drawing.Size(454, 50);
            this.tableLayoutPanel_ObjectSettings.TabIndex = 2;
            // 
            // panel_TileSizeSettings
            // 
            this.panel_TileSizeSettings.AutoSize = true;
            this.panel_TileSizeSettings.Controls.Add(this.label_TileSize);
            this.panel_TileSizeSettings.Controls.Add(this.textBox_TileSize);
            this.panel_TileSizeSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_TileSizeSettings.Location = new System.Drawing.Point(0, 0);
            this.panel_TileSizeSettings.Margin = new System.Windows.Forms.Padding(0);
            this.panel_TileSizeSettings.Name = "panel_TileSizeSettings";
            this.panel_TileSizeSettings.Size = new System.Drawing.Size(454, 50);
            this.panel_TileSizeSettings.TabIndex = 7;
            // 
            // label_TileSize
            // 
            this.label_TileSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_TileSize.AutoSize = true;
            this.label_TileSize.BackColor = System.Drawing.Color.Transparent;
            this.label_TileSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_TileSize.Location = new System.Drawing.Point(165, 14);
            this.label_TileSize.Name = "label_TileSize";
            this.label_TileSize.Size = new System.Drawing.Size(67, 20);
            this.label_TileSize.TabIndex = 4;
            this.label_TileSize.Text = "Tile Size:";
            // 
            // textBox_TileSize
            // 
            this.textBox_TileSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_TileSize.Location = new System.Drawing.Point(240, 14);
            this.textBox_TileSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_TileSize.Name = "textBox_TileSize";
            this.textBox_TileSize.Size = new System.Drawing.Size(41, 22);
            this.textBox_TileSize.TabIndex = 3;
            this.textBox_TileSize.TextChanged += new System.EventHandler(this.TileSize_TextChanged);
            this.textBox_TileSize.Leave += new System.EventHandler(this.TileSize_Leave);
            // 
            // panel_TilePicker
            // 
            this.panel_TilePicker.Controls.Add(this.tabControl_Tileset);
            this.panel_TilePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_TilePicker.Location = new System.Drawing.Point(3, 52);
            this.panel_TilePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_TilePicker.Name = "panel_TilePicker";
            this.panel_TilePicker.Size = new System.Drawing.Size(448, 310);
            this.panel_TilePicker.TabIndex = 3;
            // 
            // tabControl_Tileset
            // 
            this.tabControl_Tileset.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl_Tileset.Controls.Add(this.tabPage_EmptyTileset);
            this.tabControl_Tileset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Tileset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControl_Tileset.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Tileset.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl_Tileset.Multiline = true;
            this.tabControl_Tileset.Name = "tabControl_Tileset";
            this.tabControl_Tileset.SelectedIndex = 0;
            this.tabControl_Tileset.Size = new System.Drawing.Size(448, 310);
            this.tabControl_Tileset.TabIndex = 4;
            this.tabControl_Tileset.SelectedIndexChanged += new System.EventHandler(this.TabControl_Tileset_SelectedIndexChanged);
            // 
            // tabPage_EmptyTileset
            // 
            this.tabPage_EmptyTileset.Controls.Add(this.tilePicker_Empty);
            this.tabPage_EmptyTileset.Controls.Add(this.label_NoTilesets);
            this.tabPage_EmptyTileset.Location = new System.Drawing.Point(4, 4);
            this.tabPage_EmptyTileset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_EmptyTileset.Name = "tabPage_EmptyTileset";
            this.tabPage_EmptyTileset.Size = new System.Drawing.Size(440, 277);
            this.tabPage_EmptyTileset.TabIndex = 0;
            this.tabPage_EmptyTileset.Text = "Error";
            this.tabPage_EmptyTileset.UseVisualStyleBackColor = true;
            // 
            // tilePicker_Empty
            // 
            this.tilePicker_Empty.BackColor = System.Drawing.Color.White;
            this.tilePicker_Empty.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold);
            this.tilePicker_Empty.ForeColor = System.Drawing.Color.Black;
            this.tilePicker_Empty.GridSize = 0F;
            this.tilePicker_Empty.Location = new System.Drawing.Point(3, 2);
            this.tilePicker_Empty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tilePicker_Empty.MaxZoom = 0.1F;
            this.tilePicker_Empty.MinZoom = 0.1F;
            this.tilePicker_Empty.MouseHoverUpdatesOnly = false;
            this.tilePicker_Empty.Name = "tilePicker_Empty";
            this.tilePicker_Empty.Size = new System.Drawing.Size(93, 46);
            this.tilePicker_Empty.TabIndex = 2;
            this.tilePicker_Empty.Text = "tilePicker1";
            this.tilePicker_Empty.Visible = false;
            // 
            // label_NoTilesets
            // 
            this.label_NoTilesets.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_NoTilesets.AutoSize = true;
            this.label_NoTilesets.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NoTilesets.Location = new System.Drawing.Point(40, 73);
            this.label_NoTilesets.Name = "label_NoTilesets";
            this.label_NoTilesets.Size = new System.Drawing.Size(369, 140);
            this.label_NoTilesets.TabIndex = 3;
            this.label_NoTilesets.Text = "No tilesets found!\r\n\r\nMake sure there is a subdirectory within\r\nContent containin" +
    "g the tilesets and that\r\nthey are added to the content manager.\r\n\r\nFor example: " +
    "Content/Tiles/Tileset.png";
            this.label_NoTilesets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_TilePicker
            // 
            this.label_TilePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_TilePicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_TilePicker.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_TilePicker.Location = new System.Drawing.Point(0, 0);
            this.label_TilePicker.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label_TilePicker.Name = "label_TilePicker";
            this.label_TilePicker.Size = new System.Drawing.Size(454, 16);
            this.label_TilePicker.TabIndex = 3;
            this.label_TilePicker.Text = "Tile Picker";
            this.label_TilePicker.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel_Edit
            // 
            this.tableLayoutPanel_Edit.ColumnCount = 1;
            this.tableLayoutPanel_Edit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Edit.Controls.Add(this.panel_Edit, 0, 2);
            this.tableLayoutPanel_Edit.Controls.Add(this.label_Edit, 0, 0);
            this.tableLayoutPanel_Edit.Controls.Add(this.tableLayoutPanel_EditSettings, 0, 1);
            this.tableLayoutPanel_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Edit.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Edit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel_Edit.Name = "tableLayoutPanel_Edit";
            this.tableLayoutPanel_Edit.RowCount = 3;
            this.tableLayoutPanel_Edit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_Edit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Edit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Edit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_Edit.Size = new System.Drawing.Size(454, 617);
            this.tableLayoutPanel_Edit.TabIndex = 7;
            // 
            // panel_Edit
            // 
            this.panel_Edit.Controls.Add(this.tableLayoutPanel_EditTable);
            this.panel_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Edit.Location = new System.Drawing.Point(0, 70);
            this.panel_Edit.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Edit.Name = "panel_Edit";
            this.panel_Edit.Size = new System.Drawing.Size(454, 547);
            this.panel_Edit.TabIndex = 5;
            // 
            // tableLayoutPanel_EditTable
            // 
            this.tableLayoutPanel_EditTable.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel_EditTable.ColumnCount = 9;
            this.tableLayoutPanel_EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_EditTable.Controls.Add(this.button_Edit_FlipHorizontal, 7, 7);
            this.tableLayoutPanel_EditTable.Controls.Add(this.button_Edit_FlipVertical, 1, 7);
            this.tableLayoutPanel_EditTable.Controls.Add(this.button_Edit_RotateCW, 7, 1);
            this.tableLayoutPanel_EditTable.Controls.Add(this.button_Edit_RotateCCW, 1, 1);
            this.tableLayoutPanel_EditTable.Controls.Add(this.currentTileDisplay, 3, 3);
            this.tableLayoutPanel_EditTable.Controls.Add(this.button_Edit_Up, 4, 1);
            this.tableLayoutPanel_EditTable.Controls.Add(this.button_Edit_Left, 1, 4);
            this.tableLayoutPanel_EditTable.Controls.Add(this.button_Edit_Down, 4, 7);
            this.tableLayoutPanel_EditTable.Controls.Add(this.button_Edit_Right, 7, 4);
            this.tableLayoutPanel_EditTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_EditTable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel_EditTable.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_EditTable.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_EditTable.Name = "tableLayoutPanel_EditTable";
            this.tableLayoutPanel_EditTable.RowCount = 9;
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_EditTable.Size = new System.Drawing.Size(454, 547);
            this.tableLayoutPanel_EditTable.TabIndex = 0;
            // 
            // button_Edit_FlipHorizontal
            // 
            this.button_Edit_FlipHorizontal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_FlipHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_FlipHorizontal.Image = global::Railgun.Editor.Properties.Resources.Flip_Horizontal;
            this.button_Edit_FlipHorizontal.Location = new System.Drawing.Point(350, 422);
            this.button_Edit_FlipHorizontal.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_FlipHorizontal.Name = "button_Edit_FlipHorizontal";
            this.button_Edit_FlipHorizontal.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_FlipHorizontal.TabIndex = 9;
            this.button_Edit_FlipHorizontal.UseVisualStyleBackColor = true;
            this.button_Edit_FlipHorizontal.Click += new System.EventHandler(this.Menu_Edit_FlipHorizontally_Click);
            // 
            // button_Edit_FlipVertical
            // 
            this.button_Edit_FlipVertical.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_FlipVertical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_FlipVertical.Image = global::Railgun.Editor.Properties.Resources.Flip_Vertical;
            this.button_Edit_FlipVertical.Location = new System.Drawing.Point(50, 422);
            this.button_Edit_FlipVertical.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_FlipVertical.Name = "button_Edit_FlipVertical";
            this.button_Edit_FlipVertical.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_FlipVertical.TabIndex = 7;
            this.button_Edit_FlipVertical.UseVisualStyleBackColor = true;
            this.button_Edit_FlipVertical.Click += new System.EventHandler(this.Menu_Edit_FlipVertically_Click);
            // 
            // button_Edit_RotateCW
            // 
            this.button_Edit_RotateCW.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_RotateCW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Edit_RotateCW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_RotateCW.Image = global::Railgun.Editor.Properties.Resources.Clockwise;
            this.button_Edit_RotateCW.Location = new System.Drawing.Point(350, 74);
            this.button_Edit_RotateCW.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_RotateCW.Name = "button_Edit_RotateCW";
            this.button_Edit_RotateCW.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_RotateCW.TabIndex = 2;
            this.button_Edit_RotateCW.UseVisualStyleBackColor = true;
            this.button_Edit_RotateCW.Click += new System.EventHandler(this.Menu_Edit_Rotate90CW_Click);
            // 
            // button_Edit_RotateCCW
            // 
            this.button_Edit_RotateCCW.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_RotateCCW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_RotateCCW.Image = global::Railgun.Editor.Properties.Resources.Counter_Clockwise;
            this.button_Edit_RotateCCW.Location = new System.Drawing.Point(50, 74);
            this.button_Edit_RotateCCW.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_RotateCCW.Name = "button_Edit_RotateCCW";
            this.button_Edit_RotateCCW.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_RotateCCW.TabIndex = 3;
            this.button_Edit_RotateCCW.UseVisualStyleBackColor = true;
            this.button_Edit_RotateCCW.Click += new System.EventHandler(this.Menu_Edit_Rotate90CCW_Click);
            // 
            // currentTileDisplay
            // 
            this.currentTileDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.currentTileDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel_EditTable.SetColumnSpan(this.currentTileDisplay, 3);
            this.currentTileDisplay.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold);
            this.currentTileDisplay.ForeColor = System.Drawing.Color.Black;
            this.currentTileDisplay.Location = new System.Drawing.Point(151, 198);
            this.currentTileDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.currentTileDisplay.Name = "currentTileDisplay";
            this.tableLayoutPanel_EditTable.SetRowSpan(this.currentTileDisplay, 3);
            this.currentTileDisplay.Size = new System.Drawing.Size(149, 150);
            this.currentTileDisplay.TabIndex = 1;
            this.currentTileDisplay.Text = "currentTileDisplay";
            // 
            // button_Edit_Up
            // 
            this.button_Edit_Up.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_Up.Image = global::Railgun.Editor.Properties.Resources.Move_Up;
            this.button_Edit_Up.Location = new System.Drawing.Point(200, 74);
            this.button_Edit_Up.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_Up.Name = "button_Edit_Up";
            this.button_Edit_Up.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_Up.TabIndex = 4;
            this.button_Edit_Up.UseVisualStyleBackColor = true;
            this.button_Edit_Up.Visible = false;
            this.button_Edit_Up.Click += new System.EventHandler(this.Menu_Edit_MoveUp_Click);
            // 
            // button_Edit_Left
            // 
            this.button_Edit_Left.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_Left.Image = global::Railgun.Editor.Properties.Resources.Move_Left;
            this.button_Edit_Left.Location = new System.Drawing.Point(50, 248);
            this.button_Edit_Left.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_Left.Name = "button_Edit_Left";
            this.button_Edit_Left.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_Left.TabIndex = 5;
            this.button_Edit_Left.UseVisualStyleBackColor = true;
            this.button_Edit_Left.Visible = false;
            this.button_Edit_Left.Click += new System.EventHandler(this.Menu_Edit_MoveLeft_Click);
            // 
            // button_Edit_Down
            // 
            this.button_Edit_Down.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_Down.Image = global::Railgun.Editor.Properties.Resources.Move_Down;
            this.button_Edit_Down.Location = new System.Drawing.Point(200, 422);
            this.button_Edit_Down.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_Down.Name = "button_Edit_Down";
            this.button_Edit_Down.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_Down.TabIndex = 8;
            this.button_Edit_Down.UseVisualStyleBackColor = true;
            this.button_Edit_Down.Visible = false;
            this.button_Edit_Down.Click += new System.EventHandler(this.Menu_Edit_MoveDown_Click);
            // 
            // button_Edit_Right
            // 
            this.button_Edit_Right.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_Right.Image = global::Railgun.Editor.Properties.Resources.Move_Right;
            this.button_Edit_Right.Location = new System.Drawing.Point(350, 248);
            this.button_Edit_Right.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_Right.Name = "button_Edit_Right";
            this.button_Edit_Right.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_Right.TabIndex = 6;
            this.button_Edit_Right.UseVisualStyleBackColor = true;
            this.button_Edit_Right.Visible = false;
            this.button_Edit_Right.Click += new System.EventHandler(this.Menu_Edit_MoveRight_Click);
            // 
            // label_Edit
            // 
            this.label_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Edit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_Edit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Edit.Location = new System.Drawing.Point(0, 0);
            this.label_Edit.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label_Edit.Name = "label_Edit";
            this.label_Edit.Size = new System.Drawing.Size(454, 16);
            this.label_Edit.TabIndex = 4;
            this.label_Edit.Text = "Edit";
            this.label_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel_EditSettings
            // 
            this.tableLayoutPanel_EditSettings.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel_EditSettings.ColumnCount = 1;
            this.tableLayoutPanel_EditSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_EditSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_EditSettings.Controls.Add(this.checkBox_Solid, 0, 0);
            this.tableLayoutPanel_EditSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_EditSettings.Location = new System.Drawing.Point(0, 20);
            this.tableLayoutPanel_EditSettings.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_EditSettings.Name = "tableLayoutPanel_EditSettings";
            this.tableLayoutPanel_EditSettings.RowCount = 1;
            this.tableLayoutPanel_EditSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_EditSettings.Size = new System.Drawing.Size(454, 50);
            this.tableLayoutPanel_EditSettings.TabIndex = 6;
            // 
            // checkBox_Solid
            // 
            this.checkBox_Solid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox_Solid.AutoSize = true;
            this.checkBox_Solid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_Solid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBox_Solid.Location = new System.Drawing.Point(171, 13);
            this.checkBox_Solid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_Solid.Name = "checkBox_Solid";
            this.checkBox_Solid.Size = new System.Drawing.Size(111, 24);
            this.checkBox_Solid.TabIndex = 0;
            this.checkBox_Solid.Text = "Place Hitbox";
            this.checkBox_Solid.UseVisualStyleBackColor = true;
            this.checkBox_Solid.CheckedChanged += new System.EventHandler(this.CheckBox_Solid_CheckedChanged);
            // 
            // tableLayoutPanel_MainEditor
            // 
            this.tableLayoutPanel_MainEditor.ColumnCount = 1;
            this.tableLayoutPanel_MainEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_MainEditor.Controls.Add(this.tableLayoutPanel_MainEditorSettings, 0, 0);
            this.tableLayoutPanel_MainEditor.Controls.Add(this.panel_Big_Holder, 0, 1);
            this.tableLayoutPanel_MainEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_MainEditor.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_MainEditor.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_MainEditor.Name = "tableLayoutPanel_MainEditor";
            this.tableLayoutPanel_MainEditor.RowCount = 2;
            this.tableLayoutPanel_MainEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_MainEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_MainEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel_MainEditor.Size = new System.Drawing.Size(1071, 1005);
            this.tableLayoutPanel_MainEditor.TabIndex = 2;
            // 
            // tableLayoutPanel_MainEditorSettings
            // 
            this.tableLayoutPanel_MainEditorSettings.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel_MainEditorSettings.ColumnCount = 3;
            this.tableLayoutPanel_MainEditorSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_MainEditorSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_MainEditorSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_MainEditorSettings.Controls.Add(this.checkBox_ShowHitboxes, 0, 0);
            this.tableLayoutPanel_MainEditorSettings.Controls.Add(this.panel_LayerSettings, 0, 0);
            this.tableLayoutPanel_MainEditorSettings.Controls.Add(this.checkBox_ShowGrid, 2, 0);
            this.tableLayoutPanel_MainEditorSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_MainEditorSettings.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_MainEditorSettings.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_MainEditorSettings.Name = "tableLayoutPanel_MainEditorSettings";
            this.tableLayoutPanel_MainEditorSettings.RowCount = 1;
            this.tableLayoutPanel_MainEditorSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_MainEditorSettings.Size = new System.Drawing.Size(1071, 50);
            this.tableLayoutPanel_MainEditorSettings.TabIndex = 2;
            // 
            // panel_LayerSettings
            // 
            this.panel_LayerSettings.Controls.Add(this.label_Layers);
            this.panel_LayerSettings.Controls.Add(this.comboBox_Layers);
            this.panel_LayerSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_LayerSettings.Location = new System.Drawing.Point(0, 0);
            this.panel_LayerSettings.Margin = new System.Windows.Forms.Padding(0);
            this.panel_LayerSettings.Name = "panel_LayerSettings";
            this.panel_LayerSettings.Size = new System.Drawing.Size(357, 50);
            this.panel_LayerSettings.TabIndex = 2;
            // 
            // label_Layers
            // 
            this.label_Layers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Layers.AutoSize = true;
            this.label_Layers.BackColor = System.Drawing.Color.Transparent;
            this.label_Layers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_Layers.Location = new System.Drawing.Point(34, 14);
            this.label_Layers.Name = "label_Layers";
            this.label_Layers.Size = new System.Drawing.Size(99, 20);
            this.label_Layers.TabIndex = 5;
            this.label_Layers.Text = "Current Layer:";
            // 
            // comboBox_Layers
            // 
            this.comboBox_Layers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_Layers.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_Layers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Layers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Layers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBox_Layers.FormattingEnabled = true;
            this.comboBox_Layers.Items.AddRange(new object[] {
            "Entities",
            "Hitboxes",
            "Tiles Bottom",
            "Tiles Top"});
            this.comboBox_Layers.Location = new System.Drawing.Point(154, 11);
            this.comboBox_Layers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Layers.Name = "comboBox_Layers";
            this.comboBox_Layers.Size = new System.Drawing.Size(165, 28);
            this.comboBox_Layers.TabIndex = 3;
            this.comboBox_Layers.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Layers_SelectedIndexChanged);
            // 
            // panel_Big_Holder
            // 
            this.panel_Big_Holder.Controls.Add(this.panel_EntityPickerHolder);
            this.panel_Big_Holder.Controls.Add(this.panel_MapEditorHolder);
            this.panel_Big_Holder.Location = new System.Drawing.Point(4, 54);
            this.panel_Big_Holder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_Big_Holder.Name = "panel_Big_Holder";
            this.panel_Big_Holder.Size = new System.Drawing.Size(1033, 947);
            this.panel_Big_Holder.TabIndex = 3;
            // 
            // panel_EntityPickerHolder
            // 
            this.panel_EntityPickerHolder.Controls.Add(this.panel_Entities);
            this.panel_EntityPickerHolder.Location = new System.Drawing.Point(207, 196);
            this.panel_EntityPickerHolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_EntityPickerHolder.Name = "panel_EntityPickerHolder";
            this.panel_EntityPickerHolder.Size = new System.Drawing.Size(669, 382);
            this.panel_EntityPickerHolder.TabIndex = 1;
            // 
            // panel_Entities
            // 
            this.panel_Entities.Controls.Add(this.tableLayoutPanel_EntityPicker);
            this.panel_Entities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Entities.Location = new System.Drawing.Point(0, 0);
            this.panel_Entities.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Entities.Name = "panel_Entities";
            this.panel_Entities.Size = new System.Drawing.Size(669, 382);
            this.panel_Entities.TabIndex = 5;
            // 
            // tableLayoutPanel_EntityPicker
            // 
            this.tableLayoutPanel_EntityPicker.ColumnCount = 1;
            this.tableLayoutPanel_EntityPicker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_EntityPicker.Controls.Add(this.tableLayoutPanel_EntitySettings, 0, 1);
            this.tableLayoutPanel_EntityPicker.Controls.Add(this.panel_EntityPicker, 0, 2);
            this.tableLayoutPanel_EntityPicker.Controls.Add(this.label_EntityPicker, 0, 0);
            this.tableLayoutPanel_EntityPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_EntityPicker.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_EntityPicker.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_EntityPicker.Name = "tableLayoutPanel_EntityPicker";
            this.tableLayoutPanel_EntityPicker.RowCount = 3;
            this.tableLayoutPanel_EntityPicker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_EntityPicker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_EntityPicker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_EntityPicker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_EntityPicker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_EntityPicker.Size = new System.Drawing.Size(669, 382);
            this.tableLayoutPanel_EntityPicker.TabIndex = 1;
            // 
            // panel_EntityPicker
            // 
            this.panel_EntityPicker.Controls.Add(this.listView_Entities);
            this.panel_EntityPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_EntityPicker.Location = new System.Drawing.Point(3, 72);
            this.panel_EntityPicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_EntityPicker.Name = "panel_EntityPicker";
            this.panel_EntityPicker.Size = new System.Drawing.Size(663, 308);
            this.panel_EntityPicker.TabIndex = 3;
            // 
            // listView_Entities
            // 
            this.listView_Entities.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listView_Entities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_Entities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Entities.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            listViewItem5.StateImageIndex = 0;
            listViewItem6.StateImageIndex = 0;
            this.listView_Entities.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.listView_Entities.LargeImageList = this.imageList_Entities;
            this.listView_Entities.Location = new System.Drawing.Point(0, 0);
            this.listView_Entities.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView_Entities.MultiSelect = false;
            this.listView_Entities.Name = "listView_Entities";
            this.listView_Entities.Size = new System.Drawing.Size(663, 308);
            this.listView_Entities.TabIndex = 8;
            this.listView_Entities.TileSize = new System.Drawing.Size(20, 20);
            this.listView_Entities.UseCompatibleStateImageBehavior = false;
            this.listView_Entities.SelectedIndexChanged += new System.EventHandler(this.ListBox_EntityPicker_SelectedIndexChanged);
            // 
            // imageList_Entities
            // 
            this.imageList_Entities.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Entities.ImageStream")));
            this.imageList_Entities.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_Entities.Images.SetKeyName(0, "Eraser.png");
            this.imageList_Entities.Images.SetKeyName(1, "Entrence.png");
            this.imageList_Entities.Images.SetKeyName(2, "Exit.png");
            this.imageList_Entities.Images.SetKeyName(3, "Skeleton.png");
            this.imageList_Entities.Images.SetKeyName(4, "Gas Man.png");
            this.imageList_Entities.Images.SetKeyName(5, "Unknown.png");
            // 
            // panel_MapEditorHolder
            // 
            this.panel_MapEditorHolder.Controls.Add(this.mapEditor);
            this.panel_MapEditorHolder.Location = new System.Drawing.Point(79, 47);
            this.panel_MapEditorHolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_MapEditorHolder.Name = "panel_MapEditorHolder";
            this.panel_MapEditorHolder.Size = new System.Drawing.Size(267, 123);
            this.panel_MapEditorHolder.TabIndex = 0;
            // 
            // mapEditor
            // 
            this.mapEditor.BackColor = System.Drawing.SystemColors.Control;
            this.mapEditor.CurrentMap = null;
            this.mapEditor.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mapEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapEditor.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapEditor.ForeColor = System.Drawing.Color.Black;
            this.mapEditor.Location = new System.Drawing.Point(0, 0);
            this.mapEditor.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.mapEditor.MaxZoom = 0.1F;
            this.mapEditor.MinZoom = 0.1F;
            this.mapEditor.MouseHoverUpdatesOnly = false;
            this.mapEditor.Name = "mapEditor";
            this.mapEditor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mapEditor.Size = new System.Drawing.Size(267, 123);
            this.mapEditor.TabIndex = 2;
            this.mapEditor.Text = "mainEditorPanel";
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
            this.tableLayoutPanel_MainOutline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 764F));
            this.tableLayoutPanel_MainOutline.Size = new System.Drawing.Size(1529, 1013);
            this.tableLayoutPanel_MainOutline.TabIndex = 6;
            // 
            // label_EntityPicker
            // 
            this.label_EntityPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_EntityPicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_EntityPicker.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_EntityPicker.Location = new System.Drawing.Point(0, 0);
            this.label_EntityPicker.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label_EntityPicker.Name = "label_EntityPicker";
            this.label_EntityPicker.Size = new System.Drawing.Size(669, 16);
            this.label_EntityPicker.TabIndex = 4;
            this.label_EntityPicker.Text = "Entity Picker";
            this.label_EntityPicker.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel_EntitySettings
            // 
            this.tableLayoutPanel_EntitySettings.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel_EntitySettings.ColumnCount = 1;
            this.tableLayoutPanel_EntitySettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_EntitySettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_EntitySettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_EntitySettings.Location = new System.Drawing.Point(0, 20);
            this.tableLayoutPanel_EntitySettings.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_EntitySettings.Name = "tableLayoutPanel_EntitySettings";
            this.tableLayoutPanel_EntitySettings.RowCount = 1;
            this.tableLayoutPanel_EntitySettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_EntitySettings.Size = new System.Drawing.Size(669, 50);
            this.tableLayoutPanel_EntitySettings.TabIndex = 2;
            // 
            // checkBox_ShowGrid
            // 
            this.checkBox_ShowGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox_ShowGrid.AutoSize = true;
            this.checkBox_ShowGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_ShowGrid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBox_ShowGrid.Location = new System.Drawing.Point(845, 13);
            this.checkBox_ShowGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_ShowGrid.Name = "checkBox_ShowGrid";
            this.checkBox_ShowGrid.Size = new System.Drawing.Size(95, 24);
            this.checkBox_ShowGrid.TabIndex = 3;
            this.checkBox_ShowGrid.Text = "Show Grid";
            this.checkBox_ShowGrid.UseVisualStyleBackColor = true;
            this.checkBox_ShowGrid.CheckedChanged += new System.EventHandler(this.CheckBox_ShowGrid_CheckedChanged);
            // 
            // checkBox_ShowHitboxes
            // 
            this.checkBox_ShowHitboxes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox_ShowHitboxes.AutoSize = true;
            this.checkBox_ShowHitboxes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_ShowHitboxes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBox_ShowHitboxes.Location = new System.Drawing.Point(472, 13);
            this.checkBox_ShowHitboxes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_ShowHitboxes.Name = "checkBox_ShowHitboxes";
            this.checkBox_ShowHitboxes.Size = new System.Drawing.Size(126, 24);
            this.checkBox_ShowHitboxes.TabIndex = 4;
            this.checkBox_ShowHitboxes.Text = "Show Hitboxes";
            this.checkBox_ShowHitboxes.UseVisualStyleBackColor = true;
            this.checkBox_ShowHitboxes.CheckedChanged += new System.EventHandler(this.CheckBox_ShowHitboxes_CheckedChanged);
            // 
            // toolStripMenuItem_ShowGrid
            // 
            this.toolStripMenuItem_ShowGrid.CheckOnClick = true;
            this.toolStripMenuItem_ShowGrid.Name = "toolStripMenuItem_ShowGrid";
            this.toolStripMenuItem_ShowGrid.Size = new System.Drawing.Size(233, 26);
            this.toolStripMenuItem_ShowGrid.Text = "Show Grid";
            this.toolStripMenuItem_ShowGrid.CheckedChanged += new System.EventHandler(this.Menu_View_ShowGrid_CheckedChanged);
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
            this.splitContainer_LeftSideBar.Panel1.ResumeLayout(false);
            this.splitContainer_LeftSideBar.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_LeftSideBar)).EndInit();
            this.splitContainer_LeftSideBar.ResumeLayout(false);
            this.tableLayoutPanel_Tiles.ResumeLayout(false);
            this.panel_Objects.ResumeLayout(false);
            this.tableLayoutPanel_TilePicker.ResumeLayout(false);
            this.tableLayoutPanel_ObjectSettings.ResumeLayout(false);
            this.tableLayoutPanel_ObjectSettings.PerformLayout();
            this.panel_TileSizeSettings.ResumeLayout(false);
            this.panel_TileSizeSettings.PerformLayout();
            this.panel_TilePicker.ResumeLayout(false);
            this.tabControl_Tileset.ResumeLayout(false);
            this.tabPage_EmptyTileset.ResumeLayout(false);
            this.tabPage_EmptyTileset.PerformLayout();
            this.tableLayoutPanel_Edit.ResumeLayout(false);
            this.panel_Edit.ResumeLayout(false);
            this.tableLayoutPanel_EditTable.ResumeLayout(false);
            this.tableLayoutPanel_EditSettings.ResumeLayout(false);
            this.tableLayoutPanel_EditSettings.PerformLayout();
            this.tableLayoutPanel_MainEditor.ResumeLayout(false);
            this.tableLayoutPanel_MainEditorSettings.ResumeLayout(false);
            this.tableLayoutPanel_MainEditorSettings.PerformLayout();
            this.panel_LayerSettings.ResumeLayout(false);
            this.panel_LayerSettings.PerformLayout();
            this.panel_Big_Holder.ResumeLayout(false);
            this.panel_EntityPickerHolder.ResumeLayout(false);
            this.panel_Entities.ResumeLayout(false);
            this.tableLayoutPanel_EntityPicker.ResumeLayout(false);
            this.panel_EntityPicker.ResumeLayout(false);
            this.panel_MapEditorHolder.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer splitContainer_LeftSideBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Tiles;
        private System.Windows.Forms.Label label_TilePicker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Edit;
        private System.Windows.Forms.Panel panel_Edit;
        private System.Windows.Forms.Label label_Edit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_MainOutline;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_EditTable;
        private Controls.CurrentTileDisplay currentTileDisplay;
        private System.Windows.Forms.Button button_Edit_RotateCW;
        private System.Windows.Forms.Button button_Edit_FlipHorizontal;
        private System.Windows.Forms.Button button_Edit_Down;
        private System.Windows.Forms.Button button_Edit_FlipVertical;
        private System.Windows.Forms.Button button_Edit_Right;
        private System.Windows.Forms.Button button_Edit_Left;
        private System.Windows.Forms.Button button_Edit_Up;
        private System.Windows.Forms.Button button_Edit_RotateCCW;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_MoveUp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_MoveDown;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_MoveLeft;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_MoveRight;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Title;
        private System.Windows.Forms.CheckBox checkBox_Solid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_EditSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_PlaceHitbox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowHitboxes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_MainEditor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_MainEditorSettings;
        private System.Windows.Forms.Panel panel_LayerSettings;
        private System.Windows.Forms.Label label_Layers;
        private System.Windows.Forms.ComboBox comboBox_Layers;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_LabelRotation;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ValueRotation;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_LabelFlip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ValueFlip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Spring;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_LabelFPS;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ValueFPS;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_End;
        private System.Windows.Forms.Panel panel_Objects;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_TilePicker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_ObjectSettings;
        private System.Windows.Forms.Panel panel_TileSizeSettings;
        private System.Windows.Forms.Label label_TileSize;
        private System.Windows.Forms.TextBox textBox_TileSize;
        private System.Windows.Forms.Panel panel_TilePicker;
        private System.Windows.Forms.TabControl tabControl_Tileset;
        private System.Windows.Forms.TabPage tabPage_EmptyTileset;
        private Controls.TilePicker tilePicker_Empty;
        private System.Windows.Forms.Label label_NoTilesets;
        private System.Windows.Forms.Panel panel_Big_Holder;
        private System.Windows.Forms.Panel panel_EntityPickerHolder;
        private System.Windows.Forms.Panel panel_Entities;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_EntityPicker;
        private System.Windows.Forms.Panel panel_EntityPicker;
        private System.Windows.Forms.Panel panel_MapEditorHolder;
        private Controls.MapEditor mapEditor;
        private System.Windows.Forms.ListView listView_Entities;
        private System.Windows.Forms.ImageList imageList_Entities;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_EntitySettings;
        private System.Windows.Forms.Label label_EntityPicker;
        private System.Windows.Forms.CheckBox checkBox_ShowGrid;
        private System.Windows.Forms.CheckBox checkBox_ShowHitboxes;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowGrid;
    }
}