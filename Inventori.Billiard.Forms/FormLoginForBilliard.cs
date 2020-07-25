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
    public partial class FormLoginForBilliard : Inventori.Forms.FormLogin
    {
        [STAThread]
        public static void Main(string[] args)
        {
            //this is App entry point
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLoginForBilliard());
        }

        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private FormMainForBilliard f_Main;
        private Balloon.NET.BalloonHelp balloonHelp;

        public FormLoginForBilliard()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.billiard;
            this.Text = AppCode.AssemblyProduct;
        }

        private void FormLoginForBilliard_Load(object sender, EventArgs e)
        {
            Form f = this.Owner;
            if (f != null)
                f_Main = (FormMainForBilliard)f;
            userNameTextBox.Focus();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            MUser user;
            try
            {
                user = (MUser)DataMaster.GetObjectByProperty(typeof(MUser), MUser.ColumnNames.UserName, userNameTextBox.Text, MUser.ColumnNames.UserPassword, userPasswordTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login gagal \n " + ex.Message, "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user != null)
            {
                if (!user.UserStatus)
                {
                    RecreateBalloon();

                    balloonHelp.Caption = "Nama pengguna Tidak Valid";
                    balloonHelp.Content = "Nama pengguna tidak aktif";
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
                        f_Main.masukToolStripMenuItem.Enabled = false;
                    }
                    else
                        f_Main = new FormMainForBilliard();
                }
                else
                    f_Main = new FormMainForBilliard();

                f_Main.toolStripStatusLabelLoginName.Text = userNameTextBox.Text;
                f_Main.FilterPriviledge();
                f_Main.Show();
            }
            else
            {
                RecreateBalloon();

                balloonHelp.Caption = "Login Tidak Valid";
                balloonHelp.Content = "Nama pengguna atau kata kunci tidak cocok !!";
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

        private void FormLoginForBilliard_Shown(object sender, EventArgs e)
        {
            userNameTextBox.Focus();
            userNameTextBox.Select();
        }

        private void userPasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonOK_Click(null, null);
        }

    }
}

