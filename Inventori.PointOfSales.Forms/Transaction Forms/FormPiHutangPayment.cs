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
    public partial class FormPiHutangPayment : FormParentForPointOfSales
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

        private bool _isDelete;
        public bool IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
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
            if (IsDelete)
            {
                if (PiHutang == ListOfPiHutangStatus.Piutang)
                {
                    //beban penghapusan piutang dropdownlist
                    mSubAccountBindingSource.DataSource = DataMaster.GetListEq(typeof(MSubAccount), MSubAccount.ColumnNames.SubAccountId, AppCode.GetPiutangBebanAccountNo());
                }
                else if (PiHutang == ListOfPiHutangStatus.Hutang)
                {
                    //pendapatan penghapusan hutang dropdownlist
                    mSubAccountBindingSource.DataSource = DataMaster.GetListEq(typeof(MSubAccount), MSubAccount.ColumnNames.AccountId, AppCode.GetOtherRevenueAccountNo());
                }

            }
            else
            {
                //kas dropdownlist
                mSubAccountBindingSource.DataSource = DataMaster.GetListEq(typeof(MSubAccount), MSubAccount.ColumnNames.AccountId, AppCode.GetKasAccountNo());
            }


            //journal date
            ModuleControlSettings.SetDateTimePicker(journalDateDateTimePicker, false);

            //numeric up down
            ModuleControlSettings.SetNumericUpDown(journalJumlahNumericUpDown, true);

            //add column to grid
            tPiHutangDataGridView.ReadOnly = false;

            DataGridViewCheckBoxColumn cekColoumn = new DataGridViewCheckBoxColumn(false);
            cekColoumn.ReadOnly = false;
            tPiHutangDataGridView.Columns.Add(cekColoumn);

            for (int i = 1; i < 6; i++)
            {
                tPiHutangDataGridView.Columns.Add(i.ToString(), i.ToString());
                tPiHutangDataGridView.Columns[i].ReadOnly = true;
            }

            DataGridViewTextBoxColumn txtColumn = new DataGridViewTextBoxColumn();
            txtColumn.ValueType = typeof(decimal);
            tPiHutangDataGridView.Columns.Add(txtColumn);

            for (int i = 7; i < 9; i++)
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
            //tPiHutangDataGridView.Columns[6].ReadOnly = false;
            tPiHutangDataGridView.Columns[7].Visible = false;
            tPiHutangDataGridView.Columns[8].Visible = false;


            //journal date
            ModuleControlSettings.SetDateTimePicker(journalDateDateTimePicker, false);

            //set display
            if (PiHutang == ListOfPiHutangStatus.Hutang)
                SetInitialHutangSettings();
            else if (PiHutang == ListOfPiHutangStatus.Piutang)
                SetInitialPiutangSettings();
            else if (PiHutang == ListOfPiHutangStatus.HutangJasa)
                SetInitialHutangJasaSettings();
        }

        private void SetInitialHutangJasaSettings()
        {
            //title
            string title = string.Empty;
            if (IsDelete)
                title = "Penghapusan Hutang Ekspedisi";
            else
                title = "Pembayaran Hutang Ekspedisi";

            this.Text = title;
            this.TabText = title;

            //Ekspedisi
            piHutangPicLabel.Text = "Ekspedisi ";
            piHutangPicComboBox.DataSource = DataMaster.GetAll(typeof(MEkspedission));
            piHutangPicComboBox.DisplayMember = MEkspedission.ColumnNames.EkspedissionName;
            piHutangPicComboBox.ValueMember = MEkspedission.ColumnNames.EkspedissionId;
            piHutangPicComboBox.Show();
        }

        void SetInitialPiutangSettings()
        {
            //title
            string title = string.Empty;
            if (IsDelete)
                title = "Penghapusan Piutang Dagang";
            else
                title = "Penerimaan Piutang Dagang";

            this.Text = title;
            this.TabText = title;


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
            string title = string.Empty;
            if (IsDelete)
                title = "Penghapusan Hutang Dagang";
            else
                title = "Pembayaran Hutang Dagang";

            this.Text = title;
            this.TabText = title;

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
            // balloonHelp.TopMost = true;
        }

        private void piHutangPicComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (piHutangPicComboBox.SelectedIndex == -1)
                return;

            tPiHutangDataGridView.Rows.Clear();

            NHibernate.Expression.ICriterion[] expArrays = new NHibernate.Expression.ICriterion[3];
            expArrays[0] = NHibernate.Expression.Expression.Eq(TPiHutang.ColumnNames.PiHutangStatus, PiHutang.ToString());
            expArrays[1] = NHibernate.Expression.Expression.Eq(TPiHutang.ColumnNames.PiHutangPic, piHutangPicComboBox.SelectedValue.ToString());
            expArrays[2] = NHibernate.Expression.Expression.Gt(TPiHutang.ColumnNames.PiHutangSisa, decimal.Zero);


            NHibernate.Expression.Order[] orderArrays = new NHibernate.Expression.Order[1];
            orderArrays[0] = NHibernate.Expression.Order.Desc(TPiHutang.ColumnNames.TransactionId);

            IList piHutangList = DataMaster.GetList(typeof(TPiHutang), expArrays, orderArrays);

            //IList piHutangList = DataMaster.GetListEqGreatThan(typeof(TPiHutang), TPiHutang.ColumnNames.PiHutangStatus, PiHutang.ToString(), TPiHutang.ColumnNames.PiHutangPic, piHutangPicComboBox.SelectedValue.ToString(), TPiHutang.ColumnNames.PiHutangSisa, decimal.Zero);
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
            subAccountIdComboBox.SelectedIndex = -1;
            journalDescTextBox.ResetText();
            journalJumlahNumericUpDown.Value = 0;
            tPiHutangDataGridView.Rows.Clear();
        }

        private void tPiHutangDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tPiHutangDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

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
                    tPiHutangDataGridView.CurrentRow.Cells[4].Value = sisa - paid;
                }
                catch (Exception)
                {
                    tPiHutangDataGridView.CurrentRow.Cells[6].Value = decimal.Zero;
                }
            }
            CalculateJumlah();
            CreateDescription();
        }

        private void CreateDescription()
        {
            string desc = this.Text + " untuk faktur : ";
            for (int i = 0; i < tPiHutangDataGridView.RowCount; i++)
            {
                if (Convert.ToBoolean(tPiHutangDataGridView.Rows[i].Cells[0].Value) == true)
                {
                    desc += tPiHutangDataGridView.Rows[i].Cells[1].Value.ToString() + ", ";
                }
            }
            if (desc.Length > 2)
            {
                desc = desc.Substring(0, desc.Length - 2);
            }
            journalDescTextBox.Text = desc;
        }

        private void CalculateJumlah()
        {
            decimal tot = 0;
            for (int i = 0; i < tPiHutangDataGridView.RowCount; i++)
            {
                if (Convert.ToBoolean(tPiHutangDataGridView.Rows[i].Cells[0].Value) == true)
                {
                    tot += Convert.ToDecimal(tPiHutangDataGridView.Rows[i].Cells[6].Value);
                }
            }
            journalJumlahNumericUpDown.Value = tot;
        }

        private void UpdatePiHutang(object sender, EventArgs e)
        {
            if (!ValidatePiHutang())
                return;

            simpanToolStripButton.Enabled = false;

            TJournal jur = new TJournal();
            jur.JournalDate = journalDateDateTimePicker.Value;
            jur.JournalDesc = journalDescTextBox.Text;
            jur.JournalJumlah = journalJumlahNumericUpDown.Value;
            jur.JournalPic = piHutangPicComboBox.SelectedValue.ToString();

            if (!IsDelete)
            {
                if (PiHutang == ListOfPiHutangStatus.Piutang)
                    jur.JournalStatus = ListOfJournalStatus.Debet.ToString();
                else if (PiHutang == ListOfPiHutangStatus.Hutang)
                    jur.JournalStatus = ListOfJournalStatus.Kredit.ToString();
                else if (PiHutang == ListOfPiHutangStatus.HutangJasa)
                    jur.JournalStatus = ListOfJournalStatus.Kredit.ToString();
            }
            else
            {
                if (PiHutang == ListOfPiHutangStatus.Piutang)
                    jur.JournalStatus = ListOfJournalStatus.Kredit.ToString();
                else if (PiHutang == ListOfPiHutangStatus.Hutang)
                    jur.JournalStatus = ListOfJournalStatus.Debet.ToString();
                else if (PiHutang == ListOfPiHutangStatus.HutangJasa)
                    jur.JournalStatus = ListOfJournalStatus.Debet.ToString();
            }


            //if (IsDelete)
            //{
            //    jur.SubAccountId = subAccountIdComboBox.SelectedValue.ToString();
            //}
            //else
            //{
            jur.SubAccountId = subAccountIdComboBox.SelectedValue.ToString();
            //}

            jur.VoucherNo = voucherNoTextBox.Text;
            jur.ModifiedBy = lbl_UserName.Text;
            jur.ModifiedDate = DateTime.Now;
            AppCode.SaveTJournal(jur);


            TPiHutang piHut;
            for (int i = 0; i < tPiHutangDataGridView.RowCount; i++)
            {

                if (Convert.ToBoolean(tPiHutangDataGridView.Rows[i].Cells[0].Value) == true)
                {
                    piHut = (TPiHutang)DataMaster.GetObjectByProperty(typeof(TPiHutang), TPiHutang.ColumnNames.PiHutangId, Convert.ToDecimal(tPiHutangDataGridView.Rows[i].Cells[7].Value));
                    piHut.PiHutangDibayar += Convert.ToDecimal(tPiHutangDataGridView.Rows[i].Cells[6].Value);
                    piHut.PiHutangSisa = piHut.PiHutangJumlah - piHut.PiHutangRetur - piHut.PiHutangDibayar;

                    if (piHut.PiHutangSisa == decimal.Zero)
                    {
                        piHut.PiHutangLunasDate = journalDateDateTimePicker.Value;
                        if (piHutang == ListOfPiHutangStatus.Piutang && !IsDelete)
                        {
                            ShareCommissionInterface(piHut.TransactionId);
                        }
                    }

                    piHut.ModifiedBy = lbl_UserName.Text;
                    piHut.ModifiedDate = DateTime.Now;
                    DataMaster.UpdatePersistence(piHut);

                    jur = new TJournal();
                    jur.JournalDate = journalDateDateTimePicker.Value;
                    jur.JournalDesc = journalDescTextBox.Text;
                    jur.JournalJumlah = Convert.ToDecimal(tPiHutangDataGridView.Rows[i].Cells[6].Value);
                    jur.JournalPic = piHutangPicComboBox.SelectedValue.ToString();

                    if (!IsDelete)
                    {
                        if (PiHutang == ListOfPiHutangStatus.Piutang)
                            jur.JournalStatus = ListOfJournalStatus.Kredit.ToString();
                        else if (PiHutang == ListOfPiHutangStatus.Hutang)
                            jur.JournalStatus = ListOfJournalStatus.Debet.ToString();
                        else if (PiHutang == ListOfPiHutangStatus.HutangJasa)
                            jur.JournalStatus = ListOfJournalStatus.Debet.ToString();
                    }
                    else
                    {
                        if (PiHutang == ListOfPiHutangStatus.Piutang)
                            jur.JournalStatus = ListOfJournalStatus.Debet.ToString();
                        else if (PiHutang == ListOfPiHutangStatus.Hutang)
                            jur.JournalStatus = ListOfJournalStatus.Kredit.ToString();
                        else if (PiHutang == ListOfPiHutangStatus.HutangJasa)
                            jur.JournalStatus = ListOfJournalStatus.Kredit.ToString();
                    }


                    jur.SubAccountId = tPiHutangDataGridView.Rows[i].Cells[8].Value.ToString();
                    jur.VoucherNo = voucherNoTextBox.Text;
                    jur.ModifiedBy = lbl_UserName.Text;
                    jur.ModifiedDate = DateTime.Now;
                    AppCode.SaveTJournal(jur);
                }
            }

            MessageBox.Show(this.Text + " berhasil disimpan", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShareCommissionInterface(decimal transactionId)
        {
            TTransaction tr = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, transactionId);
            if (tr != null)
            {
                IList listDet = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, tr.TransactionId);
                TTransactionDetail det;
                for (int i = 0; i < listDet.Count; i++)
                {
                    det = (TTransactionDetail)listDet[i];
                    ShareCommission(det.Commission, det.IsPacket, tr.EmployeeId, tr.EmployeeId2, tr.TransactionDesk, tr.TransactionId, tr.TransactionFactur);
                }
            }
        }

        private void ShareCommission(decimal commission, bool isPacket, string employeeId, string employeeId2, string transactionDesk, decimal transactionId, string transactionFactur)
        {
            //MCommission comm = null;
            //if (isPacket)
            //    comm = (MCommission)DataMaster.GetObjectByProperty(typeof(MCommission), MCommission.ColumnNames.CommissionStatus, ListOfCommission.Puyer.ToString());
            //else
            //    comm = (MCommission)DataMaster.GetObjectByProperty(typeof(MCommission), MCommission.ColumnNames.CommissionStatus, ListOfCommission.Non_Puyer.ToString());

            //if (comm != null)
            //{
            //    IList listShareComm = DataMaster.GetListEq(typeof(MCommissionShare), MCommissionShare.ColumnNames.CommissionId, comm.CommissionId);
            //    MCommissionShare commShare;
            //    decimal shareValue;

            //    for (int i = 0; i < listShareComm.Count; i++)
            //    {
            //        commShare = (MCommissionShare)listShareComm[i];
            //        shareValue = commShare.ShareValue / 100 * commission;
            //        if (commShare.ShareTo == ListOfCommissionShare.Dokter.ToString() && !string.IsNullOrEmpty(employeeId))
            //            SaveTCommission(commShare.ShareTo, employeeId, shareValue, transactionId, transactionFactur);
            //        else if (commShare.ShareTo == ListOfCommissionShare.Manager.ToString())
            //        {
            //            SaveTCommission(commShare.ShareTo, ListOfCommissionShare.Manager.ToString(), shareValue, transactionId, transactionFactur);
            //        }
            //        else if (commShare.ShareTo == ListOfCommissionShare.Petugas.ToString() && !string.IsNullOrEmpty(employeeId2))
            //        {
            //            SaveTCommission(commShare.ShareTo, employeeId2, shareValue, transactionId, transactionFactur);
            //        }
            //        else if (commShare.ShareTo == ListOfCommissionShare.Ruang_Apotek.ToString())
            //        {
            //            SaveTCommission(commShare.ShareTo, ListOfCommissionShare.Ruang_Apotek.ToString(), shareValue, transactionId, transactionFactur);
            //        }
            //        else if (commShare.ShareTo == ListOfCommissionShare.Ruangan.ToString() && !string.IsNullOrEmpty(transactionDesk))
            //        {
            //            SaveTCommission(commShare.ShareTo, transactionDesk, shareValue, transactionId, transactionFactur);
            //        }
            //    }
            //}
        }

        private void SaveTCommission(string shareTo, string pic, decimal shareValue, decimal transactionId, string transactionFactur)
        {
            TCommission tcomm = new TCommission();
            tcomm.CommissionDate = DateTime.Today;
            tcomm.CommissionPic = pic;
            tcomm.CommissionValue = shareValue;
            tcomm.ModifiedBy = lbl_UserName.Text;
            tcomm.ModifiedDate = DateTime.Now;
            tcomm.ShareTo = shareTo;
            tcomm.TransactionFacturNo = transactionFactur;
            tcomm.TransactionId = transactionId;
            DataMaster.SavePersistence(tcomm);
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
            if (subAccountIdComboBox.SelectedIndex == -1)
            {
                balloonHelp.Content = "Pilih kas !!";
                balloonHelp.ShowBalloon(subAccountIdComboBox);
                subAccountIdComboBox.Focus();
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