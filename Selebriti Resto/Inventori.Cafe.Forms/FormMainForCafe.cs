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

namespace Inventori.Cafe.Forms
{
    public partial class FormMainForCafe : Inventori.Forms.FormMain
    {
        public FormMainForCafe()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.cafe1;
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
            //master karyawan
            dataPokokToolStripMenuItem.DropDownItems.Remove(karyawanToolStripMenuItem);
            //master bagian
            dataPokokToolStripMenuItem.DropDownItems.Remove(bagianToolStripMenuItem);

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
            //daftar bagian
            laporanToolStripMenuItem.DropDownItems.Remove(daftarBagianToolStripMenuItem);
            //daftar karyawan
            laporanToolStripMenuItem.DropDownItems.Remove(daftarKaryawanToolStripMenuItem);
            //laporan penjualan
            laporanPenjualanToolStripMenuItem.Click += new EventHandler(laporanPenjualanToolStripMenuItem_Click);
            //laporan retur penjualan
            laporanReturPenjualanToolStripMenuItem.Click += new EventHandler(laporanReturPenjualanToolStripMenuItem_Click);
            //laporan pembelian
            laporanPembelianToolStripMenuItem.Click += new EventHandler(laporanPembelianToolStripMenuItem_Click);
            //laporan retur pembelian
            laporanReturPembelianToolStripMenuItem.Click += new EventHandler(laporanReturPembelianToolStripMenuItem_Click);
            //laporan penyesuain
            laporanPenyesuaianToolStripMenuItem.Click += new EventHandler(laporanPenyesuaianToolStripMenuItem_Click);
            //toolstrip15
            laporanToolStripMenuItem.DropDownItems.Remove(toolStripSeparator15);

            //setting program
            konfigurasiProgramToolStripMenuItem.Click += new EventHandler(konfigurasiProgramToolStripMenuItem_Click);
            toolStripButton_Seting.Click += new EventHandler(konfigurasiProgramToolStripMenuItem_Click);
            //list user
            listUserToolStripMenuItem.Click += new EventHandler(listUserToolStripMenuItem_Click);

            //add click to about
            aboutToolStripMenuItem.Click += new EventHandler(aboutToolStripMenuItem_Click);

            //add separator
            ToolStripSeparator sep = new ToolStripSeparator();
            ToolStripMenuItem menu = new ToolStripMenuItem();

            //dataPokokToolStripMenuItem.DropDownItems.Add(sep);
            //add meja
            menu = new ToolStripMenuItem();
            menu.Text = "Meja";
            menu.Click += new EventHandler(tMeja_Click);
            dataPokokToolStripMenuItem.DropDownItems.Add(menu);

            //add separator
            sep = new ToolStripSeparator();
            transaksiToolStripMenuItem.DropDownItems.Add(sep);

            //add cafe
            menu = new ToolStripMenuItem();
            menu.Text = "Cafe";
            //cafe.Size = new Size(207, 22);
            menu.ShortcutKeys = Keys.F8;
            menu.Image = Properties.Resources.restaurant_cafe;
            menu.Click += new EventHandler(tCafe_Click);
            transaksiToolStripMenuItem.DropDownItems.Add(menu);

            //insert tutup hari
            menu = new ToolStripMenuItem();
            menu.Text = "Tutup Periode";
            menu.Click += new EventHandler(closingPeriode_Click);
            toolToolStripMenuItem.DropDownItems.Insert(0, menu);

            //insert hapus transaksi
            menu = new ToolStripMenuItem();
            menu.Text = "Hapus Transaksi";
            menu.Click += new EventHandler(deleteTransaction_Click);
            toolToolStripMenuItem.DropDownItems.Insert(1, menu);


            //add tool strip cafe
            ToolStripButton_Cafe = new ToolStripButton();
            ToolStripButton_Cafe.Text = "Cafe";
            ToolStripButton_Cafe.Image = Properties.Resources.restaurant_cafe;
            ToolStripButton_Cafe.Click += new EventHandler(tCafe_Click);
            toolStrip.Items.Insert(3, ToolStripButton_Cafe);
        }
        ToolStripButton ToolStripButton_Cafe;


