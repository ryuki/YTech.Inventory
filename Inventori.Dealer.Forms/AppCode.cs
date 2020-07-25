using System;
using System.Collections.Generic;
using System.Text;

using System.Reflection;
using System.Collections;
using Inventori.Data;
using Inventori.DataAccess;
using Inventori.Facade;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

using NHibernate;

using System.Configuration;
//using NHibernate.Cfg;
//using NHibernate.Expression;

namespace Inventori.Dealer.Forms
{
    public class AppCode
    {
        public static string GenerateFacturNo(ListOfTransaction tr, string DeskNo)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            MSetting set = (MSetting)DataMaster.GetObjectById(typeof(MSetting), AssemblyProduct);
            TReference refer = (TReference)DataMaster.GetObjectByProperty(typeof(TReference), TReference.ColumnNames.ReferenceType, tr.ToString());
            if (refer == null)
            {
                refer = new TReference();
                refer.NextId = decimal.Zero.ToString();
            }

            string facturNoTemplate = set.FacturNoFormat;
            decimal no = Convert.ToDecimal(refer.NextId) + 1;
            int len = set.FacturNoLength - no.ToString().Length;

            string factur = no.ToString();
            for (int i = 0; i < len; i++)
            {
                factur = "0" + factur;
            }

            refer.NextId = no.ToString();
            refer.ReferenceType = tr.ToString();
            DataMaster.SaveOrUpdate(refer);

            string tipeTrans = string.Empty;
            char[] charTransArray = tr.ToString().ToCharArray();
            char charTrans;

            for (int i = 0; i < tr.ToString().Length; i++)
            {
                charTrans = charTransArray[i];
                if (char.IsUpper(tr.ToString(), i))
                    tipeTrans += tr.ToString().Substring(i, 1);
            }

            return facturNoTemplate.Replace("[xxx]", factur).Replace("[meja]", DeskNo).Replace("[tanggal]", DateTime.Now.Day.ToString()).Replace("[bulan]", DateTime.Now.Month.ToString()).Replace("[tahun]", DateTime.Now.Year.ToString()).Replace("[Tipe]", tipeTrans);

        }

        public static string ConvertNumericToString(decimal nNilai)
        {
            string[] Grade = { "Milyar ", "Juta ", "Ribu ", "" };
            string strTerbilang = string.Empty;
            string strPart;
            //Byte iGrade;
            int iGrade = 4;

            if (nNilai.ToString().Length > 12)
            {
                return "Melewati batas konversi";
            }
            else
            {
                strPart = nNilai.ToString();
                for (int i = 0; i < iGrade; i++)
                {
                    if (Convert.ToInt32(strPart.Substring(i * 3 + 1, 3)) > 0)
                    {
                        strTerbilang = strTerbilang + GetRatus(strPart.Substring(iGrade * 3 + 1, 3), iGrade);
                        strTerbilang = strTerbilang + Grade[i];
                    }
                }
            }

            //Kembalikan nilai melalui nama fungsi-nya
            return strTerbilang + " Rupiah";

            //If Len(CStr(nNilai)) > 12 Then
            //    strTerbilang = "Melewati batas konversi"
            //Else
            //    strPart = Format(nNilai, String(12, "0"))

            //    For iGrade = 1 To 4
            //    If Val(Mid(strPart, (iGrade - 1) * 3 + 1, 3)) > 0 Then
            //        strTerbilang = strTerbilang & _
            //            GetRatus(Mid(strPart, (iGrade - 1) * 3 + 1, 3), iGrade)
            //        strTerbilang = strTerbilang & Grade(iGrade - 1)
            //    End If
            //    Next iGrade
            //End If

        }

