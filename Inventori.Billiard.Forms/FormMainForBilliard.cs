using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.Data;
using Inventori.Facade;
using Inventori.Forms;
using Inventori.Module;

namespace Inventori.Billiard.Forms
{
    public partial class FormMainForBilliard : Inventori.Forms.FormMain
    {
        public FormMainForBilliard()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.billiard;
            this.Text = AppCode.AssemblyProduct;

            //master golongan item
            subItemToolStripMenuItem.Click += new EventHandler(subItemToolStripMenuItem_Click);
            //master item
            itemToolStripMenuItem.Click += new EventHandler(itemToolStripMenuItem_Click);
            toolStripButton_Item.Click += new EventHandler(itemToolStripMenuItem_Click);
            //master customer
            pelangganToolStripMenuItem.Click += new EventHandler(pelangganToolStripMenuItem_Click);
            //master supplier
            supplierToolStripMenuItem.Click += new EventHandler(supplierToolStripMenuItem_Click);
            ////master karyawan
            //karyawanToolStripMenuItem.Click += new EventHandler(karyawanToolStripMenuItem_Click);
            ////master bagian
            //bagianToolStripMenuItem.Click += new EventHandler(bagianToolStripMenuItem_Click);
            dataPokokToolStripMenuItem.DropDownItems.Remove(karyawanToolStripMenuItem);
            dataPokokToolStripMenuItem.DropDownItems.Remove(bagianToolStripMenuItem);
            dataPokokToolStripMenuItem.DropDownItems.Remove(toolStripSeparator3);

            //log out 
            keluarToolStripMenuItem.Click += new EventHandler(keluarToolStripMenuItem_Click);

            //set transaction click even
            //penjualan
            penjualanToolStripMenuItem.Click += new EventHandler(penjualanToolStripMenuItem_Click);
            toolStripButton_Sales.Click += new EventHandler(penjualanToolStripMenuItem_Click);
            //retur penjualan
            returPenjualanToolStripMenuItem.Click += new EventHandler(returPenjualanToolStripMenuItem_Click);
            //pembelian
            pembelianToolStripMenuItem.Click += new EventHandler(pembelianToolStripMenuItem_Click);
            //retur pembelian
            returPembelianToolStripMenuItem.Click += new EventHandler(returPembelianToolStripMenuItem_Click);
            //penyesuaian
            penyesuaianToolStripMenuItem.Click += new EventHandler(penyesuaianToolStripMenuItem_Click);

            //daftar golongan item
            daftarSubItemToolStripMenuItem.Click += new EventHandler(daftarSubItemToolStripMenuItem_Click);
            //daftar item
            daftarItemToolStripMenuItem.Click += new EventHandler(daftarItemToolStripMenuItem_Click);
            //daftar pelanggan
            daftarPelangganToolStripMenuItem.Click += new EventHandler(daftarPelangganToolStripMenuItem_Click);
            //daftar supplier
            daftarSupplierToolStripMenuItem.Click += new EventHandler(daftarSupplierToolStripMenuItem_Click);
            ////daftar bagian
            //daftarBagianToolStripMenuItem.Click += new EventHandler(daftarBagianToolStripMenuItem_Click);
            ////daftar karyawan
            //daftarKaryawanToolStripMenuItem.Click += new EventHandler(daftarKaryawanToolStripMenuItem_Click);
            ////daftar departemen
            laporanToolStripMenuItem.DropDownItems.Remove(toolStripSeparator15);
            laporanToolStripMenuItem.DropDownItems.Remove(daftarBagianToolStripMenuItem);
            laporanToolStripMenuItem.DropDownItems.Remove(daftarKaryawanToolStripMenuItem);

            ToolStripMenuItem menu = new ToolStripMenuItem();
            menu.Text = "Laporan Kartu Stok";
            menu.Click += new EventHandler(laporanKartuStok_Click);
            laporanToolStripMenuItem.DropDownItems.Insert(2, menu);

            //laporan penjualan per item
            laporanPenjualanToolStripMenuItem.Text = "Laporan Total Penjualan Per Item";
            laporanPenjualanToolStripMenuItem.Click += new EventHandler(laporanPenjualanToolStripMenuItem_Click);

            //laporan penjualan vip per item
            laporanPenjualanVIPByItem = new ToolStripMenuItem();
            laporanPenjualanVIPByItem.Text = "Laporan Total Penjualan VIP Per Item";
            laporanPenjualanVIPByItem.Click += new EventHandler(laporanPenjualanVIPByItem_Click);
            penjualanToolStripMenuItem1.DropDownItems.Insert(1, laporanPenjualanVIPByItem);

