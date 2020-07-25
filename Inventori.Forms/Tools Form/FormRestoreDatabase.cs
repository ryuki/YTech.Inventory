using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using System.Data.SqlClient;
//using ICSharpCode.SharpZipLib.Zip;
//using ICSharpCode.SharpZipLib.Checksums;
using System.IO;

//using ActiveDs;
using Inventori.BackupRestore.Class;

namespace Inventori.Forms
{
    public partial class FormRestoreDatabase : Inventori.Forms.FormParentForToolsForm
    {
        string BackupFileExtention = "backup";

        string ServerName;

        string pServer;
        string pDatabase = "INVENTORI";
        string pUserName = "INVENTORI";
        string pPassword = "INVENTORI$";
        string pNoOfRow = "TOP 100 PERCENT *";
        clsScript oScript = new clsScript();

        public FormRestoreDatabase()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Backup Files ( *." + BackupFileExtention + " ) | *." + BackupFileExtention;

            ServerName = System.Configuration.ConfigurationManager.AppSettings["ServerName"].ToString();
            pServer = ServerName + "\\SQLEXPRESS";
        }

        private void FormRestoreDatabase_Load(object sender, EventArgs e)
        {
            Inventori.Module.ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.Database, lbl_UserName.Text);

            System.IO.DirectoryInfo dir = new DirectoryInfo(System.Windows.Forms.Application.StartupPath.ToString() + "\\temp\\" + DateTime.Now.ToFileTimeUtc().ToString());

