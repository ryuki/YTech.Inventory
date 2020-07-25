namespace Inventori.Apotek.Forms
{
    partial class FormMasterEmployee
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
            System.Windows.Forms.Label employeeStatusLabel;
            System.Windows.Forms.Label employeeStartWorkLabel;
            System.Windows.Forms.Label employeeBirthDateLabel;
            System.Windows.Forms.Label employeeBirthPlaceLabel;
            System.Windows.Forms.Label employeeMaritalStatusLabel;
            System.Windows.Forms.Label employeeIdCardLabel;
            System.Windows.Forms.Label employeePhoneLabel;
            System.Windows.Forms.Label employeeGenderLabel;
            System.Windows.Forms.Label employeeAddressLabel;
            System.Windows.Forms.Label depIdLabel;
            System.Windows.Forms.Label employeeNameLabel;
            System.Windows.Forms.Label employeeIdLabel;
            this.employeeStatusComboBox = new System.Windows.Forms.ComboBox();
            this.employeeStartWorkDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.employeeBirthDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.employeeBirthPlaceTextBox = new System.Windows.Forms.TextBox();
            this.employeeMaritalStatusComboBox = new System.Windows.Forms.ComboBox();
            this.employeeIdCardTextBox = new System.Windows.Forms.TextBox();
            this.employeePhoneTextBox = new System.Windows.Forms.TextBox();
            this.employeeGenderComboBox = new System.Windows.Forms.ComboBox();
            this.employeeAddressTextBox = new System.Windows.Forms.TextBox();
            this.depIdComboBox = new System.Windows.Forms.ComboBox();
            this.employeeNameTextBox = new System.Windows.Forms.TextBox();
            this.employeeIdTextBox = new System.Windows.Forms.TextBox();
            employeeStatusLabel = new System.Windows.Forms.Label();
            employeeStartWorkLabel = new System.Windows.Forms.Label();
            employeeBirthDateLabel = new System.Windows.Forms.Label();
            employeeBirthPlaceLabel = new System.Windows.Forms.Label();
            employeeMaritalStatusLabel = new System.Windows.Forms.Label();
            employeeIdCardLabel = new System.Windows.Forms.Label();
            employeePhoneLabel = new System.Windows.Forms.Label();
            employeeGenderLabel = new System.Windows.Forms.Label();
            employeeAddressLabel = new System.Windows.Forms.Label();
            depIdLabel = new System.Windows.Forms.Label();
            employeeNameLabel = new System.Windows.Forms.Label();
            employeeIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MEmployee);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(employeeStatusLabel);
            this.groupBox1.Controls.Add(this.employeeStatusComboBox);
            this.groupBox1.Controls.Add(employeeStartWorkLabel);
            this.groupBox1.Controls.Add(this.employeeStartWorkDateTimePicker);
            this.groupBox1.Controls.Add(employeeBirthDateLabel);
            this.groupBox1.Controls.Add(this.employeeBirthDateDateTimePicker);
            this.groupBox1.Controls.Add(employeeBirthPlaceLabel);
            this.groupBox1.Controls.Add(this.employeeBirthPlaceTextBox);
            this.groupBox1.Controls.Add(employeeMaritalStatusLabel);
            this.groupBox1.Controls.Add(this.employeeMaritalStatusComboBox);
            this.groupBox1.Controls.Add(employeeIdCardLabel);
            this.groupBox1.Controls.Add(this.employeeIdCardTextBox);
            this.groupBox1.Controls.Add(employeePhoneLabel);
            this.groupBox1.Controls.Add(this.employeePhoneTextBox);
            this.groupBox1.Controls.Add(employeeGenderLabel);
            this.groupBox1.Controls.Add(this.employeeGenderComboBox);
            this.groupBox1.Controls.Add(employeeAddressLabel);
            this.groupBox1.Controls.Add(this.employeeAddressTextBox);
            this.groupBox1.Controls.Add(depIdLabel);
            this.groupBox1.Controls.Add(this.depIdComboBox);
            this.groupBox1.Controls.Add(employeeNameLabel);
            this.groupBox1.Controls.Add(this.employeeNameTextBox);
            this.groupBox1.Controls.Add(employeeIdLabel);
            this.groupBox1.Controls.Add(this.employeeIdTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 191);
            this.groupBox1.Text = "Master Detail Karyawan";
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 191;
            // 
            // employeeStatusLabel
            // 
            employeeStatusLabel.AutoSize = true;
            employeeStatusLabel.Location = new System.Drawing.Point(326, 158);
            employeeStatusLabel.Name = "employeeStatusLabel";
            employeeStatusLabel.Size = new System.Drawing.Size(40, 13);
            employeeStatusLabel.TabIndex = 46;
            employeeStatusLabel.Text = "Status:";
            // 
            // employeeStartWorkLabel
            // 
            employeeStartWorkLabel.AutoSize = true;
            employeeStartWorkLabel.Location = new System.Drawing.Point(326, 133);
            employeeStartWorkLabel.Name = "employeeStartWorkLabel";
            employeeStartWorkLabel.Size = new System.Drawing.Size(74, 13);
            employeeStartWorkLabel.TabIndex = 44;
            employeeStartWorkLabel.Text = "Mulai Bekerja:";
            // 
            // employeeBirthDateLabel
            // 
            employeeBirthDateLabel.AutoSize = true;
            employeeBirthDateLabel.Location = new System.Drawing.Point(326, 107);
            employeeBirthDateLabel.Name = "employeeBirthDateLabel";
            employeeBirthDateLabel.Size = new System.Drawing.Size(75, 13);
            employeeBirthDateLabel.TabIndex = 42;
            employeeBirthDateLabel.Text = "Tanggal Lahir:";
            // 
            // employeeBirthPlaceLabel
            // 
            employeeBirthPlaceLabel.AutoSize = true;
            employeeBirthPlaceLabel.Location = new System.Drawing.Point(326, 80);
            employeeBirthPlaceLabel.Name = "employeeBirthPlaceLabel";
            employeeBirthPlaceLabel.Size = new System.Drawing.Size(72, 13);
            employeeBirthPlaceLabel.TabIndex = 40;
            employeeBirthPlaceLabel.Text = "Tempat Lahir:";
            // 
            // employeeMaritalStatusLabel
            // 
            employeeMaritalStatusLabel.AutoSize = true;
            employeeMaritalStatusLabel.Location = new System.Drawing.Point(326, 53);
            employeeMaritalStatusLabel.Name = "employeeMaritalStatusLabel";
            employeeMaritalStatusLabel.Size = new System.Drawing.Size(72, 13);
            employeeMaritalStatusLabel.TabIndex = 38;
            employeeMaritalStatusLabel.Text = "Status Kawin:";
            // 
            // employeeIdCardLabel
            // 
            employeeIdCardLabel.AutoSize = true;
            employeeIdCardLabel.Location = new System.Drawing.Point(326, 27);
            employeeIdCardLabel.Name = "employeeIdCardLabel";
            employeeIdCardLabel.Size = new System.Drawing.Size(48, 13);
            employeeIdCardLabel.TabIndex = 36;
            employeeIdCardLabel.Text = "No KTP:";
            // 
            // employeePhoneLabel
            // 
            employeePhoneLabel.AutoSize = true;
            employeePhoneLabel.Location = new System.Drawing.Point(6, 132);
            employeePhoneLabel.Name = "employeePhoneLabel";
            employeePhoneLabel.Size = new System.Drawing.Size(49, 13);
            employeePhoneLabel.TabIndex = 34;
            employeePhoneLabel.Text = "Telepon:";
            // 
            // employeeGenderLabel
            // 
            employeeGenderLabel.AutoSize = true;
            employeeGenderLabel.Location = new System.Drawing.Point(6, 158);
            employeeGenderLabel.Name = "employeeGenderLabel";
            employeeGenderLabel.Size = new System.Drawing.Size(74, 13);
            employeeGenderLabel.TabIndex = 32;
            employeeGenderLabel.Text = "Jenis Kelamin:";
            // 
            // employeeAddressLabel
            // 
            employeeAddressLabel.AutoSize = true;
            employeeAddressLabel.Location = new System.Drawing.Point(6, 106);
            employeeAddressLabel.Name = "employeeAddressLabel";
            employeeAddressLabel.Size = new System.Drawing.Size(42, 13);
            employeeAddressLabel.TabIndex = 30;
            employeeAddressLabel.Text = "Alamat:";
            // 
            // depIdLabel
            // 
            depIdLabel.AutoSize = true;
            depIdLabel.Location = new System.Drawing.Point(6, 79);
            depIdLabel.Name = "depIdLabel";
            depIdLabel.Size = new System.Drawing.Size(43, 13);
            depIdLabel.TabIndex = 28;
            depIdLabel.Text = "Bagian:";
            // 
            // employeeNameLabel
            // 
            employeeNameLabel.AutoSize = true;
            employeeNameLabel.Location = new System.Drawing.Point(6, 53);
            employeeNameLabel.Name = "employeeNameLabel";
            employeeNameLabel.Size = new System.Drawing.Size(88, 13);
            employeeNameLabel.TabIndex = 26;
            employeeNameLabel.Text = "Nama Karyawan:";
            // 
            // employeeIdLabel
            // 
            employeeIdLabel.AutoSize = true;
            employeeIdLabel.Location = new System.Drawing.Point(6, 27);
            employeeIdLabel.Name = "employeeIdLabel";
            employeeIdLabel.Size = new System.Drawing.Size(85, 13);
            employeeIdLabel.TabIndex = 24;
            employeeIdLabel.Text = "Kode Karyawan:";
            // 
            // employeeStatusComboBox
            // 
            this.employeeStatusComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bindingSource_Master, "EmployeeStatus", true));
            this.employeeStatusComboBox.FormattingEnabled = true;
            this.employeeStatusComboBox.Location = new System.Drawing.Point(455, 155);
            this.employeeStatusComboBox.Name = "employeeStatusComboBox";
            this.employeeStatusComboBox.Size = new System.Drawing.Size(121, 21);
            this.employeeStatusComboBox.TabIndex = 47;
            this.employeeStatusComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // employeeStartWorkDateTimePicker
            // 
            this.employeeStartWorkDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource_Master, "EmployeeStartWork", true));
            this.employeeStartWorkDateTimePicker.Location = new System.Drawing.Point(455, 129);
            this.employeeStartWorkDateTimePicker.Name = "employeeStartWorkDateTimePicker";
            this.employeeStartWorkDateTimePicker.Size = new System.Drawing.Size(130, 20);
            this.employeeStartWorkDateTimePicker.TabIndex = 45;
            this.employeeStartWorkDateTimePicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // employeeBirthDateDateTimePicker
            // 
            this.employeeBirthDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource_Master, "EmployeeBirthDate", true));
            this.employeeBirthDateDateTimePicker.Location = new System.Drawing.Point(455, 103);
            this.employeeBirthDateDateTimePicker.Name = "employeeBirthDateDateTimePicker";
            this.employeeBirthDateDateTimePicker.Size = new System.Drawing.Size(130, 20);
            this.employeeBirthDateDateTimePicker.TabIndex = 43;
            this.employeeBirthDateDateTimePicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // employeeBirthPlaceTextBox
            // 
            this.employeeBirthPlaceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "EmployeeBirthPlace", true));
            this.employeeBirthPlaceTextBox.Location = new System.Drawing.Point(455, 77);
            this.employeeBirthPlaceTextBox.Name = "employeeBirthPlaceTextBox";
            this.employeeBirthPlaceTextBox.Size = new System.Drawing.Size(143, 20);
            this.employeeBirthPlaceTextBox.TabIndex = 41;
            this.employeeBirthPlaceTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // employeeMaritalStatusComboBox
            // 
            this.employeeMaritalStatusComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bindingSource_Master, "EmployeeMaritalStatus", true));
            this.employeeMaritalStatusComboBox.FormattingEnabled = true;
            this.employeeMaritalStatusComboBox.Location = new System.Drawing.Point(455, 50);
            this.employeeMaritalStatusComboBox.Name = "employeeMaritalStatusComboBox";
            this.employeeMaritalStatusComboBox.Size = new System.Drawing.Size(121, 21);
            this.employeeMaritalStatusComboBox.TabIndex = 39;
            this.employeeMaritalStatusComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // employeeIdCardTextBox
            // 
            this.employeeIdCardTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "EmployeeIdCard", true));
            this.employeeIdCardTextBox.Location = new System.Drawing.Point(455, 24);
            this.employeeIdCardTextBox.Name = "employeeIdCardTextBox";
            this.employeeIdCardTextBox.Size = new System.Drawing.Size(143, 20);
            this.employeeIdCardTextBox.TabIndex = 37;
            this.employeeIdCardTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // employeePhoneTextBox
            // 
            this.employeePhoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "EmployeePhone", true));
            this.employeePhoneTextBox.Location = new System.Drawing.Point(106, 129);
            this.employeePhoneTextBox.Name = "employeePhoneTextBox";
            this.employeePhoneTextBox.Size = new System.Drawing.Size(100, 20);
            this.employeePhoneTextBox.TabIndex = 35;
            this.employeePhoneTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // employeeGenderComboBox
            // 
            this.employeeGenderComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bindingSource_Master, "EmployeeGender", true));
            this.employeeGenderComboBox.FormattingEnabled = true;
            this.employeeGenderComboBox.Location = new System.Drawing.Point(106, 155);
            this.employeeGenderComboBox.Name = "employeeGenderComboBox";
            this.employeeGenderComboBox.Size = new System.Drawing.Size(121, 21);
            this.employeeGenderComboBox.TabIndex = 33;
            this.employeeGenderComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // employeeAddressTextBox
            // 
            this.employeeAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "EmployeeAddress", true));
            this.employeeAddressTextBox.Location = new System.Drawing.Point(106, 103);
            this.employeeAddressTextBox.Name = "employeeAddressTextBox";
            this.employeeAddressTextBox.Size = new System.Drawing.Size(214, 20);
            this.employeeAddressTextBox.TabIndex = 31;
            this.employeeAddressTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // depIdComboBox
            // 
            this.depIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource_Master, "DepId", true));
            this.depIdComboBox.FormattingEnabled = true;
            this.depIdComboBox.Location = new System.Drawing.Point(106, 76);
            this.depIdComboBox.Name = "depIdComboBox";
            this.depIdComboBox.Size = new System.Drawing.Size(121, 21);
            this.depIdComboBox.TabIndex = 29;
            this.depIdComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // employeeNameTextBox
            // 
            this.employeeNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "EmployeeName", true));
            this.employeeNameTextBox.Location = new System.Drawing.Point(106, 50);
            this.employeeNameTextBox.Name = "employeeNameTextBox";
            this.employeeNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.employeeNameTextBox.TabIndex = 27;
            this.employeeNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // employeeIdTextBox
            // 
            this.employeeIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "EmployeeId", true));
            this.employeeIdTextBox.Location = new System.Drawing.Point(106, 24);
            this.employeeIdTextBox.Name = "employeeIdTextBox";
            this.employeeIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.employeeIdTextBox.TabIndex = 25;
            this.employeeIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // FormMasterEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterEmployee";
            this.TabText = "Master Karyawan";
            this.Text = "Master Karyawan";
            this.Load += new System.EventHandler(this.FormMasterEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox employeeStatusComboBox;
        private System.Windows.Forms.DateTimePicker employeeStartWorkDateTimePicker;
        private System.Windows.Forms.DateTimePicker employeeBirthDateDateTimePicker;
        private System.Windows.Forms.TextBox employeeBirthPlaceTextBox;
        private System.Windows.Forms.ComboBox employeeMaritalStatusComboBox;
        private System.Windows.Forms.TextBox employeeIdCardTextBox;
        private System.Windows.Forms.TextBox employeePhoneTextBox;
        private System.Windows.Forms.ComboBox employeeGenderComboBox;
        private System.Windows.Forms.TextBox employeeAddressTextBox;
        private System.Windows.Forms.ComboBox depIdComboBox;
        private System.Windows.Forms.TextBox employeeNameTextBox;
        private System.Windows.Forms.TextBox employeeIdTextBox;
    }
}
