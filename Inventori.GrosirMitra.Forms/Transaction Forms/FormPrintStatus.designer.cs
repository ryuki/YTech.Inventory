namespace Inventori.GrosirMitra.Forms
{
    partial class FormPrintStatus
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
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Replay = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Location = new System.Drawing.Point(12, 9);
            // 
            // button_OK
            // 
            this.button_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Image = global::Inventori.GrosirMitra.Forms.Properties.Resources.OK;
            this.button_OK.Location = new System.Drawing.Point(15, 97);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(117, 61);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "Cetak Faktur Berhasil";
            this.button_OK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Replay
            // 
            this.button_Replay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Replay.Image = global::Inventori.GrosirMitra.Forms.Properties.Resources.printer;
            this.button_Replay.Location = new System.Drawing.Point(152, 97);
            this.button_Replay.Name = "button_Replay";
            this.button_Replay.Size = new System.Drawing.Size(117, 61);
            this.button_Replay.TabIndex = 2;
            this.button_Replay.Text = "Ulang Cetak Faktur";
            this.button_Replay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Replay.UseVisualStyleBackColor = true;
            this.button_Replay.Click += new System.EventHandler(this.button_Replay_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.Image = global::Inventori.GrosirMitra.Forms.Properties.Resources.delete;
            this.button_Cancel.Location = new System.Drawing.Point(288, 97);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(117, 61);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "Batal";
            this.button_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 52);
            this.label1.TabIndex = 4;
            this.label1.Text = "Apakah faktur sudah terprint dengan baik?\r\nKlik Cetak Faktur Berhasil jika cetak " +
                "faktur selesai\r\nKlik Ulang Cetak Faktur jika ingin mengulang cetak faktur\r\nDan k" +
                "lik Batal untuk membatalkan";
            // 
            // FormPrintStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(421, 167);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Replay);
            this.Controls.Add(this.button_OK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrintStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "Konfirmasi Cetak Faktur";
            this.Text = "Konfirmasi Cetak Faktur";
            this.Controls.SetChildIndex(this.button_OK, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.Controls.SetChildIndex(this.button_Replay, 0);
            this.Controls.SetChildIndex(this.button_Cancel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Replay;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label1;
    }
}
