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

namespace Inventori.MotorKymco.Forms
{
    public partial class FormPiHutangPayment : FormParentForMotorKymco
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private Balloon.NET.BalloonHelp balloonHelp;

        public FormPiHutangPayment()
        {
            InitializeComponent();
        }

        private ListOfPiHutangStatus piHutang;
        public ListOfPiHutangStatus PiHutang
        {
            get { return piHutang; }
            set { piHutang = value; }
        }

        private void FormPiHutangPayment_Load(object sender, EventArgs e)
        {
            SetInitialCommonSettings();

            ResetPiHutangHeader(sender, e);

            //clear group box text
            groupBox_Head.ResetText();
            groupBox_PiHutangDetail.ResetText();
        }

        void SetInitialCommonSettings()
        {
            //kas dropdownlist
            mSubAccountBindingSource.DataSource = DataMaster.GetListEq(typeof(MSubAccount), MSubAccount.ColumnNames.AccountId, AppCode.GetKasAccountNo());

            //journal date
            ModuleControlSettings.SetDateTimePicker(journalDateDateTimePicker, false);

            //numeric up down
            ModuleControlSettings.SetNumericUpDown(journalJumlahNumericUpDown, true);

            //add column to grid
            tPiHutangDataGridView.ReadOnly = false;

            DataGridViewCheckBoxColumn cekColoumn = new DataGridViewCheckBoxColumn(false);
            cekColoumn.ReadOnly = false;
            tPiHutangDataGridView.Columns.Add(cekColoumn);

            for (int i = 1; i < 9; i++)
            {
                tPiHutangDataGridView.Columns.Add(i.ToString(), i.ToString());
                tPiHutangDataGridView.Columns[i].ReadOnly = true;
            }

            //set width for grid view
            tPiHutangDataGridView.Columns[0].Width = label_Pay.Width;
            tPiHutangDataGridView.Columns[1].Width = label_FacturNo.Width;
            tPiHutangDataGridView.Columns[2].Width = label_DueDate.Width;
            tPiHutangDataGridView.Columns[3].Width = label_Jumlah.Width;
            tPiHutangDataGridView.Columns[4].Width = label_Retur.Width;
            tPiHutangDataGridView.Columns[5].Width = label_Sisa.Width;
            tPiHutangDataGridView.Columns[6].Width = label_Ammount.Width;
            tPiHutangDataGridView.Columns[7].Width = label_Ammount.Width;
            tPiHutangDataGridView.Columns[8].Width = label_Ammount.Width;

            tPiHutangDataGridView.Columns[2].DefaultCellStyle.Format = ModuleControlSettings.DateFormat();

            //set format
            for (int i = 3; i < 7; i++)
            {
                tPiHutangDataGridView.Columns[i].DefaultCellStyle.Format = "N";
                tPiHutangDataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            tPiHutangDataGridView.Columns[6].ReadOnly = false;
            tPiHutangDataGridView.Columns[7].Visible = false;
            tPiHutangDataGridView.Columns[8].Visible = false;


            //journal date
            ModuleControlSettings.SetDateTimePicker(journalDateDateTimePicker, false);

            //set display
            if (PiHutang == ListOfPiHutangStatus.Hutang)
                SetInitialHutangSettings();
            else if (PiHutang == ListOfPiHutangStatus.Piutang)
                SetInitialPiutangSettings();
        }

        void SetInitialPiutangSettings()
        {
            //title
            this.Text = "Penerimaan Piutang Dagang";
            this.TabText = "Penerimaan Piutang Dagang";

            //customer
            piHutangPicLabel.Text = "Pelanggan ";
            piHutangPicComboBox.DataSource = DataMaster.GetAll(typeof(MCustomer));
            piHutangPicComboBox.DisplayMember = MCustomer.ColumnNames.CustomerName;
            piHutangPicComboBox.ValueMember = MCustomer.ColumnNames.CustomerId;
            piHutangPicComboBox.Show();

        }

        void SetInitialHutangSettings()
        {
            //title
            this.Text = "Pembayaran Utang Dagang";
            this.TabText = "Pembayaran Utang Dagang";

            //supplier
            piHutangPicLabel.Text = "Supplier ";
            piHutangPicComboBox.DataSource = DataMaster.GetAll(typeof(MSupplier));
            piHutangPicComboBox.DisplayMember = MSupplier.ColumnNames.SupplierName;
            piHutangPicComboBox.ValueMember = MSupplier.ColumnNames.SupplierId;
            piHutangPicComboBox.Show();
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
        }

        private void piHutangPicComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (piHutangPicComboBox.SelectedIndex == -1)
                return;

            tPiHutangDataGridView.Rows.Clear();
            IList piHutangList = DataMaster.GetListEqGreatThan(typeof(TPiHutang), TPiHutang.ColumnNames.PiHutangStatus, PiHutang.ToString(), TPiHutang.ColumnNames.PiHutangPic, piHutangPicComboBox.SelectedValue.ToString(), TPiHutang.ColumnNames.PiHutangSisa, decimal.Zero);
            TPiHutang piHut;

            for (int i = 0; i < piHutangList.Count; i++)
            {
                piHut = (TPiHutang)piHutangList[i];

                object[] piHutangDetail = new object[9];
                piHutangDetail[0] = false;
                piHutangDetail[1] = piHut.PiHutangDesc;
                piHutangDetail[2] = piHut.PiHutangJatuhTempo;
                piHutangDetail[3] = piHut.PiHutangJumlah;
                piHutangDetail[4] = piHut.PiHutangRetur;
                piHutangDetail[5] = piHut.PiHutangSisa;
                piHutangDetail[6] = string.Empty;
                piHutangDetail[7] = piHut.PiHutangId;
                piHutangDetail[8] = piHut.SubAccountId;

                tPiHutangDataGridView.Rows.Add(piHutangDetail);
            }

        }

