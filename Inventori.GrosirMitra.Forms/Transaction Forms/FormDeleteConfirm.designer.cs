namespace Inventori.GrosirMitra.Forms
{
    partial class FormDeleteConfirm
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
            this.deletePinLabel = new System.Windows.Forms.Label();
            this.discountPinTextBox = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deletePinLabel
            // 
            this.deletePinLabel.AutoSize = true;
            this.deletePinLabel.Location = new System.Drawing.Point(25, 15);
            this.deletePinLabel.Name = "deletePinLabel";
            this.deletePinLabel.Size = new System.Drawing.Size(114, 13);
            this.deletePinLabel.TabIndex = 1;
            this.deletePinLabel.Text = "Pin Diskon Penjualan :";
            // 
            // discountPinTextBox
            // 
            this.discountPinTextBox.Location = new System.Drawing.Point(195, 12);
            this.discountPinTextBox.Name = "discountPinTextBox";
            this.discountPinTextBox.Size = new System.Drawing.Size(150, 20);
            this.discountPinTextBox.TabIndex = 2;
            this.discountPinTextBox.UseSystemPasswordChar = true;
            this.discountPinTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.deletePinTextBox_KeyDown);
            // 
            // btn_OK
            // 
            this.btn_OK.Image = global::Inventori.GrosirMitra.Forms.Properties.Resources.OK;
            this.btn_OK.Location = new System.Drawing.Point(37, 45);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(143, 46);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "OK";
            this.btn_OK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_OK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Image = global::Inventori.GrosirMitra.Forms.Properties.Resources.delete;
            this.btn_Cancel.Location = new System.Drawing.Point(202, 45);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(143, 46);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Batal";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // FormDeleteConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 98);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.deletePinLabel);
            this.Controls.Add(this.discountPinTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDeleteConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Konfirmasi Diskon Penjualan";
            this.Controls.SetChildIndex(this.discountPinTextBox, 0);
            this.Controls.SetChildIndex(this.deletePinLabel, 0);
            this.Controls.SetChildIndex(this.btn_OK, 0);
            this.Controls.SetChildIndex(this.btn_Cancel, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        public System.Windows.Forms.Label deletePinLabel;
        public System.Windows.Forms.TextBox discountPinTextBox;
    }
}