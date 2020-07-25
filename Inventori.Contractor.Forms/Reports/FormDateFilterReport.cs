using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Inventori.Data;
using Inventori.Facade;
using Inventori.Module;

namespace Inventori.Contractor.Forms
{
    public partial class FormDateFilterReport : Form
    {
        public FormDateFilterReport()
        {
            InitializeComponent();
        }

        private void FormDateFilterReport_Load(object sender, EventArgs e)
        {
            dt_From.Value = DateTime.Now.AddDays(-7);
            dt_To.Value = DateTime.Now;
            ModuleControlSettings.SetDateTimePicker(dt_From, true);
            ModuleControlSettings.SetDateTimePicker(dt_To, true);
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}