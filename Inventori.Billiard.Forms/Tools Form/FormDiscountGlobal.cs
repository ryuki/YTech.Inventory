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
using Inventori.Billiard.Data;
using Inventori.Module;

namespace Inventori.Billiard.Forms
{
    public partial class FormDiscountGlobal : FormParentForBilliard
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        MDiscount disc;
        private Balloon.NET.BalloonHelp balloonHelp;

        public FormDiscountGlobal()
        {
            InitializeComponent();
            ModuleControlSettings.SetDaysComboBox(discDayComboBox);
            discDayComboBox.SelectedIndex = 0;
        }

        private void FormDiscountGlobal_Shown(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            disc = (MDiscount)DataMaster.GetObjectByProperty(typeof(MDiscount), "DiscDay", discDayComboBox.SelectedItem.ToString());
            if (disc == null)
            {
                ResetForm();
                return;
            }

            discTextBox.Text = disc.Disc.ToString();
            discDayComboBox.SelectedItem = disc.DiscDay;
            discTimeHourFromNumericUpDown.Value = disc.DiscTimeHourFrom;
            discTimeHourToNumericUpDown.Value = disc.DiscTimeHourTo;
            discTimeMinFromNumericUpDown.Value = disc.DiscTimeMinFrom;
            discTimeMinToNumericUpDown.Value = disc.DiscTimeMinTo;
        }

        private void discDayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void ResetForm()
        {
            discTextBox.Text = "0";
            //discDayComboBox.SelectedIndex = 0;
            discTimeHourFromNumericUpDown.Value = 0;
            discTimeHourToNumericUpDown.Value = 0;
            discTimeMinFromNumericUpDown.Value = 0;
            discTimeMinToNumericUpDown.Value = 0;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            disc = (MDiscount)DataMaster.GetObjectByProperty(typeof(MDiscount), "DiscDay", discDayComboBox.SelectedItem.ToString());
            bool isSave = (disc == null);
            if (isSave)
                disc = new MDiscount();

            disc.Disc = Convert.ToDecimal(discTextBox.Text);
            disc.DiscDay = discDayComboBox.SelectedItem.ToString();
            disc.DiscTimeHourFrom = Convert.ToInt32(discTimeHourFromNumericUpDown.Value);
            disc.DiscTimeHourTo = Convert.ToInt32(discTimeHourToNumericUpDown.Value);
            disc.DiscTimeMinFrom = Convert.ToInt32(discTimeMinFromNumericUpDown.Value);
            disc.DiscTimeMinTo = Convert.ToInt32(discTimeMinToNumericUpDown.Value);
            disc.ModifiedBy = lbl_UserName.Text;
            disc.ModifiedDate = DateTime.Now;            
            

            if (isSave)
                DataMaster.SavePersistence(disc);
            else
                DataMaster.UpdatePersistence(disc);

            BindData();
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (discDayComboBox.SelectedIndex == -1)
            {
                balloonHelp.Content = "Pilih hari";
                balloonHelp.ShowBalloon(discDayComboBox);
                discDayComboBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(discTextBox.Text))
            {
                balloonHelp.Content = "Diskon harus diisi";
                balloonHelp.ShowBalloon(discTextBox);
                discTextBox.Focus();
                return false;
            }
            return true;
        }

        private void RecreateBalloon()
        {
            balloonHelp = new Balloon.NET.BalloonHelp();
            balloonHelp.Icon = Properties.Resources.warning;
            balloonHelp.ShowCloseButton = false;
        }
    }
}