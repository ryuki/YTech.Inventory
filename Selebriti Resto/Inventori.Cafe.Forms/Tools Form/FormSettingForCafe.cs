using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Inventori.Cafe.Data;
using Inventori.Data;
using Inventori.Facade;
using Inventori.Module;
using Inventori.Forms;
using Inventori.Data;

namespace Inventori.Cafe.Forms
{
    public partial class FormSettingForCafe : Inventori.Forms.FormSetting
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MSetting set;
        private TCafeSetting cafeSet;
        public FormSettingForCafe()
        {
            InitializeComponent();
        }

        private void FormSettingForCafe_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MSetting, lbl_UserName.Text);
            BindData();
            autoBackupCheckBox_CheckedChanged(null, null);
        }

        private void BindData()
        {
            set = (MSetting)DataMaster.GetObjectByProperty(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            if (set != null)
                mSettingDetail();

            cafeSet = (TCafeSetting)DataMaster.GetObjectByProperty(typeof(TCafeSetting), TCafeSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            if (cafeSet != null)
                cafeSettingDetail();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //set = (MSetting)DataMaster.GetObjectByProperty(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            bool isSave = (set == null);
            if (isSave)
                set = new MSetting();
            set.AutoPrintSales = autoPrintSalesCheckBox.Checked;
            set.CompanyAddress = companyAddressTextBox.Text;
            set.CompanyCity = companyCityTextBox.Text;
            set.CompanyName = companyNameTextBox.Text;
            set.CompanyTelp = companyTelpTextBox.Text;
            set.AutoBackup = autoBackupCheckBox.Checked;
            set.BackupDir = backupDirTextBox.Text;
            set.FacturNoFormat = facturNoFormatTextBox.Text;
            set.SettingId = AppCode.AssemblyProduct;
            set.ModifiedBy = lbl_UserName.Text;
            set.ModifiedDate = DateTime.Now;
            if (isSave)
                DataMaster.SavePersistence(set);
            else
                DataMaster.UpdatePersistence(set);

            isSave = (cafeSet == null);
            if (isSave)
                cafeSet = new TCafeSetting();
            cafeSet.ExportedDir = exportedDirTextBox.Text;
            cafeSet.DiscountPassword = discountPasswordTextBox.Text;
            cafeSet.TelpNoSaranKritik = telpNoSaranKritikTextBox.Text;
            cafeSet.SettingId = AppCode.AssemblyProduct;
            cafeSet.ModifiedBy = lbl_UserName.Text;
            cafeSet.ModifiedDate = DateTime.Now;
            if (isSave)
                DataMaster.SavePersistence(cafeSet);
            else
                DataMaster.UpdatePersistence(cafeSet);

            ModuleControlSettings.SaveLog(ListOfAction.Update, string.Empty, ListOfTable.MSetting, lbl_UserName.Text);
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

        private void mSettingDetail()
        {
            companyNameTextBox.Text = set.CompanyName;
            companyAddressTextBox.Text = set.CompanyAddress;
            companyCityTextBox.Text = set.CompanyCity;
            companyTelpTextBox.Text = set.CompanyTelp;
            autoPrintSalesCheckBox.Checked = set.AutoPrintSales;
            autoBackupCheckBox.Checked = set.AutoBackup;
            backupDirTextBox.Text = set.BackupDir;
            facturNoFormatTextBox.Text = set.FacturNoFormat;
            facturNoLengthNumericUpDown.Value = int.Parse(set.FacturNoLength.ToString());
        }

        private void cafeSettingDetail()
        {
            exportedDirTextBox.Text = cafeSet.ExportedDir;
            discountPasswordTextBox.Text = cafeSet.DiscountPassword;
            telpNoSaranKritikTextBox.Text = cafeSet.TelpNoSaranKritik;
        }

        private void button_BrowseExport_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = exportedDirTextBox.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                exportedDirTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

    }
}

