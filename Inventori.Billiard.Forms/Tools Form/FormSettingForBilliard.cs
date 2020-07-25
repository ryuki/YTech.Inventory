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
using System.IO;

namespace Inventori.Billiard.Forms
{
    public partial class FormSettingForBilliard : Inventori.Forms.FormSetting
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private TBilliardSetting bilSet;
        private MSetting set;
        private TBonus bonus;

        public FormSettingForBilliard()
        {
            InitializeComponent();

            ModuleControlSettings.SetNumericUpDown(biliardItemPriceMiniNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(biliardItemPriceNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(biliardItemPriceVipNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(quitTimeoutNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(fullfillPriceNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(minimumPlayNumericUpDown); ModuleControlSettings.SetNumericUpDown(calculateTimeNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(toleranceTimeNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(quantityNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(refereeBonusNumericUpDown);

            //set max hour to 24
            decimal maxhour = 24;
            biliardItemHourFrom1NumericUpDown.Maximum = maxhour;
            biliardItemHourFrom2NumericUpDown.Maximum = maxhour;
            biliardItemHourFrom3NumericUpDown.Maximum = maxhour;
            biliardItemHourTo1NumericUpDown.Maximum = maxhour;
            biliardItemHourTo2NumericUpDown.Maximum = maxhour;
            biliardItemHourTo3NumericUpDown.Maximum = maxhour;

            itemIdTextBox.Validating += new CancelEventHandler(itemIdTextBox_Validating);
            itemIdTextBox.Enter += new EventHandler(itemIdTextBox_Enter);
            itemIdTextBox.Leave += new EventHandler(itemIdTextBox_Leave);
            PictureBox searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPic_Click);
            itemIdTextBox.Controls.Add(searchPic);
        }

        void itemIdTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), false);
        }

        void itemIdTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), true);
        }

        void itemIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(itemIdTextBox.Text.Trim()))
            {
                MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemIdTextBox.Text);

