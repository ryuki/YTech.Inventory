using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class TDesk: IEquatable<TDesk>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _t_desk_id; 
		private string _desk_id; 
		private DateTime _desk_booking_date; 
		private DateTime _desk_in_date; 
		private DateTime _desk_out_date; 
		private string _desk_cust_id; 
		private decimal _desk_long_play_minutes; 
		private string _desk_status; 
		private decimal _desk_transaction_id; 
		private decimal _desk_grand_total; 
		private string _employee_id; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TDesk()
		{
			_t_desk_id = 0; 
			_desk_id = String.Empty; 
			_desk_booking_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_desk_in_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_desk_out_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_desk_cust_id = String.Empty; 
			_desk_long_play_minutes = 0; 
			_desk_status = String.Empty; 
			_desk_transaction_id = 0; 
			_desk_grand_total = 0; 
			_employee_id = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TDesk(
			decimal t_desk_id)
			: this()
		{
			_t_desk_id = t_desk_id;
			_desk_id = String.Empty;
			_desk_booking_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_desk_in_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_desk_out_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_desk_cust_id = String.Empty;
			_desk_long_play_minutes = 0;
			_desk_status = String.Empty;
			_desk_transaction_id = 0;
			_desk_grand_total = 0;
			_employee_id = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTDesk
        {

					internal decimal TDeskId;

					internal string DeskId;

					internal DateTime DeskBookingDate;

					internal DateTime DeskInDate;

					internal DateTime DeskOutDate;

					internal string DeskCustId;

					internal decimal DeskLongPlayMinutes;

					internal string DeskStatus;

					internal decimal DeskTransactionId;

					internal decimal DeskGrandTotal;

					internal string EmployeeId;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTDesk _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.TDeskId = this.TDeskId;	
				
				
					
					this._clone.DeskId = this.DeskId;	
				
				
					
					this._clone.DeskBookingDate = this.DeskBookingDate;	
				
				
					
					this._clone.DeskInDate = this.DeskInDate;	
				
				
					
					this._clone.DeskOutDate = this.DeskOutDate;	
				
				
					
					this._clone.DeskCustId = this.DeskCustId;	
				
				
					
					this._clone.DeskLongPlayMinutes = this.DeskLongPlayMinutes;	
				
				
					
					this._clone.DeskStatus = this.DeskStatus;	
				
				
					
					this._clone.DeskTransactionId = this.DeskTransactionId;	
				
				
					
					this._clone.DeskGrandTotal = this.DeskGrandTotal;	
				
				
					
					this._clone.EmployeeId = this.EmployeeId;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.TDeskId = this._clone.TDeskId;	
				
				
					
					this.DeskId = this._clone.DeskId;	
				
				
					
					this.DeskBookingDate = this._clone.DeskBookingDate;	
				
				
					
					this.DeskInDate = this._clone.DeskInDate;	
				
				
					
					this.DeskOutDate = this._clone.DeskOutDate;	
				
				
					
					this.DeskCustId = this._clone.DeskCustId;	
				
				
					
					this.DeskLongPlayMinutes = this._clone.DeskLongPlayMinutes;	
				
				
					
					this.DeskStatus = this._clone.DeskStatus;	
				
				
					
					this.DeskTransactionId = this._clone.DeskTransactionId;	
				
				
					
					this.DeskGrandTotal = this._clone.DeskGrandTotal;	
				
				
					
					this.EmployeeId = this._clone.EmployeeId;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTDesk();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual decimal TDeskId
		{
			get
			{ 
				return _t_desk_id;
			}
			set
			{
				_t_desk_id = value;
			}

		}
			
		public virtual string DeskId
		{
			get
			{ 
				return _desk_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for DeskId", value, value.ToString());
				
				_desk_id = value;
			}
		}
			
		public virtual DateTime DeskBookingDate
		{
			get
			{ 
				return _desk_booking_date;
			}
			set
			{
				_desk_booking_date = value;
			}

		}
			
		public virtual DateTime DeskInDate
		{
			get
			{ 
				return _desk_in_date;
			}
			set
			{
				_desk_in_date = value;
			}

		}
			
		public virtual DateTime DeskOutDate
		{
			get
			{ 
				return _desk_out_date;
			}
			set
			{
				_desk_out_date = value;
			}

		}
			
		public virtual string DeskCustId
		{
			get
			{ 
				return _desk_cust_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for DeskCustId", value, value.ToString());
				
				_desk_cust_id = value;
			}
		}
			
		public virtual decimal DeskLongPlayMinutes
		{
			get
			{ 
				return _desk_long_play_minutes;
			}
			set
			{
				_desk_long_play_minutes = value;
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
			
		public virtual decimal DeskTransactionId
		{
			get
			{ 
				return _desk_transaction_id;
			}
			set
			{
				_desk_transaction_id = value;
			}

		}
			
		public virtual decimal DeskGrandTotal
		{
			get
			{ 
				return _desk_grand_total;
			}
			set
			{
				_desk_grand_total = value;
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
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeeId", value, value.ToString());
				
				_employee_id = value;
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
			TDesk castObj = (TDesk)obj; 
			return ( castObj != null ) &&
				( this._t_desk_id == castObj.TDeskId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _t_desk_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TDesk other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._t_desk_id == other.TDeskId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_t_desk_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_booking_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_in_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_out_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_cust_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_long_play_minutes.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_transaction_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_grand_total.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_id.ToString()); 
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
		
				public const string TDeskId = "TDeskId";
				
				public const string DeskId = "DeskId";
				
				public const string DeskBookingDate = "DeskBookingDate";
				
				public const string DeskInDate = "DeskInDate";
				
				public const string DeskOutDate = "DeskOutDate";
				
				public const string DeskCustId = "DeskCustId";
				
				public const string DeskLongPlayMinutes = "DeskLongPlayMinutes";
				
				public const string DeskStatus = "DeskStatus";
				
				public const string DeskTransactionId = "DeskTransactionId";
				
				public const string DeskGrandTotal = "DeskGrandTotal";
				
				public const string EmployeeId = "EmployeeId";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
