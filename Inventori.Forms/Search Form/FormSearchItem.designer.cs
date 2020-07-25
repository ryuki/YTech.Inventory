namespace Inventori.Forms
{
    partial class FormSearchItem
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
            this.lbl_TempTransaction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Search)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_SearchByName
            // 
            this.txt_SearchByName.Text = "<Cari Berdasar Nama Item>";
            // 
            // txt_SearchById
            // 
            this.txt_SearchById.Text = "<Cari Berdasar Kode Item>";
            // 
            // lbl_TempTransaction
            // 
            this.lbl_TempTransaction.AutoSize = true;
            this.lbl_TempTransaction.Location = new System.Drawing.Point(3, 385);
            this.lbl_TempTransaction.Name = "lbl_TempTransaction";
            this.lbl_TempTransaction.Size = new System.Drawing.Size(106, 13);
            this.lbl_TempTransaction.TabIndex = 7;
            this.lbl_TempTransaction.Text = "lbl_TempTransaction";
            this.lbl_TempTransaction.Visible = false;
            // 
            // FormSearchItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(535, 405);
            this.Name = "FormSearchItem";
            this.TabText = "Pencarian Item";
            this.Text = "Pencarian Item";
            this.Load += new System.EventHandler(this.FormSearchItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Search)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbl_TempTransaction;
    }
}
