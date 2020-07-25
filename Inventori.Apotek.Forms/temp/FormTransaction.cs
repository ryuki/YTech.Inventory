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
    public partial class FormTransaction : FormParentForApotek
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private Balloon.NET.BalloonHelp balloonHelp;
        public event EventHandler TransactionHasSaved;
        ListOfTransaction trans;

        public FormTransaction(ListOfTransaction tr)
        {
            InitializeComponent();
            trans = tr;
            this.Icon = Properties.Resources.sales_ico;
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
        }

        private void FormTransaction_Load(object sender, EventArgs e)
        {
            SetInitialCommonSettings();
            ResetTransaction(null, null);
        }

        void SetInitialCommonSettings()
        {
            ModuleControlSettings.SetDateTimePicker(transactionDateDateTimePicker);

            for (int i = 0; i < 9; i++)
                tTransactionDetailDataGridView.Columns.Add(i.ToString(), i.ToString());

            //set width for grid view
            tTransactionDetailDataGridView.Columns[0].Width = itemIdTextBox.Width;
            tTransactionDetailDataGridView.Columns[1].Width = itemNameTextBox.Width;
            tTransactionDetailDataGridView.Columns[2].Width = quantityNumericUpDown.Width;
            tTransactionDetailDataGridView.Columns[3].Width = priceNumericUpDown.Width;
            tTransactionDetailDataGridView.Columns[4].Width = jumlahNumericUpDown.Width;
            tTransactionDetailDataGridView.Columns[5].Width = discNumericUpDown.Width;
            tTransactionDetailDataGridView.Columns[6].Width = tuslahNumericUpDown.Width;
            tTransactionDetailDataGridView.Columns[7].Width = totalNumericUpDown.Width;
            tTransactionDetailDataGridView.Columns[8].Width = expiredDateDateTimePicker.Width;

            for (int i = 2; i < 8; i++)
            {
                tTransactionDetailDataGridView.Columns[i].DefaultCellStyle.Format = "N";
                tTransactionDetailDataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            ModuleControlSettings.SetNumericUpDown(quantityNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(priceNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(jumlahNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(discNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(tuslahNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(totalNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(quantitySubTotalNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(priceSubTotalNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(jumlahSubTotalNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(discountSubTotalNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(tuslahSubTotalNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(totalSubTotalNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(ppnNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(GrandTotalNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(piHutangCreditLongNumericUpDown);

            ModuleControlSettings.SetDateTimePicker(expiredDateDateTimePicker, false);

            //search item
            PictureBox searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicItem_Click);
            itemIdTextBox.Controls.Add(searchPic);

            //search customer
            searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(transactionByTextBox, ListOfSearchWindow.SearchCustomer.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicTransactionBy_Click);
            transactionByTextBox.Controls.Add(searchPic);

            mRoomBindingSource.DataSource = DataMaster.GetAll(typeof(MRoom));
            mCustomerGroupBindingSource.DataSource = DataMaster.GetAll(typeof(MCustomerGroup));

            //set initial settings
            if (trans == ListOfTransaction.Sales)
                SetInitialSettingsForSales();
            else if (trans == ListOfTransaction.Purchase)
                SetInitialSettingsForPurchase();
        }

        void SetInitialSettingsForSales()
        {
            //reference id
            transactionReferenceIdLabel.Visible = false;
            transactionReferenceIdTextBox.Visible = false;

            //lama kredit
            piHutangCreditLongLabel.Visible = false;
            piHutangCreditLongNumericUpDown.Visible = false;
            hariLabel.Visible = false;

            //price
            priceNumericUpDown.Enabled = false;
        }

        private void SetInitialSettingsForPurchase()
        {
            //transaction by label
            transactionByLabel.Text = "Supplier";

            //kategori pelanggan
            transactionByNameLabel.Visible = false;
            transactionByNameComboBox.Visible = false;

            //nama pasien
            transactionDescLabel.Visible = false;
            transactionDescTextBox.Visible = false;

            //ruangan
            transactionDeskComboBox.Visible = false;
            transactionDeskLabel.Visible = false;
        }


        void searchPicTransactionBy_Click(object sender, EventArgs e)
        {
            if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.ReturSales))
                OpenFormSearchCustomer();
            else if (trans.Equals(ListOfTransaction.Correction))
                OpenFormSearchEmployee();
            else if (trans.Equals(ListOfTransaction.Purchase) || trans.Equals(ListOfTransaction.ReturPurchase))
                OpenFormSearchSupplier();
        }

        FormSearchEmployee f_SearchEmployee;
        private void OpenFormSearchEmployee()
        {
            if (f_SearchEmployee != null)
            {
                if (!f_SearchEmployee.IsDisposed)
                {
                    f_SearchEmployee.WindowState = FormWindowState.Normal;
                    f_SearchEmployee.BringToFront();
                }
                else
                    f_SearchEmployee = new FormSearchEmployee();
            }
            else
                f_SearchEmployee = new FormSearchEmployee();

            f_SearchEmployee.EmployeeHasSelected += new EventHandler(f_SearchEmployee_EmployeeHasSelected);
            f_SearchEmployee.ShowDialog(this);
        }

        private void f_SearchEmployee_EmployeeHasSelected(object sender, EventArgs e)
        {
            if (f_SearchEmployee.grid_Search.Rows.Count > 0)
            {
                transactionByTextBox.Text = f_SearchEmployee.grid_Search.CurrentRow.Cells[0].Value.ToString();
                transactionByTextBox_Validating(null, null);
            }
        }


        FormSearchCustomer f_SearchCustomer;//= new FormSearchItem();
        private void OpenFormSearchCustomer()
        {
            if (f_SearchCustomer != null)
            {
                if (!f_SearchCustomer.IsDisposed)
                {
                    f_SearchCustomer.WindowState = FormWindowState.Normal;
                    f_SearchCustomer.BringToFront();
                }
                else
                    f_SearchCustomer = new FormSearchCustomer();
            }
            else
                f_SearchCustomer = new FormSearchCustomer();

            f_SearchCustomer.CustomerHasSelected += new EventHandler(f_SearchCustomer_CustomerHasSelected);
            //f_SearchCustomer.MdiParent = this.MdiParent;
            f_SearchCustomer.ShowInTaskbar = false;
            f_SearchCustomer.ShowDialog();
        }

        private void f_SearchCustomer_CustomerHasSelected(object sender, EventArgs e)
        {
            if (f_SearchCustomer.grid_Search.Rows.Count > 0)
            {
                transactionByTextBox.Text = f_SearchCustomer.grid_Search.CurrentRow.Cells[0].Value.ToString();
                transactionByTextBox_Validating(null, null);
            }
        }

        FormSearchSupplier f_SearchSupplier;//= new FormSearchItem();
        private void OpenFormSearchSupplier()
        {
            if (f_SearchSupplier != null)
            {
                if (!f_SearchSupplier.IsDisposed)
                {
                    f_SearchSupplier.WindowState = FormWindowState.Normal;
                    f_SearchSupplier.BringToFront();
                }
                else
                    f_SearchSupplier = new FormSearchSupplier();
            }
            else
                f_SearchSupplier = new FormSearchSupplier();

            f_SearchSupplier.SupplierHasSelected += new EventHandler(f_SearchSupplier_SupplierHasSelected);
            f_SearchSupplier.ShowInTaskbar = false;
            f_SearchSupplier.ShowDialog();
        }

        private void f_SearchSupplier_SupplierHasSelected(object sender, EventArgs e)
        {
            if (f_SearchSupplier.grid_Search.Rows.Count > 0)
            {
                transactionByTextBox.Text = f_SearchSupplier.grid_Search.CurrentRow.Cells[0].Value.ToString();
                transactionByTextBox_Validating(null, null);
            }
        }

        void searchPicItem_Click(object sender, EventArgs e)
        {
            OpenFormSearchItem();
        }

        FormSearchItem f_SearchItem;
        private void OpenFormSearchItem()
        {
            if (f_SearchItem != null)
            {
                if (!f_SearchItem.IsDisposed)
                {
                    f_SearchItem.WindowState = FormWindowState.Normal;
                    f_SearchItem.BringToFront();
                }
                else
                    f_SearchItem = new FormSearchItem();
            }
            else
                f_SearchItem = new FormSearchItem();

            f_SearchItem.ItemHasSelected += new EventHandler(f_SearchItem_ItemHasSelected);
            if (!trans.Equals(ListOfTransaction.Sales))
                f_SearchItem.lbl_TempTransaction.Text = trans.ToString();

            f_SearchItem.ShowInTaskbar = false;
            f_SearchItem.ShowDialog();
        }

        private void f_SearchItem_ItemHasSelected(object sender, EventArgs e)
        {
            if (f_SearchItem.grid_Search.Rows.Count > 0)
            {
                itemIdTextBox.Text = f_SearchItem.grid_Search.CurrentRow.Cells[0].Value.ToString();
                itemIdTextBox_Validating(null, null);
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (ValidateTransactionDetail())
            {
                object[] transDetail = new object[9];
                transDetail[0] = itemIdTextBox.Text;
                transDetail[1] = itemNameTextBox.Text;
                transDetail[2] = quantityNumericUpDown.Value;
                transDetail[3] = priceNumericUpDown.Value;
                transDetail[4] = jumlahNumericUpDown.Value;
                transDetail[5] = discNumericUpDown.Value;
                transDetail[6] = tuslahNumericUpDown.Value;
                transDetail[7] = totalNumericUpDown.Value;
                transDetail[8] = expiredDateDateTimePicker.Value;

                tTransactionDetailDataGridView.Rows.Add(transDetail);

                ResetTransactionDetail();

            }

        }

        private void transactionUsePpnCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ppnNumericUpDown.Enabled = transactionUsePpnCheckBox.Checked;
            if (!ppnNumericUpDown.Enabled)
                ppnNumericUpDown.Value = 0;
            else
                ppnNumericUpDown.Value = 10;

            CalculateGrandTotal(null, null);
        }

        private void itemIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(itemIdTextBox.Text.Trim()))
            {
                MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemIdTextBox.Text);

                if (item != null)
                {
                    itemNameTextBox.Text = item.ItemName;

                    if (trans.Equals(ListOfTransaction.Sales))
                    {
                        if (transactionByNameComboBox.SelectedIndex != -1)
                        {
                            MCustomerGroup custGroup = (MCustomerGroup)DataMaster.GetObjectByProperty(typeof(MCustomerGroup), MCustomerGroup.ColumnNames.CustomerGroupId, transactionByNameComboBox.SelectedValue.ToString());
                            decimal persen = 0;
                            if (custGroup != null)
                                persen = custGroup.CustomerGroupPercentage;
                            priceNumericUpDown.Value = item.ItemPricePurchase * (1 + (persen / 100));
                        }
                        else
                        {
                            MessageBox.Show("Kategori Pelanggan belum dipilih!", "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResetTransactionDetail();
                            transactionByNameComboBox.Select();
                        }

                    }
                    else if (trans.Equals(ListOfTransaction.Purchase) || trans.Equals(ListOfTransaction.ReturPurchase))
                        priceNumericUpDown.Value = item.ItemPricePurchase;

                    //if (!trans.Equals(ListOfTransaction.Correction))
                    //    num_Price.Value = item.ItemPriceMax;
                }
            }
        }

        private void CalculateJumlahAndTotal(object sender, EventArgs e)
        {
            jumlahNumericUpDown.Value = quantityNumericUpDown.Value * priceNumericUpDown.Value;
            totalNumericUpDown.Value = (jumlahNumericUpDown.Value * ((100 - discNumericUpDown.Value) / 100)) + tuslahNumericUpDown.Value;
        }

        private void CalculateSubTotal()
        {
            decimal sq = 0;
            decimal sp = 0;
            decimal sj = 0;
            decimal sd = 0;
            decimal stus = 0;
            decimal st = 0;

            for (int i = 0; i < tTransactionDetailDataGridView.Rows.Count; i++)
            {
                sq += Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[2].Value);
                sp += Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[3].Value);
                sj += Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[4].Value);
                sd += Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[5].Value);
                stus += Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[6].Value);
                st += Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[7].Value);
            }

            quantitySubTotalNumericUpDown.Value = sq;
            priceSubTotalNumericUpDown.Value = sp;
            jumlahSubTotalNumericUpDown.Value = sj;
            discountSubTotalNumericUpDown.Value = sd;
            tuslahSubTotalNumericUpDown.Value = stus;
            totalSubTotalNumericUpDown.Value = st;
        }

        private void tTransactionDetailDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateSubTotal();
        }

        private void tTransactionDetailDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateSubTotal();
        }

        private void CalculateGrandTotal(object sender, EventArgs e)
        {
            if (ppnNumericUpDown.Enabled)
                GrandTotalNumericUpDown.Value = totalSubTotalNumericUpDown.Value * ((100 + ppnNumericUpDown.Value) / 100);
            else
                GrandTotalNumericUpDown.Value = totalSubTotalNumericUpDown.Value;
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (tTransactionDetailDataGridView.Rows.Count > 0)
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (tTransactionDetailDataGridView.CurrentRow.Index != -1)
                        tTransactionDetailDataGridView.Rows.RemoveAt(tTransactionDetailDataGridView.CurrentRow.Index);
                    else
                        tTransactionDetailDataGridView.Rows.RemoveAt(0);

                    ResetTransactionDetail();
                }
            }
        }

        private void itemIdTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), true);
        }

        private void itemIdTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), false);
        }

        private void transactionByTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(transactionByTextBox, ListOfSearchWindow.SearchCustomer.ToString(), true);
        }

        private void transactionByTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(transactionByTextBox, ListOfSearchWindow.SearchCustomer.ToString(), false);
        }

        private void transactionByTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(transactionByTextBox.Text.Trim()))
            {
                if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.ReturSales) || trans.Equals(ListOfTransaction.SalesVIP) || trans.Equals(ListOfTransaction.ReturSalesVIP))
                {
                    MCustomer cust = (MCustomer)DataMaster.GetObjectByProperty(typeof(MCustomer), MCustomer.ColumnNames.CustomerId, transactionByTextBox.Text);
                    if (cust != null)
                        transactionByTextBox_Name.Text = cust.CustomerName;
                    else
                        transactionByTextBox_Name.ResetText();
                }
                else if (trans.Equals(ListOfTransaction.Usage) || trans.Equals(ListOfTransaction.Correction))
                {
                    MEmployee emp = (MEmployee)DataMaster.GetObjectByProperty(typeof(MEmployee), MEmployee.ColumnNames.EmployeeId, transactionByTextBox.Text);
                    if (emp != null)
                        transactionByTextBox_Name.Text = emp.EmployeeName;
                    else
                        transactionByTextBox_Name.ResetText();
                }
                else if (trans.Equals(ListOfTransaction.PurchaseOrder) || trans.Equals(ListOfTransaction.Purchase) || trans.Equals(ListOfTransaction.ReturPurchase))
                {
                    MSupplier supp = (MSupplier)DataMaster.GetObjectByProperty(typeof(MSupplier), MSupplier.ColumnNames.SupplierId, transactionByTextBox.Text);
                    if (supp != null)
                    {
                        transactionByTextBox_Name.Text = supp.SupplierName;


                        if (trans.Equals(ListOfTransaction.Purchase))
                        {
                            ModuleControlSettings.SetTransactionTextBoxSuggest(transactionReferenceIdTextBox, ListOfTransaction.PurchaseOrder, supp.SupplierId);
                        }
                    }
                    else
                        transactionByTextBox_Name.ResetText();
                }
            }
        }

        void ResetTransactionDetail()
        {
            itemIdTextBox.ResetText();
            itemNameTextBox.ResetText();
            quantityNumericUpDown.Value = 1;
            priceNumericUpDown.Value = 0;
            jumlahNumericUpDown.Value = 0;
            discNumericUpDown.Value = 0;
            tuslahNumericUpDown.Value = 0;
            totalNumericUpDown.Value = 0;

            itemIdTextBox.Select();
        }

        void ResetTransaction(object sender, EventArgs e)
        {
            transactionIdLabel.Text = DateTime.Now.ToFileTime().ToString();
            transactionDateDateTimePicker.Value = DateTime.Now;
            transactionFacturTextBox.Text = AppCode.GenerateFacturNo(trans, string.Empty);
            transactionReferenceIdTextBox.ResetText();
            transactionByTextBox.ResetText();
            transactionByTextBox_Name.ResetText();
            transactionByNameComboBox.SelectedIndex = -1;
            transactionDescTextBox.ResetText();
            transactionDeskComboBox.SelectedIndex = -1;

            groupBox_Payment.Visible = false;

            tTransactionDetailDataGridView.Rows.Clear();
            ResetTransactionDetail();
        }

        void SaveTransactionInterface(object sender, EventArgs e)
        {
            if (ValidateTransaction())
            {
                if (trans == ListOfTransaction.Sales)
                {
                    if (sender == simpanToolStripButton)
                    {
                        groupBox_Payment.Visible = true;
                        goto none;
                    }
                    else if (sender == button_Cash)
                    {
                        salesPayment = Payment.Cash;
                        goto save;
                    }
                    else if (sender == button_Credit)
                    {
                        salesPayment = Payment.Credit;
                        goto saveCredit;
                    }
                }
                else if (trans == ListOfTransaction.Purchase)
                {
                    salesPayment = Payment.Credit;
                    goto saveCredit;
                }
                else
                    goto save;

            saveCredit:
                {
                    SaveJournalInterface();
                    SavePiHutang();
                    SaveTransaction();
                    SaveTransactionDetail();

                    ResetTransaction(null, null);
                    ResetTransactionDetail();
                };

            save:
                {
                    SaveJournalInterface();
                    SaveTransaction();
                    SaveTransactionDetail();

                    ResetTransaction(null, null);
                    ResetTransactionDetail();
                };
            none:
                {
                    //MessageBox.Show(sender.ToString());
                };

            }
        }

        private void SaveJournalInterface()
        {
            TDefaultAccount def = (TDefaultAccount)DataMaster.GetObjectByProperty(typeof(TDefaultAccount), TDefaultAccount.ColumnNames.TransactionType, trans.ToString(), TDefaultAccount.ColumnNames.TransactionPayment, salesPayment.ToString());
            if (salesPayment == Payment.Cash)
            {
                subAcc = def.DebetSubAccountId;
                //save to cash
                SaveJournal(subAcc, ListOfJournalStatus.Debet);
                //save to pj acc
                SaveJournal(def.KreditSubAccountId, ListOfJournalStatus.Kredit);
            }
            else if (salesPayment == Payment.Credit)
            {
                if (trans == ListOfTransaction.Sales)
                {
                    MCustomer cust = (MCustomer)DataMaster.GetObjectByProperty(typeof(MCustomer), MCustomer.ColumnNames.CustomerId, transactionByTextBox.Text);
                    if (cust != null)
                    {
                        if (!string.IsNullOrEmpty(cust.SubAccountId))
                            subAcc = cust.SubAccountId;
                        else
                            //if customer not have piutang account
                            subAcc = def.DebetSubAccountId;
                    }
                    else
                        //if customer not have piutang account
                        subAcc = def.DebetSubAccountId;

                    //add piutang journal
                    SaveJournal(subAcc, ListOfJournalStatus.Debet);

                    //save penjualan account
                    SaveJournal(def.KreditSubAccountId, ListOfJournalStatus.Kredit);
                }
                else if (trans == ListOfTransaction.Purchase)
                {
                    MSupplier supp = (MSupplier)DataMaster.GetObjectByProperty(typeof(MSupplier), MSupplier.ColumnNames.SupplierId, transactionByTextBox.Text);
                    if (supp != null)
                    {
                        if (!string.IsNullOrEmpty(supp.SubAccountId))
                            subAcc = supp.SubAccountId;
                        else
                            //if supp not have utang account
                            subAcc = def.DebetSubAccountId;
                    }
                    else
                        //if supp not have utang account
                        subAcc = def.DebetSubAccountId;

                    //add utang journal
                    SaveJournal(subAcc, ListOfJournalStatus.Debet);

                    //save penjualan account
                    SaveJournal(def.KreditSubAccountId, ListOfJournalStatus.Kredit);
                }

            }
        }

        private void SaveJournal(string subAccountId, ListOfJournalStatus listOfJournalStatus)
        {
            TJournal jur = new TJournal();

            MSubAccount sub = (MSubAccount)DataMaster.GetObjectByProperty(typeof(MSubAccount), MSubAccount.ColumnNames.SubAccountId, subAccountId);
            MAccount acc = new MAccount();
            if (sub != null)
            {
                acc = (MAccount)DataMaster.GetObjectByProperty(typeof(MAccount), MAccount.ColumnNames.AccountId, sub.AccountId);
                if (acc == null)
                    acc = new MAccount();
            }
            else
                sub = new MSubAccount();

            if (acc.AccountStatus == listOfJournalStatus.ToString())
            {
                jur.AccountSaldo = acc.AccountSaldo + GrandTotalNumericUpDown.Value;
                jur.SubAccontSaldo = sub.SubAccountSaldo + GrandTotalNumericUpDown.Value;
            }
            else
            {
                jur.AccountSaldo = acc.AccountSaldo - GrandTotalNumericUpDown.Value;
                jur.SubAccontSaldo = sub.SubAccountSaldo - GrandTotalNumericUpDown.Value;
            }

            jur.JournalDate = DateTime.Now;
            jur.JournalDesc = namaTransaksi + transactionFacturTextBox.Text;
            jur.JournalJumlah = GrandTotalNumericUpDown.Value;
            jur.JournalPic = transactionByTextBox.Text;
            jur.JournalStatus = listOfJournalStatus.ToString();
            jur.SubAccountId = subAccountId;
            jur.ModifiedBy = lbl_UserName.Text;
            jur.ModifiedDate = DateTime.Now;
            DataMaster.SavePersistence(jur);

            //update saldo sub account
            sub.SubAccountSaldo = jur.SubAccontSaldo;
            sub.ModifiedBy = lbl_UserName.Text;
            sub.ModifiedDate = DateTime.Now;
            DataMaster.UpdatePersistence(sub);

            //update saldo account
            acc.AccountSaldo = jur.AccountSaldo;
            acc.ModifiedBy = lbl_UserName.Text;
            acc.ModifiedDate = DateTime.Now;
            DataMaster.UpdatePersistence(acc);
        }

        string subAcc, namaTransaksi;
        private void SavePiHutang()
        {
            TPiHutang pihutang = new TPiHutang();
            pihutang.PiHutangCreditLong = piHutangCreditLongNumericUpDown.Value;
            pihutang.PiHutangDate = DateTime.Now;

            ListOfPiHutangStatus piHutangStatus = ListOfPiHutangStatus.Hutang;

            switch (trans)
            {
                case ListOfTransaction.Purchase:
                    namaTransaksi = "Pembelian ";
                    piHutangStatus = ListOfPiHutangStatus.Hutang;

                    break;
                case ListOfTransaction.Sales:
                    namaTransaksi = "Penjualan ";
                    piHutangStatus = ListOfPiHutangStatus.Piutang;

                    break;
                default:
                    break;
            }
            pihutang.PiHutangDesc = transactionFacturTextBox.Text;
            pihutang.PiHutangDibayar = 0;
            pihutang.PiHutangJatuhTempo = DateTime.Now.AddDays(Convert.ToDouble(piHutangCreditLongNumericUpDown.Value));
            pihutang.PiHutangJumlah = GrandTotalNumericUpDown.Value;
            pihutang.PiHutangLunasDate = DateTime.Now;
            pihutang.PiHutangStatus = piHutangStatus.ToString();
            pihutang.SubAccountId = subAcc;
            pihutang.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);

            pihutang.ModifiedBy = lbl_UserName.Text;
            pihutang.ModifiedDate = DateTime.Now;
            DataMaster.SavePersistence(pihutang);
        }

        void SaveTransaction()
        {
            TTransaction t = new TTransaction();
            t.CurrencyId = ListOfCurrency.Rupiah.ToString();
            t.EmployeeId = string.Empty;
            t.GudangId = 1;
            t.TransactionBy = transactionByTextBox.Text;

            if (transactionByNameComboBox.SelectedIndex != -1)
                t.TransactionByName = transactionByNameComboBox.SelectedValue.ToString();

            t.TransactionDate = transactionDateDateTimePicker.Value;
            t.TransactionDesc = transactionDescTextBox.Text;

            if (transactionDeskComboBox.SelectedIndex != -1)
                t.TransactionDesk = transactionDeskComboBox.SelectedValue.ToString();

            t.TransactionDisc = 0;
            t.TransactionFactur = transactionFacturTextBox.Text;
            t.TransactionGrandTotal = GrandTotalNumericUpDown.Value;
            t.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);

            if (salesPayment == Payment.Cash)
                t.TransactionPaid = GrandTotalNumericUpDown.Value;
            else if (salesPayment == Payment.Credit)
                t.TransactionPaid = 0;


            t.TransactionPayment = salesPayment.ToString();

            if (!string.IsNullOrEmpty(transactionReferenceIdTextBox.Text.Trim()))
                t.TransactionReferenceId = Convert.ToDecimal(transactionReferenceIdTextBox.Text);
            else
                t.TransactionReferenceId = 0;

            t.TransactionPpn = ppnNumericUpDown.Value;

            if (salesPayment == Payment.Cash)
                t.TransactionSisa = 0;
            else if (salesPayment == Payment.Credit)
                t.TransactionSisa = GrandTotalNumericUpDown.Value;


            t.TransactionStatus = trans.ToString();
            t.TransactionSubTotal = totalSubTotalNumericUpDown.Value;
            t.TransactionUsePpn = transactionUsePpnCheckBox.Checked;

            t.ModifiedBy = lbl_UserName.Text;
            t.ModifiedDate = DateTime.Now;
            DataMaster.SavePersistence(t);
        }

        Payment salesPayment = Payment.Cash;
        enum Payment
        {
            Cash,
            Credit
        }

        private void SaveTransactionDetail()
        {
            TTransactionDetail det;
            ItemGudangStok stok;
            MItem item;
            TStokCard krt;

            int gudangId = 1;

            bool AddStok = true;
            decimal saldo = 0;

            if ((trans == ListOfTransaction.Sales) || (trans == ListOfTransaction.ReturPurchase))
                AddStok = false;
            else if ((trans == ListOfTransaction.Purchase) || (trans == ListOfTransaction.ReturSales))
                AddStok = true;

            for (int i = 0; i < tTransactionDetailDataGridView.Rows.Count; i++)
            {
                saldo = 0;

                det = new TTransactionDetail();
                det.Description = string.Empty;
                det.Disc = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[5].Value);
                det.ExpiredDate = Convert.ToDateTime(tTransactionDetailDataGridView.Rows[i].Cells[8].Value);
                det.ItemId = tTransactionDetailDataGridView.Rows[i].Cells[0].Value.ToString();
                det.Jumlah = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[4].Value);
                det.Ppn = 0;
                det.Price = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[3].Value);
                det.Quantity = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[2].Value);

                //if corection, save item quantity for detail total
                if (trans == ListOfTransaction.Correction)
                    det.Total = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[2].Value);
                else
                    det.Total = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[7].Value);

                det.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);
                det.Tuslah = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[6].Value);
                det.ModifiedBy = lbl_UserName.Text;
                det.ModifiedDate = DateTime.Now;
                DataMaster.SavePersistence(det);

                item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, tTransactionDetailDataGridView.Rows[i].Cells[0].Value.ToString());
                if (item != null)
                {
                    //if purchase, update item price avg
                    if (trans == ListOfTransaction.Purchase)
                    {
                        item.ItemPricePurchaseAvg = (item.ItemPricePurchaseAvg + Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[3].Value)) / 2;
                        DataMaster.UpdatePersistence(item);
                    }

                    //if item == barang
                    if (item.ItemTypeId == 1)
                    {
                        //change stok
                        stok = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, tTransactionDetailDataGridView.Rows[i].Cells[0].Value.ToString(), ItemGudangStok.ColumnNames.GudangId, gudangId);
                        if (stok != null)
                        {
                            if (AddStok)
                                saldo = stok.ItemStok + Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[2].Value);
                            else
                                saldo = stok.ItemStok - Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[2].Value);

                            stok.ItemStok = saldo;
                            stok.ModifiedBy = lbl_UserName.Text;
                            stok.ModifiedDate = DateTime.Now;
                            DataMaster.UpdatePersistence(stok);
                        }
                        else
                        {
                            stok = new ItemGudangStok();
                            stok.GudangId = gudangId;
                            stok.ItemId = det.ItemId;
                            stok.ItemMaxStok = 0;
                            stok.ItemMinStok = 0;
                            if (AddStok)
                                stok.ItemStok = det.Quantity;
                            else
                                stok.ItemStok = det.Quantity * -1;
                            stok.ModifiedBy = lbl_UserName.Text;
                            stok.ModifiedDate = DateTime.Now;
                            DataMaster.SavePersistence(stok);
                        }

                    }

                    krt = new TStokCard();
                    krt.ItemId = tTransactionDetailDataGridView.Rows[i].Cells[0].Value.ToString();
                    krt.GudangId = gudangId;
                    krt.StokCardDate = DateTime.Now;
                    krt.StokCardPic = lbl_UserName.Text;
                    krt.StokCardQuantity = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[2].Value);
                    krt.StokCardSaldo = saldo;
                    krt.StokCardStatus = AddStok;
                    krt.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);
                    krt.ModifiedBy = lbl_UserName.Text;
                    krt.ModifiedDate = DateTime.Now;
                    DataMaster.SavePersistence(krt);
                }
            }
        }

        bool ValidateTransaction()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(transactionFacturTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Nomor faktur harus diisi !!";
                balloonHelp.ShowBalloon(transactionFacturTextBox);
                transactionFacturTextBox.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(transactionByTextBox.Text))
            {
                string errMsg = "";
                if ((trans == ListOfTransaction.Sales) || (trans == ListOfTransaction.ReturSales))
                {
                    errMsg = "Pelanggan harus diisi !!";
                }
                else if ((trans == ListOfTransaction.Purchase) || (trans == ListOfTransaction.ReturPurchase))
                    errMsg = "Supplier harus diisi !!";
                else if ((trans == ListOfTransaction.Correction))
                    errMsg = "Pelapor harus diisi !!";

                balloonHelp.Content = errMsg;
                balloonHelp.ShowBalloon(transactionByTextBox);
                transactionByTextBox.Focus();
                return false;
            }
            if (transactionByNameComboBox.Visible)
            {
                if (transactionByNameComboBox.SelectedIndex == -1)
                {
                    balloonHelp.Content = "Nomor faktur harus diisi !!";
                    balloonHelp.ShowBalloon(transactionByNameComboBox);
                    transactionByNameComboBox.Focus();
                    return false;
                }
            }
            if (tTransactionDetailDataGridView.RowCount == 0)
            {
                MessageBox.Show("Transaksi yang kosong tidak bisa diproses.", "Transaksi tidak bisa diproses.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                itemIdTextBox.Select();
                itemIdTextBox.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(transactionFacturTextBox.Text.Trim()))
            {
                TTransaction tr = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionFactur, transactionFacturTextBox.Text.Trim());
                if (tr != null)
                {
                    balloonHelp.Content = "Nomor faktur " + transactionFacturTextBox.Text + " sudah pernah diinput, silahkan input nomor faktur yang lain.";
                    balloonHelp.ShowBalloon(transactionFacturTextBox);
                    transactionFacturTextBox.Focus();
                    return false;
                }
            }

            return true;
        }

        bool ValidateTransactionDetail()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(itemIdTextBox.Text))
            {
                balloonHelp.Content = "Item harus diisi !!";
                balloonHelp.ShowBalloon(itemIdTextBox);
                itemIdTextBox.Focus();
                return false;
            }
            else
            {
                MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemIdTextBox.Text);
                if (item == null)
                {
                    balloonHelp.Content = "Item " + itemIdTextBox.Text + " tidak ada dalam database. \n Pastikan anda menulis kode yang tepat atau \n pilih item dengan mengklik gambar disamping untuk mencari item.";
                    balloonHelp.ShowBalloon(itemIdTextBox);
                    itemIdTextBox.Focus();
                    return false;
                }
            }

            if (quantityNumericUpDown.Value == 0)
            {
                balloonHelp.Content = "Kuantitas tidak boleh 0 !!";
                balloonHelp.ShowBalloon(quantityNumericUpDown);
                quantityNumericUpDown.Focus();
                return false;
            }
            return true;
        }

        private void transactionByNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetTransactionDetail();
            tTransactionDetailDataGridView.Rows.Clear();
        }

        private void RecreateBalloon()
        {
            balloonHelp = new Balloon.NET.BalloonHelp();
            balloonHelp.Icon = Properties.Resources.warning_ico;
            balloonHelp.CloseOnMouseClick = true;
            balloonHelp.CloseOnDeactivate = false;
            balloonHelp.CloseOnMouseMove = false;
            balloonHelp.CloseOnKeyPress = false;
            balloonHelp.ShowCloseButton = false;
            // balloonHelp.TopMost = true;
        }
    }
}