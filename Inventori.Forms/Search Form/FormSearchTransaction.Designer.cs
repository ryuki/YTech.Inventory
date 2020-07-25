namespace Inventori.Forms
{
    partial class FormSearchTransaction
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
            this.contextMenuStrip_Transaction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTransaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hapusTransaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cetakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Search)).BeginInit();
            this.contextMenuStrip_Transaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_SearchByName
            // 
            this.txt_SearchByName.Visible = false;
            // 
            // txt_SearchById
            // 
            this.txt_SearchById.Text = "<Cari Berdasar No Faktur>";
            this.txt_SearchById.TextChanged += new System.EventHandler(this.BindData);
            // 
            // contextMenuStrip_Transaction
            // 
            this.contextMenuStrip_Transaction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTransaksiToolStripMenuItem,
            this.hapusTransaksiToolStripMenuItem,
            this.toolStripSeparator1,
            this.cetakToolStripMenuItem});
            this.contextMenuStrip_Transaction.Name = "contextMenuStrip1";
            this.contextMenuStrip_Transaction.Size = new System.Drawing.Size(164, 98);
            // 
            // editTransaksiToolStripMenuItem
            // 
            this.editTransaksiToolStripMenuItem.Image = global::Inventori.Forms.Properties.Resources.edit16;
            this.editTransaksiToolStripMenuItem.Name = "editTransaksiToolStripMenuItem";
            this.editTransaksiToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.editTransaksiToolStripMenuItem.Text = "Edit Transaksi";
            // 
            // hapusTransaksiToolStripMenuItem
            // 
            this.hapusTransaksiToolStripMenuItem.Image = global::Inventori.Forms.Properties.Resources.delete16;
            this.hapusTransaksiToolStripMenuItem.Name = "hapusTransaksiToolStripMenuItem";
            this.hapusTransaksiToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.hapusTransaksiToolStripMenuItem.Text = "Hapus Transaksi";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // cetakToolStripMenuItem
            // 
            this.cetakToolStripMenuItem.Image = global::Inventori.Forms.Properties.Resources.printer;
            this.cetakToolStripMenuItem.Name = "cetakToolStripMenuItem";
            this.cetakToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.cetakToolStripMenuItem.Text = "Cetak";
            // 
            // FormSearchTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 405);
            this.Name = "FormSearchTransaction";
            this.TabText = "Pencarian Transaksi";
            this.Text = "Pencarian Transaksi";
            this.Load += new System.EventHandler(this.FormSearchTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Search)).EndInit();
            this.contextMenuStrip_Transaction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ContextMenuStrip contextMenuStrip_Transaction;
        public System.Windows.Forms.ToolStripMenuItem hapusTransaksiToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cetakToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem editTransaksiToolStripMenuItem;
    }
}