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

namespace Inventori.MotorKymco.Forms
{
    public partial class FormMain : Form
    {
        Inventori.Facade.DataMasterMgtServices DataMaster = new Inventori.Facade.DataMasterMgtServices();
        Inventori.Data.MSetting set;

        public FormMain()
        {
            InitializeComponent();
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.Icon = Properties.Resources.kymco_logo_ico;

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

            if (pengingatToolStripMenuItem.Enabled)
                pengingatToolStripMenuItem.PerformClick();
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

                f_Login = new FormLoginForKymco();
            }
            else
                f_Login = new FormLoginForKymco();

            f_Login.ShowDialog(this);
        }

        private FormLoginForKymco f_Login;


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

        FormMasterGroup f_Group;
        private void subItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Group != null)
            {
                if (!f_Group.IsDisposed)
                {
                    f_Group.WindowState = FormWindowState.Normal;
                    f_Group.BringToFront();
                }
                else
                    f_Group = new FormMasterGroup();
            }
            else
                f_Group = new FormMasterGroup();

            f_Group.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Group.Show(dockPanel1);
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

        FormMasterEmployee f_Emp;
        private void karyawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Emp != null)
            {
                if (!f_Emp.IsDisposed)
                {
                    f_Emp.WindowState = FormWindowState.Normal;
                    f_Emp.BringToFront();
                }
                else
                    f_Emp = new FormMasterEmployee();
            }
            else
                f_Emp = new FormMasterEmployee();

            f_Emp.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Emp.Show(dockPanel1);
        }

        FormMasterDepartment f_Dep;
        private void bagianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Dep != null)
            {
                if (!f_Dep.IsDisposed)
                {
                    f_Dep.WindowState = FormWindowState.Normal;
                    f_Dep.BringToFront();
                }
                else
                    f_Dep = new FormMasterDepartment();
            }
            else
                f_Dep = new FormMasterDepartment();

            f_Dep.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Dep.Show(dockPanel1);
        }

        FormSettingForKymco f_Setting;
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
                    f_Setting = new FormSettingForKymco();
            }
            else
                f_Setting = new FormSettingForKymco();

            f_Setting.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Setting.Show(dockPanel1);
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
            if (set != null)
                f_Transaction.companyNameLabel.Text = set.CompanyName;
            f_Transaction.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.Sales);
            f_Transaction.Show(dockPanel1);
        }

        private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.Purchase);
            f_Transaction.Show(dockPanel1);
        }

        private void returPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.ReturSales);
            f_Transaction.Show(dockPanel1);
        }

        private void returPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.ReturPurchase);
            f_Transaction.Show(dockPanel1);
        }

        private void koreksiStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.Correction);
            f_Transaction.Show(dockPanel1);
        }

        private void mutasiStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction(ListOfTransaction.Mutation);
            f_Transaction.Show(dockPanel1);
        }

        private FormPiHutangPayment f_PiHutangPayment;
        private void OpenFormPiHutangPayment()
        {
            if (f_PiHutangPayment != null)
            {
                if (!f_PiHutangPayment.IsDisposed)
                    f_PiHutangPayment.Close();
            }
            f_PiHutangPayment = new FormPiHutangPayment();
            if (set != null)
                f_PiHutangPayment.companyNameLabel.Text = set.CompanyName;
            f_PiHutangPayment.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
        }

        private void penerimaanPiutangDagangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormPiHutangPayment();
            f_PiHutangPayment.PiHutang = ListOfPiHutangStatus.Piutang;
            f_PiHutangPayment.Show(dockPanel1);
        }

        private void pembayaranHutangDagangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormPiHutangPayment();
            f_PiHutangPayment.PiHutang = ListOfPiHutangStatus.Hutang;
            f_PiHutangPayment.Show(dockPanel1);
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

        FormAboutKymco f_About;
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
                    f_About = new FormAboutKymco();
            }
            else
                f_About = new FormAboutKymco();

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
            f_Register.Icon = Properties.Resources.kymco_logo_ico;
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

        private void laporanPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.TransactionDetail;
            f_ViewReport.listOfTransaction = ListOfTransaction.Sales;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanReturPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.TransactionDetail;
            f_ViewReport.listOfTransaction = ListOfTransaction.ReturSales;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.TransactionDetail;
            f_ViewReport.listOfTransaction = ListOfTransaction.Purchase;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanReturPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.TransactionDetail;
            f_ViewReport.listOfTransaction = ListOfTransaction.ReturPurchase;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanKoreksiStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.TransactionDetail;
            f_ViewReport.listOfTransaction = ListOfTransaction.Correction;
            f_ViewReport.Show(dockPanel1);
        }

        private void laporanMutasiStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.TransactionDetail;
            f_ViewReport.listOfTransaction = ListOfTransaction.Mutation;
            f_ViewReport.Show(dockPanel1);
        }

        FormReminder f_Reminder;
        private void pengingatToolStripMenuItem_Click(object sender, EventArgs e)
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

        FormClosing f_Closing;
        private void prosesAkhirBulanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Closing != null)
            {
                if (!f_Closing.IsDisposed)
                {
                    f_Closing.WindowState = FormWindowState.Normal;
                    f_Closing.BringToFront();
                }
                else
                    f_Closing = new FormClosing();
            }
            else
                f_Closing = new FormClosing();

            f_Closing.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Closing.Show(dockPanel1);
        }

        private void laporanLabaRugiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportLabaRugi;
            f_ViewReport.Show(dockPanel1);
        }

        FormMasterCustomerGroup f_CustGroup;
        private void kategoriPelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_CustGroup != null)
            {
                if (!f_CustGroup.IsDisposed)
                {
                    f_CustGroup.WindowState = FormWindowState.Normal;
                    f_CustGroup.BringToFront();
                }
                else
                    f_CustGroup = new FormMasterCustomerGroup();
            }
            else
                f_CustGroup = new FormMasterCustomerGroup();

            f_CustGroup.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_CustGroup.Show(dockPanel1);
        }

        private void lapPenjualanPerPelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionByPIC;
            f_ViewReport.listOfTransaction = ListOfTransaction.Sales;
            f_ViewReport.UseDateFilter = true;
            f_ViewReport.Filter = FormViewReport.ParameterFilter.Customer;
            f_ViewReport.Show(dockPanel1);
        }

        private void lapReturPenjPerPelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionByPIC;
            f_ViewReport.listOfTransaction = ListOfTransaction.ReturSales;
            f_ViewReport.UseDateFilter = true;
            f_ViewReport.Filter = FormViewReport.ParameterFilter.Customer;
            f_ViewReport.Show(dockPanel1);
        }

        private void lapPembelianPerSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionByPIC;
            f_ViewReport.listOfTransaction = ListOfTransaction.Purchase;
            f_ViewReport.UseDateFilter = true;
            f_ViewReport.Filter = FormViewReport.ParameterFilter.Supplier;
            f_ViewReport.Show(dockPanel1);
        }

        private void lapReturPembelianPerSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionByPIC;
            f_ViewReport.listOfTransaction = ListOfTransaction.ReturPurchase;
            f_ViewReport.UseDateFilter = true;
            f_ViewReport.Filter = FormViewReport.ParameterFilter.Supplier;
            f_ViewReport.Show(dockPanel1);
        }

        private void lapKoreksiStokPerItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionInternalByItem;
            f_ViewReport.listOfTransaction = ListOfTransaction.Correction;
            f_ViewReport.UseDateFilter = true;
            f_ViewReport.Filter = FormViewReport.ParameterFilter.None;
            f_ViewReport.Show(dockPanel1);
        }

        private void lapMutasiStokPerItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionInternalByItem;
            f_ViewReport.listOfTransaction = ListOfTransaction.Mutation;
            f_ViewReport.UseDateFilter = true;
            f_ViewReport.Filter = FormViewReport.ParameterFilter.None;
            f_ViewReport.Show(dockPanel1);
        }

        private void lapPenjualanPerItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionByItem;
            f_ViewReport.listOfTransaction = ListOfTransaction.Sales;
            f_ViewReport.UseDateFilter = true;
            f_ViewReport.Filter = FormViewReport.ParameterFilter.None;
            f_ViewReport.Show(dockPanel1);
        }

        private void lapReturPenjPerItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionByItem;
            f_ViewReport.listOfTransaction = ListOfTransaction.ReturSales;
            f_ViewReport.UseDateFilter = true;
            f_ViewReport.Filter = FormViewReport.ParameterFilter.None;
            f_ViewReport.Show(dockPanel1);
        }

        private void lapPembelianPerItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionByItem;
            f_ViewReport.listOfTransaction = ListOfTransaction.Purchase;
            f_ViewReport.UseDateFilter = true;
            f_ViewReport.Filter = FormViewReport.ParameterFilter.None;
            f_ViewReport.Show(dockPanel1);
        }

        private void lapReturPembelianPerItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionByItem;
            f_ViewReport.listOfTransaction = ListOfTransaction.ReturPurchase;
            f_ViewReport.UseDateFilter = true;
            f_ViewReport.Filter = FormViewReport.ParameterFilter.None;
            f_ViewReport.Show(dockPanel1);
        }

        private void lapRugiLabaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportLabaRugi;
            f_ViewReport.UseDateFilter = true;
            f_ViewReport.Show(dockPanel1);
        }

        private void lapHutangJatuhTempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportPiHutangDue;
            f_ViewReport.PiHutangStatus = ListOfPiHutangStatus.Hutang;
            f_ViewReport.Show(dockPanel1);
        }

        private void lapPiutangJatuhTempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportPiHutangDue;
            f_ViewReport.PiHutangStatus = ListOfPiHutangStatus.Piutang;
            f_ViewReport.Show(dockPanel1);
        }

        private void lapFakturPajakSederhanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportPajak;
            f_ViewReport.listOfTransaction = ListOfTransaction.Sales;
            f_ViewReport.UseDateFilter = true;
            f_ViewReport.Filter = FormViewReport.ParameterFilter.None;
            f_ViewReport.Show(dockPanel1);
        }

        private void stokItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportStokItem;            
            f_ViewReport.UseDateFilter = false;
            f_ViewReport.UsePeriodFilter = false;
            f_ViewReport.Filter = FormViewReport.ParameterFilter.None;
            f_ViewReport.Show(dockPanel1);
        }

        FormSearchItem f_SerachItem;
        private void pencarianItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_SerachItem != null)
            {
                if (!f_SerachItem.IsDisposed)
                {
                    f_SerachItem.WindowState = FormWindowState.Normal;
                    f_SerachItem.BringToFront();
                }
                else
                    f_SerachItem = new FormSearchItem();
            }
            else
                f_SerachItem = new FormSearchItem();

            f_SerachItem.itemType = 1;
            f_SerachItem.lbl_TempTransaction.Text = ListOfTransaction.Sales.ToString();
            f_SerachItem.btn_Cancel.Visible = false;
            f_SerachItem.btn_OK.Visible = false;
            f_SerachItem.Show(dockPanel1);
        }

        private void kartuStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportStokCard;
            f_ViewReport.UseDateFilter = false;
            f_ViewReport.UsePeriodFilter = false;
            f_ViewReport.Filter = FormViewReport.ParameterFilter.None;
            f_ViewReport.Show(dockPanel1);
        }

        FormService f_Service;
        private void bengkelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Service != null)
            {
                if (!f_Service.IsDisposed)
                {
                    f_Service.WindowState = FormWindowState.Normal;
                    f_Service.BringToFront();
                }
                else
                    f_Service = new FormService();
            }
            else
                f_Service = new FormService();

            f_Service.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Service.Show(dockPanel1);
        }

        FormMasterService f_MasterService;
        private void masterJasaServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_MasterService != null)
            {
                if (!f_MasterService.IsDisposed)
                {
                    f_MasterService.WindowState = FormWindowState.Normal;
                    f_MasterService.BringToFront();
                }
                else
                    f_MasterService = new FormMasterService();
            }
            else
                f_MasterService = new FormMasterService();

            f_MasterService.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_MasterService.Show(dockPanel1);
        }

        private void lapHistoriServicePelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportHistoryServiceCustomer;
            f_ViewReport.UseDateFilter = false;
            f_ViewReport.UsePeriodFilter = false;
            f_ViewReport.Filter = FormViewReport.ParameterFilter.None;
            f_ViewReport.Show(dockPanel1);
        }

        private void lapServiceBengkelPerPelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormViewReport();
            f_ViewReport.listOfReports = ListOfReports.ReportTransactionServiceByPIC;
            f_ViewReport.listOfTransaction = ListOfTransaction.Service;
            f_ViewReport.UseDateFilter = true;
            f_ViewReport.Filter = FormViewReport.ParameterFilter.Customer;
            f_ViewReport.Show(dockPanel1);
        }
    }
}
