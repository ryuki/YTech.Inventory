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
using Inventori.Module;
using Microsoft.Reporting.WinForms;

using Inventori.Contractor.Data;

namespace Inventori.Contractor.Forms
{
    public partial class FormViewReport : Inventori.Contractor.Forms.FormParentForContractor
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private BindingSource bs;
        ListOfReports rep;
        public FormViewReport(ListOfReports r)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.report1;
            rep = r;
        }

        private bool _enabledDateFilter = false;
        public bool EnabledDateFilter
        {
            get { return _enabledDateFilter; }
            set { _enabledDateFilter = value; }
        }

        private string _dataId;
        public string DataId
        {
            get { return _dataId; }
            set { _dataId = value; }
        }

        private string _dataId2;
        public string DataId2
        {
            get { return _dataId2; }
            set { _dataId2 = value; }
        }

        private ListOfTransaction _trans;
        public ListOfTransaction Trans
        {
            get { return _trans; }
            set { _trans = value; }
        }

        private ParameterView param = ParameterView.None;
        public ParameterView Param
        {
            get { return param; }
            set { param = value; }
        }

        private GiroGroupBy _giroGroup;
        public GiroGroupBy GiroGroup
        {
            get { return _giroGroup; }
            set { _giroGroup = value; }
        }

        private bool _useSupplierList = false;
        public bool UseSupplierList
        {
            get { return _useSupplierList; }
            set { _useSupplierList = value; }
        }

        public enum ParameterView
        {
            Employee, Customer, Supplier, User, Currency, None
        }

        private void FormViewReport_Load(object sender, EventArgs e)
        {
            SetInitialSetting();
            //BindReport();
        }

        private void SetInitialSetting()
        {
            dt_From.Value = DateTime.Now.AddDays(-7);
            dt_To.Value = DateTime.Now;
            ModuleControlSettings.SetDateTimePicker(dt_From, true);
            ModuleControlSettings.SetDateTimePicker(dt_To, true);

            dt_From.Enabled = EnabledDateFilter;
            dt_To.Enabled = EnabledDateFilter;

            //groupBox1.Visible = UseSupplierList;
            //if (UseSupplierList)
            //{
            //    checkedListBox_Parameter.Items.Clear();
            //    IList listSupp = DataMaster.GetAll(typeof(MSupplier));
            //    MSupplier sup;
            //    for (int i = 0; i < listSupp.Count; i++)
            //    {
            //        sup = (MSupplier)listSupp[i];
            //        checkedListBox_Parameter.Items.Add(sup.SupplierId + " (" + sup.SupplierName + ")", true);
            //    }
            //}

            if (Param == ParameterView.None)
            {
                transactionByComboBox.Enabled = false;
                if (!EnabledDateFilter)
                {
                    splitContainer1.Panel1Collapsed = true;
                    BindReport();
                }
            }
            else if (Param == ParameterView.Customer)
            {
                transactionByLabel.Text = "Pilih Pelanggan : ";
                Module.ModuleControlSettings.SetCustomerComboBoxForFilter(transactionByComboBox);
            }
            else if (Param == ParameterView.Employee)
            {
                transactionByLabel.Text = "Pilih Pelapor : ";
                Module.ModuleControlSettings.SetEmployeeComboBoxForFilter(transactionByComboBox);
            }
            else if (Param == ParameterView.Supplier)
            {
                transactionByLabel.Text = "Pilih Supplier : ";
                Module.ModuleControlSettings.SetSupplierComboBoxForFilter(transactionByComboBox);
            }
            else if (Param == ParameterView.User)
            {
                transactionByLabel.Text = "Pilih Nama Pengguna : ";
                Module.ModuleControlSettings.SetUserComboBoxForFilter(transactionByComboBox);
            }
            else if (Param == ParameterView.Currency)
            {
                transactionByLabel.Text = "Pilih Mata Uang : ";
                AppCode.SetCurrencyStatusComboBox(transactionByComboBox);
                transactionByComboBox.SelectedIndex = 0;
            }

            

        }

        string title;

        public void BindReport()
        {
            if (transactionByComboBox.SelectedValue != null)
            {
                DataId = transactionByComboBox.SelectedValue.ToString();
            }

            if (Param == ParameterView.Currency)
                DataId = transactionByComboBox.SelectedItem.ToString();

            title = "Laporan";
            reportViewer1.Reset();

            switch (rep)
            {
                case ListOfReports.MItem:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportMItem.rdlc";
                    FillVItemDetailDataSource();
                    title = "Daftar Item";
                    break;
                case ListOfReports.MGroup:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportSubItem.rdlc";
                    FillMGroupDataSource();
                    title = "Daftar Golongan Item";
                    break;
                case ListOfReports.MSupplier:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportMSupplier.rdlc";
                    FillVSupplierAccountDataSource();
                    title = "Daftar Supplier";
                    break;
                case ListOfReports.MEmployee:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportMEmployee.rdlc";
                    FillMEmployeeDataSource();
                    title = "Daftar Karyawan";
                    break;
                case ListOfReports.ReportTransactionTotalByItem:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportTransactionTotalByItem.rdlc";
                    FillTransactionTotalSource(Trans.ToString(), dt_From.Value, dt_To.Value, ReportBy.Item, DataId);
                    title = "Laporan Transaksi Per Item";
                    break;
                case ListOfReports.TransactionDetail:
                    decimal transactionId = Convert.ToDecimal(DataId);
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportTransactionDetail.rdlc";
                    FillTransactionDetailSource(transactionId);
                    title = "Laporan Detail Transaksi";
                    break;
                case ListOfReports.UtangDetail:
                    string suppId = DataId;
                    string currencyid = DataId2;
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportUtangDetail.rdlc";
                    FillTransactionSource(suppId, currencyid);
                    FillGiroSource(suppId, currencyid);
                    title = "Laporan Utang";
                    break;
                case ListOfReports.ReportPODetailForPrint:
                    transactionId = Convert.ToDecimal(DataId);
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportPODetailForPrint.rdlc";
                    TTransaction tr = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, transactionId);
                    FillTransactionDetailSource(transactionId);
                    FillMSupplierDataSource(tr.TransactionBy);
                    title = "Laporan Detail PO";
                    break;
                case ListOfReports.ReportTransactionTotalByPIC:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportTransactionTotalByPIC.rdlc";
                    FillTransactionTotalSource(Trans.ToString(), dt_From.Value, dt_To.Value, ReportBy.PIC, DataId);
                    title = "Laporan Transaksi";
                    break;
                case ListOfReports.ReportGiro:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportGiro.rdlc";
                    FillGiroSource(GiroGroup.ToString(), DataId);
                    title = "Laporan Giro";
                    break;
                case ListOfReports.ReportUsageTotalByAlat:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportUsageTotalByAlat.rdlc";

                    FillTransactionTotalSource(Trans.ToString(), dt_From.Value, dt_To.Value, ReportBy.Item, DataId);
                    title = "Laporan Pemakaian Spare Parts Per Alat";
                    break;
                case ListOfReports.ReportTransactionPerMonth:
                    // splitContainer1.Panel1Collapsed = false;
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportTransactionPerMonth.rdlc";
                    if (transactionByComboBox.SelectedValue != null)
                        FillVTransactionSource(Trans.ToString(), DataId);
                    title = "Laporan Transaksi Per Bulan";
                    break;
                case ListOfReports.ReportPOTotalByItem:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportPOTotalByItem.rdlc";
                    FillTransactionTotalSource(Trans.ToString(), dt_From.Value, dt_To.Value, ReportBy.Item, DataId);
                    title = "Laporan Transaksi Per Item";
                    break;
                case ListOfReports.ReportPOTotalByPIC:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportPOTotalByPIC.rdlc";
                    FillTransactionTotalSource(Trans.ToString(), dt_From.Value, dt_To.Value, ReportBy.PIC, DataId);
                    title = "Laporan Transaksi";
                    break;
                case ListOfReports.ReportUserLog:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportUserLog.rdlc";
                    FillUserLogSource(dt_From.Value, dt_To.Value, DataId);
                    title = "Laporan Histori Pengguna";
                    break;
                case ListOfReports.ReportListTransaction:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportListTransaction.rdlc";
                    FillTransactionTotalSource(Trans.ToString(), dt_From.Value, dt_To.Value, ReportBy.PIC, DataId);
                    if (Trans == ListOfTransaction.Purchase)
                        title = "Laporan List Pembelian";
                    else if (Trans == ListOfTransaction.PurchaseOrder)
                        title = "Laporan List Order Pembelian";
                    break;
                case ListOfReports.ReportTagihan:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventori.Contractor.Forms.Reports.ReportTagihan.rdlc";
                    //FillVTransactionWithBankAccSource(Trans.ToString(), dt_From.Value, dt_To.Value, ReportBy.PIC, DataId, true);
                    FillVTransactionDetailWithBankAccSource(Trans.ToString(), dt_From.Value, dt_To.Value, ReportBy.PIC, DataId, true);
                    button_Reset.Visible = true;

                    //object[] transBy = new object[checkedListBox_Parameter.CheckedItems.Count];
                    //string supp;
                    //for (int i = 0; i < checkedListBox_Parameter.CheckedItems.Count; i++)
                    //{
                    //    supp = checkedListBox_Parameter.CheckedItems[i].ToString();
                    //    supp = supp.Substring(0, supp.IndexOf(" ("));
                    //    transBy[i] = supp;
                    //}

                    //FillVTransactionWithBankAccSource(Trans.ToString(), dt_From.Value, dt_To.Value, transBy);
                    title = "Laporan Tagihan";
                    break;
                default:
                    break;
            }

            reportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

            this.reportViewer1.RefreshReport();

            this.Text = title;
            this.TabText = title;

        }

        IList listVTransactionDetailWithBankAcc = null;
        private void FillVTransactionDetailWithBankAccSource(string transStatus, DateTime from, DateTime to, ReportBy reportBy, string ItemOrPIC, bool isAdd)
        {
            IList listTemp = null;
            string ItemOrPIC_Temp = ItemOrPIC;
            if (ItemOrPIC_Temp.Equals(""))
                ItemOrPIC_Temp = "%%";

            bs = new BindingSource();
            bs.Clear();
            //if (!transStatus.Equals(lbl_Param1.Name))
            switch (reportBy)
            {
                case ReportBy.PIC:
                    listTemp = DataMaster.GetListBetweenEqLikeValue(typeof(VTotalTransactionDetailWithBankAcc), VTotalTransactionDetailWithBankAcc.ColumnNames.TransactionDate, from, to, VTotalTransactionDetailWithBankAcc.ColumnNames.TransactionStatus, transStatus, VTotalTransactionDetailWithBankAcc.ColumnNames.TransactionBy, ItemOrPIC_Temp);
                    break;
                default:
                    break;
            }
            //else
            //    bs.DataSource = DataMaster.GetListBetweenValue(typeof(VTransactionWithBankAcc), VTransactionWithBankAcc.ColumnNames.TransactionDate, from, to);

            if (listVTransactionDetailWithBankAcc == null)
                listVTransactionDetailWithBankAcc = new List<VTotalTransactionDetailWithBankAcc>();

            for (int i = 0; i < listTemp.Count; i++)
            {
                listVTransactionDetailWithBankAcc.Add(listTemp[i]);
            }

            bs.DataSource = listVTransactionDetailWithBankAcc;
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTotalTransactionDetailWithBankAcc", bs));
        }

        IList listVTransactionWithBankAcc = null;
        private void FillVTransactionWithBankAccSource(string transStatus, DateTime from, DateTime to, ReportBy reportBy, string ItemOrPIC, bool isAdd)
        {
            IList listTemp = null;
            string ItemOrPIC_Temp = ItemOrPIC;
            if (ItemOrPIC_Temp.Equals(""))
                ItemOrPIC_Temp = "%%";

            bs = new BindingSource();
            bs.Clear();
            //if (!transStatus.Equals(lbl_Param1.Name))
            switch (reportBy)
            {
                case ReportBy.PIC:
                    listTemp = DataMaster.GetListBetweenEqLikeValue(typeof(VTransactionWithBankAcc), VTransactionWithBankAcc.ColumnNames.TransactionDate, from, to, VTransactionWithBankAcc.ColumnNames.TransactionStatus, transStatus, VTransactionWithBankAcc.ColumnNames.TransactionBy, ItemOrPIC_Temp);
                    break;
                default:
                    break;
            }
            //else
            //    bs.DataSource = DataMaster.GetListBetweenValue(typeof(VTransactionWithBankAcc), VTransactionWithBankAcc.ColumnNames.TransactionDate, from, to);

            if (listVTransactionWithBankAcc == null)
                listVTransactionWithBankAcc = new List<VTransactionWithBankAcc>();

            for (int i = 0; i < listTemp.Count; i++)
            {
                listVTransactionWithBankAcc.Add(listTemp[i]);
            }

            bs.DataSource = listVTransactionWithBankAcc;
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTransactionWithBankAcc", bs));
        }

        private void FillVTransactionWithBankAccSource(string transStatus, DateTime from, DateTime to, object[] transBy)
        {
            bs = new BindingSource();
            bs.Clear();

            NHibernate.Expression.ICriterion[] expArrays = new NHibernate.Expression.ICriterion[3];
            expArrays[0] = NHibernate.Expression.Expression.Eq(VTransactionWithBankAcc.ColumnNames.TransactionStatus, transStatus);
            expArrays[1] = NHibernate.Expression.Expression.Between(VTransactionWithBankAcc.ColumnNames.TransactionDate, from, to);
            expArrays[2] = NHibernate.Expression.Expression.In(VTransactionWithBankAcc.ColumnNames.TransactionBy, transBy);

            NHibernate.Expression.Order[] ordArrays = new NHibernate.Expression.Order[1];
            ordArrays[0] = NHibernate.Expression.Order.Asc(VTransactionWithBankAcc.ColumnNames.TransactionFactur);

            bs.DataSource = DataMaster.GetList(typeof(VTransactionWithBankAcc), expArrays, ordArrays);

            //bs.DataSource = DataMaster.GetListBetweenValue(typeof(VTransactionWithBankAcc), VTransactionWithBankAcc.ColumnNames.TransactionDate, from, to);

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTransactionWithBankAcc", bs));
        }

        private void FillVTransactionSource(string transStatus, string transactionBy)
        {
            bs = new BindingSource();
            bs.Clear();
            //if (!transStatus.Equals(lbl_Param1.Name))
            bs.DataSource = DataMaster.GetListEq(typeof(VTransaction), VTransaction.ColumnNames.TransactionStatus, transStatus, VTransaction.ColumnNames.TransactionBy, transactionBy);

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTransaction", bs));
        }

        private void FillVTransactionWithBankAccSource(string transStatus, DateTime from, DateTime to, ReportBy reportBy, string ItemOrPIC)
        {
            string ItemOrPIC_Temp = ItemOrPIC;
            if (ItemOrPIC_Temp.Equals(""))
                ItemOrPIC_Temp = "%%";

            bs = new BindingSource();
            bs.Clear();
            //if (!transStatus.Equals(lbl_Param1.Name))
            switch (reportBy)
            {
                case ReportBy.PIC:
                    bs.DataSource = DataMaster.GetListBetweenEqLikeValue(typeof(VTransactionWithBankAcc), VTransactionWithBankAcc.ColumnNames.TransactionDate, from, to, VTransactionWithBankAcc.ColumnNames.TransactionStatus, transStatus, VTransactionWithBankAcc.ColumnNames.TransactionBy, ItemOrPIC_Temp);
                    break;
                default:
                    break;
            }
            //else
            //    bs.DataSource = DataMaster.GetListBetweenValue(typeof(VTransactionWithBankAcc), VTransactionWithBankAcc.ColumnNames.TransactionDate, from, to);

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTransactionWithBankAcc", bs));
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            mSettingBindingSource.Clear();
            mSettingBindingSource.DataSource = DataMaster.GetListEq(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            e.DataSources.Add(new ReportDataSource("Inventori_Data_MSetting", mSettingBindingSource));


            BindingSource bsset = new BindingSource();
            bsset.DataSource = DataMaster.GetListEq(typeof(TContractorSetting), TContractorSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            e.DataSources.Add(new ReportDataSource("Inventori_Contractor_Data_TContractorSetting", bsset));

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

        private void FillMSupplierDataSource(string p)
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetListEq(typeof(MSupplier), MSupplier.ColumnNames.SupplierId, p);
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
                    bs.DataSource = DataMaster.GetListBetweenEqLikeValue(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionDate, from, to, VTotalTransactionDetail.ColumnNames.TransactionStatus, transStatus, VTotalTransactionDetail.ColumnNames.ItemId, ItemOrPIC_Temp);
                    break;
                case ReportBy.PIC:
                    bs.DataSource = DataMaster.GetListBetweenEqLikeValue(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionDate, from, to, VTotalTransactionDetail.ColumnNames.TransactionStatus, transStatus, VTotalTransactionDetail.ColumnNames.TransactionBy, ItemOrPIC_Temp);
                    break;
                default:
                    break;
            }
            //else
            //    bs.DataSource = DataMaster.GetListBetweenValue(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionDate, from, to);

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTotalTransactionDetail", bs));

            try
            {
                ReportParameter[] parameters = new ReportParameter[4];
                parameters[0] = new ReportParameter("Report_Parameter_DateFrom", from.ToString("f"));
                parameters[1] = new ReportParameter("Report_Parameter_DateTo", to.ToString("f"));
                parameters[2] = new ReportParameter("Report_Parameter_Status", transStatus);
                parameters[3] = new ReportParameter("Report_Parameter_PIC", ItemOrPIC_Temp);
                reportViewer1.LocalReport.SetParameters(parameters);
            }
            catch (Exception)
            {
            }

        }

        private void FillTransactionTotalSource(string transStatus, string transactionBy)
        {
            bs = new BindingSource();
            bs.Clear();
            //if (!transStatus.Equals(lbl_Param1.Name))
            bs.DataSource = DataMaster.GetListEq(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionStatus, transStatus, VTotalTransactionDetail.ColumnNames.TransactionBy, transactionBy);

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTotalTransactionDetail", bs));
        }


        private void FillTransactionDetailSource(decimal transactionId)
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetListEq(typeof(VTotalTransactionDetail), VTotalTransactionDetail.ColumnNames.TransactionId, transactionId);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VTotalTransactionDetail", bs));
        }

        private void FillTransactionSource(string suppId)
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetListEq(typeof(TTransaction), TTransaction.ColumnNames.TransactionBy, suppId, TTransaction.ColumnNames.TransactionStatus, ListOfTransaction.Purchase.ToString());
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TTransaction", bs));
        }

        private void FillTransactionSource(string suppId, string currencyid)
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetListEq(typeof(TTransaction), TTransaction.ColumnNames.TransactionBy, suppId, TTransaction.ColumnNames.TransactionStatus, ListOfTransaction.Purchase.ToString(), TTransaction.ColumnNames.CurrencyId, currencyid);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TTransaction", bs));
        }

        private void FillGiroSource(string suppId)
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetListEq(typeof(TGiro), TGiro.ColumnNames.GiroTo, suppId, TGiro.ColumnNames.GiroStatus, ListOfGiroStatus.Cair.ToString());
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TGiro", bs));
        }

        private void FillGiroSource(string groupBy, string currencyid)
        {
            bs = new BindingSource();
            bs.Clear();

            bs.DataSource = DataMaster.GetListEq(typeof(TGiro), TGiro.ColumnNames.CurrencyId, currencyid);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TGiro", bs));

            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("Report_Parameter_GroupBy", groupBy);
            parameters[1] = new ReportParameter("Report_Parameter_CurrencyId", currencyid);
            reportViewer1.LocalReport.SetParameters(parameters);
        }

        private void FillVSupplierDetailDataSource()
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetAll(typeof(VSupplierDetail));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VSupplierDetail", bs));
        }

        private void FillVSupplierAccountDataSource()
        {
            bs = new BindingSource();
            bs.Clear();
            bs.DataSource = DataMaster.GetAll(typeof(VSupplierAccount));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_VSupplierAccount", bs));
        }

        private void FillUserLogSource(DateTime from, DateTime to, string p)
        {
            bs = new BindingSource();
            bs.Clear();
            if (!string.IsNullOrEmpty(p))
                bs.DataSource = DataMaster.GetListBetweenEqValue(typeof(TLog), TLog.ColumnNames.LogDate, from, to, TLog.ColumnNames.LogUser, p);
            else
                bs.DataSource = DataMaster.GetListBetweenValue(typeof(TLog), TLog.ColumnNames.LogDate, from, to);

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Inventori_Data_TLog", bs));
        }

        private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            BindReport();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            BindReport();
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            listVTransactionWithBankAcc = null;
            reportViewer1.Clear();
        }
    }
}

