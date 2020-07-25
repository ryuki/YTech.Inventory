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
    public partial class FormMasterService : Inventori.Forms.FormParentForMasterForm
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MItem item;
        public FormMasterService()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItem.ColumnNames.ItemId;
            grid_Col.HeaderText = "Kode Service";
            grid_Master.Columns.Add(grid_Col);
            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItem.ColumnNames.ItemName;
            grid_Col.HeaderText = "Nama Service";
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
            ModuleControlSettings.SetNumericUpDown(itemPriceMaxNumericUpDown);
        }

        private void FormMasterService_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MItem, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;

            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetListEq(typeof(MItem), MItem.ColumnNames.ItemTypeId, 2);
            if (listMaster.Count > 0)
                bindingSource_Master.DataSource = listMaster;

            bindingSource_Master_PositionChanged(null, null);
            detailControl_KeyDown(null, null);
        }

        private void bindingSource_Master_PositionChanged(object sender, EventArgs e)
        {
            SetNavigatorDisplay();
            itemIdTextBox.Enabled = true;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            itemIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
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

            item.DefaultGudangId = 0;
            item.GroupId = 0;
            item.ItemCommision = decimal.Zero;
            item.ItemDesc = itemDescTextBox.Text;
            item.ItemId = itemIdTextBox.Text;
            item.ItemName = itemNameTextBox.Text;
            item.ItemPriceMax = itemPriceMaxNumericUpDown.Value;
            item.ItemPriceMaxVip = decimal.Zero;
            item.ItemPriceMin = decimal.Zero;
            item.ItemPriceMinVip = decimal.Zero;
            item.ItemPricePurchase = decimal.Zero;
            //item.ItemPricePurchaseAvg
            item.ItemSatuan = string.Empty;
            item.ItemTypeId = 2;
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
                    balloonHelp.Content = "Service dengan kode " + itemIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
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

            if (string.IsNullOrEmpty(itemNameTextBox.Text))
            {
                balloonHelp.Content = "Nama Item harus diisi";
                balloonHelp.ShowBalloon(itemNameTextBox);
                itemNameTextBox.Focus();
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