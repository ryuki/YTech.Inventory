using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

using System.Reflection;
using System.Collections;
using Inventori.Data;
using Inventori.Facade;

namespace Inventori.Billiard.Forms
{
    public class AppCode
    {
        public static string GenerateFacturNo(string DeskNo)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            MSetting set = (MSetting)DataMaster.GetObjectByProperty(typeof(MSetting), MSetting.ColumnNames.SettingId, AssemblyProduct);

            //IList listTrans = DataMaster.GetAll(typeof(TTransaction));

            string facturNoTemplate = set.FacturNoFormat;
            //int no = listTrans.Count + 1;
            int no = Convert.ToInt32(set.FacturNoNext) + 1;
            int len = set.FacturNoLength - no.ToString().Length;

            string factur = no.ToString();
            for (int i = 0; i < len; i++)
            {
                factur = "0" + factur;
            }

            //update next faktur
            set.FacturNoNext = set.FacturNoNext + 1;
            DataMaster.UpdatePersistence(set);

            return facturNoTemplate.Replace("[xxx]", factur).Replace("[meja]", DeskNo).Replace("[tanggal]", DateTime.Now.Day.ToString()).Replace("[bulan]", DateTime.Now.Month.ToString()).Replace("[tahun]", DateTime.Now.Year.ToString());

        }

        public static string DateFormat
        {
            get { return ConfigurationManager.AppSettings["DateFormat"]; }
        }

        public static string DateTimeFormat
        {
            get { return ConfigurationManager.AppSettings["DateTimeFormat"]; }
        }

        public static string NumericFormat
        {
            get { return ConfigurationManager.AppSettings["NumericFormat"]; }
        }


        public static float PaperWidth
        {
            get
            {
                float w = 241.3f;
                try
                {
                    w = float.Parse(ConfigurationManager.AppSettings["PaperWidth"]);
                }
                catch (Exception)
                {
                    throw;
                }
                return w;
            }
        }

        public static int MarginTop
        {
            get
            {
                int m = 48;
                try
                {
                    m = int.Parse(ConfigurationManager.AppSettings["MarginTop"]);
                }
                catch (Exception)
                {
                    throw;
                }
                return m;
            }
        }

        public static int MarginBottom
        {
            get
            {
                int m = 48;
                try
                {
                    m = int.Parse(ConfigurationManager.AppSettings["MarginBottom"]);
                }
                catch (Exception)
                {
                    throw;
                }
                return m;
            }
        }

        public static int MarginLeft
        {
            get
            {
                int m = 96;
                try
                {
                    m = int.Parse(ConfigurationManager.AppSettings["MarginLeft"]);
                }
                catch (Exception)
                {
                    throw;
                }
                return m;
            }
        }

        public static int MarginRight
        {
            get
            {
                int m = 96;
                try
                {
                    m = int.Parse(ConfigurationManager.AppSettings["MarginRight"]);
                }
                catch (Exception)
                {
                    throw;
                }
                return m;
            }
        }


        public static float PaperHeight
        {
            get
            {
                float h = 139.7f;
                try
                {
                    h = float.Parse(ConfigurationManager.AppSettings["PaperHeight"]);
                }
                catch (Exception)
                {
                    throw;
                }
                return h;
            }
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
