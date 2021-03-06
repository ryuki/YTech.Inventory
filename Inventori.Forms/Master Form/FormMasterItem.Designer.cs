namespace Inventori.Forms
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
            System.Windows.Forms.Label gudangIdLabel;
            System.Windows.Forms.Label itemMinStokLabel;
            System.Windows.Forms.Label itemIdLabel1;
            System.Windows.Forms.Label itemMaxStokLabel;
            System.Windows.Forms.Label itemTypeIdLabel;
            System.Windows.Forms.Label itemSatuanLabel;
            System.Windows.Forms.Label itemPriceMinVipLabel;
            System.Windows.Forms.Label itemPriceMinLabel;
            System.Windows.Forms.Label defaultGudangIdLabel;
            System.Windows.Forms.Label itemPriceMaxVipLabel;
            System.Windows.Forms.Label groupIdLabel;
            System.Windows.Forms.Label itemPriceMaxLabel;
            System.Windows.Forms.Label itemCommisionLabel;
            System.Windows.Forms.Label itemNameLabel;
            System.Windows.Forms.Label itemDescLabel;
            System.Windows.Forms.Label itemIdLabel;
            this.itemPricePurchaseTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.itemStokLabel = new System.Windows.Forms.Label();
            this.itemStokTextBox = new System.Windows.Forms.TextBox();
            this.itemGudangStokBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gudangIdTextBox = new System.Windows.Forms.TextBox();
            this.itemMinStokTextBox = new System.Windows.Forms.TextBox();
            this.itemMaxStokTextBox = new System.Windows.Forms.TextBox();
            this.itemIdTextBox1 = new System.Windows.Forms.TextBox();
            this.defaultGudangIdComboBox = new System.Windows.Forms.ComboBox();
            this.itemTypeIdComboBox = new System.Windows.Forms.ComboBox();
            this.itemSatuanTextBox = new System.Windows.Forms.TextBox();
            this.itemPriceMinVipTextBox = new System.Windows.Forms.TextBox();
            this.itemPriceMinTextBox = new System.Windows.Forms.TextBox();
            this.itemPriceMaxVipTextBox = new System.Windows.Forms.TextBox();
            this.itemPriceMaxTextBox = new System.Windows.Forms.TextBox();
            this.groupIdComboBox = new System.Windows.Forms.ComboBox();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.itemCommisionTextBox = new System.Windows.Forms.TextBox();
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
            itemPricePurchaseLabel = new System.Windows.Forms.Label();
            gudangIdLabel = new System.Windows.Forms.Label();
            itemMinStokLabel = new System.Windows.Forms.Label();
            itemIdLabel1 = new System.Windows.Forms.Label();
            itemMaxStokLabel = new System.Windows.Forms.Label();
            itemTypeIdLabel = new System.Windows.Forms.Label();
            itemSatuanLabel = new System.Windows.Forms.Label();
            itemPriceMinVipLabel = new System.Windows.Forms.Label();
            itemPriceMinLabel = new System.Windows.Forms.Label();
            defaultGudangIdLabel = new System.Windows.Forms.Label();
            itemPriceMaxVipLabel = new System.Windows.Forms.Label();
            groupIdLabel = new System.Windows.Forms.Label();
            itemPriceMaxLabel = new System.Windows.Forms.Label();
            itemCommisionLabel = new System.Windows.Forms.Label();
            itemNameLabel = new System.Windows.Forms.Label();
            itemDescLabel = new System.Windows.Forms.Label();
            itemIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGudangStokBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MItem);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(itemPricePurchaseLabel);
            this.groupBox1.Controls.Add(this.itemPricePurchaseTextBox);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.defaultGudangIdComboBox);
            this.groupBox1.Controls.Add(this.itemTypeIdComboBox);
            this.groupBox1.Controls.Add(itemTypeIdLabel);
            this.groupBox1.Controls.Add(this.itemSatuanTextBox);
            this.groupBox1.Controls.Add(itemSatuanLabel);
            this.groupBox1.Controls.Add(this.itemPriceMinVipTextBox);
            this.groupBox1.Controls.Add(itemPriceMinVipLabel);
            this.groupBox1.Controls.Add(this.itemPriceMinTextBox);
            this.groupBox1.Controls.Add(itemPriceMinLabel);
            this.groupBox1.Controls.Add(this.itemPriceMaxVipTextBox);
            this.groupBox1.Controls.Add(defaultGudangIdLabel);
            this.groupBox1.Controls.Add(itemPriceMaxVipLabel);
            this.groupBox1.Controls.Add(this.itemPriceMaxTextBox);
            this.groupBox1.Controls.Add(groupIdLabel);
            this.groupBox1.Controls.Add(itemPriceMaxLabel);
            this.groupBox1.Controls.Add(this.groupIdComboBox);
            this.groupBox1.Controls.Add(this.itemNameTextBox);
            this.groupBox1.Controls.Add(itemCommisionLabel);
            this.groupBox1.Controls.Add(itemNameLabel);
            this.groupBox1.Controls.Add(this.itemCommisionTextBox);
            this.groupBox1.Controls.Add(this.itemIdTextBox);
            this.groupBox1.Controls.Add(itemDescLabel);
            this.groupBox1.Controls.Add(itemIdLabel);
            this.groupBox1.Controls.Add(this.itemDescTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 281);
            this.groupBox1.Text = "Master Detail Item";
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemDescTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(itemDescLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemCommisionTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(itemCommisionLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.groupIdComboBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemPriceMaxLabel, 0);
            this.groupBox1.Controls.SetChildIndex(groupIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemPriceMaxTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemPriceMaxVipLabel, 0);
            this.groupBox1.Controls.SetChildIndex(defaultGudangIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemPriceMaxVipTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemPriceMinLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemPriceMinTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemPriceMinVipLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemPriceMinVipTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemSatuanLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemSatuanTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemTypeIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemTypeIdComboBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.defaultGudangIdComboBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemPricePurchaseTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemPricePurchaseLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 281;
            // 
            // itemPricePurchaseLabel
            // 
            itemPricePurchaseLabel.AutoSize = true;
            itemPricePurchaseLabel.Location = new System.Drawing.Point(23, 158);
            itemPricePurchaseLabel.Name = "itemPricePurchaseLabel";
            itemPricePurchaseLabel.Size = new System.Drawing.Size(95, 13);
            itemPricePurchaseLabel.TabIndex = 62;
            itemPricePurchaseLabel.Text = "Harga Per Satuan:";
            // 
            // gudangIdLabel
            // 
            gudangIdLabel.AutoSize = true;
            gudangIdLabel.Location = new System.Drawing.Point(10, 177);
            gudangIdLabel.Name = "gudangIdLabel";
            gudangIdLabel.Size = new System.Drawing.Size(60, 13);
            gudangIdLabel.TabIndex = 26;
            gudangIdLabel.Text = "Gudang Id:";
            // 
            // itemMinStokLabel
            // 
            itemMinStokLabel.AutoSize = true;
            itemMinStokLabel.Location = new System.Drawing.Point(27, 52);
            itemMinStokLabel.Name = "itemMinStokLabel";
            itemMinStokLabel.Size = new System.Drawing.Size(70, 13);
            itemMinStokLabel.TabIndex = 32;
            itemMinStokLabel.Text = "Stok Minimal:";
            // 
            // itemIdLabel1
            // 
            itemIdLabel1.AutoSize = true;
            itemIdLabel1.Location = new System.Drawing.Point(10, 203);
            itemIdLabel1.Name = "itemIdLabel1";
            itemIdLabel1.Size = new System.Drawing.Size(42, 13);
            itemIdLabel1.TabIndex = 28;
            itemIdLabel1.Text = "Item Id:";
            // 
            // itemMaxStokLabel
            // 
            itemMaxStokLabel.AutoSize = true;
            itemMaxStokLabel.Location = new System.Drawing.Point(27, 26);
            itemMaxStokLabel.Name = "itemMaxStokLabel";
            itemMaxStokLabel.Size = new System.Drawing.Size(79, 13);
            itemMaxStokLabel.TabIndex = 30;
            itemMaxStokLabel.Text = "Stok Maksimal:";
            // 
            // itemTypeIdLabel
            // 
            itemTypeIdLabel.AutoSize = true;
            itemTypeIdLabel.Location = new System.Drawing.Point(23, 78);
            itemTypeIdLabel.Name = "itemTypeIdLabel";
            itemTypeIdLabel.Size = new System.Drawing.Size(57, 13);
            itemTypeIdLabel.TabIndex = 60;
            itemTypeIdLabel.Text = "Tipe  Item:";
            // 
            // itemSatuanLabel
            // 
            itemSatuanLabel.AutoSize = true;
            itemSatuanLabel.Location = new System.Drawing.Point(23, 132);
            itemSatuanLabel.Name = "itemSatuanLabel";
            itemSatuanLabel.Size = new System.Drawing.Size(44, 13);
            itemSatuanLabel.TabIndex = 58;
            itemSatuanLabel.Text = "Satuan:";
            // 
            // itemPriceMinVipLabel
            // 
            itemPriceMinVipLabel.AutoSize = true;
            itemPriceMinVipLabel.Location = new System.Drawing.Point(21, 442);
            itemPriceMinVipLabel.Name = "itemPriceMinVipLabel";
            itemPriceMinVipLabel.Size = new System.Drawing.Size(95, 13);
            itemPriceMinVipLabel.TabIndex = 56;
            itemPriceMinVipLabel.Text = "Item Price Min Vip:";
            itemPriceMinVipLabel.Visible = false;
            // 
            // itemPriceMinLabel
            // 
            itemPriceMinLabel.AutoSize = true;
            itemPriceMinLabel.Location = new System.Drawing.Point(21, 416);
            itemPriceMinLabel.Name = "itemPriceMinLabel";
            itemPriceMinLabel.Size = new System.Drawing.Size(77, 13);
            itemPriceMinLabel.TabIndex = 54;
            itemPriceMinLabel.Text = "Item Price Min:";
            itemPriceMinLabel.Visible = false;
            // 
            // defaultGudangIdLabel
            // 
            defaultGudangIdLabel.AutoSize = true;
            defaultGudangIdLabel.Location = new System.Drawing.Point(21, 363);
            defaultGudangIdLabel.Name = "defaultGudangIdLabel";
            defaultGudangIdLabel.Size = new System.Drawing.Size(97, 13);
            defaultGudangIdLabel.TabIndex = 38;
            defaultGudangIdLabel.Text = "Default Gudang Id:";
            defaultGudangIdLabel.Visible = false;
            // 
            // itemPriceMaxVipLabel
            // 
            itemPriceMaxVipLabel.AutoSize = true;
            itemPriceMaxVipLabel.Location = new System.Drawing.Point(23, 210);
            itemPriceMaxVipLabel.Name = "itemPriceMaxVipLabel";
            itemPriceMaxVipLabel.Size = new System.Drawing.Size(59, 13);
            itemPriceMaxVipLabel.TabIndex = 52;
            itemPriceMaxVipLabel.Text = "Harga VIP:";
            // 
            // groupIdLabel
            // 
            groupIdLabel.AutoSize = true;
            groupIdLabel.Location = new System.Drawing.Point(23, 105);
            groupIdLabel.Name = "groupIdLabel";
            groupIdLabel.Size = new System.Drawing.Size(79, 13);
            groupIdLabel.TabIndex = 40;
            groupIdLabel.Text = "Golongan Item:";
            // 
            // itemPriceMaxLabel
            // 
            itemPriceMaxLabel.AutoSize = true;
            itemPriceMaxLabel.Location = new System.Drawing.Point(23, 184);
            itemPriceMaxLabel.Name = "itemPriceMaxLabel";
            itemPriceMaxLabel.Size = new System.Drawing.Size(61, 13);
            itemPriceMaxLabel.TabIndex = 50;
            itemPriceMaxLabel.Text = "Harga Jual:";
            // 
            // itemCommisionLabel
            // 
            itemCommisionLabel.AutoSize = true;
            itemCommisionLabel.Location = new System.Drawing.Point(21, 390);
            itemCommisionLabel.Name = "itemCommisionLabel";
            itemCommisionLabel.Size = new System.Drawing.Size(83, 13);
            itemCommisionLabel.TabIndex = 42;
            itemCommisionLabel.Text = "Item Commision:";
            itemCommisionLabel.Visible = false;
            // 
            // itemNameLabel
            // 
            itemNameLabel.AutoSize = true;
            itemNameLabel.Location = new System.Drawing.Point(23, 52);
            itemNameLabel.Name = "itemNameLabel";
            itemNameLabel.Size = new System.Drawing.Size(61, 13);
            itemNameLabel.TabIndex = 48;
            itemNameLabel.Text = "Nama Item:";
            // 
            // itemDescLabel
            // 
            itemDescLabel.AutoSize = true;
            itemDescLabel.Location = new System.Drawing.Point(23, 236);
            itemDescLabel.Name = "itemDescLabel";
            itemDescLabel.Size = new System.Drawing.Size(76, 13);
            itemDescLabel.TabIndex = 44;
            itemDescLabel.Text = "Deskripsi Item:";
            // 
            // itemIdLabel
            // 
            itemIdLabel.AutoSize = true;
            itemIdLabel.Location = new System.Drawing.Point(23, 26);
            itemIdLabel.Name = "itemIdLabel";
            itemIdLabel.Size = new System.Drawing.Size(58, 13);
            itemIdLabel.TabIndex = 46;
            itemIdLabel.Text = "Kode Item:";
            // 
            // itemPricePurchaseTextBox
            // 
            this.itemPricePurchaseTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemPricePurchase", true));
            this.itemPricePurchaseTextBox.Location = new System.Drawing.Point(127, 155);
            this.itemPricePurchaseTextBox.Name = "itemPricePurchaseTextBox";
            this.itemPricePurchaseTextBox.Size = new System.Drawing.Size(100, 20);
            this.itemPricePurchaseTextBox.TabIndex = 64;
            this.itemPricePurchaseTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.itemStokLabel);
            this.groupBox2.Controls.Add(this.itemStokTextBox);
            this.groupBox2.Controls.Add(gudangIdLabel);
            this.groupBox2.Controls.Add(this.gudangIdTextBox);
            this.groupBox2.Controls.Add(this.itemMinStokTextBox);
            this.groupBox2.Controls.Add(itemMinStokLabel);
            this.groupBox2.Controls.Add(itemIdLabel1);
            this.groupBox2.Controls.Add(this.itemMaxStokTextBox);
            this.groupBox2.Controls.Add(itemMaxStokLabel);
            this.groupBox2.Controls.Add(this.itemIdTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(308, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 108);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stok Item";
            // 
            // itemStokLabel
            // 
            this.itemStokLabel.AutoSize = true;
            this.itemStokLabel.Location = new System.Drawing.Point(27, 78);
            this.itemStokLabel.Name = "itemStokLabel";
            this.itemStokLabel.Size = new System.Drawing.Size(55, 13);
            this.itemStokLabel.TabIndex = 38;
            this.itemStokLabel.Text = "Stok Item:";
            // 
            // itemStokTextBox
            // 
            this.itemStokTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemGudangStokBindingSource, "ItemStok", true));
            this.itemStokTextBox.Location = new System.Drawing.Point(111, 75);
            this.itemStokTextBox.Name = "itemStokTextBox";
            this.itemStokTextBox.Size = new System.Drawing.Size(100, 20);
            this.itemStokTextBox.TabIndex = 35;
            this.itemStokTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemGudangStokBindingSource
            // 
            this.itemGudangStokBindingSource.DataSource = typeof(Inventori.Data.ItemGudangStok);
            // 
            // gudangIdTextBox
            // 
            this.gudangIdTextBox.Location = new System.Drawing.Point(94, 174);
            this.gudangIdTextBox.Name = "gudangIdTextBox";
            this.gudangIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.gudangIdTextBox.TabIndex = 27;
            // 
            // itemMinStokTextBox
            // 
            this.itemMinStokTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemGudangStokBindingSource, "ItemMinStok", true));
            this.itemMinStokTextBox.Location = new System.Drawing.Point(111, 49);
            this.itemMinStokTextBox.Name = "itemMinStokTextBox";
            this.itemMinStokTextBox.Size = new System.Drawing.Size(100, 20);
            this.itemMinStokTextBox.TabIndex = 33;
            this.itemMinStokTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemMaxStokTextBox
            // 
            this.itemMaxStokTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemGudangStokBindingSource, "ItemMaxStok", true));
            this.itemMaxStokTextBox.Location = new System.Drawing.Point(111, 23);
            this.itemMaxStokTextBox.Name = "itemMaxStokTextBox";
            this.itemMaxStokTextBox.Size = new System.Drawing.Size(100, 20);
            this.itemMaxStokTextBox.TabIndex = 31;
            this.itemMaxStokTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemIdTextBox1
            // 
            this.itemIdTextBox1.Location = new System.Drawing.Point(94, 200);
            this.itemIdTextBox1.Name = "itemIdTextBox1";
            this.itemIdTextBox1.Size = new System.Drawing.Size(100, 20);
            this.itemIdTextBox1.TabIndex = 29;
            // 
            // defaultGudangIdComboBox
            // 
            this.defaultGudangIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource_Master, "DefaultGudangId", true));
            this.defaultGudangIdComboBox.FormattingEnabled = true;
            this.defaultGudangIdComboBox.Location = new System.Drawing.Point(125, 360);
            this.defaultGudangIdComboBox.Name = "defaultGudangIdComboBox";
            this.defaultGudangIdComboBox.Size = new System.Drawing.Size(121, 21);
            this.defaultGudangIdComboBox.TabIndex = 39;
            this.defaultGudangIdComboBox.Visible = false;
            // 
            // itemTypeIdComboBox
            // 
            this.itemTypeIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource_Master, "ItemTypeId", true));
            this.itemTypeIdComboBox.FormattingEnabled = true;
            this.itemTypeIdComboBox.Location = new System.Drawing.Point(127, 75);
            this.itemTypeIdComboBox.Name = "itemTypeIdComboBox";
            this.itemTypeIdComboBox.Size = new System.Drawing.Size(121, 21);
            this.itemTypeIdComboBox.TabIndex = 61;
            this.itemTypeIdComboBox.SelectedIndexChanged += new System.EventHandler(this.itemTypeIdComboBox_SelectedIndexChanged);
            this.itemTypeIdComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemSatuanTextBox
            // 
            this.itemSatuanTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemSatuan", true));
            this.itemSatuanTextBox.Location = new System.Drawing.Point(127, 129);
            this.itemSatuanTextBox.Name = "itemSatuanTextBox";
            this.itemSatuanTextBox.Size = new System.Drawing.Size(121, 20);
            this.itemSatuanTextBox.TabIndex = 59;
            this.itemSatuanTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemPriceMinVipTextBox
            // 
            this.itemPriceMinVipTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemPriceMinVip", true));
            this.itemPriceMinVipTextBox.Location = new System.Drawing.Point(125, 439);
            this.itemPriceMinVipTextBox.Name = "itemPriceMinVipTextBox";
            this.itemPriceMinVipTextBox.Size = new System.Drawing.Size(121, 20);
            this.itemPriceMinVipTextBox.TabIndex = 57;
            this.itemPriceMinVipTextBox.Visible = false;
            // 
            // itemPriceMinTextBox
            // 
            this.itemPriceMinTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemPriceMin", true));
            this.itemPriceMinTextBox.Location = new System.Drawing.Point(125, 413);
            this.itemPriceMinTextBox.Name = "itemPriceMinTextBox";
            this.itemPriceMinTextBox.Size = new System.Drawing.Size(121, 20);
            this.itemPriceMinTextBox.TabIndex = 55;
            this.itemPriceMinTextBox.Visible = false;
            // 
            // itemPriceMaxVipTextBox
            // 
            this.itemPriceMaxVipTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemPriceMaxVip", true));
            this.itemPriceMaxVipTextBox.Location = new System.Drawing.Point(127, 207);
            this.itemPriceMaxVipTextBox.Name = "itemPriceMaxVipTextBox";
            this.itemPriceMaxVipTextBox.Size = new System.Drawing.Size(121, 20);
            this.itemPriceMaxVipTextBox.TabIndex = 53;
            this.itemPriceMaxVipTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemPriceMaxTextBox
            // 
            this.itemPriceMaxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemPriceMax", true));
            this.itemPriceMaxTextBox.Location = new System.Drawing.Point(127, 181);
            this.itemPriceMaxTextBox.Name = "itemPriceMaxTextBox";
            this.itemPriceMaxTextBox.Size = new System.Drawing.Size(121, 20);
            this.itemPriceMaxTextBox.TabIndex = 51;
            this.itemPriceMaxTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // groupIdComboBox
            // 
            this.groupIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource_Master, "GroupId", true));
            this.groupIdComboBox.FormattingEnabled = true;
            this.groupIdComboBox.Location = new System.Drawing.Point(127, 102);
            this.groupIdComboBox.Name = "groupIdComboBox";
            this.groupIdComboBox.Size = new System.Drawing.Size(121, 21);
            this.groupIdComboBox.TabIndex = 41;
            this.groupIdComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemName", true));
            this.itemNameTextBox.Location = new System.Drawing.Point(127, 49);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.itemNameTextBox.TabIndex = 49;
            this.itemNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemCommisionTextBox
            // 
            this.itemCommisionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemCommision", true));
            this.itemCommisionTextBox.Location = new System.Drawing.Point(125, 387);
            this.itemCommisionTextBox.Name = "itemCommisionTextBox";
            this.itemCommisionTextBox.Size = new System.Drawing.Size(121, 20);
            this.itemCommisionTextBox.TabIndex = 43;
            this.itemCommisionTextBox.Visible = false;
            // 
            // itemIdTextBox
            // 
            this.itemIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemId", true));
            this.itemIdTextBox.Location = new System.Drawing.Point(127, 23);
            this.itemIdTextBox.Name = "itemIdTextBox";
            this.itemIdTextBox.Size = new System.Drawing.Size(121, 20);
            this.itemIdTextBox.TabIndex = 47;
            this.itemIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // itemDescTextBox
            // 
            this.itemDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemDesc", true));
            this.itemDescTextBox.Location = new System.Drawing.Point(127, 233);
            this.itemDescTextBox.Multiline = true;
            this.itemDescTextBox.Name = "itemDescTextBox";
            this.itemDescTextBox.Size = new System.Drawing.Size(194, 42);
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
            // FormMasterItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterItem";
            this.TabText = "Master Item";
            this.Text = "Master Item";
            this.Load += new System.EventHandler(this.FormMasterItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGudangStokBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox itemPricePurchaseTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label itemStokLabel;
        private System.Windows.Forms.TextBox itemStokTextBox;
        private System.Windows.Forms.TextBox gudangIdTextBox;
        private System.Windows.Forms.TextBox itemMinStokTextBox;
        private System.Windows.Forms.TextBox itemMaxStokTextBox;
        private System.Windows.Forms.TextBox itemIdTextBox1;
        private System.Windows.Forms.ComboBox defaultGudangIdComboBox;
        private System.Windows.Forms.ComboBox itemTypeIdComboBox;
        private System.Windows.Forms.TextBox itemSatuanTextBox;
        private System.Windows.Forms.TextBox itemPriceMinVipTextBox;
        private System.Windows.Forms.TextBox itemPriceMinTextBox;
        private System.Windows.Forms.TextBox itemPriceMaxVipTextBox;
        private System.Windows.Forms.TextBox itemPriceMaxTextBox;
        private System.Windows.Forms.ComboBox groupIdComboBox;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.TextBox itemCommisionTextBox;
        private System.Windows.Forms.TextBox itemIdTextBox;
        private System.Windows.Forms.TextBox itemDescTextBox;
        private System.Windows.Forms.BindingSource itemGudangStokBindingSource;
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
    }
}
