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
    public partial class FormListUser : Inventori.Forms.FormParentForMasterForm
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MUser user;
        private TMenuUser menuUser;
        private string appl;
        public FormListUser(string application)
        {
            InitializeComponent();
            appl = application;


            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MUser.ColumnNames.UserName;
            grid_Col.HeaderText = "Nama Pengguna";
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private MenuStrip _menuStrip;
        public MenuStrip menuStrip
        {
            get { return _menuStrip; }
            set { _menuStrip = value; }
        }

        private void FormListUser_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MUser, lbl_UserName.Text);
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();
            PopulateNodes();
            treeView_Menu.ExpandAll();
            BindData();
        }

        int menuNo;
        void PopulateNodes()
        {
            menuNo = 0;
            int x = 100;
            TreeNode node;
            for (int i = 2; i < menuStrip.Items.Count - 1; i++)
            {
                menuNo = x * (i - 1);
                node = new TreeNode();
                node.Text = menuStrip.Items[i].Text.Replace("&", "");
                node.Tag = menuNo;

                treeView_Menu.Nodes.Add(node);
                AddChildrenNodes((ToolStripMenuItem)menuStrip.Items[i], node);
            }
        }

        private void AddChildrenNodes(ToolStripMenuItem toolStripItem, TreeNode node)
        {
            ToolStripMenuItem submenu;
            TreeNode childNode;

            foreach (object obj in toolStripItem.DropDownItems)
            {
                if (obj.GetType() == typeof(ToolStripMenuItem))
                {
                    menuNo++;
                    submenu = (ToolStripMenuItem)obj;

                    childNode = new TreeNode();
                    childNode.Text = submenu.Text.Replace("&", "");
                    childNode.Tag = menuNo;
                    node.Nodes.Add(childNode);

                    AddChildrenNodes(submenu, childNode);
                }
            }
        }

        private void BindData()
        {
            IList listUser = DataMaster.GetAll(typeof(MUser));
            if (listUser.Count > 0)
                bindingSource_Master.DataSource = listUser;

            bindingSource_Master_PositionChanged(null, null);
            detailControl_KeyDown(null, null);

        }

        private void bindingSource_Master_PositionChanged(object sender, EventArgs e)
        {
            SetNavigatorDisplay();

            for (int i = 0; i < treeView_Menu.Nodes.Count; i++)
            {
                treeView_Menu.Nodes[i].Checked = ModuleControlSettings.HavePriviledges(userNameTextBox.Text, Convert.ToInt32(treeView_Menu.Nodes[i].Tag), appl);
                SetChecked(treeView_Menu.Nodes[i]);
            }
        }

        private void SetChecked(TreeNode treeNode)
        {
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                treeNode.Nodes[i].Checked = ModuleControlSettings.HavePriviledges(userNameTextBox.Text, Convert.ToInt32(treeNode.Nodes[i].Tag), appl);
                SetChecked(treeNode.Nodes[i]);
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
                    user = (MUser)DataMaster.GetObjectById(typeof(MUser), userNameTextBox.Text);
                    DataMaster.Delete(user);

                    DeleteTMenuUser();
                    BindData();
                }
            }
        }

        private void DeleteTMenuUser()
        {
            IList listMenuUser = DataMaster.GetListEq(typeof(TMenuUser), TMenuUser.ColumnNames.UserName, userNameTextBox.Text, TMenuUser.ColumnNames.SettingId, appl);

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
                user = (MUser)DataMaster.GetObjectByProperty(typeof(MUser), MUser.ColumnNames.UserName, userNameTextBox.Text);

            user.UserName = userNameTextBox.Text;
            user.UserPassword = userPasswordTextBox.Text;
            user.UserStatus = userStatusCheckBox.Checked;
            user.ModifiedBy = lbl_UserName.Text;
            user.ModifiedDate = DateTime.Now;

            if (userNameTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(user);

                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Pengguna dengan nama " + userNameTextBox.Text + " sudah pernah diinput, silahkan input dengan nama yang lain";
                    balloonHelp.ShowBalloon(userNameTextBox);
                    userNameTextBox.Focus();
                    return;
                }
                ModuleControlSettings.SaveLog(ListOfAction.Insert, userNameTextBox.Text, ListOfTable.MUser, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(user);
                ModuleControlSettings.SaveLog(ListOfAction.Update, userNameTextBox.Text, ListOfTable.MUser, lbl_UserName.Text);
            }

            DeleteTMenuUser();
            SaveParentMenuUser();

            BindData();
        }

        private void SaveParentMenuUser()
        {
            for (int i = 0; i < treeView_Menu.Nodes.Count; i++)
            {
                SaveTMenuUser(Convert.ToDecimal(treeView_Menu.Nodes[i].Tag), treeView_Menu.Nodes[i].Checked);
                SaveChildMenuUser(treeView_Menu.Nodes[i]);
            }
        }

        private void SaveChildMenuUser(TreeNode treeNode)
        {
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                SaveTMenuUser(Convert.ToDecimal(treeNode.Nodes[i].Tag), treeNode.Nodes[i].Checked);
                SaveChildMenuUser(treeNode.Nodes[i]);
            }
        }

        private void SaveTMenuUser(decimal menuId, bool hasAccess)
        {
            TMenuUser tmenu = new TMenuUser();
            tmenu.HasAccess = hasAccess;
            tmenu.MenuId = menuId;
            tmenu.SettingId = appl;
            tmenu.UserName = userNameTextBox.Text;
            tmenu.ModifiedBy = lbl_UserName.Text;
            tmenu.ModifiedDate = DateTime.Now;
            DataMaster.SavePersistence(tmenu);
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(userNameTextBox.Text))
            {
                balloonHelp.Content = "Nama pengguna harus diisi";
                balloonHelp.ShowBalloon(userNameTextBox);
                userNameTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(userPasswordTextBox.Text))
            {
                balloonHelp.Content = "Kata kunci harus diisi";
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

        private void treeView_Menu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
            {
                CheckedChildrenNodes(e.Node, e.Node.Checked);
                CheckedParentNodes(e.Node, e.Node.Checked);
            }
        }

        private void CheckedParentNodes(TreeNode treeNode, bool isChecked)
        {
            if (isChecked)
            {
                if (treeNode.Parent != null)
                {
                    treeNode.Parent.Checked = isChecked;
                    CheckedParentNodes(treeNode.Parent, isChecked);
                }
            }
        }

        private void CheckedChildrenNodes(TreeNode treeNode, bool isChecked)
        {
            TreeNode child;
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                child = treeNode.Nodes[i];
                child.Checked = isChecked;
                CheckedChildrenNodes(child, isChecked);
            }
        }
    }
}

