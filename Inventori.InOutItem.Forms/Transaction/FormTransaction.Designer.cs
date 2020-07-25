namespace Inventori.InOutItem.Forms
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
            System.Windows.Forms.Label quantityLabel;
            System.Windows.Forms.Label itemIdLabel;
            System.Windows.Forms.Label stockBarcodeIdLabel;
            System.Windows.Forms.Label stockLocationLabel;
            this.transactionByLabel = new System.Windows.Forms.Label();
            this.transactionDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.transactionIdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.transactionFacturTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.transactionByNameTextBox = new System.Windows.Forms.TextBox();
            this.transactionByTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.itemIdTextBox = new System.Windows.Forms.TextBox();
            this.quantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.stockLocationTextBox = new System.Windows.Forms.TextBox();
            this.stockBarcodeIdTextBox = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.tStockDataGridView = new System.Windows.Forms.DataGridView();
            this.stockBarcodeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockLocationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.tTransactionDetailDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.simpanToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Reset = new System.Windows.Forms.ToolStripButton();
            transactionDateLabel = new System.Windows.Forms.Label();
            transactionFacturLabel = new System.Windows.Forms.Label();
            quantityLabel = new System.Windows.Forms.Label();
            itemIdLabel = new System.Windows.Forms.Label();
            stockBarcodeIdLabel = new System.Windows.Forms.Label();
            stockLocationLabel = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionIdNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tStockDataGridView)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionDetailDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Location = new System.Drawing.Point(0, 36);
            // 
            // transactionDateLabel
            // 
            transactionDateLabel.AutoSize = true;
            transactionDateLabel.Location = new System.Drawing.Point(6, 43);
            transactionDateLabel.Name = "transactionDateLabel";
            transactionDateLabel.Size = new System.Drawing.Size(52, 13);
            transactionDateLabel.TabIndex = 1;
            transactionDateLabel.Text = "Tanggal :";
            // 
            // transactionFacturLabel
            // 
            transactionFacturLabel.AutoSize = true;
            transactionFacturLabel.Location = new System.Drawing.Point(6, 16);
            transactionFacturLabel.Name = "transactionFacturLabel";
            transactionFacturLabel.Size = new System.Drawing.Size(60, 13);
            transactionFacturLabel.TabIndex = 2;
            transactionFacturLabel.Text = "No Faktur :";
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.Location = new System.Drawing.Point(3, 59);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new System.Drawing.Size(49, 13);
            quantityLabel.TabIndex = 11;
            quantityLabel.Text = "Quantity:";
            // 
            // itemIdLabel
            // 
            itemIdLabel.AutoSize = true;
            itemIdLabel.Location = new System.Drawing.Point(3, 10);
            itemIdLabel.Name = "itemIdLabel";
            itemIdLabel.Size = new System.Drawing.Size(47, 13);
            itemIdLabel.TabIndex = 7;
            itemIdLabel.Text = "Barang :";
            // 
            // stockBarcodeIdLabel
            // 
            stockBarcodeIdLabel.AutoSize = true;
            stockBarcodeIdLabel.Location = new System.Drawing.Point(1, 16);
            stockBarcodeIdLabel.Name = "stockBarcodeIdLabel";
            stockBarcodeIdLabel.Size = new System.Drawing.Size(81, 13);
            stockBarcodeIdLabel.TabIndex = 0;
            stockBarcodeIdLabel.Text = "Kode Barcode :";
            // 
            // stockLocationLabel
            // 
            stockLocationLabel.AutoSize = true;
            stockLocationLabel.Location = new System.Drawing.Point(1, 42);
            stockLocationLabel.Name = "stockLocationLabel";
            stockLocationLabel.Size = new System.Drawing.Size(50, 13);
            stockLocationLabel.TabIndex = 4;
            stockLocationLabel.Text = "No Rak :";
            // 
            // transactionByLabel
            // 
            this.transactionByLabel.AutoSize = true;
            this.transactionByLabel.Location = new System.Drawing.Point(6, 16);
            this.transactionByLabel.Name = "transactionByLabel";
            this.transactionByLabel.Size = new System.Drawing.Size(51, 13);
            this.transactionByLabel.TabIndex = 0;
            this.transactionByLabel.Text = "Supplier :";
            // 
            // transactionDateDateTimePicker
            // 
            this.transactionDateDateTimePicker.Location = new System.Drawing.Point(111, 39);
            this.transactionDateDateTimePicker.Name = "transactionDateDateTimePicker";
            this.transactionDateDateTimePicker.Size = new System.Drawing.Size(140, 20);
            this.transactionDateDateTimePicker.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 36);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(967, 497);
            this.splitContainer1.SplitterDistance = 124;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(967, 124);
            this.splitContainer2.SplitterDistance = 69;
            this.splitContainer2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.transactionIdNumericUpDown);
            this.groupBox1.Controls.Add(transactionFacturLabel);
            this.groupBox1.Controls.Add(this.transactionDateDateTimePicker);
            this.groupBox1.Controls.Add(transactionDateLabel);
            this.groupBox1.Controls.Add(this.transactionFacturTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(967, 69);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // transactionIdNumericUpDown
            // 
            this.transactionIdNumericUpDown.Location = new System.Drawing.Point(463, 43);
            this.transactionIdNumericUpDown.Name = "transactionIdNumericUpDown";
            this.transactionIdNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.transactionIdNumericUpDown.TabIndex = 5;
            this.transactionIdNumericUpDown.Visible = false;
            // 
            // transactionFacturTextBox
            // 
            this.transactionFacturTextBox.Location = new System.Drawing.Point(111, 13);
            this.transactionFacturTextBox.Name = "transactionFacturTextBox";
            this.transactionFacturTextBox.Size = new System.Drawing.Size(140, 20);
            this.transactionFacturTextBox.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.transactionByNameTextBox);
            this.groupBox2.Controls.Add(this.transactionByTextBox);
            this.groupBox2.Controls.Add(this.transactionByLabel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(967, 51);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // transactionByNameTextBox
            // 
            this.transactionByNameTextBox.Location = new System.Drawing.Point(257, 13);
            this.transactionByNameTextBox.Name = "transactionByNameTextBox";
            this.transactionByNameTextBox.Size = new System.Drawing.Size(227, 20);
            this.transactionByNameTextBox.TabIndex = 2;
            // 
            // transactionByTextBox
            // 
            this.transactionByTextBox.Location = new System.Drawing.Point(111, 13);
            this.transactionByTextBox.Name = "transactionByTextBox";
            this.transactionByTextBox.Size = new System.Drawing.Size(140, 20);
            this.transactionByTextBox.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.splitContainer3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(967, 369);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 16);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.AutoScroll = true;
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer5);
            this.splitContainer3.Panel1.Controls.Add(this.splitter1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.AutoScroll = true;
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(961, 350);
            this.splitContainer3.SplitterDistance = 399;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(8, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.splitContainer6);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.AutoScroll = true;
            this.splitContainer5.Panel2.Controls.Add(this.tStockDataGridView);
            this.splitContainer5.Size = new System.Drawing.Size(391, 350);
            this.splitContainer5.SplitterDistance = 198;
            this.splitContainer5.TabIndex = 1;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(itemIdLabel);
            this.splitContainer6.Panel1.Controls.Add(this.itemNameTextBox);
            this.splitContainer6.Panel1.Controls.Add(this.buttonSave);
            this.splitContainer6.Panel1.Controls.Add(this.itemIdTextBox);
            this.splitContainer6.Panel1.Controls.Add(quantityLabel);
            this.splitContainer6.Panel1.Controls.Add(this.quantityNumericUpDown);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.AutoScroll = true;
            this.splitContainer6.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer6.Size = new System.Drawing.Size(391, 198);
            this.splitContainer6.SplitterDistance = 122;
            this.splitContainer6.TabIndex = 14;
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.Location = new System.Drawing.Point(80, 33);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(208, 20);
            this.itemNameTextBox.TabIndex = 13;
            // 
            // buttonSave
            // 
            this.buttonSave.Image = global::Inventori.InOutItem.Forms.Properties.Resources.save;
            this.buttonSave.Location = new System.Drawing.Point(147, 85);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(96, 30);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Simpan";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // itemIdTextBox
            // 
            this.itemIdTextBox.Location = new System.Drawing.Point(80, 7);
            this.itemIdTextBox.Name = "itemIdTextBox";
            this.itemIdTextBox.Size = new System.Drawing.Size(133, 20);
            this.itemIdTextBox.TabIndex = 8;
            // 
            // quantityNumericUpDown
            // 
            this.quantityNumericUpDown.Location = new System.Drawing.Point(80, 59);
            this.quantityNumericUpDown.Name = "quantityNumericUpDown";
            this.quantityNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.quantityNumericUpDown.TabIndex = 12;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(stockLocationLabel);
            this.groupBox4.Controls.Add(stockBarcodeIdLabel);
            this.groupBox4.Controls.Add(this.stockLocationTextBox);
            this.groupBox4.Controls.Add(this.stockBarcodeIdTextBox);
            this.groupBox4.Controls.Add(this.buttonAdd);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(391, 72);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // stockLocationTextBox
            // 
            this.stockLocationTextBox.Location = new System.Drawing.Point(98, 39);
            this.stockLocationTextBox.Name = "stockLocationTextBox";
            this.stockLocationTextBox.Size = new System.Drawing.Size(140, 20);
            this.stockLocationTextBox.TabIndex = 5;
            // 
            // stockBarcodeIdTextBox
            // 
            this.stockBarcodeIdTextBox.Location = new System.Drawing.Point(98, 13);
            this.stockBarcodeIdTextBox.Name = "stockBarcodeIdTextBox";
            this.stockBarcodeIdTextBox.Size = new System.Drawing.Size(167, 20);
            this.stockBarcodeIdTextBox.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Image = global::Inventori.InOutItem.Forms.Properties.Resources.add;
            this.buttonAdd.Location = new System.Drawing.Point(271, 33);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(103, 30);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Tambah";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // tStockDataGridView
            // 
            this.tStockDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stockBarcodeIdDataGridViewTextBoxColumn,
            this.stockLocationDataGridViewTextBoxColumn,
            this.ItemId});
            this.tStockDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tStockDataGridView.Location = new System.Drawing.Point(0, 0);
            this.tStockDataGridView.Name = "tStockDataGridView";
            this.tStockDataGridView.Size = new System.Drawing.Size(391, 148);
            this.tStockDataGridView.TabIndex = 0;
            // 
            // stockBarcodeIdDataGridViewTextBoxColumn
            // 
            this.stockBarcodeIdDataGridViewTextBoxColumn.HeaderText = "Kode Barcode";
            this.stockBarcodeIdDataGridViewTextBoxColumn.Name = "stockBarcodeIdDataGridViewTextBoxColumn";
            this.stockBarcodeIdDataGridViewTextBoxColumn.Width = 200;
            // 
            // stockLocationDataGridViewTextBoxColumn
            // 
            this.stockLocationDataGridViewTextBoxColumn.HeaderText = "No Rak";
            this.stockLocationDataGridViewTextBoxColumn.Name = "stockLocationDataGridViewTextBoxColumn";
            this.stockLocationDataGridViewTextBoxColumn.Width = 150;
            // 
            // ItemId
            // 
            this.ItemId.HeaderText = "ItemId";
            this.ItemId.Name = "ItemId";
            this.ItemId.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 350);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.AutoScroll = true;
            this.splitContainer4.Panel1.Controls.Add(this.tTransactionDetailDataGridView);
            this.splitContainer4.Size = new System.Drawing.Size(558, 350);
            this.splitContainer4.SplitterDistance = 523;
            this.splitContainer4.TabIndex = 0;
            // 
            // tTransactionDetailDataGridView
            // 
            this.tTransactionDetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn4});
            this.tTransactionDetailDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tTransactionDetailDataGridView.Location = new System.Drawing.Point(0, 0);
            this.tTransactionDetailDataGridView.Name = "tTransactionDetailDataGridView";
            this.tTransactionDetailDataGridView.Size = new System.Drawing.Size(523, 350);
            this.tTransactionDetailDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Kode Barang";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpanToolStripButton,
            this.toolStripSeparator1,
            this.toolStripButton_Reset});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(967, 36);
            this.bindingNavigator1.TabIndex = 4;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // simpanToolStripButton
            // 
            this.simpanToolStripButton.Image = global::Inventori.InOutItem.Forms.Properties.Resources.save;
            this.simpanToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.simpanToolStripButton.Name = "simpanToolStripButton";
            this.simpanToolStripButton.Size = new System.Drawing.Size(45, 33);
            this.simpanToolStripButton.Text = "Simpan";
            this.simpanToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // toolStripButton_Reset
            // 
            this.toolStripButton_Reset.Image = global::Inventori.InOutItem.Forms.Properties.Resources.Refresh;
            this.toolStripButton_Reset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Reset.Name = "toolStripButton_Reset";
            this.toolStripButton_Reset.Size = new System.Drawing.Size(39, 33);
            this.toolStripButton_Reset.Text = "Reset";
            this.toolStripButton_Reset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // FormTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 533);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bindingNavigator1);
            this.Name = "FormTransaction";
            this.TabText = "Barang Masuk";
            this.Text = "Barang Masuk";
            this.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionIdNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel1.PerformLayout();
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tStockDataGridView)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionDetailDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker transactionDateDateTimePicker;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox transactionFacturTextBox;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox transactionByNameTextBox;
        private System.Windows.Forms.TextBox transactionByTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.NumericUpDown quantityNumericUpDown;
        private System.Windows.Forms.TextBox itemIdTextBox;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView tTransactionDetailDataGridView;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.DataGridView tStockDataGridView;
        private System.Windows.Forms.TextBox stockBarcodeIdTextBox;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox stockLocationTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton simpanToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Reset;
        private System.Windows.Forms.NumericUpDown transactionIdNumericUpDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockBarcodeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockLocationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.Label transactionByLabel;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}