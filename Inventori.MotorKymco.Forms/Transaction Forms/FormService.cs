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
using Inventori.Module;
using Inventori.Forms;

namespace Inventori.MotorKymco.Forms
{
    public partial class FormService : FormParentForMotorKymco
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private Balloon.NET.BalloonHelp balloonHelp;
        static int btnWidth = 50;
        static int btnHeight = 25;
        static int btnX = 5;
        static int btnY = 15;
        static int queue = 0;
        static Color noneBackColor = Color.Transparent;
        static Color noneForeColor = Color.Black;
        static Color activeBackCoor = Color.SteelBlue;
        static Color activeForeColor = Color.White;
        bool isInEdit = false;

        private Button _activeButton;
        private Button activeButton
        {
            get { return _activeButton; }
            set { _activeButton = value; }
        }


        public FormService()
        {
            InitializeComponent();
        }

        private void FormService_Load(object sender, EventArgs e)
        {
            isInEdit = false;
            btnX = 5;
            btnY = 10;
            SetInitialCommonSettings();
            CreateQueueList();
            FillServiceStatus();
        }

        void FillServiceStatus()
        {
            Type serv = typeof(ListOfServiceStatus);

            descriptionComboBox.Items.Clear();
            foreach (string s in Enum.GetNames(serv))
            {
                descriptionComboBox.Items.Add(Enum.Parse(serv, s).ToString().Replace("_", " "));
            }
            descriptionComboBox.Show();
        }

