using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

using System.Reflection;
using System.IO;
using System.Data.SqlClient;

namespace Inventori.Billiard.InstallerDB
{
    [RunInstaller(true)]
    public partial class InstallerDB : Installer
    {
        SqlConnection cn;
        SqlCommand cmd;
        public InstallerDB()
        {
            InitializeComponent();
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
            ExecuteSQL(strDBName, GetSqlFile("create_V_TRANSACTION_DETAIL.sql"));
            ExecuteSQL(strDBName, GetSqlFile("create_V_ITEM_DETAIL.sql"));
            ExecuteSQL(strDBName, GetSqlFile("create_V_TOTAL_TRANSACTION_DETAIL.sql"));
            ExecuteSQL(strDBName, GetSqlFile("create_V_SUPPLIER_DETAIL.sql"));
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(local)\\SQLExpress;Integrated Security=True;Persist Security Info=False";
            GetQuery("INVENTORI");
        }

    }
}