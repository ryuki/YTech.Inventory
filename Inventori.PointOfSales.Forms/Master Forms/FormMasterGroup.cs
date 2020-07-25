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

namespace Inventori.PointOfSales.Forms
{
    public partial class FormMasterGroup : Inventori.Forms.FormParentForMasterForm
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MGroup group;

        public FormMasterGroup()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MGroup.ColumnNames.GroupId;
            grid_Col.HeaderText = "Kode Golongan Barang";
            grid_Master.Columns.Add(grid_Col);
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MGroup.ColumnNames.GroupName;
            grid_Col.HeaderText = "Nama Golongan Barang";
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterGroup_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MGroup, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MGroup));
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
            if (!string.IsNullOrEmpty(groupIdLabel1.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    group = (MGroup)DataMaster.GetObjectByProperty(typeof(MGroup), MGroup.ColumnNames.GroupId, int.Parse(groupIdLabel1.Text));
                    DataMaster.Delete(group);
                    ModuleControlSettings.SaveLog(ListOfAction.Delete, groupNameTextBox.Text, ListOfTable.MGroup, lbl_UserName.Text);
                    BindData();
                }
            }
        }


        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (!(groupIdLabel1.Text.Trim().Equals("0") || string.IsNullOrEmpty(groupIdLabel1.Text.Trim())))
                group = (MGroup)DataMaster.GetObjectById(typeof(MGroup), Convert.ToInt32(groupIdLabel1.Text));
            else
                group = new MGroup();

            group.GroupName = groupNameTextBox.Text;
            group.ModifiedBy = lbl_UserName.Text;
            group.ModifiedDate = DateTime.Now;

            DataMaster.SaveOrUpdate(group);

            ModuleControlSettings.SaveLog(ListOfAction.Update, groupNameTextBox.Text, ListOfTable.MGroup, lbl_UserName.Text);
            BindData();
        }

        private bool ValidateForm()
        {
            RecreateBalloon();
            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(groupNameTextBox.Text))
            {
                balloonHelp.Content = "Nama Golongan Barang harus diisi";
                balloonHelp.ShowBalloon(groupNameTextBox);
                groupNameTextBox.Focus();
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
                groupNameTextBox.Focus();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                Control c = (Control)sender;
                if (sender == groupNameTextBox)
                    bindingNavigatorSaveItem_Click(null, null);

            }
        }
    }
}

