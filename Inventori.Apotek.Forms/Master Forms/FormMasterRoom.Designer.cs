namespace Inventori.Apotek.Forms
{
    partial class FormMasterRoom
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
            System.Windows.Forms.Label roomComissionLabel;
            System.Windows.Forms.Label roomDescLabel;
            System.Windows.Forms.Label roomIdLabel;
            System.Windows.Forms.Label roomNameLabel;
            System.Windows.Forms.Label label1;
            this.roomComissionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.roomDescTextBox = new System.Windows.Forms.TextBox();
            this.roomIdTextBox = new System.Windows.Forms.TextBox();
            this.roomNameTextBox = new System.Windows.Forms.TextBox();
            roomComissionLabel = new System.Windows.Forms.Label();
            roomDescLabel = new System.Windows.Forms.Label();
            roomIdLabel = new System.Windows.Forms.Label();
            roomNameLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomComissionNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MRoom);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(roomComissionLabel);
            this.groupBox1.Controls.Add(this.roomComissionNumericUpDown);
            this.groupBox1.Controls.Add(roomDescLabel);
            this.groupBox1.Controls.Add(this.roomDescTextBox);
            this.groupBox1.Controls.Add(roomIdLabel);
            this.groupBox1.Controls.Add(this.roomIdTextBox);
            this.groupBox1.Controls.Add(roomNameLabel);
            this.groupBox1.Controls.Add(this.roomNameTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 202);
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.roomNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(roomNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.roomIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(roomIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.roomDescTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(roomDescLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.roomComissionNumericUpDown, 0);
            this.groupBox1.Controls.SetChildIndex(roomComissionLabel, 0);
            this.groupBox1.Controls.SetChildIndex(label1, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 202;
            // 
            // roomComissionLabel
            // 
            roomComissionLabel.AutoSize = true;
            roomComissionLabel.Location = new System.Drawing.Point(9, 77);
            roomComissionLabel.Name = "roomComissionLabel";
            roomComissionLabel.Size = new System.Drawing.Size(43, 13);
            roomComissionLabel.TabIndex = 1;
            roomComissionLabel.Text = "Komisi :";
            // 
            // roomDescLabel
            // 
            roomDescLabel.AutoSize = true;
            roomDescLabel.Location = new System.Drawing.Point(9, 106);
            roomDescLabel.Name = "roomDescLabel";
            roomDescLabel.Size = new System.Drawing.Size(68, 13);
            roomDescLabel.TabIndex = 3;
            roomDescLabel.Text = "Keterangan :";
            // 
            // roomIdLabel
            // 
            roomIdLabel.AutoSize = true;
            roomIdLabel.Location = new System.Drawing.Point(9, 28);
            roomIdLabel.Name = "roomIdLabel";
            roomIdLabel.Size = new System.Drawing.Size(85, 13);
            roomIdLabel.TabIndex = 5;
            roomIdLabel.Text = "Kode Ruangan :";
            // 
            // roomNameLabel
            // 
            roomNameLabel.AutoSize = true;
            roomNameLabel.Location = new System.Drawing.Point(9, 54);
            roomNameLabel.Name = "roomNameLabel";
            roomNameLabel.Size = new System.Drawing.Size(88, 13);
            roomNameLabel.TabIndex = 7;
            roomNameLabel.Text = "Nama Ruangan :";
            // 
            // roomComissionNumericUpDown
            // 
            this.roomComissionNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource_Master, "RoomComission", true));
            this.roomComissionNumericUpDown.Location = new System.Drawing.Point(103, 77);
            this.roomComissionNumericUpDown.Name = "roomComissionNumericUpDown";
            this.roomComissionNumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.roomComissionNumericUpDown.TabIndex = 2;
            // 
            // roomDescTextBox
            // 
            this.roomDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "RoomDesc", true));
            this.roomDescTextBox.Location = new System.Drawing.Point(103, 103);
            this.roomDescTextBox.Multiline = true;
            this.roomDescTextBox.Name = "roomDescTextBox";
            this.roomDescTextBox.Size = new System.Drawing.Size(207, 89);
            this.roomDescTextBox.TabIndex = 4;
            // 
            // roomIdTextBox
            // 
            this.roomIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "RoomId", true));
            this.roomIdTextBox.Location = new System.Drawing.Point(103, 25);
            this.roomIdTextBox.Name = "roomIdTextBox";
            this.roomIdTextBox.Size = new System.Drawing.Size(120, 20);
            this.roomIdTextBox.TabIndex = 6;
            // 
            // roomNameTextBox
            // 
            this.roomNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "RoomName", true));
            this.roomNameTextBox.Location = new System.Drawing.Point(103, 51);
            this.roomNameTextBox.Name = "roomNameTextBox";
            this.roomNameTextBox.Size = new System.Drawing.Size(120, 20);
            this.roomNameTextBox.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(165, 80);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(15, 13);
            label1.TabIndex = 9;
            label1.Text = "%";
            // 
            // FormMasterRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterRoom";
            this.TabText = "Master Ruangan";
            this.Text = "Master Ruangan";
            this.Load += new System.EventHandler(this.FormMasterRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roomComissionNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown roomComissionNumericUpDown;
        private System.Windows.Forms.TextBox roomDescTextBox;
        private System.Windows.Forms.TextBox roomIdTextBox;
        private System.Windows.Forms.TextBox roomNameTextBox;
    }
}