using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class VItemDetail: IEquatable<VItemDetail>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _item_id; 
		private int _item_type_id; 
		private int _group_id; 
		private string _item_name; 
		private string _item_satuan; 
		private string _item_desc; 
		private decimal _item_commision; 
		private int _default_gudang_id; 
		private decimal _item_price_max_vip; 
		private decimal _item_price_min_vip; 
		private decimal _item_price_max; 
		private decimal _item_price_min; 
		private decimal _item_price_purchase; 
		private decimal _item_price_purchase_avg; 
		private string _supplier_id; 
		private string _modified_by; 
		private DateTime _modified_date; 
		private string _group_name; 
		private string _item_type_name; 
		private string _gudang_name; 
		private decimal _item_stok; 
		private decimal _item_min_stok; 
		private decimal _item_max_stok; 
		private int _gudang_id; 
		private string _item_position; 		
		#endregion

		#region Constructor

		public VItemDetail()
		{
			_item_id = String.Empty; 
			_item_type_id = 0; 
			_group_id = 0; 
			_item_name = String.Empty; 
			_item_satuan = String.Empty; 
			_item_desc = String.Empty; 
			_item_commision = 0; 
			_default_gudang_id = 0; 
			_item_price_max_vip = 0; 
			_item_price_min_vip = 0; 
			_item_price_max = 0; 
			_item_price_min = 0; 
			_item_price_purchase = 0; 
			_item_price_purchase_avg = 0; 
			_supplier_id = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_group_name = String.Empty; 
			_item_type_name = String.Empty; 
			_gudang_name = String.Empty; 
			_item_stok = 0; 
			_item_min_stok = 0; 
			_item_max_stok = 0; 
			_gudang_id = 0; 
			_item_position = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public VItemDetail(
			string item_id, 
			string group_name, 
			string item_type_name, 
			string gudang_name, 
			decimal item_stok, 
			decimal item_min_stok, 
			decimal item_max_stok, 
			int gudang_id, 
			string item_position)
			: this()
		{
			_item_id = item_id;
			_item_type_id = 0;
			_group_id = 0;
			_item_name = String.Empty;
			_item_satuan = String.Empty;
			_item_desc = String.Empty;
			_item_commision = 0;
			_default_gudang_id = 0;
			_item_price_max_vip = 0;
			_item_price_min_vip = 0;
			_item_price_max = 0;
			_item_price_min = 0;
			_item_price_purchase = 0;
			_item_price_purchase_avg = 0;
			_supplier_id = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_group_name = group_name;
			_item_type_name = item_type_name;
			_gudang_name = gudang_name;
			_item_stok = item_stok;
			_item_min_stok = item_min_stok;
			_item_max_stok = item_max_stok;
			_gudang_id = gudang_id;
			_item_position = item_position;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructVItemDetail
        {

					internal string ItemId;

					internal int ItemTypeId;

					internal int GroupId;

					internal string ItemName;

					internal string ItemSatuan;

					internal string ItemDesc;

					internal decimal ItemCommision;

					internal int DefaultGudangId;

					internal decimal ItemPriceMaxVip;

					internal decimal ItemPriceMinVip;

					internal decimal ItemPriceMax;

					internal decimal ItemPriceMin;

					internal decimal ItemPricePurchase;

					internal decimal ItemPricePurchaseAvg;

					internal string SupplierId;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

					internal string GroupName;

					internal string ItemTypeName;

					internal string GudangName;

					internal decimal ItemStok;

					internal decimal ItemMinStok;

					internal decimal ItemMaxStok;

					internal int GudangId;

					internal string ItemPosition;

        }

        StructVItemDetail _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.ItemId = this.ItemId;	
				
				
					
					this._clone.ItemTypeId = this.ItemTypeId;	
				
				
					
					this._clone.GroupId = this.GroupId;	
				
				
					
					this._clone.ItemName = this.ItemName;	
				
				
					
					this._clone.ItemSatuan = this.ItemSatuan;	
				
				
					
					this._clone.ItemDesc = this.ItemDesc;	
				
				
					
					this._clone.ItemCommision = this.ItemCommision;	
				
				
					
					this._clone.DefaultGudangId = this.DefaultGudangId;	
				
				
					
					this._clone.ItemPriceMaxVip = this.ItemPriceMaxVip;	
				
				
					
					this._clone.ItemPriceMinVip = this.ItemPriceMinVip;	
				
				
					
					this._clone.ItemPriceMax = this.ItemPriceMax;	
				
				
					
					this._clone.ItemPriceMin = this.ItemPriceMin;	
				
				
					
					this._clone.ItemPricePurchase = this.ItemPricePurchase;	
				
				
					
					this._clone.ItemPricePurchaseAvg = this.ItemPricePurchaseAvg;	
				
				
					
					this._clone.SupplierId = this.SupplierId;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
				
					
					this._clone.GroupName = this.GroupName;	
				
				
					
					this._clone.ItemTypeName = this.ItemTypeName;	
				
				
					
					this._clone.GudangName = this.GudangName;	
				
				
					
					this._clone.ItemStok = this.ItemStok;	
				
				
					
					this._clone.ItemMinStok = this.ItemMinStok;	
				
				
					
					this._clone.ItemMaxStok = this.ItemMaxStok;	
				
				
					
					this._clone.GudangId = this.GudangId;	
				
				
					
					this._clone.ItemPosition = this.ItemPosition;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.ItemId = this._clone.ItemId;	
				
				
					
					this.ItemTypeId = this._clone.ItemTypeId;	
				
				
					
					this.GroupId = this._clone.GroupId;	
				
				
					
					this.ItemName = this._clone.ItemName;	
				
				
					
					this.ItemSatuan = this._clone.ItemSatuan;	
				
				
					
					this.ItemDesc = this._clone.ItemDesc;	
				
				
					
					this.ItemCommision = this._clone.ItemCommision;	
				
				
					
					this.DefaultGudangId = this._clone.DefaultGudangId;	
				
				
					
					this.ItemPriceMaxVip = this._clone.ItemPriceMaxVip;	
				
				
					
					this.ItemPriceMinVip = this._clone.ItemPriceMinVip;	
				
				
					
					this.ItemPriceMax = this._clone.ItemPriceMax;	
				
				
					
					this.ItemPriceMin = this._clone.ItemPriceMin;	
				
				
					
					this.ItemPricePurchase = this._clone.ItemPricePurchase;	
				
				
					
					this.ItemPricePurchaseAvg = this._clone.ItemPricePurchaseAvg;	
				
				
					
					this.SupplierId = this._clone.SupplierId;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
				
					
					this.GroupName = this._clone.GroupName;	
				
				
					
					this.ItemTypeName = this._clone.ItemTypeName;	
				
				
					
					this.GudangName = this._clone.GudangName;	
				
				
					
					this.ItemStok = this._clone.ItemStok;	
				
				
					
					this.ItemMinStok = this._clone.ItemMinStok;	
				
				
					
					this.ItemMaxStok = this._clone.ItemMaxStok;	
				
				
					
					this.GudangId = this._clone.GudangId;	
				
				
					
					this.ItemPosition = this._clone.ItemPosition;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructVItemDetail();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string ItemId
		{
			get
			{ 
				return _item_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for ItemId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ItemId", value, value.ToString());
				
				_item_id = value;
			}
		}
			
		public virtual int ItemTypeId
		{
			get
			{ 
				return _item_type_id;
			}
			set
			{
				_item_type_id = value;
			}

		}
			
		public virtual int GroupId
		{
			get
			{ 
				return _group_id;
			}
			set
			{
				_group_id = value;
			}

		}
			
		public virtual string ItemName
		{
			get
			{ 
				return _item_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ItemName", value, value.ToString());
				
				_item_name = value;
			}
		}
			
		public virtual string ItemSatuan
		{
			get
			{ 
				return _item_satuan;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ItemSatuan", value, value.ToString());
				
				_item_satuan = value;
			}
		}
			
		public virtual string ItemDesc
		{
			get
			{ 
				return _item_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 2147483647)
					throw new ArgumentOutOfRangeException("Invalid value for ItemDesc", value, value.ToString());
				
				_item_desc = value;
			}
		}
			
		public virtual decimal ItemCommision
		{
			get
			{ 
				return _item_commision;
			}
			set
			{
				_item_commision = value;
			}

		}
			
		public virtual int DefaultGudangId
		{
			get
			{ 
				return _default_gudang_id;
			}
			set
			{
				_default_gudang_id = value;
			}

		}
			
		public virtual decimal ItemPriceMaxVip
		{
			get
			{ 
				return _item_price_max_vip;
			}
			set
			{
				_item_price_max_vip = value;
			}

		}
			
		public virtual decimal ItemPriceMinVip
		{
			get
			{ 
				return _item_price_min_vip;
			}
			set
			{
				_item_price_min_vip = value;
			}

		}
			
		public virtual decimal ItemPriceMax
		{
			get
			{ 
				return _item_price_max;
			}
			set
			{
				_item_price_max = value;
			}

		}
			
		public virtual decimal ItemPriceMin
		{
			get
			{ 
				return _item_price_min;
			}
			set
			{
				_item_price_min = value;
			}

		}
			
		public virtual decimal ItemPricePurchase
		{
			get
			{ 
				return _item_price_purchase;
			}
			set
			{
				_item_price_purchase = value;
			}

		}
			
		public virtual decimal ItemPricePurchaseAvg
		{
			get
			{ 
				return _item_price_purchase_avg;
			}
			set
			{
				_item_price_purchase_avg = value;
			}

		}
			
		public virtual string SupplierId
		{
			get
			{ 
				return _supplier_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierId", value, value.ToString());
				
				_supplier_id = value;
			}
		}
			
		public virtual string ModifiedBy
		{
			get
			{ 
				return _modified_by;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ModifiedBy", value, value.ToString());
				
				_modified_by = value;
			}
		}
			
		public virtual DateTime ModifiedDate
		{
			get
			{ 
				return _modified_date;
			}
			set
			{
				_modified_date = value;
			}

		}
			
		public virtual string GroupName
		{
			get
			{ 
				return _group_name;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for GroupName", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for GroupName", value, value.ToString());
				
				_group_name = value;
			}
		}
			
		public virtual string ItemTypeName
		{
			get
			{ 
				return _item_type_name;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for ItemTypeName", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ItemTypeName", value, value.ToString());
				
				_item_type_name = value;
			}
		}
			
		public virtual string GudangName
		{
			get
			{ 
				return _gudang_name;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for GudangName", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for GudangName", value, value.ToString());
				
				_gudang_name = value;
			}
		}
			
		public virtual decimal ItemStok
		{
			get
			{ 
				return _item_stok;
			}
			set
			{
				_item_stok = value;
			}

		}
			
		public virtual decimal ItemMinStok
		{
			get
			{ 
				return _item_min_stok;
			}
			set
			{
				_item_min_stok = value;
			}

		}
			
		public virtual decimal ItemMaxStok
		{
			get
			{ 
				return _item_max_stok;
			}
			set
			{
				_item_max_stok = value;
			}

		}
			
		public virtual int GudangId
		{
			get
			{ 
				return _gudang_id;
			}
			set
			{
				_gudang_id = value;
			}

		}
			
		public virtual string ItemPosition
		{
			get
			{ 
				return _item_position;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for ItemPosition", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ItemPosition", value, value.ToString());
				
				_item_position = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		#endregion //Public Functions

		#region Equals And HashCode Overrides
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			VItemDetail castObj = (VItemDetail)obj; 
			return castObj.GetHashCode() == this.GetHashCode();
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			return this.GetType().FullName.GetHashCode();
				
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(VItemDetail other)
		{
			if (other == this)
				return true;
		
			return other.GetHashCode() == this.GetHashCode();
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_item_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_type_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_group_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_satuan.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_commision.ToString()); 
			sb.Append("|");						
						
			sb.Append(_default_gudang_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_price_max_vip.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_price_min_vip.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_price_max.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_price_min.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_price_purchase.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_price_purchase_avg.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_modified_by.ToString()); 
			sb.Append("|");						
						
			sb.Append(_modified_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_group_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_type_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_gudang_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_stok.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_min_stok.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_max_stok.ToString()); 
			sb.Append("|");						
						
			sb.Append(_gudang_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_position.ToString()); 
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string ItemId = "ItemId";
				
				public const string ItemTypeId = "ItemTypeId";
				
				public const string GroupId = "GroupId";
				
				public const string ItemName = "ItemName";
				
				public const string ItemSatuan = "ItemSatuan";
				
				public const string ItemDesc = "ItemDesc";
				
				public const string ItemCommision = "ItemCommision";
				
				public const string DefaultGudangId = "DefaultGudangId";
				
				public const string ItemPriceMaxVip = "ItemPriceMaxVip";
				
				public const string ItemPriceMinVip = "ItemPriceMinVip";
				
				public const string ItemPriceMax = "ItemPriceMax";
				
				public const string ItemPriceMin = "ItemPriceMin";
				
				public const string ItemPricePurchase = "ItemPricePurchase";
				
				public const string ItemPricePurchaseAvg = "ItemPricePurchaseAvg";
				
				public const string SupplierId = "SupplierId";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
				public const string GroupName = "GroupName";
				
				public const string ItemTypeName = "ItemTypeName";
				
				public const string GudangName = "GudangName";
				
				public const string ItemStok = "ItemStok";
				
				public const string ItemMinStok = "ItemMinStok";
				
				public const string ItemMaxStok = "ItemMaxStok";
				
				public const string GudangId = "GudangId";
				
				public const string ItemPosition = "ItemPosition";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
