using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SQLDMO;
using System.Runtime.InteropServices;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;
using System.IO;

using NHibernate;
using Inventori.DataAccess;
using System.Data.SqlClient;

namespace Inventori.RestoreDatabase
{
    public partial class FormBackupDatabase : Form
    {
        string BackupFileExtention = "bak";
        public FormBackupDatabase()
        {
            InitializeComponent();

            saveFileDialog1.Filter = "Backup Files ( *." + BackupFileExtention + " ) | *." + BackupFileExtention;
        }

        private void btn_BackupFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMddHHmmss." + BackupFileExtention);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                txt_BackupFile.Text = saveFileDialog1.FileName;
        }

        private void ZipFile(string sSourceDir, string sFileName)
        {
            string[] astrFileNames = Directory.GetFiles(sSourceDir);
            Crc32 objCrc32 = new Crc32();
            ZipOutputStream strmZipOutputStream;
            strmZipOutputStream = new ZipOutputStream(File.Create(sFileName));
            strmZipOutputStream.SetLevel(6);
            //    Compression;
            //Level:
            //    (0 - 9);
            //    0    //    no(Compression);
            //    9    //    maximum;
            //    compression;
            //string strFile;
            foreach (string strFile in astrFileNames)
            {
                FileStream strmFile = File.OpenRead(strFile);
                byte[] abyBuffer = new byte[strmFile.Length];
                strmFile.Read(abyBuffer, 0, abyBuffer.Length);
                ZipEntry objZipEntry = new ZipEntry(GetFileNameFromFullPath(strFile));
                objZipEntry.DateTime = DateTime.Now;
                objZipEntry.Size = strmFile.Length;
                strmFile.Close();
                objCrc32.Reset();
                objCrc32.Update(abyBuffer);
                objZipEntry.Crc = objCrc32.Value;
                strmZipOutputStream.PutNextEntry(objZipEntry);
                strmZipOutputStream.Write(abyBuffer, 0, abyBuffer.Length);
            }
            strmZipOutputStream.Finish();
            strmZipOutputStream.Close();
        }

        public static string GetFileNameFromFullPath(string sPath)
        {
            // Dim n As Integer = InStrRev(sPath, "\")
            // If n > 0 Then
            //     Return Trim(Mid(sPath, n + 1, Len(sPath)))
            // End If
            return sPath;
        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_BackupFile.Text.Trim()))
            {
                saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMddHHmmss." + BackupFileExtention);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    txt_BackupFile.Text = saveFileDialog1.FileName;
                else
                    return;
            }

            if (!string.IsNullOrEmpty(txt_BackupFile.Text.Trim()))
            {
                try
                {
                    panel1.Enabled = false;
                    pb_Loading.Visible = true;
                    lbl_Loading.Visible = true;
                    this.Refresh();

                    System.IO.DirectoryInfo dir = new DirectoryInfo(System.Windows.Forms.Application.StartupPath.ToString() + "\\temp\\" + DateTime.Now.ToFileTimeUtc().ToString());

                    dir.Create();
                    txt_BackupDir.Text = dir.FullName;

                    BackupDatabase(txt_BackupDir.Text + "\\" + DateTime.Now.ToFileTimeUtc().ToString());
                    ZipFile(txt_BackupDir.Text, txt_BackupFile.Text);
                    //DirectoryInfo dir = new DirectoryInfo(txt_BackupDir.Text);
                    dir.Delete(true);
                    panel1.Enabled = true;
                    pb_Loading.Visible = false;
                    lbl_Loading.Visible = false;
                    this.Refresh();

                    MessageBox.Show("Backup Database berhasil", "Backup Database ", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Backup Database error : " + ex.Message, "Backup Database ", MessageBoxButtons.OK);
                }
            }
        }

        private void BackupDatabase(string BackupFile)
        {
            //pb_Loading.Dispose();
            pb_Loading.Maximum = 5;
            //pb_Loading.Step = 1;
            //pb_Loading.Show();
            pb_Loading.Value = 0;
            this.Refresh();
            SQLServer2Class server = new SQLServer2Class();
            Backup2Class backUp = new Backup2Class();
            Databases dbs;
            Database2 db2;
            server.DisConnect();

            //if (server.JobServer.Status == SQLDMO_SVCSTATUS_TYPE.SQLDMOSvc_Stopped || server.JobServer.Status == SQLDMO_SVCSTATUS_TYPE.SQLDMOSvc_Paused)
            //{
            //    server.JobServer.Start();
            //    server.JobServer.AutoStart;
            //}
            //else
            //{
            //    server.JobServer.Stop();
            //    server.JobServer.Start();
            //    server.JobServer.AutoStart;
            //}
            pb_Loading.Value = 1;
            this.Refresh();
            server.LoginSecure = true;

            ISession m_session = NHibernateHttpModule.CurrentSession;
            SqlConnection cn = (SqlConnection)m_session.Connection;

            server.Connect(cn.DataSource, cn.Database, "INVENTORI$");
            dbs = server.Databases;
            db2 = (Database2)dbs.Item(cn.Database, null);

            pb_Loading.Value = 2;
            this.Refresh();
            backUp.Database = db2.Name;
            backUp.Files = @"[" + BackupFile + "]";

            pb_Loading.Value = 3;
            this.Refresh();
            backUp.Action = SQLDMO_BACKUP_TYPE.SQLDMOBackup_Database;
            pb_Loading.Value = 4;
            this.Refresh();
            backUp.SQLBackup(server);
            pb_Loading.Value = 5;
            this.Refresh();

            server.DisConnect();
            backUp = null;
            server = null;
        }

        private void FormBackupDatabase_Load(object sender, EventArgs e)
        {
            if (lbl_Auto.Text == true.ToString())
            {
                this.Size = new Size(this.Size.Width, 145);
                this.Text = "Otomatisasi Backup Database";
                panel1.Visible = false;
                pb_Loading.Location = new Point(pb_Loading.Location.X, 7);
                lbl_Loading.Location = new Point(lbl_Loading.Location.X, 30);
                this.Refresh();

                //System.Threading.Thread.Sleep(5000);
                btn_Backup_Click(null, null);
                this.Close();
            }
        }
    }
}

