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
using Inventori.Contractor.Data;
using System.IO;

namespace Inventori.Contractor.Forms
{
    public partial class FormSettingForContractor : Inventori.Forms.FormSetting
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MSetting set;
        private TContractorSetting conSet;

        public FormSettingForContractor()
        {
            InitializeComponent();
        }

        private void FormSettingForContractor_Load(object sender, EventArgs e)
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

            conSet = (TContractorSetting)DataMaster.GetObjectByProperty(typeof(TContractorSetting), TContractorSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            if (conSet != null)
                conSettingDetail();
        }

        private void conSettingDetail()
        {
            giroDeletePinTextBox.Text = conSet.GiroDeletePin;
            poDeletePinTextBox.Text = conSet.PoDeletePin;

            Font f = new Font(conSet.CompanyNameFont, float.Parse(conSet.CompanyNameFontHeight.ToString()));
            ColorConverter cv = new ColorConverter();
            label_CompanyName.Font = f;
            label_CompanyName.ForeColor = (Color)cv.ConvertFromString(conSet.CompanyNameColour);            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            bool isSave = (set == null);
            if (isSave)
                set = new MSetting();
            set.AutoPrintSales = autoPrintSalesCheckBox.Checked;
            set.CompanyAddress = companyAddressTextBox.Text;
            set.CompanyAddress2 = companyAddress2TextBox.Text;

            if (label_ImageLogoLocation.Text != label_ImageLogoLocation.Name)
            {
                if (label_ImageLogoLocation.Text != tempFileLoc)
                {
                    FileInfo f = new FileInfo(label_ImageLogoLocation.Text);
                    FileStream fs = f.OpenRead();
                    byte[] data = new byte[fs.Length];
                    fs.Read(data, 0, int.Parse(fs.Length.ToString()));
                    fs.Flush();
                    fs.Close();

                    set.CompanyLogo = data;

                    fs.Dispose();

                }
            }

            if (label_ImageLogoLocation.Text == tempFileLoc)
            {
                try
                {
                    FileInfo f = new FileInfo(label_ImageLogoLocation.Text);
                    f.Directory.Delete(true);
                }
                catch (Exception)
                {
                }
            }

            set.CompanyFax = companyFaxTextBox.Text;
            set.CompanyNpwp = companyNpwpTextBox.Text;
            set.CompanyPkpDate = companyPkpDateDateTimePicker.Value;

            set.CompanyCity = companyCityTextBox.Text;
            set.CompanyName = companyNameTextBox.Text;
            set.CompanyTelp = companyTelpTextBox.Text;
            set.AutoBackup = autoBackupCheckBox.Checked;
            set.BackupDir = backupDirTextBox.Text;
            set.FacturNoFormat = facturNoFormatTextBox.Text;
            set.FacturNoLength = Convert.ToInt32(facturNoLengthNumericUpDown.Value);
            set.SettingId = AppCode.AssemblyProduct;
            set.ModifiedBy = lbl_UserName.Text;
            set.ModifiedDate = DateTime.Now;
            if (isSave)
                DataMaster.SavePersistence(set);
            else
                DataMaster.UpdatePersistence(set);


            isSave = (conSet == null);
            if (isSave)
                conSet = new TContractorSetting();

            conSet.GiroDeletePin = giroDeletePinTextBox.Text;
            conSet.PoDeletePin = poDeletePinTextBox.Text;
            conSet.CompanyNameFont = label_CompanyName.Font.Name;
            conSet.CompanyNameFontHeight = Convert.ToInt32(Math.Floor(Convert.ToDecimal(label_CompanyName.Font.Size)));
            conSet.CompanyNameColour = label_CompanyName.ForeColor.Name;
            conSet.SettingId = AppCode.AssemblyProduct;
            if (isSave)
                DataMaster.SavePersistence(conSet);
            else
                DataMaster.UpdatePersistence(conSet);

            ModuleControlSettings.SaveLog(ListOfAction.Update, string.Empty, ListOfTable.MSetting, lbl_UserName.Text);
            BindData();

            MessageBox.Show("Konfigurasi Program berhasil disimpan.", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        string tempFileLoc;
        private void mSettingDetail()
        {
            companyNameTextBox.Text = set.CompanyName;
            companyAddressTextBox.Text = set.CompanyAddress;
            companyAddress2TextBox.Text = set.CompanyAddress2;
            companyFaxTextBox.Text = set.CompanyFax;
            companyNpwpTextBox.Text = set.CompanyNpwp;
            companyPkpDateDateTimePicker.Value = set.CompanyPkpDate;
            companyCityTextBox.Text = set.CompanyCity;
            companyTelpTextBox.Text = set.CompanyTelp;
            autoPrintSalesCheckBox.Checked = set.AutoPrintSales;
            autoBackupCheckBox.Checked = set.AutoBackup;
            backupDirTextBox.Text = set.BackupDir;
            facturNoFormatTextBox.Text = set.FacturNoFormat;
            facturNoLengthNumericUpDown.Value = decimal.Parse(set.FacturNoLength.ToString());

            if (set.CompanyLogo.Length > 0)
            {
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\temp\\");
                if (!dir.Exists)
                    dir.Create();

                tempFileLoc = dir.FullName + DateTime.Now.ToFileTimeUtc().ToString();
                byte[] barrImg = set.CompanyLogo;
                FileStream fs = new FileStream(tempFileLoc, FileMode.CreateNew, FileAccess.Write);
                fs.Write(barrImg, 0, barrImg.Length);
                fs.Flush();
                fs.Close();

                companyLogoPictureBox.Image = Image.FromFile(tempFileLoc);
                label_ImageLogoLocation.Text = tempFileLoc;
            }

        }

        private void button_Font_Click(object sender, EventArgs e)
        {
            if (conSet != null)
            {
                fontDialog1.Font = label_CompanyName.Font;
                fontDialog1.Color = label_CompanyName.ForeColor;
            }

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label_CompanyName.Font = fontDialog1.Font;
                label_CompanyName.ForeColor = fontDialog1.Color;
            }
        }

        private void poDeletePinLabel_Click(object sender, EventArgs e)
        {

        }
    }
}