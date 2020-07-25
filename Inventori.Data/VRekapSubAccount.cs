using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class VRekapSubAccount: IEquatable<VRekapSubAccount>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _rekap_sub_account_id; 
		private string _account_id; 
		private string _account_name; 
		private string _account_status; 
		private decimal _account_saldo; 
		private string _account_desc; 
		private string _account_position; 
		private string _rekap_sub_account_periode; 
		private string _sub_account_id; 
		private decimal _rekap_subaccount_saldo; 
		private string _rekap_subaccount_desc; 
		private string _sub_account_name; 
		private string _sub_account_desc; 		
		#endregion

		#region Constructor

		public VRekapSubAccount()
		{
			_rekap_sub_account_id = 0; 
			_account_id = String.Empty; 
			_account_name = String.Empty; 
			_account_status = String.Empty; 
			_account_saldo = 0; 
			_account_desc = String.Empty; 
			_account_position = String.Empty; 
			_rekap_sub_account_periode = String.Empty; 
			_sub_account_id = String.Empty; 
			_rekap_subaccount_saldo = 0; 
			_rekap_subaccount_desc = String.Empty; 
			_sub_account_name = String.Empty; 
			_sub_account_desc = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public VRekapSubAccount(
			decimal rekap_sub_account_id)
			: this()
		{
			_rekap_sub_account_id = rekap_sub_account_id;
			_account_id = String.Empty;
			_account_name = String.Empty;
			_account_status = String.Empty;
			_account_saldo = 0;
			_account_desc = String.Empty;
			_account_position = String.Empty;
			_rekap_sub_account_periode = String.Empty;
			_sub_account_id = String.Empty;
			_rekap_subaccount_saldo = 0;
			_rekap_subaccount_desc = String.Empty;
			_sub_account_name = String.Empty;
			_sub_account_desc = String.Empty;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructVRekapSubAccount
        {

					internal decimal RekapSubAccountId;

					internal string AccountId;

					internal string AccountName;

					internal string AccountStatus;

					internal decimal AccountSaldo;

					internal string AccountDesc;

					internal string AccountPosition;

					internal string RekapSubAccountPeriode;

					internal string SubAccountId;

					internal decimal RekapSubaccountSaldo;

					internal string RekapSubaccountDesc;

					internal string SubAccountName;

					internal string SubAccountDesc;

        }

        StructVRekapSubAccount _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.RekapSubAccountId = this.RekapSubAccountId;	
				
				
					
					this._clone.AccountId = this.AccountId;	
				
				
					
					this._clone.AccountName = this.AccountName;	
				
				
					
					this._clone.AccountStatus = this.AccountStatus;	
				
				
					
					this._clone.AccountSaldo = this.AccountSaldo;	
				
				
					
					this._clone.AccountDesc = this.AccountDesc;	
				
				
					
					this._clone.AccountPosition = this.AccountPosition;	
				
				
					
					this._clone.RekapSubAccountPeriode = this.RekapSubAccountPeriode;	
				
				
					
					this._clone.SubAccountId = this.SubAccountId;	
				
				
					
					this._clone.RekapSubaccountSaldo = this.RekapSubaccountSaldo;	
				
				
					
					this._clone.RekapSubaccountDesc = this.RekapSubaccountDesc;	
				
				
					
					this._clone.SubAccountName = this.SubAccountName;	
				
				
					
					this._clone.SubAccountDesc = this.SubAccountDesc;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.RekapSubAccountId = this._clone.RekapSubAccountId;	
				
				
					
					this.AccountId = this._clone.AccountId;	
				
				
					
					this.AccountName = this._clone.AccountName;	
				
				
					
					this.AccountStatus = this._clone.AccountStatus;	
				
				
					
					this.AccountSaldo = this._clone.AccountSaldo;	
				
				
					
					this.AccountDesc = this._clone.AccountDesc;	
				
				
					
					this.AccountPosition = this._clone.AccountPosition;	
				
				
					
					this.RekapSubAccountPeriode = this._clone.RekapSubAccountPeriode;	
				
				
					
					this.SubAccountId = this._clone.SubAccountId;	
				
				
					
					this.RekapSubaccountSaldo = this._clone.RekapSubaccountSaldo;	
				
				
					
					this.RekapSubaccountDesc = this._clone.RekapSubaccountDesc;	
				
				
					
					this.SubAccountName = this._clone.SubAccountName;	
				
				
					
					this.SubAccountDesc = this._clone.SubAccountDesc;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructVRekapSubAccount();
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
			VRekapSubAccount castObj = (VRekapSubAccount)obj; 
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

		public bool Equals(VRekapSubAccount other)
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
		
			sb.Append(_rekap_sub_account_id.ToString()); 
			sb.Append("|");						
						
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
						
			sb.Append(_rekap_sub_account_periode.ToString()); 
			sb.Append("|");						
						
			sb.Append(_sub_account_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_rekap_subaccount_saldo.ToString()); 
			sb.Append("|");						
						
			sb.Append(_rekap_subaccount_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_sub_account_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_sub_account_desc.ToString()); 
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string RekapSubAccountId = "RekapSubAccountId";
				
				public const string AccountId = "AccountId";
				
				public const string AccountName = "AccountName";
				
				public const string AccountStatus = "AccountStatus";
				
				public const string AccountSaldo = "AccountSaldo";
				
				public const string AccountDesc = "AccountDesc";
				
				public const string AccountPosition = "AccountPosition";
				
				public const string RekapSubAccountPeriode = "RekapSubAccountPeriode";
				
				public const string SubAccountId = "SubAccountId";
				
				public const string RekapSubaccountSaldo = "RekapSubaccountSaldo";
				
				public const string RekapSubaccountDesc = "RekapSubaccountDesc";
				
				public const string SubAccountName = "SubAccountName";
				
				public const string SubAccountDesc = "SubAccountDesc";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
