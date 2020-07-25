using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class TRekapSubAccount: IEquatable<TRekapSubAccount>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _rekap_sub_account_id; 
		private string _rekap_sub_account_periode; 
		private string _account_id; 
		private string _sub_account_id; 
		private decimal _rekap_subaccount_saldo; 
		private string _rekap_subaccount_desc; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TRekapSubAccount()
		{
			_rekap_sub_account_id = 0; 
			_rekap_sub_account_periode = String.Empty; 
			_account_id = String.Empty; 
			_sub_account_id = String.Empty; 
			_rekap_subaccount_saldo = 0; 
			_rekap_subaccount_desc = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TRekapSubAccount(
			decimal rekap_sub_account_id)
			: this()
		{
			_rekap_sub_account_id = rekap_sub_account_id;
			_rekap_sub_account_periode = String.Empty;
			_account_id = String.Empty;
			_sub_account_id = String.Empty;
			_rekap_subaccount_saldo = 0;
			_rekap_subaccount_desc = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTRekapSubAccount
        {

					internal decimal RekapSubAccountId;

					internal string RekapSubAccountPeriode;

					internal string AccountId;

					internal string SubAccountId;

					internal decimal RekapSubaccountSaldo;

					internal string RekapSubaccountDesc;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTRekapSubAccount _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.RekapSubAccountId = this.RekapSubAccountId;	
				
				
					
					this._clone.RekapSubAccountPeriode = this.RekapSubAccountPeriode;	
				
				
					
					this._clone.AccountId = this.AccountId;	
				
				
					
					this._clone.SubAccountId = this.SubAccountId;	
				
				
					
					this._clone.RekapSubaccountSaldo = this.RekapSubaccountSaldo;	
				
				
					
					this._clone.RekapSubaccountDesc = this.RekapSubaccountDesc;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.RekapSubAccountId = this._clone.RekapSubAccountId;	
				
				
					
					this.RekapSubAccountPeriode = this._clone.RekapSubAccountPeriode;	
				
				
					
					this.AccountId = this._clone.AccountId;	
				
				
					
					this.SubAccountId = this._clone.SubAccountId;	
				
				
					
					this.RekapSubaccountSaldo = this._clone.RekapSubaccountSaldo;	
				
				
					
					this.RekapSubaccountDesc = this._clone.RekapSubaccountDesc;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTRekapSubAccount();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual decimal RekapSubAccountId
		{
			get
			{ 
				return _rekap_sub_account_id;
			}
			set
			{
				_rekap_sub_account_id = value;
			}

		}
			
		public virtual string RekapSubAccountPeriode
		{
			get
			{ 
				return _rekap_sub_account_periode;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for RekapSubAccountPeriode", value, value.ToString());
				
				_rekap_sub_account_periode = value;
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
			
		public virtual string SubAccountId
		{
			get
			{ 
				return _sub_account_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SubAccountId", value, value.ToString());
				
				_sub_account_id = value;
			}
		}
			
		public virtual decimal RekapSubaccountSaldo
		{
			get
			{ 
				return _rekap_subaccount_saldo;
			}
			set
			{
				_rekap_subaccount_saldo = value;
			}

		}
			
		public virtual string RekapSubaccountDesc
		{
			get
			{ 
				return _rekap_subaccount_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for RekapSubaccountDesc", value, value.ToString());
				
				_rekap_subaccount_desc = value;
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
			TRekapSubAccount castObj = (TRekapSubAccount)obj; 
			return ( castObj != null ) &&
				( this._rekap_sub_account_id == castObj.RekapSubAccountId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _rekap_sub_account_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TRekapSubAccount other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._rekap_sub_account_id == other.RekapSubAccountId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_rekap_sub_account_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_rekap_sub_account_periode.ToString()); 
			sb.Append("|");						
						
			sb.Append(_account_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_sub_account_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_rekap_subaccount_saldo.ToString()); 
			sb.Append("|");						
						
			sb.Append(_rekap_subaccount_desc.ToString()); 
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
		
				public const string RekapSubAccountId = "RekapSubAccountId";
				
				public const string RekapSubAccountPeriode = "RekapSubAccountPeriode";
				
				public const string AccountId = "AccountId";
				
				public const string SubAccountId = "SubAccountId";
				
				public const string RekapSubaccountSaldo = "RekapSubaccountSaldo";
				
				public const string RekapSubaccountDesc = "RekapSubaccountDesc";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
