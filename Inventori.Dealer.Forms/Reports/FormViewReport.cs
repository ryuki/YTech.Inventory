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

using NHibernate;

namespace Inventori.Dealer.Forms
{
    public partial class FormViewReport : FormParentForDealer
    {

        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private BindingSource bs;

        public FormViewReport()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.report_ico;
        }

        private ListOfReports _listOfReports;
        public ListOfReports listOfReports
        {
            get { return _listOfReports; }
            set { _listOfReports = value; }
        }

        private ListOfTransaction _listOfTransaction;
        public ListOfTransaction listOfTransaction
        {
            get { return _listOfTransaction; }
            set { _listOfTransaction = value; }
        }


        private object _dataId;
        public object DataId
        {
            get { return _dataId; }
            set { _dataId = value; }
        }

        #region panel filter

        public bool ShowGudangIdPanel
        {
            get { return GudangIdPanel.Visible; }
            set { GudangIdPanel.Visible = value; }
        }

        public bool ShowLocationIdPanel
        {
            get { return LocationIdPanel.Visible; }
            set { LocationIdPanel.Visible = value; }
        }

        public bool ShowTransactionByPanel
        {
            get { return TransactionByPanel.Visible; }
            set { TransactionByPanel.Visible = value; }
        }

        public bool ShowTransactionDatePanel
        {
            get { return TransactionDatePanel.Visible; }
            set { TransactionDatePanel.Visible = value; }
        }

        public bool ShowTransactionDateToPanel
        {
            get { return TransactionDateToPanel.Visible; }
            set { TransactionDateToPanel.Visible = value; }
        }

        public bool ShowItemIdPanel
        {
            get { return ItemIdPanel.Visible; }
            set { ItemIdPanel.Visible = value; }
        }

        public bool ShowColourPanel
        {
            get { return ColourPanel.Visible; }
            set { ColourPanel.Visible = value; }
        }

        public bool ShowNoRangkaPanel
        {
            get { return NoRangkaPanel.Visible; }
            set { NoRangkaPanel.Visible = value; }
        }

        public bool ShowNoMesinPanel
        {
            get { return NoMesinPanel.Visible; }
            set { NoMesinPanel.Visible = value; }
        }

        public bool ShowStatusStockPanel
        {
            get { return StatusStockPanel.Visible; }
            set { StatusStockPanel.Visible = value; }
        }

        public bool ShowFilterByDatePanel
        {
            get { return FilterByDatePanel.Visible; }
            set { FilterByDatePanel.Visible = value; }
        }

        public bool ShowSearchPanel
        {
            get { return !ReportSplitContainer.Panel1Collapsed; }
            set { ReportSplitContainer.Panel1Collapsed = !value; }
        }


        #endregion

        private void FormViewReport_Load(object sender, EventArgs e)
        {
            SearchButton.Click += new EventHandler(SearchButton_Click);
            ResetButton.Click += new EventHandler(ResetButton_Click);
            reportViewer1.ReportRefresh += new CancelEventHandler(reportViewer1_ReportRefresh);
            FilterByDateCheckBox.CheckedChanged += new EventHandler(FilterByDateCheckBox_CheckedChanged);
            gudangIdComboBox.SelectedIndexChanged += new EventHandler(gudangIdComboBox_SelectedIndexChanged);
            FillFilter();
            BindReport();
            this.reportViewer1.RefreshReport();
        }

