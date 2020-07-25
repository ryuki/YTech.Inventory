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
    public partial class FormMasterDesk : Inventori.Forms.FormParentForMasterForm
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MDesk desk;

        public FormMasterDesk()
        {
            InitializeComponent();
            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MDesk.ColumnNames.DeskId;
            grid_Col.HeaderText = "Kode Meja";
            grid_Master.Columns.Add(grid_Col);
            //add kolom status
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MDesk.ColumnNames.DeskStatus;
            grid_Col.HeaderText = "Status Meja";
            grid_Master.Columns.Add(grid_Col);
            //add kolom keterangan
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MDesk.ColumnNames.DeskDesc;
            grid_Col.HeaderText = "Keterangan";
            grid_Master.Columns.Add(grid_Col);


            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterDesk_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SetDeskStatusComboBox(bilStatusComboBox);
            BindData();
        }

        private void BindData()
        {
            bindingSource_Master.Clear();
            IList listMaster = DataMaster.GetAllSortBy(typeof(MDesk), MDesk.ColumnNames.DeskOrder, "ASC");
            if (listMaster.Count > 0)
                bindingSource_Master.DataSource = listMaster;

            bindingSource_Master_PositionChanged(null, null);
            detailControl_KeyDown(null, null);
        }

        private void bindingSource_Master_PositionChanged(object sender, EventArgs e)
        {
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            bilIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            bilIdTextBox.Enabled = false;
            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(bilIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(bilIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    desk = (MDesk)DataMaster.GetObjectById(typeof(MDesk), bilIdTextBox.Text);
                    DataMaster.Delete(desk);
                    BindData();

                }
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (bilIdTextBox.Enabled == true)
                desk = new MDesk();
            else
                desk = (MDesk)DataMaster.GetObjectById(typeof(MDesk), bilIdTextBox.Text);

            desk.DeskDesc = bilDescTextBox.Text;
            desk.DeskId = bilIdTextBox.Text;
            desk.DeskStatus = bilStatusComboBox.SelectedItem.ToString();
            desk.DeskOrder = Convert.ToInt32(bilOrderNumericUpDown.Value);
            if (bilIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(desk);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Nomor meja " + bilIdTextBox.Text + " sudah pernah diinput, silahkan input dengan nomor yang lain";
                    balloonHelp.ShowBalloon(bilIdTextBox);
                    bilIdTextBox.Focus();
                    return;
                }
            }
            else
                DataMaster.UpdatePersistence(desk);

            BindData();
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(bilIdTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Nomor meja harus diisi";
                balloonHelp.ShowBalloon(bilIdTextBox);
                bilIdTextBox.Focus();
                return false;
            }
            else if (bilStatusComboBox.SelectedIndex == -1)
            {
                balloonHelp.Content = "Pilih status meja";
                balloonHelp.ShowBalloon(bilStatusComboBox);
                bilStatusComboBox.Focus();
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
                bilIdTextBox.Focus();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                Control c = (Control)sender;
                if (sender == bilIdTextBox)
                    bilStatusComboBox.Focus();
                else if (sender == bilStatusComboBox)
                    bilOrderNumericUpDown.Focus();
                else if (sender == bilOrderNumericUpDown)
                    bilDescTextBox.Focus();
                else if (sender == bilDescTextBox)
                    bindingNavigatorSaveItem_Click(null, null);

            }

        }

    }
}

