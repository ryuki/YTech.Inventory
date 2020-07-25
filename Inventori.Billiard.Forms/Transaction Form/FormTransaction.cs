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

namespace Inventori.Billiard.Forms
{
    public partial class FormTransaction : FormParentForBilliard
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private Balloon.NET.BalloonHelp balloonHelp;
        public event EventHandler TransactionHasSaved;
        public bool IsBindGridView = true;

        public FormTransaction()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.sales1;
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);

            //set numeric updown
            ModuleControlSettings.SetNumericUpDown(numericUpDown_ItemQuantity);
            ModuleControlSettings.SetNumericUpDown(num_Quantity);
            ModuleControlSettings.SetNumericUpDown(num_Jumlah, true);
            ModuleControlSettings.SetNumericUpDown(num_Disc);
            ModuleControlSettings.SetNumericUpDown(num_Total, true);
            ModuleControlSettings.SetNumericUpDown(num_PPN);
            ModuleControlSettings.SetNumericUpDown(num_GrandTotal, true);
            ModuleControlSettings.SetNumericUpDown(num_Pay);
            ModuleControlSettings.SetNumericUpDown(num_Back, true);

            num_Back.Minimum = decimal.MinValue;

            for (int i = 0; i < 7; i++)
                grid_Trans.Columns.Add(i.ToString(), i.ToString());

            // Mengatur lebar kolom
            grid_Trans.Columns[0].Width = 93 - 1;
            grid_Trans.Columns[1].Width = 153;
            grid_Trans.Columns[2].Width = 65;
            grid_Trans.Columns[3].Width = 73 - 1;
            grid_Trans.Columns[4].Width = 101 - 1;
            grid_Trans.Columns[5].Width = 60 - 1;
            grid_Trans.Columns[6].Width = 89;

            grid_Trans.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid_Trans.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //grid_Trans.Columns[2].DefaultCellStyle.Format = ModuleControlSettings.numFormat;
            //grid_Trans.Columns[3].DefaultCellStyle.Format = ModuleControlSettings.numFormat;
            //grid_Trans.Columns[4].DefaultCellStyle.Format = ModuleControlSettings.numFormat;
            //grid_Trans.Columns[5].DefaultCellStyle.Format = ModuleControlSettings.numFormat;
            //grid_Trans.Columns[6].DefaultCellStyle.Format = ModuleControlSettings.numFormat;

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
        }

        private void FormTransaction_Load(object sender, EventArgs e)
        {
            //show tunai group box
            if (!(lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString())))
            {
                lbl_Pay.Visible = false;
                num_Pay.Visible = false;
                lbl_Back.Visible = false;
                num_Back.Visible = false;
            }

            ModuleControlSettings.SetNumericUpDown(num_Price, true);

            if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSalesVIP.ToString()))
            {
                lbl_Customer.Text = "Pelanggan :";
                if (lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSalesVIP.ToString()))
                    num_Price.Enabled = true;
            }
            else if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Correction.ToString()))
                SetFormToCorrection();
            else
            {
                num_Price.Enabled = true;
                lbl_Customer.Text = "Supplier :";
            }

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

            txt_Factur.Text = AppCode.GenerateFacturNo(lbl_TempDesk.Text);

            if (IsBindGridView)
            {

                //fill suggest textbox
                //ModuleControlSettings.FillItemSuggestSource(txt_ItemId);
                if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSalesVIP.ToString()))
                {
                    ModuleControlSettings.SetCustomerTextBoxSuggest(txt_CustId);
                    //set grid view pelanggan
                    mCustomerBindingSource.Clear();
                    mCustomerBindingSource.DataSource = DataMaster.GetListNotEq(typeof(MCustomer), MCustomer.ColumnNames.CustomerStatus, ListOfCustStatus.Off.ToString());

                }
                else
                {
                    ModuleControlSettings.SetSupplierTextBoxSuggest(txt_CustId);
                    tabPage2.Text = "Daftar Suppplier";

                    //set grid view Suppplier
                    mSupplierBindingSource.Clear();
                    mSupplierBindingSource.DataSource = DataMaster.GetAll(typeof(MSupplier));
                    mCustomerDataGridView.DataSource = mSupplierBindingSource;
                    mCustomerDataGridView.Columns[0].HeaderText = "Kode Supplier";
                    mCustomerDataGridView.Columns[0].DataPropertyName = MSupplier.ColumnNames.SupplierId;
                    mCustomerDataGridView.Columns[1].DataPropertyName = MSupplier.ColumnNames.SupplierName;
                }


                //set combo box group and grid view item
                ModuleControlSettings.SetGroupComboBoxForFilter(combo_Group);
                combo_Group.SelectedIndex = 0;
                combo_Group_SelectedIndexChanged(null, null);
                //set num_quntity_item value = 1
                numericUpDown_ItemQuantity.Value = 1;
                //set grid view item
                ModuleControlSettings.SetGridDataView(mItemDataGridView);
                ModuleControlSettings.SetGridDataView(mCustomerDataGridView);

            }
            detailControl_KeyDown(null, null);
        }

        private void SetFormToCorrection()
        {
            // splitContainer2.Panel2Collapsed = true;
            tabControl1.TabPages.Remove(tabPage2);
            splitContainer2.SplitterDistance = splitContainer2.SplitterDistance - 220;

            detailControl_KeyDown(txt_CustId, new KeyEventArgs(Keys.Enter));
            num_Quantity.Minimum = decimal.MinValue;
            numericUpDown_ItemQuantity.Minimum = decimal.MinValue;
            //lbl_Customer.Visible = false;
            //txt_CustId.Visible = false;
            //txt_CustName.Visible = false;
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
            grid_Trans.Width = 310;
            //groupBox6.Width = 221;

            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox3.Location = new Point(8, groupBox3.Location.Y);
            button1.Location = new Point(330, button1.Location.Y);
            button2.Location = new Point(330, button2.Location.Y);
            button3.Location = new Point(330, button3.Location.Y);

            groupBox5.Size = new Size(groupBox5.Size.Width - 300, groupBox5.Size.Height);
            groupBox2.Size = new Size(groupBox2.Size.Width - 300, groupBox2.Size.Height);
            groupBox4.Size = new Size(groupBox4.Size.Width - 300, groupBox4.Size.Height);
            groupBox9.Size = new Size(groupBox9.Size.Width - 320, groupBox9.Size.Height);
            this.Width = this.Width - 300;
            this.Height = this.Height - 70;

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
            field[2] = ModuleControlSettings.NumericFormat(num_Quantity.Value.ToString());
            field[3] = ModuleControlSettings.NumericFormat(num_Price.Value.ToString());
            field[4] = ModuleControlSettings.NumericFormat(num_Jumlah.Value.ToString());
            field[5] = ModuleControlSettings.NumericFormat(num_Disc.Value.ToString());
            field[6] = ModuleControlSettings.NumericFormat(num_Total.Value.ToString());

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

            ResetTransactionDetail();
        }

        private void ResetTransactionDetail()
        {
            txt_ItemId.ResetText();
            txt_ItemName.ResetText();
            num_Quantity.Value = 0;
            numericUpDown_ItemQuantity.Value = 1;
            num_Price.Value = 0;
            num_Jumlah.Value = 0;
            num_Disc.Value = 0;
            num_Total.Value = 0;

            txt_ItemId.Focus();
            txt_ItemId.Select();
        }

        private void SumGrandTotal(object sender, EventArgs e)
        {
            //try
            //{
            decimal st = Convert.ToDecimal(txt_SubTotal.Text);
            decimal gt = st * ((100 + num_PPN.Value) / 100);
            num_GrandTotal.Value = gt;
            //}
            //catch (Exception)
            //{
            //    //throw;
            //}
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
                        DialogResult res = MessageBox.Show("Cetak faktur?", "Konfirmasi cetak faktur", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (res == DialogResult.Yes)
                            PrintFactur();
                        else if (res == DialogResult.No)
                            SaveTransactionInterface();
                    }
                }
                else
                {
                    DialogResult res = MessageBox.Show("Cetak faktur?", "Konfirmasi cetak faktur", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)
                        PrintFactur();
                    else if (res == DialogResult.No)
                        SaveTransactionInterface();
                }
            }
            else
                SaveTransactionInterface();
        }

        private void SaveTransactionInterface()
        {
            SaveTransaction();
            SaveTransactionDetail();

            if (IsBindGridView)
            {
                ResetTransaction();
                ResetTransactionDetail();
            }

            if (this.TransactionHasSaved != null)
                this.TransactionHasSaved(this, null);
        }

        private FormPrintStatus f_Stat;
        private void PrintFactur()
        {

            //CustomPrint.AddCustomPaperSizeToDefaultPrinter("FacturPaper", AppCode.PaperWidth, AppCode.PaperHeight);
            ////printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(96, 48, 48, 48);
            printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(AppCode.MarginLeft, AppCode.MarginRight, AppCode.MarginTop, AppCode.MarginBottom);
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
            f_Stat.Show(this);
        }

        private void f_Stat_PrintStatusHasSelected(object sender, EventArgs e)
        {
            if (sender.Equals(ListOfPrintStatus.PrintOK))
            {
                SaveTransactionInterface();
            }
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

            if (string.IsNullOrEmpty(txt_CustId.Text))
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

            if (num_Back.Value < 0)
            {
                if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()))
                {
                    balloonHelp.Content = "Total yang harus dibayar lebih kecil dari pembayaran !!";
                    balloonHelp.ShowBalloon(num_Pay);
                    num_Pay.Focus();
                    return false;
                }
            }

            if (grid_Trans.RowCount == 0)
            {
                balloonHelp.Content = "Transaksi tidak boleh kosong !!";
                balloonHelp.ShowBalloon(grid_Trans);
                grid_Trans.Focus();
                return false;
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
            t.TransactionPpn = num_PPN.Value;
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
                    DataMaster.Delete(t);
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
                        stok = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, grid_Trans.Rows[i].Cells[0].Value.ToString(), ItemGudangStok.ColumnNames.GudangId, 1);
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
                                saldo = Convert.ToDecimal(grid_Trans.Rows[i].Cells[2].Value);
                            else
                                saldo = Convert.ToDecimal(grid_Trans.Rows[i].Cells[2].Value) * -1; ;
                            stok.ItemStok = saldo;
                            stok.ModifiedBy = lbl_UserName.Text;
                            stok.ModifiedDate = DateTime.Now;
                            DataMaster.SavePersistence(stok);
                        }
                        krt = new TStokCard();
                        krt.ItemId = grid_Trans.Rows[i].Cells[0].Value.ToString();
                        krt.GudangId = 1;
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
                    balloonHelp.Content = "Item " + txt_ItemId.Text + " tidak ada dalam database. \n Pastikan anda menulis kode yang tepat atau \n pilih item dengan mengklik gambar disamping untuk mencari item.";
                    balloonHelp.ShowBalloon(txt_ItemId);
                    txt_ItemId.Focus();
                    return false;
                }
            }

            if (num_Quantity.Value == 0)
            {
                balloonHelp.Content = "Kuantitas tidak boleh 0 !!";
                balloonHelp.ShowBalloon(num_Quantity);
                num_Quantity.Focus();
                return false;
            }
            return true;
        }

        private void RecreateBalloon()
        {
            balloonHelp = new Balloon.NET.BalloonHelp();
            balloonHelp.Icon = Properties.Resources.warning;
            balloonHelp.CloseOnMouseClick = true;
            //balloonHelp.CloseOnDeactivate = true;
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

                    //if (!lbl_TempTransaction.Text.Equals(ListOfTransaction.Correction.ToString()))
                    //    num_Price.Value = item.ItemPriceMax;
                }
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void printDocument1_PrintPage2(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Single xPos = e.MarginBounds.Left;
            Single yPos = e.MarginBounds.Top;
            Font printFont = new Font("Arial", 9);
            Single lineHeight = printFont.GetHeight(e.Graphics) + 5;

            //Single widthPaper = 76 - e.MarginBounds.Left;
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

            printFont = new Font("Arial", 8);

            //no faktur
            xPos = e.MarginBounds.Left;
            yPos += lineHeight * 2;
            txt = "No : " + txt_Factur.Text;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            //diprint
            txt = "Di Cetak oleh : " + lbl_UserName.Text + " Tgl : " + DateTime.Now.ToString(AppCode.DateTimeFormat);
            yPos += lineHeight;
            //xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
            xPos = e.MarginBounds.Left;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);


            //tanggal
            xPos = e.MarginBounds.Left;
            yPos += lineHeight;
            txt = dt_TransactionDate.Value.ToString(AppCode.DateTimeFormat);
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //jika billiard
            if (lbl_TempDesk.Text != ListOfDesk.Cafe.ToString())
            {
                //masuk
                xPos = e.MarginBounds.Left;
                yPos += lineHeight;
                txt = "Masuk : " + DateInLabel2.Text;
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                //keluar
                //xPos += 250;
                xPos = e.MarginBounds.Left;
                yPos += lineHeight;
                //yPos += lineHeight;
                txt = "Keluar : " + DateOutLabel2.Text;
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                //durasi
                xPos = e.MarginBounds.Left;
                yPos += lineHeight;
                //xPos += 250;
                //yPos += lineHeight;
                txt = "Durasi : " + DurationLabel2.Text;
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            }

            yPos += lineHeight;

            ////header
            ////garis
            //yPos += lineHeight;
            //xPos = e.MarginBounds.Left;
            //txt = "========================================================================================================================";
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            ////nama barang
            //yPos += lineHeight;
            //xPos = e.MarginBounds.Left;
            //txt = "Nama Barang";
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            ////qty
            //xPos += 250;
            //txt = "Qty";
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            ////@ harga
            //xPos += 80;
            //txt = "Harga";
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            ////jumlah
            //txt = "Jumlah";
            //xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 100f;
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);


            ////garis
            //yPos += lineHeight;
            //xPos = e.MarginBounds.Left;
            //txt = "========================================================================================================================";
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);


            for (int i = 0; i < grid_Trans.Rows.Count; i++)
            {
                //display item code
                xPos = e.MarginBounds.Left;
                yPos += lineHeight;
                txt = grid_Trans.Rows[i].Cells[1].Value.ToString();
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                ////display nama item
                //xPos += 100;
                //txt = grid_Trans.Rows[i].Cells[1].Value.ToString();
                //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                //if (Convert.ToDecimal(grid_Trans.Rows[i].Cells[2].Value) != 1)
                //{
                //qty +@ harga
                //xPos += 250;
                xPos = e.MarginBounds.Left;
                yPos += lineHeight;
                txt = ModuleControlSettings.NumericFormat(grid_Trans.Rows[i].Cells[2].Value) + " x @" + ModuleControlSettings.NumericFormat(grid_Trans.Rows[i].Cells[3].Value);
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
                ////@ harga
                //xPos += 80;
                //txt = ModuleControlSettings.NumericFormat(grid_Trans.Rows[i].Cells[3].Value);
                //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
                //jumlah
                txt = ModuleControlSettings.NumericFormat(grid_Trans.Rows[i].Cells[4].Value, true);
                xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 10f;
                //xPos = e.MarginBounds.Left + 50f;
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
                //}

                ////display total
                //txt = ModuleControlSettings.NumericFormat(grid_Trans.Rows[i].Cells[4].Value, true);
                //xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
                //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            }

            ////garis
            //yPos += lineHeight;
            //xPos = e.MarginBounds.Left;
            //txt = "========================================================================================================================";
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            float w = 30f;
            float num = 10f;
            //display ppn
            xPos = e.MarginBounds.Left + w;
            yPos += lineHeight;
            txt = "Services :  ";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            txt = ModuleControlSettings.NumericFormat(num_PPN.Value, false) + " %";
            xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - num;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //display grantotal
            xPos = e.MarginBounds.Left + w;
            yPos += lineHeight;
            txt = "Total :  ";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            txt = ModuleControlSettings.NumericFormat(num_GrandTotal.Value, true);
            xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - num;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //display dibayar
            xPos = e.MarginBounds.Left + w;
            yPos += lineHeight;
            txt = "Tunai :  ";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            txt = ModuleControlSettings.NumericFormat(num_Pay.Value, true);
            xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - num;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);


            //garis
            yPos += lineHeight;
            txt = "---------------------------------------";
            xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - num;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //display kembali
            xPos = e.MarginBounds.Left + w;
            yPos += lineHeight;
            txt = "Kembali :  ";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            txt = ModuleControlSettings.NumericFormat(num_Back.Value, true);
            xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - num;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

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
        }

        private void mItemDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mItemDataGridView.RowCount == 0)
                return;

            txt_ItemId.Text = mItemDataGridView.CurrentRow.Cells[0].Value.ToString();
            txt_ItemId_Validating(null, null);
            num_Quantity.Value = numericUpDown_ItemQuantity.Value;
        }

        private void combo_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            mItemBindingSource.Clear();
            IList listItem = null;

            if (combo_Group.SelectedIndex > 0)
            {
                listItem = DataMaster.GetListEq(typeof(MItem), MItem.ColumnNames.GroupId, Convert.ToInt32(combo_Group.SelectedValue.ToString()));
            }
            else if (combo_Group.SelectedIndex == 0)
                listItem = DataMaster.GetAll(typeof(MItem));

            mItemBindingSource.DataSource = listItem;
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
                txt_Factur.Focus();
                txt_Factur.Select();
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
                    txt_CustId.Focus();
                else if (sender == txt_CustId)
                    txt_ItemId.Focus();
                else if (sender == txt_ItemId)
                    num_Quantity.Focus();
                else if (sender == num_Quantity)
                    if (num_Price.Enabled)
                        num_Price.Focus();
                    else
                        num_Disc.Focus();
                else if (sender == num_Price)
                    num_Disc.Focus();
                else if (sender == num_Disc)
                {
                    button1.PerformClick();
                    txt_ItemId.Focus();
                }
                else
                    txt_Factur.Select();
            }
        }

        private void mCustomerDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mCustomerDataGridView.RowCount == 0)
                return;

            txt_CustId.Text = mCustomerDataGridView.CurrentRow.Cells[0].Value.ToString();
            txt_CustId_Validating(null, null);
        }

        private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }
    }
}