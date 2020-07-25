using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class VSupplierAccount: IEquatable<VSupplierAccount>, System.ComponentModel.IEditableObject
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
		private string _bank_id_rupiah; 
		private string _supplier_account_no_rupiah; 
		private string _supplier_account_name_rupiah; 
		private string _bank_id_dollar; 
		private string _supplier_account_no_dollar; 
		private string _supplier_account_name_dollar; 		
		#endregion

		#region Constructor

		public VSupplierAccount()
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
			_bank_id_rupiah = String.Empty; 
			_supplier_account_no_rupiah = String.Empty; 
			_supplier_account_name_rupiah = String.Empty; 
			_bank_id_dollar = String.Empty; 
			_supplier_account_no_dollar = String.Empty; 
			_supplier_account_name_dollar = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public VSupplierAccount(
			string supplier_id)
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
			_bank_id_rupiah = String.Empty;
			_supplier_account_no_rupiah = String.Empty;
			_supplier_account_name_rupiah = String.Empty;
			_bank_id_dollar = String.Empty;
			_supplier_account_no_dollar = String.Empty;
			_supplier_account_name_dollar = String.Empty;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructVSupplierAccount
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

					internal string BankIdRupiah;

					internal string SupplierAccountNoRupiah;

					internal string SupplierAccountNameRupiah;

					internal string BankIdDollar;

					internal string SupplierAccountNoDollar;

					internal string SupplierAccountNameDollar;

        }

        StructVSupplierAccount _clone;
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
				
				
					
					this._clone.BankIdRupiah = this.BankIdRupiah;	
				
				
					
					this._clone.SupplierAccountNoRupiah = this.SupplierAccountNoRupiah;	
				
				
					
					this._clone.SupplierAccountNameRupiah = this.SupplierAccountNameRupiah;	
				
				
					
					this._clone.BankIdDollar = this.BankIdDollar;	
				
				
					
					this._clone.SupplierAccountNoDollar = this.SupplierAccountNoDollar;	
				
				
					
					this._clone.SupplierAccountNameDollar = this.SupplierAccountNameDollar;	
				
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
				
				
					
					this.BankIdRupiah = this._clone.BankIdRupiah;	
				
				
					
					this.SupplierAccountNoRupiah = this._clone.SupplierAccountNoRupiah;	
				
				
					
					this.SupplierAccountNameRupiah = this._clone.SupplierAccountNameRupiah;	
				
				
					
					this.BankIdDollar = this._clone.BankIdDollar;	
				
				
					
					this.SupplierAccountNoDollar = this._clone.SupplierAccountNoDollar;	
				
				
					
					this.SupplierAccountNameDollar = this._clone.SupplierAccountNameDollar;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructVSupplierAccount();
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
			
		public virtual string BankIdRupiah
		{
			get
			{ 
				return _bank_id_rupiah;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for BankIdRupiah", value, value.ToString());
				
				_bank_id_rupiah = value;
			}
		}
			
		public virtual string SupplierAccountNoRupiah
		{
			get
			{ 
				return _supplier_account_no_rupiah;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierAccountNoRupiah", value, value.ToString());
				
				_supplier_account_no_rupiah = value;
			}
		}
			
		public virtual string SupplierAccountNameRupiah
		{
			get
			{ 
				return _supplier_account_name_rupiah;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierAccountNameRupiah", value, value.ToString());
				
				_supplier_account_name_rupiah = value;
			}
		}
			
		public virtual string BankIdDollar
		{
			get
			{ 
				return _bank_id_dollar;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for BankIdDollar", value, value.ToString());
				
				_bank_id_dollar = value;
			}
		}
			
		public virtual string SupplierAccountNoDollar
		{
			get
			{ 
				return _supplier_account_no_dollar;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierAccountNoDollar", value, value.ToString());
				
				_supplier_account_no_dollar = value;
			}
		}
			
		public virtual string SupplierAccountNameDollar
		{
			get
			{ 
				return _supplier_account_name_dollar;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierAccountNameDollar", value, value.ToString());
				
				_supplier_account_name_dollar = value;
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
			VSupplierAccount castObj = (VSupplierAccount)obj; 
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

		public bool Equals(VSupplierAccount other)
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
						
			sb.Append(_bank_id_rupiah.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_account_no_rupiah.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_account_name_rupiah.ToString()); 
			sb.Append("|");						
						
			sb.Append(_bank_id_dollar.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_account_no_dollar.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_account_name_dollar.ToString()); 
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
				
				public const string BankIdRupiah = "BankIdRupiah";
				
				public const string SupplierAccountNoRupiah = "SupplierAccountNoRupiah";
				
				public const string SupplierAccountNameRupiah = "SupplierAccountNameRupiah";
				
				public const string BankIdDollar = "BankIdDollar";
				
				public const string SupplierAccountNoDollar = "SupplierAccountNoDollar";
				
				public const string SupplierAccountNameDollar = "SupplierAccountNameDollar";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
