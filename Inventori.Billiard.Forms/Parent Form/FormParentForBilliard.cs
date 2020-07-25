using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.Billiard.Forms
{
    public partial class FormParentForBilliard : Inventori.Forms.FormParent
    {
        public FormParentForBilliard()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.billiard;
            this.HideOnClose = false;
        }
    }
}

