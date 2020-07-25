using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace Inventori.Billiard.Forms
{
    partial class FormAboutBox : FormParentForBilliard
    {
        public FormAboutBox()
        {
            InitializeComponent();

            //  Initialize the AboutBox to display the product information from the assembly information.
            //  Change assembly information settings for your application through either:
            //  - Project->Properties->Application->Assembly Information
            //  - AssemblyInfo.cs
            this.Text = String.Format("Tentang {0}", AppCode.AssemblyTitle);
            this.labelProductName.Text = AppCode.AssemblyProduct;
            this.labelVersion.Text = String.Format("Versi {0}", AppCode.AssemblyVersion);
            this.labelCopyright.Text = AppCode.AssemblyCopyright;
            this.labelCompanyName.Text = AppCode.AssemblyCompany;
            this.textBoxDescription.Text = AppCode.AssemblyDescription;
        }    
    }
}
