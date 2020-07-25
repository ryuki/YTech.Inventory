using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Reflection;
using System.IO;
using System.Data.SqlClient;
using Inventori.Module;
using System.Diagnostics;

namespace Inventori.Contractor.InstallerDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection cn;
        SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("net start \"SQL Server (SQLEXPRESS)\" >> c:\\log.txt");
            //System.Diagnostics.Process.Start("isql -S (local)\\SQLEXPRESS -E -d \"MASTER\" -Q \"EXEC xp_instance_regwrite N'HKEY_LOCAL_MACHINE', N'Software\\Microsoft\\MSSQLServer\\MSSQLServer', N'LoginMode', REG_DWORD, 2\" >> c:\\log.txt");
            //System.Diagnostics.Process.Start("net stop \"SQL Server (SQLEXPRESS)\" >> c:\\log.txt");
            //System.Diagnostics.Process.Start("net start \"SQL Server (SQLEXPRESS)\" >> c:\\log.txt");

          

            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(local)\\SQLExpress;Integrated Security=True;Persist Security Info=False";
            GetQuery("INVENTORI");
        }

        private string GetSqlFile(string nama)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Stream strm = asm.GetManifestResourceStream(asm.GetName().Name + "." + nama);
            StreamReader rd = new StreamReader(strm);
            return rd.ReadToEnd();
        }

        private void ExecuteSQL(string DBName, string sql)
        {
            try
            {
                cmd = new SqlCommand(sql, cn);
                cn.Open();
                cmd.Connection.ChangeDatabase(DBName);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
            }
        }

        private void GetQuery(string strDBName)
        {
            
            //ExecuteSQL("MASTER", "USE [MASTER] EXEC xp_instance_regwrite N'HKEY_LOCAL_MACHINE', N'Software\\Microsoft\\MSSQLServer\\MSSQLServer', N'LoginMode', REG_DWORD, 2");

            //string ErrorInfo;
            //string NTServiceName = "SQL Server (SQLEXPRESS)";
            //NTServiceInfo si = new NTServiceInfo(NTServiceName, "");
            //try
            //{
            //    si.RestartServervice(false, out ErrorInfo);
            //}
            //catch (Exception)
            //{
            //}

            //try
            //{
            //    NTServiceName = "SQL Server Browser";
            //    si = new NTServiceInfo(NTServiceName, "");
            //    si.StartService(false, out ErrorInfo);
            //}
            //catch (Exception)
            //{
            //}

            ExecuteSQL("MASTER", @"USE [MASTER] IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'" + strDBName + "') DROP DATABASE [" + strDBName + "] CREATE DATABASE [" + strDBName + "] COLLATE SQL_Latin1_General_CP1_CI_AS");

            ExecuteSQL(strDBName, GetSqlFile("installDB.sql"));
            ExecuteSQL(strDBName, GetSqlFile("installTable.sql"));
            ExecuteSQL(strDBName, GetSqlFile("deleteView.sql"));
            ExecuteSQL(strDBName, GetSqlFile("create_V_MENU_USER.sql"));
            ExecuteSQL(strDBName, GetSqlFile("create_V_TOTAL_TRANSACTION_BY_ITEM.sql"));
            ExecuteSQL(strDBName, GetSqlFile("create_V_TRANSACTION_DETAIL.sql"));
        }

        private void button_Aut_Click(object sender, EventArgs e)
        {
            Process pro = new Process();
            pro.EnableRaisingEvents = false;
            pro.StartInfo.FileName = "DBConfig.bat";
            pro.Start();
            pro.WaitForExit();
            pro.Dispose();
        }
    }
}