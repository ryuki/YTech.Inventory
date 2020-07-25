using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.Module;

namespace Inventori.Apotek.Forms
{
    public partial class FormDateFilterReport : FormParentForApotek
    {
        public FormDateFilterReport()
        {
            InitializeComponent();
        }

        private void FormDateFilterReport_Load(object sender, EventArgs e)
        {
            dt_From.Value = DateTime.Today.AddMonths(-1);
            dt_To.Value = DateTime.Today;
            ModuleControlSettings.SetDateTimePicker(dt_From, false);
            ModuleControlSettings.SetDateTimePicker(dt_To, false);
        }
    }
}