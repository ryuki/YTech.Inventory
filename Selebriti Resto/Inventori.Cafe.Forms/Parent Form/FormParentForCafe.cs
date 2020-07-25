using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.Cafe.Forms
{
    public partial class FormParentForCafe : Inventori.Forms.FormParent
    {
        public FormParentForCafe()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.cafe1;
            this.HideOnClose = true;
        }
    }
}

