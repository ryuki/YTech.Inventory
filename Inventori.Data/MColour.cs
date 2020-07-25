using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class MColour: IEquatable<MColour>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _colour_id; 
		private string _colour_status; 
		private string _colour_desc; 
		private int _colour_order; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MColour()
		{
			_colour_id = String.Empty; 
			_colour_status = String.Empty; 
			_colour_desc = String.Empty; 
			_colour_order = 0; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MColour(
			string colour_id)
			: this()
		{
			_colour_id = colour_id;
			_colour_status = String.Empty;
			_colour_desc = String.Empty;
			_colour_order = 0;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMColour
        {

					internal string ColourId;

					internal string ColourStatus;

					internal string ColourDesc;

					internal int ColourOrder;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMColour _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.ColourId = this.ColourId;	
				
				
					
					this._clone.ColourStatus = this.ColourStatus;	
				
				
					
					this._clone.ColourDesc = this.ColourDesc;	
				
				
					
					this._clone.ColourOrder = this.ColourOrder;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.ColourId = this._clone.ColourId;	
				
				
					
					this.ColourStatus = this._clone.ColourStatus;	
				
				
					
					this.ColourDesc = this._clone.ColourDesc;	
				
				
					
					this.ColourOrder = this._clone.ColourOrder;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMColour();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string ColourId
		{
			get
			{ 
				return _colour_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for ColourId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ColourId", value, value.ToString());
				
				_colour_id = value;
			}
		}
			
		public virtual string ColourStatus
		{
			get
			{ 
				return _colour_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ColourStatus", value, value.ToString());
				
				_colour_status = value;
			}
		}
			
		public virtual string ColourDesc
		{
			get
			{ 
				return _colour_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 2147483647)
					throw new ArgumentOutOfRangeException("Invalid value for ColourDesc", value, value.ToString());
				
				_colour_desc = value;
			}
		}
			
		public virtual int ColourOrder
		{
			get
			{ 
				return _colour_order;
			}
			set
			{
				_colour_order = value;
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
			MColour castObj = (MColour)obj; 
			return ( castObj != null ) &&
				( this._colour_id == castObj.ColourId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _colour_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MColour other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._colour_id == other.ColourId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_colour_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_colour_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_colour_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_colour_order.ToString()); 
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
		
				public const string ColourId = "ColourId";
				
				public const string ColourStatus = "ColourStatus";
				
				public const string ColourDesc = "ColourDesc";
				
				public const string ColourOrder = "ColourOrder";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
