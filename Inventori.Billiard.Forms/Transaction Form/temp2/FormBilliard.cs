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
using WeifenLuo.WinFormsUI.Docking;
using Inventori.Module;
using Inventori.Forms;
using Inventori.Billiard.Data;

namespace Inventori.Billiard.Forms
{
    public partial class FormBilliard : FormParentForBilliard
    {
        public FormBilliard()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.billiard;
            set = (MSetting)DataMaster.GetObjectByProperty(typeof(MSetting), MSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);
            bilSet = (TBilliardSetting)DataMaster.GetObjectByProperty(typeof(TBilliardSetting), TBilliardSetting.ColumnNames.SettingId, AppCode.AssemblyProduct);

            //wasit
            if (!bilSet.UseReferee)
            {
                gb_Emp.Visible = false;
                tabControl1.TabPages.RemoveAt(2);
            }

            //back color
            noneColor = ColorTranslator.FromWin32(bilSet.DeskBackColor);
            bookingColor = ColorTranslator.FromWin32(bilSet.DeskBackColor1);
            inColor = ColorTranslator.FromWin32(bilSet.DeskBackColor2);

            //font color
            noneFontColor = ColorTranslator.FromWin32(bilSet.DeskFontColor);
            bookingFontColor = ColorTranslator.FromWin32(bilSet.DeskFontColor1);
            inFontColor = ColorTranslator.FromWin32(bilSet.DeskFontColor2);

            //font
            FontStyle st = FontStyle.Regular;
            if (bilSet.DeskFontBold)
                st = FontStyle.Bold;
            if (bilSet.DeskFontItalic)
                st = FontStyle.Italic;
            if (bilSet.DeskFontUnderline)
                st = FontStyle.Underline;
            noneFont = new Font(bilSet.DeskFontName, float.Parse(bilSet.DeskFontSize.ToString()), st);

            st = FontStyle.Regular;
            if (bilSet.DeskFontBold1)
                st = FontStyle.Bold;
            if (bilSet.DeskFontItalic1)
                st = FontStyle.Italic;
            if (bilSet.DeskFontUnderline1)
                st = FontStyle.Underline;
            bookingFont = new Font(bilSet.DeskFontName1, float.Parse(bilSet.DeskFontSize1.ToString()), st);

            st = FontStyle.Regular;
            if (bilSet.DeskFontBold2)
                st = FontStyle.Bold;
            if (bilSet.DeskFontItalic2)
                st = FontStyle.Italic;
            if (bilSet.DeskFontUnderline2)
                st = FontStyle.Underline;
            inFont = new Font(bilSet.DeskFontName2, float.Parse(bilSet.DeskFontSize2.ToString()), st);

            splitContainer3.BackColor = ColorTranslator.FromWin32(bilSet.BackColor);
        }

        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        Button activeButton = new Button();
        private Balloon.NET.BalloonHelp balloonHelp;
        Color noneColor = Color.White;
        Color bookingColor = Color.FromArgb(255, 255, 192);
        Color inColor = Color.FromArgb(192, 255, 192);

        Color noneFontColor = Color.Black;
        Color bookingFontColor = Color.Orange;
        Color inFontColor = Color.Purple;

        Font noneFont = new Font("Verdana", 16, GraphicsUnit.Point);
        Font bookingFont = new Font("Verdana", 16, GraphicsUnit.Point);
        Font inFont = new Font("Verdana", 16, GraphicsUnit.Point);

        MItem item;
        MCustomer cust;
        MSetting set;
        TDesk tdesk;
        MDesk mdesk;
        Timer tim;
        MEmployee emp;
        TBilliardSetting bilSet;

        private void FormBilliard_Load(object sender, EventArgs e)
        {
            //enabled if have priviledges to access sales form
            btn_Cafe.Enabled = ModuleControlSettings.HavePriviledges(lbl_UserName.Text, 201, AppCode.AssemblyProduct);

            //set numeric updown
            ModuleControlSettings.SetNumericUpDown(numericUpDown_ItemQuantity);
            ModuleControlSettings.SetNumericUpDown(num_Quantity);
            ModuleControlSettings.SetNumericUpDown(num_Price, true);
            ModuleControlSettings.SetNumericUpDown(num_Jumlah, true);
            ModuleControlSettings.SetNumericUpDown(num_Disc);
            ModuleControlSettings.SetNumericUpDown(num_Total, true);

            //set datetime picker
            dt_Booking.Format = DateTimePickerFormat.Custom;
            dt_Booking.CustomFormat = ModuleControlSettings.DateTimeFormat();
            dt_In.Format = DateTimePickerFormat.Custom;
            dt_In.CustomFormat = ModuleControlSettings.DateTimeFormat();
            dt_Out.Format = DateTimePickerFormat.Custom;
            dt_Out.CustomFormat = ModuleControlSettings.DateTimeFormat();

            //splitContainer1.Visible = false;
            CreateMDeskButton();

            PictureBox searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(txt_CustId, ListOfSearchWindow.SearchCustomer.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicCustomer_Click);
            txt_CustId.Controls.Add(searchPic);

            searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(txt_ItemId, ListOfSearchWindow.SearchItem.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicItem_Click);
            txt_ItemId.Controls.Add(searchPic);

            searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(txt_EmpId, ListOfSearchWindow.SearchEmployee.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicEmployee_Click);
            txt_EmpId.Controls.Add(searchPic);

            //set gridview transaction detail
            ModuleControlSettings.SetGridDataView(tTransactionDetailDataGridView);

            //set combo box group and grid view item
            ModuleControlSettings.SetGroupComboBoxForFilter(combo_Group);
            combo_Group.SelectedIndex = 0;
            combo_Group_SelectedIndexChanged(null, null);
            //set num_quntity_item value = 1
            numericUpDown_ItemQuantity.Value = 1;
            //set grid view item
            ModuleControlSettings.SetGridDataView(mItemDataGridView);

            //set grid view pelanggan
            mCustomerBindingSource.Clear();

            mCustomerBindingSource.DataSource = DataMaster.GetListNotEq(typeof(MCustomer), MCustomer.ColumnNames.CustomerStatus, ListOfCustStatus.Off.ToString());

            ModuleControlSettings.SetGridDataView(mCustomerDataGridView);

            //set grid view wasit
            mEmployeeBindingSource.Clear();

            mEmployeeBindingSource.DataSource = DataMaster.GetListEq(typeof(MEmployee), MEmployee.ColumnNames.DepId, "WASIT");

            ModuleControlSettings.SetGridDataView(mEmployeeDataGridView);
        }

