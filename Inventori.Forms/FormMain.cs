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

//using Inventori.Data;
//using Inventori.Facade;
//using Inventori.Forms;
using Inventori.Module;

namespace Inventori.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
        }

        private void FormMain_Load(object sender, EventArgs e)
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
        }

        private void masukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keluarToolStripMenuItem.Enabled = !masukToolStripMenuItem.Enabled;
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDockContent[] cont = dockPanel1.GetDocuments();
            for (int z = 0; z < cont.Length; z++)
            {
                try
                {
                    dockPanel1.Contents[z].DockHandler.Close();

                }
                catch (Exception)
                {
                }
                try
                {
                    dockPanel1.Contents[z].DockHandler.Hide();
                }
                catch (Exception)
                {
                }

            }

            this.Hide();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        public FormBackupDatabase f_BackupDB;
        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
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

        private FormRestoreDatabase f_RestoreDB;
        private void restoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
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

        private FormChangePassword f_ChangePassword;
        private void gantiKataKunciToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel_Time.Text = DateTime.Now.ToString("f");
        }


        public void AutoBackup(string application)
        {
            Inventori.Facade.DataMasterMgtServices DataMaster = new Inventori.Facade.DataMasterMgtServices();
            Inventori.Data.MSetting set = (Inventori.Data.MSetting)DataMaster.GetObjectByProperty(typeof(Inventori.Data.MSetting), Inventori.Data.MSetting.ColumnNames.SettingId, application);
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
    }
}
