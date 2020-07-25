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

using System.Collections;
using Inventori.Data;
using Inventori.Facade;
using Inventori.Forms;
using Inventori.Module;

namespace Inventori.Billiard.Forms
{
    public partial class FormMain : Form
    {
        [STAThread]
        public static void Main(string[] args)
        {
            //this is App entry point
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);  
            Application.Run(new FormLogin());
        }

        private int childFormNumber = 0;
        //private FormBilliard f_Bil = new FormBilliard();

        private bool m_bSaveLayout = true;
        private FormBilliard f_Bil = new FormBilliard();
        private DeserializeDockContent m_deserializeDockContent;

        DataMasterMgtServices DataMaster = new DataMasterMgtServices();

        public FormMain()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.billiard;
            this.Text = AppCode.AssemblyProduct;
            this.WindowState = FormWindowState.Maximized;

            toolStripStatusLabel_CompanyName.Text = "";
            try
            {
                MSetting set = (MSetting)DataMaster.GetObjectByProperty(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
                if (set != null)
                    toolStripStatusLabel_CompanyName.Text = "Registered to : " + set.CompanyName + "        ";
                //f_Bil.Show(dockPanel1);

                m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);

                Extender.SetSchema(dockPanel1, Extender.Schema.VS2005);
            }
            catch (Exception)
            {
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            // Create a new instance of the child form.
            Form childForm = new Form();
            // Make it a child of this MDI form before showing it.
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                // TODO: Add code here to open the file.
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
                // TODO: Add code here to save the current contents of the form to a file.
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //CancelEventArgs ca = new CancelEventArgs(true);
            //Application.Exit();

            //FormClosingEventArgs cl = new FormClosingEventArgs(CloseReason.UserClosing, false);
            //FormMain_FormClosing(this, cl);
            this.Close();
            //}
            //catch (Exception)
            //{
            //}
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard.GetText() or System.Windows.Forms.GetData to retrieve information from the clipboard.
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        //list all available form
        private FormTransaction f_Transaction = new FormTransaction();
        private FormMasterItem f_Item = new FormMasterItem();
        private FormMasterGroup f_Group = new FormMasterGroup();
        private FormMasterCustomer f_Customer = new FormMasterCustomer();
        private FormMasterSupplier f_Supplier = new FormMasterSupplier();
        private FormBilliardListUser f_ListUser = new FormBilliardListUser();
        private FormBackupDatabase f_BackupDB = new FormBackupDatabase();
        private FormRestoreDatabase f_RestoreDB = new FormRestoreDatabase();
        private FormViewReport f_ViewReport = new FormViewReport();
        private FormBilliardSetting f_Setting = new FormBilliardSetting();
        private FormMasterDesk f_Desk = new FormMasterDesk();
        private FormMasterEmployee f_Employee = new FormMasterEmployee();
        private FormDiscountGlobal f_DiscountGlobal = new FormDiscountGlobal();
        private FormAboutBox f_AboutBox = new FormAboutBox();
        private FormChangePassword f_ChangePassword = new FormChangePassword();
        private FormLogin f_Login = new FormLogin();
        private FormClosingDay f_ClosingDay = new FormClosingDay();

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction();
            f_Transaction.lbl_TempTransaction.Text = ListOfTransaction.Sales.ToString();
            f_Transaction.lbl_TempDesk.Text = ListOfDesk.Cafe.ToString();
            f_Transaction.Show(dockPanel1);
        }

        private void OpenFormTransaction()
        {
            if (f_Transaction != null)
            {
                if (!f_Transaction.IsDisposed)
                {
                    //f_Transaction.WindowState = FormWindowState.Normal;
                    //f_Transaction.BringToFront();
                    f_Transaction.Close();
                    f_Transaction = new FormTransaction();
                }
                else
                    f_Transaction = new FormTransaction();
            }
            else
                f_Transaction = new FormTransaction();

            // f_Transaction.MdiParent = this;
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

        private void subItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Group != null)
            {
                if (!f_Group.IsDisposed)
                {
                    //f_Group.WindowState = FormWindowState.Normal;
                    //f_Group.BringToFront();
                    f_Group.Close();
                    f_Group = new FormMasterGroup();
                }
                else
                    f_Group = new FormMasterGroup();
            }
            else
                f_Group = new FormMasterGroup();

