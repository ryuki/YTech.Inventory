namespace Inventori.MotorKymco.Forms
{
    partial class FormMasterItem
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
            System.Windows.Forms.Label itemPricePurchaseLabel;
            System.Windows.Forms.Label itemMinStokLabel;
            System.Windows.Forms.Label itemMaxStokLabel;
            System.Windows.Forms.Label itemSatuanLabel;
            System.Windows.Forms.Label groupIdLabel;
            System.Windows.Forms.Label itemNameLabel;
            System.Windows.Forms.Label itemDescLabel;
            System.Windows.Forms.Label itemIdLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label gudangIdLabel;
            System.Windows.Forms.Label itemPricePurchaseAvgLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label itemPriceMaxLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label itemPositionLabel;
            this.itemStokNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.itemMinStokNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.itemMaxStokNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.itemStokLabel = new System.Windows.Forms.Label();
            this.itemSatuanTextBox = new System.Windows.Forms.TextBox();
            this.groupIdComboBox = new System.Windows.Forms.ComboBox();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.itemIdTextBox = new System.Windows.Forms.TextBox();
            this.itemDescTextBox = new System.Windows.Forms.TextBox();
            this.itemTypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemPriceMinVipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemPriceMinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defaultGudangIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemCommisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemPricePurchaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemPriceMaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemSatuanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemPriceMaxVipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemPricePurchaseNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tabControl_Gudang = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.itemPositionTextBox = new System.Windows.Forms.TextBox();
            this.itemGudangStokBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gudangIdLabel1 = new System.Windows.Forms.Label();
            this.groupBox_Stok = new System.Windows.Forms.GroupBox();
            this.itemPricePurchaseAvgNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.itemPriceMaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            itemPricePurchaseLabel = new System.Windows.Forms.Label();
            itemMinStokLabel = new System.Windows.Forms.Label();
            itemMaxStokLabel = new System.Windows.Forms.Label();
            itemSatuanLabel = new System.Windows.Forms.Label();
            groupIdLabel = new System.Windows.Forms.Label();
            itemNameLabel = new System.Windows.Forms.Label();
            itemDescLabel = new System.Windows.Forms.Label();
            itemIdLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            gudangIdLabel = new System.Windows.Forms.Label();
            itemPricePurchaseAvgLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            itemPriceMaxLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            itemPositionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemStokNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMinStokNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMaxStokNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPricePurchaseNumericUpDown)).BeginInit();
            this.tabControl_Gudang.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGudangStokBindingSource)).BeginInit();
            this.groupBox_Stok.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemPricePurchaseAvgNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPriceMaxNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MItem);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(itemPriceMaxLabel);
            this.groupBox1.Controls.Add(this.itemPriceMaxNumericUpDown);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(itemPricePurchaseAvgLabel);
            this.groupBox1.Controls.Add(this.itemPricePurchaseAvgNumericUpDown);
            this.groupBox1.Controls.Add(this.groupBox_Stok);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Controls.Add(this.itemPricePurchaseNumericUpDown);
            this.groupBox1.Controls.Add(itemPricePurchaseLabel);
            this.groupBox1.Controls.Add(this.itemSatuanTextBox);
            this.groupBox1.Controls.Add(itemSatuanLabel);
            this.groupBox1.Controls.Add(groupIdLabel);
            this.groupBox1.Controls.Add(this.groupIdComboBox);
            this.groupBox1.Controls.Add(this.itemNameTextBox);
            this.groupBox1.Controls.Add(itemNameLabel);
            this.groupBox1.Controls.Add(this.itemIdTextBox);
            this.groupBox1.Controls.Add(itemDescLabel);
            this.groupBox1.Controls.Add(itemIdLabel);
            this.groupBox1.Controls.Add(this.itemDescTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 337);
            this.groupBox1.Text = "Master Detail Item";
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemDescTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(itemDescLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.groupIdComboBox, 0);
            this.groupBox1.Controls.SetChildIndex(groupIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(itemSatuanLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemSatuanTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemPricePurchaseLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemPricePurchaseNumericUpDown, 0);
            this.groupBox1.Controls.SetChildIndex(label3, 0);
            this.groupBox1.Controls.SetChildIndex(this.groupBox_Stok, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemPricePurchaseAvgNumericUpDown, 0);
            this.groupBox1.Controls.SetChildIndex(itemPricePurchaseAvgLabel, 0);
            this.groupBox1.Controls.SetChildIndex(label1, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemPriceMaxNumericUpDown, 0);
            this.groupBox1.Controls.SetChildIndex(itemPriceMaxLabel, 0);
            this.groupBox1.Controls.SetChildIndex(label2, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 337;
            // 
            // itemPricePurchaseLabel
            // 
            itemPricePurchaseLabel.AutoSize = true;
            itemPricePurchaseLabel.Location = new System.Drawing.Point(23, 130);
            itemPricePurchaseLabel.Name = "itemPricePurchaseLabel";
            itemPricePurchaseLabel.Size = new System.Drawing.Size(62, 13);
            itemPricePurchaseLabel.TabIndex = 62;
            itemPricePurchaseLabel.Text = "Harga Beli :";
            // 
            // itemMinStokLabel
            // 
            itemMinStokLabel.AutoSize = true;
            itemMinStokLabel.Location = new System.Drawing.Point(17, 64);
            itemMinStokLabel.Name = "itemMinStokLabel";
            itemMinStokLabel.Size = new System.Drawing.Size(70, 13);
            itemMinStokLabel.TabIndex = 32;
            itemMinStokLabel.Text = "Stok Minimal:";
            // 
            // itemMaxStokLabel
            // 
            itemMaxStokLabel.AutoSize = true;
            itemMaxStokLabel.Location = new System.Drawing.Point(17, 38);
            itemMaxStokLabel.Name = "itemMaxStokLabel";
            itemMaxStokLabel.Size = new System.Drawing.Size(79, 13);
            itemMaxStokLabel.TabIndex = 30;
            itemMaxStokLabel.Text = "Stok Maksimal:";
            // 
            // itemSatuanLabel
            // 
            itemSatuanLabel.AutoSize = true;
            itemSatuanLabel.Location = new System.Drawing.Point(23, 105);
            itemSatuanLabel.Name = "itemSatuanLabel";
            itemSatuanLabel.Size = new System.Drawing.Size(44, 13);
            itemSatuanLabel.TabIndex = 58;
            itemSatuanLabel.Text = "Satuan:";
            // 
            // groupIdLabel
            // 
            groupIdLabel.AutoSize = true;
            groupIdLabel.Location = new System.Drawing.Point(23, 78);
            groupIdLabel.Name = "groupIdLabel";
            groupIdLabel.Size = new System.Drawing.Size(82, 13);
            groupIdLabel.TabIndex = 40;
            groupIdLabel.Text = "Golongan Item :";
            // 
            // itemNameLabel
            // 
            itemNameLabel.AutoSize = true;
            itemNameLabel.Location = new System.Drawing.Point(23, 52);
            itemNameLabel.Name = "itemNameLabel";
            itemNameLabel.Size = new System.Drawing.Size(64, 13);
            itemNameLabel.TabIndex = 48;
            itemNameLabel.Text = "Nama Item :";
            // 
            // itemDescLabel
            // 
            itemDescLabel.AutoSize = true;
            itemDescLabel.Location = new System.Drawing.Point(23, 208);
            itemDescLabel.Name = "itemDescLabel";
            itemDescLabel.Size = new System.Drawing.Size(68, 13);
            itemDescLabel.TabIndex = 44;
            itemDescLabel.Text = "Keterangan :";
            // 
            // itemIdLabel
            // 
            itemIdLabel.AutoSize = true;
            itemIdLabel.Location = new System.Drawing.Point(23, 26);
            itemIdLabel.Name = "itemIdLabel";
            itemIdLabel.Size = new System.Drawing.Size(61, 13);
            itemIdLabel.TabIndex = 46;
            itemIdLabel.Text = "Kode Item :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(124, 130);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(24, 13);
            label3.TabIndex = 70;
            label3.Text = "Rp.";
            // 
            // gudangIdLabel
            // 
            gudangIdLabel.AutoSize = true;
            gudangIdLabel.Location = new System.Drawing.Point(17, 14);
            gudangIdLabel.Name = "gudangIdLabel";
            gudangIdLabel.Size = new System.Drawing.Size(51, 13);
            gudangIdLabel.TabIndex = 41;
            gudangIdLabel.Text = "Gudang :";
            // 
            // itemPricePurchaseAvgLabel
            // 
            itemPricePurchaseAvgLabel.AutoSize = true;
            itemPricePurchaseAvgLabel.Location = new System.Drawing.Point(23, 181);
            itemPricePurchaseAvgLabel.Name = "itemPricePurchaseAvgLabel";
            itemPricePurchaseAvgLabel.Size = new System.Drawing.Size(89, 13);
            itemPricePurchaseAvgLabel.TabIndex = 72;
            itemPricePurchaseAvgLabel.Text = "Harga Rata-rata :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(124, 181);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(24, 13);
            label1.TabIndex = 74;
            label1.Text = "Rp.";
            // 
            // itemPriceMaxLabel
            // 
            itemPriceMaxLabel.AutoSize = true;
            itemPriceMaxLabel.Location = new System.Drawing.Point(23, 155);
            itemPriceMaxLabel.Name = "itemPriceMaxLabel";
            itemPriceMaxLabel.Size = new System.Drawing.Size(64, 13);
            itemPriceMaxLabel.TabIndex = 74;
            itemPriceMaxLabel.Text = "Harga Jual :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(124, 155);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(24, 13);
            label2.TabIndex = 76;
            label2.Text = "Rp.";
            // 
            // itemPositionLabel
            // 
            itemPositionLabel.AutoSize = true;
            itemPositionLabel.Location = new System.Drawing.Point(17, 117);
            itemPositionLabel.Name = "itemPositionLabel";
            itemPositionLabel.Size = new System.Drawing.Size(67, 13);
            itemPositionLabel.TabIndex = 42;
            itemPositionLabel.Text = "Nomor Rak :";
            // 
            // itemStokNumericUpDown
            // 
            this.itemStokNumericUpDown.Location = new System.Drawing.Point(113, 88);
            this.itemStokNumericUpDown.Name = "itemStokNumericUpDown";
            this.itemStokNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.itemStokNumericUpDown.TabIndex = 41;
            this.itemStokNumericUpDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemMinStokNumericUpDown
            // 
            this.itemMinStokNumericUpDown.Location = new System.Drawing.Point(113, 62);
            this.itemMinStokNumericUpDown.Name = "itemMinStokNumericUpDown";
            this.itemMinStokNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.itemMinStokNumericUpDown.TabIndex = 40;
            this.itemMinStokNumericUpDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemMaxStokNumericUpDown
            // 
            this.itemMaxStokNumericUpDown.Location = new System.Drawing.Point(113, 36);
            this.itemMaxStokNumericUpDown.Name = "itemMaxStokNumericUpDown";
            this.itemMaxStokNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.itemMaxStokNumericUpDown.TabIndex = 39;
            this.itemMaxStokNumericUpDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemStokLabel
            // 
            this.itemStokLabel.AutoSize = true;
            this.itemStokLabel.Location = new System.Drawing.Point(17, 90);
            this.itemStokLabel.Name = "itemStokLabel";
            this.itemStokLabel.Size = new System.Drawing.Size(55, 13);
            this.itemStokLabel.TabIndex = 38;
            this.itemStokLabel.Text = "Stok Item:";
            // 
            // itemSatuanTextBox
            // 
            this.itemSatuanTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemSatuan", true));
            this.itemSatuanTextBox.Location = new System.Drawing.Point(127, 102);
            this.itemSatuanTextBox.Name = "itemSatuanTextBox";
            this.itemSatuanTextBox.Size = new System.Drawing.Size(163, 20);
            this.itemSatuanTextBox.TabIndex = 59;
            this.itemSatuanTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // groupIdComboBox
            // 
            this.groupIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource_Master, "GroupId", true));
            this.groupIdComboBox.FormattingEnabled = true;
            this.groupIdComboBox.Location = new System.Drawing.Point(127, 75);
            this.groupIdComboBox.Name = "groupIdComboBox";
            this.groupIdComboBox.Size = new System.Drawing.Size(178, 21);
            this.groupIdComboBox.TabIndex = 41;
            this.groupIdComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemName", true));
            this.itemNameTextBox.Location = new System.Drawing.Point(127, 49);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(192, 20);
            this.itemNameTextBox.TabIndex = 49;
            this.itemNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemIdTextBox
            // 
            this.itemIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemId", true));
            this.itemIdTextBox.Location = new System.Drawing.Point(127, 23);
            this.itemIdTextBox.Name = "itemIdTextBox";
            this.itemIdTextBox.Size = new System.Drawing.Size(104, 20);
            this.itemIdTextBox.TabIndex = 47;
            this.itemIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemDescTextBox
            // 
            this.itemDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemDesc", true));
            this.itemDescTextBox.Location = new System.Drawing.Point(127, 205);
            this.itemDescTextBox.Multiline = true;
            this.itemDescTextBox.Name = "itemDescTextBox";
            this.itemDescTextBox.Size = new System.Drawing.Size(208, 93);
            this.itemDescTextBox.TabIndex = 45;
            this.itemDescTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemTypeIdDataGridViewTextBoxColumn
            // 
            this.itemTypeIdDataGridViewTextBoxColumn.DataPropertyName = "ItemTypeId";
            this.itemTypeIdDataGridViewTextBoxColumn.HeaderText = "ItemTypeId";
            this.itemTypeIdDataGridViewTextBoxColumn.Name = "itemTypeIdDataGridViewTextBoxColumn";
            this.itemTypeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemPriceMinVipDataGridViewTextBoxColumn
            // 
            this.itemPriceMinVipDataGridViewTextBoxColumn.DataPropertyName = "ItemPriceMinVip";
            this.itemPriceMinVipDataGridViewTextBoxColumn.HeaderText = "ItemPriceMinVip";
            this.itemPriceMinVipDataGridViewTextBoxColumn.Name = "itemPriceMinVipDataGridViewTextBoxColumn";
            this.itemPriceMinVipDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemIdDataGridViewTextBoxColumn
            // 
            this.itemIdDataGridViewTextBoxColumn.DataPropertyName = "ItemId";
            this.itemIdDataGridViewTextBoxColumn.HeaderText = "ItemId";
            this.itemIdDataGridViewTextBoxColumn.Name = "itemIdDataGridViewTextBoxColumn";
            this.itemIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemPriceMinDataGridViewTextBoxColumn
            // 
            this.itemPriceMinDataGridViewTextBoxColumn.DataPropertyName = "ItemPriceMin";
            this.itemPriceMinDataGridViewTextBoxColumn.HeaderText = "ItemPriceMin";
            this.itemPriceMinDataGridViewTextBoxColumn.Name = "itemPriceMinDataGridViewTextBoxColumn";
            this.itemPriceMinDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // defaultGudangIdDataGridViewTextBoxColumn
            // 
            this.defaultGudangIdDataGridViewTextBoxColumn.DataPropertyName = "DefaultGudangId";
            this.defaultGudangIdDataGridViewTextBoxColumn.HeaderText = "DefaultGudangId";
            this.defaultGudangIdDataGridViewTextBoxColumn.Name = "defaultGudangIdDataGridViewTextBoxColumn";
            this.defaultGudangIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemDescDataGridViewTextBoxColumn
            // 
            this.itemDescDataGridViewTextBoxColumn.DataPropertyName = "ItemDesc";
            this.itemDescDataGridViewTextBoxColumn.HeaderText = "ItemDesc";
            this.itemDescDataGridViewTextBoxColumn.Name = "itemDescDataGridViewTextBoxColumn";
            this.itemDescDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemCommisionDataGridViewTextBoxColumn
            // 
            this.itemCommisionDataGridViewTextBoxColumn.DataPropertyName = "ItemCommision";
            this.itemCommisionDataGridViewTextBoxColumn.HeaderText = "ItemCommision";
            this.itemCommisionDataGridViewTextBoxColumn.Name = "itemCommisionDataGridViewTextBoxColumn";
            this.itemCommisionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemPricePurchaseDataGridViewTextBoxColumn
            // 
            this.itemPricePurchaseDataGridViewTextBoxColumn.DataPropertyName = "ItemPricePurchase";
            this.itemPricePurchaseDataGridViewTextBoxColumn.HeaderText = "ItemPricePurchase";
            this.itemPricePurchaseDataGridViewTextBoxColumn.Name = "itemPricePurchaseDataGridViewTextBoxColumn";
            this.itemPricePurchaseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemPriceMaxDataGridViewTextBoxColumn
            // 
            this.itemPriceMaxDataGridViewTextBoxColumn.DataPropertyName = "ItemPriceMax";
            this.itemPriceMaxDataGridViewTextBoxColumn.HeaderText = "ItemPriceMax";
            this.itemPriceMaxDataGridViewTextBoxColumn.Name = "itemPriceMaxDataGridViewTextBoxColumn";
            this.itemPriceMaxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupIdDataGridViewTextBoxColumn
            // 
            this.groupIdDataGridViewTextBoxColumn.DataPropertyName = "GroupId";
            this.groupIdDataGridViewTextBoxColumn.HeaderText = "GroupId";
            this.groupIdDataGridViewTextBoxColumn.Name = "groupIdDataGridViewTextBoxColumn";
            this.groupIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemSatuanDataGridViewTextBoxColumn
            // 
            this.itemSatuanDataGridViewTextBoxColumn.DataPropertyName = "ItemSatuan";
            this.itemSatuanDataGridViewTextBoxColumn.HeaderText = "ItemSatuan";
            this.itemSatuanDataGridViewTextBoxColumn.Name = "itemSatuanDataGridViewTextBoxColumn";
            this.itemSatuanDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemPriceMaxVipDataGridViewTextBoxColumn
            // 
            this.itemPriceMaxVipDataGridViewTextBoxColumn.DataPropertyName = "ItemPriceMaxVip";
            this.itemPriceMaxVipDataGridViewTextBoxColumn.HeaderText = "ItemPriceMaxVip";
            this.itemPriceMaxVipDataGridViewTextBoxColumn.Name = "itemPriceMaxVipDataGridViewTextBoxColumn";
            this.itemPriceMaxVipDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemPricePurchaseNumericUpDown
            // 
            this.itemPricePurchaseNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource_Master, "ItemPricePurchase", true));
            this.itemPricePurchaseNumericUpDown.Location = new System.Drawing.Point(150, 127);
            this.itemPricePurchaseNumericUpDown.Name = "itemPricePurchaseNumericUpDown";
            this.itemPricePurchaseNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this.itemPricePurchaseNumericUpDown.TabIndex = 65;
            this.itemPricePurchaseNumericUpDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // tabControl_Gudang
            // 
            this.tabControl_Gudang.Controls.Add(this.tabPage1);
            this.tabControl_Gudang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Gudang.Location = new System.Drawing.Point(3, 16);
            this.tabControl_Gudang.Name = "tabControl_Gudang";
            this.tabControl_Gudang.SelectedIndex = 0;
            this.tabControl_Gudang.Size = new System.Drawing.Size(301, 181);
            this.tabControl_Gudang.TabIndex = 71;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(itemPositionLabel);
            this.tabPage1.Controls.Add(this.itemPositionTextBox);
            this.tabPage1.Controls.Add(gudangIdLabel);
            this.tabPage1.Controls.Add(this.gudangIdLabel1);
            this.tabPage1.Controls.Add(this.itemStokNumericUpDown);
            this.tabPage1.Controls.Add(itemMaxStokLabel);
            this.tabPage1.Controls.Add(this.itemMinStokNumericUpDown);
            this.tabPage1.Controls.Add(itemMinStokLabel);
            this.tabPage1.Controls.Add(this.itemMaxStokNumericUpDown);
            this.tabPage1.Controls.Add(this.itemStokLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(293, 155);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // itemPositionTextBox
            // 
            this.itemPositionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemGudangStokBindingSource, "ItemPosition", true));
            this.itemPositionTextBox.Location = new System.Drawing.Point(113, 114);
            this.itemPositionTextBox.Name = "itemPositionTextBox";
            this.itemPositionTextBox.Size = new System.Drawing.Size(159, 20);
            this.itemPositionTextBox.TabIndex = 43;
            // 
            // itemGudangStokBindingSource
            // 
            this.itemGudangStokBindingSource.DataSource = typeof(Inventori.Data.ItemGudangStok);
            // 
            // gudangIdLabel1
            // 
            this.gudangIdLabel1.AutoSize = true;
            this.gudangIdLabel1.Location = new System.Drawing.Point(110, 14);
            this.gudangIdLabel1.Name = "gudangIdLabel1";
            this.gudangIdLabel1.Size = new System.Drawing.Size(45, 13);
            this.gudangIdLabel1.TabIndex = 42;
            this.gudangIdLabel1.Text = "Gudang";
            // 
            // groupBox_Stok
            // 
            this.groupBox_Stok.Controls.Add(this.tabControl_Gudang);
            this.groupBox_Stok.Location = new System.Drawing.Point(343, 23);
            this.groupBox_Stok.Name = "groupBox_Stok";
            this.groupBox_Stok.Size = new System.Drawing.Size(307, 200);
            this.groupBox_Stok.TabIndex = 72;
            this.groupBox_Stok.TabStop = false;
            this.groupBox_Stok.Text = "Stok Item";
            // 
            // itemPricePurchaseAvgNumericUpDown
            // 
            this.itemPricePurchaseAvgNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource_Master, "ItemPricePurchaseAvg", true));
            this.itemPricePurchaseAvgNumericUpDown.Enabled = false;
            this.itemPricePurchaseAvgNumericUpDown.Location = new System.Drawing.Point(150, 179);
            this.itemPricePurchaseAvgNumericUpDown.Name = "itemPricePurchaseAvgNumericUpDown";
            this.itemPricePurchaseAvgNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this.itemPricePurchaseAvgNumericUpDown.TabIndex = 73;
            // 
            // itemPriceMaxNumericUpDown
            // 
            this.itemPriceMaxNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource_Master, "ItemPriceMax", true));
            this.itemPriceMaxNumericUpDown.Location = new System.Drawing.Point(150, 153);
            this.itemPriceMaxNumericUpDown.Name = "itemPriceMaxNumericUpDown";
            this.itemPriceMaxNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this.itemPriceMaxNumericUpDown.TabIndex = 75;
            // 
            // FormMasterItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterItem";
            this.TabText = "Daftar Item";
            this.Text = "Daftar Item";
            this.Load += new System.EventHandler(this.FormMasterItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemStokNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMinStokNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMaxStokNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPricePurchaseNumericUpDown)).EndInit();
            this.tabControl_Gudang.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGudangStokBindingSource)).EndInit();
            this.groupBox_Stok.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemPricePurchaseAvgNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPriceMaxNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label itemStokLabel;
        private System.Windows.Forms.TextBox itemSatuanTextBox;
        private System.Windows.Forms.ComboBox groupIdComboBox;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.TextBox itemIdTextBox;
        private System.Windows.Forms.TextBox itemDescTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemTypeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemPriceMinVipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemPriceMinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn defaultGudangIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemCommisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemPricePurchaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemPriceMaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemSatuanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemPriceMaxVipDataGridViewTextBoxColumn;
        private System.Windows.Forms.NumericUpDown itemPricePurchaseNumericUpDown;
        private System.Windows.Forms.NumericUpDown itemStokNumericUpDown;
        private System.Windows.Forms.NumericUpDown itemMinStokNumericUpDown;
        private System.Windows.Forms.NumericUpDown itemMaxStokNumericUpDown;
        private System.Windows.Forms.TabControl tabControl_Gudang;
        private System.Windows.Forms.GroupBox groupBox_Stok;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label gudangIdLabel1;
        private System.Windows.Forms.NumericUpDown itemPricePurchaseAvgNumericUpDown;
        private System.Windows.Forms.NumericUpDown itemPriceMaxNumericUpDown;
        private System.Windows.Forms.TextBox itemPositionTextBox;
        private System.Windows.Forms.BindingSource itemGudangStokBindingSource;
    }
}
