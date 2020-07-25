using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class TTransactionDelivery: IEquatable<TTransactionDelivery>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _delivery_id; 
		private decimal _transaction_id; 
		private string _delivery_number_expedission; 
		private string _delivery_number_pic; 
		private string _delivery_expedission; 
		private string _delivery_pic; 
		private DateTime _delivery_sent_date; 
		private DateTime _delivery_receive_date; 
		private string _delivery_payment; 
		private decimal _delivery_cost; 
		private string _delivery_desc; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TTransactionDelivery()
		{
			_delivery_id = 0; 
			_transaction_id = 0; 
			_delivery_number_expedission = String.Empty; 
			_delivery_number_pic = String.Empty; 
			_delivery_expedission = String.Empty; 
			_delivery_pic = String.Empty; 
			_delivery_sent_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_delivery_receive_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_delivery_payment = String.Empty; 
			_delivery_cost = 0; 
			_delivery_desc = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TTransactionDelivery(
			decimal delivery_id)
			: this()
		{
			_delivery_id = delivery_id;
			_transaction_id = 0;
			_delivery_number_expedission = String.Empty;
			_delivery_number_pic = String.Empty;
			_delivery_expedission = String.Empty;
			_delivery_pic = String.Empty;
			_delivery_sent_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_delivery_receive_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_delivery_payment = String.Empty;
			_delivery_cost = 0;
			_delivery_desc = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTTransactionDelivery
        {

					internal decimal DeliveryId;

					internal decimal TransactionId;

					internal string DeliveryNumberExpedission;

					internal string DeliveryNumberPic;

					internal string DeliveryExpedission;

					internal string DeliveryPic;

					internal DateTime DeliverySentDate;

					internal DateTime DeliveryReceiveDate;

					internal string DeliveryPayment;

					internal decimal DeliveryCost;

					internal string DeliveryDesc;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTTransactionDelivery _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.DeliveryId = this.DeliveryId;	
				
				
					
					this._clone.TransactionId = this.TransactionId;	
				
				
					
					this._clone.DeliveryNumberExpedission = this.DeliveryNumberExpedission;	
				
				
					
					this._clone.DeliveryNumberPic = this.DeliveryNumberPic;	
				
				
					
					this._clone.DeliveryExpedission = this.DeliveryExpedission;	
				
				
					
					this._clone.DeliveryPic = this.DeliveryPic;	
				
				
					
					this._clone.DeliverySentDate = this.DeliverySentDate;	
				
				
					
					this._clone.DeliveryReceiveDate = this.DeliveryReceiveDate;	
				
				
					
					this._clone.DeliveryPayment = this.DeliveryPayment;	
				
				
					
					this._clone.DeliveryCost = this.DeliveryCost;	
				
				
					
					this._clone.DeliveryDesc = this.DeliveryDesc;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.DeliveryId = this._clone.DeliveryId;	
				
				
					
					this.TransactionId = this._clone.TransactionId;	
				
				
					
					this.DeliveryNumberExpedission = this._clone.DeliveryNumberExpedission;	
				
				
					
					this.DeliveryNumberPic = this._clone.DeliveryNumberPic;	
				
				
					
					this.DeliveryExpedission = this._clone.DeliveryExpedission;	
				
				
					
					this.DeliveryPic = this._clone.DeliveryPic;	
				
				
					
					this.DeliverySentDate = this._clone.DeliverySentDate;	
				
				
					
					this.DeliveryReceiveDate = this._clone.DeliveryReceiveDate;	
				
				
					
					this.DeliveryPayment = this._clone.DeliveryPayment;	
				
				
					
					this.DeliveryCost = this._clone.DeliveryCost;	
				
				
					
					this.DeliveryDesc = this._clone.DeliveryDesc;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTTransactionDelivery();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
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
			
		public virtual string DeliveryNumberExpedission
		{
			get
			{ 
				return _delivery_number_expedission;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DeliveryNumberExpedission", value, value.ToString());
				
				_delivery_number_expedission = value;
			}
		}
			
		public virtual string DeliveryNumberPic
		{
			get
			{ 
				return _delivery_number_pic;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DeliveryNumberPic", value, value.ToString());
				
				_delivery_number_pic = value;
			}
		}
			
		public virtual string DeliveryExpedission
		{
			get
			{ 
				return _delivery_expedission;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DeliveryExpedission", value, value.ToString());
				
				_delivery_expedission = value;
			}
		}
			
		public virtual string DeliveryPic
		{
			get
			{ 
				return _delivery_pic;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DeliveryPic", value, value.ToString());
				
				_delivery_pic = value;
			}
		}
			
		public virtual DateTime DeliverySentDate
		{
			get
			{ 
				return _delivery_sent_date;
			}
			set
			{
				_delivery_sent_date = value;
			}

		}
			
		public virtual DateTime DeliveryReceiveDate
		{
			get
			{ 
				return _delivery_receive_date;
			}
			set
			{
				_delivery_receive_date = value;
			}

		}
			
		public virtual string DeliveryPayment
		{
			get
			{ 
				return _delivery_payment;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DeliveryPayment", value, value.ToString());
				
				_delivery_payment = value;
			}
		}
			
		public virtual decimal DeliveryCost
		{
			get
			{ 
				return _delivery_cost;
			}
			set
			{
				_delivery_cost = value;
			}

		}
			
		public virtual string DeliveryDesc
		{
			get
			{ 
				return _delivery_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for DeliveryDesc", value, value.ToString());
				
				_delivery_desc = value;
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
			TTransactionDelivery castObj = (TTransactionDelivery)obj; 
			return ( castObj != null ) &&
				( this._delivery_id == castObj.DeliveryId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _delivery_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TTransactionDelivery other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._delivery_id == other.DeliveryId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_delivery_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_delivery_number_expedission.ToString()); 
			sb.Append("|");						
						
			sb.Append(_delivery_number_pic.ToString()); 
			sb.Append("|");						
						
			sb.Append(_delivery_expedission.ToString()); 
			sb.Append("|");						
						
			sb.Append(_delivery_pic.ToString()); 
			sb.Append("|");						
						
			sb.Append(_delivery_sent_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_delivery_receive_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_delivery_payment.ToString()); 
			sb.Append("|");						
						
			sb.Append(_delivery_cost.ToString()); 
			sb.Append("|");						
						
			sb.Append(_delivery_desc.ToString()); 
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
		
				public const string DeliveryId = "DeliveryId";
				
				public const string TransactionId = "TransactionId";
				
				public const string DeliveryNumberExpedission = "DeliveryNumberExpedission";
				
				public const string DeliveryNumberPic = "DeliveryNumberPic";
				
				public const string DeliveryExpedission = "DeliveryExpedission";
				
				public const string DeliveryPic = "DeliveryPic";
				
				public const string DeliverySentDate = "DeliverySentDate";
				
				public const string DeliveryReceiveDate = "DeliveryReceiveDate";
				
				public const string DeliveryPayment = "DeliveryPayment";
				
				public const string DeliveryCost = "DeliveryCost";
				
				public const string DeliveryDesc = "DeliveryDesc";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
