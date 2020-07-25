using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class TRekapTransaction: IEquatable<TRekapTransaction>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private DateTime _rekap_date_from; 
		private DateTime _rekap_date_to; 
		private string _desk_id; 
		private decimal _total_sales; 
		private decimal _total_sales_vip; 
		private decimal _total_purchase; 
		private decimal _total_retur_sales; 
		private decimal _total_retur_sales_vip; 
		private decimal _total_retur_purchase; 
		private decimal _total_correction; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TRekapTransaction()
		{
			_rekap_date_from = DateTime.MinValue; 
			_rekap_date_to = DateTime.MinValue; 
			_desk_id = String.Empty; 
			_total_sales = 0; 
			_total_sales_vip = 0; 
			_total_purchase = 0; 
			_total_retur_sales = 0; 
			_total_retur_sales_vip = 0; 
			_total_retur_purchase = 0; 
			_total_correction = 0; 
			_modified_by = String.Empty; 
			_modified_date = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TRekapTransaction(
			DateTime rekap_date_from)
			: this()
		{
			_rekap_date_from = rekap_date_from;
			_rekap_date_to = DateTime.MinValue;
			_desk_id = String.Empty;
			_total_sales = 0;
			_total_sales_vip = 0;
			_total_purchase = 0;
			_total_retur_sales = 0;
			_total_retur_sales_vip = 0;
			_total_retur_purchase = 0;
			_total_correction = 0;
			_modified_by = String.Empty;
			_modified_date = DateTime.MinValue;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTRekapTransaction
        {

					internal DateTime RekapDateFrom;

					internal DateTime RekapDateTo;

					internal string DeskId;

					internal decimal TotalSales;

					internal decimal TotalSalesVip;

					internal decimal TotalPurchase;

					internal decimal TotalReturSales;

					internal decimal TotalReturSalesVip;

					internal decimal TotalReturPurchase;

					internal decimal TotalCorrection;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTRekapTransaction _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.RekapDateFrom = this.RekapDateFrom;	
				
				
					
					this._clone.RekapDateTo = this.RekapDateTo;	
				
				
					
					this._clone.DeskId = this.DeskId;	
				
				
					
					this._clone.TotalSales = this.TotalSales;	
				
				
					
					this._clone.TotalSalesVip = this.TotalSalesVip;	
				
				
					
					this._clone.TotalPurchase = this.TotalPurchase;	
				
				
					
					this._clone.TotalReturSales = this.TotalReturSales;	
				
				
					
					this._clone.TotalReturSalesVip = this.TotalReturSalesVip;	
				
				
					
					this._clone.TotalReturPurchase = this.TotalReturPurchase;	
				
				
					
					this._clone.TotalCorrection = this.TotalCorrection;	
				
				
					
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
				
				
					
					this.DeskId = this._clone.DeskId;	
				
				
					
					this.TotalSales = this._clone.TotalSales;	
				
				
					
					this.TotalSalesVip = this._clone.TotalSalesVip;	
				
				
					
					this.TotalPurchase = this._clone.TotalPurchase;	
				
				
					
					this.TotalReturSales = this._clone.TotalReturSales;	
				
				
					
					this.TotalReturSalesVip = this._clone.TotalReturSalesVip;	
				
				
					
					this.TotalReturPurchase = this._clone.TotalReturPurchase;	
				
				
					
					this.TotalCorrection = this._clone.TotalCorrection;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTRekapTransaction();
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
			
		public virtual decimal TotalSales
		{
			get
			{ 
				return _total_sales;
			}
			set
			{
				_total_sales = value;
			}

		}
			
		public virtual decimal TotalSalesVip
		{
			get
			{ 
				return _total_sales_vip;
			}
			set
			{
				_total_sales_vip = value;
			}

		}
			
		public virtual decimal TotalPurchase
		{
			get
			{ 
				return _total_purchase;
			}
			set
			{
				_total_purchase = value;
			}

		}
			
		public virtual decimal TotalReturSales
		{
			get
			{ 
				return _total_retur_sales;
			}
			set
			{
				_total_retur_sales = value;
			}

		}
			
		public virtual decimal TotalReturSalesVip
		{
			get
			{ 
				return _total_retur_sales_vip;
			}
			set
			{
				_total_retur_sales_vip = value;
			}

		}
			
		public virtual decimal TotalReturPurchase
		{
			get
			{ 
				return _total_retur_purchase;
			}
			set
			{
				_total_retur_purchase = value;
			}

		}
			
		public virtual decimal TotalCorrection
		{
			get
			{ 
				return _total_correction;
			}
			set
			{
				_total_correction = value;
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
			TRekapTransaction castObj = (TRekapTransaction)obj; 
			return ( castObj != null ) &&
				( this._rekap_date_from == castObj.RekapDateFrom );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _rekap_date_from.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TRekapTransaction other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._rekap_date_from == other.RekapDateFrom );
				   
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
						
			sb.Append(_desk_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_total_sales.ToString()); 
			sb.Append("|");						
						
			sb.Append(_total_sales_vip.ToString()); 
			sb.Append("|");						
						
			sb.Append(_total_purchase.ToString()); 
			sb.Append("|");						
						
			sb.Append(_total_retur_sales.ToString()); 
			sb.Append("|");						
						
			sb.Append(_total_retur_sales_vip.ToString()); 
			sb.Append("|");						
						
			sb.Append(_total_retur_purchase.ToString()); 
			sb.Append("|");						
						
			sb.Append(_total_correction.ToString()); 
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
				
				public const string DeskId = "DeskId";
				
				public const string TotalSales = "TotalSales";
				
				public const string TotalSalesVip = "TotalSalesVip";
				
				public const string TotalPurchase = "TotalPurchase";
				
				public const string TotalReturSales = "TotalReturSales";
				
				public const string TotalReturSalesVip = "TotalReturSalesVip";
				
				public const string TotalReturPurchase = "TotalReturPurchase";
				
				public const string TotalCorrection = "TotalCorrection";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
