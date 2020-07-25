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
    public partial class FormMasterItem : Inventori.Forms.FormParentForMasterForm
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MItem item;

        public FormMasterItem()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItem.ColumnNames.ItemId;
            grid_Col.HeaderText = "Kode Item";
            grid_Master.Columns.Add(grid_Col);
            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItem.ColumnNames.ItemName;
            grid_Col.HeaderText = "Nama Item";
            grid_Master.Columns.Add(grid_Col);
            //add kolom satuan
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItem.ColumnNames.ItemSatuan;
            grid_Col.HeaderText = "Satuan";
            grid_Master.Columns.Add(grid_Col);
            //add kolom harga per satuan
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItem.ColumnNames.ItemPricePurchase;
            grid_Col.HeaderText = "Harga Per Satuan";
            grid_Master.Columns.Add(grid_Col);
            //add kolom harga jual
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItem.ColumnNames.ItemPriceMax;
            grid_Col.HeaderText = "Harga Jual";
            grid_Master.Columns.Add(grid_Col);
            //add kolom harga jual VIP
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItem.ColumnNames.ItemId;
            grid_Col.HeaderText = "Harga Jual VIP";
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterItem_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SetGudangComboBox(defaultGudangIdComboBox);
            ModuleControlSettings.SetTypeItemComboBox(itemTypeIdComboBox);
            ModuleControlSettings.SetGroupComboBox(groupIdComboBox);

            BindData();
        }

        private void BindData()
        {
            bindingSource_Master.Clear();
            IList listMaster = DataMaster.GetAll(typeof(MItem));
            if (listMaster.Count > 0)
                bindingSource_Master.DataSource = listMaster;

            bindingSource_Master_PositionChanged(null, null);
            detailControl_KeyDown(null, null);
        }

        private void bindingSource_Master_PositionChanged(object sender, EventArgs e)
        {
            itemIdTextBox.Enabled = true;
            itemStokLabel.Text = "Stok Item";

            itemGudangStokBindingSource.Clear();
            IList liststok = DataMaster.GetListEq(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, itemIdTextBox.Text, ItemGudangStok.ColumnNames.GudangId, 1);
            if (liststok.Count > 0)
                itemGudangStokBindingSource.DataSource = liststok;

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            itemIdTextBox.Enabled = true;

            itemMaxStokTextBox.ResetText();
            itemMinStokTextBox.ResetText();
            itemStokTextBox.ResetText();

            itemStokTextBox.Enabled = true;
            itemStokLabel.Text = "Stok Awal";
            itemTypeIdComboBox.Enabled = true;

            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            itemIdTextBox.Enabled = false;

            itemStokTextBox.Enabled = false;
            itemStokLabel.Text = "Stok Item";
            itemTypeIdComboBox.Enabled = false;

            itemTypeIdComboBox_SelectedIndexChanged(null, null);
            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(itemIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(itemIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    item = (MItem)DataMaster.GetObjectById(typeof(MItem), itemIdTextBox.Text);
                    DataMaster.Delete(item);

                    ItemGudangStok stok = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, itemIdTextBox.Text, ItemGudangStok.ColumnNames.GudangId, defaultGudangIdComboBox.SelectedValue);
                    DataMaster.Delete(stok);

                }
            }
        }


        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (itemIdTextBox.Enabled == true)
                item = new MItem();
            else
                item = (MItem)DataMaster.GetObjectById(typeof(MItem), itemIdTextBox.Text);

            item.ItemId = itemIdTextBox.Text;
            item.ItemName = itemNameTextBox.Text;
            //item.DefaultGudangId = Convert.ToInt32(defaultGudangIdComboBox.SelectedValue);
            item.DefaultGudangId = 1;

            item.GroupId = Convert.ToInt32(groupIdComboBox.SelectedValue);
            //item.ItemCommision = Convert.ToDecimal(itemCommisionTextBox.Text);
            item.ItemCommision = 0;

            item.ItemDesc = itemDescTextBox.Text;
            item.ItemPriceMax = Convert.ToDecimal(itemPriceMaxTextBox.Text);
            item.ItemPriceMaxVip = Convert.ToDecimal(itemPriceMaxVipTextBox.Text);
            //item.ItemPriceMin = Convert.ToDecimal(itemPriceMinTextBox.Text);
            //item.ItemPriceMinVip = Convert.ToDecimal(itemPriceMinVipTextBox.Text);
            item.ItemPriceMin = 0;
            item.ItemPriceMinVip = 0;

            item.ItemSatuan = itemSatuanTextBox.Text;
            item.ItemTypeId = Convert.ToInt32(itemTypeIdComboBox.SelectedValue);
            item.ItemPricePurchase = Convert.ToDecimal(itemPricePurchaseTextBox.Text);

            if (itemIdTextBox.Enabled == true)
                try
                {
                    DataMaster.SavePersistence(item);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Item dengan kode " + itemIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
                    balloonHelp.ShowBalloon(itemIdTextBox);
                    itemIdTextBox.Focus();
                    return;
                }
            else
                DataMaster.UpdatePersistence(item);


            ItemGudangStok stok;

            if (itemIdTextBox.Enabled == true)
                stok = new ItemGudangStok();
            else
                stok = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, itemIdTextBox.Text);

            stok.ItemId = itemIdTextBox.Text;
            //stok.GudangId = Convert.ToInt32(defaultGudangIdComboBox.SelectedValue);
            stok.GudangId = 1;
            //if type == barang
            if (groupBox2.Enabled == true)
            {
                stok.ItemMaxStok = Convert.ToDecimal(itemMaxStokTextBox.Text);
                stok.ItemMinStok = Convert.ToDecimal(itemMinStokTextBox.Text);
                stok.ItemStok = Convert.ToDecimal(itemStokTextBox.Text);
            }
            else
            {
                stok.ItemMaxStok = 0;
                stok.ItemMinStok = 0;
                stok.ItemStok = 0;
            }

            if (itemIdTextBox.Enabled == true)
                DataMaster.SavePersistence(stok);
            else
                DataMaster.UpdatePersistence(stok);

            BindData();
        }

        private bool ValidateForm()
        {
            RecreateBalloon();
            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(itemIdTextBox.Text))
            {
                balloonHelp.Content = "Kode Item harus diisi";
                balloonHelp.ShowBalloon(itemIdTextBox);
                itemIdTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(itemNameTextBox.Text))
            {
                balloonHelp.Content = "Nama Item harus diisi";
                balloonHelp.ShowBalloon(itemNameTextBox);
                itemNameTextBox.Focus();
                return false;
            }
            else if (itemTypeIdComboBox.SelectedIndex == -1)
            {
                balloonHelp.Content = "Pilih Tipe Item";
                balloonHelp.ShowBalloon(itemTypeIdComboBox);
                itemTypeIdComboBox.Focus();
                return false;
            }
            else if (groupIdComboBox.SelectedIndex == -1)
            {
                balloonHelp.Content = "Pilih Golongan Item";
                balloonHelp.ShowBalloon(groupIdComboBox);
                groupIdComboBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(itemPricePurchaseTextBox.Text))
            {
                balloonHelp.Content = "Harga Persatuan harus diisi";
                balloonHelp.ShowBalloon(itemPricePurchaseTextBox);
                itemPricePurchaseTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(itemPriceMaxTextBox.Text))
            {
                balloonHelp.Content = "Harga Jual harus diisi";
                balloonHelp.ShowBalloon(itemPriceMaxTextBox);
                itemPriceMaxTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(itemPriceMaxVipTextBox.Text))
            {
                balloonHelp.Content = "Harga VIP harus diisi";
                balloonHelp.ShowBalloon(itemPriceMaxVipTextBox);
                itemPriceMaxVipTextBox.Focus();
                return false;
            }

            if (groupBox2.Enabled)
            {
                if (string.IsNullOrEmpty(itemMaxStokTextBox.Text))
                {
                    balloonHelp.Content = "Stok maksimal harus diisi";
                    balloonHelp.ShowBalloon(itemMaxStokTextBox);
                    itemMaxStokTextBox.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(itemMinStokTextBox.Text))
                {
                    balloonHelp.Content = "Stok minimum harus diisi";
                    balloonHelp.ShowBalloon(itemMinStokTextBox);
                    itemMinStokTextBox.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(itemStokTextBox.Text))
                {
                    balloonHelp.Content = "Stok item harus diisi";
                    balloonHelp.ShowBalloon(itemStokTextBox);
                    itemStokTextBox.Focus();
                    return false;
                }

            }
            return true;
        }

        private void bindingNavigatorRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void detailControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender == null)
                itemIdTextBox.Focus();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                Control c = (Control)sender;
                if (sender == itemIdTextBox)
                    itemNameTextBox.Focus();
                else if (sender == itemNameTextBox)
                {
                    if (itemTypeIdComboBox.Enabled)
                        itemTypeIdComboBox.Focus();
                    else
                        groupIdComboBox.Focus();
                }
                else if (sender == itemTypeIdComboBox)
                    groupIdComboBox.Focus();
                else if (sender == groupIdComboBox)
                    itemSatuanTextBox.Focus();
                else if (sender == itemSatuanTextBox)
                    itemPricePurchaseTextBox.Focus();
                else if (sender == itemPricePurchaseTextBox)
                    itemPriceMaxTextBox.Focus();
                else if (sender == itemPriceMaxTextBox)
                    itemPriceMaxVipTextBox.Focus();
                else if (sender == itemPriceMaxVipTextBox)
                    itemDescTextBox.Focus();
                else if (sender == itemDescTextBox)
                {
                    if (!groupBox2.Enabled)
                        bindingNavigatorSaveItem_Click(null, null);
                    else
                        itemMaxStokTextBox.Focus();
                }
                else if (sender == itemMaxStokTextBox)
                    itemMinStokTextBox.Focus();
                else if (sender == itemMinStokTextBox)
                {
                    if (!itemStokTextBox.Enabled)
                        bindingNavigatorSaveItem_Click(null, null);
                    else
                        itemStokTextBox.Focus();
                }
                else if (sender == itemStokTextBox)
                    bindingNavigatorSaveItem_Click(null, null);
            }
        }

        private void itemTypeIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemTypeIdComboBox.SelectedIndex > -1)
                groupBox2.Enabled = (itemTypeIdComboBox.SelectedIndex == 0);
        }
    }
}

