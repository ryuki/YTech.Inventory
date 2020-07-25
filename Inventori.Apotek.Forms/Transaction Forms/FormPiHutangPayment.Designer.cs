namespace Inventori.Apotek.Forms
{
    partial class FormPiHutangPayment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label journalDateLabel;
            System.Windows.Forms.Label voucherNoLabel;
            System.Windows.Forms.Label journalDescLabel;
            System.Windows.Forms.Label journalJumlahLabel;
            this.subAccountIdLabel = new System.Windows.Forms.Label();
            this.piHutangPicLabel = new System.Windows.Forms.Label();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.splitContainer_Header = new System.Windows.Forms.SplitContainer();
            this.groupBox_CompanyName = new System.Windows.Forms.GroupBox();
            this.companyNameLabel = new System.Windows.Forms.Label();
            this.splitContainer_Head = new System.Windows.Forms.SplitContainer();
            this.piHutangPicComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox_Head = new System.Windows.Forms.GroupBox();
            this.journalJumlahNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tJournalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.journalDescTextBox = new System.Windows.Forms.TextBox();
            this.voucherNoTextBox = new System.Windows.Forms.TextBox();
            this.journalDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.subAccountIdComboBox = new System.Windows.Forms.ComboBox();
            this.mSubAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.journalJumlahLabel2 = new System.Windows.Forms.Label();
            this.journalJumlahSaidLabel = new System.Windows.Forms.Label();
            this.groupBox_PiHutangDetail = new System.Windows.Forms.GroupBox();
            this.label_Retur = new System.Windows.Forms.Label();
            this.label_Ammount = new System.Windows.Forms.Label();
            this.label_Sisa = new System.Windows.Forms.Label();
            this.label_Jumlah = new System.Windows.Forms.Label();
            this.label_DueDate = new System.Windows.Forms.Label();
            this.label_FacturNo = new System.Windows.Forms.Label();
            this.label_Pay = new System.Windows.Forms.Label();
            this.tPiHutangDataGridView = new System.Windows.Forms.DataGridView();
            this.tJournalBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.simpanToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CetakToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Reset = new System.Windows.Forms.ToolStripButton();
            journalDateLabel = new System.Windows.Forms.Label();
            voucherNoLabel = new System.Windows.Forms.Label();
            journalDescLabel = new System.Windows.Forms.Label();
            journalJumlahLabel = new System.Windows.Forms.Label();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.Panel2.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            this.splitContainer_Header.Panel1.SuspendLayout();
            this.splitContainer_Header.Panel2.SuspendLayout();
            this.splitContainer_Header.SuspendLayout();
            this.groupBox_CompanyName.SuspendLayout();
            this.splitContainer_Head.Panel1.SuspendLayout();
            this.splitContainer_Head.Panel2.SuspendLayout();
            this.splitContainer_Head.SuspendLayout();
            this.groupBox_Head.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.journalJumlahNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tJournalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSubAccountBindingSource)).BeginInit();
            this.groupBox_PiHutangDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tPiHutangDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tJournalBindingNavigator)).BeginInit();
            this.tJournalBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Location = new System.Drawing.Point(358, 117);
            // 
            // subAccountIdLabel
            // 
            this.subAccountIdLabel.AutoSize = true;
            this.subAccountIdLabel.Location = new System.Drawing.Point(12, 28);
            this.subAccountIdLabel.Name = "subAccountIdLabel";
            this.subAccountIdLabel.Size = new System.Drawing.Size(38, 13);
            this.subAccountIdLabel.TabIndex = 10;
            this.subAccountIdLabel.Text = "Akun :";
            // 
            // journalDateLabel
            // 
            journalDateLabel.AutoSize = true;
            journalDateLabel.Location = new System.Drawing.Point(12, 53);
            journalDateLabel.Name = "journalDateLabel";
            journalDateLabel.Size = new System.Drawing.Size(52, 13);
            journalDateLabel.TabIndex = 11;
            journalDateLabel.Text = "Tanggal :";
            // 
            // voucherNoLabel
            // 
            voucherNoLabel.AutoSize = true;
            voucherNoLabel.Location = new System.Drawing.Point(12, 75);
            voucherNoLabel.Name = "voucherNoLabel";
            voucherNoLabel.Size = new System.Drawing.Size(70, 13);
            voucherNoLabel.TabIndex = 12;
            voucherNoLabel.Text = "No Voucher :";
            // 
            // journalDescLabel
            // 
            journalDescLabel.AutoSize = true;
            journalDescLabel.Location = new System.Drawing.Point(10, 98);
            journalDescLabel.Name = "journalDescLabel";
            journalDescLabel.Size = new System.Drawing.Size(68, 13);
            journalDescLabel.TabIndex = 13;
            journalDescLabel.Text = "Keterangan :";
            // 
            // journalJumlahLabel
            // 
            journalJumlahLabel.AutoSize = true;
            journalJumlahLabel.Location = new System.Drawing.Point(11, 146);
            journalJumlahLabel.Name = "journalJumlahLabel";
            journalJumlahLabel.Size = new System.Drawing.Size(43, 13);
            journalJumlahLabel.TabIndex = 14;
            journalJumlahLabel.Text = "Jumlah:";
            // 
            // piHutangPicLabel
            // 
            this.piHutangPicLabel.AutoSize = true;
            this.piHutangPicLabel.Location = new System.Drawing.Point(10, 9);
            this.piHutangPicLabel.Name = "piHutangPicLabel";
            this.piHutangPicLabel.Size = new System.Drawing.Size(75, 13);
            this.piHutangPicLabel.TabIndex = 0;
            this.piHutangPicLabel.Text = "Pi Hutang Pic:";
            // 
            // splitContainer_Main
            // 
            this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Main.Name = "splitContainer_Main";
            this.splitContainer_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.Controls.Add(this.splitContainer_Header);
            // 
            // splitContainer_Main.Panel2
            // 
            this.splitContainer_Main.Panel2.Controls.Add(this.groupBox_PiHutangDetail);
            this.splitContainer_Main.Size = new System.Drawing.Size(992, 616);
            this.splitContainer_Main.SplitterDistance = 321;
            this.splitContainer_Main.TabIndex = 2;
            // 
            // splitContainer_Header
            // 
            this.splitContainer_Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Header.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_Header.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Header.Name = "splitContainer_Header";
            this.splitContainer_Header.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Header.Panel1
            // 
            this.splitContainer_Header.Panel1.Controls.Add(this.groupBox_CompanyName);
            // 
            // splitContainer_Header.Panel2
            // 
            this.splitContainer_Header.Panel2.Controls.Add(this.splitContainer_Head);
            this.splitContainer_Header.Size = new System.Drawing.Size(992, 321);
            this.splitContainer_Header.SplitterDistance = 68;
            this.splitContainer_Header.TabIndex = 0;
            // 
            // groupBox_CompanyName
            // 
            this.groupBox_CompanyName.Controls.Add(this.companyNameLabel);
            this.groupBox_CompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_CompanyName.Location = new System.Drawing.Point(0, 0);
            this.groupBox_CompanyName.Name = "groupBox_CompanyName";
            this.groupBox_CompanyName.Size = new System.Drawing.Size(992, 68);
            this.groupBox_CompanyName.TabIndex = 0;
            this.groupBox_CompanyName.TabStop = false;
            // 
            // companyNameLabel
            // 
            this.companyNameLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.companyNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyNameLabel.Location = new System.Drawing.Point(3, 30);
            this.companyNameLabel.Name = "companyNameLabel";
            this.companyNameLabel.Size = new System.Drawing.Size(986, 35);
            this.companyNameLabel.TabIndex = 1;
            this.companyNameLabel.Text = "companyName";
            this.companyNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer_Head
            // 
            this.splitContainer_Head.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Head.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_Head.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Head.Name = "splitContainer_Head";
            this.splitContainer_Head.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Head.Panel1
            // 
            this.splitContainer_Head.Panel1.AutoScroll = true;
            this.splitContainer_Head.Panel1.Controls.Add(this.piHutangPicLabel);
            this.splitContainer_Head.Panel1.Controls.Add(this.piHutangPicComboBox);
            // 
            // splitContainer_Head.Panel2
            // 
            this.splitContainer_Head.Panel2.Controls.Add(this.groupBox_Head);
            this.splitContainer_Head.Size = new System.Drawing.Size(992, 249);
            this.splitContainer_Head.SplitterDistance = 33;
            this.splitContainer_Head.TabIndex = 0;
            // 
            // piHutangPicComboBox
            // 
            this.piHutangPicComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.piHutangPicComboBox.FormattingEnabled = true;
            this.piHutangPicComboBox.Location = new System.Drawing.Point(115, 6);
            this.piHutangPicComboBox.Name = "piHutangPicComboBox";
            this.piHutangPicComboBox.Size = new System.Drawing.Size(231, 21);
            this.piHutangPicComboBox.TabIndex = 1;
            this.piHutangPicComboBox.SelectedIndexChanged += new System.EventHandler(this.piHutangPicComboBox_SelectedIndexChanged);
            // 
            // groupBox_Head
            // 
            this.groupBox_Head.Controls.Add(journalJumlahLabel);
            this.groupBox_Head.Controls.Add(this.journalJumlahNumericUpDown);
            this.groupBox_Head.Controls.Add(journalDescLabel);
            this.groupBox_Head.Controls.Add(this.journalDescTextBox);
            this.groupBox_Head.Controls.Add(voucherNoLabel);
            this.groupBox_Head.Controls.Add(this.voucherNoTextBox);
            this.groupBox_Head.Controls.Add(journalDateLabel);
            this.groupBox_Head.Controls.Add(this.journalDateDateTimePicker);
            this.groupBox_Head.Controls.Add(this.subAccountIdLabel);
            this.groupBox_Head.Controls.Add(this.subAccountIdComboBox);
            this.groupBox_Head.Controls.Add(this.journalJumlahLabel2);
            this.groupBox_Head.Controls.Add(this.journalJumlahSaidLabel);
            this.groupBox_Head.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Head.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Head.Name = "groupBox_Head";
            this.groupBox_Head.Size = new System.Drawing.Size(992, 212);
            this.groupBox_Head.TabIndex = 0;
            this.groupBox_Head.TabStop = false;
            this.groupBox_Head.Text = "groupBox_Head";
            // 
            // journalJumlahNumericUpDown
            // 
            this.journalJumlahNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tJournalBindingSource, "JournalJumlah", true));
            this.journalJumlahNumericUpDown.Location = new System.Drawing.Point(103, 144);
            this.journalJumlahNumericUpDown.Name = "journalJumlahNumericUpDown";
            this.journalJumlahNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.journalJumlahNumericUpDown.TabIndex = 15;
            // 
            // tJournalBindingSource
            // 
            this.tJournalBindingSource.DataSource = typeof(Inventori.Data.TJournal);
            // 
            // journalDescTextBox
            // 
            this.journalDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tJournalBindingSource, "JournalDesc", true));
            this.journalDescTextBox.Location = new System.Drawing.Point(102, 95);
            this.journalDescTextBox.Multiline = true;
            this.journalDescTextBox.Name = "journalDescTextBox";
            this.journalDescTextBox.Size = new System.Drawing.Size(244, 46);
            this.journalDescTextBox.TabIndex = 14;
            // 
            // voucherNoTextBox
            // 
            this.voucherNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tJournalBindingSource, "VoucherNo", true));
            this.voucherNoTextBox.Location = new System.Drawing.Point(102, 72);
            this.voucherNoTextBox.Name = "voucherNoTextBox";
            this.voucherNoTextBox.Size = new System.Drawing.Size(140, 20);
            this.voucherNoTextBox.TabIndex = 13;
            // 
            // journalDateDateTimePicker
            // 
            this.journalDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tJournalBindingSource, "JournalDate", true));
            this.journalDateDateTimePicker.Location = new System.Drawing.Point(102, 49);
            this.journalDateDateTimePicker.Name = "journalDateDateTimePicker";
            this.journalDateDateTimePicker.Size = new System.Drawing.Size(110, 20);
            this.journalDateDateTimePicker.TabIndex = 12;
            // 
            // subAccountIdComboBox
            // 
            this.subAccountIdComboBox.DataSource = this.mSubAccountBindingSource;
            this.subAccountIdComboBox.DisplayMember = "SubAccountName";
            this.subAccountIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subAccountIdComboBox.FormattingEnabled = true;
            this.subAccountIdComboBox.Location = new System.Drawing.Point(102, 25);
            this.subAccountIdComboBox.Name = "subAccountIdComboBox";
            this.subAccountIdComboBox.Size = new System.Drawing.Size(206, 21);
            this.subAccountIdComboBox.TabIndex = 11;
            this.subAccountIdComboBox.ValueMember = "SubAccountId";
            // 
            // mSubAccountBindingSource
            // 
            this.mSubAccountBindingSource.DataSource = typeof(Inventori.Data.MSubAccount);
            // 
            // journalJumlahLabel2
            // 
            this.journalJumlahLabel2.AutoSize = true;
            this.journalJumlahLabel2.Location = new System.Drawing.Point(12, 172);
            this.journalJumlahLabel2.Name = "journalJumlahLabel2";
            this.journalJumlahLabel2.Size = new System.Drawing.Size(57, 13);
            this.journalJumlahLabel2.TabIndex = 8;
            this.journalJumlahLabel2.Text = "Terbilang :";
            this.journalJumlahLabel2.Visible = false;
            // 
            // journalJumlahSaidLabel
            // 
            this.journalJumlahSaidLabel.AutoSize = true;
            this.journalJumlahSaidLabel.Location = new System.Drawing.Point(105, 172);
            this.journalJumlahSaidLabel.Name = "journalJumlahSaidLabel";
            this.journalJumlahSaidLabel.Size = new System.Drawing.Size(60, 13);
            this.journalJumlahSaidLabel.TabIndex = 9;
            this.journalJumlahSaidLabel.Text = "Nol Rupiah";
            this.journalJumlahSaidLabel.Visible = false;
            // 
            // groupBox_PiHutangDetail
            // 
            this.groupBox_PiHutangDetail.Controls.Add(this.label_Retur);
            this.groupBox_PiHutangDetail.Controls.Add(this.label_Ammount);
            this.groupBox_PiHutangDetail.Controls.Add(this.label_Sisa);
            this.groupBox_PiHutangDetail.Controls.Add(this.label_Jumlah);
            this.groupBox_PiHutangDetail.Controls.Add(this.label_DueDate);
            this.groupBox_PiHutangDetail.Controls.Add(this.label_FacturNo);
            this.groupBox_PiHutangDetail.Controls.Add(this.label_Pay);
            this.groupBox_PiHutangDetail.Controls.Add(this.tPiHutangDataGridView);
            this.groupBox_PiHutangDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_PiHutangDetail.Location = new System.Drawing.Point(0, 0);
            this.groupBox_PiHutangDetail.Name = "groupBox_PiHutangDetail";
            this.groupBox_PiHutangDetail.Size = new System.Drawing.Size(992, 291);
            this.groupBox_PiHutangDetail.TabIndex = 0;
            this.groupBox_PiHutangDetail.TabStop = false;
            this.groupBox_PiHutangDetail.Text = "groupBox_PiHutangDetail";
            // 
            // label_Retur
            // 
            this.label_Retur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Retur.Location = new System.Drawing.Point(385, 16);
            this.label_Retur.Name = "label_Retur";
            this.label_Retur.Size = new System.Drawing.Size(103, 23);
            this.label_Retur.TabIndex = 28;
            this.label_Retur.Text = "Retur";
            this.label_Retur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Ammount
            // 
            this.label_Ammount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Ammount.Location = new System.Drawing.Point(591, 16);
            this.label_Ammount.Name = "label_Ammount";
            this.label_Ammount.Size = new System.Drawing.Size(103, 23);
            this.label_Ammount.TabIndex = 27;
            this.label_Ammount.Text = "Jumlah Dibayar";
            this.label_Ammount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Sisa
            // 
            this.label_Sisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Sisa.Location = new System.Drawing.Point(488, 16);
            this.label_Sisa.Name = "label_Sisa";
            this.label_Sisa.Size = new System.Drawing.Size(103, 23);
            this.label_Sisa.TabIndex = 26;
            this.label_Sisa.Text = "Sisa";
            this.label_Sisa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Jumlah
            // 
            this.label_Jumlah.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Jumlah.Location = new System.Drawing.Point(282, 16);
            this.label_Jumlah.Name = "label_Jumlah";
            this.label_Jumlah.Size = new System.Drawing.Size(103, 23);
            this.label_Jumlah.TabIndex = 25;
            this.label_Jumlah.Text = "Jumlah";
            this.label_Jumlah.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_DueDate
            // 
            this.label_DueDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_DueDate.Location = new System.Drawing.Point(199, 16);
            this.label_DueDate.Name = "label_DueDate";
            this.label_DueDate.Size = new System.Drawing.Size(83, 23);
            this.label_DueDate.TabIndex = 24;
            this.label_DueDate.Text = "Jth Tempo";
            this.label_DueDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_FacturNo
            // 
            this.label_FacturNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_FacturNo.Location = new System.Drawing.Point(69, 16);
            this.label_FacturNo.Name = "label_FacturNo";
            this.label_FacturNo.Size = new System.Drawing.Size(130, 23);
            this.label_FacturNo.TabIndex = 23;
            this.label_FacturNo.Text = "No Faktur";
            this.label_FacturNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Pay
            // 
            this.label_Pay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Pay.Location = new System.Drawing.Point(13, 16);
            this.label_Pay.Name = "label_Pay";
            this.label_Pay.Size = new System.Drawing.Size(56, 23);
            this.label_Pay.TabIndex = 22;
            this.label_Pay.Text = "Dibayar";
            this.label_Pay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tPiHutangDataGridView
            // 
            this.tPiHutangDataGridView.AllowUserToAddRows = false;
            this.tPiHutangDataGridView.AllowUserToDeleteRows = false;
            this.tPiHutangDataGridView.AllowUserToResizeColumns = false;
            this.tPiHutangDataGridView.AllowUserToResizeRows = false;
            this.tPiHutangDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.tPiHutangDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tPiHutangDataGridView.ColumnHeadersVisible = false;
            this.tPiHutangDataGridView.Location = new System.Drawing.Point(13, 39);
            this.tPiHutangDataGridView.MultiSelect = false;
            this.tPiHutangDataGridView.Name = "tPiHutangDataGridView";
            this.tPiHutangDataGridView.ReadOnly = true;
            this.tPiHutangDataGridView.RowHeadersVisible = false;
            this.tPiHutangDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tPiHutangDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tPiHutangDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tPiHutangDataGridView.Size = new System.Drawing.Size(681, 208);
            this.tPiHutangDataGridView.TabIndex = 17;
            this.tPiHutangDataGridView.TabStop = false;
            this.tPiHutangDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.tPiHutangDataGridView_CellBeginEdit);
            this.tPiHutangDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tPiHutangDataGridView_CellEndEdit);
            this.tPiHutangDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.tPiHutangDataGridView_CellEnter);
            // 
            // tJournalBindingNavigator
            // 
            this.tJournalBindingNavigator.AddNewItem = null;
            this.tJournalBindingNavigator.CountItem = null;
            this.tJournalBindingNavigator.DeleteItem = null;
            this.tJournalBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpanToolStripButton,
            this.CetakToolStripButton,
            this.toolStripSeparator1,
            this.toolStripButton_Reset});
            this.tJournalBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.tJournalBindingNavigator.MoveFirstItem = null;
            this.tJournalBindingNavigator.MoveLastItem = null;
            this.tJournalBindingNavigator.MoveNextItem = null;
            this.tJournalBindingNavigator.MovePreviousItem = null;
            this.tJournalBindingNavigator.Name = "tJournalBindingNavigator";
            this.tJournalBindingNavigator.PositionItem = null;
            this.tJournalBindingNavigator.Size = new System.Drawing.Size(992, 36);
            this.tJournalBindingNavigator.TabIndex = 3;
            this.tJournalBindingNavigator.Text = "bindingNavigator1";
            // 
            // simpanToolStripButton
            // 
            this.simpanToolStripButton.Image = global::Inventori.Apotek.Forms.Properties.Resources.save;
            this.simpanToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.simpanToolStripButton.Name = "simpanToolStripButton";
            this.simpanToolStripButton.Size = new System.Drawing.Size(45, 33);
            this.simpanToolStripButton.Text = "Simpan";
            this.simpanToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.simpanToolStripButton.Click += new System.EventHandler(this.UpdatePiHutang);
            // 
            // CetakToolStripButton
            // 
            this.CetakToolStripButton.Image = global::Inventori.Apotek.Forms.Properties.Resources.printer;
            this.CetakToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CetakToolStripButton.Name = "CetakToolStripButton";
            this.CetakToolStripButton.Size = new System.Drawing.Size(65, 33);
            this.CetakToolStripButton.Text = "Cetak Bukti";
            this.CetakToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CetakToolStripButton.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // toolStripButton_Reset
            // 
            this.toolStripButton_Reset.Image = global::Inventori.Apotek.Forms.Properties.Resources.Refresh;
            this.toolStripButton_Reset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Reset.Name = "toolStripButton_Reset";
            this.toolStripButton_Reset.Size = new System.Drawing.Size(39, 33);
            this.toolStripButton_Reset.Text = "Reset";
            this.toolStripButton_Reset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_Reset.Click += new System.EventHandler(this.ResetPiHutangHeader);
            // 
            // FormPiHutangPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 616);
            this.Controls.Add(this.tJournalBindingNavigator);
            this.Controls.Add(this.splitContainer_Main);
            this.Name = "FormPiHutangPayment";
            this.Text = "FormPayment";
            this.Load += new System.EventHandler(this.FormPiHutangPayment_Load);
            this.Controls.SetChildIndex(this.splitContainer_Main, 0);
            this.Controls.SetChildIndex(this.tJournalBindingNavigator, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.splitContainer_Main.Panel1.ResumeLayout(false);
            this.splitContainer_Main.Panel2.ResumeLayout(false);
            this.splitContainer_Main.ResumeLayout(false);
            this.splitContainer_Header.Panel1.ResumeLayout(false);
            this.splitContainer_Header.Panel2.ResumeLayout(false);
            this.splitContainer_Header.ResumeLayout(false);
            this.groupBox_CompanyName.ResumeLayout(false);
            this.splitContainer_Head.Panel1.ResumeLayout(false);
            this.splitContainer_Head.Panel1.PerformLayout();
            this.splitContainer_Head.Panel2.ResumeLayout(false);
            this.splitContainer_Head.ResumeLayout(false);
            this.groupBox_Head.ResumeLayout(false);
            this.groupBox_Head.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.journalJumlahNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tJournalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSubAccountBindingSource)).EndInit();
            this.groupBox_PiHutangDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tPiHutangDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tJournalBindingNavigator)).EndInit();
            this.tJournalBindingNavigator.ResumeLayout(false);
            this.tJournalBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.SplitContainer splitContainer_Header;
        private System.Windows.Forms.GroupBox groupBox_CompanyName;
        private System.Windows.Forms.BindingNavigator tJournalBindingNavigator;
        private System.Windows.Forms.SplitContainer splitContainer_Head;
        private System.Windows.Forms.GroupBox groupBox_Head;
        private System.Windows.Forms.BindingSource mSubAccountBindingSource;
        private System.Windows.Forms.ToolStripButton simpanToolStripButton;
        private System.Windows.Forms.ToolStripButton CetakToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Reset;
        private System.Windows.Forms.Label journalJumlahSaidLabel;
        private System.Windows.Forms.Label journalJumlahLabel2;
        public System.Windows.Forms.Label companyNameLabel;
        private System.Windows.Forms.ComboBox piHutangPicComboBox;
        private System.Windows.Forms.NumericUpDown journalJumlahNumericUpDown;
        private System.Windows.Forms.BindingSource tJournalBindingSource;
        private System.Windows.Forms.TextBox journalDescTextBox;
        private System.Windows.Forms.TextBox voucherNoTextBox;
        private System.Windows.Forms.DateTimePicker journalDateDateTimePicker;
        private System.Windows.Forms.ComboBox subAccountIdComboBox;
        private System.Windows.Forms.GroupBox groupBox_PiHutangDetail;
        private System.Windows.Forms.DataGridView tPiHutangDataGridView;
        private System.Windows.Forms.Label label_Pay;
        private System.Windows.Forms.Label label_Retur;
        private System.Windows.Forms.Label label_Ammount;
        private System.Windows.Forms.Label label_Sisa;
        private System.Windows.Forms.Label label_Jumlah;
        private System.Windows.Forms.Label label_DueDate;
        private System.Windows.Forms.Label label_FacturNo;
        private System.Windows.Forms.Label piHutangPicLabel;
        private System.Windows.Forms.Label subAccountIdLabel;
    }
}