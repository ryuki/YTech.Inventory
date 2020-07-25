using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

using System.Collections;
using System.Drawing;
using Inventori.Data;
using Inventori.Facade;
using System.Threading;

namespace Inventori.Module
{
    public class ModuleControlSettings
    {
        [STAThread]
        public static void Main(string[] args)
        {
            //this is App entry point
        }

        public static void SetGridDataView(DataGridView dg)
        {
            dg.ReadOnly = true;
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg.MultiSelect = false;
            dg.CausesValidation = false;
            dg.AllowUserToDeleteRows = false;
            dg.AllowUserToAddRows = false;
            dg.ScrollBars = ScrollBars.Vertical;

            for (int i = 0; i < dg.Columns.Count; i++)
            {
                if (i == dg.Columns.Count)
                    dg.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                else
                    dg.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        public static void SetTypeItemComboBox(ComboBox cb)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();

            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            IList listItemType = DataMaster.GetAll(typeof(MItemType));

            if (listItemType.Count > 0)
            {
                cb.DataSource = listItemType;
                cb.DisplayMember = "ItemTypeName";
                cb.ValueMember = "ItemTypeId";
                cb.Show();
            }
        }

        public static void SetGroupComboBox(ComboBox cb)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listGroup = DataMaster.GetAll(typeof(MGroup));

            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            if (listGroup.Count > 0)
            {
                cb.DataSource = listGroup;
                cb.DisplayMember = "GroupName";
                cb.ValueMember = "GroupId";
                cb.Show();
            }
        }

        public static void SetGroupComboBoxForFilter(ComboBox cb)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listGroup = DataMaster.GetAll(typeof(MGroup));
            MGroup group;

            DataTable dt = new DataTable();
            dt.Columns.Add(MGroup.ColumnNames.GroupId);
            dt.Columns.Add(MGroup.ColumnNames.GroupName);

            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "-Semua Golongan-";
            dt.Rows.Add(dr);

            for (int i = 0; i < listGroup.Count; i++)
            {
                group = (MGroup)listGroup[i];
                dr = dt.NewRow();
                dr[0] = group.GroupId;
                dr[1] = group.GroupName;
                dt.Rows.Add(dr);
            }

            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            cb.DataSource = dt;
            cb.ValueMember = MGroup.ColumnNames.GroupId;
            cb.DisplayMember = MGroup.ColumnNames.GroupName;
            cb.Show();
        }

