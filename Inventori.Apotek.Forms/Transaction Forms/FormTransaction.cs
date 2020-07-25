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

namespace Inventori.Apotek.Forms
{
    public partial class FormTransaction : FormParentForApotek
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
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
        }

        private void FormTransaction_Load(object sender, EventArgs e)
        {
            SetInitialCommonSettings();
            transactionIdLabel.Text = DateTime.Now.ToFileTime().ToString();
            transactionFacturTextBox.Text = AppCode.GenerateFacturNo(trans, string.Empty);
            transactionDeskComboBox.SelectedIndex = -1;

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
            ModuleControlSettings.SetNumericUpDown(commissionNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(transactionPotonganNumericUpDown);
            GrandTotalNumericUpDown.Minimum = decimal.MinValue;

            //set date time picker
            ModuleControlSettings.SetDateTimePicker(expiredDateDateTimePicker, false);
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

            //search employee / dokter
            searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(employeeIdTextBox, ListOfSearchWindow.SearchEmployee.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicEmployee_Click);
            employeeIdTextBox.Controls.Add(searchPic);

            //search employee / petugas
            searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(employeeId2TextBox, ListOfSearchWindow.SearchEmployee.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicEmployee2_Click);
            employeeId2TextBox.Controls.Add(searchPic);

            mRoomBindingSource.DataSource = DataMaster.GetAll(typeof(MRoom));
            mCustomerGroupBindingSource.DataSource = DataMaster.GetAll(typeof(MCustomerGroup));

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

        private void SetInitialSettingsForSales()
        {
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

            //price
            priceNumericUpDown.Enabled = false;

            //golongan pelanggan
            transactionByNameComboBox.SelectedValue = "JU";
            //validate customer
            mustValidateTransactionBy = false;

            //description
            descriptionLabel.Visible = false;
            descriptionComboBox.Visible = false;
        }

        private void SetInitialSettingsForPurchase()
        {
            //is paket
            label_IsPacket.Visible = false;
            checkBox_IsPacket.Visible = false;

            //reference id
            transactionReferenceIdLabel.Visible = false;
            transactionReferenceIdTextBox.Visible = false;
            garingLabel.Visible = false;
            transactionReferenceFacturTextBox.Visible = false;
            button_Detail.Visible = false;

            //lama kredit
            piHutangCreditLongLabel.Location = transactionReferenceIdLabel.Location;
            piHutangCreditLongNumericUpDown.Location = transactionReferenceIdTextBox.Location;
            hariLabel.Location = new Point(hariLabel.Location.X, piHutangCreditLongNumericUpDown.Location.Y);

            //transaction by label
            transactionByLabel.Text = "Supplier";

            //kategori pelanggan
            transactionByNameLabel.Visible = false;
            transactionByNameComboBox.Visible = false;

            //nama pasien
            transactionDescLabel.Visible = false;
            transactionDescTextBox.Visible = false;

            //dokter
            employeeIdLabel.Visible = false;
            employeeIdTextBox.Visible = false;
            employeeNameTextBox.Visible = false;

            //petugas
            employeeId2Label.Visible = false;
            employeeId2TextBox.Visible = false;
            employeeName2TextBox.Visible = false;

            //ruangan
            transactionDeskComboBox.Visible = false;
            transactionDeskLabel.Visible = false;

            //tuslah
            commissionLabel.Visible = false;
            commissionNumericUpDown.Visible = false;

            //expire
            expiredDateLabel.Location = totalLabel.Location;
            expiredDateDateTimePicker.Location = totalNumericUpDown.Location;

            //total 
            totalLabel.Location = commissionLabel.Location;
            totalNumericUpDown.Location = commissionNumericUpDown.Location;

            //validate supplier
            mustValidateTransactionBy = true;

            //description
            descriptionLabel.Visible = false;
            descriptionComboBox.Visible = false;
        }

        private void SetInitialSettingsForReturSales()
        {
            //is paket            
            //checkBox_IsPacket.Enabled = false;

            //use ppn
            transactionUsePpnCheckBox.Visible = false;

            ////grand total
            //groupBox_GrandTotal.Visible = false;

            //ref id
            transactionReferenceIdLabel.Text = "No Transaksi/Faktur Jual :";

            //lama kredit
            piHutangCreditLongLabel.Visible = false;
            piHutangCreditLongNumericUpDown.Visible = false;
            hariLabel.Visible = false;

            //carabayar
            transactionPaymentLabel.Visible = true;
            transactionPaymentTextBox.Visible = true;

            //potongan
            transactionPotonganLabel.Visible = true;
            transactionPotonganNumericUpDown.Visible = true;

            //tuslah
            commissionLabel.Visible = false;
            commissionNumericUpDown.Visible = false;

            //groupBox_FacturDesc
            groupBox_FacturDesc.Enabled = false;

            //golongan pelanggan
            transactionByNameComboBox.SelectedIndex = -1;

            //validate customer
            mustValidateTransactionBy = false;

            //description
            descriptionLabel.Visible = false;
            descriptionComboBox.Visible = false;
        }

        private void SetInitialSettingsForReturPurchase()
        {
            //is paket
            label_IsPacket.Visible = false;
            checkBox_IsPacket.Visible = false;

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
            transactionPaymentTextBox.Visible = true;

            //potongan
            transactionPotonganLabel.Visible = true;
            transactionPotonganNumericUpDown.Visible = true;

            //transaction by label
            transactionByLabel.Text = "Supplier";

            //kategori pelanggan
            transactionByNameLabel.Visible = false;
            transactionByNameComboBox.Visible = false;

            //nama pasien
            transactionDescLabel.Visible = false;
            transactionDescTextBox.Visible = false;

            //dokter
            employeeIdLabel.Visible = false;
            employeeIdTextBox.Visible = false;
            employeeNameTextBox.Visible = false;

            //petugas
            employeeId2Label.Visible = false;
            employeeId2TextBox.Visible = false;
            employeeName2TextBox.Visible = false;

            //ruangan
            transactionDeskComboBox.Visible = false;
            transactionDeskLabel.Visible = false;

            //tuslah
            commissionLabel.Visible = false;
            commissionNumericUpDown.Visible = false;


            //expire
            expiredDateLabel.Location = totalLabel.Location;
            expiredDateDateTimePicker.Location = totalNumericUpDown.Location;

            //total 
            totalLabel.Location = commissionLabel.Location;
            totalNumericUpDown.Location = commissionNumericUpDown.Location;


            //validate customer
            mustValidateTransactionBy = true;

            //description
            descriptionLabel.Visible = false;
            descriptionComboBox.Visible = false;
        }

        private void SetInitialSettingsForCorrection()
        {
            FillDescription();

            //is paket
            label_IsPacket.Visible = false;
            checkBox_IsPacket.Visible = false;

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

            //tuslah
            commissionLabel.Visible = false;
            commissionNumericUpDown.Visible = false;

            //transaction by label
            transactionByLabel.Text = "Pelapor";

            //kategori pelanggan
            transactionByNameLabel.Visible = false;
            transactionByNameComboBox.Visible = false;

            //nama pasien
            transactionDescLabel.Visible = false;
            transactionDescTextBox.Visible = false;

            //dokter
            employeeIdLabel.Visible = false;
            employeeIdTextBox.Visible = false;
            employeeNameTextBox.Visible = false;

            //petugas
            employeeId2Label.Visible = false;
            employeeId2TextBox.Visible = false;
            employeeName2TextBox.Visible = false;

            //ruangan
            transactionDeskComboBox.Visible = false;
            transactionDeskLabel.Visible = false;

            //validate pelapor
            mustValidateTransactionBy = true;

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

            //expire
            expiredDateLabel.Location = priceLabel.Location;
            expiredDateDateTimePicker.Location = priceNumericUpDown.Location;

            //description
            descriptionLabel.Location = jumlahLabel.Location;
            descriptionComboBox.Location = jumlahNumericUpDown.Location;

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
            balloonHelp.Caption = "Petunjuk Pengisian Data Kuantitas Obat";
            balloonHelp.Content = "Jika jumlah Obat \"kurang\", maka kuantitas item diisi dengan tanda minus (misalnya : \"-8\" ) \n dan apabila jumlah item \"berlebih\", maka kuantitas item diisi tanpa tanda (misalnya : \"9\" )";
            balloonHelp.ShowBalloon(quantityNumericUpDown);

        }

        private void SetInitialSettingsForMutation()
        {
            //is paket
            label_IsPacket.Visible = false;
            checkBox_IsPacket.Visible = false;

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

            //tuslah
            commissionLabel.Visible = false;
            commissionNumericUpDown.Visible = false;

            //transaction by label
            transactionByLabel.Text = "Pelapor :";

            //kategori pelanggan
            transactionByNameLabel.Visible = false;
            transactionByNameComboBox.Visible = false;

            //nama pasien
            transactionDescLabel.Visible = false;
            transactionDescTextBox.Visible = false;

            //dokter
            employeeIdLabel.Visible = false;
            employeeIdTextBox.Visible = false;
            employeeNameTextBox.Visible = false;

            //petugas
            employeeId2Label.Visible = false;
            employeeId2TextBox.Visible = false;
            employeeName2TextBox.Visible = false;

            //ruangan
            transactionDeskComboBox.Visible = false;
            transactionDeskLabel.Visible = false;

            //validate pelapor
            mustValidateTransactionBy = true;

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

            //expire
            expiredDateLabel.Location = priceLabel.Location;
            expiredDateDateTimePicker.Location = priceNumericUpDown.Location;

            //description
            descriptionLabel.Location = jumlahLabel.Location;
            descriptionComboBox.Location = jumlahNumericUpDown.Location;

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
        }

        enum EmployeeEnum
        {
            Dokter, Petugas, Pelapor
        }
        void searchPicEmployee_Click(object sender, EventArgs e)
        {
            OpenFormSearchEmployee(EmployeeEnum.Dokter);
        }

        void searchPicEmployee2_Click(object sender, EventArgs e)
        {
            OpenFormSearchEmployee(EmployeeEnum.Petugas);
        }


        void searchPicTransactionBy_Click(object sender, EventArgs e)
        {
            if (trans.Equals(ListOfTransaction.Sales) || trans.Equals(ListOfTransaction.ReturSales))
                OpenFormSearchCustomer();
            else if (trans.Equals(ListOfTransaction.Purchase) || trans.Equals(ListOfTransaction.ReturPurchase))
                OpenFormSearchSupplier();
            else if (trans.Equals(ListOfTransaction.Correction))
                OpenFormSearchEmployee(EmployeeEnum.Pelapor);
        }

        FormSearchEmployee f_SearchEmployee;
        private void OpenFormSearchEmployee(EmployeeEnum emp)
        {
            //if (f_SearchEmployee != null)
            //{
            //    if (!f_SearchEmployee.IsDisposed)
            //    {
            //        f_SearchEmployee.WindowState = FormWindowState.Normal;
            //        f_SearchEmployee.BringToFront();
            //    }
            //    else
            //        f_SearchEmployee = new FormSearchEmployee();
            //}
            //else
            //    f_SearchEmployee = new FormSearchEmployee();
            if (f_SearchEmployee != null)
                f_SearchEmployee.Close();

            f_SearchEmployee = new FormSearchEmployee();

            if (emp == EmployeeEnum.Dokter)
                f_SearchEmployee.EmployeeHasSelected += new EventHandler(f_SearchEmployee_DokterHasSelected);
            else if (emp == EmployeeEnum.Petugas)
                f_SearchEmployee.EmployeeHasSelected += new EventHandler(f_SearchEmployee_PetugasHasSelected);
            else if (emp == EmployeeEnum.Pelapor)
                f_SearchEmployee.EmployeeHasSelected += new EventHandler(f_SearchEmployee_PelaporHasSelected);

            f_SearchEmployee.ShowDialog(this);
        }

        private void f_SearchEmployee_PelaporHasSelected(object sender, EventArgs e)
        {
            if (f_SearchEmployee.grid_Search.Rows.Count > 0)
            {
                transactionByTextBox.Text = f_SearchEmployee.grid_Search.CurrentRow.Cells[0].Value.ToString();
                transactionByTextBox_Validating(null, null);
            }
        }

        private void f_SearchEmployee_DokterHasSelected(object sender, EventArgs e)
        {
            if (f_SearchEmployee.grid_Search.Rows.Count > 0)
            {
                employeeIdTextBox.Text = f_SearchEmployee.grid_Search.CurrentRow.Cells[0].Value.ToString();
                employeeIdTextBox_Validating(null, null);
            }
        }

        private void f_SearchEmployee_PetugasHasSelected(object sender, EventArgs e)
        {
            if (f_SearchEmployee.grid_Search.Rows.Count > 0)
            {
                employeeId2TextBox.Text = f_SearchEmployee.grid_Search.CurrentRow.Cells[0].Value.ToString();
                employeeId2TextBox_Validating(null, null);
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
            if (!checkBox_IsPacket.Checked)
                OpenFormSearchItem();
            else
                OpenFormSearchPacket();
        }

        FormSearchPacket f_SearchPacket;
        private void OpenFormSearchPacket()
        {
            if (f_SearchPacket != null)
            {
                if (!f_SearchPacket.IsDisposed)
                {
                    f_SearchPacket.WindowState = FormWindowState.Normal;
                    f_SearchPacket.BringToFront();
                }
                else
                    f_SearchPacket = new FormSearchPacket();
            }
            else
                f_SearchPacket = new FormSearchPacket();

            f_SearchPacket.packetIdColoumnName = "Kode Obat Puyer";
            f_SearchPacket.packetNameColoumnName = "Nama Obat Puyer";
            f_SearchPacket.packetPriceColoumnName = "Harga";
            f_SearchPacket.Text = "Pencarian Obat Puyer";
            f_SearchPacket.PacketHasSelected += new EventHandler(f_SearchPacket_PacketHasSelected);

            if (trans == ListOfTransaction.ReturSales || trans == ListOfTransaction.ReturPurchase)
            {
                if (!string.IsNullOrEmpty(transactionReferenceIdTextBox.Text.Trim()))
                    f_SearchPacket.TransactionId = transactionReferenceIdTextBox.Text;
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

            f_SearchPacket.ShowInTaskbar = false;
            f_SearchPacket.ShowDialog();
        }

        void f_SearchPacket_PacketHasSelected(object sender, EventArgs e)
        {
            if (f_SearchPacket.grid_Search.Rows.Count > 0)
            {
                itemIdTextBox.Text = f_SearchPacket.grid_Search.CurrentRow.Cells[0].Value.ToString();
                itemIdTextBox_Validating(null, null);
            }
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
            if (trans == ListOfTransaction.Sales || trans == ListOfTransaction.ReturSales)
                f_SearchItem.lbl_TempTransaction.ResetText();
            else
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
                object[] transDetail = new object[11];
                transDetail[0] = checkBox_IsPacket.Checked;
                transDetail[1] = itemIdTextBox.Text;
                transDetail[2] = itemNameTextBox.Text;
                transDetail[3] = quantityNumericUpDown.Value;
                transDetail[4] = priceNumericUpDown.Value;
                transDetail[5] = jumlahNumericUpDown.Value;
                transDetail[6] = discNumericUpDown.Value;
                transDetail[7] = commissionNumericUpDown.Value;
                transDetail[8] = totalNumericUpDown.Value;
                transDetail[9] = expiredDateDateTimePicker.Value;
                transDetail[10] = descriptionComboBox.Text;

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
                string itemId = string.Empty;
                string itemName = string.Empty;
                string itemDesc = string.Empty;
                string itemSatuan = string.Empty;
                decimal purchasePrice = decimal.Zero;
                decimal commission = decimal.Zero;

                MCommission comm = null;

                if (!checkBox_IsPacket.Checked)
                {
                    MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemIdTextBox.Text);
                    if (item != null)
                    {
                        itemId = item.ItemId;
                        itemName = item.ItemName;
                        itemDesc = item.ItemDesc;
                        itemSatuan = item.ItemSatuan;
                        purchasePrice = item.ItemPricePurchase;
                    }
                    comm = (MCommission)DataMaster.GetObjectByProperty(typeof(MCommission), MCommission.ColumnNames.CommissionStatus, ListOfCommission.Non_Puyer.ToString());
                    if (comm != null)
                        commission = comm.CommissionValue;
                }
                else
                {
                    MPacket paket = (MPacket)DataMaster.GetObjectByProperty(typeof(MPacket), MPacket.ColumnNames.PacketId, itemIdTextBox.Text);
                    if (paket != null)
                    {
                        itemId = paket.PacketId;
                        itemName = paket.PacketName;
                        itemDesc = string.Empty;
                        itemSatuan = string.Empty;
                        purchasePrice = paket.PacketPrice;
                    }
                    comm = (MCommission)DataMaster.GetObjectByProperty(typeof(MCommission), MCommission.ColumnNames.CommissionStatus, ListOfCommission.Puyer.ToString());
                    if (comm != null)
                        commission = comm.CommissionValue;
                }

                itemNameTextBox.Text = itemName;
                itemDescTextBox.Text = itemDesc;
                itemSatuanTextBox.Text = itemSatuan;

                if (trans.Equals(ListOfTransaction.Sales))
                {
                    if (transactionByNameComboBox.SelectedIndex != -1)
                    {
                        MCustomerGroup custGroup = (MCustomerGroup)DataMaster.GetObjectByProperty(typeof(MCustomerGroup), MCustomerGroup.ColumnNames.CustomerGroupId, transactionByNameComboBox.SelectedValue.ToString());
                        decimal persen = 0;
                        if (custGroup != null)
                            persen = custGroup.CustomerGroupPercentage;
                        priceNumericUpDown.Value = purchasePrice * (1 + (persen / 100));
                        commissionNumericUpDown.Value = commission;
                    }
                    else
                    {
                        MessageBox.Show("Kategori Pelanggan belum dipilih!", "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetTransactionDetail();
                        transactionByNameComboBox.Select();
                    }

                }
                else if (trans.Equals(ListOfTransaction.Purchase))
                    priceNumericUpDown.Value = purchasePrice;
                else if (trans == ListOfTransaction.ReturPurchase || trans == ListOfTransaction.ReturSales)
                {
                    TTransactionDetail det = (TTransactionDetail)DataMaster.GetObjectByProperty(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, Convert.ToDecimal(transactionReferenceIdTextBox.Text), TTransactionDetail.ColumnNames.ItemId, itemId);
                    priceNumericUpDown.Value = det.Price;
                    discNumericUpDown.Value = det.Disc;
                    expiredDateDateTimePicker.Value = det.ExpiredDate;
                }

            }
        }

        private void CalculateJumlahAndTotal(object sender, EventArgs e)
        {
            jumlahNumericUpDown.Value = quantityNumericUpDown.Value * priceNumericUpDown.Value;
            totalNumericUpDown.Value = (jumlahNumericUpDown.Value * ((100 - discNumericUpDown.Value) / 100)) + commissionNumericUpDown.Value;
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
                    ModuleControlSettings.SetTransactionTextBoxSuggest(transactionReferenceIdTextBox, ListOfTransaction.PurchaseOrder, transactionByTextBox.Text);
                }
            }
        }

        void ResetTransactionDetail()
        {
            checkBox_IsPacket.Checked = false;
            itemIdTextBox.ResetText();
            itemNameTextBox.ResetText();
            itemDescTextBox.ResetText();
            itemSatuanTextBox.ResetText();
            quantityNumericUpDown.Value = decimal.One;
            priceNumericUpDown.Value = decimal.Zero;
            jumlahNumericUpDown.Value = decimal.Zero;
            discNumericUpDown.Value = decimal.Zero;
            commissionNumericUpDown.Value = decimal.Zero;
            totalNumericUpDown.Value = decimal.Zero;
            expiredDateDateTimePicker.Value = DateTime.Today;
            descriptionComboBox.ResetText();

            itemIdTextBox.Select();
        }

        void ResetTransaction(object sender, EventArgs e)
        {
            transactionIdLabel.Text = DateTime.Now.ToFileTime().ToString();
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
            transactionByNameComboBox.SelectedIndex = -1;
            transactionDescTextBox.ResetText();
            transactionDeskComboBox.SelectedIndex = -1;
            employeeIdTextBox.ResetText();
            employeeNameTextBox.ResetText();
            employeeId2TextBox.ResetText();
            employeeName2TextBox.ResetText();

            simpanToolStripButton.Enabled = true;
            groupBox_Payment.Visible = false;

            tTransactionDetailDataGridView.Rows.Clear();
            ResetTransactionDetail();
        }

        void SaveTransactionInterface(object sender, EventArgs e)
        {
            if (ValidateTransaction())
            {
                if (trans == ListOfTransaction.Sales)
                {
                    if (sender == simpanToolStripButton)
                    {
                        groupBox_Payment.Visible = true;
                        simpanToolStripButton.Enabled = false;
                        goto none;
                    }
                    else if (sender == button_Cash)
                    {
                        salesPayment = Payment.Cash;
                        groupBox_Payment.Visible = false;
                        goto saveCash;
                    }
                    else if (sender == button_Credit)
                    {
                        if (!string.IsNullOrEmpty(transactionByTextBox.Text))
                        {
                            salesPayment = Payment.Credit;
                            groupBox_Payment.Visible = false;
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

                            groupBox_Payment.Visible = false;
                            simpanToolStripButton.Enabled = true;
                            goto none;
                        }
                    }
                    else if (sender == button_Batal)
                    {
                        groupBox_Payment.Visible = false;
                        simpanToolStripButton.Enabled = true;
                        goto none;
                    }
                }
                else if (trans == ListOfTransaction.Purchase)
                {
                    salesPayment = Payment.Credit;
                    simpanToolStripButton.Enabled = false;
                    piHutangStatus = ListOfPiHutangStatus.Hutang;
                    goto saveCredit;
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

                    if (salesPayment == Payment.Cash)
                    {
                        button_PaymentFlipFlop.Image = Properties.Resources.cash;
                        button_PaymentFlipFlop.Text = "Pembayaran retur dengan potong nilai tunai dari kasir.";
                    }
                    else if (salesPayment == Payment.Credit)
                    {
                        UpdatePiHutang();
                        button_PaymentFlipFlop.Image = Properties.Resources.kredit;
                        button_PaymentFlipFlop.Text = "Pembayaran retur dengan potong " + piHutangStatus.ToString();
                    }
                    timer1.Start();
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

        enum SubJournal
        {
            PPN, SalesCommission
        }

        string voucherNo;
        private void SaveJournalInterface()
        {
            TDefaultAccount def = (TDefaultAccount)DataMaster.GetObjectByProperty(typeof(TDefaultAccount), TDefaultAccount.ColumnNames.TransactionType, trans.ToString(), TDefaultAccount.ColumnNames.TransactionPayment, salesPayment.ToString());
            voucherNo = AppCode.GetVoucherNo();
            if (trans == ListOfTransaction.Sales)
            {
                //if customer not have piutang account
                subAcc = def.DebetSubAccountId;
                if (salesPayment == Payment.Cash)
                {
                    //save to cash
                    SaveTransactionJournal(subAcc, ListOfJournalStatus.Debet, GrandTotalNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text, transactionByTextBox.Text);
                }
                else if (salesPayment == Payment.Credit)
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
                subAcc = def.DebetSubAccountId;
                if (salesPayment == Payment.Credit)
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
                if (salesPayment == Payment.Cash)
                {
                    //add cash journal
                    SaveTransactionJournal(def.DebetSubAccountId, ListOfJournalStatus.Debet, GrandTotalNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text + " ref: " + transactionReferenceFacturTextBox.Text, transactionByTextBox.Text);
                }
                else if (salesPayment == Payment.Credit)
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
                if (salesPayment == Payment.Cash)
                {
                    //add cash journal
                    SaveTransactionJournal(def.KreditSubAccountId, ListOfJournalStatus.Kredit, GrandTotalNumericUpDown.Value, namaTransaksi + transactionFacturTextBox.Text + " ref: " + transactionReferenceFacturTextBox.Text, transactionByTextBox.Text);
                }
                else if (salesPayment == Payment.Credit)
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
            pihutang.PiHutangCreditLong = piHutangCreditLongNumericUpDown.Value;
            pihutang.PiHutangDate = DateTime.Today;
            pihutang.PiHutangDesc = transactionFacturTextBox.Text;
            pihutang.PiHutangDibayar = 0;

            if (piHutangCreditLongNumericUpDown.Visible)
                pihutang.PiHutangJatuhTempo = DateTime.Today.AddDays(Convert.ToDouble(piHutangCreditLongNumericUpDown.Value));
            else
            {
                Apotek.Data.TApotekSetting apoSet = (Apotek.Data.TApotekSetting)DataMaster.GetObjectByProperty(typeof(Apotek.Data.TApotekSetting), Apotek.Data.TApotekSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
                if (apoSet != null)
                    pihutang.PiHutangJatuhTempo = DateTime.Today.AddDays(Convert.ToDouble(apoSet.DefaultPiutangCreditLong));
                else
                    pihutang.PiHutangJatuhTempo = DateTime.Today;
            }

            pihutang.PiHutangJumlah = GrandTotalNumericUpDown.Value;
            pihutang.PiHutangPic = transactionByTextBox.Text;
            pihutang.PiHutangRetur = decimal.Zero;
            pihutang.PiHutangSisa = GrandTotalNumericUpDown.Value;
            pihutang.PiHutangStatus = piHutangStatus.ToString();
            pihutang.SubAccountId = subAcc;
            pihutang.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);

            pihutang.ModifiedBy = lbl_UserName.Text;
            pihutang.ModifiedDate = DateTime.Now;
            DataMaster.SavePersistence(pihutang);
        }

        void SaveTransaction()
        {
            TTransaction t = new TTransaction();
            t.CurrencyId = ListOfCurrency.Rupiah.ToString();
            t.EmployeeId = employeeIdTextBox.Text;
            t.EmployeeId2 = employeeId2TextBox.Text;
            t.GudangId = 1;

            if (trans == ListOfTransaction.Mutation)
            {
                //to gudang
                t.GudangId = Convert.ToInt32(gudangIdToComboBox.SelectedValue);

                //from gudang
                t.TransactionDesk = gudangIdComboBox.SelectedValue.ToString();
            }

            t.TransactionBy = transactionByTextBox.Text;

            if (transactionByNameComboBox.SelectedIndex != -1)
                t.TransactionByName = transactionByNameComboBox.SelectedValue.ToString();

            t.TransactionCommision = decimal.Zero;
            t.TransactionDate = transactionDateDateTimePicker.Value;
            t.TransactionDesc = transactionDescTextBox.Text;

            if (transactionDeskComboBox.SelectedIndex != -1)
                t.TransactionDesk = transactionDeskComboBox.SelectedValue.ToString();

            t.TransactionDisc = decimal.Zero;
            t.TransactionFactur = transactionFacturTextBox.Text;
            t.TransactionGrandTotal = GrandTotalNumericUpDown.Value;
            t.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);

            if (salesPayment == Payment.Cash)
                t.TransactionPaid = GrandTotalNumericUpDown.Value;
            else if (salesPayment == Payment.Credit)
                t.TransactionPaid = decimal.Zero;


            t.TransactionPayment = salesPayment.ToString();
            t.TransactionPotongan = transactionPotonganNumericUpDown.Value;

            if (!string.IsNullOrEmpty(transactionReferenceIdTextBox.Text.Trim()))
                t.TransactionReferenceId = Convert.ToDecimal(transactionReferenceIdTextBox.Text);
            else
                t.TransactionReferenceId = decimal.Zero;

            t.TransactionPpn = ppnNumericUpDown.Value;

            if (salesPayment == Payment.Cash)
                t.TransactionSisa = decimal.Zero;
            else if (salesPayment == Payment.Credit)
                t.TransactionSisa = GrandTotalNumericUpDown.Value;


            t.TransactionStatus = trans.ToString();
            t.TransactionSubTotal = totalSubTotalNumericUpDown.Value;
            t.TransactionUsePpn = transactionUsePpnCheckBox.Checked;

            t.ModifiedBy = lbl_UserName.Text;
            t.ModifiedDate = DateTime.Now;
            DataMaster.SavePersistence(t);
        }

        Payment salesPayment = Payment.Cash;
        enum Payment
        {
            Cash,
            Credit
        }
        decimal costPrice = 0;
        private void SaveTransactionDetail()
        {
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


                det = new TTransactionDetail();
                det.Commission = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[7].Value);

                //if (trans == ListOfTransaction.Sales || trans == ListOfTransaction.ReturSales || trans == ListOfTransaction.Correction)
                //{
                decimal avgPrice = decimal.Zero;
                if (!isPacket)
                {
                    if (item != null)
                    {
                        avgPrice = item.ItemPricePurchaseAvg;
                    }
                }
                else
                {
                    MPacket paket = (MPacket)DataMaster.GetObjectByProperty(typeof(MPacket), MPacket.ColumnNames.PacketId, itemId);
                    if (paket != null)
                    {
                        avgPrice = paket.PacketPriceAvg;
                    }
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
                DataMaster.SavePersistence(det);

                if (trans == ListOfTransaction.Sales && salesPayment == Payment.Cash)
                {
                    ShareCommission(det.Commission, det.IsPacket);
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
                    UpdateStok(det.IsPacket, gudangId, det.ItemId, det.Quantity, AddStok);
                }
            }
        }

        private void ShareCommission(decimal commission, bool isPacket)
        {
            MCommission comm = null;
            if (isPacket)
                comm = (MCommission)DataMaster.GetObjectByProperty(typeof(MCommission), MCommission.ColumnNames.CommissionStatus, ListOfCommission.Puyer.ToString());
            else
                comm = (MCommission)DataMaster.GetObjectByProperty(typeof(MCommission), MCommission.ColumnNames.CommissionStatus, ListOfCommission.Non_Puyer.ToString());

            if (comm != null)
            {
                IList listShareComm = DataMaster.GetListEq(typeof(MCommissionShare), MCommissionShare.ColumnNames.CommissionId, comm.CommissionId);
                MCommissionShare commShare;
                decimal shareValue;

                for (int i = 0; i < listShareComm.Count; i++)
                {
                    commShare = (MCommissionShare)listShareComm[i];
                    shareValue = commShare.ShareValue / 100 * commission;
                    if (commShare.ShareTo == ListOfCommissionShare.Dokter.ToString() && !string.IsNullOrEmpty(employeeIdTextBox.Text))
                        SaveTCommission(commShare.ShareTo, employeeIdTextBox.Text, shareValue);
                    else if (commShare.ShareTo == ListOfCommissionShare.Manager.ToString())
                    {
                        SaveTCommission(commShare.ShareTo, ListOfCommissionShare.Manager.ToString(), shareValue);
                    }
                    else if (commShare.ShareTo == ListOfCommissionShare.Petugas.ToString() && !string.IsNullOrEmpty(employeeId2TextBox.Text))
                    {
                        SaveTCommission(commShare.ShareTo, employeeId2TextBox.Text, shareValue);
                    }
                    else if (commShare.ShareTo == ListOfCommissionShare.Ruang_Apotek.ToString())
                    {
                        SaveTCommission(commShare.ShareTo, ListOfCommissionShare.Ruang_Apotek.ToString(), shareValue);
                    }
                    else if (commShare.ShareTo == ListOfCommissionShare.Ruangan.ToString() && transactionDeskComboBox.SelectedIndex != -1)
                    {
                        SaveTCommission(commShare.ShareTo, transactionDeskComboBox.SelectedValue.ToString(), shareValue);
                    }
                }
            }
        }

        private void SaveTCommission(string shareTo, string pic, decimal shareValue)
        {
            TCommission tcomm = new TCommission();
            tcomm.CommissionDate = DateTime.Today;
            tcomm.CommissionPic = pic;
            tcomm.CommissionValue = shareValue;
            tcomm.ModifiedBy = lbl_UserName.Text;
            tcomm.ModifiedDate = DateTime.Now;
            tcomm.ShareTo = shareTo;
            tcomm.TransactionFacturNo = transactionFacturTextBox.Text;
            tcomm.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);
            DataMaster.SavePersistence(tcomm);
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

            if (transactionByNameComboBox.Visible)
            {
                if (transactionByNameComboBox.SelectedIndex == -1)
                {
                    balloonHelp.Content = "Pilih kategori pelanggan !!";
                    balloonHelp.ShowBalloon(transactionByNameComboBox);
                    transactionByNameComboBox.Focus();
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

            if (!string.IsNullOrEmpty(transactionFacturTextBox.Text.Trim()))
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
                balloonHelp.Content = "Obat harus diisi !!";
                balloonHelp.ShowBalloon(itemIdTextBox);
                itemIdTextBox.Focus();
                return false;
            }
            else
            {
                if (!checkBox_IsPacket.Checked)
                {
                    MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemIdTextBox.Text);
                    if (item == null)
                    {
                        balloonHelp.Content = "Obat " + itemIdTextBox.Text + " tidak ada dalam database. \n Pastikan anda menulis kode yang tepat atau \n pilih item dengan mengklik gambar disamping untuk mencari Obat.";
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
                            if (MessageBox.Show("Stok obat di " + gudangName + " = 0. Anda yakin melanjutkan transaksi?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
                                    if (MessageBox.Show("Stok obat di " + gudangName + " tidak mencukupi untuk transaksi ini. Anda yakin melanjutkan transaksi?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MPacket paket = (MPacket)DataMaster.GetObjectByProperty(typeof(MPacket), MPacket.ColumnNames.PacketId, itemIdTextBox.Text);
                    if (paket == null)
                    {
                        balloonHelp.Content = "Obat puyer " + itemIdTextBox.Text + " tidak ada dalam database. \n Pastikan anda menulis kode yang tepat atau \n pilih item dengan mengklik gambar disamping untuk mencari Obat.";
                        balloonHelp.ShowBalloon(itemIdTextBox);
                        itemIdTextBox.Focus();
                        return false;
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
            if (trans == ListOfTransaction.ReturSales)
                f_SearchTrans = new FormSearchTransaction(ListOfTransaction.Sales);
            else if (trans == ListOfTransaction.ReturPurchase)
                f_SearchTrans = new FormSearchTransaction(ListOfTransaction.Purchase);

            DataGridViewColumn grid_Col;
            //add kolom nama pasien
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = TTransaction.ColumnNames.TransactionDesc;
            grid_Col.HeaderText = "Nama Pasien";
            f_SearchTrans.grid_Search.Columns.Add(grid_Col);

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
            transactionPaymentTextBox.Text = tr.TransactionPayment;
            transactionByTextBox.Text = tr.TransactionBy;
            transactionByTextBox_Validating(null, null);
            transactionByNameComboBox.SelectedValue = tr.TransactionByName;
            transactionDescTextBox.Text = tr.TransactionDesc;
            transactionDeskComboBox.SelectedValue = tr.TransactionDesk;
            employeeIdTextBox.Text = tr.EmployeeId;
            employeeIdTextBox_Validating(null, null);
            employeeId2TextBox.Text = tr.EmployeeId2;
            employeeId2TextBox_Validating(null, null);

            if (tr.TransactionPayment == Payment.Cash.ToString())
                salesPayment = Payment.Cash;
            else if (tr.TransactionPayment == Payment.Credit.ToString())
                salesPayment = Payment.Credit;
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

        int flipflop = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            button_PaymentFlipFlop.Visible = !button_PaymentFlipFlop.Visible;
            flipflop++;
            if (flipflop == 10)
            {
                button_PaymentFlipFlop.Visible = false;
                timer1.Stop();
                MessageBox.Show("Transaksi " + namaTransaksi + " berhasil disimpan", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void employeeIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            ModuleControlSettings.EmployeeValidating(employeeIdTextBox.Text, employeeNameTextBox);
        }

        private void employeeId2TextBox_Validating(object sender, CancelEventArgs e)
        {
            ModuleControlSettings.EmployeeValidating(employeeId2TextBox.Text, employeeName2TextBox);
        }

        private void employeeIdTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(employeeIdTextBox, ListOfSearchWindow.SearchEmployee.ToString(), true);
        }

        private void employeeId2TextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(employeeId2TextBox, ListOfSearchWindow.SearchEmployee.ToString(), true);
        }

        private void employeeIdTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(employeeIdTextBox, ListOfSearchWindow.SearchEmployee.ToString(), false);
        }

        private void employeeId2TextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(employeeId2TextBox, ListOfSearchWindow.SearchEmployee.ToString(), false);
        }
    }
}