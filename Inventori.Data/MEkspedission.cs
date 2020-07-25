using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class MEkspedission: IEquatable<MEkspedission>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _ekspedission_id; 
		private string _ekspedission_name; 
		private string _ekspedission_address; 
		private string _ekspedission_phone; 
		private string _ekspedission_fax; 
		private string _ekspedission_status; 
		private string _ekspedission_npwp; 
		private decimal _ekspedission_disc; 
		private decimal _ekspedission_limit; 
		private string _ekspedission_desc; 
		private string _ekspedission_desc2; 
		private string _sub_account_id; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MEkspedission()
		{
			_ekspedission_id = String.Empty; 
			_ekspedission_name = String.Empty; 
			_ekspedission_address = String.Empty; 
			_ekspedission_phone = String.Empty; 
			_ekspedission_fax = String.Empty; 
			_ekspedission_status = String.Empty; 
			_ekspedission_npwp = String.Empty; 
			_ekspedission_disc = 0; 
			_ekspedission_limit = 0; 
			_ekspedission_desc = String.Empty; 
			_ekspedission_desc2 = String.Empty; 
			_sub_account_id = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MEkspedission(
			string ekspedission_id)
			: this()
		{
			_ekspedission_id = ekspedission_id;
			_ekspedission_name = String.Empty;
			_ekspedission_address = String.Empty;
			_ekspedission_phone = String.Empty;
			_ekspedission_fax = String.Empty;
			_ekspedission_status = String.Empty;
			_ekspedission_npwp = String.Empty;
			_ekspedission_disc = 0;
			_ekspedission_limit = 0;
			_ekspedission_desc = String.Empty;
			_ekspedission_desc2 = String.Empty;
			_sub_account_id = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMEkspedission
        {

					internal string EkspedissionId;

					internal string EkspedissionName;

					internal string EkspedissionAddress;

					internal string EkspedissionPhone;

					internal string EkspedissionFax;

					internal string EkspedissionStatus;

					internal string EkspedissionNpwp;

					internal decimal EkspedissionDisc;

					internal decimal EkspedissionLimit;

					internal string EkspedissionDesc;

					internal string EkspedissionDesc2;

					internal string SubAccountId;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMEkspedission _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.EkspedissionId = this.EkspedissionId;	
				
				
					
					this._clone.EkspedissionName = this.EkspedissionName;	
				
				
					
					this._clone.EkspedissionAddress = this.EkspedissionAddress;	
				
				
					
					this._clone.EkspedissionPhone = this.EkspedissionPhone;	
				
				
					
					this._clone.EkspedissionFax = this.EkspedissionFax;	
				
				
					
					this._clone.EkspedissionStatus = this.EkspedissionStatus;	
				
				
					
					this._clone.EkspedissionNpwp = this.EkspedissionNpwp;	
				
				
					
					this._clone.EkspedissionDisc = this.EkspedissionDisc;	
				
				
					
					this._clone.EkspedissionLimit = this.EkspedissionLimit;	
				
				
					
					this._clone.EkspedissionDesc = this.EkspedissionDesc;	
				
				
					
					this._clone.EkspedissionDesc2 = this.EkspedissionDesc2;	
				
				
					
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
                
				
					
					this.EkspedissionId = this._clone.EkspedissionId;	
				
				
					
					this.EkspedissionName = this._clone.EkspedissionName;	
				
				
					
					this.EkspedissionAddress = this._clone.EkspedissionAddress;	
				
				
					
					this.EkspedissionPhone = this._clone.EkspedissionPhone;	
				
				
					
					this.EkspedissionFax = this._clone.EkspedissionFax;	
				
				
					
					this.EkspedissionStatus = this._clone.EkspedissionStatus;	
				
				
					
					this.EkspedissionNpwp = this._clone.EkspedissionNpwp;	
				
				
					
					this.EkspedissionDisc = this._clone.EkspedissionDisc;	
				
				
					
					this.EkspedissionLimit = this._clone.EkspedissionLimit;	
				
				
					
					this.EkspedissionDesc = this._clone.EkspedissionDesc;	
				
				
					
					this.EkspedissionDesc2 = this._clone.EkspedissionDesc2;	
				
				
					
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
                this._clone = new StructMEkspedission();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string EkspedissionId
		{
			get
			{ 
				return _ekspedission_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for EkspedissionId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EkspedissionId", value, value.ToString());
				
				_ekspedission_id = value;
			}
		}
			
		public virtual string EkspedissionName
		{
			get
			{ 
				return _ekspedission_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EkspedissionName", value, value.ToString());
				
				_ekspedission_name = value;
			}
		}
			
		public virtual string EkspedissionAddress
		{
			get
			{ 
				return _ekspedission_address;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for EkspedissionAddress", value, value.ToString());
				
				_ekspedission_address = value;
			}
		}
			
		public virtual string EkspedissionPhone
		{
			get
			{ 
				return _ekspedission_phone;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EkspedissionPhone", value, value.ToString());
				
				_ekspedission_phone = value;
			}
		}
			
		public virtual string EkspedissionFax
		{
			get
			{ 
				return _ekspedission_fax;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EkspedissionFax", value, value.ToString());
				
				_ekspedission_fax = value;
			}
		}
			
		public virtual string EkspedissionStatus
		{
			get
			{ 
				return _ekspedission_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EkspedissionStatus", value, value.ToString());
				
				_ekspedission_status = value;
			}
		}
			
		public virtual string EkspedissionNpwp
		{
			get
			{ 
				return _ekspedission_npwp;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EkspedissionNpwp", value, value.ToString());
				
				_ekspedission_npwp = value;
			}
		}
			
		public virtual decimal EkspedissionDisc
		{
			get
			{ 
				return _ekspedission_disc;
			}
			set
			{
				_ekspedission_disc = value;
			}

		}
			
		public virtual decimal EkspedissionLimit
		{
			get
			{ 
				return _ekspedission_limit;
			}
			set
			{
				_ekspedission_limit = value;
			}

		}
			
		public virtual string EkspedissionDesc
		{
			get
			{ 
				return _ekspedission_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EkspedissionDesc", value, value.ToString());
				
				_ekspedission_desc = value;
			}
		}
			
		public virtual string EkspedissionDesc2
		{
			get
			{ 
				return _ekspedission_desc2;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EkspedissionDesc2", value, value.ToString());
				
				_ekspedission_desc2 = value;
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
			MEkspedission castObj = (MEkspedission)obj; 
			return ( castObj != null ) &&
				( this._ekspedission_id == castObj.EkspedissionId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _ekspedission_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MEkspedission other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._ekspedission_id == other.EkspedissionId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_ekspedission_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_ekspedission_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_ekspedission_address.ToString()); 
			sb.Append("|");						
						
			sb.Append(_ekspedission_phone.ToString()); 
			sb.Append("|");						
						
			sb.Append(_ekspedission_fax.ToString()); 
			sb.Append("|");						
						
			sb.Append(_ekspedission_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_ekspedission_npwp.ToString()); 
			sb.Append("|");						
						
			sb.Append(_ekspedission_disc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_ekspedission_limit.ToString()); 
			sb.Append("|");						
						
			sb.Append(_ekspedission_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_ekspedission_desc2.ToString()); 
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
		
				public const string EkspedissionId = "EkspedissionId";
				
				public const string EkspedissionName = "EkspedissionName";
				
				public const string EkspedissionAddress = "EkspedissionAddress";
				
				public const string EkspedissionPhone = "EkspedissionPhone";
				
				public const string EkspedissionFax = "EkspedissionFax";
				
				public const string EkspedissionStatus = "EkspedissionStatus";
				
				public const string EkspedissionNpwp = "EkspedissionNpwp";
				
				public const string EkspedissionDisc = "EkspedissionDisc";
				
				public const string EkspedissionLimit = "EkspedissionLimit";
				
				public const string EkspedissionDesc = "EkspedissionDesc";
				
				public const string EkspedissionDesc2 = "EkspedissionDesc2";
				
				public const string SubAccountId = "SubAccountId";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
