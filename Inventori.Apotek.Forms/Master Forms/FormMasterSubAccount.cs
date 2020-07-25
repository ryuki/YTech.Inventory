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
using Inventori.Forms;

namespace Inventori.Apotek.Forms
{
    public partial class FormMasterSubAccount : Inventori.Forms.FormParentForMasterForm
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MSubAccount subacc;

        public FormMasterSubAccount()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MSubAccount.ColumnNames.SubAccountId;
            grid_Col.HeaderText = "Kode Rekening";
            grid_Master.Columns.Add(grid_Col);

            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MSubAccount.ColumnNames.SubAccountName;
            grid_Col.HeaderText = "Nama Rekening";
            grid_Master.Columns.Add(grid_Col);

            //add kolom saldo
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MSubAccount.ColumnNames.SubAccountSaldo;
            grid_Col.DefaultCellStyle.Format = "N";
            grid_Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grid_Col.HeaderText = "Saldo";
            grid_Master.Columns.Add(grid_Col);


            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);

            //set numeric updown
            ModuleControlSettings.SetNumericUpDown(subAccountSaldoNumericUpDown,true);
            subAccountSaldoNumericUpDown.Minimum = decimal.MinValue;

            //search item
            PictureBox searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(accountIdTextBox, ListOfSearchWindow.SearchAccount.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicAccount_Click);
            accountIdTextBox.Controls.Add(searchPic);
        }

        void searchPicAccount_Click(object sender, EventArgs e)
        {
            OpenFormSearchAccount();
        }

        FormSearchAccount f_SearchAccount;
        private void OpenFormSearchAccount()
        {
            if (f_SearchAccount != null)
            {
                if (!f_SearchAccount.IsDisposed)
                {
                    f_SearchAccount.WindowState = FormWindowState.Normal;
                    f_SearchAccount.BringToFront();
                }
                else
                    f_SearchAccount = new FormSearchAccount();
            }
            else
                f_SearchAccount = new FormSearchAccount();

            f_SearchAccount.AccountHasSelected += new EventHandler(f_SearchAccount_AccountHasSelected);

            f_SearchAccount.ShowInTaskbar = false;
            f_SearchAccount.ShowDialog();
        }

        void f_SearchAccount_AccountHasSelected(object sender, EventArgs e)
        {
            if (f_SearchAccount.grid_Search.Rows.Count > 0)
            {
                accountIdTextBox.Text = f_SearchAccount.grid_Search.CurrentRow.Cells[0].Value.ToString();
                accountIdTextBox_Validating(null, null);
            }
        }

        private void FormMasterSubAccount_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MSubAccount, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MSubAccount));
            if (listMaster.Count > 0)
                bindingSource_Master.DataSource = listMaster;

            bindingSource_Master_PositionChanged(null, null);
            detailControl_KeyDown(null, null);
        }

        private void bindingSource_Master_PositionChanged(object sender, EventArgs e)
        {
            SetNavigatorDisplay();
            accountIdTextBox_Validating(null, null);
        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            subAccountIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            subAccountIdTextBox.Enabled = false;

            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(subAccountIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(subAccountIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    subacc = (MSubAccount)DataMaster.GetObjectByProperty(typeof(MSubAccount), MSubAccount.ColumnNames.SubAccountId, subAccountIdTextBox.Text);
                    DataMaster.Delete(subacc);

                    ModuleControlSettings.SaveLog(ListOfAction.Delete, subAccountIdTextBox.Text, ListOfTable.MSubAccount, lbl_UserName.Text);

                    BindData();
                }
            }
        }
        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (subAccountIdTextBox.Enabled == true)
                subacc = new MSubAccount();
            else
                subacc = (MSubAccount)DataMaster.GetObjectByProperty(typeof(MSubAccount), MSubAccount.ColumnNames.SubAccountId, subAccountIdTextBox.Text);

            subacc.AccountId = accountIdTextBox.Text;
            subacc.SubAccountDesc = subAccountDescTextBox.Text;
            subacc.SubAccountId = subAccountIdTextBox.Text;
            subacc.SubAccountName = subAccountNameTextBox.Text;
            //subacc.SubAccountSaldo = subAccountSaldoNumericUpDown.Value;
            subacc.ModifiedBy = lbl_UserName.Text;
            subacc.ModifiedDate = DateTime.Now;

            if (subAccountIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(subacc);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Rekening dengan kode " + subAccountIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
                    balloonHelp.ShowBalloon(subAccountIdTextBox);
                    subAccountIdTextBox.Focus();
                    return;
                }
                ModuleControlSettings.SaveLog(ListOfAction.Insert, subAccountIdTextBox.Text, ListOfTable.MSubAccount, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(subacc);
                ModuleControlSettings.SaveLog(ListOfAction.Update, subAccountIdTextBox.Text, ListOfTable.MSubAccount, lbl_UserName.Text);
            }


            BindData();

        }

        private bool ValidateForm()
        {
            RecreateBalloon();
            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(subAccountIdTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Kode rekening harus diisi";
                balloonHelp.ShowBalloon(subAccountIdTextBox);
                subAccountIdTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(accountIdTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Kode POS harus diisi";
                balloonHelp.ShowBalloon(accountIdTextBox);
                accountIdTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(subAccountNameTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Nama rekening harus diisi";
                balloonHelp.ShowBalloon(subAccountNameTextBox);
                subAccountNameTextBox.Focus();
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
                    subAccountIdTextBox.Select();
                else if (sender == subAccountIdTextBox)
                    subAccountNameTextBox.Select();
                else if (sender == subAccountNameTextBox)
                    bindingNavigatorSaveItem_Click(null, null);
            }
        }

        private void accountIdTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(accountIdTextBox, ListOfSearchWindow.SearchAccount.ToString(), true);
        }

        private void accountIdTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(accountIdTextBox, ListOfSearchWindow.SearchAccount.ToString(), false);
        }

        private void accountIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            MAccount acc = (MAccount)DataMaster.GetObjectByProperty(typeof(MAccount), MAccount.ColumnNames.AccountId, accountIdTextBox.Text);
            if (acc != null)
                accountNameTextBox.Text = acc.AccountName;
            else
                accountNameTextBox.ResetText();
        }

    }
}