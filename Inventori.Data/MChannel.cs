using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class MChannel: IEquatable<MChannel>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _channel_id; 
		private string _channel_name; 
		private string _channel_address; 
		private string _channel_phone; 
		private string _channel_fax; 
		private string _channel_status; 
		private string _channel_npwp; 
		private string _channel_desc; 
		private string _channel_desc2; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MChannel()
		{
			_channel_id = String.Empty; 
			_channel_name = String.Empty; 
			_channel_address = String.Empty; 
			_channel_phone = String.Empty; 
			_channel_fax = String.Empty; 
			_channel_status = String.Empty; 
			_channel_npwp = String.Empty; 
			_channel_desc = String.Empty; 
			_channel_desc2 = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MChannel(
			string channel_id)
			: this()
		{
			_channel_id = channel_id;
			_channel_name = String.Empty;
			_channel_address = String.Empty;
			_channel_phone = String.Empty;
			_channel_fax = String.Empty;
			_channel_status = String.Empty;
			_channel_npwp = String.Empty;
			_channel_desc = String.Empty;
			_channel_desc2 = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMChannel
        {

					internal string ChannelId;

					internal string ChannelName;

					internal string ChannelAddress;

					internal string ChannelPhone;

					internal string ChannelFax;

					internal string ChannelStatus;

					internal string ChannelNpwp;

					internal string ChannelDesc;

					internal string ChannelDesc2;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMChannel _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.ChannelId = this.ChannelId;	
				
				
					
					this._clone.ChannelName = this.ChannelName;	
				
				
					
					this._clone.ChannelAddress = this.ChannelAddress;	
				
				
					
					this._clone.ChannelPhone = this.ChannelPhone;	
				
				
					
					this._clone.ChannelFax = this.ChannelFax;	
				
				
					
					this._clone.ChannelStatus = this.ChannelStatus;	
				
				
					
					this._clone.ChannelNpwp = this.ChannelNpwp;	
				
				
					
					this._clone.ChannelDesc = this.ChannelDesc;	
				
				
					
					this._clone.ChannelDesc2 = this.ChannelDesc2;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.ChannelId = this._clone.ChannelId;	
				
				
					
					this.ChannelName = this._clone.ChannelName;	
				
				
					
					this.ChannelAddress = this._clone.ChannelAddress;	
				
				
					
					this.ChannelPhone = this._clone.ChannelPhone;	
				
				
					
					this.ChannelFax = this._clone.ChannelFax;	
				
				
					
					this.ChannelStatus = this._clone.ChannelStatus;	
				
				
					
					this.ChannelNpwp = this._clone.ChannelNpwp;	
				
				
					
					this.ChannelDesc = this._clone.ChannelDesc;	
				
				
					
					this.ChannelDesc2 = this._clone.ChannelDesc2;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMChannel();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string ChannelId
		{
			get
			{ 
				return _channel_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for ChannelId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelId", value, value.ToString());
				
				_channel_id = value;
			}
		}
			
		public virtual string ChannelName
		{
			get
			{ 
				return _channel_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelName", value, value.ToString());
				
				_channel_name = value;
			}
		}
			
		public virtual string ChannelAddress
		{
			get
			{ 
				return _channel_address;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelAddress", value, value.ToString());
				
				_channel_address = value;
			}
		}
			
		public virtual string ChannelPhone
		{
			get
			{ 
				return _channel_phone;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelPhone", value, value.ToString());
				
				_channel_phone = value;
			}
		}
			
		public virtual string ChannelFax
		{
			get
			{ 
				return _channel_fax;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelFax", value, value.ToString());
				
				_channel_fax = value;
			}
		}
			
		public virtual string ChannelStatus
		{
			get
			{ 
				return _channel_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelStatus", value, value.ToString());
				
				_channel_status = value;
			}
		}
			
		public virtual string ChannelNpwp
		{
			get
			{ 
				return _channel_npwp;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelNpwp", value, value.ToString());
				
				_channel_npwp = value;
			}
		}
			
		public virtual string ChannelDesc
		{
			get
			{ 
				return _channel_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelDesc", value, value.ToString());
				
				_channel_desc = value;
			}
		}
			
		public virtual string ChannelDesc2
		{
			get
			{ 
				return _channel_desc2;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelDesc2", value, value.ToString());
				
				_channel_desc2 = value;
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
			MChannel castObj = (MChannel)obj; 
			return ( castObj != null ) &&
				( this._channel_id == castObj.ChannelId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _channel_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MChannel other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._channel_id == other.ChannelId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_channel_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_channel_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_channel_address.ToString()); 
			sb.Append("|");						
						
			sb.Append(_channel_phone.ToString()); 
			sb.Append("|");						
						
			sb.Append(_channel_fax.ToString()); 
			sb.Append("|");						
						
			sb.Append(_channel_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_channel_npwp.ToString()); 
			sb.Append("|");						
						
			sb.Append(_channel_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_channel_desc2.ToString()); 
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
		
				public const string ChannelId = "ChannelId";
				
				public const string ChannelName = "ChannelName";
				
				public const string ChannelAddress = "ChannelAddress";
				
				public const string ChannelPhone = "ChannelPhone";
				
				public const string ChannelFax = "ChannelFax";
				
				public const string ChannelStatus = "ChannelStatus";
				
				public const string ChannelNpwp = "ChannelNpwp";
				
				public const string ChannelDesc = "ChannelDesc";
				
				public const string ChannelDesc2 = "ChannelDesc2";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
