namespace Inventori.PointOfSales.Forms
{
    partial class FormDateFilterReport
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combo_Param = new System.Windows.Forms.ComboBox();
            this.lbl_Param = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.dt_To = new System.Windows.Forms.DateTimePicker();
            this.dt_From = new System.Windows.Forms.DateTimePicker();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Location = new System.Drawing.Point(260, 127);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(15, 49);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 13);
            label1.TabIndex = 0;
            label1.Text = "Dari :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(15, 72);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(48, 13);
            label2.TabIndex = 1;
            label2.Text = "Sampai :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combo_Param);
            this.groupBox1.Controls.Add(this.lbl_Param);
            this.groupBox1.Controls.Add(this.button_OK);
            this.groupBox1.Controls.Add(this.dt_To);
            this.groupBox1.Controls.Add(this.dt_From);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 153);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Berdasar Tanggal";
            // 
            // combo_Param
            // 
            this.combo_Param.FormattingEnabled = true;
            this.combo_Param.Location = new System.Drawing.Point(101, 21);
            this.combo_Param.Name = "combo_Param";
            this.combo_Param.Size = new System.Drawing.Size(216, 21);
            this.combo_Param.TabIndex = 6;
            this.combo_Param.Visible = false;
            // 
            // lbl_Param
            // 
            this.lbl_Param.AutoSize = true;
            this.lbl_Param.Location = new System.Drawing.Point(13, 24);
            this.lbl_Param.Name = "lbl_Param";
            this.lbl_Param.Size = new System.Drawing.Size(61, 13);
            this.lbl_Param.TabIndex = 5;
            this.lbl_Param.Text = "Parameter :";
            this.lbl_Param.Visible = false;
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Image = global::Inventori.PointOfSales.Forms.Properties.Resources.OK;
            this.button_OK.Location = new System.Drawing.Point(80, 94);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(165, 49);
            this.button_OK.TabIndex = 4;
            this.button_OK.Text = "OK";
            this.button_OK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_OK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // dt_To
            // 
            this.dt_To.Location = new System.Drawing.Point(101, 68);
            this.dt_To.Name = "dt_To";
            this.dt_To.Size = new System.Drawing.Size(144, 20);
            this.dt_To.TabIndex = 3;
            // 
            // dt_From
            // 
            this.dt_From.Location = new System.Drawing.Point(101, 45);
            this.dt_From.Name = "dt_From";
            this.dt_From.Size = new System.Drawing.Size(144, 20);
            this.dt_From.TabIndex = 2;
            // 
            // FormDateFilterReport
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 159);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "FormDateFilterReport";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter Berdasar Tanggal";
            this.Load += new System.EventHandler(this.FormDateFilterReport_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_OK;
        public System.Windows.Forms.DateTimePicker dt_To;
        public System.Windows.Forms.DateTimePicker dt_From;
        public System.Windows.Forms.ComboBox combo_Param;
        public System.Windows.Forms.Label lbl_Param;
    }
}