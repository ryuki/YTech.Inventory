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

namespace Inventori.GrosirMitra.Forms
{
    public partial class FormTransaction : FormParentForGrosirMitra
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private Balloon.NET.BalloonHelp balloonHelp;
        ListOfTransaction trans;
        bool mustValidateTransactionBy;

        public FormTransaction(ListOfTransaction tr)
        {
            InitializeComponent();
            trans = tr;
            this.Icon = Properties.Resources.sales_ico;
        }

        private void FormTransaction_Load(object sender, EventArgs e)
        {
            SetInitialCommonSettings();
            ResetTransaction(sender, e);

            groupBox_CompanyName.ResetText();
            groupBox_FacturDate.ResetText();
            groupBox_FacturDesc.ResetText();
            groupBox_GrandTotal.ResetText();
            groupBox_TransactionDetailList.ResetText();
        }

        void SetInitialCommonSettings()
        {
            //set date time picker
            ModuleControlSettings.SetDateTimePicker(transactionDateDateTimePicker, false);

            ////set grid
            //ModuleControlSettings.SetGridDataView(tTransactionDetailDataGridView);

            //for (int i = 0; i < 8; i++)
            //    tTransactionDetailDataGridView.Columns.Add(i.ToString(), i.ToString());

            ////set width for grid view
            //tTransactionDetailDataGridView.Columns[0].Width = itemIdTextBox.Width;
            //tTransactionDetailDataGridView.Columns[1].Width = label_ItemName.Width;
            //tTransactionDetailDataGridView.Columns[2].Width = label_Quantity.Width;
            //tTransactionDetailDataGridView.Columns[3].Width = label_Price.Width;
            //tTransactionDetailDataGridView.Columns[4].Width = label_Jumlah.Width;
            //tTransactionDetailDataGridView.Columns[5].Width = label_Disc.Width;
            //tTransactionDetailDataGridView.Columns[6].Width = label_Total.Width;
            //tTransactionDetailDataGridView.Columns[7].Width = descriptionComboBox.Width;

            ////set visible for grid transaction
            //tTransactionDetailDataGridView.Columns[0].Visible = false;
            //tTransactionDetailDataGridView.Columns[7].Visible = false;

            //for (int i = 2; i < 7; i++)
            //{
            //    tTransactionDetailDataGridView.Columns[i].DefaultCellStyle.Format = "N";
            //    tTransactionDetailDataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //}

            //set numeric up down
            ModuleControlSettings.SetNumericUpDown(quantityNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(priceNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(jumlahNumericUpDown, true);

            ModuleControlSettings.SetNumericUpDown(totalSubTotalNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(GrandTotalNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(piHutangCreditLongNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(transactionDiscNumericUpDown);


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

            //search employee
            searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(employeeIdTextBox, ListOfSearchWindow.SearchEmployee.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicEmployee_Click);
            employeeIdTextBox.Controls.Add(searchPic);

            mCustomerGroupBindingSource.DataSource = DataMaster.GetAll(typeof(MCustomerGroup));

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
                    namaTransaksi = "Penjualan Retail";
                    SetInitialSettingsForSales();
                    break;
                case ListOfTransaction.SalesVIP:
                    namaTransaksi = "Penjualan Grosir";
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

            toolStripButton_ListTransaction.Text = "Daftar " + namaTransaksi;
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

        private void SetInitialSettingsForMutation()
        {
            //set splitContainer_Main
            //splitContainer_Main.SplitterDistance = 175;

            FillDescription();

            //reference id
            transactionReferenceIdLabel.Visible = false;
            transactionReferenceIdTextBox.Visible = false;
            garingLabel.Visible = false;
            transactionReferenceFacturTextBox.Visible = false;
            //button_Detail.Visible = false;

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

            //transaction by label
            transactionByLabel.Text = "Pelapor :";

            //salesman
            employeeIdLabel.Visible = false;
            employeeIdTextBox.Visible = false;
            employeeNameTextBox.Visible = false;

            //validate pelapor
            mustValidateTransactionBy = true;

            ///transaction detail

            //price
            priceLabel.Visible = false;
            priceNumericUpDown.Visible = false;

            //jumlah
            jumlahLabel.Visible = false;
            jumlahNumericUpDown.Visible = false;

            //description
            descriptionLabel.Location = priceLabel.Location;
            descriptionComboBox.Location = priceNumericUpDown.Location;

            ////reset button
            //button_Reset.Location = new Point(button_Reset.Location.X, discLabel.Location.Y);
            ////add button
            //button_Add.Location = new Point(button_Add.Location.X, discLabel.Location.Y);

            ///grid transaction
            ///

            ////label
            //label_Price.Text = "Keterangan";
            //label_Price.Width = label_Price.Width + label_Jumlah.Width + label_Disc.Width + label_Total.Width;
            //label_Jumlah.Visible = false;
            //label_Disc.Visible = false;
            //label_Total.Visible = false;

            ////grid
            for (int i = 3; i < 5; i++)
            {
                tTransactionDetailDataGridView.Columns[i].Visible = false;
            }
            tTransactionDetailDataGridView.Columns[5].Visible = true;
            //tTransactionDetailDataGridView.Columns[7].Width = label_Price.Width;

            ////sub total
            //priceSubTotalNumericUpDown.Visible = false;
            //jumlahSubTotalNumericUpDown.Visible = false;
            //discountSubTotalNumericUpDown.Visible = false;
            totalSubTotalNumericUpDown.Visible = false;
            label_TotalSubTotal.Visible = false;

            //grand total
            groupBox_GrandTotal.Visible = false;
        }

        enum DescriptionEnum
        {
            Hilang, Rusak
        }

        void FillDescription()
        {
            Type desc = typeof(DescriptionEnum);

            descriptionComboBox.Items.Clear();
            foreach (string s in Enum.GetNames(desc))
            {
                descriptionComboBox.Items.Add(Enum.Parse(desc, s).ToString().Replace("_", " "));
            }
            descriptionComboBox.Show();
        }

        private void SetInitialSettingsForCorrection()
        {
            //set splitContainer_Main
            //splitContainer_Main.SplitterDistance = 175;

            FillDescription();

            //gudang
            gudangIdLabel.Location = transactionReferenceIdLabel.Location;
            gudangIdComboBox.Location = transactionReferenceIdTextBox.Location;

            gudangIdLabel.Text = "Lokasi :";
            gudangIdLabel.Visible = true;
            gudangIdComboBox.Visible = true;

            gudangIdComboBox.DataSource = DataMaster.GetAll(typeof(MGudang));
            gudangIdComboBox.DisplayMember = MGudang.ColumnNames.GudangName;
            gudangIdComboBox.ValueMember = MGudang.ColumnNames.GudangId;
            gudangIdComboBox.Show();

            //reference id
            transactionReferenceIdLabel.Visible = false;
            transactionReferenceIdTextBox.Visible = false;
            garingLabel.Visible = false;
            transactionReferenceFacturTextBox.Visible = false;
            //button_Detail.Visible = false;

            //lama kredit
            piHutangCreditLongLabel.Visible = false;
            piHutangCreditLongNumericUpDown.Visible = false;
            hariLabel.Visible = false;

            //transaction by label
            transactionByLabel.Text = "Pelapor";

            //salesman
            employeeIdLabel.Visible = false;
            employeeIdTextBox.Visible = false;
            employeeNameTextBox.Visible = false;

            //validate pelapor
            mustValidateTransactionBy = true;

            ///transaction detail

            //kuantitas
            quantityNumericUpDown.Minimum = decimal.MinValue;
            //quantitySubTotalNumericUpDown.Minimum = decimal.MinValue;

            //price
            priceLabel.Visible = false;
            priceNumericUpDown.Visible = false;

            //jumlah
            jumlahLabel.Visible = false;
            jumlahNumericUpDown.Visible = false;

            //description
            descriptionLabel.Location = priceLabel.Location;
            descriptionComboBox.Location = priceNumericUpDown.Location;

            ////reset button
            //button_Reset.Location = new Point(button_Reset.Location.X, discLabel.Location.Y);
            ////add button
            //button_Add.Location = new Point(button_Add.Location.X, discLabel.Location.Y);

            ///grid transaction
            ///

            ////label
            //label_Price.Text = "Keterangan";
            //label_Price.Width = label_Price.Width + label_Jumlah.Width + label_Disc.Width + label_Total.Width;
            //label_Jumlah.Visible = false;
            //label_Disc.Visible = false;
            //label_Total.Visible = false;

            //grid
            for (int i = 3; i < 5; i++)
            {
                tTransactionDetailDataGridView.Columns[i].Visible = false;
            }
            tTransactionDetailDataGridView.Columns[5].Visible = true;
            //tTransactionDetailDataGridView.Columns[7].Width = label_Price.Width;

            ////sub total
            //priceSubTotalNumericUpDown.Visible = false;
            //jumlahSubTotalNumericUpDown.Visible = false;
            //discountSubTotalNumericUpDown.Visible = false;
            totalSubTotalNumericUpDown.Visible = false;
            label_TotalSubTotal.Visible = false;

            //grand total
            groupBox_GrandTotal.Visible = false;

            //display balon petunjuk
            RecreateBalloon();
            balloonHelp.Caption = "Petunjuk Pengisian Data Kuantitas Barang";
            balloonHelp.Content = "Jika jumlah Barang \"kurang\", maka kuantitas Barang diisi dengan tanda minus (misalnya : \"-8\" ) \n dan apabila jumlah Barang \"berlebih\", maka kuantitas Barang diisi tanpa tanda (misalnya : \"9\" )";
            balloonHelp.ShowBalloon(quantityNumericUpDown);

        }

        private void SetInitialSettingsForReturPurchase()
        {
            //gudang
            gudangIdLabel.Text = "Dari lokasi :";
            gudangIdLabel.Visible = true;
            gudangIdComboBox.Visible = true;

            gudangIdComboBox.DataSource = DataMaster.GetAll(typeof(MGudang));
            gudangIdComboBox.DisplayMember = MGudang.ColumnNames.GudangName;
            gudangIdComboBox.ValueMember = MGudang.ColumnNames.GudangId;
            gudangIdComboBox.Show();
            gudangIdComboBox.Enabled = false;

            ////grand total
            //groupBox_GrandTotal.Visible = false;

            //diskon
            transactionDiscNumericUpDown.Enabled = false;

            //ref id
            transactionReferenceIdLabel.Text = "No Transaksi/Faktur Beli :";

            //lama kredit           
            piHutangCreditLongNumericUpDown.Enabled = false;

            //carabayar
            transactionPaymentComboBox.Enabled = false;

            //transaction by label
            transactionByLabel.Text = "Supplier";

            ////groupBox_FacturDesc
            //groupBox_FacturDesc.Enabled = false;

            //salesman
            employeeIdLabel.Visible = false;
            employeeIdTextBox.Visible = false;
            employeeNameTextBox.Visible = false;

            //validate customer
            mustValidateTransactionBy = true;

            //description
            descriptionLabel.Visible = false;
            descriptionComboBox.Visible = false;
        }

        private void SetInitialSettingsForReturSales()
        {
            ////grand total
            //groupBox_GrandTotal.Visible = false;

            //diskon
            transactionDiscNumericUpDown.Enabled = false;

            //ref id
            transactionReferenceIdLabel.Text = "No Transaksi/Faktur Jual :";

            //lama kredit
            //piHutangCreditLongLabel.Visible = false;
            piHutangCreditLongNumericUpDown.Enabled = false;
            //hariLabel.Visible = false;

            //carabayar
            transactionPaymentComboBox.Enabled = false;
            //transactionPaymentLabel.Location = piHutangCreditLongLabel.Location;
            //transactionPaymentTextBox.Location = piHutangCreditLongNumericUpDown.Location;

            //transaction by label
            transactionByLabel.Text = "Pelanggan";

            //address, phone, plat
            transactionByAddressLabel.Visible = true;
            transactionByAddressTextBox.Visible = true;
            transactionByPhoneLabel.Visible = true;
            transactionByPhoneTextBox.Visible = true;
            //transactionDescLabel.Visible = true;
            //transactionDescTextBox.Visible = true;

            ////groupBox_FacturDesc
            //groupBox_FacturDesc.Enabled = false;

            //validate customer
            mustValidateTransactionBy = true;

            //description
            descriptionLabel.Visible = false;
            descriptionComboBox.Visible = false;
        }

        void SetInitialSettingsForSales()
        {
            //cetak faktur
            CetakToolStripButton.Visible = true;

            //reference id
            transactionReferenceIdLabel.Visible = false;
            transactionReferenceIdTextBox.Visible = false;
            garingLabel.Visible = false;
            transactionReferenceFacturTextBox.Visible = false;
            //button_Detail.Visible = false;

            //lama kredit
            piHutangCreditLongLabel.Location = transactionReferenceIdLabel.Location;
            piHutangCreditLongNumericUpDown.Location = transactionReferenceIdTextBox.Location;
            hariLabel.Location = new Point(hariLabel.Location.X, piHutangCreditLongNumericUpDown.Location.Y);

            //address, phone, plat
            transactionByAddressLabel.Visible = true;
            transactionByAddressTextBox.Visible = true;
            transactionByPhoneLabel.Visible = true;
            transactionByPhoneTextBox.Visible = true;
            //transactionDescLabel.Visible = true;
            //transactionDescTextBox.Visible = true;

            //price
            priceNumericUpDown.Enabled = true;

            //validate customer
            mustValidateTransactionBy = false;

            //description
            descriptionLabel.Visible = false;
            descriptionComboBox.Visible = false;
        }

        private void SetInitialSettingsForPurchase()
        {
            //gudang
            gudangIdLabel.Location = piHutangCreditLongLabel.Location;
            gudangIdComboBox.Location = piHutangCreditLongNumericUpDown.Location;

            gudangIdLabel.Text = "Masuk ke lokasi :";
            gudangIdLabel.Visible = true;
            gudangIdComboBox.Visible = true;

            gudangIdComboBox.DataSource = DataMaster.GetAll(typeof(MGudang));
            gudangIdComboBox.DisplayMember = MGudang.ColumnNames.GudangName;
            gudangIdComboBox.ValueMember = MGudang.ColumnNames.GudangId;
            gudangIdComboBox.Show();

            //reference id
            transactionReferenceIdLabel.Visible = false;
            transactionReferenceIdTextBox.Visible = false;
            garingLabel.Visible = false;
            transactionReferenceFacturTextBox.Visible = false;
            //button_Detail.Visible = false;

            //lama kredit
            piHutangCreditLongLabel.Location = transactionReferenceIdLabel.Location;
            piHutangCreditLongNumericUpDown.Location = transactionReferenceIdTextBox.Location;
            hariLabel.Location = new Point(hariLabel.Location.X, piHutangCreditLongNumericUpDown.Location.Y);

            //transaction by label
            transactionByLabel.Text = "Supplier";

            //salesman
            employeeIdLabel.Visible = false;
            employeeIdTextBox.Visible = false;
            employeeNameTextBox.Visible = false;

            //validate supplier
            mustValidateTransactionBy = true;

            //description
            descriptionLabel.Visible = false;
            descriptionComboBox.Visible = false;
        }

        void searchPicTransactionBy_Click(object sender, EventArgs e)
        {
            if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.ReturSales) || trans == ListOfTransaction.SalesVIP)
                OpenFormSearchCustomer();
            else if (trans.Equals(ListOfTransaction.Purchase) || trans.Equals(ListOfTransaction.ReturPurchase))
                OpenFormSearchSupplier();
            else if (trans.Equals(ListOfTransaction.Correction) || trans == ListOfTransaction.Mutation)
                OpenFormSearchEmployee(Employee.Pelapor);
        }

        enum Employee
        {
            Pelapor, Salesman
        }

        void searchPicEmployee_Click(object sender, EventArgs e)
        {
            OpenFormSearchEmployee(Employee.Salesman);
        }

        FormSearchEmployee f_SearchEmployee;
        private void OpenFormSearchEmployee(Employee emp)
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

            if (emp == Employee.Pelapor)
                f_SearchEmployee.EmployeeHasSelected += new EventHandler(f_SearchEmployee_EmployeeHasSelected);
            else if (emp == Employee.Salesman)
                f_SearchEmployee.EmployeeHasSelected += new EventHandler(f_SearchEmployeeSalesman_EmployeeHasSelected);

            f_SearchEmployee.ShowDialog(this);
        }

        private void f_SearchEmployee_EmployeeHasSelected(object sender, EventArgs e)
        {
            if (f_SearchEmployee.grid_Search.Rows.Count > 0)
            {
                transactionByTextBox.Text = f_SearchEmployee.grid_Search.CurrentRow.Cells[0].Value.ToString();
                transactionByTextBox_Validating(null, null);
            }
        }

        private void f_SearchEmployeeSalesman_EmployeeHasSelected(object sender, EventArgs e)
        {
            if (f_SearchEmployee.grid_Search.Rows.Count > 0)
            {
                employeeIdTextBox.Text = f_SearchEmployee.grid_Search.CurrentRow.Cells[0].Value.ToString();
                employeeIdTextBox_Validating(null, null);
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


            //if (trans == ListOfTransaction.ReturSales || trans == ListOfTransaction.ReturPurchase)
            //{
            //    if (!string.IsNullOrEmpty(transactionReferenceIdTextBox.Text.Trim()))
            //        f_SearchItem.TransactionId = transactionReferenceIdTextBox.Text;
            //    else
            //    {
            //        RecreateBalloon();

            //        balloonHelp.Caption = "Validasi data kurang";
            //        balloonHelp.Content = transactionReferenceIdLabel.Text + " tidak boleh kosong !!";
            //        balloonHelp.ShowBalloon(transactionReferenceFacturTextBox);
            //        transactionReferenceFacturTextBox.Focus();
            //        return;
            //    }
            //}

            f_SearchItem.ShowInTaskbar = false;
            f_SearchItem.itemId_HeaderText = "Kode Barang";
            f_SearchItem.itemName_HeaderText = "Nama Barang";
            f_SearchItem.itemSalesPrice_HeaderText = "Harga Jual Retail";
            f_SearchItem.itemSalesPriceVIP_HeaderText = "Harga Jual Grosir";
            f_SearchItem.Text = "Pencarian Barang";
            f_SearchItem.searchItemByIdText = "<Cari Berdasar Kode Barang>";
            f_SearchItem.searchItemByNameText = "<Cari Berdasar Nama Barang>";
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
                object[] transDetail = new object[7];
                transDetail[0] = itemIdTextBox.Text;
                transDetail[1] = itemNameTextBox.Text;
                transDetail[2] = quantityNumericUpDown.Value;
                transDetail[3] = priceNumericUpDown.Value;
                transDetail[4] = jumlahNumericUpDown.Value;
                transDetail[5] = descriptionComboBox.Text;
                transDetail[6] = decimal.Zero;

                tTransactionDetailDataGridView.Rows.Add(transDetail);

                ResetTransactionDetail();
            }
        }

        private void itemIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(itemIdTextBox.Text.Trim()))
            {
                MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemIdTextBox.Text);

                if (item != null)
                {
                    itemNameTextBox.Text = item.ItemName;
                    itemSatuanTextBox.Text = item.ItemSatuan;

                    if (trans.Equals(ListOfTransaction.Sales) || (trans == ListOfTransaction.ReturSales))
                        priceNumericUpDown.Value = item.ItemPriceMax;
                    else if (trans.Equals(ListOfTransaction.SalesVIP))
                        priceNumericUpDown.Value = item.ItemPriceMaxVip;
                    else if (trans.Equals(ListOfTransaction.Purchase) || (trans == ListOfTransaction.ReturPurchase))
                        priceNumericUpDown.Value = item.ItemPricePurchase;
                    //else if (trans == ListOfTransaction.ReturPurchase || trans == ListOfTransaction.ReturSales)
                    //{
                    //    TTransactionDetail det = (TTransactionDetail)DataMaster.GetObjectByProperty(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, Convert.ToDecimal(transactionReferenceIdTextBox.Text), TTransactionDetail.ColumnNames.ItemId, item.ItemId);
                    //    priceNumericUpDown.Value = det.Price;
                    //}
                }
            }
        }

