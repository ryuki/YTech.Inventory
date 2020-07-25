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

namespace Inventori.Cafe.Forms
{
    public partial class FormTransaction : FormParentForCafe
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private Balloon.NET.BalloonHelp balloonHelp;
        public event EventHandler TransactionHasSaved;
        public FormTransaction()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.sales1;
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);


        }

        public void SetInitialSettings()
        {
            ResetTransaction();
            if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Purchase.ToString()))
                ModuleControlSettings.SetNumericUpDown(num_Price);
            else
                ModuleControlSettings.SetNumericUpDown(num_Price, true);

            txt_Factur.Text = AppCode.GenerateFacturNo(lbl_TempDesk.Text);
        }

        private void FormTransaction_Load(object sender, EventArgs e)
        {
            //set numeric updown

            ModuleControlSettings.SetNumericUpDown(num_Quantity);
            ModuleControlSettings.SetNumericUpDown(num_Jumlah, true);
            ModuleControlSettings.SetNumericUpDown(num_Disc);
            ModuleControlSettings.SetNumericUpDown(num_Total, true);
            ModuleControlSettings.SetNumericUpDown(num_Tax);
            ModuleControlSettings.SetNumericUpDown(num_TaxValue);
            ModuleControlSettings.SetNumericUpDown(num_GrandTotal, true);
            ModuleControlSettings.SetNumericUpDown(num_Pay);

            ModuleControlSettings.SetNumericUpDown(num_Back, true);
            num_Back.Minimum = decimal.MinValue;


            for (int i = 0; i < 7; i++)
                grid_Trans.Columns.Add(i.ToString(), i.ToString());

            // Mengatur lebar kolom
            grid_Trans.Columns[0].Width = 192 - 1;
            grid_Trans.Columns[1].Width = 223;
            grid_Trans.Columns[2].Width = 65;
            grid_Trans.Columns[3].Width = 73 - 1;
            grid_Trans.Columns[4].Width = 101 - 1;
            grid_Trans.Columns[5].Width = 60 - 1;
            grid_Trans.Columns[6].Width = 89;

            grid_Trans.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid_Trans.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            ModuleControlSettings.SetDateTimePicker(dt_TransactionDate);
            dt_TransactionDate.Value = DateTime.Now;
            txt_TransactionId.Text = DateTime.Now.ToFileTimeUtc().ToString();

            MSetting set = (MSetting)DataMaster.GetObjectByProperty(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            if (set != null)
            {
                lbl_ShopName.Text = set.CompanyName;
                lbl_ShopAddress.Text = set.CompanyAddress + " " + set.CompanyCity;
                lbl_ShopTelp.Text = "Telp : " + set.CompanyTelp;
            }
            //set location shop header
            float shopWidth = (lbl_ShopName.Text.Length * (lbl_ShopName.Font.Size - 2));
            float xShop = (groupBox5.Width / 2) - (shopWidth / 2) + groupBox5.Location.X;
            lbl_ShopName.Location = new Point(Convert.ToInt32(xShop), lbl_ShopName.Location.Y);

            shopWidth = (lbl_ShopAddress.Text.Length * (lbl_ShopAddress.Font.Size - 2));
            xShop = (groupBox5.Width / 2) - (shopWidth / 2) + groupBox5.Location.X;
            lbl_ShopAddress.Location = new Point(Convert.ToInt32(xShop), lbl_ShopAddress.Location.Y);

            shopWidth = (lbl_ShopTelp.Text.Length * (lbl_ShopTelp.Font.Size - 2));
            xShop = (groupBox5.Width / 2) - (shopWidth / 2) + groupBox5.Location.X;
            lbl_ShopTelp.Location = new Point(Convert.ToInt32(xShop), lbl_ShopTelp.Location.Y);

            SetInitialSettings();
            detailControl_KeyDown(null, null);

            //show tunai group box
            if (!(lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString())))
            {
                lbl_Pay.Visible = false;
                num_Pay.Visible = false;
                lbl_Back.Visible = false;
                num_Back.Visible = false;
            }

            if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSalesVIP.ToString()))
            {
                lbl_Customer.Text = "Pelanggan :";
                if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()))
                {
                    ModuleControlSettings.SetNumericUpDown(num_Price, true);
                }
            }
            else if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Correction.ToString()))
                SetFormToCorrection();
            else
                lbl_Customer.Text = "Supplier :";

            PictureBox searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(txt_CustId, ListOfSearchWindow.SearchCustomer.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicCustomer_Click);
            txt_CustId.Controls.Add(searchPic);

            searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(txt_ItemId, ListOfSearchWindow.SearchItem.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicItem_Click);
            txt_ItemId.Controls.Add(searchPic);

            string j = "Penjualan";

            if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()))
                j = "Penjualan";
            else if (lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSalesVIP.ToString()))
                j = "Retur Penjualan";
            else if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Purchase.ToString()))
                j = "Pembelian";
            else if (lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturPurchase.ToString()))
                j = "Retur Pembelian";
            else if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Correction.ToString()))
                j = "Penyesuaian";

            this.TabText = j;
            this.Text = j;

            //fill suggest textbox
            ModuleControlSettings.FillItemSuggestSource(txt_ItemId);
            if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSalesVIP.ToString()))
                ModuleControlSettings.SetCustomerTextBoxSuggest(txt_CustId);
            else
                ModuleControlSettings.SetSupplierTextBoxSuggest(txt_CustId);
        }

        private void SetFormToCorrection()
        {

            splitContainer2.SplitterDistance = splitContainer2.SplitterDistance - 220;

            detailControl_KeyDown(txt_CustId, new KeyEventArgs(Keys.Enter));
            num_Quantity.Minimum = -99999999;
            lbl_Price.Visible = false;
            num_Price.Visible = false;
            txt_SubPrice.Visible = false;
            lbl_Jumlah.Visible = false;
            num_Jumlah.Visible = false;
            txt_SubJumlah.Visible = false;
            lbl_Disc.Visible = false;
            num_Disc.Visible = false;
            txt_SubDisc.Visible = false;
            lbl_Total.Visible = false;
            num_Total.Visible = false;
            txt_SubTotal.Visible = false;
            grid_Trans.Width = grid_Trans.Width - 320;
            //groupBox6.Width = 221;

            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox3.Location = new Point(8, groupBox3.Location.Y);
            button1.Location = new Point(button1.Location.X - 320, button1.Location.Y);
            button2.Location = new Point(button2.Location.X - 320, button2.Location.Y);
            button3.Location = new Point(button3.Location.X - 320, button3.Location.Y);

            groupBox5.Size = new Size(groupBox5.Size.Width - 300, groupBox5.Size.Height);
            groupBox2.Size = new Size(groupBox2.Size.Width - 300, groupBox2.Size.Height);
            groupBox4.Size = new Size(groupBox4.Size.Width - 300, groupBox4.Size.Height);
            groupBox9.Size = new Size(groupBox9.Size.Width - 320, groupBox9.Size.Height);
            this.Width = this.Width - 300;
            this.Height = this.Height - 70;

            lbl_ShopName.Location = new Point(lbl_ShopName.Location.X - 150, lbl_ShopName.Location.Y);
            lbl_ShopAddress.Location = new Point(lbl_ShopAddress.Location.X - 150, lbl_ShopAddress.Location.Y);
            lbl_ShopTelp.Location = new Point(lbl_ShopTelp.Location.X - 150, lbl_ShopTelp.Location.Y);

            //display balon petunjuk
            RecreateBalloon();
            balloonHelp.Caption = "Petunjuk Pengisian Data Kuantitas Item";
            balloonHelp.Content = "Jika jumlah item \"kurang\", maka kuantitas item diisi dengan tanda minus (misalnya : \"-8\" ) \n dan apabila jumlah item \"berlebih\", maka kuantitas item diisi tanpa tanda (misalnya : \"9\" )";
            balloonHelp.ShowBalloon(num_Quantity);
        }

        private void txt_CustId_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(txt_CustId, ListOfSearchWindow.SearchCustomer.ToString(), true);
        }

        private void txt_CustId_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(txt_CustId, ListOfSearchWindow.SearchCustomer.ToString(), false);
        }

        private void txt_ItemId_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(txt_ItemId, ListOfSearchWindow.SearchItem.ToString(), true);
        }

        private void txt_ItemId_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(txt_ItemId, ListOfSearchWindow.SearchItem.ToString(), false);
        }

        private void f_SearchItem_ItemHasSelected(object sender, EventArgs e)
        {
            if (f_SearchItem.grid_Search.Rows.Count > 0)
            {
                txt_ItemId.Text = f_SearchItem.grid_Search.Rows[f_SearchItem.grid_Search.CurrentRow.Index].Cells[0].Value.ToString();
                txt_ItemId_Validating(null, null);
            }
        }

        private void searchPicItem_Click(object sender, EventArgs e)
        {
            OpenFormSearchItem();
        }

        FormSearchItem f_SearchItem;//= new FormSearchItem();
        private void OpenFormSearchItem()
        {
            if (f_SearchItem != null)
            {
                if (!f_SearchItem.IsDisposed)
                {
                    f_SearchItem.WindowState = FormWindowState.Normal;
                    f_SearchItem.BringToFront();
                }
                else
                    f_SearchItem = new FormSearchItem();
            }
            else
                f_SearchItem = new FormSearchItem();

            f_SearchItem.ItemHasSelected += new EventHandler(f_SearchItem_ItemHasSelected);
            f_SearchItem.lbl_TempTransaction.Text = lbl_TempTransaction.Text;
            f_SearchItem.ShowInTaskbar = false;
            f_SearchItem.ShowDialog();
        }

        private void searchPicCustomer_Click(object sender, EventArgs e)
        {
            if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSalesVIP.ToString()))
                OpenFormSearchCustomer();
            else
                OpenFormSearchSupplier();
        }


        FormSearchCustomer f_SearchCustomer;//= new FormSearchItem();
        private void OpenFormSearchCustomer()
        {
            if (f_SearchCustomer != null)
            {
                if (!f_SearchCustomer.IsDisposed)
                {
                    f_SearchCustomer.WindowState = FormWindowState.Normal;
                    f_SearchCustomer.BringToFront();
                }
                else
                    f_SearchCustomer = new FormSearchCustomer();
            }
            else
                f_SearchCustomer = new FormSearchCustomer();

            f_SearchCustomer.CustomerHasSelected += new EventHandler(f_SearchCustomer_CustomerHasSelected);
            //f_SearchCustomer.MdiParent = this.MdiParent;
            f_SearchCustomer.ShowInTaskbar = false;
            f_SearchCustomer.ShowDialog();
        }

        private void f_SearchCustomer_CustomerHasSelected(object sender, EventArgs e)
        {
            if (f_SearchCustomer.grid_Search.Rows.Count > 0)
            {
                txt_CustId.Text = f_SearchCustomer.grid_Search.Rows[f_SearchCustomer.grid_Search.CurrentRow.Index].Cells[0].Value.ToString();
                txt_CustId_Validating(null, null);
            }
        }

        FormSearchSupplier f_SearchSupplier;//= new FormSearchItem();
        private void OpenFormSearchSupplier()
        {
            if (f_SearchSupplier != null)
            {
                if (!f_SearchSupplier.IsDisposed)
                {
                    f_SearchSupplier.WindowState = FormWindowState.Normal;
                    f_SearchSupplier.BringToFront();
                }
                else
                    f_SearchSupplier = new FormSearchSupplier();
            }
            else
                f_SearchSupplier = new FormSearchSupplier();

            f_SearchSupplier.SupplierHasSelected += new EventHandler(f_SearchSupplier_SupplierHasSelected);
            f_SearchSupplier.ShowInTaskbar = false;
            f_SearchSupplier.ShowDialog();
        }

        private void f_SearchSupplier_SupplierHasSelected(object sender, EventArgs e)
        {
            if (f_SearchSupplier.grid_Search.Rows.Count > 0)
            {
                txt_CustId.Text = f_SearchSupplier.grid_Search.Rows[f_SearchSupplier.grid_Search.CurrentRow.Index].Cells[0].Value.ToString();
                txt_CustId_Validating(null, null);
            }
        }

        private void CalculateItemPrice(object sender, EventArgs e)
        {
            try
            {
                decimal q = num_Quantity.Value;
                decimal p = num_Price.Value;
                decimal j = q * p;
                num_Jumlah.Value = j;

                decimal d = num_Disc.Value;
                decimal t = j * ((100 - d) / 100);
                num_Total.Value = t;
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateFormDetail())
                return;

            string[] field = new string[7];
            field[0] = txt_ItemId.Text;
            field[1] = txt_ItemName.Text;
            field[2] = ModuleControlSettings.NumericFormat(num_Quantity.Value);
            field[3] = ModuleControlSettings.NumericFormat(num_Price.Value);
            field[4] = ModuleControlSettings.NumericFormat(num_Jumlah.Value);
            field[5] = ModuleControlSettings.NumericFormat(num_Disc.Value);
            field[6] = ModuleControlSettings.NumericFormat(num_Total.Value);

            grid_Trans.Rows.Insert(0, field);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (grid_Trans.Rows.Count > 0)
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (grid_Trans.CurrentRow.Index != -1)
                        grid_Trans.Rows.RemoveAt(grid_Trans.CurrentRow.Index);
                    else
                        grid_Trans.Rows.RemoveAt(0);
                }
            }
        }

        private void grid_Trans_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SumSubTotal();
        }

        private void grid_Trans_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SumSubTotal();
        }

        private void SumSubTotal()
        {
            decimal sq = 0;
            decimal sp = 0;
            decimal sj = 0;
            decimal sd = 0;
            decimal st = 0;

            for (int i = 0; i < grid_Trans.Rows.Count; i++)
            {
                sq += Convert.ToDecimal(grid_Trans.Rows[i].Cells[2].Value);
                sp += Convert.ToDecimal(grid_Trans.Rows[i].Cells[3].Value);
                sj += Convert.ToDecimal(grid_Trans.Rows[i].Cells[4].Value);
                sd += Convert.ToDecimal(grid_Trans.Rows[i].Cells[5].Value);
                st += Convert.ToDecimal(grid_Trans.Rows[i].Cells[6].Value);
            }
            txt_SubQuantity.Text = ModuleControlSettings.NumericFormat(sq);
            txt_SubPrice.Text = ModuleControlSettings.NumericFormat(sp);
            txt_SubJumlah.Text = ModuleControlSettings.NumericFormat(sj);
            txt_SubDisc.Text = ModuleControlSettings.NumericFormat(sd);
            txt_SubTotal.Text = ModuleControlSettings.NumericFormat(st);
            SumGrandTotal(null, null);

            ResetTransactionDetail();
        }

        private void ResetTransactionDetail()
        {
            txt_ItemId.ResetText();
            txt_ItemName.ResetText();
            num_Quantity.Value = 1;
            num_Price.Value = 0;
            num_Jumlah.Value = 0;
            num_Disc.Value = 0;
            num_Total.Value = 0;

            num_Quantity.ResetText();

            txt_ItemId.Focus();
            txt_ItemId.Select();
        }

        private void SumGrandTotal(object sender, EventArgs e)
        {
            try
            {
                decimal st = Convert.ToDecimal(txt_SubTotal.Text);
                // decimal gt = st * ((100 + num_Tax.Value) / 100);
                decimal tax = (num_Tax.Value / 100) * st;
                if (sender == num_TaxValue)
                {
                    tax = num_TaxValue.Value;
                }
                num_TaxValue.Value = tax;
                num_GrandTotal.Value = st + tax;
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void SumBack(object sender, EventArgs e)
        {
            //try
            //{
            num_Back.Value = num_Pay.Value - num_GrandTotal.Value;
            //}
            //catch (Exception)
            //{
            //}
        }

        MSetting set;
        private void button3_Click(object sender, EventArgs e)
        {
            if (!ValidateFormHeader())
                return;

            if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()))
            {
                set = (MSetting)DataMaster.GetObjectByProperty(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
                if (set != null)
                {
                    if (set.AutoPrintSales)
                        PrintFactur();
                    else
                    {
                        DialogResult res = MessageBox.Show("Cetak faktur penjualan?", "Konfirmasi cetak faktur penjualan", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                            PrintFactur();
                        else if (res == DialogResult.No)
                            SaveTransactionInterface();
                    }
                }
                else
                    SaveTransactionInterface();
            }
            else
                SaveTransactionInterface();
        }

        private void SaveTransactionInterface()
        {
            SaveTransaction();
            SaveTransactionDetail();

            ResetTransaction();
            ResetTransactionDetail();

            if (this.TransactionHasSaved != null)
                this.TransactionHasSaved(this, null);
        }

        private FormPrintStatus f_Stat;
        private void PrintFactur()
        {
            //CustomPrint.AddCustomPaperSizeToDefaultPrinter("FacturPaper", 122, 140);
            printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            //printDocument1.DefaultPageSettings.PaperSize.PaperName = "FacturPaper";
            printDocument1.Print();

            //this.Enabled = false;

            if (f_Stat != null)
            {
                if (!f_Stat.IsDisposed)
                    f_Stat.Close();
            }
            f_Stat = new FormPrintStatus();
            f_Stat.PrintStatusHasSelected += new EventHandler(f_Stat_PrintStatusHasSelected);
            f_Stat.ShowDialog(this);
        }

        private void f_Stat_PrintStatusHasSelected(object sender, EventArgs e)
        {
            if (sender.Equals(ListOfPrintStatus.PrintOK))
                SaveTransactionInterface();
            else if (sender.Equals(ListOfPrintStatus.PrintFailed))
            {
                PrintFactur();
            }
            else if (sender.Equals(ListOfPrintStatus.PrintCancel))
            {
            }
            //this.Enabled = true;
        }

        private bool ValidateFormHeader()
        {
            if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Correction.ToString()))
                return true;

            //RecreateBalloon(this, EventArgs.Empty);
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(txt_Factur.Text))
            {
                balloonHelp.Content = "Nomor faktur harus diisi";
                balloonHelp.ShowBalloon(txt_Factur);
                txt_Factur.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txt_CustId.Text))
            {
                string errMsg = "";
                if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSalesVIP.ToString()))
                {
                    errMsg = "Kode pelanggan harus diisi";
                }
                else
                    errMsg = "Kode supplier harus diisi";

                balloonHelp.Content = errMsg;
                balloonHelp.ShowBalloon(txt_CustId);
                txt_CustId.Focus();
                return false;
            }
            else if (grid_Trans.RowCount == 0)
            {
                MessageBox.Show("Transaksi yang kosong tidak bisa diproses.", "Transaksi tidak bisa diproses.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ItemId.Select();
                txt_ItemId.Focus();
                return false;
            }
            else if (num_Back.Value < 0)
            {
                if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()))
                {
                    balloonHelp.Content = "Total yang harus dibayar lebih kecil dari pembayaran !!";
                    balloonHelp.ShowBalloon(num_Pay);
                    num_Pay.Focus();
                    return false;
                }
            }

            return true;
        }

        private void SaveTransaction()
        {
            TTransaction t = new TTransaction();
            t.TransactionBy = txt_CustId.Text;
            t.TransactionDate = dt_TransactionDate.Value;
            t.TransactionDisc = 0;
            t.TransactionFactur = txt_Factur.Text;
            t.TransactionGrandTotal = num_GrandTotal.Value;
            t.TransactionId = Convert.ToDecimal(txt_TransactionId.Text);
            t.TransactionPaid = num_GrandTotal.Value;
            t.TransactionPpn = num_Tax.Value;
            t.TransactionSisa = 0;
            t.TransactionStatus = lbl_TempTransaction.Text;
            t.TransactionSubTotal = Convert.ToDecimal(txt_SubTotal.Text);
            t.TransactionDesk = lbl_TempDesk.Text;
            t.EmployeeId = lbl_EmployeeId.Text;
            t.ModifiedBy = lbl_UserName.Text;
            t.ModifiedDate = DateTime.Now;
            DataMaster.SavePersistence(t);
        }

        private void SaveTransactionDetail()
        {
            TTransactionDetail det;
            ItemGudangStok stok;
            MItem item;
            TStokCard krt;


            //clear data if from billiard desk
            if (!lbl_TempDesk.Text.Equals(ListOfDesk.Cafe.ToString()))
            {
                IList listOfTransDetail = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, Convert.ToDecimal(txt_TransactionId.Text));
                for (int i = 0; i < listOfTransDetail.Count; i++)
                {
                    det = (TTransactionDetail)listOfTransDetail[i];
                    DataMaster.Delete(det);
                }

                TDesk t = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskTransactionId, Convert.ToDecimal(txt_TransactionId.Text));
                if (t != null)
                {
                    t.DeskStatus = ListOfBilliardPaymentStatus.Paid.ToString();
                    t.ModifiedBy = lbl_UserName.Text;
                    t.ModifiedDate = DateTime.Now;
                    DataMaster.UpdatePersistence(t);
                }
            }

            bool AddStok = true;
            decimal saldo = 0;

            if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturPurchase.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()))
                AddStok = false;
            else
                AddStok = true;

            for (int i = 0; i < grid_Trans.Rows.Count; i++)
            {
                saldo = 0;

                det = new TTransactionDetail();
                det.Disc = Convert.ToDecimal(grid_Trans.Rows[i].Cells[5].Value);
                det.ItemId = grid_Trans.Rows[i].Cells[0].Value.ToString();
                det.Ppn = 0;
                det.Price = Convert.ToDecimal(grid_Trans.Rows[i].Cells[3].Value);
                det.Quantity = Convert.ToDecimal(grid_Trans.Rows[i].Cells[2].Value);

                //if corection, save item quantity for detail total
                if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Correction.ToString()))
                    det.Total = Convert.ToDecimal(grid_Trans.Rows[i].Cells[2].Value);
                else
                    det.Total = Convert.ToDecimal(grid_Trans.Rows[i].Cells[6].Value);

                det.TransactionId = Convert.ToDecimal(txt_TransactionId.Text);
                det.Jumlah = Convert.ToDecimal(grid_Trans.Rows[i].Cells[4].Value);

                det.ModifiedBy = lbl_UserName.Text;
                det.ModifiedDate = DateTime.Now;
                DataMaster.SavePersistence(det);

                item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, grid_Trans.Rows[i].Cells[0].Value.ToString());
                if (item != null)
                {
                    //if item == barang
                    if (item.ItemTypeId == 1)
                    {
                        //change stok
                        stok = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, grid_Trans.Rows[i].Cells[0].Value.ToString());
                        if (stok != null)
                        {
                            if (AddStok)
                                saldo = stok.ItemStok + Convert.ToDecimal(grid_Trans.Rows[i].Cells[2].Value);
                            else
                                saldo = stok.ItemStok - Convert.ToDecimal(grid_Trans.Rows[i].Cells[2].Value);

                            stok.ItemStok = saldo;
                            stok.ModifiedBy = lbl_UserName.Text;
                            stok.ModifiedDate = DateTime.Now;
                            DataMaster.UpdatePersistence(stok);
                        }
                        else
                        {
                            stok = new ItemGudangStok();
                            stok.GudangId = 1;
                            stok.ItemId = det.ItemId;
                            stok.ItemMaxStok = 0;
                            stok.ItemMinStok = 0;
                            if (AddStok)
                                stok.ItemStok = det.Quantity;
                            else
                                stok.ItemStok = det.Quantity * -1;
                            stok.ModifiedBy = lbl_UserName.Text;
                            stok.ModifiedDate = DateTime.Now;
                            DataMaster.SavePersistence(stok);
                        }

                    }
                }

                krt = new TStokCard();
                krt.ItemId = grid_Trans.Rows[i].Cells[0].Value.ToString();
                krt.StokCardDate = DateTime.Now;
                krt.StokCardPic = lbl_UserName.Text;
                krt.StokCardQuantity = Convert.ToDecimal(grid_Trans.Rows[i].Cells[2].Value);
                krt.StokCardSaldo = saldo;
                krt.StokCardStatus = AddStok;
                krt.TransactionId = Convert.ToDecimal(txt_TransactionId.Text);
                krt.ModifiedBy = lbl_UserName.Text;
                krt.ModifiedDate = DateTime.Now;
                DataMaster.SavePersistence(krt);
            }

        }

        private void ResetTransaction()
        {
            txt_Factur.Text = AppCode.GenerateFacturNo(lbl_TempDesk.Text);
            txt_CustId.ResetText();
            txt_CustName.ResetText();
            txt_TransactionId.Text = DateTime.Now.ToFileTimeUtc().ToString();

            num_Pay.Value = 0;
            num_Back.Value = 0;
            num_Pay.ResetText();
            num_TaxValue.Value = 10;
            num_Tax.Value = 0;

            grid_Trans.Rows.Clear();
            dt_TransactionDate.Value = DateTime.Now;

            txt_Factur.Focus();
            txt_Factur.Select();
        }

        private bool ValidateFormDetail()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(txt_ItemId.Text))
            {
                balloonHelp.Content = "Item harus diisi";
                balloonHelp.ShowBalloon(txt_ItemId);
                txt_ItemId.Focus();
                return false;
            }
            else
            {
                MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, txt_ItemId.Text);
                if (item == null)
                {
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Item " + txt_ItemId.Text + " tidak ada dalam database. \n Pastikan anda menulis kode yang tepat atau \n pilih item dengan mengklik gambar disamping untuk mencari item.";
                    balloonHelp.ShowBalloon(txt_ItemId);
                    txt_ItemId.Focus();
                    return false;
                }
            }
            return true;
        }

        private void RecreateBalloon()
        {
            balloonHelp = new Balloon.NET.BalloonHelp();
            balloonHelp.Icon = Properties.Resources.warning;
            balloonHelp.CloseOnMouseClick = true;
            balloonHelp.CloseOnDeactivate = false;
            balloonHelp.ShowCloseButton = false;
            balloonHelp.TopMost = true;
        }

        private void txt_ItemId_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_ItemId.Text.Trim()))
            {
                MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, txt_ItemId.Text);

                if (item != null)
                {
                    txt_ItemName.Text = item.ItemName;

                    if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSales.ToString()))
                        num_Price.Value = item.ItemPriceMax;
                    else if (lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSalesVIP.ToString()))
                        num_Price.Value = item.ItemPriceMaxVip;
                    else if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Purchase.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturPurchase.ToString()))
                        num_Price.Value = item.ItemPricePurchase;

                    if (!lbl_TempTransaction.Text.Equals(ListOfTransaction.Correction.ToString()))
                        num_Price.Value = item.ItemPriceMax;
                }
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Single xPos = e.MarginBounds.Left;
            Single yPos = e.MarginBounds.Top;
            Font printFont = new Font("MS Sans Serif", 10);
            Single lineHeight = printFont.GetHeight(e.Graphics) + 5;

            //Single widthPaper = 480 - e.MarginBounds.Left;
            Single widthPaper = e.PageSettings.PaperSize.Width - e.MarginBounds.Left;
            string txt = "";

            txt = set.CompanyName;
            xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);


            txt = set.CompanyAddress + " " + set.CompanyCity;
            yPos += lineHeight;
            xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            txt = "Telp : " + set.CompanyTelp;
            yPos += lineHeight;
            xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //xPos = e.MarginBounds.Left;
            //yPos += lineHeight * 2;
            //txt = "No : " + txt_Factur.Text;
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            xPos = e.MarginBounds.Left;
            yPos += lineHeight;
            txt = dt_TransactionDate.Value.ToString("dd MMMM yyyy HH:mm");
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            yPos += lineHeight;
            for (int i = 0; i < grid_Trans.Rows.Count; i++)
            {
                //display item code
                //xPos = e.MarginBounds.Left;
                //yPos += lineHeight;
                //txt = grid_Trans.Rows[i].Cells[0].Value.ToString();
                //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                //display nama item
                //xPos += 100;
                xPos = e.MarginBounds.Left;
                yPos += lineHeight;
                txt = grid_Trans.Rows[i].Cells[1].Value.ToString();
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                //if (Convert.ToDecimal(grid_Trans.Rows[i].Cells[2].Value) != 1)
                //{
                //display kuantitas
                xPos = e.MarginBounds.Left;
                yPos += lineHeight;
                txt = ModuleControlSettings.NumericFormat(grid_Trans.Rows[i].Cells[2].Value) + " x @" + ModuleControlSettings.NumericFormat(grid_Trans.Rows[i].Cells[3].Value);
                //display discount
                if (ModuleControlSettings.isDecimal(grid_Trans.Rows[i].Cells[5].Value.ToString()))
                {
                    if (Convert.ToDecimal(grid_Trans.Rows[i].Cells[5].Value.ToString()) > 0)
                        txt += " - " + ModuleControlSettings.NumericFormat(grid_Trans.Rows[i].Cells[5].Value) + "%";
                }
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);



                ////display total
                //xPos += 130;
                txt = ModuleControlSettings.NumericFormat(grid_Trans.Rows[i].Cells[6].Value, true);
                xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;

                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            }

            if (num_TaxValue.Value > 0)
            {
                //display subtotal
                xPos = e.MarginBounds.Left + 50;
                yPos += lineHeight;
                txt = "Sub Total :  ";
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
                txt = ModuleControlSettings.NumericFormat(decimal.Parse(txt_SubTotal.Text), true);
                xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                //display tax
                xPos = e.MarginBounds.Left + 50;
                yPos += lineHeight;
                txt = "Tax :  ";
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
                txt = ModuleControlSettings.NumericFormat(num_TaxValue.Value, true);
                xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            }

            //display grantotal
            xPos = e.MarginBounds.Left + 50;
            yPos += lineHeight;
            txt = "Total :  ";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            txt = ModuleControlSettings.NumericFormat(num_GrandTotal.Value, true);
            //xPos =  e.MarginBounds.Right -e.Graphics.MeasureString(txt, printFont).Width;
            xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            ////display dibayar
            //xPos = e.MarginBounds.Left + 50;
            //yPos += lineHeight;
            //txt = "Tunai :  ";
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            //txt = ModuleControlSettings.NumericFormat(num_Pay.Value, true);
            ////xPos =  e.MarginBounds.Right -e.Graphics.MeasureString(txt, printFont).Width;
            //xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            ////display kembali
            //xPos = e.MarginBounds.Left + 50;
            //yPos += lineHeight;
            //txt = "Kembali :  ";
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            //txt = ModuleControlSettings.NumericFormat(num_Back.Value, true);
            ////xPos =  e.MarginBounds.Right -e.Graphics.MeasureString(txt, printFont).Width;
            //xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            ////keterangan            
            //txt = "Barang yang sudah dibeli";
            //yPos += lineHeight * 2;
            //xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //txt = "Tidak dapat ditukar / dikembalikan";
            //yPos += lineHeight;
            //xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //thanks
            txt = "Terima Kasih atas kunjungan anda";
            yPos += lineHeight * 2;
            xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //saran
            txt = "Saran dan kritik, hubungi : ";
            yPos += lineHeight;
            xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //saran
            Inventori.Cafe.Data.TCafeSetting cafeSet = (Inventori.Cafe.Data.TCafeSetting)DataMaster.GetObjectByProperty(typeof(Inventori.Cafe.Data.TCafeSetting), Inventori.Cafe.Data.TCafeSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            if (cafeSet != null)
            {
                txt = cafeSet.TelpNoSaranKritik;
                yPos += lineHeight;
                xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            }
        }

        private void txt_CustId_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_CustId.Text.Trim()))
            {
                if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSalesVIP.ToString()))
                {
                    MCustomer cust = (MCustomer)DataMaster.GetObjectByProperty(typeof(MCustomer), MCustomer.ColumnNames.CustomerId, txt_CustId.Text);
                    if (cust != null)
                        txt_CustName.Text = cust.CustomerName;
                    else
                        txt_CustName.ResetText();
                }
                else
                {
                    MSupplier supp = (MSupplier)DataMaster.GetObjectByProperty(typeof(MSupplier), MSupplier.ColumnNames.SupplierId, txt_CustId.Text);
                    if (supp != null)
                        txt_CustName.Text = supp.SupplierName;
                    else
                        txt_CustName.ResetText();
                }
            }
        }

        private void detailControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender == null)
            {
                txt_CustId.Focus();
                txt_CustId.Select();
            }
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode == Keys.Add)
                    if (Control.ModifierKeys == Keys.Control)
                    {
                        button1.PerformClick();
                        return;
                    }

                if (e.KeyCode == Keys.S)
                    if (Control.ModifierKeys == Keys.Control)
                    {
                        button3.PerformClick();
                        return;
                    }

                if (e.KeyCode == Keys.Delete)
                    if (Control.ModifierKeys == Keys.Control)
                    {
                        button2.PerformClick();
                        return;
                    }

                if (e.KeyCode != Keys.Enter)
                    return;

                if (sender == num_Pay)
                {
                    button3.PerformClick();
                    return;
                }

                if (sender == txt_Factur)
                    txt_CustId.Select();
                else if (sender == txt_CustId)
                    txt_ItemId.Select();
                else if (sender == txt_ItemId)
                    num_Quantity.Select();
                else if (sender == num_Quantity)
                    if (num_Price.Enabled)
                        num_Price.Select();
                    else
                        num_Disc.Select();
                else if (sender == num_Price)
                    num_Disc.Select();
                else if (sender == num_Disc)
                {
                    button1.PerformClick();
                    txt_ItemId.Select();
                }
                //else
                //    txt_Factur.Select();
            }
        }
    }
}