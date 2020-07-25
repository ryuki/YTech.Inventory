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
namespace Inventori.Dealer.Forms
{
    public partial class FormSearchStock : Inventori.Forms.FormParentForSearchForm
    {
        public event EventHandler StockHasSelected;
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        public FormSearchStock()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = TStock.ColumnNames.StockId;
            grid_Col.HeaderText = "Kode Stok";
            grid_Search.Columns.Add(grid_Col);
            //add kolom item
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = TStock.ColumnNames.ItemId;
            grid_Col.HeaderText = "Type Unit";
            grid_Search.Columns.Add(grid_Col);
            //add kolom warna
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = TStock.ColumnNames.StockDesc1;
            grid_Col.HeaderText = "Warna";
            grid_Search.Columns.Add(grid_Col);
            //add kolom no rangka
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = TStock.ColumnNames.StockDesc2;
            grid_Col.HeaderText = "No Rangka";
            grid_Search.Columns.Add(grid_Col);
            //add kolom no mesin
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = TStock.ColumnNames.StockDesc3;
            grid_Col.HeaderText = "No Mesin";
            grid_Search.Columns.Add(grid_Col);

            grid_Search.CellDoubleClick += new DataGridViewCellEventHandler(grid_Search_CellDoubleClick);
            grid_Search.KeyDown += new KeyEventHandler(grid_Search_KeyDown);
            txt_SearchById.TextChanged += new EventHandler(txt_SearchById_TextChanged);
            txt_SearchByName.TextChanged += new EventHandler(txt_SearchByName_TextChanged);
            btn_OK.Click += new EventHandler(btn_OK_Click);
          
        }

        public ComboBox cb_ItemId;
        private void CreateItemFilter()
        {
            Label l = new Label();
            l.Location = new Point(9, 50);
            l.Text = "Type Unit";
            l.AutoSize = true;
            groupBox1.Controls.Add(l);

            //type unit
            cb_ItemId = new ComboBox();
            cb_ItemId.Location = new Point(100, 50);
            cb_ItemId.Width = 150;
            cb_ItemId.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_ItemId.ValueMember = MItem.ColumnNames.ItemId;
            cb_ItemId.DisplayMember = MItem.ColumnNames.ItemName;
            cb_ItemId.SelectedIndexChanged += new EventHandler(cb_ItemId_SelectedIndexChanged);
            cb_ItemId.DataSource = DataMaster.GetAll(typeof(MItem));
            cb_ItemId.Show();
            groupBox1.Controls.Add(cb_ItemId);

            groupBox1.Size = new Size(groupBox1.Size.Width, groupBox1.Size.Height + 50);
            tableLayoutPanel1.RowStyles[0].Height += 50;

        }

        void cb_ItemId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData(sender, e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //create search
            CreateItemFilter();
            BindData(null, null);
            //BindData(string.Empty, TStock.ColumnNames.StockId);
        }

        private int _location;
        public int GudangId
        {
            get { return _location; }
            set { _location = value; }
        }

        private string _location1;
        public string LocationId
        {
            get { return _location1; }
            set { _location1 = value; }
        }

        private void BindData(object sender, EventArgs e)
        {
            string myKeyWord = string.Empty;
            string col = TStock.ColumnNames.StockDesc2;
            if (sender == txt_SearchById)
            {
                if (!txt_SearchById.Text.Equals("<Cari Berdasar No Rangka>"))
                    myKeyWord = txt_SearchById.Text.Trim();
                col = TStock.ColumnNames.StockDesc2;
            }
            else if (sender == txt_SearchByName)
            {
                if (!txt_SearchByName.Text.Equals("<Cari Berdasar No Mesin>"))
                    myKeyWord = txt_SearchByName.Text.Trim();
                col = TStock.ColumnNames.StockDesc3;
            }
            //bindingSource_Search.Clear();

            NHibernate.Expression.ICriterion[] expArrays = new NHibernate.Expression.ICriterion[5];
            expArrays[0] = NHibernate.Expression.Expression.Eq(TStock.ColumnNames.ItemId, cb_ItemId.SelectedValue.ToString());
            expArrays[1] = NHibernate.Expression.Expression.InsensitiveLike(col, myKeyWord,NHibernate.Expression.MatchMode.Anywhere);
            expArrays[2] = NHibernate.Expression.Expression.Eq(TStock.ColumnNames.GudangId, GudangId);
            if (!string.IsNullOrEmpty(LocationId))
            {
                expArrays[3] = NHibernate.Expression.Expression.Eq(TStock.ColumnNames.LocatonId, LocationId);
            }
            expArrays[4] = NHibernate.Expression.Expression.Eq(TStock.ColumnNames.StockIsAvailable, true);

            IList listSearch = DataMaster.GetList(typeof(TStock), expArrays, null);
            TStock stok;
            MColour color;
            MItem item;
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(TStock.ColumnNames.StockId);
            dt.Columns.Add(TStock.ColumnNames.ItemId);
            dt.Columns.Add(TStock.ColumnNames.StockDesc1);
            dt.Columns.Add(TStock.ColumnNames.StockDesc2);
            dt.Columns.Add(TStock.ColumnNames.StockDesc3);

            for (int i = 0; i < listSearch.Count; i++)
            {
                stok = listSearch[i] as TStock;
                dr = dt.NewRow();
                dr[0] = stok.StockId;

                //nama item
                item = DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, stok.ItemId) as MItem;
                if (item == null)
                    item = new MItem();
                dr[1] = item.ItemName;
                //nama warna
                color = DataMaster.GetObjectByProperty(typeof(MColour), MColour.ColumnNames.ColourId, stok.StockDesc1) as MColour;
                if (color == null)
                    color = new MColour();
                dr[2] = color.ColourDesc;
                dr[3] = stok.StockDesc2;
                dr[4] = stok.StockDesc3;
                dt.Rows.Add(dr);
            }

            bindingSource_Search.DataSource = dt;
            //if (listSearch.Count > 0)
            //    bindingSource_Search.DataSource = listSearch;
        }

        private void grid_Search_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.StockHasSelected != null)
                this.StockHasSelected(null, null);

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
            BindData(sender, null);
        }

        private void txt_SearchByName_TextChanged(object sender, EventArgs e)
        {
            BindData(sender, null);
        }
    }
}