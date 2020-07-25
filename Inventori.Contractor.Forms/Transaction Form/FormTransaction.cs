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
using System.Threading;

namespace Inventori.Contractor.Forms
{
    public partial class FormTransaction : FormParentForContractor
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private Balloon.NET.BalloonHelp balloonHelp;
        public event EventHandler TransactionHasSaved;
        ListOfTransaction trans;
        public bool isTransInEdit = false;
        public FormTransaction(ListOfTransaction tr)
        {
            InitializeComponent();
            trans = tr;
            this.Icon = Properties.Resources.sales1;
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
        }

        public void SetInitialSettings()
        {
            ResetTransaction();
            if (trans.Equals(ListOfTransaction.Purchase))
                ModuleControlSettings.SetNumericUpDown(num_Price);
            else
                ModuleControlSettings.SetNumericUpDown(num_Price, true);

            txt_Factur.Text = AppCode.GenerateFacturNo(trans, lbl_TempDesk.Text);
        }

        private void FormTransaction_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, trans.ToString(), ListOfTable.TTransaction, lbl_UserName.Text);
            //set numeric updown

            ModuleControlSettings.SetNumericUpDown(num_Quantity);
            ModuleControlSettings.SetNumericUpDown(num_Jumlah, true);
            ModuleControlSettings.SetNumericUpDown(num_Disc);
            ModuleControlSettings.SetNumericUpDown(num_Total, true);
            ModuleControlSettings.SetNumericUpDown(num_PPN);
            ModuleControlSettings.SetNumericUpDown(num_GrandTotal, true);
            ModuleControlSettings.SetNumericUpDown(num_GrandTotal2, true);
            ModuleControlSettings.SetNumericUpDown(num_Cash);
            ModuleControlSettings.SetNumericUpDown(num_Credit, true);


            for (int i = 0; i < 9; i++)
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
            grid_Trans.Columns[8].Visible = false;

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

            //ModuleControlSettings.SetItemTextBoxSuggest(txt_ItemId);

            if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.ReturSales) || trans.Equals(ListOfTransaction.SalesVIP) || trans.Equals(ListOfTransaction.ReturSalesVIP))
            {
                lbl_Customer.Text = "Pelanggan :";
                ModuleControlSettings.SetCustomerTextBoxSuggest(txt_CustId);
            }
            else if (trans.Equals(ListOfTransaction.Usage) || trans.Equals(ListOfTransaction.Correction))
            {
                lbl_Customer.Text = "Pelapor :";
                ModuleControlSettings.SetEmployeeTextBoxSuggest(txt_CustId);
            }
            else if (trans.Equals(ListOfTransaction.PurchaseOrder) || trans.Equals(ListOfTransaction.Purchase) || trans.Equals(ListOfTransaction.ReturPurchase))
            {
                lbl_Customer.Text = "Supplier :";
                ModuleControlSettings.SetSupplierTextBoxSuggest(txt_CustId);
            }

            if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.ReturSales) || trans.Equals(ListOfTransaction.SalesVIP) || trans.Equals(ListOfTransaction.ReturSalesVIP))
            {
                if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.SalesVIP))
                {
                    ModuleControlSettings.SetNumericUpDown(num_Price, true);
                }
            }
            //else if (trans.Equals(ListOfTransaction.Correction))
            //    SetFormToCorrection();
            if (trans.Equals(ListOfTransaction.PurchaseOrder) || trans.Equals(ListOfTransaction.Usage) || trans.Equals(ListOfTransaction.Correction))
            {
                SetFormToWithOutPriceDisplay();
            }

            PictureBox searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(txt_CustId, ListOfSearchWindow.SearchCustomer.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicCustomer_Click);
            txt_CustId.Controls.Add(searchPic);

            searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(txt_ItemId, ListOfSearchWindow.SearchItem.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicItem_Click);
            txt_ItemId.Controls.Add(searchPic);

            string j = "";

            if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.SalesVIP))
                j = "Penjualan";
            else if (trans.Equals(ListOfTransaction.ReturSales) || trans.Equals(ListOfTransaction.ReturSalesVIP))
                j = "Retur Penjualan";
            else if (trans.Equals(ListOfTransaction.Purchase))
                j = "Pembelian";
            else if (trans.Equals(ListOfTransaction.ReturPurchase))
                j = "Retur Pembelian";
            else if (trans.Equals(ListOfTransaction.Correction))
                j = "Penyesuaian";
            else if (trans.Equals(ListOfTransaction.PurchaseOrder))
                j = "Order Pembelian";
            else if (trans.Equals(ListOfTransaction.Usage))
                j = "Pemakaian Spare Parts";

            this.TabText = j;
            this.Text = j;

            AppCode.SetCurrencyStatusComboBox(currencyIdComboBox);
            currencyIdComboBox.Visible = false;

            if ((trans == ListOfTransaction.PurchaseOrder) || (trans == ListOfTransaction.ReturPurchase))
            {
                currencyIdComboBox.Visible = true;
                currencyIdLabel.Visible = true;

                ModuleControlSettings.SetGudangComboBox(combo_Gudang);
                lbl_Gudang.Visible = true;
                combo_Gudang.Visible = true;
            }

            if (trans.Equals(ListOfTransaction.Purchase))
            {
                lbl_OrderNo.Visible = true;
                txt_OrderNo.Visible = true;
                lbl_Garing.Visible = true;
                txt_OrderId.Visible = true;
                currencyIdComboBox.Visible = true;
                currencyIdLabel.Visible = true;


                ModuleControlSettings.SetGudangComboBox(combo_Gudang);
                lbl_Gudang.Visible = true;
                combo_Gudang.Visible = true;

                searchPic = new PictureBox();
                ModuleControlSettings.SetSearchPictureBox(txt_OrderNo, ListOfSearchWindow.SearchTransaction.ToString(), searchPic);
                searchPic.Click += new EventHandler(searchPicOrderNo_Click);
                txt_OrderNo.Controls.Add(searchPic);

                btn_Edit.Visible = true;
                //button1.Visible = false;

                //txt_ItemId.Enabled = false;
                //txt_ItemName.Enabled = false;

                grid_Trans.ContextMenuStrip = contextMenuStrip_TransGrid;
            }

            detailControl_KeyDown(null, null);
        }

        FormSearchTransaction f_SearchTrans;
        private void searchPicOrderNo_Click(object sender, EventArgs e)
        {
            f_SearchTrans = new FormSearchTransaction(ListOfTransaction.PurchaseOrder);
            f_SearchTrans.TransactionHasSelected += new EventHandler(f_SearchTrans_TransactionHasSelected);
            f_SearchTrans.ShowDialog(this);
        }

        private void f_SearchTrans_TransactionHasSelected(object sender, EventArgs e)
        {
            if (f_SearchTrans.grid_Search.Rows.Count > 0)
            {
                //txt_OrderId.Text = f_SearchTrans.grid_Search.CurrentRow.Cells[0].Value.ToString();
                txt_OrderNo.Text = f_SearchTrans.grid_Search.CurrentRow.Cells[1].Value.ToString();
                txt_OrderNo_Validating(null, null);
            }
        }

        private void SetFormToWithOutPriceDisplay()
        {
            if (!trans.Equals(ListOfTransaction.PurchaseOrder))
            {
                ModuleControlSettings.SetGudangComboBox(combo_Gudang);
                lbl_Gudang.Visible = true;
                combo_Gudang.Visible = true;
            }

            if (trans.Equals(ListOfTransaction.Correction))
            {
                num_Quantity.Minimum = -999999999999999999;

                //display balon petunjuk
                RecreateBalloon();
                balloonHelp.Caption = "Petunjuk Pengisian Data Kuantitas Item";
                balloonHelp.Content = "Jika jumlah item \"kurang\", maka kuantitas item diisi dengan tanda minus (misalnya : \"-8\" ) \n dan apabila jumlah item \"berlebih\", maka kuantitas item diisi tanpa tanda (misalnya : \"9\" )";
                balloonHelp.ShowBalloon(num_Quantity);
            }

            grid_Trans.Columns[3].Visible = false;
            grid_Trans.Columns[4].Visible = false;
            grid_Trans.Columns[5].Visible = false;
            grid_Trans.Columns[6].Visible = false;
            grid_Trans.Columns[7].Width = txt_Desc.Width;
            grid_Trans.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            txt_Desc.Visible = true;
            lbl_Price.Text = "Keterangan";
            lbl_Price.Width = txt_Desc.Width;

            //detailControl_KeyDown(txt_CustId, new KeyEventArgs(Keys.Enter));
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

            groupBox7.Visible = false;
        }

        //private void SetFormToCorrection()
        //{

        //    splitContainer2.SplitterDistance = splitContainer2.SplitterDistance - 220;

        //    detailControl_KeyDown(txt_CustId, new KeyEventArgs(Keys.Enter));
        //    num_Quantity.Minimum = -99999999;
        //    lbl_Price.Visible = false;
        //    num_Price.Visible = false;
        //    txt_SubPrice.Visible = false;
        //    lbl_Jumlah.Visible = false;
        //    num_Jumlah.Visible = false;
        //    txt_SubJumlah.Visible = false;
        //    lbl_Disc.Visible = false;
        //    num_Disc.Visible = false;
        //    txt_SubDisc.Visible = false;
        //    lbl_Total.Visible = false;
        //    num_Total.Visible = false;
        //    txt_SubTotal.Visible = false;
        //    grid_Trans.Width = grid_Trans.Width - 320;
        //    //groupBox6.Width = 221;

        //    groupBox6.Visible = false;
        //    groupBox7.Visible = false;
        //    groupBox3.Location = new Point(8, groupBox3.Location.Y);
        //    button1.Location = new Point(button1.Location.X - 320, button1.Location.Y);
        //    button2.Location = new Point(button2.Location.X - 320, button2.Location.Y);
        //    button3.Location = new Point(button3.Location.X - 320, button3.Location.Y);

        //    groupBox5.Size = new Size(groupBox5.Size.Width - 300, groupBox5.Size.Height);
        //    groupBox2.Size = new Size(groupBox2.Size.Width - 300, groupBox2.Size.Height);
        //    groupBox4.Size = new Size(groupBox4.Size.Width - 300, groupBox4.Size.Height);
        //    groupBox9.Size = new Size(groupBox9.Size.Width - 320, groupBox9.Size.Height);
        //    this.Width = this.Width - 300;
        //    this.Height = this.Height - 70;

        //    lbl_ShopName.Location = new Point(lbl_ShopName.Location.X - 150, lbl_ShopName.Location.Y);
        //    lbl_ShopAddress.Location = new Point(lbl_ShopAddress.Location.X - 150, lbl_ShopAddress.Location.Y);
        //    lbl_ShopTelp.Location = new Point(lbl_ShopTelp.Location.X - 150, lbl_ShopTelp.Location.Y);

        //    //display balon petunjuk
        //    RecreateBalloon();
        //    balloonHelp.Caption = "Petunjuk Pengisian Data Kuantitas Item";
        //    balloonHelp.Content = "Jika jumlah item \"kurang\", maka kuantitas item diisi dengan tanda minus (misalnya : \"-8\" ) \n dan apabila jumlah item \"berlebih\", maka kuantitas item diisi tanpa tanda (misalnya : \"9\" )";
        //    balloonHelp.ShowBalloon(num_Quantity);
        //}

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

            //fill suggest textbox
            //if (txt_ItemId.AutoCompleteCustomSource.Count == 0)
            //{
            //    ModuleControlSettings.SetItemTextBoxSuggest(txt_ItemId);
            //}
            //if (!bgw_Main.IsBusy)
            //    bgw_Main.RunWorkerAsync();
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
            f_SearchItem.lbl_TempTransaction.Text = trans.ToString();
            f_SearchItem.ShowInTaskbar = false;
            f_SearchItem.ShowDialog();
        }

        private void searchPicCustomer_Click(object sender, EventArgs e)
        {
            if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.ReturSales) || trans.Equals(ListOfTransaction.SalesVIP) || trans.Equals(ListOfTransaction.ReturSalesVIP))
                OpenFormSearchCustomer();
            else if (trans.Equals(ListOfTransaction.Usage) || trans.Equals(ListOfTransaction.Correction))
                OpenFormSearchEmployee();
            else if (trans.Equals(ListOfTransaction.PurchaseOrder) || trans.Equals(ListOfTransaction.Purchase) || trans.Equals(ListOfTransaction.ReturPurchase))
                OpenFormSearchSupplier();
        }

        FormSearchEmployee f_SearchEmployee;
        private void OpenFormSearchEmployee()
        {
            if (f_SearchEmployee != null)
            {
                if (!f_SearchEmployee.IsDisposed)
                {
                    f_SearchEmployee.WindowState = FormWindowState.Normal;
                    f_SearchEmployee.BringToFront();
                }
                else
                    f_SearchEmployee = new FormSearchEmployee();
            }
            else
                f_SearchEmployee = new FormSearchEmployee();

            f_SearchEmployee.EmployeeHasSelected += new EventHandler(f_SearchEmployee_EmployeeHasSelected);
            f_SearchEmployee.ShowDialog(this);
        }

        private void f_SearchEmployee_EmployeeHasSelected(object sender, EventArgs e)
        {
            if (f_SearchEmployee.grid_Search.Rows.Count > 0)
            {
                txt_CustId.Text = f_SearchEmployee.grid_Search.CurrentRow.Cells[0].Value.ToString();
                txt_CustId_Validating(null, null);
            }
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

            string[] field = new string[8];
            field[0] = txt_ItemId.Text;
            field[1] = txt_ItemName.Text;
            field[2] = ModuleControlSettings.NumericFormat(num_Quantity.Value);
            field[3] = ModuleControlSettings.NumericFormat(num_Price.Value);
            field[4] = ModuleControlSettings.NumericFormat(num_Jumlah.Value);
            field[5] = ModuleControlSettings.NumericFormat(num_Disc.Value);
            field[6] = ModuleControlSettings.NumericFormat(num_Total.Value);
            field[7] = txt_Desc.Text;

            grid_Trans.Rows.Insert(0, field);
            ResetTransactionDetail();


            btn_Edit.Text = "&Ubah";
            ubahDetailTransaksiToolStripMenuItem.Text = "Ubah Detail Transaksi";
            isInEdit = false;

            txt_ItemId.Select();
            txt_ItemId.Focus();

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

                    ResetTransactionDetail();
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
        }

        private void ResetTransactionDetail()
        {
            txt_ItemId.ResetText();
            txt_ItemName.ResetText();
            txt_Desc.ResetText();
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
                decimal gt = st * ((100 + num_PPN.Value) / 100);
                num_GrandTotal.Value = gt;

                num_GrandTotal2.Value = gt;
                num_Credit.Value = gt;
                //if (gt <= 1000000)
                //    num_Cash.Value = gt;
                //else
                //{
                //    num_Cash.Value = 0;
                //    num_Cash.ResetText();
                //}
            }
            catch (Exception)
            {
                //throw;
            }
        }

        MSetting set;
        private void button3_Click(object sender, EventArgs e)
        {
            if (trans.Equals(ListOfTransaction.Purchase))
            {
                gb_Payment.Visible = true;
                num_Cash.Select();
                num_Cash.Focus();
            }
            else
                btn_PaymentOK_Click(null, null);
        }

        private void SaveTransactionInterface()
        {
            if (isTransInEdit)
            {
                DeleteTransactionDetail(Convert.ToDecimal(txt_TransactionId.Text));
            }
            SaveTransaction();
            SaveTransactionDetail();
            ModuleControlSettings.SaveLog(ListOfAction.Insert, trans.ToString() + ";" + txt_Factur.Text, ListOfTable.TTransaction, lbl_UserName.Text);
            if (trans.Equals(ListOfTransaction.PurchaseOrder))
            {
                FormViewReport f_Report = new FormViewReport(ListOfReports.ReportPODetailForPrint);
                f_Report.DataId = txt_TransactionId.Text;
                f_Report.Show(this);
            }

            ResetTransaction();
            ResetTransactionDetail();

            if (this.TransactionHasSaved != null)
                this.TransactionHasSaved(this, null);
        }

        private void DeleteTransactionDetail(decimal TransactionId)
        {
            bool AddStok;
            if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.ReturPurchase) || trans.Equals(ListOfTransaction.SalesVIP) || trans.Equals(ListOfTransaction.Usage))
                AddStok = true;
            else
                AddStok = false;

            TTransaction t = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, Convert.ToDecimal(txt_TransactionId.Text));
            int gudangId = 1;
            if (t != null)
                gudangId = t.GudangId;

            IList listDet = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, TransactionId);
            TTransactionDetail det;
            for (int i = 0; i < listDet.Count; i++)
            {
                det = (TTransactionDetail)listDet[i];

                if (!trans.Equals(ListOfTransaction.PurchaseOrder))
                {
                    UpdateStok(det.ItemId, gudangId, det.Quantity, AddStok);
                }
                DataMaster.Delete(det);
            }
        }

        private FormPrintStatus f_Stat;
        private void PrintFactur()
        {
            //CustomPrint.AddCustomPaperSizeToDefaultPrinter("FacturPaper", 122, 140);
            printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(30, 30, 30, 30);
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
            if (trans.Equals(ListOfTransaction.Correction))
                return true;

            //RecreateBalloon(this, EventArgs.Empty);
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(txt_Factur.Text.Trim()))
            {
                balloonHelp.Content = "Nomor faktur harus diisi";
                balloonHelp.ShowBalloon(txt_Factur);
                txt_Factur.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txt_CustId.Text))
            {
                string errMsg = "";
                if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.ReturSales) || trans.Equals(ListOfTransaction.SalesVIP) || trans.Equals(ListOfTransaction.ReturSalesVIP))
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

            if (combo_Gudang.Visible)
            {
                if (combo_Gudang.SelectedIndex == -1)
                {
                    balloonHelp.Content = "Pilih gudang !";
                    balloonHelp.ShowBalloon(combo_Gudang);
                    combo_Gudang.Focus();
                    return false;
                }
            }

            if (currencyIdComboBox.Visible)
            {
                if (currencyIdComboBox.SelectedIndex == -1)
                {
                    balloonHelp.Content = "Pilih mata uang !";
                    balloonHelp.ShowBalloon(currencyIdComboBox);
                    currencyIdComboBox.Focus();
                    return false;
                }
            }

            if (currencyIdComboBox.Visible)
            {
                if (currencyIdComboBox.SelectedIndex == -1)
                {
                    balloonHelp.Content = "Pilih mata uang !";
                    balloonHelp.ShowBalloon(currencyIdComboBox);
                    currencyIdComboBox.Focus();
                    return false;
                }
            }

            if (grid_Trans.RowCount == 0)
            {
                MessageBox.Show("Transaksi yang kosong tidak bisa diproses.", "Transaksi tidak bisa diproses.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ItemId.Select();
                txt_ItemId.Focus();
                return false;
            }

            //if (!string.IsNullOrEmpty(txt_Factur.Text.Trim()))
            //{
            //    TTransaction tr = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionFactur, txt_Factur.Text.Trim());
            //    if (tr != null)
            //    {
            //        balloonHelp.Content = "Nomor faktur " + txt_Factur.Text + " sudah pernah diinput, silahkan input nomor faktur yang lain.";
            //        balloonHelp.ShowBalloon(txt_Factur);
            //        txt_Factur.Focus();
            //        return false;
            //    }
            //}
            return true;
        }

        private void SaveTransaction()
        {
            TTransaction t = new TTransaction();
            bool isSave = true;
            if (isTransInEdit)
            {
                t = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, Convert.ToDecimal(txt_TransactionId.Text));
                if (t == null)
                {
                    t = new TTransaction();
                    isSave = true;
                }
                else
                    isSave = false;
            }
            t.TransactionBy = txt_CustId.Text;
            t.TransactionDate = dt_TransactionDate.Value;
            t.TransactionDisc = 0;
            t.TransactionFactur = txt_Factur.Text;
            t.TransactionGrandTotal = num_GrandTotal.Value;
            t.TransactionId = Convert.ToDecimal(txt_TransactionId.Text);
            if (!isSave)
            {
                t.TransactionPaid = t.TransactionPaid + num_Cash.Value;
                t.TransactionSisa = t.TransactionGrandTotal - t.TransactionPaid;
            }
            else
            {
                t.TransactionPaid = num_Cash.Value;
                t.TransactionSisa = num_Credit.Value;

            }
            t.TransactionPpn = num_PPN.Value;
            t.TransactionStatus = trans.ToString();
            t.TransactionSubTotal = Convert.ToDecimal(txt_SubTotal.Text);

            if (combo_Gudang.SelectedIndex != -1)
                t.GudangId = Convert.ToInt32(combo_Gudang.SelectedValue);

            t.EmployeeId = lbl_EmployeeId.Text;

            if (!string.IsNullOrEmpty(txt_OrderId.Text.Trim()))
                t.TransactionReferenceId = Convert.ToDecimal(txt_OrderId.Text);
            else
                t.TransactionReferenceId = 0;

            if (currencyIdComboBox.SelectedIndex != -1)
                t.CurrencyId = currencyIdComboBox.SelectedItem.ToString();

            t.ModifiedBy = lbl_UserName.Text;
            t.ModifiedDate = DateTime.Now;

            if (isSave)
                DataMaster.SavePersistence(t);
            else
                DataMaster.UpdatePersistence(t);
        }

        private void SaveTransactionDetail()
        {
            TTransactionDetail det;
            ItemGudangStok stok;
            MItem item;
            TStokCard krt;

            int gudangId = 0;
            if (combo_Gudang.SelectedIndex != -1)
                gudangId = Convert.ToInt32(combo_Gudang.SelectedValue.ToString());

            bool AddStok = true;
            decimal saldo = 0;

            if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.ReturPurchase) || trans.Equals(ListOfTransaction.SalesVIP) || trans.Equals(ListOfTransaction.Usage))
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
                if (trans.Equals(ListOfTransaction.Correction) || trans.Equals(ListOfTransaction.PurchaseOrder) || trans.Equals(ListOfTransaction.Usage))
                    det.Total = Convert.ToDecimal(grid_Trans.Rows[i].Cells[2].Value);
                else
                    det.Total = Convert.ToDecimal(grid_Trans.Rows[i].Cells[6].Value);

                det.TransactionId = Convert.ToDecimal(txt_TransactionId.Text);
                det.Jumlah = Convert.ToDecimal(grid_Trans.Rows[i].Cells[4].Value);
                det.Description = grid_Trans.Rows[i].Cells[7].Value.ToString();
                det.ModifiedBy = lbl_UserName.Text;
                det.ModifiedDate = DateTime.Now;
                DataMaster.SavePersistence(det);

                if (!trans.Equals(ListOfTransaction.PurchaseOrder))
                {
                    UpdateStok(grid_Trans.Rows[i].Cells[0].Value.ToString(), gudangId, Convert.ToDecimal(grid_Trans.Rows[i].Cells[2].Value), AddStok);
                }
            }

        }

        void UpdateStok(string itemId, int gudangId, decimal qty, bool isAddStok)
        {
            MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemId);
            ItemGudangStok stok;
            decimal saldo = 0;
            if (item != null)
            {
                //if item == barang
                if (item.ItemTypeId == 1)
                {
                    //change stok
                    stok = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, itemId, ItemGudangStok.ColumnNames.GudangId, gudangId);
                    if (stok != null)
                    {
                        if (isAddStok)
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
                        stok.ItemMaxStok = 0;
                        stok.ItemMinStok = 0;
                        if (isAddStok)
                            stok.ItemStok = qty;
                        else
                            stok.ItemStok = qty * -1;
                        stok.ModifiedBy = lbl_UserName.Text;
                        stok.ModifiedDate = DateTime.Now;
                        DataMaster.SavePersistence(stok);
                    }

                }
            }

            TStokCard krt = new TStokCard();
            krt.ItemId = itemId;
            krt.GudangId = gudangId;
            krt.StokCardDate = DateTime.Now;
            krt.StokCardPic = lbl_UserName.Text;
            krt.StokCardQuantity = qty;
            krt.StokCardSaldo = saldo;
            krt.StokCardStatus = isAddStok;
            krt.TransactionId = Convert.ToDecimal(txt_TransactionId.Text);
            krt.ModifiedBy = lbl_UserName.Text;
            krt.ModifiedDate = DateTime.Now;
            DataMaster.SavePersistence(krt);
        }

        private void ResetTransaction()
        {
            gb_Payment.Visible = false;
            txt_Factur.Text = AppCode.GenerateFacturNo(trans, lbl_TempDesk.Text);
            combo_Gudang.SelectedIndex = -1;

            txt_OrderId.ResetText();
            txt_OrderNo.ResetText();

            txt_CustId.ResetText();
            txt_CustName.ResetText();

            txt_TransactionId.Text = DateTime.Now.ToFileTimeUtc().ToString();

            num_PPN.Value = 0;

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
            else if (txt_Desc.Visible)
            {
                if (string.IsNullOrEmpty(txt_Desc.Text.Trim()))
                {
                    balloonHelp.Content = "Keterangan harus diisi";
                    balloonHelp.ShowBalloon(txt_Desc);
                    txt_Desc.Focus();
                    return false;
                }
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
                else if ((trans == ListOfTransaction.PurchaseOrder || trans == ListOfTransaction.Purchase) && item.ItemTypeId == 1)
                {
                    if (num_Quantity.Value > item.ItemPriceMax)
                    {
                        balloonHelp.Caption = "Validasi data kurang";
                        balloonHelp.Content = "Kuantitas item melebihi batas order atau pembelian yang diijinkan. Batas pembelian yang diijinkan adalah " + item.ItemPriceMax.ToString();
                        balloonHelp.ShowBalloon(num_Quantity);
                        num_Quantity.Focus();
                        return false;
                    }
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
            balloonHelp.CloseOnMouseMove = false;
            balloonHelp.CloseOnKeyPress = false;
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

                    if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.ReturSales))
                        num_Price.Value = item.ItemPriceMax;
                    else if (trans.Equals(ListOfTransaction.SalesVIP) || trans.Equals(ListOfTransaction.ReturSalesVIP))
                        num_Price.Value = item.ItemPriceMaxVip;
                    else if (trans.Equals(ListOfTransaction.Purchase) || trans.Equals(ListOfTransaction.ReturPurchase))
                        num_Price.Value = item.ItemPricePurchase;

                    //if (!trans.Equals(ListOfTransaction.Correction))
                    //    num_Price.Value = item.ItemPriceMax;
                }
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            switch (trans)
            {
                case ListOfTransaction.Correction:
                    break;
                case ListOfTransaction.Purchase:
                    break;
                case ListOfTransaction.PurchaseOrder:
                    printFacturForPurchaseOrder(e);
                    break;
                case ListOfTransaction.ReturPurchase:
                    break;
                case ListOfTransaction.ReturSales:
                    break;
                case ListOfTransaction.ReturSalesVIP:
                    break;
                case ListOfTransaction.Sales:
                    printFacturForSales(e);
                    break;
                case ListOfTransaction.SalesVIP:
                    printFacturForSales(e);
                    break;
                case ListOfTransaction.Usage:
                    break;
                default:
                    break;
            }
        }

        private void printFacturForSales(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Single xPos = e.MarginBounds.Left;
            Single yPos = e.MarginBounds.Top;
            Font printFont = new Font("MS Sans Serif", 10);
            Single lineHeight = printFont.GetHeight(e.Graphics) + 5;

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

            xPos = e.MarginBounds.Left;
            yPos += lineHeight * 2;
            txt = "No : " + txt_Factur.Text;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            xPos = e.MarginBounds.Left;
            yPos += lineHeight;
            txt = dt_TransactionDate.Value.ToShortDateString() + "         " + dt_TransactionDate.Value.ToShortTimeString();
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            yPos += lineHeight;
            for (int i = 0; i < grid_Trans.Rows.Count; i++)
            {
                //display nama item
                //xPos += 100;
                xPos = e.MarginBounds.Left;
                yPos += lineHeight;
                txt = grid_Trans.Rows[i].Cells[1].Value.ToString();
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

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
                txt = ModuleControlSettings.NumericFormat(grid_Trans.Rows[i].Cells[6].Value, true);
                xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;

                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            }

            //display grantotal
            xPos = e.MarginBounds.Left + 50;
            yPos += lineHeight;
            txt = "Total :  ";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            txt = ModuleControlSettings.NumericFormat(num_GrandTotal.Value, true);
            xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //display dibayar
            xPos = e.MarginBounds.Left + 50;
            yPos += lineHeight;
            txt = "Tunai :  ";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //display kembali
            xPos = e.MarginBounds.Left + 50;
            yPos += lineHeight;
            txt = "Kembali :  ";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //thanks
            txt = "Terima Kasih atas kunjungan anda";
            yPos += lineHeight * 2;
            xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
        }

        private void printFacturForPurchaseOrder(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Single xPos = e.MarginBounds.Left;
            Single yPos = e.MarginBounds.Top;
            Font printFont = new Font("MS Sans Serif", 10);
            Single lineHeight = printFont.GetHeight(e.Graphics) + 5;

            Single widthPaper = e.PageSettings.PaperSize.Width - e.MarginBounds.Left;
            string txt = "";

            txt = set.CompanyName;
            xPos = e.MarginBounds.Left;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);


            txt = "PURCHASE ORDER";
            //yPos += lineHeight;
            xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //no PO
            xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
            yPos += lineHeight;
            txt = "PO Number : " + txt_Factur.Text;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //kepada
            xPos = e.MarginBounds.Left;
            yPos += lineHeight * 2;
            txt = "Kepada     :   " + txt_CustName.Text;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //tanggal
            xPos = e.MarginBounds.Left;
            yPos += lineHeight;
            txt = "Tanggal     :   " + dt_TransactionDate.Value.ToString("D");
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //design table
            // No  |  Nama Barang  |  Jumlah  | Keterangan
            //No
            xPos = e.MarginBounds.Left;
            yPos += lineHeight * 2;
            txt = "No";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            //Nama Barang
            xPos += 80;
            txt = "Nama Barang";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            //Jumlah
            xPos += 200;
            txt = "Jumlah";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            //Keterangan
            xPos += 150;
            txt = "Keterangan";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //yPos += lineHeight;
            for (int i = 0; i < grid_Trans.Rows.Count; i++)
            {
                //No
                xPos = e.MarginBounds.Left;
                yPos += lineHeight;
                txt = (i + 1).ToString() + ".";
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
                //Nama Barang
                xPos += 30;
                txt = grid_Trans.Rows[i].Cells[1].Value.ToString();
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
                //Jumlah
                xPos += 250;
                txt = ModuleControlSettings.NumericFormat(grid_Trans.Rows[i].Cells[2].Value);
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
                //Keterangan
                xPos += 100;
                txt = grid_Trans.Rows[i].Cells[7].Value.ToString();
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            }

            //thanks
            txt = "Diketahui :";
            yPos += lineHeight * 2;
            xPos = e.MarginBounds.Left + 100;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
        }

        private void txt_CustId_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_CustId.Text.Trim()))
            {
                if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.ReturSales) || trans.Equals(ListOfTransaction.SalesVIP) || trans.Equals(ListOfTransaction.ReturSalesVIP))
                {
                    MCustomer cust = (MCustomer)DataMaster.GetObjectByProperty(typeof(MCustomer), MCustomer.ColumnNames.CustomerId, txt_CustId.Text);
                    if (cust != null)
                        txt_CustName.Text = cust.CustomerName;
                    else
                        txt_CustName.ResetText();
                }
                else if (trans.Equals(ListOfTransaction.Usage) || trans.Equals(ListOfTransaction.Correction))
                {
                    MEmployee emp = (MEmployee)DataMaster.GetObjectByProperty(typeof(MEmployee), MEmployee.ColumnNames.EmployeeId, txt_CustId.Text);
                    if (emp != null)
                        txt_CustName.Text = emp.EmployeeName;
                    else
                        txt_CustName.ResetText();
                }
                else if (trans.Equals(ListOfTransaction.PurchaseOrder) || trans.Equals(ListOfTransaction.Purchase) || trans.Equals(ListOfTransaction.ReturPurchase))
                {
                    MSupplier supp = (MSupplier)DataMaster.GetObjectByProperty(typeof(MSupplier), MSupplier.ColumnNames.SupplierId, txt_CustId.Text);
                    if (supp != null)
                    {
                        txt_CustName.Text = supp.SupplierName;


                        if (trans.Equals(ListOfTransaction.Purchase))
                        {
                            ModuleControlSettings.SetTransactionTextBoxSuggest(txt_OrderNo, ListOfTransaction.PurchaseOrder, supp.SupplierId);
                        }
                    }
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

                //if (sender == num_Pay)
                //{
                //    button3.PerformClick();
                //    return;
                //}

                if (sender == txt_Factur)
                    txt_CustId.Select();
                else if (sender == txt_CustId)
                {
                    if (combo_Gudang.Visible)
                    {
                        combo_Gudang.Select();
                        combo_Gudang.Focus();
                    }
                    else
                        txt_ItemId.Select();
                }
                else if (sender == combo_Gudang)
                {
                    if (txt_OrderNo.Visible)
                    {
                        txt_OrderNo.Select();
                        txt_OrderNo.Focus();
                    }
                    else
                        txt_ItemId.Select();
                }
                else if (sender == txt_OrderNo)
                {
                    txt_ItemId.Select();
                    txt_ItemId.Focus();
                }
                else if (sender == txt_ItemId)
                    num_Quantity.Select();
                else if (sender == num_Quantity)
                {
                    if (txt_Desc.Visible)
                    {
                        txt_Desc.Focus();
                        txt_Desc.Select();
                    }
                    else
                    {
                        if (num_Price.Enabled)
                            num_Price.Select();
                        else
                            num_Disc.Select();
                    }
                }
                else if (sender == num_Price)
                    num_Disc.Select();
                else if (sender == txt_Desc)
                {
                    button1.Select();
                    button1.Focus();
                }
                else if (sender == num_Disc)
                {
                    if (button1.Visible)
                    {
                        button1.Select();
                        button1.Focus();
                    }
                    else if (btn_Edit.Visible)
                    {
                        btn_Edit.Select();
                        btn_Edit.Focus();
                    }
                }
                else if (sender == num_PPN)
                {
                    button3.Focus();
                    button3.Select();
                }
                else if (sender == num_Cash)
                {
                    btn_PaymentOK.Focus();
                    btn_PaymentOK.Select();
                }
                else
                    txt_Factur.Select();
            }
        }

        private void txt_OrderNo_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(txt_OrderNo, ListOfSearchWindow.SearchTransaction.ToString(), true);
        }

        private void txt_OrderNo_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(txt_OrderNo, ListOfSearchWindow.SearchTransaction.ToString(), false);
        }

        private void btn_PaymentCancel_Click(object sender, EventArgs e)
        {
            gb_Payment.Visible = false;
        }

        private void btn_PaymentOK_Click(object sender, EventArgs e)
        {
            if (!ValidateFormHeader())
                return;

            if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.SalesVIP))
            {
                set = (MSetting)DataMaster.GetObjectByProperty(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
                if (set != null)
                {
                    if (set.AutoPrintSales)
                        PrintFactur();
                    else
                    {
                        DialogResult res = MessageBox.Show("Cetak faktur?", "Konfirmasi cetak faktur", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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

        private void SumPayment(object sender, EventArgs e)
        {
            //try
            //{
            num_Credit.Value = num_GrandTotal.Value - num_Cash.Value;
            //}
            //catch (Exception)
            //{
            //    num_Credit.Value = 0;
            //    num_Cash.Value = num_GrandTotal.Value;
            //}
        }

        private void txt_OrderId_TextChanged(object sender, EventArgs e)
        {
            pb_Detail.Visible = !string.IsNullOrEmpty(txt_OrderId.Text.Trim());

            RecreateBalloon();
            balloonHelp.Caption = "Detail Transaksi";
            balloonHelp.Content = "Klik disini untuk melihat detail transaksi";
            balloonHelp.ShowBalloon(pb_Detail);
        }

        FormViewReport f_Report;
        private void pb_Detail_Click(object sender, EventArgs e)
        {
            if (f_Report != null)
            {
                if (!f_Report.IsDisposed)
                    f_Report.Close();
            }
            f_Report = new FormViewReport(ListOfReports.TransactionDetail);
            f_Report.DataId = txt_OrderId.Text;
            f_Report.DesktopLocation = new Point(0, 0);
            f_Report.Height = 300;
            f_Report.Show(this);
        }

        private Thread t;
        private void txt_OrderNo_Validating(object sender, CancelEventArgs e)
        {
            TTransaction trans = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionFactur, txt_OrderNo.Text);
            if (trans != null)
            {
                txt_OrderId.Text = trans.TransactionId.ToString();
                FillTransactionDetail(trans.TransactionId, ListOfTransaction.PurchaseOrder);
            }
            else
                txt_OrderId.ResetText();

        }

        public void FillTransactionDetail(decimal TransactionId, ListOfTransaction transType)
        {
            grid_Trans.Rows.Clear();
            IList listDet = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, TransactionId);
            TTransactionDetail det;
            MItem item;
            string[] field = new string[8];
            decimal jumlah = 0;
            decimal total = 0;
            decimal disc = 0;

            for (int i = 0; i < listDet.Count; i++)
            {
                det = (TTransactionDetail)listDet[i];

                item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, det.ItemId);
                if (item == null)
                    item = new MItem();

                field = new string[9];
                field[0] = det.ItemId;
                field[1] = item.ItemName;
                field[2] = ModuleControlSettings.NumericFormat(det.Quantity);
                if (transType == ListOfTransaction.PurchaseOrder)
                {
                    field[3] = ModuleControlSettings.NumericFormat(item.ItemPricePurchase);
                    jumlah = det.Quantity * item.ItemPricePurchase;
                }
                else
                {
                    field[3] = ModuleControlSettings.NumericFormat(det.Price);
                    jumlah = det.Quantity * det.Price;

                }

                field[4] = ModuleControlSettings.NumericFormat(jumlah);

                field[5] = ModuleControlSettings.NumericFormat(disc);
                total = jumlah * ((100 - disc) / 100);
                field[6] = ModuleControlSettings.NumericFormat(total);
                field[7] = det.Description;
                field[8] = det.TransactionDetailId.ToString();

                grid_Trans.Rows.Insert(0, field);
            }
        }

        private bool isInEdit = false;
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (isInEdit)
            {
                button1_Click(null, null);
            }
            else
            {
                if (grid_Trans.Rows.Count > 0)
                {
                    txt_ItemId.Text = grid_Trans.CurrentRow.Cells[0].Value.ToString();
                    txt_ItemName.Text = grid_Trans.CurrentRow.Cells[1].Value.ToString();
                    num_Quantity.Value = Convert.ToDecimal(grid_Trans.CurrentRow.Cells[2].Value);
                    num_Price.Value = Convert.ToDecimal(grid_Trans.CurrentRow.Cells[3].Value);
                    //num_Jumlah.Value = Convert.ToDecimal(grid_Trans.CurrentRow.Cells[4].Value);
                    num_Disc.Value = Convert.ToDecimal(grid_Trans.CurrentRow.Cells[5].Value);
                    //num_Total.Value = Convert.ToDecimal(grid_Trans.CurrentRow.Cells[6].Value);

                    if (grid_Trans.CurrentRow.Index != -1)
                        grid_Trans.Rows.RemoveAt(grid_Trans.CurrentRow.Index);
                    else
                        grid_Trans.Rows.RemoveAt(0);

                    btn_Edit.Text = "&OK";
                    ubahDetailTransaksiToolStripMenuItem.Text = "Simpan Detail Transaksi";

                    isInEdit = true;
                    num_Quantity.Select();
                    num_Quantity.Focus();
                }
            }
        }

        internal void FillTransaction(decimal TransactionId)
        {
            TTransaction t = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, TransactionId);
            if (t != null)
            {
                txt_CustId.Text = t.TransactionBy;
                txt_CustId_Validating(null, null);
                //txt_Desc
                txt_Factur.Text = t.TransactionFactur;
                currencyIdComboBox.SelectedItem = t.CurrencyId;
                dt_TransactionDate.Value = t.TransactionDate;
                combo_Gudang.SelectedValue = t.GudangId;
                if (t.TransactionReferenceId != 0)
                {
                    TTransaction tRef = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, t.TransactionReferenceId);
                    if (tRef != null)
                    {
                        txt_OrderNo.Text = tRef.TransactionFactur;
                        txt_OrderNo_Validating(null, null);
                    }
                }
            }
        }
    }
}