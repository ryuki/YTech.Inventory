using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class TTransactionDeliveryDetail: IEquatable<TTransactionDeliveryDetail>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _delivery_detail_id; 
		private decimal _delivery_id; 
		private decimal _transaction_detail_id; 
		private string _delivery_detail_item_id; 
		private decimal _delivery_detail_quantity; 
		private string _delivery_detail_desc; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TTransactionDeliveryDetail()
		{
			_delivery_detail_id = 0; 
			_delivery_id = 0; 
			_transaction_detail_id = 0; 
			_delivery_detail_item_id = String.Empty; 
			_delivery_detail_quantity = 0; 
			_delivery_detail_desc = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TTransactionDeliveryDetail(
			decimal delivery_detail_id)
			: this()
		{
			_delivery_detail_id = delivery_detail_id;
			_delivery_id = 0;
			_transaction_detail_id = 0;
			_delivery_detail_item_id = String.Empty;
			_delivery_detail_quantity = 0;
			_delivery_detail_desc = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTTransactionDeliveryDetail
        {

					internal decimal DeliveryDetailId;

					internal decimal DeliveryId;

					internal decimal TransactionDetailId;

					internal string DeliveryDetailItemId;

					internal decimal DeliveryDetailQuantity;

					internal string DeliveryDetailDesc;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTTransactionDeliveryDetail _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.DeliveryDetailId = this.DeliveryDetailId;	
				
				
					
					this._clone.DeliveryId = this.DeliveryId;	
				
				
					
					this._clone.TransactionDetailId = this.TransactionDetailId;	
				
				
					
					this._clone.DeliveryDetailItemId = this.DeliveryDetailItemId;	
				
				
					
					this._clone.DeliveryDetailQuantity = this.DeliveryDetailQuantity;	
				
				
					
					this._clone.DeliveryDetailDesc = this.DeliveryDetailDesc;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.DeliveryDetailId = this._clone.DeliveryDetailId;	
				
				
					
					this.DeliveryId = this._clone.DeliveryId;	
				
				
					
					this.TransactionDetailId = this._clone.TransactionDetailId;	
				
				
					
					this.DeliveryDetailItemId = this._clone.DeliveryDetailItemId;	
				
				
					
					this.DeliveryDetailQuantity = this._clone.DeliveryDetailQuantity;	
				
				
					
					this.DeliveryDetailDesc = this._clone.DeliveryDetailDesc;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTTransactionDeliveryDetail();
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
			TTransactionDeliveryDetail castObj = (TTransactionDeliveryDetail)obj; 
			return ( castObj != null ) &&
				( this._delivery_detail_id == castObj.DeliveryDetailId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _delivery_detail_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TTransactionDeliveryDetail other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._delivery_detail_id == other.DeliveryDetailId );
				   
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
						
			sb.Append(_transaction_detail_id.ToString()); 
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
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string DeliveryDetailId = "DeliveryDetailId";
				
				public const string DeliveryId = "DeliveryId";
				
				public const string TransactionDetailId = "TransactionDetailId";
				
				public const string DeliveryDetailItemId = "DeliveryDetailItemId";
				
				public const string DeliveryDetailQuantity = "DeliveryDetailQuantity";
				
				public const string DeliveryDetailDesc = "DeliveryDetailDesc";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
