using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.PointOfSales.Forms
{
    public partial class FormParentForPointOfSales : Inventori.Forms.FormParent
    {
        public FormParentForPointOfSales()
        {
            InitializeComponent();
            this.HideOnClose = false;
        }
    }
}