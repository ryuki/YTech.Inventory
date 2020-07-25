using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.Data;
using Inventori.Facade;
using Inventori.Module;
using Inventori.Forms;

namespace Inventori.InOutItem.Forms
{
    public partial class FormTransaction : FormParentForInOutItem
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        public ListOfTransaction trans;

        public FormTransaction(ListOfTransaction tr)
        {
            InitializeComponent();

            trans = tr;
            SetInitialSettings();
            //set event
            SetEvent();

        }

        private void SetEvent()
        {
            this.Load += new EventHandler(FormTransaction_Load);
            //transaction by
            transactionByTextBox.Validating += new CancelEventHandler(transactionByTextBox_Validating);
            transactionByTextBox.Enter += new EventHandler(transactionByTextBox_Enter);
            transactionByTextBox.Leave += new EventHandler(transactionByTextBox_Leave);
            //item
            itemIdTextBox.Validating += new CancelEventHandler(itemIdTextBox_Validating);
            itemIdTextBox.Enter += new EventHandler(itemIdTextBox_Enter);
            itemIdTextBox.Leave += new EventHandler(itemIdTextBox_Leave);
            //add button
            buttonAdd.Click += new EventHandler(buttonAdd_Click);
            //tStockDataGridView

            //save
            buttonSave.Click += new EventHandler(buttonSave_Click);

            simpanToolStripButton.Click += new EventHandler(simpanToolStripButton_Click);
        }

