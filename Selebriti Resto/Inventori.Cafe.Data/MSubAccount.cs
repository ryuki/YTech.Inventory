using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class MSubAccount: IEquatable<MSubAccount>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _sub_account_id; 
		private string _account_id; 
		private string _sub_account_name; 
		private decimal _sub_account_saldo; 
		private string _sub_account_desc; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MSubAccount()
		{
			_sub_account_id = String.Empty; 
			_account_id = String.Empty; 
			_sub_account_name = String.Empty; 
			_sub_account_saldo = 0; 
			_sub_account_desc = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MSubAccount(
			string sub_account_id)
			: this()
		{
			_sub_account_id = sub_account_id;
			_account_id = String.Empty;
			_sub_account_name = String.Empty;
			_sub_account_saldo = 0;
			_sub_account_desc = String.Empty;
			_modified_by = String.Empty;
			_modified_date = DateTime.MinValue;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMSubAccount
        {

					internal string SubAccountId;

					internal string AccountId;

					internal string SubAccountName;

					internal decimal SubAccountSaldo;

					internal string SubAccountDesc;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMSubAccount _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.SubAccountId = this.SubAccountId;	
				
				
					
					this._clone.AccountId = this.AccountId;	
				
				
					
					this._clone.SubAccountName = this.SubAccountName;	
				
				
					
					this._clone.SubAccountSaldo = this.SubAccountSaldo;	
				
				
					
					this._clone.SubAccountDesc = this.SubAccountDesc;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.SubAccountId = this._clone.SubAccountId;	
				
				
					
					this.AccountId = this._clone.AccountId;	
				
				
					
					this.SubAccountName = this._clone.SubAccountName;	
				
				
					
					this.SubAccountSaldo = this._clone.SubAccountSaldo;	
				
				
					
					this.SubAccountDesc = this._clone.SubAccountDesc;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMSubAccount();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string SubAccountId
		{
			get
			{ 
				return _sub_account_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for SubAccountId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SubAccountId", value, value.ToString());
				
				_sub_account_id = value;
			}
		}
			
		public virtual string AccountId
		{
			get
			{ 
				return _account_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for AccountId", value, value.ToString());
				
				_account_id = value;
			}
		}
			
		public virtual string SubAccountName
		{
			get
			{ 
				return _sub_account_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SubAccountName", value, value.ToString());
				
				_sub_account_name = value;
			}
		}
			
		public virtual decimal SubAccountSaldo
		{
			get
			{ 
				return _sub_account_saldo;
			}
			set
			{
				_sub_account_saldo = value;
			}

		}
			
		public virtual string SubAccountDesc
		{
			get
			{ 
				return _sub_account_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 2147483647)
					throw new ArgumentOutOfRangeException("Invalid value for SubAccountDesc", value, value.ToString());
				
				_sub_account_desc = value;
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
			MSubAccount castObj = (MSubAccount)obj; 
			return ( castObj != null ) &&
				( this._sub_account_id == castObj.SubAccountId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _sub_account_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MSubAccount other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._sub_account_id == other.SubAccountId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_sub_account_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_account_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_sub_account_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_sub_account_saldo.ToString()); 
			sb.Append("|");						
						
			sb.Append(_sub_account_desc.ToString()); 
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
		
				public const string SubAccountId = "SubAccountId";
				
				public const string AccountId = "AccountId";
				
				public const string SubAccountName = "SubAccountName";
				
				public const string SubAccountSaldo = "SubAccountSaldo";
				
				public const string SubAccountDesc = "SubAccountDesc";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