        void gudangIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //gudang combobox
                if (gudangIdComboBox.SelectedValue != null)
                    //if (int.Parse(gudangIdComboBox.SelectedValue.ToString()) != 0)
                    locationIdComboBox.Enabled = (Convert.ToInt32(gudangIdComboBox.SelectedValue) == 4);
            }
            catch (Exception)
            {

                //throw;
            }
        }

        void FilterByDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            transactionDateDateTimePicker.Enabled = transactionDateToDateTimePicker.Enabled = FilterByDateCheckBox.Checked;
        }

        void ResetButton_Click(object sender, EventArgs e)
        {
            locationIdComboBox.SelectedIndex = 0;
            gudangIdComboBox.SelectedIndex = 0;
            transactionByComboBox.SelectedIndex = 0;
            transactionDateDateTimePicker.Value = DateTime.Today.AddDays(-30);
            transactionDateToDateTimePicker.Value = DateTime.Today;
            itemIdComboBox.SelectedIndex = 0;
            stockDesc1ComboBox.SelectedIndex = 0;
            stockDesc2TextBox.ResetText();
            stockDesc3TextBox.ResetText();
            StatusStockComboBox.SelectedIndex = 0;

            BindReport();
        }

        void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            BindReport();
        }

        void SearchButton_Click(object sender, EventArgs e)
        {
            BindReport();
        }

        private void FillFilter()
        {
            //date
            transactionDateDateTimePicker.Value = DateTime.Today.AddDays(-30);
            Module.ModuleControlSettings.SetDateTimePicker(transactionDateDateTimePicker, false);
            transactionDateToDateTimePicker.Value = DateTime.Today;
            Module.ModuleControlSettings.SetDateTimePicker(transactionDateToDateTimePicker, false);

            //lokasi
            AppCode.FillGudangComboBox(gudangIdComboBox);
            //channel
            AppCode.FillChannelComboBox(locationIdComboBox);
            //fill color
            AppCode.FillColorComboBox(stockDesc1ComboBox);
            //fill type unit
            AppCode.FillItemComboBox(itemIdComboBox);

            //status stok
            StatusStockComboBox.SelectedIndex = 0;

            //gudang 
            gudangIdComboBox.SelectedIndex = 0;
            //location
            locationIdComboBox.SelectedIndex = 0;

            //set transaction by
            switch (listOfTransaction)
            {
                case ListOfTransaction.Correction:
                    //pelanggan
                    AppCode.FillCustomerComboBox(transactionByComboBox);
                    break;
                case ListOfTransaction.Mutation:
                    //pelanggan
                    AppCode.FillCustomerComboBox(transactionByComboBox);
                    break;
                case ListOfTransaction.Purchase:
                    //supplier
                    AppCode.FillSupplierComboBox(transactionByComboBox);
                    break;
                case ListOfTransaction.PurchaseOrder:
                    break;
                case ListOfTransaction.ReturPurchase:
                    break;
                case ListOfTransaction.ReturSales:
                    break;
                case ListOfTransaction.ReturSalesVIP:
                    break;
                case ListOfTransaction.Sales:
                    //pelanggan
                    AppCode.FillCustomerComboBox(transactionByComboBox);
                    break;
                case ListOfTransaction.SalesVIP:
                    break;
                case ListOfTransaction.Service:
                    break;
                case ListOfTransaction.Temp:
                    break;
                case ListOfTransaction.Usage:
                    break;
                default:
                    break;
            }
        }

        private void BindReport()
        {
            string title = "Laporan";
            reportViewer1.Reset();

            string namaTransaksi = string.Empty;
            switch (listOfTransaction)
            {
                case ListOfTransaction.Purchase:
                    namaTransaksi = "Pembelian ";
                    break;
                case ListOfTransaction.Sales:
                    namaTransaksi = "Penjualan ";
                    break;
                case ListOfTransaction.ReturSales:
                    namaTransaksi = "Retur Penjualan ";
                    break;
                case ListOfTransaction.ReturPurchase:
                    namaTransaksi = "Retur Pembelian ";
                    break;
                case ListOfTransaction.Correction:
                    namaTransaksi = "Koreksi Stok ";
                    break;
                case ListOfTransaction.Mutation:
                    namaTransaksi = "Mutasi Stok ";
                    break;
                default:
                    break;
            }

            switch (listOfReports)
            {
                case ListOfReports.ReportTransactionDetail:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportTransactionDetail.rdlc";

                    FillVTotalTransactionDataSource(Convert.ToDecimal(DataId));

                    //set parameter for report
                    ReportParameter[] parameters = new ReportParameter[5];
                    parameters[0] = new ReportParameter("Report_Parameter_Date_From", transactionDateDateTimePicker.Value.ToShortDateString());
                    parameters[1] = new ReportParameter("Report_Parameter_Date_To", transactionDateToDateTimePicker.Value.ToShortDateString());
                    parameters[2] = new ReportParameter("Report_Parameter_Use_Date", (!FilterByDateCheckBox.Checked).ToString());
                    parameters[3] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);
                    parameters[4] = new ReportParameter("Report_Parameter_Transaction_Name", namaTransaksi);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Laporan Detail Transaksi " + namaTransaksi;
                    break;
                case ListOfReports.ReportRecapStockByUnit:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportRecapStockByUnit.rdlc";

                    FillVStockDetailTransactionDealerDataSource();

                    //set parameter for report
                    parameters = new ReportParameter[4];
                    parameters[0] = new ReportParameter("Report_Parameter_Date_From", transactionDateDateTimePicker.Value.ToShortDateString());
                    parameters[1] = new ReportParameter("Report_Parameter_Date_To", transactionDateToDateTimePicker.Value.ToShortDateString());
                    parameters[2] = new ReportParameter("Report_Parameter_Use_Date", (!FilterByDateCheckBox.Checked).ToString());
                    parameters[3] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Laporan Rekap Stok Per Unit";
                    break;
                case ListOfReports.ReportRecapStockByLocation:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportRecapStockByLocation.rdlc";

                    FillVStockDetailTransactionDealerDataSource();

                    //set parameter for report
                    parameters = new ReportParameter[4];
                    parameters[0] = new ReportParameter("Report_Parameter_Date_From", transactionDateDateTimePicker.Value.ToShortDateString());
                    parameters[1] = new ReportParameter("Report_Parameter_Date_To", transactionDateToDateTimePicker.Value.ToShortDateString());
                    parameters[2] = new ReportParameter("Report_Parameter_Use_Date", (!FilterByDateCheckBox.Checked).ToString());
                    parameters[3] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Laporan Rekap Stok Per Lokasi";
                    break;
                case ListOfReports.ReportMasterCustomer:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportMasterCustomer.rdlc";

                    FillMasterCustomerDataSource();

                    //set parameter for report
                    parameters = new ReportParameter[1];
                    parameters[0] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Daftar Pelanggan";
                    break;
                case ListOfReports.ReportMasterChannel:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportMasterChannel.rdlc";

                    FillMasterChannelDataSource();

                    //set parameter for report
                    parameters = new ReportParameter[1];
                    parameters[0] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Daftar Channel";
                    break;
                case ListOfReports.ReportMasterEmployee:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportMasterEmployee.rdlc";

                    FillMasterEmployeeDataSource();

                    //set parameter for report
                    parameters = new ReportParameter[1];
                    parameters[0] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Daftar Salesman";
                    break;
                case ListOfReports.ReportMasterFinance:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportMasterFinance.rdlc";

                    FillMasterFinanceDataSource();

                    //set parameter for report
                    parameters = new ReportParameter[1];
                    parameters[0] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Daftar Finance";
                    break;
                case ListOfReports.ReportMasterSupplier:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportMasterSupplier.rdlc";

                    FillMasterSupplierDataSource();

                    //set parameter for report
                    parameters = new ReportParameter[1];
                    parameters[0] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Daftar Supplier";
                    break;

                case ListOfReports.ReportTransactionDetailByFinance:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportTransactionDetailByFinance.rdlc";

                    FillVTotalTransactionDataSource(Convert.ToDecimal(DataId));

                    //set parameter for report
                    parameters = new ReportParameter[5];
                    parameters[0] = new ReportParameter("Report_Parameter_Date_From", transactionDateDateTimePicker.Value.ToShortDateString());
                    parameters[1] = new ReportParameter("Report_Parameter_Date_To", transactionDateToDateTimePicker.Value.ToShortDateString());
                    parameters[2] = new ReportParameter("Report_Parameter_Use_Date", (!FilterByDateCheckBox.Checked).ToString());
                    parameters[3] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);
                    parameters[4] = new ReportParameter("Report_Parameter_Transaction_Name", namaTransaksi);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Laporan Piutang Finance";
                    break;
                case ListOfReports.ReportTransactionRecap:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportTransactionRecap.rdlc";

                    FillVTotalTransactionDataSource(Convert.ToDecimal(DataId));

                    //set parameter for report
                    parameters = new ReportParameter[5];
                    parameters[0] = new ReportParameter("Report_Parameter_Date_From", transactionDateDateTimePicker.Value.ToShortDateString());
                    parameters[1] = new ReportParameter("Report_Parameter_Date_To", transactionDateToDateTimePicker.Value.ToShortDateString());
                    parameters[2] = new ReportParameter("Report_Parameter_Use_Date", (!FilterByDateCheckBox.Checked).ToString());
                    parameters[3] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);
                    parameters[4] = new ReportParameter("Report_Parameter_Transaction_Name", namaTransaksi);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Laporan " + namaTransaksi;
                    break;

                case ListOfReports.ReportRecapSisaStock:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportRecapSisaStock.rdlc";

                    //status stok blm terjual
                    StatusStockComboBox.SelectedIndex = 2;

                    FillVSisaStockDataSource();
                    FillVStockDetailTransactionDealerDataSource();

                    //set parameter for report
                    parameters = new ReportParameter[4];
                    parameters[0] = new ReportParameter("Report_Parameter_Date_From", transactionDateDateTimePicker.Value.ToShortDateString());
                    parameters[1] = new ReportParameter("Report_Parameter_Date_To", transactionDateToDateTimePicker.Value.ToShortDateString());
                    parameters[2] = new ReportParameter("Report_Parameter_Use_Date", (!FilterByDateCheckBox.Checked).ToString());
                    parameters[3] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Laporan Rekap Sisa Stok";
                    break;
                case ListOfReports.ReportTransactionRecapByFinance:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportTransactionRecapByFinance.rdlc";

                    FillVTotalTransactionDataSource(Convert.ToDecimal(DataId));

                    //set parameter for report
                    parameters = new ReportParameter[5];
                    parameters[0] = new ReportParameter("Report_Parameter_Date_From", transactionDateDateTimePicker.Value.ToShortDateString());
                    parameters[1] = new ReportParameter("Report_Parameter_Date_To", transactionDateToDateTimePicker.Value.ToShortDateString());
                    parameters[2] = new ReportParameter("Report_Parameter_Use_Date", (!FilterByDateCheckBox.Checked).ToString());
                    parameters[3] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);
                    parameters[4] = new ReportParameter("Report_Parameter_Transaction_Name", namaTransaksi);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Laporan Rekap Piutang Finance";
                    break;
                case ListOfReports.ReportPurchaseRecap:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportPurchaseRecap.rdlc";

                    FillVTotalTransactionDataSource(Convert.ToDecimal(DataId));

                    //set parameter for report
                    parameters = new ReportParameter[5];
                    parameters[0] = new ReportParameter("Report_Parameter_Date_From", transactionDateDateTimePicker.Value.ToShortDateString());
                    parameters[1] = new ReportParameter("Report_Parameter_Date_To", transactionDateToDateTimePicker.Value.ToShortDateString());
                    parameters[2] = new ReportParameter("Report_Parameter_Use_Date", (!FilterByDateCheckBox.Checked).ToString());
                    parameters[3] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);
                    parameters[4] = new ReportParameter("Report_Parameter_Transaction_Name", namaTransaksi);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Laporan " + namaTransaksi;
                    break;
                case ListOfReports.ReportPurchaseRecapByItem:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportPurchaseRecapByItem.rdlc";

                    FillVTotalTransactionDataSource(Convert.ToDecimal(DataId));

                    //set parameter for report
                    parameters = new ReportParameter[5];
                    parameters[0] = new ReportParameter("Report_Parameter_Date_From", transactionDateDateTimePicker.Value.ToShortDateString());
                    parameters[1] = new ReportParameter("Report_Parameter_Date_To", transactionDateToDateTimePicker.Value.ToShortDateString());
                    parameters[2] = new ReportParameter("Report_Parameter_Use_Date", (!FilterByDateCheckBox.Checked).ToString());
                    parameters[3] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);
                    parameters[4] = new ReportParameter("Report_Parameter_Transaction_Name", namaTransaksi);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Laporan " + namaTransaksi + " Per Type Unit";
                    break;
                case ListOfReports.ReportTransactionRecapBySalesman:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportTransactionRecapBySalesman.rdlc";

                    FillVTotalTransactionDataSource(Convert.ToDecimal(DataId));

                    //set parameter for report
                    parameters = new ReportParameter[5];
                    parameters[0] = new ReportParameter("Report_Parameter_Date_From", transactionDateDateTimePicker.Value.ToShortDateString());
                    parameters[1] = new ReportParameter("Report_Parameter_Date_To", transactionDateToDateTimePicker.Value.ToShortDateString());
                    parameters[2] = new ReportParameter("Report_Parameter_Use_Date", (!FilterByDateCheckBox.Checked).ToString());
                    parameters[3] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);
                    parameters[4] = new ReportParameter("Report_Parameter_Transaction_Name", namaTransaksi);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Laporan Rekap Penjualan Per Salesman";
                    break;
                case ListOfReports.ReportTransactionRecapByChannel:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Dealer.Forms.Reports.ReportTransactionRecapByChannel.rdlc";

                    FillVTotalTransactionDataSource(Convert.ToDecimal(DataId));

                    //set parameter for report
                    parameters = new ReportParameter[5];
                    parameters[0] = new ReportParameter("Report_Parameter_Date_From", transactionDateDateTimePicker.Value.ToShortDateString());
                    parameters[1] = new ReportParameter("Report_Parameter_Date_To", transactionDateToDateTimePicker.Value.ToShortDateString());
                    parameters[2] = new ReportParameter("Report_Parameter_Use_Date", (!FilterByDateCheckBox.Checked).ToString());
                    parameters[3] = new ReportParameter("Report_Parameter_Print_By", lbl_UserName.Text);
                    parameters[4] = new ReportParameter("Report_Parameter_Transaction_Name", namaTransaksi);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    title = "Laporan Rekap Penjualan Per Channel";
                    break;
                default:
                    break;
            }



            reportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

            this.Text = title;
            this.TabText = title;

            this.reportViewer1.RefreshReport();
        }

        private void FillVSisaStockDataSource()
        {
            IList listItem = DataMaster.GetAll(typeof(MItem));
            IList listVS = new List<VTStockDetail>();
            MItem item;
            VTStockDetail vs;
            for (int i = 0; i < listItem.Count; i++)
            {
                item = listItem[i] as MItem;
                vs = new VTStockDetail();
                vs.ItemId = item.ItemId;
                vs.ItemName = item.ItemName;
                //calculate stok akhir
                vs.GudangId = CalculateStockAkhir(item.ItemId);
                //calculate stok masuk
                vs.StockPriceIn = CalculateStock(true, item.ItemId);
                //calculate stok masuk
                vs.StockPriceOut = CalculateStock(false, item.ItemId);

                listVS.Add(vs);

            }

            bs = new BindingSource();
            bs.DataSource = listVS;
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTStockDetail", bs));
        }

        private int CalculateStockAkhir(string ItemId)
        {
            NHibernate.Expression.ICriterion[] expArrays = new NHibernate.Expression.ICriterion[3];
            expArrays[0] = NHibernate.Expression.Expression.Eq(VTStockDetail.ColumnNames.ItemId, ItemId);
            expArrays[1] = NHibernate.Expression.Expression.Lt(VTStockDetail.ColumnNames.StockDateIn, transactionDateDateTimePicker.Value);
            expArrays[2] = NHibernate.Expression.Expression.Not(NHibernate.Expression.Expression.Eq(VTStockDetail.ColumnNames.StockDateIn, System.Data.SqlTypes.SqlDateTime.MinValue.Value));
            int stokMasuk = DataMaster.GetList(typeof(VTStockDetail), expArrays, null).Count;

            expArrays = new NHibernate.Expression.ICriterion[3];
            expArrays[0] = NHibernate.Expression.Expression.Eq(VTStockDetail.ColumnNames.ItemId, ItemId);
            expArrays[1] = NHibernate.Expression.Expression.Lt(VTStockDetail.ColumnNames.StockDateOut, transactionDateDateTimePicker.Value);
            expArrays[2] = NHibernate.Expression.Expression.Not(NHibernate.Expression.Expression.Eq(VTStockDetail.ColumnNames.StockDateOut, System.Data.SqlTypes.SqlDateTime.MinValue.Value));
            int stokKeluar = DataMaster.GetList(typeof(VTStockDetail), expArrays, null).Count;

            return stokMasuk - stokKeluar;
        }

        private decimal CalculateStock(bool isIn, string ItemId)
        {
            NHibernate.Expression.ICriterion[] expArrays = new NHibernate.Expression.ICriterion[3];
            expArrays[0] = NHibernate.Expression.Expression.Eq(VTStockDetail.ColumnNames.ItemId, ItemId);
            if (isIn)
            {
                expArrays[1] = NHibernate.Expression.Expression.Between(VTStockDetail.ColumnNames.StockDateIn, transactionDateDateTimePicker.Value, transactionDateToDateTimePicker.Value.AddDays(1));
                expArrays[2] = NHibernate.Expression.Expression.Not(NHibernate.Expression.Expression.Eq(VTStockDetail.ColumnNames.StockDateIn, System.Data.SqlTypes.SqlDateTime.MinValue.Value));
            }
            else
            {
                expArrays[1] = NHibernate.Expression.Expression.Between(VTStockDetail.ColumnNames.StockDateOut, transactionDateDateTimePicker.Value, transactionDateToDateTimePicker.Value.AddDays(1));
                expArrays[2] = NHibernate.Expression.Expression.Not(NHibernate.Expression.Expression.Eq(VTStockDetail.ColumnNames.StockDateOut, System.Data.SqlTypes.SqlDateTime.MinValue.Value));
            }


            return DataMaster.GetList(typeof(VTStockDetail), expArrays, null).Count;
        }

        private void FillMasterSupplierDataSource()
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetList(typeof(MSupplier), null, null);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MSupplier", bs));
        }

        private void FillMasterFinanceDataSource()
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetList(typeof(MFinance), null, null);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MFinance", bs));
        }

        private void FillMasterEmployeeDataSource()
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetList(typeof(MEmployee), null, null);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MEmployee", bs));
        }

        private void FillMasterChannelDataSource()
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetList(typeof(MChannel), null, null);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MChannel", bs));
        }

        private void FillMasterCustomerDataSource()
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetList(typeof(MCustomer), null, null);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MCustomer", bs));
        }

        private void FillVStockDetailDataSource()
        {
            NHibernate.Expression.ICriterion[] expArrays = new NHibernate.Expression.ICriterion[2];
            if (itemIdComboBox.SelectedIndex != 0)
            {
                expArrays[0] = NHibernate.Expression.Expression.Eq(VTStockDetail.ColumnNames.ItemId, itemIdComboBox.SelectedValue);
            }
            if (FilterByDateCheckBox.Checked)
            {
                expArrays[1] = NHibernate.Expression.Expression.Between(VTStockDetail.ColumnNames.StockDateIn, transactionDateDateTimePicker.Value, transactionDateToDateTimePicker.Value.AddDays(1));
            }

            bs = new BindingSource();
            bs.DataSource = DataMaster.GetList(typeof(VTStockDetail), expArrays, null);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTStockDetail", bs));
        }

        private void FillVStockDetailTransactionDealerDataSource()
        {
            NHibernate.Expression.ICriterion[] expArrays = new NHibernate.Expression.ICriterion[10];
            if (itemIdComboBox.SelectedIndex != 0)
            {
                expArrays[0] = NHibernate.Expression.Expression.Eq(VTStockDetail.ColumnNames.ItemId, itemIdComboBox.SelectedValue);
            }

            if (stockDesc1ComboBox.SelectedIndex != 0)
            {
                expArrays[1] = NHibernate.Expression.Expression.Eq(VTStockDetail.ColumnNames.StockDesc1, stockDesc1ComboBox.SelectedValue);
            }

            if (!string.IsNullOrEmpty(stockDesc2TextBox.Text.Trim()))
            {
                expArrays[2] = NHibernate.Expression.Expression.Like(VTStockDetail.ColumnNames.StockDesc2, stockDesc2TextBox.Text, NHibernate.Expression.MatchMode.Anywhere);
            }

            if (!string.IsNullOrEmpty(stockDesc3TextBox.Text.Trim()))
            {
                expArrays[3] = NHibernate.Expression.Expression.Like(VTStockDetail.ColumnNames.StockDesc3, stockDesc3TextBox.Text, NHibernate.Expression.MatchMode.Anywhere);
            }

            if (listOfReports != ListOfReports.ReportRecapSisaStock)
            {
                if (FilterByDateCheckBox.Checked)
                {
                    expArrays[4] = NHibernate.Expression.Expression.Between(VTStockDetail.ColumnNames.StockDateIn, transactionDateDateTimePicker.Value, transactionDateToDateTimePicker.Value.AddDays(1));
                }

                //jika status stok terjual
                if (StatusStockComboBox.SelectedIndex == 1)
                {
                    expArrays[5] = NHibernate.Expression.Expression.Not(NHibernate.Expression.Expression.Eq(VTStockDetail.ColumnNames.StockDateOut, System.Data.SqlTypes.SqlDateTime.MinValue.Value));
                }
                //jika status stok belum terjual
                else if (StatusStockComboBox.SelectedIndex == 2)
                {
                    expArrays[5] = NHibernate.Expression.Expression.Eq(VTStockDetail.ColumnNames.StockDateOut, System.Data.SqlTypes.SqlDateTime.MinValue.Value);
                }
            }

            //jika gudang visible
            if (ShowGudangIdPanel)
            {
                if (gudangIdComboBox.SelectedIndex != 0)
                {
                    expArrays[6] = NHibernate.Expression.Expression.Eq(VTStockDetail.ColumnNames.GudangId, Convert.ToInt32(gudangIdComboBox.SelectedValue));
                    try
                    {
                        if (Convert.ToInt32(gudangIdComboBox.SelectedValue) == 4)
                        {
                            if (locationIdComboBox.SelectedIndex != 0)
                            {
                                expArrays[7] = NHibernate.Expression.Expression.Eq(VTStockDetail.ColumnNames.LocatonId, locationIdComboBox.SelectedValue);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            if (listOfReports == ListOfReports.ReportRecapSisaStock)
            {
                expArrays[8] = NHibernate.Expression.Expression.Or(NHibernate.Expression.Expression.Eq(VTStockDetail.ColumnNames.StockDateOut, System.Data.SqlTypes.SqlDateTime.MinValue.Value), NHibernate.Expression.Expression.Gt(VTStockDetail.ColumnNames.StockDateOut, transactionDateToDateTimePicker.Value.AddDays(1)));
                //expArrays[8] = NHibernate.Expression.Expression.Lt(VTStockDetail.ColumnNames.StockDateOut, transactionDateToDateTimePicker.Value.AddDays(1));
                expArrays[9] = NHibernate.Expression.Expression.Lt(VTStockDetail.ColumnNames.StockDateIn, transactionDateToDateTimePicker.Value.AddDays(1));
            }

            IList listStok = DataMaster.GetList(typeof(VTStockDetail), expArrays, null);
            VTStockDetail s;

            IList list = new List<VStockDetailTransactionDealer>();
            VStockDetailTransactionDealer v;
            VTotalTransactionDealer det;
            for (int i = 0; i < listStok.Count; i++)
            {
                s = listStok[i] as VTStockDetail;
                v = new VStockDetailTransactionDealer();

                v.ChannelName = s.ChannelName;
                v.ColourDesc = s.ColourDesc;

                det = DataMaster.GetObjectByProperty(typeof(VTotalTransactionDealer), VTotalTransactionDealer.ColumnNames.StockId, s.StockId, VTotalTransactionDealer.ColumnNames.TransactionStatus, ListOfTransaction.Sales.ToString()) as VTotalTransactionDealer;
                if (det != null)
                {
                    v.CustomerName = det.CustomerName;
                }

                v.GudangId = s.GudangId;
                v.GudangName = s.GudangName;
                v.ItemId = s.ItemId;
                v.ItemName = s.ItemName;
                v.LocatonId = s.LocatonId;
                v.StockBarcodeId = s.StockBarcodeId;
                v.StockDateIn = s.StockDateIn;
                v.StockDateOut = s.StockDateOut;
                v.StockDesc1 = s.StockDesc1;
                v.StockDesc2 = s.StockDesc2;
                v.StockDesc3 = s.StockDesc3;
                v.StockId = s.StockId;
                v.StockInBy = s.StockInBy;
                v.StockIsAvailable = s.StockIsAvailable;
                v.StockOutBy = s.StockOutBy;
                v.StockPriceIn = s.StockPriceIn;
                v.StockPriceOut = s.StockPriceOut;
                list.Add(v);

            }

            //expArrays[8] =NHibernate.Expression.Expression NHibernate.Expression.Expression.Eq(VStockDetailTransactionDealer.ColumnNames.ItemId, itemIdComboBox.SelectedValue);

            bs = new BindingSource();
            bs.DataSource = list;
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VStockDetailTransactionDealer", bs));
        }

        private void FillVTotalTransactionDataSource(decimal p)
        {
            NHibernate.Expression.ICriterion[] expArrays = new NHibernate.Expression.ICriterion[5];
            if (gudangIdComboBox.SelectedIndex != 0)
            {
                int t = 0;
                if (int.TryParse(gudangIdComboBox.SelectedValue.ToString(), out t))
                {
                    expArrays[0] = NHibernate.Expression.Expression.Eq(VTotalTransactionDealer.ColumnNames.GudangId, int.Parse(gudangIdComboBox.SelectedValue.ToString()));
                }

            }

            if (locationIdComboBox.SelectedIndex != 0)
            {
                expArrays[1] = NHibernate.Expression.Expression.Eq(VTotalTransactionDealer.ColumnNames.LocationId, locationIdComboBox.SelectedValue);
            }

            if (transactionByComboBox.SelectedIndex != 0)
            {
                expArrays[2] = NHibernate.Expression.Expression.Eq(VTotalTransactionDealer.ColumnNames.TransactionBy, transactionByComboBox.SelectedValue);
            }

            if (FilterByDateCheckBox.Checked)
            {
                expArrays[3] = NHibernate.Expression.Expression.Between(VTotalTransactionDealer.ColumnNames.TransactionDate, transactionDateDateTimePicker.Value, transactionDateToDateTimePicker.Value.AddDays(1));
            }


            expArrays[4] = NHibernate.Expression.Expression.Eq(VTotalTransactionDealer.ColumnNames.TransactionStatus, listOfTransaction.ToString());

            NHibernate.Expression.Order[] orderArrays = new NHibernate.Expression.Order[1];
            orderArrays[0] = NHibernate.Expression.Order.Asc(VTotalTransactionDealer.ColumnNames.TransactionDate);

            bs = new BindingSource();
            bs.DataSource = DataMaster.GetList(typeof(VTotalTransactionDealer), expArrays, orderArrays);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTotalTransactionDealer", bs));
        }

        void LocalReport_SubreportProcessing(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        {
            //mSettingBindingSource.Clear();
            //mSettingBindingSource.DataSource = DataMaster.GetListEq(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            //e.DataSources.Add(new ReportDataSource("Inventori_Data_MSetting", mSettingBindingSource));
        }
    }
}