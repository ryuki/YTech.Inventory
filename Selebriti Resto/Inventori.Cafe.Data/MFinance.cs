using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class MFinance: IEquatable<MFinance>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _finance_id; 
		private string _finance_name; 
		private string _finance_address; 
		private string _finance_phone; 
		private string _finance_fax; 
		private string _finance_status; 
		private string _finance_npwp; 
		private string _finance_desc; 
		private string _finance_desc2; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MFinance()
		{
			_finance_id = String.Empty; 
			_finance_name = String.Empty; 
			_finance_address = String.Empty; 
			_finance_phone = String.Empty; 
			_finance_fax = String.Empty; 
			_finance_status = String.Empty; 
			_finance_npwp = String.Empty; 
			_finance_desc = String.Empty; 
			_finance_desc2 = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MFinance(
			string finance_id)
			: this()
		{
			_finance_id = finance_id;
			_finance_name = String.Empty;
			_finance_address = String.Empty;
			_finance_phone = String.Empty;
			_finance_fax = String.Empty;
			_finance_status = String.Empty;
			_finance_npwp = String.Empty;
			_finance_desc = String.Empty;
			_finance_desc2 = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMFinance
        {

					internal string FinanceId;

					internal string FinanceName;

					internal string FinanceAddress;

					internal string FinancePhone;

					internal string FinanceFax;

					internal string FinanceStatus;

					internal string FinanceNpwp;

					internal string FinanceDesc;

					internal string FinanceDesc2;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMFinance _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.FinanceId = this.FinanceId;	
				
				
					
					this._clone.FinanceName = this.FinanceName;	
				
				
					
					this._clone.FinanceAddress = this.FinanceAddress;	
				
				
					
					this._clone.FinancePhone = this.FinancePhone;	
				
				
					
					this._clone.FinanceFax = this.FinanceFax;	
				
				
					
					this._clone.FinanceStatus = this.FinanceStatus;	
				
				
					
					this._clone.FinanceNpwp = this.FinanceNpwp;	
				
				
					
					this._clone.FinanceDesc = this.FinanceDesc;	
				
				
					
					this._clone.FinanceDesc2 = this.FinanceDesc2;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.FinanceId = this._clone.FinanceId;	
				
				
					
					this.FinanceName = this._clone.FinanceName;	
				
				
					
					this.FinanceAddress = this._clone.FinanceAddress;	
				
				
					
					this.FinancePhone = this._clone.FinancePhone;	
				
				
					
					this.FinanceFax = this._clone.FinanceFax;	
				
				
					
					this.FinanceStatus = this._clone.FinanceStatus;	
				
				
					
					this.FinanceNpwp = this._clone.FinanceNpwp;	
				
				
					
					this.FinanceDesc = this._clone.FinanceDesc;	
				
				
					
					this.FinanceDesc2 = this._clone.FinanceDesc2;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMFinance();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string FinanceId
		{
			get
			{ 
				return _finance_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for FinanceId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for FinanceId", value, value.ToString());
				
				_finance_id = value;
			}
		}
			
		public virtual string FinanceName
		{
			get
			{ 
				return _finance_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for FinanceName", value, value.ToString());
				
				_finance_name = value;
			}
		}
			
		public virtual string FinanceAddress
		{
			get
			{ 
				return _finance_address;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for FinanceAddress", value, value.ToString());
				
				_finance_address = value;
			}
		}
			
		public virtual string FinancePhone
		{
			get
			{ 
				return _finance_phone;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for FinancePhone", value, value.ToString());
				
				_finance_phone = value;
			}
		}
			
		public virtual string FinanceFax
		{
			get
			{ 
				return _finance_fax;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for FinanceFax", value, value.ToString());
				
				_finance_fax = value;
			}
		}
			
		public virtual string FinanceStatus
		{
			get
			{ 
				return _finance_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for FinanceStatus", value, value.ToString());
				
				_finance_status = value;
			}
		}
			
		public virtual string FinanceNpwp
		{
			get
			{ 
				return _finance_npwp;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for FinanceNpwp", value, value.ToString());
				
				_finance_npwp = value;
			}
		}
			
		public virtual string FinanceDesc
		{
			get
			{ 
				return _finance_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for FinanceDesc", value, value.ToString());
				
				_finance_desc = value;
			}
		}
			
		public virtual string FinanceDesc2
		{
			get
			{ 
				return _finance_desc2;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for FinanceDesc2", value, value.ToString());
				
				_finance_desc2 = value;
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
			MFinance castObj = (MFinance)obj; 
			return ( castObj != null ) &&
				( this._finance_id == castObj.FinanceId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _finance_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MFinance other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._finance_id == other.FinanceId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_finance_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_finance_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_finance_address.ToString()); 
			sb.Append("|");						
						
			sb.Append(_finance_phone.ToString()); 
			sb.Append("|");						
						
			sb.Append(_finance_fax.ToString()); 
			sb.Append("|");						
						
			sb.Append(_finance_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_finance_npwp.ToString()); 
			sb.Append("|");						
						
			sb.Append(_finance_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_finance_desc2.ToString()); 
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
		
				public const string FinanceId = "FinanceId";
				
				public const string FinanceName = "FinanceName";
				
				public const string FinanceAddress = "FinanceAddress";
				
				public const string FinancePhone = "FinancePhone";
				
				public const string FinanceFax = "FinanceFax";
				
				public const string FinanceStatus = "FinanceStatus";
				
				public const string FinanceNpwp = "FinanceNpwp";
				
				public const string FinanceDesc = "FinanceDesc";
				
				public const string FinanceDesc2 = "FinanceDesc2";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
