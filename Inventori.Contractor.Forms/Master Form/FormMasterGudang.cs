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

namespace Inventori.Contractor.Forms
{
    public partial class FormMasterGudang : Inventori.Forms.FormParentForMasterForm
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MGudang gud;

        public FormMasterGudang()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MGudang.ColumnNames.GudangId;
            grid_Col.HeaderText = "Kode Gudang";
            grid_Master.Columns.Add(grid_Col);
            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MGudang.ColumnNames.GudangName;
            grid_Col.HeaderText = "Nama Gudang";
            grid_Master.Columns.Add(grid_Col);


            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterGudang_Load(object sender, EventArgs e)
        {
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            BindData();
        }


        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MGudang));
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
            if (!string.IsNullOrEmpty(gudangIdLabel1.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    gud = (MGudang)DataMaster.GetObjectByProperty(typeof(MGudang), MGudang.ColumnNames.GudangId, Convert.ToInt32(gudangIdLabel1.Text));
                    DataMaster.Delete(gud);
                    ModuleControlSettings.SaveLog(ListOfAction.Delete, gudangNameTextBox.Text, ListOfTable.MGudang, lbl_UserName.Text);
                    BindData();
                }
            }
        }


        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (!(gudangIdLabel1.Text.Trim().Equals("0") || string.IsNullOrEmpty(gudangIdLabel1.Text.Trim())))
                gud = (MGudang)DataMaster.GetObjectByProperty(typeof(MGudang), MGudang.ColumnNames.GudangId, Convert.ToInt32(gudangIdLabel1.Text));
            else
                gud = new MGudang();

            gud.GudangName = gudangNameTextBox.Text;
            gud.ModifiedBy = lbl_UserName.Text;
            gud.ModifiedDate = DateTime.Now;

            DataMaster.SaveOrUpdate(gud);
            ModuleControlSettings.SaveLog(ListOfAction.Update, gudangNameTextBox.Text, ListOfTable.MGudang, lbl_UserName.Text);
            BindData();

        }

        private bool ValidateForm()
        {
            RecreateBalloon();
            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(gudangNameTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Nama gudang harus diisi";
                balloonHelp.ShowBalloon(gudangNameTextBox);
                gudangNameTextBox.Focus();
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
                gudangNameTextBox.Select();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;
                if (sender == gudangNameTextBox)
                    bindingNavigatorSaveItem_Click(null, null);
            }
        }

    }
}