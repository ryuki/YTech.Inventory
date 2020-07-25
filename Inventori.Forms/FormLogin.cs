using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Inventori.Module.ModuleControlSettings.SaveLog(ListOfAction.Exit, string.Empty, ListOfTable.None, string.Empty);
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {
            }

            try
            {
                System.Environment.Exit(1);
            }
            catch (Exception)
            {
            }

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.Focus();
            userNameTextBox.ResetText();
            userPasswordTextBox.ResetText();
            userNameTextBox.Focus();
        }

        private void userNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                userPasswordTextBox.Select();
        }

        private void userPasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonOK.Focus();
        }

    }
}