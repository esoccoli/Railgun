namespace Railgun.Editor
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
            this.mainEditorPanel1 = new Railgun.Editor.Controls.MainEditorPanel();
            this.SuspendLayout();
            // 
            // mainEditorPanel1
            // 
            this.mainEditorPanel1.Location = new System.Drawing.Point(328, 74);
            this.mainEditorPanel1.MouseHoverUpdatesOnly = false;
            this.mainEditorPanel1.Name = "mainEditorPanel1";
            this.mainEditorPanel1.Size = new System.Drawing.Size(390, 394);
            this.mainEditorPanel1.TabIndex = 0;
            this.mainEditorPanel1.Text = "mainEditorPanel1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.mainEditorPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.MainEditorPanel mainEditorPanel1;
    }
}