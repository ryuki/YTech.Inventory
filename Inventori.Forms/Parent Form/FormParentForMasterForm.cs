using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.Forms
{
    public partial class FormParentForMasterForm : FormParent
    {
        public Balloon.NET.BalloonHelp balloonHelp;
        public FormParentForMasterForm()
        {
            InitializeComponent();
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.Icon = Properties.Resources.data_master;
            grid_Master.AutoGenerateColumns = false;
            grid_Master.Columns.Clear();

        }

        private void FormParentForMasterForm_Load(object sender, EventArgs e)
        {
            Inventori.Module.ModuleControlSettings.SetGridDataView(grid_Master);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < groupBox1.Controls.Count; i++)
            //{
            //    if (groupBox1.Controls[i].GetType().Equals(typeof(TextBox)))
            //        ((TextBox)groupBox1.Controls[i]).ResetText();
            //    if (groupBox1.Controls[i].GetType().Equals(typeof(ComboBox)))
            //        ((ComboBox)groupBox1.Controls[i]).SelectedIndex = -1;
            //    if (groupBox1.Controls[i].GetType().Equals(typeof(NumericUpDown)))
            //        ((NumericUpDown)groupBox1.Controls[i]).Value = 0;
            //    if (groupBox1.Controls[i].GetType().Equals(typeof(CheckBox)))
            //        ((CheckBox)groupBox1.Controls[i]).Checked = false;
            //    //if (groupBox1.Controls[i].GetType().Equals(typeof(Label)))
            //    //    ((Label)groupBox1.Controls[i]).ResetText();
            //}

            setEnableGroupBox1(true);
            bindingNavigatorAddNewItem.Enabled = false;
            bindingNavigatorEditItem.Enabled = false;
            bindingNavigatorDeleteItem.Enabled = false;
            bindingNavigatorSaveItem.Enabled = true;
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            setEnableGroupBox1(true);
            bindingNavigatorAddNewItem.Enabled = false;
            bindingNavigatorEditItem.Enabled = false;
            bindingNavigatorDeleteItem.Enabled = true;
            bindingNavigatorSaveItem.Enabled = true;
        }

        private void bindingSource_Master_PositionChanged(object sender, EventArgs e)
        {
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
        }

        public void RecreateBalloon()
        {
            balloonHelp = new Balloon.NET.BalloonHelp();
            balloonHelp.Icon = Properties.Resources.warning;
            balloonHelp.ShowCloseButton = false;
        }

        public void setEnableGroupBox1(bool isEnabled)
        {
            try
            {
                groupBox1.Enabled = isEnabled;
            }
            catch (Exception)
            {
            }
        }

        public void SetNavigatorDisplay()
        {
            if (bindingSource_Master.Count > 0)
            {
                setEnableGroupBox1(false);
                bindingNavigatorAddNewItem.Enabled = true;
                bindingNavigatorEditItem.Enabled = true;
                bindingNavigatorDeleteItem.Enabled = true;
                bindingNavigatorSaveItem.Enabled = false;
            }
            else
            {
                setEnableGroupBox1(false);
                bindingNavigatorAddNewItem.Enabled = true;
                bindingNavigatorEditItem.Enabled = false;
                bindingNavigatorDeleteItem.Enabled = false;
                bindingNavigatorSaveItem.Enabled = false;
            }
        }

        //public bool isInEdit = false;
        private void FormParentForMasterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bindingNavigatorSaveItem.Enabled)
            {
                DialogResult res = MessageBox.Show("Data belum disimpan. Simpan data?", "Konfirmasi simpan data.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    bindingNavigatorSaveItem.PerformClick();
                    e.Cancel = true;
                }
                else if (res == DialogResult.No)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }

        private void bindingNavigatorSaveItem_EnabledChanged(object sender, EventArgs e)
        {
            if (bindingNavigatorSaveItem.Enabled)
            {
                this.Text = this.Text + "*";
                this.TabText = this.TabText + "*";
            }
            else
            {
                this.Text = this.Text.Replace("*", "");
                this.TabText = this.TabText.Replace("*", "");
            }
        }

    }
}