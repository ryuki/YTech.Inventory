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

namespace Inventori.Apotek.Forms
{
    public partial class FormMasterCustomer : Inventori.Forms.FormParentForMasterForm
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MCustomer cust;

        public FormMasterCustomer()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MCustomer.ColumnNames.CustomerId;
            grid_Col.HeaderText = "Kode Pelanggan";
            grid_Master.Columns.Add(grid_Col);
            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MCustomer.ColumnNames.CustomerName;
            grid_Col.HeaderText = "Nama Pelanggan";
            grid_Master.Columns.Add(grid_Col);
            //add kolom alamat
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MCustomer.ColumnNames.CustomerAddress;
            grid_Col.HeaderText = "Alamat";
            grid_Master.Columns.Add(grid_Col);
            //add kolom telpon
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MCustomer.ColumnNames.CustomerPhone;
            grid_Col.HeaderText = "Telepon";
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterCustomer_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MCustomer, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MCustomer));
            if (listMaster.Count > 0)
                bindingSource_Master.DataSource = listMaster;

            bindingSource_Master_PositionChanged(null, null);
            detailControl_KeyDown(null, null);
        }

        private void bindingSource_Master_PositionChanged(object sender, EventArgs e)
        {
            SetNavigatorDisplay();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            customerIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            customerIdTextBox.Enabled = false;
            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(customerIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(customerIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    cust = (MCustomer)DataMaster.GetObjectById(typeof(MCustomer), customerIdTextBox.Text);
                    DataMaster.Delete(cust);
                    ModuleControlSettings.SaveLog(ListOfAction.Delete, customerIdTextBox.Text, ListOfTable.MCustomer, lbl_UserName.Text);
                    BindData();

                }
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (customerIdTextBox.Enabled == true)
                cust = new MCustomer();
            else
                cust = (MCustomer)DataMaster.GetObjectById(typeof(MCustomer), customerIdTextBox.Text);

            cust.CustomerAddress = customerAddressTextBox.Text;
            cust.CustomerDisc = decimal.Zero;
            cust.CustomerFax = customerFaxTextBox.Text;
            cust.CustomerId = customerIdTextBox.Text;
            cust.CustomerLimit = decimal.Zero;
            cust.CustomerName = customerNameTextBox.Text;
            cust.CustomerPhone = customerPhoneTextBox.Text;
            cust.CustomerStatus = ListOfCustStatus.Active.ToString();
            cust.SubAccountId = string.Empty;
            cust.ModifiedBy = lbl_UserName.Text;
            cust.ModifiedDate = DateTime.Now;

            if (customerIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(cust);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Pelanggan dengan kode " + customerIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
                    balloonHelp.ShowBalloon(customerIdTextBox);
                    customerIdTextBox.Focus();
                    return;
                }
                ModuleControlSettings.SaveLog(ListOfAction.Insert, customerIdTextBox.Text, ListOfTable.MCustomer, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(cust);
                ModuleControlSettings.SaveLog(ListOfAction.Update, customerIdTextBox.Text, ListOfTable.MCustomer, lbl_UserName.Text);
            }

            BindData();
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(customerIdTextBox.Text))
            {
                balloonHelp.Content = "Kode Pelanggan harus diisi";
                balloonHelp.ShowBalloon(customerIdTextBox);
                customerIdTextBox.Focus();
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
                customerIdTextBox.Focus();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                Control c = (Control)sender;
                if (sender == customerIdTextBox)
                    customerNameTextBox.Focus();
                else if (sender == customerNameTextBox)
                    customerPhoneTextBox.Focus();
                else if (sender == customerPhoneTextBox)
                    customerAddressTextBox.Focus();
                else if (sender == customerAddressTextBox)
                    bindingNavigatorSaveItem_Click(null, null);
            }

        }
    }
}