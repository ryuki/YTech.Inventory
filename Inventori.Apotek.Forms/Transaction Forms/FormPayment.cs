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

namespace Inventori.Apotek.Forms
{
    public partial class FormPayment : FormParentForApotek
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private Balloon.NET.BalloonHelp balloonHelp;

        public FormPayment()
        {
            InitializeComponent();
        }

        private ListOfJournalStatus journalStatus = ListOfJournalStatus.Debet;
        //debet for penerimaan
        //kredit for pembayaran
        public ListOfJournalStatus JournalStatus
        {
            get { return journalStatus; }
            set { journalStatus = value; }
        }


        private void FormPayment_Load(object sender, EventArgs e)
        {
            SetInitialCommonSettings();
            ResetHeaderJournal(sender, e);

            //clear group box text
            groupBox_Head.ResetText();
            groupBox_Input.ResetText();
            groupBox_List.ResetText();
        }

        void SetInitialCommonSettings()
        {
            //kas dropdownlist
            mSubAccountBindingSource.DataSource = DataMaster.GetListEq(typeof(MSubAccount), MSubAccount.ColumnNames.AccountId,AppCode.GetKasAccountNo());

            //numeric up down
            ModuleControlSettings.SetNumericUpDown(kasJumlahNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(journalJumlahNumericUpDown);

            //add column to grid
            for (int i = 0; i < 4; i++)
                tJournalDataGridView.Columns.Add(i.ToString(), i.ToString());

            //set width for grid view
            tJournalDataGridView.Columns[0].Width = label_AccId.Width;
            tJournalDataGridView.Columns[1].Width = label_AccName.Width;
            tJournalDataGridView.Columns[2].Width = label_JournalJumlah.Width;
            tJournalDataGridView.Columns[3].Width = label_JournalDesc.Width;

            //set format
            tJournalDataGridView.Columns[2].DefaultCellStyle.Format = "N";
            tJournalDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //journal date
            ModuleControlSettings.SetDateTimePicker(journalDateDateTimePicker,false);

            //search sub acc
            PictureBox searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(subAccountIdTextBox, ListOfSearchWindow.SearchSubAccount.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicSubAcc_Click);
            subAccountIdTextBox.Controls.Add(searchPic);

            //set display
            if (JournalStatus == ListOfJournalStatus.Debet)
                SetInitialDebetSettings();
            else if (JournalStatus == ListOfJournalStatus.Kredit)
                SetInitialKreditSettings();
        }

        void searchPicSubAcc_Click(object sender, EventArgs e)
        {
            OpenFormSearchAccount();
        }

        FormSearchSubAccount f_SearchSubAccount;
        private void OpenFormSearchAccount()
        {
            if (f_SearchSubAccount != null)
            {
                if (!f_SearchSubAccount.IsDisposed)
                {
                    f_SearchSubAccount.WindowState = FormWindowState.Normal;
                    f_SearchSubAccount.BringToFront();
                }
                else
                    f_SearchSubAccount = new FormSearchSubAccount();
            }
            else
                f_SearchSubAccount = new FormSearchSubAccount();
            f_SearchSubAccount.SubAccountHasSelected += new EventHandler(f_SearchSubAccount_SubAccountHasSelected);
            f_SearchSubAccount.ShowInTaskbar = false;
            f_SearchSubAccount.ShowDialog();
        }

        void f_SearchSubAccount_SubAccountHasSelected(object sender, EventArgs e)
        {
            if (f_SearchSubAccount.grid_Search.Rows.Count > 0)
            {
                subAccountIdTextBox.Text = f_SearchSubAccount.grid_Search.CurrentRow.Cells[0].Value.ToString();
                subAccountIdTextBox_Validating(null, null);
            }
        }

        void SetInitialDebetSettings()
        {
            //title
            this.Text = "Penerimaan Lain-lain";
            this.TabText = "Penerimaan Lain-lain";

            //kas
            kasAccountIdLabel.Text = "Deposit ke :";

            //journal date
            journalDateLabel.Text = "Tanggal terima :";
        }

        void SetInitialKreditSettings()
        {
            //title
            this.Text = "Pembayaran Lain-lain";
            this.TabText = "Pembayaran Lain-lain";

            //kas
            kasAccountIdLabel.Text = "Deposit dari :";

            //journal date
            journalDateLabel.Text = "Tanggal bayar :";
        }

        void ResetHeaderJournal(object sender, EventArgs e)
        {
            simpanToolStripButton.Enabled = true;
            kasAccountIdComboBox.SelectedIndex = -1;
            journalDateDateTimePicker.Value = DateTime.Today;
            voucherNoTextBox.Text = AppCode.GetVoucherNo();
            kasDescTextBox.ResetText();
            kasJumlahNumericUpDown.Value = decimal.Zero;

            tJournalDataGridView.Rows.Clear();
            ResetJournalDetail(sender, e);
        }

        private void subAccountIdTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(subAccountIdTextBox, ListOfSearchWindow.SearchSubAccount.ToString(), true);
        }

