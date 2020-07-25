using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.MotorKymco.Forms
{
    public partial class FormParentForMotorKymco : Inventori.Forms.FormParent
    {
        public FormParentForMotorKymco()
        {
            InitializeComponent();
            this.HideOnClose = false;
        }
    }
}