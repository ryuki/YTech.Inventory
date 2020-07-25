using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.Data;
using Inventori.Facade;

namespace Inventori.GrosirMitra.Forms
{
    public partial class FormTreeView : FormParentForGrosirMitra
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();

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
            if (MessageBox.Show("Anda yakin update stok?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                BindData(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindData(false);
        }

        private void BindData(bool isUpdate)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("stok card id");
            dt.Columns.Add("transaction id");
            dt.Columns.Add("faktur");
            dt.Columns.Add("trans status");
            dt.Columns.Add("item id");
            dt.Columns.Add("status add");
            dt.Columns.Add("jumlah");
            dt.Columns.Add("saldo");
            dt.Columns.Add("saldo 2");

            DataRow dr;

            IList listItem = DataMaster.GetAll(typeof(MItem));
            MItem item;

            IList listStok;
            TStokCard stokCard;

            TTransaction trans;
            ItemGudangStok stok;

            decimal t = 0;

            for (int i = 0; i < listItem.Count; i++)
            {
                item = (MItem)listItem[i];
                listStok = DataMaster.GetSortByListLike(typeof(TStokCard), TStokCard.ColumnNames.ItemId, item.ItemId, TStokCard.ColumnNames.StokCardId, "ASC");

                t = 0;
                for (int j = 0; j < listStok.Count; j++)
                {
                    stokCard = (TStokCard)listStok[j];

                    trans = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, stokCard.TransactionId);

                    if (j == 0)
                    {
                        if (trans.TransactionStatus == ListOfTransaction.SalesVIP.ToString())
                        {
                            t = stokCard.StokCardSaldo - (stokCard.StokCardQuantity * 2);
                        }
                        else
                        {
                            t = stokCard.StokCardSaldo + (stokCard.StokCardQuantity * 2);
                        }

                    }
                    else
                    {
                        if (trans.TransactionStatus == ListOfTransaction.SalesVIP.ToString())
                        {
                            t = t - stokCard.StokCardQuantity;
                        }
                        else
                        {
                            t = t + stokCard.StokCardQuantity;
                        }
                    }

                    dr = dt.NewRow();
                    dr[0] = stokCard.StokCardId;
                    dr[1] = trans.TransactionId;
                    dr[2] = trans.TransactionFactur;
                    dr[3] = trans.TransactionStatus;
                    dr[4] = item.ItemId;
                    dr[5] = stokCard.StokCardStatus;
                    dr[6] = stokCard.StokCardQuantity;
                    dr[7] = stokCard.StokCardSaldo;
                    dr[8] = t;
                    dt.Rows.Add(dr);

                    if (isUpdate)
                    {
                        if (trans.TransactionStatus == ListOfTransaction.SalesVIP.ToString())
                        {
                            stokCard.StokCardStatus = false;
                        }
                        stokCard.StokCardSaldo = t;
                        DataMaster.UpdatePersistence(stokCard);

                        if (j == listStok.Count - 1)
                        {
                            stok = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.GudangId, stokCard.GudangId, ItemGudangStok.ColumnNames.ItemId, stokCard.ItemId);
                            if (stok != null)
                            {
                                stok.ItemStok = t;
                                DataMaster.UpdatePersistence(stok);
                            }
                        }
                    }
                }
            }

            dataGridView1.DataSource = dt;
            dataGridView1.Show();

            Inventori.Module.ModuleControlSettings.SetGridDataView(dataGridView1);
        }
    }
}