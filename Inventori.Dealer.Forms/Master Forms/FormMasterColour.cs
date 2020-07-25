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
    public partial class FormMasterColour : Inventori.Forms.FormParentForMasterForm
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MColour color;
        public FormMasterColour()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MColour.ColumnNames.ColourId;
            grid_Col.HeaderText = "Kode Warna";
            grid_Master.Columns.Add(grid_Col);
            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MColour.ColumnNames.ColourDesc;
            grid_Col.HeaderText = "Warna";
            grid_Master.Columns.Add(grid_Col);
            
            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterColour_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MColour, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MColour));
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
            colourIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            colourIdTextBox.Enabled = false;
            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(colourIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(colourIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    color = (MColour)DataMaster.GetObjectById(typeof(MColour), colourIdTextBox.Text);
                    DataMaster.Delete(color);
                    ModuleControlSettings.SaveLog(ListOfAction.Delete, colourIdTextBox.Text, ListOfTable.MColour, lbl_UserName.Text);
                    BindData();

                }
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (colourIdTextBox.Enabled == true)
                color = new MColour();
            else
                color = (MColour)DataMaster.GetObjectById(typeof(MColour), colourIdTextBox.Text);

            color.ColourId = colourIdTextBox.Text;
            color.ColourDesc = colourDescTextBox.Text;
            color.ModifiedBy = lbl_UserName.Text;
            color.ModifiedDate = DateTime.Now;

            if (colourIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(color);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Warna dengan kode " + colourIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
                    balloonHelp.ShowBalloon(colourIdTextBox);
                    colourIdTextBox.Focus();
                    return;
                }
                ModuleControlSettings.SaveLog(ListOfAction.Insert, colourIdTextBox.Text, ListOfTable.MColour, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(color);
                ModuleControlSettings.SaveLog(ListOfAction.Update, colourIdTextBox.Text, ListOfTable.MColour, lbl_UserName.Text);
            }

            BindData();
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(colourIdTextBox.Text))
            {
                balloonHelp.Content = "Kode Warna harus diisi";
                balloonHelp.ShowBalloon(colourIdTextBox);
                colourIdTextBox.Focus();
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
                colourIdTextBox.Focus();
            //else
            //{
            //    if (e == null)
            //        return;

            //    if (e.KeyCode != Keys.Enter)
            //        return;

            //    Control c = (Control)sender;
            //    if (sender == colourIdTextBox)
            //        coloromerNameTextBox.Focus();
            //    else if (sender == coloromerNameTextBox)
            //        coloromerPhoneTextBox.Focus();
            //    else if (sender == coloromerPhoneTextBox)
            //        coloromerAddressTextBox.Focus();
            //    else if (sender == coloromerAddressTextBox)
            //        bindingNavigatorSaveItem_Click(null, null);
            //}

        }

        private void colourDescTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}