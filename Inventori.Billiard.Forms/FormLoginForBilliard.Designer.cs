namespace Inventori.Billiard.Forms
{
    partial class FormLoginForBilliard
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
            this.userPasswordTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.userPasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userPasswordTextBox_KeyDown);
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Inventori.Billiard.Forms.Properties.Resources.BilliardImage;
            // 
            // buttonOK
            // 
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // FormLoginForBilliard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(432, 180);
            this.Name = "FormLoginForBilliard";
            this.Shown += new System.EventHandler(this.FormLoginForBilliard_Shown);
            this.Load += new System.EventHandler(this.FormLoginForBilliard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
