using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class MAccount: IEquatable<MAccount>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _account_id; 
		private string _account_name; 
		private string _account_status; 
		private decimal _account_saldo; 
		private string _account_desc; 
		private string _account_position; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MAccount()
		{
			_account_id = String.Empty; 
			_account_name = String.Empty; 
			_account_status = String.Empty; 
			_account_saldo = 0; 
			_account_desc = String.Empty; 
			_account_position = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MAccount(
			string account_id)
			: this()
		{
			_account_id = account_id;
			_account_name = String.Empty;
			_account_status = String.Empty;
			_account_saldo = 0;
			_account_desc = String.Empty;
			_account_position = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMAccount
        {

					internal string AccountId;

					internal string AccountName;

					internal string AccountStatus;

					internal decimal AccountSaldo;

					internal string AccountDesc;

					internal string AccountPosition;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMAccount _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.AccountId = this.AccountId;	
				
				
					
					this._clone.AccountName = this.AccountName;	
				
				
					
					this._clone.AccountStatus = this.AccountStatus;	
				
				
					
					this._clone.AccountSaldo = this.AccountSaldo;	
				
				
					
					this._clone.AccountDesc = this.AccountDesc;	
				
				
					
					this._clone.AccountPosition = this.AccountPosition;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.AccountId = this._clone.AccountId;	
				
				
					
					this.AccountName = this._clone.AccountName;	
				
				
					
					this.AccountStatus = this._clone.AccountStatus;	
				
				
					
					this.AccountSaldo = this._clone.AccountSaldo;	
				
				
					
					this.AccountDesc = this._clone.AccountDesc;	
				
				
					
					this.AccountPosition = this._clone.AccountPosition;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMAccount();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string AccountId
		{
			get
			{ 
				return _account_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for AccountId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for AccountId", value, value.ToString());
				
				_account_id = value;
			}
		}
			
		public virtual string AccountName
		{
			get
			{ 
				return _account_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for AccountName", value, value.ToString());
				
				_account_name = value;
			}
		}
			
		public virtual string AccountStatus
		{
			get
			{ 
				return _account_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for AccountStatus", value, value.ToString());
				
				_account_status = value;
			}
		}
			
		public virtual decimal AccountSaldo
		{
			get
			{ 
				return _account_saldo;
			}
			set
			{
				_account_saldo = value;
			}

		}
			
		public virtual string AccountDesc
		{
			get
			{ 
				return _account_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for AccountDesc", value, value.ToString());
				
				_account_desc = value;
			}
		}
			
		public virtual string AccountPosition
		{
			get
			{ 
				return _account_position;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for AccountPosition", value, value.ToString());
				
				_account_position = value;
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
			MAccount castObj = (MAccount)obj; 
			return ( castObj != null ) &&
				( this._account_id == castObj.AccountId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _account_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MAccount other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._account_id == other.AccountId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_account_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_account_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_account_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_account_saldo.ToString()); 
			sb.Append("|");						
						
			sb.Append(_account_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_account_position.ToString()); 
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
		
				public const string AccountId = "AccountId";
				
				public const string AccountName = "AccountName";
				
				public const string AccountStatus = "AccountStatus";
				
				public const string AccountSaldo = "AccountSaldo";
				
				public const string AccountDesc = "AccountDesc";
				
				public const string AccountPosition = "AccountPosition";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