        private FormDeleteTransaction f_DeleteTransaction;
        private void deleteTransaction_Click(object sender, EventArgs e)
        {
            if (f_DeleteTransaction != null)
            {
                if (!f_DeleteTransaction.IsDisposed)
                    f_DeleteTransaction.Close();
            }
            f_DeleteTransaction = new FormDeleteTransaction();

            f_DeleteTransaction.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_DeleteTransaction.Show(dockPanel1);
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

        private FormLoginForCafe f_Login;
        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Login != null)
            {
                if (!f_Login.IsDisposed)
                    f_Login.Close();

                f_Login = new FormLoginForCafe();
            }
            else
                f_Login = new FormLoginForCafe();

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

        private FormCafe f_Cafe;
        private void tCafe_Click(object sender, EventArgs e)
        {
            if (f_Cafe != null)
            {
                if (!f_Cafe.IsDisposed)
                    f_Cafe.Close();
            }

            f_Cafe = new FormCafe();

            f_Cafe.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Cafe.lbl_EmployeeId.Text = toolStripStatusLabelLoginName.Text;
            f_Cafe.Show(dockPanel1);
        }

        private FormAboutBoxForCafe f_About;
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_About != null)
            {
                if (!f_About.IsDisposed)
                    f_About.Close();
            }

            f_About = new FormAboutBoxForCafe();
            f_About.StartPosition = FormStartPosition.CenterScreen;
            f_About.ShowDialog(this);
        }

        private FormSettingForCafe f_Setting;
        private void konfigurasiProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Setting != null)
            {
                if (!f_Setting.IsDisposed)
                    f_Setting.Close();
            }

            f_Setting = new FormSettingForCafe();

            f_Setting.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Setting.Show(dockPanel1);
        }

        private void FormMainForCafe_Load(object sender, EventArgs e)
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
                toolStripStatusLabel_CompanyName.Text = "Demo";
            }
        }

        private void FormMainForCafe_FormClosing(object sender, FormClosingEventArgs e)
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


        int i;
        public void FilterPriviledge()
        {
            i = 0;

            int x = 100;
            for (int j = 2; j < menuStrip.Items.Count - 1; j++)
            {
                i = x * (j - 1);
                ((ToolStripMenuItem)menuStrip.Items[j]).Enabled = false;
                ShowMenu((ToolStripMenuItem)menuStrip.Items[j]);
            }

            toolStripButton_Item.Enabled = ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text, 102, AppCode.AssemblyProduct);
            toolStripButton_Sales.Enabled = ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text, 201, AppCode.AssemblyProduct);
            
            ToolStripButton_Cafe.Enabled = ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text, 206, AppCode.AssemblyProduct);

            toolStripButton_Backup.Enabled = ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text, 402, AppCode.AssemblyProduct);
            toolStripButton_Seting.Enabled = ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text, 404, AppCode.AssemblyProduct);
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
                   // submenu.Text += i.ToString();

                    submenu.Enabled = false;
                    //submenu.OwnerItem.Enabled = false;

                    if (ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text, i, AppCode.AssemblyProduct))
                    {
                        submenu.Enabled = true;
                        submenu.OwnerItem.Enabled = true;
                        //submenu.Owner.Enabled = true;
                    }
                    ShowMenu(submenu);
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
            f_ViewReport.lbl_TempReport.Text = ListOfReports.MGroup.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.MItem.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarPelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.MCustomer.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.MSupplier.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private FormClosingDay f_Close;
        private void closingPeriode_Click(object sender, EventArgs e)
        {
            if (f_Close != null)
            {
                if (!f_Close.IsDisposed)
                    f_Close.Close();
            }
            f_Close = new FormClosingDay();

            f_Close.Show(dockPanel1);
        }

        private void laporanPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportTransactionTotal.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Sales.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanPenyesuaianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportTransactionTotal.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Correction.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanReturPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportTransactionTotal.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.ReturPurchase.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportTransactionTotal.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.Purchase.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanReturPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.ReportTransactionTotal.ToString();
            f_ViewReport.lbl_Param1.Text = ListOfTransaction.ReturSales.ToString();
            f_ViewReport.Show(dockPanel1);
        }
    }
}

