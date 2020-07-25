using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.Data;
using System.Collections;
using Inventori.Module;
//using Inventori.Forms;

namespace Inventori.Dealer.Forms
{
    public partial class FormTransaction : FormParentForDealer
    {
        ListOfTransaction trans = ListOfTransaction.Sales;
        private Balloon.NET.BalloonHelp balloonHelp;
        public FormTransaction(ListOfTransaction t)
        {
            InitializeComponent();

            //tipe transaksi
            trans = t;

            //add
            button_Add.Click += new EventHandler(button_Add_Click);
            //reset
            button_Reset.Click += new EventHandler(button_Reset_Click);
            //batal
            CancelButton.Click += new EventHandler(CancelButton_Click);
            //reset transaction
            toolStripButton_Reset.Click += new EventHandler(toolStripButton_Reset_Click);
            //gudangIdComboBox
            gudangIdComboBox.SelectedIndexChanged += new EventHandler(gudangIdComboBox_SelectedIndexChanged);
            gudangIdToComboBox.SelectedIndexChanged += new EventHandler(gudangIdToComboBox_SelectedIndexChanged);
            //payment
            transactionPaymentComboBox.SelectedIndexChanged += new EventHandler(transactionPaymentComboBox_SelectedIndexChanged);
            //pelanggan
            transactionByComboBox.SelectedIndexChanged += new EventHandler(transactionByComboBox_SelectedIndexChanged);
            //item
            itemIdComboBox.SelectedIndexChanged += new EventHandler(itemIdComboBox_SelectedIndexChanged);
            //numeric price
            Module.ModuleControlSettings.SetNumericUpDown(priceNumericUpDown, true, 0);
            Module.ModuleControlSettings.SetNumericUpDown(costPriceNumericUpDown, true, 0);
            Module.ModuleControlSettings.SetNumericUpDown(transactionIdNumericUpDown);
            Module.ModuleControlSettings.SetNumericUpDown(transactionGrandTotalNumericUpDown, true, 0);
            Module.ModuleControlSettings.SetNumericUpDown(transactionPotonganNumericUpDown, false, 0);
            Module.ModuleControlSettings.SetNumericUpDown(transactionPaidNumericUpDown, false, 0);
            //date
            Module.ModuleControlSettings.SetDateTimePicker(transactionDateDateTimePicker, true);
            //search stok
            PictureBox searchPic = new PictureBox();
            Module.ModuleControlSettings.SetSearchPictureBox(stockIdTextBox, ListOfSearchWindow.SearchTransaction.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPic_Click);
            stockIdTextBox.Controls.Add(searchPic);
            stockIdTextBox.Enter += new EventHandler(stockIdTextBox_Enter);
            stockIdTextBox.Leave += new EventHandler(stockIdTextBox_Leave);

            //grid view
            tTransactionDetailDataGridView.RowsAdded += new DataGridViewRowsAddedEventHandler(tTransactionDetailDataGridView_RowsAdded);
            tTransactionDetailDataGridView.RowsRemoved += new DataGridViewRowsRemovedEventHandler(tTransactionDetailDataGridView_RowsRemoved);
            //simpanToolStripButton
            simpanToolStripButton.Click += new EventHandler(simpanToolStripButton_Click);
            //stok id
            stockIdTextBox.Validating += new CancelEventHandler(stockIdTextBox_Validating);

            //daftar transaksi
            toolStripButton_List.Click += new EventHandler(toolStripButton_List_Click);

            //print
            toolStripButton_printKwitansi.Click += new EventHandler(toolStripButton_printKwitansi_Click);
            printDocument_Kwitansi.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument_Kwitansi_PrintPage);
            toolStripButton_printSurat.Click += new EventHandler(toolStripButton_printSurat_Click);
            printDocument_Surat.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument_Surat_PrintPage);

        }

        void printDocument_Surat_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Single xPos = e.MarginBounds.Left;
            Single yPos = e.MarginBounds.Top;
            Font printFont = new Font("Arial", 10, FontStyle.Bold);
            Single lineHeight = printFont.GetHeight(e.Graphics) + 5;
            string txt = string.Empty;

            if (trans == ListOfTransaction.Mutation)
            {
                //channel
                string titipan = "TITIPAN";
                bool temp = false;
                xPos = e.MarginBounds.Left + 100f + 50f;
                yPos += lineHeight * 6.5f;
                if (gudangIdComboBox.SelectedValue != null && gudangIdToComboBox.SelectedValue != null)
                {
                    //jika lokasi adalah channel
                    if (Convert.ToInt32(gudangIdComboBox.SelectedValue) == 4)
                    {
                        txt = locationIdComboBox.Text;
                        titipan = "TARIKAN";
                        temp = true;
                    }
                    //jika lokasi tujuan adalah channel
                    if (Convert.ToInt32(gudangIdToComboBox.SelectedValue) == 4)
                    {
                        txt = locationIdToComboBox.Text;
                        //jika tarik dan titip
                        if (temp)
                            titipan = "TITIPAN / TARIKAN";
                        else
                            titipan = "TITIPAN";
                    }
                }

                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                //tarikan atau titipan
                xPos += 300f;
                txt = titipan;
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            }
            else if (trans == ListOfTransaction.Sales)
            {
                //nama
                xPos = e.MarginBounds.Left + 100f + 50f;
                yPos += lineHeight * 6.5f;
                txt = customerDescTextBox.Text;
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            }

            //alamat
            xPos = e.MarginBounds.Left + 100f + 50f;
            yPos += lineHeight * 1.5f;
            txt = customerAddressTextBox.Text;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //
            yPos += lineHeight * 3.5f;
            Single yPosKet = yPos + (lineHeight * 1.5f);
            //unit 
            for (int i = 0; i < tTransactionDetailDataGridView.RowCount; i++)
            {
                //nomor
                xPos = e.MarginBounds.Left + 50f;
                yPos += lineHeight * 1.5f;
                txt = (i + 1).ToString();
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                //nomor
                xPos += 30f;
                txt = "1 UNIT";
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                //type
                xPos += 60f + 30f;
                txt = tTransactionDetailDataGridView.Rows[i].Cells[1].Value.ToString();
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                //warna
                xPos += 120f;// -30f;
                txt = tTransactionDetailDataGridView.Rows[i].Cells[4].Value.ToString();
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                //no rangka
                xPos += 120f - 30f + 20f;
                txt = tTransactionDetailDataGridView.Rows[i].Cells[5].Value.ToString();
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                //mesin
                xPos += 120f - 20f;
                txt = tTransactionDetailDataGridView.Rows[i].Cells[6].Value.ToString();
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            }

            int totUnit = tTransactionDetailDataGridView.RowCount;
            //perkecil tulisan
            printFont = new Font("Arial", 8, FontStyle.Regular);
            lineHeight = printFont.GetHeight(e.Graphics) + 5;
            //keterangan
            //kunci kontak
            xPos += 225f - 30f;
            yPos = yPosKet;
            txt = (totUnit * 2).ToString() + " BUAH";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //toolkit
            yPos += lineHeight;
            txt = (totUnit * 1).ToString() + " SET";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //kaca spion
            yPos += lineHeight;
            txt = "TERPASANG";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //jaket
            yPos += lineHeight;
            txt = (totUnit * 1).ToString() + " BUAH";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //helm
            yPos += lineHeight;
            txt = (totUnit * 1).ToString() + " BUAH";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //baterai
            yPos += lineHeight;
            txt = "TERPASANG";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //buku service
            yPos += lineHeight;
            txt = (totUnit * 1).ToString() + " BUAH";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //buku petunjuk service
            yPos += lineHeight * 1.5f;
            txt = (totUnit * 1).ToString() + " BUAH";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //lain-lain

            //tanggal
            printFont = new Font("Arial", 10, FontStyle.Bold);
            lineHeight = printFont.GetHeight(e.Graphics) + 5;

            xPos -= 100f;
            yPos += lineHeight * 2.5f;
            txt = transactionDateDateTimePicker.Value.ToString(ModuleControlSettings.DateFormat());
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
        }

        void toolStripButton_printSurat_Click(object sender, EventArgs e)
        {
            PrintFacturSurat();
        }

        private void PrintFacturSurat()
        {
            CustomPrint.AddCustomPaperSizeToDefaultPrinter("SuratPaper", AppCode.PaperSuratWidth, AppCode.PaperSuratHeight);
            ////printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(96, 48, 48, 48);
            printDocument_Surat.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            printDocument_Surat.DefaultPageSettings.PaperSize.PaperName = "SuratPaper";
            printDocument_Surat.Print();

            //this.Enabled = false;

            if (f_Stat != null)
            {
                if (!f_Stat.IsDisposed)
                    f_Stat.Close();
            }
            f_Stat = new FormPrintStatus();
            f_Stat.PrintStatusHasSelected += new EventHandler(f_Stat2_PrintStatusHasSelected);
            f_Stat.Show(this);
            f_Stat.Focus();
        }

        private void f_Stat2_PrintStatusHasSelected(object sender, EventArgs e)
        {
            if (sender.Equals(ListOfPrintStatus.PrintOK))
            {

            }
            else if (sender.Equals(ListOfPrintStatus.PrintFailed))
            {
                PrintFacturSurat();
            }
            else if (sender.Equals(ListOfPrintStatus.PrintCancel))
            {
            }
        }

        void printDocument_Kwitansi_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Single xPos = e.MarginBounds.Left;
            Single yPos = e.MarginBounds.Top;
            Font printFont = new Font("Arial", 10, FontStyle.Bold);
            Single lineHeight = printFont.GetHeight(e.Graphics) + 5;
            string txt = string.Empty;

            //nomor faktur
            xPos = e.MarginBounds.Left + 160f + 140f;
            yPos += lineHeight * 3f;
            txt = transactionFacturTextBox.Text;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //nama + alamat
            xPos = e.MarginBounds.Left + 260f + 40f;
            yPos += lineHeight * 1.5f;
            txt = customerNameTextBox.Text + " " + customerAddressTextBox.Text;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //banyaknya
            xPos = e.MarginBounds.Left + 260f + 40f;
            yPos += lineHeight * 1.5f;
            string terbilang = new AppCode().GetNumericSaid(transactionPaidNumericUpDown.Value);
            if (terbilang.Length > 60)
            {
                string terbilang1 = terbilang.Substring(0, 60);
                int lastSpace = terbilang1.LastIndexOf(" ");
                txt = "# " + terbilang1.Substring(0, lastSpace);
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                yPos += lineHeight;
                txt = terbilang.Substring(lastSpace, terbilang.Length - lastSpace) + " Rupiah #";
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
                yPos -= lineHeight;
            }
            else
            {
                txt = "# " + terbilang + " Rupiah #";
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            }

            //merek / type
            xPos = e.MarginBounds.Left + 360f + 40f;
            yPos += lineHeight * 2.5f;
            txt = tTransactionDetailDataGridView.Rows[0].Cells[3].Value.ToString();
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //no rangka
            xPos = e.MarginBounds.Left + 360f + 40f;
            yPos += lineHeight * 1.25f;
            txt = tTransactionDetailDataGridView.Rows[0].Cells[5].Value.ToString();
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //no mesin
            xPos = e.MarginBounds.Left + 360f + 40f;
            yPos += lineHeight * 1.25f;
            txt = tTransactionDetailDataGridView.Rows[0].Cells[6].Value.ToString();
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //warna
            xPos = e.MarginBounds.Left + 360f + 40f;
            yPos += lineHeight * 1.25f;
            txt = tTransactionDetailDataGridView.Rows[0].Cells[4].Value.ToString();
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //ket
            xPos = e.MarginBounds.Left + 360f + 40f;
            yPos += lineHeight * 1.25f;
            txt = "KONDISI BARU";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //pekanbaru
            xPos = e.MarginBounds.Left + 460f + 80f;
            yPos += lineHeight * 1.5f;
            txt = transactionDateDateTimePicker.Value.ToString(ModuleControlSettings.DateFormat());
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //total rp
            xPos = e.MarginBounds.Left + 260f;
            yPos += lineHeight * 2.5f;
            txt = ModuleControlSettings.NumericFormat(transactionPaidNumericUpDown.Value, true);
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);


        }

        void toolStripButton_printKwitansi_Click(object sender, EventArgs e)
        {
            PrintFacturKwitansi();
        }

        private FormPrintStatus f_Stat;
        private void PrintFacturKwitansi()
        {
            CustomPrint.AddCustomPaperSizeToDefaultPrinter("KwitansiPaper", AppCode.PaperKwitansiWidth, AppCode.PaperKwitansiHeight);
            ////printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(96, 48, 48, 48);
            printDocument_Kwitansi.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            printDocument_Kwitansi.DefaultPageSettings.PaperSize.PaperName = "KwitansiPaper";
            printDocument_Kwitansi.Print();

            //this.Enabled = false;

            if (f_Stat != null)
            {
                if (!f_Stat.IsDisposed)
                    f_Stat.Close();
            }
            f_Stat = new FormPrintStatus();
            f_Stat.PrintStatusHasSelected += new EventHandler(f_Stat_PrintStatusHasSelected);
            f_Stat.Show(this);
            f_Stat.Focus();
        }

        private void f_Stat_PrintStatusHasSelected(object sender, EventArgs e)
        {
            if (sender.Equals(ListOfPrintStatus.PrintOK))
            {

            }
            else if (sender.Equals(ListOfPrintStatus.PrintFailed))
            {
                PrintFacturKwitansi();
            }
            else if (sender.Equals(ListOfPrintStatus.PrintCancel))
            {
            }
        }

        FormSearchTransaction f_SearchTrans;
        void toolStripButton_List_Click(object sender, EventArgs e)
        {
            if (f_SearchTrans != null)
            {
                if (!f_SearchTrans.IsDisposed)
                    f_SearchTrans.Close();
            }

            f_SearchTrans = new FormSearchTransaction(trans);
            f_SearchTrans.TransactionHasSelected += new EventHandler(f_SearchTrans_TransactionHasSelected);
            f_SearchTrans.Show(this);
        }

        bool isInEdit = false;
        void f_SearchTrans_TransactionHasSelected(object sender, EventArgs e)
        {
            if (f_SearchTrans.grid_Search.Rows.Count > 0)
            {
                //transactionIdNumericUpDown.Value = Convert.ToDecimal(f_SearchTrans.grid_Search.CurrentRow.Cells[0].Value);

                SetTransaction(Convert.ToDecimal(f_SearchTrans.grid_Search.CurrentRow.Cells[0].Value));


                isInEdit = true;
                simpanToolStripButton.Enabled = true;

                SetDisplayTransaction(isInEdit);
                //TTransaction tr = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, transactionIdNumericUpDown.Value);
                //if (tr != null)
                //{
                //    simpanToolStripButton.Enabled = true;
                //    isInEdit = true;
                //    transactionPaymentComboBox.Enabled = false;

                //    transactionFacturTextBox.Text = tr.TransactionFactur;
                //    transactionDateDateTimePicker.Value = tr.TransactionDate;

                //    //to gudang
                //    gudangIdToComboBox.SelectedValue = tr.GudangIdTo;
                //    locationIdToComboBox.SelectedValue = tr.LocationIdTo;
                //    //from gudang
                //    gudangIdComboBox.SelectedValue = tr.GudangTo;
                //    locationIdComboBox.SelectedValue = tr.LocationId;

                //}
            }
        }

        void gudangIdToComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //gudang combobox
                if (gudangIdToComboBox.SelectedValue != null)
                    //if (!string.IsNullOrEmpty(gudangIdToComboBox.SelectedValue.ToString()))
                    locationIdToComboBox.Enabled = (Convert.ToInt32(gudangIdToComboBox.SelectedValue.ToString()) == 4);
            }
            catch (Exception)
            {

                //throw;
            }

            //set channel name to first row
            if (!locationIdToComboBox.Enabled)
                locationIdToComboBox.SelectedIndex = 0;
        }

        void toolStripButton_Reset_Click(object sender, EventArgs e)
        {
            SetTransaction(Convert.ToDecimal(DateTime.Now.ToFileTime()));
            isInEdit = false;
            simpanToolStripButton.Enabled = true;
            toolStripButton_printKwitansi.Enabled = false;
            toolStripButton_printSurat.Enabled = false;

            SetDisplayTransaction(isInEdit);
        }

        private void SetDisplayTransaction(bool isInEdit)
        {
            TranLocPanel.Enabled = !isInEdit;
            LocationToPanel.Enabled = !isInEdit;
        }

        void stockIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(stockIdTextBox.Text))
            {
                TStock stok = DataMaster.GetObjectByProperty(typeof(TStock), TStock.ColumnNames.StockId, stockIdTextBox.Text) as TStock;
                if (stok == null)
                {
                    stok = new TStock();
                }

                itemIdComboBox.SelectedValue = stok.ItemId;
                stockDesc1ComboBox.SelectedValue = stok.StockDesc1;
                stockDesc2TextBox.Text = stok.StockDesc2;
                stockDesc3TextBox.Text = stok.StockDesc3;
            }
        }

        void simpanToolStripButton_Click(object sender, EventArgs e)
        {
            if (!ValidateTransaction())
                return;

            SaveTransaction();
            SaveTransactionDetail();
            MessageBox.Show(Text + " berhasil disimpan.", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);

            isInEdit = false;
            simpanToolStripButton.Enabled = false;
            toolStripButton_printKwitansi.Enabled = true;
            toolStripButton_printSurat.Enabled = true;
            //SetTransaction(Convert.ToDecimal(DateTime.Now.ToFileTime()));
            //ResetTransactionDetail();
        }

        private bool ValidateTransaction()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (TranLocPanel.Visible)
            {
                if (gudangIdComboBox.SelectedValue != null)
                {
                    if (int.Parse(gudangIdComboBox.SelectedValue.ToString()) == 0)
                    {
                        balloonHelp.Content = "Pilih lokasi !!!";
                        balloonHelp.ShowBalloon(gudangIdComboBox);
                        gudangIdComboBox.Focus();
                        return false;
                    }
                }

                if (locationIdComboBox.Enabled)
                {
                    if (locationIdComboBox.SelectedValue != null)
                    {
                        if (string.IsNullOrEmpty(locationIdComboBox.SelectedValue.ToString()))
                        {
                            balloonHelp.Content = "Pilih channel !!!";
                            balloonHelp.ShowBalloon(locationIdComboBox);
                            locationIdComboBox.Focus();
                            return false;
                        }
                    }
                }
            }

            if (LocationToPanel.Visible)
            {
                if (gudangIdToComboBox.SelectedValue != null)
                {
                    if (int.Parse(gudangIdToComboBox.SelectedValue.ToString()) == 0)
                    {
                        balloonHelp.Content = "Pilih tujuan lokasi !!!";
                        balloonHelp.ShowBalloon(gudangIdToComboBox);
                        gudangIdToComboBox.Focus();
                        return false;
                    }
                }

                if (locationIdToComboBox.Enabled)
                {
                    if (locationIdToComboBox.SelectedValue != null)
                    {
                        if (string.IsNullOrEmpty(locationIdToComboBox.SelectedValue.ToString()))
                        {
                            balloonHelp.Content = "Pilih tujuan channel !!!";
                            balloonHelp.ShowBalloon(locationIdToComboBox);
                            locationIdToComboBox.Focus();
                            return false;
                        }
                    }
                }
            }

            if (trans == ListOfTransaction.Sales)
            {
                if (string.IsNullOrEmpty(customerNameTextBox.Text.Trim()))
                {
                    balloonHelp.Content = "Nama Pelanggan harus diisi !!!";
                    balloonHelp.ShowBalloon(customerNameTextBox);
                    customerNameTextBox.Focus();
                    return false;
                }
            }
            else if (trans == ListOfTransaction.Purchase)
            {
                if (string.IsNullOrEmpty(transactionByComboBox.SelectedValue.ToString()))
                {
                    balloonHelp.Content = "Pilih supplier !!!";
                    balloonHelp.ShowBalloon(transactionByComboBox);
                    transactionByComboBox.Focus();
                    return false;
                }
            }

            if (TransPaymentPanel.Visible)
            {
                if (transactionDesc2ComboBox.Enabled)
                {
                    if (transactionDesc2ComboBox.SelectedValue != null)
                    {

                        if (string.IsNullOrEmpty(transactionDesc2ComboBox.SelectedValue.ToString()))
                        {
                            balloonHelp.Content = "Pilih finance !!!";
                            balloonHelp.ShowBalloon(transactionDesc2ComboBox);
                            transactionDesc2ComboBox.Focus();
                            return false;
                        }
                    }
                }
            }

            if (tTransactionDetailDataGridView.Rows.Count == 0)
            {
                balloonHelp.Content = "Transaksi yang kosong tidak bisa disimpan !!!";
                balloonHelp.ShowBalloon(tTransactionDetailDataGridView);
                tTransactionDetailDataGridView.Focus();
                return false;
            }


            return true;
        }

        private void SaveTransactionDetail()
        {
            if (isInEdit)
            {
                DeleteTransactionDetail();
            }
            TTransactionDetail det;
            TStock stok;
            bool isSaveStock = false;
            bool isSaveItemStock = true;
            for (int i = 0; i < tTransactionDetailDataGridView.Rows.Count; i++)
            {
                //save stock
                stok = DataMaster.GetObjectByProperty(typeof(TStock), TStock.ColumnNames.StockId, tTransactionDetailDataGridView.Rows[i].Cells[9].Value) as TStock;
                if (stok == null)
                {
                    isSaveStock = true;
                    stok = new TStock();
                    stok.StockId = AppCode.GetNewId(typeof(TStock));
                    stok.ItemId = tTransactionDetailDataGridView.Rows[i].Cells[1].Value.ToString();
                    stok.StockDesc1 = tTransactionDetailDataGridView.Rows[i].Cells[2].Value.ToString();
                    stok.StockDesc2 = tTransactionDetailDataGridView.Rows[i].Cells[5].Value.ToString();
                    stok.StockDesc3 = tTransactionDetailDataGridView.Rows[i].Cells[6].Value.ToString();
                }

                if (trans == ListOfTransaction.Purchase)
                {
                    stok.StockIsAvailable = true;
                    stok.GudangId = 1;
                    stok.StockDateIn = transactionDateDateTimePicker.Value;
                    stok.StockInBy = lbl_UserName.Text;
                    stok.StockPriceIn = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[7].Value);
                }
                else if (trans == ListOfTransaction.Sales)
                {
                    stok.StockIsAvailable = false;
                    stok.StockDateOut = transactionDateDateTimePicker.Value;
                    stok.StockOutBy = lbl_UserName.Text;
                    stok.StockPriceOut = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[7].Value);
                }
                else if (trans == ListOfTransaction.Mutation)
                {
                    stok.StockIsAvailable = true;
                    stok.GudangId = int.Parse(gudangIdToComboBox.SelectedValue.ToString());
                    stok.LocatonId = locationIdToComboBox.SelectedValue.ToString();
                    isSaveItemStock = false;
                }

                stok.ModifiedBy = lbl_UserName.Text;
                stok.ModifiedDate = DateTime.Now;
                if (isSaveStock)
                {
                    DataMaster.SavePersistence(stok);
                }
                else
                {
                    DataMaster.UpdatePersistence(stok);
                }

                //save detail
                det = DataMaster.GetObjectByProperty(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionDetailId, tTransactionDetailDataGridView.Rows[i].Cells[0].Value) as TTransactionDetail;
                if (det == null)
                {
                    det = new TTransactionDetail();
                }
                det.ItemId = tTransactionDetailDataGridView.Rows[i].Cells[1].Value.ToString();
                det.Price = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[7].Value);
                det.Quantity = decimal.One;
                det.CostPrice = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[8].Value);
                det.StockId = stok.StockId;
                det.TransactionId = Convert.ToDecimal(transactionIdNumericUpDown.Value);
                det.ModifiedBy = lbl_UserName.Text;
                det.ModifiedDate = DateTime.Now;
                DataMaster.SaveOrUpdate(det);

                //save item gudang stok
                if (isSaveItemStock)
                    SaveItemStock(int.Parse(gudangIdComboBox.SelectedValue.ToString()), tTransactionDetailDataGridView.Rows[i].Cells[1].Value.ToString(), decimal.One, false);

            }
        }

        private void DeleteTransactionDetail()
        {
            IList listDet = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, transactionIdNumericUpDown.Value);
            TTransactionDetail det;

            for (int i = 0; i < listDet.Count; i++)
            {
                det = listDet[i] as TTransactionDetail;

                if (det != null)
                {
                    //save stock
                    TStock stok = DataMaster.GetObjectByProperty(typeof(TStock), TStock.ColumnNames.StockId, det.StockId) as TStock;

                    if (stok != null)
                    {
                        if (trans == ListOfTransaction.Purchase)
                        {
                            DataMaster.Delete(stok);
                        }
                        else if (trans == ListOfTransaction.Sales)
                        {
                            stok.StockIsAvailable = true;
                            stok.StockDateOut = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
                            stok.StockOutBy = string.Empty;
                            stok.StockPriceOut = decimal.Zero;
                            stok.ModifiedBy = lbl_UserName.Text;
                            stok.ModifiedDate = DateTime.Now;
                            DataMaster.UpdatePersistence(stok);
                        }
                    }

                    //save item gudang stok
                    //if (isSaveItemStock)
                    SaveItemStock(int.Parse(gudangIdComboBox.SelectedValue.ToString()), det.ItemId, det.Quantity, true);

                    DataMaster.Delete(det);
                }
            }
        }

        private void SaveItemStock(int gudangId, string itemId, decimal qty, bool isDelete)
        {
            bool AddStok = true;
            switch (trans)
            {
                case ListOfTransaction.Correction:
                    break;
                case ListOfTransaction.Mutation:
                    break;
                case ListOfTransaction.Purchase:
                    AddStok = true;
                    gudangId = 1;
                    break;
                case ListOfTransaction.PurchaseOrder:
                    break;
                case ListOfTransaction.ReturPurchase:
                    break;
                case ListOfTransaction.ReturSales:
                    break;
                case ListOfTransaction.ReturSalesVIP:
                    break;
                case ListOfTransaction.Sales:
                    AddStok = false;
                    break;
                case ListOfTransaction.SalesVIP:
                    break;
                case ListOfTransaction.Service:
                    break;
                case ListOfTransaction.Temp:
                    break;
                case ListOfTransaction.Usage:
                    break;
                default:
                    break;
            }

            if (isDelete)
                AddStok = !AddStok;

            ItemGudangStok stok;
            TStokCard krt;
            decimal saldo = decimal.Zero;

            //MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemId);

            //if (item != null)
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

                krt = new TStokCard();
                krt.ItemId = itemId;
                krt.GudangId = gudangId;
                krt.StokCardDate = DateTime.Today;
                krt.StokCardPic = transactionByComboBox.SelectedValue.ToString();
                krt.StokCardQuantity = qty;
                krt.StokCardSaldo = saldo;
                krt.StokCardStatus = AddStok;
                krt.TransactionId = transactionIdNumericUpDown.Value;
                krt.ModifiedBy = lbl_UserName.Text;
                krt.ModifiedDate = DateTime.Now;
                DataMaster.SavePersistence(krt);
            }
        }

        private void SaveTransaction()
        {
            bool isSave = false;
            TTransaction t = DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, transactionIdNumericUpDown.Value) as TTransaction;
            if (t == null)
            {
                isSave = true;
                t = new TTransaction();
                t.TransactionId = transactionIdNumericUpDown.Value;
            }
            if (SalesmanPanel.Visible)
            {
                t.EmployeeId = employeeIdComboBox.SelectedValue.ToString();
            }
            if (LocationToPanel.Visible)
            {
                t.GudangIdTo = Convert.ToInt32(gudangIdToComboBox.SelectedValue);
                t.LocationIdTo = locationIdToComboBox.SelectedValue.ToString();
            }

            t.TransactionDate = transactionDateDateTimePicker.Value;
            t.TransactionFactur = transactionFacturTextBox.Text;
            t.TransactionPayment = transactionPaymentComboBox.SelectedItem.ToString();

            if (t.TransactionPayment == ListOfPayment.Credit.ToString())
            {
                t.TransactionSisa = transactionGrandTotalNumericUpDown.Value - transactionPaidNumericUpDown.Value + transactionPotonganNumericUpDown.Value;
                t.TransactionPpn = transactionGrandTotalNumericUpDown.Value - transactionPaidNumericUpDown.Value + transactionPotonganNumericUpDown.Value;
            }

            if (TranLocPanel.Visible)
            {
                t.GudangId = Convert.ToInt32(gudangIdComboBox.SelectedValue);
                t.LocationId = locationIdComboBox.SelectedValue.ToString();
            }
            else
            {
                t.GudangId = 1;
            }

            t.TransactionDesc2 = transactionDesc2ComboBox.SelectedValue.ToString();
            if (TransByGroupBox.Visible)
            {
                if (string.IsNullOrEmpty(transactionByComboBox.SelectedValue.ToString()))
                    t.TransactionBy = SaveNewCustomer();
                else
                    t.TransactionBy = transactionByComboBox.SelectedValue.ToString();
            }
            t.TransactionPotongan = transactionPotonganNumericUpDown.Value;
            t.TransactionPaid = transactionPaidNumericUpDown.Value;
            t.TransactionGrandTotal = transactionGrandTotalNumericUpDown.Value;
            t.TransactionStatus = trans.ToString();
            t.ModifiedBy = lbl_UserName.Text;
            t.ModifiedDate = DateTime.Now;
            t.TransactionDesc = transactionDescTextBox.Text;

            if (isSave)
            {
                DataMaster.SavePersistence(t);
            }
            else
            {
                DataMaster.UpdatePersistence(t);
            }

        }

        private string SaveNewCustomer()
        {
            MCustomer cust = new MCustomer();
            cust.CustomerId = AppCode.GetNewId(typeof(MCustomer));
            cust.CustomerAddress = customerAddressTextBox.Text;
            cust.CustomerDisc = decimal.Zero;
            cust.CustomerFax = customerFaxTextBox.Text;
            cust.CustomerNpwp = customerNpwpTextBox.Text;
            cust.CustomerLimit = decimal.Zero;
            cust.CustomerName = customerNameTextBox.Text;
            cust.CustomerPhone = customerPhoneTextBox.Text;
            cust.CustomerStatus = ListOfCustStatus.Active.ToString();
            cust.SubAccountId = string.Empty;
            cust.CustomerDesc = customerDescTextBox.Text;
            cust.ModifiedBy = lbl_UserName.Text;
            cust.ModifiedDate = DateTime.Now;

            DataMaster.SavePersistence(cust);

            return cust.CustomerId;
        }

        void tTransactionDetailDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateGrandTotal();
        }

        private void CalculateGrandTotal()
        {
            decimal gt = decimal.Zero;
            for (int i = 0; i < tTransactionDetailDataGridView.Rows.Count; i++)
            {
                gt += Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[7].Value);
            }
            transactionGrandTotalNumericUpDown.Value = gt;
        }

        void tTransactionDetailDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateGrandTotal();
        }

        private void SetDisplayByTransactionType()
        {
            string transBy = string.Empty;
            bool showCustDetail = false;
            bool showTransPayment = false;
            bool showTransLoc = false;
            bool showStockId = false;
            bool enabledStockDetail = false;
            bool enabledPrice = false;
            string title = string.Empty;
            bool showLocationTo = false;
            bool showTransactionBy = true;
            bool showTransactionList = true;
            bool showSales = true;
            bool showPotongan = false;
            bool showPrintKwitansi = false;
            bool showPrintSurat = false;

            switch (trans)
            {
                case ListOfTransaction.Correction:
                    //transBy = "Pelanggan : ";
                    showCustDetail = false;
                    showTransPayment = false;
                    showTransLoc = true;
                    showStockId = true;
                    enabledStockDetail = false;
                    enabledPrice = false;
                    title = "Transaksi Koreksi Stok";
                    showLocationTo = false;
                    //LocationToPanel.Location = TransPaymentPanel.Location;
                    showTransactionBy = false;
                    showTransactionList = false;
                    showSales = false;
                    showPotongan = false;
                    showPrintKwitansi = false;
                    showPrintSurat = false;
                    break;
                case ListOfTransaction.Mutation:
                    transBy = "Pelanggan : ";
                    showCustDetail = false;
                    showTransPayment = false;
                    showTransLoc = true;
                    showStockId = true;
                    enabledStockDetail = false;
                    enabledPrice = false;
                    title = "Transaksi Mutasi Stok";
                    showLocationTo = true;
                    //LocationToPanel.Location = TransPaymentPanel.Location;
                    showTransactionBy = false;
                    showTransactionList = false;
                    showSales = false;
                    showPotongan = false;
                    showPrintKwitansi = false;
                    showPrintSurat = true;
                    break;
                case ListOfTransaction.Purchase:
                    //splitContainer1.SplitterDistance = 150;
                    transBy = "Supplier : ";
                    showCustDetail = false;
                    showTransPayment = false;
                    showTransLoc = false;
                    showStockId = false;
                    enabledStockDetail = true;
                    enabledPrice = true;
                    title = "Transaksi Pembelian";
                    gudangIdComboBox.SelectedValue = "1";
                    showLocationTo = false;
                    showTransactionBy = true;
                    //suupplier
                    AppCode.FillSupplierComboBox(transactionByComboBox);
                    showTransactionList = true;
                    showSales = false;
                    showPotongan = false;
                    PricePanel.Visible = false;
                    tTransactionDetailDataGridView.Columns[7].Visible = false;
                    showPrintKwitansi = false;
                    showPrintSurat = false;
                    break;
                case ListOfTransaction.PurchaseOrder:
                    break;
                case ListOfTransaction.ReturPurchase:
                    break;
                case ListOfTransaction.ReturSales:
                    break;
                case ListOfTransaction.ReturSalesVIP:
                    break;
                case ListOfTransaction.Sales:
                    transBy = "Pelanggan : ";
                    showCustDetail = true;
                    showTransPayment = true;
                    showTransLoc = true;
                    showStockId = true;
                    enabledStockDetail = false;
                    enabledPrice = false;
                    title = "Transaksi Penjualan";
                    showLocationTo = false;
                    showTransactionBy = true;
                    //pelanggan
                    AppCode.FillCustomerComboBox(transactionByComboBox);
                    showTransactionList = true;
                    showSales = true;
                    AppCode.FillSalesComboBox(employeeIdComboBox);
                    //SalesmanPanel.Location = LocationToPanel.Location;
                    showPotongan = true;
                    //SubsidiPanel.Location = LocationToPanel.Location;
                    surveyorPanel.Visible = true;
                    showPrintKwitansi = true;
                    showPrintSurat = true;
                    break;
                case ListOfTransaction.SalesVIP:
                    break;
                case ListOfTransaction.Service:
                    break;
                case ListOfTransaction.Temp:
                    break;
                case ListOfTransaction.Usage:
                    break;
                default:
                    break;
            }

            transactionByLabel.Text = transBy;
            customerDetailPanel.Visible = showCustDetail;
            TransPaymentPanel.Visible = showTransPayment;
            TranLocPanel.Visible = showTransLoc;
            StokIdPanel.Visible = showStockId;
            Text = TabText = title;
            StockDetailPanel.Enabled = enabledStockDetail;
            priceNumericUpDown.Enabled = enabledPrice;
            LocationToPanel.Visible = showLocationTo;
            TransByGroupBox.Visible = showTransactionBy;
            toolStripButton_List.Visible = showTransactionList;
            SalesmanPanel.Visible = showSales;
            SubsidiPanel.Visible = showPotongan;
            toolStripButton_printKwitansi.Visible = showPrintKwitansi;
            toolStripButton_printSurat.Visible = showPrintSurat;
        }

        void stockIdTextBox_Leave(object sender, EventArgs e)
        {
            Module.ModuleControlSettings.SetVisibleControlChild(stockIdTextBox, ListOfSearchWindow.SearchTransaction.ToString(), false);
        }

        void stockIdTextBox_Enter(object sender, EventArgs e)
        {
            Module.ModuleControlSettings.SetVisibleControlChild(stockIdTextBox, ListOfSearchWindow.SearchTransaction.ToString(), true);
        }

        void searchPic_Click(object sender, EventArgs e)
        {
            if (ValidateOpenSearchStock())
                OpenFormSearchStock();
        }

        private bool ValidateOpenSearchStock()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (gudangIdComboBox.SelectedValue != null)
            {
                if (int.Parse(gudangIdComboBox.SelectedValue.ToString()) == 0)
                {
                    balloonHelp.Content = "Pilih lokasi !!!";
                    balloonHelp.ShowBalloon(gudangIdComboBox);
                    gudangIdComboBox.Focus();
                    return false;
                }
            }

            if (locationIdComboBox.Enabled)
            {
                if (locationIdComboBox.SelectedValue != null)
                {
                    if (string.IsNullOrEmpty(locationIdComboBox.SelectedValue.ToString()))
                    {
                        balloonHelp.Content = "Pilih channel !!!";
                        balloonHelp.ShowBalloon(locationIdComboBox);
                        locationIdComboBox.Focus();
                        return false;
                    }
                }
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

        FormSearchStock f_SearchStock;
        private void OpenFormSearchStock()
        {
            if (f_SearchStock != null)
                f_SearchStock.Close();

            f_SearchStock = new FormSearchStock();

            f_SearchStock.StockHasSelected += new EventHandler(f_SearchStock_StockHasSelected);
            f_SearchStock.GudangId = int.Parse(gudangIdComboBox.SelectedValue.ToString());
            f_SearchStock.LocationId = locationIdComboBox.SelectedValue.ToString();

            f_SearchStock.ShowDialog(this);
        }

        void f_SearchStock_StockHasSelected(object sender, EventArgs e)
        {
            if (f_SearchStock.grid_Search.Rows.Count > 0)
                stockIdTextBox.Text = f_SearchStock.grid_Search.CurrentRow.Cells[0].Value.ToString();

            stockIdTextBox_Validating(null, null);
        }

        void button_Reset_Click(object sender, EventArgs e)
        {
            ResetTransactionDetail();
        }

        void CancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin membatalkan unit?", AppCode.AssemblyProduct, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                tTransactionDetailDataGridView.Rows.Remove(tTransactionDetailDataGridView.CurrentRow);

            ResetTransactionDetail();
        }

        private void ResetTransactionDetail()
        {
            stockIdTextBox.Text = string.Empty;
            itemIdComboBox.SelectedIndex = 0;
            stockDesc1ComboBox.SelectedIndex = 0;
            itemIdComboBox.SelectedIndex = 0;
            stockDesc1ComboBox.SelectedIndex = 0;
            stockDesc2TextBox.Text = string.Empty;
            stockDesc3TextBox.Text = string.Empty;
            priceNumericUpDown.Value = decimal.Zero;
            costPriceNumericUpDown.Value = decimal.Zero;
        }

        void itemIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MItem item = null;
            if (itemIdComboBox.SelectedValue != null)
            {
                if (!string.IsNullOrEmpty(itemIdComboBox.SelectedValue.ToString()))
                {
                    item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemIdComboBox.SelectedValue.ToString());
                }
            }

            if (item == null)
                item = new MItem();

            priceNumericUpDown.Value = item.ItemPriceMax;
            costPriceNumericUpDown.Value = item.ItemPricePurchase;

            //set price
            if (trans == ListOfTransaction.Purchase)
            {
                priceNumericUpDown.Value = item.ItemPricePurchase;
            }
            else if (trans == ListOfTransaction.Sales)
            {
                priceNumericUpDown.Value = item.ItemPriceMax;
            }
        }

        void transactionByComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customerDetailPanel.Visible)
            {
                MCustomer cust = null;
                if (!string.IsNullOrEmpty(transactionByComboBox.SelectedValue.ToString()))
                    cust = (MCustomer)DataMaster.GetObjectByProperty(typeof(MCustomer), MCustomer.ColumnNames.CustomerId, transactionByComboBox.SelectedValue.ToString());
                if (cust == null)
                {
                    cust = new MCustomer();
                    customerDetailPanel.Enabled = true;
                }
                else
                {
                    customerDetailPanel.Enabled = false;
                }

                customerNameTextBox.Text = cust.CustomerName;
                customerDescTextBox.Text = cust.CustomerDesc;
                customerAddressTextBox.Text = cust.CustomerAddress;
                customerNpwpTextBox.Text = cust.CustomerNpwp;
                customerPhoneTextBox.Text = cust.CustomerPhone;
                customerFaxTextBox.Text = cust.CustomerFax;
            }
        }

        void transactionPaymentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //finance
            if (transactionPaymentComboBox.SelectedItem != null)
                if (!string.IsNullOrEmpty(transactionPaymentComboBox.SelectedItem.ToString()))
                    transactionDesc2ComboBox.Enabled = (transactionPaymentComboBox.SelectedItem.ToString().Equals(ListOfPayment.Credit.ToString()));
        }

        void gudangIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //gudang combobox
                if (gudangIdComboBox.SelectedValue != null)
                    //if (int.Parse(gudangIdComboBox.SelectedValue.ToString()) != 0)
                    locationIdComboBox.Enabled = (Convert.ToInt32(gudangIdComboBox.SelectedValue) == 4);
            }
            catch (Exception)
            {

                //throw;
            }

            //set channel name to first row
            if (!locationIdComboBox.Enabled)
                locationIdComboBox.SelectedIndex = 0;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //inisial setting
            InitialSetting();
            //set display
            SetDisplayByTransactionType();
            //set empty transaction
            transactionIdNumericUpDown.Value = Convert.ToDecimal(DateTime.Now.ToFileTime());
            SetTransaction(transactionIdNumericUpDown.Value);

        }

        private void SetTransaction(decimal transactionId)
        {
            TTransaction t = DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, transactionId) as TTransaction;
            if (t == null)
            {
                t = new TTransaction();
                t.TransactionId = transactionId;
                t.TransactionDate = DateTime.Now;
                t.TransactionFactur = AppCode.GenerateFacturNo(trans, string.Empty);
                t.TransactionPayment = ListOfPayment.Cash.ToString();
                //t.GudangId = 0;
            }
            transactionIdNumericUpDown.Value = t.TransactionId;
            transactionDateDateTimePicker.Value = t.TransactionDate;
            transactionFacturTextBox.Text = t.TransactionFactur;
            //if (t.GudangId == 0)
            //    gudangIdComboBox.SelectedIndex = 0;
            //else
            gudangIdComboBox.SelectedValue = t.GudangId;
            //channel
            locationIdComboBox.SelectedValue = t.LocationId;
            //payment
            transactionPaymentComboBox.SelectedItem = t.TransactionPayment;
            //finance
            transactionDesc2ComboBox.SelectedValue = t.TransactionDesc2;
            //by
            transactionByComboBox.SelectedValue = t.TransactionBy;
            transactionByComboBox_SelectedIndexChanged(null, null);

            transactionPotonganNumericUpDown.Value = t.TransactionPotongan;
            if (t.TransactionPotongan == decimal.Zero)
                transactionPotonganNumericUpDown.ResetText();

            transactionPaidNumericUpDown.Value = t.TransactionPaid;
            if (t.TransactionPaid == decimal.Zero)
                transactionPaidNumericUpDown.ResetText();
            transactionDescTextBox.Text = t.TransactionDesc;
            //employee
            employeeIdComboBox.SelectedValue = t.EmployeeId;



            //fill transactio detail
            FillTransactionDetail(t.TransactionId);
        }

        private void FillTransactionDetail(decimal TransactionId)
        {
            tTransactionDetailDataGridView.Rows.Clear();

            IList list = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, TransactionId);
            if (list.Count > 0)
            {
                TTransactionDetail det;
                TStock stok;
                MItem item;
                MColour col;
                object[] obj;
                for (int i = 0; i < list.Count; i++)
                {
                    det = (TTransactionDetail)list[i];

                    //stok
                    stok = (TStock)DataMaster.GetObjectByProperty(typeof(TStock), TStock.ColumnNames.StockId, det.StockId);
                    if (stok == null)
                    {
                        stok = new TStock();
                    }

                    //item
                    item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, det.ItemId);
                    if (item == null)
                    {
                        item = new MItem();
                    }

                    //color
                    col = (MColour)DataMaster.GetObjectByProperty(typeof(MColour), MColour.ColumnNames.ColourId, stok.StockDesc1);
                    if (col == null)
                    {
                        col = new MColour();
                    }

                    obj = new object[10];
                    obj[0] = det.TransactionDetailId;
                    obj[1] = det.ItemId;
                    obj[2] = stok.StockDesc1;
                    obj[3] = item.ItemName;
                    obj[4] = col.ColourDesc;
                    obj[5] = stok.StockDesc2;
                    obj[6] = stok.StockDesc3;
                    obj[7] = det.Price;
                    obj[8] = det.CostPrice;
                    obj[9] = det.StockId;

                    tTransactionDetailDataGridView.Rows.Add(obj);
                }
            }
        }

        private void InitialSetting()
        {
            //lokasi
            AppCode.FillGudangComboBox(gudangIdComboBox);
            AppCode.FillGudangComboBox(gudangIdToComboBox);
            //channel
            AppCode.FillChannelComboBox(locationIdComboBox);
            AppCode.FillChannelComboBox(locationIdToComboBox);
            //payment
            AppCode.FillPaymentComboBox(transactionPaymentComboBox);
            //finance
            AppCode.FillFinanceComboBox(transactionDesc2ComboBox);
            //fill color
            AppCode.FillColorComboBox(stockDesc1ComboBox);
            //fill type unit
            AppCode.FillItemComboBox(itemIdComboBox);

            //grid view
            Module.ModuleControlSettings.SetGridDataView(tTransactionDetailDataGridView);
        }

        #region event handler

        void button_Add_Click(object sender, EventArgs e)
        {
            if (!ValidateTransactionDetail())
                return;


            object[] obj = new object[10];
            obj[0] = decimal.Zero;
            obj[1] = itemIdComboBox.SelectedValue;
            obj[2] = stockDesc1ComboBox.SelectedValue;
            obj[3] = itemIdComboBox.Text;
            obj[4] = stockDesc1ComboBox.Text;
            obj[5] = stockDesc2TextBox.Text;
            obj[6] = stockDesc3TextBox.Text;
            obj[7] = priceNumericUpDown.Value;
            obj[8] = costPriceNumericUpDown.Value;
            obj[9] = stockIdTextBox.Text;

            tTransactionDetailDataGridView.Rows.Add(obj);

            ResetTransactionDetail();
        }

        private bool ValidateTransactionDetail()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(itemIdComboBox.SelectedValue.ToString()))
            {
                balloonHelp.Content = "Pilih unit !!";
                balloonHelp.ShowBalloon(itemIdComboBox);
                itemIdComboBox.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(stockDesc1ComboBox.SelectedValue.ToString()))
            {
                balloonHelp.Content = "Pilih warna !!";
                balloonHelp.ShowBalloon(stockDesc1ComboBox);
                stockDesc1ComboBox.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(stockDesc2TextBox.Text))
            {
                balloonHelp.Content = "No rangka belum diisi !!";
                balloonHelp.ShowBalloon(stockDesc2TextBox);
                stockDesc2TextBox.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(stockDesc3TextBox.Text))
            {
                balloonHelp.Content = "No mesin belum diisi !!";
                balloonHelp.ShowBalloon(stockDesc3TextBox);
                stockDesc3TextBox.Focus();
                return false;
            }

            return true;
        }

        #endregion

    }
}