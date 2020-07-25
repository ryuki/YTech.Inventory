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

namespace Inventori.Contractor.Forms
{
    public partial class FormMasterBank : Inventori.Forms.FormParentForMasterForm
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MBank bank;

        public FormMasterBank()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MBank.ColumnNames.BankId;
            grid_Col.HeaderText = "Kode Bank";
            grid_Master.Columns.Add(grid_Col);
            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MBank.ColumnNames.BankName;
            grid_Col.HeaderText = "Nama Bank";
            //add kolom alamat
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MBank.ColumnNames.BankAddress;
            grid_Col.HeaderText = "Alamat";
            grid_Master.Columns.Add(grid_Col);


            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterBank_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MBank, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MBank));
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
            bankIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            bankIdTextBox.Enabled = false;

            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(bankIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(bankIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    bank = (MBank)DataMaster.GetObjectByProperty(typeof(MBank), MBank.ColumnNames.BankId, bankIdTextBox.Text);
                    DataMaster.Delete(bank);

                    ModuleControlSettings.SaveLog(ListOfAction.Delete, bankIdTextBox.Text, ListOfTable.MBank, lbl_UserName.Text);

                    BindData();
                }
            }
        }
        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (bankIdTextBox.Enabled == true)
                bank = new MBank();
            else
                bank = (MBank)DataMaster.GetObjectByProperty(typeof(MBank), MBank.ColumnNames.BankId, bankIdTextBox.Text);

            bank.BankId = bankIdTextBox.Text;
            bank.BankName = bankNameTextBox.Text;
            bank.BankAddress = bankAddressTextBox.Text;
            bank.BankLimitGiroPerMonth = bankLimitGiroPerMonthNumericUpDown.Value;
            bank.ModifiedBy = lbl_UserName.Text;
            bank.ModifiedDate = DateTime.Now;

            if (bankIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(bank);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Bank dengan kode " + bankIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
                    balloonHelp.ShowBalloon(bankIdTextBox);
                    bankIdTextBox.Focus();
                    return;
                }
                ModuleControlSettings.SaveLog(ListOfAction.Insert, bankIdTextBox.Text, ListOfTable.MBank, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(bank);
                ModuleControlSettings.SaveLog(ListOfAction.Update, bankIdTextBox.Text, ListOfTable.MBank, lbl_UserName.Text);
            }


            BindData();

        }

        private bool ValidateForm()
        {
            RecreateBalloon();
            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(bankIdTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Kode bank harus diisi";
                balloonHelp.ShowBalloon(bankIdTextBox);
                bankIdTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(bankNameTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Nama bank harus diisi";
                balloonHelp.ShowBalloon(bankNameTextBox);
                bankNameTextBox.Focus();
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
                bankIdTextBox.Select();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                if (sender == bankIdTextBox)
                    bankNameTextBox.Select();
                else if (sender == bankNameTextBox)
                    bankAddressTextBox.Select();
                else if (sender == bankAddressTextBox)
                    bindingNavigatorSaveItem_Click(null, null);
            }
        }

    }
}