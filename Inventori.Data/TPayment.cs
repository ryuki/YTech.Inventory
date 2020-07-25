using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class TPayment: IEquatable<TPayment>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _payment_id; 
		private string _finance_id; 
		private decimal _payment_ammount; 
		private DateTime _payment_date; 
		private string _transaction_id; 
		private string _payment_desc; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TPayment()
		{
			_payment_id = String.Empty; 
			_finance_id = String.Empty; 
			_payment_ammount = 0; 
			_payment_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_transaction_id = String.Empty; 
			_payment_desc = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TPayment(
			string payment_id)
			: this()
		{
			_payment_id = payment_id;
			_finance_id = String.Empty;
			_payment_ammount = 0;
			_payment_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_transaction_id = String.Empty;
			_payment_desc = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTPayment
        {

					internal string PaymentId;

					internal string FinanceId;

					internal decimal PaymentAmmount;

					internal DateTime PaymentDate;

					internal string TransactionId;

					internal string PaymentDesc;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTPayment _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.PaymentId = this.PaymentId;	
				
				
					
					this._clone.FinanceId = this.FinanceId;	
				
				
					
					this._clone.PaymentAmmount = this.PaymentAmmount;	
				
				
					
					this._clone.PaymentDate = this.PaymentDate;	
				
				
					
					this._clone.TransactionId = this.TransactionId;	
				
				
					
					this._clone.PaymentDesc = this.PaymentDesc;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.PaymentId = this._clone.PaymentId;	
				
				
					
					this.FinanceId = this._clone.FinanceId;	
				
				
					
					this.PaymentAmmount = this._clone.PaymentAmmount;	
				
				
					
					this.PaymentDate = this._clone.PaymentDate;	
				
				
					
					this.TransactionId = this._clone.TransactionId;	
				
				
					
					this.PaymentDesc = this._clone.PaymentDesc;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTPayment();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string PaymentId
		{
			get
			{ 
				return _payment_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for PaymentId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for PaymentId", value, value.ToString());
				
				_payment_id = value;
			}
		}
			
		public virtual string FinanceId
		{
			get
			{ 
				return _finance_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for FinanceId", value, value.ToString());
				
				_finance_id = value;
			}
		}
			
		public virtual decimal PaymentAmmount
		{
			get
			{ 
				return _payment_ammount;
			}
			set
			{
				_payment_ammount = value;
			}

		}
			
		public virtual DateTime PaymentDate
		{
			get
			{ 
				return _payment_date;
			}
			set
			{
				_payment_date = value;
			}

		}
			
		public virtual string TransactionId
		{
			get
			{ 
				return _transaction_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionId", value, value.ToString());
				
				_transaction_id = value;
			}
		}
			
		public virtual string PaymentDesc
		{
			get
			{ 
				return _payment_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for PaymentDesc", value, value.ToString());
				
				_payment_desc = value;
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
			TPayment castObj = (TPayment)obj; 
			return ( castObj != null ) &&
				( this._payment_id == castObj.PaymentId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _payment_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TPayment other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._payment_id == other.PaymentId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_payment_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_finance_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_payment_ammount.ToString()); 
			sb.Append("|");						
						
			sb.Append(_payment_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_payment_desc.ToString()); 
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
		
				public const string PaymentId = "PaymentId";
				
				public const string FinanceId = "FinanceId";
				
				public const string PaymentAmmount = "PaymentAmmount";
				
				public const string PaymentDate = "PaymentDate";
				
				public const string TransactionId = "TransactionId";
				
				public const string PaymentDesc = "PaymentDesc";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
