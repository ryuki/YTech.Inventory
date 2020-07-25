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
using Inventori.Billiard.Data;
using Inventori.Forms;
using Microsoft.Reporting.WinForms;

namespace Inventori.Billiard.Forms
{
    public partial class FormViewReport : Inventori.Billiard.Forms.FormParentForBilliard
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private BindingSource bs;
        public FormViewReport()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.report1;
        }
        private FormDateFilterReport f_FilterReport;
        private void FormViewReport_Load(object sender, EventArgs e)
        {
            if ((lbl_TempReport.Text.Equals(ListOfReports.RekapTotalTransactionByItem.ToString()) && !lbl_Param1.Text.Equals(lbl_Param1.Name)) || (lbl_TempReport.Text.Equals(ListOfReports.RekapTotalTransactionByDesk.ToString()) && !lbl_Param1.Text.Equals(lbl_Param1.Name)) || (lbl_TempReport.Text.Equals(ListOfReports.ReportDetailTransaction.ToString()) && !lbl_Param1.Text.Equals(lbl_Param1.Name)) || (lbl_TempReport.Text.Equals(ListOfReports.ReportRekapKomisiWasit.ToString()) && !lbl_Param1.Text.Equals(lbl_Param1.Name)) || (lbl_TempReport.Text.Equals(ListOfReports.ReportListTransaction.ToString()) && !lbl_Param1.Text.Equals(lbl_Param1.Name)) || (lbl_TempReport.Text.Equals(ListOfReports.ReportStokCard.ToString()) && !lbl_Param1.Text.Equals(lbl_Param1.Name)) || (lbl_TempReport.Text.Equals(ListOfReports.ReportListTransactionDetail.ToString()) && !lbl_Param1.Text.Equals(lbl_Param1.Name)) || (lbl_TempReport.Text.Equals(ListOfReports.ReportListTransactionDetailItem.ToString()) && !lbl_Param1.Text.Equals(lbl_Param1.Name)))
            {
                if (f_FilterReport != null)
                {
                    if (!f_FilterReport.IsDisposed)
                    {
                        f_FilterReport.WindowState = FormWindowState.Normal;
                        f_FilterReport.BringToFront();
                    }
                    else
                        f_FilterReport = new FormDateFilterReport();
                }
                else
                    f_FilterReport = new FormDateFilterReport();

                f_FilterReport.ShowDialog(this);
                lbl_Param2.Text = f_FilterReport.dt_From.Value.ToString();
                lbl_Param3.Text = f_FilterReport.dt_To.Value.ToString();
            }

            BindReport();
        }

        private void BindReport()
        {
            string title = "Laporan";
            reportViewer1.Reset();


            if (lbl_TempReport.Text.Equals(ListOfReports.MItem.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Billiard.Forms.Reports.ReportMItem.rdlc";
                FillVItemDetailDataSource();
                title = "Daftar Item";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.MGroup.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Billiard.Forms.Reports.ReportSubItem.rdlc";
                FillMGroupDataSource();
                title = "Daftar Golongan Item";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.MCustomer.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Billiard.Forms.Reports.ReportMCustomer.rdlc";
                FillMCustomerDataSource();
                title = "Daftar Pelanggan";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.MSupplier.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Billiard.Forms.Reports.ReportMSupplier.rdlc";
                FillMSupplierDataSource();
                title = "Daftar Supplier";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.MEmployee.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Billiard.Forms.Reports.ReportMEmployee.rdlc";
                FillMEmployeeDataSource();
                title = "Daftar Karyawan";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.MDesk.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Billiard.Forms.Reports.ReportMDesk.rdlc";
                FillMDeskDataSource();
                title = "Daftar Meja Billiard";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.RekapTotalTransactionByItem.ToString()))
            {
                DateTime from = Convert.ToDateTime(lbl_Param2.Text);
                DateTime to = Convert.ToDateTime(lbl_Param3.Text);
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Billiard.Forms.Reports.RekapTotalTransactionByItem.rdlc";
                FillTransactionTotalSource(lbl_Param1.Text, from, to);
                title = "Laporan Total Transaksi Berdasar Item";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.RekapTotalTransactionByDesk.ToString()))
            {
                DateTime from = Convert.ToDateTime(lbl_Param2.Text);
                DateTime to = Convert.ToDateTime(lbl_Param3.Text);
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Billiard.Forms.Reports.ReportTotalTransactionByDesk.rdlc";
                FillTransactionTotalSource(lbl_Param1.Text, from, to);
                title = "Laporan Total Transaksi Berdasar Meja";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.ReportDetailTransaction.ToString()))
            {
                DateTime from = Convert.ToDateTime(lbl_Param2.Text);
                DateTime to = Convert.ToDateTime(lbl_Param3.Text);
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Billiard.Forms.Reports.ReportTransactionDetail.rdlc";
                FillTransactionTotalSource(lbl_Param1.Text, from, to);
                title = "Laporan Detail Transaksi";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.ReportRekapKomisiWasit.ToString()))
            {
                DateTime from = Convert.ToDateTime(lbl_Param2.Text);
                DateTime to = Convert.ToDateTime(lbl_Param3.Text);
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Billiard.Forms.Reports.ReportRekapKomisiWasit.rdlc";
                FillRekapCommissionSource(from, to);
                title = "Laporan Rekap Komisi Wasit";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.ReportListTransaction.ToString()))
            {
                DateTime from = Convert.ToDateTime(lbl_Param2.Text);
                DateTime to = Convert.ToDateTime(lbl_Param3.Text);
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Billiard.Forms.Reports.ReportListTransaction.rdlc";

                FillTransactionTotalSource(lbl_Param1.Text, from, to, ReportBy.PIC, string.Empty);

                title = "Laporan Rekap Penjualan";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.ReportStokCard.ToString()))
            {
                DateTime from = Convert.ToDateTime(lbl_Param2.Text);
                DateTime to = Convert.ToDateTime(lbl_Param3.Text);
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Billiard.Forms.Reports.ReportStokCard.rdlc";

                FillVStokCard(from, to);

                title = "Laporan Kartu Stok";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.MDepartment.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Billiard.Forms.Reports.ReportMDep.rdlc";
                FillDataMaster(typeof(MDep));
                title = "Daftar Bagian";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.ReportListTransactionDetail.ToString()))
            {
                DateTime from = Convert.ToDateTime(lbl_Param2.Text);
                DateTime to = Convert.ToDateTime(lbl_Param3.Text);
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Billiard.Forms.Reports.ReportListTransactionDetail.rdlc";

                FillTransactionTotalSource(lbl_Param1.Text, from, to, ReportBy.Item, "%Rental Meja%");

                title = "Laporan Rekap Penjualan Meja";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.ReportListTransactionDetailItem.ToString()))
            {
                DateTime from = Convert.ToDateTime(lbl_Param2.Text);
                DateTime to = Convert.ToDateTime(lbl_Param3.Text);
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Billiard.Forms.Reports.ReportListTransactionDetail.rdlc";

                FillNotLikeTransactionTotalSource(lbl_Param1.Text, from, to, ReportBy.Item, "%Rental Meja%");

                title = "Laporan Rekap Penjualan Barang";
            }

            reportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

            this.reportViewer1.RefreshReport();

            this.Text = title;
            this.TabText = title;
        }

        private void FillNotLikeTransactionTotalSource(string transStatus, DateTime from, DateTime to, ReportBy reportBy, string ItemOrPIC)
        {
            string ItemOrPIC_Temp = ItemOrPIC;
            if (ItemOrPIC_Temp.Equals(""))
                ItemOrPIC_Temp = "%%";

            bs = new BindingSource();
            bs.Clear();

            NHibernate.Expression.ICriterion[] expArray = new NHibernate.Expression.ICriterion[3];
            expArray[0] = NHibernate.Expression.Expression.Not(NHibernate.Expression.Expression.InsensitiveLike(VTotalTransactionDetail.ColumnNames.ItemId, ItemOrPIC_Temp));
            expArray[1] = NHibernate.Expression.Expression.Between(VTotalTransactionDetail.ColumnNames.TransactionDate, from, to);
            expArray[2] = NHibernate.Expression.Expression.Or(NHibernate.Expression.Expression.Eq(VTotalTransactionDetail.ColumnNames.TransactionStatus, ListOfTransaction.Sales.ToString()), NHibernate.Expression.Expression.Eq(VTotalTransactionDetail.ColumnNames.TransactionStatus, ListOfTransaction.SalesVIP.ToString()));
            bs.DataSource = DataMaster.GetList(typeof(VTotalTransactionDetail), expArray, null);

            //if (!transStatus.Equals(lbl_Param1.Name))
            //switch (reportBy)
            //{
            //    case ReportBy.Item:
            //        NHibernate.Expression.ICriterion[] expArray = new NHibernate.Expression.ICriterion[1];
            //        expArray[0]=  NHibernate.Expression.Expression.Not( NHibernate.Expression.Expression.InsensitiveLike(VTotalTransactionDetail.ColumnNames.ItemId,ItemOrPIC_Temp));
            //        bs.DataSource = DataMaster.GetList(typeof(VTotalTransactionDetail), expArray, null);

            //        //bs.DataSource = DataMaster.GetListBetweenEqLikeValue(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionDate, from, to, VTotalTransactionDetail.ColumnNames.TransactionStatus, transStatus, VTotalTransactionDetail.ColumnNames.ItemId, ItemOrPIC_Temp);
            //        break;
            //    case ReportBy.PIC:
            //        bs.DataSource = DataMaster.GetListBetweenEqLikeValue(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionDate, from, to, VTotalTransactionDetail.ColumnNames.TransactionStatus, transStatus, VTotalTransactionDetail.ColumnNames.TransactionBy, ItemOrPIC_Temp);
            //        break;
            //    default:
            //        break;
            //}
            //else
            //    bs.DataSource = DataMaster.GetListBetweenValue(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionDate, from, to);

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTotalTransactionDetail", bs));

            try
            {

                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("Report_Parameter_DateFrom", from.ToString(AppCode.DateTimeFormat));
                parameters[1] = new ReportParameter("Report_Parameter_DateTo", to.ToString(AppCode.DateTimeFormat));
                reportViewer1.LocalReport.SetParameters(parameters);
            }
            catch (Exception)
            {
            }
        }

        private void FillDataMaster(Type type)
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetAll(type);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_" + type.Name, bs));
        }

        private void FillVStokCard(DateTime DateFrom, DateTime DateTo)
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetListBetweenValue(typeof(VStokCard), VStokCard.ColumnNames.StokCardDate, DateFrom, DateTo);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VStokCard", bs));
        }

        private enum ReportBy
        {
            Item, PIC
        }
        private void FillTransactionTotalSource(string transStatus, DateTime from, DateTime to, ReportBy reportBy, string ItemOrPIC)
        {
            string ItemOrPIC_Temp = ItemOrPIC;
            if (ItemOrPIC_Temp.Equals(""))
                ItemOrPIC_Temp = "%%";

            bs = new BindingSource();
            bs.Clear();
            //if (!transStatus.Equals(lbl_Param1.Name))
            switch (reportBy)
            {
                case ReportBy.Item:
                    NHibernate.Expression.ICriterion[] expArray = new NHibernate.Expression.ICriterion[3];
                    expArray[0] = NHibernate.Expression.Expression.InsensitiveLike(VTotalTransactionDetail.ColumnNames.ItemId, ItemOrPIC_Temp);
                    expArray[1] = NHibernate.Expression.Expression.Between(VTotalTransactionDetail.ColumnNames.TransactionDate, from, to);
                    expArray[2] = NHibernate.Expression.Expression.Or(NHibernate.Expression.Expression.Eq(VTotalTransactionDetail.ColumnNames.TransactionStatus, ListOfTransaction.Sales.ToString()), NHibernate.Expression.Expression.Eq(VTotalTransactionDetail.ColumnNames.TransactionStatus, ListOfTransaction.SalesVIP.ToString()));
                    bs.DataSource = DataMaster.GetList(typeof(VTotalTransactionDetail), expArray, null);

                    //bs.DataSource = DataMaster.GetListBetweenEqLikeValue(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionDate, from, to, VTotalTransactionDetail.ColumnNames.TransactionStatus, transStatus, VTotalTransactionDetail.ColumnNames.ItemId, ItemOrPIC_Temp);
                    break;
                case ReportBy.PIC:
                     expArray = new NHibernate.Expression.ICriterion[3];
                    expArray[0] = NHibernate.Expression.Expression.InsensitiveLike(VTotalTransactionDetail.ColumnNames.TransactionBy, ItemOrPIC_Temp);
                    expArray[1] = NHibernate.Expression.Expression.Between(VTotalTransactionDetail.ColumnNames.TransactionDate, from, to);
                    expArray[2] = NHibernate.Expression.Expression.Or(NHibernate.Expression.Expression.Eq(VTotalTransactionDetail.ColumnNames.TransactionStatus, ListOfTransaction.Sales.ToString()), NHibernate.Expression.Expression.Eq(VTotalTransactionDetail.ColumnNames.TransactionStatus, ListOfTransaction.SalesVIP.ToString()));
                    bs.DataSource = DataMaster.GetList(typeof(VTotalTransactionDetail), expArray, null);
                    //bs.DataSource = DataMaster.GetListBetweenEqLikeValue(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionDate, from, to, VTotalTransactionDetail.ColumnNames.TransactionStatus, transStatus, VTotalTransactionDetail.ColumnNames.TransactionBy, ItemOrPIC_Temp);
                    break;
                default:
                    break;
            }
            //else
            //    bs.DataSource = DataMaster.GetListBetweenValue(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionDate, from, to);

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTotalTransactionDetail", bs));

            try
            {

                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("Report_Parameter_DateFrom", from.ToString(AppCode.DateTimeFormat));
                parameters[1] = new ReportParameter("Report_Parameter_DateTo", to.ToString(AppCode.DateTimeFormat));
                reportViewer1.LocalReport.SetParameters(parameters);
            }
            catch (Exception)
            {
            }
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            mSettingBindingSource.Clear();
            mSettingBindingSource.DataSource = DataMaster.GetListEq(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            e.DataSources.Add(new ReportDataSource("Inventori_Data_MSetting", mSettingBindingSource));

            if (lbl_TempReport.Text.Equals(ListOfReports.MItem.ToString()))
            {
                BindingSource bsstok = new BindingSource();
                bsstok.DataSource = DataMaster.GetAll(typeof(ItemGudangStok));
                e.DataSources.Add(new ReportDataSource("Inventori_Data_ItemGudangStok", bsstok));
            }
        }

        private void FillMItemDataSource()
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetAll(typeof(MItem));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MItem", bs));
        }

        private void FillVItemDetailDataSource()
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetAll(typeof(VItemDetail));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VItemDetail", bs));
        }

        private void FillMGroupDataSource()
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetAll(typeof(MGroup));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MGroup", bs));
        }

        private void FillMCustomerDataSource()
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetAll(typeof(MCustomer));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MCustomer", bs));
        }

        private void FillMSupplierDataSource()
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetAll(typeof(MSupplier));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MSupplier", bs));
        }

        private void FillMEmployeeDataSource()
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetAll(typeof(MEmployee));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MEmployee", bs));
        }

        private void FillMDeskDataSource()
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetAll(typeof(MDesk));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MDesk", bs));
        }

        //private void FillRekapTotalTransactionByItemDataSource(string transStatus)
        //{
        //    bs = new BindingSource();
        //    bs.Clear();
        //    if (!transStatus.Equals(lbl_Param1.Name))
        //        bs.DataSource = DataMaster.GetListEq(typeof(VTotalTransactionByItem), VTotalTransactionByItem.ColumnNames.TransactionStatus, transStatus);
        //    else
        //        bs.DataSource = DataMaster.GetAll(typeof(VTotalTransactionByItem));

        //    reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTotalTransactionByItem", bs));
        //}

        private void FillTransactionTotalSource(string transStatus, DateTime from, DateTime to)
        {
            bs = new BindingSource();
            bs.Clear();
            if (!transStatus.Equals(lbl_Param1.Name))
                bs.DataSource = DataMaster.GetListBetweenEqValue(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionDate, from, to, VTotalTransactionDetail.ColumnNames.TransactionStatus, transStatus);
            else
                bs.DataSource = DataMaster.GetListBetweenValue(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionDate, from, to);

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTotalTransactionDetail", bs));

            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("Report_Parameter_DateFrom", from.ToString(AppCode.DateTimeFormat));
            parameters[1] = new ReportParameter("Report_Parameter_DateTo", to.ToString(AppCode.DateTimeFormat));
            parameters[2] = new ReportParameter("Report_Parameter_Status", transStatus);
            reportViewer1.LocalReport.SetParameters(parameters);
        }

        private void FillRekapCommissionSource(DateTime from, DateTime to)
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetListBetweenValue(typeof(TRekapCommission), TRekapCommission.ColumnNames.RekapDateFrom, from, to);

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TRekapCommission", bs));

            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("Report_Parameter_DateFrom", from.ToString(AppCode.DateTimeFormat));
            parameters[1] = new ReportParameter("Report_Parameter_DateTo", to.ToString(AppCode.DateTimeFormat));
            reportViewer1.LocalReport.SetParameters(parameters);
        }

        private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            BindReport();
        }
    }
}