        private void CalculateJumlahAndTotal(object sender, EventArgs e)
        {
            jumlahNumericUpDown.Value = quantityNumericUpDown.Value * priceNumericUpDown.Value;
        }

        private void CalculateSubTotal()
        {
            decimal st = 0;

            for (int i = 0; i < tTransactionDetailDataGridView.Rows.Count; i++)
            {
                st += Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[4].Value);
            }

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
            GrandTotalNumericUpDown.Value = ((totalSubTotalNumericUpDown.Value) * ((100 - transactionDiscNumericUpDown.Value) / 100));
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
                    MCustomer cust = (MCustomer)DataMaster.GetObjectByProperty(typeof(MCustomer), MCustomer.ColumnNames.CustomerId, transactionByTextBox.Text);
                    if (cust != null)
                    {
                        transactionByTextBox_Name.Text = cust.CustomerName;
                        transactionByAddressTextBox.Text = cust.CustomerAddress;
                        transactionByPhoneTextBox.Text = cust.CustomerPhone;
                        //transactionDescTextBox.Text = cust.CustomerDesc2;
                    }
                    else
                        transactionByTextBox_Name.ResetText();
                }
                else if (trans.Equals(ListOfTransaction.Usage) || trans.Equals(ListOfTransaction.Correction))
                {
                    MEmployee emp = (MEmployee)DataMaster.GetObjectByProperty(typeof(MEmployee), MEmployee.ColumnNames.EmployeeId, transactionByTextBox.Text);
                    if (emp != null)
                        transactionByTextBox_Name.Text = emp.EmployeeName;
                    else
                        transactionByTextBox_Name.ResetText();
                }
                else if (trans.Equals(ListOfTransaction.PurchaseOrder) || trans.Equals(ListOfTransaction.Purchase) || trans.Equals(ListOfTransaction.ReturPurchase))
                {
                    MSupplier supp = (MSupplier)DataMaster.GetObjectByProperty(typeof(MSupplier), MSupplier.ColumnNames.SupplierId, transactionByTextBox.Text);
                    if (supp != null)
                    {
                        transactionByTextBox_Name.Text = supp.SupplierName;

                        if (trans.Equals(ListOfTransaction.Purchase))
                        {
                            ModuleControlSettings.SetTransactionTextBoxSuggest(transactionReferenceIdTextBox, ListOfTransaction.PurchaseOrder, supp.SupplierId);
                        }
                    }
                    else
                        transactionByTextBox_Name.ResetText();
                }
            }
        }

        void ResetTransactionDetail()
        {
            itemIdTextBox.ResetText();
            itemNameTextBox.ResetText();
            itemSatuanTextBox.ResetText();
            quantityNumericUpDown.Value = 1;
            priceNumericUpDown.Value = 0;
            jumlahNumericUpDown.Value = 0;
            descriptionComboBox.ResetText();

            itemIdTextBox.Select();
        }

        void ResetTransaction(object sender, EventArgs e)
        {
            simpanToolStripButton.Enabled = true;
            isInEdit = false;
            transactionPaymentComboBox.Enabled = true;

            transactionIdLabel.Text = DateTime.Now.ToFileTime().ToString();
            transactionDateDateTimePicker.Value = DateTime.Today;
            transactionFacturTextBox.Text = AppCode.GenerateFacturNo(trans, string.Empty);
            gudangIdComboBox.SelectedIndex = -1;
            gudangIdToComboBox.SelectedIndex = -1;
            piHutangCreditLongNumericUpDown.Value = decimal.Zero;


            transactionReferenceIdTextBox.ResetText();
            transactionReferenceFacturTextBox.ResetText();
            transactionByAddressTextBox.ResetText();
            transactionByPhoneTextBox.ResetText();
            //transactionDescTextBox.ResetText();

            //button_Detail.Visible = false;
            transactionByTextBox.ResetText();
            transactionByTextBox_Name.ResetText();
            employeeIdTextBox.ResetText();
            employeeNameTextBox.ResetText();

            transactionDiscNumericUpDown.Value = decimal.Zero;

            tTransactionDetailDataGridView.Rows.Clear();
            ResetTransactionDetail();
        }

        void SaveTransactionInterface(object sender, EventArgs e)
        {
            if (ValidateTransaction())
            {
                if (isInEdit)
                {
                    formDel = new FormDeleteConfirm(FormDeleteConfirm.Pin.Discount);
                    formDel.Text = "Konfirmasi Perubahan Transaksi " + namaTransaksi;
                    formDel.deletePinLabel.Text = "Pin Perubahan Transaksi :";
                    if (formDel.ShowDialog(this) != DialogResult.OK)
                        return;
                }

                if (trans == ListOfTransaction.Sales || trans == ListOfTransaction.SalesVIP || trans == ListOfTransaction.Purchase)
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
                            balloonHelp.Content = "Untuk pembayaran secara kredit, " + transactionByLabel.Text.Substring(0, transactionByLabel.Text.Length - 1) + " harus diisi !!";
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
                    SavePiHutang();

                    MessageBox.Show("Transaksi " + namaTransaksi + " berhasil disimpan", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                };

            saveCash:
                {
                    SaveTransaction();
                    SaveTransactionDetail();

                    MessageBox.Show("Transaksi " + namaTransaksi + " berhasil disimpan", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                };
            saveRetur:
                {
                    SaveTransaction();
                    SaveTransactionDetail();

                    if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Credit.ToString())
                    {
                        if (!string.IsNullOrEmpty(transactionReferenceIdTextBox.Text) && transactionReferenceIdTextBox.Text != "0")
                            UpdatePiHutang();
                        else
                            SavePiHutang();
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

        string namaTransaksi;
        ListOfPiHutangStatus piHutangStatus = ListOfPiHutangStatus.Hutang;
        private void SavePiHutang()
        {
            decimal kredit = piHutangCreditLongNumericUpDown.Value;
            //if (trans == ListOfTransaction.SalesVIP || trans == ListOfTransaction.Sales)
            //{
            //    Inventori.GrosirMitra.Data.TGrosirSetting tg = (Inventori.GrosirMitra.Data.TGrosirSetting)DataMaster.GetObjectByProperty(typeof(Inventori.GrosirMitra.Data.TGrosirSetting), Inventori.GrosirMitra.Data.TGrosirSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            //    if (tg != null)
            //        kredit = tg.DefaultPiutangCreditLong;
            //}

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

            pihutang.PiHutangCreditLong = kredit;
            pihutang.PiHutangDate = transactionDateDateTimePicker.Value;
            pihutang.PiHutangDesc = transactionFacturTextBox.Text;
            pihutang.PiHutangJatuhTempo = transactionDateDateTimePicker.Value.AddDays(Convert.ToDouble(kredit));

            if (trans == ListOfTransaction.ReturPurchase || trans == ListOfTransaction.ReturSales)
            {
                pihutang.PiHutangJumlah = decimal.Zero - GrandTotalNumericUpDown.Value;
                if (isSave)
                {
                    pihutang.PiHutangDibayar = 0;
                    pihutang.PiHutangRetur = GrandTotalNumericUpDown.Value;
                    pihutang.PiHutangSisa = decimal.Zero - GrandTotalNumericUpDown.Value;
                }
                else
                {
                    //pihutang.PiHutangDibayar = 0;
                    pihutang.PiHutangRetur = GrandTotalNumericUpDown.Value;
                    pihutang.PiHutangSisa = pihutang.PiHutangDibayar - GrandTotalNumericUpDown.Value;

                    //pihutang.PiHutangSisa = pihutang.PiHutangDibayar - pihutang.PiHutangRetur;
                }
            }
            else
            {
                pihutang.PiHutangJumlah = GrandTotalNumericUpDown.Value;

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
            }

            pihutang.PiHutangLunasDate = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
            pihutang.PiHutangPic = transactionByTextBox.Text;


            pihutang.PiHutangStatus = piHutangStatus.ToString();
            pihutang.SubAccountId = string.Empty;
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
            t.EmployeeId = employeeIdTextBox.Text;

            if (gudangIdToComboBox.Visible)
                t.GudangId = Convert.ToInt32(gudangIdToComboBox.SelectedValue);
            else
                t.GudangId = 1;

            if (trans == ListOfTransaction.Mutation)
            {
                //to gudang
                t.GudangId = Convert.ToInt32(gudangIdToComboBox.SelectedValue);

                //from gudang
                t.TransactionDesk = gudangIdComboBox.SelectedValue.ToString();
            }

            t.TransactionBy = transactionByTextBox.Text;
            t.TransactionByAddress = transactionByAddressTextBox.Text;
            t.TransactionByPhone = transactionByPhoneTextBox.Text;
            //t.TransactionDesc = transactionDescTextBox.Text;
            //t.TransactionDesc2 = string.Empty;

            //if (transactionByNameComboBox.SelectedIndex != -1)
            //    t.TransactionByName = transactionByNameComboBox.SelectedValue.ToString();

            t.TransactionCommision = decimal.Zero;
            t.TransactionDate = transactionDateDateTimePicker.Value;

            t.TransactionDisc = transactionDiscNumericUpDown.Value;
            t.TransactionFactur = transactionFacturTextBox.Text;
            t.TransactionGrandTotal = GrandTotalNumericUpDown.Value;
            t.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);

            if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Cash.ToString())
            {
                t.TransactionPaid = GrandTotalNumericUpDown.Value;
                if (isSave)
                {
                    t.TransactionSisa = decimal.Zero;
                }
            }
            else if (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Credit.ToString())
            {
                t.TransactionSisa = t.TransactionSisa - GrandTotalNumericUpDown.Value;
                if (isSave)
                {
                    t.TransactionPaid = decimal.Zero;
                }
            }

            t.TransactionPayment = transactionPaymentComboBox.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(transactionReferenceIdTextBox.Text.Trim()))
                t.TransactionReferenceId = Convert.ToDecimal(transactionReferenceIdTextBox.Text);
            else
                t.TransactionReferenceId = decimal.Zero;

            t.TransactionPpn = decimal.Zero;

            t.TransactionStatus = trans.ToString();
            t.TransactionSubTotal = totalSubTotalNumericUpDown.Value;
            t.TransactionUsePpn = false;

            t.ModifiedBy = lbl_UserName.Text;
            t.ModifiedDate = DateTime.Now;

            if (isSave)
                DataMaster.SavePersistence(t);
            else
                DataMaster.UpdatePersistence(t);
        }

        private void SaveTransactionDetail()
        {
            if (isInEdit)
            {
                DeleteTransactionDetail(Convert.ToDecimal(transactionIdLabel.Text));
            }

            TTransactionDetail det;
            MItem item;

            int gudangId = 1;

            if (gudangIdComboBox.Visible)
                gudangId = Convert.ToInt32(gudangIdComboBox.SelectedValue);

            bool AddStok = true;

            if ((trans == ListOfTransaction.Sales) || (trans == ListOfTransaction.ReturPurchase) || trans == ListOfTransaction.SalesVIP)
                AddStok = false;
            else if ((trans == ListOfTransaction.Purchase) || (trans == ListOfTransaction.ReturSales))
                AddStok = true;

            for (int i = 0; i < tTransactionDetailDataGridView.Rows.Count; i++)
            {
                item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, tTransactionDetailDataGridView.Rows[i].Cells[0].Value.ToString());
                decimal qty = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[2].Value);
                decimal transDetailId = decimal.Zero;

                try
                {
                    transDetailId = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[6].Value);
                }
                catch (Exception)
                {
                    transDetailId = decimal.Zero;
                }

                if (transDetailId == decimal.Zero)
                {
                    det = new TTransactionDetail();
                }
                else
                {
                    det = (TTransactionDetail)DataMaster.GetObjectByProperty(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionDetailId, transDetailId);
                }

                if (item != null && (trans == ListOfTransaction.Sales || trans == ListOfTransaction.SalesVIP || trans == ListOfTransaction.ReturSales || trans == ListOfTransaction.ReturSalesVIP))
                    det.CostPrice = qty * item.ItemPricePurchaseAvg;


                det.Description = tTransactionDetailDataGridView.Rows[i].Cells[5].Value.ToString();
                det.ItemId = tTransactionDetailDataGridView.Rows[i].Cells[0].Value.ToString();
                det.Jumlah = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[4].Value);
                det.Ppn = 0;
                det.Price = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[3].Value);
                det.Quantity = qty;

                //if corection or Mutation, save item quantity for detail total
                if (trans == ListOfTransaction.Correction || trans == ListOfTransaction.Mutation)
                    det.Total = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[2].Value);
                else
                    det.Total = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[4].Value);

                det.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);

                det.ModifiedBy = lbl_UserName.Text;
                det.ModifiedDate = DateTime.Now;
                DataMaster.SaveOrUpdate(det);

                if (item != null)
                {
                    // update average price
                    if (trans == ListOfTransaction.Purchase)
                    {
                        decimal price = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[3].Value);
                        if (item.ItemPricePurchaseAvg != decimal.Zero)
                            item.ItemPricePurchaseAvg = (item.ItemPricePurchaseAvg + price) / 2;
                        else
                            item.ItemPricePurchaseAvg = price;

                        DataMaster.UpdatePersistence(item);
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
                                AddStok = false;
                            }
                            else if (j == 1)
                            {
                                //ke gudang
                                gudangId = Convert.ToInt32(gudangIdToComboBox.SelectedValue);
                                AddStok = true;
                            }
                        }

                        UpdateStok(false, gudangId, det.ItemId, det.Quantity, AddStok);

                        ////if item == barang
                        //if (item.ItemTypeId == 1)
                        //{
                        //    //change stok
                        //    stok = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, tTransactionDetailDataGridView.Rows[i].Cells[0].Value.ToString(), ItemGudangStok.ColumnNames.GudangId, gudangId);
                        //    if (stok != null)
                        //    {
                        //        if (AddStok)
                        //            saldo = stok.ItemStok + Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[2].Value);
                        //        else
                        //            saldo = stok.ItemStok - Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[2].Value);

                        //        stok.ItemStok = saldo;
                        //        stok.ModifiedBy = lbl_UserName.Text;
                        //        stok.ModifiedDate = DateTime.Now;
                        //        DataMaster.UpdatePersistence(stok);
                        //    }
                        //    else
                        //    {
                        //        stok = new ItemGudangStok();
                        //        stok.GudangId = gudangId;
                        //        stok.ItemId = det.ItemId;
                        //        stok.ItemMaxStok = 0;
                        //        stok.ItemMinStok = 0;
                        //        if (AddStok)
                        //            saldo = det.Quantity;
                        //        else
                        //            saldo = det.Quantity * -1;

                        //        stok.ItemStok = saldo;
                        //        stok.ModifiedBy = lbl_UserName.Text;
                        //        stok.ModifiedDate = DateTime.Now;
                        //        DataMaster.SavePersistence(stok);
                        //    }

                        //}

                        //krt = new TStokCard();
                        //krt.ItemId = tTransactionDetailDataGridView.Rows[i].Cells[0].Value.ToString();
                        //krt.GudangId = gudangId;
                        //krt.StokCardDate = DateTime.Today;
                        //krt.StokCardPic = transactionByTextBox.Text;
                        //krt.StokCardQuantity = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[2].Value);
                        //krt.StokCardSaldo = saldo;
                        //krt.StokCardStatus = AddStok;
                        //krt.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);
                        //krt.ModifiedBy = lbl_UserName.Text;
                        //krt.ModifiedDate = DateTime.Now;
                        //DataMaster.SavePersistence(krt);
                    }
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
                //if (item.ItemTypeId == 1)
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
                krt.StokCardDate = transactionDateDateTimePicker.Value;
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

        private void DeleteTransactionDetail(decimal TransactionId)
        {
            decimal transDetailId = decimal.Zero;
            bool isDelete = false;
            IList listTrans = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, TransactionId);
            TTransactionDetail det;

            bool AddStok = true;
            int gudangId = 1;

            if ((trans == ListOfTransaction.Sales) || (trans == ListOfTransaction.ReturPurchase) || (trans == ListOfTransaction.SalesVIP))
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
                        transDetailId = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[j].Cells[6].Value);
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
                    UpdateStok(false, gudangId, det.ItemId, det.Quantity, AddStok);


                }

                if (isDelete)
                {
                    DataMaster.Delete(det);
                }
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

            if (gudangIdComboBox.Visible && gudangIdComboBox.SelectedIndex == -1)
            {
                balloonHelp.Content = "Pilih lokasi  !!";
                balloonHelp.ShowBalloon(gudangIdComboBox);
                gudangIdComboBox.Focus();
                return false;
            }

            //if (transactionByNameComboBox.Visible)
            //{
            //    if (transactionByNameComboBox.SelectedIndex == -1)
            //    {
            //        balloonHelp.Content = "Pilih kategori pelanggan !!";
            //        balloonHelp.ShowBalloon(transactionByNameComboBox);
            //        transactionByNameComboBox.Focus();
            //        return false;
            //    }
            //}

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

            //if (transactionByNameComboBox.Visible)
            //{
            //    if (transactionByNameComboBox.SelectedIndex == -1)
            //    {
            //        balloonHelp.Content = "Pilih kategori pelanggan !!";
            //        balloonHelp.ShowBalloon(transactionByNameComboBox);
            //        transactionByNameComboBox.Focus();
            //        return false;
            //    }
            //}
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

        private FormDeleteConfirm formDel;
        bool ValidateTransactionDetail()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";


            //if (transactionReferenceIdTextBox.Visible)
            //{
            //    if (string.IsNullOrEmpty(transactionReferenceIdTextBox.Text))
            //    {
            //        balloonHelp.Content = "Referensi transaksi " + namaTransaksi + " harus diisi !!";
            //        balloonHelp.ShowBalloon(transactionReferenceFacturTextBox);
            //        transactionReferenceFacturTextBox.Focus();
            //        return false;
            //    }
            //}


            if (quantityNumericUpDown.Value == 0)
            {
                balloonHelp.Content = "Kuantitas tidak boleh 0 !!";
                balloonHelp.ShowBalloon(quantityNumericUpDown);
                quantityNumericUpDown.Focus();
                return false;
            }


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
                    balloonHelp.Content = "Barang " + itemIdTextBox.Text + " tidak ada dalam database. \n Pastikan anda menulis kode yang tepat atau \n pilih Barang dengan mengklik gambar disamping untuk mencari Barang.";
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

                    if (gudangIdToComboBox.Visible)
                    {
                        if (gudangIdComboBox.SelectedIndex == -1)
                        {
                            balloonHelp.Content = "Pilih lokasi !!";
                            balloonHelp.ShowBalloon(gudangIdComboBox);
                            gudangIdComboBox.Focus();
                            return false;
                        }
                        gudangId = Convert.ToInt32(gudangIdComboBox.SelectedValue);
                        gudangName = gudangIdComboBox.Text;
                    }

                    ItemGudangStok gud = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, item.ItemId, ItemGudangStok.ColumnNames.GudangId, gudangId);
                    if (trans == ListOfTransaction.Sales || trans == ListOfTransaction.ReturPurchase || trans == ListOfTransaction.Mutation)
                    {
                        if (gud == null)
                        {
                            if (MessageBox.Show("Stok Barang di " + gudangName + " = 0. Anda yakin melanjutkan transaksi?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return false;
                            }
                        }
                        else
                        {

                            if (gud.ItemStok < quantityNumericUpDown.Value)
                            {
                                if (MessageBox.Show("Stok Barang di " + gudangName + " tidak mencukupi untuk transaksi ini. Anda yakin melanjutkan transaksi?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
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

        private void CetakToolStripButton_Click(object sender, EventArgs e)
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
                //button_Detail.Visible = true;

                //RecreateBalloon();
                //balloonHelp.Caption = "Detail Transaksi";
                //balloonHelp.Content = "Klik disini untuk melihat detail transaksi";
                //balloonHelp.ShowBalloon(button_Detail);
            }
            else
            {
                transactionReferenceIdTextBox.ResetText();
                //button_Detail.Visible = false;
            }
        }

        private void FillTransaction(TTransaction tr)
        {
            if (gudangIdComboBox.Visible)
                gudangIdComboBox.SelectedValue = tr.GudangId;

            transactionPaymentComboBox.SelectedItem = tr.TransactionPayment;
            transactionByTextBox.Text = tr.TransactionBy;
            transactionByTextBox_Validating(null, null);
            employeeIdTextBox.Text = tr.EmployeeId;

            //address, phone, plat
            transactionByAddressTextBox.Text = tr.TransactionByAddress;
            transactionByPhoneTextBox.Text = tr.TransactionByPhone;
            //transactionDescTextBox.Text = tr.TransactionDesc;

            transactionDiscNumericUpDown.Value = tr.TransactionDisc;

            TPiHutang pihut = (TPiHutang)DataMaster.GetObjectByProperty(typeof(TPiHutang), TPiHutang.ColumnNames.TransactionId, tr.TransactionId);
            if (pihut != null)
                piHutangCreditLongNumericUpDown.Value = pihut.PiHutangCreditLong;

            //if (trans == ListOfTransaction.ReturSales)
            //    transactionByNameComboBox.SelectedValue = tr.TransactionByName;
        }

        private void button_Detail_Click(object sender, EventArgs e)
        {
            FormViewReport f_Report = new FormViewReport();
            f_Report.listOfReports = ListOfReports.TransactionDetail;
            f_Report.DataId = transactionReferenceIdTextBox.Text;
            f_Report.Show(this);
        }

        private void transactionByNameComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (trans != ListOfTransaction.Sales)
                return;

            //if (transactionByNameComboBox.SelectedIndex != -1)
            //{
            //    MCustomerGroup cg = (MCustomerGroup)DataMaster.GetObjectByProperty(typeof(MCustomerGroup), MCustomerGroup.ColumnNames.CustomerGroupId, transactionByNameComboBox.SelectedValue.ToString());
            //    if (cg != null)
            //    {
            //        if (cg.CustomerGroupUsePercentage)
            //        {
            //            transactionDiscNumericUpDown.Value = cg.CustomerGroupPercentage;
            //            transactionDiscNumericUpDown.Enabled = false;
            //        }
            //        else
            //        {
            //            transactionDiscNumericUpDown.Value = 0;
            //            transactionDiscNumericUpDown.Enabled = true;
            //        }
            //    }
            //    else
            //    {
            //        transactionDiscNumericUpDown.Value = 0;
            //        transactionDiscNumericUpDown.Enabled = true;
            //    }
            //}
        }

        private void employeeIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(employeeIdTextBox.Text.Trim()))
            {
                MEmployee emp = (MEmployee)DataMaster.GetObjectByProperty(typeof(MEmployee), MEmployee.ColumnNames.EmployeeId, employeeIdTextBox.Text);
                if (emp != null)
                    employeeNameTextBox.Text = emp.EmployeeName;
                else
                    employeeNameTextBox.ResetText();
            }
        }

        private void employeeIdTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(employeeIdTextBox, ListOfSearchWindow.SearchEmployee.ToString(), true);
        }

        private void employeeIdTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(employeeIdTextBox, ListOfSearchWindow.SearchEmployee.ToString(), false);
        }

        private void toolStripButton_ListTransaction_Click(object sender, EventArgs e)
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
        bool isInEdit = false;
        void f_SearchTransList_TransactionHasSelected(object sender, EventArgs e)
        {
            if (f_SearchTrans.grid_Search.Rows.Count > 0)
            {
                transactionIdLabel.Text = f_SearchTrans.grid_Search.CurrentRow.Cells[0].Value.ToString();

                TTransaction tr = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, Convert.ToDecimal(transactionIdLabel.Text));
                if (tr != null)
                {
                    simpanToolStripButton.Enabled = true;
                    isInEdit = true;
                    transactionPaymentComboBox.Enabled = false;
                    //transactionPaymentComboBox.Enabled = false;

                    transactionFacturTextBox.Text = tr.TransactionFactur;
                    transactionDateDateTimePicker.Value = tr.TransactionDate;

                    //to gudang
                    gudangIdToComboBox.SelectedValue = tr.GudangId;
                    //from gudang
                    gudangIdComboBox.SelectedValue = tr.TransactionDesk;

                    if (trans == ListOfTransaction.ReturPurchase || trans == ListOfTransaction.ReturSales)
                    {
                        transactionReferenceIdTextBox.Text = tr.TransactionReferenceId.ToString();
                        TTransaction t = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, tr.TransactionReferenceId);
                        if (t != null)
                        {
                            transactionReferenceFacturTextBox.Text = t.TransactionFactur;
                            transactionReferenceFacturTextBox_Validating(null, null);
                        }
                    }

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
                transDetail = new object[7];
                transDetail[0] = det.ItemId;
                item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, det.ItemId);
                if (item != null)
                {
                    transDetail[1] = item.ItemName;
                }
                transDetail[2] = det.Quantity;
                transDetail[3] = det.Price;
                transDetail[4] = det.Jumlah;
                transDetail[5] = det.Description;
                transDetail[6] = det.TransactionDetailId;
                tTransactionDetailDataGridView.Rows.Add(transDetail);
            }
        }

        private void transactionPaymentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (trans == ListOfTransaction.Sales || trans == ListOfTransaction.Purchase)
            {
                piHutangCreditLongNumericUpDown.Enabled = (transactionPaymentComboBox.SelectedItem.ToString() == ListOfPayment.Credit.ToString());
            }
        }

        private void transactionDiscNumericUpDown_Leave(object sender, EventArgs e)
        {
            if (transactionDiscNumericUpDown.Enabled && transactionDiscNumericUpDown.Value > 0 && transactionDiscNumericUpDown.Visible && trans == ListOfTransaction.Sales)
            {
                formDel = new FormDeleteConfirm(FormDeleteConfirm.Pin.Discount);
                if (formDel.ShowDialog(this) != DialogResult.OK)
                    return;
                else
                    transactionDiscNumericUpDown.Value = 0;
            }
        }
    }
}