        private void ResetPiHutangHeader(object sender, EventArgs e)
        {
            simpanToolStripButton.Enabled = true;
            voucherNoTextBox.Text = AppCode.GetVoucherNo();
            journalDateDateTimePicker.Value = DateTime.Today;
            piHutangPicComboBox.SelectedIndex = -1;
            journalDescTextBox.ResetText();
            journalJumlahNumericUpDown.Value = 0;
            tPiHutangDataGridView.Rows.Clear();
        }

        private void tPiHutangDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(tPiHutangDataGridView.CurrentCell.Value) == true)
                    tPiHutangDataGridView.CurrentRow.Cells[6].Value = tPiHutangDataGridView.CurrentRow.Cells[5].Value;
                else if (Convert.ToBoolean(tPiHutangDataGridView.CurrentCell.Value) == false)
                    tPiHutangDataGridView.CurrentRow.Cells[6].Value = decimal.Zero;

            }
            else if (e.ColumnIndex == 6)
            {
                try
                {
                    decimal paid = decimal.Parse(
 tPiHutangDataGridView.CurrentRow.Cells[6].Value.ToString());
                    tPiHutangDataGridView.CurrentRow.Cells[0].Value = true;

                    decimal sisa = decimal.Parse(
tPiHutangDataGridView.CurrentRow.Cells[5].Value.ToString());
                    tPiHutangDataGridView.CurrentRow.Cells[5].Value = sisa - paid;
                }
                catch (Exception)
                {
                    tPiHutangDataGridView.CurrentRow.Cells[6].Value = decimal.Zero;
                }
            }
            CalculateJumlah();
        }

        private void CalculateJumlah()
        {
            decimal tot = 0;
            for (int i = 0; i < tPiHutangDataGridView.RowCount; i++)
            {
                if (Convert.ToBoolean(tPiHutangDataGridView.Rows[i].Cells[0].Value) == true)
                {
                    tot += Convert.ToDecimal(tPiHutangDataGridView.CurrentRow.Cells[6].Value);
                }
            }
            journalJumlahNumericUpDown.Value = tot;
        }

        private void UpdatePiHutang(object sender, EventArgs e)
        {
            if (!ValidatePiHutang())
                return;

            simpanToolStripButton.Enabled = false;

            TPiHutang piHut;
            for (int i = 0; i < tPiHutangDataGridView.RowCount; i++)
            {

                if (Convert.ToBoolean(tPiHutangDataGridView.Rows[i].Cells[0].Value) == true)
                {
                    piHut = (TPiHutang)DataMaster.GetObjectByProperty(typeof(TPiHutang), TPiHutang.ColumnNames.PiHutangId, Convert.ToDecimal(tPiHutangDataGridView.Rows[i].Cells[7].Value));
                    piHut.PiHutangDibayar += Convert.ToDecimal(tPiHutangDataGridView.Rows[i].Cells[6].Value);
                    piHut.PiHutangSisa = piHut.PiHutangJumlah - piHut.PiHutangRetur - piHut.PiHutangDibayar;

                    if (piHut.PiHutangSisa == decimal.Zero)
                        piHut.PiHutangLunasDate = journalDateDateTimePicker.Value;

                    piHut.ModifiedBy = lbl_UserName.Text;
                    piHut.ModifiedDate = DateTime.Now;
                    DataMaster.UpdatePersistence(piHut);
                }
            }

            MessageBox.Show(this.Text + " berhasil disimpan", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidatePiHutang()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (piHutangPicComboBox.SelectedIndex == -1)
            {
                balloonHelp.Content = "Pilih " + piHutangPicLabel.Text + " !!";
                balloonHelp.ShowBalloon(piHutangPicComboBox);
                piHutangPicComboBox.Focus();
                return false;
            }
            if (journalJumlahNumericUpDown.Value == 0)
            {
                balloonHelp.Content = "Harus ada transaksi yang dibayar !!";
                balloonHelp.ShowBalloon(tPiHutangDataGridView);
                tPiHutangDataGridView.Focus();
                return false;
            }

            return true;
        }
    }
}