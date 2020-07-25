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

namespace Inventori.Dealer.Forms
{
    public partial class FormClosing : FormParentForDealer
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();

        public FormClosing()
        {
            InitializeComponent();
        }

        private void FormClosing_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SetMonthsComboBox(comboBox_Month);
            if (DateTime.Today.Month == 1)
            {
                comboBox_Month.SelectedIndex = 11;
            }
            else
                comboBox_Month.SelectedIndex = DateTime.Today.Month - 2;
            numericUpDown_Year.Value = Convert.ToDecimal(DateTime.Today.Year);
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (!ValidateClosing())
                return;

            groupBox1.Enabled = false;
            progressBar1.Visible = true;
            label_Wait.Visible = true;

            UpdateAveragePrice();
            CalculateItemValue();

            MessageBox.Show(this.Text + " berhasil dilakukan!!", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
            f_ViewReport = new FormViewReport();
            f_ViewReport.lbl_UserName.Text = lbl_UserName.Text;
            f_ViewReport.listOfReports = ListOfReports.ReportNeraca;
            f_ViewReport.DataId = period;
            f_ViewReport.Show(this);
        }
        private FormViewReport f_ViewReport;

        string period;
        private bool ValidateClosing()
        {
            period = numericUpDown_Year.Value.ToString() + comboBox_Month.SelectedValue.ToString();

            TRekapSubAccount rekap = (TRekapSubAccount)DataMaster.GetObjectByProperty(typeof(TRekapSubAccount), TRekapSubAccount.ColumnNames.RekapSubAccountPeriode, period);

            if (rekap != null)
            {
                if (MessageBox.Show("Proses akhir bulan " + comboBox_Month.Text + " " + numericUpDown_Year.Value.ToString() + " sudah dilakukan. Anda yakin melanjutkan ?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return false;
            }

            string today = DateTime.Today.Month.ToString();
            if (DateTime.Today.Month < 10)
                today = decimal.Zero.ToString() + DateTime.Today.Month.ToString();
            today = DateTime.Today.Year.ToString() + today;


            if (Convert.ToDecimal(today) <= Convert.ToDecimal(period))
            {
                if (MessageBox.Show("Proses akhir bulan hanya bisa dilakukan untuk periode bulan sebelumnya. Anda yakin melanjutkan ?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return false;
            }

            IList listAcc = DataMaster.GetAll(typeof(MAccount));
            MAccount acc;
            decimal totDebet = 0;
            decimal totKredit = 0;

            for (int i = 0; i < listAcc.Count; i++)
            {
                acc = (MAccount)listAcc[i];
                if (acc.AccountStatus == ListOfJournalStatus.Debet.ToString())
                    totDebet += acc.AccountSaldo;
                else if (acc.AccountStatus == ListOfJournalStatus.Kredit.ToString())
                    totKredit += acc.AccountSaldo;
            }

            if (totKredit != totDebet)
            {
                decimal selisih = totDebet - totKredit;
                if (selisih < 0)
                    selisih = selisih * -1;

                MessageBox.Show("Proses akhir bulan belum dapat dilakukan, terjadi selisih sebesar " + ModuleControlSettings.NumericFormat(selisih, true), AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        DateTime from, to;
        private void UpdateAveragePrice()
        {
            string separator = "-";
            DateTimeConverter con = new DateTimeConverter();
            from = Convert.ToDateTime(con.ConvertFromString(numericUpDown_Year.Value.ToString() + separator + comboBox_Month.SelectedValue.ToString() + separator + decimal.Zero.ToString() + decimal.One.ToString()));
            to = from.AddMonths(1);

            //DataTable dt = AppCode.GetTransactionAveragePrice(ListOfTransaction.Purchase, from, to);
            //DataRow dr;
            //MItem item;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dr = dt.Rows[i];
            //    item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, dr[0].ToString());
            //    if (item != null)
            //    {
            //        item.ItemPricePurchaseAvg = Convert.ToDecimal(dr[1]);
            //        item.ModifiedBy = lbl_UserName.Text;
            //        item.ModifiedDate = DateTime.Now;
            //        DataMaster.UpdatePersistence(item);
            //    }
            //}
        }

        private void CalculateItemValue()
        {
            //IList listGudang = DataMaster.GetAll(typeof(MGudang));
            //MGudang gud;

            //IList listItemStok;
            //ItemGudangStok stok;
            //MItem item;

            //decimal itemvalue = 0;

            //for (int i = 0; i < listGudang.Count; i++)
            //{
            //    gud = (MGudang)listGudang[i];
            //    listItemStok = DataMaster.GetListEq(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.GudangId, gud.GudangId);
            //    for (int j = 0; j < listItemStok.Count; j++)
            //    {
            //        stok = (ItemGudangStok)listItemStok[j];
            //        item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, stok.ItemId);
            //        if (item != null)
            //        {
            //            itemvalue += stok.ItemStok * item.ItemPricePurchaseAvg;
            //        }
            //    }
            //}

            //IList listTrans = DataMaster.GetListBetweenValue(typeof(TTransaction), TTransaction.ColumnNames.TransactionDate, from, to);
            //IList listDet;
            //TTransaction trans;
            //TTransactionDetail det;

            //decimal salesTot = 0;
            //decimal retSalesTot = 0;
            //decimal hppSalesTot = 0;
            //decimal hppRetSalesTot = 0;
            ////decimal purTot = 0;
            ////decimal retPurTot = 0;

            //for (int i = 0; i < listTrans.Count; i++)
            //{
            //    trans = (TTransaction)listTrans[i];

            //    if (trans.TransactionStatus == ListOfTransaction.Sales.ToString() || trans.TransactionStatus == ListOfTransaction.ReturSales.ToString())
            //    {
            //        listDet = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, trans.TransactionId);
            //        for (int j = 0; j < listDet.Count; j++)
            //        {
            //            det = (TTransactionDetail)listDet[j];
            //            if (trans.TransactionStatus == ListOfTransaction.Sales.ToString())
            //                hppSalesTot += det.CostPrice;
            //            else if (trans.TransactionStatus == ListOfTransaction.ReturSales.ToString())
            //                hppRetSalesTot += det.CostPrice;
            //        }

            //    }
            //}

            //decimal hppNet = hppSalesTot - hppRetSalesTot;

            //string voucherno = AppCode.GetVoucherNo();

            //TJournal jur = new TJournal();
            //jur.JournalDate = DateTime.Today;
            //jur.JournalDesc = "Harga Pokok Penjualan bulan " + comboBox_Month.Text + " " + numericUpDown_Year.Value.ToString();
            //jur.JournalJumlah = hppNet;
            //jur.JournalPic = string.Empty;
            //jur.JournalStatus = ListOfJournalStatus.Debet.ToString();
            //jur.SubAccountId = AppCode.GetHPPAccountNo();
            //jur.VoucherNo = voucherno;
            //jur.ModifiedBy = lbl_UserName.Text;
            //jur.ModifiedDate = DateTime.Now;
            //AppCode.SaveTJournal(jur);

            //jur = new TJournal();
            //jur.JournalDate = DateTime.Today;
            //jur.JournalDesc = "Ikhtiar Rugi Laba bulan " + comboBox_Month.Text + " " + numericUpDown_Year.Value.ToString();
            //jur.JournalJumlah = hppNet;
            //jur.JournalPic = string.Empty;
            //jur.JournalStatus = ListOfJournalStatus.Kredit.ToString();
            //jur.SubAccountId = AppCode.GetIkhtiarRLAccountNo();
            //jur.VoucherNo = voucherno;
            //jur.ModifiedBy = lbl_UserName.Text;
            //jur.ModifiedDate = DateTime.Now;
            //AppCode.SaveTJournal(jur);

            IList listSubAcc = DataMaster.GetAll(typeof(MSubAccount));
            MSubAccount sub;
            MAccount acc;
            decimal rl = 0;
            for (int i = 0; i < listSubAcc.Count; i++)
            {
                sub = (MSubAccount)listSubAcc[i];
                SaveRekap(sub.AccountId, sub.SubAccountId, sub.SubAccountName, sub.SubAccountSaldo);
                acc = (MAccount)DataMaster.GetObjectByProperty(typeof(MAccount), MAccount.ColumnNames.AccountId, sub.AccountId);
                if (acc != null)
                {
                    if (acc.AccountPosition == ListOfAccountPosition.RugiLaba.ToString())
                    {
                        rl += sub.SubAccountSaldo;
                    }
                }
            }

            string voucherno = AppCode.GetVoucherNo();
            if (comboBox_Month.SelectedValue.ToString() == "12")
            {
                TJournal jur;
                IList listAcc = DataMaster.GetListEq(typeof(MAccount), MAccount.ColumnNames.AccountPosition, ListOfAccountPosition.RugiLaba.ToString());
                for (int i = 0; i < listAcc.Count; i++)
                {
                    acc = (MAccount)listAcc[i];
                    listSubAcc = DataMaster.GetListEq(typeof(MSubAccount), MSubAccount.ColumnNames.AccountId, acc.AccountId);
                    for (int j = 0; j < listSubAcc.Count; j++)
                    {
                        sub = (MSubAccount)listSubAcc[j];
                        jur = new TJournal();
                        jur.JournalDate = DateTime.Today;
                        jur.JournalDesc = "Jurnal Pembalik periode " + numericUpDown_Year.Value.ToString();
                        jur.JournalJumlah = sub.SubAccountSaldo;
                        jur.JournalPic = lbl_UserName.Text;
                        jur.JournalStatus = ListOfJournalStatus.Debet.ToString();

                        jur.SubAccountId = sub.SubAccountId;
                        jur.VoucherNo = voucherno;
                        jur.ModifiedBy = lbl_UserName.Text;
                        jur.ModifiedDate = DateTime.Now;
                        AppCode.SaveTJournal(jur);
                    }
                }

                sub = (MSubAccount)DataMaster.GetObjectByProperty(typeof(MSubAccount), MSubAccount.ColumnNames.SubAccountId, AppCode.GetLabaDitahanAccountNo());

                jur = new TJournal();
                jur.JournalDate = DateTime.Today;
                jur.JournalDesc = "Laba Tahun " + numericUpDown_Year.Value.ToString();
                jur.JournalJumlah = rl;
                jur.JournalPic = lbl_UserName.Text;
                jur.JournalStatus = ListOfJournalStatus.Kredit.ToString();
                jur.SubAccountId = sub.SubAccountId;
                jur.VoucherNo = voucherno;
                jur.ModifiedBy = lbl_UserName.Text;
                jur.ModifiedDate = DateTime.Now;
                AppCode.SaveTJournal(jur);

                SaveRekap(sub.AccountId, sub.SubAccountId, sub.SubAccountName, rl);
            }
            else
                SaveRekap("", "", "Laba/Rugi Periode Berjalan", rl);
        }

        private void SaveRekap(string acc, string subacc, string desc, decimal saldo)
        {
            //period = numericUpDown_Year.Value.ToString() + comboBox_Month.SelectedValue.ToString();
            TRekapSubAccount rekap = (TRekapSubAccount)DataMaster.GetObjectByProperty(typeof(TRekapSubAccount), TRekapSubAccount.ColumnNames.RekapSubAccountPeriode, period, TRekapSubAccount.ColumnNames.SubAccountId, subacc);
            if (rekap == null)
                rekap = new TRekapSubAccount();

            rekap.AccountId = acc;
            rekap.ModifiedBy = lbl_UserName.Text;
            rekap.ModifiedDate = DateTime.Now;
            rekap.RekapSubaccountDesc = desc;
            rekap.RekapSubAccountPeriode = period;
            rekap.RekapSubaccountSaldo = saldo;
            rekap.SubAccountId = subacc;
            DataMaster.SaveOrUpdate(rekap);
        }
    }
}