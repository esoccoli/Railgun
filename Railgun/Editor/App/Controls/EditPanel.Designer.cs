namespace Railgun.Editor.App.Controls
{
    partial class EditPanel
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
            this.button_Edit_FlipHorizontal = new System.Windows.Forms.Button();
            this.button_Edit_FlipVertical = new System.Windows.Forms.Button();
            this.button_Edit_RotateCW = new System.Windows.Forms.Button();
            this.button_Edit_RotateCCW = new System.Windows.Forms.Button();
            this.button_Edit_Up = new System.Windows.Forms.Button();
            this.button_Edit_Left = new System.Windows.Forms.Button();
            this.button_Edit_Down = new System.Windows.Forms.Button();
            this.button_Edit_Right = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel_Edit.Size = new System.Drawing.Size(597, 515);
            this.tableLayoutPanel_Edit.TabIndex = 8;
            // 
            // panel_Edit
            // 
            this.panel_Edit.Controls.Add(this.tableLayoutPanel_EditTable);
            this.panel_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Edit.Location = new System.Drawing.Point(0, 70);
            this.panel_Edit.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Edit.Name = "panel_Edit";
            this.panel_Edit.Size = new System.Drawing.Size(597, 445);
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
            this.tableLayoutPanel_EditTable.Size = new System.Drawing.Size(597, 445);
            this.tableLayoutPanel_EditTable.TabIndex = 0;
            // 
            // currentTileDisplay
            // 
            this.currentTileDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.currentTileDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel_EditTable.SetColumnSpan(this.currentTileDisplay, 3);
            this.currentTileDisplay.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold);
            this.currentTileDisplay.ForeColor = System.Drawing.Color.Black;
            this.currentTileDisplay.Location = new System.Drawing.Point(223, 146);
            this.currentTileDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.currentTileDisplay.Name = "currentTileDisplay";
            this.tableLayoutPanel_EditTable.SetRowSpan(this.currentTileDisplay, 3);
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
            this.label_Edit.Size = new System.Drawing.Size(597, 16);
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
            this.tableLayoutPanel_EditSettings.Size = new System.Drawing.Size(597, 50);
            this.tableLayoutPanel_EditSettings.TabIndex = 6;
            // 
            // checkBox_Solid
            // 
            this.checkBox_Solid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox_Solid.AutoSize = true;
            this.checkBox_Solid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_Solid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBox_Solid.Location = new System.Drawing.Point(243, 13);
            this.checkBox_Solid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_Solid.Name = "checkBox_Solid";
            this.checkBox_Solid.Size = new System.Drawing.Size(111, 24);
            this.checkBox_Solid.TabIndex = 0;
            this.checkBox_Solid.Text = "Place Hitbox";
            this.checkBox_Solid.UseVisualStyleBackColor = true;
            this.checkBox_Solid.CheckedChanged += new System.EventHandler(this.CheckBox_Solid_CheckedChanged);
            // 
            // button_Edit_FlipHorizontal
            // 
            this.button_Edit_FlipHorizontal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_FlipHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_FlipHorizontal.Image = global::Railgun.Editor.Properties.Resources.Flip_Horizontal;
            this.button_Edit_FlipHorizontal.Location = new System.Drawing.Point(458, 344);
            this.button_Edit_FlipHorizontal.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_FlipHorizontal.Name = "button_Edit_FlipHorizontal";
            this.button_Edit_FlipHorizontal.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_FlipHorizontal.TabIndex = 9;
            this.button_Edit_FlipHorizontal.UseVisualStyleBackColor = true;
            this.button_Edit_FlipHorizontal.Click += new System.EventHandler(this.Button_FlipHorizontally_Click);
            // 
            // button_Edit_FlipVertical
            // 
            this.button_Edit_FlipVertical.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_FlipVertical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_FlipVertical.Image = global::Railgun.Editor.Properties.Resources.Flip_Vertical;
            this.button_Edit_FlipVertical.Location = new System.Drawing.Point(86, 344);
            this.button_Edit_FlipVertical.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_FlipVertical.Name = "button_Edit_FlipVertical";
            this.button_Edit_FlipVertical.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_FlipVertical.TabIndex = 7;
            this.button_Edit_FlipVertical.UseVisualStyleBackColor = true;
            this.button_Edit_FlipVertical.Click += new System.EventHandler(this.Button_Edit_FlipVertically_Click);
            // 
            // button_Edit_RotateCW
            // 
            this.button_Edit_RotateCW.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_RotateCW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Edit_RotateCW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_RotateCW.Image = global::Railgun.Editor.Properties.Resources.Clockwise;
            this.button_Edit_RotateCW.Location = new System.Drawing.Point(458, 48);
            this.button_Edit_RotateCW.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_RotateCW.Name = "button_Edit_RotateCW";
            this.button_Edit_RotateCW.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_RotateCW.TabIndex = 2;
            this.button_Edit_RotateCW.UseVisualStyleBackColor = true;
            this.button_Edit_RotateCW.Click += new System.EventHandler(this.Button_Rotate90CW_Click);
            // 
            // button_Edit_RotateCCW
            // 
            this.button_Edit_RotateCCW.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_RotateCCW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_RotateCCW.Image = global::Railgun.Editor.Properties.Resources.Counter_Clockwise;
            this.button_Edit_RotateCCW.Location = new System.Drawing.Point(86, 48);
            this.button_Edit_RotateCCW.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_RotateCCW.Name = "button_Edit_RotateCCW";
            this.button_Edit_RotateCCW.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_RotateCCW.TabIndex = 3;
            this.button_Edit_RotateCCW.UseVisualStyleBackColor = true;
            this.button_Edit_RotateCCW.Click += new System.EventHandler(this.Button_Rotate90CCW_Click);
            // 
            // button_Edit_Up
            // 
            this.button_Edit_Up.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_Up.Image = global::Railgun.Editor.Properties.Resources.Move_Up;
            this.button_Edit_Up.Location = new System.Drawing.Point(272, 48);
            this.button_Edit_Up.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_Up.Name = "button_Edit_Up";
            this.button_Edit_Up.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_Up.TabIndex = 4;
            this.button_Edit_Up.UseVisualStyleBackColor = true;
            this.button_Edit_Up.Visible = false;
            this.button_Edit_Up.Click += new System.EventHandler(this.Button_MoveUp_Click);
            // 
            // button_Edit_Left
            // 
            this.button_Edit_Left.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_Left.Image = global::Railgun.Editor.Properties.Resources.Move_Left;
            this.button_Edit_Left.Location = new System.Drawing.Point(86, 196);
            this.button_Edit_Left.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_Left.Name = "button_Edit_Left";
            this.button_Edit_Left.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_Left.TabIndex = 5;
            this.button_Edit_Left.UseVisualStyleBackColor = true;
            this.button_Edit_Left.Visible = false;
            this.button_Edit_Left.Click += new System.EventHandler(this.Button_MoveLeft_Click);
            // 
            // button_Edit_Down
            // 
            this.button_Edit_Down.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_Down.Image = global::Railgun.Editor.Properties.Resources.Move_Down;
            this.button_Edit_Down.Location = new System.Drawing.Point(272, 344);
            this.button_Edit_Down.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_Down.Name = "button_Edit_Down";
            this.button_Edit_Down.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_Down.TabIndex = 8;
            this.button_Edit_Down.UseVisualStyleBackColor = true;
            this.button_Edit_Down.Visible = false;
            this.button_Edit_Down.Click += new System.EventHandler(this.Button_MoveDown_Click);
            // 
            // button_Edit_Right
            // 
            this.button_Edit_Right.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Edit_Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit_Right.Image = global::Railgun.Editor.Properties.Resources.Move_Right;
            this.button_Edit_Right.Location = new System.Drawing.Point(458, 196);
            this.button_Edit_Right.Margin = new System.Windows.Forms.Padding(0);
            this.button_Edit_Right.Name = "button_Edit_Right";
            this.button_Edit_Right.Size = new System.Drawing.Size(51, 50);
            this.button_Edit_Right.TabIndex = 6;
            this.button_Edit_Right.UseVisualStyleBackColor = true;
            this.button_Edit_Right.Visible = false;
            this.button_Edit_Right.Click += new System.EventHandler(this.Button_MoveRight_Click);
            // 
            // EditPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_Edit);
            this.Name = "EditPanel";
            this.Size = new System.Drawing.Size(597, 515);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_EditTable;
        private System.Windows.Forms.Label label_Edit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_EditSettings;
        public System.Windows.Forms.Button button_Edit_FlipHorizontal;
        public System.Windows.Forms.Button button_Edit_FlipVertical;
        public System.Windows.Forms.Button button_Edit_RotateCW;
        public System.Windows.Forms.Button button_Edit_RotateCCW;
        public CurrentTileDisplay currentTileDisplay;
        public System.Windows.Forms.Button button_Edit_Up;
        public System.Windows.Forms.Button button_Edit_Left;
        public System.Windows.Forms.Button button_Edit_Down;
        public System.Windows.Forms.Button button_Edit_Right;
        public System.Windows.Forms.CheckBox checkBox_Solid;
    }
}
