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
    public partial class FormTransaction : FormParentForPointOfSales
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private Balloon.NET.BalloonHelp balloonHelp;
        ListOfTransaction trans;
        bool mustValidateTransactionBy;

        bool isInEdit = false;

        public FormTransaction(ListOfTransaction tr)
        {
            InitializeComponent();
            trans = tr;
            this.Icon = Properties.Resources.sales_ico;
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
        }

        private void FormTransaction_Load(object sender, EventArgs e)
        {
            SetInitialCommonSettings();
            transactionIdLabel.Text = DateTime.Now.ToFileTime().ToString();
            transactionFacturTextBox.Text = AppCode.GenerateFacturNo(trans, string.Empty);

            groupBox_CompanyName.ResetText();
            groupBox_FacturDate.ResetText();
            groupBox_FacturDesc.ResetText();
            groupBox_GrandTotal.ResetText();
            //groupBox_Payment.ResetText();
            groupBox_TransactionDetailList.ResetText();
        }

        private void SetInitialCommonSettings()
        {
            //set numeric up down
            ModuleControlSettings.SetNumericUpDown(quantityNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(priceNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(jumlahNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(discNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(totalNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(totalSubTotalNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(ppnNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(GrandTotalNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(piHutangCreditLongNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(transactionPotonganNumericUpDown);
            GrandTotalNumericUpDown.Minimum = decimal.MinValue;
            ModuleControlSettings.SetDateTimePicker(expiredDateDateTimePicker, false);

            //set date time picker
            ModuleControlSettings.SetDateTimePicker(transactionDateDateTimePicker, false);

            //search item
            PictureBox searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicItem_Click);
            itemIdTextBox.Controls.Add(searchPic);

            //search customer
            searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(transactionByTextBox, ListOfSearchWindow.SearchCustomer.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicTransactionBy_Click);
            transactionByTextBox.Controls.Add(searchPic);

            //search transaction
            searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(transactionReferenceFacturTextBox, ListOfSearchWindow.SearchTransaction.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicReferenceId_Click);
            transactionReferenceFacturTextBox.Controls.Add(searchPic);

            //fill payment dropdownlist (cash, kredit)
            FillPayment();

            //set initial settings
            switch (trans)
            {
                case ListOfTransaction.Purchase:
                    namaTransaksi = "Pembelian ";
                    SetInitialSettingsForPurchase();
                    break;
                case ListOfTransaction.Sales:
                    namaTransaksi = "Penjualan ";
                    SetInitialSettingsForSales();
                    break;
                case ListOfTransaction.ReturSales:
                    SetInitialSettingsForReturSales();
                    namaTransaksi = "Retur Penjualan ";
                    break;
                case ListOfTransaction.ReturPurchase:
                    SetInitialSettingsForReturPurchase();
                    namaTransaksi = "Retur Pembelian ";
                    break;
                case ListOfTransaction.Correction:
                    namaTransaksi = "Koreksi Stok ";
                    SetInitialSettingsForCorrection();
                    break;
                case ListOfTransaction.Mutation:
                    namaTransaksi = "Mutasi Stok ";
                    SetInitialSettingsForMutation();
                    break;
                default:
                    break;
            }

            //set header text
            this.Text += namaTransaksi;
            this.TabText += namaTransaksi;

            toolStripButton_List.Text = "Daftar " + namaTransaksi;
        }

        enum DescriptionEnum
        {
            Kadaluarsa, Hilang, Rusak
        }

        private void FillDescription()
        {
            Type desc = typeof(DescriptionEnum);

            descriptionComboBox.Items.Clear();
            foreach (string s in Enum.GetNames(desc))
            {
                descriptionComboBox.Items.Add(Enum.Parse(desc, s).ToString().Replace("_", " "));
            }
            descriptionComboBox.Show();
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

        private void SetInitialSettingsForSales()
        {
            //cetak faktur
            toolStripButton_Cetak.Visible = true;

            //reference id
            transactionReferenceIdLabel.Visible = false;
            transactionReferenceIdTextBox.Visible = false;
            garingLabel.Visible = false;
            transactionReferenceFacturTextBox.Visible = false;
            button_Detail.Visible = false;

            //lama kredit
            piHutangCreditLongLabel.Location = transactionPaymentLabel.Location;
            piHutangCreditLongNumericUpDown.Location = transactionPaymentComboBox.Location;
            hariLabel.Location = new Point(hariLabel.Location.X, piHutangCreditLongLabel.Location.Y);

            //cara bayar
            transactionPaymentLabel.Location = transactionReferenceIdLabel.Location;
            transactionPaymentComboBox.Location = transactionReferenceIdTextBox.Location;

            ////price
            //priceNumericUpDown.Enabled = false;

            //validate customer
            mustValidateTransactionBy = false;

            //description
            descriptionLabel.Visible = false;
            descriptionComboBox.Visible = false;
        }

        private void SetInitialSettingsForPurchase()
        {
            //check use ekspedission
            transactionDescCheckBox.Visible = true;
            transactionDesc2Label.Visible = true;
            transactionDesc2TextBox.Visible = true;

            //reference id
            transactionReferenceIdLabel.Visible = false;
            transactionReferenceIdTextBox.Visible = false;
            garingLabel.Visible = false;
            transactionReferenceFacturTextBox.Visible = false;
            button_Detail.Visible = false;

            //lama kredit
            piHutangCreditLongLabel.Location = transactionPaymentLabel.Location;
            piHutangCreditLongNumericUpDown.Location = transactionPaymentComboBox.Location;
            hariLabel.Location = new Point(hariLabel.Location.X, piHutangCreditLongLabel.Location.Y);

            //cara bayar
            transactionPaymentLabel.Location = transactionReferenceIdLabel.Location;
            transactionPaymentComboBox.Location = transactionReferenceIdTextBox.Location;

            //transaction by label
            transactionByLabel.Text = "Supplier";

            //validate supplier
            mustValidateTransactionBy = true;

            //description
            descriptionLabel.Visible = false;
            descriptionComboBox.Visible = false;
        }

        private void SetInitialSettingsForReturSales()
        {
            //use ppn
            transactionUsePpnCheckBox.Visible = false;

            ////grand total
            //groupBox_GrandTotal.Visible = false;

            //ref id
            transactionReferenceIdLabel.Text = "No Transaksi/Faktur Jual :";

            ////lama kredit
            piHutangCreditLongNumericUpDown.Enabled = false;
            //piHutangCreditLongLabel.Visible = false;
            //piHutangCreditLongNumericUpDown.Visible = false;
            //hariLabel.Visible = false;

            //carabayar
            transactionPaymentLabel.Visible = true;
            transactionPaymentComboBox.Visible = true;
            transactionPaymentComboBox.Enabled = false;

            //potongan
            transactionPotonganLabel.Visible = true;
            transactionPotonganNumericUpDown.Visible = true;

            //groupBox_FacturDesc
            groupBox_FacturDesc.Enabled = false;

            //validate customer
            mustValidateTransactionBy = false;

            //description
            descriptionLabel.Visible = false;
            descriptionComboBox.Visible = false;
        }

        private void SetInitialSettingsForReturPurchase()
        {
            //check use ekspedission
            transactionDescCheckBox.Visible = true;
            transactionDesc2Label.Visible = true;
            transactionDesc2TextBox.Visible = true;

            //use ppn
            transactionUsePpnCheckBox.Visible = false;

            ////grand total
            //groupBox_GrandTotal.Visible = false;

            //ref id
            transactionReferenceIdLabel.Text = "No Transaksi/Faktur Beli :";

            //lama kredit           
            piHutangCreditLongNumericUpDown.Enabled = false;

            //carabayar
            transactionPaymentLabel.Visible = true;
            transactionPaymentComboBox.Visible = true;
            transactionPaymentComboBox.Enabled = false;

            //potongan
            transactionPotonganLabel.Visible = true;
            transactionPotonganNumericUpDown.Visible = true;

            //transaction by label
            transactionByLabel.Text = "Supplier";


            //validate customer
            mustValidateTransactionBy = true;

            //description
            descriptionLabel.Visible = false;
            descriptionComboBox.Visible = false;
        }

        private void SetInitialSettingsForCorrection()
        {
            FillDescription();

            //use ppn
            transactionUsePpnCheckBox.Visible = false;

            //reference id
            transactionReferenceIdLabel.Visible = false;
            transactionReferenceIdTextBox.Visible = false;
            garingLabel.Visible = false;
            transactionReferenceFacturTextBox.Visible = false;
            button_Detail.Visible = false;

            //lama kredit
            piHutangCreditLongLabel.Visible = false;
            piHutangCreditLongNumericUpDown.Visible = false;
            hariLabel.Visible = false;

            //carabayar
            transactionPaymentLabel.Visible = false;
            transactionPaymentComboBox.Visible = false;

            //transaction by label
            transactionByLabel.Text = "Pelapor";
            transactionByLabel.Visible = false;
            transactionByTextBox.Visible = false;
            transactionByTextBox_Name.Visible = false;


            //validate pelapor
            mustValidateTransactionBy = false;

            ///transaction detail

            //kuantitas
            quantityNumericUpDown.Minimum = decimal.MinValue;

            //price
            priceLabel.Visible = false;
            priceNumericUpDown.Visible = false;

            //jumlah
            jumlahLabel.Visible = false;
            jumlahNumericUpDown.Visible = false;

            //diskon
            discLabel.Visible = false;
            discNumericUpDown.Visible = false;

            //total
            totalLabel.Visible = false;
            totalNumericUpDown.Visible = false;


            //description
            descriptionLabel.Location = priceLabel.Location;
            descriptionComboBox.Location = priceNumericUpDown.Location;

            //reset button
            button_Reset.Location = new Point(button_Reset.Location.X, discLabel.Location.Y);
            //add button
            button_Add.Location = new Point(button_Add.Location.X, discLabel.Location.Y);

            ///grid transaction
            ///

            //grid
            for (int i = 4; i < 9; i++)
            {
                tTransactionDetailDataGridView.Columns[i].Visible = false;
            }
            tTransactionDetailDataGridView.Columns[9].Visible = true;
            tTransactionDetailDataGridView.Columns[10].Visible = true;

            //sub total
            totalSubTotalNumericUpDown.Visible = false;


            //grand total
            groupBox_GrandTotal.Visible = false;

            //display balon petunjuk
            RecreateBalloon();
            balloonHelp.Caption = "Petunjuk Pengisian Data Kuantitas Barang";
            balloonHelp.Content = "Jika jumlah Barang \"kurang\", maka kuantitas item diisi dengan tanda minus (misalnya : \"-8\" ) \n dan apabila jumlah item \"berlebih\", maka kuantitas item diisi tanpa tanda (misalnya : \"9\" )";
            balloonHelp.ShowBalloon(quantityNumericUpDown);

            //expired date
            expiredDateLabel.Visible = false;
            expiredDateDateTimePicker.Visible = false;

        }

        private void SetInitialSettingsForMutation()
        {

            //use ppn
            transactionUsePpnCheckBox.Visible = false;

            //reference id
            transactionReferenceIdLabel.Visible = false;
            transactionReferenceIdTextBox.Visible = false;
            garingLabel.Visible = false;
            transactionReferenceFacturTextBox.Visible = false;
            button_Detail.Visible = false;

            //dari gudang .. ke ..
            gudangIdLabel.Location = transactionReferenceIdLabel.Location;
            gudangIdComboBox.Location = transactionReferenceIdTextBox.Location;
            gudangIdToLabel.Location = garingLabel.Location;
            gudangIdToComboBox.Location = transactionReferenceFacturTextBox.Location;

            gudangIdLabel.Visible = true;
            gudangIdComboBox.Visible = true;
            gudangIdToLabel.Visible = true;
            gudangIdToComboBox.Visible = true;

            gudangIdComboBox.DataSource = DataMaster.GetAll(typeof(MGudang));
            gudangIdComboBox.DisplayMember = MGudang.ColumnNames.GudangName;
            gudangIdComboBox.ValueMember = MGudang.ColumnNames.GudangId;
            gudangIdComboBox.Show();

            gudangIdToComboBox.DataSource = DataMaster.GetAll(typeof(MGudang));
            gudangIdToComboBox.DisplayMember = MGudang.ColumnNames.GudangName;
            gudangIdToComboBox.ValueMember = MGudang.ColumnNames.GudangId;
            gudangIdToComboBox.Show();

            //lama kredit
            piHutangCreditLongLabel.Visible = false;
            piHutangCreditLongNumericUpDown.Visible = false;
            hariLabel.Visible = false;

            //carabayar
            transactionPaymentLabel.Visible = false;
            transactionPaymentComboBox.Visible = false;


            //transaction by label
            transactionByLabel.Text = "Pelapor";
            transactionByLabel.Visible = false;
            transactionByTextBox.Visible = false;
            transactionByTextBox_Name.Visible = false;


            //validate pelapor
            mustValidateTransactionBy = false;

            ///transaction detail

            //price
            priceLabel.Visible = false;
            priceNumericUpDown.Visible = false;

            //jumlah
            jumlahLabel.Visible = false;
            jumlahNumericUpDown.Visible = false;

            //diskon
            discLabel.Visible = false;
            discNumericUpDown.Visible = false;

            //total
            totalLabel.Visible = false;
            totalNumericUpDown.Visible = false;

            //description
            descriptionLabel.Location = priceLabel.Location;
            descriptionComboBox.Location = priceNumericUpDown.Location;

            //reset button
            button_Reset.Location = new Point(button_Reset.Location.X, discLabel.Location.Y);
            //add button
            button_Add.Location = new Point(button_Add.Location.X, discLabel.Location.Y);

            ///grid transaction
            ///

            //grid
            //grid
            for (int i = 4; i < 9; i++)
            {
                tTransactionDetailDataGridView.Columns[i].Visible = false;
            }
            tTransactionDetailDataGridView.Columns[9].Visible = true;
            tTransactionDetailDataGridView.Columns[10].Visible = true;

            //sub total
            totalSubTotalNumericUpDown.Visible = false;


            //grand total
            groupBox_GrandTotal.Visible = false;

            //expired date
            expiredDateLabel.Visible = false;
            expiredDateDateTimePicker.Visible = false;
        }


        void searchPicEmployee_Click(object sender, EventArgs e)
        {
            OpenFormSearchEmployee();
        }


        void searchPicTransactionBy_Click(object sender, EventArgs e)
        {
            if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.ReturSales))
                OpenFormSearchCustomer();
            else if (trans.Equals(ListOfTransaction.Purchase) || trans.Equals(ListOfTransaction.ReturPurchase))
                OpenFormSearchSupplier();
            else if (trans.Equals(ListOfTransaction.Correction))
                OpenFormSearchEmployee();
        }

        FormSearchEmployee f_SearchEmployee;
        private void OpenFormSearchEmployee()
        {
            if (f_SearchEmployee != null)
                f_SearchEmployee.Close();

            f_SearchEmployee = new FormSearchEmployee();

            f_SearchEmployee.EmployeeHasSelected += new EventHandler(f_SearchEmployee_HasSelected);

            f_SearchEmployee.ShowDialog(this);
        }

        private void f_SearchEmployee_HasSelected(object sender, EventArgs e)
        {
            if (f_SearchEmployee.grid_Search.Rows.Count > 0)
            {
                transactionByTextBox.Text = f_SearchEmployee.grid_Search.CurrentRow.Cells[0].Value.ToString();
                transactionByTextBox_Validating(null, null);
            }
        }

        FormSearchCustomer f_SearchCustomer;
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
                transactionByTextBox.Text = f_SearchCustomer.grid_Search.CurrentRow.Cells[0].Value.ToString();
                transactionByTextBox_Validating(null, null);
            }
        }

        FormSearchSupplier f_SearchSupplier;
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
                transactionByTextBox.Text = f_SearchSupplier.grid_Search.CurrentRow.Cells[0].Value.ToString();
                transactionByTextBox_Validating(null, null);
            }
        }

        void searchPicItem_Click(object sender, EventArgs e)
        {
            OpenFormSearchItem();
        }

        FormSearchItem f_SearchItem;
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


            if (trans == ListOfTransaction.ReturSales || trans == ListOfTransaction.ReturPurchase)
            {
                if (!string.IsNullOrEmpty(transactionReferenceIdTextBox.Text.Trim()))
                    f_SearchItem.TransactionId = transactionReferenceIdTextBox.Text;
                else
                {
                    RecreateBalloon();

                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = transactionReferenceIdLabel.Text + " tidak boleh kosong !!";
                    balloonHelp.ShowBalloon(transactionReferenceFacturTextBox);
                    transactionReferenceFacturTextBox.Focus();
                    return;
                }
            }

            f_SearchItem.ShowInTaskbar = false;
            f_SearchItem.ShowDialog();
        }

        private void f_SearchItem_ItemHasSelected(object sender, EventArgs e)
        {
            if (f_SearchItem.grid_Search.Rows.Count > 0)
            {
                itemIdTextBox.Text = f_SearchItem.grid_Search.CurrentRow.Cells[0].Value.ToString();
                itemIdTextBox_Validating(null, null);
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (ValidateTransactionDetail())
            {
                object[] transDetail = new object[12];
                transDetail[0] = false;
                transDetail[1] = itemIdTextBox.Text;
                transDetail[2] = itemNameTextBox.Text;
                transDetail[3] = quantityNumericUpDown.Value;
                transDetail[4] = priceNumericUpDown.Value;
                transDetail[5] = jumlahNumericUpDown.Value;
                transDetail[6] = discNumericUpDown.Value;
                transDetail[7] = decimal.Zero;
                transDetail[8] = totalNumericUpDown.Value;
                //transDetail[9] = DateTime.Today;
                transDetail[9] = expiredDateDateTimePicker.Value;
                transDetail[10] = descriptionComboBox.Text;
                transDetail[11] = decimal.Zero;

                tTransactionDetailDataGridView.Rows.Add(transDetail);
                ResetTransactionDetail();
            }
        }

        private void transactionUsePpnCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //ppnNumericUpDown.Enabled = transactionUsePpnCheckBox.Checked;
            if (!transactionUsePpnCheckBox.Checked)
                ppnNumericUpDown.Value = 0;
            else
                ppnNumericUpDown.Value = 10;
        }

        private void itemIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(itemIdTextBox.Text.Trim()))
            {
                MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemIdTextBox.Text);

                itemNameTextBox.Text = item.ItemName;
                itemSatuanTextBox.Text = item.ItemSatuan;

                if (trans.Equals(ListOfTransaction.Purchase))
                    priceNumericUpDown.Value = item.ItemPricePurchase;
                else if (trans.Equals(ListOfTransaction.Sales))
                    priceNumericUpDown.Value = item.ItemPriceMax;
                else if (trans == ListOfTransaction.ReturPurchase || trans == ListOfTransaction.ReturSales)
                {
                    TTransactionDetail det = (TTransactionDetail)DataMaster.GetObjectByProperty(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, Convert.ToDecimal(transactionReferenceIdTextBox.Text), TTransactionDetail.ColumnNames.ItemId, item.ItemId);
                    priceNumericUpDown.Value = det.Price;
                    discNumericUpDown.Value = det.Disc;
                }
            }
        }

        private void CalculateJumlahAndTotal(object sender, EventArgs e)
        {
            jumlahNumericUpDown.Value = quantityNumericUpDown.Value * priceNumericUpDown.Value;
            totalNumericUpDown.Value = (jumlahNumericUpDown.Value * ((100 - discNumericUpDown.Value) / 100));
        }

        private void CalculateSubTotal()
        {
            //decimal sq = 0;
            //decimal sp = 0;
            //decimal sj = 0;
            //decimal sd = 0;
            decimal st = 0;

            for (int i = 0; i < tTransactionDetailDataGridView.Rows.Count; i++)
            {
                //sq += Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[2].Value);
                //sp += Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[3].Value);
                //sj += Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[4].Value);
                //sd += Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[5].Value);
                st += Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[8].Value);
            }

            //quantitySubTotalNumericUpDown.Value = sq;
            //priceSubTotalNumericUpDown.Value = sp;
            //jumlahSubTotalNumericUpDown.Value = sj;
            //discountSubTotalNumericUpDown.Value = sd;
            totalSubTotalNumericUpDown.Value = st;
        }

        private void tTransactionDetailDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateSubTotal();
        }

        private void tTransactionDetailDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateSubTotal();
        }

        private void CalculateGrandTotal(object sender, EventArgs e)
        {
            if (transactionUsePpnCheckBox.Checked)
                GrandTotalNumericUpDown.Value = ((totalSubTotalNumericUpDown.Value) * ((100 + ppnNumericUpDown.Value) / 100)) - transactionPotonganNumericUpDown.Value;
            else
                GrandTotalNumericUpDown.Value = totalSubTotalNumericUpDown.Value - transactionPotonganNumericUpDown.Value;
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (tTransactionDetailDataGridView.Rows.Count > 0)
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (tTransactionDetailDataGridView.CurrentRow.Index != -1)
                        tTransactionDetailDataGridView.Rows.RemoveAt(tTransactionDetailDataGridView.CurrentRow.Index);
                    else
                        tTransactionDetailDataGridView.Rows.RemoveAt(0);

                    ResetTransactionDetail();
                }
            }
        }

        private void itemIdTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), true);
        }

        private void itemIdTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), false);
        }

        private void transactionByTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(transactionByTextBox, ListOfSearchWindow.SearchCustomer.ToString(), true);
        }

        private void transactionByTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(transactionByTextBox, ListOfSearchWindow.SearchCustomer.ToString(), false);
        }

        private void transactionByTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(transactionByTextBox.Text.Trim()))
            {
                if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.ReturSales) || trans.Equals(ListOfTransaction.SalesVIP) || trans.Equals(ListOfTransaction.ReturSalesVIP))
                {
                    ModuleControlSettings.CustomerValidating(transactionByTextBox.Text, transactionByTextBox_Name);
                }
                else if (trans.Equals(ListOfTransaction.Usage) || trans.Equals(ListOfTransaction.Correction))
                {
                    ModuleControlSettings.EmployeeValidating(transactionByTextBox.Text, transactionByTextBox_Name);
                }
                else if (trans.Equals(ListOfTransaction.PurchaseOrder) || trans.Equals(ListOfTransaction.Purchase) || trans.Equals(ListOfTransaction.ReturPurchase))
                {
                    ModuleControlSettings.SupplierValidating(transactionByTextBox.Text, transactionByTextBox_Name);
                    //ModuleControlSettings.SetTransactionTextBoxSuggest(transactionReferenceIdTextBox, ListOfTransaction.PurchaseOrder, transactionByTextBox.Text);
                }
            }
        }

        void ResetTransactionDetail()
        {
            itemIdTextBox.ResetText();
            itemNameTextBox.ResetText();
            itemSatuanTextBox.ResetText();
            quantityNumericUpDown.Value = decimal.One;
            priceNumericUpDown.Value = decimal.Zero;
            jumlahNumericUpDown.Value = decimal.Zero;
            discNumericUpDown.Value = decimal.Zero;
            totalNumericUpDown.Value = decimal.Zero;
            descriptionComboBox.ResetText();

            itemIdTextBox.Select();
        }

        void ResetTransaction(object sender, EventArgs e)
        {
            isInEdit = false;
            transactionIdLabel.Text = DateTime.Now.ToFileTime().ToString();
            transactionDescCheckBox.Enabled = true;
            transactionPaymentComboBox.Enabled = true;

            transactionDateDateTimePicker.Value = DateTime.Today;
            transactionFacturTextBox.Text = AppCode.GenerateFacturNo(trans, string.Empty);
            transactionUsePpnCheckBox.Checked = false;
            gudangIdComboBox.SelectedIndex = -1;
            gudangIdToComboBox.SelectedIndex = -1;

            transactionPotonganNumericUpDown.Value = decimal.Zero;

            transactionReferenceIdTextBox.ResetText();
            transactionReferenceFacturTextBox.ResetText();
            button_Detail.Visible = false;
            transactionByTextBox.ResetText();
            transactionByTextBox_Name.ResetText();

            simpanToolStripButton.Enabled = true;

            transactionPaymentComboBox.SelectedIndex = 0;
            piHutangCreditLongNumericUpDown.Value = decimal.Zero;
            transactionDescCheckBox.Checked = false;
            transactionDesc2TextBox.ResetText();

            tTransactionDetailDataGridView.Rows.Clear();
            ResetTransactionDetail();
        }

        void SaveTransactionInterface(object sender, EventArgs e)
        {
            if (ValidateTransaction())
            {
                if (trans == ListOfTransaction.Sales)
                {
                    if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Cash.ToString())
                    {
                        simpanToolStripButton.Enabled = false;
                        goto saveCash;
                    }
                    else if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Credit.ToString())
                    {
                        if (!string.IsNullOrEmpty(transactionByTextBox.Text))
                        {
                            simpanToolStripButton.Enabled = false;
                            piHutangStatus = ListOfPiHutangStatus.Piutang;
                            goto saveCredit;
                        }
                        else
                        {
                            RecreateBalloon();
                            balloonHelp.Caption = "Validasi data kurang";
                            balloonHelp.Content = "Untuk pembayaran secara kredit, pelanggan harus diisi !!";
                            balloonHelp.ShowBalloon(transactionByTextBox);
                            transactionByTextBox.Focus();

                            simpanToolStripButton.Enabled = true;
                            goto none;
                        }
                    }
                }
                else if (trans == ListOfTransaction.Purchase)
                {
                    if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Cash.ToString())
                    {
                        simpanToolStripButton.Enabled = false;
                        goto saveCash;
                    }
                    else if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Credit.ToString())
                    {
                        if (!string.IsNullOrEmpty(transactionByTextBox.Text))
                        {
                            simpanToolStripButton.Enabled = false;
                            piHutangStatus = ListOfPiHutangStatus.Hutang;
                            goto saveCredit;
                        }
                        else
                        {
                            RecreateBalloon();
                            balloonHelp.Caption = "Validasi data kurang";
                            balloonHelp.Content = "Untuk pembayaran secara kredit, supplier harus diisi !!";
                            balloonHelp.ShowBalloon(transactionByTextBox);
                            transactionByTextBox.Focus();

                            simpanToolStripButton.Enabled = true;
                            goto none;
                        }
                    }
                }
                else if (trans == ListOfTransaction.ReturPurchase)
                {
                    simpanToolStripButton.Enabled = false;
                    piHutangStatus = ListOfPiHutangStatus.Hutang;
                    goto saveRetur;
                }
                else if (trans == ListOfTransaction.ReturSales)
                {
                    simpanToolStripButton.Enabled = false;
                    piHutangStatus = ListOfPiHutangStatus.Piutang;
                    goto saveRetur;
                }
                else if (trans == ListOfTransaction.Mutation)
                {
                    simpanToolStripButton.Enabled = false;
                    goto save;
                }
                else if (trans == ListOfTransaction.Correction)
                {
                    simpanToolStripButton.Enabled = false;
                    goto saveCash;
                }

            saveCredit:
                {
                    SaveTransaction();
                    SaveTransactionDetail();
                    SaveJournalInterface();
                    SavePiHutang();

                    MessageBox.Show("Transaksi " + namaTransaksi + " berhasil disimpan", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                };

            saveCash:
                {
                    SaveTransaction();
                    SaveTransactionDetail();
                    SaveJournalInterface();

                    MessageBox.Show("Transaksi " + namaTransaksi + " berhasil disimpan", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                };
            saveRetur:
                {
                    SaveTransaction();
                    SaveTransactionDetail();
                    SaveJournalInterface();

                    if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Credit.ToString())
                    {
                        UpdatePiHutang();

                    }
                    MessageBox.Show("Transaksi " + namaTransaksi + " berhasil disimpan", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                };
            save:
                {
                    SaveTransaction();
                    SaveTransactionDetail();

                    MessageBox.Show("Transaksi " + namaTransaksi + " berhasil disimpan", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                };
            none:
                {
                    return;
                };
            }
        }

        private void UpdatePiHutang()
        {
            TPiHutang pihutang = (TPiHutang)DataMaster.GetObjectByProperty(typeof(TPiHutang), TPiHutang.ColumnNames.TransactionId, Convert.ToDecimal(transactionReferenceIdTextBox.Text));

            pihutang.PiHutangRetur += totalSubTotalNumericUpDown.Value;
            pihutang.PiHutangSisa = pihutang.PiHutangSisa - totalSubTotalNumericUpDown.Value;

            pihutang.ModifiedBy = lbl_UserName.Text;
            pihutang.ModifiedDate = DateTime.Now;
            DataMaster.UpdatePersistence(pihutang);
        }

        string voucherNo;
        private void SaveJournalInterface()
        {
            if (isInEdit)
                JurnalPembalik(Convert.ToDecimal(transactionIdLabel.Text));

            TDefaultAccount def = (TDefaultAccount)DataMaster.GetObjectByProperty(typeof(TDefaultAccount), TDefaultAccount.ColumnNames.TransactionType, trans.ToString(), TDefaultAccount.ColumnNames.TransactionPayment, transactionPaymentComboBox.SelectedItem.ToString());
            voucherNo = AppCode.GetVoucherNo();
            if (trans == ListOfTransaction.Sales)
            {
                //if customer not have piutang account
                subAcc = def.DebetSubAccountId;
                if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Cash.ToString())
                {
                    //save to cash
                    SaveTransactionJournal(subAcc, ListOfJournalStatus.Debet, GrandTotalNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);
                }
                else if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Credit.ToString())
                {
                    //add piutang journal
                    SaveTransactionJournal(subAcc, ListOfJournalStatus.Debet, GrandTotalNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);
                }

                //save penjualan account
                SaveTransactionJournal(def.KreditSubAccountId, ListOfJournalStatus.Kredit, totalSubTotalNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);

                //save ppn sales journal
                if (ppnNumericUpDown.Value > decimal.Zero)
                {
                    //save ppn penjualan account
                    decimal ppn = GrandTotalNumericUpDown.Value - totalSubTotalNumericUpDown.Value;
                    SaveTransactionJournal(AppCode.GetPPNSalesAccountNo(), ListOfJournalStatus.Kredit, ppn, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);

                }

                //save hpp
                SaveTransactionJournal(AppCode.GetHPPAccountNo(), ListOfJournalStatus.Debet, costPrice, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);

                //save persediaan
                SaveTransactionJournal(AppCode.GetPersediaanAccountNo(), ListOfJournalStatus.Kredit, costPrice, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);

                ////save commission journal
                //if (transactionCommisionNumericUpDown.Value > 0)
                //{
                //    TDefaultAccount defCom = (TDefaultAccount)DataMaster.GetObjectByProperty(typeof(TDefaultAccount), TDefaultAccount.ColumnNames.TransactionType, trans.ToString(), TDefaultAccount.ColumnNames.Description, SubJournal.SalesCommission.ToString());

                //    //save commission penjualan account
                //    SaveTransactionJournal(defCom.KreditSubAccountId, ListOfJournalStatus.Kredit, transactionCommisionNumericUpDown.Value, transactionFacturTextBox.Text, employeeIdTextBox.Text);

                //}
            }
            else if (trans == ListOfTransaction.Purchase)
            {
                //if supp not have utang account
                subAcc = def.KreditSubAccountId;

                //cash
                if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Cash.ToString())
                {
                    //add cash journal
                    SaveTransactionJournal(def.KreditSubAccountId, ListOfJournalStatus.Kredit, GrandTotalNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);
                }
                else if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Credit.ToString())
                {
                    //add utang journal
                    SaveTransactionJournal(def.KreditSubAccountId, ListOfJournalStatus.Kredit, GrandTotalNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);
                }

                //save pembelian account
                SaveTransactionJournal(def.DebetSubAccountId, ListOfJournalStatus.Debet, totalSubTotalNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);

                ////save persediaan
                //SaveTransactionJournal(AppCode.GetPersediaanAccountNo(), ListOfJournalStatus.Kredit, costPrice, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);


                //save ppn purchase journal
                if (ppnNumericUpDown.Value > decimal.Zero)
                {
                    decimal ppn = GrandTotalNumericUpDown.Value - totalSubTotalNumericUpDown.Value;
                    SaveTransactionJournal(AppCode.GetPPNPurchaseAccountNo(), ListOfJournalStatus.Debet, ppn, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);
                }
            }
            else if (trans == ListOfTransaction.ReturPurchase)
            {
                if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Cash.ToString())
                {
                    //add cash journal
                    SaveTransactionJournal(def.DebetSubAccountId, ListOfJournalStatus.Debet, GrandTotalNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text + " ref: " + transactionReferenceFacturTextBox.Text, transactionByTextBox.Text);
                }
                else if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Credit.ToString())
                {
                    //add hutang journal
                    SaveTransactionJournal(def.DebetSubAccountId, ListOfJournalStatus.Debet, GrandTotalNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text + " ref: " + transactionReferenceFacturTextBox.Text, transactionByTextBox.Text);
                }

                //if (transactionPotonganNumericUpDown.Value > decimal.Zero)
                //{
                //    //add potongan retur purchase
                //    SaveTransactionJournal(AppCode.GetPotReturBeliAccountNo(), ListOfJournalStatus.Kredit, transactionPotonganNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text + " ref: " + transactionReferenceFacturTextBox.Text, transactionByTextBox.Text);
                //}

                //add retur purchase journal
                SaveTransactionJournal(def.KreditSubAccountId, ListOfJournalStatus.Kredit, GrandTotalNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text + " ref: " + transactionReferenceFacturTextBox.Text, transactionByTextBox.Text);
            }

            else if (trans == ListOfTransaction.ReturSales)
            {
                if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Cash.ToString())
                {
                    //add cash journal
                    SaveTransactionJournal(def.KreditSubAccountId, ListOfJournalStatus.Kredit, GrandTotalNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text + " ref: " + transactionReferenceFacturTextBox.Text, transactionByTextBox.Text);
                }
                else if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Credit.ToString())
                {
                    //add piutang journal
                    SaveTransactionJournal(def.KreditSubAccountId, ListOfJournalStatus.Kredit, GrandTotalNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text + " ref: " + transactionReferenceFacturTextBox.Text, transactionByTextBox.Text);
                }

                if (transactionPotonganNumericUpDown.Value > decimal.Zero)
                {
                    //add potongan retur sales
                    SaveTransactionJournal(AppCode.GetPotReturJualAccountNo(), ListOfJournalStatus.Kredit, transactionPotonganNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text + " ref: " + transactionReferenceFacturTextBox.Text, transactionByTextBox.Text);
                }

                //save ppn retur sales journal
                if (ppnNumericUpDown.Value > decimal.Zero)
                {
                    //save ppn penjualan account
                    decimal ppn = GrandTotalNumericUpDown.Value - totalSubTotalNumericUpDown.Value;
                    SaveTransactionJournal(AppCode.GetPPNSalesAccountNo(), ListOfJournalStatus.Debet, ppn, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);

                }

                //add retur sales journal
                SaveTransactionJournal(def.DebetSubAccountId, ListOfJournalStatus.Debet, totalSubTotalNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text + " ref: " + transactionReferenceFacturTextBox.Text, transactionByTextBox.Text);



                //save hpp
                SaveTransactionJournal(AppCode.GetHPPAccountNo(), ListOfJournalStatus.Kredit, costPrice, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);

                //save persediaan
                SaveTransactionJournal(AppCode.GetPersediaanAccountNo(), ListOfJournalStatus.Debet, costPrice, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);

            }
            else if (trans == ListOfTransaction.Correction)
            {
                //save persediaan
                SaveTransactionJournal(AppCode.GetPersediaanAccountNo(), ListOfJournalStatus.Kredit, costPrice * -1, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);

                //save beban perubahan stok
                SaveTransactionJournal(AppCode.GetBiayaStokAccountNo(), ListOfJournalStatus.Debet, costPrice * -1, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);
            }

        }

        private void JurnalPembalik(decimal TransactionId)
        {
            IList listJournal = DataMaster.GetListEq(typeof(TJournal), TJournal.ColumnNames.TransactionId, TransactionId);
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

        private void SaveTransactionJournal(string subAccountId, ListOfJournalStatus listOfJournalStatus, decimal saldo, string desc, string pic)
        {
            TJournal jur = new TJournal();

            //MSubAccount sub = (MSubAccount)DataMaster.GetObjectByProperty(typeof(MSubAccount), MSubAccount.ColumnNames.SubAccountId, subAccountId);
            //MAccount acc = new MAccount();
            //if (sub != null)
            //{
            //    acc = (MAccount)DataMaster.GetObjectByProperty(typeof(MAccount), MAccount.ColumnNames.AccountId, sub.AccountId);
            //    if (acc == null)
            //        acc = new MAccount();
            //}
            //else
            //    sub = new MSubAccount();

            //if (acc.AccountStatus == listOfJournalStatus.ToString())
            //{
            //    jur.AccountSaldo = acc.AccountSaldo + saldo;
            //    jur.SubAccontSaldo = sub.SubAccountSaldo + saldo;
            //}
            //else
            //{
            //    jur.AccountSaldo = acc.AccountSaldo - saldo;
            //    jur.SubAccontSaldo = sub.SubAccountSaldo - saldo;
            //}

            jur.JournalDate = DateTime.Now;
            jur.JournalDesc = desc;
            jur.JournalJumlah = saldo;
            jur.JournalPic = pic;
            jur.JournalStatus = listOfJournalStatus.ToString();
            jur.SubAccountId = subAccountId;
            jur.VoucherNo = voucherNo;
            jur.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);
            jur.ModifiedBy = lbl_UserName.Text;
            jur.ModifiedDate = DateTime.Now;

            AppCode.SaveTJournal(jur);
            //DataMaster.SavePersistence(jur);

            ////update saldo sub account
            //sub.SubAccountSaldo = jur.SubAccontSaldo;
            //sub.ModifiedBy = lbl_UserName.Text;
            //sub.ModifiedDate = DateTime.Now;
            //DataMaster.UpdatePersistence(sub);

            ////update saldo account
            //acc.AccountSaldo = jur.AccountSaldo;
            //acc.ModifiedBy = lbl_UserName.Text;
            //acc.ModifiedDate = DateTime.Now;
            //DataMaster.UpdatePersistence(acc);
        }

        string subAcc, namaTransaksi;
        ListOfPiHutangStatus piHutangStatus = ListOfPiHutangStatus.Hutang;
        private void SavePiHutang()
        {
            TPiHutang pihutang = new TPiHutang();
            bool isSave = true;
            if (isInEdit)
            {
                pihutang = (TPiHutang)DataMaster.GetObjectByProperty(typeof(TPiHutang), TPiHutang.ColumnNames.TransactionId, Convert.ToDecimal(transactionIdLabel.Text));
                if (pihutang != null)
                {
                    isSave = false;
                }
            }
            pihutang.PiHutangCreditLong = piHutangCreditLongNumericUpDown.Value;
            pihutang.PiHutangDate = transactionDateDateTimePicker.Value;
            pihutang.PiHutangDesc = transactionFacturTextBox.Text;

            if (piHutangCreditLongNumericUpDown.Visible)
                pihutang.PiHutangJatuhTempo = transactionDateDateTimePicker.Value.AddDays(Convert.ToDouble(piHutangCreditLongNumericUpDown.Value));
            else
            {
                //PointOfSales.Data.TApotekSetting apoSet = (PointOfSales.Data.TApotekSetting)DataMaster.GetObjectByProperty(typeof(PointOfSales.Data.TApotekSetting), PointOfSales.Data.TApotekSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
                //if (apoSet != null)
                //    pihutang.PiHutangJatuhTempo = DateTime.Today.AddDays(Convert.ToDouble(apoSet.DefaultPiutangCreditLong));
                //else
                //    pihutang.PiHutangJatuhTempo = DateTime.Today;
            }

            pihutang.PiHutangJumlah = GrandTotalNumericUpDown.Value;
            pihutang.PiHutangPic = transactionByTextBox.Text;

            if (isSave)
            {
                pihutang.PiHutangDibayar = 0;
                pihutang.PiHutangRetur = decimal.Zero;
                pihutang.PiHutangSisa = GrandTotalNumericUpDown.Value;
            }
            else
            {
                pihutang.PiHutangSisa = GrandTotalNumericUpDown.Value - pihutang.PiHutangDibayar - pihutang.PiHutangRetur;
            }

            pihutang.PiHutangStatus = piHutangStatus.ToString();
            pihutang.SubAccountId = subAcc;
            pihutang.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);

            pihutang.ModifiedBy = lbl_UserName.Text;
            pihutang.ModifiedDate = DateTime.Now;

            if (isSave)
                DataMaster.SavePersistence(pihutang);
            else
                DataMaster.UpdatePersistence(pihutang);

        }

        void SaveTransaction()
        {
            TTransaction t = new TTransaction();
            bool isSave = true;
            if (isInEdit)
            {
                t = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, Convert.ToDecimal(transactionIdLabel.Text));
                if (t == null)
                {
                    t = new TTransaction();
                }
                else
                    isSave = false;
            }

            t.CurrencyId = ListOfCurrency.Rupiah.ToString();
            t.GudangId = 1;

            if (trans == ListOfTransaction.Mutation)
            {
                //to gudang
                t.GudangId = Convert.ToInt32(gudangIdToComboBox.SelectedValue);

                //from gudang
                t.TransactionDesk = gudangIdComboBox.SelectedValue.ToString();
            }

            t.TransactionBy = transactionByTextBox.Text;


            t.TransactionCommision = decimal.Zero;
            t.TransactionDesc = transactionDescCheckBox.Checked.ToString();
            t.TransactionDesc2 = transactionDesc2TextBox.Text;
            t.TransactionDate = transactionDateDateTimePicker.Value;

            t.TransactionDisc = decimal.Zero;
            t.TransactionFactur = transactionFacturTextBox.Text;
            t.TransactionGrandTotal = GrandTotalNumericUpDown.Value;
            t.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);

            if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Cash.ToString())
                t.TransactionPaid = GrandTotalNumericUpDown.Value;
            else if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Credit.ToString())
                t.TransactionPaid = decimal.Zero;


            t.TransactionPayment = transactionPaymentComboBox.SelectedItem.ToString();
            t.TransactionPotongan = transactionPotonganNumericUpDown.Value;

            if (!string.IsNullOrEmpty(transactionReferenceIdTextBox.Text.Trim()))
                t.TransactionReferenceId = Convert.ToDecimal(transactionReferenceIdTextBox.Text);
            else
                t.TransactionReferenceId = decimal.Zero;

            t.TransactionPpn = ppnNumericUpDown.Value;

            if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Cash.ToString())
                t.TransactionSisa = decimal.Zero;
            else if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Credit.ToString())
                t.TransactionSisa = GrandTotalNumericUpDown.Value;


            t.TransactionStatus = trans.ToString();
            t.TransactionSubTotal = totalSubTotalNumericUpDown.Value;
            t.TransactionUsePpn = transactionUsePpnCheckBox.Checked;

            t.ModifiedBy = lbl_UserName.Text;
            t.ModifiedDate = DateTime.Now;

            if (isSave)
                DataMaster.SavePersistence(t);
            else
                DataMaster.UpdatePersistence(t);
        }


        decimal costPrice = 0;
        private void SaveTransactionDetail()
        {
            if (isInEdit)
            {
                DeleteTransactionDetail(Convert.ToDecimal(transactionIdLabel.Text));
            }

            costPrice = 0;
            TTransactionDetail det;

            int gudangId = 1;

            bool AddStok = true;

            if ((trans == ListOfTransaction.Sales) || (trans == ListOfTransaction.ReturPurchase))
                AddStok = false;
            else if ((trans == ListOfTransaction.Purchase) || (trans == ListOfTransaction.ReturSales))
                AddStok = true;

            for (int i = 0; i < tTransactionDetailDataGridView.Rows.Count; i++)
            {
                item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, tTransactionDetailDataGridView.Rows[i].Cells[1].Value.ToString());

                decimal price = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[4].Value);
                decimal qty = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[3].Value);
                DateTime expire = Convert.ToDateTime(tTransactionDetailDataGridView.Rows[i].Cells[9].Value);
                bool isPacket = Convert.ToBoolean(tTransactionDetailDataGridView.Rows[i].Cells[0].Value);
                string itemId = tTransactionDetailDataGridView.Rows[i].Cells[1].Value.ToString();
                decimal transDetailId = decimal.Zero;

                try
                {
                    transDetailId = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[11].Value);
                }
                catch (Exception)
                {
                    transDetailId = decimal.Zero;
                }

                // update average price
                if (trans == ListOfTransaction.Purchase)
                {
                    if (item.ItemPricePurchaseAvg != decimal.Zero)
                        item.ItemPricePurchaseAvg = (item.ItemPricePurchaseAvg + price) / 2;
                    else
                        item.ItemPricePurchaseAvg = price;

                    item.ItemExpiredDate = expire;
                    DataMaster.UpdatePersistence(item);
                }

                if (transDetailId == decimal.Zero)
                {
                    det = new TTransactionDetail();
                }
                else
                {
                    det = (TTransactionDetail)DataMaster.GetObjectByProperty(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionDetailId, transDetailId);
                }

                det.Commission = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[7].Value);

                //if (trans == ListOfTransaction.Sales || trans == ListOfTransaction.ReturSales || trans == ListOfTransaction.Correction)
                //{
                decimal avgPrice = decimal.Zero;
                if (item != null)
                {
                    avgPrice = item.ItemPricePurchaseAvg;
                }

                det.CostPrice = qty * avgPrice;
                costPrice += det.CostPrice;
                //}

                det.Description = tTransactionDetailDataGridView.Rows[i].Cells[10].Value.ToString();
                det.Disc = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[6].Value);
                det.ExpiredDate = expire;
                det.IsPacket = isPacket;
                det.ItemId = itemId;
                det.Jumlah = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[5].Value);
                det.Ppn = decimal.Zero;
                det.Price = price;
                det.Quantity = qty;

                //if corection or Mutation, save item quantity for detail total
                if (trans == ListOfTransaction.Correction || trans == ListOfTransaction.Mutation)
                    det.Total = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[3].Value);
                else
                    det.Total = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[8].Value);

                det.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);
                det.ModifiedBy = lbl_UserName.Text;
                det.ModifiedDate = DateTime.Now;
                DataMaster.SaveOrUpdate(det);

                int gudangCount = 1;
                if (trans == ListOfTransaction.Mutation)
                    gudangCount = 2;

                for (int j = 0; j < gudangCount; j++)
                {
                    if (gudangCount == 2)
                    {
                        if (j == 0)
                        {
                            //dari gudang
                            gudangId = Convert.ToInt32(gudangIdComboBox.SelectedValue);
                            AddStok = false;
                        }
                        else if (j == 1)
                        {
                            //ke gudang
                            gudangId = Convert.ToInt32(gudangIdToComboBox.SelectedValue);
                            AddStok = true;
                        }
                    }
                    //if ((transactionDescCheckBox.Checked && trans == ListOfTransaction.Purchase) == false)
                    if (!transactionDescCheckBox.Checked)
                    {
                        UpdateStok(det.IsPacket, gudangId, det.ItemId, det.Quantity, AddStok);
                    }

                }
            }
        }

        private void DeleteTransactionDetail(decimal TransactionId)
        {
            decimal transDetailId = decimal.Zero;
            bool isDelete = false;
            IList listTrans = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, TransactionId);
            TTransactionDetail det;

            bool AddStok = true;
            int gudangId = 1;

            if ((trans == ListOfTransaction.Sales) || (trans == ListOfTransaction.ReturPurchase))
                AddStok = true;
            else if ((trans == ListOfTransaction.Purchase) || (trans == ListOfTransaction.ReturSales))
                AddStok = false;

            for (int i = 0; i < listTrans.Count; i++)
            {
                det = (TTransactionDetail)listTrans[i];
                isDelete = true;
                for (int j = 0; j < tTransactionDetailDataGridView.Rows.Count; j++)
                {
                    try
                    {
                        transDetailId = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[j].Cells[11].Value);
                    }
                    catch (Exception)
                    {
                        transDetailId = decimal.Zero;
                    }
                    if (transDetailId == det.TransactionDetailId && transDetailId != decimal.Zero)
                    {
                        isDelete = false;
                        break;
                    }
                }

                int gudangCount = 1;
                if (trans == ListOfTransaction.Mutation)
                    gudangCount = 2;

                for (int j = 0; j < gudangCount; j++)
                {
                    if (gudangCount == 2)
                    {
                        if (j == 0)
                        {
                            //dari gudang
                            gudangId = Convert.ToInt32(gudangIdComboBox.SelectedValue);
                            AddStok = true;
                        }
                        else if (j == 1)
                        {
                            //ke gudang
                            gudangId = Convert.ToInt32(gudangIdToComboBox.SelectedValue);
                            AddStok = false;
                        }
                    }
                    if ((transactionDescCheckBox.Checked && trans == ListOfTransaction.Purchase) == false)
                    {
                        UpdateStok(det.IsPacket, gudangId, det.ItemId, det.Quantity, AddStok);
                    }

                }

                if (isDelete)
                {
                    DataMaster.Delete(det);
                }
            }
        }

        MItem item;
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
                krt.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);
                krt.ModifiedBy = lbl_UserName.Text;
                krt.ModifiedDate = DateTime.Now;
                DataMaster.SavePersistence(krt);
            }
        }

        bool ValidateTransaction()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(transactionFacturTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Nomor faktur harus diisi !!";
                balloonHelp.ShowBalloon(transactionFacturTextBox);
                transactionFacturTextBox.Focus();
                return false;
            }

            if (trans == ListOfTransaction.Mutation)
            {
                if (gudangIdComboBox.SelectedIndex == -1 || gudangIdToComboBox.SelectedIndex == -1)
                {
                    balloonHelp.Content = "Pilih lokasi mutasi stok !!";
                    balloonHelp.ShowBalloon(gudangIdComboBox);
                    gudangIdComboBox.Focus();
                    return false;
                }
                if (gudangIdComboBox.SelectedValue == gudangIdToComboBox.SelectedValue)
                {
                    balloonHelp.Content = "Lokasi mutasi stok harus berbeda !!";
                    balloonHelp.ShowBalloon(gudangIdComboBox);
                    gudangIdComboBox.Focus();
                    return false;
                }
            }

            if (mustValidateTransactionBy)
            {
                if (string.IsNullOrEmpty(transactionByTextBox.Text))
                {
                    string errMsg = "";
                    if ((trans == ListOfTransaction.Sales) || (trans == ListOfTransaction.ReturSales))
                    {
                        errMsg = "Pelanggan harus diisi !!";
                    }
                    else if ((trans == ListOfTransaction.Purchase) || (trans == ListOfTransaction.ReturPurchase))
                        errMsg = "Supplier harus diisi !!";
                    else if (trans == ListOfTransaction.Correction || trans == ListOfTransaction.Mutation)
                        errMsg = "Pelapor harus diisi !!";

                    balloonHelp.Content = errMsg;
                    balloonHelp.ShowBalloon(transactionByTextBox);
                    transactionByTextBox.Focus();
                    return false;
                }
            }

            if (tTransactionDetailDataGridView.RowCount == 0)
            {
                MessageBox.Show("Transaksi yang kosong tidak bisa diproses.", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Error);
                itemIdTextBox.Select();
                itemIdTextBox.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(transactionFacturTextBox.Text.Trim()) && !isInEdit)
            {
                TTransaction tr = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionFactur, transactionFacturTextBox.Text.Trim());
                if (tr != null)
                {
                    balloonHelp.Content = "Nomor faktur " + transactionFacturTextBox.Text + " sudah pernah diinput, silahkan input nomor faktur yang lain.";
                    balloonHelp.ShowBalloon(transactionFacturTextBox);
                    transactionFacturTextBox.Focus();
                    return false;
                }
            }

            return true;
        }

        bool ValidateTransactionDetail()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(itemIdTextBox.Text))
            {
                balloonHelp.Content = "Barang harus diisi !!";
                balloonHelp.ShowBalloon(itemIdTextBox);
                itemIdTextBox.Focus();
                return false;
            }
            else
            {
                MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemIdTextBox.Text);
                if (item == null)
                {
                    balloonHelp.Content = "Barang " + itemIdTextBox.Text + " tidak ada dalam database. \n Pastikan anda menulis kode yang tepat atau \n pilih item dengan mengklik gambar disamping untuk mencari Barang.";
                    balloonHelp.ShowBalloon(itemIdTextBox);
                    itemIdTextBox.Focus();
                    return false;
                }
                else
                {
                    int gudangId = 1;
                    string gudangName = "Toko";

                    if (trans == ListOfTransaction.Mutation)
                    {
                        if (gudangIdComboBox.SelectedIndex == -1 || gudangIdToComboBox.SelectedIndex == -1)
                        {
                            balloonHelp.Content = "Pilih lokasi mutasi stok !!";
                            balloonHelp.ShowBalloon(gudangIdComboBox);
                            gudangIdComboBox.Focus();
                            return false;
                        }
                        gudangId = Convert.ToInt32(gudangIdComboBox.SelectedValue);
                        gudangName = gudangIdComboBox.Text;
                    }

                    ItemGudangStok gud = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, item.ItemId, ItemGudangStok.ColumnNames.GudangId, gudangId);
                    if (gud == null)
                    {
                        if (MessageBox.Show("Stok barang di " + gudangName + " = 0. Anda yakin melanjutkan transaksi?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (trans == ListOfTransaction.Sales || trans == ListOfTransaction.ReturPurchase || trans == ListOfTransaction.Mutation || trans == ListOfTransaction.Correction)
                        {

                            if (gud.ItemStok < quantityNumericUpDown.Value)
                            {
                                if (MessageBox.Show("Stok barang di " + gudangName + " tidak mencukupi untuk transaksi ini. Anda yakin melanjutkan transaksi?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            if (transactionReferenceIdTextBox.Visible)
            {
                if (string.IsNullOrEmpty(transactionReferenceIdTextBox.Text))
                {
                    balloonHelp.Content = "Referensi transaksi " + namaTransaksi + " harus diisi !!";
                    balloonHelp.ShowBalloon(transactionReferenceFacturTextBox);
                    transactionReferenceFacturTextBox.Focus();
                    return false;
                }
            }

            if (quantityNumericUpDown.Value == 0)
            {
                balloonHelp.Content = "Kuantitas tidak boleh 0 !!";
                balloonHelp.ShowBalloon(quantityNumericUpDown);
                quantityNumericUpDown.Focus();
                return false;
            }
            return true;
        }

        private void transactionByNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetTransactionDetail();
            tTransactionDetailDataGridView.Rows.Clear();
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

        private void button_Reset_Click(object sender, EventArgs e)
        {
            ResetTransactionDetail();
        }

        private void transactionReferenceFacturTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(transactionReferenceFacturTextBox, ListOfSearchWindow.SearchTransaction.ToString(), true);
        }

        private void transactionReferenceFacturTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(transactionReferenceFacturTextBox, ListOfSearchWindow.SearchTransaction.ToString(), false);
        }

        FormSearchTransaction f_SearchTrans;
        void searchPicReferenceId_Click(object sender, EventArgs e)
        {
            if (f_SearchTrans != null)
            {
                if (!f_SearchTrans.IsDisposed)
                    f_SearchTrans.Close();
            }

            if (trans == ListOfTransaction.ReturSales)
                f_SearchTrans = new FormSearchTransaction(ListOfTransaction.Sales);
            else if (trans == ListOfTransaction.ReturPurchase)
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
            }
        }

        private void FillTransaction(TTransaction tr)
        {
            transactionPaymentComboBox.SelectedItem = tr.TransactionPayment;
            transactionByTextBox.Text = tr.TransactionBy;

            //check use ekspedission
            transactionDesc2TextBox.Text = tr.TransactionDesc2;
            try
            {
                transactionDescCheckBox.Checked = Convert.ToBoolean(tr.TransactionDesc);
            }
            catch (Exception)
            {
                transactionDescCheckBox.Checked = false;
            }

            transactionByTextBox_Validating(null, null);

            if (tr.TransactionPayment == ListOfPayment.Credit.ToString())
            {
                TPiHutang pihut = (TPiHutang)DataMaster.GetObjectByProperty(typeof(TPiHutang), TPiHutang.ColumnNames.TransactionId, tr.TransactionId);
                if (pihut != null)
                {
                    piHutangCreditLongNumericUpDown.Value = pihut.PiHutangCreditLong;
                }
            }
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

        private void transactionPaymentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (trans == ListOfTransaction.Sales || trans == ListOfTransaction.Purchase)
            {
                piHutangCreditLongNumericUpDown.Enabled = (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Credit.ToString());
            }
        }

        private void toolStripButton_Cetak_Click(object sender, EventArgs e)
        {
            if (!simpanToolStripButton.Enabled)
            {
                FormViewReport f_Report = new FormViewReport();
                f_Report.listOfReports = ListOfReports.ReportSalesFactur;
                f_Report.DataId = transactionIdLabel.Text;
                f_Report.Show(this);
            }
            else
                MessageBox.Show("Transaksi " + namaTransaksi + " yang belum disimpan tidak bisa di cetak.", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void transactionDescCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            transactionDesc2TextBox.Enabled = transactionDescCheckBox.Checked;
        }

        private void toolStripButton_List_Click(object sender, EventArgs e)
        {
            if (f_SearchTrans != null)
            {
                if (!f_SearchTrans.IsDisposed)
                    f_SearchTrans.Close();
            }

            f_SearchTrans = new FormSearchTransaction(trans);
            f_SearchTrans.TransactionHasSelected += new EventHandler(f_SearchTransList_TransactionHasSelected);
            f_SearchTrans.Show(this);
        }

        void f_SearchTransList_TransactionHasSelected(object sender, EventArgs e)
        {
            if (f_SearchTrans.grid_Search.Rows.Count > 0)
            {
                transactionIdLabel.Text = transactionReferenceFacturTextBox.Text = f_SearchTrans.grid_Search.CurrentRow.Cells[0].Value.ToString();

                TTransaction tr = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, Convert.ToDecimal(transactionIdLabel.Text));
                if (tr != null)
                {
                    simpanToolStripButton.Enabled = true;
                    isInEdit = true;
                    transactionDescCheckBox.Enabled = false;
                    transactionPaymentComboBox.Enabled = false;

                    transactionFacturTextBox.Text = tr.TransactionFactur;
                    transactionDateDateTimePicker.Value = tr.TransactionDate;
                    transactionUsePpnCheckBox.Checked = tr.TransactionUsePpn;
                    transactionPotonganNumericUpDown.Value = tr.TransactionPotongan;

                    //to gudang
                    gudangIdToComboBox.SelectedValue = tr.GudangId;
                    //from gudang
                    gudangIdComboBox.SelectedValue = tr.TransactionDesk;

                    FillTransaction(tr);
                    FillTransactionDetail(tr);
                }
            }
        }

        private void FillTransactionDetail(TTransaction tr)
        {
            tTransactionDetailDataGridView.Rows.Clear();
            object[] transDetail;
            IList listTransDetail = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, tr.TransactionId);
            TTransactionDetail det;
            MItem item;

            for (int i = 0; i < listTransDetail.Count; i++)
            {
                det = (TTransactionDetail)listTransDetail[i];
                transDetail = new object[12];
                transDetail[0] = false;
                transDetail[1] = det.ItemId;
                item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, det.ItemId);
                if (item != null)
                {
                    transDetail[2] = item.ItemName;
                }
                transDetail[3] = det.Quantity;
                transDetail[4] = det.Price;
                transDetail[5] = det.Jumlah;
                transDetail[6] = det.Disc;
                transDetail[7] = det.Commission;
                transDetail[8] = det.Total;
                transDetail[9] = det.ExpiredDate;
                transDetail[10] = det.Description;
                transDetail[11] = det.TransactionDetailId;
                tTransactionDetailDataGridView.Rows.Add(transDetail);
            }


        }
    }
}