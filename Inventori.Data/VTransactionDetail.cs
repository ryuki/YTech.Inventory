using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class VTransactionDetail: IEquatable<VTransactionDetail>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _transaction_detail_id; 
		private decimal _transaction_id; 
		private string _item_id; 
		private decimal _quantity; 
		private decimal _price; 
		private decimal _jumlah; 
		private decimal _disc; 
		private decimal _ppn; 
		private decimal _total; 
		private string _modified_by; 
		private DateTime _modified_date; 
		private string _description; 
		private DateTime _expired_date; 
		private decimal _commission; 
		private decimal _cost_price; 
		private string _item_name; 
		private string _group_name; 
		private bool _is_packet; 		
		#endregion

		#region Constructor

		public VTransactionDetail()
		{
			_transaction_detail_id = 0; 
			_transaction_id = 0; 
			_item_id = String.Empty; 
			_quantity = 0; 
			_price = 0; 
			_jumlah = 0; 
			_disc = 0; 
			_ppn = 0; 
			_total = 0; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_description = String.Empty; 
			_expired_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_commission = 0; 
			_cost_price = 0; 
			_item_name = String.Empty; 
			_group_name = String.Empty; 
			_is_packet = false; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public VTransactionDetail(
			decimal transaction_detail_id, 
			string item_name, 
			string group_name)
			: this()
		{
			_transaction_detail_id = transaction_detail_id;
			_transaction_id = 0;
			_item_id = String.Empty;
			_quantity = 0;
			_price = 0;
			_jumlah = 0;
			_disc = 0;
			_ppn = 0;
			_total = 0;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_description = String.Empty;
			_expired_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_commission = 0;
			_cost_price = 0;
			_item_name = item_name;
			_group_name = group_name;
			_is_packet = false;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructVTransactionDetail
        {

					internal decimal TransactionDetailId;

					internal decimal TransactionId;

					internal string ItemId;

					internal decimal Quantity;

					internal decimal Price;

					internal decimal Jumlah;

					internal decimal Disc;

					internal decimal Ppn;

					internal decimal Total;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

					internal string Description;

					internal DateTime ExpiredDate;

					internal decimal Commission;

					internal decimal CostPrice;

					internal string ItemName;

					internal string GroupName;

					internal bool IsPacket;

        }

        StructVTransactionDetail _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.TransactionDetailId = this.TransactionDetailId;	
				
				
					
					this._clone.TransactionId = this.TransactionId;	
				
				
					
					this._clone.ItemId = this.ItemId;	
				
				
					
					this._clone.Quantity = this.Quantity;	
				
				
					
					this._clone.Price = this.Price;	
				
				
					
					this._clone.Jumlah = this.Jumlah;	
				
				
					
					this._clone.Disc = this.Disc;	
				
				
					
					this._clone.Ppn = this.Ppn;	
				
				
					
					this._clone.Total = this.Total;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
				
					
					this._clone.Description = this.Description;	
				
				
					
					this._clone.ExpiredDate = this.ExpiredDate;	
				
				
					
					this._clone.Commission = this.Commission;	
				
				
					
					this._clone.CostPrice = this.CostPrice;	
				
				
					
					this._clone.ItemName = this.ItemName;	
				
				
					
					this._clone.GroupName = this.GroupName;	
				
				
					
					this._clone.IsPacket = this.IsPacket;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.TransactionDetailId = this._clone.TransactionDetailId;	
				
				
					
					this.TransactionId = this._clone.TransactionId;	
				
				
					
					this.ItemId = this._clone.ItemId;	
				
				
					
					this.Quantity = this._clone.Quantity;	
				
				
					
					this.Price = this._clone.Price;	
				
				
					
					this.Jumlah = this._clone.Jumlah;	
				
				
					
					this.Disc = this._clone.Disc;	
				
				
					
					this.Ppn = this._clone.Ppn;	
				
				
					
					this.Total = this._clone.Total;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
				
					
					this.Description = this._clone.Description;	
				
				
					
					this.ExpiredDate = this._clone.ExpiredDate;	
				
				
					
					this.Commission = this._clone.Commission;	
				
				
					
					this.CostPrice = this._clone.CostPrice;	
				
				
					
					this.ItemName = this._clone.ItemName;	
				
				
					
					this.GroupName = this._clone.GroupName;	
				
				
					
					this.IsPacket = this._clone.IsPacket;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructVTransactionDetail();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
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
			
		public virtual decimal TransactionId
		{
			get
			{ 
				return _transaction_id;
			}
			set
			{
				_transaction_id = value;
			}

		}
			
		public virtual string ItemId
		{
			get
			{ 
				return _item_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ItemId", value, value.ToString());
				
				_item_id = value;
			}
		}
			
		public virtual decimal Quantity
		{
			get
			{ 
				return _quantity;
			}
			set
			{
				_quantity = value;
			}

		}
			
		public virtual decimal Price
		{
			get
			{ 
				return _price;
			}
			set
			{
				_price = value;
			}

		}
			
		public virtual decimal Jumlah
		{
			get
			{ 
				return _jumlah;
			}
			set
			{
				_jumlah = value;
			}

		}
			
		public virtual decimal Disc
		{
			get
			{ 
				return _disc;
			}
			set
			{
				_disc = value;
			}

		}
			
		public virtual decimal Ppn
		{
			get
			{ 
				return _ppn;
			}
			set
			{
				_ppn = value;
			}

		}
			
		public virtual decimal Total
		{
			get
			{ 
				return _total;
			}
			set
			{
				_total = value;
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
			
		public virtual string Description
		{
			get
			{ 
				return _description;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				
				_description = value;
			}
		}
			
		public virtual DateTime ExpiredDate
		{
			get
			{ 
				return _expired_date;
			}
			set
			{
				_expired_date = value;
			}

		}
			
		public virtual decimal Commission
		{
			get
			{ 
				return _commission;
			}
			set
			{
				_commission = value;
			}

		}
			
		public virtual decimal CostPrice
		{
			get
			{ 
				return _cost_price;
			}
			set
			{
				_cost_price = value;
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
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for ItemName", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ItemName", value, value.ToString());
				
				_item_name = value;
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
			
		public virtual bool IsPacket
		{
			get
			{ 
				return _is_packet;
			}
			set
			{
				_is_packet = value;
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
			VTransactionDetail castObj = (VTransactionDetail)obj; 
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

		public bool Equals(VTransactionDetail other)
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
		
			sb.Append(_transaction_detail_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_quantity.ToString()); 
			sb.Append("|");						
						
			sb.Append(_price.ToString()); 
			sb.Append("|");						
						
			sb.Append(_jumlah.ToString()); 
			sb.Append("|");						
						
			sb.Append(_disc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_ppn.ToString()); 
			sb.Append("|");						
						
			sb.Append(_total.ToString()); 
			sb.Append("|");						
						
			sb.Append(_modified_by.ToString()); 
			sb.Append("|");						
						
			sb.Append(_modified_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_description.ToString()); 
			sb.Append("|");						
						
			sb.Append(_expired_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_commission.ToString()); 
			sb.Append("|");						
						
			sb.Append(_cost_price.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_group_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_is_packet.ToString()); 
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string TransactionDetailId = "TransactionDetailId";
				
				public const string TransactionId = "TransactionId";
				
				public const string ItemId = "ItemId";
				
				public const string Quantity = "Quantity";
				
				public const string Price = "Price";
				
				public const string Jumlah = "Jumlah";
				
				public const string Disc = "Disc";
				
				public const string Ppn = "Ppn";
				
				public const string Total = "Total";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
				public const string Description = "Description";
				
				public const string ExpiredDate = "ExpiredDate";
				
				public const string Commission = "Commission";
				
				public const string CostPrice = "CostPrice";
				
				public const string ItemName = "ItemName";
				
				public const string GroupName = "GroupName";
				
				public const string IsPacket = "IsPacket";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
