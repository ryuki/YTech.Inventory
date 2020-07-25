using System;
using System.Collections.Generic;


namespace Inventori.Billiard.Data
{
	[Serializable]
	public class MDiscount: IEquatable<MDiscount>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _disc_id; 
		private decimal _disc; 
		private string _disc_day; 
		private int _disc_time_hour_from; 
		private int _disc_time_min_from; 
		private int _disc_time_hour_to; 
		private int _disc_time_min_to; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MDiscount()
		{
			_disc_id = 0; 
			_disc = 0; 
			_disc_day = String.Empty; 
			_disc_time_hour_from = 0; 
			_disc_time_min_from = 0; 
			_disc_time_hour_to = 0; 
			_disc_time_min_to = 0; 
			_modified_by = String.Empty; 
			_modified_date = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MDiscount(
			decimal disc_id)
			: this()
		{
			_disc_id = disc_id;
			_disc = 0;
			_disc_day = String.Empty;
			_disc_time_hour_from = 0;
			_disc_time_min_from = 0;
			_disc_time_hour_to = 0;
			_disc_time_min_to = 0;
			_modified_by = String.Empty;
			_modified_date = DateTime.MinValue;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMDiscount
        {

					internal decimal DiscId;

					internal decimal Disc;

					internal string DiscDay;

					internal int DiscTimeHourFrom;

					internal int DiscTimeMinFrom;

					internal int DiscTimeHourTo;

					internal int DiscTimeMinTo;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMDiscount _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.DiscId = this.DiscId;	
				
				
					
					this._clone.Disc = this.Disc;	
				
				
					
					this._clone.DiscDay = this.DiscDay;	
				
				
					
					this._clone.DiscTimeHourFrom = this.DiscTimeHourFrom;	
				
				
					
					this._clone.DiscTimeMinFrom = this.DiscTimeMinFrom;	
				
				
					
					this._clone.DiscTimeHourTo = this.DiscTimeHourTo;	
				
				
					
					this._clone.DiscTimeMinTo = this.DiscTimeMinTo;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.DiscId = this._clone.DiscId;	
				
				
					
					this.Disc = this._clone.Disc;	
				
				
					
					this.DiscDay = this._clone.DiscDay;	
				
				
					
					this.DiscTimeHourFrom = this._clone.DiscTimeHourFrom;	
				
				
					
					this.DiscTimeMinFrom = this._clone.DiscTimeMinFrom;	
				
				
					
					this.DiscTimeHourTo = this._clone.DiscTimeHourTo;	
				
				
					
					this.DiscTimeMinTo = this._clone.DiscTimeMinTo;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMDiscount();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual decimal DiscId
		{
			get
			{ 
				return _disc_id;
			}
			set
			{
				_disc_id = value;
			}

		}
			
		public virtual decimal Disc
		{
			get
			{ 
				return _disc;
			}
			set
			{
				_disc = value;
			}

		}
			
		public virtual string DiscDay
		{
			get
			{ 
				return _disc_day;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DiscDay", value, value.ToString());
				
				_disc_day = value;
			}
		}
			
		public virtual int DiscTimeHourFrom
		{
			get
			{ 
				return _disc_time_hour_from;
			}
			set
			{
				_disc_time_hour_from = value;
			}

		}
			
		public virtual int DiscTimeMinFrom
		{
			get
			{ 
				return _disc_time_min_from;
			}
			set
			{
				_disc_time_min_from = value;
			}

		}
			
		public virtual int DiscTimeHourTo
		{
			get
			{ 
				return _disc_time_hour_to;
			}
			set
			{
				_disc_time_hour_to = value;
			}

		}
			
		public virtual int DiscTimeMinTo
		{
			get
			{ 
				return _disc_time_min_to;
			}
			set
			{
				_disc_time_min_to = value;
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
			MDiscount castObj = (MDiscount)obj; 
			return ( castObj != null ) &&
				( this._disc_id == castObj.DiscId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _disc_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MDiscount other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._disc_id == other.DiscId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_disc_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_disc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_disc_day.ToString()); 
			sb.Append("|");						
						
			sb.Append(_disc_time_hour_from.ToString()); 
			sb.Append("|");						
						
			sb.Append(_disc_time_min_from.ToString()); 
			sb.Append("|");						
						
			sb.Append(_disc_time_hour_to.ToString()); 
			sb.Append("|");						
						
			sb.Append(_disc_time_min_to.ToString()); 
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
		
				public const string DiscId = "DiscId";
				
				public const string Disc = "Disc";
				
				public const string DiscDay = "DiscDay";
				
				public const string DiscTimeHourFrom = "DiscTimeHourFrom";
				
				public const string DiscTimeMinFrom = "DiscTimeMinFrom";
				
				public const string DiscTimeHourTo = "DiscTimeHourTo";
				
				public const string DiscTimeMinTo = "DiscTimeMinTo";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
