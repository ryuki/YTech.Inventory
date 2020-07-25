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
using Inventori.Billiard.Data;

namespace Inventori.Billiard.Forms
{
    public partial class FormClosingDay : FormParentForBilliard
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        public FormClosingDay()
        {
            InitializeComponent();
        }

        private void FormClosingDay_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            ModuleControlSettings.SetDateTimePicker(dt_ClosingFrom, true);
            ModuleControlSettings.SetDateTimePicker(dt_ClosingTo, true);
            try
            {
 dt_ClosingFrom.Value = ModuleControlSettings.GetMaksDateTransactionClosing();
            }
            catch (Exception)
            {
                dt_ClosingFrom.Value = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
            }
           
            dt_ClosingTo.Value = DateTime.Now;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin melakukan tutup hari?", "Konfirmasi tutup hari", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            pb_Loading.Visible = true;
            lbl_Loading.Visible = true;

            pb_Loading.Maximum = 5;
            pb_Loading.Value = 0;
            this.Refresh();

            DateTime from = dt_ClosingFrom.Value;
            DateTime to = dt_ClosingTo.Value;

            IList listEmployee = DataMaster.GetAll(typeof(MEmployee));
            MEmployee emp;
            IList listTrans;
            TTransaction trans;
            IList listDet;
            TTransactionDetail transDet;
            TRekapTransaction rekapTrans;
            TRekapCommission rekapCom;

            decimal refereePrice = 0;
            string billiardItem = "Rental Meja";
            TBilliardSetting bilSet = (TBilliardSetting)DataMaster.GetObjectByProperty(typeof(TBilliardSetting), TBilliardSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            if (bilSet == null)
            {
                MessageBox.Show("Setting untuk menghitung komisi wasit tidak terdaftar, \n Hubungi supervisor anda untuk konfigurasi sistem. \n Atau klik menu Tools - Konfigurasi Program", "Konfirmasi tutup hari", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (bilSet.RefereeBonus == 0)
                {
                    MessageBox.Show("Bonus wasit 0, \n Hubungi supervisor anda untuk konfigurasi sistem. \n Atau klik menu Tools - Konfigurasi Program", "Konfirmasi tutup hari", MessageBoxButtons.OK);
                    return;
                }
                else
                    refereePrice = bilSet.RefereeBonus;
            }


            decimal totSales = 0;
            decimal totSalesVIP = 0;
            decimal totReturSales = 0;
            decimal totReturSalesVIP = 0;
            decimal totPurchase = 0;
            decimal totReturPurchase = 0;
            decimal totCorrection = 0;
            decimal q = 0;

            decimal totDuration;
            decimal totBonus;


            pb_Loading.Value = 1;

            //looping for available employee
            for (int i = 0; i < listEmployee.Count; i++)
            {
                emp = (MEmployee)listEmployee[i];
                listTrans = DataMaster.GetListBetweenEqValue(typeof(TTransaction), TTransaction.ColumnNames.TransactionDate, from, to, TTransaction.ColumnNames.EmployeeId, emp.EmployeeId);
                if (listTrans.Count > 0)
                {
                    totDuration = 0;
                    totBonus = 0;

                    //looping for list transaction 
                    for (int j = 0; j < listTrans.Count; j++)
                    {
                        trans = (TTransaction)listTrans[j];

                        //searching transaction detail for billiard item
                        listDet = DataMaster.GetListLikeEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, trans.TransactionId, TTransactionDetail.ColumnNames.ItemId, billiardItem + "%");

                        if (listDet.Count > 0)
                        {
                            transDet = (TTransactionDetail)listDet[0];

                            if (transDet != null)
                            {
                                totDuration += transDet.Quantity;
                                totBonus += transDet.Quantity * refereePrice;
                            }
                        }
                    }
                    totBonus = Math.Floor(totBonus / bilSet.FullfillPrice) * bilSet.FullfillPrice;

                    rekapCom = new TRekapCommission();
                    rekapCom.EmployeeId = emp.EmployeeId;
                    rekapCom.RefereePrice = refereePrice;
                    rekapCom.RefereePriceVip = refereePrice;

                    rekapCom.RekapBonus = totBonus;
                    rekapCom.RekapDateFrom = from;
                    rekapCom.RekapDateTo = to;

                    //duration in minutes
                    rekapCom.RekapTotalDuration = totDuration * 60;
                    rekapCom.ModifiedBy = lbl_UserName.Text;
                    rekapCom.ModifiedDate = DateTime.Now;            
                    DataMaster.SavePersistence(rekapCom);
                }
            }

            //trans does not have referee
            listTrans = DataMaster.GetListBetweenEqValue(typeof(TTransaction), TTransaction.ColumnNames.TransactionDate, from, to, TTransaction.ColumnNames.EmployeeId, string.Empty);
            if (listTrans.Count > 0)
            {
                totDuration = 0;
                totBonus = 0;

                //looping for list transaction 
                for (int j = 0; j < listTrans.Count; j++)
                {
                    trans = (TTransaction)listTrans[j];

                    //searching transaction detail for billiard item
                    listDet = DataMaster.GetListLikeEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, trans.TransactionId, TTransactionDetail.ColumnNames.ItemId, billiardItem + "%");

                    if (listDet.Count > 0)
                    {
                        transDet = (TTransactionDetail)listDet[0];
                        if (transDet != null)
                        {
                            totDuration += transDet.Quantity;
                            totBonus += transDet.Quantity * refereePrice;
                        }
                    }
                }
                totBonus = Math.Floor(totBonus / bilSet.FullfillPrice) * bilSet.FullfillPrice;

                rekapCom = new TRekapCommission();
                rekapCom.EmployeeId = string.Empty;
                rekapCom.RefereePrice = refereePrice;
                rekapCom.RefereePriceVip = refereePrice;

                rekapCom.RekapBonus = totBonus;
                rekapCom.RekapDateFrom = from;
                rekapCom.RekapDateTo = to;
                //duration in minutes
                rekapCom.RekapTotalDuration = totDuration * 60;
                rekapCom.ModifiedBy = lbl_UserName.Text;
                rekapCom.ModifiedDate = DateTime.Now;            
                DataMaster.SavePersistence(rekapCom);
            }


            pb_Loading.Value = 3;
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

            pb_Loading.Value = 4;
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

           
            pb_Loading.Value = 5;

            pb_Loading.Visible = false;
            lbl_Loading.Visible = false;
            buttonOK.Enabled = false;

            FormViewReport f_ViewReport = new FormViewReport();

            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportListTransaction.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Sales.ToString();
            f_ViewReport.lbl_Param2.Text = dt_ClosingFrom.Value.ToString();
            f_ViewReport.lbl_Param3.Text = dt_ClosingTo.Value.ToString();

            f_ViewReport.StartPosition = FormStartPosition.WindowsDefaultLocation;
            f_ViewReport.WindowState = FormWindowState.Maximized;
            f_ViewReport.Show();
        }
    }
}

