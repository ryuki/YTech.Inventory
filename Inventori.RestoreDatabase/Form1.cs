using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventori.RestoreDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Backup_Click(object sender, EventArgs e)
        {
            FormBackupDatabase b = new FormBackupDatabase();
            b.Show(this);
        }

        private void button_Restore_Click(object sender, EventArgs e)
        {
            FormRestoreDatabase r = new FormRestoreDatabase();
            r.Show(this);
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            SqlConnection cn= new SqlConnection("Server=" + txt_Server.Text + ";initial catalog=" + txt_DB.Text + ";User Id=" + txt_User.Text + ";Password=" + txt_Pass.Text + ";");
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = txt_Query.Text;
                cmd.ExecuteNonQuery();
                //SqlDataAdapter adp = new SqlDataAdapter(txt_Query.Text, cn);
                //DataSet ds = new DataSet();
                //adp.Fill(ds);
                //bindingSource1.DataSource = ds;
                //dataGridView1.DataSource = ds;
                //dataGridView1.AutoGenerateColumns = true;
                //dataGridView1.Show();

            }
                
            finally
            {
                cn.Close();
            }

        }
    }
}