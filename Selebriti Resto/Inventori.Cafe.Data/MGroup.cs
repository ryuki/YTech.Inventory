using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class MGroup: IEquatable<MGroup>
	{

		#region Private Members

		private int _group_id; 
		private string _group_name; 
		private string _modified_by;
        private DateTime _modified_date;
        private bool _print_order;
        private string _printer_name;  		
		#endregion

		#region Constructor

		public MGroup()
		{
			_group_id = 0; 
			_group_name = String.Empty; 
			_modified_by = String.Empty;
            _modified_date = DateTime.MinValue;
            _print_order = false;
            _printer_name = String.Empty;
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MGroup(
			int group_id)
			: this()
		{
			_group_id = group_id;
			_group_name = String.Empty;
			_modified_by = String.Empty;
            _modified_date = DateTime.MinValue;
            _print_order = false;
            _printer_name = String.Empty;
		}
		#endregion // End Constructor
	
	
		#region Public Properties
			
		public virtual int GroupId
		{
			get
			{ 
				return _group_id;
			}
			set
			{
				_group_id = value;
			}

		}
			
		public virtual string GroupName
		{
			get
			{ 
				return _group_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for GroupName", value, value.ToString());
				
				_group_name = value;
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

        public virtual bool PrintOrder
        {
            get
            {
                return _print_order;
            }
            set
            {
                _print_order = value;
            }

        }

        public virtual string PrinterName
        {
            get
            {
                return _printer_name;
            }

            set
            {
                if (value != null && value.Length > 200)
                    throw new ArgumentOutOfRangeException("Invalid value for PrinterName", value, value.ToString());

                _printer_name = value;
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
			MGroup castObj = (MGroup)obj; 
			return ( castObj != null ) &&
				( this._group_id == castObj.GroupId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _group_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MGroup other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._group_id == other.GroupId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_group_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_group_name.ToString()); 
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
		
				public const string GroupId = "GroupId";
				
				public const string GroupName = "GroupName";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