        private void SetInitialCommonSettings()
        {
            //servce typr
            mItemBindingSource.DataSource = DataMaster.GetListEq(typeof(MItem), MItem.ColumnNames.ItemTypeId, 2);

            //set date time picker
            ModuleControlSettings.SetDateTimePicker(transactionDateDateTimePicker, false);
            ModuleControlSettings.SetDateTimePicker(serviceRequestDateDateTimePicker, true);
            ModuleControlSettings.SetDateTimePicker(serviceStartWorkDateTimePicker, true);
            ModuleControlSettings.SetDateTimePicker(serviceEndWorkDateTimePicker, true);

            //set numeric up down
            ModuleControlSettings.SetNumericUpDown(quantityNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(priceNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(jumlahNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(discNumericUpDown);
            ModuleControlSettings.SetNumericUpDown(totalNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(transactionSubTotalNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(serviceChargeNumericUpDown, true);
            ModuleControlSettings.SetNumericUpDown(transactionGrandTotalNumericUpDown, true);


            //search item
            PictureBox searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicItem_Click);
            itemIdTextBox.Controls.Add(searchPic);

            //search customer
            searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(transactionByTextBox, ListOfSearchWindow.SearchCustomer.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicTransactionBy_Click);
            transactionByTextBox.Controls.Add(searchPic);

            //search employee
            searchPic = new PictureBox();
            ModuleControlSettings.SetSearchPictureBox(servicePicTextBox, ListOfSearchWindow.SearchEmployee.ToString(), searchPic);
            searchPic.Click += new EventHandler(searchPicEmployee_Click);
            servicePicTextBox.Controls.Add(searchPic);
        }

        private void CreateQueueList()
        {
            groupBox_TransHeader.Enabled = false;
            splitContainer_Detail_Detail.Enabled = false;

            groupBox_QueueList.Controls.Clear();
            IList listQueue = DataMaster.GetAll(typeof(TDesk));
            TDesk desk;
            Button btn;

            int max = 0;

            for (int i = 0; i < listQueue.Count; i++)
            {
                desk = (TDesk)listQueue[i];
                btn = new Button();
                btn.UseVisualStyleBackColor = true;
                btn.Text = desk.DeskId;
                btn.Tag = desk.DeskTransactionId;
                btn.Size = new Size(btnWidth, btnHeight);
                btn.Location = new Point(btnX, btnY);
                btnX += btnWidth + 5;

                if ((btnX + btnWidth) > splitContainer_Header.Panel2.Width)
                {
                    btnY += btnHeight + 5;
                    btnX = 5;
                }
                btn.BackColor = noneBackColor;
                btn.ForeColor = noneForeColor;
                btn.Click += new EventHandler(btn_Click);

                groupBox_QueueList.Controls.Add(btn);

                try
                {
                    if (int.Parse(desk.DeskId) > max)
                    {
                        max = int.Parse(desk.DeskId);
                    }
                }
                catch (Exception)
                {
                }

            }
            queue = max;
        }

        void btn_Click(object sender, EventArgs e)
        {
            if (!ConfirmSave())
                return;

            if (activeButton != null)
            {
                activeButton.BackColor = noneBackColor;
                activeButton.ForeColor = noneForeColor;
            }
            activeButton = (Button)sender;
            activeButton.BackColor = activeBackCoor;
            activeButton.ForeColor = activeForeColor;

            if (activeButton.Tag != null)
            {
                transactionIdLabel.Text = activeButton.Tag.ToString();
                IList tr = DataMaster.GetListEq(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, decimal.Parse(activeButton.Tag.ToString()));
                if (tr.Count > 0)
                {
                    tTransactionBindingSource.DataSource = tr;
                    transactionByTextBox_Validating(null, null);

                    TTransaction t = (TTransaction)tr[0];
                    if (t.TransactionStatus == ListOfTransaction.Service.ToString())
                    {
                        splitContainer_Detail_Detail.Enabled = false;
                        groupBox_TransHeader.Enabled = false;
                        toolStripButton_Save.Enabled = false;
                        toolStripButton_Cetak.Enabled = true;
                        toolStripButton_Cash.Enabled = false;
                        toolStripButton_Delete.Enabled = true;

                    }
                    else if (t.TransactionStatus == ListOfTransaction.Temp.ToString())
                    {
                        splitContainer_Detail_Detail.Enabled = true;
                        groupBox_TransHeader.Enabled = true;
                        toolStripButton_Save.Enabled = true;
                        toolStripButton_Cetak.Enabled = false;
                        toolStripButton_Cash.Enabled = true;
                        toolStripButton_Delete.Enabled = false;
                    }
                }
                else
                {
                    tTransactionBindingSource.Clear();
                    transactionFacturTextBox.Text = AppCode.GenerateFacturNo(ListOfTransaction.Sales, string.Empty);
                    customerNameTextBox.ResetText();


                    splitContainer_Detail_Detail.Enabled = true;
                    groupBox_TransHeader.Enabled = true;
                    toolStripButton_Save.Enabled = true;
                    toolStripButton_Cetak.Enabled = false;
                    toolStripButton_Cash.Enabled = false;
                    toolStripButton_Delete.Enabled = false;
                }

                tr = DataMaster.GetListEq(typeof(TTransactionService), TTransactionService.ColumnNames.TransactionId, decimal.Parse(activeButton.Tag.ToString()));
                if (tr.Count > 0)
                {
                    tTransactionServiceBindingSource.DataSource = tr;
                    servicePicTextBox_Validating(null, null);
                }
                else
                {
                    tTransactionServiceBindingSource.Clear();
                    employeeNameTextBox.ResetText();
                }
                FillGridDetailTransaction();
            }

            isInEdit = true;
            groupBox_TransDetail.Visible = false;
        }

        private void FillGridDetailTransaction()
        {
            tTransactionDetailDataGridView.Rows.Clear();
            IList listTrans = DataMaster.GetListEq(typeof(VTransactionDetail), VTransactionDetail.ColumnNames.TransactionId, decimal.Parse(transactionIdLabel.Text));
            VTransactionDetail det;
            object[] transDetail;
            for (int i = 0; i < listTrans.Count; i++)
            {
                det = (VTransactionDetail)listTrans[i];
                transDetail = new object[8];
                transDetail[0] = det.ItemId;
                transDetail[1] = det.ItemName;
                transDetail[2] = det.Quantity;
                transDetail[3] = det.Price;
                transDetail[4] = det.Jumlah;
                transDetail[5] = det.Disc;
                transDetail[6] = det.Total;
                transDetail[7] = det.Description;

                tTransactionDetailDataGridView.Rows.Add(transDetail);
            }
        }

        private void button_Queue_Click(object sender, EventArgs e)
        {
            if (!ConfirmSave())
                return;
            //ResetTransaction();

            transactionIdLabel.Text = DateTime.Now.ToFileTime().ToString();

            queue++;
            SaveQueue(queue);

            Button btn = new Button();
            btn = new Button();
            btn.UseVisualStyleBackColor = true;
            btn.Text = queue.ToString();
            btn.Size = new Size(btnWidth, btnHeight);
            btn.Location = new Point(btnX, btnY);
            btnX += btnWidth + 5;

            if ((btnX + btnWidth) > splitContainer_Header.Panel2.Width)
            {
                btnY += btnHeight + 5;
                btnX = 5;
            }
            btn.BackColor = noneBackColor;
            btn.ForeColor = noneForeColor;
            btn.Click += new EventHandler(btn_Click);
            btn.Tag = decimal.Parse(transactionIdLabel.Text);
            groupBox_QueueList.Controls.Add(btn);

            btn.PerformClick();

            groupBox_TransHeader.Enabled = true;
            splitContainer_Detail_Detail.Enabled = true;

            isInEdit = true;
            toolStripButton_Save.Enabled = true;
            toolStripButton_Cetak.Enabled = false;
            toolStripButton_Cash.Enabled = false;
            groupBox_TransDetail.Visible = false;
            toolStripButton_Delete.Enabled = false;
        }

        private bool ConfirmSave()
        {
            if (isInEdit)
            {
                if (MessageBox.Show("Transaksi " + this.Text + " belum disimpan. Anda yakin melanjutkan?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    return false;
            }
            return true;
        }

        private void SaveQueue(int queue)
        {
            TDesk desk = new TDesk();
            desk.DeskId = queue.ToString();
            desk.DeskTransactionId = decimal.Parse(transactionIdLabel.Text);
            desk.ModifiedBy = lbl_UserName.Text;
            desk.ModifiedDate = DateTime.Now;
            DataMaster.SavePersistence(desk);
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            ResetTransactionDetail();
            groupBox_TransDetail.Visible = true;
        }

        private void ResetTransactionDetail()
        {
            tTransactionDetailBindingSource.Clear();
            itemNameTextBox.ResetText();
        }

        private void button_CancelDetail_Click(object sender, EventArgs e)
        {
            groupBox_TransDetail.Visible = false;
        }

        private void searchPicTransactionBy_Click(object sender, EventArgs e)
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
                    f_SearchCustomer.WindowState = FormWindowState.Normal;
                    f_SearchCustomer.BringToFront();
                }
                else
                    f_SearchCustomer = new FormSearchCustomer();
            }
            else
                f_SearchCustomer = new FormSearchCustomer();

            f_SearchCustomer.CustomerHasSelected += new EventHandler(f_SearchCustomer_CustomerHasSelected);
            f_SearchCustomer.ShowInTaskbar = false;
            f_SearchCustomer.ShowDialog();
        }

        private void f_SearchCustomer_CustomerHasSelected(object sender, EventArgs e)
        {
            if (f_SearchCustomer.grid_Search.Rows.Count > 0)
            {
                transactionByTextBox.Text = f_SearchCustomer.grid_Search.CurrentRow.Cells[0].Value.ToString();
                transactionByTextBox_Validating(this, null);
            }
        }

        void searchPicItem_Click(object sender, EventArgs e)
        {
            OpenFormSearchItem();
        }

        FormSearchItem f_SearchItem;
        private void OpenFormSearchItem()
        {
            if (f_SearchItem != null)
            {
                if (!f_SearchItem.IsDisposed)
                {
                    f_SearchItem.WindowState = FormWindowState.Normal;
                    f_SearchItem.BringToFront();
                }
                else
                    f_SearchItem = new FormSearchItem();
            }
            else
                f_SearchItem = new FormSearchItem();

            f_SearchItem.ItemHasSelected += new EventHandler(f_SearchItem_ItemHasSelected);

            f_SearchItem.lbl_TempTransaction.Text = ListOfTransaction.Sales.ToString();
            f_SearchItem.itemType = 1;

            f_SearchItem.ShowInTaskbar = false;
            f_SearchItem.ShowDialog();
        }

        void searchPicEmployee_Click(object sender, EventArgs e)
        {
            OpenFormSearchEmployee();
        }

        FormSearchEmployee f_SearchEmployee;
        private void OpenFormSearchEmployee()
        {
            if (f_SearchEmployee != null)
            {
                if (!f_SearchEmployee.IsDisposed)
                {
                    f_SearchEmployee.WindowState = FormWindowState.Normal;
                    f_SearchEmployee.BringToFront();
                }
                else
                    f_SearchEmployee = new FormSearchEmployee();
            }
            else
                f_SearchEmployee = new FormSearchEmployee();

            f_SearchEmployee.EmployeeHasSelected += new EventHandler(f_SearchEmployee_EmployeeHasSelected);
            f_SearchEmployee.ShowDialog(this);
        }

        private void f_SearchEmployee_EmployeeHasSelected(object sender, EventArgs e)
        {
            if (f_SearchEmployee.grid_Search.Rows.Count > 0)
            {
                servicePicTextBox.Text = f_SearchEmployee.grid_Search.CurrentRow.Cells[0].Value.ToString();
                servicePicTextBox_Validating(null, null);
            }
        }

        private void f_SearchItem_ItemHasSelected(object sender, EventArgs e)
        {
            if (f_SearchItem.grid_Search.Rows.Count > 0)
            {
                itemIdTextBox.Text = f_SearchItem.grid_Search.CurrentRow.Cells[0].Value.ToString();
                itemIdTextBox_Validating(sender, null);
            }
        }

        private void transactionByTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(transactionByTextBox.Text.Trim()))
            {
                MCustomer cust = (MCustomer)DataMaster.GetObjectByProperty(typeof(MCustomer), MCustomer.ColumnNames.CustomerId, transactionByTextBox.Text);
                if (cust != null)
                {
                    customerNameTextBox.Text = cust.CustomerName;
                    if (sender != null)
                    {

                        transactionByAddressTextBox.Text = cust.CustomerAddress;
                        transactionByPhoneTextBox.Text = cust.CustomerPhone;
                        transactionDescTextBox.Text = cust.CustomerDesc2;
                        transactionDesc2TextBox.Text = cust.CustomerDesc;
                    }
                }
                else
                    customerNameTextBox.ResetText();

            }
        }

        private void transactionByTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(transactionByTextBox, ListOfSearchWindow.SearchCustomer.ToString(), true);
        }

