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

namespace Inventori.Apotek.Forms
{
    public partial class FormMasterRoom : Inventori.Forms.FormParentForMasterForm
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MRoom room;

        public FormMasterRoom()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MRoom.ColumnNames.RoomId;
            grid_Col.HeaderText = "Kode Ruangan";
            grid_Master.Columns.Add(grid_Col);

            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MRoom.ColumnNames.RoomName;
            grid_Col.HeaderText = "Nama Ruangan";
            grid_Master.Columns.Add(grid_Col);

            //add kolom komisi
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MRoom.ColumnNames.RoomComission;
            grid_Col.HeaderText = "Komisi";
            grid_Master.Columns.Add(grid_Col);


            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterRoom_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MBank, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MRoom));
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
            roomIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            roomIdTextBox.Enabled = false;

            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(roomIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(roomIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    room = (MRoom)DataMaster.GetObjectByProperty(typeof(MRoom), MRoom.ColumnNames.RoomId, roomIdTextBox.Text);
                    DataMaster.Delete(room);

                    ModuleControlSettings.SaveLog(ListOfAction.Delete, roomIdTextBox.Text, ListOfTable.MRoom, lbl_UserName.Text);

                    BindData();
                }
            }
        }
        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (roomIdTextBox.Enabled == true)
                room = new MRoom();
            else
                room = (MRoom)DataMaster.GetObjectByProperty(typeof(MRoom), MRoom.ColumnNames.RoomId, roomIdTextBox.Text);

            room.RoomComission = roomComissionNumericUpDown.Value;
            room.RoomDesc = roomDescTextBox.Text;
            room.RoomId = roomIdTextBox.Text;
            room.RoomName = roomNameTextBox.Text;
            room.ModifiedBy = lbl_UserName.Text;
            room.ModifiedDate = DateTime.Now;

            if (roomIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(room);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Ruangan dengan kode " + roomIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
                    balloonHelp.ShowBalloon(roomIdTextBox);
                    roomIdTextBox.Focus();
                    return;
                }
                ModuleControlSettings.SaveLog(ListOfAction.Insert, roomIdTextBox.Text, ListOfTable.MRoom, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(room);
                ModuleControlSettings.SaveLog(ListOfAction.Update, roomIdTextBox.Text, ListOfTable.MRoom, lbl_UserName.Text);
            }
            BindData();

        }

        private bool ValidateForm()
        {
            RecreateBalloon();
            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(roomIdTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Kode ruangan harus diisi";
                balloonHelp.ShowBalloon(roomIdTextBox);
                roomIdTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(roomNameTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Nama ruangan harus diisi";
                balloonHelp.ShowBalloon(roomNameTextBox);
                roomNameTextBox.Focus();
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
                roomIdTextBox.Select();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                if (sender == roomIdTextBox)
                    roomNameTextBox.Select();
                else if (sender == roomNameTextBox)
                    roomComissionNumericUpDown.Select();
                else if (sender == roomComissionNumericUpDown)
                    bindingNavigatorSaveItem_Click(null, null);
            }
        }
    }
}