                if (item != null)
                {
                    itemNameTextBox.Text = item.ItemName;
                }
                else
                {
                    itemNameTextBox.Text = string.Empty;
                }
            }
        }

        void searchPic_Click(object sender, EventArgs e)
        {
            OpenFormSearchItem();
        }

        FormSearchItem f_SearchItem;//= new FormSearchItem();
        private void OpenFormSearchItem()
        {
            if (f_SearchItem != null)
            {
                if (!f_SearchItem.IsDisposed)
                    f_SearchItem.Close();
            }
            f_SearchItem = new FormSearchItem();

            f_SearchItem.ItemHasSelected += new EventHandler(f_SearchItem_ItemHasSelected);
            f_SearchItem.lbl_TempTransaction.Text = string.Empty;
            //f_SearchItem.ShowInTaskbar = false;
            f_SearchItem.ShowDialog();
        }

        void f_SearchItem_ItemHasSelected(object sender, EventArgs e)
        {
            if (f_SearchItem.grid_Search.Rows.Count > 0)
            {
                itemIdTextBox.Text = f_SearchItem.grid_Search.Rows[f_SearchItem.grid_Search.CurrentRow.Index].Cells[0].Value.ToString();
                itemIdTextBox_Validating(null, null);
            }
        }

        private void FormSettingForBilliard_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SetNumericUpDown(deskHeightNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(deskWidthNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(quantityNumericUpDown);
            BindData();
            autoBackupCheckBox_CheckedChanged(null, null);
        }

        private void BindData()
        {
            set = (MSetting)DataMaster.GetObjectByProperty(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            if (set != null)
                mSettingDetail();

            bilSet = (TBilliardSetting)DataMaster.GetObjectByProperty(typeof(TBilliardSetting), TBilliardSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            if (bilSet != null)
                billiardSettingDetail();

            bonus = (TBonus)DataMaster.GetObjectByProperty(typeof(TBonus), TBonus.ColumnNames.SettingId, AppCode.AssemblyProduct);
            if (bonus != null)
                bonusSettingDetail();
        }

        private void bonusSettingDetail()
        {
            itemIdTextBox.Text = bonus.ItemId;
            itemIdTextBox_Validating(null, null);
            quantityNumericUpDown.Value = bonus.Quantity;
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

            isSave = (bilSet == null);
            if (isSave)
                bilSet = new TBilliardSetting();

            //price periode I
            bilSet.BiliardItemPrice = biliardItemPriceNumericUpDown.Value;
            bilSet.BiliardItemPriceMini = biliardItemPriceMiniNumericUpDown.Value;
            bilSet.BiliardItemPriceVip = biliardItemPriceVipNumericUpDown.Value;
            //hour
            bilSet.BiliardItemHourFrom1 = Convert.ToInt32(biliardItemHourFrom1NumericUpDown.Value);
            bilSet.BiliardItemHourTo1 = Convert.ToInt32(biliardItemHourTo1NumericUpDown.Value);

            //price periode II
            bilSet.BiliardItemPrice2 = biliardItemPrice2NumericUpDown.Value;
            bilSet.BiliardItemPriceMini2 = biliardItemPriceMini2NumericUpDown.Value;
            bilSet.BiliardItemPriceVip2 = biliardItemPriceVip2NumericUpDown.Value;
            //hour
            bilSet.BiliardItemHourFrom2 = Convert.ToInt32(biliardItemHourFrom2NumericUpDown.Value);
            bilSet.BiliardItemHourTo2 = Convert.ToInt32(biliardItemHourTo2NumericUpDown.Value);

            //price periode III
            bilSet.BiliardItemPrice3 = biliardItemPrice3NumericUpDown.Value;
            bilSet.BiliardItemPriceMini3 = biliardItemPriceMini3NumericUpDown.Value;
            bilSet.BiliardItemPriceVip3 = biliardItemPriceVip3NumericUpDown.Value;
            //hour
            bilSet.BiliardItemHourFrom3 = Convert.ToInt32(biliardItemHourFrom3NumericUpDown.Value);
            bilSet.BiliardItemHourTo3 = Convert.ToInt32(biliardItemHourTo3NumericUpDown.Value);


            bilSet.FullfillPrice = fullfillPriceNumericUpDown.Value;
            bilSet.RefereeBonus = refereeBonusNumericUpDown.Value;
            bilSet.MinimumPlay = minimumPlayNumericUpDown.Value;
            bilSet.QuitTimeout = quitTimeoutNumericUpDown.Value;

            //wasit 
            bilSet.UseReferee = useRefereeCheckBox.Checked;

            //waktu
            bilSet.ToleranceTime = toleranceTimeNumericUpDown.Value;
            bilSet.CalculateTime = calculateTimeNumericUpDown.Value;

            //setting meja common
            bilSet.BackColor = ColorTranslator.ToWin32(splitContainer1.Panel1.BackColor);
            bilSet.DeskBackColor = ColorTranslator.ToWin32(btn_Bil.BackColor);
            bilSet.DeskFontBold = btn_Bil.Font.Bold;
            bilSet.DeskFontColor = ColorTranslator.ToWin32(btn_Bil.ForeColor);
            bilSet.DeskFontItalic = btn_Bil.Font.Italic;
            bilSet.DeskFontName = btn_Bil.Font.Name;
            bilSet.DeskFontSize = decimal.Parse(btn_Bil.Font.Size.ToString());
            bilSet.DeskFontUnderline = btn_Bil.Font.Underline;
            bilSet.DeskHeight = btn_Bil.Height;
            bilSet.DeskWidth = btn_Bil.Width;

            //booking
            bilSet.DeskBackColor1 = ColorTranslator.ToWin32(btn_Bil1.BackColor);
            bilSet.DeskFontBold1 = btn_Bil1.Font.Bold;
            bilSet.DeskFontColor1 = ColorTranslator.ToWin32(btn_Bil1.ForeColor);
            bilSet.DeskFontItalic1 = btn_Bil1.Font.Italic;
            bilSet.DeskFontName1 = btn_Bil1.Font.Name;
            bilSet.DeskFontSize1 = decimal.Parse(btn_Bil1.Font.Size.ToString());
            bilSet.DeskFontUnderline1 = btn_Bil1.Font.Underline;

            //booking
            bilSet.DeskBackColor2 = ColorTranslator.ToWin32(btn_Bil2.BackColor);
            bilSet.DeskFontBold2 = btn_Bil2.Font.Bold;
            bilSet.DeskFontColor2 = ColorTranslator.ToWin32(btn_Bil2.ForeColor);
            bilSet.DeskFontItalic2 = btn_Bil2.Font.Italic;
            bilSet.DeskFontName2 = btn_Bil2.Font.Name;
            bilSet.DeskFontSize2 = decimal.Parse(btn_Bil2.Font.Size.ToString());
            bilSet.DeskFontUnderline2 = btn_Bil2.Font.Underline;
            bilSet.ModifiedBy = lbl_UserName.Text;
            bilSet.ModifiedDate = DateTime.Now;
            bilSet.SettingId = AppCode.AssemblyProduct;

            if (isSave)
                DataMaster.SavePersistence(bilSet);
            else
                DataMaster.UpdatePersistence(bilSet);

            isSave = (bonus == null);
            if (isSave)
                bonus = new TBonus();

            bonus.ItemId = itemIdTextBox.Text;
            bonus.Quantity = quantityNumericUpDown.Value;
            bonus.ModifiedBy = lbl_UserName.Text;
            bonus.ModifiedDate = DateTime.Now;
            bonus.SettingId = AppCode.AssemblyProduct;
            if (isSave)
                DataMaster.SavePersistence(bonus);
            else
                DataMaster.UpdatePersistence(bonus);

            BindData();

            MessageBox.Show(this.Text + " berhasil disimpan !!", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void backColorPictureBox_Click(object sender, EventArgs e)
        {
            //colorDialog1.Dispose();
            colorDialog1.Color = ((PictureBox)sender).BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;

                ((PictureBox)sender).BackColor = c;

                if (sender == backColorPictureBox)
                    splitContainer1.Panel1.BackColor = c;
                else if (sender == deskBackColorPictureBox)
                {
                    button_Font.BackColor = c;
                    btn_Bil.BackColor = c;
                }
                else if (sender == deskFontColorPictureBox)
                {
                    button_Font.ForeColor = c;
                    btn_Bil.ForeColor = c;
                }
                else if (sender == deskBackColor1PictureBox)
                {
                    button_Font1.BackColor = c;
                    btn_Bil1.BackColor = c;
                }
                else if (sender == deskFontColor1PictureBox)
                {
                    button_Font1.ForeColor = c;
                    btn_Bil1.ForeColor = c;
                }
                else if (sender == deskBackColor2PictureBox)
                {
                    button_Font2.BackColor = c;
                    btn_Bil2.BackColor = c;
                }
                else if (sender == deskFontColor2PictureBox)
                {
                    button_Font2.ForeColor = c;
                    btn_Bil2.ForeColor = c;
                }
            }
        }

        private void deskSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            btn_Bil.Size = new Size(Convert.ToInt32(deskWidthNumericUpDown.Value), Convert.ToInt32(deskHeightNumericUpDown.Value));
            btn_Bil1.Size = new Size(Convert.ToInt32(deskWidthNumericUpDown.Value), Convert.ToInt32(deskHeightNumericUpDown.Value));
            btn_Bil2.Size = new Size(Convert.ToInt32(deskWidthNumericUpDown.Value), Convert.ToInt32(deskHeightNumericUpDown.Value));
        }

        private void button_Font_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = ((Button)sender).Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                if (sender == button_Font)
                {
                    btn_Bil.Font = fontDialog1.Font;
                    button_Font.Font = fontDialog1.Font;
                }
                else if (sender == button_Font1)
                {
                    btn_Bil1.Font = fontDialog1.Font;
                    button_Font1.Font = fontDialog1.Font;
                }
                else if (sender == button_Font2)
                {
                    btn_Bil2.Font = fontDialog1.Font;
                    button_Font2.Font = fontDialog1.Font;
                }
            }
        }

        private void billiardSettingDetail()
        {
            deskWidthNumericUpDown.Value = bilSet.DeskWidth;
            deskHeightNumericUpDown.Value = bilSet.DeskHeight;

            //desk setting price
            //periode I
            biliardItemPriceNumericUpDown.Value = bilSet.BiliardItemPrice;
            biliardItemPriceVipNumericUpDown.Value = bilSet.BiliardItemPriceVip;
            biliardItemPriceMiniNumericUpDown.Value = bilSet.BiliardItemPriceMini;
            //hour
            biliardItemHourFrom1NumericUpDown.Value = bilSet.BiliardItemHourFrom1;
            biliardItemHourTo1NumericUpDown.Value = bilSet.BiliardItemHourTo1;

            //periode II
            biliardItemPrice2NumericUpDown.Value = bilSet.BiliardItemPrice2;
            biliardItemPriceVip2NumericUpDown.Value = bilSet.BiliardItemPriceVip2;
            biliardItemPriceMini2NumericUpDown.Value = bilSet.BiliardItemPriceMini2;
            //hour
            biliardItemHourFrom2NumericUpDown.Value = bilSet.BiliardItemHourFrom2;
            biliardItemHourTo2NumericUpDown.Value = bilSet.BiliardItemHourTo2;

            //periode III
            biliardItemPrice3NumericUpDown.Value = bilSet.BiliardItemPrice3;
            biliardItemPriceVip3NumericUpDown.Value = bilSet.BiliardItemPriceVip3;
            biliardItemPriceMini3NumericUpDown.Value = bilSet.BiliardItemPriceMini3;
            //hour
            biliardItemHourFrom3NumericUpDown.Value = bilSet.BiliardItemHourFrom3;
            biliardItemHourTo3NumericUpDown.Value = bilSet.BiliardItemHourTo3;

            refereeBonusNumericUpDown.Value = bilSet.RefereeBonus;
            quitTimeoutNumericUpDown.Value = bilSet.QuitTimeout;
            minimumPlayNumericUpDown.Value = bilSet.MinimumPlay;
            fullfillPriceNumericUpDown.Value = bilSet.FullfillPrice;


            //wasit 
            useRefereeCheckBox.Checked = bilSet.UseReferee;

            //waktu
            toleranceTimeNumericUpDown.Value = bilSet.ToleranceTime;
            calculateTimeNumericUpDown.Value = bilSet.CalculateTime;

            FontStyle st = FontStyle.Regular;
            Color c;
            //common
            if (bilSet.DeskFontBold)
                st = FontStyle.Bold;
            if (bilSet.DeskFontItalic)
                st = FontStyle.Italic;
            if (bilSet.DeskFontUnderline)
                st = FontStyle.Underline;

            btn_Bil.Font = new Font(bilSet.DeskFontName, float.Parse(bilSet.DeskFontSize.ToString()), st);
            button_Font.Font = btn_Bil.Font;

            c = ColorTranslator.FromWin32(bilSet.DeskFontColor);
            btn_Bil.ForeColor = c;
            button_Font.ForeColor = c;
            deskFontColorPictureBox.BackColor = c;

            c = ColorTranslator.FromWin32(bilSet.BackColor);
            backColorPictureBox.BackColor = c;
            splitContainer1.Panel1.BackColor = c;

            c = ColorTranslator.FromWin32(bilSet.DeskBackColor);
            deskBackColorPictureBox.BackColor = c;
            btn_Bil.BackColor = c;
            button_Font.BackColor = c;

            //booking
            st = FontStyle.Regular;
            if (bilSet.DeskFontBold1)
                st = FontStyle.Bold;
            if (bilSet.DeskFontItalic1)
                st = FontStyle.Italic;
            if (bilSet.DeskFontUnderline1)
                st = FontStyle.Underline;

            btn_Bil1.Font = new Font(bilSet.DeskFontName1, float.Parse(bilSet.DeskFontSize1.ToString()), st);
            button_Font1.Font = btn_Bil1.Font;

            c = ColorTranslator.FromWin32(bilSet.DeskFontColor1);
            btn_Bil1.ForeColor = c;
            button_Font1.ForeColor = c;
            deskFontColor1PictureBox.BackColor = c;

            c = ColorTranslator.FromWin32(bilSet.DeskBackColor1);
            deskBackColor1PictureBox.BackColor = c;
            btn_Bil1.BackColor = c;
            button_Font1.BackColor = c;

            //in
            st = FontStyle.Regular;
            if (bilSet.DeskFontBold2)
                st = FontStyle.Bold;
            if (bilSet.DeskFontItalic2)
                st = FontStyle.Italic;
            if (bilSet.DeskFontUnderline2)
                st = FontStyle.Underline;

            btn_Bil2.Font = new Font(bilSet.DeskFontName2, float.Parse(bilSet.DeskFontSize2.ToString()), st);
            button_Font2.Font = btn_Bil2.Font;

            c = ColorTranslator.FromWin32(bilSet.DeskFontColor2);
            btn_Bil2.ForeColor = c;
            button_Font2.ForeColor = c;
            deskFontColor2PictureBox.BackColor = c;

            c = ColorTranslator.FromWin32(bilSet.DeskBackColor2);
            deskBackColor2PictureBox.BackColor = c;
            btn_Bil2.BackColor = c;
            button_Font2.BackColor = c;

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

    }
}

