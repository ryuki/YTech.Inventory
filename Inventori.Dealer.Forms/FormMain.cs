using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using DockSample.Customization;

using Inventori.Data;
using Inventori.Facade;
using Inventori.Forms;
using Inventori.Module;

namespace Inventori.Dealer.Forms
{
    public partial class FormMain : Form
    {
        Inventori.Facade.DataMasterMgtServices DataMaster = new Inventori.Facade.DataMasterMgtServices();
        Inventori.Data.MSetting set;

        public FormMain()
        {
            InitializeComponent();
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.Icon = Properties.Resources.favicon;

            try
            {
                set = (Inventori.Data.MSetting)DataMaster.GetObjectByProperty(typeof(Inventori.Data.MSetting), Inventori.Data.MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
                if (set != null)
                    this.Text = AppCode.AssemblyProduct + "-" + set.CompanyName;
                else
                    this.Text = AppCode.AssemblyProduct + "-" + "Demo Version ";

            }
            catch (Exception)
            {
                this.Text = AppCode.AssemblyProduct;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lbl_LoginTime.Text = DateTime.Now.ToString("f");
            try
            {
                Extender.SetSchema(dockPanel1, Extender.Schema.VS2005);
            }
            catch (Exception)
            {
            }
            timer1_Tick(null, null);
            timer1.Start();


            try
            {
                if (set != null)
                    toolStripStatusLabel_CompanyName.Text = set.CompanyName;
                else
                    toolStripStatusLabel_CompanyName.Text = "Demo Version ";

            }
            catch (Exception)
            {
                toolStripStatusLabel_CompanyName.Text = "";
            }

            //if (reminderToolStripMenuItem.Enabled)
            //    reminderToolStripMenuItem.PerformClick();
        }

        private void masukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keluarToolStripMenuItem.Enabled = !masukToolStripMenuItem.Enabled;
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDockContent[] cont = dockPanel1.GetDocuments();
            for (int z = 0; z < cont.Length; z++)
            {
                try
                {
                    dockPanel1.Contents[z].DockHandler.Close();

                }
                catch (Exception)
                {
                }
                try
                {
                    dockPanel1.Contents[z].DockHandler.Hide();
                }
                catch (Exception)
                {
                }

            }

            this.Hide();

            Inventori.Module.ModuleControlSettings.SaveLog(ListOfAction.Logout, string.Empty, ListOfTable.None, toolStripStatusLabelLoginName.Text);
            if (f_Login != null)
            {
                if (!f_Login.IsDisposed)
                    f_Login.Close();

                f_Login = new Inventori.Dealer.Forms.FormLogin();
            }
            else
                f_Login = new Inventori.Dealer.Forms.FormLogin();

            f_Login.ShowDialog(this);
        }

        private Inventori.Dealer.Forms.FormLogin f_Login;


        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        public FormBackupDatabase f_BackupDB;
        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_BackupDB != null)
            {
                if (!f_BackupDB.IsDisposed)
                    f_BackupDB.Close();
            }
            f_BackupDB = new FormBackupDatabase();
            f_BackupDB.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_BackupDB.Show(dockPanel1);
        }

