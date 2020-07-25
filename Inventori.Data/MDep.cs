using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class MDep: IEquatable<MDep>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _dep_id; 
		private string _dep_name; 
		private string _dep_status; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MDep()
		{
			_dep_id = String.Empty; 
			_dep_name = String.Empty; 
			_dep_status = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MDep(
			string dep_id)
			: this()
		{
			_dep_id = dep_id;
			_dep_name = String.Empty;
			_dep_status = String.Empty;
			_modified_by = String.Empty;
			_modified_date = DateTime.MinValue;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMDep
        {

					internal string DepId;

					internal string DepName;

					internal string DepStatus;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMDep _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.DepId = this.DepId;	
				
				
					
					this._clone.DepName = this.DepName;	
				
				
					
					this._clone.DepStatus = this.DepStatus;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.DepId = this._clone.DepId;	
				
				
					
					this.DepName = this._clone.DepName;	
				
				
					
					this.DepStatus = this._clone.DepStatus;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMDep();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string DepId
		{
			get
			{ 
				return _dep_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for DepId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DepId", value, value.ToString());
				
				_dep_id = value;
			}
		}
			
		public virtual string DepName
		{
			get
			{ 
				return _dep_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DepName", value, value.ToString());
				
				_dep_name = value;
			}
		}
			
		public virtual string DepStatus
		{
			get
			{ 
				return _dep_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DepStatus", value, value.ToString());
				
				_dep_status = value;
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
			MDep castObj = (MDep)obj; 
			return ( castObj != null ) &&
				( this._dep_id == castObj.DepId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _dep_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MDep other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._dep_id == other.DepId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_dep_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_dep_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_dep_status.ToString()); 
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
		
				public const string DepId = "DepId";
				
				public const string DepName = "DepName";
				
				public const string DepStatus = "DepStatus";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
