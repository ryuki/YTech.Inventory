using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class MPacket: IEquatable<MPacket>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _packet_id; 
		private string _packet_name; 
		private decimal _packet_discount; 
		private decimal _packet_price; 
		private string _packet_desc; 
		private decimal _packet_price_avg; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MPacket()
		{
			_packet_id = String.Empty; 
			_packet_name = String.Empty; 
			_packet_discount = 0; 
			_packet_price = 0; 
			_packet_desc = String.Empty; 
			_packet_price_avg = 0; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MPacket(
			string packet_id)
			: this()
		{
			_packet_id = packet_id;
			_packet_name = String.Empty;
			_packet_discount = 0;
			_packet_price = 0;
			_packet_desc = String.Empty;
			_packet_price_avg = 0;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMPacket
        {

					internal string PacketId;

					internal string PacketName;

					internal decimal PacketDiscount;

					internal decimal PacketPrice;

					internal string PacketDesc;

					internal decimal PacketPriceAvg;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMPacket _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.PacketId = this.PacketId;	
				
				
					
					this._clone.PacketName = this.PacketName;	
				
				
					
					this._clone.PacketDiscount = this.PacketDiscount;	
				
				
					
					this._clone.PacketPrice = this.PacketPrice;	
				
				
					
					this._clone.PacketDesc = this.PacketDesc;	
				
				
					
					this._clone.PacketPriceAvg = this.PacketPriceAvg;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.PacketId = this._clone.PacketId;	
				
				
					
					this.PacketName = this._clone.PacketName;	
				
				
					
					this.PacketDiscount = this._clone.PacketDiscount;	
				
				
					
					this.PacketPrice = this._clone.PacketPrice;	
				
				
					
					this.PacketDesc = this._clone.PacketDesc;	
				
				
					
					this.PacketPriceAvg = this._clone.PacketPriceAvg;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMPacket();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string PacketId
		{
			get
			{ 
				return _packet_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for PacketId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for PacketId", value, value.ToString());
				
				_packet_id = value;
			}
		}
			
		public virtual string PacketName
		{
			get
			{ 
				return _packet_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for PacketName", value, value.ToString());
				
				_packet_name = value;
			}
		}
			
		public virtual decimal PacketDiscount
		{
			get
			{ 
				return _packet_discount;
			}
			set
			{
				_packet_discount = value;
			}

		}
			
		public virtual decimal PacketPrice
		{
			get
			{ 
				return _packet_price;
			}
			set
			{
				_packet_price = value;
			}

		}
			
		public virtual string PacketDesc
		{
			get
			{ 
				return _packet_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for PacketDesc", value, value.ToString());
				
				_packet_desc = value;
			}
		}
			
		public virtual decimal PacketPriceAvg
		{
			get
			{ 
				return _packet_price_avg;
			}
			set
			{
				_packet_price_avg = value;
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
			MPacket castObj = (MPacket)obj; 
			return ( castObj != null ) &&
				( this._packet_id == castObj.PacketId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _packet_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MPacket other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._packet_id == other.PacketId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_packet_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_packet_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_packet_discount.ToString()); 
			sb.Append("|");						
						
			sb.Append(_packet_price.ToString()); 
			sb.Append("|");						
						
			sb.Append(_packet_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_packet_price_avg.ToString()); 
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
		
				public const string PacketId = "PacketId";
				
				public const string PacketName = "PacketName";
				
				public const string PacketDiscount = "PacketDiscount";
				
				public const string PacketPrice = "PacketPrice";
				
				public const string PacketDesc = "PacketDesc";
				
				public const string PacketPriceAvg = "PacketPriceAvg";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
