namespace Inventori.Dealer.Forms
{
    partial class FormChangePrice
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
            System.Windows.Forms.Label itemIdLabel;
            System.Windows.Forms.Label itemPriceMaxLabel;
            System.Windows.Forms.Label itemPricePurchaseLabel;
            System.Windows.Forms.Label transactionDateLabel;
            System.Windows.Forms.Label label1;
            this.itemIdComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.itemPriceMaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.itemPricePurchaseNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tStockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tStockDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tTransactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionDateFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.transactionDateToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            itemIdLabel = new System.Windows.Forms.Label();
            itemPriceMaxLabel = new System.Windows.Forms.Label();
            itemPricePurchaseLabel = new System.Windows.Forms.Label();
            transactionDateLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemPriceMaxNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPricePurchaseNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStockBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStockDataGridView)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // itemIdLabel
            // 
            itemIdLabel.AutoSize = true;
            itemIdLabel.Location = new System.Drawing.Point(27, 67);
            itemIdLabel.Name = "itemIdLabel";
            itemIdLabel.Size = new System.Drawing.Size(42, 13);
            itemIdLabel.TabIndex = 3;
            itemIdLabel.Text = "Item Id:";
            // 
            // itemIdComboBox
            // 
            this.itemIdComboBox.FormattingEnabled = true;
            this.itemIdComboBox.Location = new System.Drawing.Point(157, 67);
            this.itemIdComboBox.Name = "itemIdComboBox";
            this.itemIdComboBox.Size = new System.Drawing.Size(200, 21);
            this.itemIdComboBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(74, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // itemPriceMaxLabel
            // 
            itemPriceMaxLabel.AutoSize = true;
            itemPriceMaxLabel.Location = new System.Drawing.Point(27, 91);
            itemPriceMaxLabel.Name = "itemPriceMaxLabel";
            itemPriceMaxLabel.Size = new System.Drawing.Size(80, 13);
            itemPriceMaxLabel.TabIndex = 5;
            itemPriceMaxLabel.Text = "Item Price Max:";
            // 
            // itemPriceMaxNumericUpDown
            // 
            this.itemPriceMaxNumericUpDown.Location = new System.Drawing.Point(157, 94);
            this.itemPriceMaxNumericUpDown.Name = "itemPriceMaxNumericUpDown";
            this.itemPriceMaxNumericUpDown.Size = new System.Drawing.Size(199, 20);
            this.itemPriceMaxNumericUpDown.TabIndex = 6;
            // 
            // itemPricePurchaseLabel
            // 
            itemPricePurchaseLabel.AutoSize = true;
            itemPricePurchaseLabel.Location = new System.Drawing.Point(27, 117);
            itemPricePurchaseLabel.Name = "itemPricePurchaseLabel";
            itemPricePurchaseLabel.Size = new System.Drawing.Size(105, 13);
            itemPricePurchaseLabel.TabIndex = 7;
            itemPricePurchaseLabel.Text = "Item Price Purchase:";
            // 
            // itemPricePurchaseNumericUpDown
            // 
            this.itemPricePurchaseNumericUpDown.Location = new System.Drawing.Point(157, 118);
            this.itemPricePurchaseNumericUpDown.Name = "itemPricePurchaseNumericUpDown";
            this.itemPricePurchaseNumericUpDown.Size = new System.Drawing.Size(199, 20);
            this.itemPricePurchaseNumericUpDown.TabIndex = 8;
            // 
            // tStockBindingSource
            // 
            this.tStockBindingSource.DataSource = typeof(Inventori.Data.TStock);
            // 
            // tStockDataGridView
            // 
            this.tStockDataGridView.AutoGenerateColumns = false;
            this.tStockDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16});
            this.tStockDataGridView.DataSource = this.tStockBindingSource;
            this.tStockDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tStockDataGridView.Location = new System.Drawing.Point(0, 0);
            this.tStockDataGridView.Name = "tStockDataGridView";
            this.tStockDataGridView.Size = new System.Drawing.Size(451, 263);
            this.tStockDataGridView.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ModifiedBy";
            this.dataGridViewTextBoxColumn1.HeaderText = "ModifiedBy";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "StockIsAvailable";
            this.dataGridViewCheckBoxColumn1.HeaderText = "StockIsAvailable";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "StockBarcodeId";
            this.dataGridViewTextBoxColumn2.HeaderText = "StockBarcodeId";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "StockDateIn";
            this.dataGridViewTextBoxColumn3.HeaderText = "StockDateIn";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "StockDateOut";
            this.dataGridViewTextBoxColumn4.HeaderText = "StockDateOut";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ModifiedDate";
            this.dataGridViewTextBoxColumn5.HeaderText = "ModifiedDate";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "LocatonId";
            this.dataGridViewTextBoxColumn6.HeaderText = "LocatonId";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "StockPriceIn";
            this.dataGridViewTextBoxColumn7.HeaderText = "StockPriceIn";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "StockDesc2";
            this.dataGridViewTextBoxColumn8.HeaderText = "StockDesc2";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "StockDesc1";
            this.dataGridViewTextBoxColumn9.HeaderText = "StockDesc1";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "StockPriceOut";
            this.dataGridViewTextBoxColumn10.HeaderText = "StockPriceOut";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ItemId";
            this.dataGridViewTextBoxColumn11.HeaderText = "ItemId";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "StockId";
            this.dataGridViewTextBoxColumn12.HeaderText = "StockId";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "GudangId";
            this.dataGridViewTextBoxColumn13.HeaderText = "GudangId";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "StockOutBy";
            this.dataGridViewTextBoxColumn14.HeaderText = "StockOutBy";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "StockInBy";
            this.dataGridViewTextBoxColumn15.HeaderText = "StockInBy";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "StockDesc3";
            this.dataGridViewTextBoxColumn16.HeaderText = "StockDesc3";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(label1);
            this.splitContainer1.Panel1.Controls.Add(this.transactionDateToDateTimePicker);
            this.splitContainer1.Panel1.Controls.Add(transactionDateLabel);
            this.splitContainer1.Panel1.Controls.Add(this.transactionDateFromDateTimePicker);
            this.splitContainer1.Panel1.Controls.Add(itemIdLabel);
            this.splitContainer1.Panel1.Controls.Add(itemPricePurchaseLabel);
            this.splitContainer1.Panel1.Controls.Add(this.itemIdComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.itemPricePurchaseNumericUpDown);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(itemPriceMaxLabel);
            this.splitContainer1.Panel1.Controls.Add(this.itemPriceMaxNumericUpDown);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tStockDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(451, 469);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 10;
            // 
            // tTransactionBindingSource
            // 
            this.tTransactionBindingSource.DataSource = typeof(Inventori.Data.TTransaction);
            // 
            // transactionDateLabel
            // 
            transactionDateLabel.AutoSize = true;
            transactionDateLabel.Location = new System.Drawing.Point(27, 19);
            transactionDateLabel.Name = "transactionDateLabel";
            transactionDateLabel.Size = new System.Drawing.Size(92, 13);
            transactionDateLabel.TabIndex = 8;
            transactionDateLabel.Text = "Transaction Date:";
            // 
            // transactionDateFromDateTimePicker
            // 
            this.transactionDateFromDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tTransactionBindingSource, "TransactionDate", true));
            this.transactionDateFromDateTimePicker.Location = new System.Drawing.Point(157, 15);
            this.transactionDateFromDateTimePicker.Name = "transactionDateFromDateTimePicker";
            this.transactionDateFromDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.transactionDateFromDateTimePicker.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(27, 45);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(92, 13);
            label1.TabIndex = 10;
            label1.Text = "Transaction Date:";
            // 
            // transactionDateToDateTimePicker
            // 
            this.transactionDateToDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tTransactionBindingSource, "TransactionDate", true));
            this.transactionDateToDateTimePicker.Location = new System.Drawing.Point(157, 41);
            this.transactionDateToDateTimePicker.Name = "transactionDateToDateTimePicker";
            this.transactionDateToDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.transactionDateToDateTimePicker.TabIndex = 11;
            // 
            // FormChangePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 469);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormChangePrice";
            this.Text = "FormChangePrice";
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.itemPriceMaxNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPricePurchaseNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStockBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStockDataGridView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox itemIdComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown itemPriceMaxNumericUpDown;
        private System.Windows.Forms.NumericUpDown itemPricePurchaseNumericUpDown;
        private System.Windows.Forms.BindingSource tStockBindingSource;
        private System.Windows.Forms.DataGridView tStockDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DateTimePicker transactionDateToDateTimePicker;
        private System.Windows.Forms.BindingSource tTransactionBindingSource;
        private System.Windows.Forms.DateTimePicker transactionDateFromDateTimePicker;
    }
}