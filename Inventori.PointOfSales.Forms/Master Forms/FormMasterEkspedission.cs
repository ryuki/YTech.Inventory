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

namespace Inventori.PointOfSales.Forms
{
    public partial class FormMasterEkspedission : Inventori.Forms.FormParentForMasterForm
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MEkspedission eks;

        public FormMasterEkspedission()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MEkspedission.ColumnNames.EkspedissionId;
            grid_Col.HeaderText = "Kode Ekspedisi";
            grid_Master.Columns.Add(grid_Col);
            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MEkspedission.ColumnNames.EkspedissionName;
            grid_Col.HeaderText = "Nama Ekspedisi";
            grid_Master.Columns.Add(grid_Col);
            //add kolom alamat
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MEkspedission.ColumnNames.EkspedissionAddress;
            grid_Col.HeaderText = "Alamat";
            grid_Master.Columns.Add(grid_Col);
            //add kolom telpon
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MEkspedission.ColumnNames.EkspedissionPhone;
            grid_Col.HeaderText = "Telepon";
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterEkspedission_Load(object sender, EventArgs e)
        {
            //ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MCustomer, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MEkspedission));
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
            ekspedissionIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            ekspedissionIdTextBox.Enabled = false;
            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(ekspedissionIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ekspedissionIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    eks = (MEkspedission)DataMaster.GetObjectById(typeof(MEkspedission), ekspedissionIdTextBox.Text);
                    DataMaster.Delete(eks);
                    //ModuleControlSettings.SaveLog(ListOfAction.Delete, ekspedissionIdTextBox.Text, ListOfTable.MEkspedission, lbl_UserName.Text);
                    BindData();

                }
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (ekspedissionIdTextBox.Enabled == true)
                eks = new MEkspedission();
            else
                eks = (MEkspedission)DataMaster.GetObjectById(typeof(MEkspedission), ekspedissionIdTextBox.Text);

            eks.EkspedissionAddress = ekspedissionAddressTextBox.Text;
            eks.EkspedissionDisc = decimal.Zero;
            eks.EkspedissionFax = ekspedissionFaxTextBox.Text;
            eks.EkspedissionId = ekspedissionIdTextBox.Text;
            eks.EkspedissionLimit = decimal.Zero;
            eks.EkspedissionName = ekspedissionNameTextBox.Text;
            eks.EkspedissionPhone = ekspedissionPhoneTextBox.Text;
            eks.EkspedissionStatus = ListOfCustStatus.Active.ToString();
            eks.SubAccountId = string.Empty;
            eks.ModifiedBy = lbl_UserName.Text;
            eks.ModifiedDate = DateTime.Now;

            if (ekspedissionIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(eks);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Ekspedisi dengan kode " + ekspedissionIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
                    balloonHelp.ShowBalloon(ekspedissionIdTextBox);
                    ekspedissionIdTextBox.Focus();
                    return;
                }
                //ModuleControlSettings.SaveLog(ListOfAction.Insert, ekspedissionIdTextBox.Text, ListOfTable.MEkspedission, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(eks);
                //ModuleControlSettings.SaveLog(ListOfAction.Update, ekspedissionIdTextBox.Text, ListOfTable.MEkspedission, lbl_UserName.Text);
            }

            BindData();
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(ekspedissionIdTextBox.Text))
            {
                balloonHelp.Content = "Kode Ekspedisi harus diisi";
                balloonHelp.ShowBalloon(ekspedissionIdTextBox);
                ekspedissionIdTextBox.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(ekspedissionNameTextBox.Text))
            {
                balloonHelp.Content = "Nama Ekspedisi harus diisi";
                balloonHelp.ShowBalloon(ekspedissionNameTextBox);
                ekspedissionNameTextBox.Focus();
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
                ekspedissionIdTextBox.Focus();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                Control c = (Control)sender;
                if (sender == ekspedissionIdTextBox)
                    ekspedissionNameTextBox.Focus();
                else if (sender == ekspedissionNameTextBox)
                    ekspedissionPhoneTextBox.Focus();
                else if (sender == ekspedissionPhoneTextBox)
                    ekspedissionAddressTextBox.Focus();
                else if (sender == ekspedissionAddressTextBox)
                    bindingNavigatorSaveItem_Click(null, null);
            }

        }
    }
}