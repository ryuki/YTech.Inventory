using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.Forms
{
    public partial class FormParentForSearchForm : FormParent
    {
        //DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        public FormParentForSearchForm()
        {
            InitializeComponent();
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.Icon = Properties.Resources.search;
            grid_Search.AutoGenerateColumns = false;
            grid_Search.Columns.Clear();

            btn_Cancel.Click += new EventHandler(btn_Cancel_Click);

        }

        void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormParentForSearchForm_Load(object sender, EventArgs e)
        {
            grid_Search.DataSource = bindingSource_Search;
            Inventori.Module.ModuleControlSettings.SetGridDataView(grid_Search);
            grid_Search.Focus();
            grid_Search.Select();
        }
    }
}