using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.Module;

namespace Inventori.Contractor.Forms
{
    public partial class FormMain : Inventori.Forms.FormMain
    {
        public FormMain()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.worker_ico;
            this.Text = AppCode.AssemblyProduct;

            //master golongan item
            subItemToolStripMenuItem.Click += new EventHandler(subItemToolStripMenuItem_Click);
            //master item
            itemToolStripMenuItem.Click += new EventHandler(itemToolStripMenuItem_Click);
            toolStripButton_Item.Click += new EventHandler(itemToolStripMenuItem_Click);
            //master customer
            dataPokokToolStripMenuItem.DropDownItems.Remove(pelangganToolStripMenuItem);
            //master supplier
            supplierToolStripMenuItem.Click += new EventHandler(supplierToolStripMenuItem_Click);
            //master karyawan
            karyawanToolStripMenuItem.Click += new EventHandler(karyawanToolStripMenuItem_Click);
            //master bagian
            bagianToolStripMenuItem.Click += new EventHandler(bagianToolStripMenuItem_Click);

            //log out 
            keluarToolStripMenuItem.Click += new EventHandler(keluarToolStripMenuItem_Click);

            toolBarToolStripMenuItem.DropDownItems.Clear();
            //set transaction click even
            //penjualan
            penjualanToolStripMenuItem.Text = "Pemakaian Spare Parts";
            penjualanToolStripMenuItem.Click += new EventHandler(penjualanToolStripMenuItem_Click);
            toolStripButton_Sales.Text = "Pemakaian Spare Parts";
            toolStripButton_Sales.Click += new EventHandler(penjualanToolStripMenuItem_Click);
            //retur penjualan
            returPenjualanToolStripMenuItem.Text = "Order Pembelian";
            returPenjualanToolStripMenuItem.Click += new EventHandler(returPenjualanToolStripMenuItem_Click);
            //pembelian
            pembelianToolStripMenuItem.Click += new EventHandler(pembelianToolStripMenuItem_Click);
            //retur pembelian
            returPembelianToolStripMenuItem.Click += new EventHandler(returPembelianToolStripMenuItem_Click);
            //penyesuaian
            penyesuaianToolStripMenuItem.Click += new EventHandler(penyesuaianToolStripMenuItem_Click);

            //pengguna
            listUserToolStripMenuItem.Click += new EventHandler(listUserToolStripMenuItem_Click);

            //add click to about
            aboutToolStripMenuItem.Click += new EventHandler(aboutToolStripMenuItem_Click);


            //add separator
            ToolStripSeparator sep = new ToolStripSeparator();
            ToolStripMenuItem menu = new ToolStripMenuItem();

            //add separator
            sep = new ToolStripSeparator();
            dataPokokToolStripMenuItem.DropDownItems.Add(sep);

            //bank
            ToolStripMenuItem_Bank = new ToolStripMenuItem();
            ToolStripMenuItem_Bank.Text = "Bank";
            ToolStripMenuItem_Bank.Click += new EventHandler(ToolStripMenuItem_Bank_Click);
            dataPokokToolStripMenuItem.DropDownItems.Add(ToolStripMenuItem_Bank);

            //add separator
            sep = new ToolStripSeparator();
            dataPokokToolStripMenuItem.DropDownItems.Add(sep);

            //Gudang
            ToolStripMenuItem_Gudang = new ToolStripMenuItem();
            ToolStripMenuItem_Gudang.Text = "Gudang";
            ToolStripMenuItem_Gudang.Click += new EventHandler(ToolStripMenuItem_Gudang_Click);
            dataPokokToolStripMenuItem.DropDownItems.Add(ToolStripMenuItem_Gudang);

            //add separator
            sep = new ToolStripSeparator();
            transaksiToolStripMenuItem.DropDownItems.Add(sep);

            //giro
            ToolStripMenuItem_Giro = new ToolStripMenuItem();
            ToolStripMenuItem_Giro.Text = "Giro";
            ToolStripMenuItem_Giro.ShortcutKeys = Keys.Control | Keys.G;
            ToolStripMenuItem_Giro.Click += new EventHandler(ToolStripMenuItem_Giro_Click);
            transaksiToolStripMenuItem.DropDownItems.Add(ToolStripMenuItem_Giro);

            //add separator
            sep = new ToolStripSeparator();
            transaksiToolStripMenuItem.DropDownItems.Add(sep);

            //add ListTransaction
            ToolStripMenuItem_ListTransaction = new ToolStripMenuItem();
            ToolStripMenuItem_ListTransaction.Text = "Daftar Order Pembelian";
            ToolStripMenuItem_ListTransaction.Click += new EventHandler(ToolStripMenuItem_ListTransaction_Click);
            transaksiToolStripMenuItem.DropDownItems.Add(ToolStripMenuItem_ListTransaction);

