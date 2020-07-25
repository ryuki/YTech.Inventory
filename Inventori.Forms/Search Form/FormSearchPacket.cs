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
    public partial class FormSearchPacket : Inventori.Forms.FormParentForSearchForm
    {
        public event EventHandler PacketHasSelected;
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();

        private string _packetIdColoumnName;
        public string packetIdColoumnName
        {
            get { return _packetIdColoumnName; }
            set { _packetIdColoumnName = value; }
        }

        private string _packetNameColoumnName;
        public string packetNameColoumnName
        {
            get { return _packetNameColoumnName; }
            set { _packetNameColoumnName = value; }
        }

        private string _packetPriceColoumnName;
        public string packetPriceColoumnName
        {
            get { return _packetPriceColoumnName; }
            set { _packetPriceColoumnName = value; }
        }

        private object _transactionId;
        public object TransactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; }
        }

        public FormSearchPacket()
        {
            InitializeComponent();
        }

        private void SetInitialSettings()
        {
            grid_Search.Columns.Clear();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MPacket.ColumnNames.PacketId;
            grid_Col.HeaderText = string.IsNullOrEmpty(packetIdColoumnName) ? "Kode" : packetIdColoumnName;
            grid_Search.Columns.Add(grid_Col);

            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MPacket.ColumnNames.PacketName;
            grid_Col.HeaderText = string.IsNullOrEmpty(packetNameColoumnName) ? "Nama" : packetNameColoumnName;
            grid_Search.Columns.Add(grid_Col);

            //add kolom harga
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MPacket.ColumnNames.PacketPrice;
            grid_Col.DefaultCellStyle.Format = "N";
            grid_Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grid_Col.HeaderText = string.IsNullOrEmpty(packetPriceColoumnName) ? "Harga" : packetPriceColoumnName;
            grid_Search.Columns.Add(grid_Col);

            grid_Search.CellDoubleClick += new DataGridViewCellEventHandler(grid_Search_CellDoubleClick);
            grid_Search.KeyDown += new KeyEventHandler(grid_Search_KeyDown);
            txt_SearchById.TextChanged += new EventHandler(txt_SearchById_TextChanged);
            txt_SearchByName.TextChanged += new EventHandler(txt_SearchByName_TextChanged);
            btn_OK.Click += new EventHandler(btn_OK_Click);

            ModuleControlSettings.SetGridDataView(grid_Search);
            //set display text
            groupBox1.Text = this.Text;
        }

        private void FormSearchPacket_Load(object sender, EventArgs e)
        {
            SetInitialSettings();
            BindData(string.Empty, MPacket.ColumnNames.PacketId);
        }

        private void BindData(string keyWord, string columnName)
        {
            string myKeyWord = "%" + keyWord + "%";
            bindingSource_Search.Clear();
            IList listSearch = null; 

            if (TransactionId == null)
                listSearch = DataMaster.GetListLike(typeof(MPacket), columnName, myKeyWord);
            else
            {
                tableLayoutPanel1.RowStyles[0].Height = 0f;
                listSearch = new List<MPacket>();
                IList detList = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, Convert.ToDecimal(TransactionId),TTransactionDetail.ColumnNames.IsPacket,true);
                TTransactionDetail det;
                MPacket paket;

                for (int i = 0; i < detList.Count; i++)
                {
                    det = (TTransactionDetail)detList[i];
                    paket = (MPacket)DataMaster.GetObjectByProperty(typeof(MPacket), MPacket.ColumnNames.PacketId, det.ItemId);
                    if (paket != null)
                        listSearch.Add(paket);
                }
            }

            if (listSearch.Count > 0)
                bindingSource_Search.DataSource = listSearch;
        }

        private void grid_Search_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.PacketHasSelected != null)
                this.PacketHasSelected(null, null);

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
            BindData(txt_SearchById.Text, MPacket.ColumnNames.PacketId);
        }

        private void txt_SearchByName_TextChanged(object sender, EventArgs e)
        {
            BindData(txt_SearchByName.Text, MPacket.ColumnNames.PacketName);
        }
	
	
	

    }
}