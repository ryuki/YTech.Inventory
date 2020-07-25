namespace Inventori.Cafe.Forms
{
    partial class FormMainForCafe
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
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 648;
            // 
            // lbl_LoginTime
            // 
            this.lbl_LoginTime.Size = new System.Drawing.Size(211, 15);
            this.lbl_LoginTime.Text = "Monday, April 16, 2007 6:55 PM";
            // 
            // FormMainForCafe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(992, 453);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormMainForCafe";
            this.Text = "Cafe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainForCafe_FormClosing);
            this.Load += new System.EventHandler(this.FormMainForCafe_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.dockPanel1, 0);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
