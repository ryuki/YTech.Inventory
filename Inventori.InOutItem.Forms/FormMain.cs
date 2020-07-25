using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using DockSample.Customization;

using Inventori.Data;
using Inventori.Facade;
using Inventori.Forms;
using Inventori.Module;

namespace Inventori.InOutItem.Forms
{
    public partial class FormMain : Form
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        MSetting set;

        public FormMain()
        {
            InitializeComponent();
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.Icon = Properties.Resources.inventori_ico;

            try
            {
                set = (MSetting)DataMaster.GetObjectByProperty(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
                if (set != null)
                    this.Text = AppCode.AssemblyTitle + "-" + set.CompanyName;
                else
                {
                    this.Text = AppCode.AssemblyTitle + "-" + "Demo Version ";
                    set.CompanyName = "Demo Version";
                }

            }
            catch (Exception)
            {
                this.Text = AppCode.AssemblyTitle + "-" + "Demo Version ";
            }

            SetEvent();
        }

        public FormBackupDatabase f_BackupDB;
        private FormRestoreDatabase f_RestoreDB;
        private FormChangePassword f_ChangePassword;
        private Inventori.InOutItem.Forms.FormLogin f_Login;
        FormMasterGroup f_Group;
        FormMasterItem f_Item;
        FormMasterCustomer f_Cust;
        FormMasterSupplier f_Supp;
        FormTransaction f_Transaction;
        FormSettingForInOutItem f_Setting;
        FormListUser f_ListUser;
        FormSearchItem f_SearchItem;
        FormReminder f_Reminder;
        FormTreeView f_Tree;

        #region method

        private void SetEvent()
        {
            //timer
            timer1.Tick += new EventHandler(timer1_Tick);
            //main
            this.Load += new EventHandler(FormMain_Load);
            this.FormClosing += new FormClosingEventHandler(FormMain_FormClosing);
            //file
            masukToolStripMenuItem.Click += new EventHandler(masukToolStripMenuItem_Click);
            keluarToolStripMenuItem.Click += new EventHandler(keluarToolStripMenuItem_Click);
            exitToolStripMenuItem.Click += new EventHandler(exitToolStripMenuItem_Click);
            //view
            toolBarToolStripMenuItem.Click += new EventHandler(toolBarToolStripMenuItem_Click);
            statusBarToolStripMenuItem.Click += new EventHandler(statusBarToolStripMenuItem_Click);
            treeViewToolStripMenuItem.Click += new EventHandler(treeViewToolStripMenuItem_Click);
            //data pokok
            subItemToolStripMenuItem.Click += new EventHandler(subItemToolStripMenuItem_Click);
            itemToolStripMenuItem.Click += new EventHandler(itemToolStripMenuItem_Click);
            pelangganToolStripMenuItem.Click += new EventHandler(pelangganToolStripMenuItem_Click);
            supplierToolStripMenuItem.Click += new EventHandler(supplierToolStripMenuItem_Click);
            //transaksi
            barangMasukToolStripMenuItem.Click += new EventHandler(barangMasukToolStripMenuItem_Click);
            barangKeluarToolStripMenuItem.Click += new EventHandler(barangKeluarToolStripMenuItem_Click);
            koreksiStokToolStripMenuItem.Click += new EventHandler(koreksiStokToolStripMenuItem_Click);

            //utiliti
            konfigurasiProgramToolStripMenuItem.Click += new EventHandler(konfigurasiProgramToolStripMenuItem_Click);
            listUserToolStripMenuItem.Click += new EventHandler(listUserToolStripMenuItem_Click);
            gantiKataKunciToolStripMenuItem.Click += new EventHandler(gantiKataKunciToolStripMenuItem_Click);
            backupDatabaseToolStripMenuItem.Click += new EventHandler(backupDatabaseToolStripMenuItem_Click);
            restoreDatabaseToolStripMenuItem.Click += new EventHandler(restoreDatabaseToolStripMenuItem_Click);
            pencarianBarangToolStripMenuItem.Click += new EventHandler(pencarianBarangToolStripMenuItem_Click);
            reminderToolStripMenuItem.Click += new EventHandler(reminderToolStripMenuItem_Click);

            //toolbar
            toolStripButton_Item.Click += new EventHandler(itemToolStripMenuItem_Click);
            toolStripButton_BarangKeluar.Click +=new EventHandler(barangKeluarToolStripMenuItem_Click);
            toolStripButton_Seting.Click+=new EventHandler(konfigurasiProgramToolStripMenuItem_Click);
            toolStripButton_Backup.Click += new EventHandler(backupDatabaseToolStripMenuItem_Click);
        }

        public void AutoBackup(string application)
        {
            if (set == null)
                return;

            if (set.AutoBackup)
            {
                if (f_BackupDB != null)
                {
                    if (!f_BackupDB.IsDisposed)
                    {
                        f_BackupDB.Close();
                    }
                }
                f_BackupDB = new FormBackupDatabase();
                f_BackupDB.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
                string BackupFileExtention = "backup";

                f_BackupDB.txt_BackupFile.Text = set.BackupDir + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss.") + BackupFileExtention;
                f_BackupDB.lbl_Auto.Text = set.AutoBackup.ToString();
                f_BackupDB.ShowDialog();
            }
        }

        int i;
        public void FilterPriviledge()
        {
            i = 0;
            int x = 100;
            for (int j = 2; j < menuStrip.Items.Count - 1; j++)
            {
                i = x * (j - 1);
                ((ToolStripMenuItem)menuStrip.Items[j]).Enabled = ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text, i, AppCode.AssemblyProduct);
                ShowMenu((ToolStripMenuItem)menuStrip.Items[j]);
            }

            //toolStripButton_Item.Enabled = itemToolStripMenuItem.Enabled;
            //toolStripButton_Sales.Enabled = penjualanToolStripMenuItem.Enabled;
            //toolStripButton_Backup.Enabled = backupDatabaseToolStripMenuItem.Enabled;
            //toolStripButton_Seting.Enabled = konfigurasiProgramToolStripMenuItem.Enabled;

        }

