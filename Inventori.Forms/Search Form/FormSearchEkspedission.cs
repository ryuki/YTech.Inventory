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

namespace Inventori.Forms
{
    public partial class FormSearchEkspedission : Inventori.Forms.FormParentForSearchForm
    {
        public event EventHandler EkspedissionHasSelected;
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();

        public FormSearchEkspedission()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MEkspedission.ColumnNames.EkspedissionId;
            grid_Col.HeaderText = "Kode Ekspedisi";
            grid_Search.Columns.Add(grid_Col);
            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MEkspedission.ColumnNames.EkspedissionName;
            grid_Col.HeaderText = "Nama Ekspedisi";
            grid_Search.Columns.Add(grid_Col);
            //add kolom alamat
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MEkspedission.ColumnNames.EkspedissionAddress;
            grid_Col.HeaderText = "Alamat";
            grid_Search.Columns.Add(grid_Col);

            grid_Search.CellDoubleClick += new DataGridViewCellEventHandler(grid_Search_CellDoubleClick);
            grid_Search.KeyDown += new KeyEventHandler(grid_Search_KeyDown);
            txt_SearchById.TextChanged += new EventHandler(txt_SearchById_TextChanged);
            txt_SearchByName.TextChanged += new EventHandler(txt_SearchByName_TextChanged);
            btn_OK.Click += new EventHandler(btn_OK_Click);
        }

        private void FormSearchEkspedission_Load(object sender, EventArgs e)
        {
            BindData(string.Empty, MEkspedission.ColumnNames.EkspedissionName);
        }

        private void BindData(string keyWord, string columnName)
        {
            string myKeyWord = "%" + keyWord + "%";
            bindingSource_Search.Clear();
            IList listSearch = DataMaster.GetListLike(typeof(MEkspedission), columnName, myKeyWord);
            if (listSearch.Count > 0)
                bindingSource_Search.DataSource = listSearch;
        }

        private void grid_Search_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.EkspedissionHasSelected != null)
                this.EkspedissionHasSelected(null, null);

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
            BindData(txt_SearchById.Text, MEkspedission.ColumnNames.EkspedissionId);
        }

        private void txt_SearchByName_TextChanged(object sender, EventArgs e)
        {
            BindData(txt_SearchByName.Text, MEkspedission.ColumnNames.EkspedissionName);
        }
    }
}