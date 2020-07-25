using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.GrosirMitra.Data;
using Inventori.Facade;

namespace Inventori.GrosirMitra.Forms
{
    public partial class FormDeleteConfirm : FormParentForGrosirMitra
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private Pin pin;

        public enum Pin
        {
            Discount
        }
        public FormDeleteConfirm(Pin _pin)
        {
            InitializeComponent();
            pin = _pin;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            TGrosirSetting motorSet = null;
            if (pin == Pin.Discount)
            {
                motorSet = (TGrosirSetting)DataMaster.GetObjectByProperty(typeof(TGrosirSetting), TGrosirSetting.ColumnNames.SettingId, AppCode.AssemblyProduct, TGrosirSetting.ColumnNames.DiscountPin, discountPinTextBox.Text);
            }

            if (motorSet != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Refresh();
                this.Close();
            }
            else
                MessageBox.Show("Pin yang anda input salah.","Pin Salah",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void deletePinTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                btn_OK.Focus();
            }
        }
    }
}