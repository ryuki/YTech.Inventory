using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using SQLDMO;
using System.Runtime.InteropServices;
//using ICSharpCode.SharpZipLib.Zip;
//using ICSharpCode.SharpZipLib.Checksums;
using System.IO;

using System.Data.OleDb;

using Inventori.BackupRestore.Class;

namespace Inventori.Forms
{
    public partial class FormBackupDatabase : Inventori.Forms.FormParentForToolsForm
    {
        string BackupFileExtention = "backup";
        public FormBackupDatabase()
        {
            InitializeComponent();

            saveFileDialog1.Filter = "Backup Files ( *." + BackupFileExtention + " ) | *." + BackupFileExtention;
            ServerName = System.Configuration.ConfigurationManager.AppSettings["ServerName"].ToString();
            pServer = ServerName + "\\SQLEXPRESS";

            System.IO.DirectoryInfo dir = new DirectoryInfo(System.Windows.Forms.Application.StartupPath.ToString() + "\\temp\\" + DateTime.Now.ToFileTimeUtc().ToString());

            dir.Create();
            txt_BackupDir.Text = dir.FullName + "\\";
        }

        string ServerName;

        string pServer;
        string pDatabase = "INVENTORI";
        string pUserName = "INVENTORI";
        string pPassword = "INVENTORI$";
        string pNoOfRow = "TOP 100 PERCENT *";
        clsScript oScript = new clsScript();

        private void FormBackupDatabase_Load(object sender, EventArgs e)
        {
            Inventori.Module.ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.Database, lbl_UserName.Text);
            oScript.ConnectDatabaseWithRefresh(pServer, pDatabase, pUserName, pPassword);

            if (lbl_Auto.Text == true.ToString())
            {
                this.Size = new Size(this.Size.Width, 145);
                this.Text = "Otomatisasi Backup Database";
                panel1.Visible = false;
                pb_Loading.Location = new Point(pb_Loading.Location.X, 7);
                lbl_Loading.Location = new Point(lbl_Loading.Location.X, 30);
                this.Refresh();

                System.Threading.Thread.Sleep(5000);
                btn_Backup_Click(null, null);
                this.Close();
            }
        }

        //private void ZipFile(string sSourceDir, string sFileName)
        //{
        //    string[] astrFileNames = Directory.GetFiles(sSourceDir);
        //    Crc32 objCrc32 = new Crc32();
        //    ZipOutputStream strmZipOutputStream;
        //    strmZipOutputStream = new ZipOutputStream(File.Create(sFileName));
        //    strmZipOutputStream.SetLevel(6);
        //    //    Compression;
        //    //Level:
        //    //    (0 - 9);
        //    //    0    //    no(Compression);
        //    //    9    //    maximum;
        //    //    compression;
        //    //string strFile;
        //    foreach (string strFile in astrFileNames)
        //    {
        //        FileStream strmFile = File.OpenRead(strFile);
        //        byte[] abyBuffer = new byte[strmFile.Length];
        //        strmFile.Read(abyBuffer, 0, abyBuffer.Length);
        //        ZipEntry objZipEntry = new ZipEntry(GetFileNameFromFullPath(strFile));
        //        objZipEntry.DateTime = DateTime.Now;
        //        objZipEntry.Size = strmFile.Length;
        //        strmFile.Close();
        //        objCrc32.Reset();
        //        objCrc32.Update(abyBuffer);
        //        objZipEntry.Crc = objCrc32.Value;
        //        strmZipOutputStream.PutNextEntry(objZipEntry);
        //        strmZipOutputStream.Write(abyBuffer, 0, abyBuffer.Length);
        //    }
        //    strmZipOutputStream.Finish();
        //    strmZipOutputStream.Close();
        //}

        //public static string GetFileNameFromFullPath(string sPath)
        //{
        //    // Dim n As Integer = InStrRev(sPath, "\")
        //    // If n > 0 Then
        //    //     Return Trim(Mid(sPath, n + 1, Len(sPath)))
        //    // End If
        //    return sPath;
        //}

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            grid_Tables.DataSource = oScript.GetTableNames(pServer, pDatabase, pUserName, pPassword, pNoOfRow);

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



                    ExportDatabase(txt_BackupDir.Text + "\\" + DateTime.Now.ToFileTimeUtc().ToString());
                    clsZip.ZipIT(txt_BackupDir.Text, txt_BackupFile.Text);
                    DirectoryInfo dir = new DirectoryInfo(txt_BackupDir.Text);
                    dir.Delete(true);
                    panel1.Enabled = true;
                    pb_Loading.Visible = false;
                    lbl_Loading.Visible = false;
                    this.Refresh();

