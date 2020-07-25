using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class VSupplierDetail: IEquatable<VSupplierDetail>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _supplier_id; 
		private string _supplier_name; 
		private string _supplier_address; 
		private string _supplier_phone; 
		private string _supplier_fax; 
		private string _supplier_npwp; 
		private string _supplier_contact; 
		private string _supplier_contact_phone; 
		private decimal _supplier_limit; 
		private string _sub_account_id; 
		private string _modified_by; 
		private DateTime _modified_date; 
		private string _bank_id; 
		private string _currency_id; 
		private string _supplier_account_no; 
		private string _supplier_account_name; 		
		#endregion

		#region Constructor

		public VSupplierDetail()
		{
			_supplier_id = String.Empty; 
			_supplier_name = String.Empty; 
			_supplier_address = String.Empty; 
			_supplier_phone = String.Empty; 
			_supplier_fax = String.Empty; 
			_supplier_npwp = String.Empty; 
			_supplier_contact = String.Empty; 
			_supplier_contact_phone = String.Empty; 
			_supplier_limit = 0; 
			_sub_account_id = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_bank_id = String.Empty; 
			_currency_id = String.Empty; 
			_supplier_account_no = String.Empty; 
			_supplier_account_name = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public VSupplierDetail(
			string supplier_id, 
			string bank_id, 
			string currency_id, 
			string supplier_account_no, 
			string supplier_account_name)
			: this()
		{
			_supplier_id = supplier_id;
			_supplier_name = String.Empty;
			_supplier_address = String.Empty;
			_supplier_phone = String.Empty;
			_supplier_fax = String.Empty;
			_supplier_npwp = String.Empty;
			_supplier_contact = String.Empty;
			_supplier_contact_phone = String.Empty;
			_supplier_limit = 0;
			_sub_account_id = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_bank_id = bank_id;
			_currency_id = currency_id;
			_supplier_account_no = supplier_account_no;
			_supplier_account_name = supplier_account_name;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructVSupplierDetail
        {

					internal string SupplierId;

					internal string SupplierName;

					internal string SupplierAddress;

					internal string SupplierPhone;

					internal string SupplierFax;

					internal string SupplierNpwp;

					internal string SupplierContact;

					internal string SupplierContactPhone;

					internal decimal SupplierLimit;

					internal string SubAccountId;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

					internal string BankId;

					internal string CurrencyId;

					internal string SupplierAccountNo;

					internal string SupplierAccountName;

        }

        StructVSupplierDetail _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.SupplierId = this.SupplierId;	
				
				
					
					this._clone.SupplierName = this.SupplierName;	
				
				
					
					this._clone.SupplierAddress = this.SupplierAddress;	
				
				
					
					this._clone.SupplierPhone = this.SupplierPhone;	
				
				
					
					this._clone.SupplierFax = this.SupplierFax;	
				
				
					
					this._clone.SupplierNpwp = this.SupplierNpwp;	
				
				
					
					this._clone.SupplierContact = this.SupplierContact;	
				
				
					
					this._clone.SupplierContactPhone = this.SupplierContactPhone;	
				
				
					
					this._clone.SupplierLimit = this.SupplierLimit;	
				
				
					
					this._clone.SubAccountId = this.SubAccountId;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
				
					
					this._clone.BankId = this.BankId;	
				
				
					
					this._clone.CurrencyId = this.CurrencyId;	
				
				
					
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
				
				
					
					this.SupplierName = this._clone.SupplierName;	
				
				
					
					this.SupplierAddress = this._clone.SupplierAddress;	
				
				
					
					this.SupplierPhone = this._clone.SupplierPhone;	
				
				
					
					this.SupplierFax = this._clone.SupplierFax;	
				
				
					
					this.SupplierNpwp = this._clone.SupplierNpwp;	
				
				
					
					this.SupplierContact = this._clone.SupplierContact;	
				
				
					
					this.SupplierContactPhone = this._clone.SupplierContactPhone;	
				
				
					
					this.SupplierLimit = this._clone.SupplierLimit;	
				
				
					
					this.SubAccountId = this._clone.SubAccountId;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
				
					
					this.BankId = this._clone.BankId;	
				
				
					
					this.CurrencyId = this._clone.CurrencyId;	
				
				
					
					this.SupplierAccountNo = this._clone.SupplierAccountNo;	
				
				
					
					this.SupplierAccountName = this._clone.SupplierAccountName;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructVSupplierDetail();
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
				
				if(  value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierId", value, value.ToString());
				
				_supplier_id = value;
			}
		}
			
		public virtual string SupplierName
		{
			get
			{ 
				return _supplier_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierName", value, value.ToString());
				
				_supplier_name = value;
			}
		}
			
		public virtual string SupplierAddress
		{
			get
			{ 
				return _supplier_address;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierAddress", value, value.ToString());
				
				_supplier_address = value;
			}
		}
			
		public virtual string SupplierPhone
		{
			get
			{ 
				return _supplier_phone;
			}

			set	
			{	
				if(  value != null &&  value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierPhone", value, value.ToString());
				
				_supplier_phone = value;
			}
		}
			
		public virtual string SupplierFax
		{
			get
			{ 
				return _supplier_fax;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierFax", value, value.ToString());
				
				_supplier_fax = value;
			}
		}
			
		public virtual string SupplierNpwp
		{
			get
			{ 
				return _supplier_npwp;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierNpwp", value, value.ToString());
				
				_supplier_npwp = value;
			}
		}
			
		public virtual string SupplierContact
		{
			get
			{ 
				return _supplier_contact;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierContact", value, value.ToString());
				
				_supplier_contact = value;
			}
		}
			
		public virtual string SupplierContactPhone
		{
			get
			{ 
				return _supplier_contact_phone;
			}

			set	
			{	
				if(  value != null &&  value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierContactPhone", value, value.ToString());
				
				_supplier_contact_phone = value;
			}
		}
			
		public virtual decimal SupplierLimit
		{
			get
			{ 
				return _supplier_limit;
			}
			set
			{
				_supplier_limit = value;
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
			
		public virtual string BankId
		{
			get
			{ 
				return _bank_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for BankId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for BankId", value, value.ToString());
				
				_bank_id = value;
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
			
		public virtual string SupplierAccountNo
		{
			get
			{ 
				return _supplier_account_no;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for SupplierAccountNo", value, "null");
				
				if(  value.Length > 50)
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
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for SupplierAccountName", value, "null");
				
				if(  value.Length > 100)
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
			VSupplierDetail castObj = (VSupplierDetail)obj; 
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

		public bool Equals(VSupplierDetail other)
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
		
			sb.Append(_supplier_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_address.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_phone.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_fax.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_npwp.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_contact.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_contact_phone.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_limit.ToString()); 
			sb.Append("|");						
						
			sb.Append(_sub_account_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_modified_by.ToString()); 
			sb.Append("|");						
						
			sb.Append(_modified_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_bank_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_currency_id.ToString()); 
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
				
				public const string SupplierName = "SupplierName";
				
				public const string SupplierAddress = "SupplierAddress";
				
				public const string SupplierPhone = "SupplierPhone";
				
				public const string SupplierFax = "SupplierFax";
				
				public const string SupplierNpwp = "SupplierNpwp";
				
				public const string SupplierContact = "SupplierContact";
				
				public const string SupplierContactPhone = "SupplierContactPhone";
				
				public const string SupplierLimit = "SupplierLimit";
				
				public const string SubAccountId = "SubAccountId";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
				public const string BankId = "BankId";
				
				public const string CurrencyId = "CurrencyId";
				
				public const string SupplierAccountNo = "SupplierAccountNo";
				
				public const string SupplierAccountName = "SupplierAccountName";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
