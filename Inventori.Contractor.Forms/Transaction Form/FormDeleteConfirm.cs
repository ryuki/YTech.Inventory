using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.Contractor.Data;
using Inventori.Facade;

namespace Inventori.Contractor.Forms
{
    public partial class FormDeleteConfirm : Form
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private DeletePin delPin;

        public enum DeletePin
        {
            Giro,
            PO
        }
        public FormDeleteConfirm(DeletePin _delpin)
        {
            InitializeComponent();
            delPin = _delpin;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            TContractorSetting conSet = null;
            if (delPin == DeletePin.Giro)
            {
                 conSet = (TContractorSetting)DataMaster.GetObjectByProperty(typeof(TContractorSetting), TContractorSetting.ColumnNames.SettingId, AppCode.AssemblyProduct,TContractorSetting.ColumnNames.GiroDeletePin,deletePinTextBox.Text);
            }
            else if (delPin == DeletePin.PO)
            {
                conSet = (TContractorSetting)DataMaster.GetObjectByProperty(typeof(TContractorSetting), TContractorSetting.ColumnNames.SettingId, AppCode.AssemblyProduct, TContractorSetting.ColumnNames.PoDeletePin, deletePinTextBox.Text);
            }
         
            if (conSet != null)
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