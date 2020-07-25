namespace Inventori.Forms
{
    partial class FormSearchEkspedission
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Search)).BeginInit();
            this.SuspendLayout();
            // 
            // FormSearchEkspedission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 405);
            this.Name = "FormSearchEkspedission";
            this.TabText = "Pencarian Ekspedisi";
            this.Text = "Pencarian Ekspedisi";
            this.Load += new System.EventHandler(this.FormSearchEkspedission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Search)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}