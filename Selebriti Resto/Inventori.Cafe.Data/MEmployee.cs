using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class MEmployee: IEquatable<MEmployee>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _employee_id; 
		private string _employee_name; 
		private string _dep_id; 
		private string _employee_gender; 
		private string _employee_id_card; 
		private string _employee_address; 
		private string _employee_phone; 
		private string _employee_birth_place; 
		private DateTime _employee_birth_date; 
		private string _employee_marital_status; 
		private DateTime _employee_start_work; 
		private string _employee_status; 
		private string _employee_desc; 
		private string _employee_desc2; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MEmployee()
		{
			_employee_id = String.Empty; 
			_employee_name = String.Empty; 
			_dep_id = String.Empty; 
			_employee_gender = String.Empty; 
			_employee_id_card = String.Empty; 
			_employee_address = String.Empty; 
			_employee_phone = String.Empty; 
			_employee_birth_place = String.Empty; 
			_employee_birth_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_employee_marital_status = String.Empty; 
			_employee_start_work = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_employee_status = String.Empty; 
			_employee_desc = String.Empty; 
			_employee_desc2 = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MEmployee(
			string employee_id)
			: this()
		{
			_employee_id = employee_id;
			_employee_name = String.Empty;
			_dep_id = String.Empty;
			_employee_gender = String.Empty;
			_employee_id_card = String.Empty;
			_employee_address = String.Empty;
			_employee_phone = String.Empty;
			_employee_birth_place = String.Empty;
			_employee_birth_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_employee_marital_status = String.Empty;
			_employee_start_work = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_employee_status = String.Empty;
			_employee_desc = String.Empty;
			_employee_desc2 = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMEmployee
        {

					internal string EmployeeId;

					internal string EmployeeName;

					internal string DepId;

					internal string EmployeeGender;

					internal string EmployeeIdCard;

					internal string EmployeeAddress;

					internal string EmployeePhone;

					internal string EmployeeBirthPlace;

					internal DateTime EmployeeBirthDate;

					internal string EmployeeMaritalStatus;

					internal DateTime EmployeeStartWork;

					internal string EmployeeStatus;

					internal string EmployeeDesc;

					internal string EmployeeDesc2;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMEmployee _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.EmployeeId = this.EmployeeId;	
				
				
					
					this._clone.EmployeeName = this.EmployeeName;	
				
				
					
					this._clone.DepId = this.DepId;	
				
				
					
					this._clone.EmployeeGender = this.EmployeeGender;	
				
				
					
					this._clone.EmployeeIdCard = this.EmployeeIdCard;	
				
				
					
					this._clone.EmployeeAddress = this.EmployeeAddress;	
				
				
					
					this._clone.EmployeePhone = this.EmployeePhone;	
				
				
					
					this._clone.EmployeeBirthPlace = this.EmployeeBirthPlace;	
				
				
					
					this._clone.EmployeeBirthDate = this.EmployeeBirthDate;	
				
				
					
					this._clone.EmployeeMaritalStatus = this.EmployeeMaritalStatus;	
				
				
					
					this._clone.EmployeeStartWork = this.EmployeeStartWork;	
				
				
					
					this._clone.EmployeeStatus = this.EmployeeStatus;	
				
				
					
					this._clone.EmployeeDesc = this.EmployeeDesc;	
				
				
					
					this._clone.EmployeeDesc2 = this.EmployeeDesc2;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.EmployeeId = this._clone.EmployeeId;	
				
				
					
					this.EmployeeName = this._clone.EmployeeName;	
				
				
					
					this.DepId = this._clone.DepId;	
				
				
					
					this.EmployeeGender = this._clone.EmployeeGender;	
				
				
					
					this.EmployeeIdCard = this._clone.EmployeeIdCard;	
				
				
					
					this.EmployeeAddress = this._clone.EmployeeAddress;	
				
				
					
					this.EmployeePhone = this._clone.EmployeePhone;	
				
				
					
					this.EmployeeBirthPlace = this._clone.EmployeeBirthPlace;	
				
				
					
					this.EmployeeBirthDate = this._clone.EmployeeBirthDate;	
				
				
					
					this.EmployeeMaritalStatus = this._clone.EmployeeMaritalStatus;	
				
				
					
					this.EmployeeStartWork = this._clone.EmployeeStartWork;	
				
				
					
					this.EmployeeStatus = this._clone.EmployeeStatus;	
				
				
					
					this.EmployeeDesc = this._clone.EmployeeDesc;	
				
				
					
					this.EmployeeDesc2 = this._clone.EmployeeDesc2;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMEmployee();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string EmployeeId
		{
			get
			{ 
				return _employee_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for EmployeeId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeeId", value, value.ToString());
				
				_employee_id = value;
			}
		}
			
		public virtual string EmployeeName
		{
			get
			{ 
				return _employee_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeeName", value, value.ToString());
				
				_employee_name = value;
			}
		}
			
		public virtual string DepId
		{
			get
			{ 
				return _dep_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DepId", value, value.ToString());
				
				_dep_id = value;
			}
		}
			
		public virtual string EmployeeGender
		{
			get
			{ 
				return _employee_gender;
			}

			set	
			{	
				if(  value != null &&  value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeeGender", value, value.ToString());
				
				_employee_gender = value;
			}
		}
			
		public virtual string EmployeeIdCard
		{
			get
			{ 
				return _employee_id_card;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeeIdCard", value, value.ToString());
				
				_employee_id_card = value;
			}
		}
			
		public virtual string EmployeeAddress
		{
			get
			{ 
				return _employee_address;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeeAddress", value, value.ToString());
				
				_employee_address = value;
			}
		}
			
		public virtual string EmployeePhone
		{
			get
			{ 
				return _employee_phone;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeePhone", value, value.ToString());
				
				_employee_phone = value;
			}
		}
			
		public virtual string EmployeeBirthPlace
		{
			get
			{ 
				return _employee_birth_place;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeeBirthPlace", value, value.ToString());
				
				_employee_birth_place = value;
			}
		}
			
		public virtual DateTime EmployeeBirthDate
		{
			get
			{ 
				return _employee_birth_date;
			}
			set
			{
				_employee_birth_date = value;
			}

		}
			
		public virtual string EmployeeMaritalStatus
		{
			get
			{ 
				return _employee_marital_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeeMaritalStatus", value, value.ToString());
				
				_employee_marital_status = value;
			}
		}
			
		public virtual DateTime EmployeeStartWork
		{
			get
			{ 
				return _employee_start_work;
			}
			set
			{
				_employee_start_work = value;
			}

		}
			
		public virtual string EmployeeStatus
		{
			get
			{ 
				return _employee_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeeStatus", value, value.ToString());
				
				_employee_status = value;
			}
		}
			
		public virtual string EmployeeDesc
		{
			get
			{ 
				return _employee_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeeDesc", value, value.ToString());
				
				_employee_desc = value;
			}
		}
			
		public virtual string EmployeeDesc2
		{
			get
			{ 
				return _employee_desc2;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeeDesc2", value, value.ToString());
				
				_employee_desc2 = value;
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
			MEmployee castObj = (MEmployee)obj; 
			return ( castObj != null ) &&
				( this._employee_id == castObj.EmployeeId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _employee_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MEmployee other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._employee_id == other.EmployeeId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_employee_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_dep_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_gender.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_id_card.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_address.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_phone.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_birth_place.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_birth_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_marital_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_start_work.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_desc2.ToString()); 
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
		
				public const string EmployeeId = "EmployeeId";
				
				public const string EmployeeName = "EmployeeName";
				
				public const string DepId = "DepId";
				
				public const string EmployeeGender = "EmployeeGender";
				
				public const string EmployeeIdCard = "EmployeeIdCard";
				
				public const string EmployeeAddress = "EmployeeAddress";
				
				public const string EmployeePhone = "EmployeePhone";
				
				public const string EmployeeBirthPlace = "EmployeeBirthPlace";
				
				public const string EmployeeBirthDate = "EmployeeBirthDate";
				
				public const string EmployeeMaritalStatus = "EmployeeMaritalStatus";
				
				public const string EmployeeStartWork = "EmployeeStartWork";
				
				public const string EmployeeStatus = "EmployeeStatus";
				
				public const string EmployeeDesc = "EmployeeDesc";
				
				public const string EmployeeDesc2 = "EmployeeDesc2";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
