namespace Inventori.GrosirMitra.Forms
{
    partial class FormMasterTypeItem
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
            System.Windows.Forms.Label itemTypeIdLabel;
            System.Windows.Forms.Label itemTypeNameLabel;
            this.itemTypeIdLabel1 = new System.Windows.Forms.Label();
            this.itemTypeNameTextBox = new System.Windows.Forms.TextBox();
            itemTypeIdLabel = new System.Windows.Forms.Label();
            itemTypeNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MItemType);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(itemTypeIdLabel);
            this.groupBox1.Controls.Add(this.itemTypeIdLabel1);
            this.groupBox1.Controls.Add(itemTypeNameLabel);
            this.groupBox1.Controls.Add(this.itemTypeNameTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 100);
            this.groupBox1.Text = "Master Detail Tipe Barang";
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemTypeNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemTypeNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemTypeIdLabel1, 0);
            this.groupBox1.Controls.SetChildIndex(itemTypeIdLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 100;
            // 
            // itemTypeIdLabel
            // 
            itemTypeIdLabel.AutoSize = true;
            itemTypeIdLabel.Location = new System.Drawing.Point(33, 27);
            itemTypeIdLabel.Name = "itemTypeIdLabel";
            itemTypeIdLabel.Size = new System.Drawing.Size(99, 13);
            itemTypeIdLabel.TabIndex = 1;
            itemTypeIdLabel.Text = "Kode Tipe Barang :";
            // 
            // itemTypeNameLabel
            // 
            itemTypeNameLabel.AutoSize = true;
            itemTypeNameLabel.Location = new System.Drawing.Point(33, 56);
            itemTypeNameLabel.Name = "itemTypeNameLabel";
            itemTypeNameLabel.Size = new System.Drawing.Size(102, 13);
            itemTypeNameLabel.TabIndex = 3;
            itemTypeNameLabel.Text = "Nama Tipe Barang :";
            // 
            // itemTypeIdLabel1
            // 
            this.itemTypeIdLabel1.AutoSize = true;
            this.itemTypeIdLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemTypeId", true));
            this.itemTypeIdLabel1.Location = new System.Drawing.Point(150, 27);
            this.itemTypeIdLabel1.Name = "itemTypeIdLabel1";
            this.itemTypeIdLabel1.Size = new System.Drawing.Size(0, 13);
            this.itemTypeIdLabel1.TabIndex = 2;
            // 
            // itemTypeNameTextBox
            // 
            this.itemTypeNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemTypeName", true));
            this.itemTypeNameTextBox.Location = new System.Drawing.Point(150, 53);
            this.itemTypeNameTextBox.Name = "itemTypeNameTextBox";
            this.itemTypeNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.itemTypeNameTextBox.TabIndex = 4;
            // 
            // FormMasterTypeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterTypeItem";
            this.TabText = "Master Tipe Barang";
            this.Text = "Master Tipe Barang";
            this.Load += new System.EventHandler(this.FormMasterTypeItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label itemTypeIdLabel1;
        private System.Windows.Forms.TextBox itemTypeNameTextBox;
    }
}