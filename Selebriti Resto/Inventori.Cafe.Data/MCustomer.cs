using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class MCustomer: IEquatable<MCustomer>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _customer_id; 
		private string _customer_name; 
		private string _customer_address; 
		private string _customer_phone; 
		private string _customer_fax; 
		private string _customer_status; 
		private string _customer_npwp; 
		private decimal _customer_disc; 
		private decimal _customer_limit; 
		private string _customer_desc; 
		private string _customer_desc2; 
		private string _sub_account_id; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MCustomer()
		{
			_customer_id = String.Empty; 
			_customer_name = String.Empty; 
			_customer_address = String.Empty; 
			_customer_phone = String.Empty; 
			_customer_fax = String.Empty; 
			_customer_status = String.Empty; 
			_customer_npwp = String.Empty; 
			_customer_disc = 0; 
			_customer_limit = 0; 
			_customer_desc = String.Empty; 
			_customer_desc2 = String.Empty; 
			_sub_account_id = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MCustomer(
			string customer_id)
			: this()
		{
			_customer_id = customer_id;
			_customer_name = String.Empty;
			_customer_address = String.Empty;
			_customer_phone = String.Empty;
			_customer_fax = String.Empty;
			_customer_status = String.Empty;
			_customer_npwp = String.Empty;
			_customer_disc = 0;
			_customer_limit = 0;
			_customer_desc = String.Empty;
			_customer_desc2 = String.Empty;
			_sub_account_id = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMCustomer
        {

					internal string CustomerId;

					internal string CustomerName;

					internal string CustomerAddress;

					internal string CustomerPhone;

					internal string CustomerFax;

					internal string CustomerStatus;

					internal string CustomerNpwp;

					internal decimal CustomerDisc;

					internal decimal CustomerLimit;

					internal string CustomerDesc;

					internal string CustomerDesc2;

					internal string SubAccountId;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMCustomer _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.CustomerId = this.CustomerId;	
				
				
					
					this._clone.CustomerName = this.CustomerName;	
				
				
					
					this._clone.CustomerAddress = this.CustomerAddress;	
				
				
					
					this._clone.CustomerPhone = this.CustomerPhone;	
				
				
					
					this._clone.CustomerFax = this.CustomerFax;	
				
				
					
					this._clone.CustomerStatus = this.CustomerStatus;	
				
				
					
					this._clone.CustomerNpwp = this.CustomerNpwp;	
				
				
					
					this._clone.CustomerDisc = this.CustomerDisc;	
				
				
					
					this._clone.CustomerLimit = this.CustomerLimit;	
				
				
					
					this._clone.CustomerDesc = this.CustomerDesc;	
				
				
					
					this._clone.CustomerDesc2 = this.CustomerDesc2;	
				
				
					
					this._clone.SubAccountId = this.SubAccountId;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.CustomerId = this._clone.CustomerId;	
				
				
					
					this.CustomerName = this._clone.CustomerName;	
				
				
					
					this.CustomerAddress = this._clone.CustomerAddress;	
				
				
					
					this.CustomerPhone = this._clone.CustomerPhone;	
				
				
					
					this.CustomerFax = this._clone.CustomerFax;	
				
				
					
					this.CustomerStatus = this._clone.CustomerStatus;	
				
				
					
					this.CustomerNpwp = this._clone.CustomerNpwp;	
				
				
					
					this.CustomerDisc = this._clone.CustomerDisc;	
				
				
					
					this.CustomerLimit = this._clone.CustomerLimit;	
				
				
					
					this.CustomerDesc = this._clone.CustomerDesc;	
				
				
					
					this.CustomerDesc2 = this._clone.CustomerDesc2;	
				
				
					
					this.SubAccountId = this._clone.SubAccountId;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMCustomer();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string CustomerId
		{
			get
			{ 
				return _customer_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for CustomerId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerId", value, value.ToString());
				
				_customer_id = value;
			}
		}
			
		public virtual string CustomerName
		{
			get
			{ 
				return _customer_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerName", value, value.ToString());
				
				_customer_name = value;
			}
		}
			
		public virtual string CustomerAddress
		{
			get
			{ 
				return _customer_address;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerAddress", value, value.ToString());
				
				_customer_address = value;
			}
		}
			
		public virtual string CustomerPhone
		{
			get
			{ 
				return _customer_phone;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerPhone", value, value.ToString());
				
				_customer_phone = value;
			}
		}
			
		public virtual string CustomerFax
		{
			get
			{ 
				return _customer_fax;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerFax", value, value.ToString());
				
				_customer_fax = value;
			}
		}
			
		public virtual string CustomerStatus
		{
			get
			{ 
				return _customer_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerStatus", value, value.ToString());
				
				_customer_status = value;
			}
		}
			
		public virtual string CustomerNpwp
		{
			get
			{ 
				return _customer_npwp;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerNpwp", value, value.ToString());
				
				_customer_npwp = value;
			}
		}
			
		public virtual decimal CustomerDisc
		{
			get
			{ 
				return _customer_disc;
			}
			set
			{
				_customer_disc = value;
			}

		}
			
		public virtual decimal CustomerLimit
		{
			get
			{ 
				return _customer_limit;
			}
			set
			{
				_customer_limit = value;
			}

		}
			
		public virtual string CustomerDesc
		{
			get
			{ 
				return _customer_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerDesc", value, value.ToString());
				
				_customer_desc = value;
			}
		}
			
		public virtual string CustomerDesc2
		{
			get
			{ 
				return _customer_desc2;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerDesc2", value, value.ToString());
				
				_customer_desc2 = value;
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
			MCustomer castObj = (MCustomer)obj; 
			return ( castObj != null ) &&
				( this._customer_id == castObj.CustomerId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _customer_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MCustomer other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._customer_id == other.CustomerId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_customer_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_address.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_phone.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_fax.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_npwp.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_disc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_limit.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_desc2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_sub_account_id.ToString()); 
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
		
				public const string CustomerId = "CustomerId";
				
				public const string CustomerName = "CustomerName";
				
				public const string CustomerAddress = "CustomerAddress";
				
				public const string CustomerPhone = "CustomerPhone";
				
				public const string CustomerFax = "CustomerFax";
				
				public const string CustomerStatus = "CustomerStatus";
				
				public const string CustomerNpwp = "CustomerNpwp";
				
				public const string CustomerDisc = "CustomerDisc";
				
				public const string CustomerLimit = "CustomerLimit";
				
				public const string CustomerDesc = "CustomerDesc";
				
				public const string CustomerDesc2 = "CustomerDesc2";
				
				public const string SubAccountId = "SubAccountId";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
