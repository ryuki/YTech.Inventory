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
using Inventori.Forms;
using Microsoft.Reporting.WinForms;

namespace Inventori.Cafe.Forms
{
    public partial class FormViewReport : Inventori.Cafe.Forms.FormParentForCafe
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
            if (lbl_TempReport.Text.Equals(ListOfReports.ReportTransactionTotal.ToString()) && !lbl_Param1.Text.Equals(lbl_Param1.Name))
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

            // 
            Inventori.Module.ModuleControlSettings.SaveLog(ListOfAction.Open, lbl_TempReport.Text, ListOfTable.Report, lbl_UserName.Text);
            BindReport();           

            reportViewer1_ReportRefresh(null, null);
        }

        private void BindReport()
        {
            string title = "Laporan";
            reportViewer1.Reset();


            if (lbl_TempReport.Text.Equals(ListOfReports.MItem.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Cafe.Forms.Reports.ReportMItem.rdlc";
                FillVItemDetailDataSource();
                title = "Daftar Item";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.MGroup.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Cafe.Forms.Reports.ReportSubItem.rdlc";
                FillMGroupDataSource();
                title = "Daftar Golongan Item";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.MCustomer.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Cafe.Forms.Reports.ReportMCustomer.rdlc";
                FillMCustomerDataSource();
                title = "Daftar Pelanggan";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.MSupplier.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Cafe.Forms.Reports.ReportMSupplier.rdlc";
                FillMSupplierDataSource();
                title = "Daftar Supplier";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.MEmployee.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Cafe.Forms.Reports.ReportMEmployee.rdlc";
                FillMEmployeeDataSource();
                title = "Daftar Karyawan";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.MDesk.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Cafe.Forms.Reports.ReportMDesk.rdlc";
                FillMDeskDataSource();
                title = "Daftar Meja";
            }
            else if (lbl_TempReport.Text.Equals(ListOfReports.ReportTransactionTotal.ToString()))
            {
                DateTime from = Convert.ToDateTime(lbl_Param2.Text);
                DateTime to = Convert.ToDateTime(lbl_Param3.Text);
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Cafe.Forms.Reports.ReportTransactionTotal.rdlc";
                FillTransactionTotalSource(lbl_Param1.Text, from, to);
                title = "Laporan Transaksi";
            }

            reportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

            this.reportViewer1.RefreshReport();

            this.Text = title;
            this.TabText = title;

        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            mSettingBindingSource.Clear();
            mSettingBindingSource.DataSource = DataMaster.GetListEq(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            e.DataSources.Add(new ReportDataSource("Inventori_Data_MSetting", mSettingBindingSource));
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
            parameters[0] = new ReportParameter("Report_Parameter_DateFrom", from.ToString("f"));
            parameters[1] = new ReportParameter("Report_Parameter_DateTo", to.ToString("f"));
            parameters[2] = new ReportParameter("Report_Parameter_Status", transStatus);
            reportViewer1.LocalReport.SetParameters(parameters);

            bs = new BindingSource();
            bs.Clear();
            if (transStatus.Equals(lbl_Param1.Name) || transStatus.Equals(ListOfTransaction.Sales.ToString()) || transStatus.Equals(ListOfTransaction.SalesVIP.ToString()))
            {
                bs.DataSource = DataMaster.GetListBetweenEqValue(typeof(TTransaction), TTransaction.ColumnNames.TransactionDate, from, to, TTransaction.ColumnNames.TransactionStatus, ListOfTransaction.Sales.ToString());
            }
            else
            {
                bs.DataSource = DataMaster.GetListBetweenEqValue(typeof(TTransaction), TTransaction.ColumnNames.TransactionDate, from, to, TTransaction.ColumnNames.TransactionStatus, transStatus);
            }

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TTransaction", bs));
        }


        private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            BindReport();
        }

        private void reportViewer1_Print(object sender, CancelEventArgs e)
        {
            Inventori.Module.ModuleControlSettings.SaveLog(ListOfAction.Print, lbl_TempReport.Text, ListOfTable.Report, lbl_UserName.Text);
        }

        private void reportViewer1_ReportExport(object sender, ReportExportEventArgs e)
        {
            Inventori.Module.ModuleControlSettings.SaveLog(ListOfAction.Export, lbl_TempReport.Text, ListOfTable.Report, lbl_UserName.Text);
        }
    }
}

