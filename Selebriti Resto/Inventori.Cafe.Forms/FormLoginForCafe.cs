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

namespace Inventori.Cafe.Forms
{
    public partial class FormLoginForCafe : Inventori.Forms.FormLogin
    {
        [STAThread]
        public static void Main(string[] args)
        {
            //this is App entry point
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLoginForCafe());
        }

        public FormLoginForCafe()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.cafe1;
            this.Text = AppCode.AssemblyProduct;
        }
        private FormMainForCafe f_Main;
        private Balloon.NET.BalloonHelp balloonHelp;

        private void FormLoginForCafe_Load(object sender, EventArgs e)
        {
            Form f = this.Owner;
            if (f != null)
                f_Main = (FormMainForCafe)f;
            userNameTextBox.Focus();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DataMasterMgtServices DataMaster = new DataMasterMgtServices();
            MUser user;
            try
            {
               user = (MUser)DataMaster.GetObjectByProperty(typeof(MUser), MUser.ColumnNames.UserName, userNameTextBox.Text, MUser.ColumnNames.UserPassword, userPasswordTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login gagal \n" + ex.Message, "Login Gagal", MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                        f_Main = new FormMainForCafe();
                }
                else
                    f_Main = new FormMainForCafe();

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

        private void FormLoginForCafe_Shown(object sender, EventArgs e)
        {
            userNameTextBox.Focus();
            userNameTextBox.Select();
        }

        private void userPasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonOK.PerformClick();
        }

    }
}

