using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class MBank: IEquatable<MBank>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _bank_id; 
		private string _bank_name; 
		private string _bank_address; 
		private decimal _bank_limit_giro_per_month; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MBank()
		{
			_bank_id = String.Empty; 
			_bank_name = String.Empty; 
			_bank_address = String.Empty; 
			_bank_limit_giro_per_month = 0; 
			_modified_by = String.Empty; 
			_modified_date = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MBank(
			string bank_id)
			: this()
		{
			_bank_id = bank_id;
			_bank_name = String.Empty;
			_bank_address = String.Empty;
			_bank_limit_giro_per_month = 0;
			_modified_by = String.Empty;
			_modified_date = DateTime.MinValue;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMBank
        {

					internal string BankId;

					internal string BankName;

					internal string BankAddress;

					internal decimal BankLimitGiroPerMonth;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMBank _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.BankId = this.BankId;	
				
				
					
					this._clone.BankName = this.BankName;	
				
				
					
					this._clone.BankAddress = this.BankAddress;	
				
				
					
					this._clone.BankLimitGiroPerMonth = this.BankLimitGiroPerMonth;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.BankId = this._clone.BankId;	
				
				
					
					this.BankName = this._clone.BankName;	
				
				
					
					this.BankAddress = this._clone.BankAddress;	
				
				
					
					this.BankLimitGiroPerMonth = this._clone.BankLimitGiroPerMonth;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMBank();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
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
			
		public virtual string BankName
		{
			get
			{ 
				return _bank_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for BankName", value, value.ToString());
				
				_bank_name = value;
			}
		}
			
		public virtual string BankAddress
		{
			get
			{ 
				return _bank_address;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for BankAddress", value, value.ToString());
				
				_bank_address = value;
			}
		}
			
		public virtual decimal BankLimitGiroPerMonth
		{
			get
			{ 
				return _bank_limit_giro_per_month;
			}
			set
			{
				_bank_limit_giro_per_month = value;
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
			MBank castObj = (MBank)obj; 
			return ( castObj != null ) &&
				( this._bank_id == castObj.BankId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _bank_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MBank other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._bank_id == other.BankId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_bank_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_bank_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_bank_address.ToString()); 
			sb.Append("|");						
						
			sb.Append(_bank_limit_giro_per_month.ToString()); 
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
		
				public const string BankId = "BankId";
				
				public const string BankName = "BankName";
				
				public const string BankAddress = "BankAddress";
				
				public const string BankLimitGiroPerMonth = "BankLimitGiroPerMonth";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
