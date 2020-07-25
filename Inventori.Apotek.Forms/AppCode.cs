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
//using NHibernate.Cfg;
//using NHibernate.Expression;

namespace Inventori.Apotek.Forms
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

        public static string GetVoucherNo()
        {
            string voucherFrontString = "V/" + DateTime.Now.Year.ToString() + "/";
            int voucherLength = 8;
            string lastVoucher;
            string VoucherNo = "VoucherNo";

            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TReference refer = (TReference)DataMaster.GetObjectByProperty(typeof(TReference), TReference.ColumnNames.ReferenceType, VoucherNo);
            if (refer == null)
            {
                refer = new TReference();
                lastVoucher = decimal.Zero.ToString();
            }
            else
            {
                lastVoucher = refer.NextId.Substring(refer.NextId.Length - voucherLength, voucherLength);
                //voucherLength = voucherLength - 1;
            }

            decimal nextNumVoucher = Convert.ToDecimal(lastVoucher) + 1;
            string nextVoucher = nextNumVoucher.ToString();

            for (int i = 0; i < voucherLength - nextNumVoucher.ToString().Length; i++)
            {
                nextVoucher = "0" + nextVoucher;
            }
            nextVoucher = voucherFrontString + nextVoucher;

            refer.NextId = nextVoucher;
            refer.ReferenceType = VoucherNo;
            DataMaster.SaveOrUpdate(refer);
            return nextVoucher;
        }

        public static string GetKasAccountNo()
        {
            string KasAccountNo = "KasAccountNo";
            string defaultKasAccountNo = "100";
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TReference refer = (TReference)DataMaster.GetObjectByProperty(typeof(TReference), TReference.ColumnNames.ReferenceType, KasAccountNo);

            if (refer == null)
            {
                refer = new TReference();
                refer.ReferenceType = KasAccountNo;
                refer.NextId = defaultKasAccountNo;
                DataMaster.SaveOrUpdate(refer);
            }
            else
                defaultKasAccountNo = refer.NextId;

            return defaultKasAccountNo;
        }

        public static string GetOtherRevenueAccountNo()
        {
            string OtherRevenueAccountNo = "OtherRevenueAccountNo";
            string defaultOtherRevenueAccountNo = "680";
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TReference refer = (TReference)DataMaster.GetObjectByProperty(typeof(TReference), TReference.ColumnNames.ReferenceType, OtherRevenueAccountNo);

            if (refer == null)
            {
                refer = new TReference();
                refer.ReferenceType = OtherRevenueAccountNo;
                refer.NextId = defaultOtherRevenueAccountNo;
                DataMaster.SaveOrUpdate(refer);
            }
            else
                defaultOtherRevenueAccountNo = refer.NextId;

            return defaultOtherRevenueAccountNo;
        }

        public static string GetPiutangBebanAccountNo()
        {
            string PiutangBebanAccountNo = "PiutangBebanAccountNo";
            string defaultPiutangBebanAccountNo = "800HAP001";
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TReference refer = (TReference)DataMaster.GetObjectByProperty(typeof(TReference), TReference.ColumnNames.ReferenceType, PiutangBebanAccountNo);

            if (refer == null)
            {
                refer = new TReference();
                refer.ReferenceType = PiutangBebanAccountNo;
                refer.NextId = defaultPiutangBebanAccountNo;
                DataMaster.SaveOrUpdate(refer);
            }
            else
                defaultPiutangBebanAccountNo = refer.NextId;

            return defaultPiutangBebanAccountNo;
        }

        public static string GetHPPAccountNo()
        {
            string HPPAccountNo = "HPPAccountNo";
            string defaultHPPAccountNo = "700HAR001";
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TReference refer = (TReference)DataMaster.GetObjectByProperty(typeof(TReference), TReference.ColumnNames.ReferenceType, HPPAccountNo);

            if (refer == null)
            {
                refer = new TReference();
                refer.ReferenceType = HPPAccountNo;
                refer.NextId = defaultHPPAccountNo;
                DataMaster.SaveOrUpdate(refer);
            }
            else
                defaultHPPAccountNo = refer.NextId;

            return defaultHPPAccountNo;
        }

        public static string GetPersediaanAccountNo()
        {
            string PersediaanAccountNo = "PersediaanAccountNo";
            string defaultPersediaanAccountNo = "150PER001";
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TReference refer = (TReference)DataMaster.GetObjectByProperty(typeof(TReference), TReference.ColumnNames.ReferenceType, PersediaanAccountNo);

            if (refer == null)
            {
                refer = new TReference();
                refer.ReferenceType = PersediaanAccountNo;
                refer.NextId = defaultPersediaanAccountNo;
                DataMaster.SaveOrUpdate(refer);
            }
            else
                defaultPersediaanAccountNo = refer.NextId;

            return defaultPersediaanAccountNo;
        }

        public static string GetBiayaStokAccountNo()
        {
            string BiayaStokAccountNo = "BiayaStokAccountNo";
            string defaultBiayaStokAccountNo = "830STO001";
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TReference refer = (TReference)DataMaster.GetObjectByProperty(typeof(TReference), TReference.ColumnNames.ReferenceType, BiayaStokAccountNo);

            if (refer == null)
            {
                refer = new TReference();
                refer.ReferenceType = BiayaStokAccountNo;
                refer.NextId = defaultBiayaStokAccountNo;
                DataMaster.SaveOrUpdate(refer);
            }
            else
                defaultBiayaStokAccountNo = refer.NextId;

            return defaultBiayaStokAccountNo;
        }

        public static string GetPotReturBeliAccountNo()
        {
            string PotReturBeliAccountNo = "PotReturBeli";
            string defaultPotReturBeliAccountNo = "710-POTRB001";
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TReference refer = (TReference)DataMaster.GetObjectByProperty(typeof(TReference), TReference.ColumnNames.ReferenceType, PotReturBeliAccountNo);

            if (refer == null)
            {
                refer = new TReference();
                refer.ReferenceType = PotReturBeliAccountNo;
                refer.NextId = defaultPotReturBeliAccountNo;
                DataMaster.SaveOrUpdate(refer);
            }
            else
                defaultPotReturBeliAccountNo = refer.NextId;

            return defaultPotReturBeliAccountNo;
        }

        public static string GetPotReturJualAccountNo()
        {
            string PotReturJualAccountNo = "PotReturJual";
            string defaultPotReturJualAccountNo = "640POT001";
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TReference refer = (TReference)DataMaster.GetObjectByProperty(typeof(TReference), TReference.ColumnNames.ReferenceType, PotReturJualAccountNo);

            if (refer == null)
            {
                refer = new TReference();
                refer.ReferenceType = PotReturJualAccountNo;
                refer.NextId = defaultPotReturJualAccountNo;
                DataMaster.SaveOrUpdate(refer);
            }
            else
                defaultPotReturJualAccountNo = refer.NextId;

            return defaultPotReturJualAccountNo;
        }

        public static string GetPPNSalesAccountNo()
        {
            string PPNSalesAccountNo = "PPNSales";
            string defaultPPNSalesAccountNo = "990PPN001";
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TReference refer = (TReference)DataMaster.GetObjectByProperty(typeof(TReference), TReference.ColumnNames.ReferenceType, PPNSalesAccountNo);

            if (refer == null)
            {
                refer = new TReference();
                refer.ReferenceType = PPNSalesAccountNo;
                refer.NextId = defaultPPNSalesAccountNo;
                DataMaster.SaveOrUpdate(refer);
            }
            else
                defaultPPNSalesAccountNo = refer.NextId;

            return defaultPPNSalesAccountNo;
        }

        public static string GetPPNPurchaseAccountNo()
        {
            string PPNPurchaseAccountNo = "PPNPurchase";
            string defaultPPNPurchaseAccountNo = "320PPN001";
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TReference refer = (TReference)DataMaster.GetObjectByProperty(typeof(TReference), TReference.ColumnNames.ReferenceType, PPNPurchaseAccountNo);

            if (refer == null)
            {
                refer = new TReference();
                refer.ReferenceType = PPNPurchaseAccountNo;
                refer.NextId = defaultPPNPurchaseAccountNo;
                DataMaster.SaveOrUpdate(refer);
            }
            else
                defaultPPNPurchaseAccountNo = refer.NextId;

            return defaultPPNPurchaseAccountNo;
        }

        public static string GetLabaDitahanAccountNo()
        {
            string LabaDitahanAccountNo = "LabaDitahanAccountNo";
            string defaultLabaDitahanAccountNo = "510LAB001";
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            TReference refer = (TReference)DataMaster.GetObjectByProperty(typeof(TReference), TReference.ColumnNames.ReferenceType, LabaDitahanAccountNo);

            if (refer == null)
            {
                refer = new TReference();
                refer.ReferenceType = LabaDitahanAccountNo;
                refer.NextId = defaultLabaDitahanAccountNo;
                DataMaster.SaveOrUpdate(refer);
            }
            else
                defaultLabaDitahanAccountNo = refer.NextId;

            return defaultLabaDitahanAccountNo;
        }

        public static void SaveTJournal(TJournal jur)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            MSubAccount sub = (MSubAccount)DataMaster.GetObjectByProperty(typeof(MSubAccount), MSubAccount.ColumnNames.SubAccountId, jur.SubAccountId);
            MAccount acc = new MAccount();
            if (sub != null)
            {
                acc = (MAccount)DataMaster.GetObjectByProperty(typeof(MAccount), MAccount.ColumnNames.AccountId, sub.AccountId);
                if (acc == null)
                    acc = new MAccount();
            }
            else
                sub = new MSubAccount();

            if (acc.AccountStatus == jur.JournalStatus)
            {
                jur.AccountSaldo = acc.AccountSaldo + jur.JournalJumlah;
                jur.SubAccontSaldo = sub.SubAccountSaldo + jur.JournalJumlah;
            }
            else
            {
                jur.AccountSaldo = acc.AccountSaldo - jur.JournalJumlah;
                jur.SubAccontSaldo = sub.SubAccountSaldo - jur.JournalJumlah;
            }

            jur.AccountId = acc.AccountId;
            DataMaster.SavePersistence(jur);

            //update saldo sub account
            sub.SubAccountSaldo = jur.SubAccontSaldo;
            sub.ModifiedBy = jur.ModifiedBy;
            sub.ModifiedDate = DateTime.Now;
            DataMaster.UpdatePersistence(sub);

            //update saldo account
            acc.AccountSaldo = jur.AccountSaldo;
            acc.ModifiedBy = jur.ModifiedBy;
            acc.ModifiedDate = DateTime.Now;
            DataMaster.UpdatePersistence(acc);
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

    }
}
