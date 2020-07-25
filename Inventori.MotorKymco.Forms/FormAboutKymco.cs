using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.MotorKymco.Forms
{
    public partial class FormAboutKymco : Inventori.Forms.FormAboutBox
    {
        public FormAboutKymco()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.kymco_logo_ico;
            logoPictureBox.Image = Properties.Resources.Kymco_Logo_Name;


            this.Text = String.Format("Tentang {0}", AppCode.AssemblyTitle);
            this.labelProductName.Text = AppCode.AssemblyProduct;
            this.labelVersion.Text = String.Format("Versi {0}", AppCode.AssemblyVersion);
            this.labelCopyright.Text = AppCode.AssemblyCopyright;
            this.labelCompanyName.Text = AppCode.AssemblyCompany;
            this.textBoxDescription.Text = AppCode.AssemblyDescription;
        }
    }
}