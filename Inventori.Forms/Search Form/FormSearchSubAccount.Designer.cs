namespace Inventori.Forms
{
    partial class FormSearchSubAccount
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
            // txt_SearchByName
            // 
            this.txt_SearchByName.Text = "<Cari Berdasar Nama Akun>";
            // 
            // txt_SearchById
            // 
            this.txt_SearchById.Text = "<Cari Berdasar Kode Akun>";
            // 
            // FormSearchSubAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 405);
            this.Name = "FormSearchSubAccount";
            this.TabText = "Pencarian Akun";
            this.Text = "Pencarian Akun";
            this.Load += new System.EventHandler(this.FormSearchSubAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Search)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}