        private static string GetRatus(string strPart, int iGrade)
        {
            string[] Angka1 = { "Satu ", "Dua ", "Tiga ", "Empat ", "Lima ", "Enam ", "Tujuh ", "Delapan ", "Sembilan " };
            string[] Angka2 = { "Ratus ", "Puluh ", "" };

            string strHasil = string.Empty;
            int nTemp;

            for (int i = 0; i < 3; i++)
            {
                nTemp = Convert.ToInt32(strPart.Substring(i, 1));
                if (nTemp == 1)
                {
                    if (i == 1)
                        strHasil = "Seratus ";
                    else if (i == 2)
                    {
                        i = i + 1;
                        nTemp = Convert.ToInt32(strPart.Substring(i, 1));

                        if (nTemp == 0)
                            strHasil = strHasil + "Sepuluh ";
                        else if (nTemp == 1)
                            strHasil = strHasil + "Sebelas ";
                        else
                            strHasil = strHasil + Angka1[nTemp] + "Belas ";
                    }
                    else if (strPart == "1" && iGrade == 3)
                        strHasil = strHasil + "Se";
                    else
                        strHasil = strHasil + "Satu ";
                }
                else if (nTemp != 0)
                    strHasil = strHasil + Angka1[nTemp] + Angka2[i];
            }

            return strHasil;

            //        Dim Angka1 As Variant, Angka2 As Variant
            //Dim i As Integer
            //Dim strHasil As String
            //Dim nTemp As Byte

            //Angka1 = Array("Satu ", "Dua ", "Tiga ", "Empat ", _
            //   "Lima ", "Enam ", "Tujuh ", "Delapan ", "Sembilan ")
            //Angka2 = Array("Ratus ", "Puluh ", "")

            //For i = 1 To 3
            //    nTemp = Val(Mid(strPart, i, 1))
            //    If nTemp = 1 Then
            //        If i = 1 Then
            //            strHasil = "Seratus "
            //        ElseIf i = 2 Then

            //            i = i + 1
            //                nTemp = Val(Mid(strPart, i, 1))
            //            If nTemp = 0 Then
            //                strHasil = strHasil & "Sepuluh "
            //            ElseIf nTemp = 1 Then
            //                strHasil = strHasil & "Sebelas "
            //            Else
            //                strHasil = strHasil & _
            //                   Angka1(nTemp - 1) & "Belas "
            //            End If

            //        ElseIf Val(strPart) = 1 And iGrade = 3 Then
            //            strHasil = strHasil & "Se"
            //        Else
            //            strHasil = strHasil & "Satu "
            //        End If
            //    ElseIf nTemp <> 0 Then
            //        strHasil = strHasil + Angka1(nTemp - 1) + Angka2(i - 1)
            //    End If
            //Next i
            //GetRatus = strHasil
        }