        void transactionByTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(transactionByTextBox, ListOfSearchWindow.SearchCustomer.ToString(), false);
        }

        void transactionByTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(transactionByTextBox, ListOfSearchWindow.SearchCustomer.ToString(), true);
        }

        void itemIdTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), false);
        }

        void itemIdTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), true);
        }

        void simpanToolStripButton_Click(object sender, EventArgs e)
        {
            SaveTransaction();
            SaveTransactionDetail();
            SaveStock();

            MessageBox.Show("Transaksi " + Text + " berhasil disimpan", AppCode.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            simpanToolStripButton.Enabled = false;
        }

        private void SaveStock()
        {
            for (int i = 0; i < tStockDataGridView.RowCount; i++)
            {
                TStock s = new TStock();
                s.ItemId = tStockDataGridView.Rows[i].Cells[2].Value.ToString();
                s.StockBarcodeId = tStockDataGridView.Rows[i].Cells[0].Value.ToString();
                s.StockLocation = tStockDataGridView.Rows[i].Cells[1].Value.ToString();
                DataMaster.SaveOrUpdate(s);
            }
        }

        private void SaveTransactionDetail()
        {
            for (int i = 0; i < tTransactionDetailDataGridView.RowCount; i++)
            {
                TTransactionDetail det = new TTransactionDetail();
                det.ItemId = tTransactionDetailDataGridView.Rows[i].Cells[0].Value.ToString();
                det.Quantity = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[1].Value);
                DataMaster.SaveOrUpdate(det);

                UpdateStok(det.ItemId, det.Quantity);
            }
        }

        private void UpdateStok(string ItemId, decimal qty)
        {
            int gudangId = 1;
            bool AddStok = true;
            if (trans == ListOfTransaction.Sales)
            {
                AddStok = false;
            }
            decimal saldo = decimal.Zero;
            ItemGudangStok stok = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, ItemId, ItemGudangStok.ColumnNames.GudangId, gudangId);
            if (AddStok)
                saldo = stok.ItemStok + qty;
            else
                saldo = stok.ItemStok - qty;

            stok.ItemStok = saldo;
            stok.ModifiedBy = lbl_UserName.Text;
            stok.ModifiedDate = DateTime.Now;
            DataMaster.UpdatePersistence(stok);
        }

        private void SaveTransaction()
        {
            TTransaction t = new TTransaction();
            t.TransactionId = transactionIdNumericUpDown.Value;
            t.TransactionStatus = trans.ToString();
            DataMaster.SavePersistence(t);
        }

        void buttonSave_Click(object sender, EventArgs e)
        {
            object[] transDetail = new object[2];
            transDetail[0] = itemIdTextBox.Text;
            transDetail[1] = quantityNumericUpDown.Value;

            tTransactionDetailDataGridView.Rows.Add(transDetail);

        }

        void buttonAdd_Click(object sender, EventArgs e)
        {
            object[] stockDetail = new object[3];
            stockDetail[0] = stockBarcodeIdTextBox.Text;
            stockDetail[1] = stockLocationTextBox.Text;
            stockDetail[2] = itemIdTextBox.Text;

            tStockDataGridView.Rows.Add(stockDetail);

            quantityNumericUpDown.Value = tStockDataGridView.RowCount;
        }

        void itemIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(itemIdTextBox.Text.Trim()))
            {
                MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemIdTextBox.Text);
                if (item != null)
                    itemNameTextBox.Text = item.ItemName;
            }
        }

        void transactionByTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (trans == ListOfTransaction.Purchase)
                ModuleControlSettings.SupplierValidating(transactionByTextBox.Text, transactionByNameTextBox);
            else if (trans == ListOfTransaction.Sales)
                ModuleControlSettings.CustomerValidating(transactionByTextBox.Text, transactionByNameTextBox);
        }

        void FormTransaction_Load(object sender, EventArgs e)
        {
        }

        private void SetInitialSettings()
        {
            //id
            ModuleControlSettings.SetNumericUpDown(transactionIdNumericUpDown);
            transactionIdNumericUpDown.Value = DateTime.Now.ToFileTime();
            //factur
            transactionFacturTextBox.Text = AppCode.GenerateFacturNo(trans, string.Empty);
            //set date time picker
            ModuleControlSettings.SetDateTimePicker(transactionDateDateTimePicker, false);
            //set numeric up down
            ModuleControlSettings.SetNumericUpDown(quantityNumericUpDown, true);
            //grid view
            ModuleControlSettings.SetGridDataView(tStockDataGridView);
            ModuleControlSettings.SetGridDataView(tTransactionDetailDataGridView);


            //search item
            PictureBox searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicItem_Click);
            itemIdTextBox.Controls.Add(searchPic);

            //search supplier
            searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(transactionByTextBox, ListOfSearchWindow.SearchCustomer.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicTransactionBy_Click);
            transactionByTextBox.Controls.Add(searchPic);


            //title
            string title = string.Empty;
            string transBy = string.Empty;
            if (trans == ListOfTransaction.Sales)
            {
                transBy = "Pelanggan : ";
                title = "Barang Keluar";
            }
            else if (trans == ListOfTransaction.Purchase)
            {
                transBy = "Supplier : ";
                title = "Barang Masuk";
            }
            else if (trans == ListOfTransaction.Correction)
            {
                transBy = "Pemeriksa : ";
                title = "Koreksi Stok";

                groupBox4.Visible = false;
                tStockDataGridView.Visible = false;
                quantityNumericUpDown.Enabled = true;
                quantityNumericUpDown.Minimum = decimal.MinValue;
                groupBox2.Visible = false;
            }

            this.TabText = title;
            Text = title;
            transactionByLabel.Text = transBy;
        }

        void searchPicItem_Click(object sender, EventArgs e)
        {
            OpenFormSearchItem();
        }

        FormSearchItem f_SearchItem;
        private void OpenFormSearchItem()
        {
            if (f_SearchItem != null)
            {
                if (!f_SearchItem.IsDisposed)
                {
                    f_SearchItem.WindowState = FormWindowState.Normal;
                    f_SearchItem.BringToFront();
                }
                else
                    f_SearchItem = new FormSearchItem();
            }
            else
                f_SearchItem = new FormSearchItem();

            f_SearchItem.ItemHasSelected += new EventHandler(f_SearchItem_ItemHasSelected);
            f_SearchItem.lbl_TempTransaction.Text = ListOfTransaction.Correction.ToString();

            f_SearchItem.ShowInTaskbar = false;
            f_SearchItem.ShowDialog();
        }

        private void f_SearchItem_ItemHasSelected(object sender, EventArgs e)
        {
            if (f_SearchItem.grid_Search.Rows.Count > 0)
            {
                itemIdTextBox.Text = f_SearchItem.grid_Search.CurrentRow.Cells[0].Value.ToString();
                itemIdTextBox_Validating(null, null);
            }
        }

        void searchPicTransactionBy_Click(object sender, EventArgs e)
        {
            if (trans == ListOfTransaction.Sales)
                OpenFormSearchCustomer();
            else if (trans == ListOfTransaction.Purchase)
                OpenFormSearchSupplier();
        }

        FormSearchCustomer f_SearchCustomer;
        private void OpenFormSearchCustomer()
        {
            if (f_SearchCustomer != null)
            {
                if (!f_SearchCustomer.IsDisposed)
                {
                    f_SearchCustomer.WindowState = FormWindowState.Normal;
                    f_SearchCustomer.BringToFront();
                }
                else
                    f_SearchCustomer = new FormSearchCustomer();
            }
            else
                f_SearchCustomer = new FormSearchCustomer();

            f_SearchCustomer.CustomerHasSelected += new EventHandler(f_SearchCustomer_CustomerHasSelected);
            f_SearchCustomer.ShowInTaskbar = false;
            f_SearchCustomer.ShowDialog();
        }

        void f_SearchCustomer_CustomerHasSelected(object sender, EventArgs e)
        {
            if (f_SearchCustomer.grid_Search.Rows.Count > 0)
            {
                transactionByTextBox.Text = f_SearchCustomer.grid_Search.CurrentRow.Cells[0].Value.ToString();
                transactionByTextBox_Validating(null, null);
            }
        }

        FormSearchSupplier f_SearchSupplier;
        private void OpenFormSearchSupplier()
        {
            if (f_SearchSupplier != null)
            {
                if (!f_SearchSupplier.IsDisposed)
                {
                    f_SearchSupplier.WindowState = FormWindowState.Normal;
                    f_SearchSupplier.BringToFront();
                }
                else
                    f_SearchSupplier = new FormSearchSupplier();
            }
            else
                f_SearchSupplier = new FormSearchSupplier();

            f_SearchSupplier.SupplierHasSelected += new EventHandler(f_SearchSupplier_SupplierHasSelected);
            f_SearchSupplier.ShowInTaskbar = false;
            f_SearchSupplier.ShowDialog();
        }

        private void f_SearchSupplier_SupplierHasSelected(object sender, EventArgs e)
        {
            if (f_SearchSupplier.grid_Search.Rows.Count > 0)
            {
                transactionByTextBox.Text = f_SearchSupplier.grid_Search.CurrentRow.Cells[0].Value.ToString();
                transactionByTextBox_Validating(null, null);
            }
        }
    }
}