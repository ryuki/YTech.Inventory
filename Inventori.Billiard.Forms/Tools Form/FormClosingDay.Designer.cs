namespace Inventori.Billiard.Forms
{
    partial class FormClosingDay
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dt_ClosingTo = new System.Windows.Forms.DateTimePicker();
            this.dt_ClosingFrom = new System.Windows.Forms.DateTimePicker();
            this.tRekapTransactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbl_Loading = new System.Windows.Forms.Label();
            this.pb_Loading = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tRekapTransactionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Image = global::Inventori.Billiard.Forms.Properties.Resources.CloseBook;
            this.buttonOK.Location = new System.Drawing.Point(337, 10);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(160, 39);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "Tutup Hari";
            this.buttonOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dt_ClosingTo);
            this.groupBox1.Controls.Add(this.dt_ClosingFrom);
            this.groupBox1.Controls.Add(this.buttonOK);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 69);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tutup Hari";
            // 
            // dt_ClosingTo
            // 
            this.dt_ClosingTo.Enabled = false;
            this.dt_ClosingTo.Location = new System.Drawing.Point(182, 19);
            this.dt_ClosingTo.Name = "dt_ClosingTo";
            this.dt_ClosingTo.Size = new System.Drawing.Size(149, 20);
            this.dt_ClosingTo.TabIndex = 22;
            // 
            // dt_ClosingFrom
            // 
            this.dt_ClosingFrom.Enabled = false;
            this.dt_ClosingFrom.Location = new System.Drawing.Point(6, 19);
            this.dt_ClosingFrom.Name = "dt_ClosingFrom";
            this.dt_ClosingFrom.Size = new System.Drawing.Size(149, 20);
            this.dt_ClosingFrom.TabIndex = 21;
            // 
            // tRekapTransactionBindingSource
            // 
            this.tRekapTransactionBindingSource.DataSource = typeof(Inventori.Data.TRekapTransaction);
            // 
            // lbl_Loading
            // 
            this.lbl_Loading.AutoSize = true;
            this.lbl_Loading.Location = new System.Drawing.Point(187, 96);
            this.lbl_Loading.Name = "lbl_Loading";
            this.lbl_Loading.Size = new System.Drawing.Size(154, 26);
            this.lbl_Loading.TabIndex = 13;
            this.lbl_Loading.Text = "Tutup hari sedang dilakukan ...\r\nSilahkan Tunggu ...";
            this.lbl_Loading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Loading.Visible = false;
            // 
            // pb_Loading
            // 
            this.pb_Loading.Location = new System.Drawing.Point(73, 75);
            this.pb_Loading.Name = "pb_Loading";
            this.pb_Loading.Size = new System.Drawing.Size(402, 18);
            this.pb_Loading.TabIndex = 12;
            this.pb_Loading.Visible = false;
            // 
            // FormClosingDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(543, 137);
            this.Controls.Add(this.lbl_Loading);
            this.Controls.Add(this.pb_Loading);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormClosingDay";
            this.TabText = "Tutup Hari";
            this.Text = "Tutup Hari";
            this.Load += new System.EventHandler(this.FormClosingDay_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.Controls.SetChildIndex(this.pb_Loading, 0);
            this.Controls.SetChildIndex(this.lbl_Loading, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tRekapTransactionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource tRekapTransactionBindingSource;
        private System.Windows.Forms.Label lbl_Loading;
        private System.Windows.Forms.ProgressBar pb_Loading;
        private System.Windows.Forms.DateTimePicker dt_ClosingTo;
        private System.Windows.Forms.DateTimePicker dt_ClosingFrom;
    }
}
