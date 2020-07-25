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

namespace Inventori.Apotek.Forms
{
    public partial class FormViewReport : Inventori.Apotek.Forms.FormParentForApotek
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

        private DateTime _from;
        public DateTime DateFrom
        {
            get { return _from; }
            set { _from = value; }
        }

        private DateTime _to;
        public DateTime DateTo
        {
            get { return _to; }
            set { _to = value; }
        }

        private ListOfPiHutangStatus pihut;
        public ListOfPiHutangStatus PiHutangStatus
        {
            get { return pihut; }
            set { pihut = value; }
        }

        private bool _showDatefilter;
        public bool UseDateFilter
        {
            get { return _showDatefilter; }
            set { _showDatefilter = value; }
        }

        private bool _usePeriodFilter;
        public bool UsePeriodFilter
        {
            get { return _usePeriodFilter; }
            set { _usePeriodFilter = value; }
        }


        private void FormViewReport_Load(object sender, EventArgs e)
        {
            if (UseDateFilter)
                ShowDateFilter();

            if (UsePeriodFilter)
                ShowPeriodFilter();

            BindReport();
            this.reportViewer1.RefreshReport();
        }

        private FormPeriodFilterReport f_PeriodFilterReport;
        private void ShowPeriodFilter()
        {
            if (f_PeriodFilterReport != null)
            {
                if (!f_PeriodFilterReport.IsDisposed)
                {
                    f_PeriodFilterReport.WindowState = FormWindowState.Normal;
                    f_PeriodFilterReport.BringToFront();
                }
                else
                    f_PeriodFilterReport = new FormPeriodFilterReport();
            }
            else
                f_PeriodFilterReport = new FormPeriodFilterReport();

            f_PeriodFilterReport.ShowDialog(this);
            DataId = f_PeriodFilterReport.numericUpDown_Year.Value.ToString() + f_PeriodFilterReport.comboBox_Month.SelectedValue.ToString();

        }

        private FormDateFilterReport f_FilterReport;
        private void ShowDateFilter()
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

            if (Filter != ParameterFilter.None)
            {
                f_FilterReport.lbl_Param.Visible = true;
                f_FilterReport.combo_Param.Visible = true;

                switch (Filter)
                {
                    case ParameterFilter.Customer:
                        f_FilterReport.lbl_Param.Text = "Pilih Pelanggan : ";
                        Module.ModuleControlSettings.SetCustomerComboBoxForFilter(f_FilterReport.combo_Param);
                        break;
                    case ParameterFilter.Supplier:
                        f_FilterReport.lbl_Param.Text = "Pilih Supplier : ";
                        Module.ModuleControlSettings.SetSupplierComboBoxForFilter(f_FilterReport.combo_Param);
                        break;
                    case ParameterFilter.Item:
                        f_FilterReport.lbl_Param.Text = "Pilih Item : ";
                        Module.ModuleControlSettings.SetItemComboBoxForFilter(f_FilterReport.combo_Param);
                        break;
                    case ParameterFilter.Employee:
                        f_FilterReport.lbl_Param.Text = "Pilih Pelapor : ";
                        Module.ModuleControlSettings.SetUserComboBoxForFilter(f_FilterReport.combo_Param);
                        break;
                    case ParameterFilter.None:
                        break;
                    default:
                        break;
                }
            }

            f_FilterReport.ShowDialog(this);
            DateFrom = f_FilterReport.dt_From.Value;
            DateTo = f_FilterReport.dt_To.Value.AddDays(1);

