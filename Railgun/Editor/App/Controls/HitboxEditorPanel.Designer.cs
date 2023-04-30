namespace Railgun.Editor.App.Controls
{
    partial class HitboxEditorPanel
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
            this.tableLayoutPanel_Edit = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Edit = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_EditTable = new System.Windows.Forms.TableLayoutPanel();
            this.currentTileDisplay = new Railgun.Editor.App.Controls.CurrentTileDisplay();
            this.label_Edit = new System.Windows.Forms.Label();
            this.tableLayoutPanel_EditSettings = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_Solid = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel_Edit.SuspendLayout();
            this.panel_Edit.SuspendLayout();
            this.tableLayoutPanel_EditTable.SuspendLayout();
            this.tableLayoutPanel_EditSettings.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel_Edit.Size = new System.Drawing.Size(580, 475);
            this.tableLayoutPanel_Edit.TabIndex = 9;
            // 
            // panel_Edit
            // 
            this.panel_Edit.Controls.Add(this.tableLayoutPanel_EditTable);
            this.panel_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Edit.Location = new System.Drawing.Point(0, 70);
            this.panel_Edit.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Edit.Name = "panel_Edit";
            this.panel_Edit.Size = new System.Drawing.Size(580, 405);
            this.panel_Edit.TabIndex = 5;
            // 
            // tableLayoutPanel_EditTable
            // 
            this.tableLayoutPanel_EditTable.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel_EditTable.ColumnCount = 3;
            this.tableLayoutPanel_EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_EditTable.Controls.Add(this.currentTileDisplay, 1, 1);
            this.tableLayoutPanel_EditTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_EditTable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel_EditTable.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_EditTable.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_EditTable.Name = "tableLayoutPanel_EditTable";
            this.tableLayoutPanel_EditTable.RowCount = 3;
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_EditTable.Size = new System.Drawing.Size(580, 405);
            this.tableLayoutPanel_EditTable.TabIndex = 1;
            // 
            // currentTileDisplay
            // 
            this.currentTileDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.currentTileDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.currentTileDisplay.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold);
            this.currentTileDisplay.ForeColor = System.Drawing.Color.Black;
            this.currentTileDisplay.Location = new System.Drawing.Point(215, 127);
            this.currentTileDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.currentTileDisplay.Name = "currentTileDisplay";
            this.currentTileDisplay.Size = new System.Drawing.Size(149, 150);
            this.currentTileDisplay.TabIndex = 1;
            this.currentTileDisplay.Text = "currentTileDisplay";
            // 
            // label_Edit
            // 
            this.label_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Edit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_Edit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Edit.Location = new System.Drawing.Point(0, 0);
            this.label_Edit.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label_Edit.Name = "label_Edit";
            this.label_Edit.Size = new System.Drawing.Size(580, 16);
            this.label_Edit.TabIndex = 4;
            this.label_Edit.Text = "Edit Hitbox";
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
            this.tableLayoutPanel_EditSettings.Size = new System.Drawing.Size(580, 50);
            this.tableLayoutPanel_EditSettings.TabIndex = 6;
            // 
            // checkBox_Solid
            // 
            this.checkBox_Solid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox_Solid.AutoSize = true;
            this.checkBox_Solid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_Solid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBox_Solid.Location = new System.Drawing.Point(234, 13);
            this.checkBox_Solid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_Solid.Name = "checkBox_Solid";
            this.checkBox_Solid.Size = new System.Drawing.Size(111, 24);
            this.checkBox_Solid.TabIndex = 0;
            this.checkBox_Solid.Text = "Place Hitbox";
            this.checkBox_Solid.UseVisualStyleBackColor = true;
            this.checkBox_Solid.CheckedChanged += new System.EventHandler(this.CheckBox_Solid_CheckedChanged);
            // 
            // HitboxEditorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_Edit);
            this.Name = "HitboxEditorPanel";
            this.Size = new System.Drawing.Size(580, 475);
            this.tableLayoutPanel_Edit.ResumeLayout(false);
            this.panel_Edit.ResumeLayout(false);
            this.tableLayoutPanel_EditTable.ResumeLayout(false);
            this.tableLayoutPanel_EditSettings.ResumeLayout(false);
            this.tableLayoutPanel_EditSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Edit;
        private System.Windows.Forms.Panel panel_Edit;
        private System.Windows.Forms.Label label_Edit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_EditSettings;
        public System.Windows.Forms.CheckBox checkBox_Solid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_EditTable;
        public CurrentTileDisplay currentTileDisplay;
    }
}