        private void ShowMenu(ToolStripMenuItem m)
        {
            ToolStripMenuItem submenu;

            foreach (object obj in m.DropDownItems)
            {
                if (obj.GetType() == typeof(ToolStripMenuItem))
                {
                    i++;
                    submenu = (ToolStripMenuItem)obj;

                    submenu.Enabled = ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text, i, AppCode.AssemblyProduct);
                    if (submenu.Enabled)
                        submenu.OwnerItem.Enabled = true;

                    ShowMenu(submenu);
                }
            }
        }


        private void OpenFormTransaction(ListOfTransaction trans)
        {
            if (f_Transaction != null)
            {
                if (!f_Transaction.IsDisposed)
                    f_Transaction.Close();
            }
            f_Transaction = new FormTransaction(trans);
            //if (set != null)
            //    f_Transaction.companyNameLabel.Text = set.CompanyName;
            //f_Transaction.trans = trans;
            f_Transaction.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
        }
        #endregion

        #region utiliti

        void reminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Reminder != null)
            {
                if (!f_Reminder.IsDisposed)
                {
                    f_Reminder.WindowState = FormWindowState.Normal;
                    f_Reminder.BringToFront();
                }
                else
                    f_Reminder = new FormReminder();
            }
            else
                f_Reminder = new FormReminder();

            f_Reminder.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Reminder.Show(dockPanel1);
            f_Reminder.DockState = DockState.DockLeftAutoHide;
        }

        void pencarianBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (f_SearchItem != null)
            {
                if (!f_SearchItem.IsDisposed)
                {
                    f_SearchItem.WindowState = FormWindowState.Normal;
                    f_SearchItem.BringToFront();
                }
                else
                    f_SearchItem = new FormSearchItem();
            }
            else
                f_SearchItem = new FormSearchItem();

            f_SearchItem.lbl_TempTransaction.Text = ListOfTransaction.Correction.ToString();

            f_SearchItem.btn_Cancel.Visible = false;
            f_SearchItem.btn_OK.Visible = false;
            f_SearchItem.Show(dockPanel1);
        }
        void restoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_RestoreDB != null)
            {
                if (!f_RestoreDB.IsDisposed)
                    f_RestoreDB.Close();
            }
            f_RestoreDB = new FormRestoreDatabase();
            f_RestoreDB.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_RestoreDB.Show(dockPanel1);
        }

        void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_BackupDB != null)
            {
                if (!f_BackupDB.IsDisposed)
                    f_BackupDB.Close();
            }
            f_BackupDB = new FormBackupDatabase();
            f_BackupDB.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_BackupDB.Show(dockPanel1);
        }

        void gantiKataKunciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_ChangePassword != null)
            {
                if (!f_ChangePassword.IsDisposed)
                    f_ChangePassword.Close();

            }

            f_ChangePassword = new FormChangePassword();
            f_ChangePassword.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_ChangePassword.userNameLabel1.Text = toolStripStatusLabelLoginName.Text;
            f_ChangePassword.ShowDialog(this);
        }

        void listUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_ListUser != null)
            {
                if (!f_ListUser.IsDisposed)
                {
                    f_ListUser.WindowState = FormWindowState.Normal;
                    f_ListUser.BringToFront();
                }
                else
                    f_ListUser = new FormListUser(AppCode.AssemblyProduct);
            }
            else
                f_ListUser = new FormListUser(AppCode.AssemblyProduct);

            f_ListUser.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_ListUser.menuStrip = this.menuStrip;
            f_ListUser.Show(dockPanel1);
        }


        void konfigurasiProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Setting != null)
            {
                if (!f_Setting.IsDisposed)
                {
                    f_Setting.WindowState = FormWindowState.Normal;
                    f_Setting.BringToFront();
                }
                else
                    f_Setting = new FormSettingForInOutItem();
            }
            else
                f_Setting = new FormSettingForInOutItem();

            f_Setting.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Setting.Show(dockPanel1);
        }

        #endregion

        #region transaksi

        void barangMasukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.Purchase);
            f_Transaction.Show(dockPanel1);
        }

        void barangKeluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.Sales);
            f_Transaction.Show(dockPanel1);
        }

        void koreksiStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.Correction);
            f_Transaction.Show(dockPanel1);
        }



        #endregion

        #region data pokok
        void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Supp != null)
            {
                if (!f_Supp.IsDisposed)
                {
                    f_Supp.WindowState = FormWindowState.Normal;
                    f_Supp.BringToFront();
                }
                else
                    f_Supp = new FormMasterSupplier();
            }
            else
                f_Supp = new FormMasterSupplier();

            f_Supp.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Supp.Show(dockPanel1);
        }

        void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Cust != null)
            {
                if (!f_Cust.IsDisposed)
                {
                    f_Cust.WindowState = FormWindowState.Normal;
                    f_Cust.BringToFront();
                }
                else
                    f_Cust = new FormMasterCustomer();
            }
            else
                f_Cust = new FormMasterCustomer();

            f_Cust.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Cust.Show(dockPanel1);
        }

        void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Item != null)
            {
                if (!f_Item.IsDisposed)
                {
                    f_Item.WindowState = FormWindowState.Normal;
                    f_Item.BringToFront();
                }
                else
                    f_Item = new FormMasterItem();
            }
            else
                f_Item = new FormMasterItem();

            f_Item.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Item.Show(dockPanel1);
        }

        void subItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Group != null)
            {
                if (!f_Group.IsDisposed)
                {
                    f_Group.WindowState = FormWindowState.Normal;
                    f_Group.BringToFront();
                }
                else
                    f_Group = new FormMasterGroup();
            }
            else
                f_Group = new FormMasterGroup();

            f_Group.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Group.Show(dockPanel1);
        }
        
        #endregion

        #region view
        void treeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Tree != null)
            {
                if (!f_Tree.IsDisposed)
                {
                    f_Tree.WindowState = FormWindowState.Normal;
                    f_Tree.BringToFront();
                }
                else
                    f_Tree = new FormTreeView();
            }
            else
                f_Tree = new FormTreeView();

            f_Tree.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Tree.menuStrip = this.menuStrip;
            f_Tree.Show(dockPanel1);
        }

        void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        void toolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }
        #endregion

        #region file

        void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDockContent[] cont = dockPanel1.GetDocuments();
            for (int z = 0; z < cont.Length; z++)
            {
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        dockPanel1.Contents[z].DockHandler.Close();
                        break;
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        dockPanel1.Contents[z].DockHandler.Hide();
                        break;
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            this.Hide();

            ModuleControlSettings.SaveLog(ListOfAction.Logout, string.Empty, ListOfTable.None, toolStripStatusLabelLoginName.Text);
            if (f_Login != null)
            {
                if (!f_Login.IsDisposed)
                    f_Login.Close();

                f_Login = new Inventori.InOutItem.Forms.FormLogin();
            }
            else
                f_Login = new Inventori.InOutItem.Forms.FormLogin();

            f_Login.ShowDialog(this);
        }

        void masukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keluarToolStripMenuItem.Enabled = !masukToolStripMenuItem.Enabled;
        }
