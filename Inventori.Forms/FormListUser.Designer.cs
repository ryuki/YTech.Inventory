namespace Inventori.Forms
{
    partial class FormListUser
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
            System.Windows.Forms.Label userNameLabel;
            System.Windows.Forms.Label userPasswordLabel;
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userPasswordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userStatusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userPasswordTextBox = new System.Windows.Forms.TextBox();
            this.userStatusCheckBox = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grid_MenuAccess = new System.Windows.Forms.DataGridView();
            userNameLabel = new System.Windows.Forms.Label();
            userPasswordLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_MenuAccess)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MUser);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer2);
            this.groupBox1.Size = new System.Drawing.Size(788, 317);
            this.groupBox1.Text = "Detail Pengguna:";
            this.groupBox1.Controls.SetChildIndex(this.splitContainer2, 0);
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 317;
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new System.Drawing.Point(9, 15);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new System.Drawing.Size(90, 13);
            userNameLabel.TabIndex = 1;
            userNameLabel.Text = "Nama Pengguna:";
            // 
            // userPasswordLabel
            // 
            userPasswordLabel.AutoSize = true;
            userPasswordLabel.Location = new System.Drawing.Point(9, 41);
            userPasswordLabel.Name = "userPasswordLabel";
            userPasswordLabel.Size = new System.Drawing.Size(62, 13);
            userPasswordLabel.TabIndex = 3;
            userPasswordLabel.Text = "Kata Kunci:";
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userPasswordDataGridViewTextBoxColumn
            // 
            this.userPasswordDataGridViewTextBoxColumn.DataPropertyName = "UserPassword";
            this.userPasswordDataGridViewTextBoxColumn.HeaderText = "UserPassword";
            this.userPasswordDataGridViewTextBoxColumn.Name = "userPasswordDataGridViewTextBoxColumn";
            this.userPasswordDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userStatusDataGridViewCheckBoxColumn
            // 
            this.userStatusDataGridViewCheckBoxColumn.DataPropertyName = "UserStatus";
            this.userStatusDataGridViewCheckBoxColumn.HeaderText = "UserStatus";
            this.userStatusDataGridViewCheckBoxColumn.Name = "userStatusDataGridViewCheckBoxColumn";
            this.userStatusDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "UserName", true));
            this.userNameTextBox.Location = new System.Drawing.Point(105, 12);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(120, 20);
            this.userNameTextBox.TabIndex = 2;
            // 
            // userPasswordTextBox
            // 
            this.userPasswordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "UserPassword", true));
            this.userPasswordTextBox.Location = new System.Drawing.Point(105, 38);
            this.userPasswordTextBox.Name = "userPasswordTextBox";
            this.userPasswordTextBox.Size = new System.Drawing.Size(120, 20);
            this.userPasswordTextBox.TabIndex = 4;
            // 
            // userStatusCheckBox
            // 
            this.userStatusCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource_Master, "UserStatus", true));
            this.userStatusCheckBox.Location = new System.Drawing.Point(105, 64);
            this.userStatusCheckBox.Name = "userStatusCheckBox";
            this.userStatusCheckBox.Size = new System.Drawing.Size(95, 24);
            this.userStatusCheckBox.TabIndex = 6;
            this.userStatusCheckBox.Text = "Aktif";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 16);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(userNameLabel);
            this.splitContainer2.Panel1.Controls.Add(this.userStatusCheckBox);
            this.splitContainer2.Panel1.Controls.Add(this.userNameTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.userPasswordTextBox);
            this.splitContainer2.Panel1.Controls.Add(userPasswordLabel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grid_MenuAccess);
            this.splitContainer2.Size = new System.Drawing.Size(782, 298);
            this.splitContainer2.SplitterDistance = 238;
            this.splitContainer2.TabIndex = 7;
            // 
            // grid_MenuAccess
            // 
            this.grid_MenuAccess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_MenuAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_MenuAccess.Location = new System.Drawing.Point(0, 0);
            this.grid_MenuAccess.Name = "grid_MenuAccess";
            this.grid_MenuAccess.Size = new System.Drawing.Size(540, 298);
            this.grid_MenuAccess.TabIndex = 0;
            // 
            // FormListUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormListUser";
            this.TabText = "Daftar Pengguna";
            this.Text = "Daftar Pengguna";
            this.Load += new System.EventHandler(this.FormListUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_MenuAccess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userPasswordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn userStatusDataGridViewCheckBoxColumn;
        public System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.CheckBox userStatusCheckBox;
        public System.Windows.Forms.TextBox userNameTextBox;
        public System.Windows.Forms.TextBox userPasswordTextBox;
        public System.Windows.Forms.DataGridView grid_MenuAccess;
    }
}
