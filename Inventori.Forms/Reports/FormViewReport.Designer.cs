namespace Inventori.Forms
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lbl_TempReport = new System.Windows.Forms.Label();
            this.mSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mSettingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(510, 417);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.reportViewer1_ReportRefresh);
            // 
            // lbl_TempReport
            // 
            this.lbl_TempReport.AutoSize = true;
            this.lbl_TempReport.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mSettingBindingSource, "AutoPrintSales", true));
            this.lbl_TempReport.Location = new System.Drawing.Point(94, 76);
            this.lbl_TempReport.Name = "lbl_TempReport";
            this.lbl_TempReport.Size = new System.Drawing.Size(82, 13);
            this.lbl_TempReport.TabIndex = 2;
            this.lbl_TempReport.Text = "lbl_TempReport";
            this.lbl_TempReport.Visible = false;
            // 
            // mSettingBindingSource
            // 
            this.mSettingBindingSource.DataSource = typeof(Inventori.Data.MSetting);
            // 
            // FormViewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(510, 417);
            this.Controls.Add(this.lbl_TempReport);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormViewReport";
            this.TabText = "Laporan";
            this.Text = "Laporan";
            this.Load += new System.EventHandler(this.FormViewReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mSettingBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbl_TempReport;
        public System.Windows.Forms.BindingSource mSettingBindingSource;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
