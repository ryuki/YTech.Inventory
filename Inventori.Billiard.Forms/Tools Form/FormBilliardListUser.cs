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

namespace Inventori.Billiard.Forms
{
    public partial class FormBilliardListUser : Inventori.Forms.FormListUser
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MUser user;
        private TMenuUser menuUser;
        public FormBilliardListUser()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MUser.ColumnNames.UserName;
            grid_Col.HeaderText = "User Name";
            grid_Master.Columns.Add(grid_Col);

            DataGridViewCheckBoxColumn grid_Check = new DataGridViewCheckBoxColumn();
            grid_Check.CellTemplate = new DataGridViewCheckBoxCell();
            grid_Check.ReadOnly = false;
            grid_Check.ThreeState = false;
            grid_MenuAccess.Columns.Add(grid_Check);

            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.HeaderText = "Menu";
            grid_Col.ReadOnly = true;
            grid_MenuAccess.Columns.Add(grid_Col);

            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.HeaderText = "MenuId";
            grid_Col.Visible = false;
            grid_MenuAccess.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormBilliardListUser_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SetGridDataView(grid_MenuAccess);
            grid_MenuAccess.ReadOnly = false;
            BindData();
        }

        private void BindData()
        {
            bindingSource_Master.Clear();
            IList listMaster = DataMaster.GetAll(typeof(MUser));
            if (listMaster.Count > 0)
                bindingSource_Master.DataSource = listMaster;

            bindingSource_Master_PositionChanged(null, null);
            detailControl_KeyDown(null, null);

        }

        private void bindingSource_Master_PositionChanged(object sender, EventArgs e)
        {
            MMenu mmenu;
            TMenuUser tmenu;
            //IList listMenuUser = DataMaster.GetListEq(typeof(VMenuUser), "UserName", userNameTextBox.Text);
            IList listMenu = DataMaster.GetAll(typeof(MMenu));
            grid_MenuAccess.Rows.Clear();
            //if (listMenu.Count == 0)
            //{
            //listMenuUser = DataMaster.GetAll(typeof(MMenu));
            bool hasAccess = false;
            for (int i = 0; i < listMenu.Count; i++)
            {
                mmenu = (MMenu)listMenu[i];
                tmenu = (TMenuUser)DataMaster.GetObjectByProperty(typeof(TMenuUser), TMenuUser.ColumnNames.UserName, userNameTextBox.Text, TMenuUser.ColumnNames.MenuId, mmenu.MenuId);

                if (tmenu != null)
                    hasAccess = tmenu.HasAccess;
                else
                    hasAccess = false;

                grid_MenuAccess.Rows.Add();
                grid_MenuAccess.Rows[i].Cells[0].Value = hasAccess;
                grid_MenuAccess.Rows[i].Cells[1].Value = mmenu.MenuName;
                grid_MenuAccess.Rows[i].Cells[2].Value = mmenu.MenuId;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            userNameTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            userNameTextBox.Enabled = false;
            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(userNameTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userNameTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    user = (MUser)DataMaster.GetObjectById(typeof(MUser),userNameTextBox.Text);
                    DataMaster.Delete(user);

                    DeleteTMenuUser();
                    BindData();

                }
            }
        }

        private void DeleteTMenuUser()
        {
            IList listMenuUser = DataMaster.GetListEq(typeof(TMenuUser), "UserName", userNameTextBox.Text);

            for (int i = 0; i < listMenuUser.Count; i++)
            {
                menuUser = (TMenuUser)listMenuUser[i];
                DataMaster.Delete(menuUser);
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (userNameTextBox.Enabled == true)
                user = new MUser();
            else
                user = (MUser)DataMaster.GetObjectById(typeof(MUser), userNameTextBox.Text);

            user.UserName = userNameTextBox.Text;
            user.UserPassword = userPasswordTextBox.Text;
            user.UserStatus = userStatusCheckBox.Checked;

            if (userNameTextBox.Enabled == true)
                DataMaster.SavePersistence(user);
            else
                DataMaster.UpdatePersistence(user);

            DeleteTMenuUser();
            SaveTMenuUser();

            BindData();
        }

        private void SaveTMenuUser()
        {
            for (int i = 0; i < grid_MenuAccess.Rows.Count; i++)
            {
                //try
                //{
                menuUser = new TMenuUser();
                menuUser.HasAccess = Convert.ToBoolean(grid_MenuAccess.Rows[i].Cells[0].Value);
                menuUser.MenuId = Convert.ToDecimal(grid_MenuAccess.Rows[i].Cells[2].Value);
                menuUser.UserName = userNameTextBox.Text;
                DataMaster.SavePersistence(menuUser);
                //}
                //catch (Exception)
                //{

                //    //throw;
                //}

            }
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(userNameTextBox.Text))
            {
                balloonHelp.Content = "User name harus diisi";
                balloonHelp.ShowBalloon(userNameTextBox);
                userNameTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(userPasswordTextBox.Text))
            {
                balloonHelp.Content = "Password harus diisi";
                balloonHelp.ShowBalloon(userPasswordTextBox);
                userPasswordTextBox.Focus();
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
                userNameTextBox.Focus();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                Control c = (Control)sender;
                if (sender == userNameTextBox)
                    userPasswordTextBox.Focus();
                else if (sender == userPasswordTextBox)
                    userStatusCheckBox.Focus();
                else if (sender == userStatusCheckBox)
                    bindingNavigatorSaveItem_Click(null, null);

            }

        }
    }
}

