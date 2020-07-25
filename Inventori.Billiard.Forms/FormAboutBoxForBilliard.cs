using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.Billiard.Forms
{
    public partial class FormAboutBoxForBilliard : Inventori.Forms.FormAboutBox
    {
        public FormAboutBoxForBilliard()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.billiard;

            logoPictureBox.Image = Properties.Resources.BilliardImage;

            this.Text = String.Format("Tentang {0}", AppCode.AssemblyTitle);
            this.labelProductName.Text = AppCode.AssemblyProduct;
            this.labelVersion.Text = String.Format("Versi {0}", AppCode.AssemblyVersion);
            this.labelCopyright.Text = AppCode.AssemblyCopyright;
            this.labelCompanyName.Text = AppCode.AssemblyCompany;
            this.textBoxDescription.Text = AppCode.AssemblyDescription;
        }
    }
}

