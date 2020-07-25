namespace Inventori.Forms
{
    partial class FormChangePassword
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label userPasswordLabel;
            System.Windows.Forms.Label userNameLabel;
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.userPasswordTextBoxConfirm = new System.Windows.Forms.TextBox();
            this.userPasswordTextBoxNew = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userPasswordTextBox = new System.Windows.Forms.TextBox();
            this.userNameLabel1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            userPasswordLabel = new System.Windows.Forms.Label();
            userNameLabel = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(26, 48);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(93, 13);
            label2.TabIndex = 6;
            label2.Text = "Ulang Kata Kunci:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(26, 22);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(87, 13);
            label1.TabIndex = 4;
            label1.Text = "Kata Kunci Baru:";
            // 
            // userPasswordLabel
            // 
            userPasswordLabel.AutoSize = true;
            userPasswordLabel.Location = new System.Drawing.Point(26, 54);
            userPasswordLabel.Name = "userPasswordLabel";
            userPasswordLabel.Size = new System.Drawing.Size(62, 13);
            userPasswordLabel.TabIndex = 2;
            userPasswordLabel.Text = "Kata Kunci:";
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new System.Drawing.Point(25, 25);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new System.Drawing.Size(90, 13);
            userNameLabel.TabIndex = 1;
            userNameLabel.Text = "Nama Pengguna:";
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Image = global::Inventori.Forms.Properties.Resources.users;
            this.buttonOK.Location = new System.Drawing.Point(122, 186);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(201, 45);
            this.buttonOK.TabIndex = 12;
            this.buttonOK.Text = "Ganti Kata Kunci";
            this.buttonOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Image = global::Inventori.Forms.Properties.Resources.delete16;
            this.buttonCancel.Location = new System.Drawing.Point(12, 186);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(88, 45);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Tutup";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.userPasswordTextBoxConfirm);
            this.groupBox2.Controls.Add(label2);
            this.groupBox2.Controls.Add(this.userPasswordTextBoxNew);
            this.groupBox2.Controls.Add(label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 78);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kata Kunci Baru";
            // 
            // userPasswordTextBoxConfirm
            // 
            this.userPasswordTextBoxConfirm.Location = new System.Drawing.Point(135, 45);
            this.userPasswordTextBoxConfirm.Name = "userPasswordTextBoxConfirm";
            this.userPasswordTextBoxConfirm.PasswordChar = '*';
            this.userPasswordTextBoxConfirm.Size = new System.Drawing.Size(152, 20);
            this.userPasswordTextBoxConfirm.TabIndex = 7;
            this.userPasswordTextBoxConfirm.UseSystemPasswordChar = true;
            // 
            // userPasswordTextBoxNew
            // 
            this.userPasswordTextBoxNew.Location = new System.Drawing.Point(135, 19);
            this.userPasswordTextBoxNew.Name = "userPasswordTextBoxNew";
            this.userPasswordTextBoxNew.PasswordChar = '*';
            this.userPasswordTextBoxNew.Size = new System.Drawing.Size(152, 20);
            this.userPasswordTextBoxNew.TabIndex = 5;
            this.userPasswordTextBoxNew.UseSystemPasswordChar = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.userPasswordTextBox);
            this.groupBox1.Controls.Add(userPasswordLabel);
            this.groupBox1.Controls.Add(this.userNameLabel1);
            this.groupBox1.Controls.Add(userNameLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 84);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kata Kunci Lama";
            // 
            // userPasswordTextBox
            // 
            this.userPasswordTextBox.Location = new System.Drawing.Point(132, 51);
            this.userPasswordTextBox.Name = "userPasswordTextBox";
            this.userPasswordTextBox.PasswordChar = '*';
            this.userPasswordTextBox.Size = new System.Drawing.Size(152, 20);
            this.userPasswordTextBox.TabIndex = 3;
            this.userPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // userNameLabel1
            // 
            this.userNameLabel1.AutoSize = true;
            this.userNameLabel1.Location = new System.Drawing.Point(132, 25);
            this.userNameLabel1.Name = "userNameLabel1";
            this.userNameLabel1.Size = new System.Drawing.Size(57, 13);
            this.userNameLabel1.TabIndex = 2;
            this.userNameLabel1.Text = "UserName";
            // 
            // FormChangePassword
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(339, 254);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "Ganti Kata Kunci";
            this.Text = "Ganti Kata Kunci";
            this.Load += new System.EventHandler(this.FormChangePassword_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.buttonOK, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox userPasswordTextBoxConfirm;
        private System.Windows.Forms.TextBox userPasswordTextBoxNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox userPasswordTextBox;
        public System.Windows.Forms.Label userNameLabel1;
    }
}
