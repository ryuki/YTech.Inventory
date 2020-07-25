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
    public partial class FormSearchSupplier : Inventori.Forms.FormParentForSearchForm
    {
        public event EventHandler SupplierHasSelected;
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();

        public FormSearchSupplier()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MSupplier.ColumnNames.SupplierId;
            grid_Col.HeaderText = "Kode Supplier";
            grid_Search.Columns.Add(grid_Col);
            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MSupplier.ColumnNames.SupplierName;
            grid_Col.HeaderText = "Nama Supplier";
            grid_Search.Columns.Add(grid_Col);
            //add kolom telp
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MSupplier.ColumnNames.SupplierPhone;
            grid_Col.HeaderText = "Telepon";
            grid_Search.Columns.Add(grid_Col);


            grid_Search.CellDoubleClick += new DataGridViewCellEventHandler(grid_Search_CellDoubleClick);
            grid_Search.KeyDown += new KeyEventHandler(grid_Search_KeyDown);
            txt_SearchById.TextChanged += new EventHandler(txt_SearchById_TextChanged);
            txt_SearchByName.TextChanged += new EventHandler(txt_SearchByName_TextChanged);
            btn_OK.Click += new EventHandler(btn_OK_Click);
        }

        private void FormSearchEmployee_Load(object sender, EventArgs e)
        {
            BindData(string.Empty, MSupplier.ColumnNames.SupplierName);
        }

        private void BindData(string keyWord, string columnName)
        {
            string myKeyWord = "%" + keyWord + "%";
            bindingSource_Search.Clear();
            IList listSearch = DataMaster.GetListLike(typeof(MSupplier), columnName, myKeyWord);
            if (listSearch.Count > 0)
                bindingSource_Search.DataSource = listSearch;
        }

        private void grid_Search_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.SupplierHasSelected != null)
                this.SupplierHasSelected(null, null);

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
            BindData(txt_SearchById.Text, MSupplier.ColumnNames.SupplierId);
        }

        private void txt_SearchByName_TextChanged(object sender, EventArgs e)
        {
            BindData(txt_SearchByName.Text, MSupplier.ColumnNames.SupplierName);
        }
    }
}

