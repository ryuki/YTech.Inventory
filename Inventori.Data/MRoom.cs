using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class MRoom: IEquatable<MRoom>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _room_id; 
		private string _room_name; 
		private decimal _room_comission; 
		private string _room_desc; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MRoom()
		{
			_room_id = String.Empty; 
			_room_name = String.Empty; 
			_room_comission = 0; 
			_room_desc = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MRoom(
			string room_id)
			: this()
		{
			_room_id = room_id;
			_room_name = String.Empty;
			_room_comission = 0;
			_room_desc = String.Empty;
			_modified_by = String.Empty;
			_modified_date = DateTime.MinValue;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMRoom
        {

					internal string RoomId;

					internal string RoomName;

					internal decimal RoomComission;

					internal string RoomDesc;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMRoom _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.RoomId = this.RoomId;	
				
				
					
					this._clone.RoomName = this.RoomName;	
				
				
					
					this._clone.RoomComission = this.RoomComission;	
				
				
					
					this._clone.RoomDesc = this.RoomDesc;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.RoomId = this._clone.RoomId;	
				
				
					
					this.RoomName = this._clone.RoomName;	
				
				
					
					this.RoomComission = this._clone.RoomComission;	
				
				
					
					this.RoomDesc = this._clone.RoomDesc;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMRoom();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string RoomId
		{
			get
			{ 
				return _room_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for RoomId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for RoomId", value, value.ToString());
				
				_room_id = value;
			}
		}
			
		public virtual string RoomName
		{
			get
			{ 
				return _room_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for RoomName", value, value.ToString());
				
				_room_name = value;
			}
		}
			
		public virtual decimal RoomComission
		{
			get
			{ 
				return _room_comission;
			}
			set
			{
				_room_comission = value;
			}

		}
			
		public virtual string RoomDesc
		{
			get
			{ 
				return _room_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 2147483647)
					throw new ArgumentOutOfRangeException("Invalid value for RoomDesc", value, value.ToString());
				
				_room_desc = value;
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
			MRoom castObj = (MRoom)obj; 
			return ( castObj != null ) &&
				( this._room_id == castObj.RoomId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _room_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MRoom other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._room_id == other.RoomId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_room_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_room_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_room_comission.ToString()); 
			sb.Append("|");						
						
			sb.Append(_room_desc.ToString()); 
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
		
				public const string RoomId = "RoomId";
				
				public const string RoomName = "RoomName";
				
				public const string RoomComission = "RoomComission";
				
				public const string RoomDesc = "RoomDesc";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
