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
using Inventori.Forms;

namespace Inventori.Dealer.Forms
{
    public partial class FormStockAwal : FormParentForDealer
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();

        public FormStockAwal()
        {
            InitializeComponent();
        }

        private void FormStockAwal_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IsUpdate", typeof(bool));
            dt.Columns.Add("ItemId", typeof(string));
            dt.Columns.Add("ItemName", typeof(string));
            dt.Columns.Add("CurrentItemStok", typeof(decimal));
            dt.Columns.Add("ItemStok", typeof(decimal));

            DataRow dr;

            IList listItem = DataMaster.GetAll(typeof(MItem));
            MItem item;
            ItemGudangStok stok;
            for (int i = 0; i < listItem.Count; i++)
            {
                item = (MItem)listItem[i];
                dr = dt.NewRow();
                dr[0] = false;
                dr[1] = item.ItemId;
                dr[2] = item.ItemName;
                stok = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, item.ItemId);
                if (stok != null)
                {
                    dr[3] = stok.ItemStok;
                    dr[4] = stok.ItemStok;
                }
                else
                {
                    dr[3] = 0;
                    dr[4] = 0;
                }
                dt.Rows.Add(dr);
            }
            itemGudangStokDataGridView.DataSource = dt;
            itemGudangStokDataGridView.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin menyimpan data?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            decimal stokItem = 0;
            string itemId;
            int gudangId = 1;
            ItemGudangStok stok;
            bool isUpdate = false;
            for (int i = 0; i < itemGudangStokDataGridView.RowCount; i++)
            {
                isUpdate = Convert.ToBoolean(itemGudangStokDataGridView.Rows[i].Cells[0].Value);
                if (isUpdate)
                {
                    itemId = itemGudangStokDataGridView.Rows[i].Cells[1].Value.ToString();
                    stokItem = Convert.ToDecimal(itemGudangStokDataGridView.Rows[i].Cells[4].Value);
                    stok = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, itemId, ItemGudangStok.ColumnNames.GudangId, gudangId);
                    if (stok == null)
                    {
                        stok = new ItemGudangStok();
                        stok.GudangId = gudangId;
                        stok.ItemId = itemId;
                        stok.ItemMaxStok = 0;
                        stok.ItemMinStok = 0;
                        stok.ItemStok = stokItem;
                        stok.ModifiedBy = lbl_UserName.Text;
                        stok.ModifiedDate = DateTime.Now;
                        DataMaster.SavePersistence(stok);
                    }
                    else
                    {
                        stok.ItemStok = stokItem;
                        stok.ModifiedBy = lbl_UserName.Text;
                        stok.ModifiedDate = DateTime.Now;
                        DataMaster.UpdatePersistence(stok);
                    }

                    TStokCard krt = new TStokCard();
                    krt.ItemId = itemId;
                    krt.GudangId = gudangId;
                    krt.StokCardDate = DateTime.Today;
                    krt.StokCardPic = "Saldo Awal";
                    krt.StokCardQuantity = stokItem;
                    krt.StokCardSaldo = stokItem;
                    krt.StokCardStatus = true;
                    krt.TransactionId = 0;
                    krt.ModifiedBy = lbl_UserName.Text;
                    krt.ModifiedDate = DateTime.Now;
                    DataMaster.SavePersistence(krt);
                }

            }

            MessageBox.Show("Stok Awal barang berhasil disimpan", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}