#endregion

        #region main
        void FormMain_Load(object sender, EventArgs e)
        {
            lbl_LoginTime.Text = DateTime.Now.ToString("f");
            try
            {
                Extender.SetSchema(dockPanel1, Extender.Schema.VS2005);
            }
            catch (Exception)
            {
            }
            timer1_Tick(null, null);
            timer1.Start();


            try
            {
                if (set != null)
                    toolStripStatusLabel_CompanyName.Text = set.CompanyName;
                else
                    toolStripStatusLabel_CompanyName.Text = "Demo Version";

            }
            catch (Exception)
            {
                toolStripStatusLabel_CompanyName.Text = "";
            }


        }

        void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason != CloseReason.UserClosing)
            {
                e.Cancel = false;
                // return;
                for (int n = 0; n < Application.OpenForms.Count; n++)
                {
                    Application.OpenForms[n].Close();
                }
            }
            else
            {
                if (MessageBox.Show("Anda yakin menutup program?", "Konfirmasi Tutup Program", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    AutoBackup(AppCode.AssemblyProduct);
                    e.Cancel = false;
                    for (int n = 0; n < Application.OpenForms.Count; n++)
                    {
                        Application.OpenForms[n].Close();
                    }
                }
                else
                {
                    this.Show();
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region timer
        void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel_Time.Text = DateTime.Now.ToString("f");
        }
        #endregion


    }
}
