namespace MonoGame.Forms.DX
{
    partial class Form1
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
            this.sampleControl = new MonoGame.Forms.DX.Controls.SampleControl();
            this.SuspendLayout();
            // 
            // sampleControl
            // 
            this.sampleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sampleControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleControl.Location = new System.Drawing.Point(0, 0);
            this.sampleControl.MouseHoverUpdatesOnly = false;
            this.sampleControl.Name = "sampleControl";
            this.sampleControl.Size = new System.Drawing.Size(582, 353);
            this.sampleControl.TabIndex = 0;
            this.sampleControl.Text = "Sample Control";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.sampleControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SampleControl sampleControl;
    }
}

