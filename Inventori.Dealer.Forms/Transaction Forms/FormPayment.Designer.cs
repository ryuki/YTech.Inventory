namespace Inventori.Dealer.Forms
{
    partial class FormPayment
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
            System.Windows.Forms.Label financeIdLabel;
            System.Windows.Forms.Label paymentAmmountLabel;
            System.Windows.Forms.Label paymentDateLabel;
            System.Windows.Forms.Label paymentDescLabel;
            System.Windows.Forms.Label transactionIdLabel;
            System.Windows.Forms.Label transactionPpnLabel;
            System.Windows.Forms.Label transactionByNameLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.financeIdComboBox = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tTransactionDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTransactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionByNameLabel1 = new System.Windows.Forms.Label();
            this.transactionPpnLabel1 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.transactionIdTextBox = new System.Windows.Forms.TextBox();
            this.paymentAmmountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.paymentDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.paymentDescTextBox = new System.Windows.Forms.TextBox();
            financeIdLabel = new System.Windows.Forms.Label();
            paymentAmmountLabel = new System.Windows.Forms.Label();
            paymentDateLabel = new System.Windows.Forms.Label();
            paymentDescLabel = new System.Windows.Forms.Label();
            transactionIdLabel = new System.Windows.Forms.Label();
            transactionPpnLabel = new System.Windows.Forms.Label();
            transactionByNameLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentAmmountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // financeIdLabel
            // 
            financeIdLabel.AutoSize = true;
            financeIdLabel.Location = new System.Drawing.Point(15, 6);
            financeIdLabel.Name = "financeIdLabel";
            financeIdLabel.Size = new System.Drawing.Size(51, 13);
            financeIdLabel.TabIndex = 0;
            financeIdLabel.Text = "Finance :";
            // 
            // paymentAmmountLabel
            // 
            paymentAmmountLabel.AutoSize = true;
            paymentAmmountLabel.Location = new System.Drawing.Point(10, 72);
            paymentAmmountLabel.Name = "paymentAmmountLabel";
            paymentAmmountLabel.Size = new System.Drawing.Size(101, 13);
            paymentAmmountLabel.TabIndex = 2;
            paymentAmmountLabel.Text = "Jumlah Yg Dibayar :";
            // 
            // paymentDateLabel
            // 
            paymentDateLabel.AutoSize = true;
            paymentDateLabel.Location = new System.Drawing.Point(10, 102);
            paymentDateLabel.Name = "paymentDateLabel";
            paymentDateLabel.Size = new System.Drawing.Size(90, 13);
            paymentDateLabel.TabIndex = 4;
            paymentDateLabel.Text = "Tgl Pembayaran :";
            // 
            // paymentDescLabel
            // 
            paymentDescLabel.AutoSize = true;
            paymentDescLabel.Location = new System.Drawing.Point(10, 127);
            paymentDescLabel.Name = "paymentDescLabel";
            paymentDescLabel.Size = new System.Drawing.Size(68, 13);
            paymentDescLabel.TabIndex = 6;
            paymentDescLabel.Text = "Keterangan :";
            // 
            // transactionIdLabel
            // 
            transactionIdLabel.AutoSize = true;
            transactionIdLabel.Location = new System.Drawing.Point(19, 297);
            transactionIdLabel.Name = "transactionIdLabel";
            transactionIdLabel.Size = new System.Drawing.Size(78, 13);
            transactionIdLabel.TabIndex = 10;
            transactionIdLabel.Text = "Transaction Id:";
            transactionIdLabel.Visible = false;
            // 
            // transactionPpnLabel
            // 
            transactionPpnLabel.AutoSize = true;
            transactionPpnLabel.Location = new System.Drawing.Point(10, 46);
            transactionPpnLabel.Name = "transactionPpnLabel";
            transactionPpnLabel.Size = new System.Drawing.Size(72, 13);
            transactionPpnLabel.TabIndex = 12;
            transactionPpnLabel.Text = "Sisa Piutang :";
            // 
            // transactionByNameLabel
            // 
            transactionByNameLabel.AutoSize = true;
            transactionByNameLabel.Location = new System.Drawing.Point(10, 23);
            transactionByNameLabel.Name = "transactionByNameLabel";
            transactionByNameLabel.Size = new System.Drawing.Size(133, 13);
            transactionByNameLabel.TabIndex = 13;
            transactionByNameLabel.Text = "Nama Pelanggan (STNK) :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(976, 460);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pembayaran";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(financeIdLabel);
            this.splitContainer1.Panel1.Controls.Add(this.financeIdComboBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(970, 441);
            this.splitContainer1.SplitterDistance = 33;
            this.splitContainer1.TabIndex = 12;
            // 
            // financeIdComboBox
            // 
            this.financeIdComboBox.FormattingEnabled = true;
            this.financeIdComboBox.Location = new System.Drawing.Point(119, 3);
            this.financeIdComboBox.Name = "financeIdComboBox";
            this.financeIdComboBox.Size = new System.Drawing.Size(200, 21);
            this.financeIdComboBox.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.tTransactionDataGridView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(transactionByNameLabel);
            this.splitContainer2.Panel2.Controls.Add(this.transactionByNameLabel1);
            this.splitContainer2.Panel2.Controls.Add(transactionPpnLabel);
            this.splitContainer2.Panel2.Controls.Add(this.transactionPpnLabel1);
            this.splitContainer2.Panel2.Controls.Add(this.SaveButton);
            this.splitContainer2.Panel2.Controls.Add(paymentAmmountLabel);
            this.splitContainer2.Panel2.Controls.Add(this.transactionIdTextBox);
            this.splitContainer2.Panel2.Controls.Add(this.paymentAmmountNumericUpDown);
            this.splitContainer2.Panel2.Controls.Add(transactionIdLabel);
            this.splitContainer2.Panel2.Controls.Add(paymentDateLabel);
            this.splitContainer2.Panel2.Controls.Add(this.paymentDateDateTimePicker);
            this.splitContainer2.Panel2.Controls.Add(paymentDescLabel);
            this.splitContainer2.Panel2.Controls.Add(this.paymentDescTextBox);
            this.splitContainer2.Size = new System.Drawing.Size(970, 404);
            this.splitContainer2.SplitterDistance = 652;
            this.splitContainer2.TabIndex = 0;
            // 
            // tTransactionDataGridView
            // 
            this.tTransactionDataGridView.AutoGenerateColumns = false;
            this.tTransactionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn25,
            this.Column1,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn16});
            this.tTransactionDataGridView.DataSource = this.tTransactionBindingSource;
            this.tTransactionDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tTransactionDataGridView.Location = new System.Drawing.Point(0, 0);
            this.tTransactionDataGridView.Name = "tTransactionDataGridView";
            this.tTransactionDataGridView.Size = new System.Drawing.Size(652, 404);
            this.tTransactionDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TransactionFactur";
            this.dataGridViewTextBoxColumn5.HeaderText = "No Faktur";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "TransactionDate";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            this.dataGridViewTextBoxColumn25.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn25.HeaderText = "Tgl";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "TransactionByName";
            this.Column1.HeaderText = "Nama Pelanggan (STNK)";
            this.Column1.Name = "Column1";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TransactionPaid";
            dataGridViewCellStyle2.Format = "N";
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn10.HeaderText = "Uang Muka";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TransactionPotongan";
            dataGridViewCellStyle3.Format = "N";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "Subsidi";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "TransactionGrandTotal";
            dataGridViewCellStyle4.Format = "N";
            this.dataGridViewTextBoxColumn24.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn24.HeaderText = "Grand Total";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "TransactionSisa";
            dataGridViewCellStyle5.Format = "N";
            this.dataGridViewTextBoxColumn26.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn26.HeaderText = "Piutang";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "TransactionPpn";
            dataGridViewCellStyle6.Format = "N";
            this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn16.HeaderText = "Sisa Piutang";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // tTransactionBindingSource
            // 
            this.tTransactionBindingSource.DataSource = typeof(Inventori.Data.TTransaction);
            // 
            // transactionByNameLabel1
            // 
            this.transactionByNameLabel1.AutoSize = true;
            this.transactionByNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tTransactionBindingSource, "TransactionByName", true));
            this.transactionByNameLabel1.Location = new System.Drawing.Point(149, 23);
            this.transactionByNameLabel1.Name = "transactionByNameLabel1";
            this.transactionByNameLabel1.Size = new System.Drawing.Size(58, 13);
            this.transactionByNameLabel1.TabIndex = 14;
            this.transactionByNameLabel1.Text = "Pelanggan";
            // 
            // transactionPpnLabel1
            // 
            this.transactionPpnLabel1.AutoSize = true;
            this.transactionPpnLabel1.Location = new System.Drawing.Point(149, 46);
            this.transactionPpnLabel1.Name = "transactionPpnLabel1";
            this.transactionPpnLabel1.Size = new System.Drawing.Size(27, 13);
            this.transactionPpnLabel1.TabIndex = 13;
            this.transactionPpnLabel1.Text = "Sisa";
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Image = global::Inventori.Dealer.Forms.Properties.Resources.save;
            this.SaveButton.Location = new System.Drawing.Point(85, 211);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(122, 44);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Simpan";
            this.SaveButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // transactionIdTextBox
            // 
            this.transactionIdTextBox.Location = new System.Drawing.Point(123, 294);
            this.transactionIdTextBox.Name = "transactionIdTextBox";
            this.transactionIdTextBox.Size = new System.Drawing.Size(148, 20);
            this.transactionIdTextBox.TabIndex = 11;
            this.transactionIdTextBox.Visible = false;
            // 
            // paymentAmmountNumericUpDown
            // 
            this.paymentAmmountNumericUpDown.Location = new System.Drawing.Point(152, 72);
            this.paymentAmmountNumericUpDown.Name = "paymentAmmountNumericUpDown";
            this.paymentAmmountNumericUpDown.Size = new System.Drawing.Size(148, 20);
            this.paymentAmmountNumericUpDown.TabIndex = 3;
            // 
            // paymentDateDateTimePicker
            // 
            this.paymentDateDateTimePicker.Location = new System.Drawing.Point(152, 98);
            this.paymentDateDateTimePicker.Name = "paymentDateDateTimePicker";
            this.paymentDateDateTimePicker.Size = new System.Drawing.Size(148, 20);
            this.paymentDateDateTimePicker.TabIndex = 5;
            // 
            // paymentDescTextBox
            // 
            this.paymentDescTextBox.Location = new System.Drawing.Point(152, 124);
            this.paymentDescTextBox.Multiline = true;
            this.paymentDescTextBox.Name = "paymentDescTextBox";
            this.paymentDescTextBox.Size = new System.Drawing.Size(148, 81);
            this.paymentDescTextBox.TabIndex = 7;
            // 
            // FormPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 460);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormPayment";
            this.TabText = "Pembayaran";
            this.Text = "Pembayaran";
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTransactionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentAmmountNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox financeIdComboBox;
        private System.Windows.Forms.NumericUpDown paymentAmmountNumericUpDown;
        private System.Windows.Forms.DateTimePicker paymentDateDateTimePicker;
        private System.Windows.Forms.TextBox paymentDescTextBox;
        private System.Windows.Forms.TextBox transactionIdTextBox;
        private System.Windows.Forms.DataGridView tTransactionDataGridView;
        private System.Windows.Forms.BindingSource tTransactionBindingSource;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label transactionPpnLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.Label transactionByNameLabel1;
    }
}