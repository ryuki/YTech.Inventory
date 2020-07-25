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
namespace Inventori.Dealer.Forms
{
    public partial class FormMasterChannel : Inventori.Forms.FormParentForMasterForm
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MChannel cust;
        public FormMasterChannel()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MChannel.ColumnNames.ChannelId;
            grid_Col.HeaderText = "Kode Channel";
            grid_Master.Columns.Add(grid_Col);
            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MChannel.ColumnNames.ChannelName;
            grid_Col.HeaderText = "Nama Channel";
            grid_Master.Columns.Add(grid_Col);
            //add kolom alamat
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MChannel.ColumnNames.ChannelAddress;
            grid_Col.HeaderText = "Alamat";
            grid_Master.Columns.Add(grid_Col);
            //add kolom telpon
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MChannel.ColumnNames.ChannelPhone;
            grid_Col.HeaderText = "Telepon";
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterChannel_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MChannel, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MChannel));
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
            channelIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            channelIdTextBox.Enabled = false;
            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(channelIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(channelIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    cust = (MChannel)DataMaster.GetObjectById(typeof(MChannel), channelIdTextBox.Text);
                    DataMaster.Delete(cust);
                    ModuleControlSettings.SaveLog(ListOfAction.Delete, channelIdTextBox.Text, ListOfTable.MChannel, lbl_UserName.Text);
                    BindData();

                }
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (channelIdTextBox.Enabled == true)
                cust = new MChannel();
            else
                cust = (MChannel)DataMaster.GetObjectById(typeof(MChannel), channelIdTextBox.Text);

            cust.ChannelAddress = channelAddressTextBox.Text;
            //cust.ChannelDisc = decimal.Zero;
            cust.ChannelFax = channelFaxTextBox.Text;
            cust.ChannelId = channelIdTextBox.Text;
            //cust.ChannelLimit = decimal.Zero;
            cust.ChannelName = channelNameTextBox.Text;
            cust.ChannelPhone = channelPhoneTextBox.Text;
            cust.ChannelStatus = ListOfCustStatus.Active.ToString();
            //cust.SubAccountId = string.Empty;
            cust.ModifiedBy = lbl_UserName.Text;
            cust.ModifiedDate = DateTime.Now;

            if (channelIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(cust);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Channel dengan kode " + channelIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
                    balloonHelp.ShowBalloon(channelIdTextBox);
                    channelIdTextBox.Focus();
                    return;
                }
                ModuleControlSettings.SaveLog(ListOfAction.Insert, channelIdTextBox.Text, ListOfTable.MChannel, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(cust);
                ModuleControlSettings.SaveLog(ListOfAction.Update, channelIdTextBox.Text, ListOfTable.MChannel, lbl_UserName.Text);
            }

            BindData();
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(channelIdTextBox.Text))
            {
                balloonHelp.Content = "Kode Channel harus diisi";
                balloonHelp.ShowBalloon(channelIdTextBox);
                channelIdTextBox.Focus();
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
                channelIdTextBox.Focus();
            //else
            //{
            //    if (e == null)
            //        return;

            //    if (e.KeyCode != Keys.Enter)
            //        return;

            //    Control c = (Control)sender;
            //    if (sender == channelIdTextBox)
            //        channelNameTextBox.Focus();
            //    else if (sender == channelNameTextBox)
            //        channelPhoneTextBox.Focus();
            //    else if (sender == channelPhoneTextBox)
            //        channelAddressTextBox.Focus();
            //    else if (sender == channelAddressTextBox)
            //        bindingNavigatorSaveItem_Click(null, null);
            //}

        }
    }
}