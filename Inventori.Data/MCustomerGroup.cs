using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class MCustomerGroup: IEquatable<MCustomerGroup>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _customer_group_id; 
		private string _customer_group_name; 
		private string _customer_group_desc; 
		private decimal _customer_group_percentage; 
		private bool _customer_group_use_percentage; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MCustomerGroup()
		{
			_customer_group_id = String.Empty; 
			_customer_group_name = String.Empty; 
			_customer_group_desc = String.Empty; 
			_customer_group_percentage = 0; 
			_customer_group_use_percentage = false; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MCustomerGroup(
			string customer_group_id)
			: this()
		{
			_customer_group_id = customer_group_id;
			_customer_group_name = String.Empty;
			_customer_group_desc = String.Empty;
			_customer_group_percentage = 0;
			_customer_group_use_percentage = false;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMCustomerGroup
        {

					internal string CustomerGroupId;

					internal string CustomerGroupName;

					internal string CustomerGroupDesc;

					internal decimal CustomerGroupPercentage;

					internal bool CustomerGroupUsePercentage;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMCustomerGroup _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.CustomerGroupId = this.CustomerGroupId;	
				
				
					
					this._clone.CustomerGroupName = this.CustomerGroupName;	
				
				
					
					this._clone.CustomerGroupDesc = this.CustomerGroupDesc;	
				
				
					
					this._clone.CustomerGroupPercentage = this.CustomerGroupPercentage;	
				
				
					
					this._clone.CustomerGroupUsePercentage = this.CustomerGroupUsePercentage;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.CustomerGroupId = this._clone.CustomerGroupId;	
				
				
					
					this.CustomerGroupName = this._clone.CustomerGroupName;	
				
				
					
					this.CustomerGroupDesc = this._clone.CustomerGroupDesc;	
				
				
					
					this.CustomerGroupPercentage = this._clone.CustomerGroupPercentage;	
				
				
					
					this.CustomerGroupUsePercentage = this._clone.CustomerGroupUsePercentage;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMCustomerGroup();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string CustomerGroupId
		{
			get
			{ 
				return _customer_group_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for CustomerGroupId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerGroupId", value, value.ToString());
				
				_customer_group_id = value;
			}
		}
			
		public virtual string CustomerGroupName
		{
			get
			{ 
				return _customer_group_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerGroupName", value, value.ToString());
				
				_customer_group_name = value;
			}
		}
			
		public virtual string CustomerGroupDesc
		{
			get
			{ 
				return _customer_group_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 2147483647)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerGroupDesc", value, value.ToString());
				
				_customer_group_desc = value;
			}
		}
			
		public virtual decimal CustomerGroupPercentage
		{
			get
			{ 
				return _customer_group_percentage;
			}
			set
			{
				_customer_group_percentage = value;
			}

		}
			
		public virtual bool CustomerGroupUsePercentage
		{
			get
			{ 
				return _customer_group_use_percentage;
			}
			set
			{
				_customer_group_use_percentage = value;
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
			MCustomerGroup castObj = (MCustomerGroup)obj; 
			return ( castObj != null ) &&
				( this._customer_group_id == castObj.CustomerGroupId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _customer_group_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MCustomerGroup other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._customer_group_id == other.CustomerGroupId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_customer_group_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_group_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_group_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_group_percentage.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_group_use_percentage.ToString()); 
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
		
				public const string CustomerGroupId = "CustomerGroupId";
				
				public const string CustomerGroupName = "CustomerGroupName";
				
				public const string CustomerGroupDesc = "CustomerGroupDesc";
				
				public const string CustomerGroupPercentage = "CustomerGroupPercentage";
				
				public const string CustomerGroupUsePercentage = "CustomerGroupUsePercentage";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
