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

namespace Inventori.Forms
{
    public partial class FormViewReport : FormParent
    {
        public FormViewReport()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.report1;
        }
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();

        private void FormViewReport_Load(object sender, EventArgs e)
        {
            BindReport();
        }

        private void BindReport()
        {
            string title = "";
            reportViewer1.Reset();


            if (lbl_TempReport.Text.Equals(ListOfMasterReports.MItem.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Forms.Reports.ReportMItem.rdlc";
                FillMGroupDataSource();
                FillMItemDataSource();
                title = "Daftar Item";
            }
            else if (lbl_TempReport.Text.Equals(ListOfMasterReports.MGroup.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Forms.Reports.ReportSubItem.rdlc";
                FillMGroupDataSource();
                title = "Daftar Golongan Item";
            }
            else if (lbl_TempReport.Text.Equals(ListOfMasterReports.MCustomer.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Forms.Reports.ReportMCustomer.rdlc";
                FillMCustomerDataSource();
                title = "Daftar Pelanggan";
            }
            else if (lbl_TempReport.Text.Equals(ListOfMasterReports.MSupplier.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Forms.Reports.ReportMSupplier.rdlc";
                FillMSupplierDataSource();
                title = "Daftar Supplier";
            }
            else if (lbl_TempReport.Text.Equals(ListOfMasterReports.MEmployee.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Forms.Reports.ReportMEmployee.rdlc";
                FillMEmployeeDataSource();
                title = "Daftar Karyawan";
            }
            else if (lbl_TempReport.Text.Equals(ListOfMasterReports.MDesk.ToString()))
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Forms.Reports.ReportMDesk.rdlc";
                FillMDeskDataSource();
                title = "Daftar Meja";
            }


            //FillMSettingDataSource();

            //reportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

            this.reportViewer1.RefreshReport();

            this.Text = title;
            this.TabText = title;
        }

        //private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        //{
        //    e.DataSources.Add(new ReportDataSource("Inventori_Data_MSetting", mSettingBindingSource));
        //}

        //private void FillMSettingDataSource()
        //{
        //    mSettingBindingSource.Clear();
        //    mSettingBindingSource.DataSource = DataMaster.GetListEq(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
        //    //reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("INV_BIL_Data_MSetting", MSettingBindingSource));
        //}

        private void FillMItemDataSource()
        {
            BindingSource MItemBindingSource = new BindingSource();
            MItemBindingSource.Clear();
            MItemBindingSource.DataSource = DataMaster.GetAll(typeof(MItem));

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MItem", MItemBindingSource));
        }

        private void FillMGroupDataSource()
        {
            BindingSource MGroupBindingSource = new BindingSource();
            MGroupBindingSource.Clear();
            MGroupBindingSource.DataSource = DataMaster.GetAll(typeof(MGroup));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MGroup", MGroupBindingSource));
        }

        private void FillMCustomerDataSource()
        {
            BindingSource MCustomerBindingSource = new BindingSource();
            MCustomerBindingSource.Clear();
            MCustomerBindingSource.DataSource = DataMaster.GetAll(typeof(MCustomer));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MCustomer", MCustomerBindingSource));
        }

        private void FillMSupplierDataSource()
        {
            BindingSource MSupplierBindingSource = new BindingSource();
            MSupplierBindingSource.Clear();
            MSupplierBindingSource.DataSource = DataMaster.GetAll(typeof(MSupplier));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MSupplier", MSupplierBindingSource));
        }

        private void FillMEmployeeDataSource()
        {
            BindingSource MEmployeeBindingSource = new BindingSource();
            MEmployeeBindingSource.Clear();
            MEmployeeBindingSource.DataSource = DataMaster.GetAll(typeof(MEmployee));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MEmployee", MEmployeeBindingSource));
        }

        private void FillMDeskDataSource()
        {
            BindingSource MDeskBindingSource = new BindingSource();
            MDeskBindingSource.Clear();
            MDeskBindingSource.DataSource = DataMaster.GetAll(typeof(MDesk));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MDesk", MDeskBindingSource));
        }

        private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            BindReport();
        }
    }
}

