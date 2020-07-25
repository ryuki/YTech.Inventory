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
    public partial class FormMasterAccount : Inventori.Forms.FormParentForMasterForm
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MAccount acc;

        public FormMasterAccount()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MAccount.ColumnNames.AccountId;
            grid_Col.HeaderText = "Kode POS";
            grid_Master.Columns.Add(grid_Col);

            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MAccount.ColumnNames.AccountName;
            grid_Col.HeaderText = "Nama POS";
            grid_Master.Columns.Add(grid_Col);

            //add kolom saldo
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MAccount.ColumnNames.AccountSaldo;
            grid_Col.DefaultCellStyle.Format = "N";
            grid_Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grid_Col.HeaderText = "Saldo";
            grid_Master.Columns.Add(grid_Col);

            //add kolom status
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MAccount.ColumnNames.AccountStatus;
            grid_Col.HeaderText = "Status";
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);

            //set numeric updown
            ModuleControlSettings.SetNumericUpDown(accountSaldoNumericUpDown,true);
            accountSaldoNumericUpDown.Minimum = decimal.MinValue;

            FillAccountPosition();
        }

        private void FillAccountPosition()
        {
            Type desc = typeof(ListOfAccountPosition);

            accountPositionComboBox.Items.Clear();
            foreach (string s in Enum.GetNames(desc))
            {
                accountPositionComboBox.Items.Add(Enum.Parse(desc, s).ToString().Replace("_", " "));
            }
            accountPositionComboBox.Show();
        }

        private void FormMasterAccount_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MAccount, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MAccount));
            if (listMaster.Count > 0)
                bindingSource_Master.DataSource = listMaster;

            bindingSource_Master_PositionChanged(null, null);
            detailControl_KeyDown(null, null);
        }

        private void bindingSource_Master_PositionChanged(object sender, EventArgs e)
        {
            SetNavigatorDisplay();
            acc = (MAccount)DataMaster.GetObjectByProperty(typeof(MAccount), MAccount.ColumnNames.AccountId, accountIdTextBox.Text);
            if (acc != null)
            {
                accountStatusDebetRadioButton.Checked = (acc.AccountStatus == ListOfJournalStatus.Debet.ToString());
                accountStatusKreditRadioButton.Checked = (acc.AccountStatus == ListOfJournalStatus.Kredit.ToString());
            }
        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            accountIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            accountIdTextBox.Enabled = false;

            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(accountIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(accountIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    acc = (MAccount)DataMaster.GetObjectByProperty(typeof(MAccount), MAccount.ColumnNames.AccountId, accountIdTextBox.Text);
                    DataMaster.Delete(acc);

                    ModuleControlSettings.SaveLog(ListOfAction.Delete, accountIdTextBox.Text, ListOfTable.MAccount, lbl_UserName.Text);

                    BindData();
                }
            }
        }
        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (accountIdTextBox.Enabled == true)
                acc = new MAccount();
            else
                acc = (MAccount)DataMaster.GetObjectByProperty(typeof(MAccount), MAccount.ColumnNames.AccountId, accountIdTextBox.Text);

            acc.AccountDesc = accountDescTextBox.Text;
            acc.AccountId = accountIdTextBox.Text;
            acc.AccountName = accountNameTextBox.Text;
            //acc.AccountSaldo = accountSaldoNumericUpDown.Value;
            acc.AccountPosition = accountPositionComboBox.Text;
            if (accountStatusDebetRadioButton.Checked)
                acc.AccountStatus = ListOfJournalStatus.Debet.ToString();
            if (accountStatusKreditRadioButton.Checked)
                acc.AccountStatus = ListOfJournalStatus.Kredit.ToString();

            acc.ModifiedBy = lbl_UserName.Text;
            acc.ModifiedDate = DateTime.Now;

            if (accountIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(acc);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "POS Neraca dengan kode " + accountIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
                    balloonHelp.ShowBalloon(accountIdTextBox);
                    accountIdTextBox.Focus();
                    return;
                }
                ModuleControlSettings.SaveLog(ListOfAction.Insert, accountIdTextBox.Text, ListOfTable.MAccount, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(acc);
                ModuleControlSettings.SaveLog(ListOfAction.Update, accountIdTextBox.Text, ListOfTable.MAccount, lbl_UserName.Text);
            }


            BindData();

        }

        private bool ValidateForm()
        {
            RecreateBalloon();
            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(accountIdTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Kode POS Neraca harus diisi";
                balloonHelp.ShowBalloon(accountIdTextBox);
                accountIdTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(accountNameTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Nama POS Neraca harus diisi";
                balloonHelp.ShowBalloon(accountNameTextBox);
                accountNameTextBox.Focus();
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
                accountIdTextBox.Select();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                if (sender == accountIdTextBox)
                    accountNameTextBox.Select();
                else if (sender == accountNameTextBox)
                    accountSaldoNumericUpDown.Select();
                else if (sender == accountSaldoNumericUpDown)
                    bindingNavigatorSaveItem_Click(null, null);
            }
        }
    }
}