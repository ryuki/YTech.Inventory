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

namespace Inventori.InOutItem.Forms
{
    public partial class FormMasterSupplier : Inventori.Forms.FormParentForMasterForm
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MSupplier supp;

        public FormMasterSupplier()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MSupplier.ColumnNames.SupplierId;
            grid_Col.HeaderText = "Kode Supplier";
            grid_Master.Columns.Add(grid_Col);
            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MSupplier.ColumnNames.SupplierName;
            grid_Col.HeaderText = "Nama Supplier";
            grid_Master.Columns.Add(grid_Col);
            //add kolom alamat
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MSupplier.ColumnNames.SupplierAddress;
            grid_Col.HeaderText = "Alamat";
            grid_Master.Columns.Add(grid_Col);
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MSupplier.ColumnNames.SupplierPhone;
            grid_Col.HeaderText = "Telepon";
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterSupplier_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MSupplier, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();

            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MSupplier));
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
            supplierIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            supplierIdTextBox.Enabled = false;
            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(supplierIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(supplierIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    supp = (MSupplier)DataMaster.GetObjectById(typeof(MSupplier), supplierIdTextBox.Text);
                    DataMaster.Delete(supp);

                    ModuleControlSettings.SaveLog(ListOfAction.Delete, supplierIdTextBox.Text, ListOfTable.MSupplier, lbl_UserName.Text);
                    BindData();

                }
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (supplierIdTextBox.Enabled == true)
                supp = new MSupplier();
            else
                supp = (MSupplier)DataMaster.GetObjectById(typeof(MSupplier), supplierIdTextBox.Text);

            supp.SubAccountId = string.Empty;
            supp.SupplierAddress = supplierAddressTextBox.Text;
            supp.SupplierContact = supplierContactTextBox.Text;
            supp.SupplierContactPhone = supplierContactPhoneTextBox.Text;
            supp.SupplierFax = supplierFaxTextBox.Text;
            supp.SupplierId = supplierIdTextBox.Text;
            supp.SupplierLimit = decimal.Zero;
            supp.SupplierName = supplierNameTextBox.Text;
            supp.SupplierNpwp = supplierNpwpTextBox.Text;
            supp.SupplierPhone = supplierPhoneTextBox.Text;
            supp.ModifiedBy = lbl_UserName.Text;
            supp.ModifiedDate = DateTime.Now;

            if (supplierIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(supp);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Supplier dengan kode " + supplierIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
                    balloonHelp.ShowBalloon(supplierIdTextBox);
                    supplierIdTextBox.Focus();
                    return;
                }
                ModuleControlSettings.SaveLog(ListOfAction.Insert, supplierIdTextBox.Text, ListOfTable.MSupplier, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(supp);
                ModuleControlSettings.SaveLog(ListOfAction.Update, supplierIdTextBox.Text, ListOfTable.MSupplier, lbl_UserName.Text);
            }
            BindData();
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(supplierIdTextBox.Text))
            {
                balloonHelp.Content = "Kode Supplier harus diisi";
                balloonHelp.ShowBalloon(supplierIdTextBox);
                supplierIdTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(supplierNameTextBox.Text))
            {
                balloonHelp.Content = "Nama Supplier harus diisi";
                balloonHelp.ShowBalloon(supplierNameTextBox);
                supplierNameTextBox.Focus();
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
                supplierIdTextBox.Focus();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                Control c = (Control)sender;
                if (sender == supplierIdTextBox)
                    supplierNameTextBox.Focus();
                else if (sender == supplierNameTextBox)
                    supplierAddressTextBox.Focus();
                else if (sender == supplierAddressTextBox)
                    supplierPhoneTextBox.Focus();
                else if (sender == supplierPhoneTextBox)
                    supplierContactTextBox.Focus();
                else if (sender == supplierContactTextBox)
                    supplierContactPhoneTextBox.Focus();
                else if (sender == supplierContactPhoneTextBox)
                    bindingNavigatorSaveItem_Click(null, null);
            }

        }
    }
}

