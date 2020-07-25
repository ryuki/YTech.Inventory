namespace Inventori.Contractor.Forms
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
            System.Windows.Forms.Label deletePinLabel;
            this.deletePinTextBox = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            deletePinLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deletePinLabel
            // 
            deletePinLabel.AutoSize = true;
            deletePinLabel.Location = new System.Drawing.Point(51, 15);
            deletePinLabel.Name = "deletePinLabel";
            deletePinLabel.Size = new System.Drawing.Size(88, 13);
            deletePinLabel.TabIndex = 1;
            deletePinLabel.Text = "Pin Hapus Data :";
            // 
            // deletePinTextBox
            // 
            this.deletePinTextBox.Location = new System.Drawing.Point(145, 12);
            this.deletePinTextBox.Name = "deletePinTextBox";
            this.deletePinTextBox.Size = new System.Drawing.Size(150, 20);
            this.deletePinTextBox.TabIndex = 2;
            this.deletePinTextBox.UseSystemPasswordChar = true;
            this.deletePinTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.deletePinTextBox_KeyDown);
            // 
            // btn_OK
            // 
            this.btn_OK.Image = global::Inventori.Contractor.Forms.Properties.Resources.OK;
            this.btn_OK.Location = new System.Drawing.Point(12, 45);
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
            this.btn_Cancel.Image = global::Inventori.Contractor.Forms.Properties.Resources.delete16;
            this.btn_Cancel.Location = new System.Drawing.Point(177, 45);
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
            this.ClientSize = new System.Drawing.Size(332, 98);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(deletePinLabel);
            this.Controls.Add(this.deletePinTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDeleteConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Konfirmasi Hapus Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox deletePinTextBox;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}