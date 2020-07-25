namespace Inventori.GrosirMitra.Forms
{
    partial class FormTransaction
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
            System.Windows.Forms.Label transactionDateLabel;
            System.Windows.Forms.Label transactionFacturLabel;
            System.Windows.Forms.Label transactionDiscLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.transactionByLabel = new System.Windows.Forms.Label();
            this.transactionReferenceIdLabel = new System.Windows.Forms.Label();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.splitContainer_Header = new System.Windows.Forms.SplitContainer();
            this.groupBox_CompanyName = new System.Windows.Forms.GroupBox();
            this.companyNameLabel = new System.Windows.Forms.Label();
            this.splitContainer_TransactionHeader = new System.Windows.Forms.SplitContainer();
            this.groupBox_FacturDate = new System.Windows.Forms.GroupBox();
            this.transactionPaymentComboBox = new System.Windows.Forms.ComboBox();
            this.tTransactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gudangIdToComboBox = new System.Windows.Forms.ComboBox();
            this.transactionPaymentLabel = new System.Windows.Forms.Label();
            this.gudangIdToLabel = new System.Windows.Forms.Label();
            this.gudangIdLabel = new System.Windows.Forms.Label();
            this.gudangIdComboBox = new System.Windows.Forms.ComboBox();
            this.garingLabel = new System.Windows.Forms.Label();
            this.transactionReferenceFacturTextBox = new System.Windows.Forms.TextBox();
            this.transactionIdLabel = new System.Windows.Forms.Label();
            this.hariLabel = new System.Windows.Forms.Label();
            this.piHutangCreditLongLabel = new System.Windows.Forms.Label();
            this.piHutangCreditLongNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.transactionReferenceIdTextBox = new System.Windows.Forms.TextBox();
            this.transactionFacturTextBox = new System.Windows.Forms.TextBox();
            this.transactionDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox_FacturDesc = new System.Windows.Forms.GroupBox();
            this.employeeNameTextBox = new System.Windows.Forms.TextBox();
            this.transactionByPhoneLabel = new System.Windows.Forms.Label();
            this.transactionByPhoneTextBox = new System.Windows.Forms.TextBox();
            this.transactionByAddressLabel = new System.Windows.Forms.Label();
            this.transactionByAddressTextBox = new System.Windows.Forms.TextBox();
            this.employeeIdLabel = new System.Windows.Forms.Label();
            this.employeeIdTextBox = new System.Windows.Forms.TextBox();
            this.transactionByTextBox_Name = new System.Windows.Forms.TextBox();
            this.transactionByTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer_TransactionDetail = new System.Windows.Forms.SplitContainer();
            this.groupBox_TransactionDetailList = new System.Windows.Forms.GroupBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionComboBox = new System.Windows.Forms.ComboBox();
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.jumlahLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.itemIdLabel = new System.Windows.Forms.Label();
            this.itemSatuanLabel = new System.Windows.Forms.Label();
            this.itemSatuanTextBox = new System.Windows.Forms.TextBox();
            this.button_Reset = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.jumlahNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.priceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.quantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.itemIdTextBox = new System.Windows.Forms.TextBox();
            this.button_Delete = new System.Windows.Forms.Button();
            this.totalSubTotalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label_TotalSubTotal = new System.Windows.Forms.Label();
            this.groupBox_GrandTotal = new System.Windows.Forms.GroupBox();
            this.transactionDiscNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.GrandTotalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tTransactionDetailDataGridView = new System.Windows.Forms.DataGridView();
            this.mCustomerGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.simpanToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CetakToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Reset = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ListTransaction = new System.Windows.Forms.ToolStripButton();
            this.Column_Item_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Item_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Sub_Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTransactionDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            transactionDateLabel = new System.Windows.Forms.Label();
            transactionFacturLabel = new System.Windows.Forms.Label();
            transactionDiscLabel = new System.Windows.Forms.Label();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.Panel2.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            this.splitContainer_Header.Panel1.SuspendLayout();
            this.splitContainer_Header.Panel2.SuspendLayout();
            this.splitContainer_Header.SuspendLayout();
            this.groupBox_CompanyName.SuspendLayout();
            this.splitContainer_TransactionHeader.Panel1.SuspendLayout();
            this.splitContainer_TransactionHeader.Panel2.SuspendLayout();
            this.splitContainer_TransactionHeader.SuspendLayout();
            this.groupBox_FacturDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piHutangCreditLongNumericUpDown)).BeginInit();
            this.groupBox_FacturDesc.SuspendLayout();
            this.splitContainer_TransactionDetail.Panel1.SuspendLayout();
            this.splitContainer_TransactionDetail.Panel2.SuspendLayout();
            this.splitContainer_TransactionDetail.SuspendLayout();
            this.groupBox_TransactionDetailList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jumlahNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalSubTotalNumericUpDown)).BeginInit();
            this.groupBox_GrandTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionDiscNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionDetailDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCustomerGroupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // transactionDateLabel
            // 
            transactionDateLabel.AutoSize = true;
            transactionDateLabel.Location = new System.Drawing.Point(3, 18);
            transactionDateLabel.Name = "transactionDateLabel";
            transactionDateLabel.Size = new System.Drawing.Size(52, 13);
            transactionDateLabel.TabIndex = 0;
            transactionDateLabel.Text = "Tanggal :";
            // 
            // transactionFacturLabel
            // 
            transactionFacturLabel.AutoSize = true;
            transactionFacturLabel.Location = new System.Drawing.Point(3, 39);
            transactionFacturLabel.Name = "transactionFacturLabel";
            transactionFacturLabel.Size = new System.Drawing.Size(77, 13);
            transactionFacturLabel.TabIndex = 2;
            transactionFacturLabel.Text = "Nomor Faktur :";
            // 
            // transactionDiscLabel
            // 
            transactionDiscLabel.AutoSize = true;
            transactionDiscLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            transactionDiscLabel.Location = new System.Drawing.Point(6, 21);
            transactionDiscLabel.Name = "transactionDiscLabel";
            transactionDiscLabel.Size = new System.Drawing.Size(92, 17);
            transactionDiscLabel.TabIndex = 22;
            transactionDiscLabel.Text = "Diskon (%):";
            // 
            // transactionByLabel
            // 
            this.transactionByLabel.AutoSize = true;
            this.transactionByLabel.Location = new System.Drawing.Point(13, 43);
            this.transactionByLabel.Name = "transactionByLabel";
            this.transactionByLabel.Size = new System.Drawing.Size(64, 13);
            this.transactionByLabel.TabIndex = 2;
            this.transactionByLabel.Text = "Pelanggan :";
            // 
            // transactionReferenceIdLabel
            // 
            this.transactionReferenceIdLabel.AutoSize = true;
            this.transactionReferenceIdLabel.Location = new System.Drawing.Point(5, 61);
            this.transactionReferenceIdLabel.Name = "transactionReferenceIdLabel";
            this.transactionReferenceIdLabel.Size = new System.Drawing.Size(69, 13);
            this.transactionReferenceIdLabel.TabIndex = 5;
            this.transactionReferenceIdLabel.Text = "Trans Ref Id:";
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
            this.splitContainer_Main.Panel2.Controls.Add(this.splitContainer_TransactionDetail);
            this.splitContainer_Main.Size = new System.Drawing.Size(992, 616);
            this.splitContainer_Main.SplitterDistance = 230;
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
            this.splitContainer_Header.Panel2.Controls.Add(this.splitContainer_TransactionHeader);
            this.splitContainer_Header.Size = new System.Drawing.Size(992, 230);
            this.splitContainer_Header.SplitterDistance = 63;
            this.splitContainer_Header.TabIndex = 0;
            // 
            // groupBox_CompanyName
            // 
            this.groupBox_CompanyName.Controls.Add(this.companyNameLabel);
            this.groupBox_CompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_CompanyName.Location = new System.Drawing.Point(0, 0);
            this.groupBox_CompanyName.Name = "groupBox_CompanyName";
            this.groupBox_CompanyName.Size = new System.Drawing.Size(992, 63);
            this.groupBox_CompanyName.TabIndex = 0;
            this.groupBox_CompanyName.TabStop = false;
            this.groupBox_CompanyName.Text = "Company Name";
            // 
            // companyNameLabel
            // 
            this.companyNameLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.companyNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyNameLabel.Location = new System.Drawing.Point(3, 35);
            this.companyNameLabel.Name = "companyNameLabel";
            this.companyNameLabel.Size = new System.Drawing.Size(986, 25);
            this.companyNameLabel.TabIndex = 1;
            this.companyNameLabel.Text = "Company Name";
            this.companyNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer_TransactionHeader
            // 
            this.splitContainer_TransactionHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_TransactionHeader.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_TransactionHeader.Name = "splitContainer_TransactionHeader";
            // 
            // splitContainer_TransactionHeader.Panel1
            // 
            this.splitContainer_TransactionHeader.Panel1.Controls.Add(this.groupBox_FacturDate);
            // 
            // splitContainer_TransactionHeader.Panel2
            // 
            this.splitContainer_TransactionHeader.Panel2.Controls.Add(this.groupBox_FacturDesc);
            this.splitContainer_TransactionHeader.Size = new System.Drawing.Size(992, 163);
            this.splitContainer_TransactionHeader.SplitterDistance = 513;
            this.splitContainer_TransactionHeader.TabIndex = 0;
            // 
            // groupBox_FacturDate
            // 
            this.groupBox_FacturDate.Controls.Add(this.transactionPaymentComboBox);
            this.groupBox_FacturDate.Controls.Add(this.gudangIdToComboBox);
            this.groupBox_FacturDate.Controls.Add(this.transactionPaymentLabel);
            this.groupBox_FacturDate.Controls.Add(this.gudangIdToLabel);
            this.groupBox_FacturDate.Controls.Add(this.gudangIdLabel);
            this.groupBox_FacturDate.Controls.Add(this.gudangIdComboBox);
            this.groupBox_FacturDate.Controls.Add(this.garingLabel);
            this.groupBox_FacturDate.Controls.Add(this.transactionReferenceFacturTextBox);
            this.groupBox_FacturDate.Controls.Add(this.transactionIdLabel);
            this.groupBox_FacturDate.Controls.Add(this.hariLabel);
            this.groupBox_FacturDate.Controls.Add(this.piHutangCreditLongLabel);
            this.groupBox_FacturDate.Controls.Add(this.piHutangCreditLongNumericUpDown);
            this.groupBox_FacturDate.Controls.Add(this.transactionReferenceIdLabel);
            this.groupBox_FacturDate.Controls.Add(this.transactionReferenceIdTextBox);
            this.groupBox_FacturDate.Controls.Add(this.transactionFacturTextBox);
            this.groupBox_FacturDate.Controls.Add(transactionFacturLabel);
            this.groupBox_FacturDate.Controls.Add(transactionDateLabel);
            this.groupBox_FacturDate.Controls.Add(this.transactionDateDateTimePicker);
            this.groupBox_FacturDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_FacturDate.Location = new System.Drawing.Point(0, 0);
            this.groupBox_FacturDate.Name = "groupBox_FacturDate";
            this.groupBox_FacturDate.Size = new System.Drawing.Size(513, 163);
            this.groupBox_FacturDate.TabIndex = 0;
            this.groupBox_FacturDate.TabStop = false;
            this.groupBox_FacturDate.Text = "groupBox_FacturDate";
            // 
            // transactionPaymentComboBox
            // 
            this.transactionPaymentComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tTransactionBindingSource, "TransactionPayment", true));
            this.transactionPaymentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transactionPaymentComboBox.FormattingEnabled = true;
            this.transactionPaymentComboBox.Location = new System.Drawing.Point(138, 81);
            this.transactionPaymentComboBox.Name = "transactionPaymentComboBox";
            this.transactionPaymentComboBox.Size = new System.Drawing.Size(121, 21);
            this.transactionPaymentComboBox.TabIndex = 18;
            this.transactionPaymentComboBox.SelectedIndexChanged += new System.EventHandler(this.transactionPaymentComboBox_SelectedIndexChanged);
            // 
            // tTransactionBindingSource
            // 
            this.tTransactionBindingSource.DataSource = typeof(Inventori.Data.TTransaction);
            // 
            // gudangIdToComboBox
            // 
            this.gudangIdToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gudangIdToComboBox.FormattingEnabled = true;
            this.gudangIdToComboBox.Location = new System.Drawing.Point(294, 128);
            this.gudangIdToComboBox.Name = "gudangIdToComboBox";
            this.gudangIdToComboBox.Size = new System.Drawing.Size(132, 21);
            this.gudangIdToComboBox.TabIndex = 14;
            this.gudangIdToComboBox.Visible = false;
            // 
            // transactionPaymentLabel
            // 
            this.transactionPaymentLabel.AutoSize = true;
            this.transactionPaymentLabel.Location = new System.Drawing.Point(6, 84);
            this.transactionPaymentLabel.Name = "transactionPaymentLabel";
            this.transactionPaymentLabel.Size = new System.Drawing.Size(65, 13);
            this.transactionPaymentLabel.TabIndex = 16;
            this.transactionPaymentLabel.Text = "Cara Bayar :";
            // 
            // gudangIdToLabel
            // 
            this.gudangIdToLabel.AutoSize = true;
            this.gudangIdToLabel.Location = new System.Drawing.Point(272, 131);
            this.gudangIdToLabel.Name = "gudangIdToLabel";
            this.gudangIdToLabel.Size = new System.Drawing.Size(19, 13);
            this.gudangIdToLabel.TabIndex = 13;
            this.gudangIdToLabel.Text = "ke";
            this.gudangIdToLabel.Visible = false;
            // 
            // gudangIdLabel
            // 
            this.gudangIdLabel.AutoSize = true;
            this.gudangIdLabel.Location = new System.Drawing.Point(5, 131);
            this.gudangIdLabel.Name = "gudangIdLabel";
            this.gudangIdLabel.Size = new System.Drawing.Size(32, 13);
            this.gudangIdLabel.TabIndex = 11;
            this.gudangIdLabel.Text = "Dari :";
            this.gudangIdLabel.Visible = false;
            // 
            // gudangIdComboBox
            // 
            this.gudangIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gudangIdComboBox.FormattingEnabled = true;
            this.gudangIdComboBox.Location = new System.Drawing.Point(138, 128);
            this.gudangIdComboBox.Name = "gudangIdComboBox";
            this.gudangIdComboBox.Size = new System.Drawing.Size(132, 21);
            this.gudangIdComboBox.TabIndex = 12;
            this.gudangIdComboBox.Visible = false;
            // 
            // garingLabel
            // 
            this.garingLabel.AutoSize = true;
            this.garingLabel.Location = new System.Drawing.Point(273, 61);
            this.garingLabel.Name = "garingLabel";
            this.garingLabel.Size = new System.Drawing.Size(12, 13);
            this.garingLabel.TabIndex = 14;
            this.garingLabel.Text = "/";
            // 
            // transactionReferenceFacturTextBox
            // 
            this.transactionReferenceFacturTextBox.Location = new System.Drawing.Point(294, 57);
            this.transactionReferenceFacturTextBox.Name = "transactionReferenceFacturTextBox";
            this.transactionReferenceFacturTextBox.Size = new System.Drawing.Size(146, 20);
            this.transactionReferenceFacturTextBox.TabIndex = 13;
            this.transactionReferenceFacturTextBox.Enter += new System.EventHandler(this.transactionReferenceFacturTextBox_Enter);
            this.transactionReferenceFacturTextBox.Leave += new System.EventHandler(this.transactionReferenceFacturTextBox_Leave);
            this.transactionReferenceFacturTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.transactionReferenceFacturTextBox_Validating);
            // 
            // transactionIdLabel
            // 
            this.transactionIdLabel.Location = new System.Drawing.Point(326, 16);
            this.transactionIdLabel.Name = "transactionIdLabel";
            this.transactionIdLabel.Size = new System.Drawing.Size(100, 23);
            this.transactionIdLabel.TabIndex = 11;
            this.transactionIdLabel.Text = "transactionIdLabel";
            this.transactionIdLabel.Visible = false;
            // 
            // hariLabel
            // 
            this.hariLabel.AutoSize = true;
            this.hariLabel.Location = new System.Drawing.Point(210, 109);
            this.hariLabel.Name = "hariLabel";
            this.hariLabel.Size = new System.Drawing.Size(24, 13);
            this.hariLabel.TabIndex = 9;
            this.hariLabel.Text = "hari";
            // 
            // piHutangCreditLongLabel
            // 
            this.piHutangCreditLongLabel.AutoSize = true;
            this.piHutangCreditLongLabel.Location = new System.Drawing.Point(5, 109);
            this.piHutangCreditLongLabel.Name = "piHutangCreditLongLabel";
            this.piHutangCreditLongLabel.Size = new System.Drawing.Size(69, 13);
            this.piHutangCreditLongLabel.TabIndex = 7;
            this.piHutangCreditLongLabel.Text = "Lama Kredit :";
            // 
            // piHutangCreditLongNumericUpDown
            // 
            this.piHutangCreditLongNumericUpDown.Location = new System.Drawing.Point(138, 105);
            this.piHutangCreditLongNumericUpDown.Name = "piHutangCreditLongNumericUpDown";
            this.piHutangCreditLongNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.piHutangCreditLongNumericUpDown.TabIndex = 8;
            // 
            // transactionReferenceIdTextBox
            // 
            this.transactionReferenceIdTextBox.Location = new System.Drawing.Point(138, 58);
            this.transactionReferenceIdTextBox.Name = "transactionReferenceIdTextBox";
            this.transactionReferenceIdTextBox.ReadOnly = true;
            this.transactionReferenceIdTextBox.Size = new System.Drawing.Size(132, 20);
            this.transactionReferenceIdTextBox.TabIndex = 6;
            // 
            // transactionFacturTextBox
            // 
            this.transactionFacturTextBox.Location = new System.Drawing.Point(138, 36);
            this.transactionFacturTextBox.Name = "transactionFacturTextBox";
            this.transactionFacturTextBox.Size = new System.Drawing.Size(152, 20);
            this.transactionFacturTextBox.TabIndex = 3;
            // 
            // transactionDateDateTimePicker
            // 
            this.transactionDateDateTimePicker.Location = new System.Drawing.Point(138, 14);
            this.transactionDateDateTimePicker.Name = "transactionDateDateTimePicker";
            this.transactionDateDateTimePicker.Size = new System.Drawing.Size(112, 20);
            this.transactionDateDateTimePicker.TabIndex = 1;
            // 
            // groupBox_FacturDesc
            // 
            this.groupBox_FacturDesc.Controls.Add(this.employeeNameTextBox);
            this.groupBox_FacturDesc.Controls.Add(this.transactionByPhoneLabel);
            this.groupBox_FacturDesc.Controls.Add(this.transactionByPhoneTextBox);
            this.groupBox_FacturDesc.Controls.Add(this.transactionByAddressLabel);
            this.groupBox_FacturDesc.Controls.Add(this.transactionByAddressTextBox);
            this.groupBox_FacturDesc.Controls.Add(this.employeeIdLabel);
            this.groupBox_FacturDesc.Controls.Add(this.employeeIdTextBox);
            this.groupBox_FacturDesc.Controls.Add(this.transactionByTextBox_Name);
            this.groupBox_FacturDesc.Controls.Add(this.transactionByLabel);
            this.groupBox_FacturDesc.Controls.Add(this.transactionByTextBox);
            this.groupBox_FacturDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_FacturDesc.Location = new System.Drawing.Point(0, 0);
            this.groupBox_FacturDesc.Name = "groupBox_FacturDesc";
            this.groupBox_FacturDesc.Size = new System.Drawing.Size(475, 163);
            this.groupBox_FacturDesc.TabIndex = 0;
            this.groupBox_FacturDesc.TabStop = false;
            this.groupBox_FacturDesc.Text = "groupBox_FacturDesc";
            // 
            // employeeNameTextBox
            // 
            this.employeeNameTextBox.Location = new System.Drawing.Point(236, 17);
            this.employeeNameTextBox.Name = "employeeNameTextBox";
            this.employeeNameTextBox.Size = new System.Drawing.Size(177, 20);
            this.employeeNameTextBox.TabIndex = 15;
            // 
            // transactionByPhoneLabel
            // 
            this.transactionByPhoneLabel.AutoSize = true;
            this.transactionByPhoneLabel.Location = new System.Drawing.Point(13, 89);
            this.transactionByPhoneLabel.Name = "transactionByPhoneLabel";
            this.transactionByPhoneLabel.Size = new System.Drawing.Size(77, 13);
            this.transactionByPhoneLabel.TabIndex = 12;
            this.transactionByPhoneLabel.Text = "No Telp / HP :";
            this.transactionByPhoneLabel.Visible = false;
            // 
            // transactionByPhoneTextBox
            // 
            this.transactionByPhoneTextBox.Location = new System.Drawing.Point(131, 86);
            this.transactionByPhoneTextBox.Name = "transactionByPhoneTextBox";
            this.transactionByPhoneTextBox.Size = new System.Drawing.Size(127, 20);
            this.transactionByPhoneTextBox.TabIndex = 13;
            this.transactionByPhoneTextBox.Visible = false;
            // 
            // transactionByAddressLabel
            // 
            this.transactionByAddressLabel.AutoSize = true;
            this.transactionByAddressLabel.Location = new System.Drawing.Point(13, 66);
            this.transactionByAddressLabel.Name = "transactionByAddressLabel";
            this.transactionByAddressLabel.Size = new System.Drawing.Size(45, 13);
            this.transactionByAddressLabel.TabIndex = 11;
            this.transactionByAddressLabel.Text = "Alamat :";
            this.transactionByAddressLabel.Visible = false;
            // 
            // transactionByAddressTextBox
            // 
            this.transactionByAddressTextBox.Location = new System.Drawing.Point(131, 63);
            this.transactionByAddressTextBox.Name = "transactionByAddressTextBox";
            this.transactionByAddressTextBox.Size = new System.Drawing.Size(194, 20);
            this.transactionByAddressTextBox.TabIndex = 12;
            this.transactionByAddressTextBox.Visible = false;
            // 
            // employeeIdLabel
            // 
            this.employeeIdLabel.AutoSize = true;
            this.employeeIdLabel.Location = new System.Drawing.Point(13, 20);
            this.employeeIdLabel.Name = "employeeIdLabel";
            this.employeeIdLabel.Size = new System.Drawing.Size(111, 13);
            this.employeeIdLabel.TabIndex = 9;
            this.employeeIdLabel.Text = "Salesman / Mekanik :";
            // 
            // employeeIdTextBox
            // 
            this.employeeIdTextBox.Location = new System.Drawing.Point(131, 17);
            this.employeeIdTextBox.Name = "employeeIdTextBox";
            this.employeeIdTextBox.Size = new System.Drawing.Size(101, 20);
            this.employeeIdTextBox.TabIndex = 10;
            this.employeeIdTextBox.Enter += new System.EventHandler(this.employeeIdTextBox_Enter);
            this.employeeIdTextBox.Leave += new System.EventHandler(this.employeeIdTextBox_Leave);
            this.employeeIdTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.employeeIdTextBox_Validating);
            // 
            // transactionByTextBox_Name
            // 
            this.transactionByTextBox_Name.Location = new System.Drawing.Point(236, 40);
            this.transactionByTextBox_Name.Name = "transactionByTextBox_Name";
            this.transactionByTextBox_Name.Size = new System.Drawing.Size(177, 20);
            this.transactionByTextBox_Name.TabIndex = 8;
            // 
            // transactionByTextBox
            // 
            this.transactionByTextBox.Location = new System.Drawing.Point(131, 40);
            this.transactionByTextBox.Name = "transactionByTextBox";
            this.transactionByTextBox.Size = new System.Drawing.Size(101, 20);
            this.transactionByTextBox.TabIndex = 3;
            this.transactionByTextBox.Enter += new System.EventHandler(this.transactionByTextBox_Enter);
            this.transactionByTextBox.Leave += new System.EventHandler(this.transactionByTextBox_Leave);
            this.transactionByTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.transactionByTextBox_Validating);
            // 
            // splitContainer_TransactionDetail
            // 
            this.splitContainer_TransactionDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_TransactionDetail.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_TransactionDetail.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_TransactionDetail.Name = "splitContainer_TransactionDetail";
            // 
            // splitContainer_TransactionDetail.Panel1
            // 
            this.splitContainer_TransactionDetail.Panel1.Controls.Add(this.groupBox_TransactionDetailList);
            // 
            // splitContainer_TransactionDetail.Panel2
            // 
            this.splitContainer_TransactionDetail.Panel2.AutoScroll = true;
            this.splitContainer_TransactionDetail.Panel2.Controls.Add(this.button_Delete);
            this.splitContainer_TransactionDetail.Panel2.Controls.Add(this.totalSubTotalNumericUpDown);
            this.splitContainer_TransactionDetail.Panel2.Controls.Add(this.label_TotalSubTotal);
            this.splitContainer_TransactionDetail.Panel2.Controls.Add(this.groupBox_GrandTotal);
            this.splitContainer_TransactionDetail.Panel2.Controls.Add(this.tTransactionDetailDataGridView);
            this.splitContainer_TransactionDetail.Size = new System.Drawing.Size(992, 382);
            this.splitContainer_TransactionDetail.SplitterDistance = 309;
            this.splitContainer_TransactionDetail.TabIndex = 0;
            // 
            // groupBox_TransactionDetailList
            // 
            this.groupBox_TransactionDetailList.Controls.Add(this.descriptionLabel);
            this.groupBox_TransactionDetailList.Controls.Add(this.descriptionComboBox);
            this.groupBox_TransactionDetailList.Controls.Add(this.itemNameLabel);
            this.groupBox_TransactionDetailList.Controls.Add(this.jumlahLabel);
            this.groupBox_TransactionDetailList.Controls.Add(this.priceLabel);
            this.groupBox_TransactionDetailList.Controls.Add(this.quantityLabel);
            this.groupBox_TransactionDetailList.Controls.Add(this.itemIdLabel);
            this.groupBox_TransactionDetailList.Controls.Add(this.itemSatuanLabel);
            this.groupBox_TransactionDetailList.Controls.Add(this.itemSatuanTextBox);
            this.groupBox_TransactionDetailList.Controls.Add(this.button_Reset);
            this.groupBox_TransactionDetailList.Controls.Add(this.button_Add);
            this.groupBox_TransactionDetailList.Controls.Add(this.itemNameTextBox);
            this.groupBox_TransactionDetailList.Controls.Add(this.jumlahNumericUpDown);
            this.groupBox_TransactionDetailList.Controls.Add(this.priceNumericUpDown);
            this.groupBox_TransactionDetailList.Controls.Add(this.quantityNumericUpDown);
            this.groupBox_TransactionDetailList.Controls.Add(this.itemIdTextBox);
            this.groupBox_TransactionDetailList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_TransactionDetailList.Location = new System.Drawing.Point(0, 0);
            this.groupBox_TransactionDetailList.Name = "groupBox_TransactionDetailList";
            this.groupBox_TransactionDetailList.Size = new System.Drawing.Size(309, 382);
            this.groupBox_TransactionDetailList.TabIndex = 0;
            this.groupBox_TransactionDetailList.TabStop = false;
            this.groupBox_TransactionDetailList.Text = "groupBox_TransactionDetailList";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(4, 177);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(68, 13);
            this.descriptionLabel.TabIndex = 43;
            this.descriptionLabel.Text = "Keterangan :";
            // 
            // descriptionComboBox
            // 
            this.descriptionComboBox.FormattingEnabled = true;
            this.descriptionComboBox.Location = new System.Drawing.Point(87, 174);
            this.descriptionComboBox.Name = "descriptionComboBox";
            this.descriptionComboBox.Size = new System.Drawing.Size(214, 21);
            this.descriptionComboBox.TabIndex = 44;
            // 
            // itemNameLabel
            // 
            this.itemNameLabel.AutoSize = true;
            this.itemNameLabel.Location = new System.Drawing.Point(6, 47);
            this.itemNameLabel.Name = "itemNameLabel";
            this.itemNameLabel.Size = new System.Drawing.Size(78, 13);
            this.itemNameLabel.TabIndex = 43;
            this.itemNameLabel.Text = "Nama Barang :";
            // 
            // jumlahLabel
            // 
            this.jumlahLabel.AutoSize = true;
            this.jumlahLabel.Location = new System.Drawing.Point(5, 150);
            this.jumlahLabel.Name = "jumlahLabel";
            this.jumlahLabel.Size = new System.Drawing.Size(59, 13);
            this.jumlahLabel.TabIndex = 43;
            this.jumlahLabel.Text = "Sub Total :";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(5, 124);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(42, 13);
            this.priceLabel.TabIndex = 43;
            this.priceLabel.Text = "Harga :";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(5, 98);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(57, 13);
            this.quantityLabel.TabIndex = 43;
            this.quantityLabel.Text = "Kuantitas :";
            // 
            // itemIdLabel
            // 
            this.itemIdLabel.AutoSize = true;
            this.itemIdLabel.Location = new System.Drawing.Point(6, 21);
            this.itemIdLabel.Name = "itemIdLabel";
            this.itemIdLabel.Size = new System.Drawing.Size(75, 13);
            this.itemIdLabel.TabIndex = 43;
            this.itemIdLabel.Text = "Kode Barang :";
            // 
            // itemSatuanLabel
            // 
            this.itemSatuanLabel.AutoSize = true;
            this.itemSatuanLabel.Location = new System.Drawing.Point(5, 73);
            this.itemSatuanLabel.Name = "itemSatuanLabel";
            this.itemSatuanLabel.Size = new System.Drawing.Size(47, 13);
            this.itemSatuanLabel.TabIndex = 42;
            this.itemSatuanLabel.Text = "Satuan :";
            // 
            // itemSatuanTextBox
            // 
            this.itemSatuanTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.itemSatuanTextBox.Location = new System.Drawing.Point(89, 70);
            this.itemSatuanTextBox.Name = "itemSatuanTextBox";
            this.itemSatuanTextBox.ReadOnly = true;
            this.itemSatuanTextBox.Size = new System.Drawing.Size(151, 20);
            this.itemSatuanTextBox.TabIndex = 43;
            // 
            // button_Reset
            // 
            this.button_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Reset.Image = global::Inventori.GrosirMitra.Forms.Properties.Resources.Refresh;
            this.button_Reset.Location = new System.Drawing.Point(72, 200);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(92, 41);
            this.button_Reset.TabIndex = 41;
            this.button_Reset.Text = "&Reset";
            this.button_Reset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // button_Add
            // 
            this.button_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Add.Image = global::Inventori.GrosirMitra.Forms.Properties.Resources.add;
            this.button_Add.Location = new System.Drawing.Point(172, 200);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(92, 41);
            this.button_Add.TabIndex = 39;
            this.button_Add.Text = "&Simpan";
            this.button_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.itemNameTextBox.Location = new System.Drawing.Point(89, 44);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.ReadOnly = true;
            this.itemNameTextBox.Size = new System.Drawing.Size(214, 20);
            this.itemNameTextBox.TabIndex = 15;
            // 
            // jumlahNumericUpDown
            // 
            this.jumlahNumericUpDown.Location = new System.Drawing.Point(89, 148);
            this.jumlahNumericUpDown.Name = "jumlahNumericUpDown";
            this.jumlahNumericUpDown.Size = new System.Drawing.Size(101, 20);
            this.jumlahNumericUpDown.TabIndex = 12;
            this.jumlahNumericUpDown.ValueChanged += new System.EventHandler(this.CalculateJumlahAndTotal);
            // 
            // priceNumericUpDown
            // 
            this.priceNumericUpDown.Location = new System.Drawing.Point(89, 122);
            this.priceNumericUpDown.Name = "priceNumericUpDown";
            this.priceNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.priceNumericUpDown.TabIndex = 11;
            this.priceNumericUpDown.ValueChanged += new System.EventHandler(this.CalculateJumlahAndTotal);
            // 
            // quantityNumericUpDown
            // 
            this.quantityNumericUpDown.Location = new System.Drawing.Point(89, 96);
            this.quantityNumericUpDown.Name = "quantityNumericUpDown";
            this.quantityNumericUpDown.Size = new System.Drawing.Size(73, 20);
            this.quantityNumericUpDown.TabIndex = 10;
            this.quantityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityNumericUpDown.ValueChanged += new System.EventHandler(this.CalculateJumlahAndTotal);
            // 
            // itemIdTextBox
            // 
            this.itemIdTextBox.Location = new System.Drawing.Point(89, 18);
            this.itemIdTextBox.Name = "itemIdTextBox";
            this.itemIdTextBox.Size = new System.Drawing.Size(185, 20);
            this.itemIdTextBox.TabIndex = 9;
            this.itemIdTextBox.Enter += new System.EventHandler(this.itemIdTextBox_Enter);
            this.itemIdTextBox.Leave += new System.EventHandler(this.itemIdTextBox_Leave);
            this.itemIdTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.itemIdTextBox_Validating);
            // 
            // button_Delete
            // 
            this.button_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Delete.Image = global::Inventori.GrosirMitra.Forms.Properties.Resources.delete;
            this.button_Delete.Location = new System.Drawing.Point(632, 23);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(24, 119);
            this.button_Delete.TabIndex = 40;
            this.button_Delete.Text = "&Hapus";
            this.button_Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // totalSubTotalNumericUpDown
            // 
            this.totalSubTotalNumericUpDown.Enabled = false;
            this.totalSubTotalNumericUpDown.Location = new System.Drawing.Point(486, 245);
            this.totalSubTotalNumericUpDown.Name = "totalSubTotalNumericUpDown";
            this.totalSubTotalNumericUpDown.Size = new System.Drawing.Size(136, 20);
            this.totalSubTotalNumericUpDown.TabIndex = 20;
            this.totalSubTotalNumericUpDown.ValueChanged += new System.EventHandler(this.CalculateGrandTotal);
            // 
            // label_TotalSubTotal
            // 
            this.label_TotalSubTotal.AutoSize = true;
            this.label_TotalSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TotalSubTotal.Location = new System.Drawing.Point(401, 247);
            this.label_TotalSubTotal.Name = "label_TotalSubTotal";
            this.label_TotalSubTotal.Size = new System.Drawing.Size(70, 13);
            this.label_TotalSubTotal.TabIndex = 21;
            this.label_TotalSubTotal.Text = "Sub Total :";
            this.label_TotalSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox_GrandTotal
            // 
            this.groupBox_GrandTotal.Controls.Add(transactionDiscLabel);
            this.groupBox_GrandTotal.Controls.Add(this.transactionDiscNumericUpDown);
            this.groupBox_GrandTotal.Controls.Add(this.label9);
            this.groupBox_GrandTotal.Controls.Add(this.GrandTotalNumericUpDown);
            this.groupBox_GrandTotal.Location = new System.Drawing.Point(360, 262);
            this.groupBox_GrandTotal.Name = "groupBox_GrandTotal";
            this.groupBox_GrandTotal.Size = new System.Drawing.Size(262, 78);
            this.groupBox_GrandTotal.TabIndex = 22;
            this.groupBox_GrandTotal.TabStop = false;
            this.groupBox_GrandTotal.Text = "groupBox_GrandTotal";
            // 
            // transactionDiscNumericUpDown
            // 
            this.transactionDiscNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionDiscNumericUpDown.Location = new System.Drawing.Point(185, 19);
            this.transactionDiscNumericUpDown.Name = "transactionDiscNumericUpDown";
            this.transactionDiscNumericUpDown.Size = new System.Drawing.Size(68, 23);
            this.transactionDiscNumericUpDown.TabIndex = 23;
            this.transactionDiscNumericUpDown.ValueChanged += new System.EventHandler(this.CalculateGrandTotal);
            this.transactionDiscNumericUpDown.Leave += new System.EventHandler(this.transactionDiscNumericUpDown_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Grand Total :";
            // 
            // GrandTotalNumericUpDown
            // 
            this.GrandTotalNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrandTotalNumericUpDown.Location = new System.Drawing.Point(117, 46);
            this.GrandTotalNumericUpDown.Name = "GrandTotalNumericUpDown";
            this.GrandTotalNumericUpDown.Size = new System.Drawing.Size(136, 23);
            this.GrandTotalNumericUpDown.TabIndex = 21;
            // 
            // tTransactionDetailDataGridView
            // 
            this.tTransactionDetailDataGridView.AllowUserToAddRows = false;
            this.tTransactionDetailDataGridView.AllowUserToDeleteRows = false;
            this.tTransactionDetailDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tTransactionDetailDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.tTransactionDetailDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tTransactionDetailDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tTransactionDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tTransactionDetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Item_Id,
            this.Column_Item_Name,
            this.Column_Quantity,
            this.Column_Price,
            this.Column_Sub_Total,
            this.Column_Desc,
            this.ColumnTransactionDetailId});
            this.tTransactionDetailDataGridView.Location = new System.Drawing.Point(13, 3);
            this.tTransactionDetailDataGridView.MultiSelect = false;
            this.tTransactionDetailDataGridView.Name = "tTransactionDetailDataGridView";
            this.tTransactionDetailDataGridView.ReadOnly = true;
            this.tTransactionDetailDataGridView.RowHeadersVisible = false;
            this.tTransactionDetailDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tTransactionDetailDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tTransactionDetailDataGridView.Size = new System.Drawing.Size(609, 238);
            this.tTransactionDetailDataGridView.TabIndex = 15;
            this.tTransactionDetailDataGridView.TabStop = false;
            this.tTransactionDetailDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.tTransactionDetailDataGridView_RowsAdded);
            this.tTransactionDetailDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.tTransactionDetailDataGridView_RowsRemoved);
            // 
            // mCustomerGroupBindingSource
            // 
            this.mCustomerGroupBindingSource.DataSource = typeof(Inventori.Data.MCustomerGroup);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpanToolStripButton,
            this.CetakToolStripButton,
            this.toolStripSeparator1,
            this.toolStripButton_Reset,
            this.toolStripButton_ListTransaction});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(992, 36);
            this.bindingNavigator1.TabIndex = 3;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // simpanToolStripButton
            // 
            this.simpanToolStripButton.Image = global::Inventori.GrosirMitra.Forms.Properties.Resources.save;
            this.simpanToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.simpanToolStripButton.Name = "simpanToolStripButton";
            this.simpanToolStripButton.Size = new System.Drawing.Size(45, 33);
            this.simpanToolStripButton.Text = "Simpan";
            this.simpanToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.simpanToolStripButton.Click += new System.EventHandler(this.SaveTransactionInterface);
            // 
            // CetakToolStripButton
            // 
            this.CetakToolStripButton.Image = global::Inventori.GrosirMitra.Forms.Properties.Resources.printer;
            this.CetakToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CetakToolStripButton.Name = "CetakToolStripButton";
            this.CetakToolStripButton.Size = new System.Drawing.Size(73, 33);
            this.CetakToolStripButton.Text = "Cetak Faktur";
            this.CetakToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CetakToolStripButton.Visible = false;
            this.CetakToolStripButton.Click += new System.EventHandler(this.CetakToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // toolStripButton_Reset
            // 
            this.toolStripButton_Reset.Image = global::Inventori.GrosirMitra.Forms.Properties.Resources.Refresh;
            this.toolStripButton_Reset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Reset.Name = "toolStripButton_Reset";
            this.toolStripButton_Reset.Size = new System.Drawing.Size(39, 33);
            this.toolStripButton_Reset.Text = "Reset";
            this.toolStripButton_Reset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_Reset.Click += new System.EventHandler(this.ResetTransaction);
            // 
            // toolStripButton_ListTransaction
            // 
            this.toolStripButton_ListTransaction.Image = global::Inventori.GrosirMitra.Forms.Properties.Resources.list;
            this.toolStripButton_ListTransaction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ListTransaction.Name = "toolStripButton_ListTransaction";
            this.toolStripButton_ListTransaction.Size = new System.Drawing.Size(90, 33);
            this.toolStripButton_ListTransaction.Text = "Daftar Transaksi";
            this.toolStripButton_ListTransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_ListTransaction.Click += new System.EventHandler(this.toolStripButton_ListTransaction_Click);
            // 
            // Column_Item_Id
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Item_Id.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column_Item_Id.HeaderText = "Kode Barang";
            this.Column_Item_Id.Name = "Column_Item_Id";
            this.Column_Item_Id.ReadOnly = true;
            this.Column_Item_Id.Width = 150;
            // 
            // Column_Item_Name
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Item_Name.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column_Item_Name.HeaderText = "Nama Barang";
            this.Column_Item_Name.Name = "Column_Item_Name";
            this.Column_Item_Name.ReadOnly = true;
            this.Column_Item_Name.Width = 200;
            // 
            // Column_Quantity
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Quantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column_Quantity.HeaderText = "Kuantitas";
            this.Column_Quantity.Name = "Column_Quantity";
            this.Column_Quantity.ReadOnly = true;
            this.Column_Quantity.Width = 75;
            // 
            // Column_Price
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Price.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column_Price.HeaderText = "Harga";
            this.Column_Price.Name = "Column_Price";
            this.Column_Price.ReadOnly = true;
            this.Column_Price.Width = 75;
            // 
            // Column_Sub_Total
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N";
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Sub_Total.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column_Sub_Total.HeaderText = "Sub Total";
            this.Column_Sub_Total.Name = "Column_Sub_Total";
            this.Column_Sub_Total.ReadOnly = true;
            // 
            // Column_Desc
            // 
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Desc.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column_Desc.HeaderText = "Keterangan";
            this.Column_Desc.Name = "Column_Desc";
            this.Column_Desc.ReadOnly = true;
            this.Column_Desc.Visible = false;
            this.Column_Desc.Width = 175;
            // 
            // ColumnTransactionDetailId
            // 
            this.ColumnTransactionDetailId.HeaderText = "TransactionDetailId";
            this.ColumnTransactionDetailId.Name = "ColumnTransactionDetailId";
            this.ColumnTransactionDetailId.ReadOnly = true;
            this.ColumnTransactionDetailId.Visible = false;
            // 
            // FormTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(992, 616);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.splitContainer_Main);
            this.Name = "FormTransaction";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "Transaksi ";
            this.Text = "Transaksi ";
            this.Load += new System.EventHandler(this.FormTransaction_Load);
            this.Controls.SetChildIndex(this.splitContainer_Main, 0);
            this.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.splitContainer_Main.Panel1.ResumeLayout(false);
            this.splitContainer_Main.Panel2.ResumeLayout(false);
            this.splitContainer_Main.ResumeLayout(false);
            this.splitContainer_Header.Panel1.ResumeLayout(false);
            this.splitContainer_Header.Panel2.ResumeLayout(false);
            this.splitContainer_Header.ResumeLayout(false);
            this.groupBox_CompanyName.ResumeLayout(false);
            this.splitContainer_TransactionHeader.Panel1.ResumeLayout(false);
            this.splitContainer_TransactionHeader.Panel2.ResumeLayout(false);
            this.splitContainer_TransactionHeader.ResumeLayout(false);
            this.groupBox_FacturDate.ResumeLayout(false);
            this.groupBox_FacturDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piHutangCreditLongNumericUpDown)).EndInit();
            this.groupBox_FacturDesc.ResumeLayout(false);
            this.groupBox_FacturDesc.PerformLayout();
            this.splitContainer_TransactionDetail.Panel1.ResumeLayout(false);
            this.splitContainer_TransactionDetail.Panel2.ResumeLayout(false);
            this.splitContainer_TransactionDetail.Panel2.PerformLayout();
            this.splitContainer_TransactionDetail.ResumeLayout(false);
            this.groupBox_TransactionDetailList.ResumeLayout(false);
            this.groupBox_TransactionDetailList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jumlahNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalSubTotalNumericUpDown)).EndInit();
            this.groupBox_GrandTotal.ResumeLayout(false);
            this.groupBox_GrandTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionDiscNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionDetailDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCustomerGroupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.SplitContainer splitContainer_Header;
        private System.Windows.Forms.GroupBox groupBox_CompanyName;
        private System.Windows.Forms.SplitContainer splitContainer_TransactionHeader;
        private System.Windows.Forms.GroupBox groupBox_FacturDate;
        private System.Windows.Forms.TextBox transactionFacturTextBox;
        private System.Windows.Forms.DateTimePicker transactionDateDateTimePicker;
        private System.Windows.Forms.GroupBox groupBox_FacturDesc;
        private System.Windows.Forms.TextBox transactionByTextBox;
        private System.Windows.Forms.TextBox transactionReferenceIdTextBox;
        private System.Windows.Forms.SplitContainer splitContainer_TransactionDetail;
        private System.Windows.Forms.GroupBox groupBox_TransactionDetailList;
        private System.Windows.Forms.TextBox itemIdTextBox;
        private System.Windows.Forms.NumericUpDown quantityNumericUpDown;
        private System.Windows.Forms.NumericUpDown priceNumericUpDown;
        private System.Windows.Forms.NumericUpDown jumlahNumericUpDown;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.DataGridView tTransactionDetailDataGridView;
        private System.Windows.Forms.Label label_TotalSubTotal;
        private System.Windows.Forms.GroupBox groupBox_GrandTotal;
        private System.Windows.Forms.NumericUpDown GrandTotalNumericUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripButton CetakToolStripButton;
        public System.Windows.Forms.Label companyNameLabel;
        private System.Windows.Forms.ToolStripButton toolStripButton_Reset;
        private System.Windows.Forms.Label transactionReferenceIdLabel;
        private System.Windows.Forms.TextBox transactionByTextBox_Name;
        private System.Windows.Forms.NumericUpDown piHutangCreditLongNumericUpDown;
        private System.Windows.Forms.Label piHutangCreditLongLabel;
        private System.Windows.Forms.Label hariLabel;
        private System.Windows.Forms.Label transactionByLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label transactionIdLabel;
        private System.Windows.Forms.ToolStripButton simpanToolStripButton;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.NumericUpDown totalSubTotalNumericUpDown;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.TextBox employeeIdTextBox;
        private System.Windows.Forms.Label employeeIdLabel;
        private System.Windows.Forms.TextBox itemSatuanTextBox;
        private System.Windows.Forms.Label itemSatuanLabel;
        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.Label jumlahLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label itemIdLabel;
        private System.Windows.Forms.Label garingLabel;
        private System.Windows.Forms.TextBox transactionReferenceFacturTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.ComboBox descriptionComboBox;
        private System.Windows.Forms.Label transactionPaymentLabel;
        private System.Windows.Forms.ComboBox gudangIdToComboBox;
        private System.Windows.Forms.Label gudangIdToLabel;
        private System.Windows.Forms.Label gudangIdLabel;
        private System.Windows.Forms.ComboBox gudangIdComboBox;
        private System.Windows.Forms.BindingSource mCustomerGroupBindingSource;
        private System.Windows.Forms.NumericUpDown transactionDiscNumericUpDown;
        private System.Windows.Forms.TextBox transactionByPhoneTextBox;
        private System.Windows.Forms.TextBox transactionByAddressTextBox;
        private System.Windows.Forms.Label transactionByPhoneLabel;
        private System.Windows.Forms.Label transactionByAddressLabel;
        private System.Windows.Forms.TextBox employeeNameTextBox;
        private System.Windows.Forms.ToolStripButton toolStripButton_ListTransaction;
        private System.Windows.Forms.ComboBox transactionPaymentComboBox;
        private System.Windows.Forms.BindingSource tTransactionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Item_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Item_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Sub_Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTransactionDetailId;
    }
}