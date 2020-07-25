namespace Inventori.Billiard.Forms
{
    partial class FormDiscountGlobal
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
            System.Windows.Forms.Label discDayLabel;
            System.Windows.Forms.Label discTimeHourFromLabel;
            System.Windows.Forms.Label discTimeHourToLabel;
            System.Windows.Forms.Label discTimeMinFromLabel;
            System.Windows.Forms.Label discTimeMinToLabel;
            System.Windows.Forms.Label discLabel;
            System.Windows.Forms.Label label1;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.discTextBox = new System.Windows.Forms.TextBox();
            this.discTimeMinToNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.discTimeMinFromNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.discTimeHourToNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.discTimeHourFromNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.discDayComboBox = new System.Windows.Forms.ComboBox();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            discDayLabel = new System.Windows.Forms.Label();
            discTimeHourFromLabel = new System.Windows.Forms.Label();
            discTimeHourToLabel = new System.Windows.Forms.Label();
            discTimeMinFromLabel = new System.Windows.Forms.Label();
            discTimeMinToLabel = new System.Windows.Forms.Label();
            discLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discTimeMinToNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discTimeMinFromNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discTimeHourToNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discTimeHourFromNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // discDayLabel
            // 
            discDayLabel.AutoSize = true;
            discDayLabel.Location = new System.Drawing.Point(31, 33);
            discDayLabel.Name = "discDayLabel";
            discDayLabel.Size = new System.Drawing.Size(29, 13);
            discDayLabel.TabIndex = 0;
            discDayLabel.Text = "Hari:";
            // 
            // discTimeHourFromLabel
            // 
            discTimeHourFromLabel.AutoSize = true;
            discTimeHourFromLabel.Location = new System.Drawing.Point(31, 59);
            discTimeHourFromLabel.Name = "discTimeHourFromLabel";
            discTimeHourFromLabel.Size = new System.Drawing.Size(54, 13);
            discTimeHourFromLabel.TabIndex = 2;
            discTimeHourFromLabel.Text = "Mulai jam:";
            // 
            // discTimeHourToLabel
            // 
            discTimeHourToLabel.AutoSize = true;
            discTimeHourToLabel.Location = new System.Drawing.Point(31, 85);
            discTimeHourToLabel.Name = "discTimeHourToLabel";
            discTimeHourToLabel.Size = new System.Drawing.Size(64, 13);
            discTimeHourToLabel.TabIndex = 4;
            discTimeHourToLabel.Text = "Sampai jam:";
            // 
            // discTimeMinFromLabel
            // 
            discTimeMinFromLabel.AutoSize = true;
            discTimeMinFromLabel.Location = new System.Drawing.Point(160, 59);
            discTimeMinFromLabel.Name = "discTimeMinFromLabel";
            discTimeMinFromLabel.Size = new System.Drawing.Size(10, 13);
            discTimeMinFromLabel.TabIndex = 6;
            discTimeMinFromLabel.Text = ":";
            // 
            // discTimeMinToLabel
            // 
            discTimeMinToLabel.AutoSize = true;
            discTimeMinToLabel.Location = new System.Drawing.Point(160, 87);
            discTimeMinToLabel.Name = "discTimeMinToLabel";
            discTimeMinToLabel.Size = new System.Drawing.Size(10, 13);
            discTimeMinToLabel.TabIndex = 8;
            discTimeMinToLabel.Text = ":";
            // 
            // discLabel
            // 
            discLabel.AutoSize = true;
            discLabel.Location = new System.Drawing.Point(31, 112);
            discLabel.Name = "discLabel";
            discLabel.Size = new System.Drawing.Size(43, 13);
            discLabel.TabIndex = 10;
            discLabel.Text = "Diskon:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(158, 112);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(15, 13);
            label1.TabIndex = 12;
            label1.Text = "%";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(discLabel);
            this.groupBox1.Controls.Add(this.discTextBox);
            this.groupBox1.Controls.Add(discTimeMinToLabel);
            this.groupBox1.Controls.Add(this.discTimeMinToNumericUpDown);
            this.groupBox1.Controls.Add(discTimeMinFromLabel);
            this.groupBox1.Controls.Add(this.discTimeMinFromNumericUpDown);
            this.groupBox1.Controls.Add(discTimeHourToLabel);
            this.groupBox1.Controls.Add(this.discTimeHourToNumericUpDown);
            this.groupBox1.Controls.Add(discTimeHourFromLabel);
            this.groupBox1.Controls.Add(this.discTimeHourFromNumericUpDown);
            this.groupBox1.Controls.Add(discDayLabel);
            this.groupBox1.Controls.Add(this.discDayComboBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Diskon Global";
            // 
            // discTextBox
            // 
            this.discTextBox.Location = new System.Drawing.Point(116, 109);
            this.discTextBox.Name = "discTextBox";
            this.discTextBox.Size = new System.Drawing.Size(41, 20);
            this.discTextBox.TabIndex = 11;
            this.discTextBox.Text = "0";
            this.discTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // discTimeMinToNumericUpDown
            // 
            this.discTimeMinToNumericUpDown.Location = new System.Drawing.Point(172, 85);
            this.discTimeMinToNumericUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.discTimeMinToNumericUpDown.Name = "discTimeMinToNumericUpDown";
            this.discTimeMinToNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.discTimeMinToNumericUpDown.TabIndex = 9;
            this.discTimeMinToNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // discTimeMinFromNumericUpDown
            // 
            this.discTimeMinFromNumericUpDown.Location = new System.Drawing.Point(172, 57);
            this.discTimeMinFromNumericUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.discTimeMinFromNumericUpDown.Name = "discTimeMinFromNumericUpDown";
            this.discTimeMinFromNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.discTimeMinFromNumericUpDown.TabIndex = 7;
            this.discTimeMinFromNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // discTimeHourToNumericUpDown
            // 
            this.discTimeHourToNumericUpDown.Location = new System.Drawing.Point(116, 83);
            this.discTimeHourToNumericUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.discTimeHourToNumericUpDown.Name = "discTimeHourToNumericUpDown";
            this.discTimeHourToNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.discTimeHourToNumericUpDown.TabIndex = 5;
            this.discTimeHourToNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // discTimeHourFromNumericUpDown
            // 
            this.discTimeHourFromNumericUpDown.Location = new System.Drawing.Point(116, 57);
            this.discTimeHourFromNumericUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.discTimeHourFromNumericUpDown.Name = "discTimeHourFromNumericUpDown";
            this.discTimeHourFromNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.discTimeHourFromNumericUpDown.TabIndex = 3;
            this.discTimeHourFromNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // discDayComboBox
            // 
            this.discDayComboBox.FormattingEnabled = true;
            this.discDayComboBox.Location = new System.Drawing.Point(116, 30);
            this.discDayComboBox.Name = "discDayComboBox";
            this.discDayComboBox.Size = new System.Drawing.Size(121, 21);
            this.discDayComboBox.TabIndex = 1;
            this.discDayComboBox.SelectedIndexChanged += new System.EventHandler(this.discDayComboBox_SelectedIndexChanged);
            // 
            // button16
            // 
            this.button16.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button16.Image = global::Inventori.Billiard.Forms.Properties.Resources.delete16;
            this.button16.Location = new System.Drawing.Point(65, 152);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(90, 32);
            this.button16.TabIndex = 24;
            this.button16.Text = "Tutup";
            this.button16.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Image = global::Inventori.Billiard.Forms.Properties.Resources.save;
            this.button15.Location = new System.Drawing.Point(161, 151);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(90, 33);
            this.button15.TabIndex = 23;
            this.button15.Text = "Simpan";
            this.button15.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // FormDiscountGlobal
            // 
            this.AcceptButton = this.button15;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button16;
            this.ClientSize = new System.Drawing.Size(316, 204);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button15);
            this.Name = "FormDiscountGlobal";
            this.TabText = "Diskon Global";
            this.Text = "Diskon Global";
            this.Shown += new System.EventHandler(this.FormDiscountGlobal_Shown);
            this.Controls.SetChildIndex(this.button15, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.button16, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discTimeMinToNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discTimeMinFromNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discTimeHourToNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discTimeHourFromNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox discTextBox;
        private System.Windows.Forms.NumericUpDown discTimeMinToNumericUpDown;
        private System.Windows.Forms.NumericUpDown discTimeMinFromNumericUpDown;
        private System.Windows.Forms.NumericUpDown discTimeHourToNumericUpDown;
        private System.Windows.Forms.NumericUpDown discTimeHourFromNumericUpDown;
        private System.Windows.Forms.ComboBox discDayComboBox;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
    }
}