            //laporan penjualan per meja
            laporanPenjualanByDesk = new ToolStripMenuItem();
            laporanPenjualanByDesk.Text = "Laporan Total Penjualan Per Meja";
            laporanPenjualanByDesk.Click += new EventHandler(laporanPenjualanByDesk_Click);
            penjualanToolStripMenuItem1.DropDownItems.Insert(2, laporanPenjualanByDesk);

            //laporan penjualan VIP per meja
            laporanPenjualanVIPByDesk = new ToolStripMenuItem();
            laporanPenjualanVIPByDesk.Text = "Laporan Total Penjualan VIP Per Meja";
            laporanPenjualanVIPByDesk.Click += new EventHandler(laporanPenjualanVIPByDesk_Click);
            penjualanToolStripMenuItem1.DropDownItems.Insert(3, laporanPenjualanVIPByDesk);

            //laporan detail penjualan
            laporanPenjualanDetail = new ToolStripMenuItem();
            laporanPenjualanDetail.Text = "Laporan Detail Penjualan";
            laporanPenjualanDetail.Click += new EventHandler(laporanPenjualanDetail_Click);
            penjualanToolStripMenuItem1.DropDownItems.Insert(4, laporanPenjualanDetail);

            //laporan detail penjualan VIP
            laporanPenjualanVIPDetail = new ToolStripMenuItem();
            laporanPenjualanVIPDetail.Text = "Laporan Detail Penjualan VIP";
            laporanPenjualanVIPDetail.Click += new EventHandler(laporanPenjualanVIPDetail_Click);
            penjualanToolStripMenuItem1.DropDownItems.Insert(5, laporanPenjualanVIPDetail);

            //laporan rekap penjualan
            menu = new ToolStripMenuItem();
            menu.Text = "Laporan Rekap Penjualan";
            menu.Click += new EventHandler(laporanRekapPenjualan_Click);
            penjualanToolStripMenuItem1.DropDownItems.Insert(6, menu);

            //laporan rekap penjualan vip
            menu = new ToolStripMenuItem();
            menu.Text = "Laporan Rekap Penjualan VIP";
            menu.Click += new EventHandler(laporanRekapPenjualanVIP_Click);
            //penjualanToolStripMenuItem1.DropDownItems.Insert(7, menu);

            //laporan rekap penjualan meja
            menu = new ToolStripMenuItem();
            menu.Text = "Laporan Rekap Penjualan Per Meja";
            menu.Click += new EventHandler(laporanRekapPenjualanMeja_Click);
            penjualanToolStripMenuItem1.DropDownItems.Insert(7, menu);

            //laporan rekap penjualan barang
            menu = new ToolStripMenuItem();
            menu.Text = "Laporan Rekap Penjualan Per Barang";
            menu.Click += new EventHandler(laporanRekapPenjualanBarang_Click);
            penjualanToolStripMenuItem1.DropDownItems.Insert(8, menu);


            //laporan retur penjualan
            laporanReturPenjualanToolStripMenuItem.Text = "Laporan Total Retur Penjualan Per Item";
            laporanReturPenjualanToolStripMenuItem.Click += new EventHandler(laporanReturPenjualanToolStripMenuItem_Click);

            //laporan detail retur penjualan
            laporanReturPenjualanDetail = new ToolStripMenuItem();
            laporanReturPenjualanDetail.Text = "Laporan Detail Retur Penjualan";
            laporanReturPenjualanDetail.Click += new EventHandler(laporanReturPenjualanDetail_Click);
            penjualanToolStripMenuItem1.DropDownItems.Insert(10, laporanReturPenjualanDetail);

            //laporan pembelian
            laporanPembelianToolStripMenuItem.Text = "Laporan Total Pembelian Per Item";
            laporanPembelianToolStripMenuItem.Click += new EventHandler(laporanPembelianToolStripMenuItem_Click);

            //laporan detail pembelian
            laporanPembelianDetail = new ToolStripMenuItem();
            laporanPembelianDetail.Text = "Laporan Detail Pembelian";
            laporanPembelianDetail.Click += new EventHandler(laporanPembelianDetail_Click);
            pembelianToolStripMenuItem1.DropDownItems.Insert(1, laporanPembelianDetail);

            //laporan retur pembelian
            laporanReturPembelianToolStripMenuItem.Text = "Laporan Total Retur Pembelian Per Item";
            laporanReturPembelianToolStripMenuItem.Click += new EventHandler(laporanReturPembelianToolStripMenuItem_Click);