            f_Group.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Group.Show(dockPanel1);
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Item != null)
            {
                if (!f_Item.IsDisposed)
                {
                    //f_Item.WindowState = FormWindowState.Normal;
                    //f_Item.BringToFront();
                    f_Item.Close();
                    f_Item = new FormMasterItem();
                }
                else
                    f_Item = new FormMasterItem();
            }
            else
                f_Item = new FormMasterItem();
            f_Item.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Item.Show(dockPanel1);
        }

        private void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Customer != null)
            {
                if (!f_Customer.IsDisposed)
                {
                    //f_Customer.WindowState = FormWindowState.Normal;
                    //f_Customer.BringToFront();
                    f_Customer.Close();
                    f_Customer = new FormMasterCustomer();
                }
                else
                    f_Customer = new FormMasterCustomer();
            }
            else
                f_Customer = new FormMasterCustomer();
            f_Customer.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Customer.Show(dockPanel1);
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Supplier != null)
            {
                if (!f_Supplier.IsDisposed)
                {
                    //f_Supplier.WindowState = FormWindowState.Normal;
                    //f_Supplier.BringToFront();
                    f_Supplier.Close();
                    f_Supplier = new FormMasterSupplier();
                }
                else
                    f_Supplier = new FormMasterSupplier();
            }
            else
                f_Supplier = new FormMasterSupplier();
            f_Supplier.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Supplier.Show(dockPanel1);
        }

        private void penyesuaianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormTransaction();
            f_Transaction.lbl_TempTransaction.Text = ListOfTransaction.Correction.ToString();
            f_Transaction.lbl_TempDesk.Text = ListOfDesk.Cafe.ToString();
            f_Transaction.Show(dockPanel1);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                //string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

                //if (File.Exists(configFile))
                    //dockPanel1.LoadFromXml(configFile, m_deserializeDockContent);
            }
            catch (Exception)
            {
            }
            timer1_Tick(null, null);
            timer1.Start();
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(FormBilliard).ToString())
                return f_Bil;
            else if (persistString == typeof(FormTransaction).ToString())
                return f_Transaction;
            else if (persistString == typeof(FormMasterItem).ToString())
                return f_Item;
            else if (persistString == typeof(FormMasterGroup).ToString())
                return f_Group;
            else if (persistString == typeof(FormMasterCustomer).ToString())
                return f_Customer;
            else if (persistString == typeof(FormMasterSupplier).ToString())
                return f_Supplier;
            else if (persistString == typeof(FormListUser).ToString())
                return f_ListUser;
            else if (persistString == typeof(FormBackupDatabase).ToString())
                return f_BackupDB;
            else if (persistString == typeof(FormRestoreDatabase).ToString())
                return f_RestoreDB;
            //else if (persistString == typeof(FormViewReport).ToString())
            //    return f_ViewReport;
            else if (persistString == typeof(FormBilliardSetting).ToString())
                return f_Setting;
            else if (persistString == typeof(FormMasterDesk).ToString())
                return f_Desk;
            else if (persistString == typeof(FormMasterEmployee).ToString())
                return f_Employee;
            else if (persistString == typeof(FormDiscountGlobal).ToString())
                return f_DiscountGlobal;
            else
                return f_Transaction;
        }

        private void billiardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Bil != null)
            {
                if (!f_Bil.IsDisposed)
                {
                    //f_Bil.WindowState = FormWindowState.Normal;
                    //f_Bil.BringToFront();
                    f_Bil.Close();
                    f_Bil = new FormBilliard();
                }
                else
                    f_Bil = new FormBilliard();
            }
            else
                f_Bil = new FormBilliard();

            f_Bil.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Bil.Show(dockPanel1);
        }

        private IDockContent FindDocument(string text)
        {
            if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text == text)
                        return form as IDockContent;

                return null;
            }
            else
            {
                foreach (IDockContent content in dockPanel1.Documents)
                    if (content.DockHandler.TabText == text)
                        return content;

                return null;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
         
            //MessageBox.Show(e.CloseReason.ToString());
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
                    //try
                    //{
                    //    string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
                    //    if (m_bSaveLayout)
                    //        dockPanel1.SaveAsXml(configFile);
                    //    else if (File.Exists(configFile))
                    //        File.Delete(configFile);
                    //}
                    //catch (Exception)
                    //{
                    //}

                    AutoBackup();
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

        private void AutoBackup()
        {
            MSetting set = (MSetting)DataMaster.GetObjectById(typeof(MSetting), AppCode.AssemblyProduct);

            if (set.AutoBackup)
            {
                if (f_BackupDB != null)
                {
                    if (!f_BackupDB.IsDisposed)
                    {
                        //f_BackupDB.WindowState = FormWindowState.Normal;
                        //f_BackupDB.BringToFront();
                        f_BackupDB.Close();
                        f_BackupDB = new FormBackupDatabase();
                    }
                    else
                        f_BackupDB = new FormBackupDatabase();
                }
                else
                    f_BackupDB = new FormBackupDatabase();

                string BackupFileExtention = "backup";

                f_BackupDB.txt_BackupFile.Text = set.BackupDir + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss.") + BackupFileExtention;
                f_BackupDB.lbl_Auto.Text = set.AutoBackup.ToString();
                f_BackupDB.ShowDialog();
            }
            //e.Cancel = false;

            //Application.Exit();
            //try
            //{
            //    System.Environment.Exit(1);
            //}
            //catch (Exception)
            //{
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel_Time.Text = DateTime.Now.ToString("dd MMMM yyyy  HH:mm");
        }

        private void listUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_ListUser != null)
            {
                if (!f_ListUser.IsDisposed)
                {
                    f_ListUser.Close();
                    f_ListUser = new FormBilliardListUser();
                }
                else
                    f_ListUser = new FormBilliardListUser();
            }
            else
                f_ListUser = new FormBilliardListUser();

            f_ListUser.Show(dockPanel1);
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_BackupDB != null)
            {
                if (!f_BackupDB.IsDisposed)
                {
                    f_BackupDB.Close();
                    f_BackupDB = new FormBackupDatabase();
                }
                else
                    f_BackupDB = new FormBackupDatabase();
            }
            else
                f_BackupDB = new FormBackupDatabase();

            f_BackupDB.Show(dockPanel1);
        }

        private void restoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_RestoreDB != null)
            {
                if (!f_RestoreDB.IsDisposed)
                {
                    f_RestoreDB.Close();
                    f_RestoreDB = new FormRestoreDatabase();
                }
                else
                    f_RestoreDB = new FormRestoreDatabase();
            }
            else
                f_RestoreDB = new FormRestoreDatabase();

            f_RestoreDB.Show(dockPanel1);

        }

        private void daftarItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.MItem.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void settingProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Setting != null)
            {
                if (!f_Setting.IsDisposed)
                {
                    f_Setting.Close();
                    f_Setting = new FormBilliardSetting();
                }
                else
                    f_Setting = new FormBilliardSetting();
            }
            else
                f_Setting = new FormBilliardSetting();

            f_Setting.Show(dockPanel1);

        }

        private void daftarSubItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.MGroup.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void OpenFormReportViewer()
        {
            if (f_ViewReport != null)
            {
                if (!f_ViewReport.IsDisposed)
                {
                    f_ViewReport = new FormViewReport();
                }
                else
                    f_ViewReport = new FormViewReport();
            }
            else
                f_ViewReport = new FormViewReport();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            itemToolStripMenuItem_Click(null, null);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            penjualanToolStripMenuItem_Click(null, null);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            billiardToolStripMenuItem_Click(null, null);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            listUserToolStripMenuItem_Click(null, null);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            settingProgramToolStripMenuItem_Click(null, null);
        }

        private void mejaBilliardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Desk != null)
            {
                if (!f_Desk.IsDisposed)
                {
                    f_Desk.Close();
                    f_Desk = new FormMasterDesk();
                }
                else
                    f_Desk = new FormMasterDesk();
            }
            else
                f_Desk = new FormMasterDesk();

            f_Desk.Show(dockPanel1);
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

        private void karyawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_Employee != null)
            {
                if (!f_Employee.IsDisposed)
                {
                    f_Employee.Close();
                    f_Employee = new FormMasterEmployee();
                }
                else
                    f_Employee = new FormMasterEmployee();
            }
            else
                f_Employee = new FormMasterEmployee();
            f_Employee.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_Employee.Show(dockPanel1);

        }

        private void diskonGlobalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_DiscountGlobal != null)
            {
                if (!f_DiscountGlobal.IsDisposed)
                {
                    f_DiscountGlobal.Close();
                    f_DiscountGlobal = new FormDiscountGlobal();
                }
                else
                    f_DiscountGlobal = new FormDiscountGlobal();
            }
            else
                f_DiscountGlobal = new FormDiscountGlobal();

            f_DiscountGlobal.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_DiscountGlobal.Show(dockPanel1);
        }

       private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_AboutBox != null)
            {
                if (!f_AboutBox.IsDisposed)
                    f_AboutBox.Close();

                f_AboutBox = new FormAboutBox();
            }
            else
                f_AboutBox = new FormAboutBox();

            f_AboutBox.ShowDialog(this);
        }

        private void gantiPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_ChangePassword != null)
            {
                if (!f_ChangePassword.IsDisposed)
                    f_ChangePassword.Close();

                f_ChangePassword = new FormChangePassword();
            }
            else
                f_ChangePassword = new FormChangePassword();
            f_ChangePassword.userNameLabel1.Text = toolStripStatusLabelLoginName.Text;
            f_ChangePassword.ShowDialog(this);
        }

        private void loginToolStripMenuItem_EnabledChanged(object sender, EventArgs e)
        {
            logoutToolStripMenuItem.Enabled = !loginToolStripMenuItem.Enabled;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
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
            if (f_Login != null)
            {
                if (!f_Login.IsDisposed)
                    f_Login.Close();

                f_Login = new FormLogin();
            }
            else
                f_Login = new FormLogin();

            f_Login.ShowDialog(this);
            //if (f_Login.ShowDialog(this) == DialogResult.OK)
            //    loginToolStripMenuItem.Enabled = false;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
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

            toolStripButtonItem.Enabled = ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text,102);
            toolStripButtonSales.Enabled = ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text, 201);
            toolStripButtonBilliard.Enabled = ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text, 206);
            toolStripButtonListUser.Enabled = ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text, 403);
            toolStripButtonSetting.Enabled = ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text, 404);
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
                   //submenu.Text += i.ToString();

                    submenu.Enabled = false;
                    //submenu.OwnerItem.Enabled = false;

                    if (ModuleControlSettings.HavePriviledges(toolStripStatusLabelLoginName.Text,i))
                    {
                        submenu.Enabled = true;
                        submenu.OwnerItem.Enabled = true;
                        //submenu.Owner.Enabled = true;
                    }
                    ShowMenu(submenu);
                }
            }
        }

        private void daftarKaryawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.MEmployee.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void daftarMejaBilliardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormReportViewer();
            f_ViewReport.lbl_TempReport.Text = ListOfReports.MDesk.ToString();
            f_ViewReport.Show(dockPanel1);
        }

        private void tutupHariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_ClosingDay != null)
            {
                if (!f_ClosingDay.IsDisposed)
                {
                    f_ClosingDay.Close();
                    f_ClosingDay = new FormClosingDay();
                }
                else
                    f_ClosingDay = new FormClosingDay();
            }
            else
                f_ClosingDay = new FormClosingDay();

            f_ClosingDay.lbl_UserName.Text = toolStripStatusLabelLoginName.Text;
            f_ClosingDay.Show(dockPanel1);
        }

    }
}
