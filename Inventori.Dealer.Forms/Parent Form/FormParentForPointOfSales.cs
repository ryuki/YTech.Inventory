using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.Facade;
namespace Inventori.Dealer.Forms
{
    public partial class FormParentForDealer : Inventori.Forms.FormParent
    {
       public DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        public FormParentForDealer()
        {
            InitializeComponent();
            this.HideOnClose = false;
        }
    }
}