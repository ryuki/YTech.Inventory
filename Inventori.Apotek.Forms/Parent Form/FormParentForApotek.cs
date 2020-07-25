using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.Apotek.Forms
{
    public partial class FormParentForApotek : Inventori.Forms.FormParent
    {
        public FormParentForApotek()
        {
            InitializeComponent();
            this.HideOnClose = false;
        }
    }
}