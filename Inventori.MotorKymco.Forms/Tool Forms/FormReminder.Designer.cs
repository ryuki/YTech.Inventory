namespace Inventori.MotorKymco.Forms
{
    partial class FormReminder
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Daftar Item Kurang Dari Batas Minimum", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Hutang Jatuh Tempo", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Piutang Jatuh Tempo", System.Windows.Forms.HorizontalAlignment.Left);
            this.listView_Reminder = new System.Windows.Forms.ListView();
            this.columnHeader_Keterangan = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Jumlah = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_Reminder
            // 
            this.listView_Reminder.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView_Reminder.AllowColumnReorder = true;
            this.listView_Reminder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Keterangan,
            this.columnHeader_Jumlah});
            this.listView_Reminder.ContextMenuStrip = this.contextMenuStrip1;
            this.listView_Reminder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Reminder.FullRowSelect = true;
            this.listView_Reminder.GridLines = true;
            listViewGroup1.Header = "Daftar Item Kurang Dari Batas Minimum";
            listViewGroup1.Name = "listViewGroup_MinStock";
            listViewGroup2.Header = "Hutang Jatuh Tempo";
            listViewGroup2.Name = "ListViewGroup_Hutang";
            listViewGroup3.Header = "Piutang Jatuh Tempo";
            listViewGroup3.Name = "ListViewGroup_Piutang";
            this.listView_Reminder.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.listView_Reminder.Location = new System.Drawing.Point(0, 0);
            this.listView_Reminder.MultiSelect = false;
            this.listView_Reminder.Name = "listView_Reminder";
            this.listView_Reminder.ShowItemToolTips = true;
            this.listView_Reminder.Size = new System.Drawing.Size(289, 518);
            this.listView_Reminder.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_Reminder.TabIndex = 2;
            this.listView_Reminder.UseCompatibleStateImageBehavior = false;
            this.listView_Reminder.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_Keterangan
            // 
            this.columnHeader_Keterangan.Text = "Keterangan";
            this.columnHeader_Keterangan.Width = 154;
            // 
            // columnHeader_Jumlah
            // 
            this.columnHeader_Jumlah.Text = "Jumlah";
            this.columnHeader_Jumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader_Jumlah.Width = 78;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 26);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::Inventori.MotorKymco.Forms.Properties.Resources.Refresh;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormReminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(289, 518);
            this.Controls.Add(this.listView_Reminder);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft;
            this.Name = "FormReminder";
            this.TabText = "Pengingat";
            this.Text = "Pengingat";
            this.Load += new System.EventHandler(this.FormReminder_Load);
            this.Controls.SetChildIndex(this.listView_Reminder, 0);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_Reminder;
        private System.Windows.Forms.ColumnHeader columnHeader_Keterangan;
        private System.Windows.Forms.ColumnHeader columnHeader_Jumlah;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}