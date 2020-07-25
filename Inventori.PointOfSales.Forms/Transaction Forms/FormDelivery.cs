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
    public partial class FormDelivery : FormParentForPointOfSales
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private Balloon.NET.BalloonHelp balloonHelp;

        public FormDelivery()
        {
            InitializeComponent();
        }

        private void FormDelivery_Load(object sender, EventArgs e)
        {
            SetInitialSettings();
        }

        void SetGridView(DataGridView dg)
        {
            dg.MultiSelect = false;
            dg.CausesValidation = false;
            dg.AllowUserToDeleteRows = false;
            dg.AllowUserToAddRows = false;
            dg.ScrollBars = ScrollBars.Vertical;

            for (int i = 0; i < dg.Columns.Count; i++)
            {
                if (i == dg.Columns.Count)
                    dg.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                else
                    dg.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void SetInitialSettings()
        {
            //first focus
            transactionReferenceFacturTextBox.Focus();

            //cara bayar
            FillPayment();

            //set gridview
            SetGridView(tTransactionDeliveryDetailDataGridView);

            //set date time picker
            ModuleControlSettings.SetDateTimePicker(deliveryReceiveDateDateTimePicker, false);
            ModuleControlSettings.SetDateTimePicker(deliverySentDateDateTimePicker, false);

            //numeric updown
            ModuleControlSettings.SetNumericUpDown(deliveryCostNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(piHutangCreditLongNumericUpDown, true);

            //search ekpedisi
            PictureBox searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(deliveryExpedissionTextBox, ListOfSearchWindow.SearchEkspedission.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicExpedission_Click);
            deliveryExpedissionTextBox.Controls.Add(searchPic);

            //search transaction
            searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(transactionReferenceFacturTextBox, ListOfSearchWindow.SearchTransaction.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicReferenceId_Click);
            transactionReferenceFacturTextBox.Controls.Add(searchPic);
        }

        void searchPicExpedission_Click(object sender, EventArgs e)
        {
            OpenFormSearchExpedission();
        }

        FormSearchEkspedission f_SearchEkspedission;
        private void OpenFormSearchExpedission()
        {
            if (f_SearchEkspedission != null)
            {
                if (!f_SearchEkspedission.IsDisposed)
                {
                    f_SearchEkspedission.WindowState = FormWindowState.Normal;
                    f_SearchEkspedission.BringToFront();
                }
                else
                    f_SearchEkspedission = new FormSearchEkspedission();
            }
            else
                f_SearchEkspedission = new FormSearchEkspedission();

            f_SearchEkspedission.EkspedissionHasSelected += new EventHandler(f_SearchEkspedission_EkspedissionHasSelected);

            f_SearchEkspedission.ShowInTaskbar = false;
            f_SearchEkspedission.ShowDialog();
        }

        void f_SearchEkspedission_EkspedissionHasSelected(object sender, EventArgs e)
        {
            if (f_SearchEkspedission.grid_Search.Rows.Count > 0)
            {
                deliveryExpedissionTextBox.Text = f_SearchEkspedission.grid_Search.CurrentRow.Cells[0].Value.ToString();
                deliveryExpedissionTextBox_Validating(null, null);
            }
        }

        FormSearchTransaction f_SearchTrans;
        void searchPicReferenceId_Click(object sender, EventArgs e)
        {
            f_SearchTrans = new FormSearchTransaction(ListOfTransaction.Purchase);

            f_SearchTrans.TransactionHasSelected += new EventHandler(f_SearchTrans_TransactionHasSelected);
            f_SearchTrans.ShowDialog(this);
        }

        void f_SearchTrans_TransactionHasSelected(object sender, EventArgs e)
        {
            if (f_SearchTrans.grid_Search.Rows.Count > 0)
            {
                transactionReferenceFacturTextBox.Text = f_SearchTrans.grid_Search.CurrentRow.Cells[1].Value.ToString();
                transactionReferenceFacturTextBox_Validating(null, null);
            }
        }

        private void transactionReferenceFacturTextBox_Validating(object sender, CancelEventArgs e)
        {
            TTransaction tr = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionFactur, transactionReferenceFacturTextBox.Text);
            if (tr != null)
            {
                transactionReferenceIdTextBox.Text = tr.TransactionId.ToString();
                FillTransaction(tr);
                FillTransactionDetail(tr);
                button_Detail.Visible = true;

                RecreateBalloon();
                balloonHelp.Caption = "Detail Transaksi";
                balloonHelp.Content = "Klik disini untuk melihat detail transaksi";
                balloonHelp.ShowBalloon(button_Detail);
            }
            else
            {
                transactionReferenceIdTextBox.ResetText();
                button_Detail.Visible = false;
                //tTransactionDeliveryDetailDataGridView.DataSource = null;
            }
        }

        private void FillTransactionDetail(TTransaction tr)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("AddDetail", typeof(bool));
            dt.Columns.Add("ItemId", typeof(string));
            dt.Columns.Add("ItemName", typeof(string));
            dt.Columns.Add("Quantity", typeof(decimal));
            dt.Columns.Add("QuantityDeliveryLast", typeof(decimal));
            dt.Columns.Add("QuantityDelivery", typeof(decimal));
            dt.Columns.Add("TransactionDetailId", typeof(decimal));
            dt.Columns.Add("DeliveryDetailId", typeof(decimal));

            IList listDet = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, tr.TransactionId);

            NHibernate.Expression.ICriterion[] expArrays;
            if (isInEdit)
            {
                expArrays = new NHibernate.Expression.ICriterion[2];
                expArrays[0] = NHibernate.Expression.Expression.Eq(TTransactionDelivery.ColumnNames.TransactionId, tr.TransactionId);
                expArrays[1] = NHibernate.Expression.Expression.Not(NHibernate.Expression.Expression.Eq(TTransactionDelivery.ColumnNames.DeliveryId, delId));

            }
            else
            {
                expArrays = new NHibernate.Expression.ICriterion[1];
                expArrays[0] = NHibernate.Expression.Expression.Eq(TTransactionDelivery.ColumnNames.TransactionId, tr.TransactionId);

            }

            NHibernate.Expression.Order[] ordArrays = new NHibernate.Expression.Order[1];
            ordArrays[0] = NHibernate.Expression.Order.Asc(TTransactionDelivery.ColumnNames.DeliveryReceiveDate);

            IList listDel = DataMaster.GetList(typeof(TTransactionDelivery), expArrays, ordArrays);

            TTransactionDetail det;
            MItem item;
            TTransactionDelivery del;
            TTransactionDeliveryDetail delDet;
            decimal delCount = decimal.Zero;

            for (int i = 0; i < listDet.Count; i++)
            {
                delCount = decimal.Zero;
                det = (TTransactionDetail)listDet[i];
                dr = dt.NewRow();
                dr[0] = false;
                dr[1] = det.ItemId;
                item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, det.ItemId);
                if (item != null)
                    dr[2] = item.ItemName;
                dr[3] = det.Quantity;
                for (int j = 0; j < listDel.Count; j++)
                {
                    del = (TTransactionDelivery)listDel[j];
                    delDet = (TTransactionDeliveryDetail)DataMaster.GetObjectByProperty(typeof(TTransactionDeliveryDetail), TTransactionDeliveryDetail.ColumnNames.DeliveryId, del.DeliveryId, TTransactionDeliveryDetail.ColumnNames.TransactionDetailId, det.TransactionDetailId);
                    if (delDet != null)
                        delCount += delDet.DeliveryDetailQuantity;

                    //listDelDet = DataMaster.GetListEq(typeof(TTransactionDeliveryDetail), TTransactionDeliveryDetail.ColumnNames.DeliveryId, del.DeliveryId);
                    //for (int k = 0; k < listDelDet.Count; k++)
                    //{
                    //    delDet = (TTransactionDeliveryDetail)listDelDet[k];
                    //    delCount += delDet.DeliveryDetailQuantity;
                    //}
                }
                dr[4] = delCount;
                if (isInEdit)
                {
                    del = (TTransactionDelivery)DataMaster.GetObjectByProperty(typeof(TTransactionDelivery), TTransactionDeliveryDetail.ColumnNames.DeliveryId, delId);
                    if (del != null)
                    {
                        delDet = (TTransactionDeliveryDetail)DataMaster.GetObjectByProperty(typeof(TTransactionDeliveryDetail), TTransactionDeliveryDetail.ColumnNames.DeliveryId, del.DeliveryId, TTransactionDeliveryDetail.ColumnNames.TransactionDetailId, det.TransactionDetailId);
                        if (delDet != null)
                        {
                            dr[5] = delDet.DeliveryDetailQuantity;
                            dr[7] = delDet.DeliveryDetailId;
                        }
                        else
                        {
                            dr[5] = decimal.Zero;
                            dr[7] = decimal.Zero;
                        }
                    }
                }
                else
                {
                    dr[5] = decimal.Zero;
                    dr[7] = decimal.Zero;
                }


                dr[6] = det.TransactionDetailId;
                dt.Rows.Add(dr);
            }
            tTransactionDeliveryDetailDataGridView.DataSource = dt;
            tTransactionDeliveryDetailDataGridView.Show();
        }

        private void FillTransaction(TTransaction tr)
        {
            deliveryNumberPicTextBox.Text = tr.TransactionDesc2;
            transactionByTextBox.Text = tr.TransactionBy;
        }

        private void button_Detail_Click(object sender, EventArgs e)
        {
            FormViewReport f_Report = new FormViewReport();
            f_Report.listOfReports = ListOfReports.ReportTransactionDetail;
            f_Report.UseDateFilter = false;
            f_Report.UsePeriodFilter = false;
            f_Report.DataId = transactionReferenceIdTextBox.Text;
            f_Report.Show(this);
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

        private void transactionReferenceFacturTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(transactionReferenceFacturTextBox, ListOfSearchWindow.SearchTransaction.ToString(), true);
        }

        private void transactionReferenceFacturTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(transactionReferenceFacturTextBox, ListOfSearchWindow.SearchTransaction.ToString(), false);
        }

        private void tTransactionDeliveryDetailDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                MessageBox.Show("Kuantitas harus diisi dengan angka", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (MessageBox.Show("Apakah data sudah benar? Anda yakin menyimpan data?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            SaveOrUpdateDelivery();
            SaveOrUpdateDeliveryDetail();
            SaveJournalInterface();
            MessageBox.Show("Transaksi Ekspedisi berhasil disimpan", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
            toolStripButton1.Enabled = false;
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(transactionReferenceIdTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Pilih nomor faktur transaksi pembelian !!";
                balloonHelp.ShowBalloon(transactionReferenceFacturTextBox);
                transactionReferenceFacturTextBox.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(deliveryExpedissionTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Ekspedisi tidak boleh kosong !!";
                balloonHelp.ShowBalloon(deliveryExpedissionTextBox);
                deliveryExpedissionTextBox.Focus();
                return false;
            }

            bool isEmpty = true;
            for (int i = 0; i < tTransactionDeliveryDetailDataGridView.RowCount; i++)
            {
                if (Convert.ToBoolean(tTransactionDeliveryDetailDataGridView.Rows[i].Cells[0].Value))
                {
                    isEmpty = false;
                    break;
                }
            }
            if (isEmpty)
            {
                balloonHelp.Content = "Tidak ada barang yang dipilih !!";
                balloonHelp.ShowBalloon(tTransactionDeliveryDetailDataGridView);
                tTransactionDeliveryDetailDataGridView.Focus();
                return false;
            }
            return true;
        }

        string voucherNo;
        private void SaveJournalInterface()
        {
            if (isInEdit)
                JurnalPembalik(delId);

            voucherNo = AppCode.GetVoucherNo();
            //save to biaya ekspedisi
            SaveTransactionJournal(AppCode.GetBiayaEkspedisiAccountNo(), ListOfJournalStatus.Debet, deliveryCostNumericUpDown.Value, "Surat Jalan " + deliveryNumberExpedissionTextBox.Text, deliveryExpedissionTextBox.Text);

            if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Credit.ToString())
            {
                //save to hutang ekspedisi
                SaveTransactionJournal(AppCode.GetHutangEkspedisiAccountNo(), ListOfJournalStatus.Kredit, deliveryCostNumericUpDown.Value, "Surat Jalan " + deliveryNumberExpedissionTextBox.Text, deliveryExpedissionTextBox.Text);

                //save pi hutang
                SavePiHutang();
            }
            else if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Cash.ToString())
            {
                //save to kas
                SaveTransactionJournal("100KAS001", ListOfJournalStatus.Kredit, deliveryCostNumericUpDown.Value, "Surat Jalan " + deliveryNumberExpedissionTextBox.Text, deliveryExpedissionTextBox.Text);
            }
        }

        private void JurnalPembalik(decimal delId)
        {

            voucherNo = AppCode.GetVoucherNo();
            IList listJournal = DataMaster.GetListEq(typeof(TJournal), TJournal.ColumnNames.TransactionId, delId);
            TJournal jurnal;
            for (int i = 0; i < listJournal.Count; i++)
            {
                jurnal = (TJournal)listJournal[i];
                if (jurnal.JournalStatus == ListOfJournalStatus.Debet.ToString())
                {
                    SaveTransactionJournal(jurnal.SubAccountId, ListOfJournalStatus.Kredit, jurnal.JournalJumlah, "Edit Transaksi : " + jurnal.JournalDesc, jurnal.JournalPic);
                }
                else
                {
                    SaveTransactionJournal(jurnal.SubAccountId, ListOfJournalStatus.Debet, jurnal.JournalJumlah, "Edit Transaksi : " + jurnal.JournalDesc, jurnal.JournalPic);
                }
            }
        }

        private void SavePiHutang()
        {
            TPiHutang pihutang = new TPiHutang();
            bool isSave = true;
            if (isInEdit)
            {
                pihutang = (TPiHutang)DataMaster.GetObjectByProperty(typeof(TPiHutang), TPiHutang.ColumnNames.TransactionId, delId);
                if (pihutang != null)
                    isSave = false;
            }

            pihutang.PiHutangCreditLong = piHutangCreditLongNumericUpDown.Value;
            pihutang.PiHutangDate = deliverySentDateDateTimePicker.Value;
            pihutang.PiHutangDesc = transactionReferenceFacturTextBox.Text;

            if (isSave)
            {
                pihutang.PiHutangDibayar = decimal.Zero;
                pihutang.PiHutangRetur = decimal.Zero;
                pihutang.PiHutangSisa = deliveryCostNumericUpDown.Value;
            }
            else
            {
                pihutang.PiHutangSisa = deliveryCostNumericUpDown.Value - pihutang.PiHutangDibayar - pihutang.PiHutangRetur;
            }

            pihutang.PiHutangJatuhTempo = deliverySentDateDateTimePicker.Value.AddDays(Convert.ToDouble(piHutangCreditLongNumericUpDown.Value));

            pihutang.PiHutangJumlah = deliveryCostNumericUpDown.Value;
            pihutang.PiHutangPic = deliveryExpedissionTextBox.Text;
            pihutang.PiHutangStatus = ListOfPiHutangStatus.HutangJasa.ToString();
            pihutang.SubAccountId = AppCode.GetHutangEkspedisiAccountNo();
            pihutang.TransactionId = delId;

            pihutang.ModifiedBy = lbl_UserName.Text;
            pihutang.ModifiedDate = DateTime.Now;

            if (isSave)
                DataMaster.SavePersistence(pihutang);
            else
                DataMaster.UpdatePersistence(pihutang);
        }

        private void SaveTransactionJournal(string subAccountId, ListOfJournalStatus listOfJournalStatus, decimal saldo, string desc, string pic)
        {
            TJournal jur = new TJournal();
            jur.JournalDate = DateTime.Now;
            jur.JournalDesc = desc;
            jur.JournalJumlah = saldo;
            jur.JournalPic = pic;
            jur.JournalStatus = listOfJournalStatus.ToString();
            jur.SubAccountId = subAccountId;
            jur.VoucherNo = voucherNo;
            jur.TransactionId = delId;
            jur.ModifiedBy = lbl_UserName.Text;
            jur.ModifiedDate = DateTime.Now;

            AppCode.SaveTJournal(jur);
        }

        private void SaveOrUpdateDeliveryDetail()
        {
            TTransactionDeliveryDetail deldet;
            string itemId;
            decimal qty, transDetId, delDetId;
            for (int i = 0; i < tTransactionDeliveryDetailDataGridView.RowCount; i++)
            {
                if (Convert.ToBoolean(tTransactionDeliveryDetailDataGridView.Rows[i].Cells[0].Value))
                {
                    itemId = tTransactionDeliveryDetailDataGridView.Rows[i].Cells[1].Value.ToString();
                    qty = Convert.ToDecimal(tTransactionDeliveryDetailDataGridView.Rows[i].Cells[5].Value);
                    transDetId = Convert.ToDecimal(tTransactionDeliveryDetailDataGridView.Rows[i].Cells[6].Value);
                    delDetId = Convert.ToDecimal(tTransactionDeliveryDetailDataGridView.Rows[i].Cells[7].Value);
                    if (isInEdit)
                    {
                        deldet = (TTransactionDeliveryDetail)DataMaster.GetObjectByProperty(typeof(TTransactionDeliveryDetail), TTransactionDeliveryDetail.ColumnNames.DeliveryDetailId, delDetId, TTransactionDeliveryDetail.ColumnNames.TransactionDetailId, transDetId);
                        if (deldet == null)
                            deldet = new TTransactionDeliveryDetail();
                        else
                            UpdateStok(false, 1, itemId, deldet.DeliveryDetailQuantity, false);
                    }
                    else
                        deldet = new TTransactionDeliveryDetail();

                    deldet.DeliveryDetailDesc = string.Empty;
                    deldet.DeliveryDetailItemId = itemId;
                    deldet.DeliveryDetailQuantity = qty;
                    deldet.DeliveryId = delId;
                    deldet.TransactionDetailId = transDetId;
                    deldet.ModifiedBy = lbl_UserName.Text;
                    deldet.ModifiedDate = DateTime.Now;
                    DataMaster.SaveOrUpdate(deldet);


                    UpdateStok(false, 1, itemId, qty, true);
                }
            }
        }

        private void UpdateStok(bool isPacket, int gudangId, string itemId, decimal qty, bool AddStok)
        {
            if (!isPacket)
                UpdateStok(gudangId, itemId, qty, AddStok);
            else
            {
                IList paketItemList = DataMaster.GetListEq(typeof(MPacketItem), MPacketItem.ColumnNames.PacketId, itemId);
                MPacketItem paketItem;
                for (int i = 0; i < paketItemList.Count; i++)
                {
                    paketItem = (MPacketItem)paketItemList[i];
                    UpdateStok(gudangId, paketItem.ItemId, qty * paketItem.PacketItemQuantity, AddStok);
                }
            }
        }

        MItem item;
        private void UpdateStok(int gudangId, string itemId, decimal qty, bool AddStok)
        {
            ItemGudangStok stok;
            TStokCard krt;
            decimal saldo = 0;

            item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemId);

            if (item != null)
            {
                //if item == barang
                if (item.ItemTypeId == 1)
                {
                    //change stok
                    stok = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, itemId, ItemGudangStok.ColumnNames.GudangId, gudangId);
                    if (stok != null)
                    {
                        if (AddStok)
                            saldo = stok.ItemStok + qty;
                        else
                            saldo = stok.ItemStok - qty;

                        stok.ItemStok = saldo;
                        stok.ModifiedBy = lbl_UserName.Text;
                        stok.ModifiedDate = DateTime.Now;
                        DataMaster.UpdatePersistence(stok);
                    }
                    else
                    {
                        stok = new ItemGudangStok();
                        stok.GudangId = gudangId;
                        stok.ItemId = itemId;
                        stok.ItemMaxStok = decimal.Zero;
                        stok.ItemMinStok = decimal.Zero;
                        if (AddStok)
                            saldo = qty;
                        else
                            saldo = qty * -1;

                        stok.ItemStok = saldo;
                        stok.ModifiedBy = lbl_UserName.Text;
                        stok.ModifiedDate = DateTime.Now;
                        DataMaster.SavePersistence(stok);
                    }
                }

                krt = new TStokCard();
                krt.ItemId = itemId;
                krt.GudangId = gudangId;
                krt.StokCardDate = DateTime.Today;
                krt.StokCardPic = transactionByTextBox.Text;
                krt.StokCardQuantity = qty;
                krt.StokCardSaldo = saldo;
                krt.StokCardStatus = AddStok;
                krt.TransactionId = Convert.ToDecimal(transactionReferenceIdTextBox.Text);
                krt.ModifiedBy = lbl_UserName.Text;
                krt.ModifiedDate = DateTime.Now;
                DataMaster.SavePersistence(krt);
            }
        }

        decimal delId;
        bool isInEdit = false;
        bool isSave = false;
        TTransactionDelivery del;

        private void SaveOrUpdateDelivery()
        {
            if (!isInEdit)
            {
                delId = Convert.ToDecimal(DateTime.Now.ToFileTime());
                del = new TTransactionDelivery();
                isSave = true;
            }
            else
            {
                del = (TTransactionDelivery)DataMaster.GetObjectByProperty(typeof(TTransactionDelivery), TTransactionDelivery.ColumnNames.DeliveryId, delId);
                if (del != null)
                    isSave = false;
                else
                    isSave = true;
            }

            del.DeliveryCost = deliveryCostNumericUpDown.Value;
            del.DeliveryDesc = deliveryDescTextBox.Text;
            del.DeliveryExpedission = deliveryExpedissionTextBox.Text;
            del.DeliveryId = delId;
            del.DeliveryNumberExpedission = deliveryNumberExpedissionTextBox.Text;
            del.DeliveryNumberPic = deliveryNumberPicTextBox.Text;
            del.DeliveryPic = transactionByTextBox.Text;
            del.DeliveryReceiveDate = deliveryReceiveDateDateTimePicker.Value;
            del.DeliverySentDate = deliverySentDateDateTimePicker.Value;
            del.ModifiedBy = lbl_UserName.Text;
            del.ModifiedDate = DateTime.Now;
            del.TransactionId = Convert.ToDecimal(transactionReferenceIdTextBox.Text);
            del.DeliveryPayment = transactionPaymentComboBox.SelectedItem.ToString();

            if (isSave)
                DataMaster.SavePersistence(del);
            else
                DataMaster.UpdatePersistence(del);
        }

        private void tTransactionDeliveryDetailDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //   MessageBox.Show(tTransactionDeliveryDetailDataGridView.CurrentRow.Cells[0].Value.ToString());
            //MessageBox.Show(tTransactionDeliveryDetailDataGridView.CurrentRow.Cells[1].Value.ToString());
            //MessageBox.Show(tTransactionDeliveryDetailDataGridView.CurrentRow.Cells[2].Value.ToString());
            //MessageBox.Show(tTransactionDeliveryDetailDataGridView.CurrentRow.Cells[3].Value.ToString());
            //MessageBox.Show(tTransactionDeliveryDetailDataGridView.CurrentRow.Cells[4].Value.ToString());
            decimal qty = Convert.ToDecimal(tTransactionDeliveryDetailDataGridView.CurrentRow.Cells[3].Value);
            decimal qtyCurrent = Convert.ToDecimal(tTransactionDeliveryDetailDataGridView.CurrentRow.Cells[4].Value);
            decimal qtyDel = Convert.ToDecimal(tTransactionDeliveryDetailDataGridView.CurrentRow.Cells[5].Value);

            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(tTransactionDeliveryDetailDataGridView.CurrentRow.Cells[0].Value))
                {
                    tTransactionDeliveryDetailDataGridView.CurrentRow.Cells[5].Value = qty - qtyCurrent;
                }
                else
                {
                    tTransactionDeliveryDetailDataGridView.CurrentRow.Cells[5].Value = 0;
                }
            }

            if (e.ColumnIndex == 5)
            {
                if (Convert.ToBoolean(tTransactionDeliveryDetailDataGridView.CurrentRow.Cells[0].Value))
                {

                    if (qtyDel + qtyCurrent > qty)
                    {
                        MessageBox.Show("Kuantitas barang dikirim melebihi jumlah barang yang dipesan.", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
        }

        private void FillPayment()
        {
            Type desc = typeof(ListOfPayment);

            transactionPaymentComboBox.Items.Clear();
            foreach (string s in Enum.GetNames(desc))
            {
                transactionPaymentComboBox.Items.Add(Enum.Parse(desc, s).ToString().Replace("_", " "));
            }
            transactionPaymentComboBox.Show();

            try
            {
                transactionPaymentComboBox.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
        }

        private void transactionPaymentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            piHutangCreditLongNumericUpDown.Enabled = (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Credit.ToString());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            isInEdit = false;
            transactionPaymentComboBox.Enabled = true;
            transactionReferenceFacturTextBox.Enabled = true;
            transactionReferenceFacturTextBox.ResetText();
            transactionReferenceFacturTextBox_Validating(null, null);
            tTransactionDeliveryBindingSource.Clear();
            tPiHutangBindingSource.Clear();
            toolStripButton1.Enabled = true;
        }

        private void deliveryExpedissionTextBox_Validating(object sender, CancelEventArgs e)
        {
            ModuleControlSettings.EkspedissionValidating(deliveryExpedissionTextBox.Text, deliveryExpedissionNameTextBox);
        }

        private void deliveryExpedissionTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(deliveryExpedissionTextBox, ListOfSearchWindow.SearchEkspedission.ToString(), true);
        }

        private void deliveryExpedissionTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(deliveryExpedissionTextBox, ListOfSearchWindow.SearchEkspedission.ToString(), false);
        }

        FormSearchDelivery f_SearchDelivery;
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (f_SearchDelivery != null)
            {
                if (!f_SearchDelivery.IsDisposed)
                    f_SearchDelivery.Close();
            }

            f_SearchDelivery = new FormSearchDelivery();
            f_SearchDelivery.DeliveryHasSelected += new EventHandler(f_SearchDelivery_DeliveryHasSelected);
            f_SearchDelivery.Show(this);
        }

        void f_SearchDelivery_DeliveryHasSelected(object sender, EventArgs e)
        {
            if (f_SearchDelivery.grid_Search.Rows.Count > 0)
            {
                delId = Convert.ToDecimal(f_SearchDelivery.grid_Search.CurrentRow.Cells[0].Value);

                del = (TTransactionDelivery)DataMaster.GetObjectByProperty(typeof(TTransactionDelivery), TTransactionDelivery.ColumnNames.DeliveryId, delId);
                if (del != null)
                {
                    toolStripButton1.Enabled = true;
                    isInEdit = true;
                    transactionReferenceFacturTextBox.Enabled = false;
                    FillTransactionDelivery(del);
                }
            }
        }

        private void FillTransactionDelivery(TTransactionDelivery del)
        {
            TTransaction t = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, del.TransactionId);
            if (t != null)
            {
                transactionReferenceFacturTextBox.Text = t.TransactionFactur;
                transactionReferenceFacturTextBox_Validating(null, null);
                deliveryExpedissionTextBox.Text = del.DeliveryExpedission;
                deliveryExpedissionTextBox_Validating(null, null);
                deliveryNumberExpedissionTextBox.Text = del.DeliveryNumberExpedission;
                deliverySentDateDateTimePicker.Value = del.DeliverySentDate;
                deliveryReceiveDateDateTimePicker.Value = del.DeliveryReceiveDate;
                deliveryCostNumericUpDown.Value = del.DeliveryCost;
                deliveryDescTextBox.Text = del.DeliveryDesc;
                transactionPaymentComboBox.Enabled = false;
                transactionPaymentComboBox.SelectedItem = del.DeliveryPayment;

                TPiHutang pihut = (TPiHutang)DataMaster.GetObjectByProperty(typeof(TPiHutang), TPiHutang.ColumnNames.TransactionId, del.DeliveryId);
                if (pihut != null)
                    piHutangCreditLongNumericUpDown.Value = pihut.PiHutangCreditLong;
            }

        }
    }
}