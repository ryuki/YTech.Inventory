using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class TDefaultAccount: IEquatable<TDefaultAccount>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private int _default_account_id; 
		private string _transaction_type; 
		private string _transaction_payment; 
		private string _debet_sub_account_id; 
		private string _kredit_sub_account_id; 
		private string _description; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TDefaultAccount()
		{
			_default_account_id = 0; 
			_transaction_type = String.Empty; 
			_transaction_payment = String.Empty; 
			_debet_sub_account_id = String.Empty; 
			_kredit_sub_account_id = String.Empty; 
			_description = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TDefaultAccount(
			int default_account_id)
			: this()
		{
			_default_account_id = default_account_id;
			_transaction_type = String.Empty;
			_transaction_payment = String.Empty;
			_debet_sub_account_id = String.Empty;
			_kredit_sub_account_id = String.Empty;
			_description = String.Empty;
			_modified_by = String.Empty;
			_modified_date = DateTime.MinValue;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTDefaultAccount
        {

					internal int DefaultAccountId;

					internal string TransactionType;

					internal string TransactionPayment;

					internal string DebetSubAccountId;

					internal string KreditSubAccountId;

					internal string Description;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTDefaultAccount _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.DefaultAccountId = this.DefaultAccountId;	
				
				
					
					this._clone.TransactionType = this.TransactionType;	
				
				
					
					this._clone.TransactionPayment = this.TransactionPayment;	
				
				
					
					this._clone.DebetSubAccountId = this.DebetSubAccountId;	
				
				
					
					this._clone.KreditSubAccountId = this.KreditSubAccountId;	
				
				
					
					this._clone.Description = this.Description;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.DefaultAccountId = this._clone.DefaultAccountId;	
				
				
					
					this.TransactionType = this._clone.TransactionType;	
				
				
					
					this.TransactionPayment = this._clone.TransactionPayment;	
				
				
					
					this.DebetSubAccountId = this._clone.DebetSubAccountId;	
				
				
					
					this.KreditSubAccountId = this._clone.KreditSubAccountId;	
				
				
					
					this.Description = this._clone.Description;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTDefaultAccount();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual int DefaultAccountId
		{
			get
			{ 
				return _default_account_id;
			}
			set
			{
				_default_account_id = value;
			}

		}
			
		public virtual string TransactionType
		{
			get
			{ 
				return _transaction_type;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionType", value, value.ToString());
				
				_transaction_type = value;
			}
		}
			
		public virtual string TransactionPayment
		{
			get
			{ 
				return _transaction_payment;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionPayment", value, value.ToString());
				
				_transaction_payment = value;
			}
		}
			
		public virtual string DebetSubAccountId
		{
			get
			{ 
				return _debet_sub_account_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DebetSubAccountId", value, value.ToString());
				
				_debet_sub_account_id = value;
			}
		}
			
		public virtual string KreditSubAccountId
		{
			get
			{ 
				return _kredit_sub_account_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for KreditSubAccountId", value, value.ToString());
				
				_kredit_sub_account_id = value;
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
				if(  value != null &&  value.Length > 2147483647)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				
				_description = value;
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
			TDefaultAccount castObj = (TDefaultAccount)obj; 
			return ( castObj != null ) &&
				( this._default_account_id == castObj.DefaultAccountId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _default_account_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TDefaultAccount other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._default_account_id == other.DefaultAccountId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_default_account_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_type.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_payment.ToString()); 
			sb.Append("|");						
						
			sb.Append(_debet_sub_account_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_kredit_sub_account_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_description.ToString()); 
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
		
				public const string DefaultAccountId = "DefaultAccountId";
				
				public const string TransactionType = "TransactionType";
				
				public const string TransactionPayment = "TransactionPayment";
				
				public const string DebetSubAccountId = "DebetSubAccountId";
				
				public const string KreditSubAccountId = "KreditSubAccountId";
				
				public const string Description = "Description";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
