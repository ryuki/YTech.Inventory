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

namespace Inventori.Dealer.Forms
{
    public partial class FormStock : Inventori.Forms.FormParentForMasterForm
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private TStock stok;

        ToolStripComboBox itemToolStripComboBox;
        ToolStripTextBox stockDesc2ToolStripTextBox;
        ToolStripTextBox stockDesc3ToolStripTextBox;

        public FormStock()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode Stock
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = TStock.ColumnNames.StockId;
            grid_Col.HeaderText = "Kode Stock";
            grid_Master.Columns.Add(grid_Col);
            //add kolom Type Unit
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = TStock.ColumnNames.ItemId;
            grid_Col.HeaderText = "Type Unit";
            grid_Master.Columns.Add(grid_Col);
            //add kolom Warna
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = TStock.ColumnNames.StockDesc1;
            grid_Col.HeaderText = "Warna";
            grid_Master.Columns.Add(grid_Col);
            //add kolom Nomor Rangka
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = TStock.ColumnNames.StockDesc2;
            grid_Col.HeaderText = "Nomor Rangka";
            grid_Master.Columns.Add(grid_Col);
            //add kolom Nomor Mesin
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = TStock.ColumnNames.StockDesc3;
            grid_Col.HeaderText = "Nomor Mesin";
            grid_Master.Columns.Add(grid_Col);

            //hidden add and edit
            bindingNavigatorAddNewItem.Visible = false;
            bindingNavigatorDeleteItem.Visible = false;

            //add sep
            ToolStripSeparator sep = new ToolStripSeparator();
            bindingNavigator_Master.Items.Add(sep);


            //add combo
            itemToolStripComboBox = new ToolStripComboBox();

            NHibernate.Expression.Order[] orderArrays = new NHibernate.Expression.Order[1];
            orderArrays[0] = NHibernate.Expression.Order.Asc(MItem.ColumnNames.ItemName);
            IList listItem = DataMaster.GetList(typeof(MItem), null, orderArrays);
            MItem item = new MItem();
            item.ItemName = "-Type Unit-";
            listItem.Insert(0, item);
            itemToolStripComboBox.ComboBox.DataSource = listItem;
            itemToolStripComboBox.ComboBox.DisplayMember = MItem.ColumnNames.ItemName;
            itemToolStripComboBox.ComboBox.ValueMember = MItem.ColumnNames.ItemId;
            itemToolStripComboBox.ComboBox.Show();

            //combo.Items.Add("Kode Type Unit");
            //combo.Items.Add("Nama Type Unit");
            itemToolStripComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            bindingNavigator_Master.Items.Add(itemToolStripComboBox);

            //add cari text
            bindingNavigator_Master.Items.Add("No Rangka :");

            //add textbox
            stockDesc2ToolStripTextBox = new ToolStripTextBox();
            stockDesc2ToolStripTextBox.TextBox.Width = 80;
            bindingNavigator_Master.Items.Add(stockDesc2ToolStripTextBox);

            //add cari text
            bindingNavigator_Master.Items.Add("No Mesin :");

            //add textbox
            stockDesc3ToolStripTextBox = new ToolStripTextBox();
            stockDesc3ToolStripTextBox.TextBox.Width = 80;
            bindingNavigator_Master.Items.Add(stockDesc3ToolStripTextBox);

            //add button
            ToolStripButton btn = new ToolStripButton();
            btn.Text = "Cari";
            btn.Image = Properties.Resources.scanner;
            btn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btn.TextImageRelation = TextImageRelation.ImageAboveText;
            btn.Click += new EventHandler(btn_Click);
            bindingNavigator_Master.Items.Add(btn);

            //refresh navigator
            bindingNavigator_Master.Refresh();

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);

        }

        void btn_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //fill color
            AppCode.FillColorComboBox(stockDesc1ComboBox);
            //fill unit
            AppCode.FillItemComboBox(itemIdComboBox);


            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            NHibernate.Expression.ICriterion[] expArrays = new NHibernate.Expression.ICriterion[3];
            if (itemToolStripComboBox.ComboBox.SelectedValue != null)
            {
                if (itemToolStripComboBox.ComboBox.SelectedValue.ToString() != string.Empty)
                {
                    expArrays[0] = NHibernate.Expression.Expression.Eq(TStock.ColumnNames.ItemId, itemToolStripComboBox.ComboBox.SelectedValue);
                }
            }

            expArrays[1] = NHibernate.Expression.Expression.Like(TStock.ColumnNames.StockDesc2, stockDesc2ToolStripTextBox.Text, NHibernate.Expression.MatchMode.Anywhere);
            expArrays[2] = NHibernate.Expression.Expression.Like(TStock.ColumnNames.StockDesc3, stockDesc3ToolStripTextBox.Text, NHibernate.Expression.MatchMode.Anywhere);

            IList listMaster = DataMaster.GetList(typeof(TStock), expArrays, null);
            if (listMaster.Count > 0)
                bindingSource_Master.DataSource = listMaster;
            else
                bindingSource_Master.Clear();

            bindingSource_Master_PositionChanged(null, null);
        }

        private void bindingSource_Master_PositionChanged(object sender, EventArgs e)
        {
            SetNavigatorDisplay();
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            stok = (TStock)DataMaster.GetObjectByProperty(typeof(TStock), TStock.ColumnNames.StockId, stockIdLabel1.Text);

            stok.ItemId = itemIdComboBox.SelectedValue.ToString();
            stok.StockDesc1 = stockDesc1ComboBox.SelectedValue.ToString();
            stok.StockDesc2 = stockDesc2TextBox.Text;
            stok.StockDesc3 = stockDesc3TextBox.Text;
            stok.ModifiedBy = lbl_UserName.Text;
            stok.ModifiedDate = DateTime.Now;

            DataMaster.UpdatePersistence(stok);

            BindData();
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (stockDesc1ComboBox.SelectedIndex == 0)
            {
                balloonHelp.Content = "Pilih Warna ";
                balloonHelp.ShowBalloon(stockDesc1ComboBox);
                stockDesc1ComboBox.Focus();
                return false;
            }
            return true;
        }

        private void bindingNavigatorRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}