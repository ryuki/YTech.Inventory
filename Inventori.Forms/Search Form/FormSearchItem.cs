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

namespace Inventori.Forms
{
    public partial class FormSearchItem : Inventori.Forms.FormParentForSearchForm
    {
        public event EventHandler ItemHasSelected;
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        public FormSearchItem()
        {
            InitializeComponent();

            grid_Search.CellDoubleClick += new DataGridViewCellEventHandler(grid_Search_CellDoubleClick);
            grid_Search.KeyDown += new KeyEventHandler(grid_Search_KeyDown);
            txt_SearchById.TextChanged += new EventHandler(txt_SearchById_TextChanged);
            txt_SearchByName.TextChanged += new EventHandler(txt_SearchByName_TextChanged);
            btn_OK.Click += new EventHandler(btn_OK_Click);
        }

        private object _transactionId;
        public object TransactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; }
        }

        private int _itemType;
        public int itemType
        {
            get { return _itemType; }
            set { _itemType = value; }
        }

        private void FormSearchItem_Load(object sender, EventArgs e)
        {
            SetSearchTextBox();
            CreateColumn();
            BindData(string.Empty, MItem.ColumnNames.ItemName);

            if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSales.ToString()))
            {
                //if sales ,use common price
                grid_Search.Columns[3].Visible = false;
                grid_Search.Columns[4].Visible = false;
            }
            else if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Purchase.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturPurchase.ToString()))
            {
                //if purchase , use purchase price
                grid_Search.Columns[2].Visible = false;
                grid_Search.Columns[3].Visible = false;
            }
            else if (lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSalesVIP.ToString()))
            {
                //if vip, use vip price
                grid_Search.Columns[2].Visible = false;
                grid_Search.Columns[4].Visible = false;
            }
            else if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Correction.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.PurchaseOrder.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.Usage.ToString()))
            {
                //if correction, use none
                grid_Search.Columns[2].Visible = false;
                grid_Search.Columns[3].Visible = false;
                grid_Search.Columns[4].Visible = false;
            }
            else
            {
                grid_Search.Columns[2].Visible = false;
                grid_Search.Columns[3].Visible = false;
                grid_Search.Columns[4].Visible = false;
            }
        }

        private string _itemId_HeaderText = "Kode Item";
        public string itemId_HeaderText
        {
            get { return _itemId_HeaderText; }
            set { _itemId_HeaderText = value; }
        }

        private string _itemName_HeaderText = "Nama Item";
        public string itemName_HeaderText
        {
            get { return _itemName_HeaderText; }
            set { _itemName_HeaderText = value; }
        }

        private string _itemSalesPrice_HeaderText = "Harga Jual";
        public string itemSalesPrice_HeaderText
        {
            get { return _itemSalesPrice_HeaderText; }
            set { _itemSalesPrice_HeaderText = value; }
        }

        private string _itemSalesPriceVIP_HeaderText = "Harga Jual VIP";
        public string itemSalesPriceVIP_HeaderText
        {
            get { return _itemSalesPriceVIP_HeaderText; }
            set { _itemSalesPriceVIP_HeaderText = value; }
        }

        private string _itemPurchasePrice_HeaderText = "Harga Beli";
        public string itemPurchasePrice_HeaderText
        {
            get { return _itemPurchasePrice_HeaderText; }
            set { _itemPurchasePrice_HeaderText = value; }
        }

        private string _searchItemByIdText = "<Cari Berdasar Kode Item>";
        public string searchItemByIdText
        {
            get { return _searchItemByIdText; }
            set { _searchItemByIdText = value; }
        }

        private string _searchItemByNameText = "<Cari Berdasar Nama Item>";
        public string searchItemByNameText
        {
            get { return _searchItemByNameText; }
            set { _searchItemByNameText = value; }
        }

        private void SetSearchTextBox()
        {
            txt_SearchById.Text = searchItemByIdText;
            txt_SearchByName.Text = searchItemByNameText;
        }

        private void CreateColumn()
        {
            grid_Search.Columns.Clear();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItem.ColumnNames.ItemId;
            grid_Col.HeaderText = itemId_HeaderText;
            grid_Search.Columns.Add(grid_Col);
            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItem.ColumnNames.ItemName;
            grid_Col.HeaderText = itemName_HeaderText;
            grid_Search.Columns.Add(grid_Col);
            //add kolom harga jual
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItem.ColumnNames.ItemPriceMax;
            grid_Col.HeaderText = itemSalesPrice_HeaderText;
            grid_Col.DefaultCellStyle.Format = "N";
            grid_Search.Columns.Add(grid_Col);
            //add kolom Harga Jual VIP
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItem.ColumnNames.ItemPriceMaxVip;
            grid_Col.HeaderText = itemSalesPriceVIP_HeaderText;
            grid_Col.DefaultCellStyle.Format = "N";
            grid_Search.Columns.Add(grid_Col);
            //add kolom Harga Per Satuan
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItem.ColumnNames.ItemPricePurchase;
            grid_Col.HeaderText = itemPurchasePrice_HeaderText;
            grid_Col.DefaultCellStyle.Format = "N";
            grid_Search.Columns.Add(grid_Col);

            ModuleControlSettings.SetGridDataView(grid_Search);
        }

        private void BindData(string keyWord, string columnName)
        {
            string myKeyWord = "%" + keyWord + "%";
            bindingSource_Search.Clear();
            IList listSearch = null;

            if (TransactionId == null)
            {
                if (itemType != 0)
                    listSearch = DataMaster.GetListLikeEq(typeof(MItem), MItem.ColumnNames.ItemTypeId, itemType, columnName, myKeyWord);
                else
                    listSearch = DataMaster.GetListLike(typeof(MItem), columnName, myKeyWord);
            }
            else
            {
                tableLayoutPanel1.RowStyles[0].Height = 0f;
                listSearch = new List<MItem>();
                IList detList = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, Convert.ToDecimal(TransactionId), TTransactionDetail.ColumnNames.IsPacket, false);
                TTransactionDetail det;
                MItem item;

                for (int i = 0; i < detList.Count; i++)
                {
                    det = (TTransactionDetail)detList[i];
                    item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, det.ItemId);
                    if (item != null)
                        listSearch.Add(item);
                }
            }

            if (listSearch.Count > 0)
                bindingSource_Search.DataSource = listSearch;
        }

        private void grid_Search_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.ItemHasSelected != null)
                this.ItemHasSelected(null, null);

            this.Close();
        }

        private void grid_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                grid_Search_CellDoubleClick(null, null);
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            grid_Search_CellDoubleClick(null, null);
        }

        private void txt_SearchById_TextChanged(object sender, EventArgs e)
        {
            BindData(txt_SearchById.Text, MItem.ColumnNames.ItemId);
        }

        private void txt_SearchByName_TextChanged(object sender, EventArgs e)
        {
            BindData(txt_SearchByName.Text, MItem.ColumnNames.ItemName);
        }
    }
}