        private void FormBilliard_Shown(object sender, EventArgs e)
        {

        }

        private void CreateMDeskButton()
        {
            //setting billiard desk
            //flowLayoutPanel1.Controls.Clear();

            //VIP
            splitContainer4.Panel2.Controls.Clear();
            //active 
            splitContainer10.Panel1.Controls.Clear();
            //mini
            splitContainer10.Panel2.Controls.Clear();

            IList listofbil = DataMaster.GetAllSortBy(typeof(MDesk), MDesk.ColumnNames.DeskOrder, "ASC");

            Button btn;
            int xVIP = 0;
            int yVIP = 0;
            int xActive = 0;
            int yActive = 0;
            int xMini = 0;
            int yMini = 0;

            for (int i = 0; i < listofbil.Count; i++)
            {
                mdesk = (MDesk)listofbil[i];
                btn = new Button();

                btn.Name = mdesk.DeskId;
                btn.Size = new Size(bilSet.DeskWidth, bilSet.DeskHeight);

                if (mdesk.DeskStatus.Equals(ListOfBilliardStatus.VIP.ToString()))
                {
                    btn.Location = new Point(xVIP, yVIP);
                    xVIP += bilSet.DeskWidth + 5;
                    if ((xVIP + bilSet.DeskWidth) > splitContainer4.Panel2.Width)
                    {
                        yVIP += bilSet.DeskHeight + 5;
                        xVIP = 0;
                    }
                }
                else if (mdesk.DeskStatus.Equals(ListOfBilliardStatus.Active.ToString()) || mdesk.DeskStatus.Equals(ListOfBilliardStatus.Off.ToString()))
                {
                    btn.Location = new Point(xActive, yActive);
                    xActive += bilSet.DeskWidth + 5;
                    if ((xActive + bilSet.DeskWidth) > splitContainer10.Panel1.Width)
                    {
                        yActive += bilSet.DeskHeight + 5;
                        xActive = 0;
                    }
                }

                else if (mdesk.DeskStatus.Equals(ListOfBilliardStatus.Mini.ToString()))
                {
                    btn.Location = new Point(xMini, yMini);
                    xMini += bilSet.DeskWidth + 5;
                    if ((xMini + bilSet.DeskWidth) > splitContainer10.Panel2.Width)
                    {
                        yMini += bilSet.DeskHeight + 5;
                        xMini = 0;
                    }
                }


                btn.Text = "&" + mdesk.DeskId;

                if (mdesk.DeskStatus.Equals(ListOfBilliardStatus.Off.ToString()))
                    btn.Enabled = false;

                activeButton = btn;

                tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, mdesk.DeskId);

                if (tdesk != null)
                {
                    if (tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.None.ToString()) || tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.Paid.ToString()))
                    {
                        btn.BackColor = noneColor;
                        btn.ForeColor = noneFontColor;
                        btn.Font = noneFont;
                    }
                    else if (tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.Booking.ToString()))
                    {
                        btn.BackColor = bookingColor;
                        btn.ForeColor = bookingFontColor;
                        btn.Font = bookingFont;
                    }
                    else if (tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.In.ToString()))
                    {
                        btn.BackColor = inColor;
                        btn.ForeColor = inFontColor;
                        btn.Font = inFont;
                    }
                    else if (tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.Out.ToString()))
                    {
                        btn.BackColor = noneColor;
                        btn.ForeColor = noneFontColor;
                        btn.Font = noneFont;
                    }
                }
                else
                {
                    btn.BackColor = noneColor;
                    btn.ForeColor = noneFontColor;
                    btn.Font = noneFont;
                }
                btn.AllowDrop = true;
                //btn.DoDragDrop(mbil.DeskId, DragDropEffects.Copy);
                btn.MouseDown += new MouseEventHandler(btn_MouseDown);
                btn.DragDrop += new DragEventHandler(btn_DragDrop);
                btn.DragEnter += new DragEventHandler(btn_DragEnter);
                //btn.MouseUp += new MouseEventHandler(btn_Click);
                //btn.Click += new EventHandler(btn_Click);

                if (mdesk.DeskStatus.Equals(ListOfBilliardStatus.VIP.ToString()))
                    splitContainer4.Panel2.Controls.Add(btn);
                else if (mdesk.DeskStatus.Equals(ListOfBilliardStatus.Active.ToString()) || mdesk.DeskStatus.Equals(ListOfBilliardStatus.Off.ToString()))
                    splitContainer10.Panel1.Controls.Add(btn);
                else if (mdesk.DeskStatus.Equals(ListOfBilliardStatus.Mini.ToString()))
                    splitContainer10.Panel2.Controls.Add(btn);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (btn_CurrentDesk.Visible == false)
                btn_CurrentDesk.Visible = true;

            activeButton = (Button)sender;

            gb_Trans.Visible = false;

            mdesk = (MDesk)DataMaster.GetObjectById(typeof(MDesk), activeButton.Name);
            if (mdesk.DeskStatus == ListOfBilliardStatus.VIP.ToString())
                lbl_TempTransaction.Text = ListOfTransaction.SalesVIP.ToString();
            else
                lbl_TempTransaction.Text = ListOfTransaction.Sales.ToString();

            lbl_TempDeskType.Text = mdesk.DeskStatus;

            tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, activeButton.Name);

            if (tdesk != null)
                SetDisplay(tdesk.DeskStatus);
            else
                SetDisplay(ListOfBilliardPaymentStatus.None.ToString());

            EditView();

            timer1_Tick(null, null);
            timer1.Start();
        }

        Button senderButton;
        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            Button but = (Button)sender;
            if (but.BackColor != noneColor)
            {
                but.DoDragDrop(but.Name, DragDropEffects.Copy);
                senderButton = but;
            }
            else
                btn_Click(sender, null);
        }

        private void btn_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.Text))
            e.Effect = DragDropEffects.Copy;
        }

        private void btn_DragDrop(object sender, DragEventArgs e)
        {
            Button but = (Button)sender;
            if (e.Data.GetData(DataFormats.Text).ToString().Equals(but.Name))
                btn_Click(sender, null);
            else if (but.BackColor == noneColor)
            {
                if (MessageBox.Show("Anda yakin pindah dari meja " + e.Data.GetData(DataFormats.Text).ToString() + " ke meja " + but.Name, "Konfirmasi pindah meja?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, e.Data.GetData(DataFormats.Text).ToString());

                    bool IsSave = true;

                    if (tdesk == null)
                    {
                        IsSave = true;
                        tdesk = new TDesk();
                    }
                    else
                        IsSave = false;

                    tdesk.DeskId = but.Name;

                    if (IsSave)
                        DataMaster.SavePersistence(tdesk);
                    else
                        DataMaster.UpdatePersistence(tdesk);

                    //reset source tbil
                    tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, e.Data.GetData(DataFormats.Text).ToString());

                    if (tdesk != null)
                        DataMaster.Delete(tdesk);
                    CreateMDeskButton();
                    this.Refresh();
                    btn_Click(sender, null);
                }

            }
            else
            {
                RecreateBalloon();
                balloonHelp.Caption = "Pindah Meja Gagal";
                balloonHelp.Content = "Pindah meja harus dilakukan di meja yang kosong.";
                balloonHelp.ShowBalloon(but);
            }

        }

        private void btn_Booking_Click(object sender, EventArgs e)
        {

            if (!btn_CurrentDesk.Visible)
                return;

            if (btn_Booking.Text.Equals("Booking"))
                SaveTBilliard(ListOfBilliardPaymentStatus.Booking.ToString(), false);
            else
                SaveTBilliard(ListOfBilliardPaymentStatus.None.ToString(), false);
            timer1_Tick(null, null);

        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            if (!btn_CurrentDesk.Visible)
                return;

            if (btn_In.Text.Equals("&Main"))
            {
                if (!ValidateCustomer())
                    return;

                SaveTBilliard(ListOfBilliardPaymentStatus.In.ToString(), false);
                Timer tim = new Timer();
                tim.Interval = 60000;
                tim.Tick += new EventHandler(tim_Tick);
                tim.Start();
                tim_Tick(null, null);
            }
            else
            {
                if (tTransactionDetailDataGridView.RowCount > 0)
                {
                    MessageBox.Show("Transaksi yang tidak kosong tidak bisa dibatalkan", "Pembatalan Transaksi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int minAllow = 0;
                if (set != null)
                    minAllow = Convert.ToInt32(bilSet.QuitTimeout);

                TimeSpan ts = DateTime.Now.Subtract(dt_In.Value);
                if (ts.TotalMinutes <= minAllow)
                {
                    if (MessageBox.Show("Anda yakin membatalkan transaksi?", "Pembatalan Transaksi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        SaveTBilliard(ListOfBilliardPaymentStatus.None.ToString(), false);
                    else
                        return;
                }
                else
                {
                    RecreateBalloon();

                    balloonHelp.Caption = "Pembatalan Gagal";
                    balloonHelp.Content = "Pembatalan tidak bisa dilakukan, jangka waktu " + minAllow.ToString() + " menit sudah lewat.";
                    balloonHelp.ShowBalloon(btn_In);
                }

                lbl_Duration.Text = "00:00:00";

            }
            timer1_Tick(null, null);

            AddBonusItem();
        }

        private void AddBonusItem()
        {
            TBonus bonus = (TBonus)DataMaster.GetObjectByProperty(typeof(TBonus), TBonus.ColumnNames.SettingId, AppCode.AssemblyProduct);
            if (bonus != null)
            {
                if (!string.IsNullOrEmpty(bonus.ItemId))
                {
                    decimal price = decimal.Zero;
                    MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, bonus.ItemId);
                    if (item != null)
                    {
                        price = item.ItemPriceMax;
                    }

                    TTransactionDetail det = new TTransactionDetail();
                    det.Disc = 100;
                    det.ItemId = bonus.ItemId;
                    det.Ppn = 0;
                    det.Price = price;
                    det.Quantity = bonus.Quantity;
                    det.Total = decimal.Zero;
                    det.TransactionId = Convert.ToDecimal(lbl_TransactionId.Text);
                    det.Jumlah = decimal.Zero;
                    det.ModifiedBy = lbl_UserName.Text;
                    det.ModifiedDate = DateTime.Now;
                    DataMaster.SavePersistence(det);

                    BindTransactionDetail();
                    this.Refresh();
                }
            }


        }

        private bool ValidateCustomer()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(txt_CustId.Text.Trim()))
            {
                balloonHelp.Content = "Pelanggan harus diisi";
                balloonHelp.ShowBalloon(txt_CustId);
                txt_CustId.Focus();
                return false;
            }
            if (bilSet.UseReferee)
            {
                if (string.IsNullOrEmpty(txt_EmpId.Text.Trim()))
                {
                    DialogResult res = MessageBox.Show("Anda yakin wasit tidak diisi?", "Konfirmasi Wasit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                        txt_EmpId.Focus();
                        txt_EmpId.Select();
                        return false;
                    }
                }
            }
            return true;
        }

        private void RecreateBalloon()
        {
            balloonHelp = new Balloon.NET.BalloonHelp();
            balloonHelp.Icon = Properties.Resources.warning;
            balloonHelp.ShowCloseButton = false;
        }

        private FormTransaction f_Trans;
        private void btn_Out_Click(object sender, EventArgs e)
        {
            if (!btn_CurrentDesk.Visible)
                return;

            if (f_Trans != null)
            {
                if (!f_Trans.IsDisposed)
                    f_Trans.Close();
            }
            f_Trans = new FormTransaction();

            //lock input from transaction form
            f_Trans.groupBox8.Visible = false;
            f_Trans.groupBox6.Enabled = false;
            f_Trans.groupBox9.Enabled = false;
            f_Trans.button1.Enabled = false;
            f_Trans.button2.Enabled = false;
            f_Trans.dt_TransactionDate.Enabled = false;

            f_Trans.lbl_TempTransaction.Text = lbl_TempTransaction.Text;
            f_Trans.lbl_TempDesk.Text = activeButton.Name;
            f_Trans.txt_TransactionId.Text = lbl_TransactionId.Text;
            f_Trans.txt_CustId.Text = txt_CustId.Text;
            f_Trans.txt_CustName.Text = txt_CustName.Text;
            f_Trans.lbl_EmployeeId.Text = txt_EmpId.Text;
            f_Trans.lbl_UserName.Text = lbl_UserName.Text;

            string[] field;
            for (int i = 0; i < tTransactionDetailDataGridView.Rows.Count; i++)
            {
                field = new string[7];

                //item id
                field[0] = tTransactionDetailDataGridView.Rows[i].Cells[0].Value.ToString();

                //keterangan
                item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, tTransactionDetailDataGridView.Rows[i].Cells[0].Value.ToString());
                if (item != null)
                    field[1] = item.ItemName;
                else
                    field[1] = "";
                //field[1] = tTransactionDetailDataGridView.Rows[i].Cells[1].Value.ToString();

                //kuantitas
                field[2] = ModuleControlSettings.NumericFormat(tTransactionDetailDataGridView.Rows[i].Cells[2].Value.ToString());
                //harga / unit
                field[3] = ModuleControlSettings.NumericFormat(tTransactionDetailDataGridView.Rows[i].Cells[3].Value.ToString());
                //jumlah
                field[4] = ModuleControlSettings.NumericFormat(tTransactionDetailDataGridView.Rows[i].Cells[4].Value.ToString());

                //diskon
                field[5] = ModuleControlSettings.NumericFormat(tTransactionDetailDataGridView.Rows[i].Cells[5].Value.ToString());
                //total
                field[6] = ModuleControlSettings.NumericFormat(tTransactionDetailDataGridView.Rows[i].Cells[6].Value.ToString());

                f_Trans.grid_Trans.Rows.Insert(0, field);

            }

            string sewaMeja = "Rental Meja " + activeButton.Name;

            f_Trans.grid_Trans.Rows.Insert(0, AddRental(sewaMeja));

            f_Trans.TransactionHasSaved += new EventHandler(f_Trans_TransactionHasSaved);
            f_Trans.Size = new Size(f_Trans.Size.Width - 300, f_Trans.Size.Height);
            f_Trans.Refresh();
            f_Trans.Show(this);
            f_Trans.num_Pay.ResetText();
            f_Trans.num_Pay.Select();
        }

        private void f_Trans_TransactionHasSaved(object sender, EventArgs e)
        {
            if (sender != null)
            {
                f_Trans.Close();
                SaveTBilliard(ListOfBilliardPaymentStatus.Paid.ToString(), false);
                lbl_Duration.Text = "00:00:00";
                timer1_Tick(null, null);
            }
        }

        private decimal getRentalPrice()
        {
            decimal price = 0;
            if (lbl_TempDeskType.Text.Equals(ListOfBilliardStatus.Active.ToString()))
                price = bilSet.BiliardItemPrice;
            else if (lbl_TempDeskType.Text.Equals(ListOfBilliardStatus.Mini.ToString()))
                price = bilSet.BiliardItemPriceMini;
            else if (lbl_TempDeskType.Text.Equals(ListOfBilliardStatus.VIP.ToString()))
                price = bilSet.BiliardItemPriceVip;

            return price;
        }

        private decimal getInterval()
        {
            return getInterval(dt_In.Value, dt_Out.Value);
        }

        private decimal getInterval(DateTime dateIn, DateTime dateOut)
        {
            TimeSpan ts = dateOut.Subtract(dateIn);
            decimal tim = 0;
            decimal playMin = Convert.ToDecimal(Math.Floor(ts.TotalMinutes));

            if (playMin <= bilSet.MinimumPlay)
                tim = (bilSet.MinimumPlay / 60);
            else
            {
                decimal jam = Convert.ToDecimal(Math.Floor(playMin / 60));
                decimal sisaMenit = playMin % 60;
                decimal menit = (jam * 60);
                if (sisaMenit >= (bilSet.ToleranceTime + bilSet.CalculateTime))
                {
                    menit += bilSet.CalculateTime * 2;
                }
                else if (sisaMenit >= bilSet.CalculateTime)
                {
                    menit += bilSet.CalculateTime;
                }
                else if (sisaMenit >= bilSet.ToleranceTime)
                {
                    menit += bilSet.CalculateTime;
                }
                tim = menit / 60;
            }
            return tim;
        }

        private decimal getJumlah()
        {
            decimal j = 0;
            try
            {
                j = getInterval() * getRentalPrice();
            }
            catch (Exception)
            {
                throw;
            }
            //decimal ff = bilSet.FullfillPrice;
            //if (ff > 0)
            //    j = Math.Ceiling(j / ff) * ff;
            return j;
        }

        private decimal getDiskon()
        {
            decimal disk = 0;
            //DateTime dateIn = Convert.ToDateTime(dt_In.Text);
            //string hari = ModuleControlSettings.GetDayFromDayOfWeek(dateIn.DayOfWeek);
            //MDiscount mdisc = (MDiscount)DataMaster.GetObjectByProperty(typeof(MDiscount), MDiscount.ColumnNames.DiscDay, hari);
            //if (mdisc != null)
            //{
            //    string strFrom = dateIn.ToShortDateString() + " " + mdisc.DiscTimeHourFrom.ToString() + ":" + mdisc.DiscTimeMinFrom.ToString();
            //    DateTime dtFrom = Convert.ToDateTime(strFrom);
            //    string strTo = dateIn.ToShortDateString() + " " + mdisc.DiscTimeHourTo.ToString() + ":" + mdisc.DiscTimeMinTo.ToString();
            //    DateTime dtTo = Convert.ToDateTime(strTo);

            //    if ((mdisc.Disc != 0) && (dateIn > dtFrom && dateIn < dtTo))
            //        disk = mdisc.Disc;
            //    else
            //    {
            //        cust = (MCustomer)DataMaster.GetObjectByProperty(typeof(MCustomer), MCustomer.ColumnNames.CustomerId, txt_CustId.Text);
            //        if (cust != null)
            //            disk = cust.CustomerDisc;
            //    }
            //}
            cust = (MCustomer)DataMaster.GetObjectByProperty(typeof(MCustomer), MCustomer.ColumnNames.CustomerId, txt_CustId.Text);
            if (cust != null)
                disk = cust.CustomerDisc;
            return disk;
        }

        private decimal getTotal()
        {
            return getJumlah();
            //hitung interval waktu dari main sampe keluar
            TimeSpan ts = Convert.ToDateTime(dt_Out.Value).Subtract(dt_In.Value);
            decimal tim = 0;

            //jika interval waktu lebih kecil dari waktu minimal, maka gunakan waktu minimal sebagai patokan
            if (Convert.ToDecimal(Math.Floor(ts.TotalMinutes)) < bilSet.MinimumPlay)
            {
                //jumlah harga rental di kurangi diskon
                return getJumlah() * ((100 - getDiskon()) / 100);
            }

            textBox1.ResetText();
            decimal tot = 0;
            decimal price = getRentalPrice();
            DateTime dateIn = Convert.ToDateTime(dt_In.Value);
            DateTime dateOut = Convert.ToDateTime(dt_Out.Value);
            string hari = ModuleControlSettings.GetDayFromDayOfWeek(dateIn.DayOfWeek);
            MDiscount mdisc = (MDiscount)DataMaster.GetObjectByProperty(typeof(MDiscount), MDiscount.ColumnNames.DiscDay, hari);
            if (mdisc != null)
            {
                string strFrom = dateIn.ToShortDateString() + " " + mdisc.DiscTimeHourFrom.ToString() + ":" + mdisc.DiscTimeMinFrom.ToString();
                DateTime dateFrom = Convert.ToDateTime(strFrom);
                string strTo = dateIn.ToShortDateString() + " " + mdisc.DiscTimeHourTo.ToString() + ":" + mdisc.DiscTimeMinTo.ToString();
                DateTime dateTo = Convert.ToDateTime(strTo);

                DateTime dateTemp1 = dateIn;
                if (mdisc.Disc != 0)
                {
                    while (dateTemp1 < dateOut)
                    {
                        if (dateTemp1 < dateFrom)
                        {
                            if (dateOut <= dateFrom)
                            {
                                tot += calculateSubTotal(dateTemp1, dateOut, price, 0);
                                textBox1.Text += "\n tot1 : " + tot.ToString() + " dateTemp1 : " + dateTemp1.ToString() + " dateout : " + dateOut.ToString() + " price : " + price.ToString();
                                dateTemp1 = dateOut;
                            }
                            else
                            {
                                tot += calculateSubTotal(dateTemp1, dateFrom, price, 0);
                                textBox1.Text += "\n tot1 : " + tot.ToString() + " dateTemp1 : " + dateTemp1.ToString() + " dateout : " + dateFrom.ToString() + " price : " + price.ToString();
                                dateTemp1 = dateFrom;
                            }

                        }
                        else if (dateTemp1 < dateTo)
                        {
                            if (dateOut <= dateTo)
                            {
                                tot += calculateSubTotal(dateTemp1, dateOut, price, mdisc.Disc);
                                textBox1.Text += "\n tot2 : " + tot.ToString() + " dateTemp1 : " + dateTemp1.ToString() + " dateout : " + dateOut.ToString() + " price : " + price.ToString() + " disc : " + mdisc.Disc.ToString();
                                dateTemp1 = dateOut;
                            }
                            else
                            {
                                tot += calculateSubTotal(dateTemp1, dateTo, price, mdisc.Disc);
                                textBox1.Text += "\n tot2 : " + tot.ToString() + " dateTemp1 : " + dateTemp1.ToString() + " dateout : " + dateTo.ToString() + " price : " + price.ToString() + " disc : " + mdisc.Disc.ToString();
                                dateTemp1 = dateTo;
                            }
                        }
                        else
                        {
                            tot += calculateSubTotal(dateTemp1, dateOut, price, 0);
                            textBox1.Text += "\n tot3 : " + tot.ToString() + " dateTemp1 : " + dateTemp1.ToString() + " dateout : " + dateOut.ToString() + " price : " + price.ToString();
                            dateTemp1 = dateOut;
                        }
                    }
                }
                else
                {
                    decimal diskon = 0;
                    cust = (MCustomer)DataMaster.GetObjectByProperty(typeof(MCustomer), MCustomer.ColumnNames.CustomerId, txt_CustId.Text);
                    if (cust != null)
                        diskon = cust.CustomerDisc;
                    tot = calculateSubTotal(dateIn, dateOut, price, diskon);
                }
            }
            else
            {
                decimal diskon = 0;
                cust = (MCustomer)DataMaster.GetObjectByProperty(typeof(MCustomer), MCustomer.ColumnNames.CustomerId, txt_CustId.Text);
                if (cust != null)
                    diskon = cust.CustomerDisc;
                tot = calculateSubTotal(dateIn, dateOut, price, diskon);
            }
            decimal ff = bilSet.FullfillPrice;
            if (ff > 0)
                tot = Math.Ceiling(tot / ff) * ff;
            return tot;
        }

        private decimal calculateSubTotal(DateTime from, DateTime to, decimal price, decimal discount)
        {
            TimeSpan ts = to.Subtract(from);
            decimal tim = Convert.ToDecimal(ts.TotalHours);
            return (tim * price) * ((100 - discount) / 100);
        }

        private string[] AddRental(string itemRental)
        {
            string[] field = new string[7];
            //item id
            field[0] = itemRental;

            //keterangan
            field[1] = itemRental;

            //kuantitas
            decimal interval = getInterval();
            field[2] = ModuleControlSettings.NumericFormat(interval.ToString());

            //harga / unit
            decimal price = getRentalPrice();
            field[3] = ModuleControlSettings.NumericFormat(price.ToString());

            //jumlah
            decimal j = getJumlah();
            field[4] = ModuleControlSettings.NumericFormat(j.ToString());

            //diskon
            decimal disk = getDiskon();
            field[5] = ModuleControlSettings.NumericFormat(disk.ToString());

            //total
            decimal tot = j * ((100 - disk) / 100);
            field[6] = ModuleControlSettings.NumericFormat(tot.ToString());

            return field;
        }

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
                {
                    //f_SearchCustomer.WindowState = FormWindowState.Normal;
                    //f_SearchCustomer.BringToFront();
                    f_SearchCustomer.Close();
                    f_SearchCustomer = new FormSearchCustomer();
                }
                else
                    f_SearchCustomer = new FormSearchCustomer();
            }
            else
                f_SearchCustomer = new FormSearchCustomer();

            f_SearchCustomer.CustomerHasSelected += new EventHandler(f_SearchCustomer_CustomerHasSelected);
            //f_SearchCustomer.MdiParent = this.MdiParent;
            // f_SearchCustomer.ShowInTaskbar = false;
            f_SearchCustomer.ShowDialog();
        }


        private void f_SearchCustomer_CustomerHasSelected(object sender, EventArgs e)
        {
            if (f_SearchCustomer.grid_Search.Rows.Count > 0)
            {
                txt_CustId.Text = f_SearchCustomer.grid_Search.Rows[f_SearchCustomer.grid_Search.CurrentRow.Index].Cells[0].Value.ToString();
                txt_CustId_Validating(null, null);
                //txt_CustName.Text = f_SearchCustomer.grid_Search.Rows[f_SearchCustomer.grid_Search.CurrentRow.Index].Cells[1].Value.ToString();
            }
        }

        private void searchPicEmployee_Click(object sender, EventArgs e)
        {
            OpenFormSearchEmployee();
        }

        FormSearchEmployee f_SearchEmployee;//= new FormSearchItem();
        private void OpenFormSearchEmployee()
        {
            if (f_SearchEmployee != null)
            {
                if (!f_SearchEmployee.IsDisposed)
                    f_SearchEmployee.Close();
            }
            f_SearchEmployee = new FormSearchEmployee();

            f_SearchEmployee.EmployeeHasSelected += new EventHandler(f_SearchEmployee_EmployeeHasSelected);
            //f_SearchCustomer.MdiParent = this.MdiParent;
            //f_SearchEmployee.ShowInTaskbar = false;
            f_SearchEmployee.ShowDialog();
        }

        private void f_SearchEmployee_EmployeeHasSelected(object sender, EventArgs e)
        {
            if (f_SearchEmployee.grid_Search.Rows.Count > 0)
            {
                txt_EmpId.Text = f_SearchEmployee.grid_Search.Rows[f_SearchEmployee.grid_Search.CurrentRow.Index].Cells[0].Value.ToString();
                txt_EmpId_Validating(null, null);
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

        private void SaveTBilliard(string DisplayBilStatus, bool IsSetDisplayByData)
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

            tdesk.DeskBookingDate = dt_Booking.Value;
            tdesk.DeskCustId = txt_CustId.Text;
            tdesk.DeskId = activeButton.Name;
            tdesk.DeskInDate = Convert.ToDateTime(dt_In.Value);

            //DateTime dt = Convert.ToDateTime(lbl_Duration.Text);
            //decimal longPlay = (dt.Day * 24 * 60) + (dt.Hour * 60) + dt.Minute;
            //tdesk.DeskLongPlayMinutes = longPlay;
            tdesk.DeskOutDate = Convert.ToDateTime(dt_Out.Value);
            tdesk.DeskStatus = DisplayBilStatus;
            tdesk.DeskTransactionId = Convert.ToDecimal(lbl_TransactionId.Text);
            tdesk.DeskGrandTotal = Convert.ToDecimal(lbl_RentalPrice.Text.Replace("Rp. ", ""));
            tdesk.EmployeeId = txt_EmpId.Text;
            tdesk.ModifiedBy = lbl_UserName.Text;
            tdesk.ModifiedDate = DateTime.Now;

            if (IsSave)
                DataMaster.SavePersistence(tdesk);
            else
                DataMaster.UpdatePersistence(tdesk);
        }

        private void SetDisplay(string DisplayBilStatus)
        {
            if (DisplayBilStatus.Equals(ListOfBilliardPaymentStatus.None.ToString()) || DisplayBilStatus.Equals(ListOfBilliardPaymentStatus.Paid.ToString()))
            {
                txt_CustId.Text = "CASH";
                txt_CustName.ResetText();
                txt_EmpId.ResetText();
                txt_EmpName.ResetText();

                lbl_TransactionId.Text = DateTime.Now.ToFileTimeUtc().ToString();
                tTransactionDetailDataGridView.Rows.Clear();

                activeButton.BackColor = noneColor;
                activeButton.ForeColor = noneFontColor;
                activeButton.Font = noneFont;

                dt_Booking.Value = DateTime.Now;
                dt_In.Value = DateTime.Now;
                dt_Out.Value = DateTime.Now;

                //set group box
                //gb_Main.Visible = true;
                gb_Trans.Enabled = false;
                gb_Cust.Enabled = true;
                gb_Emp.Enabled = true;

                //set datepicker
                dt_Booking.Enabled = true;
                btn_Booking.Enabled = true;
                btn_Booking.Text = "Booking";
                dt_In.Enabled = true;
                btn_In.Enabled = true;
                btn_In.Text = "&Main";
                dt_Out.Enabled = false;
                btn_Out.Enabled = false;

                button_Tambah.Enabled = false;

            }
            else if (DisplayBilStatus.Equals(ListOfBilliardPaymentStatus.Booking.ToString()))
            {
                //booking
                activeButton.BackColor = bookingColor;
                activeButton.ForeColor = bookingFontColor;
                activeButton.Font = bookingFont;

                //set group box
                //gb_Main.Visible = true;
                gb_Trans.Enabled = false;
                gb_Cust.Enabled = true;
                gb_Emp.Enabled = true;

                //set datepicker
                dt_Booking.Enabled = false;
                btn_Booking.Enabled = true;
                btn_Booking.Text = "Batal";
                dt_In.Enabled = true;
                btn_In.Enabled = true;
                btn_In.Text = "&Main";
                dt_Out.Enabled = false;
                btn_Out.Enabled = false;

                button_Tambah.Enabled = false;
            }
            else if (DisplayBilStatus.Equals(ListOfBilliardPaymentStatus.In.ToString()))
            {
                activeButton.BackColor = inColor;
                activeButton.ForeColor = inFontColor;
                activeButton.Font = inFont;

                //set group box
                //gb_Main.Visible = true;
                gb_Trans.Enabled = true;
                gb_Cust.Enabled = false;
                gb_Emp.Enabled = false;

                //set datepicker
                dt_Booking.Enabled = false;
                btn_Booking.Enabled = false;
                btn_Booking.Text = "Booking";
                dt_In.Enabled = false;
                btn_In.Enabled = true;
                btn_In.Text = "Batal";
                dt_Out.Enabled = true;
                btn_Out.Enabled = true;

                button_Tambah.Enabled = true;

            }
            else if (DisplayBilStatus.Equals(ListOfBilliardPaymentStatus.Out.ToString()))
            {
                activeButton.BackColor = noneColor;
                activeButton.ForeColor = noneFontColor;
                activeButton.Font = noneFont;

                //set group box
                //gb_Main.Visible = true;
                gb_Trans.Enabled = false;
                gb_Cust.Enabled = true;
                gb_Emp.Enabled = true;

                //set datepicker
                dt_Booking.Enabled = true;
                btn_Booking.Enabled = true;
                btn_Booking.Text = "Booking";
                dt_In.Enabled = true;
                btn_In.Enabled = true;
                btn_In.Text = "&Main";
                dt_Out.Enabled = false;
                btn_Out.Enabled = false;
                button_Tambah.Enabled = false;

            }

            btn_CurrentDesk.Text = activeButton.Text;
            btn_CurrentDesk.BackColor = activeButton.BackColor;
            btn_CurrentDesk.ForeColor = activeButton.ForeColor;
            btn_CurrentDesk.Font = activeButton.Font;
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
                        dt_Booking.Value = tdesk.DeskBookingDate;
                        dt_In.Value = DateTime.Now;
                        dt_Out.Value = DateTime.Now;

                        lbl_Duration.Text = "00:00:00";
                    }
                    else if (tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.In.ToString()))
                    {
                        dt_Booking.Value = tdesk.DeskBookingDate;
                        dt_In.Value = tdesk.DeskInDate;
                        dt_Out.Value = DateTime.Now;

                        tim = new Timer();
                        tim.Interval = 60000;
                        tim.Tick += new EventHandler(tim_Tick);
                        tim.Start();
                        tim_Tick(null, null);
                    }
                    else if (tdesk.DeskStatus.Equals(ListOfBilliardPaymentStatus.Out.ToString()))
                    {
                        dt_Out.Value = tdesk.DeskOutDate;
                        dt_Booking.Value = tdesk.DeskBookingDate;
                        dt_In.Value = tdesk.DeskInDate;

                        tim = new Timer();
                        tim.Interval = 60000;
                        tim.Tick += new EventHandler(tim_Tick);
                        tim.Start();
                        tim_Tick(null, null);
                    }

                    txt_CustId.Text = tdesk.DeskCustId;

                    cust = (MCustomer)DataMaster.GetObjectByProperty(typeof(MCustomer), MCustomer.ColumnNames.CustomerId, tdesk.DeskCustId);
                    if (cust != null)
                        txt_CustName.Text = cust.CustomerName;
                    else
                        txt_CustName.ResetText();

                    txt_EmpId.Text = tdesk.EmployeeId;
                    emp = (MEmployee)DataMaster.GetObjectByProperty(typeof(MEmployee), MEmployee.ColumnNames.EmployeeId, tdesk.EmployeeId);
                    if (emp != null)
                        txt_EmpName.Text = emp.EmployeeName;
                    else
                        txt_EmpName.ResetText();

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
            dt_Booking.Value = DateTime.Now;
            dt_In.Value = DateTime.Now;
            dt_Out.Value = DateTime.Now;

            //txt_CustId.ResetText();
            txt_CustId.Text = "CASH";
            txt_CustName.ResetText();
            txt_EmpId.ResetText();
            txt_EmpName.ResetText();
            lbl_TransactionId.Text = DateTime.Now.ToFileTimeUtc().ToString();

            lbl_Duration.Text = "00:00:00";
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
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (!ValidateFormDetail())
                return;

            SaveTransactionDetail();
            BindTransactionDetail();
            timer1_Tick(null, null);
            ResetTransactionDetail();

            gb_Trans.Visible = false;

            this.Refresh();
        }

        private void ResetTransactionDetail()
        {
            txt_ItemId.ResetText();
            txt_ItemName.ResetText();
            lbl_Satuan.ResetText();
            numericUpDown_ItemQuantity.Value = 1;
            num_Quantity.Value = 1;
            num_Price.Value = 0;
            num_Jumlah.Value = 0;
            num_Disc.Value = 0;
            num_Total.Value = 0;
            ModuleControlSettings.SetGridDataView(tTransactionDetailDataGridView);
        }

        private void SaveTransactionDetail()
        {
            TTransactionDetail det = new TTransactionDetail();
            det.Disc = num_Disc.Value;
            det.ItemId = txt_ItemId.Text;
            det.Ppn = 0;
            det.Price = num_Price.Value;
            det.Quantity = num_Quantity.Value;
            det.Total = num_Total.Value;
            det.TransactionId = Convert.ToDecimal(lbl_TransactionId.Text);
            det.Jumlah = num_Jumlah.Value;
            det.ModifiedBy = lbl_UserName.Text;
            det.ModifiedDate = DateTime.Now;
            DataMaster.SavePersistence(det);

            tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, activeButton.Name);
            tdesk.DeskGrandTotal = tdesk.DeskGrandTotal + num_Total.Value;
            tdesk.ModifiedBy = lbl_UserName.Text;
            tdesk.ModifiedDate = DateTime.Now;
            DataMaster.UpdatePersistence(tdesk);
        }

        private void BindTransactionDetail()
        {
            vTransactionDetailBindingSource.Clear();
            vTransactionDetailBindingSource.DataSource = DataMaster.GetListEq(typeof(VTransactionDetail), VTransactionDetail.ColumnNames.TransactionId, Convert.ToDecimal(lbl_TransactionId.Text));
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ResetTransactionDetail();
            gb_Trans.Visible = false;
        }

        private bool ValidateFormDetail()
        {
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
                    balloonHelp.Content = "Item " + txt_ItemId.Text + " tidak ada dalam database. \n Pastikan anda menulis kode yang tepat atau \n pilih item dengan mengklik gambar disamping untuk mencari item.";
                    balloonHelp.ShowBalloon(txt_ItemId);
                    txt_ItemId.Focus();
                    return false;
                }
            }

            if (num_Quantity.Value == 0)
            {
                balloonHelp.Content = "Kuantitas tidak boleh 0 !!";
                balloonHelp.ShowBalloon(num_Quantity);
                num_Quantity.Focus();
                return false;
            }
            return true;
        }

        private void txt_ItemId_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_ItemId.Text.Trim()))
            {
                item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, txt_ItemId.Text);

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

        private void tim_Tick(object sender, EventArgs e)
        {
            if (dt_Booking.Enabled)
                dt_Booking.Value = DateTime.Now;

            if (dt_In.Enabled)
                dt_In.Value = DateTime.Now;

            if (dt_Out.Enabled)
                dt_Out.Value = DateTime.Now;

            CalculateDuration();
        }

        private void CalculateDuration()
        {
            try
            {
                TimeSpan ts = DateTime.Now.Subtract(dt_In.Value);
                string h = Math.Floor(ts.TotalHours).ToString();
                if (h.Length == 1)
                    h = "0" + h;

                string m = ts.Minutes.ToString();
                if (m.Length == 1)
                    m = "0" + m;

                //string s = ts.Seconds.ToString();
                //if (s.Length == 1)
                //    s = "0" + s;

                lbl_Duration.Text = h + ":" + m;
            }
            catch (Exception)
            {
                lbl_Duration.Text = "00:00";
            }
        }

        private void txt_ItemId_DragDrop(object sender, DragEventArgs e)
        {
            txt_ItemId.Text = e.Data.GetData(DataFormats.Text).ToString();
        }

        private void mItemDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            mItemDataGridView.DoDragDrop(mItemDataGridView.Rows[mItemDataGridView.CurrentRow.Index].Cells[0].Value.ToString() + "|" + numericUpDown_ItemQuantity.Value.ToString(), DragDropEffects.Copy);
        }

        private void txt_ItemId_DragEnter(object sender, DragEventArgs e)
        {
            // if (e.Data.GetDataPresent(DataFormats.Text))
            e.Effect = DragDropEffects.Copy;
        }

        private void tTransactionDetailDataGridView_DragDrop(object sender, DragEventArgs e)
        {
            if (gb_Trans.Enabled && btn_CurrentDesk.Visible)
            {
                gb_Trans.Visible = true;

                string delimStr = "|";
                char[] delimiter = delimStr.ToCharArray();

                string[] itemData = e.Data.GetData(DataFormats.Text).ToString().Split(delimiter);
                txt_ItemId.Text = itemData[0];
                num_Quantity.Value = Convert.ToDecimal(itemData[1]);
                txt_ItemId_Validating(null, null);
                num_Quantity.Focus();
            }
            else
            {
                RecreateBalloon();
                balloonHelp.Caption = "Transaksi Invalid";
                balloonHelp.Content = "Transaksi tidak bisa dilakukan di meja yang kosong";
                balloonHelp.ShowBalloon(btn_CurrentDesk);
            }

        }

        private void tTransactionDetailDataGridView_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.Text))
            e.Effect = DragDropEffects.Copy;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //posisi out
            if (btn_Out.Enabled)
            {
                decimal grandTot = getTotal();
                tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, activeButton.Name);
                if (tdesk != null)
                {
                    lbl_Total.Text = ModuleControlSettings.NumericFormat(tdesk.DeskGrandTotal, true);
                    grandTot += tdesk.DeskGrandTotal;
                }
                else
                    lbl_Total.Text = ModuleControlSettings.NumericFormat(0, true);

                lbl_RentalPrice.Text = ModuleControlSettings.NumericFormat(getTotal(), true);

                lbl_GrandTotal.Text = ModuleControlSettings.NumericFormat(grandTot, true);
            }
            else
            {
                lbl_RentalPrice.Text = ModuleControlSettings.NumericFormat(0, true);
                lbl_Total.Text = ModuleControlSettings.NumericFormat(0, true);
                lbl_GrandTotal.Text = ModuleControlSettings.NumericFormat(0, true);
            }
        }

        private void txt_EmpId_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(txt_EmpId, ListOfSearchWindow.SearchEmployee.ToString(), true);
        }

        private void txt_EmpId_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(txt_EmpId, ListOfSearchWindow.SearchEmployee.ToString(), false);

        }

        private void mCustomerDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            mCustomerDataGridView.DoDragDrop(mCustomerDataGridView.Rows[mCustomerDataGridView.CurrentRow.Index].Cells[0].Value, DragDropEffects.Copy);
        }

        private void gb_Cust_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void gb_Cust_DragDrop(object sender, DragEventArgs e)
        {
            if (gb_Cust.Enabled)
            {
                txt_CustId.Text = e.Data.GetData(DataFormats.Text).ToString();
                txt_CustId_Validating(null, null);
            }
            else
            {
                RecreateBalloon();
                balloonHelp.Caption = "Transaksi Invalid";
                balloonHelp.Content = "Pelanggan sudah ada";
                balloonHelp.ShowBalloon(gb_Cust);
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

        private void btn_Cafe_Click(object sender, EventArgs e)
        {
            if (f_Trans != null)
            {
                if (!f_Trans.IsDisposed)
                    f_Trans.Close();
            }
            f_Trans = new FormTransaction();

            f_Trans.lbl_TempTransaction.Text = ListOfTransaction.Sales.ToString();
            f_Trans.lbl_TempDesk.Text = ListOfDesk.Cafe.ToString();
            f_Trans.lbl_UserName.Text = lbl_UserName.Text;
            f_Trans.Show();
        }

        private void combo_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            mItemBindingSource.Clear();
            IList listItem = null;

            if (combo_Group.SelectedIndex > 0)
            {
                listItem = DataMaster.GetListEq(typeof(MItem), MItem.ColumnNames.GroupId, Convert.ToInt32(combo_Group.SelectedValue.ToString()));
            }
            else if (combo_Group.SelectedIndex == 0)
                listItem = DataMaster.GetAll(typeof(MItem));


            mItemBindingSource.DataSource = listItem;
        }

        private void mItemDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btn_CurrentDesk.Visible)
                return;

            if (gb_Trans.Enabled == true)
            {
                if (mItemDataGridView.RowCount == 0)
                    return;

                gb_Trans.Visible = true;
                txt_ItemId.Text = mItemDataGridView.CurrentRow.Cells[0].Value.ToString();
                txt_ItemId_Validating(null, null);
                num_Quantity.Value = numericUpDown_ItemQuantity.Value;
            }
        }

        private void mCustomerDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btn_CurrentDesk.Visible)
                return;

            if (gb_Cust.Enabled)
            {
                if (mCustomerDataGridView.RowCount == 0)
                    return;

                txt_CustId.Text = mCustomerDataGridView.CurrentRow.Cells[0].Value.ToString();
                txt_CustId_Validating(null, null);
            }
        }

        private void mEmployeeDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btn_CurrentDesk.Visible)
                return;

            if (gb_Emp.Enabled)
            {
                if (mEmployeeDataGridView.RowCount == 0)
                    return;

                txt_EmpId.Text = mEmployeeDataGridView.CurrentRow.Cells[0].Value.ToString();
                txt_EmpId_Validating(null, null);
            }
        }

        private void txt_EmpId_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_EmpId.Text.Trim()))
            {
                emp = (MEmployee)DataMaster.GetObjectByProperty(typeof(MEmployee), MEmployee.ColumnNames.EmployeeId, txt_EmpId.Text);

                if (cust != null)
                {
                    txt_EmpName.Text = emp.EmployeeName;

                    tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, activeButton.Name);

                    if (tdesk != null)
                    {
                        tdesk.EmployeeId = txt_EmpId.Text;
                        DataMaster.UpdatePersistence(tdesk);
                    }
                }
                else
                    txt_EmpName.ResetText();
            }
        }

        private void button_Tambah_Click(object sender, EventArgs e)
        {
            if (gb_Trans.Enabled && btn_CurrentDesk.Visible)
                gb_Trans.Visible = true;
        }

        private void button_Hapus_Click(object sender, EventArgs e)
        {
            if (tTransactionDetailDataGridView.Rows.Count > 0)
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    decimal total = 0;
                    TTransactionDetail det = (TTransactionDetail)DataMaster.GetObjectByProperty(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionDetailId, Convert.ToDecimal(tTransactionDetailDataGridView.CurrentRow.Cells[7].Value.ToString()));
                    total = det.Total;
                    DataMaster.Delete(det);

                    //update tdesk
                    tdesk = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskId, activeButton.Name);
                    tdesk.DeskGrandTotal = tdesk.DeskGrandTotal - total;
                    DataMaster.UpdatePersistence(tdesk);

                    timer1_Tick(null, null);

                    BindTransactionDetail();
                }
            }
        }

        private void dt_Out_ValueChanged(object sender, EventArgs e)
        {
            timer1_Tick(null, null);
            CalculateDuration();
        }
    }
}