            if (f_FilterReport.combo_Param.SelectedIndex != -1)
            {
                DataId = f_FilterReport.combo_Param.SelectedValue;
            }
        }

        public enum ParameterFilter
        {
            Customer, Supplier, Item, Employee, None
        }

        private ParameterFilter _filter;
        public ParameterFilter Filter
        {
            get { return _filter; }
            set { _filter = value; }
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
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Apotek.Forms.Reports.ReportTransactionDetail.rdlc";
                    FillVTotalTransactionDataSource(Convert.ToDecimal(DataId));
                    title = "Laporan Detail Transaksi";
                    break;
                case ListOfReports.ReportSalesFactur:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Apotek.Forms.Reports.ReportSalesFactur.rdlc";

                    if (DataId != null)
                        FillVTotalTransactionDataSource(Convert.ToDecimal(DataId));
                    title = "NOTA PENJUALAN";
                    break;
                case ListOfReports.ReportLabaRugi:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Apotek.Forms.Reports.ReportLabaRugi.rdlc";
                    FillVRekapSubAccountDataSource(ListOfAccountPosition.RugiLaba.ToString(), DataId.ToString());
                    //FillVTotalTransactionDataSource(DateFrom, DateTo);
                    title = "Laporan Laba/Rugi";

                    //ReportParameter[] parameters = new ReportParameter[1];
                    //parameters[0] = new ReportParameter("Report_Parameter_Periode","Juli 2007");
                    //reportViewer1.LocalReport.SetParameters(parameters);

                    break;
                case ListOfReports.ReportNeraca:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Apotek.Forms.Reports.ReportNeraca.rdlc";
                    FillVRekapSubAccountDataSource(DataId.ToString());

                    title = "Laporan Neraca";
                    break;
                case ListOfReports.ReportTransactionByPIC:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Apotek.Forms.Reports.ReportTransactionByPIC.rdlc";
                    FillVTotalTransactionDataSource(listOfTransaction.ToString(), DateFrom, DateTo, VTotalTransactionDetail.ColumnNames.TransactionBy, DataId.ToString());
                    title = "Laporan " + namaTransaksi;
                    break;
                case ListOfReports.ReportTransactionByItem:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Apotek.Forms.Reports.ReportTransactionByItem.rdlc";
                    FillVTotalTransactionDataSource(listOfTransaction.ToString(), DateFrom, DateTo);
                    title = "Laporan " + namaTransaksi;
                    break;
                case ListOfReports.ReportTransactionInternalByItem:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Apotek.Forms.Reports.ReportTransactionInternalByItem.rdlc";
                    FillVTotalTransactionDataSource(listOfTransaction.ToString(), DateFrom, DateTo);
                    title = "Laporan " + namaTransaksi;
                    break;
                case ListOfReports.ReportPiHutangDue:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Apotek.Forms.Reports.ReportPiHutangDue.rdlc";
                    FillTPihutang(PiHutangStatus.ToString());
                    title = "Laporan " + PiHutangStatus.ToString();
                    break;
                case ListOfReports.ReportPajak:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Apotek.Forms.Reports.ReportPajak.rdlc";
                    FillVTotalTransactionDataSource(listOfTransaction.ToString(), DateFrom, DateTo);
                    title = "Laporan Pajak";
                    break;
                case ListOfReports.ReportStokItem:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Apotek.Forms.Reports.ReportStokItem.rdlc";
                    FillVItemDetail();
                    title = "Laporan Stok Item";
                    break;
                case ListOfReports.ReportCommission:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Apotek.Forms.Reports.ReportCommission.rdlc";
                    FillTCommission(DateFrom, DateTo);
                    title = "Laporan Pembagian Tuslah";
                    break;
                case ListOfReports.ReportPiHutangDetail:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Apotek.Forms.Reports.ReportPiHutangDetail.rdlc";
                    FillTPihutang(PiHutangStatus.ToString(), DataId.ToString(), DateFrom, DateTo);
                    title = "Laporan Detail " + PiHutangStatus.ToString();
                    break;
                case ListOfReports.ReportTJournal:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Apotek.Forms.Reports.ReportTJournal.rdlc";
                    FillTJournal(DateFrom, DateTo);
                    title = "Laporan Arus Kas";
                    break;
                default:
                    break;
            }

            reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

            this.Text = title;
            this.TabText = title;

            this.reportViewer1.RefreshReport();
        }

        private void FillVRekapSubAccountDataSource(string period)
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetListEq(typeof(VRekapSubAccount),  VRekapSubAccount.ColumnNames.RekapSubAccountPeriode, period);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VRekapSubAccount", bs));
        }

        private void FillVTotalTransactionDataSource(DateTime DateFrom, DateTime DateTo)
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetListBetweenValue(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionDate, DateFrom, DateTo);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTotalTransactionDetail", bs));
        }

        private void FillTJournal(DateTime DateFrom, DateTime DateTo)
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetListBetweenEqValue(typeof(TJournal), TJournal.ColumnNames.JournalDate, DateFrom, DateTo, TJournal.ColumnNames.AccountId, "100");
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TJournal", bs));
        }

        private void FillTPihutang(string PiHutangStatus, string likeValue, DateTime DateFrom, DateTime DateTo)
        {
            if (string.IsNullOrEmpty(likeValue))
                likeValue = "%%";

            IList listPiHutang = DataMaster.GetListBetweenEqLikeValue(typeof(TPiHutang), TPiHutang.ColumnNames.PiHutangDate, DateFrom, DateTo, TPiHutang.ColumnNames.PiHutangStatus, PiHutangStatus, TPiHutang.ColumnNames.PiHutangPic, likeValue);

            bs = new BindingSource();
            bs.DataSource = listPiHutang;
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TPiHutang", bs));

            TPiHutang pihut;
            IList listTrans = new List<VTotalTransactionDetail>();

            for (int i = 0; i < listPiHutang.Count; i++)
            {
                pihut = (TPiHutang)listPiHutang[i];
                IList listTemp = DataMaster.GetListEq(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionId, pihut.TransactionId);
                for (int j = 0; j < listTemp.Count; j++)
                {
                    listTrans.Add((VTotalTransactionDetail)listTemp[j]);
                }
            }

            bs = new BindingSource();
            bs.DataSource = listTrans;
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTotalTransactionDetail", bs));
        }

        private void FillTCommission(DateTime DateFrom, DateTime DateTo)
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetListBetweenValue(typeof(TCommission), TCommission.ColumnNames.CommissionDate, DateFrom, DateTo);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TCommission", bs));
        }

        private void FillVRekapSubAccountDataSource(string accountPosition, string period)
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetListEq(typeof(VRekapSubAccount), VRekapSubAccount.ColumnNames.AccountPosition, accountPosition, VRekapSubAccount.ColumnNames.RekapSubAccountPeriode, period);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VRekapSubAccount", bs));
        }

        private void FillVItemDetail()
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetAll(typeof(VItemDetail));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VItemDetail", bs));
        }

        private void FillVTotalTransactionDataSource(string TransactionStatus, DateTime DateFrom, DateTime DateTo)
        {
            FillVTotalTransactionDataSource(TransactionStatus, DateFrom, DateTo, VTotalTransactionDetail.ColumnNames.TransactionBy, string.Empty);
        }

        private void FillVTotalTransactionDataSource(string TransactionStatus, DateTime DateFrom, DateTime DateTo,string likeProperty,string likeValue)
        {
            if (string.IsNullOrEmpty(likeValue))
                likeValue = "%%";

            bs = new BindingSource();
            bs.DataSource = DataMaster.GetListBetweenEqLikeValue(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionDate, DateFrom, DateTo, VTotalTransactionDetail.ColumnNames.TransactionStatus, TransactionStatus, likeProperty, likeValue);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTotalTransactionDetail", bs));
        }

        private void FillTPihutang(string piHutangStatus)
        {

            bs = new BindingSource();
            bs.DataSource = DataMaster.GetListEqNotEqLessThan(typeof(TPiHutang), TPiHutang.ColumnNames.PiHutangStatus, piHutangStatus, TPiHutang.ColumnNames.PiHutangSisa, decimal.Zero, TPiHutang.ColumnNames.PiHutangJatuhTempo, DateTime.Today);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TPiHutang", bs));
        }

        private void FillVTotalTransactionDataSource(string TransactionStatus)
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetListEq(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionStatus, TransactionStatus);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTotalTransactionDetail", bs));
        }

        private void FillRekapSubAccDataSource(string period)
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetListEq(typeof(TRekapSubAccount), TRekapSubAccount.ColumnNames.RekapSubAccountPeriode, period);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TRekapSubAccount", bs));
        }

        private void FillVTotalTransactionDataSource(decimal TransactionId)
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetListEq(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionId, TransactionId);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTotalTransactionDetail", bs));
        }

        private void FillAccountDataSource()
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetAll(typeof(MAccount));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MAccount", bs));
        }

        private void FillSubAccountDataSource()
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetAll(typeof(MSubAccount));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_MSubAccount", bs));
        }

        private void FillTTransactionDetailDataSource(decimal transactionId)
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, transactionId);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TTransactionDetail", bs));
        }

        private void FillTTransactionDataSource(decimal transactionId)
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetListEq(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, transactionId);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TTransaction", bs));
        }

        private void FillTTransactionDataSource(ListOfTransaction trans)
        {
            bs = new BindingSource();
            bs.DataSource = DataMaster.GetListEq(typeof(TTransaction), TTransaction.ColumnNames.TransactionStatus, trans.ToString());
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TTransaction", bs));
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            mSettingBindingSource.Clear();
            mSettingBindingSource.DataSource = DataMaster.GetListEq(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            e.DataSources.Add(new ReportDataSource("Inventori_Data_MSetting", mSettingBindingSource));

            //if (listOfReports == ListOfReports.ReportNeraca || listOfReports == ListOfReports.ReportLabaRugi)
            //{
            //    bs = new BindingSource();
            //    bs.DataSource = DataMaster.GetListEq(typeof(TRekapSubAccount), TRekapSubAccount.ColumnNames.RekapSubAccountPeriode, DataId.ToString());
            //    e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TRekapSubAccount", bs));
            //}
        }

        private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            BindReport();
        }
    }
}