            //laporan detail pembelian
            laporanReturPembelianDetail = new ToolStripMenuItem();
            laporanReturPembelianDetail.Text = "Laporan Detail Retur Pembelian";
            laporanReturPembelianDetail.Click += new EventHandler(laporanReturPembelianDetail_Click);
            pembelianToolStripMenuItem1.DropDownItems.Insert(3, laporanReturPembelianDetail);


            //laporan penyesuaian
            laporanPenyesuaianToolStripMenuItem.Text = "Penyesuaian";
            //laporanPenyesuaianToolStripMenuItem.Click +=new EventHandler(laporanPenyesuaianToolStripMenuItem_Click);

            //laporan penyesuaian per item
            laporanPenyesuaianByItem = new ToolStripMenuItem();
            laporanPenyesuaianByItem.Text = "Laporan Total Penyesuaian Per Item";
            laporanPenyesuaianByItem.Click += new EventHandler(laporanPenyesuaianByItem_Click);
            laporanPenyesuaianToolStripMenuItem.DropDownItems.Add(laporanPenyesuaianByItem);

            //laporan detail penyesuaian 
            laporanPenyesuaianDetail = new ToolStripMenuItem();
            laporanPenyesuaianDetail.Text = "Laporan Detail Penyesuaian";
            laporanPenyesuaianDetail.Click += new EventHandler(laporanPenyesuaianDetail_Click);
            laporanPenyesuaianToolStripMenuItem.DropDownItems.Add(laporanPenyesuaianDetail);

            ////laporan rekap komisi wasit
            //laporanRekapKomisiWasit = new ToolStripMenuItem();
            //laporanRekapKomisiWasit.Text = "Laporan Rekap Komisi Wasit";
            //laporanRekapKomisiWasit.Click += new EventHandler(laporanRekapKomisiWasit_Click);
            //laporanToolStripMenuItem.DropDownItems.Add(laporanRekapKomisiWasit);

            //setting program
            konfigurasiProgramToolStripMenuItem.Click += new EventHandler(konfigurasiProgramToolStripMenuItem_Click);
            toolStripButton_Seting.Click += new EventHandler(konfigurasiProgramToolStripMenuItem_Click);
            //list user
            listUserToolStripMenuItem.Click += new EventHandler(listUserToolStripMenuItem_Click);

            //add click to about
            aboutToolStripMenuItem.Click += new EventHandler(aboutToolStripMenuItem_Click);

            //add separator
            ToolStripSeparator sep = new ToolStripSeparator();
            menu = new ToolStripMenuItem();

            dataPokokToolStripMenuItem.DropDownItems.Add(sep);
            //add meja
            menu = new ToolStripMenuItem();
            menu.Text = "Meja Billiard";
            menu.Click += new EventHandler(tMeja_Click);
            dataPokokToolStripMenuItem.DropDownItems.Add(menu);

            //add separator
            sep = new ToolStripSeparator();
            transaksiToolStripMenuItem.DropDownItems.Add(sep);

            //add Billiard
            ToolStripMenuItem_Billiard = new ToolStripMenuItem();
            ToolStripMenuItem_Billiard.Text = "Billiard";
            ToolStripMenuItem_Billiard.Image = Properties.Resources.BilliardImage;
            ToolStripMenuItem_Billiard.ShortcutKeys = Keys.F8;
            ToolStripMenuItem_Billiard.Click += new EventHandler(tBilliard_Click);
            transaksiToolStripMenuItem.DropDownItems.Add(ToolStripMenuItem_Billiard);

            //insert tutup hari
            menu = new ToolStripMenuItem();
            menu.Text = "Hapus Transaksi";
            menu.Click += new EventHandler(closingDay_Click);
            toolToolStripMenuItem.DropDownItems.Insert(0, menu);

            //tree view 
            menu = new ToolStripMenuItem();
            menu.Text = "Tree View";
            menu.Visible = false;
            menu.ShortcutKeys = Keys.Shift | Keys.Control | Keys.T;
            menu.Click += new EventHandler(menuTreeView_Click);
            viewMenu.DropDownItems.Add(menu);

            ////insert diskon global
            //sep = new ToolStripSeparator();
            //toolToolStripMenuItem.DropDownItems.Insert(5, sep);
            //menu = new ToolStripMenuItem();
            //menu.Text = "Diskon Global";
            //menu.Click += new EventHandler(discGlobal_Click);
            //toolToolStripMenuItem.DropDownItems.Insert(6, menu);
            //sep = new ToolStripSeparator();
            //toolToolStripMenuItem.DropDownItems.Insert(7, sep);


