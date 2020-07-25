using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Inventori.Cafe.Data;
using Inventori.Data;
using Inventori.Facade;
using WeifenLuo.WinFormsUI.Docking;
using Inventori.Module;
using Inventori.Forms;
using Inventori.Data;
using MGroup = Inventori.Cafe.Data.MGroup;

namespace Inventori.Cafe.Forms
{
    public partial class FormCafe : FormParentForCafe
    {
        public FormCafe()
        {
            InitializeComponent();
            //this.Icon = Properties.Resources.cafe;
            set = (MSetting)DataMaster.GetObjectByProperty(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
        }

        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        Button activeButton = new Button();
        private Balloon.NET.BalloonHelp balloonHelp;
        Color noneColor = Color.White;
        Color bookingColor = Color.FromArgb(255, 255, 192);
        Color inColor = Color.FromArgb(255, 255, 192);

        Color noneFontColor = Color.Black;
        Color bookingFontColor = Color.Orange;
        Color inFontColor = Color.Orange;

        MItem item;
        MCustomer cust;
        MSetting set;
        TDesk tdesk;
        MDesk mdesk;

        private void FormBilliard_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SaveLog(ListOfAction.Open, string.Empty, ListOfTable.TDesk, lbl_UserName.Text);

            //set numeric updown
            ModuleControlSettings.SetNumericUpDown(numericUpDown_ItemQuantity);
            ModuleControlSettings.SetNumericUpDown(num_Quantity);
            ModuleControlSettings.SetNumericUpDown(num_Price, true);
            ModuleControlSettings.SetNumericUpDown(num_Jumlah, true);
            ModuleControlSettings.SetNumericUpDown(num_Disc);
            ModuleControlSettings.SetNumericUpDown(num_Total, true);

            ModuleControlSettings.SetNumericUpDown(num_Tax);
            num_Tax.Minimum = 0;
            num_Tax.Maximum = 100;
            ModuleControlSettings.SetNumericUpDown(num_TaxValue);

            ModuleControlSettings.SetNumericUpDown(num_SubTotal, true);
            num_SubTotal.Minimum = decimal.MinValue;
            ModuleControlSettings.SetNumericUpDown(num_TransDisc);
            num_TransDisc.Minimum = 0;
            num_TransDisc.Maximum = 100;
            ModuleControlSettings.SetNumericUpDown(num_GrandTotal, true);

            //set textbox suggest
            ModuleControlSettings.SetCustomerTextBoxSuggest(txt_CustId);
            ModuleControlSettings.SetItemTextBoxSuggest(txt_ItemId);

            splitContainer1.Visible = false;
            CreateMDeskButton();

            PictureBox searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(txt_CustId, ListOfSearchWindow.SearchCustomer.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicCustomer_Click);
            txt_CustId.Controls.Add(searchPic);

            searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(txt_ItemId, ListOfSearchWindow.SearchItem.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicItem_Click);
            txt_ItemId.Controls.Add(searchPic);
        }

