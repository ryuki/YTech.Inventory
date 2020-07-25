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

namespace Inventori.PointOfSales.Forms
{
    public partial class FormJournal : FormParentForPointOfSales
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private Balloon.NET.BalloonHelp balloonHelp;

        public FormJournal()
        {
            InitializeComponent();
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
            //numeric up down
            ModuleControlSettings.SetNumericUpDown(balanceJumlahNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(journalJumlahNumericUpDown);

            //add column to grid
            for (int i = 0; i < 5; i++)
                tJournalDataGridView.Columns.Add(i.ToString(), i.ToString());

            //set width for grid view
            tJournalDataGridView.Columns[0].Width = label_AccId.Width;
            tJournalDataGridView.Columns[1].Width = label_AccName.Width;
            tJournalDataGridView.Columns[2].Width = label_JournalJumlah.Width;
            tJournalDataGridView.Columns[3].Width = label_Status.Width;
            tJournalDataGridView.Columns[4].Width = label_JournalDesc.Width;

            //set format
            tJournalDataGridView.Columns[2].DefaultCellStyle.Format = "N";
            tJournalDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //journal date
            ModuleControlSettings.SetDateTimePicker(journalDateDateTimePicker, false);

            //search sub acc
            PictureBox searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(subAccountIdTextBox, ListOfSearchWindow.SearchSubAccount.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicSubAcc_Click);
            subAccountIdTextBox.Controls.Add(searchPic);

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


        void ResetHeaderJournal(object sender, EventArgs e)
        {
            simpanToolStripButton.Enabled = true;
            journalDateDateTimePicker.Value = DateTime.Today;
            voucherNoTextBox.Text = AppCode.GetVoucherNo();
            balanceJumlahNumericUpDown.Value = decimal.Zero;

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
            journalStatusDebetRadioButton.Checked = false;
            journalStatusKreditRadioButton.Checked = false;
            journalJumlahNumericUpDown.Value = decimal.Zero;
            journalDescTextBox.ResetText();

            subAccountIdTextBox.Focus();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (ValidateJournalDetail())
            {
                object[] journalDetail = new object[5];
                journalDetail[0] = subAccountIdTextBox.Text;
                journalDetail[1] = subAccountNameTextBox.Text;
                journalDetail[2] = journalJumlahNumericUpDown.Value;

                if (journalStatusDebetRadioButton.Checked)
                    journalDetail[3] = ListOfJournalStatus.Debet.ToString();
                else if (journalStatusKreditRadioButton.Checked)
                    journalDetail[3] = ListOfJournalStatus.Kredit.ToString();

                journalDetail[4] = journalDescTextBox.Text;

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

            if (!journalStatusKreditRadioButton.Checked && !journalStatusDebetRadioButton.Checked)
            {
                balloonHelp.Content = "Pilih posisi akun !!";
                balloonHelp.ShowBalloon(journalStatusDebetRadioButton);
                journalStatusDebetRadioButton.Focus();
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


        private bool CalculateKasJumlah()
        {
            decimal totDebet = 0;
            decimal totKredit = 0;

            for (int i = 0; i < tJournalDataGridView.RowCount; i++)
            {
                if (tJournalDataGridView.Rows[i].Cells[3].Value.ToString() == ListOfJournalStatus.Debet.ToString())
                    totDebet += Convert.ToDecimal(tJournalDataGridView.Rows[i].Cells[2].Value);
                else if (tJournalDataGridView.Rows[i].Cells[3].Value.ToString() == ListOfJournalStatus.Kredit.ToString())
                    totKredit += Convert.ToDecimal(tJournalDataGridView.Rows[i].Cells[2].Value);
            }

            if (totDebet == totKredit)
            {
                balanceJumlahNumericUpDown.Value = totDebet;
                return true;
            }
            else
            {
                balanceJumlahNumericUpDown.Value = decimal.Zero;
                return false;
            }
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

                TJournal jur;

                //save journal detail
                for (int i = 0; i < tJournalDataGridView.RowCount; i++)
                {
                    jur = new TJournal();
                    jur.JournalDate = journalDateDateTimePicker.Value;
                    jur.JournalDesc = tJournalDataGridView.Rows[i].Cells[4].Value.ToString();
                    jur.JournalJumlah = Convert.ToDecimal(tJournalDataGridView.Rows[i].Cells[2].Value);
                    jur.JournalPic = string.Empty;
                    jur.JournalStatus = tJournalDataGridView.Rows[i].Cells[3].Value.ToString();
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

            if (tJournalDataGridView.RowCount == 0)
            {
                balloonHelp.Content = this.Text + " tidak boleh kosong !!";
                balloonHelp.ShowBalloon(tJournalDataGridView);
                tJournalDataGridView.Focus();
                return false;
            }

            if (balanceJumlahNumericUpDown.Value == 0)
            {
                balloonHelp.Content = "Transaksi debet dan kredit harus seimbang !!";
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

        private void balanceJumlahNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //kasJumlahSaidLabel.Text = AppCode.ConvertNumericToString(kasJumlahNumericUpDown.Value);
        }
    }
}