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

namespace Inventori.MotorKymco.Forms
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
            grid_Col.HeaderText = "Harga Beli";
            grid_Col.DefaultCellStyle.Format = "N";
            grid_Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grid_Master.Columns.Add(grid_Col);

            //add kolom harga per jual
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItem.ColumnNames.ItemPriceMax;
            grid_Col.HeaderText = "Harga Jual";
            grid_Col.DefaultCellStyle.Format = "N";
            grid_Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);

            //set numeric updown
            ModuleControlSettings.SetNumericUpDown(itemPricePurchaseNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(itemPriceMaxNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(itemPricePurchaseAvgNumericUpDown, true);
        }

        private void FormMasterItem_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MItem, lbl_UserName.Text);
            CreateGudangTabPage();
            grid_Master.DataSource = bindingSource_Master;
            ModuleControlSettings.SetGroupComboBox(groupIdComboBox);

            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetListEq(typeof(MItem),MItem.ColumnNames.ItemTypeId,1);
            if (listMaster.Count > 0)
                bindingSource_Master.DataSource = listMaster;

            bindingSource_Master_PositionChanged(null, null);
            detailControl_KeyDown(null, null);
        }

        private void CreateGudangTabPage()
        {
            tabControl_Gudang.TabPages.Clear();

            IList listGudang = DataMaster.GetAll(typeof(MGudang));
            MGudang gud;
            TabPage tab;
            Label lbl;
            NumericUpDown num;
            TextBox txt;

            for (int i = 0; i < listGudang.Count; i++)
            {
                gud = (MGudang)listGudang[i];
                tab = new TabPage();
                tab.Name = "tabpages_" + gud.GudangId.ToString();
                tab.Text = gud.GudangName;
                tab.UseVisualStyleBackColor = true;

                //add label gudang
                lbl = new Label();
                lbl.Text = "Lokasi";
                lbl.AutoSize = true;
                lbl.Location = new Point(17, 14);
                tab.Controls.Add(lbl);

                //add label gudang
                lbl = new Label();
                lbl.Name = "label_gudang_" + gud.GudangId.ToString();
                lbl.Text = gud.GudangName;
                lbl.AutoSize = true;
                lbl.Location = new Point(110, 14);
                tab.Controls.Add(lbl);

                //add label Stok Maksimal
                lbl = new Label();
                lbl.Text = "Stok Maksimal";
                lbl.AutoSize = true;
                lbl.Location = new Point(17, 38);
                tab.Controls.Add(lbl);

                //add numeric maks stok
                num = new NumericUpDown();
                num.Name = "num_maks_stok_" + gud.GudangId.ToString();
                num.Location = new Point(113, 36);
                ModuleControlSettings.SetNumericUpDown(num);
                num.Minimum = decimal.MinValue;
                tab.Controls.Add(num);

                //add label Stok min
                lbl = new Label();
                lbl.Text = "Stok Minimal";
                lbl.AutoSize = true;
                lbl.Location = new Point(17, 64);
                tab.Controls.Add(lbl);

                //add numeric min stok
                num = new NumericUpDown();
                num.Name = "num_min_stok_" + gud.GudangId.ToString();
                num.Location = new Point(113, 62);
                ModuleControlSettings.SetNumericUpDown(num);
                num.Minimum = decimal.MinValue;
                tab.Controls.Add(num);

                //add label Stok 
                lbl = new Label();
                lbl.Text = "Stok Item";
                lbl.AutoSize = true;
                lbl.Location = new Point(17, 90);
                tab.Controls.Add(lbl);

                //add numeric stok
                num = new NumericUpDown();
                num.Name = "num_stok_" + gud.GudangId.ToString();
                num.Location = new Point(113, 88);
                ModuleControlSettings.SetNumericUpDown(num);
                num.Minimum = decimal.MinValue;
                tab.Controls.Add(num);

                //add label lokasi Stok 
                lbl = new Label();
                lbl.Text = "Nomor Rak :";
                lbl.AutoSize = true;
                lbl.Location = new Point(17, 117);
                tab.Controls.Add(lbl);

                //add textbox nomor rak
                txt = new TextBox();
                txt.Name = "txt_position_" + gud.GudangId.ToString();
                txt.Location = new Point(113, 114);
                txt.Size = new Size(159, 20);
                tab.Controls.Add(txt);

                tabControl_Gudang.TabPages.Add(tab);
            }
        }

        private void bindingSource_Master_PositionChanged(object sender, EventArgs e)
        {
            SetNavigatorDisplay();

            itemIdTextBox.Enabled = true;
            itemStokLabel.Text = "Stok Item";
            SetItemGudangStok(false);
        }

        private void SetItemGudangStok(bool isNew)
        {
            IList listGudang = DataMaster.GetAll(typeof(MGudang));
            MGudang gud;
            TabPage tab;
            NumericUpDown num;
            ItemGudangStok itemGud;
            TextBox txt;

            for (int i = 0; i < listGudang.Count; i++)
            {
                gud = (MGudang)listGudang[i];
                itemGud = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, itemIdTextBox.Text, ItemGudangStok.ColumnNames.GudangId, gud.GudangId);
                if (itemGud == null)
                    itemGud = new ItemGudangStok();

                tab = tabControl_Gudang.TabPages["tabpages_" + gud.GudangId.ToString()];

                //maks stok
                num = (NumericUpDown)tab.Controls["num_maks_stok_" + gud.GudangId.ToString()];
                num.Value = itemGud.ItemMaxStok;

                //min stok
                num = (NumericUpDown)tab.Controls["num_min_stok_" + gud.GudangId.ToString()];
                num.Value = itemGud.ItemMinStok;

                // stok
                num = (NumericUpDown)tab.Controls["num_stok_" + gud.GudangId.ToString()];
                num.Enabled = isNew;
                num.Value = itemGud.ItemStok;

                //nomor rak
                txt = (TextBox)tab.Controls["txt_position_" + gud.GudangId.ToString()];
                txt.Text = itemGud.ItemPosition;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            itemIdTextBox.Enabled = true;

            detailControl_KeyDown(null, null);
            SetItemGudangStok(true);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            itemIdTextBox.Enabled = false;

            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(itemIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(itemIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemIdTextBox.Text);
                    DataMaster.Delete(item);

                    IList listStok = DataMaster.GetListEq(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, itemIdTextBox.Text);
                    ItemGudangStok stok;
                    for (int i = 0; i < listStok.Count; i++)
                    {
                        stok = (ItemGudangStok)listStok[i];
                        if (stok != null)
                            DataMaster.Delete(stok);
                    }
                    ModuleControlSettings.SaveLog(ListOfAction.Delete, itemIdTextBox.Text, ListOfTable.MItem, lbl_UserName.Text);
                    BindData();
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

            item.DefaultGudangId = 1;
            item.GroupId = Convert.ToInt32(groupIdComboBox.SelectedValue);
            item.ItemCommision = decimal.Zero;
            item.ItemDesc = itemDescTextBox.Text;
            item.ItemId = itemIdTextBox.Text;
            item.ItemName = itemNameTextBox.Text;
            item.ItemPriceMax = itemPriceMaxNumericUpDown.Value;
            item.ItemPriceMaxVip = decimal.Zero;
            item.ItemPriceMin = decimal.Zero;
            item.ItemPriceMinVip = decimal.Zero;
            item.ItemPricePurchase = itemPricePurchaseNumericUpDown.Value;

            if (item.ItemPricePurchaseAvg == decimal.Zero)
            {
                item.ItemPricePurchaseAvg = itemPricePurchaseNumericUpDown.Value;
            }
            //
            item.ItemSatuan = itemSatuanTextBox.Text;
            item.ItemTypeId = 1;
            item.SupplierId = string.Empty;
            item.ModifiedBy = lbl_UserName.Text;
            item.ModifiedDate = DateTime.Now;

            if (itemIdTextBox.Enabled == true)
            {
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
                ModuleControlSettings.SaveLog(ListOfAction.Insert, itemIdTextBox.Text, ListOfTable.MItem, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(item);
                ModuleControlSettings.SaveLog(ListOfAction.Update, itemIdTextBox.Text, ListOfTable.MItem, lbl_UserName.Text);
            }

            SaveItemGudangStok();
            BindData();
        }

        private void SaveItemGudangStok()
        {
            IList listGudang = DataMaster.GetAll(typeof(MGudang));
            MGudang gud;
            TabPage tab;
            NumericUpDown num;
            ItemGudangStok itemGud;
            bool isSave = false;
            TextBox txt;

            for (int i = 0; i < listGudang.Count; i++)
            {
                gud = (MGudang)listGudang[i];
                itemGud = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, itemIdTextBox.Text, ItemGudangStok.ColumnNames.GudangId, gud.GudangId);
                if (itemGud == null)
                {
                    itemGud = new ItemGudangStok();
                    isSave = true;
                }
                else
                    isSave = false;

                tab = tabControl_Gudang.TabPages["tabpages_" + gud.GudangId.ToString()];

                //maks stok
                num = (NumericUpDown)tab.Controls["num_maks_stok_" + gud.GudangId.ToString()];
                itemGud.ItemMaxStok = num.Value;

                //min stok
                num = (NumericUpDown)tab.Controls["num_min_stok_" + gud.GudangId.ToString()];
                itemGud.ItemMinStok = num.Value;

                // stok
                num = (NumericUpDown)tab.Controls["num_stok_" + gud.GudangId.ToString()];
                itemGud.ItemStok = num.Value;

                //nomor rak
                txt = (TextBox)tab.Controls["txt_position_" + gud.GudangId.ToString()];
                itemGud.ItemPosition = txt.Text;

                itemGud.GudangId = gud.GudangId;
                itemGud.ItemId = itemIdTextBox.Text;
                itemGud.ModifiedBy = lbl_UserName.Text;
                itemGud.ModifiedDate = DateTime.Now;

                if (isSave)
                    DataMaster.SavePersistence(itemGud);
                else
                    DataMaster.UpdatePersistence(itemGud);
            }
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

            if (string.IsNullOrEmpty(itemNameTextBox.Text))
            {
                balloonHelp.Content = "Nama Item harus diisi";
                balloonHelp.ShowBalloon(itemNameTextBox);
                itemNameTextBox.Focus();
                return false;
            }

            if (groupIdComboBox.SelectedIndex == -1)
            {
                balloonHelp.Content = "Pilih Golongan Item";
                balloonHelp.ShowBalloon(groupIdComboBox);
                groupIdComboBox.Focus();
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
            if (sender == null)
                itemIdTextBox.Select();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                //if (sender == itemIdTextBox)
                //    itemNameTextBox.Select();
                //else if (sender == itemNameTextBox)
                //{
                //    if (itemTypeIdComboBox.Enabled)
                //        itemTypeIdComboBox.Select();
                //    else
                //        groupIdComboBox.Select();
                //}
                //else if (sender == itemTypeIdComboBox)
                //    groupIdComboBox.Select();
                //else if (sender == groupIdComboBox)
                //    itemSatuanTextBox.Select();
                //else if (sender == itemSatuanTextBox)
                //    itemPricePurchaseNumericUpDown.Select();
                //else if (sender == itemPricePurchaseNumericUpDown)
                //    itemDescTextBox.Select();
                //else if (sender == itemDescTextBox)
                //{
                //    if (!tabControl_Gudang.Enabled)
                //        bindingNavigatorSaveItem_Click(null, null);
                //    else
                //        itemMaxStokNumericUpDown.Select();
                //}
                //else if (sender == itemMaxStokNumericUpDown)
                //    itemMinStokNumericUpDown.Select();
                //else if (sender == itemMinStokNumericUpDown)
                //{
                //    if (!itemStokNumericUpDown.Enabled)
                //        bindingNavigatorSaveItem_Click(null, null);
                //    else
                //        itemStokNumericUpDown.Select();
                //}
                //else if (sender == itemStokNumericUpDown)
                //    bindingNavigatorSaveItem_Click(null, null);
            }
        }
    }
}