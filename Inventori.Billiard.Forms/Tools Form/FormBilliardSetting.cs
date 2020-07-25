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
using Inventori.Forms;
using Inventori.Billiard.Data;

namespace Inventori.Billiard.Forms
{
    public partial class FormBilliardSetting : Inventori.Forms.FormSetting
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        public FormBilliardSetting()
        {
            InitializeComponent();
        }

        private void FormBilliardSetting_Load(object sender, EventArgs e)
        {
            BindData();
            autoBackupCheckBox_CheckedChanged(null, null);
        }

        private void BindData()
        {
            mSettingBindingSource.Clear();
            if (DataMaster.GetListEq(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct).Count > 0)
            {
                mSettingBindingSource.DataSource = DataMaster.GetListEq(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
                tBilliardSettingBindingSource.DataSource = DataMaster.GetListEq(typeof(TBilliardSetting), TBilliardSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            MSetting set = (MSetting)DataMaster.GetObjectByProperty(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            set.AutoPrintSales = autoPrintSalesCheckBox.Checked;
            set.CompanyAddress = companyAddressTextBox.Text;
            set.CompanyCity = companyCityTextBox.Text;
            set.CompanyName = companyNameTextBox.Text;
            set.CompanyTelp = companyTelpTextBox.Text;
            set.AutoBackup = autoBackupCheckBox.Checked;
            set.BackupDir = backupDirTextBox.Text;
            set.FacturNoFormat = facturNoFormatTextBox.Text;
            DataMaster.UpdatePersistence(set);

            TBilliardSetting tbil = (TBilliardSetting)DataMaster.GetObjectByProperty(typeof(TBilliardSetting), TBilliardSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            tbil.BiliardItemPrice = biliardItemPriceNumericUpDown.Value;
            tbil.BiliardItemPriceMini = biliardItemPriceMiniNumericUpDown.Value;
            tbil.BiliardItemPriceVip = biliardItemPriceVipNumericUpDown.Value;

            tbil.FullfillPrice = fullfillPriceNumericUpDown.Value;
            tbil.MinimumPlay = minimumPlayNumericUpDown.Value;
            tbil.QuitTimeout = quitTimeoutNumericUpDown.Value;
            DataMaster.UpdatePersistence(tbil);

            BindData();
        }

        private void autoBackupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            backupDirTextBox.Enabled = autoBackupCheckBox.Checked;
            btn_Browse.Enabled = autoBackupCheckBox.Checked;
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = backupDirTextBox.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                backupDirTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}

