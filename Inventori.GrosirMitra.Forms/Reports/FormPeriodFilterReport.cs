using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.Module;

namespace Inventori.GrosirMitra.Forms
{
    public partial class FormPeriodFilterReport : FormParentForGrosirMitra
    {
        public FormPeriodFilterReport()
        {
            InitializeComponent();
        }

        private void FormDateFilterReport_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SetMonthsComboBox(comboBox_Month);
            comboBox_Month.SelectedIndex = DateTime.Today.Month - 1;
            numericUpDown_Year.Value = Convert.ToDecimal(DateTime.Today.Year);
        }
    }
}