            //add ListTransaction purchase
            ToolStripMenuItem_ListPurchaseTransaction = new ToolStripMenuItem();
            ToolStripMenuItem_ListPurchaseTransaction.Text = "Daftar Pembelian";
            ToolStripMenuItem_ListPurchaseTransaction.Click += new EventHandler(ToolStripMenuItem_ListPurchaseTransaction_Click);
            transaksiToolStripMenuItem.DropDownItems.Add(ToolStripMenuItem_ListPurchaseTransaction);

            //remove laporan not used
            laporanToolStripMenuItem.DropDownItems.Remove(penjualanToolStripMenuItem1);
            laporanToolStripMenuItem.DropDownItems.Remove(daftarPelangganToolStripMenuItem);

            //daftar golongan item
            daftarSubItemToolStripMenuItem.Click += new EventHandler(daftarSubItemToolStripMenuItem_Click);
            //daftar item
            daftarItemToolStripMenuItem.Click += new EventHandler(daftarItemToolStripMenuItem_Click);
            //daftar supplier
            daftarSupplierToolStripMenuItem.Click += new EventHandler(daftarSupplierToolStripMenuItem_Click);
            //daftar bagian
            laporanToolStripMenuItem.DropDownItems.Remove(daftarBagianToolStripMenuItem);
            //daftar karyawan
            daftarKaryawanToolStripMenuItem.Click += new EventHandler(daftarKaryawanToolStripMenuItem_Click);

            //laporan Pemakaian Spare Parts
            ToolStripMenuItem_LaporanSpareParts = new ToolStripMenuItem();
            ToolStripMenuItem_LaporanSpareParts.Text = "Pemakaian Spare Parts";
            laporanToolStripMenuItem.DropDownItems.Insert(7, ToolStripMenuItem_LaporanSpareParts);

            //laporan Pemakaian Spare Parts per alat
            ToolStripMenuItem_LaporanSparePartsPerAlat = new ToolStripMenuItem();
            ToolStripMenuItem_LaporanSparePartsPerAlat.Text = "Laporan Pemakaian Spare Parts Per Alat";
            ToolStripMenuItem_LaporanSparePartsPerAlat.Click += new EventHandler(ToolStripMenuItem_LaporanSparePartsPerAlat_Click);
            ToolStripMenuItem_LaporanSpareParts.DropDownItems.Add(ToolStripMenuItem_LaporanSparePartsPerAlat);


            //clear laporan pembelian
            pembelianToolStripMenuItem1.DropDownItems.Clear();

            //laporan list order pembelian
            menu = new ToolStripMenuItem();
            menu.Text = "Laporan List Order Pembelian";
            menu.Click += new EventHandler(menuListOrderPurchase_Click);
            pembelianToolStripMenuItem1.DropDownItems.Add(menu);

            //laporan order pembelian per item
            ToolStripMenuItem_LaporanPurchaseOrderPerItem = new ToolStripMenuItem();
            ToolStripMenuItem_LaporanPurchaseOrderPerItem.Text = "Laporan Order Pembelian Per Item";
            ToolStripMenuItem_LaporanPurchaseOrderPerItem.Click += new EventHandler(ToolStripMenuItem_LaporanPurchaseOrderPerItem_Click);
            pembelianToolStripMenuItem1.DropDownItems.Add(ToolStripMenuItem_LaporanPurchaseOrderPerItem);

            //laporan order pembelian per Supplier
            ToolStripMenuItem_LaporanPurchaseOrderPerSupplier = new ToolStripMenuItem();
            ToolStripMenuItem_LaporanPurchaseOrderPerSupplier.Text = "Laporan Order Pembelian Per Supplier";
            ToolStripMenuItem_LaporanPurchaseOrderPerSupplier.Click += new EventHandler(ToolStripMenuItem_LaporanPurchaseOrderPerSupplier_Click);
            pembelianToolStripMenuItem1.DropDownItems.Add(ToolStripMenuItem_LaporanPurchaseOrderPerSupplier);

            //add separator
            sep = new ToolStripSeparator();
            pembelianToolStripMenuItem1.DropDownItems.Add(sep);

            //laporan list pembelian
            menu = new ToolStripMenuItem();
            menu.Text = "Laporan List Pembelian";
            menu.Click += new EventHandler(menuListPurchase_Click);
            pembelianToolStripMenuItem1.DropDownItems.Add(menu);

            //laporan pembelian per item
            ToolStripMenuItem_LaporanPurchasePerItem = new ToolStripMenuItem();
            ToolStripMenuItem_LaporanPurchasePerItem.Text = "Laporan Pembelian Per Item";
            ToolStripMenuItem_LaporanPurchasePerItem.Click += new EventHandler(ToolStripMenuItem_LaporanPurchasePerItem_Click);
            pembelianToolStripMenuItem1.DropDownItems.Add(ToolStripMenuItem_LaporanPurchasePerItem);

