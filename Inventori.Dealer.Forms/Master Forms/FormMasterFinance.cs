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
namespace Inventori.Dealer.Forms
{
    public partial class FormMasterFinance : Inventori.Forms.FormParentForMasterForm
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MFinance finance;
        public FormMasterFinance()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MFinance.ColumnNames.FinanceId;
            grid_Col.HeaderText = "Kode Finance";
            grid_Master.Columns.Add(grid_Col);
            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MFinance.ColumnNames.FinanceName;
            grid_Col.HeaderText = "Nama Finance";
            grid_Master.Columns.Add(grid_Col);
            //add kolom alamat
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MFinance.ColumnNames.FinanceAddress;
            grid_Col.HeaderText = "Alamat";
            grid_Master.Columns.Add(grid_Col);
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MFinance.ColumnNames.FinancePhone;
            grid_Col.HeaderText = "Telepon";
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterFinance_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MFinance, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();

            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MFinance));
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
            financeIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            financeIdTextBox.Enabled = false;
            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(financeIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(financeIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    finance = (MFinance)DataMaster.GetObjectById(typeof(MFinance), financeIdTextBox.Text);
                    DataMaster.Delete(finance);

                    ModuleControlSettings.SaveLog(ListOfAction.Delete, financeIdTextBox.Text, ListOfTable.MFinance, lbl_UserName.Text);
                    BindData();

                }
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (financeIdTextBox.Enabled == true)
                finance = new MFinance();
            else
                finance = (MFinance)DataMaster.GetObjectById(typeof(MFinance), financeIdTextBox.Text);

            //finance.SubAccountId = string.Empty;
            finance.FinanceAddress = financeAddressTextBox.Text;
            //finance.FinanceContact = financeContactTextBox.Text;
            //finance.FinanceContactPhone = financeContactPhoneTextBox.Text;
            finance.FinanceFax = financeFaxTextBox.Text;
            finance.FinanceId = financeIdTextBox.Text;
            //finance.FinanceLimit = decimal.Zero;
            finance.FinanceName = financeNameTextBox.Text;
            finance.FinanceNpwp = financeNpwpTextBox.Text;
            finance.FinancePhone = financePhoneTextBox.Text;
            finance.ModifiedBy = lbl_UserName.Text;
            finance.ModifiedDate = DateTime.Now;

            if (financeIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(finance);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Finance dengan kode " + financeIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
                    balloonHelp.ShowBalloon(financeIdTextBox);
                    financeIdTextBox.Focus();
                    return;
                }
                ModuleControlSettings.SaveLog(ListOfAction.Insert, financeIdTextBox.Text, ListOfTable.MFinance, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(finance);
                ModuleControlSettings.SaveLog(ListOfAction.Update, financeIdTextBox.Text, ListOfTable.MFinance, lbl_UserName.Text);
            }
            BindData();
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(financeIdTextBox.Text))
            {
                balloonHelp.Content = "Kode Finance harus diisi";
                balloonHelp.ShowBalloon(financeIdTextBox);
                financeIdTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(financeNameTextBox.Text))
            {
                balloonHelp.Content = "Nama Finance harus diisi";
                balloonHelp.ShowBalloon(financeNameTextBox);
                financeNameTextBox.Focus();
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
                financeIdTextBox.Focus();
            //else
            //{
            //    if (e == null)
            //        return;

            //    if (e.KeyCode != Keys.Enter)
            //        return;

            //    Control c = (Control)sender;
            //    if (sender == financeIdTextBox)
            //        financeNameTextBox.Focus();
            //    else if (sender == financeNameTextBox)
            //        financeAddressTextBox.Focus();
            //    else if (sender == financeAddressTextBox)
            //        financePhoneTextBox.Focus();
            //    else if (sender == financePhoneTextBox)
            //        financeContactTextBox.Focus();
            //    else if (sender == financeContactTextBox)
            //        financeContactPhoneTextBox.Focus();
            //    else if (sender == financeContactPhoneTextBox)
            //        bindingNavigatorSaveItem_Click(null, null);
            //}

        }
    }
}