        private void CreateMDeskButton()
        {

            splitContainer3.Panel2.Controls.Clear();


            IList listofbil = DataMaster.GetAllSortBy(typeof(MDesk), MDesk.ColumnNames.DeskOrder, "ASC");

            contextMenuStrip_Desk.Items.Clear();
            contextMenuStrip_MainDesk.Items.Clear();

            ToolStripMenuItem menu;
            for (int i = 0; i < listofbil.Count; i++)
            {
                mdesk = (MDesk)listofbil[i];
                if (mdesk.DeskStatus == ListOfDeskStatus.Active.ToString() || mdesk.DeskStatus == ListOfDeskStatus.Off.ToString())
                {
                    menu = new ToolStripMenuItem();
                    menu.Text = "Pindah ke meja " + mdesk.DeskId;
                    menu.ToolTipText = mdesk.DeskId;
                    menu.Click += new EventHandler(menu_Click);
                    contextMenuStrip_Desk.Items.Add(menu);
                }
            }

            Button btn;
            int xActive = 0;
            int yActive = 0;
            int deskWidth = 85;
            int deskHeight = 45;
            for (int i = 0; i < listofbil.Count; i++)
            {
                mdesk = (MDesk)listofbil[i];
                if (mdesk.DeskStatus == ListOfDeskStatus.Active.ToString() || mdesk.DeskStatus == ListOfDeskStatus.Off.ToString())
                {

                    btn = new Button();

                    btn.Name = mdesk.DeskId;
                    //btn.ContextMenuStrip = contextMenuStrip_Desk;

                    //btn.BackColor = Color.FromKnownColor(KnownColor.Control);
                    btn.BackColor = noneColor;
                    btn.Font = new Font("Verdana", 16, GraphicsUnit.Point);

                    btn.Size = new Size(deskWidth, deskHeight);

                    btn.Location = new Point(xActive, yActive);
                    xActive += deskWidth + 5;
                    if ((xActive + deskWidth) > splitContainer3.Panel2.Width)
                    {
                        yActive += deskHeight + 5;
                        xActive = 0;
                    }

                    btn.Text = mdesk.DeskId;

                    if (mdesk.DeskStatus.Equals(ListOfDeskStatus.Active.ToString()) || mdesk.DeskStatus.Equals(ListOfDeskStatus.Active.ToString()))
                        btn.ForeColor = Color.White;
                    else if (mdesk.DeskStatus.Equals(ListOfDeskStatus.Off.ToString()))
                        btn.Enabled = false;

                    activeButton = btn;

                    tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, mdesk.DeskId);

                    if (tdesk != null)
                    {
                        if (tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.None.ToString()) || tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.Paid.ToString()))
                        {
                            btn.BackColor = noneColor;
                            btn.ForeColor = noneFontColor;
                        }
                        else if (tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.Booking.ToString()))
                        {
                            btn.BackColor = bookingColor;
                            btn.ForeColor = bookingFontColor;
                        }
                        else if (tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.In.ToString()))
                        {
                            btn.BackColor = inColor;
                            btn.ForeColor = inFontColor;
                        }
                        else if (tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.Out.ToString()))
                        {
                            btn.BackColor = noneColor;
                            btn.ForeColor = noneFontColor;
                        }
                    }
                    else
                    {
                        btn.BackColor = noneColor;
                        btn.ForeColor = noneFontColor;
                    }
                    //btn.AllowDrop = true;
                    //btn.DoDragDrop(mbil.DeskId, DragDropEffects.Copy);
                    //btn.MouseDown += new MouseEventHandler(btn_MouseDown);
                    //btn.DragDrop += new DragEventHandler(btn_DragDrop);
                    //btn.DragEnter += new DragEventHandler(btn_DragEnter);
                    //btn.MouseUp += new MouseEventHandler(btn_Click);
                    btn.Click += new EventHandler(btn_Click);


                    menu = new ToolStripMenuItem();
                    menu.Text = "Meja " + mdesk.DeskId;
                    KeysConverter kConv = new KeysConverter();
                    Keys k;

                    if (ModuleControlSettings.isDecimal(mdesk.DeskId))
                    {
                        int deskNo = Convert.ToInt32(mdesk.DeskId);
                        k = (Keys)kConv.ConvertFromString("D" + mdesk.DeskId.Substring(mdesk.DeskId.Length - 1, 1));
                        if (deskNo < 10)
                        {
                            menu.ShortcutKeys = Keys.Control | k;
                        }
                        else if (deskNo < 20)
                        {
                            menu.ShortcutKeys = Keys.Control | Keys.Shift | k;
                        }
                        else if (deskNo < 30)
                        {
                            menu.ShortcutKeys = Keys.Control | Keys.Shift | Keys.Alt | k;
                        }
                    }
                    else
                    {
                        k = (Keys)kConv.ConvertFromString(mdesk.DeskId.Substring(0, 1));
                        menu.ShortcutKeys = Keys.Control | k;
                    }

                    menu.Click += new EventHandler(menu_Click2);
                    contextMenuStrip_MainDesk.Items.Add(menu);

                    splitContainer3.Panel2.Controls.Add(btn);
                }
            }

        }

        private void menu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;

            if (btn_CurrentDesk.Text.Replace("&", "").Equals(menu.ToolTipText))
            {
                RecreateBalloon();
                balloonHelp.Caption = "Pindah Meja Gagal";
                balloonHelp.Content = "Pindah meja tidak bisa dilakukan dimeja yang sama.";
                balloonHelp.ShowBalloon(btn_CurrentDesk);
                return;
            }
            else if (btn_CurrentDesk.BackColor == noneColor)
            {
                RecreateBalloon();
                balloonHelp.Caption = "Pindah Meja Gagal";
                balloonHelp.Content = "Pindah meja tidak bisa dilakukan di meja yang kosong.";
                balloonHelp.ShowBalloon(btn_CurrentDesk);
                return;
            }

            //check if destination desk is empty
            tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, menu.ToolTipText);
            if (tdesk != null)
            {
                if (!(tdesk.DeskStatus == ListOfDeskPaymentStatus.None.ToString() || tdesk.DeskStatus == ListOfDeskPaymentStatus.Paid.ToString()))
                {
                    RecreateBalloon();
                    balloonHelp.Caption = "Pindah Meja Gagal";
                    balloonHelp.Content = "Meja yang dituju tidak kosong.";
                    balloonHelp.ShowBalloon(btn_CurrentDesk);
                    return;
                }
            }

            if (MessageBox.Show("Anda yakin pindah dari meja " + btn_CurrentDesk.Text.Replace("&", "") + " ke meja " + menu.ToolTipText, "Konfirmasi pindah meja?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, btn_CurrentDesk.Text.Replace("&", ""));

                //bool IsSave = true;

                //if (tdesk == null)
                //{
                //    IsSave = true;
                //    tdesk = new TDesk();
                //}
                //else
                //    IsSave = false;

                tdesk.DeskId = menu.ToolTipText;
                tdesk.ModifiedBy = lbl_UserName.Text;
                tdesk.ModifiedDate = DateTime.Now;

                //if (IsSave)
                //    DataMaster.SavePersistence(tdesk);
                //else
                DataMaster.UpdatePersistence(tdesk);

                ModuleControlSettings.SaveLog(ListOfAction.Update, activeButton.Name + ";Pindah ke meja = " + menu.ToolTipText, ListOfTable.TDesk, lbl_UserName.Text);

                //reset source tbil
                tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, btn_CurrentDesk.Text.Replace("&", ""));

                if (tdesk != null)
                    DataMaster.Delete(tdesk);
                CreateMDeskButton();
                this.Refresh();

                Button b = (Button)splitContainer3.Panel2.Controls[menu.ToolTipText];
                btn_Click(b, null);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ShowPaid(false);
            if (splitContainer1.Visible == false)
                splitContainer1.Visible = true;

            activeButton = (Button)sender;

            gb_Trans.Visible = false;

            mdesk = (MDesk)DataMaster.GetObjectById(typeof(MDesk), activeButton.Name);

            lbl_TempTransaction.Text = ListOfTransaction.Sales.ToString();

            lbl_TempDeskType.Text = mdesk.DeskStatus;

            tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, activeButton.Name);

            if (tdesk != null)
                SetDisplay(tdesk.DeskStatus);
            else
                SetDisplay(ListOfBilliardPaymentStatus.None.ToString());

            EditView();
        }

        Button senderButton;

        private bool ValidateCustomer()
        {
            //RecreateBalloon(this, EventArgs.Empty);
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(txt_CustId.Text))
            {
                balloonHelp.Content = "Pelanggan harus diisi";
                balloonHelp.ShowBalloon(txt_CustId);
                txt_CustId.Focus();
                return false;
            }
            return true;
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            if (btn_In.Text.Equals("&Masuk"))
            {
                if (!ValidateCustomer())
                    return;

                SaveTDesk(ListOfBilliardPaymentStatus.In.ToString(), false);
                button_Tambah.Focus();
            }
            else
            {
                if (tTransactionDetailDataGridView.RowCount > 0)
                {
                    MessageBox.Show("Transaksi yang tidak kosong tidak bisa dibatalkan", "Pembatalan Transaksi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SaveTDesk(ListOfBilliardPaymentStatus.None.ToString(), false);

            }
        }

        private void RecreateBalloon()
        {
            balloonHelp = new Balloon.NET.BalloonHelp();
            balloonHelp.Icon = Properties.Resources.warning;
            balloonHelp.ShowCloseButton = false;
        }
        //private FormTransaction f_Trans;
        private void btn_Out_Click(object sender, EventArgs e)
        {
            if (!btn_CurrentDesk.Visible)
                return;

            if (tTransactionDetailDataGridView.RowCount == 0)
            {
                MessageBox.Show("Transaksi yang kosong tidak bisa diproses.", "Transaksi tidak bisa diproses.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ItemId.Select();
                txt_ItemId.Focus();
                return;
            }

            ShowPaid(true);

            num_TransDisc.Value = 0;
            num_TransDisc.ResetText();
            num_TransDisc.Focus();
            num_TransDisc.Select();

            num_Tax.Value = 10;
            //num_Tax.ResetText();

            //num_Pay.Focus();
            //num_Pay.Select();
            //if (f_Trans != null)
            //{
            //    if (!f_Trans.IsDisposed)
            //    {
            //        f_Trans.WindowState = FormWindowState.Normal;
            //        f_Trans.BringToFront();
            //    }
            //    else
            //        f_Trans = new FormTransaction();
            //}
            //else
            //    f_Trans = new FormTransaction();

            //f_Trans.SetInitialSettings();
            //f_Trans.TopLevel = true;
            ////lock input from transaction form

            //f_Trans.groupBox6.Enabled = false;
            //f_Trans.groupBox9.Enabled = false;
            //f_Trans.button1.Enabled = false;
            //f_Trans.button2.Enabled = false;
            //f_Trans.dt_TransactionDate.Enabled = false;
            //f_Trans.txt_TransactionId.Text = lbl_TransactionId.Text;
            //f_Trans.lbl_TempTransaction.Text = lbl_TempTransaction.Text;
            //f_Trans.lbl_TempDesk.Text = activeButton.Name;

            //f_Trans.Show();


            //f_Trans.txt_CustId.Text = txt_CustId.Text;
            //f_Trans.txt_CustName.Text = txt_CustName.Text;
            //f_Trans.lbl_EmployeeId.Text = lbl_UserName.Text;

            //string[] field;
            //for (int i = 0; i < tTransactionDetailDataGridView.Rows.Count; i++)
            //{
            //    field = new string[7];

            //    //item id
            //    field[0] = tTransactionDetailDataGridView.Rows[i].Cells[0].Value.ToString();

            //    //keterangan
            //    item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), "ItemId", tTransactionDetailDataGridView.Rows[i].Cells[0].Value.ToString());
            //    if (item != null)
            //        field[1] = item.ItemName;
            //    else
            //        field[1] = "";
            //    //field[1] = tTransactionDetailDataGridView.Rows[i].Cells[1].Value.ToString();

            //    //kuantitas
            //    field[2] = ModuleControlSettings.NumericFormat(tTransactionDetailDataGridView.Rows[i].Cells[2].Value.ToString());
            //    //harga / unit
            //    field[3] = ModuleControlSettings.NumericFormat(tTransactionDetailDataGridView.Rows[i].Cells[3].Value.ToString());
            //    //jumlah
            //    field[4] = ModuleControlSettings.NumericFormat(tTransactionDetailDataGridView.Rows[i].Cells[4].Value.ToString());

            //    //diskon
            //    field[5] = ModuleControlSettings.NumericFormat(tTransactionDetailDataGridView.Rows[i].Cells[5].Value.ToString());
            //    //total
            //    field[6] = ModuleControlSettings.NumericFormat(tTransactionDetailDataGridView.Rows[i].Cells[6].Value.ToString());

            //    f_Trans.grid_Trans.Rows.Insert(0, field);

            //}

            //f_Trans.TransactionHasSaved += new EventHandler(f_Trans_TransactionHasSaved);
            //f_Trans.Size = new Size(f_Trans.Size.Width - 300, f_Trans.Size.Height);
            //f_Trans.Refresh();
            //f_Trans.num_Pay.Select();
        }

        //private void f_Trans_TransactionHasSaved(object sender, EventArgs e)
        //{
        //    if (sender != null)
        //    {
        //        f_Trans.Close();
        //        //SaveTBilliard(ListOfBilliardPaymentStatus.Paid.ToString(), false);
        //        tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, activeButton.Name);
        //        DataMaster.Delete(tdesk);

        //        SetDisplay(ListOfDeskPaymentStatus.None.ToString());
        //        ResetTransactionStatus();
        //        BindTransactionDetail();
        //    }
        //}

        private void searchPicCustomer_Click(object sender, EventArgs e)
        {
            OpenFormSearchCustomer();
        }

        FormSearchCustomer f_SearchCustomer;//= new FormSearchItem();
        private void OpenFormSearchCustomer()
        {
            if (f_SearchCustomer != null)
            {
                if (!f_SearchCustomer.IsDisposed)
                    f_SearchCustomer.Close();
            }
            f_SearchCustomer = new FormSearchCustomer();

            f_SearchCustomer.CustomerHasSelected += new EventHandler(f_SearchCustomer_CustomerHasSelected);
            // f_SearchCustomer.ShowInTaskbar = false;
            f_SearchCustomer.ShowDialog();
        }


        private void f_SearchCustomer_CustomerHasSelected(object sender, EventArgs e)
        {
            if (f_SearchCustomer.grid_Search.Rows.Count > 0)
            {
                txt_CustId.Text = f_SearchCustomer.grid_Search.Rows[f_SearchCustomer.grid_Search.CurrentRow.Index].Cells[0].Value.ToString();
                txt_CustName.Text = f_SearchCustomer.grid_Search.Rows[f_SearchCustomer.grid_Search.CurrentRow.Index].Cells[1].Value.ToString();
            }
        }

        private void searchPicItem_Click(object sender, EventArgs e)
        {
            OpenFormSearchItem();
        }

        FormSearchItem f_SearchItem;//= new FormSearchItem();
        private void OpenFormSearchItem()
        {
            if (f_SearchItem != null)
            {
                if (!f_SearchItem.IsDisposed)
                    f_SearchItem.Close();
            }
            f_SearchItem = new FormSearchItem();

            f_SearchItem.ItemHasSelected += new EventHandler(f_SearchItem_ItemHasSelected);
            f_SearchItem.lbl_TempTransaction.Text = lbl_TempTransaction.Text;
            //f_SearchItem.ShowInTaskbar = false;
            f_SearchItem.ShowDialog();
        }

        private void f_SearchItem_ItemHasSelected(object sender, EventArgs e)
        {
            if (f_SearchItem.grid_Search.Rows.Count > 0)
            {
                txt_ItemId.Text = f_SearchItem.grid_Search.Rows[f_SearchItem.grid_Search.CurrentRow.Index].Cells[0].Value.ToString();
                txt_ItemId_Validating(null, null);
            }

        }

        private void txt_CustId_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(txt_CustId, ListOfSearchWindow.SearchCustomer.ToString(), true);
        }

        private void txt_CustId_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(txt_CustId, ListOfSearchWindow.SearchCustomer.ToString(), false);
        }

        private void txt_ItemId_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(txt_ItemId, ListOfSearchWindow.SearchItem.ToString(), true);
        }

        private void txt_ItemId_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(txt_ItemId, ListOfSearchWindow.SearchItem.ToString(), false);
        }

        private void SaveTDesk(string DisplayBilStatus, bool IsSetDisplayByData)
        {
            tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, activeButton.Name);

            bool IsSave = true;
            SetDisplay(DisplayBilStatus);

            if (tdesk == null)
            {
                IsSave = true;
                tdesk = new TDesk();
            }
            else
            {
                IsSave = false;
                if (IsSetDisplayByData)
                    SetDisplay(tdesk.DeskStatus);
            }

            tdesk.DeskCustId = txt_CustId.Text;
            tdesk.DeskId = activeButton.Name;
            tdesk.DeskBookingDate = Convert.ToDateTime(dt_In.Text);
            tdesk.DeskInDate = Convert.ToDateTime(dt_In.Text);

            tdesk.DeskOutDate = Convert.ToDateTime(dt_Out.Text);
            tdesk.DeskStatus = DisplayBilStatus;
            tdesk.DeskTransactionId = Convert.ToDecimal(lbl_TransactionId.Text);
            tdesk.DeskGrandTotal = Convert.ToDecimal(lbl_RentalPrice.Text.Replace("Rp. ", ""));
            tdesk.EmployeeId = lbl_UserName.Text;
            tdesk.ModifiedBy = lbl_UserName.Text;
            tdesk.ModifiedDate = DateTime.Now;

            string s = "";
            switch (DisplayBilStatus)
            {
                case "In":
                    s = "Masuk";
                    break;
                case "None":
                    s = "Batal";
                    break;
                default:
                    s = "Masuk";
                    break;
            }

            if (IsSave)
            {
                DataMaster.SavePersistence(tdesk);
                ModuleControlSettings.SaveLog(ListOfAction.Insert, activeButton.Name + ";" + s, ListOfTable.TDesk, lbl_UserName.Text);
            }
            else if (DisplayBilStatus.Equals(ListOfBilliardPaymentStatus.None.ToString()))
            {
                DataMaster.Delete(tdesk);
                ModuleControlSettings.SaveLog(ListOfAction.Update, activeButton.Name + ";" + s, ListOfTable.TDesk, lbl_UserName.Text);
            }
            else if (!IsSave)
            {
                DataMaster.UpdatePersistence(tdesk);
                ModuleControlSettings.SaveLog(ListOfAction.Update, activeButton.Name + ";" + s, ListOfTable.TDesk, lbl_UserName.Text);
            }

        }

        private void SetDisplay(string DisplayBilStatus)
        {
            if (DisplayBilStatus.Equals(ListOfBilliardPaymentStatus.None.ToString()) || DisplayBilStatus.Equals(ListOfBilliardPaymentStatus.Paid.ToString()))
            {

                txt_CustId.Text = "CASH";
                txt_CustName.ResetText();

                lbl_TransactionId.Text = DateTime.Now.ToFileTimeUtc().ToString();
                tTransactionDetailDataGridView.Rows.Clear();

                activeButton.BackColor = noneColor;
                activeButton.ForeColor = noneFontColor;

                dt_In.Text = DateTime.Now.ToString(ModuleControlSettings.DateTimeFormat());
                dt_Out.Text = DateTime.Now.ToString(ModuleControlSettings.DateTimeFormat());

                //set group box
                gb_Trans.Enabled = false;
                gb_Cust.Enabled = true;

                //set datepicker
                dt_In.Enabled = true;
                btn_In.Enabled = true;
                btn_In.Text = "&Masuk";
                dt_Out.Enabled = false;
                btn_Out.Enabled = false;
                button_Tambah.Enabled = false;

                txt_CustId.Focus();
                txt_CustId.Select();

            }
            else if (DisplayBilStatus.Equals(ListOfBilliardPaymentStatus.Booking.ToString()))
            {
                activeButton.BackColor = bookingColor;
                activeButton.ForeColor = bookingFontColor;

                //set group box
                gb_Trans.Enabled = false;
                gb_Cust.Enabled = true;

                //set datepicker
                dt_In.Enabled = true;
                btn_In.Enabled = true;
                btn_In.Text = "&Masuk";
                dt_Out.Enabled = false;
                btn_Out.Enabled = false;
                button_Tambah.Enabled = false;

                txt_CustId.Focus();
                txt_CustId.Select();
            }
            else if (DisplayBilStatus.Equals(ListOfBilliardPaymentStatus.In.ToString()))
            {
                activeButton.BackColor = inColor;
                activeButton.ForeColor = inFontColor;

                //set group box
                gb_Trans.Enabled = true;
                gb_Cust.Enabled = false;

                //set datepicker
                dt_In.Enabled = false;
                btn_In.Enabled = true;
                btn_In.Text = "Batal";
                dt_Out.Enabled = true;
                btn_Out.Enabled = true;
                button_Tambah.Enabled = true;

                button_Tambah.Focus();
                button_Tambah.Select();

            }
            else if (DisplayBilStatus.Equals(ListOfBilliardPaymentStatus.Out.ToString()))
            {

                txt_CustId.Text = "CASH";

                activeButton.BackColor = noneColor;
                activeButton.ForeColor = noneFontColor;

                //set group box
                gb_Trans.Enabled = false;
                gb_Cust.Enabled = true;

                //set datepicker
                dt_In.Enabled = true;
                btn_In.Enabled = true;
                btn_In.Text = "&Masuk";
                dt_Out.Enabled = false;
                btn_Out.Enabled = false;
                button_Tambah.Enabled = false;

                txt_CustId.Focus();
                txt_CustId.Select();
            }

            btn_CurrentDesk.Text = activeButton.Text;
            btn_CurrentDesk.BackColor = activeButton.BackColor;
            btn_CurrentDesk.ForeColor = activeButton.ForeColor;
            btn_CurrentDesk.Visible = true;
        }

        private void EditView()
        {
            tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, activeButton.Name);

            if (tdesk != null)
            {
                if (!(tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.Paid.ToString()) || tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.None.ToString())))
                {

                    lbl_TransactionId.Text = tdesk.DeskTransactionId.ToString();

                    BindTransactionDetail();

                    if (tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.Booking.ToString()))
                    {
                        dt_In.Text = DateTime.Now.ToString(ModuleControlSettings.DateTimeFormat());
                        dt_Out.Text = DateTime.Now.ToString(ModuleControlSettings.DateTimeFormat());
                    }
                    else if (tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.In.ToString()))
                    {
                        dt_In.Text = tdesk.DeskInDate.ToString(ModuleControlSettings.DateTimeFormat());
                        dt_Out.Text = DateTime.Now.ToString(ModuleControlSettings.DateTimeFormat());
                    }
                    else if (tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.Out.ToString()))
                    {
                        dt_Out.Text = tdesk.DeskOutDate.ToString(ModuleControlSettings.DateTimeFormat());
                        dt_In.Text = tdesk.DeskInDate.ToString(ModuleControlSettings.DateTimeFormat());
                    }

                    txt_CustId.Text = tdesk.DeskCustId;

                    cust = (MCustomer)DataMaster.GetObjectByProperty(typeof(MCustomer), MCustomer.ColumnNames.CustomerId, tdesk.DeskCustId);
                    if (cust != null)
                        txt_CustName.Text = cust.CustomerName;
                    else
                        txt_CustName.ResetText();
                }
                else
                    ResetTransactionStatus();
            }
            else
                ResetTransactionStatus();

            BindTransactionDetail();
        }

        private void ResetTransactionStatus()
        {
            dt_In.Text = DateTime.Now.ToString(ModuleControlSettings.DateTimeFormat());
            dt_Out.Text = DateTime.Now.ToString(ModuleControlSettings.DateTimeFormat());

            txt_CustId.Text = "CASH";
            txt_CustName.ResetText();
            lbl_TransactionId.Text = DateTime.Now.ToFileTimeUtc().ToString();
        }

        private void CalculateItemPrice(object sender, EventArgs e)
        {
            try
            {
                decimal q = num_Quantity.Value;
                decimal p = num_Price.Value;
                decimal j = q * p;
                num_Jumlah.Value = j;

                decimal d = num_Disc.Value;
                decimal t = j * ((100 - d) / 100);
                num_Total.Value = t;

            }
            catch (Exception)
            {
                //throw;
            }

            if (sender == num_Disc)
            {
                bool needPass = (num_Disc.Value > 0);
                gb_DiscPass.Visible = needPass;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (!ValidateFormDetail())
                return;

            SaveTransactionDetail();
            BindTransactionDetail();

            gb_Trans.Visible = false;

            this.Refresh();
            button_Tambah.Focus();
        }

        private void ResetTransactionDetail()
        {
            //gb_DiscPass.Visible = false;
            //txt_DiscPass.ResetText();

            txt_ItemId.ResetText();
            txt_ItemName.ResetText();
            lbl_Satuan.ResetText();
            num_Quantity.Value = 1;
            num_Price.Value = 0;
            num_Jumlah.Value = 0;
            num_Disc.Value = 0;
            num_Total.Value = 0;

            num_Quantity.ResetText();

            ModuleControlSettings.SetGridDataView(tTransactionDetailDataGridView);
        }

        private void SaveTransactionDetail()
        {
            TTransactionDetail det = (TTransactionDetail)DataMaster.GetObjectByProperty(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, Convert.ToDecimal(lbl_TransactionId.Text), TTransactionDetail.ColumnNames.ItemId, txt_ItemId.Text);

            bool isSave = false;
            if (det == null)
            {
                det = new TTransactionDetail();
                isSave = true;
            }
            //TTransactionDetail det = new TTransactionDetail();
            det.Disc = num_Disc.Value;
            det.ItemId = txt_ItemId.Text;
            det.Ppn = 0;
            det.Price = num_Price.Value;
            det.Quantity = det.Quantity + num_Quantity.Value;
            det.Total = det.Total + num_Total.Value;
            det.TransactionId = Convert.ToDecimal(lbl_TransactionId.Text);
            det.Jumlah = det.Jumlah + num_Jumlah.Value;
            det.ModifiedBy = lbl_UserName.Text;
            det.ModifiedDate = DateTime.Now;

            if (isSave)
                DataMaster.SavePersistence(det);
            else
                DataMaster.UpdatePersistence(det);

            tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, activeButton.Name);
            tdesk.DeskGrandTotal = tdesk.DeskGrandTotal + num_Total.Value;
            tdesk.ModifiedBy = lbl_UserName.Text;
            tdesk.ModifiedDate = DateTime.Now;
            DataMaster.UpdatePersistence(tdesk);

            ModuleControlSettings.SaveLog(ListOfAction.Insert, "Meja = " + activeButton.Name + ";Item = " + det.ItemId + ";", ListOfTable.TTransactionDetail, lbl_UserName.Text);
        }

        private void BindTransactionDetail()
        {
            tTransactionDetailBindingSource.Clear();
            tTransactionDetailBindingSource.DataSource = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, Convert.ToDecimal(lbl_TransactionId.Text));

            tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, activeButton.Name);
            if (tdesk != null)
                lbl_RentalPrice.Text = ModuleControlSettings.NumericFormat(tdesk.DeskGrandTotal, true);
            else
                lbl_RentalPrice.Text = ModuleControlSettings.NumericFormat(0, true);

            //set gridview transaction detail
            ModuleControlSettings.SetGridDataView(tTransactionDetailDataGridView);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ResetTransactionDetail();
            gb_Trans.Visible = false;
        }

        private bool ValidateFormDetail()
        {
            //RecreateBalloon(this, EventArgs.Empty);
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(txt_ItemId.Text))
            {
                balloonHelp.Content = "Item harus diisi";
                balloonHelp.ShowBalloon(txt_ItemId);
                txt_ItemId.Focus();
                return false;
            }
            else
            {
                item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), "ItemId", txt_ItemId.Text);
                if (item == null)
                {
                    balloonHelp.Caption = "Validasi data kurang";
                    balloonHelp.Content = "Item " + txt_ItemId.Text + " tidak ada dalam database. \n Pastikan anda menulis kode yang tepat atau \n pilih item dengan mengklik gambar disamping untuk mencari item.";
                    balloonHelp.ShowBalloon(txt_ItemId);
                    txt_ItemId.Focus();
                    return false;
                }
            }

            return true;
        }

        private void txt_ItemId_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_ItemId.Text.Trim()))
            {
                item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), "ItemId", txt_ItemId.Text);

                if (item != null)
                {
                    txt_ItemName.Text = item.ItemName;
                    lbl_Satuan.Text = item.ItemSatuan;

                    if (lbl_TempTransaction.Text.Equals(ListOfTransaction.Sales.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSales.ToString()))
                        num_Price.Value = item.ItemPriceMax;
                    else if (lbl_TempTransaction.Text.Equals(ListOfTransaction.SalesVIP.ToString()) || lbl_TempTransaction.Text.Equals(ListOfTransaction.ReturSalesVIP.ToString()))
                        num_Price.Value = item.ItemPriceMaxVip;
                }
            }
        }

        private void txt_CustId_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_CustId.Text.Trim()))
            {
                cust = (MCustomer)DataMaster.GetObjectByProperty(typeof(MCustomer), "CustomerId", txt_CustId.Text);

                if (cust != null)
                    txt_CustName.Text = cust.CustomerName;
                else
                    txt_CustName.ResetText();
            }
        }


        private void button_Tambah_Click(object sender, EventArgs e)
        {
            ResetTransactionDetail();
            if (gb_Trans.Enabled)
                gb_Trans.Visible = true;

            txt_ItemId.Focus();
            txt_ItemId.Select();
        }

        private void button_Hapus_Click(object sender, EventArgs e)
        {
            if (tTransactionDetailDataGridView.Rows.Count > 0)
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    decimal total = 0;
                    TTransactionDetail det = (TTransactionDetail)DataMaster.GetObjectByProperty(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionDetailId, Convert.ToDecimal(tTransactionDetailDataGridView.CurrentRow.Cells[1].Value.ToString()));
                    total = det.Total;
                    DataMaster.Delete(det);

                    //update tdesk
                    tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, activeButton.Name);
                    tdesk.DeskGrandTotal = tdesk.DeskGrandTotal - total;
                    tdesk.ModifiedBy = lbl_UserName.Text;
                    tdesk.ModifiedDate = DateTime.Now;
                    DataMaster.UpdatePersistence(tdesk);

                    ModuleControlSettings.SaveLog(ListOfAction.Delete, "Meja = " + activeButton.Name + ";Item = " + det.ItemId + ";", ListOfTable.TTransactionDetail, lbl_UserName.Text);
                    BindTransactionDetail();
                }

            }
        }

        private void detailControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender == null)
                txt_CustId.Focus();
            else
            {
                if (e == null)
                    return;

                if (e.KeyCode == Keys.Escape)
                    button16_Click(null, null);

                if (e.KeyCode != Keys.Enter)
                    return;

                Control c = (Control)sender;
                if (sender == txt_CustId)
                    btn_In.Select();
                else if (sender == btn_In)
                    button_Tambah.Select();
                else if (sender == button_Tambah)
                    txt_ItemId.Select();
                else if (sender == txt_ItemId)
                    num_Quantity.Select();
                else if (sender == num_Quantity)
                    button15.Select();
                //    num_Disc.Select();
                //else if (sender == num_Disc)
                //{
                //    if (num_Disc.Value > 0)
                //    {
                //        gb_DiscPass.Visible = true;
                //        txt_DiscPass.Select();
                //    }
                //    else
                //    {
                //        gb_DiscPass.Visible = false;
                //        button15.Select();
                //    }
                //}
                //else if (sender == txt_DiscPass)
                //    button15.Select();
                else if (sender == button15)
                    button_Tambah.Select();

                else if (sender == num_TransDisc)
                {
                    if (num_TransDisc.Value > 0)
                    {
                        gb_DiscPass.Visible = true;
                        gb_DiscPass.Select();
                        txt_DiscPass.Focus();
                        txt_DiscPass.Select();
                    }
                    else
                    {
                        gb_DiscPass.Visible = false;
                        num_Tax.Select();
                        //num_Pay.Focus();
                        //num_Pay.Select();
                    }
                }
                else if (sender == txt_DiscPass)
                    num_Tax.Select();
                else if (sender == num_Tax)
                    num_TaxValue.Select();
                // button_OK.Select();
                else if (sender == num_TaxValue)
                    button_OK.Select();
            }
        }

        private void tTransactionDetailDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                button_Hapus_Click(null, null);
        }

        private void ShowPaid(bool visible)
        {
            lbl_TransDisc.Visible = visible;
            lbl_TransPersen.Visible = visible;
            num_TransDisc.Visible = visible;
            lbl_Tax.Visible = visible;
            num_Tax.Visible = visible;
            lbl_TaxValue.Visible = visible;
            num_TaxValue.Visible = visible;
            lbl_SubTotal.Visible = visible;
            num_SubTotal.Visible = visible;
            button_OK.Visible = visible;
            lbl_SubTotal.Text = "Grand Total : ";
            lbl_GrandTotal.Visible = visible;
            num_GrandTotal.Visible = visible;
            lbl_Line.Visible = visible;
            lbl_Line2.Visible = visible;

            gb_DiscPass.Visible = false;
            txt_DiscPass.ResetText();
        }

        private void num_Pay_ValueChanged(object sender, EventArgs e)
        {
            decimal tot = Convert.ToDecimal(lbl_RentalPrice.Text.Replace("Rp. ", ""));
            decimal subtotal = tot * ((100 - num_TransDisc.Value) / 100);
            decimal tax = (num_Tax.Value / 100) * subtotal;
            if (sender == num_TaxValue)
            {
                tax = num_TaxValue.Value;
            }
            num_SubTotal.Value = subtotal;
            num_TaxValue.Value = tax;
            num_GrandTotal.Value = subtotal + tax;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (num_TransDisc.Value > 0)
            {
                TCafeSetting cafeSet = (TCafeSetting)DataMaster.GetObjectByProperty(typeof(TCafeSetting), TCafeSetting.ColumnNames.SettingId, AppCode.AssemblyProduct, TCafeSetting.ColumnNames.DiscountPassword, txt_DiscPass.Text);
                if (cafeSet == null)
                {
                    balloonHelp.Caption = "Kata kunci salah";
                    balloonHelp.Content = "Kata kunci untuk menginput diskon salah. Silahkan ulangi.";
                    balloonHelp.ShowBalloon(txt_DiscPass);
                    gb_DiscPass.Visible = true;
                    txt_DiscPass.Select();
                    return;
                }
            }

            //if (num_Back.Value < 0)
            //{
            //    RecreateBalloon();
            //    balloonHelp.Content = "Total yang harus dibayar lebih kecil dari pembayaran !!";
            //    balloonHelp.ShowBalloon(num_Pay);
            //    num_Pay.Focus();
            //    num_Pay.Select();
            //    return;
            //}

            if (set != null)
            {
                if (set.AutoPrintSales)
                    PrintFactur();
                else
                {
                    DialogResult res = MessageBox.Show("Cetak faktur penjualan?", "Konfirmasi cetak faktur penjualan", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                        PrintFactur();
                    else if (res == DialogResult.No)
                        SaveTransactionInterface();
                }
            }
            else
                SaveTransactionInterface();
        }

        private void SaveTransactionInterface()
        {
            SaveTransaction();
            ChangeStok();

            ModuleControlSettings.SaveLog(ListOfAction.Insert, "Penjualan;Meja = " + activeButton.Name + ";", ListOfTable.TTransaction, lbl_UserName.Text);

            tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, activeButton.Name);
            if (tdesk != null)
                DataMaster.Delete(tdesk);

            SetDisplay(ListOfDeskPaymentStatus.None.ToString());
            ResetTransactionStatus();
            BindTransactionDetail();
            ShowPaid(false);
        }

        private FormPrintStatus f_Stat;
        private void PrintFactur()
        {
            printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            printDocument1.Print();

            if (f_Stat != null)
            {
                if (!f_Stat.IsDisposed)
                    f_Stat.Close();
            }
            f_Stat = new FormPrintStatus();
            f_Stat.PrintStatusHasSelected += new EventHandler(f_Stat_PrintStatusHasSelected);
            f_Stat.TopLevel = true;
            f_Stat.ShowDialog(this);
        }

        private void f_Stat_PrintStatusHasSelected(object sender, EventArgs e)
        {
            if (sender.Equals(ListOfPrintStatus.PrintOK))
                SaveTransactionInterface();
            else if (sender.Equals(ListOfPrintStatus.PrintFailed))
            {
                PrintFactur();
            }
            else if (sender.Equals(ListOfPrintStatus.PrintCancel))
            {
            }
        }

        private void SaveTransaction()
        {
            decimal tot = Convert.ToDecimal(lbl_RentalPrice.Text.Replace("Rp. ", ""));

            TTransaction t = new TTransaction();
            t.TransactionBy = txt_CustId.Text;
            t.TransactionDate = DateTime.Now;
            t.TransactionDisc = num_TransDisc.Value;
            t.TransactionFactur = AppCode.GenerateFacturNo(btn_CurrentDesk.Text.Replace("&", ""));
            t.TransactionGrandTotal = num_GrandTotal.Value;
            t.TransactionId = Convert.ToDecimal(lbl_TransactionId.Text);
            t.TransactionPaid = tot;
            t.TransactionPpn = num_TaxValue.Value;
            t.TransactionSisa = 0;
            t.TransactionStatus = lbl_TempTransaction.Text;
            t.TransactionSubTotal = num_SubTotal.Value;
            t.TransactionDesk = btn_CurrentDesk.Text.Replace("&", "");
            t.EmployeeId = lbl_EmployeeId.Text;
            t.ModifiedBy = lbl_UserName.Text;
            t.ModifiedDate = DateTime.Now;
            DataMaster.SavePersistence(t);
        }

        private void ChangeStok()
        {
            TTransactionDetail det;
            ItemGudangStok stok;
            MItem item;
            TStokCard krt;

            bool AddStok = false;
            decimal saldo = 0;

            IList listOfTransDetail = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, Convert.ToDecimal(lbl_TransactionId.Text));
            for (int i = 0; i < listOfTransDetail.Count; i++)
            {
                det = (TTransactionDetail)listOfTransDetail[i];
                saldo = 0;
                item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, det.ItemId);
                if (item != null)
                {
                    //if item == barang
                    if (item.ItemTypeId == 1)
                    {
                        //change stok
                        stok = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, det.ItemId);
                        if (stok != null)
                        {
                            if (AddStok)
                                saldo = stok.ItemStok + det.Quantity;
                            else
                                saldo = stok.ItemStok - det.Quantity;

                            stok.ItemStok = saldo;
                            stok.ModifiedBy = lbl_UserName.Text;
                            stok.ModifiedDate = DateTime.Now;

                            DataMaster.UpdatePersistence(stok);
                        }
                        else
                        {
                            stok = new ItemGudangStok();
                            stok.GudangId = 1;
                            stok.ItemId = det.ItemId;
                            stok.ItemMaxStok = 0;
                            stok.ItemMinStok = 0;
                            stok.ItemStok = det.Quantity * -1;
                            stok.ModifiedBy = lbl_UserName.Text;
                            stok.ModifiedDate = DateTime.Now;
                            DataMaster.SavePersistence(stok);
                        }

                    }
                }

                krt = new TStokCard();
                krt.ItemId = det.ItemId;
                krt.StokCardDate = DateTime.Now;
                krt.StokCardPic = lbl_UserName.Text;
                krt.StokCardQuantity = det.Quantity;
                krt.StokCardSaldo = saldo;
                krt.StokCardStatus = AddStok;
                krt.TransactionId = Convert.ToDecimal(lbl_TransactionId.Text);
                krt.ModifiedBy = lbl_UserName.Text;
                krt.ModifiedDate = DateTime.Now;
                DataMaster.SavePersistence(krt);
            }
        }

        private void num_Pay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_OK.Select();
                button_OK.Focus();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Single xPos = e.MarginBounds.Left;
            Single yPos = e.MarginBounds.Top;
            Font printFont = new Font("MS Sans Serif", 10);
            Single lineHeight = printFont.GetHeight(e.Graphics) + 5;

            //Single widthPaper = 480 - e.MarginBounds.Left;
            Single widthPaper = e.PageSettings.PaperSize.Width - e.MarginBounds.Left;
            string txt = "";

            txt = set.CompanyName;
            xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);


            txt = set.CompanyAddress + " " + set.CompanyCity;
            yPos += lineHeight;
            xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            txt = "Telp : " + set.CompanyTelp;
            yPos += lineHeight;
            xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //xPos = e.MarginBounds.Left;
            //yPos += lineHeight * 2;
            //txt = "No : " + AppCode.GenerateFacturNo(btn_CurrentDesk.Text.Replace("&", ""));
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            xPos = e.MarginBounds.Left;
            yPos += lineHeight * 2;
            txt = "Meja No : " + btn_CurrentDesk.Text.Replace("&", "");
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            xPos = e.MarginBounds.Left;
            yPos += lineHeight;
            txt = DateTime.Now.ToString("dd MMMM yyyy HH:mm");
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            yPos += lineHeight;
            for (int i = 0; i < tTransactionDetailDataGridView.Rows.Count; i++)
            {
                //display nama item
                xPos = e.MarginBounds.Left;
                yPos += lineHeight;
                txt = tTransactionDetailDataGridView.Rows[i].Cells[itemIdDataGridViewTextBoxColumn.Name].Value.ToString();
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                //display kuantitas
                xPos = e.MarginBounds.Left;
                yPos += lineHeight;
                txt = ModuleControlSettings.NumericFormat(tTransactionDetailDataGridView.Rows[i].Cells[quantityDataGridViewTextBoxColumn.Name].Value) + " x @" + ModuleControlSettings.NumericFormat(tTransactionDetailDataGridView.Rows[i].Cells[priceDataGridViewTextBoxColumn.Name].Value);
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                ////display total
                txt = ModuleControlSettings.NumericFormat(tTransactionDetailDataGridView.Rows[i].Cells[totalDataGridViewTextBoxColumn.Name].Value, true);
                xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;

                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            }

            if (num_TransDisc.Value > 0)
            {
                //display total
                xPos = e.MarginBounds.Left + 50;
                yPos += lineHeight;
                txt = "Total :  ";
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
                decimal tot = Convert.ToDecimal(lbl_RentalPrice.Text.Replace("Rp. ", ""));
                txt = ModuleControlSettings.NumericFormat(tot, true);
                xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                //display diskon
                xPos = e.MarginBounds.Left + 50;
                yPos += lineHeight;
                txt = "Diskon :  ";
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
                txt = ModuleControlSettings.NumericFormat(num_TransDisc.Value) + "%";
                xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            }

            if (num_TaxValue.Value > 0)
            {
                //display subtotal
                xPos = e.MarginBounds.Left + 50;
                yPos += lineHeight;
                txt = "Sub Total :  ";
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
                txt = ModuleControlSettings.NumericFormat(num_SubTotal.Value, true);
                xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                //display tax
                xPos = e.MarginBounds.Left + 50;
                yPos += lineHeight;
                txt = "Tax :  ";
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
                txt = ModuleControlSettings.NumericFormat(num_TaxValue.Value, true);
                xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            }


            //display grandtotal
            xPos = e.MarginBounds.Left + 50;
            yPos += lineHeight;
            txt = "Grand Total :  ";
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            txt = ModuleControlSettings.NumericFormat(num_GrandTotal.Value, true);
            xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            ////display dibayar
            //xPos = e.MarginBounds.Left + 50;
            //yPos += lineHeight;
            //txt = "Tunai :  ";
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            //txt = ModuleControlSettings.NumericFormat(num_Pay.Value, true);
            ////xPos =  e.MarginBounds.Right -e.Graphics.MeasureString(txt, printFont).Width;
            //xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            ////display kembali
            //xPos = e.MarginBounds.Left + 50;
            //yPos += lineHeight;
            //txt = "Kembali :  ";
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            //txt = ModuleControlSettings.NumericFormat(num_Back.Value, true);
            //xPos = widthPaper - (e.Graphics.MeasureString(txt, printFont).Width) - 50f;
            //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);


            //thanks
            txt = "Terima Kasih atas kunjungan anda";
            yPos += lineHeight * 2;
            xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //saran
            txt = "Saran dan kritik, hubungi : ";
            yPos += lineHeight;
            xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            //saran
            TCafeSetting cafeSet = (TCafeSetting)DataMaster.GetObjectByProperty(typeof(TCafeSetting), TCafeSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            if (cafeSet != null)
            {
                txt = cafeSet.TelpNoSaranKritik;
                yPos += lineHeight;
                xPos = e.MarginBounds.Left + ((widthPaper / 2) - (e.Graphics.MeasureString(txt, printFont).Width / 2));
                e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);
            }
        }

        private void menu_Click2(object sender, EventArgs e)
        {
            Control[] controls = splitContainer3.Panel2.Controls.Find(sender.ToString().Replace("Meja ", ""), true);
            if (controls.Length > 0)
            {
                Button b = (Button)controls[0];
                b.PerformClick();
            }
        }

        private void btnPrintOrderAll_Click(object sender, EventArgs e)
        {
            PrintOrder(true);
        }

        private IList listGroup;
        private ArrayList listPrintedOrder;
        private void PrintOrder(bool printAll = false)
        {
            listGroup = DataMaster.GetAll(typeof(MGroup));
            MGroup grp;

            for (int i = 0; i < listGroup.Count; i++)
            {
                grp = (MGroup)listGroup[i];
                if (grp.PrintOrder && !string.IsNullOrEmpty(grp.PrinterName))
                {
                    //get detail trans by group
                    listPrintedOrder = GetDetailPrinted(grp.GroupId, printAll);
                    if (listPrintedOrder.Count > 0)
                    {
                        pdOrder.PrinterSettings.PrinterName = grp.PrinterName;
                        pdOrder.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
                        pdOrder.Print();
                    }
                }
            }

            if (f_Stat != null)
            {
                if (!f_Stat.IsDisposed)
                    f_Stat.Close();
            }
            f_Stat = new FormPrintStatus();
            f_Stat.PrintStatusHasSelected += new EventHandler(f_Stat_PrintOrderHasSelected);
            f_Stat.TopLevel = true;
            f_Stat.ShowDialog(this);
        }

        private ArrayList GetDetailPrinted(int groupId, bool printAll = false)
        {
            ArrayList _listPrintedOrder = new ArrayList();
            MItem item;
            TTransactionDetail detail;
            string desc;
            for (int i = 0; i < tTransactionDetailDataGridView.Rows.Count; i++)
            {
                item = DataMaster.GetObjectById(typeof(MItem), tTransactionDetailDataGridView.Rows[i].Cells[itemIdDataGridViewTextBoxColumn.Name].Value.ToString()) as MItem;
                if (item != null)
                {
                    if (item.GroupId == groupId)
                    {
                        desc =
                            tTransactionDetailDataGridView.Rows[i].Cells[DescriptionDataGridViewTextBoxColumn.Name].Value.
                                ToString();
                        //print if print all is true or detail not printed yet
                        if (printAll || desc != "Printed")
                            _listPrintedOrder.Add(i);

                        //update description
                        if (desc != "Printed")
                        {
                            detail =
                                DataMaster.GetObjectById(typeof(TTransactionDetail),
                                                         tTransactionDetailDataGridView.Rows[i].Cells[
                                                             TransactionDetailIdDataGridViewTextBoxColumn.Name].Value) as TTransactionDetail;
                            if (detail != null)
                            {
                                detail.Description = "Printed";
                                DataMaster.UpdatePersistence(detail);
                            }
                        }
                    }
                }
            }
            return _listPrintedOrder;
        }

        private void f_Stat_PrintOrderHasSelected(object sender, EventArgs e)
        {
            if (sender.Equals(ListOfPrintStatus.PrintOK))
            {
                BindTransactionDetail();
            }
            else if (sender.Equals(ListOfPrintStatus.PrintFailed))
            {
                PrintOrder();
            }
            else if (sender.Equals(ListOfPrintStatus.PrintCancel))
            {
            }
        }

        private void pdOrder_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Single xPos = e.MarginBounds.Left;
            Single yPos = e.MarginBounds.Top;
            Font printFont = new Font("MS Sans Serif", 15);
            Single lineHeight = printFont.GetHeight(e.Graphics) + 5;

            //Single widthPaper = 480 - e.MarginBounds.Left;
            Single widthPaper = e.PageSettings.PaperSize.Width - e.MarginBounds.Left;
            string txt = "";

            xPos = e.MarginBounds.Left;
            yPos += lineHeight * 2;
            txt = "Meja No : " + btn_CurrentDesk.Text.Replace("&", "");
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            xPos = e.MarginBounds.Left;
            yPos += lineHeight;
            txt = DateTime.Now.ToString("dd MMMM yyyy HH:mm");
            e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

            yPos += lineHeight;
            for (int i = 0; i < tTransactionDetailDataGridView.Rows.Count; i++)
            {
                if (listPrintedOrder.Contains(i))
                {

                    //display nama item
                    xPos = e.MarginBounds.Left;
                    yPos += lineHeight;
                    txt = tTransactionDetailDataGridView.Rows[i].Cells[itemIdDataGridViewTextBoxColumn.Name].Value.ToString() + " " + ModuleControlSettings.NumericFormat(tTransactionDetailDataGridView.Rows[i].Cells[quantityDataGridViewTextBoxColumn.Name].Value);
                    e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                    ////display kuantitas
                    //xPos = e.MarginBounds.Left;
                    //yPos += lineHeight;
                    //txt = ModuleControlSettings.NumericFormat(tTransactionDetailDataGridView.Rows[i].Cells[quantityDataGridViewTextBoxColumn.Name].Value);
                    //e.Graphics.DrawString(txt, printFont, Brushes.Black, xPos, yPos);

                }
            }
        }

        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            PrintOrder();
        }

    }
}