        private void subAccountIdTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(subAccountIdTextBox, ListOfSearchWindow.SearchSubAccount.ToString(), false);
        }

        private void subAccountIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(subAccountIdTextBox.Text.Trim()))
            {
                MSubAccount subacc = (MSubAccount)DataMaster.GetObjectByProperty(typeof(MSubAccount), MSubAccount.ColumnNames.SubAccountId, subAccountIdTextBox.Text);
                if (subacc != null)
                    subAccountNameTextBox.Text = subacc.SubAccountName;
                else
                    subAccountNameTextBox.ResetText();
            }
        }

        private void ResetJournalDetail(object sender, EventArgs e)
        {
            subAccountIdTextBox.ResetText();
            subAccountNameTextBox.ResetText();
            journalJumlahNumericUpDown.Value = decimal.Zero;
            journalDescTextBox.ResetText();

            subAccountIdTextBox.Focus();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (ValidateJournalDetail())
            {
                object[] journalDetail = new object[4];
                journalDetail[0] = subAccountIdTextBox.Text;
                journalDetail[1] = subAccountNameTextBox.Text;
                journalDetail[2] = journalJumlahNumericUpDown.Value;
                journalDetail[3] = journalDescTextBox.Text;

                tJournalDataGridView.Rows.Add(journalDetail);
                ResetJournalDetail(sender, e);
            }
        }

        private bool ValidateJournalDetail()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(subAccountIdTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Akun yang akan diinput harus diisi !!";
                balloonHelp.ShowBalloon(subAccountIdTextBox);
                subAccountIdTextBox.Focus();
                return false;
            }

            if (journalJumlahNumericUpDown.Value == 0)
            {
                balloonHelp.Content = "Jumlah tidak boleh 0 !!";
                balloonHelp.ShowBalloon(journalJumlahNumericUpDown);
                journalJumlahNumericUpDown.Focus();
                return false;
            }

            return true;
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (tJournalDataGridView.Rows.Count > 0)
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (tJournalDataGridView.CurrentRow.Index != -1)
                        tJournalDataGridView.Rows.RemoveAt(tJournalDataGridView.CurrentRow.Index);
                    else
                        tJournalDataGridView.Rows.RemoveAt(0);

                    ResetJournalDetail(sender, e);
                }
            }
        }


        private void CalculateKasJumlah()
        {
            decimal tot = 0;

            for (int i = 0; i < tJournalDataGridView.RowCount; i++)
            {
                tot += Convert.ToDecimal(tJournalDataGridView.Rows[i].Cells[2].Value);
            }

            kasJumlahNumericUpDown.Value = tot;
        }

        private void tJournalDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateKasJumlah();
        }

        private void tJournalDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateKasJumlah();
        }

        private void SaveJournal(object sender, EventArgs e)
        {
            if (ValidateJournalHeader())
            {
                simpanToolStripButton.Enabled = false;

                TJournal jur = new TJournal();
                jur.JournalDate = journalDateDateTimePicker.Value;
                jur.JournalDesc = kasDescTextBox.Text;
                jur.JournalJumlah = kasJumlahNumericUpDown.Value;
                jur.JournalPic = string.Empty;
                jur.JournalStatus = JournalStatus.ToString();
                jur.SubAccountId = kasAccountIdComboBox.SelectedValue.ToString();
                jur.VoucherNo = voucherNoTextBox.Text;
                jur.ModifiedBy = lbl_UserName.Text;
                jur.ModifiedDate = DateTime.Now;
                AppCode.SaveTJournal(jur);

                //save journal detail
                for (int i = 0; i < tJournalDataGridView.RowCount; i++)
                {
                    jur = new TJournal();
                    jur.JournalDate = journalDateDateTimePicker.Value;
                    jur.JournalDesc = tJournalDataGridView.Rows[i].Cells[3].Value.ToString();
                    jur.JournalJumlah = Convert.ToDecimal(tJournalDataGridView.Rows[i].Cells[2].Value);
                    jur.JournalPic = string.Empty;

                    if (JournalStatus == ListOfJournalStatus.Debet)
                        jur.JournalStatus = ListOfJournalStatus.Kredit.ToString();
                    else if (JournalStatus == ListOfJournalStatus.Kredit)
                        jur.JournalStatus = ListOfJournalStatus.Debet.ToString();


                    jur.SubAccountId = tJournalDataGridView.Rows[i].Cells[0].Value.ToString();
                    jur.VoucherNo = voucherNoTextBox.Text;
                    jur.ModifiedBy = lbl_UserName.Text;
                    jur.ModifiedDate = DateTime.Now;
                    AppCode.SaveTJournal(jur);
                }

                MessageBox.Show(this.Text + " berhasil disimpan", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private bool ValidateJournalHeader()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (kasAccountIdComboBox.SelectedIndex == -1)
            {
                balloonHelp.Content = "Pilih kas yang akan dideposit !!";
                balloonHelp.ShowBalloon(kasAccountIdComboBox);
                kasAccountIdComboBox.Focus();
                return false;
            }

            if (tJournalDataGridView.RowCount ==0)
            {
                 balloonHelp.Content = this.Text + " tidak boleh kosong !!";
                balloonHelp.ShowBalloon(tJournalDataGridView);
                tJournalDataGridView.Focus();
                return false;
            }

            return true;
        }

        private void RecreateBalloon()
        {
            balloonHelp = new Balloon.NET.BalloonHelp();
            balloonHelp.Icon = Properties.Resources.warning_ico;
            balloonHelp.CloseOnMouseClick = true;
            balloonHelp.CloseOnDeactivate = false;
            balloonHelp.CloseOnMouseMove = false;
            balloonHelp.CloseOnKeyPress = false;
            balloonHelp.ShowCloseButton = false;
            // balloonHelp.TopMost = true;
        }

        private void kasJumlahNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //kasJumlahSaidLabel.Text = AppCode.ConvertNumericToString(kasJumlahNumericUpDown.Value);
        }
    }
}