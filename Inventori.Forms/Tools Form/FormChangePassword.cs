using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Inventori.Data;
using Inventori.Facade;

namespace Inventori.Forms
{
    public partial class FormChangePassword : Inventori.Forms.FormParentForToolsForm
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private Balloon.NET.BalloonHelp balloonHelp;
        MUser user;
        public FormChangePassword()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.users1;
        }

        private void FormChangePassword_Load(object sender, EventArgs e)
        {
            Inventori.Module.ModuleControlSettings.SaveLog(ListOfAction.Open, userNameLabel1.Text, ListOfTable.MUser, lbl_UserName.Text);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;
            try
            {
                user.UserPassword = userPasswordTextBoxNew.Text;
                user.ModifiedBy = lbl_UserName.Text;
                user.ModifiedDate = DateTime.Now;
                DataMaster.UpdatePersistence(user);
                MessageBox.Show("Penggantian kata kunci berhasil", "Penggantian Kata Kunci", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Inventori.Module.ModuleControlSettings.SaveLog(ListOfAction.ChangePassword, userNameLabel1.Text, ListOfTable.MUser, lbl_UserName.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Penggantian kata kunci tidak berhasil" + System.Environment.NewLine + ex.Message, "Penggantian Kata Kunci", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            RecreateBalloon();

            user = (MUser)DataMaster.GetObjectByProperty(typeof(MUser), MUser.ColumnNames.UserName, userNameLabel1.Text, MUser.ColumnNames.UserPassword, userPasswordTextBox.Text);

            if (user == null)
            {
                balloonHelp.Caption = "Login Tidak Valid";
                balloonHelp.Content = "Password anda tidak cocok !!";
                balloonHelp.ShowBalloon(userPasswordTextBox);
                userPasswordTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(userPasswordTextBoxNew.Text))
            {
                balloonHelp.Caption = "Password Baru";
                balloonHelp.Content = "Password baru harus diisi";
                balloonHelp.ShowBalloon(userPasswordTextBoxNew);
                userPasswordTextBoxNew.Focus();
                return false;
            }
            else if (!userPasswordTextBoxConfirm.Text.Equals(userPasswordTextBoxNew.Text))
            {

                balloonHelp.Caption = "Konfirmasi Password";
                balloonHelp.Content = "Konfirmasi Password berbeda dengan password baru, konfirmasi password harus sama dengan password baru.";
                balloonHelp.ShowBalloon(userPasswordTextBoxConfirm);
                userPasswordTextBoxConfirm.Focus();
                return false;
            }
            return true;
        }

        private void RecreateBalloon()
        {
            balloonHelp = new Balloon.NET.BalloonHelp();
            balloonHelp.Icon = Properties.Resources.warning;
            balloonHelp.ShowCloseButton = false;
        }

    }
}

