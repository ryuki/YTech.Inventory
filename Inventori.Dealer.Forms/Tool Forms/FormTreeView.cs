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

namespace Inventori.Dealer.Forms
{
    public partial class FormTreeView : FormParentForDealer
    {
        public FormTreeView()
        {
            InitializeComponent();
        }

        private MenuStrip _menuStrip;

        public MenuStrip menuStrip
        {
            get { return _menuStrip; }
            set { _menuStrip = value; }
        }


        private void FormTreeView_Load(object sender, EventArgs e)
        {
            PopulateNodes();
            BindKartuStokData();
        }

        private void BindKartuStokData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Hapus", typeof(bool));
            dt.Columns.Add("kartu stok id", typeof(decimal));
            dt.Columns.Add("kartu stok date", typeof(DateTime));
            dt.Columns.Add("item id", typeof(string));
            dt.Columns.Add("stok status", typeof(bool));
            dt.Columns.Add("stok jumlah", typeof(decimal));
            dt.Columns.Add("stok saldo", typeof(decimal));

            DataRow dr;
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listKartuStok = DataMaster.GetAllSortBy(typeof(TStokCard), TStokCard.ColumnNames.ItemId, "ASC");
            TStokCard card;
            for (int i = 0; i < listKartuStok.Count; i++)
            {
                card = (TStokCard)listKartuStok[i];
                dr = dt.NewRow();
                dr[0] = false;
                dr[1] = card.StokCardId;
                dr[2] = card.StokCardDate;
                dr[3] = card.ItemId;
                dr[4] = card.StokCardStatus;
                dr[5] = card.StokCardQuantity;
                dr[6] = card.StokCardSaldo;
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Show();
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
                node.Text = menuStrip.Items[i].Text.Replace("&", "") + menuNo.ToString();
                node.Tag = menuNo;

                treeView1.Nodes.Add(node);
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
                    childNode.Text = submenu.Text.Replace("&", "") + menuNo.ToString();
                    childNode.Tag = menuNo;
                    node.Nodes.Add(childNode);

                    AddChildrenNodes(submenu, childNode);
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TMenuUser tmenu = (TMenuUser)DataMaster.GetObjectByProperty(typeof(TMenuUser), TMenuUser.ColumnNames.MenuId, Convert.ToDecimal(treeView1.SelectedNode.Tag), TMenuUser.ColumnNames.SettingId, AppCode.AssemblyProduct, TMenuUser.ColumnNames.UserName, lbl_UserName.Text);

            bool isSave = false;
            if (tmenu == null)
            {
                tmenu = new TMenuUser();
                isSave = true;
            }

            tmenu.HasAccess = true;
            tmenu.MenuId = Convert.ToDecimal(treeView1.SelectedNode.Tag);
            tmenu.ModifiedBy = lbl_UserName.Text;
            tmenu.ModifiedDate = DateTime.Now;
            tmenu.SettingId = AppCode.AssemblyProduct;
            tmenu.UserName = lbl_UserName.Text;

            if (isSave)
                DataMaster.SavePersistence(tmenu);
            else
                DataMaster.UpdatePersistence(tmenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TStokCard card;
            decimal stokId;
            bool isDelete = false; ;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                isDelete = Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value);
                if (isDelete)
                {
                    stokId = Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value);
                    card = (TStokCard)DataMaster.GetObjectByProperty(typeof(TStokCard), TStokCard.ColumnNames.StokCardId, stokId);
                    if (card != null)
                    {
                        DataMaster.Delete(card);

                    }
                }
            }
        }


    }
}