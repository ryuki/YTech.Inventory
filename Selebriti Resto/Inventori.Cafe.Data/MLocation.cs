using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class MLocation: IEquatable<MLocation>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private int _location_id; 
		private int _location_parent_id; 
		private string _location_name; 
		private string _location_short_name; 
		private string _location_desc; 
		private bool _location_is_critical; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MLocation()
		{
			_location_id = 0; 
			_location_parent_id = 0; 
			_location_name = String.Empty; 
			_location_short_name = String.Empty; 
			_location_desc = String.Empty; 
			_location_is_critical = false; 
			_modified_by = String.Empty; 
			_modified_date = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MLocation(
			int location_id, 
			int location_parent_id)
			: this()
		{
			_location_id = location_id;
			_location_parent_id = location_parent_id;
			_location_name = String.Empty;
			_location_short_name = String.Empty;
			_location_desc = String.Empty;
			_location_is_critical = false;
			_modified_by = String.Empty;
			_modified_date = DateTime.MinValue;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMLocation
        {

					internal int LocationId;

					internal int LocationParentId;

					internal string LocationName;

					internal string LocationShortName;

					internal string LocationDesc;

					internal bool LocationIsCritical;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMLocation _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.LocationId = this.LocationId;	
				
				
					
					this._clone.LocationParentId = this.LocationParentId;	
				
				
					
					this._clone.LocationName = this.LocationName;	
				
				
					
					this._clone.LocationShortName = this.LocationShortName;	
				
				
					
					this._clone.LocationDesc = this.LocationDesc;	
				
				
					
					this._clone.LocationIsCritical = this.LocationIsCritical;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.LocationId = this._clone.LocationId;	
				
				
					
					this.LocationParentId = this._clone.LocationParentId;	
				
				
					
					this.LocationName = this._clone.LocationName;	
				
				
					
					this.LocationShortName = this._clone.LocationShortName;	
				
				
					
					this.LocationDesc = this._clone.LocationDesc;	
				
				
					
					this.LocationIsCritical = this._clone.LocationIsCritical;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMLocation();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual int LocationId
		{
			get
			{ 
				return _location_id;
			}
			set
			{
				_location_id = value;
			}

		}
			
		public virtual int LocationParentId
		{
			get
			{ 
				return _location_parent_id;
			}
			set
			{
				_location_parent_id = value;
			}

		}
			
		public virtual string LocationName
		{
			get
			{ 
				return _location_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for LocationName", value, value.ToString());
				
				_location_name = value;
			}
		}
			
		public virtual string LocationShortName
		{
			get
			{ 
				return _location_short_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for LocationShortName", value, value.ToString());
				
				_location_short_name = value;
			}
		}
			
		public virtual string LocationDesc
		{
			get
			{ 
				return _location_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 255)
					throw new ArgumentOutOfRangeException("Invalid value for LocationDesc", value, value.ToString());
				
				_location_desc = value;
			}
		}
			
		public virtual bool LocationIsCritical
		{
			get
			{ 
				return _location_is_critical;
			}
			set
			{
				_location_is_critical = value;
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
			MLocation castObj = (MLocation)obj; 
			return ( castObj != null ) &&
				( this._location_id == castObj.LocationId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _location_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MLocation other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._location_id == other.LocationId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_location_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_location_parent_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_location_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_location_short_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_location_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_location_is_critical.ToString()); 
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
		
				public const string LocationId = "LocationId";
				
				public const string LocationParentId = "LocationParentId";
				
				public const string LocationName = "LocationName";
				
				public const string LocationShortName = "LocationShortName";
				
				public const string LocationDesc = "LocationDesc";
				
				public const string LocationIsCritical = "LocationIsCritical";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
