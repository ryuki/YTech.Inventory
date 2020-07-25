using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Inventori.Cafe.Data;
using Inventori.Data;
using Inventori.Facade;
using Inventori.Module;
using System.IO;
using Microsoft.Reporting.WinForms;
using Inventori.Data;

namespace Inventori.Cafe.Forms
{
    public partial class FormClosingDay : FormParentForCafe
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        public FormClosingDay()
        {
            InitializeComponent();
        }

        private void FormClosingDay_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.TRekapTransaction, lbl_UserName.Text);
            dt_ClosingFrom.Value = ModuleControlSettings.GetMaksDateTransactionClosing();
            dt_ClosingTo.Value = DateTime.Now;
            ModuleControlSettings.SetDateTimePicker(dt_ClosingFrom, true);
            ModuleControlSettings.SetDateTimePicker(dt_ClosingTo, true);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin melakukan tutup periode?", "Konfirmasi tutup periode", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            ModuleControlSettings.SaveLog(ListOfAction.Insert, dt_ClosingFrom.Value.ToLongDateString() + ";" + dt_ClosingTo.Value.ToLongDateString(), ListOfTable.TRekapTransaction, lbl_UserName.Text);

            pb_Loading.Visible = true;
            lbl_Loading.Visible = true;

            pb_Loading.Maximum = 5;
            pb_Loading.Value = 0;
            this.Refresh();

            DateTime from = dt_ClosingFrom.Value;
            DateTime to = dt_ClosingTo.Value;

            IList listTrans;
            TTransaction trans;
            IList listDet;
            TTransactionDetail transDet;
            TRekapTransaction rekapTrans;

            decimal totSales = 0;
            decimal totSalesVIP = 0;
            decimal totReturSales = 0;
            decimal totReturSalesVIP = 0;
            decimal totPurchase = 0;
            decimal totReturPurchase = 0;
            decimal totCorrection = 0;
            decimal q = 0;

            pb_Loading.Value = 1;

            //sum transaction grand total by date
            listTrans = DataMaster.GetListBetweenValue(typeof(TTransaction), TTransaction.ColumnNames.TransactionDate, from, to);

            for (int j = 0; j < listTrans.Count; j++)
            {

                trans = (TTransaction)listTrans[j];

                if (trans.TransactionStatus.Equals(ListOfTransaction.Sales.ToString()))
                    totSales += trans.TransactionGrandTotal;
                else if (trans.TransactionStatus.Equals(ListOfTransaction.SalesVIP.ToString()))
                    totSalesVIP += trans.TransactionGrandTotal;
                else if (trans.TransactionStatus.Equals(ListOfTransaction.ReturSales.ToString()))
                    totReturSales += trans.TransactionGrandTotal;
                else if (trans.TransactionStatus.Equals(ListOfTransaction.ReturSalesVIP.ToString()))
                    totReturSalesVIP += trans.TransactionGrandTotal;
                else if (trans.TransactionStatus.Equals(ListOfTransaction.Purchase.ToString()))
                    totPurchase += trans.TransactionGrandTotal;
                else if (trans.TransactionStatus.Equals(ListOfTransaction.ReturPurchase.ToString()))
                    totReturPurchase += trans.TransactionGrandTotal;
                else if (trans.TransactionStatus.Equals(ListOfTransaction.Correction.ToString()))
                {
                    listDet = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, trans.TransactionId);

                    for (int k = 0; k < listDet.Count; k++)
                    {
                        transDet = (TTransactionDetail)listDet[k];
                        q = transDet.Quantity;
                        if (transDet.Quantity < 0)
                            q = transDet.Quantity * -1;
                        totCorrection += q;
                    }
                }
            }

            rekapTrans = new TRekapTransaction();
            rekapTrans.RekapDateFrom = from;
            rekapTrans.RekapDateTo = to;
            rekapTrans.TotalCorrection = totCorrection;
            rekapTrans.TotalPurchase = totPurchase;
            rekapTrans.TotalReturPurchase = totReturPurchase;
            rekapTrans.TotalReturSales = totReturSales;
            rekapTrans.TotalReturSalesVip = totReturSalesVIP;
            rekapTrans.TotalSales = totSales;
            rekapTrans.TotalSalesVip = totSalesVIP;
            rekapTrans.ModifiedBy = lbl_UserName.Text;
            rekapTrans.ModifiedDate = DateTime.Now;
            DataMaster.SavePersistence(rekapTrans);

            pb_Loading.Value = 4;
            ////delete before transaction 
            //listTrans = DataMaster.GetListLessThan(typeof(TTransaction), TTransaction.ColumnNames.TransactionDate, from);
            //for (int j = 0; j < listTrans.Count; j++)
            //{
            //    trans = (TTransaction)listTrans[j];
            //    DataMaster.Delete(trans);

            //    listDet = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, trans.TransactionId);

            //    for (int k = 0; k < listDet.Count; k++)
            //    {
            //        transDet = (TTransactionDetail)listDet[k];
            //        DataMaster.Delete(transDet);
            //    }
            //}

            pb_Loading.Value = 5;

            pb_Loading.Visible = false;
            //lbl_Loading.Visible = false;

            buttonOK.Enabled = false;
            lbl_Loading.Text = "Tutup periode berhasil dilakukan.";

            try
            {
                System.Threading.Thread.Sleep(2000);
            }
            catch (Exception)
            {
            }

            f_ViewReport = new FormViewReport();

            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportTransactionTotal.ToString();
            // f_ViewReport.lbl_Param1.Text = ListOfTransaction.Sales.ToString();
            f_ViewReport.lbl_Param2.Text = dt_ClosingFrom.Value.ToString();
            f_ViewReport.lbl_Param3.Text = dt_ClosingTo.Value.ToString();

            f_ViewReport.StartPosition = FormStartPosition.WindowsDefaultLocation;
            f_ViewReport.WindowState = FormWindowState.Maximized;
            f_ViewReport.Show();

            f_ViewReport.reportViewer1.RefreshReport();

            //export to excel
            string exportDir = Application.StartupPath;
            TCafeSetting cafeSet = (TCafeSetting)DataMaster.GetObjectByProperty(typeof(TCafeSetting), TCafeSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            if (cafeSet != null)
                exportDir = cafeSet.ExportedDir;

            string fileName = exportDir + "\\Cafe " + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = f_ViewReport.reportViewer1.LocalReport.Render(
                "Excel", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            if (MessageBox.Show("Laporan berhasil diekspor ke \n " + fileName + "\n Buka file?", "Ekspor Laporan ke File Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //Excel.Application exc = new Excel.Application;
                //Excel.Workbook wb = exc.Workbooks.Open(
                //System.IO.File.OpenRead(fileName);
                try
                {
                    System.Diagnostics.Process.Start(fileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("File hasil ekspor gagal dibuka. Silahkan buka secara manual di lokasi hasil ekspor laporan.",
                                     "Laporan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private FormViewReport f_ViewReport;
    }
}

