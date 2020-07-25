namespace Inventori.Contractor.Forms
{
    partial class FormPeriodFilterReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Month = new System.Windows.Forms.ComboBox();
            this.numericUpDown_Year = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.combo_Param = new System.Windows.Forms.ComboBox();
            this.lbl_Param = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_MonthTo = new System.Windows.Forms.ComboBox();
            this.numericUpDown_YearTo = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_YearTo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Location = new System.Drawing.Point(260, 127);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_MonthTo);
            this.groupBox1.Controls.Add(this.numericUpDown_YearTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.combo_Param);
            this.groupBox1.Controls.Add(this.lbl_Param);
            this.groupBox1.Controls.Add(this.comboBox_Month);
            this.groupBox1.Controls.Add(this.numericUpDown_Year);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_OK);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Berdasar Periode";
            // 
            // comboBox_Month
            // 
            this.comboBox_Month.FormattingEnabled = true;
            this.comboBox_Month.Location = new System.Drawing.Point(105, 48);
            this.comboBox_Month.Name = "comboBox_Month";
            this.comboBox_Month.Size = new System.Drawing.Size(138, 21);
            this.comboBox_Month.TabIndex = 7;
            // 
            // numericUpDown_Year
            // 
            this.numericUpDown_Year.Location = new System.Drawing.Point(249, 49);
            this.numericUpDown_Year.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDown_Year.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numericUpDown_Year.Name = "numericUpDown_Year";
            this.numericUpDown_Year.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown_Year.TabIndex = 9;
            this.numericUpDown_Year.Value = new decimal(new int[] {
            2005,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Dari Periode :";
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Image = global::Inventori.Contractor.Forms.Properties.Resources.OK;
            this.button_OK.Location = new System.Drawing.Point(105, 109);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(165, 49);
            this.button_OK.TabIndex = 4;
            this.button_OK.Text = "OK";
            this.button_OK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_OK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // combo_Param
            // 
            this.combo_Param.FormattingEnabled = true;
            this.combo_Param.Location = new System.Drawing.Point(105, 21);
            this.combo_Param.Name = "combo_Param";
            this.combo_Param.Size = new System.Drawing.Size(216, 21);
            this.combo_Param.TabIndex = 11;
            this.combo_Param.Visible = false;
            // 
            // lbl_Param
            // 
            this.lbl_Param.AutoSize = true;
            this.lbl_Param.Location = new System.Drawing.Point(17, 24);
            this.lbl_Param.Name = "lbl_Param";
            this.lbl_Param.Size = new System.Drawing.Size(61, 13);
            this.lbl_Param.TabIndex = 10;
            this.lbl_Param.Text = "Parameter :";
            this.lbl_Param.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "sampai";
            // 
            // comboBox_MonthTo
            // 
            this.comboBox_MonthTo.FormattingEnabled = true;
            this.comboBox_MonthTo.Location = new System.Drawing.Point(105, 74);
            this.comboBox_MonthTo.Name = "comboBox_MonthTo";
            this.comboBox_MonthTo.Size = new System.Drawing.Size(138, 21);
            this.comboBox_MonthTo.TabIndex = 13;
            // 
            // numericUpDown_YearTo
            // 
            this.numericUpDown_YearTo.Location = new System.Drawing.Point(249, 75);
            this.numericUpDown_YearTo.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDown_YearTo.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numericUpDown_YearTo.Name = "numericUpDown_YearTo";
            this.numericUpDown_YearTo.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown_YearTo.TabIndex = 14;
            this.numericUpDown_YearTo.Value = new decimal(new int[] {
            2005,
            0,
            0,
            0});
            // 
            // FormPeriodFilterReport
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 172);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "FormPeriodFilterReport";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter Berdasar Periode";
            this.Load += new System.EventHandler(this.FormDateFilterReport_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_YearTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_OK;
        public System.Windows.Forms.ComboBox comboBox_Month;
        public System.Windows.Forms.NumericUpDown numericUpDown_Year;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBox_MonthTo;
        public System.Windows.Forms.NumericUpDown numericUpDown_YearTo;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox combo_Param;
        public System.Windows.Forms.Label lbl_Param;
    }
}