            //laporan pembelian per Supplier
            ToolStripMenuItem_LaporanPurchasePerSupplier = new ToolStripMenuItem();
            ToolStripMenuItem_LaporanPurchasePerSupplier.Text = "Laporan Pembelian Per Supplier";
            ToolStripMenuItem_LaporanPurchasePerSupplier.Click += new EventHandler(ToolStripMenuItem_LaporanPurchasePerSupplier_Click);
            pembelianToolStripMenuItem1.DropDownItems.Add(ToolStripMenuItem_LaporanPurchasePerSupplier);

            //laporan pembelian per month
            ToolStripMenuItem_LaporanPurchasePerMonth = new ToolStripMenuItem();
            ToolStripMenuItem_LaporanPurchasePerMonth.Text = "Laporan Pembelian Per Bulan";
            ToolStripMenuItem_LaporanPurchasePerMonth.Click += new EventHandler(ToolStripMenuItem_LaporanPurchasePerMonth_Click);
            pembelianToolStripMenuItem1.DropDownItems.Add(ToolStripMenuItem_LaporanPurchasePerMonth);


            //laporan tagihan pembelian
            menu = new ToolStripMenuItem();
            menu.Text = "Laporan Tagihan";
            menu.Click += new EventHandler(menuReportTagihan_Click);
            pembelianToolStripMenuItem1.DropDownItems.Add(menu);


            //add separator
            sep = new ToolStripSeparator();
            pembelianToolStripMenuItem1.DropDownItems.Add(sep);

            //laporan retur pembelian per item
            ToolStripMenuItem_LaporanPurchaseReturPerItem = new ToolStripMenuItem();
            ToolStripMenuItem_LaporanPurchaseReturPerItem.Text = "Laporan Retur Pembelian Per Item";
            ToolStripMenuItem_LaporanPurchaseReturPerItem.Click += new EventHandler(ToolStripMenuItem_LaporanPurchaseReturPerItem_Click);
            pembelianToolStripMenuItem1.DropDownItems.Add(ToolStripMenuItem_LaporanPurchaseReturPerItem);

            //laporan retur pembelian per Supplier
            ToolStripMenuItem_LaporanPurchaseReturPerSupplier = new ToolStripMenuItem();
            ToolStripMenuItem_LaporanPurchaseReturPerSupplier.Text = "Laporan Retur Pembelian Per Supplier";
            ToolStripMenuItem_LaporanPurchaseReturPerSupplier.Click += new EventHandler(ToolStripMenuItem_LaporanPurchaseReturPerSupplier_Click);
            pembelianToolStripMenuItem1.DropDownItems.Add(ToolStripMenuItem_LaporanPurchaseReturPerSupplier);

            //laporan penyesuaian
            laporanPenyesuaianToolStripMenuItem.Click += new EventHandler(laporanPenyesuaianToolStripMenuItem_Click);

            //laporan Pemakaian giro
            ToolStripMenuItem_LaporanGiro = new ToolStripMenuItem();
            ToolStripMenuItem_LaporanGiro.Text = "Giro";
            laporanToolStripMenuItem.DropDownItems.Add(ToolStripMenuItem_LaporanGiro);

            //laporan giro per bank
            ToolStripMenuItem_LaporanGiroPerBank = new ToolStripMenuItem();
            ToolStripMenuItem_LaporanGiroPerBank.Text = "Laporan Giro Per Bank";
            ToolStripMenuItem_LaporanGiroPerBank.Click += new EventHandler(ToolStripMenuItem_LaporanGiroPerBank_Click);
            ToolStripMenuItem_LaporanGiro.DropDownItems.Add(ToolStripMenuItem_LaporanGiroPerBank);

            //laporan giro per tgl jatuh tempo
            ToolStripMenuItem_LaporanGiroPerMaturityDate = new ToolStripMenuItem();
            ToolStripMenuItem_LaporanGiroPerMaturityDate.Text = "Laporan Giro Per Jatuh Tempo";
            ToolStripMenuItem_LaporanGiroPerMaturityDate.Click += new EventHandler(ToolStripMenuItem_LaporanGiroPerMaturityDate_Click);
            ToolStripMenuItem_LaporanGiro.DropDownItems.Add(ToolStripMenuItem_LaporanGiroPerMaturityDate);


