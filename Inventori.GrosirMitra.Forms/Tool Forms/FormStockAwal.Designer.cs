namespace Inventori.GrosirMitra.Forms
{
    partial class FormStockAwal
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
            this.itemGudangStokBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.itemGudangStokDataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnIsAdd = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCurrentStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.itemGudangStokBindingNavigator)).BeginInit();
            this.itemGudangStokBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGudangStokDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // itemGudangStokBindingNavigator
            // 
            this.itemGudangStokBindingNavigator.AddNewItem = null;
            this.itemGudangStokBindingNavigator.CountItem = null;
            this.itemGudangStokBindingNavigator.DeleteItem = null;
            this.itemGudangStokBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.itemGudangStokBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.itemGudangStokBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.itemGudangStokBindingNavigator.MoveFirstItem = null;
            this.itemGudangStokBindingNavigator.MoveLastItem = null;
            this.itemGudangStokBindingNavigator.MoveNextItem = null;
            this.itemGudangStokBindingNavigator.MovePreviousItem = null;
            this.itemGudangStokBindingNavigator.Name = "itemGudangStokBindingNavigator";
            this.itemGudangStokBindingNavigator.PositionItem = null;
            this.itemGudangStokBindingNavigator.Size = new System.Drawing.Size(508, 44);
            this.itemGudangStokBindingNavigator.TabIndex = 3;
            this.itemGudangStokBindingNavigator.Text = "bindingNavigator1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Inventori.GrosirMitra.Forms.Properties.Resources.save;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(45, 41);
            this.toolStripButton1.Text = "Simpan";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // itemGudangStokDataGridView
            // 
            this.itemGudangStokDataGridView.AllowUserToAddRows = false;
            this.itemGudangStokDataGridView.AllowUserToDeleteRows = false;
            this.itemGudangStokDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIsAdd,
            this.ColumnItemId,
            this.ColumnItemName,
            this.ColumnCurrentStok,
            this.ColumnStok});
            this.itemGudangStokDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemGudangStokDataGridView.Location = new System.Drawing.Point(0, 44);
            this.itemGudangStokDataGridView.Name = "itemGudangStokDataGridView";
            this.itemGudangStokDataGridView.Size = new System.Drawing.Size(508, 411);
            this.itemGudangStokDataGridView.TabIndex = 3;
            // 
            // ColumnIsAdd
            // 
            this.ColumnIsAdd.DataPropertyName = "IsUpdate";
            this.ColumnIsAdd.HeaderText = "Set Stok";
            this.ColumnIsAdd.Name = "ColumnIsAdd";
            // 
            // ColumnItemId
            // 
            this.ColumnItemId.DataPropertyName = "ItemId";
            this.ColumnItemId.HeaderText = "Kode Barang";
            this.ColumnItemId.Name = "ColumnItemId";
            this.ColumnItemId.ReadOnly = true;
            // 
            // ColumnItemName
            // 
            this.ColumnItemName.DataPropertyName = "ItemName";
            this.ColumnItemName.HeaderText = "Nama Barang";
            this.ColumnItemName.Name = "ColumnItemName";
            this.ColumnItemName.ReadOnly = true;
            // 
            // ColumnCurrentStok
            // 
            this.ColumnCurrentStok.DataPropertyName = "CurrentItemStok";
            this.ColumnCurrentStok.HeaderText = "Stok Sekarang";
            this.ColumnCurrentStok.Name = "ColumnCurrentStok";
            this.ColumnCurrentStok.ReadOnly = true;
            // 
            // ColumnStok
            // 
            this.ColumnStok.DataPropertyName = "ItemStok";
            this.ColumnStok.HeaderText = "Stok Awal";
            this.ColumnStok.Name = "ColumnStok";
            // 
            // FormStockAwal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 455);
            this.Controls.Add(this.itemGudangStokDataGridView);
            this.Controls.Add(this.itemGudangStokBindingNavigator);
            this.Name = "FormStockAwal";
            this.TabText = "Set Stok Awal";
            this.Text = "Set Stok Awal";
            this.Load += new System.EventHandler(this.FormStockAwal_Load);
            this.Controls.SetChildIndex(this.itemGudangStokBindingNavigator, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.Controls.SetChildIndex(this.itemGudangStokDataGridView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.itemGudangStokBindingNavigator)).EndInit();
            this.itemGudangStokBindingNavigator.ResumeLayout(false);
            this.itemGudangStokBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGudangStokDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator itemGudangStokBindingNavigator;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView itemGudangStokDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCurrentStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStok;
    }
}