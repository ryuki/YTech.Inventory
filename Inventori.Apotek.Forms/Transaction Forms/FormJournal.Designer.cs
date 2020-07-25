namespace Inventori.Apotek.Forms
{
    partial class FormJournal
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
            System.Windows.Forms.Label journalStatusLabel;
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.splitContainer_Header = new System.Windows.Forms.SplitContainer();
            this.groupBox_CompanyName = new System.Windows.Forms.GroupBox();
            this.companyNameLabel = new System.Windows.Forms.Label();
            this.splitContainer_Head = new System.Windows.Forms.SplitContainer();
            this.groupBox_Head = new System.Windows.Forms.GroupBox();
            this.journalJumlahLabel2 = new System.Windows.Forms.Label();
            this.kasJumlahSaidLabel = new System.Windows.Forms.Label();
            this.voucherNoLabel = new System.Windows.Forms.Label();
            this.voucherNoTextBox = new System.Windows.Forms.TextBox();
            this.journalJumlahLabel = new System.Windows.Forms.Label();
            this.balanceJumlahNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.journalDateLabel = new System.Windows.Forms.Label();
            this.journalDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.splitContainer_Detail = new System.Windows.Forms.SplitContainer();
            this.groupBox_Input = new System.Windows.Forms.GroupBox();
            this.journalStatusKreditRadioButton = new System.Windows.Forms.RadioButton();
            this.tJournalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.journalStatusDebetRadioButton = new System.Windows.Forms.RadioButton();
            this.button_Reset = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.journalDescLabel1 = new System.Windows.Forms.Label();
            this.journalDescTextBox = new System.Windows.Forms.TextBox();
            this.journalJumlahLabel1 = new System.Windows.Forms.Label();
            this.journalJumlahNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.subAccountNameLabel = new System.Windows.Forms.Label();
            this.subAccountNameTextBox = new System.Windows.Forms.TextBox();
            this.subAccountIdLabel1 = new System.Windows.Forms.Label();
            this.subAccountIdTextBox = new System.Windows.Forms.TextBox();
            this.groupBox_List = new System.Windows.Forms.GroupBox();
            this.label_Status = new System.Windows.Forms.Label();
            this.button_Delete = new System.Windows.Forms.Button();
            this.label_AccId = new System.Windows.Forms.Label();
            this.label_AccName = new System.Windows.Forms.Label();
            this.label_JournalDesc = new System.Windows.Forms.Label();
            this.label_JournalJumlah = new System.Windows.Forms.Label();
            this.tJournalDataGridView = new System.Windows.Forms.DataGridView();
            this.mSubAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tJournalBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.simpanToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CetakToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Reset = new System.Windows.Forms.ToolStripButton();
            journalStatusLabel = new System.Windows.Forms.Label();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.Panel2.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            this.splitContainer_Header.Panel1.SuspendLayout();
            this.splitContainer_Header.Panel2.SuspendLayout();
            this.splitContainer_Header.SuspendLayout();
            this.groupBox_CompanyName.SuspendLayout();
            this.splitContainer_Head.Panel2.SuspendLayout();
            this.splitContainer_Head.SuspendLayout();
            this.groupBox_Head.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balanceJumlahNumericUpDown)).BeginInit();
            this.splitContainer_Detail.Panel1.SuspendLayout();
            this.splitContainer_Detail.Panel2.SuspendLayout();
            this.splitContainer_Detail.SuspendLayout();
            this.groupBox_Input.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tJournalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalJumlahNumericUpDown)).BeginInit();
            this.groupBox_List.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tJournalDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSubAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tJournalBindingNavigator)).BeginInit();
            this.tJournalBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Location = new System.Drawing.Point(358, 117);
            // 
            // journalStatusLabel
            // 
            journalStatusLabel.AutoSize = true;
            journalStatusLabel.Location = new System.Drawing.Point(8, 70);
            journalStatusLabel.Name = "journalStatusLabel";
            journalStatusLabel.Size = new System.Drawing.Size(40, 13);
            journalStatusLabel.TabIndex = 43;
            journalStatusLabel.Text = "Posisi :";
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
            this.splitContainer_Main.Panel2.Controls.Add(this.splitContainer_Detail);
            this.splitContainer_Main.Size = new System.Drawing.Size(992, 616);
            this.splitContainer_Main.SplitterDistance = 198;
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
            this.splitContainer_Header.Size = new System.Drawing.Size(992, 198);
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
            this.splitContainer_Head.Panel1Collapsed = true;
            // 
            // splitContainer_Head.Panel2
            // 
            this.splitContainer_Head.Panel2.Controls.Add(this.groupBox_Head);
            this.splitContainer_Head.Size = new System.Drawing.Size(992, 126);
            this.splitContainer_Head.SplitterDistance = 33;
            this.splitContainer_Head.TabIndex = 0;
            // 
            // groupBox_Head
            // 
            this.groupBox_Head.Controls.Add(this.journalJumlahLabel2);
            this.groupBox_Head.Controls.Add(this.kasJumlahSaidLabel);
            this.groupBox_Head.Controls.Add(this.voucherNoLabel);
            this.groupBox_Head.Controls.Add(this.voucherNoTextBox);
            this.groupBox_Head.Controls.Add(this.journalJumlahLabel);
            this.groupBox_Head.Controls.Add(this.balanceJumlahNumericUpDown);
            this.groupBox_Head.Controls.Add(this.journalDateLabel);
            this.groupBox_Head.Controls.Add(this.journalDateDateTimePicker);
            this.groupBox_Head.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Head.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Head.Name = "groupBox_Head";
            this.groupBox_Head.Size = new System.Drawing.Size(992, 126);
            this.groupBox_Head.TabIndex = 0;
            this.groupBox_Head.TabStop = false;
            this.groupBox_Head.Text = "groupBox_Head";
            // 
            // journalJumlahLabel2
            // 
            this.journalJumlahLabel2.AutoSize = true;
            this.journalJumlahLabel2.Location = new System.Drawing.Point(8, 91);
            this.journalJumlahLabel2.Name = "journalJumlahLabel2";
            this.journalJumlahLabel2.Size = new System.Drawing.Size(57, 13);
            this.journalJumlahLabel2.TabIndex = 8;
            this.journalJumlahLabel2.Text = "Terbilang :";
            this.journalJumlahLabel2.Visible = false;
            // 
            // kasJumlahSaidLabel
            // 
            this.kasJumlahSaidLabel.AutoSize = true;
            this.kasJumlahSaidLabel.Location = new System.Drawing.Point(101, 91);
            this.kasJumlahSaidLabel.Name = "kasJumlahSaidLabel";
            this.kasJumlahSaidLabel.Size = new System.Drawing.Size(60, 13);
            this.kasJumlahSaidLabel.TabIndex = 9;
            this.kasJumlahSaidLabel.Text = "Nol Rupiah";
            this.kasJumlahSaidLabel.Visible = false;
            // 
            // voucherNoLabel
            // 
            this.voucherNoLabel.AutoSize = true;
            this.voucherNoLabel.Location = new System.Drawing.Point(8, 45);
            this.voucherNoLabel.Name = "voucherNoLabel";
            this.voucherNoLabel.Size = new System.Drawing.Size(70, 13);
            this.voucherNoLabel.TabIndex = 7;
            this.voucherNoLabel.Text = "No Voucher :";
            // 
            // voucherNoTextBox
            // 
            this.voucherNoTextBox.Location = new System.Drawing.Point(100, 42);
            this.voucherNoTextBox.Name = "voucherNoTextBox";
            this.voucherNoTextBox.Size = new System.Drawing.Size(160, 20);
            this.voucherNoTextBox.TabIndex = 8;
            // 
            // journalJumlahLabel
            // 
            this.journalJumlahLabel.AutoSize = true;
            this.journalJumlahLabel.Location = new System.Drawing.Point(8, 67);
            this.journalJumlahLabel.Name = "journalJumlahLabel";
            this.journalJumlahLabel.Size = new System.Drawing.Size(46, 13);
            this.journalJumlahLabel.TabIndex = 4;
            this.journalJumlahLabel.Text = "Jumlah :";
            // 
            // balanceJumlahNumericUpDown
            // 
            this.balanceJumlahNumericUpDown.Location = new System.Drawing.Point(100, 65);
            this.balanceJumlahNumericUpDown.Name = "balanceJumlahNumericUpDown";
            this.balanceJumlahNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.balanceJumlahNumericUpDown.TabIndex = 5;
            this.balanceJumlahNumericUpDown.ValueChanged += new System.EventHandler(this.balanceJumlahNumericUpDown_ValueChanged);
            // 
            // journalDateLabel
            // 
            this.journalDateLabel.AutoSize = true;
            this.journalDateLabel.Location = new System.Drawing.Point(8, 23);
            this.journalDateLabel.Name = "journalDateLabel";
            this.journalDateLabel.Size = new System.Drawing.Size(52, 13);
            this.journalDateLabel.TabIndex = 0;
            this.journalDateLabel.Text = "Tanggal :";
            // 
            // journalDateDateTimePicker
            // 
            this.journalDateDateTimePicker.Location = new System.Drawing.Point(100, 19);
            this.journalDateDateTimePicker.Name = "journalDateDateTimePicker";
            this.journalDateDateTimePicker.Size = new System.Drawing.Size(114, 20);
            this.journalDateDateTimePicker.TabIndex = 1;
            // 
            // splitContainer_Detail
            // 
            this.splitContainer_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Detail.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_Detail.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Detail.Name = "splitContainer_Detail";
            // 
            // splitContainer_Detail.Panel1
            // 
            this.splitContainer_Detail.Panel1.Controls.Add(this.groupBox_Input);
            // 
            // splitContainer_Detail.Panel2
            // 
            this.splitContainer_Detail.Panel2.AutoScroll = true;
            this.splitContainer_Detail.Panel2.Controls.Add(this.groupBox_List);
            this.splitContainer_Detail.Size = new System.Drawing.Size(992, 414);
            this.splitContainer_Detail.SplitterDistance = 289;
            this.splitContainer_Detail.TabIndex = 0;
            // 
            // groupBox_Input
            // 
            this.groupBox_Input.Controls.Add(this.journalStatusKreditRadioButton);
            this.groupBox_Input.Controls.Add(journalStatusLabel);
            this.groupBox_Input.Controls.Add(this.journalStatusDebetRadioButton);
            this.groupBox_Input.Controls.Add(this.button_Reset);
            this.groupBox_Input.Controls.Add(this.button_Add);
            this.groupBox_Input.Controls.Add(this.journalDescLabel1);
            this.groupBox_Input.Controls.Add(this.journalDescTextBox);
            this.groupBox_Input.Controls.Add(this.journalJumlahLabel1);
            this.groupBox_Input.Controls.Add(this.journalJumlahNumericUpDown);
            this.groupBox_Input.Controls.Add(this.subAccountNameLabel);
            this.groupBox_Input.Controls.Add(this.subAccountNameTextBox);
            this.groupBox_Input.Controls.Add(this.subAccountIdLabel1);
            this.groupBox_Input.Controls.Add(this.subAccountIdTextBox);
            this.groupBox_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Input.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Input.Name = "groupBox_Input";
            this.groupBox_Input.Size = new System.Drawing.Size(289, 414);
            this.groupBox_Input.TabIndex = 0;
            this.groupBox_Input.TabStop = false;
            this.groupBox_Input.Text = "groupBox_Input";
            // 
            // journalStatusKreditRadioButton
            // 
            this.journalStatusKreditRadioButton.AutoSize = true;
            this.journalStatusKreditRadioButton.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tJournalBindingSource, "JournalStatus", true));
            this.journalStatusKreditRadioButton.Location = new System.Drawing.Point(145, 68);
            this.journalStatusKreditRadioButton.Name = "journalStatusKreditRadioButton";
            this.journalStatusKreditRadioButton.Size = new System.Drawing.Size(52, 17);
            this.journalStatusKreditRadioButton.TabIndex = 45;
            this.journalStatusKreditRadioButton.Text = "Kredit";
            // 
            // tJournalBindingSource
            // 
            this.tJournalBindingSource.DataSource = typeof(Inventori.Data.TJournal);
            // 
            // journalStatusDebetRadioButton
            // 
            this.journalStatusDebetRadioButton.AutoSize = true;
            this.journalStatusDebetRadioButton.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tJournalBindingSource, "JournalStatus", true));
            this.journalStatusDebetRadioButton.Location = new System.Drawing.Point(84, 68);
            this.journalStatusDebetRadioButton.Name = "journalStatusDebetRadioButton";
            this.journalStatusDebetRadioButton.Size = new System.Drawing.Size(54, 17);
            this.journalStatusDebetRadioButton.TabIndex = 44;
            this.journalStatusDebetRadioButton.Text = "Debet";
            // 
            // button_Reset
            // 
            this.button_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Reset.Image = global::Inventori.Apotek.Forms.Properties.Resources.Refresh;
            this.button_Reset.Location = new System.Drawing.Point(48, 200);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(92, 41);
            this.button_Reset.TabIndex = 43;
            this.button_Reset.Text = "&Reset";
            this.button_Reset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.ResetJournalDetail);
            // 
            // button_Add
            // 
            this.button_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Add.Image = global::Inventori.Apotek.Forms.Properties.Resources.add;
            this.button_Add.Location = new System.Drawing.Point(148, 200);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(92, 41);
            this.button_Add.TabIndex = 42;
            this.button_Add.Text = "&Simpan";
            this.button_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // journalDescLabel1
            // 
            this.journalDescLabel1.AutoSize = true;
            this.journalDescLabel1.Location = new System.Drawing.Point(8, 114);
            this.journalDescLabel1.Name = "journalDescLabel1";
            this.journalDescLabel1.Size = new System.Drawing.Size(68, 13);
            this.journalDescLabel1.TabIndex = 6;
            this.journalDescLabel1.Text = "Keterangan :";
            // 
            // journalDescTextBox
            // 
            this.journalDescTextBox.Location = new System.Drawing.Point(84, 111);
            this.journalDescTextBox.Multiline = true;
            this.journalDescTextBox.Name = "journalDescTextBox";
            this.journalDescTextBox.Size = new System.Drawing.Size(199, 74);
            this.journalDescTextBox.TabIndex = 7;
            // 
            // journalJumlahLabel1
            // 
            this.journalJumlahLabel1.AutoSize = true;
            this.journalJumlahLabel1.Location = new System.Drawing.Point(8, 88);
            this.journalJumlahLabel1.Name = "journalJumlahLabel1";
            this.journalJumlahLabel1.Size = new System.Drawing.Size(46, 13);
            this.journalJumlahLabel1.TabIndex = 4;
            this.journalJumlahLabel1.Text = "Jumlah :";
            // 
            // journalJumlahNumericUpDown
            // 
            this.journalJumlahNumericUpDown.Location = new System.Drawing.Point(84, 88);
            this.journalJumlahNumericUpDown.Name = "journalJumlahNumericUpDown";
            this.journalJumlahNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.journalJumlahNumericUpDown.TabIndex = 5;
            // 
            // subAccountNameLabel
            // 
            this.subAccountNameLabel.AutoSize = true;
            this.subAccountNameLabel.Location = new System.Drawing.Point(8, 45);
            this.subAccountNameLabel.Name = "subAccountNameLabel";
            this.subAccountNameLabel.Size = new System.Drawing.Size(69, 13);
            this.subAccountNameLabel.TabIndex = 2;
            this.subAccountNameLabel.Text = "Nama Akun :";
            // 
            // subAccountNameTextBox
            // 
            this.subAccountNameTextBox.Location = new System.Drawing.Point(84, 42);
            this.subAccountNameTextBox.Name = "subAccountNameTextBox";
            this.subAccountNameTextBox.ReadOnly = true;
            this.subAccountNameTextBox.Size = new System.Drawing.Size(199, 20);
            this.subAccountNameTextBox.TabIndex = 3;
            // 
            // subAccountIdLabel1
            // 
            this.subAccountIdLabel1.AutoSize = true;
            this.subAccountIdLabel1.Location = new System.Drawing.Point(8, 23);
            this.subAccountIdLabel1.Name = "subAccountIdLabel1";
            this.subAccountIdLabel1.Size = new System.Drawing.Size(55, 13);
            this.subAccountIdLabel1.TabIndex = 0;
            this.subAccountIdLabel1.Text = "No Akun :";
            // 
            // subAccountIdTextBox
            // 
            this.subAccountIdTextBox.Location = new System.Drawing.Point(84, 19);
            this.subAccountIdTextBox.Name = "subAccountIdTextBox";
            this.subAccountIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.subAccountIdTextBox.TabIndex = 1;
            this.subAccountIdTextBox.Enter += new System.EventHandler(this.subAccountIdTextBox_Enter);
            this.subAccountIdTextBox.Leave += new System.EventHandler(this.subAccountIdTextBox_Leave);
            this.subAccountIdTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.subAccountIdTextBox_Validating);
            // 
            // groupBox_List
            // 
            this.groupBox_List.Controls.Add(this.label_Status);
            this.groupBox_List.Controls.Add(this.button_Delete);
            this.groupBox_List.Controls.Add(this.label_AccId);
            this.groupBox_List.Controls.Add(this.label_AccName);
            this.groupBox_List.Controls.Add(this.label_JournalDesc);
            this.groupBox_List.Controls.Add(this.label_JournalJumlah);
            this.groupBox_List.Controls.Add(this.tJournalDataGridView);
            this.groupBox_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_List.Location = new System.Drawing.Point(0, 0);
            this.groupBox_List.Name = "groupBox_List";
            this.groupBox_List.Size = new System.Drawing.Size(699, 414);
            this.groupBox_List.TabIndex = 1;
            this.groupBox_List.TabStop = false;
            this.groupBox_List.Text = "groupBox_List";
            // 
            // label_Status
            // 
            this.label_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Status.Location = new System.Drawing.Point(384, 18);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(56, 23);
            this.label_Status.TabIndex = 42;
            this.label_Status.Text = "Posisi";
            this.label_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Delete
            // 
            this.button_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Delete.Image = global::Inventori.Apotek.Forms.Properties.Resources.delete;
            this.button_Delete.Location = new System.Drawing.Point(643, 43);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(24, 119);
            this.button_Delete.TabIndex = 41;
            this.button_Delete.Text = "&Hapus";
            this.button_Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // label_AccId
            // 
            this.label_AccId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_AccId.Location = new System.Drawing.Point(6, 18);
            this.label_AccId.Name = "label_AccId";
            this.label_AccId.Size = new System.Drawing.Size(115, 23);
            this.label_AccId.TabIndex = 21;
            this.label_AccId.Text = "No Akun";
            this.label_AccId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_AccName
            // 
            this.label_AccName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_AccName.Location = new System.Drawing.Point(121, 18);
            this.label_AccName.Name = "label_AccName";
            this.label_AccName.Size = new System.Drawing.Size(179, 23);
            this.label_AccName.TabIndex = 20;
            this.label_AccName.Text = "Nama Akun";
            this.label_AccName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_JournalDesc
            // 
            this.label_JournalDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_JournalDesc.Location = new System.Drawing.Point(440, 18);
            this.label_JournalDesc.Name = "label_JournalDesc";
            this.label_JournalDesc.Size = new System.Drawing.Size(197, 23);
            this.label_JournalDesc.TabIndex = 19;
            this.label_JournalDesc.Text = "Keterangan";
            this.label_JournalDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_JournalJumlah
            // 
            this.label_JournalJumlah.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_JournalJumlah.Location = new System.Drawing.Point(300, 18);
            this.label_JournalJumlah.Name = "label_JournalJumlah";
            this.label_JournalJumlah.Size = new System.Drawing.Size(84, 23);
            this.label_JournalJumlah.TabIndex = 18;
            this.label_JournalJumlah.Text = "Jumlah";
            this.label_JournalJumlah.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tJournalDataGridView
            // 
            this.tJournalDataGridView.AllowUserToAddRows = false;
            this.tJournalDataGridView.AllowUserToDeleteRows = false;
            this.tJournalDataGridView.AllowUserToResizeColumns = false;
            this.tJournalDataGridView.AllowUserToResizeRows = false;
            this.tJournalDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.tJournalDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tJournalDataGridView.ColumnHeadersVisible = false;
            this.tJournalDataGridView.Location = new System.Drawing.Point(6, 41);
            this.tJournalDataGridView.MultiSelect = false;
            this.tJournalDataGridView.Name = "tJournalDataGridView";
            this.tJournalDataGridView.ReadOnly = true;
            this.tJournalDataGridView.RowHeadersVisible = false;
            this.tJournalDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tJournalDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tJournalDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tJournalDataGridView.Size = new System.Drawing.Size(631, 236);
            this.tJournalDataGridView.TabIndex = 16;
            this.tJournalDataGridView.TabStop = false;
            this.tJournalDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.tJournalDataGridView_RowsAdded);
            this.tJournalDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.tJournalDataGridView_RowsRemoved);
            // 
            // mSubAccountBindingSource
            // 
            this.mSubAccountBindingSource.DataSource = typeof(Inventori.Data.MSubAccount);
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
            this.simpanToolStripButton.Click += new System.EventHandler(this.SaveJournal);
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
            this.toolStripButton_Reset.Click += new System.EventHandler(this.ResetHeaderJournal);
            // 
            // FormJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 616);
            this.Controls.Add(this.tJournalBindingNavigator);
            this.Controls.Add(this.splitContainer_Main);
            this.Name = "FormJournal";
            this.TabText = "Transaksi Lain-lain";
            this.Text = "Transaksi Lain-lain";
            this.Load += new System.EventHandler(this.FormPayment_Load);
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
            this.splitContainer_Head.Panel2.ResumeLayout(false);
            this.splitContainer_Head.ResumeLayout(false);
            this.groupBox_Head.ResumeLayout(false);
            this.groupBox_Head.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balanceJumlahNumericUpDown)).EndInit();
            this.splitContainer_Detail.Panel1.ResumeLayout(false);
            this.splitContainer_Detail.Panel2.ResumeLayout(false);
            this.splitContainer_Detail.ResumeLayout(false);
            this.groupBox_Input.ResumeLayout(false);
            this.groupBox_Input.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tJournalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalJumlahNumericUpDown)).EndInit();
            this.groupBox_List.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tJournalDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSubAccountBindingSource)).EndInit();
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
        private System.Windows.Forms.SplitContainer splitContainer_Detail;
        private System.Windows.Forms.SplitContainer splitContainer_Head;
        private System.Windows.Forms.GroupBox groupBox_Head;
        private System.Windows.Forms.NumericUpDown balanceJumlahNumericUpDown;
        private System.Windows.Forms.DateTimePicker journalDateDateTimePicker;
        private System.Windows.Forms.GroupBox groupBox_Input;
        private System.Windows.Forms.TextBox journalDescTextBox;
        private System.Windows.Forms.NumericUpDown journalJumlahNumericUpDown;
        private System.Windows.Forms.TextBox subAccountNameTextBox;
        private System.Windows.Forms.BindingSource mSubAccountBindingSource;
        private System.Windows.Forms.TextBox subAccountIdTextBox;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.ToolStripButton simpanToolStripButton;
        private System.Windows.Forms.ToolStripButton CetakToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Reset;
        private System.Windows.Forms.GroupBox groupBox_List;
        private System.Windows.Forms.DataGridView tJournalDataGridView;
        private System.Windows.Forms.Label label_JournalJumlah;
        private System.Windows.Forms.Label label_AccId;
        private System.Windows.Forms.Label label_AccName;
        private System.Windows.Forms.Label label_JournalDesc;
        private System.Windows.Forms.Label journalDescLabel1;
        private System.Windows.Forms.Label journalJumlahLabel1;
        private System.Windows.Forms.Label subAccountNameLabel;
        private System.Windows.Forms.Label subAccountIdLabel1;
        private System.Windows.Forms.Label kasJumlahSaidLabel;
        private System.Windows.Forms.TextBox voucherNoTextBox;
        private System.Windows.Forms.Label journalJumlahLabel2;
        private System.Windows.Forms.Label voucherNoLabel;
        private System.Windows.Forms.Label journalJumlahLabel;
        private System.Windows.Forms.Label journalDateLabel;
        private System.Windows.Forms.Button button_Delete;
        public System.Windows.Forms.Label companyNameLabel;
        private System.Windows.Forms.RadioButton journalStatusKreditRadioButton;
        private System.Windows.Forms.BindingSource tJournalBindingSource;
        private System.Windows.Forms.RadioButton journalStatusDebetRadioButton;
        private System.Windows.Forms.Label label_Status;
    }
}