        public static DataTable GetTransactionAveragePrice(ListOfTransaction trans, DateTime dateFrom, DateTime dateTo)
        {
            //ISession m_session = NHibernateHttpModule.CurrentSession;
            ////string queryStr = "SELECT AVG(DET.Price) ,DET.ItemId " +
            //string queryStr = "FROM TTransactionDetail DET, TTransaction TRANS " +
            // "WHERE DET.TransactionId = TRANS.TransactionId " +
            // "AND TRANS.TransactionStatus = :trans " +
            // "AND TRANS.TransactionDate BETWEEN :dateFrom AND :dateTo " +
            // "GROUP BY DET.ItemId";

            ////string queryStr = "SELECT DET.ItemId FROM TTransactionDetail DET";
            //IQuery query = m_session.CreateQuery(queryStr);
            //query.SetString("trans", trans.ToString());
            //query.SetDateTime("dateFrom", dateFrom);
            //query.SetDateTime("dateTo", dateTo);

            ISession m_session = NHibernateHttpModule.CurrentSession;
            SqlConnection cn = (SqlConnection)m_session.Connection;

            string q = @"SELECT DET.ITEM_ID as ItemId, AVG(DET.PRICE) as AvgPrice
                FROM T_TRANSACTION_DETAIL DET, T_TRANSACTION TRANS
                WHERE DET.TRANSACTION_ID = TRANS.TRANSACTION_ID 
                AND TRANS.TRANSACTION_STATUS = @trans
                AND TRANS.TRANSACTION_DATE BETWEEN @dateFrom AND @dateTo
                GROUP BY DET.ITEM_ID";

            SqlCommand cmd = new SqlCommand(q, cn);
            cmd.Parameters.Add(new SqlParameter("@trans", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@dateFrom", SqlDbType.DateTime));
            cmd.Parameters.Add(new SqlParameter("@dateTo", SqlDbType.DateTime));

            cmd.Parameters["@trans"].Value = trans.ToString();
            cmd.Parameters["@dateFrom"].Value = dateFrom;
            cmd.Parameters["@dateTo"].Value = dateTo;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        #region Assembly Attribute Accessors

        public static string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public static string AssemblyCompany
        {
            get
            {
                // Get all Company attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                // If there aren't any Company attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Company attribute, return its value
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion


        internal static void FillColorComboBox(ComboBox stockDesc1ComboBox)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();

            stockDesc1ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            NHibernate.Expression.Order[] orderArrays = new NHibernate.Expression.Order[1];
            orderArrays[0] = NHibernate.Expression.Order.Asc(MColour.ColumnNames.ColourDesc);
            IList list = DataMaster.GetList(typeof(MColour), null, orderArrays);

            MColour col = new MColour();
            col.ColourDesc = "- Warna -";
            list.Insert(0, col);

            //DataTable dt = new DataTable();
            //dt.Columns.Add(MColour.ColumnNames.ColourId);
            //dt.Columns.Add(MColour.ColumnNames.ColourDesc);

            //DataRow dr;

            //IList listItemType = DataMaster.GetAll(typeof(MColour));

            //MColour warna = new MColour();
            //warna.ColourDesc = "- Warna -";
            //dr = dt.NewRow();
            //dr[0] = warna.ColourId;
            //dr[1] = warna.ColourDesc;
            //dt.Rows.Add(dr);

            //for (int i = 0; i < listItemType.Count; i++)
            //{
            //    warna = (MColour)listItemType[i];
            //    dr = dt.NewRow();
            //    dr[0] = warna.ColourId;
            //    dr[1] = warna.ColourDesc;
            //    dt.Rows.Add(dr);
            //}

            stockDesc1ComboBox.DataSource = list;
            stockDesc1ComboBox.DisplayMember = MColour.ColumnNames.ColourDesc;
            stockDesc1ComboBox.ValueMember = MColour.ColumnNames.ColourId;
            stockDesc1ComboBox.Show();
        }

        internal static void FillItemComboBox(ComboBox itemIdComboBox)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();

            itemIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            NHibernate.Expression.Order[] orderArrays = new NHibernate.Expression.Order[1];
            orderArrays[0] = NHibernate.Expression.Order.Asc(MItem.ColumnNames.ItemName);
            IList list = DataMaster.GetList(typeof(MItem), null, orderArrays);

            MItem item = new MItem();
            item.ItemName = "- Type Unit -";
            list.Insert(0, item);

            //DataTable dt = new DataTable();
            //dt.Columns.Add(MItem.ColumnNames.ItemId);
            //dt.Columns.Add(MItem.ColumnNames.ItemName);

            //DataRow dr;

            //IList listItemType = DataMaster.GetAll(typeof(MItem));

            //MItem item = new MItem();
            //item.ItemName = "- Type Unit -";
            //dr = dt.NewRow();
            //dr[0] = item.ItemId;
            //dr[1] = item.ItemName;
            //dt.Rows.Add(dr);

            //for (int i = 0; i < listItemType.Count; i++)
            //{
            //    item = (MItem)listItemType[i];
            //    dr = dt.NewRow();
            //    dr[0] = item.ItemId;
            //    dr[1] = item.ItemName;
            //    dt.Rows.Add(dr);
            //}

            itemIdComboBox.DataSource = list;
            itemIdComboBox.DisplayMember = MItem.ColumnNames.ItemName;
            itemIdComboBox.ValueMember = MItem.ColumnNames.ItemId;
            itemIdComboBox.Show();
        }

        internal static void FillGudangComboBox(ComboBox gudangIdComboBox)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();

            gudangIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            DataTable dt = new DataTable();
            dt.Columns.Add(MGudang.ColumnNames.GudangId);
            dt.Columns.Add(MGudang.ColumnNames.GudangName);

            DataRow dr;

            IList listGudangType = DataMaster.GetAll(typeof(MGudang));

            MGudang gudang = new MGudang();
            //gudang.GudangId = 0;
            gudang.GudangName = "- Lokasi -";
            dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = gudang.GudangName;
            dt.Rows.Add(dr);

            for (int i = 0; i < listGudangType.Count; i++)
            {
                gudang = (MGudang)listGudangType[i];
                dr = dt.NewRow();
                dr[0] = gudang.GudangId;
                dr[1] = gudang.GudangName;
                dt.Rows.Add(dr);
            }

            gudangIdComboBox.DataSource = dt;
            gudangIdComboBox.DisplayMember = MGudang.ColumnNames.GudangName;
            gudangIdComboBox.ValueMember = MGudang.ColumnNames.GudangId;
            gudangIdComboBox.Show();
        }

        internal static void FillChannelComboBox(ComboBox channelIdComboBox)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();

            channelIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            NHibernate.Expression.Order[] orderArrays = new NHibernate.Expression.Order[1];
            orderArrays[0] = NHibernate.Expression.Order.Asc(MChannel.ColumnNames.ChannelName);
            IList list = DataMaster.GetList(typeof(MChannel), null, orderArrays);

            MChannel chn = new MChannel();
            chn.ChannelName = "- Channel -";
            list.Insert(0, chn);

            //DataTable dt = new DataTable();
            //dt.Columns.Add(MChannel.ColumnNames.ChannelId);
            //dt.Columns.Add(MChannel.ColumnNames.ChannelName);

            //DataRow dr;

            //IList listChannelType = DataMaster.GetAll(typeof(MChannel));

            //MChannel channel = new MChannel();
            //channel.ChannelName = "- Channel -";
            //dr = dt.NewRow();
            //dr[0] = channel.ChannelId;
            //dr[1] = channel.ChannelName;
            //dt.Rows.Add(dr);

            //for (int i = 0; i < listChannelType.Count; i++)
            //{
            //    channel = (MChannel)listChannelType[i];
            //    dr = dt.NewRow();
            //    dr[0] = channel.ChannelId;
            //    dr[1] = channel.ChannelName;
            //    dt.Rows.Add(dr);
            //}

            channelIdComboBox.DataSource = list;
            channelIdComboBox.DisplayMember = MChannel.ColumnNames.ChannelName;
            channelIdComboBox.ValueMember = MChannel.ColumnNames.ChannelId;
            channelIdComboBox.Show();
        }

        internal static void FillPaymentComboBox(ComboBox transactionPaymentComboBox)
        {
            transactionPaymentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
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

        internal static void FillFinanceComboBox(ComboBox financeIdComboBox)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();

            financeIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            NHibernate.Expression.Order[] orderArrays = new NHibernate.Expression.Order[1];
            orderArrays[0] = NHibernate.Expression.Order.Asc(MFinance.ColumnNames.FinanceName);
            IList list = DataMaster.GetList(typeof(MFinance), null, orderArrays);

            MFinance fin = new MFinance();
            fin.FinanceName = "- Finance -";
            list.Insert(0, fin);

            //DataTable dt = new DataTable();
            //dt.Columns.Add(MFinance.ColumnNames.FinanceId);
            //dt.Columns.Add(MFinance.ColumnNames.FinanceName);

            //DataRow dr;

            //IList listFinanceType = DataMaster.GetAll(typeof(MFinance));

            //MFinance finance = new MFinance();
            //finance.FinanceName = "- Finance -";
            //dr = dt.NewRow();
            //dr[0] = finance.FinanceId;
            //dr[1] = finance.FinanceName;
            //dt.Rows.Add(dr);

            //for (int i = 0; i < listFinanceType.Count; i++)
            //{
            //    finance = (MFinance)listFinanceType[i];
            //    dr = dt.NewRow();
            //    dr[0] = finance.FinanceId;
            //    dr[1] = finance.FinanceName;
            //    dt.Rows.Add(dr);
            //}

            financeIdComboBox.DataSource = list;
            financeIdComboBox.DisplayMember = MFinance.ColumnNames.FinanceName;
            financeIdComboBox.ValueMember = MFinance.ColumnNames.FinanceId;
            financeIdComboBox.Show();
        }

        internal static void FillCustomerComboBox(ComboBox custIdComboBox)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();

            custIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            NHibernate.Expression.Order[] orderArrays = new NHibernate.Expression.Order[1];
            orderArrays[0] = NHibernate.Expression.Order.Asc(MCustomer.ColumnNames.CustomerName);
            IList list = DataMaster.GetList(typeof(MCustomer), null, orderArrays);

            MCustomer cust = new MCustomer();
            cust.CustomerName = "- Pelanggan Baru -";
            list.Insert(0, cust);
            //DataTable dt = new DataTable();
            //dt.Columns.Add(MCustomer.ColumnNames.CustomerId);
            //dt.Columns.Add(MCustomer.ColumnNames.CustomerName);

            //DataRow dr;

            //IList listCustomerType = DataMaster.GetAll(typeof(MCustomer));

            //MCustomer cust = new MCustomer();
            //cust.CustomerName = "- Pelanggan Baru -";
            //dr = dt.NewRow();
            //dr[0] = cust.CustomerId;
            //dr[1] = cust.CustomerName;
            //dt.Rows.Add(dr);

            //for (int i = 0; i < listCustomerType.Count; i++)
            //{
            //    cust = (MCustomer)listCustomerType[i];
            //    dr = dt.NewRow();
            //    dr[0] = cust.CustomerId;
            //    dr[1] = cust.CustomerName;
            //    dt.Rows.Add(dr);
            //}

            custIdComboBox.DataSource = list;
            custIdComboBox.DisplayMember = MCustomer.ColumnNames.CustomerName;
            custIdComboBox.ValueMember = MCustomer.ColumnNames.CustomerId;
            custIdComboBox.Show();
        }

