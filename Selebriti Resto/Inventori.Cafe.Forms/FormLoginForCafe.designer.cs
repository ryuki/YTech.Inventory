namespace Inventori.Cafe.Forms
{
    partial class FormLoginForCafe
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // userPasswordTextBox
            // 
            this.userPasswordTextBox.TabIndex = 1;
            this.userPasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userPasswordTextBox_KeyDown);
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Inventori.Cafe.Forms.Properties.Resources.restaurant_cafe;
            // 
            // buttonOK
            // 
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // FormLoginForCafe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(432, 180);
            this.Name = "FormLoginForCafe";
            this.Text = "Cafe";
            this.Shown += new System.EventHandler(this.FormLoginForCafe_Shown);
            this.Load += new System.EventHandler(this.FormLoginForCafe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