            //laporan giro per tgl jatuh tempo
            ToolStripMenuItem_LaporanGiroPerSupplier = new ToolStripMenuItem();
            ToolStripMenuItem_LaporanGiroPerSupplier.Text = "Laporan Giro Per Supplier";
            ToolStripMenuItem_LaporanGiroPerSupplier.Click += new EventHandler(ToolStripMenuItem_LaporanGiroPerSupplier_Click);
            ToolStripMenuItem_LaporanGiro.DropDownItems.Add(ToolStripMenuItem_LaporanGiroPerSupplier);

            //ToolStripMenuItem_LaporanHistoriPenggguna
            ToolStripMenuItem_LaporanHistoriPenggguna = new ToolStripMenuItem();
            ToolStripMenuItem_LaporanHistoriPenggguna.Text = "Laporan Histori Pengguna";
            ToolStripMenuItem_LaporanHistoriPenggguna.Click += new EventHandler(ToolStripMenuItem_LaporanHistoriPenggguna_Click);
            toolToolStripMenuItem.DropDownItems.Insert(6, ToolStripMenuItem_LaporanHistoriPenggguna);

            //add separator
            sep = new ToolStripSeparator();
            toolToolStripMenuItem.DropDownItems.Insert(7, sep);

            //setting program
            konfigurasiProgramToolStripMenuItem.Click += new EventHandler(konfigurasiProgramToolStripMenuItem_Click);
            toolStripButton_Seting.Click += new EventHandler(konfigurasiProgramToolStripMenuItem_Click);


            //giro
            ToolStripMenuItem menutree = new ToolStripMenuItem();
            menutree.Text = "Giro";
            menutree.ShortcutKeys = Keys.Control | Keys.Shift | Keys.T;
            menutree.Click += new EventHandler(menutree_Click);
            menutree.Visible = false;
            viewMenu.DropDownItems.Add(menutree);
        }

        void ToolStripMenuItem_ListPurchaseTransaction_Click(object sender, EventArgs e)
        {
            if (f_SearchTrans != null)
            {
                if (!f_SearchTrans.IsDisposed)
                    f_SearchTrans.Close();
            }

            f_SearchTrans = new Inventori.Forms.FormSearchTransaction(ListOfTransaction.Purchase);
            f_SearchTrans.grid_Search.ContextMenuStrip = f_SearchTrans.contextMenuStrip_Transaction;
            f_SearchTrans.cetakToolStripMenuItem.Click += new EventHandler(cetakPurchaseToolStripMenuItem_Click);
            f_SearchTrans.hapusTransaksiToolStripMenuItem.Click += new EventHandler(hapusTransaksiToolStripMenuItem_Click);
            f_SearchTrans.editTransaksiToolStripMenuItem.Click += new EventHandler(editTransaksiPurchaseToolStripMenuItem_Click);
            f_SearchTrans.Show(dockPanel1);
        }