        internal static void FillSupplierComboBox(ComboBox suppIdComboBox)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();

            suppIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            NHibernate.Expression.Order[] orderArrays = new NHibernate.Expression.Order[1];
            orderArrays[0] = NHibernate.Expression.Order.Asc(MSupplier.ColumnNames.SupplierName);
            IList list = DataMaster.GetList(typeof(MSupplier), null, orderArrays);

            MSupplier sup = new MSupplier();
            sup.SupplierName = "- Supplier -";
            list.Insert(0, sup);

            //DataTable dt = new DataTable();
            //dt.Columns.Add(MSupplier.ColumnNames.SupplierId);
            //dt.Columns.Add(MSupplier.ColumnNames.SupplierName);

            //DataRow dr;

            //IList listSupplierType = DataMaster.GetAll(typeof(MSupplier));

            //MSupplier supp = new MSupplier();
            //supp.SupplierName = "- Supplier -";
            //dr = dt.NewRow();
            //dr[0] = supp.SupplierId;
            //dr[1] = supp.SupplierName;
            //dt.Rows.Add(dr);

            //for (int i = 0; i < listSupplierType.Count; i++)
            //{
            //    supp = (MSupplier)listSupplierType[i];
            //    dr = dt.NewRow();
            //    dr[0] = supp.SupplierId;
            //    dr[1] = supp.SupplierName;
            //    dt.Rows.Add(dr);
            //}

