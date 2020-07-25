using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Reflection;
using System.Collections;
using Inventori.Data;
using Inventori.Facade;
using System.Windows.Forms;

namespace Inventori.Contractor.Forms
{
    public class AppCode
    {
        public static string GenerateFacturNo(ListOfTransaction tr, string DeskNo)
        {
            //return "";
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            MSetting set = (MSetting)DataMaster.GetObjectByProperty(typeof(MSetting),MSetting.ColumnNames.SettingId, AssemblyProduct);
            if (set != null)
            {
                IList listTrans = DataMaster.GetListEq(typeof(TTransaction), TTransaction.ColumnNames.TransactionStatus, tr.ToString());

                string facturNoTemplate = set.FacturNoFormat;
                int no = listTrans.Count + 1;
                int len = set.FacturNoLength - no.ToString().Length;

                string factur = no.ToString();
                for (int i = 0; i < len; i++)
                {
                    factur = "0" + factur;
                }

                string typeTrans = "";
                switch (tr)
                {
                    case ListOfTransaction.Correction:
                        typeTrans = "Kor";
                        break;
                    case ListOfTransaction.Purchase:
                        typeTrans = "P";
                        break;
                    case ListOfTransaction.PurchaseOrder:
                        typeTrans = "PO";
                        break;
                    case ListOfTransaction.ReturPurchase:
                        typeTrans = "RP";
                        break;
                    case ListOfTransaction.ReturSales:
                        typeTrans = "RS";
                        break;
                    case ListOfTransaction.ReturSalesVIP:
                        typeTrans = "RSVIP";
                        break;
                    case ListOfTransaction.Sales:
                        typeTrans = "S";
                        break;
                    case ListOfTransaction.SalesVIP:
                        typeTrans = "SVIP";
                        break;
                    case ListOfTransaction.Usage:
                        typeTrans = "U";
                        break;
                    default:
                        break;
                }

                return facturNoTemplate.Replace("[xxx]", factur).Replace("[meja]", DeskNo).Replace("[tanggal]", DateTime.Now.Day.ToString()).Replace("[bulan]", DateTime.Now.Month.ToString()).Replace("[tahun]", DateTime.Now.Year.ToString()).Replace("[TipeTransaksi]",typeTrans);
            }
            else
                return "";

        }

        public static void SetGiroStatusComboBox(ComboBox cb)
        {
            Type status = typeof(ListOfGiroStatus);

            cb.Items.Clear();
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (string s in Enum.GetNames(status))
            {
                cb.Items.Add(Enum.Parse(status, s).ToString().Replace("_", " "));
            }
            cb.Show();
        }

        public static void SetCurrencyStatusComboBox(ComboBox cb)
        {
            Type status = typeof(ListOfCurrency);

            cb.Items.Clear();
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (string s in Enum.GetNames(status))
            {
                cb.Items.Add(Enum.Parse(status, s).ToString().Replace("_", " "));
            }
            cb.Show();
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
