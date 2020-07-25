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
using System.Reflection;

namespace Inventori.Billiard.Forms
{
    public partial class FormLogin : Form
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        public FormLogin()
        {
            InitializeComponent();
            this.Text = AssemblyProduct;
            this.Icon = Properties.Resources.billiard;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //try
            //{
            //    System.Environment.Exit(1);
            //}
            //catch (Exception)
            //{
            //}
        }

        FormMain f_Main;
        private Balloon.NET.BalloonHelp balloonHelp;
        private void buttonOK_Click(object sender, EventArgs e)
        {
            MUser user = (MUser)DataMaster.GetObjectByProperty(typeof(MUser), MUser.ColumnNames.UserName, userNameTextBox.Text, MUser.ColumnNames.UserPassword, userPasswordTextBox.Text);
            if (user != null)
            {
                if (!user.UserStatus)
                {
                    RecreateBalloon();

                    balloonHelp.Caption = "Login Tidak Valid";
                    balloonHelp.Content = "User name anda tidak aktif";
                    balloonHelp.ShowBalloon(userNameTextBox);
                    userNameTextBox.Focus();
                    userNameTextBox.SelectAll();
                    return;
                }

                this.Hide();

                if (f_Main != null)
                {
                    if (!f_Main.IsDisposed)
                    {
                        f_Main.WindowState = FormWindowState.Normal;
                        f_Main.BringToFront();
                        f_Main.loginToolStripMenuItem.Enabled = false;
                    }
                    else
                        f_Main = new FormMain();
                }
                else
                    f_Main = new FormMain();

                f_Main.toolStripStatusLabelLoginName.Text = userNameTextBox.Text;
                f_Main.FilterPriviledge();
                f_Main.Show();
            }
            else
            {
                RecreateBalloon();

                balloonHelp.Caption = "Login Tidak Valid";
                balloonHelp.Content = "User Name atau password tidak cocok !!";
                balloonHelp.ShowBalloon(userNameTextBox);
                userNameTextBox.Focus();
                userNameTextBox.SelectAll();
            }
        }

        private void RecreateBalloon()
        {
            balloonHelp = new Balloon.NET.BalloonHelp();
            balloonHelp.Icon = Properties.Resources.warning;
            balloonHelp.ShowCloseButton = false;
        }

        private void FormLogin_Shown(object sender, EventArgs e)
        {
            userNameTextBox.Focus();
            userNameTextBox.ResetText();
            userPasswordTextBox.ResetText();
            this.Focus();

            Form f = this.Owner;
            if (f != null)
                f_Main = (FormMain)f;
        }

        private string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        private void userNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                userPasswordTextBox.Focus();
        }
    }
}