        void menuReportTagihan_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportTagihan);
            f_ViewReport.Trans = ListOfTransaction.Purchase;
            f_ViewReport.Param = FormViewReport.ParameterView.Supplier;
            f_ViewReport.EnabledDateFilter = true;
            f_ViewReport.Show(dockPanel1);
        }

        void menuListOrderPurchase_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportListTransaction);
            f_ViewReport.Trans = ListOfTransaction.PurchaseOrder;
            f_ViewReport.Param = FormViewReport.ParameterView.Supplier;
            f_ViewReport.EnabledDateFilter = true;
            f_ViewReport.Show(dockPanel1);
        }

        void menuListPurchase_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportListTransaction);
            f_ViewReport.Trans = ListOfTransaction.Purchase;
            f_ViewReport.Param = FormViewReport.ParameterView.Supplier;
            f_ViewReport.EnabledDateFilter = true;
            f_ViewReport.Show(dockPanel1);
        }

        FormTreeView f_Tree;
        void menutree_Click(object sender, EventArgs e)
        {
            if (f_Tree != null)
            {
                if (!f_Tree.IsDisposed)
                {
                    f_Tree.WindowState = FormWindowState.Normal;
                    f_Tree.BringToFront();
                }
                else
                    f_Tree = new FormTreeView();
            }
            else
                f_Tree = new FormTreeView();

            f_Tree.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Tree.menuStrip = this.menuStrip;
            f_Tree.Show(dockPanel1);
        }

        ToolStripMenuItem ToolStripMenuItem_Giro;
        ToolStripMenuItem ToolStripMenuItem_Bank;
        ToolStripMenuItem ToolStripMenuItem_Gudang;
        ToolStripMenuItem ToolStripMenuItem_LaporanSpareParts;
        ToolStripMenuItem ToolStripMenuItem_LaporanSparePartsPerAlat;
        ToolStripMenuItem ToolStripMenuItem_LaporanGiro;
        ToolStripMenuItem ToolStripMenuItem_LaporanPurchaseOrderPerItem;
        ToolStripMenuItem ToolStripMenuItem_LaporanPurchaseOrderPerSupplier;
        ToolStripMenuItem ToolStripMenuItem_LaporanPurchasePerItem;
        ToolStripMenuItem ToolStripMenuItem_LaporanPurchasePerSupplier;
        ToolStripMenuItem ToolStripMenuItem_LaporanPurchasePerMonth;
        ToolStripMenuItem ToolStripMenuItem_LaporanPurchaseReturPerItem;
        ToolStripMenuItem ToolStripMenuItem_LaporanPurchaseReturPerSupplier;
        ToolStripMenuItem ToolStripMenuItem_LaporanGiroPerBank;
        ToolStripMenuItem ToolStripMenuItem_LaporanGiroPerMaturityDate;
        ToolStripMenuItem ToolStripMenuItem_LaporanGiroPerSupplier;
        ToolStripMenuItem ToolStripMenuItem_ListTransaction;
        ToolStripMenuItem ToolStripMenuItem_ListPurchaseTransaction;
        ToolStripMenuItem ToolStripMenuItem_LaporanHistoriPenggguna;

        int i;
        public void FilterPriviledge()
        {
            i = 0;

            int x = 100;
            for (int j = 2; j < menuStrip.Items.Count - 1; j++)
            {
                i = x * (j - 1);
                ((ToolStripMenuItem)menuStrip.Items[j]).Enabled = ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text, i, AppCode.AssemblyProduct);
                ShowMenu((ToolStripMenuItem)menuStrip.Items[j]);
            }

            toolStripButton_Item.Enabled = itemToolStripMenuItem.Enabled;
            toolStripButton_Sales.Enabled = penjualanToolStripMenuItem.Enabled;

            toolStripButton_Backup.Enabled = backupDatabaseToolStripMenuItem.Enabled;
            toolStripButton_Seting.Enabled = konfigurasiProgramToolStripMenuItem.Enabled;

        }

        private void ShowMenu(ToolStripMenuItem m)
        {
            ToolStripMenuItem submenu;

            foreach (object obj in m.DropDownItems)
            {
                if (obj.GetType() == typeof(ToolStripMenuItem))
                {
                    i++;
                    submenu = (ToolStripMenuItem)obj;

                    submenu.Enabled = ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text, i, AppCode.AssemblyProduct);
                    if (submenu.Enabled)
                        submenu.OwnerItem.Enabled = true;
                    ShowMenu(submenu);
                }
            }
        }


        private Inventori.Forms.FormListUser f_ListUser;
        private void listUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_ListUser != null)
            {
                if (!f_ListUser.IsDisposed)
                    f_ListUser.Close();
            }
            f_ListUser = new Inventori.Forms.FormListUser(AppCode.AssemblyProduct);
            f_ListUser.menuStrip = this.menuStrip;
            f_ListUser.Show(dockPanel1);
        }

        private FormMasterGudang f_Gudang;
        private void ToolStripMenuItem_Gudang_Click(object sender, EventArgs e)
        {
            if (f_Gudang != null)
            {
                if (!f_Gudang.IsDisposed)
                    f_Gudang.Close();
            }
            f_Gudang = new FormMasterGudang();
            f_Gudang.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            //f_ListUser.menuStrip = this.menuStrip;
            f_Gudang.Show(dockPanel1);
        }

        private FormMasterBank f_Bank;
        private void ToolStripMenuItem_Bank_Click(object sender, EventArgs e)
        {
            if (f_Bank != null)
            {
                if (!f_Bank.IsDisposed)
                    f_Bank.Close();
            }
            f_Bank = new FormMasterBank();
            f_Bank.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Bank.Show(dockPanel1);
        }

        private FormMasterDepartment f_Dep;
        private void bagianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Dep != null)
            {
                if (!f_Dep.IsDisposed)
                    f_Dep.Close();
            }
            f_Dep = new FormMasterDepartment();
            f_Dep.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Dep.Show(dockPanel1);
        }

        private FormMasterEmployee f_Employee;
        private void karyawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Employee != null)
            {
                if (!f_Employee.IsDisposed)
                    f_Employee.Close();
            }
            f_Employee = new FormMasterEmployee();
            f_Employee.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Employee.Show(dockPanel1);
        }



        private FormMasterSupplier f_Supplier;
        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Supplier != null)
            {
                if (!f_Supplier.IsDisposed)
                    f_Supplier.Close();
            }
            f_Supplier = new FormMasterSupplier();
            f_Supplier.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Supplier.Show(dockPanel1);
        }

        private FormMasterCustomer f_Customer;
        private void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Customer != null)
            {
                if (!f_Customer.IsDisposed)
                    f_Customer.Close();
            }
            f_Customer = new FormMasterCustomer();
            f_Customer.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Customer.Show(dockPanel1);
        }

        private FormMasterItem f_Item;
        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Item != null)
            {
                if (!f_Item.IsDisposed)
                    f_Item.Close();
            }
            f_Item = new FormMasterItem();
            f_Item.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Item.Show(dockPanel1);
        }

        private FormMasterGroup f_Group;
        private void subItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Group != null)
            {
                if (!f_Group.IsDisposed)
                    f_Group.Close();
            }
            f_Group = new FormMasterGroup();
            f_Group.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Group.Show(dockPanel1);
        }

        private FormLogin f_Login;
        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventori.Module.ModuleControlSettings.SaveLog(ListOfAction.Logout, string.Empty, ListOfTable.None, toolStripStatusLabelLoginName.Text);
            if (f_Login != null)
            {
                if (!f_Login.IsDisposed)
                    f_Login.Close();

                f_Login = new FormLogin();
            }
            else
                f_Login = new FormLogin();

            f_Login.ShowDialog(this);
        }

        private FormAbout f_About;
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_About != null)
            {
                if (!f_About.IsDisposed)
                    f_About.Close();
            }

            f_About = new FormAbout();
            f_About.StartPosition = FormStartPosition.CenterScreen;
            f_About.ShowDialog(this);
        }

        private void FormMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
            {
                e.Cancel = false;
                // return;
                for (int n = 0; n < Application.OpenForms.Count; n++)
                {
                    Application.OpenForms[n].Close();
                }
            }
            else
            {
                if (MessageBox.Show("Anda yakin menutup program?", "Konfirmasi Tutup Program", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    AutoBackup(AppCode.AssemblyProduct);
                    e.Cancel = false;
                    for (int n = 0; n < Application.OpenForms.Count; n++)
                    {
                        Application.OpenForms[n].Close();
                    }
                }
                else
                {
                    this.Show();
                    e.Cancel = true;
                }
            }
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            try
            {
                Inventori.Facade.DataMasterMgtServices DataMaster = new Inventori.Facade.DataMasterMgtServices();
                Inventori.Data.MSetting set = (Inventori.Data.MSetting)DataMaster.GetObjectByProperty(typeof(Inventori.Data.MSetting), Inventori.Data.MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
                if (set != null)
                    toolStripStatusLabel_CompanyName.Text = set.CompanyName;
                else
                    toolStripStatusLabel_CompanyName.Text = "Demo  ";

            }
            catch (Exception)
            {
                toolStripStatusLabel_CompanyName.Text = "";
            }
        }

        private FormTransaction f_Transaction;
        private void OpenFormTransaction(ListOfTransaction trans)
        {
            if (f_Transaction != null)
            {
                if (!f_Transaction.IsDisposed)
                    f_Transaction.Close();
            }
            f_Transaction = new FormTransaction(trans);
            f_Transaction.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
        }

        private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.Purchase);
            f_Transaction.lbl_TempTransaction.Text = ListOfTransaction.Purchase.ToString();
            f_Transaction.lbl_TempDesk.Text = ListOfDesk.Cafe.ToString();

            f_Transaction.Show(dockPanel1);
        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.Usage);
            f_Transaction.lbl_TempTransaction.Text = ListOfTransaction.Usage.ToString();
            //f_Transaction.lbl_TempDesk.Text = ListOfDesk.Cafe.ToString();

            f_Transaction.Show(dockPanel1);
        }

        private void returPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.PurchaseOrder);
            f_Transaction.lbl_TempTransaction.Text = ListOfTransaction.PurchaseOrder.ToString();
            //f_Transaction.lbl_TempDesk.Text = ListOfDesk.Cafe.ToString();

            f_Transaction.Show(dockPanel1);
        }

        private void returPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.ReturPurchase);
            f_Transaction.lbl_TempTransaction.Text = ListOfTransaction.ReturPurchase.ToString();
            //f_Transaction.lbl_TempDesk.Text = ListOfDesk.Cafe.ToString();

            f_Transaction.Show(dockPanel1);
        }

        private void penyesuaianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.Correction);
            f_Transaction.lbl_TempTransaction.Text = ListOfTransaction.Correction.ToString();
            //f_Transaction.lbl_TempDesk.Text = ListOfDesk.Cafe.ToString();

            f_Transaction.Show(dockPanel1);
        }

        FormGiro f_Giro;
        private void ToolStripMenuItem_Giro_Click(object sender, EventArgs e)
        {
            if (f_Giro != null)
            {
                if (!f_Giro.IsDisposed)
                    f_Giro.Close();
            }
            f_Giro = new FormGiro();
            f_Giro.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Giro.Show(dockPanel1);
        }

        Inventori.Forms.FormSearchTransaction f_SearchTrans;
        void ToolStripMenuItem_ListTransaction_Click(object sender, EventArgs e)
        {
            if (f_SearchTrans != null)
            {
                if (!f_SearchTrans.IsDisposed)
                    f_SearchTrans.Close();
            }

            f_SearchTrans = new Inventori.Forms.FormSearchTransaction(ListOfTransaction.PurchaseOrder);
            f_SearchTrans.grid_Search.ContextMenuStrip = f_SearchTrans.contextMenuStrip_Transaction;
            f_SearchTrans.cetakToolStripMenuItem.Click += new EventHandler(cetakToolStripMenuItem_Click);
            f_SearchTrans.hapusTransaksiToolStripMenuItem.Click += new EventHandler(hapusTransaksiToolStripMenuItem_Click);
            f_SearchTrans.editTransaksiToolStripMenuItem.Click += new EventHandler(editTransaksiToolStripMenuItem_Click);
            f_SearchTrans.Show(dockPanel1);
        }

        void editTransaksiPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.Purchase);
            f_Transaction.lbl_TempTransaction.Text = ListOfTransaction.Purchase.ToString();
            f_Transaction.lbl_TempDesk.Text = ListOfDesk.Cafe.ToString();
            f_Transaction.isTransInEdit = true;
            f_Transaction.Show(dockPanel1);
            f_Transaction.txt_TransactionId.Text = f_SearchTrans.grid_Search.CurrentRow.Cells[0].Value.ToString();
            f_Transaction.FillTransaction(Convert.ToDecimal(f_SearchTrans.grid_Search.CurrentRow.Cells[0].Value));
            f_Transaction.FillTransactionDetail(Convert.ToDecimal(f_SearchTrans.grid_Search.CurrentRow.Cells[0].Value), ListOfTransaction.Purchase);
        }

        void editTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.PurchaseOrder);
            f_Transaction.lbl_TempTransaction.Text = ListOfTransaction.PurchaseOrder.ToString();
            f_Transaction.lbl_TempDesk.Text = ListOfDesk.Cafe.ToString();
            f_Transaction.isTransInEdit = true;
            f_Transaction.Show(dockPanel1);
            f_Transaction.txt_TransactionId.Text = f_SearchTrans.grid_Search.CurrentRow.Cells[0].Value.ToString();
            f_Transaction.FillTransaction(Convert.ToDecimal(f_SearchTrans.grid_Search.CurrentRow.Cells[0].Value));
            f_Transaction.FillTransactionDetail(Convert.ToDecimal(f_SearchTrans.grid_Search.CurrentRow.Cells[0].Value), ListOfTransaction.PurchaseOrder);
        }

        private FormDeleteConfirm formDel;
        void hapusTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDel = new FormDeleteConfirm(FormDeleteConfirm.DeletePin.PO);

            if (formDel.ShowDialog(this) == DialogResult.OK)
            {
                Inventori.Facade.DataMasterMgtServices DataMaster = new Inventori.Facade.DataMasterMgtServices();

                Inventori.Data.TTransaction trans = null;

                if (f_SearchTrans.grid_Search.RowCount > 0)
                    trans = (Inventori.Data.TTransaction)DataMaster.GetObjectByProperty(typeof(Inventori.Data.TTransaction), Inventori.Data.TTransaction.ColumnNames.TransactionId, decimal.Parse(f_SearchTrans.grid_Search.CurrentRow.Cells[0].Value.ToString()));
                if (trans != null)
                {
                    DataMaster.Delete(trans);

                    ModuleControlSettings.SaveLog(ListOfAction.Delete, f_SearchTrans.grid_Search.CurrentRow.Cells[0].Value.ToString(), ListOfTable.TTransaction, toolStripStatusLabelLoginName.Text);
                    f_SearchTrans.BindData(null, null);
                    f_SearchTrans.Refresh();
                }
            }
        }

        void cetakPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.TransactionDetail);

            if (f_SearchTrans.grid_Search.RowCount > 0)
                f_ViewReport.DataId = f_SearchTrans.grid_Search.CurrentRow.Cells[0].Value.ToString();
            f_ViewReport.Show();
        }


        void cetakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportPODetailForPrint);

            if (f_SearchTrans.grid_Search.RowCount > 0)
                f_ViewReport.DataId = f_SearchTrans.grid_Search.CurrentRow.Cells[0].Value.ToString();
            f_ViewReport.Show();
        }

        private FormViewReport f_ViewReport;
        private void OpenFormReportViewer(ListOfReports rep)
        {
            //if (f_ViewReport != null)
            //{
            //    if (!f_ViewReport.IsDisposed)
            //        f_ViewReport.Close();
            //}
            f_ViewReport = new FormViewReport(rep);
            f_ViewReport.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
        }

        void ToolStripMenuItem_LaporanPurchaseOrderPerSupplier_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportPOTotalByPIC);
            f_ViewReport.Trans = ListOfTransaction.PurchaseOrder;
            f_ViewReport.Param = FormViewReport.ParameterView.Supplier;
            f_ViewReport.EnabledDateFilter = true;
            f_ViewReport.Show(dockPanel1);
        }

        void ToolStripMenuItem_LaporanPurchaseOrderPerItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportPOTotalByItem);
            f_ViewReport.Trans = ListOfTransaction.PurchaseOrder;
            f_ViewReport.Param = FormViewReport.ParameterView.Supplier;
            f_ViewReport.EnabledDateFilter = true;
            f_ViewReport.Show(dockPanel1);
        }

        void ToolStripMenuItem_LaporanGiroPerSupplier_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportGiro);
            f_ViewReport.GiroGroup = GiroGroupBy.Supplier;
            f_ViewReport.Param = FormViewReport.ParameterView.Currency;
            f_ViewReport.Show(dockPanel1);
        }

        void ToolStripMenuItem_LaporanGiroPerMaturityDate_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportGiro);
            f_ViewReport.GiroGroup = GiroGroupBy.MaturityDate;
            f_ViewReport.Param = FormViewReport.ParameterView.Currency;
            f_ViewReport.Show(dockPanel1);
        }


        void ToolStripMenuItem_LaporanGiroPerBank_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportGiro);
            f_ViewReport.GiroGroup = GiroGroupBy.Bank;
            f_ViewReport.Param = FormViewReport.ParameterView.Currency;
            f_ViewReport.Show(dockPanel1);
        }

        void ToolStripMenuItem_LaporanPurchaseReturPerSupplier_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportTransactionTotalByPIC);
            f_ViewReport.Trans = ListOfTransaction.ReturPurchase;
            f_ViewReport.Param = FormViewReport.ParameterView.Supplier;
            f_ViewReport.EnabledDateFilter = true;
            f_ViewReport.Show(dockPanel1);
        }

        void ToolStripMenuItem_LaporanPurchaseReturPerItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportTransactionTotalByItem);
            f_ViewReport.Trans = ListOfTransaction.ReturPurchase;
            f_ViewReport.Param = FormViewReport.ParameterView.Supplier;
            f_ViewReport.EnabledDateFilter = true;
            f_ViewReport.Show(dockPanel1);
        }

        void ToolStripMenuItem_LaporanPurchasePerSupplier_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportTransactionTotalByPIC);
            f_ViewReport.Trans = ListOfTransaction.Purchase;
            f_ViewReport.Param = FormViewReport.ParameterView.Supplier;
            f_ViewReport.EnabledDateFilter = true;
            f_ViewReport.Show(dockPanel1);
        }

        void ToolStripMenuItem_LaporanPurchasePerMonth_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportTransactionPerMonth);
            f_ViewReport.Trans = ListOfTransaction.Purchase;
            f_ViewReport.Param = FormViewReport.ParameterView.Supplier;
            f_ViewReport.EnabledDateFilter = true;
            f_ViewReport.Show(dockPanel1);
        }

        void ToolStripMenuItem_LaporanPurchasePerItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportTransactionTotalByItem);
            f_ViewReport.Trans = ListOfTransaction.Purchase;
            f_ViewReport.Param = FormViewReport.ParameterView.Supplier;
            f_ViewReport.EnabledDateFilter = true;
            f_ViewReport.Show(dockPanel1);
        }

        void ToolStripMenuItem_LaporanSparePartsPerAlat_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportUsageTotalByAlat);
            f_ViewReport.Trans = ListOfTransaction.Usage;
            f_ViewReport.Param = FormViewReport.ParameterView.Employee;
            f_ViewReport.EnabledDateFilter = true;
            f_ViewReport.Show(dockPanel1);
        }


        void laporanPenyesuaianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportPOTotalByItem);
            f_ViewReport.Trans = ListOfTransaction.Correction;
            f_ViewReport.Param = FormViewReport.ParameterView.Employee;
            f_ViewReport.EnabledDateFilter = true;
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarSubItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.MGroup);
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.MItem);
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.MSupplier);
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarKaryawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.MEmployee);
            f_ViewReport.Show(dockPanel1);
        }

        void ToolStripMenuItem_LaporanHistoriPenggguna_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer(ListOfReports.ReportUserLog);
            f_ViewReport.Param = FormViewReport.ParameterView.User;
            f_ViewReport.EnabledDateFilter = true;
            f_ViewReport.Show(dockPanel1);
        }

        private FormSettingForContractor f_Setting;
        private void konfigurasiProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Setting != null)
            {
                if (!f_Setting.IsDisposed)
                    f_Setting.Close();
            }

            f_Setting = new FormSettingForContractor();

            f_Setting.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Setting.Show(dockPanel1);
        }
    }
}