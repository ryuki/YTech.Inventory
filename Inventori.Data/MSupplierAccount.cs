using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class MSupplierAccount: IEquatable<MSupplierAccount>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _supplier_id; 
		private string _currency_id; 
		private string _bank_id; 
		private string _supplier_account_no; 
		private string _supplier_account_name; 		
		#endregion

		#region Constructor

		public MSupplierAccount()
		{
			_supplier_id = String.Empty; 
			_currency_id = String.Empty; 
			_bank_id = String.Empty; 
			_supplier_account_no = String.Empty; 
			_supplier_account_name = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MSupplierAccount(
			string supplier_id, 
			string currency_id)
			: this()
		{
			_supplier_id = supplier_id;
			_currency_id = currency_id;
			_bank_id = String.Empty;
			_supplier_account_no = String.Empty;
			_supplier_account_name = String.Empty;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMSupplierAccount
        {

					internal string SupplierId;

					internal string CurrencyId;

					internal string BankId;

					internal string SupplierAccountNo;

					internal string SupplierAccountName;

        }

        StructMSupplierAccount _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.SupplierId = this.SupplierId;	
				
				
					
					this._clone.CurrencyId = this.CurrencyId;	
				
				
					
					this._clone.BankId = this.BankId;	
				
				
					
					this._clone.SupplierAccountNo = this.SupplierAccountNo;	
				
				
					
					this._clone.SupplierAccountName = this.SupplierAccountName;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.SupplierId = this._clone.SupplierId;	
				
				
					
					this.CurrencyId = this._clone.CurrencyId;	
				
				
					
					this.BankId = this._clone.BankId;	
				
				
					
					this.SupplierAccountNo = this._clone.SupplierAccountNo;	
				
				
					
					this.SupplierAccountName = this._clone.SupplierAccountName;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMSupplierAccount();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string SupplierId
		{
			get
			{ 
				return _supplier_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for SupplierId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierId", value, value.ToString());
				
				_supplier_id = value;
			}
		}
			
		public virtual string CurrencyId
		{
			get
			{ 
				return _currency_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for CurrencyId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CurrencyId", value, value.ToString());
				
				_currency_id = value;
			}
		}
			
		public virtual string BankId
		{
			get
			{ 
				return _bank_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for BankId", value, value.ToString());
				
				_bank_id = value;
			}
		}
			
		public virtual string SupplierAccountNo
		{
			get
			{ 
				return _supplier_account_no;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierAccountNo", value, value.ToString());
				
				_supplier_account_no = value;
			}
		}
			
		public virtual string SupplierAccountName
		{
			get
			{ 
				return _supplier_account_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierAccountName", value, value.ToString());
				
				_supplier_account_name = value;
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
			MSupplierAccount castObj = (MSupplierAccount)obj; 
			return ( castObj != null ) &&
				( this._supplier_id == castObj.SupplierId ) &&
				( this._currency_id == castObj.CurrencyId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _supplier_id.GetHashCode();
			hash = 27 ^ hash ^ _currency_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MSupplierAccount other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._supplier_id == other.SupplierId ) &&
				( this._currency_id == other.CurrencyId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_supplier_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_currency_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_bank_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_account_no.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_account_name.ToString()); 
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string SupplierId = "SupplierId";
				
				public const string CurrencyId = "CurrencyId";
				
				public const string BankId = "BankId";
				
				public const string SupplierAccountNo = "SupplierAccountNo";
				
				public const string SupplierAccountName = "SupplierAccountName";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
