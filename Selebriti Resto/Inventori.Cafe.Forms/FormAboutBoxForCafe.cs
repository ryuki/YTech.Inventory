using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.Cafe.Forms
{
    internal partial class FormAboutBoxForCafe : Inventori.Forms.FormAboutBox
    {
        public FormAboutBoxForCafe()
        {
            InitializeComponent();

            logoPictureBox.Image = Properties.Resources.restaurant_cafe;

            this.Text = String.Format("Tentang {0}", AppCode.AssemblyTitle);
            this.labelProductName.Text = AppCode.AssemblyProduct;
            this.labelVersion.Text = String.Format("Versi {0}", AppCode.AssemblyVersion);
            this.labelCopyright.Text = AppCode.AssemblyCopyright;
            this.labelCompanyName.Text = AppCode.AssemblyCompany;
            this.textBoxDescription.Text = AppCode.AssemblyDescription;
        }
    }
}

