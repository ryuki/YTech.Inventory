using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.Contractor.Forms
{
    public partial class FormPrintStatus : Inventori.Contractor.Forms.FormParentForContractor
    {
        public event EventHandler PrintStatusHasSelected;
        public FormPrintStatus()
        {
            InitializeComponent();
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (this.PrintStatusHasSelected != null)
                this.PrintStatusHasSelected(ListOfPrintStatus.PrintOK, null);

            this.Close();
        }

        private void button_Replay_Click(object sender, EventArgs e)
        {
            if (this.PrintStatusHasSelected != null)
                this.PrintStatusHasSelected(ListOfPrintStatus.PrintFailed, null);

            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            if (this.PrintStatusHasSelected != null)
                this.PrintStatusHasSelected(ListOfPrintStatus.PrintCancel, null);

            this.Close();
        }
    }
}

