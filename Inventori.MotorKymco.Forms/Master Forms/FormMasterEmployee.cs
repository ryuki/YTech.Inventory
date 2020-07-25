using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Inventori.Data;
using Inventori.Facade;
using Inventori.Module;

namespace Inventori.MotorKymco.Forms
{
    public partial class FormMasterEmployee : Inventori.Forms.FormParentForMasterForm
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MEmployee emp;

        public FormMasterEmployee()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MEmployee.ColumnNames.EmployeeId;
            grid_Col.HeaderText = "Kode Karyawan";
            grid_Master.Columns.Add(grid_Col);
            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MEmployee.ColumnNames.EmployeeName;
            grid_Col.HeaderText = "Nama Karyawan";
            grid_Master.Columns.Add(grid_Col);
            //add kolom bagian
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MEmployee.ColumnNames.DepId;
            grid_Col.HeaderText = "Bagian";
            grid_Master.Columns.Add(grid_Col);
            //add kolom status
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MEmployee.ColumnNames.EmployeeStatus;
            grid_Col.HeaderText = "Status";
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged +=new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterEmployee_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MEmployee, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            ModuleControlSettings.SetDepartmentComboBox(depIdComboBox);
            ModuleControlSettings.SetGenderComboBox(employeeGenderComboBox);
            ModuleControlSettings.SetMaritalStatusComboBox(employeeMaritalStatusComboBox);
            ModuleControlSettings.SetEmployeeStatusComboBox(employeeStatusComboBox);
            ModuleControlSettings.SetDateTimePicker(employeeBirthDateDateTimePicker, false);
            ModuleControlSettings.SetDateTimePicker(employeeStartWorkDateTimePicker, false);

            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MEmployee));
            if (listMaster.Count > 0)
                bindingSource_Master.DataSource = listMaster;
            else
                bindingSource_Master.Clear();

            bindingSource_Master_PositionChanged(null, null);
            detailControl_KeyDown(null, null);
        }

        private void bindingSource_Master_PositionChanged(object sender, EventArgs e)
        {
            SetNavigatorDisplay();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            employeeIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            employeeIdTextBox.Enabled = false;
            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(employeeIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(employeeIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    emp = (MEmployee)DataMaster.GetObjectById(typeof(MEmployee), employeeIdTextBox.Text);
                    DataMaster.Delete(emp);
                    ModuleControlSettings.SaveLog(ListOfAction.Delete, employeeIdTextBox.Text, ListOfTable.MEmployee, lbl_UserName.Text);
                    BindData();

                }
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (employeeIdTextBox.Enabled == true)
                emp = new MEmployee();
            else
                emp = (MEmployee)DataMaster.GetObjectById(typeof(MEmployee), employeeIdTextBox.Text);

            emp.DepId = depIdComboBox.SelectedValue.ToString();
            emp.EmployeeDesc = employeeDescTextBox.Text;
            emp.EmployeeDesc2 = employeeDesc2TextBox.Text;
            emp.EmployeeAddress = employeeAddressTextBox.Text;
            emp.EmployeeBirthDate = employeeBirthDateDateTimePicker.Value;
            emp.EmployeeBirthPlace = employeeBirthPlaceTextBox.Text;
            emp.EmployeeGender = employeeGenderComboBox.SelectedItem.ToString();
            emp.EmployeeId = employeeIdTextBox.Text;
            emp.EmployeeIdCard = employeeIdCardTextBox.Text;
            emp.EmployeeMaritalStatus = employeeMaritalStatusComboBox.SelectedItem.ToString();
            emp.EmployeeName = employeeNameTextBox.Text;
            emp.EmployeePhone = employeePhoneTextBox.Text;
            emp.EmployeeStartWork = employeeStartWorkDateTimePicker.Value;
            emp.EmployeeStatus = employeeStatusComboBox.SelectedItem.ToString();
            emp.ModifiedBy = lbl_UserName.Text;
            emp.ModifiedDate = DateTime.Now;



            if (employeeIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(emp);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Karyawan dengan kode " + employeeIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
                    balloonHelp.ShowBalloon(employeeIdTextBox);
                    employeeIdTextBox.Focus();
                    return;
                }
                ModuleControlSettings.SaveLog(ListOfAction.Insert, employeeIdTextBox.Text, ListOfTable.MEmployee, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(emp);
                ModuleControlSettings.SaveLog(ListOfAction.Update, employeeIdTextBox.Text, ListOfTable.MEmployee, lbl_UserName.Text);
            }

            BindData();
        }

        private bool ValidateForm()
        {
            RecreateBalloon();
            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(employeeIdTextBox.Text))
            {
                balloonHelp.Content = "Kode karyawan harus diisi";
                balloonHelp.ShowBalloon(employeeIdTextBox);
                employeeIdTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(employeeNameTextBox.Text))
            {
                balloonHelp.Content = "Nama karyawan harus diisi";
                balloonHelp.ShowBalloon(employeeNameTextBox);
                employeeNameTextBox.Focus();
                return false;
            }
            else if (depIdComboBox.SelectedIndex == -1)
            {
                balloonHelp.Content = "Pilih bagian";
                balloonHelp.ShowBalloon(depIdComboBox);
                depIdComboBox.Focus();
                return false;
            }
            else if (employeeGenderComboBox.SelectedIndex == -1)
            {
                balloonHelp.Content = "Pilih jenis kelamin";
                balloonHelp.ShowBalloon(employeeGenderComboBox);
                employeeGenderComboBox.Focus();
                return false;
            }
            else if (employeeMaritalStatusComboBox.SelectedIndex == -1)
            {
                balloonHelp.Content = "Pilih status kawin";
                balloonHelp.ShowBalloon(employeeMaritalStatusComboBox);
                employeeMaritalStatusComboBox.Focus();
                return false;
            }
            else if (employeeStatusComboBox.SelectedIndex == -1)
            {
                balloonHelp.Content = "Pilih status karyawan";
                balloonHelp.ShowBalloon(employeeStatusComboBox);
                employeeStatusComboBox.Focus();
                return false;
            }

            return true;
        }

        private void bindingNavigatorRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void detailControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender == null)
                employeeIdTextBox.Focus();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                Control c = (Control)sender;
                if (sender == employeeIdTextBox)
                    employeeNameTextBox.Focus();
                else if (sender == employeeNameTextBox)
                    depIdComboBox.Focus();
                else if (sender == depIdComboBox)
                    employeeAddressTextBox.Focus();
                else if (sender == employeeAddressTextBox)
                    employeePhoneTextBox.Focus();
                else if (sender == employeePhoneTextBox)
                    employeeGenderComboBox.Focus();
                else if (sender == employeeGenderComboBox)
                    employeeIdCardTextBox.Focus();
                else if (sender == employeeIdCardTextBox)
                    employeeMaritalStatusComboBox.Focus();
                else if (sender == employeeMaritalStatusComboBox)
                    employeeBirthPlaceTextBox.Focus();
                else if (sender == employeeBirthPlaceTextBox)
                    employeeBirthDateDateTimePicker.Focus();
                else if (sender == employeeBirthDateDateTimePicker)
                    employeeStartWorkDateTimePicker.Focus();
                else if (sender == employeeStartWorkDateTimePicker)
                    employeeStatusComboBox.Focus();
                else if (sender == employeeStatusComboBox)
                    bindingNavigatorSaveItem_Click(null, null);

            }
        }
    }
}

