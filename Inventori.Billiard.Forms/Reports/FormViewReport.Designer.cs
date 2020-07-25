namespace Inventori.Billiard.Forms
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
            this.lbl_Param3 = new System.Windows.Forms.Label();
            this.lbl_Param2 = new System.Windows.Forms.Label();
            this.lbl_Param1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mSettingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapCollapsed = true;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowDocumentMapButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(510, 417);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.reportViewer1_ReportRefresh);
            // 
            // lbl_TempReport
            // 
            this.lbl_TempReport.AutoSize = true;
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
            // lbl_Param3
            // 
            this.lbl_Param3.AutoSize = true;
            this.lbl_Param3.Location = new System.Drawing.Point(233, 192);
            this.lbl_Param3.Name = "lbl_Param3";
            this.lbl_Param3.Size = new System.Drawing.Size(59, 13);
            this.lbl_Param3.TabIndex = 8;
            this.lbl_Param3.Text = "lbl_Param3";
            this.lbl_Param3.Visible = false;
            // 
            // lbl_Param2
            // 
            this.lbl_Param2.AutoSize = true;
            this.lbl_Param2.Location = new System.Drawing.Point(233, 164);
            this.lbl_Param2.Name = "lbl_Param2";
            this.lbl_Param2.Size = new System.Drawing.Size(59, 13);
            this.lbl_Param2.TabIndex = 7;
            this.lbl_Param2.Text = "lbl_Param2";
            this.lbl_Param2.Visible = false;
            // 
            // lbl_Param1
            // 
            this.lbl_Param1.AutoSize = true;
            this.lbl_Param1.Location = new System.Drawing.Point(218, 240);
            this.lbl_Param1.Name = "lbl_Param1";
            this.lbl_Param1.Size = new System.Drawing.Size(59, 13);
            this.lbl_Param1.TabIndex = 6;
            this.lbl_Param1.Text = "lbl_Param1";
            this.lbl_Param1.Visible = false;
            // 
            // FormViewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(510, 417);
            this.Controls.Add(this.lbl_Param3);
            this.Controls.Add(this.lbl_Param2);
            this.Controls.Add(this.lbl_Param1);
            this.Controls.Add(this.lbl_TempReport);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormViewReport";
            this.TabText = "Laporan";
            this.Text = "Laporan";
            this.Load += new System.EventHandler(this.FormViewReport_Load);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.Controls.SetChildIndex(this.lbl_TempReport, 0);
            this.Controls.SetChildIndex(this.lbl_Param1, 0);
            this.Controls.SetChildIndex(this.lbl_Param2, 0);
            this.Controls.SetChildIndex(this.lbl_Param3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.mSettingBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.Label lbl_TempReport;
        private System.Windows.Forms.BindingSource mSettingBindingSource;
        public System.Windows.Forms.Label lbl_Param3;
        public System.Windows.Forms.Label lbl_Param2;
        public System.Windows.Forms.Label lbl_Param1;
    }
}