            //add tool strip Billiard
            ToolStripButton_Billiard = new ToolStripButton();
            ToolStripButton_Billiard.Text = "Billiard";
            ToolStripButton_Billiard.Image = Properties.Resources.BilliardImage;
            ToolStripButton_Billiard.Click += new EventHandler(tBilliard_Click);
            toolStrip.Items.Insert(3, ToolStripButton_Billiard);
        }

        void laporanRekapPenjualanMeja_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportListTransactionDetail.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Sales.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        void laporanRekapPenjualanBarang_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportListTransactionDetailItem.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Sales.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        

        void laporanKartuStok_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportStokCard.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.SalesVIP.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        void laporanRekapPenjualanVIP_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportListTransaction.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.SalesVIP.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        void laporanRekapPenjualan_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportListTransaction.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Sales.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        FormTreeView f_Tree;
        void menuTreeView_Click(object sender, EventArgs e)
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

        //add tool strip Billiard
        ToolStripButton ToolStripButton_Billiard;
        ToolStripMenuItem ToolStripMenuItem_Billiard;
        ToolStripMenuItem laporanPenjualanByDesk;
        ToolStripMenuItem laporanPenjualanVIPByDesk;
        ToolStripMenuItem laporanPenjualanVIPByItem;

        ToolStripMenuItem laporanPenjualanDetail;
        ToolStripMenuItem laporanPenjualanVIPDetail;
        ToolStripMenuItem laporanReturPenjualanDetail;
        ToolStripMenuItem laporanPembelianDetail;
        ToolStripMenuItem laporanReturPembelianDetail;
        ToolStripMenuItem laporanPenyesuaianByItem;
        ToolStripMenuItem laporanPenyesuaianDetail;

        ToolStripMenuItem laporanRekapKomisiWasit;

