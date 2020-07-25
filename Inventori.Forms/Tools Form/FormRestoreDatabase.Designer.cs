namespace Inventori.Forms
{
    partial class FormRestoreDatabase
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
            this.txt_BackupDir = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gb_Restore = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_BackupFile = new System.Windows.Forms.Button();
            this.txt_BackupFile = new System.Windows.Forms.TextBox();
            this.btn_Restore = new System.Windows.Forms.Button();
            this.lbl_Loading = new System.Windows.Forms.Label();
            this.pb_Loading = new System.Windows.Forms.ProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grid_Tables = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.gb_Restore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Tables)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Visible = false;
            // 
            // txt_BackupDir
            // 
            this.txt_BackupDir.Location = new System.Drawing.Point(31, 184);
            this.txt_BackupDir.Name = "txt_BackupDir";
            this.txt_BackupDir.ReadOnly = true;
            this.txt_BackupDir.Size = new System.Drawing.Size(286, 20);
            this.txt_BackupDir.TabIndex = 12;
            this.txt_BackupDir.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gb_Restore);
            this.panel1.Location = new System.Drawing.Point(12, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 100);
            this.panel1.TabIndex = 15;
            // 
            // gb_Restore
            // 
            this.gb_Restore.Controls.Add(this.label4);
            this.gb_Restore.Controls.Add(this.btn_BackupFile);
            this.gb_Restore.Controls.Add(this.txt_BackupFile);
            this.gb_Restore.Controls.Add(this.btn_Restore);
            this.gb_Restore.Location = new System.Drawing.Point(19, 15);
            this.gb_Restore.Name = "gb_Restore";
            this.gb_Restore.Size = new System.Drawing.Size(504, 77);
            this.gb_Restore.TabIndex = 7;
            this.gb_Restore.TabStop = false;
            this.gb_Restore.Text = "Restore Database";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Pilih File Backup";
            // 
            // btn_BackupFile
            // 
            this.btn_BackupFile.Image = global::Inventori.Forms.Properties.Resources._0003_folder;
            this.btn_BackupFile.Location = new System.Drawing.Point(389, 13);
            this.btn_BackupFile.Name = "btn_BackupFile";
            this.btn_BackupFile.Size = new System.Drawing.Size(109, 27);
            this.btn_BackupFile.TabIndex = 6;
            this.btn_BackupFile.Text = "Pilih File";
            this.btn_BackupFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_BackupFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_BackupFile.UseVisualStyleBackColor = true;
            this.btn_BackupFile.Click += new System.EventHandler(this.btn_BackupFile_Click);
            // 
            // txt_BackupFile
            // 
            this.txt_BackupFile.Location = new System.Drawing.Point(97, 17);
            this.txt_BackupFile.Name = "txt_BackupFile";
            this.txt_BackupFile.ReadOnly = true;
            this.txt_BackupFile.Size = new System.Drawing.Size(286, 20);
            this.txt_BackupFile.TabIndex = 5;
            // 
            // btn_Restore
            // 
            this.btn_Restore.Image = global::Inventori.Forms.Properties.Resources.backup_restore;
            this.btn_Restore.Location = new System.Drawing.Point(139, 43);
            this.btn_Restore.Name = "btn_Restore";
            this.btn_Restore.Size = new System.Drawing.Size(200, 28);
            this.btn_Restore.TabIndex = 0;
            this.btn_Restore.Text = "Mulai Restore Database";
            this.btn_Restore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Restore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Restore.UseVisualStyleBackColor = true;
            this.btn_Restore.Click += new System.EventHandler(this.btn_Restore_Click);
            // 
            // lbl_Loading
            // 
            this.lbl_Loading.AutoSize = true;
            this.lbl_Loading.Location = new System.Drawing.Point(157, 138);
            this.lbl_Loading.Name = "lbl_Loading";
            this.lbl_Loading.Size = new System.Drawing.Size(192, 26);
            this.lbl_Loading.TabIndex = 14;
            this.lbl_Loading.Text = "Restore Database sedang dilakukan ...\r\nSilahkan Tunggu ...";
            this.lbl_Loading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Loading.Visible = false;
            // 
            // pb_Loading
            // 
            this.pb_Loading.Location = new System.Drawing.Point(33, 109);
            this.pb_Loading.Name = "pb_Loading";
            this.pb_Loading.Size = new System.Drawing.Size(451, 18);
            this.pb_Loading.TabIndex = 13;
            this.pb_Loading.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // grid_Tables
            // 
            this.grid_Tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Tables.Location = new System.Drawing.Point(361, 198);
            this.grid_Tables.Name = "grid_Tables";
            this.grid_Tables.Size = new System.Drawing.Size(53, 43);
            this.grid_Tables.TabIndex = 16;
            this.grid_Tables.Visible = false;
            // 
            // FormRestoreDatabase
            // 
            this.AcceptButton = this.btn_Restore;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(566, 178);
            this.Controls.Add(this.grid_Tables);
            this.Controls.Add(this.txt_BackupDir);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_Loading);
            this.Controls.Add(this.pb_Loading);
            this.Name = "FormRestoreDatabase";
            this.TabText = "Restore Database";
            this.Text = "Restore Database";
            this.Load += new System.EventHandler(this.FormRestoreDatabase_Load);
            this.Controls.SetChildIndex(this.pb_Loading, 0);
            this.Controls.SetChildIndex(this.lbl_Loading, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.txt_BackupDir, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.Controls.SetChildIndex(this.grid_Tables, 0);
            this.panel1.ResumeLayout(false);
            this.gb_Restore.ResumeLayout(false);
            this.gb_Restore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Tables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_BackupDir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gb_Restore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_BackupFile;
        private System.Windows.Forms.TextBox txt_BackupFile;
        private System.Windows.Forms.Button btn_Restore;
        private System.Windows.Forms.Label lbl_Loading;
        private System.Windows.Forms.ProgressBar pb_Loading;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView grid_Tables;
    }
}