                    Inventori.Module.ModuleControlSettings.SaveLog(ListOfAction.Backup, txt_BackupFile.Text, ListOfTable.Database, lbl_UserName.Text);
                    MessageBox.Show("Backup Database berhasil", "Backup Database ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Backup Database error : " + ex.Message, "Backup Database ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private void BackupDatabase(string BackupFile)
        //{
        //    //pb_Loading.Dispose();
        //    pb_Loading.Maximum = 5;
        //    //pb_Loading.Step = 1;
        //    //pb_Loading.Show();
        //    pb_Loading.Value = 0;
        //    this.Refresh();
        //    SQLServer2Class server = new SQLServer2Class();
        //    Backup2Class backUp = new Backup2Class();
        //    Databases dbs;
        //    Database2 db2;
        //    server.DisConnect();

        //    //if (server.JobServer.Status == SQLDMO_SVCSTATUS_TYPE.SQLDMOSvc_Stopped || server.JobServer.Status == SQLDMO_SVCSTATUS_TYPE.SQLDMOSvc_Paused)
        //    //{
        //    //    server.JobServer.Start();
        //    //    server.JobServer.AutoStart;
        //    //}
        //    //else
        //    //{
        //    //    server.JobServer.Stop();
        //    //    server.JobServer.Start();
        //    //    server.JobServer.AutoStart;
        //    //}
        //    pb_Loading.Value = 1;
        //    this.Refresh();
        //    server.LoginSecure = true;



        //    server.Connect(ServerName + "\\SQLEXPRESS", "INVENTORI", "INVENTORI$");
        //    dbs = server.Databases;
        //    db2 = (Database2)dbs.Item("INVENTORI", null);

        //    pb_Loading.Value = 2;
        //    this.Refresh();
        //    backUp.Database = db2.Name;
        //    backUp.Files = @"[" + BackupFile + "]";

        //    pb_Loading.Value = 3;
        //    this.Refresh();
        //    backUp.Action = SQLDMO_BACKUP_TYPE.SQLDMOBackup_Database;
        //    pb_Loading.Value = 4;
        //    this.Refresh();
        //    backUp.SQLBackup(server);
        //    pb_Loading.Value = 5;
        //    this.Refresh();

        //    server.DisConnect();
        //    backUp = null;
        //    server = null;
        //}

        private void ExportDatabase(string BackupFile)
        {
            //Initialize a datatable. This datatable will hold all database objects and their scripts.
            DataTable DTScripts = new DataTable();
            DTScripts.Columns.Add("ObjectName", "".GetType());
            DTScripts.Columns.Add("ObjectType", "".GetType());
            //Following column is to hold Object's script. i.e. statement like create table, create view etc...
            DTScripts.Columns.Add("ScriptSQL", "".GetType());

            //Following procedure will generate scripts for selected tables using SQL-DMO. This procedure also back up data using BCP functions in SQL-DMO library.
            //Script file and data files will be saved in temporary folder.
            GenerateFiles(ref DTScripts, ref grid_Tables, true, "table", true);

        }

        private void GenerateFiles(ref DataTable DTScripts, ref DataGridView dg, bool bExportData, string pObjectType, bool bGenerateScripts)
        {
            if (!(dg.DataSource == null))
            {
                // Convert data source of grid to datatable.
                DataTable DT = ((DataTable)(dg.DataSource));
                int i;
                for (i = 0; (i
                            <= (DT.Rows.Count - 1)); i++)
                {
                    // Backup this object only if user has selected it.
                    if (((bool)DT.Rows[i]["Select"]) == true)
                    {
                        // Generate script for selected object.
                        if (bGenerateScripts)
                        {
                            //string sSQL = oScript.GenerateScript(pServer, pDatabase, pUserName, pPassword, pObjectType, DT.Rows[i][(pObjectType + "NAME")].ToString());
                            string sSQL = "";
                            DTScripts.Rows.Add(new object[] {
                                    DT.Rows[i][(pObjectType + "NAME")],
                                    pObjectType,
                                    sSQL});
                        }
                        // Export data if this object is a table.
                        if (bExportData)
                        {
                            oScript.ExportData(pServer, pDatabase, pUserName, pPassword, DT.Rows[i][(pObjectType + "NAME")].ToString(), DT.Rows[i]["Condition"].ToString(), DT.Rows[i]["TotalRows"].ToString(), txt_BackupDir.Text);
                        }
                    }
                }
                DTScripts.TableName = "SQLScripts";
                DTScripts.WriteXml((txt_BackupDir.Text + "SQLScripts.xml"));
            }
        }
    }
}

