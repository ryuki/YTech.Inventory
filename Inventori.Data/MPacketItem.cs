using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class MPacketItem: IEquatable<MPacketItem>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _packet_item_id; 
		private string _packet_id; 
		private string _item_id; 
		private decimal _packet_item_quantity; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MPacketItem()
		{
			_packet_item_id = 0; 
			_packet_id = String.Empty; 
			_item_id = String.Empty; 
			_packet_item_quantity = 0; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MPacketItem(
			decimal packet_item_id)
			: this()
		{
			_packet_item_id = packet_item_id;
			_packet_id = String.Empty;
			_item_id = String.Empty;
			_packet_item_quantity = 0;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMPacketItem
        {

					internal decimal PacketItemId;

					internal string PacketId;

					internal string ItemId;

					internal decimal PacketItemQuantity;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMPacketItem _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.PacketItemId = this.PacketItemId;	
				
				
					
					this._clone.PacketId = this.PacketId;	
				
				
					
					this._clone.ItemId = this.ItemId;	
				
				
					
					this._clone.PacketItemQuantity = this.PacketItemQuantity;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.PacketItemId = this._clone.PacketItemId;	
				
				
					
					this.PacketId = this._clone.PacketId;	
				
				
					
					this.ItemId = this._clone.ItemId;	
				
				
					
					this.PacketItemQuantity = this._clone.PacketItemQuantity;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMPacketItem();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual decimal PacketItemId
		{
			get
			{ 
				return _packet_item_id;
			}
			set
			{
				_packet_item_id = value;
			}

		}
			
		public virtual string PacketId
		{
			get
			{ 
				return _packet_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for PacketId", value, value.ToString());
				
				_packet_id = value;
			}
		}
			
		public virtual string ItemId
		{
			get
			{ 
				return _item_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ItemId", value, value.ToString());
				
				_item_id = value;
			}
		}
			
		public virtual decimal PacketItemQuantity
		{
			get
			{ 
				return _packet_item_quantity;
			}
			set
			{
				_packet_item_quantity = value;
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
			MPacketItem castObj = (MPacketItem)obj; 
			return ( castObj != null ) &&
				( this._packet_item_id == castObj.PacketItemId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _packet_item_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MPacketItem other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._packet_item_id == other.PacketItemId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_packet_item_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_packet_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_packet_item_quantity.ToString()); 
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
		
				public const string PacketItemId = "PacketItemId";
				
				public const string PacketId = "PacketId";
				
				public const string ItemId = "ItemId";
				
				public const string PacketItemQuantity = "PacketItemQuantity";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
