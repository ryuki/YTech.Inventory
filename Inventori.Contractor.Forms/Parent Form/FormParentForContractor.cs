using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.Contractor.Forms
{
    public partial class FormParentForContractor : Inventori.Forms.FormParent
    {
        public FormParentForContractor()
        {
            InitializeComponent();
            this.HideOnClose = false;
        }
    }
}

