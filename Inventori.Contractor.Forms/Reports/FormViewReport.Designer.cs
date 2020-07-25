namespace Inventori.Contractor.Forms
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.transactionByLabel = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_Reset = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.dt_To = new System.Windows.Forms.DateTimePicker();
            this.dt_From = new System.Windows.Forms.DateTimePicker();
            this.transactionByComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.checkedListBox_Parameter = new System.Windows.Forms.CheckedListBox();
            this.mSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mSettingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(284, 66);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(48, 13);
            label2.TabIndex = 6;
            label2.Text = "Sampai :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(284, 43);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 13);
            label1.TabIndex = 5;
            label1.Text = "Dari :";
            // 
            // transactionByLabel
            // 
            this.transactionByLabel.AutoSize = true;
            this.transactionByLabel.Location = new System.Drawing.Point(283, 15);
            this.transactionByLabel.Name = "transactionByLabel";
            this.transactionByLabel.Size = new System.Drawing.Size(61, 13);
            this.transactionByLabel.TabIndex = 0;
            this.transactionByLabel.Text = "Parameter :";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapCollapsed = true;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowDocumentMapButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(725, 285);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.reportViewer1_ReportRefresh);
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
            this.splitContainer1.Panel1.Controls.Add(this.button_Reset);
            this.splitContainer1.Panel1.Controls.Add(this.button_OK);
            this.splitContainer1.Panel1.Controls.Add(this.dt_To);
            this.splitContainer1.Panel1.Controls.Add(this.dt_From);
            this.splitContainer1.Panel1.Controls.Add(label2);
            this.splitContainer1.Panel1.Controls.Add(label1);
            this.splitContainer1.Panel1.Controls.Add(this.transactionByLabel);
            this.splitContainer1.Panel1.Controls.Add(this.transactionByComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(725, 417);
            this.splitContainer1.SplitterDistance = 128;
            this.splitContainer1.TabIndex = 7;
            // 
            // button_Reset
            // 
            this.button_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Reset.Image = global::Inventori.Contractor.Forms.Properties.Resources.Refresh;
            this.button_Reset.Location = new System.Drawing.Point(316, 88);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(112, 35);
            this.button_Reset.TabIndex = 11;
            this.button_Reset.Text = "Reset";
            this.button_Reset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Reset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Visible = false;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // button_OK
            // 
            this.button_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Image = global::Inventori.Contractor.Forms.Properties.Resources._in;
            this.button_OK.Location = new System.Drawing.Point(451, 88);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(112, 35);
            this.button_OK.TabIndex = 9;
            this.button_OK.Text = "Lihat";
            this.button_OK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_OK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // dt_To
            // 
            this.dt_To.Location = new System.Drawing.Point(400, 62);
            this.dt_To.Name = "dt_To";
            this.dt_To.Size = new System.Drawing.Size(144, 20);
            this.dt_To.TabIndex = 8;
            // 
            // dt_From
            // 
            this.dt_From.Location = new System.Drawing.Point(400, 39);
            this.dt_From.Name = "dt_From";
            this.dt_From.Size = new System.Drawing.Size(144, 20);
            this.dt_From.TabIndex = 7;
            // 
            // transactionByComboBox
            // 
            this.transactionByComboBox.DisplayMember = "SupplierId";
            this.transactionByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transactionByComboBox.FormattingEnabled = true;
            this.transactionByComboBox.Location = new System.Drawing.Point(400, 12);
            this.transactionByComboBox.Name = "transactionByComboBox";
            this.transactionByComboBox.Size = new System.Drawing.Size(260, 21);
            this.transactionByComboBox.TabIndex = 1;
            this.transactionByComboBox.ValueMember = "SupplierId";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vScrollBar1);
            this.groupBox1.Controls.Add(this.checkedListBox_Parameter);
            this.groupBox1.Location = new System.Drawing.Point(7, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 114);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supplier";
            this.groupBox1.Visible = false;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(268, 16);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(16, 139);
            this.vScrollBar1.TabIndex = 1;
            // 
            // checkedListBox_Parameter
            // 
            this.checkedListBox_Parameter.CheckOnClick = true;
            this.checkedListBox_Parameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_Parameter.FormattingEnabled = true;
            this.checkedListBox_Parameter.Location = new System.Drawing.Point(3, 16);
            this.checkedListBox_Parameter.MultiColumn = true;
            this.checkedListBox_Parameter.Name = "checkedListBox_Parameter";
            this.checkedListBox_Parameter.Size = new System.Drawing.Size(265, 94);
            this.checkedListBox_Parameter.TabIndex = 0;
            // 
            // mSettingBindingSource
            // 
            this.mSettingBindingSource.DataSource = typeof(Inventori.Data.MSetting);
            // 
            // FormViewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(725, 417);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormViewReport";
            this.TabText = "Laporan";
            this.Text = "Laporan";
            this.Load += new System.EventHandler(this.FormViewReport_Load);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mSettingBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox transactionByComboBox;
        private System.Windows.Forms.BindingSource mSettingBindingSource;
        private System.Windows.Forms.Button button_OK;
        public System.Windows.Forms.DateTimePicker dt_To;
        public System.Windows.Forms.DateTimePicker dt_From;
        private System.Windows.Forms.Label transactionByLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.CheckedListBox checkedListBox_Parameter;
        private System.Windows.Forms.Button button_Reset;
    }
}
