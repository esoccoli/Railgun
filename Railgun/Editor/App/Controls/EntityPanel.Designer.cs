namespace Railgun.Editor.App.Controls
{
    partial class EntityPanel
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Eraser", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Entrence", 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Exit", 2);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Skeleton", 3);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Gas Man", 4);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Turret", 5);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Ghost", 6);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntityPanel));
            this.tableLayoutPanel_EntityPicker = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_EntitySettings = new System.Windows.Forms.TableLayoutPanel();
            this.panel_EntityPicker = new System.Windows.Forms.Panel();
            this.listView_Entities = new System.Windows.Forms.ListView();
            this.label_EntityPicker = new System.Windows.Forms.Label();
            this.imageList_Entities = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel_EntityPicker.SuspendLayout();
            this.panel_EntityPicker.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel_EntityPicker.Size = new System.Drawing.Size(570, 449);
            this.tableLayoutPanel_EntityPicker.TabIndex = 2;
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
            this.tableLayoutPanel_EntitySettings.Size = new System.Drawing.Size(570, 50);
            this.tableLayoutPanel_EntitySettings.TabIndex = 2;
            // 
            // panel_EntityPicker
            // 
            this.panel_EntityPicker.Controls.Add(this.listView_Entities);
            this.panel_EntityPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_EntityPicker.Location = new System.Drawing.Point(3, 72);
            this.panel_EntityPicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_EntityPicker.Name = "panel_EntityPicker";
            this.panel_EntityPicker.Size = new System.Drawing.Size(564, 375);
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
            listViewItem7.StateImageIndex = 0;
            this.listView_Entities.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7});
            this.listView_Entities.LargeImageList = this.imageList_Entities;
            this.listView_Entities.Location = new System.Drawing.Point(0, 0);
            this.listView_Entities.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView_Entities.MultiSelect = false;
            this.listView_Entities.Name = "listView_Entities";
            this.listView_Entities.Size = new System.Drawing.Size(564, 375);
            this.listView_Entities.TabIndex = 8;
            this.listView_Entities.TileSize = new System.Drawing.Size(20, 20);
            this.listView_Entities.UseCompatibleStateImageBehavior = false;
            this.listView_Entities.SelectedIndexChanged += new System.EventHandler(this.ListBox_EntityPicker_SelectedIndexChanged);
            // 
            // label_EntityPicker
            // 
            this.label_EntityPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_EntityPicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_EntityPicker.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_EntityPicker.Location = new System.Drawing.Point(0, 0);
            this.label_EntityPicker.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label_EntityPicker.Name = "label_EntityPicker";
            this.label_EntityPicker.Size = new System.Drawing.Size(570, 16);
            this.label_EntityPicker.TabIndex = 4;
            this.label_EntityPicker.Text = "Entity Picker";
            this.label_EntityPicker.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.imageList_Entities.Images.SetKeyName(5, "Turret.png");
            this.imageList_Entities.Images.SetKeyName(6, "Ghost.png");
            // 
            // EntityPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_EntityPicker);
            this.Name = "EntityPanel";
            this.Size = new System.Drawing.Size(570, 449);
            this.tableLayoutPanel_EntityPicker.ResumeLayout(false);
            this.panel_EntityPicker.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_EntityPicker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_EntitySettings;
        private System.Windows.Forms.Panel panel_EntityPicker;
        private System.Windows.Forms.ListView listView_Entities;
        private System.Windows.Forms.Label label_EntityPicker;
        private System.Windows.Forms.ImageList imageList_Entities;
    }
}
