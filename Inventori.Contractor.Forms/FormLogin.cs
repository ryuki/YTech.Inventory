using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.Data;
using Inventori.Facade;

namespace Inventori.Contractor.Forms
{
    public partial class FormLogin : Inventori.Forms.FormLogin
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Inventori.Module.ModuleControlSettings.SaveLog(ListOfAction.In, string.Empty, ListOfTable.None, string.Empty);
            //this is App entry point
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }

        private FormMain f_Main;
        private Balloon.NET.BalloonHelp balloonHelp;

        public FormLogin()
        {
            InitializeComponent();
            this.Text = AppCode.AssemblyProduct;
            this.Icon = Properties.Resources.worker_ico;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            userNameTextBox.Focus();
            userNameTextBox.Select();
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
                MessageBox.Show("Login gagal \n" + ex.Message, "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        f_Main = new FormMain();
                }
                else
                    f_Main = new FormMain();

                f_Main.toolStripStatusLabelLoginName.Text = userNameTextBox.Text;
                f_Main.FilterPriviledge();
                f_Main.Show();
                Inventori.Module.ModuleControlSettings.SaveLog(ListOfAction.Login, string.Empty,ListOfTable.None, userNameTextBox.Text);
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

        private void FormLogin_Shown(object sender, EventArgs e)
        {
            userNameTextBox.Focus();
            userNameTextBox.Select();
        }
    }
}