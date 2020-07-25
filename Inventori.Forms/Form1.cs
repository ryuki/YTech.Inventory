using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FormSearchCustomer f_SearchCustomer;
        FormMasterCustomer f_MasterCustomer;
        private void button1_Click(object sender, EventArgs e)
        {
            f_SearchCustomer = new FormSearchCustomer();
            f_SearchCustomer.CustomerHasSelected += new EventHandler(f_SearchCustomer_CustomerHasSelected);
            f_SearchCustomer.ShowDialog();
        }

        private void f_SearchCustomer_CustomerHasSelected(object sender, EventArgs e)
        {
            if (f_SearchCustomer.grid_Search.Rows.Count > 0)
            {
                txt_CustId.Text = f_SearchCustomer.grid_Search.Rows[f_SearchCustomer.grid_Search.CurrentRow.Index].Cells[0].Value.ToString();
                txt_CustName.Text = f_SearchCustomer.grid_Search.Rows[f_SearchCustomer.grid_Search.CurrentRow.Index].Cells[1].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f_MasterCustomer = new FormMasterCustomer();
            f_MasterCustomer.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormMasterEmployee f_Emp = new FormMasterEmployee();
            f_Emp.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormMasterGroup f_Group = new FormMasterGroup();
            f_Group.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormMasterItem f_Item = new FormMasterItem();
            f_Item.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormMasterDesk f_Desk = new FormMasterDesk();
            f_Desk.ShowDialog();
        }
    }
}