        private FormMasterDepartment f_Dep;
        private void bagianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Dep != null)
            {
                if (!f_Dep.IsDisposed)
                    f_Dep.Close();
            }
            f_Dep = new FormMasterDepartment();

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

        private FormLoginForBilliard f_Login;
        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Login != null)
            {
                if (!f_Login.IsDisposed)
                    f_Login.Close();

                f_Login = new FormLoginForBilliard();
            }
            else
                f_Login = new FormLoginForBilliard();

            f_Login.ShowDialog(this);
        }

        private FormMasterDesk f_Desk;
        private void tMeja_Click(object sender, EventArgs e)
        {
            if (f_Desk != null)
            {
                if (!f_Desk.IsDisposed)
                    f_Desk.Close();
            }

            f_Desk = new FormMasterDesk();

            f_Desk.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Desk.Show(dockPanel1);
        }

        private FormBilliard f_Billiard;
        private void tBilliard_Click(object sender, EventArgs e)
        {
            if (f_Billiard != null)
            {
                if (!f_Billiard.IsDisposed)
                    f_Billiard.Close();
            }

            f_Billiard = new FormBilliard();

            f_Billiard.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Billiard.Show(dockPanel1);
        }

        private FormAboutBoxForBilliard f_About;
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_About != null)
            {
                if (!f_About.IsDisposed)
                    f_About.Close();
            }

            f_About = new FormAboutBoxForBilliard();
            f_About.StartPosition = FormStartPosition.CenterScreen;
            f_About.ShowDialog(this);
        }

        private FormSettingForBilliard f_Setting;
        private void konfigurasiProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Setting != null)
            {
                if (!f_Setting.IsDisposed)
                    f_Setting.Close();
            }

            f_Setting = new FormSettingForBilliard();

            f_Setting.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Setting.Show(dockPanel1);
        }

        private FormDiscountGlobal f_Disc;
        private void discGlobal_Click(object sender, EventArgs e)
        {
            if (f_Disc != null)
            {
                if (!f_Disc.IsDisposed)
                    f_Disc.Close();
            }
            f_Disc = new FormDiscountGlobal();

            f_Disc.Show(dockPanel1);
        }

        //private FormClosingDay f_Close;
        private FormDeleteTransaction f_DeleteTransaction;
        private void closingDay_Click(object sender, EventArgs e)
        {
            //if (f_Close != null)
            //{
            //    if (!f_Close.IsDisposed)
            //        f_Close.Close();
            //}
            //f_Close = new FormClosingDay();

            //f_Close.Show(dockPanel1);

            if (f_DeleteTransaction != null)
            {
                if (!f_DeleteTransaction.IsDisposed)
                    f_DeleteTransaction.Close();
            }
            f_DeleteTransaction = new FormDeleteTransaction();

            f_DeleteTransaction.Show(dockPanel1);
        }

        private void FormMainForBilliard_Load(object sender, EventArgs e)
        {
            try
            {
                DataMasterMgtServices DataMaster = new DataMasterMgtServices();
                MSetting set = (MSetting)DataMaster.GetObjectByProperty(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
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

        private void FormMainForBilliard_FormClosing(object sender, FormClosingEventArgs e)
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

        private FormTransaction f_Transaction;
        private void OpenFormTransaction()
        {
            if (f_Transaction != null)
            {
                if (!f_Transaction.IsDisposed)
                    f_Transaction.Close();
            }
            f_Transaction = new FormTransaction();
            f_Transaction.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Transaction.lbl_EmployeeId.Text = toolStripStatusLabelLoginName.Text;
        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction();
            f_Transaction.lbl_TempTransaction.Text = ListOfTransaction.Sales.ToString();
            f_Transaction.lbl_TempDesk.Text = ListOfDesk.Cafe.ToString();
            f_Transaction.Show(dockPanel1);
        }

        private void returPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction();
            f_Transaction.lbl_TempTransaction.Text = ListOfTransaction.ReturSales.ToString();
            f_Transaction.lbl_TempDesk.Text = ListOfDesk.Cafe.ToString();
            f_Transaction.Show(dockPanel1);
        }

        private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction();
            f_Transaction.lbl_TempTransaction.Text = ListOfTransaction.Purchase.ToString();
            f_Transaction.lbl_TempDesk.Text = ListOfDesk.Cafe.ToString();

            f_Transaction.Show(dockPanel1);
        }

        private void returPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction();
            f_Transaction.lbl_TempTransaction.Text = ListOfTransaction.ReturPurchase.ToString();
            f_Transaction.lbl_TempDesk.Text = ListOfDesk.Cafe.ToString();
            f_Transaction.Show(dockPanel1);
        }

        private void penyesuaianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction();
            f_Transaction.lbl_TempTransaction.Text = ListOfTransaction.Correction.ToString();
            f_Transaction.lbl_TempDesk.Text = ListOfDesk.Cafe.ToString();
            f_Transaction.Show(dockPanel1);
        }

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
            ToolStripButton_Billiard.Enabled = ToolStripMenuItem_Billiard.Enabled;
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
                    ShowMenu(submenu);
                }
            }
        }

        private FormListUser f_ListUser;
        private void listUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_ListUser != null)
            {
                if (!f_ListUser.IsDisposed)
                    f_ListUser.Close();
            }
            f_ListUser = new FormListUser(AppCode.AssemblyProduct);
            f_ListUser.menuStrip = this.menuStrip;
            f_ListUser.Show(dockPanel1);
        }

        private FormViewReport f_ViewReport;
        private void OpenFormReportViewer()
        {
            //if (f_ViewReport != null)
            //{
            //    if (!f_ViewReport.IsDisposed)
            //        f_ViewReport.Close();
            //}
            f_ViewReport = new FormViewReport();
        }

        private void daftarSubItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfMasterReports.MGroup.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfMasterReports.MItem.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarPelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfMasterReports.MCustomer.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfMasterReports.MSupplier.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarKaryawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfMasterReports.MEmployee.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarBagianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfMasterReports.MDepartment.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.RekapTotalTransactionByItem.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Sales.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanPenyesuaianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.RekapTotalTransactionByItem.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Correction.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanReturPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.RekapTotalTransactionByItem.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.ReturPurchase.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.RekapTotalTransactionByItem.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Purchase.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanReturPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.RekapTotalTransactionByItem.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.ReturSales.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanPenjualanByDesk_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.RekapTotalTransactionByDesk.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Sales.ToString();
            f_ViewReport.Show(dockPanel1);
        }


        private void laporanPenjualanVIPByDesk_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.RekapTotalTransactionByDesk.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.SalesVIP.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanPenjualanVIPByItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.RekapTotalTransactionByItem.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.SalesVIP.ToString();
            f_ViewReport.Show(dockPanel1);
        }


        private void laporanPenyesuaianDetail_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportDetailTransaction.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Correction.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanPenyesuaianByItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.RekapTotalTransactionByItem.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Correction.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanReturPembelianDetail_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportDetailTransaction.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.ReturPurchase.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanPembelianDetail_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportDetailTransaction.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Purchase.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanReturPenjualanDetail_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportDetailTransaction.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.ReturSales.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanPenjualanVIPDetail_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportDetailTransaction.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.SalesVIP.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanPenjualanDetail_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportDetailTransaction.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Sales.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanRekapKomisiWasit_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportRekapKomisiWasit.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Sales.ToString();
            f_ViewReport.Show(dockPanel1);
        }

    }
}

