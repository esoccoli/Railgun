namespace Railgun.Editor.App.Controls
{
    partial class MapPanel
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
            if(disposing && (components != null))
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
            this.tableLayoutPanel_MainEditor = new System.Windows.Forms.TableLayoutPanel();
            this.mapEditor = new Railgun.Editor.App.Controls.MapEditor();
            this.tableLayoutPanel_MainEditorSettings = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_ShowHitboxes = new System.Windows.Forms.CheckBox();
            this.panel_LayerSettings = new System.Windows.Forms.Panel();
            this.label_Layers = new System.Windows.Forms.Label();
            this.comboBox_Layers = new System.Windows.Forms.ComboBox();
            this.checkBox_ShowGrid = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel_MainEditor.SuspendLayout();
            this.tableLayoutPanel_MainEditorSettings.SuspendLayout();
            this.panel_LayerSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_MainEditor
            // 
            this.tableLayoutPanel_MainEditor.ColumnCount = 1;
            this.tableLayoutPanel_MainEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_MainEditor.Controls.Add(this.mapEditor, 0, 1);
            this.tableLayoutPanel_MainEditor.Controls.Add(this.tableLayoutPanel_MainEditorSettings, 0, 0);
            this.tableLayoutPanel_MainEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_MainEditor.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_MainEditor.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_MainEditor.Name = "tableLayoutPanel_MainEditor";
            this.tableLayoutPanel_MainEditor.RowCount = 2;
            this.tableLayoutPanel_MainEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_MainEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_MainEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel_MainEditor.Size = new System.Drawing.Size(1045, 519);
            this.tableLayoutPanel_MainEditor.TabIndex = 3;
            // 
            // mapEditor
            // 
            this.mapEditor.BackColor = System.Drawing.SystemColors.Control;
            this.mapEditor.CurrentMap = null;
            this.mapEditor.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mapEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapEditor.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapEditor.ForeColor = System.Drawing.Color.Black;
            this.mapEditor.Location = new System.Drawing.Point(0, 52);
            this.mapEditor.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.mapEditor.MaxZoom = 0.1F;
            this.mapEditor.MinZoom = 0.1F;
            this.mapEditor.MouseHoverUpdatesOnly = false;
            this.mapEditor.Name = "mapEditor";
            this.mapEditor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mapEditor.Size = new System.Drawing.Size(1045, 467);
            this.mapEditor.TabIndex = 3;
            this.mapEditor.Text = "mainEditorPanel";
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
            this.tableLayoutPanel_MainEditorSettings.Size = new System.Drawing.Size(1045, 50);
            this.tableLayoutPanel_MainEditorSettings.TabIndex = 2;
            // 
            // checkBox_ShowHitboxes
            // 
            this.checkBox_ShowHitboxes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox_ShowHitboxes.AutoSize = true;
            this.checkBox_ShowHitboxes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_ShowHitboxes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBox_ShowHitboxes.Location = new System.Drawing.Point(459, 13);
            this.checkBox_ShowHitboxes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_ShowHitboxes.Name = "checkBox_ShowHitboxes";
            this.checkBox_ShowHitboxes.Size = new System.Drawing.Size(126, 24);
            this.checkBox_ShowHitboxes.TabIndex = 4;
            this.checkBox_ShowHitboxes.Text = "Show Hitboxes";
            this.checkBox_ShowHitboxes.UseVisualStyleBackColor = true;
            this.checkBox_ShowHitboxes.CheckedChanged += new System.EventHandler(this.CheckBox_ShowHitboxes_CheckedChanged);
            // 
            // panel_LayerSettings
            // 
            this.panel_LayerSettings.Controls.Add(this.label_Layers);
            this.panel_LayerSettings.Controls.Add(this.comboBox_Layers);
            this.panel_LayerSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_LayerSettings.Location = new System.Drawing.Point(0, 0);
            this.panel_LayerSettings.Margin = new System.Windows.Forms.Padding(0);
            this.panel_LayerSettings.Name = "panel_LayerSettings";
            this.panel_LayerSettings.Size = new System.Drawing.Size(348, 50);
            this.panel_LayerSettings.TabIndex = 2;
            // 
            // label_Layers
            // 
            this.label_Layers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Layers.AutoSize = true;
            this.label_Layers.BackColor = System.Drawing.Color.Transparent;
            this.label_Layers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_Layers.Location = new System.Drawing.Point(31, 14);
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
            this.comboBox_Layers.Location = new System.Drawing.Point(151, 11);
            this.comboBox_Layers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Layers.Name = "comboBox_Layers";
            this.comboBox_Layers.Size = new System.Drawing.Size(165, 28);
            this.comboBox_Layers.TabIndex = 3;
            this.comboBox_Layers.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Layers_SelectedIndexChanged);
            // 
            // checkBox_ShowGrid
            // 
            this.checkBox_ShowGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox_ShowGrid.AutoSize = true;
            this.checkBox_ShowGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_ShowGrid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBox_ShowGrid.Location = new System.Drawing.Point(823, 13);
            this.checkBox_ShowGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_ShowGrid.Name = "checkBox_ShowGrid";
            this.checkBox_ShowGrid.Size = new System.Drawing.Size(95, 24);
            this.checkBox_ShowGrid.TabIndex = 3;
            this.checkBox_ShowGrid.Text = "Show Grid";
            this.checkBox_ShowGrid.UseVisualStyleBackColor = true;
            this.checkBox_ShowGrid.CheckedChanged += new System.EventHandler(this.CheckBox_ShowGrid_CheckedChanged);
            // 
            // MapPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_MainEditor);
            this.Name = "MapPanel";
            this.Size = new System.Drawing.Size(1045, 519);
            this.tableLayoutPanel_MainEditor.ResumeLayout(false);
            this.tableLayoutPanel_MainEditorSettings.ResumeLayout(false);
            this.tableLayoutPanel_MainEditorSettings.PerformLayout();
            this.panel_LayerSettings.ResumeLayout(false);
            this.panel_LayerSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_MainEditor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_MainEditorSettings;
        private System.Windows.Forms.Panel panel_LayerSettings;
        private System.Windows.Forms.Label label_Layers;
        public MapEditor mapEditor;
        public System.Windows.Forms.CheckBox checkBox_ShowHitboxes;
        public System.Windows.Forms.ComboBox comboBox_Layers;
        public System.Windows.Forms.CheckBox checkBox_ShowGrid;
    }
}
