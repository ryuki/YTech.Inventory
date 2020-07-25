namespace Inventori.Forms
{
    partial class FormBackupDatabase
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gb_Backup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_BackupFile = new System.Windows.Forms.TextBox();
            this.btn_Backup = new System.Windows.Forms.Button();
            this.lbl_Auto = new System.Windows.Forms.Label();
            this.lbl_Loading = new System.Windows.Forms.Label();
            this.txt_BackupDir = new System.Windows.Forms.TextBox();
            this.pb_Loading = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.grid_Tables = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.gb_Backup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Tables)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gb_Backup);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 100);
            this.panel1.TabIndex = 9;
            // 
            // gb_Backup
            // 
            this.gb_Backup.Controls.Add(this.label4);
            this.gb_Backup.Controls.Add(this.txt_BackupFile);
            this.gb_Backup.Controls.Add(this.btn_Backup);
            this.gb_Backup.Location = new System.Drawing.Point(10, 12);
            this.gb_Backup.Name = "gb_Backup";
            this.gb_Backup.Size = new System.Drawing.Size(535, 77);
            this.gb_Backup.TabIndex = 7;
            this.gb_Backup.TabStop = false;
            this.gb_Backup.Text = "Backup Database";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "File Backup";
            // 
            // txt_BackupFile
            // 
            this.txt_BackupFile.Location = new System.Drawing.Point(75, 17);
            this.txt_BackupFile.Name = "txt_BackupFile";
            this.txt_BackupFile.ReadOnly = true;
            this.txt_BackupFile.Size = new System.Drawing.Size(450, 20);
            this.txt_BackupFile.TabIndex = 5;
            // 
            // btn_Backup
            // 
            this.btn_Backup.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Backup.Image = global::Inventori.Forms.Properties.Resources.backup_restore;
            this.btn_Backup.Location = new System.Drawing.Point(139, 43);
            this.btn_Backup.Name = "btn_Backup";
            this.btn_Backup.Size = new System.Drawing.Size(200, 28);
            this.btn_Backup.TabIndex = 0;
            this.btn_Backup.Text = "Mulai Backup Database";
            this.btn_Backup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Backup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Backup.UseVisualStyleBackColor = true;
            this.btn_Backup.Click += new System.EventHandler(this.btn_Backup_Click);
            // 
            // lbl_Auto
            // 
            this.lbl_Auto.AutoSize = true;
            this.lbl_Auto.Location = new System.Drawing.Point(18, 134);
            this.lbl_Auto.Name = "lbl_Auto";
            this.lbl_Auto.Size = new System.Drawing.Size(45, 13);
            this.lbl_Auto.TabIndex = 13;
            this.lbl_Auto.Text = "lbl_Auto";
            this.lbl_Auto.Visible = false;
            // 
            // lbl_Loading
            // 
            this.lbl_Loading.AutoSize = true;
            this.lbl_Loading.Location = new System.Drawing.Point(179, 127);
            this.lbl_Loading.Name = "lbl_Loading";
            this.lbl_Loading.Size = new System.Drawing.Size(192, 26);
            this.lbl_Loading.TabIndex = 11;
            this.lbl_Loading.Text = "Backup Database sedang dilakukan ...\r\nSilahkan Tunggu ...";
            this.lbl_Loading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Loading.Visible = false;
            // 
            // txt_BackupDir
            // 
            this.txt_BackupDir.Location = new System.Drawing.Point(12, 188);
            this.txt_BackupDir.Name = "txt_BackupDir";
            this.txt_BackupDir.ReadOnly = true;
            this.txt_BackupDir.Size = new System.Drawing.Size(286, 20);
            this.txt_BackupDir.TabIndex = 12;
            this.txt_BackupDir.Visible = false;
            // 
            // pb_Loading
            // 
            this.pb_Loading.Location = new System.Drawing.Point(59, 106);
            this.pb_Loading.Name = "pb_Loading";
            this.pb_Loading.Size = new System.Drawing.Size(451, 18);
            this.pb_Loading.TabIndex = 10;
            this.pb_Loading.Visible = false;
            // 
            // grid_Tables
            // 
            this.grid_Tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Tables.Location = new System.Drawing.Point(395, 171);
            this.grid_Tables.Name = "grid_Tables";
            this.grid_Tables.Size = new System.Drawing.Size(46, 37);
            this.grid_Tables.TabIndex = 14;
            this.grid_Tables.Visible = false;
            // 
            // FormBackupDatabase
            // 
            this.AcceptButton = this.btn_Backup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(565, 165);
            this.Controls.Add(this.lbl_Loading);
            this.Controls.Add(this.lbl_Auto);
            this.Controls.Add(this.pb_Loading);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grid_Tables);
            this.Controls.Add(this.txt_BackupDir);
            this.Name = "FormBackupDatabase";
            this.TabText = "Backup Database";
            this.Text = "Backup Database";
            this.Load += new System.EventHandler(this.FormBackupDatabase_Load);
            this.Controls.SetChildIndex(this.txt_BackupDir, 0);
            this.Controls.SetChildIndex(this.grid_Tables, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pb_Loading, 0);
            this.Controls.SetChildIndex(this.lbl_Auto, 0);
            this.Controls.SetChildIndex(this.lbl_Loading, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.panel1.ResumeLayout(false);
            this.gb_Backup.ResumeLayout(false);
            this.gb_Backup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Tables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gb_Backup;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txt_BackupFile;
        public System.Windows.Forms.Button btn_Backup;
        public System.Windows.Forms.Label lbl_Auto;
        private System.Windows.Forms.Label lbl_Loading;
        private System.Windows.Forms.TextBox txt_BackupDir;
        private System.Windows.Forms.ProgressBar pb_Loading;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView grid_Tables;
    }
}