            dir.Create();
            txt_BackupDir.Text = dir.FullName + "\\";
        }

        //        private void RestoreDatabase(string BackupFile)
        //        {

        //            //try
        //            //{
        //            string ServerName = System.Configuration.ConfigurationManager.AppSettings["ServerName"].ToString();
        //            SqlConnection cn = new SqlConnection("Server=" + ServerName + "\\SQLEXPRESS;initial catalog=MASTER;Integrated Security=SSPI");


        //            //
        //            string sqlCreateDB = @"USE [MASTER]
        //             IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'INVENTORI')	               CREATE DATABASE [INVENTORI]";

        //            string sqlCreateUser = @"USE [MASTER]
        //IF NOT EXISTS (SELECT * FROM MASTER.DBO.SYSLOGINS WHERE LOGINNAME = N'INVENTORI')
        //                                   CREATE LOGIN INVENTORI WITH PASSWORD = 'INVENTORI$'";

        //            string sqlRestore = @"USE [MASTER]
        //                     ALTER DATABASE INVENTORI 
        //                     SET RESTRICTED_USER WITH ROLLBACK IMMEDIATE
        //
        //                     USE [MASTER]
        //                     RESTORE DATABASE INVENTORI
        //                     FROM DISK = '" + BackupFile + "' WITH REPLACE ";

        //            sqlRestore += @" ALTER DATABASE [INVENTORI] SET  MULTI_USER WITH ROLLBACK IMMEDIATE
        //                          BACKUP LOG [INVENTORI] WITH TRUNCATE_ONLY 
        //
        //                          USE [INVENTORI]
        //                          IF EXISTS (SELECT * FROM DBO.SYSUSERS WHERE NAME = N'INVENTORI')
        //                              DROP USER [INVENTORI]
        //
        //                          IF NOT EXISTS (SELECT * FROM DBO.SYSUSERS WHERE NAME = N'INVENTORI')
        //                          BEGIN
        //                            CREATE USER [INVENTORI] FOR LOGIN [INVENTORI]
        //                            EXEC sp_addrolemember N'db_owner', N'INVENTORI'
        //                          END";
        //            //CREATE USER [INVENTORI] FOR LOGIN [INVENTORI]
        //            cn.Open();
        //            SqlCommand cmd = new SqlCommand(sqlCreateDB, cn);
        //            cmd.ExecuteNonQuery();

        //            cmd = new SqlCommand(sqlCreateUser, cn);
        //            cmd.ExecuteNonQuery();

        //            cmd = new SqlCommand(sqlRestore, cn);
        //            cmd.ExecuteNonQuery();

        //            cn.Dispose();
        //            cn.Close();
        //            SqlConnection.ClearAllPools();
        //            //}
        //            //catch (Exception)
        //            //{

        //            //    throw;
        //            //}
        //        }


        private void ImportData()
        {
            if (grid_Tables.DataSource != null)
            {
                DataTable dt = (DataTable)grid_Tables.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["status"] = oScript.ImportData(dt.Rows[i]["TableName"].ToString(), txt_BackupDir.Text, true);

                }
            }
        }

        private void btn_Restore_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_BackupFile.Text.Trim()))
            {
                try
                {
                    panel1.Enabled = false;
                    pb_Loading.Visible = true;
                    lbl_Loading.Visible = true;

                    pb_Loading.Maximum = 5;
                    pb_Loading.Value = 0;
                    this.Refresh();


                    pb_Loading.Value = 1;
                    this.Refresh();
                    //UnzipFile(txt_BackupFile.Text, txt_BackupDir.Text);

                    //string[] listOfFile = Directory.GetFiles(txt_BackupDir.Text);

                    //foreach (string f in listOfFile)
                    //{
                    //    pb_Loading.Value = 2;
                    //    this.Refresh();
                    //    //RestoreDatabase(f);

                    //}

                    pb_Loading.Value = 2;
                    this.Refresh();
                    ImportData();
                    //dir.Delete(true);

                    // DirectoryInfo dir = new DirectoryInfo(txt_BackupDir.Text);
                    // dir.Delete(true);
                    pb_Loading.Value = 5;
                    this.Refresh();
                    panel1.Enabled = true;
                    pb_Loading.Visible = false;
                    lbl_Loading.Visible = false;

                    Inventori.Module.ModuleControlSettings.SaveLog(ListOfAction.Restore, txt_BackupFile.Text, ListOfTable.Database, lbl_UserName.Text);
                    MessageBox.Show("Restore Database berhasil", "Restore Database ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Restore Database error : " + ex.Message, "Restore Database ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_BackupFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txt_BackupFile.Text = openFileDialog1.FileName;

            if (!string.IsNullOrEmpty(txt_BackupFile.Text.Trim()))
            {
                clsZip.UnzipIT(txt_BackupFile.Text, txt_BackupDir.Text);

                oScript.ConnectDatabaseWithRefresh(pServer, pDatabase, pUserName, pPassword);
                DataSet DS = new DataSet();
                DS.ReadXml(txt_BackupDir.Text + "SQLScripts.xml");

                if (DS.Tables.Count > 0)
                {
                    DataTable dt = DS.Tables[0];
                    dt.DefaultView.RowFilter = "ObjectType='table'";
                    Get_Objects(ref dt, ref grid_Tables, "TableName");
                }
            }
        }

        private void Get_Objects(ref DataTable DT, ref DataGridView dg, string ObjectTypeName)
        {
            DataTable DTObjects = new DataTable();
            DTObjects.Columns.Add(ObjectTypeName, "".GetType());
            DTObjects.Columns.Add("Select", true.GetType());
            DTObjects.Columns.Add("ScriptSQL", "".GetType());
            DTObjects.Columns.Add("Status", "".GetType());

            for (int i = 0; i < DT.DefaultView.Count; i++)
            {
                DTObjects.Rows.Add(new object[] {
                DT.DefaultView[i]["ObjectName"],
                true,
                DT.DefaultView[i]["ScriptSQL"]});
            }
            dg.DataSource = DTObjects;

        }

        //public static void UnzipFile(string sFileName, string sDirName)
        //{
        //    ZipInputStream s = new ZipInputStream(File.OpenRead(sFileName));
        //    ZipEntry theEntry;
        //    theEntry = s.GetNextEntry();
        //    while (!(theEntry == null))
        //    {
        //        string directoryName = Path.GetDirectoryName(theEntry.Name);
        //        string fileName = Path.GetFileName(theEntry.Name);
        //        Directory.CreateDirectory(sDirName);
        //        FileStream sWriter;
        //        sWriter = File.Create((sDirName + fileName));
        //        int size = 2048;
        //        byte[] data = new byte[2048];
        //        while (true)
        //        {
        //            size = s.Read(data, 0, 2048);
        //            if ((size > 0))
        //            {
        //                sWriter.Write(data, 0, size);
        //            }
        //            else
        //            {
        //                goto EX1;
        //            }
        //        }
        //    EX1:
        //        sWriter.Close();
        //        theEntry = s.GetNextEntry();
        //    }
        //    s.Close();
        //}

        //public void SetPermissions(String vPath, String UserName)
        //{
        //    ADsSecurity objADsSec;
        //    SecurityDescriptor objSecDes;
        //    AccessControlList objDAcl;
        //    AccessControlEntry objAce1;
        //    AccessControlEntry objAce2;
        //    Object objSIdHex;
        //    ADsSID objSId;

        //    objADsSec = new ADsSecurityClass();
        //    objSecDes = (SecurityDescriptor)(objADsSec.GetSecurityDescriptor("FILE://" + vPath));
        //    objDAcl = (AccessControlList)objSecDes.DiscretionaryAcl;

        //    objSId = new ADsSIDClass();
        //    objSId.SetAs((int)ADSSECURITYLib.ADS_SID_FORMAT.ADS_SID_SAM, UserName.ToString());
        //    objSIdHex = objSId.GetAs((int)ADSSECURITYLib.ADS_SID_FORMAT.ADS_SID_SDDL);

        //    // Add a new access control entry (ACE) object (objAce) so that the user has Full Control permissions on NTFS file system files.
        //    objAce1 = new AccessControlEntryClass();
        //    objAce1.Trustee = (objSIdHex).ToString();
        //    objAce1.AccessMask = (int)ActiveDs.ADS_RIGHTS_ENUM.ADS_RIGHT_GENERIC_ALL;
        //    objAce1.AceType = (int)ActiveDs.ADS_ACETYPE_ENUM.ADS_ACETYPE_ACCESS_ALLOWED;
        //    objAce1.AceFlags = (int)ActiveDs.ADS_ACEFLAG_ENUM.ADS_ACEFLAG_INHERIT_ACE | (int)ActiveDs.ADS_ACEFLAG_ENUM.ADS_ACEFLAG_INHERIT_ONLY_ACE | 1;
        //    objDAcl.AddAce(objAce1);

        //    // Add a new access control entry object (objAce) so that the user has Full Control permissions on NTFS file system folders.
        //    objAce2 = new AccessControlEntryClass();
        //    objAce2.Trustee = (objSIdHex).ToString();
        //    objAce2.AccessMask = (int)ActiveDs.ADS_RIGHTS_ENUM.ADS_RIGHT_GENERIC_ALL;
        //    objAce2.AceType = (int)ActiveDs.ADS_ACETYPE_ENUM.ADS_ACETYPE_ACCESS_ALLOWED;
        //    objAce2.AceFlags = (int)ActiveDs.ADS_ACEFLAG_ENUM.ADS_ACEFLAG_INHERIT_ACE | 1;
        //    objDAcl.AddAce(objAce2);

        //    objSecDes.DiscretionaryAcl = objDAcl;

        //    // Set permissions on the NTFS file system folder.
        //    objADsSec.SetSecurityDescriptor(objSecDes, "FILE://" + vPath);

        //}
    }
}

