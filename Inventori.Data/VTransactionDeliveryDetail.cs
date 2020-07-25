using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class VTransactionDeliveryDetail: IEquatable<VTransactionDeliveryDetail>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _delivery_detail_id; 
		private decimal _delivery_id; 
		private string _delivery_detail_item_id; 
		private decimal _delivery_detail_quantity; 
		private string _delivery_detail_desc; 
		private string _modified_by; 
		private DateTime _modified_date; 
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
		private DateTime _item_expired_date; 
		private string _supplier_id; 
		private decimal _transaction_detail_id; 		
		#endregion

		#region Constructor

		public VTransactionDeliveryDetail()
		{
			_delivery_detail_id = 0; 
			_delivery_id = 0; 
			_delivery_detail_item_id = String.Empty; 
			_delivery_detail_quantity = 0; 
			_delivery_detail_desc = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
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
			_item_expired_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_supplier_id = String.Empty; 
			_transaction_detail_id = 0; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public VTransactionDeliveryDetail(
			decimal delivery_detail_id)
			: this()
		{
			_delivery_detail_id = delivery_detail_id;
			_delivery_id = 0;
			_delivery_detail_item_id = String.Empty;
			_delivery_detail_quantity = 0;
			_delivery_detail_desc = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
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
			_item_expired_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_supplier_id = String.Empty;
			_transaction_detail_id = 0;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructVTransactionDeliveryDetail
        {

					internal decimal DeliveryDetailId;

					internal decimal DeliveryId;

					internal string DeliveryDetailItemId;

					internal decimal DeliveryDetailQuantity;

					internal string DeliveryDetailDesc;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

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

					internal DateTime ItemExpiredDate;

					internal string SupplierId;

					internal decimal TransactionDetailId;

        }

        StructVTransactionDeliveryDetail _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.DeliveryDetailId = this.DeliveryDetailId;	
				
				
					
					this._clone.DeliveryId = this.DeliveryId;	
				
				
					
					this._clone.DeliveryDetailItemId = this.DeliveryDetailItemId;	
				
				
					
					this._clone.DeliveryDetailQuantity = this.DeliveryDetailQuantity;	
				
				
					
					this._clone.DeliveryDetailDesc = this.DeliveryDetailDesc;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
				
					
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
				
				
					
					this._clone.ItemExpiredDate = this.ItemExpiredDate;	
				
				
					
					this._clone.SupplierId = this.SupplierId;	
				
				
					
					this._clone.TransactionDetailId = this.TransactionDetailId;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.DeliveryDetailId = this._clone.DeliveryDetailId;	
				
				
					
					this.DeliveryId = this._clone.DeliveryId;	
				
				
					
					this.DeliveryDetailItemId = this._clone.DeliveryDetailItemId;	
				
				
					
					this.DeliveryDetailQuantity = this._clone.DeliveryDetailQuantity;	
				
				
					
					this.DeliveryDetailDesc = this._clone.DeliveryDetailDesc;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
				
					
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
				
				
					
					this.ItemExpiredDate = this._clone.ItemExpiredDate;	
				
				
					
					this.SupplierId = this._clone.SupplierId;	
				
				
					
					this.TransactionDetailId = this._clone.TransactionDetailId;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructVTransactionDeliveryDetail();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual decimal DeliveryDetailId
		{
			get
			{ 
				return _delivery_detail_id;
			}
			set
			{
				_delivery_detail_id = value;
			}

		}
			
		public virtual decimal DeliveryId
		{
			get
			{ 
				return _delivery_id;
			}
			set
			{
				_delivery_id = value;
			}

		}
			
		public virtual string DeliveryDetailItemId
		{
			get
			{ 
				return _delivery_detail_item_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DeliveryDetailItemId", value, value.ToString());
				
				_delivery_detail_item_id = value;
			}
		}
			
		public virtual decimal DeliveryDetailQuantity
		{
			get
			{ 
				return _delivery_detail_quantity;
			}
			set
			{
				_delivery_detail_quantity = value;
			}

		}
			
		public virtual string DeliveryDetailDesc
		{
			get
			{ 
				return _delivery_detail_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for DeliveryDetailDesc", value, value.ToString());
				
				_delivery_detail_desc = value;
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
			
		public virtual DateTime ItemExpiredDate
		{
			get
			{ 
				return _item_expired_date;
			}
			set
			{
				_item_expired_date = value;
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
			
		public virtual decimal TransactionDetailId
		{
			get
			{ 
				return _transaction_detail_id;
			}
			set
			{
				_transaction_detail_id = value;
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
			VTransactionDeliveryDetail castObj = (VTransactionDeliveryDetail)obj; 
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

		public bool Equals(VTransactionDeliveryDetail other)
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
		
			sb.Append(_delivery_detail_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_delivery_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_delivery_detail_item_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_delivery_detail_quantity.ToString()); 
			sb.Append("|");						
						
			sb.Append(_delivery_detail_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_modified_by.ToString()); 
			sb.Append("|");						
						
			sb.Append(_modified_date.ToString()); 
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
						
			sb.Append(_item_expired_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_detail_id.ToString()); 
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string DeliveryDetailId = "DeliveryDetailId";
				
				public const string DeliveryId = "DeliveryId";
				
				public const string DeliveryDetailItemId = "DeliveryDetailItemId";
				
				public const string DeliveryDetailQuantity = "DeliveryDetailQuantity";
				
				public const string DeliveryDetailDesc = "DeliveryDetailDesc";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
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
				
				public const string ItemExpiredDate = "ItemExpiredDate";
				
				public const string SupplierId = "SupplierId";
				
				public const string TransactionDetailId = "TransactionDetailId";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
