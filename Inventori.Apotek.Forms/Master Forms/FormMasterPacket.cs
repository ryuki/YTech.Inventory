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

namespace Inventori.Apotek.Forms
{
    public partial class FormMasterPacket : Inventori.Forms.FormParentForMasterForm
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MPacket paket;

        public FormMasterPacket()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MPacket.ColumnNames.PacketId;
            grid_Col.HeaderText = "Kode Obat Puyer";
            grid_Master.Columns.Add(grid_Col);

            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MPacket.ColumnNames.PacketName;
            grid_Col.HeaderText = "Nama Obat Puyer";
            grid_Master.Columns.Add(grid_Col);


            //add kolom harga
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MPacket.ColumnNames.PacketPrice;
            grid_Col.DefaultCellStyle.Format = "N";
            grid_Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grid_Col.HeaderText = "Harga";
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);

            //set numeric up down
            ModuleControlSettings.SetNumericUpDown(numericUpDown_PacketItemPriceTotal, true);
            ModuleControlSettings.SetNumericUpDown(packetPriceNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(packetDiscountNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(packetItemQuantityNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(itemPricePurchaseNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(jumlahNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(packetPriceAvgNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(itemPricePurchaseAvgNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(itemPricePurchaseAvgTotalNumericUpDown, true);            

            packetPriceNumericUpDown.Minimum = decimal.MinValue;

            //search item
            PictureBox searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchItemPic_Click);
            itemIdTextBox.Controls.Add(searchPic);
        }

        void searchItemPic_Click(object sender, EventArgs e)
        {
            OpenFormSearchItem();
        }

        private void FillGridPacketItem()
        {
            mPacketItemDataGridView.Rows.Clear();

            IList listItemPaket = DataMaster.GetListEq(typeof(MPacketItem), MPacketItem.ColumnNames.PacketId, packetIdTextBox.Text);
            MPacketItem paketItem;
            MItem item;
            object[] paketitemRow;
            string itemName = string.Empty;
            decimal itemPrice, itemPriceTot;

            for (int i = 0; i < listItemPaket.Count; i++)
            {
                paketItem = (MPacketItem)listItemPaket[i];
                item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, paketItem.ItemId);
                if (item != null)
                {
                    itemName = item.ItemName;
                    itemPrice = item.ItemPricePurchase;
                }
                else
                {
                    itemName = string.Empty;
                    itemPrice = decimal.Zero;
                }

                itemPriceTot = itemPrice * paketItem.PacketItemQuantity;
                paketitemRow = new object[5];
                paketitemRow[0] = paketItem.ItemId;
                paketitemRow[1] = itemName;
                paketitemRow[2] = paketItem.PacketItemQuantity;
                paketitemRow[3] = itemPrice;
                paketitemRow[4] = itemPriceTot;
                mPacketItemDataGridView.Rows.Add(paketitemRow);

            }
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
            f_SearchItem.lbl_TempTransaction.Text = ListOfTransaction.Purchase.ToString();

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

        private void FormMasterPacket_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MPacket, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MPacket));
            if (listMaster.Count > 0)
                bindingSource_Master.DataSource = listMaster;

            bindingSource_Master_PositionChanged(null, null);
            detailControl_KeyDown(null, null);
        }

        private void bindingSource_Master_PositionChanged(object sender, EventArgs e)
        {
            SetNavigatorDisplay();
            ResetPacketItem();
            FillGridPacketItem();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            packetIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            packetIdTextBox.Enabled = false;
            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(packetIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(packetIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //delete paket
                    paket = (MPacket)DataMaster.GetObjectByProperty(typeof(MPacket), MPacket.ColumnNames.PacketId, packetIdTextBox.Text);
                    DataMaster.Delete(paket);

                    //delete item paket
                    DeleteItemPacket();

                    ModuleControlSettings.SaveLog(ListOfAction.Delete, packetIdTextBox.Text, ListOfTable.MPacket, lbl_UserName.Text);
                    BindData();

                }
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (packetIdTextBox.Enabled == true)
                paket = new MPacket();
            else
                paket = (MPacket)DataMaster.GetObjectByProperty(typeof(MPacket), MPacket.ColumnNames.PacketId, packetIdTextBox.Text);

            paket.PacketId = packetIdTextBox.Text;
            paket.PacketName = packetNameTextBox.Text;
            paket.PacketDiscount = packetDiscountNumericUpDown.Value;
            paket.PacketPrice = packetPriceNumericUpDown.Value;
            paket.PacketPriceAvg = packetPriceAvgNumericUpDown.Value;
            paket.PacketDesc = packetDescTextBox.Text;
            paket.ModifiedBy = lbl_UserName.Text;
            paket.ModifiedDate = DateTime.Now;

            if (packetIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(paket);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Obat puyer dengan kode " + packetIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
                    balloonHelp.ShowBalloon(packetIdTextBox);
                    packetIdTextBox.Focus();
                    return;
                }
                ModuleControlSettings.SaveLog(ListOfAction.Insert, packetIdTextBox.Text, ListOfTable.MPacket, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(paket);
                ModuleControlSettings.SaveLog(ListOfAction.Update, packetIdTextBox.Text, ListOfTable.MPacket, lbl_UserName.Text);
            }
            DeleteItemPacket();
            SaveItemPacket();
            BindData();
        }

        private void SaveItemPacket()
        {
            MPacketItem paketItem;
            for (int i = 0; i < mPacketItemDataGridView.RowCount; i++)
            {
                paketItem = new MPacketItem();
                paketItem.ItemId = mPacketItemDataGridView.Rows[i].Cells[0].Value.ToString();
                paketItem.PacketId = packetIdTextBox.Text;
                paketItem.PacketItemQuantity = Convert.ToDecimal(mPacketItemDataGridView.Rows[i].Cells[2].Value);
                paketItem.ModifiedBy = lbl_UserName.Text;
                paketItem.ModifiedDate = DateTime.Now;
                DataMaster.SavePersistence(paketItem);
            }
        }

        private void DeleteItemPacket()
        {
            //delete item paket
            IList listItemPaket = DataMaster.GetListEq(typeof(MPacketItem), MPacketItem.ColumnNames.PacketId, packetIdTextBox.Text);
            MPacketItem paketItem;

            for (int i = 0; i < listItemPaket.Count; i++)
            {
                paketItem = (MPacketItem)listItemPaket[i];
                DataMaster.Delete(paketItem);
            }
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(packetIdTextBox.Text))
            {
                balloonHelp.Content = "Kode obat puyer harus diisi";
                balloonHelp.ShowBalloon(packetIdTextBox);
                packetIdTextBox.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(packetNameTextBox.Text))
            {
                balloonHelp.Content = "Nama obat puyer harus diisi";
                balloonHelp.ShowBalloon(packetNameTextBox);
                packetNameTextBox.Focus();
                return false;
            }

            if (mPacketItemDataGridView.RowCount == 0)
            {
                balloonHelp.Content = "Daftar obat untuk obat puyer harus diisi minimal 1 jenis obat !!";
                balloonHelp.ShowBalloon(mPacketItemDataGridView);
                mPacketItemDataGridView.Focus();
                return false;
            }
            return true;
        }

        private void bindingNavigatorRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void detailControl_KeyDown(object sender, KeyEventArgs e)
        {
            //if (sender == null)
            //    customerIdTextBox.Focus();
            //else
            //{
            //    if (e == null)
            //        return;

            //    if (e.KeyCode != Keys.Enter)
            //        return;

            //    Control c = (Control)sender;
            //    if (sender == customerIdTextBox)
            //        customerNameTextBox.Focus();
            //    else if (sender == customerNameTextBox)
            //        customerPhoneTextBox.Focus();
            //    else if (sender == customerPhoneTextBox)
            //        customerAddressTextBox.Focus();
            //    else if (sender == customerAddressTextBox)
            //        bindingNavigatorSaveItem_Click(null, null);
            //}

        }

        private void itemIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(itemIdTextBox.Text.Trim()))
            {
                MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemIdTextBox.Text);

                if (item != null)
                {
                    itemNameTextBox.Text = item.ItemName;
                    itemPricePurchaseNumericUpDown.Value = item.ItemPricePurchase;
                    itemPricePurchaseAvgNumericUpDown.Value = item.ItemPricePurchaseAvg;
                }
                else
                {
                    itemNameTextBox.ResetText();
                    itemPricePurchaseNumericUpDown.Value = decimal.Zero;
                    itemPricePurchaseAvgNumericUpDown.Value = decimal.Zero;
                }
            }
        }

        private void CalculateTotal(object sender, EventArgs e)
        {
            jumlahNumericUpDown.Value = itemPricePurchaseNumericUpDown.Value * packetItemQuantityNumericUpDown.Value;

            itemPricePurchaseAvgTotalNumericUpDown.Value = itemPricePurchaseAvgNumericUpDown.Value * packetItemQuantityNumericUpDown.Value;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (!ValidatePacketItem())
                return;

            object[] paketitem = new object[6];
            paketitem[0] = itemIdTextBox.Text;
            paketitem[1] = itemNameTextBox.Text;
            paketitem[2] = packetItemQuantityNumericUpDown.Value;
            paketitem[3] = itemPricePurchaseNumericUpDown.Value;
            paketitem[4] = jumlahNumericUpDown.Value;
            paketitem[5] = itemPricePurchaseAvgTotalNumericUpDown.Value;
            mPacketItemDataGridView.Rows.Add(paketitem);

            ResetPacketItem();
        }

        private void ResetPacketItem()
        {
            itemIdTextBox.ResetText();
            itemNameTextBox.ResetText();
            packetItemQuantityNumericUpDown.Value = decimal.One;
            itemPricePurchaseNumericUpDown.Value = decimal.Zero;
            jumlahNumericUpDown.Value = decimal.Zero;
        }

        private bool ValidatePacketItem()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(itemIdTextBox.Text))
            {
                balloonHelp.Content = "Obat harus diisi !!";
                balloonHelp.ShowBalloon(itemIdTextBox);
                itemIdTextBox.Focus();
                return false;
            }
            else
            {
                MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemIdTextBox.Text);
                if (item == null)
                {
                    balloonHelp.Content = "Obat " + itemIdTextBox.Text + " tidak ada dalam database. \n Pastikan anda menulis kode yang tepat atau \n pilih item dengan mengklik gambar disamping untuk mencari Obat.";
                    balloonHelp.ShowBalloon(itemIdTextBox);
                    itemIdTextBox.Focus();
                    return false;
                }
            }

            if (packetItemQuantityNumericUpDown.Value == 0)
            {
                balloonHelp.Content = "Kuantitas tidak boleh 0 !!";
                balloonHelp.ShowBalloon(packetItemQuantityNumericUpDown);
                packetItemQuantityNumericUpDown.Focus();
                return false;
            }
            return true;
        }

        private void mPacketItemDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculatePcketItemTotal();
        }

        private void mPacketItemDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculatePcketItemTotal();
        }

        private void CalculatePcketItemTotal()
        {
            decimal tot = decimal.Zero;
            decimal totAvg = decimal.Zero;

            for (int i = 0; i < mPacketItemDataGridView.RowCount; i++)
            {
                tot += Convert.ToDecimal(mPacketItemDataGridView.Rows[i].Cells[4].Value);
                totAvg += Convert.ToDecimal(mPacketItemDataGridView.Rows[i].Cells[5].Value);
            }

            numericUpDown_PacketItemPriceTotal.Value = tot;
            packetPriceAvgNumericUpDown.Value = totAvg;
        }

        private void CalculatePacketPrice(object sender, EventArgs e)
        {
            packetPriceNumericUpDown.Value = numericUpDown_PacketItemPriceTotal.Value - packetDiscountNumericUpDown.Value;
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (mPacketItemDataGridView.RowCount > 0)
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (mPacketItemDataGridView.CurrentRow.Index != -1)
                        mPacketItemDataGridView.Rows.RemoveAt(mPacketItemDataGridView.CurrentRow.Index);
                    else
                        mPacketItemDataGridView.Rows.RemoveAt(0);

                    ResetPacketItem();
                }
            }
        }

        private void itemIdTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), true);
        }

        private void itemIdTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), false);
        }
    }
}