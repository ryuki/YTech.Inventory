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

namespace Inventori.GrosirMitra.Forms
{
    public partial class FormMasterTypeItem : Inventori.Forms.FormParentForMasterForm
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MItemType tipe;

        public FormMasterTypeItem()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItemType.ColumnNames.ItemTypeId;
            grid_Col.HeaderText = "Kode Tipe Barang";
            grid_Master.Columns.Add(grid_Col);
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MItemType.ColumnNames.ItemTypeName;
            grid_Col.HeaderText = "Nama Tipe Barang";
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterTypeItem_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MGroup, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MItemType));
            if (listMaster.Count > 0)
                bindingSource_Master.DataSource = listMaster;

            bindingSource_Master_PositionChanged(null, null);
            detailControl_KeyDown(null, null);
        }

        private void bindingSource_Master_PositionChanged(object sender, EventArgs e)
        {
            SetNavigatorDisplay();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(itemTypeIdLabel1.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    tipe = (MItemType)DataMaster.GetObjectByProperty(typeof(MItemType), MItemType.ColumnNames.ItemTypeId, int.Parse(itemTypeIdLabel1.Text));
                    DataMaster.Delete(tipe);
                    ModuleControlSettings.SaveLog(ListOfAction.Delete, itemTypeNameTextBox.Text, ListOfTable.MGroup, lbl_UserName.Text);
                    BindData();
                }
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (!(itemTypeIdLabel1.Text.Trim().Equals("0") || string.IsNullOrEmpty(itemTypeIdLabel1.Text.Trim())))
                tipe = (MItemType)DataMaster.GetObjectByProperty(typeof(MItemType), MItemType.ColumnNames.ItemTypeId, int.Parse(itemTypeIdLabel1.Text));
            else
                tipe = new MItemType();

            tipe.ItemTypeName = itemTypeNameTextBox.Text;
            tipe.ModifiedBy = lbl_UserName.Text;
            tipe.ModifiedDate = DateTime.Now;

            DataMaster.SaveOrUpdate(tipe);

            ModuleControlSettings.SaveLog(ListOfAction.Update, itemTypeNameTextBox.Text, ListOfTable.MGroup, lbl_UserName.Text);
            BindData();
        }

        private bool ValidateForm()
        {
            RecreateBalloon();
            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(itemTypeNameTextBox.Text))
            {
                balloonHelp.Content = "Nama Tipe Barang harus diisi";
                balloonHelp.ShowBalloon(itemTypeNameTextBox);
                itemTypeNameTextBox.Focus();
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
                itemTypeNameTextBox.Focus();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                Control c = (Control)sender;
                if (sender == itemTypeNameTextBox)
                    bindingNavigatorSaveItem_Click(null, null);

            }
        }
    }
}