        private FormRestoreDatabase f_RestoreDB;
        private void restoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_RestoreDB != null)
            {
                if (!f_RestoreDB.IsDisposed)
                    f_RestoreDB.Close();
            }
            f_RestoreDB = new FormRestoreDatabase();
            f_RestoreDB.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_RestoreDB.Show(dockPanel1);
        }

        private FormChangePassword f_ChangePassword;
        private void gantiKataKunciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_ChangePassword != null)
            {
                if (!f_ChangePassword.IsDisposed)
                    f_ChangePassword.Close();

            }

            f_ChangePassword = new FormChangePassword();
            f_ChangePassword.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_ChangePassword.userNameLabel1.Text = toolStripStatusLabelLoginName.Text;
            f_ChangePassword.ShowDialog(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel_Time.Text = DateTime.Now.ToString("f");
        }

        public void AutoBackup(string application)
        {
            if (set == null)
                return;

            if (set.AutoBackup)
            {
                if (f_BackupDB != null)
                {
                    if (!f_BackupDB.IsDisposed)
                    {
                        f_BackupDB.Close();
                    }
                }
                f_BackupDB = new FormBackupDatabase();
                f_BackupDB.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
                string BackupFileExtention = "backup";

                f_BackupDB.txt_BackupFile.Text = set.BackupDir + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss.") + BackupFileExtention;
                f_BackupDB.lbl_Auto.Text = set.AutoBackup.ToString();
                f_BackupDB.ShowDialog();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
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

        FormMasterItem f_Item;
        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Item != null)
            {
                if (!f_Item.IsDisposed)
                {
                    f_Item.WindowState = FormWindowState.Normal;
                    f_Item.BringToFront();
                }
                else
                    f_Item = new FormMasterItem();
            }
            else
                f_Item = new FormMasterItem();

            f_Item.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Item.Show(dockPanel1);
        }

        FormMasterCustomer f_Cust;
        private void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Cust != null)
            {
                if (!f_Cust.IsDisposed)
                {
                    f_Cust.WindowState = FormWindowState.Normal;
                    f_Cust.BringToFront();
                }
                else
                    f_Cust = new FormMasterCustomer();
            }
            else
                f_Cust = new FormMasterCustomer();

            f_Cust.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Cust.Show(dockPanel1);
        }

        FormMasterSupplier f_Supp;
        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Supp != null)
            {
                if (!f_Supp.IsDisposed)
                {
                    f_Supp.WindowState = FormWindowState.Normal;
                    f_Supp.BringToFront();
                }
                else
                    f_Supp = new FormMasterSupplier();
            }
            else
                f_Supp = new FormMasterSupplier();

            f_Supp.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Supp.Show(dockPanel1);
        }

        FormSettingForDealer f_Setting;
        private void konfigurasiProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Setting != null)
            {
                if (!f_Setting.IsDisposed)
                {
                    f_Setting.WindowState = FormWindowState.Normal;
                    f_Setting.BringToFront();
                }
                else
                    f_Setting = new FormSettingForDealer();
            }
            else
                f_Setting = new FormSettingForDealer();

            f_Setting.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Setting.Show(dockPanel1);
        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.Sales);
            f_Transaction.Show(dockPanel1);
        }

        private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFormTransaction(ListOfTransaction.Purchase);
            //f_Transaction.Show(dockPanel1);
        }

        private void returPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFormTransaction(ListOfTransaction.ReturSales);
            //f_Transaction.Show(dockPanel1);
        }

        private void returPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFormTransaction(ListOfTransaction.ReturPurchase);
            //f_Transaction.Show(dockPanel1);
        }

        FormReminder f_Reminder;
        private void reminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Reminder != null)
            {
                if (!f_Reminder.IsDisposed)
                {
                    f_Reminder.WindowState = FormWindowState.Normal;
                    f_Reminder.BringToFront();
                }
                else
                    f_Reminder = new FormReminder();
            }
            else
                f_Reminder = new FormReminder();

            f_Reminder.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Reminder.Show(dockPanel1);
            f_Reminder.DockState = DockState.DockLeftAutoHide;
        }

        FormTreeView f_Tree;
        private void treeViewToolStripMenuItem_Click(object sender, EventArgs e)
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

        FormListUser f_ListUser;
        private void listUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_ListUser != null)
            {
                if (!f_ListUser.IsDisposed)
                {
                    f_ListUser.WindowState = FormWindowState.Normal;
                    f_ListUser.BringToFront();
                }
                else
                    f_ListUser = new FormListUser(AppCode.AssemblyProduct);
            }
            else
                f_ListUser = new FormListUser(AppCode.AssemblyProduct);

            f_ListUser.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_ListUser.menuStrip = this.menuStrip;
            f_ListUser.Show(dockPanel1);
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

        FormAbout f_About;
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_About != null)
            {
                if (!f_About.IsDisposed)
                {
                    f_About.WindowState = FormWindowState.Normal;
                    f_About.BringToFront();
                }
                else
                    f_About = new FormAbout();
            }
            else
                f_About = new FormAbout();

            if (set != null)
                f_About.Text = "Registered to : " + set.CompanyName;
            else
                f_About.Text = "Unregistered Version";

            f_About.Show(this);
        }

        FormRegister f_Register;
        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Register != null)
            {
                if (!f_Register.IsDisposed)
                {
                    f_Register.WindowState = FormWindowState.Normal;
                    f_Register.BringToFront();
                }
                else
                    f_Register = new FormRegister();
            }
            else
                f_Register = new FormRegister();

            f_Register.label_Product.Text = AppCode.AssemblyProduct;
            //f_Register.Icon = Properties.Resources.logo_apotek_ico;
            f_Register.textBox_CompanyName.Text = set.CompanyName;
            f_Register.textBox_ProgramID.Text = Application.ProductVersion;
            f_Register.ShowDialog(this);
        }

        private FormViewReport f_ViewReport;
        private void OpenFormViewReport()
        {
            f_ViewReport = new FormViewReport();
            f_ViewReport.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
        }

        FormMasterColour f_Colour;
        private void warnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Colour != null)
            {
                if (!f_Colour.IsDisposed)
                {
                    f_Colour.WindowState = FormWindowState.Normal;
                    f_Colour.BringToFront();
                }
                else
                    f_Colour = new FormMasterColour();
            }
            else
                f_Colour = new FormMasterColour();

            f_Colour.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Colour.Show(dockPanel1);
        }

        FormMasterFinance f_Finance;
        private void financeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Finance != null)
            {
                if (!f_Finance.IsDisposed)
                {
                    f_Finance.WindowState = FormWindowState.Normal;
                    f_Finance.BringToFront();
                }
                else
                    f_Finance = new FormMasterFinance();
            }
            else
                f_Finance = new FormMasterFinance();

            f_Finance.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Finance.Show(dockPanel1);
        }

        FormMasterChannel f_Channel;
        private void channelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Channel != null)
            {
                if (!f_Channel.IsDisposed)
                {
                    f_Channel.WindowState = FormWindowState.Normal;
                    f_Channel.BringToFront();
                }
                else
                    f_Channel = new FormMasterChannel();
            }
            else
                f_Channel = new FormMasterChannel();

            f_Channel.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Channel.Show(dockPanel1);
        }

        FormMasterEmployee f_Employee;
        private void salesmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Employee != null)
            {
                if (!f_Employee.IsDisposed)
                {
                    f_Employee.WindowState = FormWindowState.Normal;
                    f_Employee.BringToFront();
                }
                else
                    f_Employee = new FormMasterEmployee();
            }
            else
                f_Employee = new FormMasterEmployee();

            f_Employee.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Employee.Show(dockPanel1);
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
            //if (set != null)
            //    f_Transaction.companyNameLabel.Text = set.CompanyName;
            f_Transaction.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
        }

        private void pembelianToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.Purchase);
            f_Transaction.Show(dockPanel1);
        }

        private void returPembelianToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.ReturPurchase);
            f_Transaction.Show(dockPanel1);
        }


        private void mutasiStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.Mutation);
            f_Transaction.Show(dockPanel1);
        }

        private void koreksiStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.Correction);
            f_Transaction.Show(dockPanel1);
        }

        #region laporan

        private void laporanPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionDetail;
            f_ViewReport.listOfTransaction = ListOfTransaction.Purchase;
            f_ViewReport.ShowLocationIdPanel = true;
            f_ViewReport.ShowGudangIdPanel = true;
            f_ViewReport.ShowTransactionByPanel = true;
            f_ViewReport.ShowTransactionDatePanel = true;
            f_ViewReport.ShowTransactionDateToPanel = true;
            f_ViewReport.ShowFilterByDatePanel = true;

            f_ViewReport.Show(dockPanel1);
        }

        private void laporanReturPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionDetail;
            f_ViewReport.listOfTransaction = ListOfTransaction.ReturPurchase;
            f_ViewReport.ShowLocationIdPanel = true;
            f_ViewReport.ShowGudangIdPanel = true;
            f_ViewReport.ShowTransactionByPanel = true;
            f_ViewReport.ShowTransactionDatePanel = true;
            f_ViewReport.ShowTransactionDateToPanel = true;
            f_ViewReport.ShowFilterByDatePanel = true;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionDetail;
            f_ViewReport.listOfTransaction = ListOfTransaction.Sales;
            f_ViewReport.ShowLocationIdPanel = true;
            f_ViewReport.ShowGudangIdPanel = true;
            f_ViewReport.ShowTransactionByPanel = true;
            f_ViewReport.ShowTransactionDatePanel = true;
            f_ViewReport.ShowTransactionDateToPanel = true;
            f_ViewReport.ShowFilterByDatePanel = true;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanKoreksiStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionDetail;
            f_ViewReport.listOfTransaction = ListOfTransaction.Correction;
            f_ViewReport.ShowLocationIdPanel = true;
            f_ViewReport.ShowGudangIdPanel = true;
            f_ViewReport.ShowTransactionByPanel = true;
            f_ViewReport.ShowTransactionDatePanel = true;
            f_ViewReport.ShowTransactionDateToPanel = true;
            f_ViewReport.ShowFilterByDatePanel = true;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanMutasiStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionDetail;
            f_ViewReport.listOfTransaction = ListOfTransaction.Mutation;
            f_ViewReport.ShowLocationIdPanel = true;
            f_ViewReport.ShowGudangIdPanel = true;
            f_ViewReport.ShowTransactionByPanel = true;
            f_ViewReport.ShowTransactionDatePanel = true;
            f_ViewReport.ShowTransactionDateToPanel = true;
            f_ViewReport.ShowFilterByDatePanel = true;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanRekapStokPerUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportRecapStockByUnit;
            f_ViewReport.ShowItemIdPanel = true;
            f_ViewReport.ShowColourPanel = true;
            f_ViewReport.ShowNoMesinPanel = true;
            f_ViewReport.ShowNoRangkaPanel = true;
            f_ViewReport.ShowTransactionDatePanel = true;
            f_ViewReport.ShowTransactionDateToPanel = true;
            f_ViewReport.ShowStatusStockPanel = true;
            f_ViewReport.ShowFilterByDatePanel = true;
            f_ViewReport.Show(dockPanel1);
        }


        #endregion

        private void daftarPelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportMasterCustomer;
            f_ViewReport.ShowSearchPanel = false;
            f_ViewReport.Show(dockPanel1);

        }

        private void daftarSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportMasterSupplier;
            f_ViewReport.ShowSearchPanel = false;
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportMasterChannel;
            f_ViewReport.ShowSearchPanel = false;
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarFinanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportMasterFinance;
            f_ViewReport.ShowSearchPanel = false;
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarSalesmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportMasterEmployee;
            f_ViewReport.ShowSearchPanel = false;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanRekapStokPerLokasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportRecapStockByLocation;
            f_ViewReport.ShowGudangIdPanel = true;
            f_ViewReport.ShowLocationIdPanel = true;
            f_ViewReport.ShowItemIdPanel = true;
            f_ViewReport.ShowColourPanel = true;
            f_ViewReport.ShowNoMesinPanel = true;
            f_ViewReport.ShowNoRangkaPanel = true;
            f_ViewReport.ShowTransactionDatePanel = true;
            f_ViewReport.ShowTransactionDateToPanel = true;
            f_ViewReport.ShowStatusStockPanel = true;
            f_ViewReport.ShowFilterByDatePanel = true;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanPiutangFinanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionDetailByFinance;
            f_ViewReport.ShowFilterByDatePanel = true;
            f_ViewReport.ShowTransactionDatePanel = true;
            f_ViewReport.ShowTransactionDateToPanel = true;
            f_ViewReport.listOfTransaction = ListOfTransaction.Sales;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanRekapPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionRecap;
            f_ViewReport.ShowFilterByDatePanel = true;
            f_ViewReport.ShowTransactionDatePanel = true;
            f_ViewReport.ShowTransactionDateToPanel = true;
            f_ViewReport.listOfTransaction = ListOfTransaction.Sales;
            f_ViewReport.Show(dockPanel1);
        }

        FormPayment f_Payment;
        private void pembayaranPiutangFinanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Payment != null)
            {
                if (!f_Payment.IsDisposed)
                {
                    f_Payment.WindowState = FormWindowState.Normal;
                    f_Payment.BringToFront();
                }
                else
                    f_Payment = new FormPayment();
            }
            else
                f_Payment = new FormPayment();

            f_Payment.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Payment.Show(dockPanel1);
        }

        FormStock f_Stock;
        private void daftarStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Stock != null)
            {
                if (!f_Stock.IsDisposed)
                {
                    f_Stock.WindowState = FormWindowState.Normal;
                    f_Stock.BringToFront();
                }
                else
                    f_Stock = new FormStock();
            }
            else
                f_Stock = new FormStock();

            f_Stock.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Stock.Show(dockPanel1);
        }

        private void laporanRekapSisaStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportRecapSisaStock;
            f_ViewReport.ShowItemIdPanel = true;
            f_ViewReport.ShowTransactionDatePanel = true;
            f_ViewReport.ShowTransactionDateToPanel = true;
            //f_ViewReport.ShowFilterByDatePanel = true;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanRekapPiutangFinanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionRecapByFinance;
            f_ViewReport.ShowFilterByDatePanel = true;
            f_ViewReport.ShowTransactionDatePanel = true;
            f_ViewReport.ShowTransactionDateToPanel = true;
            f_ViewReport.listOfTransaction = ListOfTransaction.Sales;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanRekapPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportPurchaseRecap;
            f_ViewReport.ShowFilterByDatePanel = true;
            f_ViewReport.ShowTransactionDatePanel = true;
            f_ViewReport.ShowTransactionDateToPanel = true;
            f_ViewReport.listOfTransaction = ListOfTransaction.Purchase;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanRekapPembelianPerTypeUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportPurchaseRecapByItem;
            f_ViewReport.ShowFilterByDatePanel = true;
            f_ViewReport.ShowTransactionDatePanel = true;
            f_ViewReport.ShowTransactionDateToPanel = true;
            f_ViewReport.listOfTransaction = ListOfTransaction.Purchase;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanRekapPenjualanPerSalesmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionRecapBySalesman;
            f_ViewReport.ShowFilterByDatePanel = true;
            f_ViewReport.ShowTransactionDatePanel = true;
            f_ViewReport.ShowTransactionDateToPanel = true;
            f_ViewReport.listOfTransaction = ListOfTransaction.Sales;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanRekapPenjualanPerChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionRecapByChannel;
            f_ViewReport.ShowFilterByDatePanel = true;
            f_ViewReport.ShowTransactionDatePanel = true;
            f_ViewReport.ShowTransactionDateToPanel = true;
            f_ViewReport.listOfTransaction = ListOfTransaction.Sales;
            f_ViewReport.Show(dockPanel1);
        }

        FormChangePrice f_ChangePrice;
        private void changePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_ChangePrice != null)
            {
                if (!f_ChangePrice.IsDisposed)
                {
                    f_ChangePrice.WindowState = FormWindowState.Normal;
                    f_ChangePrice.BringToFront();
                }
                else
                    f_ChangePrice = new FormChangePrice();
            }
            else
                f_ChangePrice = new FormChangePrice();

            f_ChangePrice.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_ChangePrice.Show(dockPanel1);
        }

    }
}
