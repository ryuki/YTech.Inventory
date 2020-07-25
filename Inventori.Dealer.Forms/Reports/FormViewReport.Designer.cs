namespace Inventori.Dealer.Forms
{
    partial class FormViewReport
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
            System.Windows.Forms.Label gudangIdLabel;
            System.Windows.Forms.Label locationIdLabel;
            System.Windows.Forms.Label transactionByLabel;
            System.Windows.Forms.Label transactionDateLabel;
            System.Windows.Forms.Label itemIdLabel;
            System.Windows.Forms.Label stockDesc1Label;
            System.Windows.Forms.Label stockDesc2Label;
            System.Windows.Forms.Label stockDesc3Label;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.ReportSplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.GudangIdPanel = new System.Windows.Forms.Panel();
            this.gudangIdComboBox = new System.Windows.Forms.ComboBox();
            this.tTransactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StatusStockPanel = new System.Windows.Forms.Panel();
            this.StatusStockComboBox = new System.Windows.Forms.ComboBox();
            this.FilterByDatePanel = new System.Windows.Forms.Panel();
            this.FilterByDateCheckBox = new System.Windows.Forms.CheckBox();
            this.LocationIdPanel = new System.Windows.Forms.Panel();
            this.locationIdComboBox = new System.Windows.Forms.ComboBox();
            this.TransactionByPanel = new System.Windows.Forms.Panel();
            this.transactionByComboBox = new System.Windows.Forms.ComboBox();
            this.NoMesinPanel = new System.Windows.Forms.Panel();
            this.stockDesc3TextBox = new System.Windows.Forms.TextBox();
            this.tStockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TransactionDateToPanel = new System.Windows.Forms.Panel();
            this.transactionDateToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.NoRangkaPanel = new System.Windows.Forms.Panel();
            this.stockDesc2TextBox = new System.Windows.Forms.TextBox();
            this.TransactionDatePanel = new System.Windows.Forms.Panel();
            this.transactionDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ColourPanel = new System.Windows.Forms.Panel();
            this.stockDesc1ComboBox = new System.Windows.Forms.ComboBox();
            this.ItemIdPanel = new System.Windows.Forms.Panel();
            this.itemIdComboBox = new System.Windows.Forms.ComboBox();
            this.tTransactionDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ResetButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.mSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            gudangIdLabel = new System.Windows.Forms.Label();
            locationIdLabel = new System.Windows.Forms.Label();
            transactionByLabel = new System.Windows.Forms.Label();
            transactionDateLabel = new System.Windows.Forms.Label();
            itemIdLabel = new System.Windows.Forms.Label();
            stockDesc1Label = new System.Windows.Forms.Label();
            stockDesc2Label = new System.Windows.Forms.Label();
            stockDesc3Label = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.ReportSplitContainer.Panel1.SuspendLayout();
            this.ReportSplitContainer.Panel2.SuspendLayout();
            this.ReportSplitContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.GudangIdPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionBindingSource)).BeginInit();
            this.StatusStockPanel.SuspendLayout();
            this.FilterByDatePanel.SuspendLayout();
            this.LocationIdPanel.SuspendLayout();
            this.TransactionByPanel.SuspendLayout();
            this.NoMesinPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tStockBindingSource)).BeginInit();
            this.TransactionDateToPanel.SuspendLayout();
            this.NoRangkaPanel.SuspendLayout();
            this.TransactionDatePanel.SuspendLayout();
            this.ColourPanel.SuspendLayout();
            this.ItemIdPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSettingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gudangIdLabel
            // 
            gudangIdLabel.AutoSize = true;
            gudangIdLabel.Location = new System.Drawing.Point(8, 6);
            gudangIdLabel.Name = "gudangIdLabel";
            gudangIdLabel.Size = new System.Drawing.Size(44, 13);
            gudangIdLabel.TabIndex = 0;
            gudangIdLabel.Text = "Lokasi :";
            // 
            // locationIdLabel
            // 
            locationIdLabel.AutoSize = true;
            locationIdLabel.Location = new System.Drawing.Point(8, 6);
            locationIdLabel.Name = "locationIdLabel";
            locationIdLabel.Size = new System.Drawing.Size(52, 13);
            locationIdLabel.TabIndex = 2;
            locationIdLabel.Text = "Channel :";
            // 
            // transactionByLabel
            // 
            transactionByLabel.AutoSize = true;
            transactionByLabel.Location = new System.Drawing.Point(8, 6);
            transactionByLabel.Name = "transactionByLabel";
            transactionByLabel.Size = new System.Drawing.Size(64, 13);
            transactionByLabel.TabIndex = 0;
            transactionByLabel.Text = "Pelanggan :";
            // 
            // transactionDateLabel
            // 
            transactionDateLabel.AutoSize = true;
            transactionDateLabel.Location = new System.Drawing.Point(7, 9);
            transactionDateLabel.Name = "transactionDateLabel";
            transactionDateLabel.Size = new System.Drawing.Size(52, 13);
            transactionDateLabel.TabIndex = 1;
            transactionDateLabel.Text = "Tanggal :";
            // 
            // itemIdLabel
            // 
            itemIdLabel.AutoSize = true;
            itemIdLabel.Location = new System.Drawing.Point(8, 6);
            itemIdLabel.Name = "itemIdLabel";
            itemIdLabel.Size = new System.Drawing.Size(59, 13);
            itemIdLabel.TabIndex = 0;
            itemIdLabel.Text = "Type Unit :";
            // 
            // stockDesc1Label
            // 
            stockDesc1Label.AutoSize = true;
            stockDesc1Label.Location = new System.Drawing.Point(8, 3);
            stockDesc1Label.Name = "stockDesc1Label";
            stockDesc1Label.Size = new System.Drawing.Size(45, 13);
            stockDesc1Label.TabIndex = 0;
            stockDesc1Label.Text = "Warna :";
            // 
            // stockDesc2Label
            // 
            stockDesc2Label.AutoSize = true;
            stockDesc2Label.Location = new System.Drawing.Point(8, 7);
            stockDesc2Label.Name = "stockDesc2Label";
            stockDesc2Label.Size = new System.Drawing.Size(68, 13);
            stockDesc2Label.TabIndex = 0;
            stockDesc2Label.Text = "No Rangka :";
            // 
            // stockDesc3Label
            // 
            stockDesc3Label.AutoSize = true;
            stockDesc3Label.Location = new System.Drawing.Point(7, 6);
            stockDesc3Label.Name = "stockDesc3Label";
            stockDesc3Label.Size = new System.Drawing.Size(58, 13);
            stockDesc3Label.TabIndex = 0;
            stockDesc3Label.Text = "No Mesin :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(49, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(23, 13);
            label1.TabIndex = 1;
            label1.Text = "s/d";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(8, 6);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 13);
            label2.TabIndex = 2;
            label2.Text = "Status Stok :";
            // 
            // ReportSplitContainer
            // 
            this.ReportSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ReportSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ReportSplitContainer.Name = "ReportSplitContainer";
            // 
            // ReportSplitContainer.Panel1
            // 
            this.ReportSplitContainer.Panel1.Controls.Add(this.groupBox1);
            // 
            // ReportSplitContainer.Panel2
            // 
            this.ReportSplitContainer.Panel2.Controls.Add(this.reportViewer1);
            this.ReportSplitContainer.Size = new System.Drawing.Size(606, 487);
            this.ReportSplitContainer.SplitterDistance = 283;
            this.ReportSplitContainer.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.ResetButton);
            this.groupBox1.Controls.Add(this.SearchButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 487);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.GudangIdPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.StatusStockPanel, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.FilterByDatePanel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.LocationIdPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TransactionByPanel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.NoMesinPanel, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.TransactionDateToPanel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.NoRangkaPanel, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.TransactionDatePanel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ColourPanel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.ItemIdPanel, 0, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 68);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(257, 374);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // GudangIdPanel
            // 
            this.GudangIdPanel.Controls.Add(gudangIdLabel);
            this.GudangIdPanel.Controls.Add(this.gudangIdComboBox);
            this.GudangIdPanel.Location = new System.Drawing.Point(3, 3);
            this.GudangIdPanel.Name = "GudangIdPanel";
            this.GudangIdPanel.Size = new System.Drawing.Size(251, 28);
            this.GudangIdPanel.TabIndex = 0;
            this.GudangIdPanel.Visible = false;
            // 
            // gudangIdComboBox
            // 
            this.gudangIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tTransactionBindingSource, "GudangId", true));
            this.gudangIdComboBox.FormattingEnabled = true;
            this.gudangIdComboBox.Location = new System.Drawing.Point(76, 3);
            this.gudangIdComboBox.Name = "gudangIdComboBox";
            this.gudangIdComboBox.Size = new System.Drawing.Size(174, 21);
            this.gudangIdComboBox.TabIndex = 1;
            // 
            // tTransactionBindingSource
            // 
            this.tTransactionBindingSource.DataSource = typeof(Inventori.Data.TTransaction);
            // 
            // StatusStockPanel
            // 
            this.StatusStockPanel.Controls.Add(label2);
            this.StatusStockPanel.Controls.Add(this.StatusStockComboBox);
            this.StatusStockPanel.Location = new System.Drawing.Point(3, 329);
            this.StatusStockPanel.Name = "StatusStockPanel";
            this.StatusStockPanel.Size = new System.Drawing.Size(251, 26);
            this.StatusStockPanel.TabIndex = 10;
            this.StatusStockPanel.Visible = false;
            // 
            // StatusStockComboBox
            // 
            this.StatusStockComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusStockComboBox.FormattingEnabled = true;
            this.StatusStockComboBox.Items.AddRange(new object[] {
            "Terjual dan Belum Terjual",
            "Terjual",
            "Belum Terjual"});
            this.StatusStockComboBox.Location = new System.Drawing.Point(76, 3);
            this.StatusStockComboBox.Name = "StatusStockComboBox";
            this.StatusStockComboBox.Size = new System.Drawing.Size(172, 21);
            this.StatusStockComboBox.TabIndex = 3;
            // 
            // FilterByDatePanel
            // 
            this.FilterByDatePanel.Controls.Add(this.FilterByDateCheckBox);
            this.FilterByDatePanel.Location = new System.Drawing.Point(3, 103);
            this.FilterByDatePanel.Name = "FilterByDatePanel";
            this.FilterByDatePanel.Size = new System.Drawing.Size(251, 22);
            this.FilterByDatePanel.TabIndex = 11;
            this.FilterByDatePanel.Visible = false;
            // 
            // FilterByDateCheckBox
            // 
            this.FilterByDateCheckBox.AutoSize = true;
            this.FilterByDateCheckBox.Checked = true;
            this.FilterByDateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FilterByDateCheckBox.Location = new System.Drawing.Point(91, 4);
            this.FilterByDateCheckBox.Name = "FilterByDateCheckBox";
            this.FilterByDateCheckBox.Size = new System.Drawing.Size(109, 17);
            this.FilterByDateCheckBox.TabIndex = 0;
            this.FilterByDateCheckBox.Text = "Filter Per Tanggal";
            this.FilterByDateCheckBox.UseVisualStyleBackColor = true;
            // 
            // LocationIdPanel
            // 
            this.LocationIdPanel.Controls.Add(locationIdLabel);
            this.LocationIdPanel.Controls.Add(this.locationIdComboBox);
            this.LocationIdPanel.Location = new System.Drawing.Point(3, 37);
            this.LocationIdPanel.Name = "LocationIdPanel";
            this.LocationIdPanel.Size = new System.Drawing.Size(251, 27);
            this.LocationIdPanel.TabIndex = 1;
            this.LocationIdPanel.Visible = false;
            // 
            // locationIdComboBox
            // 
            this.locationIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tTransactionBindingSource, "LocationId", true));
            this.locationIdComboBox.FormattingEnabled = true;
            this.locationIdComboBox.Location = new System.Drawing.Point(76, 3);
            this.locationIdComboBox.Name = "locationIdComboBox";
            this.locationIdComboBox.Size = new System.Drawing.Size(174, 21);
            this.locationIdComboBox.TabIndex = 3;
            // 
            // TransactionByPanel
            // 
            this.TransactionByPanel.Controls.Add(transactionByLabel);
            this.TransactionByPanel.Controls.Add(this.transactionByComboBox);
            this.TransactionByPanel.Location = new System.Drawing.Point(3, 70);
            this.TransactionByPanel.Name = "TransactionByPanel";
            this.TransactionByPanel.Size = new System.Drawing.Size(251, 27);
            this.TransactionByPanel.TabIndex = 2;
            this.TransactionByPanel.Visible = false;
            // 
            // transactionByComboBox
            // 
            this.transactionByComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tTransactionBindingSource, "TransactionBy", true));
            this.transactionByComboBox.FormattingEnabled = true;
            this.transactionByComboBox.Location = new System.Drawing.Point(75, 3);
            this.transactionByComboBox.Name = "transactionByComboBox";
            this.transactionByComboBox.Size = new System.Drawing.Size(174, 21);
            this.transactionByComboBox.TabIndex = 1;
            // 
            // NoMesinPanel
            // 
            this.NoMesinPanel.Controls.Add(stockDesc3Label);
            this.NoMesinPanel.Controls.Add(this.stockDesc3TextBox);
            this.NoMesinPanel.Location = new System.Drawing.Point(3, 297);
            this.NoMesinPanel.Name = "NoMesinPanel";
            this.NoMesinPanel.Size = new System.Drawing.Size(251, 26);
            this.NoMesinPanel.TabIndex = 6;
            this.NoMesinPanel.Visible = false;
            // 
            // stockDesc3TextBox
            // 
            this.stockDesc3TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tStockBindingSource, "StockDesc3", true));
            this.stockDesc3TextBox.Location = new System.Drawing.Point(76, 3);
            this.stockDesc3TextBox.Name = "stockDesc3TextBox";
            this.stockDesc3TextBox.Size = new System.Drawing.Size(172, 20);
            this.stockDesc3TextBox.TabIndex = 1;
            // 
            // tStockBindingSource
            // 
            this.tStockBindingSource.DataSource = typeof(Inventori.Data.TStock);
            // 
            // TransactionDateToPanel
            // 
            this.TransactionDateToPanel.Controls.Add(label1);
            this.TransactionDateToPanel.Controls.Add(this.transactionDateToDateTimePicker);
            this.TransactionDateToPanel.Location = new System.Drawing.Point(3, 168);
            this.TransactionDateToPanel.Name = "TransactionDateToPanel";
            this.TransactionDateToPanel.Size = new System.Drawing.Size(251, 27);
            this.TransactionDateToPanel.TabIndex = 7;
            this.TransactionDateToPanel.Visible = false;
            // 
            // transactionDateToDateTimePicker
            // 
            this.transactionDateToDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tTransactionBindingSource, "TransactionDate", true));
            this.transactionDateToDateTimePicker.Location = new System.Drawing.Point(75, 5);
            this.transactionDateToDateTimePicker.Name = "transactionDateToDateTimePicker";
            this.transactionDateToDateTimePicker.Size = new System.Drawing.Size(173, 20);
            this.transactionDateToDateTimePicker.TabIndex = 2;
            // 
            // NoRangkaPanel
            // 
            this.NoRangkaPanel.Controls.Add(stockDesc2Label);
            this.NoRangkaPanel.Controls.Add(this.stockDesc2TextBox);
            this.NoRangkaPanel.Location = new System.Drawing.Point(3, 265);
            this.NoRangkaPanel.Name = "NoRangkaPanel";
            this.NoRangkaPanel.Size = new System.Drawing.Size(251, 26);
            this.NoRangkaPanel.TabIndex = 5;
            this.NoRangkaPanel.Visible = false;
            // 
            // stockDesc2TextBox
            // 
            this.stockDesc2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tStockBindingSource, "StockDesc2", true));
            this.stockDesc2TextBox.Location = new System.Drawing.Point(76, 3);
            this.stockDesc2TextBox.Name = "stockDesc2TextBox";
            this.stockDesc2TextBox.Size = new System.Drawing.Size(172, 20);
            this.stockDesc2TextBox.TabIndex = 1;
            // 
            // TransactionDatePanel
            // 
            this.TransactionDatePanel.Controls.Add(transactionDateLabel);
            this.TransactionDatePanel.Controls.Add(this.transactionDateDateTimePicker);
            this.TransactionDatePanel.Location = new System.Drawing.Point(3, 131);
            this.TransactionDatePanel.Name = "TransactionDatePanel";
            this.TransactionDatePanel.Size = new System.Drawing.Size(251, 31);
            this.TransactionDatePanel.TabIndex = 3;
            this.TransactionDatePanel.Visible = false;
            // 
            // transactionDateDateTimePicker
            // 
            this.transactionDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tTransactionBindingSource, "TransactionDate", true));
            this.transactionDateDateTimePicker.Location = new System.Drawing.Point(75, 5);
            this.transactionDateDateTimePicker.Name = "transactionDateDateTimePicker";
            this.transactionDateDateTimePicker.Size = new System.Drawing.Size(173, 20);
            this.transactionDateDateTimePicker.TabIndex = 2;
            // 
            // ColourPanel
            // 
            this.ColourPanel.Controls.Add(stockDesc1Label);
            this.ColourPanel.Controls.Add(this.stockDesc1ComboBox);
            this.ColourPanel.Location = new System.Drawing.Point(3, 233);
            this.ColourPanel.Name = "ColourPanel";
            this.ColourPanel.Size = new System.Drawing.Size(251, 26);
            this.ColourPanel.TabIndex = 4;
            this.ColourPanel.Visible = false;
            // 
            // stockDesc1ComboBox
            // 
            this.stockDesc1ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tStockBindingSource, "StockDesc1", true));
            this.stockDesc1ComboBox.FormattingEnabled = true;
            this.stockDesc1ComboBox.Location = new System.Drawing.Point(76, 0);
            this.stockDesc1ComboBox.Name = "stockDesc1ComboBox";
            this.stockDesc1ComboBox.Size = new System.Drawing.Size(172, 21);
            this.stockDesc1ComboBox.TabIndex = 1;
            // 
            // ItemIdPanel
            // 
            this.ItemIdPanel.Controls.Add(itemIdLabel);
            this.ItemIdPanel.Controls.Add(this.itemIdComboBox);
            this.ItemIdPanel.Location = new System.Drawing.Point(3, 201);
            this.ItemIdPanel.Name = "ItemIdPanel";
            this.ItemIdPanel.Size = new System.Drawing.Size(251, 26);
            this.ItemIdPanel.TabIndex = 3;
            this.ItemIdPanel.Visible = false;
            // 
            // itemIdComboBox
            // 
            this.itemIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tTransactionDetailBindingSource, "ItemId", true));
            this.itemIdComboBox.FormattingEnabled = true;
            this.itemIdComboBox.Location = new System.Drawing.Point(76, 3);
            this.itemIdComboBox.Name = "itemIdComboBox";
            this.itemIdComboBox.Size = new System.Drawing.Size(172, 21);
            this.itemIdComboBox.TabIndex = 1;
            // 
            // tTransactionDetailBindingSource
            // 
            this.tTransactionDetailBindingSource.DataSource = typeof(Inventori.Data.TTransactionDetail);
            // 
            // ResetButton
            // 
            this.ResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetButton.Image = global::Inventori.Dealer.Forms.Properties.Resources.Refresh;
            this.ResetButton.Location = new System.Drawing.Point(117, 16);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(86, 46);
            this.ResetButton.TabIndex = 9;
            this.ResetButton.Text = "Reset";
            this.ResetButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ResetButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ResetButton.UseVisualStyleBackColor = true;
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Image = global::Inventori.Dealer.Forms.Properties.Resources.browse;
            this.SearchButton.Location = new System.Drawing.Point(19, 16);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(86, 46);
            this.SearchButton.TabIndex = 8;
            this.SearchButton.Text = "Cari";
            this.SearchButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SearchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(319, 487);
            this.reportViewer1.TabIndex = 0;
            // 
            // mSettingBindingSource
            // 
            this.mSettingBindingSource.DataSource = typeof(Inventori.Data.MSetting);
            // 
            // FormViewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 487);
            this.Controls.Add(this.ReportSplitContainer);
            this.Name = "FormViewReport";
            this.TabText = "Laporan";
            this.Text = "Laporan";
            this.Load += new System.EventHandler(this.FormViewReport_Load);
            this.Controls.SetChildIndex(this.ReportSplitContainer, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.ReportSplitContainer.Panel1.ResumeLayout(false);
            this.ReportSplitContainer.Panel2.ResumeLayout(false);
            this.ReportSplitContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.GudangIdPanel.ResumeLayout(false);
            this.GudangIdPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionBindingSource)).EndInit();
            this.StatusStockPanel.ResumeLayout(false);
            this.StatusStockPanel.PerformLayout();
            this.FilterByDatePanel.ResumeLayout(false);
            this.FilterByDatePanel.PerformLayout();
            this.LocationIdPanel.ResumeLayout(false);
            this.LocationIdPanel.PerformLayout();
            this.TransactionByPanel.ResumeLayout(false);
            this.TransactionByPanel.PerformLayout();
            this.NoMesinPanel.ResumeLayout(false);
            this.NoMesinPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tStockBindingSource)).EndInit();
            this.TransactionDateToPanel.ResumeLayout(false);
            this.TransactionDateToPanel.PerformLayout();
            this.NoRangkaPanel.ResumeLayout(false);
            this.NoRangkaPanel.PerformLayout();
            this.TransactionDatePanel.ResumeLayout(false);
            this.TransactionDatePanel.PerformLayout();
            this.ColourPanel.ResumeLayout(false);
            this.ColourPanel.PerformLayout();
            this.ItemIdPanel.ResumeLayout(false);
            this.ItemIdPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSettingBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer ReportSplitContainer;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource tTransactionBindingSource;
        private System.Windows.Forms.Panel GudangIdPanel;
        private System.Windows.Forms.ComboBox gudangIdComboBox;
        private System.Windows.Forms.BindingSource mSettingBindingSource;
        private System.Windows.Forms.Panel LocationIdPanel;
        private System.Windows.Forms.ComboBox locationIdComboBox;
        private System.Windows.Forms.Panel TransactionByPanel;
        private System.Windows.Forms.ComboBox transactionByComboBox;
        private System.Windows.Forms.Panel ColourPanel;
        private System.Windows.Forms.Panel ItemIdPanel;
        private System.Windows.Forms.Panel TransactionDatePanel;
        private System.Windows.Forms.Panel NoRangkaPanel;
        private System.Windows.Forms.TextBox stockDesc2TextBox;
        private System.Windows.Forms.BindingSource tStockBindingSource;
        private System.Windows.Forms.ComboBox stockDesc1ComboBox;
        private System.Windows.Forms.ComboBox itemIdComboBox;
        private System.Windows.Forms.BindingSource tTransactionDetailBindingSource;
        private System.Windows.Forms.DateTimePicker transactionDateDateTimePicker;
        private System.Windows.Forms.Panel NoMesinPanel;
        private System.Windows.Forms.TextBox stockDesc3TextBox;
        private System.Windows.Forms.Panel TransactionDateToPanel;
        private System.Windows.Forms.DateTimePicker transactionDateToDateTimePicker;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Panel StatusStockPanel;
        private System.Windows.Forms.ComboBox StatusStockComboBox;
        private System.Windows.Forms.Panel FilterByDatePanel;
        private System.Windows.Forms.CheckBox FilterByDateCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}