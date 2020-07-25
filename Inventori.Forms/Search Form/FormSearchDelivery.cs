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
    public partial class FormSearchDelivery : Inventori.Forms.FormParentForSearchForm
    {
        public event EventHandler DeliveryHasSelected;
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        //private string trans_Type;
        DateTimePicker dt_From;
        DateTimePicker dt_To;

        public FormSearchDelivery()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = TTransactionDelivery.ColumnNames.DeliveryId;
            grid_Col.HeaderText = "Kode Pengiriman";
            grid_Col.Visible = false;
            grid_Search.Columns.Add(grid_Col);

            //add kolom No Surat Jalan Supplier
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = TTransactionDelivery.ColumnNames.DeliveryNumberPic;
            grid_Col.HeaderText = "No Surat Jalan Supplier";
            grid_Search.Columns.Add(grid_Col);

            //add ekspedisi
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = TTransactionDelivery.ColumnNames.DeliveryExpedission;
            grid_Col.HeaderText = "Ekspedisi";
            grid_Search.Columns.Add(grid_Col);

            //add kolom No Surat Jalan Ekspedisi
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = TTransactionDelivery.ColumnNames.DeliveryNumberExpedission ;
            grid_Col.HeaderText = "No Surat Jalan Ekspedisi";
            grid_Search.Columns.Add(grid_Col);
        }

        private void FormSearchDelivery_Load(object sender, EventArgs e)
        {
            Label l = new Label();
            l.Location = new Point(9, 50);
            l.Text = "Dari tanggal";
            l.AutoSize = true;
            groupBox1.Controls.Add(l);

            dt_From = new DateTimePicker();
            Inventori.Module.ModuleControlSettings.SetDateTimePicker(dt_From, false);
            dt_From.Value = DateTime.Now.AddDays(-7);
            dt_From.ValueChanged += new EventHandler(BindData);
            dt_From.Location = new Point(100, 50);
            dt_From.Width = 100;
            groupBox1.Controls.Add(dt_From);

            Label l2 = new Label();
            l2.Location = new Point(220, 50);
            l2.Text = "s/d";
            l2.AutoSize = true;
            groupBox1.Controls.Add(l2);

            dt_To = new DateTimePicker();
            ModuleControlSettings.SetDateTimePicker(dt_To, false);
            dt_To.Value = DateTime.Now;
            dt_To.ValueChanged += new EventHandler(BindData);
            dt_To.Location = new Point(250, 50);
            dt_To.Width = 100;
            groupBox1.Controls.Add(dt_To);

            groupBox1.Size = new Size(groupBox1.Size.Width, groupBox1.Size.Height + 50);
            tableLayoutPanel1.RowStyles[0].Height += 50;

            grid_Search.CellDoubleClick += new DataGridViewCellEventHandler(grid_Search_CellDoubleClick);
            grid_Search.KeyDown += new KeyEventHandler(grid_Search_KeyDown);
            btn_OK.Click += new EventHandler(btn_OK_Click);

            BindData(null, null);
        }

        public void BindData(object sender, EventArgs e)
        {
            string myKeyWord = "%" + txt_SearchById.Text.Trim() + "%";
            if (txt_SearchById.Text.Equals("<Cari Berdasar No Surat Jalan Supplier>"))
                myKeyWord = "%%";

            bindingSource_Search.Clear();

            NHibernate.Expression.ICriterion[] expArrays = new NHibernate.Expression.ICriterion[2];
            expArrays[0] = NHibernate.Expression.Expression.Between(TTransactionDelivery.ColumnNames.DeliveryReceiveDate, dt_From.Value, dt_To.Value);
            expArrays[1] = NHibernate.Expression.Expression.Like(TTransactionDelivery.ColumnNames.DeliveryNumberPic, myKeyWord);

            NHibernate.Expression.Order[] ordArrays = new NHibernate.Expression.Order[1];
            ordArrays[0] = NHibernate.Expression.Order.Asc(TTransactionDelivery.ColumnNames.DeliveryReceiveDate);

            IList listSearch = DataMaster.GetList(typeof(TTransactionDelivery), expArrays, ordArrays);

            if (listSearch.Count > 0)
                bindingSource_Search.DataSource = listSearch;
        }

        private void grid_Search_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.DeliveryHasSelected != null)
                this.DeliveryHasSelected(null, null);

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
    }
}