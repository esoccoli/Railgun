namespace Railgun.Editor.App.Controls
{
    partial class TilePanel
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
            this.tableLayoutPanel_Tiles = new System.Windows.Forms.TableLayoutPanel();
            this.label_TilePicker = new System.Windows.Forms.Label();
            this.panel_Objects = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_TilePicker = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_TileSettings = new System.Windows.Forms.TableLayoutPanel();
            this.panel_TileSizeSettings = new System.Windows.Forms.Panel();
            this.numericUpDown_TileSize = new System.Windows.Forms.NumericUpDown();
            this.label_TileSize = new System.Windows.Forms.Label();
            this.panel_TilePicker = new System.Windows.Forms.Panel();
            this.tabControl_Tileset = new System.Windows.Forms.TabControl();
            this.tabPage_EmptyTileset = new System.Windows.Forms.TabPage();
            this.tilePicker_Empty = new Railgun.Editor.App.Controls.TilePicker();
            this.label_NoTilesets = new System.Windows.Forms.Label();
            this.tableLayoutPanel_Tiles.SuspendLayout();
            this.panel_Objects.SuspendLayout();
            this.tableLayoutPanel_TilePicker.SuspendLayout();
            this.tableLayoutPanel_TileSettings.SuspendLayout();
            this.panel_TileSizeSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TileSize)).BeginInit();
            this.panel_TilePicker.SuspendLayout();
            this.tabControl_Tileset.SuspendLayout();
            this.tabPage_EmptyTileset.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel_Tiles.Size = new System.Drawing.Size(689, 447);
            this.tableLayoutPanel_Tiles.TabIndex = 7;
            // 
            // label_TilePicker
            // 
            this.label_TilePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_TilePicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_TilePicker.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_TilePicker.Location = new System.Drawing.Point(0, 0);
            this.label_TilePicker.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label_TilePicker.Name = "label_TilePicker";
            this.label_TilePicker.Size = new System.Drawing.Size(689, 16);
            this.label_TilePicker.TabIndex = 3;
            this.label_TilePicker.Text = "Tile Picker";
            this.label_TilePicker.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel_Objects
            // 
            this.panel_Objects.Controls.Add(this.tableLayoutPanel_TilePicker);
            this.panel_Objects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Objects.Location = new System.Drawing.Point(0, 20);
            this.panel_Objects.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Objects.Name = "panel_Objects";
            this.panel_Objects.Size = new System.Drawing.Size(689, 427);
            this.panel_Objects.TabIndex = 4;
            // 
            // tableLayoutPanel_TilePicker
            // 
            this.tableLayoutPanel_TilePicker.ColumnCount = 1;
            this.tableLayoutPanel_TilePicker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_TilePicker.Controls.Add(this.tableLayoutPanel_TileSettings, 0, 0);
            this.tableLayoutPanel_TilePicker.Controls.Add(this.panel_TilePicker, 0, 1);
            this.tableLayoutPanel_TilePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_TilePicker.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_TilePicker.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_TilePicker.Name = "tableLayoutPanel_TilePicker";
            this.tableLayoutPanel_TilePicker.RowCount = 2;
            this.tableLayoutPanel_TilePicker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_TilePicker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_TilePicker.Size = new System.Drawing.Size(689, 427);
            this.tableLayoutPanel_TilePicker.TabIndex = 1;
            // 
            // tableLayoutPanel_TileSettings
            // 
            this.tableLayoutPanel_TileSettings.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel_TileSettings.ColumnCount = 1;
            this.tableLayoutPanel_TileSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_TileSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_TileSettings.Controls.Add(this.panel_TileSizeSettings, 0, 0);
            this.tableLayoutPanel_TileSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_TileSettings.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_TileSettings.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_TileSettings.Name = "tableLayoutPanel_TileSettings";
            this.tableLayoutPanel_TileSettings.RowCount = 1;
            this.tableLayoutPanel_TileSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_TileSettings.Size = new System.Drawing.Size(689, 50);
            this.tableLayoutPanel_TileSettings.TabIndex = 2;
            // 
            // panel_TileSizeSettings
            // 
            this.panel_TileSizeSettings.AutoSize = true;
            this.panel_TileSizeSettings.Controls.Add(this.numericUpDown_TileSize);
            this.panel_TileSizeSettings.Controls.Add(this.label_TileSize);
            this.panel_TileSizeSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_TileSizeSettings.Location = new System.Drawing.Point(0, 0);
            this.panel_TileSizeSettings.Margin = new System.Windows.Forms.Padding(0);
            this.panel_TileSizeSettings.Name = "panel_TileSizeSettings";
            this.panel_TileSizeSettings.Size = new System.Drawing.Size(689, 50);
            this.panel_TileSizeSettings.TabIndex = 7;
            // 
            // numericUpDown_TileSize
            // 
            this.numericUpDown_TileSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDown_TileSize.Location = new System.Drawing.Point(351, 14);
            this.numericUpDown_TileSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown_TileSize.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_TileSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_TileSize.Name = "numericUpDown_TileSize";
            this.numericUpDown_TileSize.Size = new System.Drawing.Size(67, 22);
            this.numericUpDown_TileSize.TabIndex = 5;
            this.numericUpDown_TileSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label_TileSize
            // 
            this.label_TileSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_TileSize.AutoSize = true;
            this.label_TileSize.BackColor = System.Drawing.Color.Transparent;
            this.label_TileSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_TileSize.Location = new System.Drawing.Point(265, 14);
            this.label_TileSize.Name = "label_TileSize";
            this.label_TileSize.Size = new System.Drawing.Size(67, 20);
            this.label_TileSize.TabIndex = 4;
            this.label_TileSize.Text = "Tile Size:";
            // 
            // panel_TilePicker
            // 
            this.panel_TilePicker.Controls.Add(this.tabControl_Tileset);
            this.panel_TilePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_TilePicker.Location = new System.Drawing.Point(0, 50);
            this.panel_TilePicker.Margin = new System.Windows.Forms.Padding(0);
            this.panel_TilePicker.Name = "panel_TilePicker";
            this.panel_TilePicker.Size = new System.Drawing.Size(689, 377);
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
            this.tabControl_Tileset.Size = new System.Drawing.Size(689, 377);
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
            this.tabPage_EmptyTileset.Size = new System.Drawing.Size(681, 344);
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
            this.label_NoTilesets.Location = new System.Drawing.Point(160, 107);
            this.label_NoTilesets.Name = "label_NoTilesets";
            this.label_NoTilesets.Size = new System.Drawing.Size(369, 140);
            this.label_NoTilesets.TabIndex = 3;
            this.label_NoTilesets.Text = "No tilesets found!\r\n\r\nMake sure there is a subdirectory within\r\nContent containin" +
    "g the tilesets and that\r\nthey are added to the content manager.\r\n\r\nFor example: " +
    "Content/Tiles/Tileset.png";
            this.label_NoTilesets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_Tiles);
            this.Name = "TilePanel";
            this.Size = new System.Drawing.Size(689, 447);
            this.tableLayoutPanel_Tiles.ResumeLayout(false);
            this.panel_Objects.ResumeLayout(false);
            this.tableLayoutPanel_TilePicker.ResumeLayout(false);
            this.tableLayoutPanel_TileSettings.ResumeLayout(false);
            this.tableLayoutPanel_TileSettings.PerformLayout();
            this.panel_TileSizeSettings.ResumeLayout(false);
            this.panel_TileSizeSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TileSize)).EndInit();
            this.panel_TilePicker.ResumeLayout(false);
            this.tabControl_Tileset.ResumeLayout(false);
            this.tabPage_EmptyTileset.ResumeLayout(false);
            this.tabPage_EmptyTileset.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Tiles;
        private System.Windows.Forms.Label label_TilePicker;
        private System.Windows.Forms.Panel panel_Objects;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_TilePicker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_TileSettings;
        private System.Windows.Forms.Panel panel_TileSizeSettings;
        private System.Windows.Forms.Label label_TileSize;
        private System.Windows.Forms.Panel panel_TilePicker;
        private System.Windows.Forms.TabPage tabPage_EmptyTileset;
        private TilePicker tilePicker_Empty;
        public System.Windows.Forms.NumericUpDown numericUpDown_TileSize;
        public System.Windows.Forms.TabControl tabControl_Tileset;
        public System.Windows.Forms.Label label_NoTilesets;
    }
}