        private void transactionByTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(transactionByTextBox, ListOfSearchWindow.SearchCustomer.ToString(), false);
        }

        private void itemIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(itemIdTextBox.Text.Trim()))
            {
                MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemIdTextBox.Text);

                if (item != null)
                {
                    itemNameTextBox.Text = item.ItemName;
                    priceNumericUpDown.Value = item.ItemPriceMax;

                }
            }
        }

        private void itemIdTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), true);
        }

        private void itemIdTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(itemIdTextBox, ListOfSearchWindow.SearchItem.ToString(), false);
        }

        private void SaveTransactionInterface(object sender, EventArgs e)
        {
            if (!ValidateTransaction())
                return;

            SaveTransaction();
            SaveTransactionService();
            DeleteTransactionDetail();
            SaveTransactionDetail();
            splitContainer_Detail_Detail.Enabled = true;

            isInEdit = false;
            toolStripButton_Save.Enabled = true;
            toolStripButton_Cetak.Enabled = false;
            toolStripButton_Cash.Enabled = true;
            toolStripButton_Delete.Enabled = false;

            MessageBox.Show("Transaksi " + this.Text + " berhasil disimpan", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteTransactionDetail()
        {
            IList listTrans = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, decimal.Parse(transactionIdLabel.Text));
            TTransactionDetail det;
            for (int i = 0; i < listTrans.Count; i++)
            {
                det = (TTransactionDetail)listTrans[i];
                DataMaster.Delete(det);
            }
        }

        private void SaveTransactionDetail()
        {
            TTransactionDetail det;
            MItem item;

            for (int i = 0; i < tTransactionDetailDataGridView.Rows.Count; i++)
            {
                item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, tTransactionDetailDataGridView.Rows[i].Cells[0].Value.ToString());
                decimal qty = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[2].Value);

                det = new TTransactionDetail();

                if (item != null)
                    det.CostPrice = qty * item.ItemPricePurchaseAvg;

                det.Description = tTransactionDetailDataGridView.Rows[i].Cells[7].Value.ToString();
                det.ItemId = tTransactionDetailDataGridView.Rows[i].Cells[0].Value.ToString();
                det.Jumlah = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[4].Value);
                det.Disc = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[5].Value);
                det.Ppn = 0;
                det.Price = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[3].Value);
                det.Quantity = qty;

                det.Total = Convert.ToDecimal(tTransactionDetailDataGridView.Rows[i].Cells[6].Value);

                det.TransactionId = decimal.Parse(transactionIdLabel.Text);

                det.ModifiedBy = lbl_UserName.Text;
                det.ModifiedDate = DateTime.Now;
                DataMaster.SavePersistence(det);
            }
        }

        private void SaveTransaction()
        {
            bool isSave = false;
            TTransaction t = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, decimal.Parse(transactionIdLabel.Text));
            if (t == null)
            {
                isSave = true;
                t = new TTransaction();
            }

            t.CurrencyId = ListOfCurrency.Rupiah.ToString();
            t.EmployeeId = servicePicTextBox.Text;

            t.GudangId = 1;
            t.TransactionBy = transactionByTextBox.Text;
            t.TransactionByAddress = transactionByAddressTextBox.Text;
            t.TransactionByPhone = transactionByPhoneTextBox.Text;
            t.TransactionDesc = transactionDescTextBox.Text;
            t.TransactionDesc2 = transactionDesc2TextBox.Text;


            t.TransactionCommision = decimal.Zero;
            t.TransactionDate = transactionDateDateTimePicker.Value;

            t.TransactionDisc = decimal.Zero;
            t.TransactionFactur = transactionFacturTextBox.Text;
            t.TransactionGrandTotal = transactionGrandTotalNumericUpDown.Value;
            t.TransactionId = decimal.Parse(transactionIdLabel.Text);

            t.TransactionPaid = transactionGrandTotalNumericUpDown.Value;


            t.TransactionPayment = "Cash";

            t.TransactionReferenceId = decimal.Zero;

            t.TransactionPpn = decimal.Zero;

            t.TransactionSisa = decimal.Zero;


            t.TransactionStatus = ListOfTransaction.Temp.ToString();
            t.TransactionSubTotal = transactionSubTotalNumericUpDown.Value;
            t.TransactionUsePpn = false;

            t.ModifiedBy = lbl_UserName.Text;
            t.ModifiedDate = DateTime.Now;

            if (isSave)
                DataMaster.SavePersistence(t);
            else
                DataMaster.UpdatePersistence(t);
        }

        private void SaveTransactionService()
        {
            bool isSave = false;
            TTransactionService t = (TTransactionService)DataMaster.GetObjectByProperty(typeof(TTransactionService), TTransactionService.ColumnNames.TransactionId, decimal.Parse(transactionIdLabel.Text));
            if (t == null)
            {
                isSave = true;
                t = new TTransactionService();
            }
            t.ServiceCharge = serviceChargeNumericUpDown.Value;
            t.ServiceComplain = serviceComplainTextBox.Text;
            t.ServiceDesc = serviceDescTextBox.Text;
            t.ServiceEndWork = serviceEndWorkDateTimePicker.Value;
            t.ServiceFirstCondition = serviceFirstConditionTextBox.Text;
            t.ServicePic = servicePicTextBox.Text;
            t.ServiceRequestDate = serviceRequestDateDateTimePicker.Value;
            t.ServiceStartWork = serviceStartWorkDateTimePicker.Value;
            if (serviceTypeComboBox.SelectedIndex != -1)
                t.ServiceType = serviceTypeComboBox.SelectedValue.ToString();
            t.TransactionId = decimal.Parse(transactionIdLabel.Text);
            t.ModifiedBy = lbl_UserName.Text;
            t.ModifiedDate = DateTime.Now;

            if (isSave)
                DataMaster.SavePersistence(t);
            else
                DataMaster.UpdatePersistence(t);
        }

        private bool ValidateTransaction()
        {
            RecreateBalloon();

            balloonHelp.Caption = "Validasi data kurang";
            if (string.IsNullOrEmpty(transactionFacturTextBox.Text.Trim()))
            {
                balloonHelp.Content = "Nomor faktur harus diisi !!";
                balloonHelp.ShowBalloon(transactionFacturTextBox);
                transactionFacturTextBox.Focus();
                return false;
            }

            if (serviceTypeComboBox.SelectedIndex == -1)
            {
                balloonHelp.Content = "Pilih jenis service !!";
                balloonHelp.ShowBalloon(serviceTypeComboBox);
                serviceTypeComboBox.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(transactionFacturTextBox.Text.Trim()))
            {
                TTransaction tr = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionFactur, transactionFacturTextBox.Text.Trim(), TTransaction.ColumnNames.TransactionStatus, ListOfTransaction.Sales.ToString());
                if (tr != null)
                {
                    balloonHelp.Content = "Nomor faktur " + transactionFacturTextBox.Text + " sudah pernah diinput, silahkan input nomor faktur yang lain.";
                    balloonHelp.ShowBalloon(transactionFacturTextBox);
                    transactionFacturTextBox.Focus();
                    return false;
                }
            }

            return true;
        }

        private void RecreateBalloon()
        {
            balloonHelp = new Balloon.NET.BalloonHelp();
            balloonHelp.Icon = Properties.Resources.warning_ico;
            balloonHelp.CloseOnMouseClick = true;
            balloonHelp.CloseOnDeactivate = false;
            balloonHelp.CloseOnMouseMove = false;
            balloonHelp.CloseOnKeyPress = false;
            balloonHelp.ShowCloseButton = false;
        }

        private void servicePicTextBox_Validating(object sender, CancelEventArgs e)
        {
            ModuleControlSettings.EmployeeValidating(servicePicTextBox.Text.Trim(), employeeNameTextBox);
        }

        private void servicePicTextBox_Enter(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(servicePicTextBox, ListOfSearchWindow.SearchEmployee.ToString(), true);
        }

        private void servicePicTextBox_Leave(object sender, EventArgs e)
        {
            ModuleControlSettings.SetVisibleControlChild(servicePicTextBox, ListOfSearchWindow.SearchEmployee.ToString(), false);
        }

        private void serviceTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serviceTypeComboBox.SelectedIndex == -1)
                return;

            MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, serviceTypeComboBox.SelectedValue.ToString());
            if (item != null)
            {
                serviceChargeNumericUpDown.Value = item.ItemPriceMax;
            }
        }

        private void CalculateGrandTotal(object sender, EventArgs e)
        {
            transactionGrandTotalNumericUpDown.Value = transactionSubTotalNumericUpDown.Value + serviceChargeNumericUpDown.Value;
        }

        private void CalculateTotal(object sender, EventArgs e)
        {
            if (descriptionComboBox.SelectedIndex != -1)
            {
                if (descriptionComboBox.SelectedItem.ToString() == ListOfServiceStatus.Klaim.ToString() || descriptionComboBox.SelectedItem.ToString() == ListOfServiceStatus.KSG.ToString())
                {
                    discNumericUpDown.Value = 100;
                }
            }

            jumlahNumericUpDown.Value = priceNumericUpDown.Value * quantityNumericUpDown.Value;
            totalNumericUpDown.Value = jumlahNumericUpDown.Value * ((100 - discNumericUpDown.Value) / 100);
        }

        private void tTransactionDetailDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateSubTotal();
        }

        private void tTransactionDetailDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateSubTotal();
        }

        private void CalculateSubTotal()
        {
            decimal sub = decimal.Zero;
            for (int i = 0; i < tTransactionDetailDataGridView.RowCount; i++)
            {
                sub += decimal.Parse(tTransactionDetailDataGridView.Rows[i].Cells[6].Value.ToString());
            }
            transactionSubTotalNumericUpDown.Value = sub;
        }

        private void button_SaveDetail_Click(object sender, EventArgs e)
        {
            if (!ValidateTransactionDetail())
                return;

            object[] transDetail = new object[8];
            transDetail[0] = itemIdTextBox.Text;
            transDetail[1] = itemNameTextBox.Text;
            transDetail[2] = quantityNumericUpDown.Value;
            transDetail[3] = priceNumericUpDown.Value;
            transDetail[4] = jumlahNumericUpDown.Value;
            transDetail[5] = discNumericUpDown.Value;
            transDetail[6] = totalNumericUpDown.Value;
            transDetail[7] = descriptionComboBox.Text;

            tTransactionDetailDataGridView.Rows.Add(transDetail);

            groupBox_TransDetail.Visible = false;

        }

        private bool ValidateTransactionDetail()
        {
            RecreateBalloon();
            balloonHelp.Caption = "Validasi data kurang";

            if (quantityNumericUpDown.Value == 0)
            {
                balloonHelp.Content = "Kuantitas tidak boleh 0 !!";
                balloonHelp.ShowBalloon(quantityNumericUpDown);
                quantityNumericUpDown.Focus();
                return false;
            }


            if (string.IsNullOrEmpty(itemIdTextBox.Text))
            {
                balloonHelp.Content = "Item harus diisi !!";
                balloonHelp.ShowBalloon(itemIdTextBox);
                itemIdTextBox.Focus();
                return false;
            }
            else
            {
                MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemIdTextBox.Text);
                if (item == null)
                {
                    balloonHelp.Content = "Item " + itemIdTextBox.Text + " tidak ada dalam database. \n Pastikan anda menulis kode yang tepat atau \n pilih item dengan mengklik gambar disamping untuk mencari Item.";
                    balloonHelp.ShowBalloon(itemIdTextBox);
                    itemIdTextBox.Focus();
                    return false;
                }
                else
                {
                    int gudangId = 1;
                    string gudangName = "Toko";

                    ItemGudangStok gud = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, item.ItemId, ItemGudangStok.ColumnNames.GudangId, gudangId);
                    if (gud == null)
                    {
                        if (MessageBox.Show("Stok Item di " + gudangName + " = 0. Anda yakin melanjutkan transaksi?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                    else
                    {

                        if (gud.ItemStok < quantityNumericUpDown.Value)
                        {
                            if (MessageBox.Show("Stok Item di " + gudangName + " tidak mencukupi untuk transaksi ini. Anda yakin melanjutkan transaksi?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (tTransactionDetailDataGridView.Rows.Count > 0)
            {
                if (MessageBox.Show("Anda yakin menghapus data?", "Konfirmasi Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (tTransactionDetailDataGridView.CurrentRow.Index != -1)
                        tTransactionDetailDataGridView.Rows.RemoveAt(tTransactionDetailDataGridView.CurrentRow.Index);
                    else
                        tTransactionDetailDataGridView.Rows.RemoveAt(0);

                }
            }
        }

        private void toolStripButton_Cash_Click(object sender, EventArgs e)
        {
            if (!ConfirmSave())
                return;

            if (MessageBox.Show("Pembayaran transaksi " + this.Text + " akan dilakukan. Anda yakin?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                return;

            TTransaction t = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, decimal.Parse(transactionIdLabel.Text));
            if (t != null)
            {
                t.TransactionStatus = ListOfTransaction.Service.ToString();
                t.ModifiedBy = lbl_UserName.Text;
                t.ModifiedDate = DateTime.Now;
                DataMaster.UpdatePersistence(t);

                groupBox_TransHeader.Enabled = false;
                splitContainer_Detail_Detail.Enabled = false;
                isInEdit = false;
                toolStripButton_Save.Enabled = false;
                toolStripButton_Cetak.Enabled = true;
                toolStripButton_Cash.Enabled = false;
                toolStripButton_Delete.Enabled = true;

                UpdateStok();

                MessageBox.Show("Pembayaran transaksi " + this.Text + " berhasil dilakukan.", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void UpdateStok()
        {
            bool AddStok = false;

            IList listTrans = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, decimal.Parse(transactionIdLabel.Text));
            TTransactionDetail det;
            for (int i = 0; i < listTrans.Count; i++)
            {
                det = (TTransactionDetail)listTrans[i];
                UpdateStok(1, det.ItemId, det.Quantity, AddStok);
            }
        }

        private void UpdateStok(int gudangId, string itemId, decimal qty, bool AddStok)
        {
            ItemGudangStok stok;
            TStokCard krt;
            decimal saldo = 0;

            MItem item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, itemId);

            if (item != null)
            {
                //if item == barang
                if (item.ItemTypeId == 1)
                {
                    //change stok
                    stok = (ItemGudangStok)DataMaster.GetObjectByProperty(typeof(ItemGudangStok), ItemGudangStok.ColumnNames.ItemId, itemId, ItemGudangStok.ColumnNames.GudangId, gudangId);
                    if (stok != null)
                    {
                        if (AddStok)
                            saldo = stok.ItemStok + qty;
                        else
                            saldo = stok.ItemStok - qty;

                        stok.ItemStok = saldo;
                        stok.ModifiedBy = lbl_UserName.Text;
                        stok.ModifiedDate = DateTime.Now;
                        DataMaster.UpdatePersistence(stok);
                    }
                    else
                    {
                        stok = new ItemGudangStok();
                        stok.GudangId = gudangId;
                        stok.ItemId = itemId;
                        stok.ItemMaxStok = decimal.Zero;
                        stok.ItemMinStok = decimal.Zero;
                        if (AddStok)
                            saldo = qty;
                        else
                            saldo = qty * -1;

                        stok.ItemStok = saldo;
                        stok.ModifiedBy = lbl_UserName.Text;
                        stok.ModifiedDate = DateTime.Now;
                        DataMaster.SavePersistence(stok);
                    }
                }

                krt = new TStokCard();
                krt.ItemId = itemId;
                krt.GudangId = gudangId;
                krt.StokCardDate = DateTime.Today;
                krt.StokCardPic = transactionByTextBox.Text;
                krt.StokCardQuantity = qty;
                krt.StokCardSaldo = saldo;
                krt.StokCardStatus = AddStok;
                krt.TransactionId = Convert.ToDecimal(transactionIdLabel.Text);
                krt.ModifiedBy = lbl_UserName.Text;
                krt.ModifiedDate = DateTime.Now;
                DataMaster.SavePersistence(krt);
            }
        }

        private void toolStripButton_Cetak_Click(object sender, EventArgs e)
        {
            FormViewReport f_Report = new FormViewReport();
            f_Report.listOfReports = ListOfReports.ReportSPKFactur;
            f_Report.DataId = transactionIdLabel.Text;
            f_Report.Show(this);
        }

        private void toolStripButton_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hapus antrian? Anda yakin?", AppCode.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                return;

            TDesk d = (TDesk)DataMaster.GetObjectByProperty(typeof(TDesk), TDesk.ColumnNames.DeskTransactionId, decimal.Parse(transactionIdLabel.Text));
            if (d != null)
                DataMaster.Delete(d);

            groupBox_QueueList.Controls.Remove(activeButton);

            groupBox_TransHeader.Enabled = false;
            splitContainer_Detail_Detail.Enabled = false;
            isInEdit = false;
            toolStripButton_Save.Enabled = false;
            toolStripButton_Cetak.Enabled = false;
            toolStripButton_Cash.Enabled = false;
            toolStripButton_Delete.Enabled = false;

            MessageBox.Show("Hapus antrian berhasil dilakukan.", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}