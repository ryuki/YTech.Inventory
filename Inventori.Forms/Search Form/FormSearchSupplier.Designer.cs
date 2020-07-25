namespace Inventori.Forms
{
    partial class FormSearchSupplier
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
            this.employeeStartWorkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIdCardDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeBirthPlaceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeBirthDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeGenderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeMaritalStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeePhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Search)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource_Search
            // 
            this.bindingSource_Search.DataSource = typeof(Inventori.Data.MEmployee);
            // 
            // txt_SearchByName
            // 
            this.txt_SearchByName.Text = "<Cari Berdasar Nama Supplier>";
            // 
            // txt_SearchById
            // 
            this.txt_SearchById.Text = "<Cari Berdasar Kode Supplier>";
            // 
            // employeeStartWorkDataGridViewTextBoxColumn
            // 
            this.employeeStartWorkDataGridViewTextBoxColumn.DataPropertyName = "EmployeeStartWork";
            this.employeeStartWorkDataGridViewTextBoxColumn.HeaderText = "EmployeeStartWork";
            this.employeeStartWorkDataGridViewTextBoxColumn.Name = "employeeStartWorkDataGridViewTextBoxColumn";
            this.employeeStartWorkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeIdCardDataGridViewTextBoxColumn
            // 
            this.employeeIdCardDataGridViewTextBoxColumn.DataPropertyName = "EmployeeIdCard";
            this.employeeIdCardDataGridViewTextBoxColumn.HeaderText = "EmployeeIdCard";
            this.employeeIdCardDataGridViewTextBoxColumn.Name = "employeeIdCardDataGridViewTextBoxColumn";
            this.employeeIdCardDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeIdDataGridViewTextBoxColumn
            // 
            this.employeeIdDataGridViewTextBoxColumn.DataPropertyName = "EmployeeId";
            this.employeeIdDataGridViewTextBoxColumn.HeaderText = "EmployeeId";
            this.employeeIdDataGridViewTextBoxColumn.Name = "employeeIdDataGridViewTextBoxColumn";
            this.employeeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeNameDataGridViewTextBoxColumn
            // 
            this.employeeNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeeName";
            this.employeeNameDataGridViewTextBoxColumn.HeaderText = "EmployeeName";
            this.employeeNameDataGridViewTextBoxColumn.Name = "employeeNameDataGridViewTextBoxColumn";
            this.employeeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeBirthPlaceDataGridViewTextBoxColumn
            // 
            this.employeeBirthPlaceDataGridViewTextBoxColumn.DataPropertyName = "EmployeeBirthPlace";
            this.employeeBirthPlaceDataGridViewTextBoxColumn.HeaderText = "EmployeeBirthPlace";
            this.employeeBirthPlaceDataGridViewTextBoxColumn.Name = "employeeBirthPlaceDataGridViewTextBoxColumn";
            this.employeeBirthPlaceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeBirthDateDataGridViewTextBoxColumn
            // 
            this.employeeBirthDateDataGridViewTextBoxColumn.DataPropertyName = "EmployeeBirthDate";
            this.employeeBirthDateDataGridViewTextBoxColumn.HeaderText = "EmployeeBirthDate";
            this.employeeBirthDateDataGridViewTextBoxColumn.Name = "employeeBirthDateDataGridViewTextBoxColumn";
            this.employeeBirthDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeGenderDataGridViewTextBoxColumn
            // 
            this.employeeGenderDataGridViewTextBoxColumn.DataPropertyName = "EmployeeGender";
            this.employeeGenderDataGridViewTextBoxColumn.HeaderText = "EmployeeGender";
            this.employeeGenderDataGridViewTextBoxColumn.Name = "employeeGenderDataGridViewTextBoxColumn";
            this.employeeGenderDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // depIdDataGridViewTextBoxColumn
            // 
            this.depIdDataGridViewTextBoxColumn.DataPropertyName = "DepId";
            this.depIdDataGridViewTextBoxColumn.HeaderText = "DepId";
            this.depIdDataGridViewTextBoxColumn.Name = "depIdDataGridViewTextBoxColumn";
            this.depIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeStatusDataGridViewTextBoxColumn
            // 
            this.employeeStatusDataGridViewTextBoxColumn.DataPropertyName = "EmployeeStatus";
            this.employeeStatusDataGridViewTextBoxColumn.HeaderText = "EmployeeStatus";
            this.employeeStatusDataGridViewTextBoxColumn.Name = "employeeStatusDataGridViewTextBoxColumn";
            this.employeeStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeMaritalStatusDataGridViewTextBoxColumn
            // 
            this.employeeMaritalStatusDataGridViewTextBoxColumn.DataPropertyName = "EmployeeMaritalStatus";
            this.employeeMaritalStatusDataGridViewTextBoxColumn.HeaderText = "EmployeeMaritalStatus";
            this.employeeMaritalStatusDataGridViewTextBoxColumn.Name = "employeeMaritalStatusDataGridViewTextBoxColumn";
            this.employeeMaritalStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeePhoneDataGridViewTextBoxColumn
            // 
            this.employeePhoneDataGridViewTextBoxColumn.DataPropertyName = "EmployeePhone";
            this.employeePhoneDataGridViewTextBoxColumn.HeaderText = "EmployeePhone";
            this.employeePhoneDataGridViewTextBoxColumn.Name = "employeePhoneDataGridViewTextBoxColumn";
            this.employeePhoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeAddressDataGridViewTextBoxColumn
            // 
            this.employeeAddressDataGridViewTextBoxColumn.DataPropertyName = "EmployeeAddress";
            this.employeeAddressDataGridViewTextBoxColumn.HeaderText = "EmployeeAddress";
            this.employeeAddressDataGridViewTextBoxColumn.Name = "employeeAddressDataGridViewTextBoxColumn";
            this.employeeAddressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormSearchSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(535, 405);
            this.Name = "FormSearchSupplier";
            this.TabText = "Pencarian Supplier";
            this.Text = "Pencarian Supplier";
            this.Load += new System.EventHandler(this.FormSearchEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Search)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn employeeStartWorkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIdCardDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeBirthPlaceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeBirthDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeGenderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn depIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeMaritalStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeePhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeAddressDataGridViewTextBoxColumn;
    }
}
