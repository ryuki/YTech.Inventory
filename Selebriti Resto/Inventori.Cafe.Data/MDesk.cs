using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class MDesk: IEquatable<MDesk>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _desk_id; 
		private string _desk_status; 
		private string _desk_desc; 
		private int _desk_order; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MDesk()
		{
			_desk_id = String.Empty; 
			_desk_status = String.Empty; 
			_desk_desc = String.Empty; 
			_desk_order = 0; 
			_modified_by = String.Empty; 
			_modified_date = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MDesk(
			string desk_id)
			: this()
		{
			_desk_id = desk_id;
			_desk_status = String.Empty;
			_desk_desc = String.Empty;
			_desk_order = 0;
			_modified_by = String.Empty;
			_modified_date = DateTime.MinValue;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMDesk
        {

					internal string DeskId;

					internal string DeskStatus;

					internal string DeskDesc;

					internal int DeskOrder;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMDesk _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.DeskId = this.DeskId;	
				
				
					
					this._clone.DeskStatus = this.DeskStatus;	
				
				
					
					this._clone.DeskDesc = this.DeskDesc;	
				
				
					
					this._clone.DeskOrder = this.DeskOrder;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.DeskId = this._clone.DeskId;	
				
				
					
					this.DeskStatus = this._clone.DeskStatus;	
				
				
					
					this.DeskDesc = this._clone.DeskDesc;	
				
				
					
					this.DeskOrder = this._clone.DeskOrder;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMDesk();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string DeskId
		{
			get
			{ 
				return _desk_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for DeskId", value, "null");
				
				if(  value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for DeskId", value, value.ToString());
				
				_desk_id = value;
			}
		}
			
		public virtual string DeskStatus
		{
			get
			{ 
				return _desk_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DeskStatus", value, value.ToString());
				
				_desk_status = value;
			}
		}
			
		public virtual string DeskDesc
		{
			get
			{ 
				return _desk_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 2147483647)
					throw new ArgumentOutOfRangeException("Invalid value for DeskDesc", value, value.ToString());
				
				_desk_desc = value;
			}
		}
			
		public virtual int DeskOrder
		{
			get
			{ 
				return _desk_order;
			}
			set
			{
				_desk_order = value;
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
			MDesk castObj = (MDesk)obj; 
			return ( castObj != null ) &&
				( this._desk_id == castObj.DeskId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _desk_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MDesk other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._desk_id == other.DeskId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_desk_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_order.ToString()); 
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
		
				public const string DeskId = "DeskId";
				
				public const string DeskStatus = "DeskStatus";
				
				public const string DeskDesc = "DeskDesc";
				
				public const string DeskOrder = "DeskOrder";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