            suppIdComboBox.DataSource = list;
            suppIdComboBox.DisplayMember = MSupplier.ColumnNames.SupplierName;
            suppIdComboBox.ValueMember = MSupplier.ColumnNames.SupplierId;
            suppIdComboBox.Show();
        }

        internal static string GetNewId(Type tipe)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TReference refer = (TReference)DataMaster.GetObjectByProperty(typeof(TReference), TReference.ColumnNames.ReferenceType, tipe.Name.ToString());
            int length = 8;//int.Parse(ConfigurationManager.AppSettings["IdLength"]);
            string result = string.Empty;
            string lastId = string.Empty;

            if (refer == null)
            {
                refer = new TReference();
                lastId = decimal.Zero.ToString();
            }
            else
            {
                lastId = refer.NextId;
            }

            decimal nextId = Convert.ToDecimal(lastId) + 1;

            for (int i = 0; i < length - nextId.ToString().Length; i++)
            {
                result = "0" + result;
            }
            result = tipe.Name.ToString().Substring(1, tipe.Name.ToString().Length - 1) + result + nextId.ToString();

            refer.NextId = nextId.ToString();
            refer.ReferenceType = tipe.Name.ToString();
            DataMaster.SaveOrUpdate(refer);
            return result;

        }

        internal static void FillSalesComboBox(ComboBox employeeIdComboBox)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();

            employeeIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            NHibernate.Expression.Order[] orderArrays = new NHibernate.Expression.Order[1];
            orderArrays[0] = NHibernate.Expression.Order.Asc(MEmployee.ColumnNames.EmployeeName);
            IList list = DataMaster.GetList(typeof(MEmployee), null, orderArrays);

            MEmployee emp = new MEmployee();
            emp.EmployeeName = "- Salesman -";
            list.Insert(0, emp);

            //DataTable dt = new DataTable();
            //dt.Columns.Add(MEmployee.ColumnNames.EmployeeId);
            //dt.Columns.Add(MEmployee.ColumnNames.EmployeeName);

            //DataRow dr;

            //IList listSupplierType = DataMaster.GetAll(typeof(MEmployee));

            //MEmployee supp = new MEmployee();
            //supp.EmployeeName = "- Salesman -";
            //dr = dt.NewRow();
            //dr[0] = supp.EmployeeId;
            //dr[1] = supp.EmployeeName;
            //dt.Rows.Add(dr);

            //for (int i = 0; i < listSupplierType.Count; i++)
            //{
            //    supp = (MEmployee)listSupplierType[i];
            //    dr = dt.NewRow();
            //    dr[0] = supp.EmployeeId;
            //    dr[1] = supp.EmployeeName;
            //    dt.Rows.Add(dr);
            //}

            employeeIdComboBox.DataSource = list;
            employeeIdComboBox.DisplayMember = MEmployee.ColumnNames.EmployeeName;
            employeeIdComboBox.ValueMember = MEmployee.ColumnNames.EmployeeId;
            employeeIdComboBox.Show();
        }

        public static float PaperKwitansiWidth
        {
            get
            {
                float w = 241.3f;
                try
                {
                    w = float.Parse(ConfigurationSettings.AppSettings["PaperKwitansiWidth"]);
                }
                catch (Exception)
                {
                    throw;
                }
                return w;
            }
        }

        public static float PaperKwitansiHeight
        {
            get
            {
                float h = 139.7f;
                try
                {
                    h = float.Parse(ConfigurationSettings.AppSettings["PaperKwitansiHeight"]);
                }
                catch (Exception)
                {
                    throw;
                }
                return h;
            }
        }

        public static float PaperSuratWidth
        {
            get
            {
                float w = 241.3f;
                try
                {
                    w = float.Parse(ConfigurationSettings.AppSettings["PaperSuratWidth"]);
                }
                catch (Exception)
                {
                    throw;
                }
                return w;
            }
        }

        public static float PaperSuratHeight
        {
            get
            {
                float h = 139.7f;
                try
                {
                    h = float.Parse(ConfigurationSettings.AppSettings["PaperSuratHeight"]);
                }
                catch (Exception)
                {
                    throw;
                }
                return h;
            }
        }

        String[] bilangan = new String[] { "", "Satu ", "Dua ", "Tiga ", "Empat ", "Lima ", "Enam ", "Tujuh ", "Delapan ", "Sembilan ", "Sepuluh ", "Sebelas " };
        StringBuilder output = new StringBuilder();
        public string GetNumericSaid(decimal number)
        {
            if (number < 12)
            {
                output.Append(bilangan[(int)number]);
            }

            if (number >= 12 && number < 20)
            {
                GetNumericSaid(number - 10);
                output.Append("belas ");
            }

            if (number >= 20 && number < 100)
            {
                GetNumericSaid(number / 10);
                output.Append("Puluh ");
                GetNumericSaid(number % 10);
            }

            if (number >= 100 && number < 200)
            {
                output.Append("Seratus ");
                GetNumericSaid(number % 100);
            }

            if (number >= 200 && number < 1000)
            {
                GetNumericSaid(number / 100);
                output.Append("Ratus ");
                GetNumericSaid(number % 100);
            }

            if (number >= 1000 && number < 2000)
            {
                output.Append("Seribu ");
                GetNumericSaid(number % 1000);
            }

            if (number >= 2000 && number < 1000000)
            {
                GetNumericSaid(number / 1000);
                output.Append("Ribu ");
                GetNumericSaid(number % 1000);
            }

            if (number >= 1000000 && number < 1000000000)
            {
                GetNumericSaid(number / 1000000);
                output.Append("Juta ");
                GetNumericSaid(number % 1000000);
            }

            return output.ToString();
        }

        public static string GetCustomerName(string CustomerId, bool useSTNKName)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            MCustomer cust = DataMaster.GetObjectByProperty(typeof(MCustomer), MCustomer.ColumnNames.CustomerId, CustomerId) as MCustomer;
            if (cust != null)
            {
                if (useSTNKName)
                    return cust.CustomerDesc;
                else
                    return cust.CustomerName;
            }
            else
                return string.Empty;
        }

        internal static string GetSupplierName(string SupplierId)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            MSupplier sup = DataMaster.GetObjectByProperty(typeof(MSupplier), MSupplier.ColumnNames.SupplierId, SupplierId) as MSupplier;
            if (sup != null)
            {
                return sup.SupplierName;
            }
            else
                return string.Empty;
        }
    }
}
