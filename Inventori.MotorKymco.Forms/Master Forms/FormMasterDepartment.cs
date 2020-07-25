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
    public partial class FormMasterDepartment : Inventori.Forms.FormParentForMasterForm
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MDep dep;
        public FormMasterDepartment()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MDep.ColumnNames.DepId;
            grid_Col.HeaderText = "Kode Bagian";
            grid_Master.Columns.Add(grid_Col);

            //add kolom status
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MDep.ColumnNames.DepName;
            grid_Col.HeaderText = "Nama Bagian";
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterDepartment_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MDep, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            BindData();
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MDep));
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
            depIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            depIdTextBox.Enabled = false;
            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(depIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(depIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    dep = (MDep)DataMaster.GetObjectById(typeof(MDep), depIdTextBox.Text);
                    DataMaster.Delete(dep);
                    ModuleControlSettings.SaveLog(ListOfAction.Delete, depIdTextBox.Text, ListOfTable.MDep, lbl_UserName.Text);
                    BindData();

                }
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (depIdTextBox.Enabled == true)
                dep = new MDep();
            else
                dep = (MDep)DataMaster.GetObjectById(typeof(MDep), depIdTextBox.Text);

            dep.DepId = depIdTextBox.Text;
            dep.DepName = depNameTextBox.Text;
            dep.DepStatus = "OK";
            dep.ModifiedBy = lbl_UserName.Text;
            dep.ModifiedDate = DateTime.Now;
            if (depIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(dep);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Bagian " + depIdTextBox.Text + " sudah pernah diinput, silahkan input bagian yang lain";
                    balloonHelp.ShowBalloon(depIdTextBox);
                    depIdTextBox.Focus();
                    return;
                }

                ModuleControlSettings.SaveLog(ListOfAction.Insert, depIdTextBox.Text, ListOfTable.MDep, lbl_UserName.Text);
            }

            else
            {
                DataMaster.UpdatePersistence(dep);
                ModuleControlSettings.SaveLog(ListOfAction.Update, depIdTextBox.Text, ListOfTable.MDep, lbl_UserName.Text);
            }


            BindData();
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(depIdTextBox.Text))
            {
                balloonHelp.Content = "Bagian harus diisi";
                balloonHelp.ShowBalloon(depIdTextBox);
                depIdTextBox.Focus();
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
                depIdTextBox.Focus();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                Control c = (Control)sender;
                if (sender == depIdTextBox)
                    depNameTextBox.Focus();
                else if (sender == depNameTextBox)
                    bindingNavigatorSaveItem.Select();

            }

        }

    }
}

