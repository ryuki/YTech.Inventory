using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class TRekapCommission: IEquatable<TRekapCommission>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private DateTime _rekap_date_from; 
		private DateTime _rekap_date_to; 
		private string _employee_id; 
		private decimal _rekap_total_duration; 
		private decimal _referee_price; 
		private decimal _referee_price_vip; 
		private decimal _rekap_bonus; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TRekapCommission()
		{
			_rekap_date_from = DateTime.MinValue; 
			_rekap_date_to = DateTime.MinValue; 
			_employee_id = String.Empty; 
			_rekap_total_duration = 0; 
			_referee_price = 0; 
			_referee_price_vip = 0; 
			_rekap_bonus = 0; 
			_modified_by = String.Empty; 
			_modified_date = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TRekapCommission(
			DateTime rekap_date_from, 
			string employee_id)
			: this()
		{
			_rekap_date_from = rekap_date_from;
			_rekap_date_to = DateTime.MinValue;
			_employee_id = employee_id;
			_rekap_total_duration = 0;
			_referee_price = 0;
			_referee_price_vip = 0;
			_rekap_bonus = 0;
			_modified_by = String.Empty;
			_modified_date = DateTime.MinValue;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTRekapCommission
        {

					internal DateTime RekapDateFrom;

					internal DateTime RekapDateTo;

					internal string EmployeeId;

					internal decimal RekapTotalDuration;

					internal decimal RefereePrice;

					internal decimal RefereePriceVip;

					internal decimal RekapBonus;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTRekapCommission _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.RekapDateFrom = this.RekapDateFrom;	
				
				
					
					this._clone.RekapDateTo = this.RekapDateTo;	
				
				
					
					this._clone.EmployeeId = this.EmployeeId;	
				
				
					
					this._clone.RekapTotalDuration = this.RekapTotalDuration;	
				
				
					
					this._clone.RefereePrice = this.RefereePrice;	
				
				
					
					this._clone.RefereePriceVip = this.RefereePriceVip;	
				
				
					
					this._clone.RekapBonus = this.RekapBonus;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.RekapDateFrom = this._clone.RekapDateFrom;	
				
				
					
					this.RekapDateTo = this._clone.RekapDateTo;	
				
				
					
					this.EmployeeId = this._clone.EmployeeId;	
				
				
					
					this.RekapTotalDuration = this._clone.RekapTotalDuration;	
				
				
					
					this.RefereePrice = this._clone.RefereePrice;	
				
				
					
					this.RefereePriceVip = this._clone.RefereePriceVip;	
				
				
					
					this.RekapBonus = this._clone.RekapBonus;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTRekapCommission();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual DateTime RekapDateFrom
		{
			get
			{ 
				return _rekap_date_from;
			}
			set
			{
				_rekap_date_from = value;
			}

		}
			
		public virtual DateTime RekapDateTo
		{
			get
			{ 
				return _rekap_date_to;
			}
			set
			{
				_rekap_date_to = value;
			}

		}
			
		public virtual string EmployeeId
		{
			get
			{ 
				return _employee_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for EmployeeId", value, "null");
				
				if(  value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeeId", value, value.ToString());
				
				_employee_id = value;
			}
		}
			
		public virtual decimal RekapTotalDuration
		{
			get
			{ 
				return _rekap_total_duration;
			}
			set
			{
				_rekap_total_duration = value;
			}

		}
			
		public virtual decimal RefereePrice
		{
			get
			{ 
				return _referee_price;
			}
			set
			{
				_referee_price = value;
			}

		}
			
		public virtual decimal RefereePriceVip
		{
			get
			{ 
				return _referee_price_vip;
			}
			set
			{
				_referee_price_vip = value;
			}

		}
			
		public virtual decimal RekapBonus
		{
			get
			{ 
				return _rekap_bonus;
			}
			set
			{
				_rekap_bonus = value;
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
			TRekapCommission castObj = (TRekapCommission)obj; 
			return ( castObj != null ) &&
				( this._rekap_date_from == castObj.RekapDateFrom ) &&
				( this._employee_id == castObj.EmployeeId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _rekap_date_from.GetHashCode();
			hash = 27 ^ hash ^ _employee_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TRekapCommission other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._rekap_date_from == other.RekapDateFrom ) &&
				( this._employee_id == other.EmployeeId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_rekap_date_from.ToString()); 
			sb.Append("|");						
						
			sb.Append(_rekap_date_to.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_rekap_total_duration.ToString()); 
			sb.Append("|");						
						
			sb.Append(_referee_price.ToString()); 
			sb.Append("|");						
						
			sb.Append(_referee_price_vip.ToString()); 
			sb.Append("|");						
						
			sb.Append(_rekap_bonus.ToString()); 
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
		
				public const string RekapDateFrom = "RekapDateFrom";
				
				public const string RekapDateTo = "RekapDateTo";
				
				public const string EmployeeId = "EmployeeId";
				
				public const string RekapTotalDuration = "RekapTotalDuration";
				
				public const string RefereePrice = "RefereePrice";
				
				public const string RefereePriceVip = "RefereePriceVip";
				
				public const string RekapBonus = "RekapBonus";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
