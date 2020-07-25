using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.Module;

namespace Inventori.Contractor.Forms
{
    public partial class FormPeriodFilterReport : FormParentForContractor
    {
        public FormPeriodFilterReport()
        {
            InitializeComponent();
        }

        private void FormDateFilterReport_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SetMonthsComboBox(comboBox_Month);
            
            if (DateTime.Today.Month - 1 == 0)
            {
                comboBox_Month.SelectedIndex = 11;
                numericUpDown_Year.Value = Convert.ToDecimal(DateTime.Today.Year - 1);
            }
            else
            {comboBox_Month.SelectedIndex = DateTime.Today.Month - 1;
                numericUpDown_Year.Value = Convert.ToDecimal(DateTime.Today.Year);
            }


            ModuleControlSettings.SetMonthsComboBox(comboBox_MonthTo);
            comboBox_MonthTo.SelectedIndex = DateTime.Today.Month;
            numericUpDown_YearTo.Value = Convert.ToDecimal(DateTime.Today.Year);
        }
    }
}