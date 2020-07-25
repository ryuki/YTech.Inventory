using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.PointOfSales.Forms
{
    public partial class FormAbout : Inventori.Forms.FormAboutBox
    {
        public FormAbout()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.inventori_ico;
            logoPictureBox.Image = Properties.Resources.inventori;

            this.Text = String.Format("Tentang {0}", AppCode.AssemblyTitle);
            this.labelProductName.Text = AppCode.AssemblyProduct;
            this.labelVersion.Text = String.Format("Versi {0}", AppCode.AssemblyVersion);
            this.labelCopyright.Text = AppCode.AssemblyCopyright;
            this.labelCompanyName.Text = AppCode.AssemblyCompany;
            this.textBoxDescription.Text = AppCode.AssemblyDescription;
        }
    }
}