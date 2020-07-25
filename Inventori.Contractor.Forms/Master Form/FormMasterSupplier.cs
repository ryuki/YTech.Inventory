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

namespace Inventori.Contractor.Forms
{
    public partial class FormMasterSupplier : Inventori.Forms.FormParentForMasterForm
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MSupplier supp;

        public FormMasterSupplier()
        {
            InitializeComponent();

            DataGridViewColumn grid_Col;
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MSupplier.ColumnNames.SupplierId;
            grid_Col.HeaderText = "Kode Supplier";
            grid_Master.Columns.Add(grid_Col);
            //add kolom nama
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MSupplier.ColumnNames.SupplierName;
            grid_Col.HeaderText = "Nama Supplier";
            grid_Master.Columns.Add(grid_Col);
            //add kolom alamat
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MSupplier.ColumnNames.SupplierAddress;
            grid_Col.HeaderText = "Alamat";
            grid_Master.Columns.Add(grid_Col);
            //add kolom kode
            grid_Col = new DataGridViewColumn();
            grid_Col.CellTemplate = new DataGridViewTextBoxCell();
            grid_Col.DataPropertyName = MSupplier.ColumnNames.SupplierPhone;
            grid_Col.HeaderText = "Telepon";
            grid_Master.Columns.Add(grid_Col);

            bindingSource_Master.PositionChanged += new EventHandler(bindingSource_Master_PositionChanged);

            bindingNavigatorAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);
            bindingNavigatorEditItem.Click += new EventHandler(bindingNavigatorEditItem_Click);
            bindingNavigatorDeleteItem.Click += new EventHandler(bindingNavigatorDeleteItem_Click);
            bindingNavigatorSaveItem.Click += new EventHandler(bindingNavigatorSaveItem_Click);
            bindingNavigatorRefresh.Click += new EventHandler(bindingNavigatorRefresh_Click);
        }

        private void FormMasterSupplier_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.MSupplier, lbl_UserName.Text);
            CreateSupllierAccountTab();
            grid_Master.DataSource = bindingSource_Master;
            bindingSource_Master.Clear();

          BindData();
        }

        private void CreateSupllierAccountTab()
        {
            tabControl_Account.TabPages.Clear();

            TabPage tab;
            Label lbl;
            ComboBox combo;
            TextBox txt;
            string curName;

            Type curs = typeof(ListOfCurrency);
            foreach (string s in Enum.GetNames(curs))
            {
                curName = Enum.Parse(curs, s).ToString();

                tab = new TabPage();
                tab.Name = "tabpages_" + curName;
                tab.Text = "Rekening " + curName;
                tab.UseVisualStyleBackColor = true;

                //add label gudang
                lbl = new Label();
                lbl.Text = "Bank";
                lbl.AutoSize = true;
                lbl.Location = new Point(11, 18);
                tab.Controls.Add(lbl);

                //add combo bank
                combo = new ComboBox();
                combo.Name = "bankIdComboBox" + curName;
                combo.Location = new Point(139, 15);
                combo.DataSource = DataMaster.GetAll(typeof(MBank)); 
                combo.DisplayMember = MBank.ColumnNames.BankName;
                combo.ValueMember = MBank.ColumnNames.BankId;
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                tab.Controls.Add(combo);

                //add label rek atas nama
                lbl = new Label();
                lbl.Text = "Rekening Atas Nama :";
                lbl.AutoSize = true;
                lbl.Location = new Point(11, 45);
                tab.Controls.Add(lbl);

                //add txt rek atas nama
                txt = new TextBox();
                txt.Name = "supplierAccountNameTextBox" + curName;
                txt.Location = new Point(139, 42);
                tab.Controls.Add(txt);

                //add label rek no
                lbl = new Label();
                lbl.Text = "Nomor Rekening :";
                lbl.AutoSize = true;
                lbl.Location = new Point(11, 71);
                tab.Controls.Add(lbl);

                //add txt rek atas nama
                txt = new TextBox();
                txt.Name = "supplierAccountNoTextBox" + curName;
                txt.Location = new Point(139, 68);
                tab.Controls.Add(txt);

                tabControl_Account.TabPages.Add(tab);
            }
        }

        private void BindData()
        {
            IList listMaster = DataMaster.GetAll(typeof(MSupplier));
            if (listMaster.Count > 0)
                bindingSource_Master.DataSource = listMaster;

            bindingSource_Master_PositionChanged(null, null);
            detailControl_KeyDown(null, null);
        }

        private void bindingSource_Master_PositionChanged(object sender, EventArgs e)
        {
            SetNavigatorDisplay();

            mSupplierAccountBindingSource.Clear();
            IList listAccount = DataMaster.GetListEq(typeof(MSupplierAccount), MSupplierAccount.ColumnNames.SupplierId, supplierIdTextBox.Text);
            if (listAccount.Count > 0)
                mSupplierAccountBindingSource.DataSource = listAccount;

            SetAccountTab(false);
        }

        private void SetAccountTab(bool isNew)
        {
            TabPage tab;
            ComboBox combo;
            TextBox txt;
            string curName;
            MSupplierAccount supAcc;

            Type curs = typeof(ListOfCurrency);
            foreach (string s in Enum.GetNames(curs))
            {
                curName = Enum.Parse(curs, s).ToString();
                supAcc = (MSupplierAccount)DataMaster.GetObjectByProperty(typeof(MSupplierAccount), MSupplierAccount.ColumnNames.SupplierId, supplierIdTextBox.Text, MSupplierAccount.ColumnNames.CurrencyId, curName);
                if (supAcc == null)
                    supAcc = new MSupplierAccount();

                tab = tabControl_Account.TabPages["tabpages_" + curName];

                //combo bank
                combo = (ComboBox)tab.Controls["bankIdComboBox" + curName];
                combo.SelectedValue = supAcc.BankId;

                //txt rek atas nama
                txt = (TextBox)tab.Controls["supplierAccountNameTextBox" + curName];
                txt.Text = supAcc.SupplierAccountName;

                //txt rek atas nama
                txt = (TextBox)tab.Controls["supplierAccountNoTextBox" + curName];
                txt.Text = supAcc.SupplierAccountNo;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            supplierIdTextBox.Enabled = true;
            detailControl_KeyDown(null, null);
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            supplierIdTextBox.Enabled = false;
            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            detailControl_KeyDown(supplierIdTextBox, key);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(supplierIdTextBox.Text.Trim()))
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    supp = (MSupplier)DataMaster.GetObjectById(typeof(MSupplier), supplierIdTextBox.Text);
                    DataMaster.Delete(supp);

                    IList listAcc = DataMaster.GetListEq(typeof(MSupplierAccount), MSupplierAccount.ColumnNames.SupplierId, supplierIdTextBox.Text);
                    MSupplierAccount suppAcc;
                    for (int i = 0; i < listAcc.Count; i++)
                    {
                        suppAcc = (MSupplierAccount)listAcc[i];
                        if (suppAcc != null)
                            DataMaster.Delete(suppAcc);
                    }

                    ModuleControlSettings.SaveLog(ListOfAction.Delete, supplierIdTextBox.Text, ListOfTable.MSupplier, lbl_UserName.Text);
                    BindData();

                }
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (supplierIdTextBox.Enabled == true)
                supp = new MSupplier();
            else
                supp = (MSupplier)DataMaster.GetObjectById(typeof(MSupplier), supplierIdTextBox.Text);

            supp.SupplierContact = supplierContactTextBox.Text;
            supp.SupplierContactPhone = supplierContactPhoneTextBox.Text;
            supp.SupplierId = supplierIdTextBox.Text;
            supp.SupplierName = supplierNameTextBox.Text;
            supp.SupplierPhone = supplierPhoneTextBox.Text;
            supp.SupplierAddress = supplierAddressTextBox.Text;
            supp.ModifiedBy = lbl_UserName.Text;
            supp.ModifiedDate = DateTime.Now;

            if (supplierIdTextBox.Enabled == true)
            {
                try
                {
                    DataMaster.SavePersistence(supp);
                }
                catch (NHibernate.NonUniqueObjectException)
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Supplier dengan kode " + supplierIdTextBox.Text + " sudah pernah diinput, silahkan input dengan kode yang lain";
                    balloonHelp.ShowBalloon(supplierIdTextBox);
                    supplierIdTextBox.Focus();
                    return;
                }
                ModuleControlSettings.SaveLog(ListOfAction.Insert, supplierIdTextBox.Text, ListOfTable.MSupplier, lbl_UserName.Text);
            }
            else
            {
                DataMaster.UpdatePersistence(supp);
                ModuleControlSettings.SaveLog(ListOfAction.Update, supplierIdTextBox.Text, ListOfTable.MSupplier, lbl_UserName.Text);
            }
            SaveSupplierAccount();
            BindData();
        }

        private void SaveSupplierAccount()
        {
            TabPage tab;
            ComboBox combo;
            TextBox txt;
            string curName;
            MSupplierAccount acc;

            Type curs = typeof(ListOfCurrency);
            foreach (string s in Enum.GetNames(curs))
            {
                curName = Enum.Parse(curs, s).ToString();

                    tab = tabControl_Account.TabPages["tabpages_" + curName];
                //combo bank
                    combo = (ComboBox)tab.Controls["bankIdComboBox" + curName];

                if (combo.SelectedIndex != -1)
                {

                    acc = (MSupplierAccount)DataMaster.GetObjectByProperty(typeof(MSupplierAccount), MSupplierAccount.ColumnNames.SupplierId, supplierIdTextBox.Text, MSupplierAccount.ColumnNames.CurrencyId, curName);
                    bool isSave = false;

                    if (acc == null)
                    {
                        acc = new MSupplierAccount();
                        isSave = true;
                    }
                    acc.CurrencyId = curName;
                    acc.BankId = combo.SelectedValue.ToString();

                    //txt rek atas nama
                    txt = (TextBox)tab.Controls["supplierAccountNameTextBox" + curName];
                    acc.SupplierAccountName = txt.Text;

                    //txt rek atas nama
                    txt = (TextBox)tab.Controls["supplierAccountNoTextBox" + curName];
                    acc.SupplierAccountNo = txt.Text;

                    acc.SupplierId = supplierIdTextBox.Text;

                    if (isSave)
                        DataMaster.SavePersistence(acc);
                    else
                        DataMaster.UpdatePersistence(acc);

                }
            }
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(supplierIdTextBox.Text))
            {
                balloonHelp.Content = "Kode Supplier harus diisi";
                balloonHelp.ShowBalloon(supplierIdTextBox);
                supplierIdTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(supplierNameTextBox.Text))
            {
                balloonHelp.Content = "Nama Supplier harus diisi";
                balloonHelp.ShowBalloon(supplierNameTextBox);
                supplierNameTextBox.Focus();
                return false;
            }
            //else if (bankIdComboBox.SelectedIndex == -1)
            //{
            //    balloonHelp.Content = "Pilih Bank";
            //    balloonHelp.ShowBalloon(bankIdComboBox);
            //    bankIdComboBox.Focus();
            //    return false;
            //}
            //else if (string.IsNullOrEmpty(supplierAccountNameTextBox.Text))
            //{
            //    balloonHelp.Content = "Nama rekening harus diisi";
            //    balloonHelp.ShowBalloon(supplierAccountNameTextBox);
            //    supplierAccountNameTextBox.Focus();
            //    return false;
            //}
            //else if (string.IsNullOrEmpty(supplierAccountNoTextBox.Text))
            //{
            //    balloonHelp.Content = "Nomor rekening harus diisi";
            //    balloonHelp.ShowBalloon(supplierAccountNoTextBox);
            //    supplierAccountNoTextBox.Focus();
            //    return false;
            //}
            return true;
        }

        private void bindingNavigatorRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void detailControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender == null)
                supplierIdTextBox.Focus();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode != Keys.Enter)
                    return;

                Control c = (Control)sender;
                if (sender == supplierIdTextBox)
                    supplierNameTextBox.Focus();
                else if (sender == supplierNameTextBox)
                    supplierAddressTextBox.Focus();
                else if (sender == supplierAddressTextBox)
                    supplierPhoneTextBox.Focus();
                else if (sender == supplierPhoneTextBox)
                    supplierContactTextBox.Focus();
                else if (sender == supplierContactTextBox)
                    supplierContactPhoneTextBox.Focus();
                else if (sender == supplierContactPhoneTextBox)
                    //    bankIdComboBox.Focus();
                    //else if (sender == bankIdComboBox)
                    //    supplierAccountNameTextBox.Focus();
                    //else if (sender == supplierAccountNameTextBox)
                    //    supplierAccountNoTextBox.Focus();
                    //else if (sender == supplierAccountNoTextBox)
                    bindingNavigatorSaveItem_Click(null, null);
            }

        }
    }
}

