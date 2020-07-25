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
    public partial class FormGiro : FormParentForContractor
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        TGiro giro;
        private Balloon.NET.BalloonHelp balloonHelp;
        public FormGiro()
        {
            InitializeComponent();
        }


        private void FormGiro_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.TGiro, lbl_UserName.Text);
            UpdateGiroMaturity();
            FillSupplierBindingSource();
            FillBankBindingSource();
            ModuleControlSettings.SetNumericUpDown(num_TotUtang, true);
            ModuleControlSettings.SetNumericUpDown(giroAmmountNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(giroIdNumericUpDown);
            ModuleControlSettings.SetGridDataView(tGiroDataGridView);
            ModuleControlSettings.SetDateTimePicker(giroCairDateDateTimePicker, false);
            ModuleControlSettings.SetDateTimePicker(giroMaturityDateDateTimePicker, false);
            ModuleControlSettings.SetDateTimePicker(giroOutDateDateTimePicker, false);
            ModuleControlSettings.SetDateTimePicker(modifiedDateDateTimePicker, true);
            AppCode.SetGiroStatusComboBox(giroStatusComboBox);
            AppCode.SetCurrencyStatusComboBox(currencyIdComboBox);
            AppCode.SetCurrencyStatusComboBox(currencyIdComboBox1);

            currencyIdComboBox.SelectedIndex = 0;

            num_TotUtang.Minimum = decimal.MinValue;

            combo_Supplier_SelectedIndexChanged(null, null);
        }

        private void UpdateGiroMaturity()
        {
            IList listGiro = DataMaster.GetListEq(typeof(TGiro), TGiro.ColumnNames.GiroStatus, ListOfGiroStatus.Baru.ToString());
            TGiro g;
            for (int i = 0; i < listGiro.Count; i++)
            {
                g = (TGiro)listGiro[i];
                if (Convert.ToDateTime(g.GiroMaturityDate.ToShortDateString()) <= Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    g.GiroStatus = ListOfGiroStatus.JatuhTempo.ToString();
                    DataMaster.UpdatePersistence(g);
                }
            }
        }

        private void FillSupplierBindingSource()
        {
            mSupplierBindingSource.Clear();
            mSupplierBindingSource.DataSource = DataMaster.GetAll(typeof(MSupplier));
        }

        private void FillBankBindingSource()
        {
            mBankBindingSource.Clear();
            mBankBindingSource.DataSource = DataMaster.GetAll(typeof(MBank));
        }

        private void combo_Supplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Supplier.SelectedIndex == -1)
                return;

            btn_Detail.Enabled = (combo_Supplier.SelectedIndex != -1);
            lbl_Supplier.Text = combo_Supplier.Text;

            currencyIdComboBox1.SelectedItem = currencyIdComboBox.SelectedItem;

            try
            {
                BindGiroData();
                CalculateTotalUtang();
            }
            catch (Exception)
            {
            }

            RecreateBalloon();
            balloonHelp.Caption = "Detail Utang";
            balloonHelp.Content = "Klik disini untuk melihat detail utang";
            balloonHelp.ShowBalloon(btn_Detail);
        }

        private void RecreateBalloon()
        {
            balloonHelp = new Balloon.NET.BalloonHelp();
            balloonHelp.Icon = Properties.Resources.warning;
            balloonHelp.CloseOnMouseClick = true;
            balloonHelp.CloseOnDeactivate = false;
            balloonHelp.CloseOnMouseMove = false;
            balloonHelp.CloseOnKeyPress = false;
            balloonHelp.ShowCloseButton = false;
            //balloonHelp.TopMost = true;
        }

        private void CalculateTotalUtang()
        {
            IList listTrans = DataMaster.GetListEq(typeof(TTransaction), TTransaction.ColumnNames.TransactionStatus, ListOfTransaction.Purchase.ToString(), TTransaction.ColumnNames.TransactionBy, combo_Supplier.SelectedValue.ToString(),TTransaction.ColumnNames.CurrencyId,currencyIdComboBox.SelectedItem.ToString());
            TTransaction trans;

            decimal totUtang = 0;
            for (int i = 0; i < listTrans.Count; i++)
            {
                trans = (TTransaction)listTrans[i];
                totUtang += trans.TransactionSisa;
            }

            decimal totPaid = 0;
            IList listGiro = DataMaster.GetListEq(typeof(TGiro), TGiro.ColumnNames.GiroTo, combo_Supplier.SelectedValue.ToString(), TGiro.ColumnNames.GiroStatus, ListOfGiroStatus.Cair.ToString(),TGiro.ColumnNames.CurrencyId,currencyIdComboBox.SelectedItem.ToString());
            TGiro g;
            for (int i = 0; i < listGiro.Count; i++)
            {
                g = (TGiro)listGiro[i];
                totPaid += g.GiroAmmount;
            }
            num_TotUtang.Value = totUtang - totPaid;
        }

        private void BindGiroData()
        {
            tGiroBindingSource.Clear();
            IList listGiro = DataMaster.GetListEq(typeof(TGiro), TGiro.ColumnNames.GiroTo, combo_Supplier.SelectedValue.ToString(),TGiro.ColumnNames.CurrencyId,currencyIdComboBox.SelectedItem.ToString());
            if (listGiro.Count > 0)
            {
                tGiroBindingSource.DataSource = listGiro;
                ChangeRowsColor();
            }
            tGiroBindingSource_PositionChanged(null, null);
        }

        private void ChangeRowsColor()
        {
            for (int i = 0; i < tGiroDataGridView.RowCount; i++)
            {
                switch (tGiroDataGridView.Rows[i].Cells[0].Value.ToString())
                {
                    case "Batal":
                        tGiroDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        break;

                    case "JatuhTempo":
                        tGiroDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                        break;
                    case "Cair":
                        tGiroDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                    default:
                        break;
                }
            }
        }

        private void tGiroBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (tGiroBindingSource.Count > 0)
            {
                setEnableGroupBox1(false);
                bindingNavigatorAddNewItem.Enabled = true;
                //bindingNavigatorEditItem.Enabled = true;
                bindingNavigatorDeleteItem.Enabled = true;
                bindingNavigatorSaveItem.Enabled = false;
            }
            else
            {
                setEnableGroupBox1(false);
                bindingNavigatorAddNewItem.Enabled = true;
                //bindingNavigatorEditItem.Enabled = false;
                bindingNavigatorDeleteItem.Enabled = false;
                bindingNavigatorSaveItem.Enabled = false;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            setEnableGroupBox1(true);
            bindingNavigatorAddNewItem.Enabled = false;
            bindingNavigatorEditItem.Enabled = false;
            bindingNavigatorDeleteItem.Enabled = false;
            bindingNavigatorSaveItem.Enabled = true;

            modifiedByTextBox.Text = lbl_UserName.Text;
            modifiedDateDateTimePicker.Value = DateTime.Now;
            btn_Batal.Enabled = false;
            btn_Cair.Enabled = false;
            gb_Cair.Visible = false;

            bankIdComboBox.Enabled = true;
            giroNoTextBox.Enabled = true;
            giroAmmountNumericUpDown.Enabled = true;
            giroMaturityDateDateTimePicker.Enabled = true;

            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            setEnableGroupBox1(true);
            bindingNavigatorAddNewItem.Enabled = false;
            bindingNavigatorEditItem.Enabled = false;
            bindingNavigatorDeleteItem.Enabled = true;
            bindingNavigatorSaveItem.Enabled = true;

            bankIdComboBox.Enabled = false;
            giroNoTextBox.Enabled = false;
            giroAmmountNumericUpDown.Enabled = false;
            giroMaturityDateDateTimePicker.Enabled = false;

            //KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            //detailControl_KeyDown(giroMaturityDateDateTimePicker, key);
        }

        private void setEnableGroupBox1(bool isEnabled)
        {
            try
            {
                gb_GiroDetail.Enabled = isEnabled;
            }
            catch (Exception)
            {
            }
        }

        private void bindingNavigatorRefresh_Click(object sender, EventArgs e)
        {
            BindGiroData();
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            bool isSave = false;
            //if (bankIdComboBox.Enabled)
            //{
            //    giro = new TGiro();
            //    isSave = true;
            //}
            //else
            //{
            //    giro = (TGiro)DataMaster.GetObjectByProperty(typeof(TGiro), TGiro.ColumnNames.GiroNo, giroNoTextBox.Text, TGiro.ColumnNames.BankId, bankIdComboBox.SelectedValue.ToString());
            //    isSave = false;
            //}

            if (giroIdNumericUpDown.Value != 0)
            {
                giro = (TGiro)DataMaster.GetObjectByProperty(typeof(TGiro), TGiro.ColumnNames.GiroId, giroIdNumericUpDown.Value);
                isSave = false;
            }
            else
            {
                giro = new TGiro();
                isSave = true;
            }

            giro.CurrencyId = currencyIdComboBox.SelectedItem.ToString();
            giro.BankId = bankIdComboBox.SelectedValue.ToString();

            giro.GiroAmmount = giroAmmountNumericUpDown.Value;
            giro.GiroCairDate = giroCairDateDateTimePicker.Value;
            giro.GiroTo = combo_Supplier.SelectedValue.ToString();
            giro.GiroMaturityDate = giroMaturityDateDateTimePicker.Value;
            giro.GiroNo = giroNoTextBox.Text;

            if (isSave)
            {
                giro.GiroStatus = ListOfGiroStatus.Baru.ToString();
                giro.GiroOutDate = DateTime.Now;
            }
            else
            {
                giro.GiroStatus = giroStatusLabel1.Text;
            }

            giro.ModifiedBy = lbl_UserName.Text;
            giro.ModifiedDate = DateTime.Now;

            DataMaster.SaveOrUpdate(giro);
            if (isSave)
            {
                //try
                //{
                //    DataMaster.SavePersistence(giro);
                //}
                //catch (NHibernate.NonUniqueObjectException)
                //{
                //    RecreateBalloon();
                //    balloonHelp.Caption = "Validasi data kurang";
                //    balloonHelp.Content = "Nomor giro " + giroNoTextBox.Text + " sudah pernah diinput, silahkan input dengan nomor yang lain";
                //    balloonHelp.ShowBalloon(giroNoTextBox);
                //    giroNoTextBox.Focus();
                //    return;
                //}
                ModuleControlSettings.SaveLog(ListOfAction.Insert, bankIdComboBox.SelectedValue.ToString() + ";" + giroNoTextBox.Text + ";" + ListOfGiroStatus.Baru.ToString(), ListOfTable.TGiro, lbl_UserName.Text);
            }
            else
            {
                //DataMaster.UpdatePersistence(giro);
                ModuleControlSettings.SaveLog(ListOfAction.Update, bankIdComboBox.SelectedValue.ToString() + ";" + giroNoTextBox.Text + ";" + giroStatusLabel1.Text, ListOfTable.TGiro, lbl_UserName.Text);
            }

            BindGiroData();
            CalculateTotalUtang();
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (bankIdComboBox.SelectedIndex == -1)
            {
                balloonHelp.Content = "Pilih Bank !";
                balloonHelp.ShowBalloon(bankIdComboBox);
                bankIdComboBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(giroNoTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Nomor Giro harus diisi";
                balloonHelp.ShowBalloon(giroNoTextBox);
                giroNoTextBox.Focus();
                return false;
            }
            else if (giroAmmountNumericUpDown.Value <= 0)
            {
                balloonHelp.Content = "Saldo harus lebih besar dari 0";
                balloonHelp.ShowBalloon(giroAmmountNumericUpDown);
                giroAmmountNumericUpDown.Focus();
                return false;
            }

            return true;
        }

        private void giroStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (giroStatusComboBox.SelectedItem.ToString())
            {
                case "Baru":
                    btn_Batal.Enabled = true;
                    btn_Cair.Enabled = false;
                    gb_Cair.Visible = false;
                    bindingNavigatorEditItem.Enabled = true;
                    break;
                case "Batal":
                    btn_Batal.Enabled = false;
                    btn_Cair.Enabled = false;
                    gb_Cair.Visible = false;
                    bindingNavigatorEditItem.Enabled = false;
                    break;
                case "Cair":
                    btn_Batal.Enabled = false;
                    btn_Cair.Enabled = false;
                    gb_Cair.Visible = true;
                    bindingNavigatorEditItem.Enabled = false;
                    break;
                case "JatuhTempo":
                    btn_Batal.Enabled = true;
                    btn_Cair.Enabled = true;
                    gb_Cair.Visible = false;
                    bindingNavigatorEditItem.Enabled = true;
                    break;
                default:
                    btn_Batal.Enabled = false;
                    btn_Cair.Enabled = false;
                    gb_Cair.Visible = false;
                    bindingNavigatorEditItem.Enabled = false;
                    break;
            }
        }

        FormViewReport f_Report;
        private void btn_Detail_Click(object sender, EventArgs e)
        {
            if (f_Report != null)
            {
                if (!f_Report.IsDisposed)
                    f_Report.Close();
            }
            f_Report = new FormViewReport(ListOfReports.UtangDetail);
            f_Report.Trans = ListOfTransaction.Purchase;
            f_Report.DataId = combo_Supplier.SelectedValue.ToString();
            f_Report.DataId2 = currencyIdComboBox.SelectedItem.ToString();
            f_Report.Width = 800;
            f_Report.Show(this);
        }

        private void btn_Batal_Click(object sender, EventArgs e)
        {
            giroStatusLabel1.Text = ListOfGiroStatus.Batal.ToString();
            btn_Batal.Enabled = false;
            btn_Cair.Enabled = false;
        }

        private void btn_Cair_Click(object sender, EventArgs e)
        {
            gb_Cair.Visible = true;
            giroCairDateDateTimePicker.Value = DateTime.Now;
            giroStatusLabel1.Text = ListOfGiroStatus.Cair.ToString();
            btn_Batal.Enabled = false;
            btn_Cair.Enabled = false;
            giroCairDateDateTimePicker.Select();
            giroCairDateDateTimePicker.Focus();
        }
        private void detailControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender == null)
                bankIdComboBox.Focus();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                Control c = (Control)sender;
                if (sender == bankIdComboBox)
                {
                    giroNoTextBox.Focus();
                    giroNoTextBox.Select();
                }
                else if (sender == giroNoTextBox)
                {
                    giroAmmountNumericUpDown.Focus();
                    giroAmmountNumericUpDown.Select();
                }
                else if (sender == giroAmmountNumericUpDown)
                {
                    giroMaturityDateDateTimePicker.Focus();
                    giroMaturityDateDateTimePicker.Select();
                }
                else if (sender == giroMaturityDateDateTimePicker)
                {
                    if (giroCairDateDateTimePicker.Visible)
                    {
                        giroCairDateDateTimePicker.Select();
                        giroCairDateDateTimePicker.Focus();
                    }
                    else
                        bindingNavigatorSaveItem_Click(null, null);
                }
                else if (sender == giroCairDateDateTimePicker)
                    bindingNavigatorSaveItem_Click(null, null);

            }
        }

        private void FormGiro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bindingNavigatorSaveItem.Enabled)
            {
                DialogResult res = MessageBox.Show("Data belum disimpan. Simpan data?", "Konfirmasi simpan data.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    bindingNavigatorSaveItem.PerformClick();
                    e.Cancel = false;
                }
                else if (res == DialogResult.No)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }

        private void bindingNavigatorSaveItem_EnabledChanged(object sender, EventArgs e)
        {
            if (bindingNavigatorSaveItem.Enabled)
            {
                this.Text = this.Text + "*";
                this.TabText = this.TabText + "*";
            }
            else
            {
                this.Text = this.Text.Replace("*", "");
                this.TabText = this.TabText.Replace("*", "");
            }
        }

        private FormDeleteConfirm formDel;
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //{
            formDel = new FormDeleteConfirm(FormDeleteConfirm.DeletePin.Giro);

                if (formDel.ShowDialog(this) == DialogResult.OK)
                {
                    giro = (TGiro)DataMaster.GetObjectByProperty(typeof(TGiro), TGiro.ColumnNames.GiroNo, giroNoTextBox.Text, TGiro.ColumnNames.BankId, bankIdComboBox.SelectedValue.ToString());
                    if (giro != null)
                        DataMaster.Delete(giro);

                    ModuleControlSettings.SaveLog(ListOfAction.Delete, bankIdComboBox.SelectedValue.ToString() + ";" + giroNoTextBox.Text + ";" + ListOfGiroStatus.Baru.ToString(), ListOfTable.TGiro, lbl_UserName.Text);
                    BindGiroData();
                }
            }
        //}
    }
}