        public static void SetGudangComboBox(ComboBox cb)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listGudang = DataMaster.GetAll(typeof(MGudang));

            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            cb.DataSource = listGudang;
            cb.ValueMember = MGudang.ColumnNames.GudangId;
            cb.DisplayMember = MGudang.ColumnNames.GudangName;
            cb.Show();
        }

        public static void SetSearchPictureBox(Control con, string searchPicName, PictureBox searchPic)
        {
            try
            {
                searchPic.Image = Image.FromFile("030-browse.png");
            }
            catch (Exception)
            {
            }

            searchPic.Name = searchPicName;
            searchPic.Visible = false;
            searchPic.Size = new Size(16, 16);
            searchPic.BorderStyle = BorderStyle.None;
            searchPic.Cursor = Cursors.Hand;
            searchPic.SizeMode = PictureBoxSizeMode.StretchImage;

            searchPic.Location = new Point(con.Width - 20, 0);

            searchPic.MouseClick += new MouseEventHandler(searchPic_MouseClick);
            searchPic.MouseLeave += new EventHandler(searchPic_MouseLeave);
            //searchPic.Click += new EventHandler(searchPic_Click);
            //con.Controls.Add(searchPic);
        }

        private static void searchPic_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox searchPic = (PictureBox)sender;
            searchPic.BorderStyle = BorderStyle.Fixed3D;
        }

        private static void searchPic_MouseLeave(object sender, EventArgs e)
        {
            PictureBox searchPic = (PictureBox)sender;
            searchPic.BorderStyle = BorderStyle.None;
        }

        public static void SetVisibleControlChild(Control con, string childControlName, bool vis)
        {
            Control[] child = con.Controls.Find(childControlName, false);
            if (child.Length > 0)
                child[0].Visible = vis;
        }

        public static void SetDateTimePicker(DateTimePicker dt)
        {
            SetDateTimePicker(dt, true);
        }

        public static void SetDateTimePicker(DateTimePicker dt, bool ShowTime)
        {
            dt.Format = DateTimePickerFormat.Custom;
            if (ShowTime)
                dt.CustomFormat = DateTimeFormat();
            else
                dt.CustomFormat = DateFormat();
        }

        public static string DateTimeFormat()
        {
            return "dd/MMM/yyyy HH:mm";
        }

        public static string DateFormat()
        {
            return "dd/MMM/yyyy";
        }

        //public static void SetDeskStatusComboBox(ComboBox cb)
        //{
        //    Type bilStatus = typeof(ListOfDeskStatus);

        //    cb.DropDownStyle = ComboBoxStyle.DropDownList;
        //    cb.Items.Clear();
        //    foreach (string s in Enum.GetNames(bilStatus))
        //    {
        //        cb.Items.Add(Enum.Parse(bilStatus, s).ToString().Replace("_", " "));
        //    }
        //    cb.Show();
        //}

        public static void FillItemSuggestSource(TextBox tb)
        {
            tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb.AutoCompleteCustomSource.Clear();

            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listItem = DataMaster.GetAll(typeof(MItem));
            MItem item;

            for (int i = 0; i < listItem.Count; i++)
            {
                item = (MItem)listItem[i];
                tb.AutoCompleteCustomSource.Add(item.ItemId);
            }
        }

        public static void SetDepartmentComboBox(ComboBox cb)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();

            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            IList listDepartment = DataMaster.GetAll(typeof(MDep));

            if (listDepartment.Count > 0)
            {
                cb.DataSource = listDepartment;
                cb.DisplayMember = "DepName";
                cb.ValueMember = "DepId";
                cb.Show();
            }
        }

        public static void SetGenderComboBox(ComboBox cb)
        {
            Type gender = typeof(ListOfGender);

            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.Items.Clear();
            foreach (string s in Enum.GetNames(gender))
            {
                cb.Items.Add(Enum.Parse(gender, s).ToString().Replace("_", " "));
            }
            cb.Show();
        }

        public static void SetMaritalStatusComboBox(ComboBox cb)
        {
            Type status = typeof(ListOfMaritalStatus);

            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.Items.Clear();
            foreach (string s in Enum.GetNames(status))
            {
                cb.Items.Add(Enum.Parse(status, s).ToString().Replace("_", " "));
            }
            cb.Show();
        }

        public static void SetEmployeeStatusComboBox(ComboBox cb)
        {
            Type status = typeof(ListOfEmployeeStatus);

            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.Items.Clear();
            foreach (string s in Enum.GetNames(status))
            {
                cb.Items.Add(Enum.Parse(status, s).ToString().Replace("_", " "));
            }
            cb.Show();
        }

        public static void SetDaysComboBox(ComboBox cb)
        {
            Type days = typeof(ListOfDays);

            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.Items.Clear();
            foreach (string s in Enum.GetNames(days))
            {
                cb.Items.Add(Enum.Parse(days, s).ToString().Replace("_", " "));
            }
            cb.Show();
            // cb.SelectedIndex = 0;
        }

        public static string GetDayFromDayOfWeek(DayOfWeek dow)
        {
            if (dow == DayOfWeek.Sunday)
                return ListOfDays.Minggu.ToString();
            else if (dow == DayOfWeek.Monday)
                return ListOfDays.Senin.ToString();
            else if (dow == DayOfWeek.Tuesday)
                return ListOfDays.Selasa.ToString();
            else if (dow == DayOfWeek.Wednesday)
                return ListOfDays.Rabu.ToString();
            else if (dow == DayOfWeek.Thursday)
                return ListOfDays.Kamis.ToString();
            else if (dow == DayOfWeek.Friday)
                return ListOfDays.Jumat.ToString();
            else if (dow == DayOfWeek.Saturday)
                return ListOfDays.Sabtu.ToString();

            return null;
        }

        public static bool HavePriviledges(string userName, int MenuId, string SettingId)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TMenuUser userMenu = (TMenuUser)DataMaster.GetObjectByProperty(typeof(TMenuUser), TMenuUser.ColumnNames.UserName, userName, TMenuUser.ColumnNames.MenuId, Convert.ToDecimal(MenuId), TMenuUser.ColumnNames.SettingId, SettingId);
            if (userMenu != null)
                return userMenu.HasAccess;
            else
                return false;
        }

        public static Balloon.NET.BalloonHelp RecreateBalloon(Balloon.NET.BalloonHelp balloonHelp)
        {
            balloonHelp = new Balloon.NET.BalloonHelp();
            try
            {
                balloonHelp.Icon = Icon.ExtractAssociatedIcon("warning.ico");

            }
            catch (Exception)
            {
            }

            balloonHelp.ShowCloseButton = false;
            return balloonHelp;
        }

        public static void SetNumericUpDown(NumericUpDown num, bool IsReadOnly)
        {
            SetNumericUpDown(num, IsReadOnly, 2);
        }

        public static void SetNumericUpDown(NumericUpDown num, bool IsReadOnly,int decimalPlace)
        {
            num.TextAlign = HorizontalAlignment.Right;
            num.ThousandsSeparator = true;
            num.DecimalPlaces = decimalPlace;
            num.Maximum = decimal.MaxValue;
            num.Enabled = !IsReadOnly;
            num.Minimum = decimal.Zero;
        }

        public static void SetNumericUpDown(NumericUpDown num)
        {
            SetNumericUpDown(num, false);
        }

        public static void SetItemTextBoxSuggest(TextBox txt)
        {
            txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt.AutoCompleteCustomSource.Clear();

            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listItem = DataMaster.GetAll(typeof(MItem));
            MItem item;

            for (int i = 0; i < listItem.Count; i++)
            {
                item = (MItem)listItem[i];
                txt.AutoCompleteCustomSource.Add(item.ItemId);
            }
        }

        public static void SetCustomerTextBoxSuggest(TextBox txt)
        {
            txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt.AutoCompleteCustomSource.Clear();

            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listCust = DataMaster.GetAll(typeof(MCustomer));
            MCustomer cust;

            for (int i = 0; i < listCust.Count; i++)
            {
                cust = (MCustomer)listCust[i];
                txt.AutoCompleteCustomSource.Add(cust.CustomerId);
            }
        }

        public static void SetSupplierTextBoxSuggest(TextBox txt)
        {
            txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt.AutoCompleteCustomSource.Clear();

            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listSupp = DataMaster.GetAll(typeof(MSupplier));
            MSupplier supp;

            for (int i = 0; i < listSupp.Count; i++)
            {
                supp = (MSupplier)listSupp[i];
                txt.AutoCompleteCustomSource.Add(supp.SupplierId);
            }
        }

        public static void SetEmployeeTextBoxSuggest(TextBox txt)
        {
            txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt.AutoCompleteCustomSource.Clear();

            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listEmployee = DataMaster.GetAll(typeof(MEmployee));
            MEmployee emp;

            for (int i = 0; i < listEmployee.Count; i++)
            {
                emp = (MEmployee)listEmployee[i];
                txt.AutoCompleteCustomSource.Add(emp.EmployeeId);
            }
        }

        public static string NumericFormat(object obj)
        {
            return NumericFormat(obj, false);
        }

        public static string NumericFormat(object obj, bool withRp)
        {
            decimal dec;
            if (isDecimal(obj.ToString()))
            {
                dec = decimal.Parse(obj.ToString());
                if (withRp)
                    return string.Format("Rp. " + numFormat, dec);
                else
                    return string.Format(numFormat, dec);
            }
            else
            {
                if (withRp)
                    return string.Format("Rp. " + numFormat, obj);
                else
                    return string.Format(numFormat, obj);
            }

        }

        public static string numFormat
        {
            get
            {
                return "{0:n}";
            }
        }

        public static bool isDecimal(string str)
        {
            try
            {
                decimal dec = decimal.Parse(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DateTime GetMaksDateTransactionClosing()
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();

            IList listRekap = DataMaster.GetAll(typeof(TRekapTransaction));
            TRekapTransaction rekap;
            DateTime maks = DateTime.MinValue;
            //search maks rekapdateto
            for (int i = 0; i < listRekap.Count; i++)
            {
                rekap = (TRekapTransaction)listRekap[i];
                if (rekap.RekapDateTo > maks)
                    maks = rekap.RekapDateTo;
            }

            if (maks == DateTime.MinValue)
            {
                //search min transaction date
                maks = DateTime.MaxValue;
                IList listTrans = DataMaster.GetAll(typeof(TTransaction));
                TTransaction trans;
                for (int i = 0; i < listTrans.Count; i++)
                {
                    trans = (TTransaction)listTrans[i];
                    if (maks > trans.TransactionDate)
                        maks = trans.TransactionDate;
                }
            }
            return maks;
        }

        public static void SetTransactionTextBoxSuggest(TextBox txt, ListOfTransaction tr)
        {
            txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt.AutoCompleteCustomSource.Clear();

            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listTrans = DataMaster.GetListEq(typeof(TTransaction), TTransaction.ColumnNames.TransactionStatus, tr.ToString());
            TTransaction trans;

            for (int i = 0; i < listTrans.Count; i++)
            {
                trans = (TTransaction)listTrans[i];
                txt.AutoCompleteCustomSource.Add(trans.TransactionFactur);
            }
        }

        public static void SetTransactionTextBoxSuggest(TextBox txt, ListOfTransaction tr, string SupplierId)
        {
            txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt.AutoCompleteCustomSource.Clear();

            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listTrans = DataMaster.GetListEq(typeof(TTransaction), TTransaction.ColumnNames.TransactionStatus, tr.ToString(), TTransaction.ColumnNames.TransactionBy, SupplierId);
            TTransaction trans;

            for (int i = 0; i < listTrans.Count; i++)
            {
                trans = (TTransaction)listTrans[i];
                txt.AutoCompleteCustomSource.Add(trans.TransactionFactur);
            }
        }

        public static void SaveLog(ListOfAction logAction, string description, ListOfTable table, string user)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TLog log = new TLog();
            log.LogAction = logAction.ToString();
            log.LogCompName = SystemInformation.ComputerName;
            log.LogDate = DateTime.Now;

            string aksi = "";
            switch (logAction)
            {
                case ListOfAction.Insert:
                    aksi = "Simpan data ";
                    break;
                case ListOfAction.Update:
                    aksi = "Ubah data ";
                    break;
                case ListOfAction.Delete:
                    aksi = "Hapus data ";
                    break;
                case ListOfAction.Open:
                    aksi = "Buka data ";
                    break;
                case ListOfAction.Close:
                    aksi = "Tutup data ";
                    break;
                case ListOfAction.Login:
                    aksi = "Pengguna masuk ke program ";
                    break;
                case ListOfAction.Logout:
                    aksi = "Pengguna keluar dari program ";
                    break;
                case ListOfAction.Exit:
                    aksi = "Tutup program ";
                    break;
                case ListOfAction.In:
                    aksi = "Buka program ";
                    break;
                case ListOfAction.Backup:
                    aksi = "Backup ";
                    break;
                case ListOfAction.Restore:
                    aksi = "Restore ";
                    break;
                case ListOfAction.ChangePassword:
                    aksi = "Ganti kata kunci ";
                    break;
                default:
                    break;
            }
            string tab = "";
            switch (table)
            {
                case ListOfTable.ItemGudangStok:
                    tab = "Stok Item";
                    break;
                case ListOfTable.MCustomer:
                    tab = "Pelanggan";
                    break;
                case ListOfTable.MDep:
                    tab = "Bagian";
                    break;
                case ListOfTable.MEmployee:
                    tab = "Karyawan";
                    break;
                case ListOfTable.MGroup:
                    tab = "Golongan Item";
                    break;
                case ListOfTable.MGudang:
                    tab = "Gudang";
                    break;
                case ListOfTable.MItem:
                    tab = "Item";
                    break;
                case ListOfTable.MItemType:
                    tab = "Tipe Item";
                    break;
                case ListOfTable.MSupplier:
                    tab = "Supplier";
                    break;
                case ListOfTable.MUser:
                    tab = "Pengguna";
                    break;
                case ListOfTable.TLog:
                    tab = "Log";
                    break;
                case ListOfTable.TMenuUser:
                    tab = "";
                    break;
                case ListOfTable.TStokCard:
                    tab = "";
                    break;
                case ListOfTable.TTransaction:
                    tab = "Transaksi";
                    break;
                case ListOfTable.TTransactionDetail:
                    tab = "Detail Transaksi";
                    break;
                case ListOfTable.VTransactionDetail:
                    tab = "";
                    break;
                case ListOfTable.MMenu:
                    tab = "Menu";
                    break;
                case ListOfTable.MSetting:
                    tab = "Konfigurasi Program";
                    break;
                case ListOfTable.MDesk:
                    tab = "Meja";
                    break;
                case ListOfTable.TDesk:
                    tab = "Transaksi Meja";
                    break;
                case ListOfTable.TRekapTransaction:
                    tab = "Rekap Transaksi";
                    break;
                case ListOfTable.TRekapCommission:
                    tab = "Rekap Komisi";
                    break;
                case ListOfTable.VTotalTransactionDetail:
                    tab = "";
                    break;
                case ListOfTable.VItemDetail:
                    tab = "";
                    break;
                case ListOfTable.MBank:
                    tab = "Bank";
                    break;
                case ListOfTable.MLocation:
                    tab = "Lokasi";
                    break;
                case ListOfTable.TGiro:
                    tab = "Giro";
                    break;
                case ListOfTable.MSupplierAccount:
                    tab = "Rekening Supplier";
                    break;
                case ListOfTable.Database:
                    tab = "Database";
                    break;
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(description.Trim()))
                log.LogDesc = aksi + tab + " : " + description;
            else
                log.LogDesc = aksi + tab;

            string localhost = System.Net.Dns.GetHostName();
            System.Net.IPAddress[] ips = System.Net.Dns.GetHostByName(localhost).AddressList;
            string ip = "";
            for (int i = 0; i < ips.Length; i++)
            {
                ip += ips[i].ToString();
                if (i < ips.Length - 1)
                    ip += ",";
            }
            log.LogIp = ip;
            log.LogTable = table.ToString();
            log.LogUser = user;

            try
            {
                DataMaster.SavePersistence(log);

            }
            catch (Exception)
            {

            }
        }

        public static void SetSupplierComboBoxForFilter(ComboBox cb)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listSupp = DataMaster.GetAll(typeof(MSupplier));
            MSupplier supp;

            DataTable dt = new DataTable();
            dt.Columns.Add(MSupplier.ColumnNames.SupplierId);
            dt.Columns.Add(MSupplier.ColumnNames.SupplierName);

            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "-Semua Supplier-";
            dt.Rows.Add(dr);

            for (int i = 0; i < listSupp.Count; i++)
            {
                supp = (MSupplier)listSupp[i];
                dr = dt.NewRow();
                dr[0] = supp.SupplierId;
                dr[1] = supp.SupplierName;
                dt.Rows.Add(dr);
            }

            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            cb.DataSource = dt;
            cb.ValueMember = MSupplier.ColumnNames.SupplierId;
            cb.DisplayMember = MSupplier.ColumnNames.SupplierName;
            cb.Show();
        }

        public static void SetCustomerComboBoxForFilter(ComboBox cb)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listCust = DataMaster.GetAll(typeof(MCustomer));
            MCustomer cust;

            DataTable dt = new DataTable();
            dt.Columns.Add(MCustomer.ColumnNames.CustomerId);
            dt.Columns.Add(MCustomer.ColumnNames.CustomerName);

            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "-Semua Pelanggan-";
            dt.Rows.Add(dr);

            for (int i = 0; i < listCust.Count; i++)
            {
                cust = (MCustomer)listCust[i];
                dr = dt.NewRow();
                dr[0] = cust.CustomerId;
                dr[1] = cust.CustomerName;
                dt.Rows.Add(dr);
            }

            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            cb.DataSource = dt;
            cb.ValueMember = MCustomer.ColumnNames.CustomerId;
            cb.DisplayMember = MCustomer.ColumnNames.CustomerName;
            cb.Show();
        }


        public static void SetEmployeeComboBoxForFilter(ComboBox cb)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listEmp = DataMaster.GetAll(typeof(MEmployee));
            MEmployee emp;

            DataTable dt = new DataTable();
            dt.Columns.Add(MEmployee.ColumnNames.EmployeeId);
            dt.Columns.Add(MEmployee.ColumnNames.EmployeeName);

            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "-Semua Karyawan-";
            dt.Rows.Add(dr);

            for (int i = 0; i < listEmp.Count; i++)
            {
                emp = (MEmployee)listEmp[i];
                dr = dt.NewRow();
                dr[0] = emp.EmployeeId;
                dr[1] = emp.EmployeeName;
                dt.Rows.Add(dr);
            }

            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            cb.DataSource = dt;
            cb.ValueMember = MEmployee.ColumnNames.EmployeeId;
            cb.DisplayMember = MEmployee.ColumnNames.EmployeeName;
            cb.Show();
        }

        public static void SetUserComboBoxForFilter(ComboBox cb)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listUser = DataMaster.GetAll(typeof(MUser));
            MUser user;

            DataTable dt = new DataTable();
            dt.Columns.Add(MUser.ColumnNames.UserStatus);
            dt.Columns.Add(MUser.ColumnNames.UserName);

            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "-Semua Pengguna-";
            dt.Rows.Add(dr);

            for (int i = 0; i < listUser.Count; i++)
            {
                user = (MUser)listUser[i];
                dr = dt.NewRow();
                dr[0] = user.UserName;
                dr[1] = user.UserName;
                dt.Rows.Add(dr);
            }

            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            cb.DataSource = dt;
            cb.ValueMember = MUser.ColumnNames.UserStatus;
            cb.DisplayMember = MUser.ColumnNames.UserName;
            cb.Show();
        }

        public static void SetItemComboBoxForFilter(ComboBox cb)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listItem = DataMaster.GetAll(typeof(MItem));
            MItem item;

            DataTable dt = new DataTable();
            dt.Columns.Add(MItem.ColumnNames.ItemId);
            dt.Columns.Add(MItem.ColumnNames.ItemName);

            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "-Semua Item-";
            dt.Rows.Add(dr);

            for (int i = 0; i < listItem.Count; i++)
            {
                item = (MItem)listItem[i];
                dr = dt.NewRow();
                dr[0] = item.ItemId;
                dr[1] = item.ItemName;
                dt.Rows.Add(dr);
            }

            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            cb.DataSource = dt;
            cb.ValueMember = MItem.ColumnNames.ItemId;
            cb.DisplayMember = MItem.ColumnNames.ItemName;
            cb.Show();
        }

        public static void SetMonthsComboBox(ComboBox cb)
        {
            Type months = typeof(ListOfMonths);

            string displayMember = "displayMember";
            string valueMember = "valueMember";

            DataTable dt = new DataTable();
            dt.Columns.Add(valueMember);
            dt.Columns.Add(displayMember);

            DataRow dr;

            for (int i = 0; i < Enum.GetNames(months).Length; i++)
            {
                dr = dt.NewRow();

                if (i+1 < 10)
                    dr[0] = decimal.Zero.ToString() + (i + 1).ToString();
                else
                    dr[0] = (i + 1).ToString();

                dr[1] = Enum.GetNames(months)[i];
                dt.Rows.Add(dr);
            }

            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            cb.DataSource = dt;
            cb.ValueMember = valueMember;
            cb.DisplayMember = displayMember;
            cb.Show();
        }

        public static void CustomerValidating(string customerId, TextBox customerNameTextBox)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            MCustomer cust = (MCustomer)DataMaster.GetObjectByProperty(typeof(MCustomer), MCustomer.ColumnNames.CustomerId, customerId);
            if (cust != null)
                customerNameTextBox.Text = cust.CustomerName;
            else
                customerNameTextBox.ResetText();
        }

        public static void EmployeeValidating(string employeeId, TextBox employeeNameTextBox)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            MEmployee emp = (MEmployee)DataMaster.GetObjectByProperty(typeof(MEmployee), MEmployee.ColumnNames.EmployeeId, employeeId);
            if (emp != null)
                employeeNameTextBox.Text = emp.EmployeeName;
            else
                employeeNameTextBox.ResetText();
        }

        public static void SupplierValidating(string supplierId, TextBox supplierNameTextBox)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            MSupplier supp = (MSupplier)DataMaster.GetObjectByProperty(typeof(MSupplier), MSupplier.ColumnNames.SupplierId, supplierId);
            if (supp != null)
                supplierNameTextBox.Text = supp.SupplierName;
            else
                supplierNameTextBox.ResetText();
        }

        public static void EkspedissionValidating(string ekspedissionId, TextBox ekspedissionNameTextBox)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            MEkspedission eks = (MEkspedission)DataMaster.GetObjectByProperty(typeof(MEkspedission), MEkspedission.ColumnNames.EkspedissionId, ekspedissionId);
            if (eks != null)
                ekspedissionNameTextBox.Text = eks.EkspedissionName;
            else
                ekspedissionNameTextBox.ResetText();
        }

        public static void SetEkspeditionComboBoxForFilter(ComboBox cb)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            IList listEks = DataMaster.GetAll(typeof(MEkspedission));
            MEkspedission eks;

            DataTable dt = new DataTable();
            dt.Columns.Add(MEkspedission.ColumnNames.EkspedissionId);
            dt.Columns.Add(MEkspedission.ColumnNames.EkspedissionName);

            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "-Semua Ekspedisi-";
            dt.Rows.Add(dr);

            for (int i = 0; i < listEks.Count; i++)
            {
                eks = (MEkspedission)listEks[i];
                dr = dt.NewRow();
                dr[0] = eks.EkspedissionId;
                dr[1] = eks.EkspedissionName;
                dt.Rows.Add(dr);
            }

            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            cb.DataSource = dt;
            cb.ValueMember = MEkspedission.ColumnNames.EkspedissionId;
            cb.DisplayMember = MEkspedission.ColumnNames.EkspedissionName;
            cb.Show();
        }
    }

}
