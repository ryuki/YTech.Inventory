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
    public partial class FormMasterCustomerGroup : Inventori.Forms.FormParentForMasterForm
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MCustomerGroup custGroup;

        public FormMasterCustomerGroup()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MCustomerGroup.ColumnNames.CustomerGroupId;
            grid_Col.HeaderText = "Kode Golongan Pelanggan";
            grid_Master.Columns.Add(grid_Col);

            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MCustomerGroup.ColumnNames.CustomerGroupName;
            grid_Col.HeaderText = "Nama Golongan Pelanggan";
            grid_Master.Columns.Add(grid_Col);

            //add kolom persen
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MCustomerGroup.ColumnNames.CustomerGroupPercentage;
            grid_Col.HeaderText = "Persentase Harga Jual";
            grid_Col.DefaultCellStyle.Format = "N";
            grid_Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterCustomerGroup_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MCustomerGroup, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MCustomerGroup));
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
            customerGroupIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            customerGroupIdTextBox.Enabled = false;

            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(customerGroupIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(customerGroupIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    custGroup = (MCustomerGroup)DataMaster.GetObjectByProperty(typeof(MCustomerGroup), MCustomerGroup.ColumnNames.CustomerGroupId, customerGroupIdTextBox.Text);
                    DataMaster.Delete(custGroup);

                    ModuleControlSettings.SaveLog(ListOfAction.Delete, customerGroupIdTextBox.Text, ListOfTable.MCustomerGroup, lbl_UserName.Text);

                    BindData();
                }
            }
        }
        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (customerGroupIdTextBox.Enabled == true)
                custGroup = new MCustomerGroup();
            else
                custGroup = (MCustomerGroup)DataMaster.GetObjectByProperty(typeof(MCustomerGroup), MCustomerGroup.ColumnNames.CustomerGroupId, customerGroupIdTextBox.Text);

            custGroup.CustomerGroupDesc = customerGroupDescTextBox.Text;
            custGroup.CustomerGroupId = customerGroupIdTextBox.Text;
            custGroup.CustomerGroupName = customerGroupNameTextBox.Text;
            custGroup.CustomerGroupPercentage = customerGroupPercentageNumericUpDown.Value;
            
            custGroup.ModifiedBy = lbl_UserName.Text;
            custGroup.ModifiedDate = DateTime.Now;

            if (customerGroupIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(custGroup);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Golongan Pelanggan dengan kode " + customerGroupIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
                    balloonHelp.ShowBalloon(customerGroupIdTextBox);
                    customerGroupIdTextBox.Focus();
                    return;
                }
                ModuleControlSettings.SaveLog(ListOfAction.Insert, customerGroupIdTextBox.Text, ListOfTable.MCustomerGroup, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(custGroup);
                ModuleControlSettings.SaveLog(ListOfAction.Update, customerGroupIdTextBox.Text, ListOfTable.MCustomerGroup, lbl_UserName.Text);
            }


            BindData();

        }

        private bool ValidateForm()
        {
            RecreateBalloon();
            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(customerGroupIdTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Kode golongan pelanggan harus diisi";
                balloonHelp.ShowBalloon(customerGroupIdTextBox);
                customerGroupIdTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(customerGroupNameTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Nama golongan pelanggan harus diisi";
                balloonHelp.ShowBalloon(customerGroupNameTextBox);
                customerGroupNameTextBox.Focus();
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
                customerGroupIdTextBox.Select();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                if (sender == customerGroupIdTextBox)
                    customerGroupNameTextBox.Select();
                else if (sender == customerGroupNameTextBox)
                    customerGroupPercentageNumericUpDown.Select();
                else if (sender == customerGroupPercentageNumericUpDown)
                    bindingNavigatorSaveItem_Click(null, null);
            }
        }
    }
}