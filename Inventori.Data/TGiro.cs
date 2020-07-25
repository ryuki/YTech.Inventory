using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class TGiro: IEquatable<TGiro>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _giro_id; 
		private string _currency_id; 
		private string _bank_id; 
		private string _giro_no; 
		private decimal _pi_hutang_id; 
		private DateTime _giro_out_date; 
		private DateTime _giro_maturity_date; 
		private string _giro_status; 
		private string _giro_to; 
		private string _giro_from; 
		private DateTime _giro_cair_date; 
		private decimal _giro_ammount; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TGiro()
		{
			_giro_id = 0; 
			_currency_id = String.Empty; 
			_bank_id = String.Empty; 
			_giro_no = String.Empty; 
			_pi_hutang_id = 0; 
			_giro_out_date = DateTime.MinValue; 
			_giro_maturity_date = DateTime.MinValue; 
			_giro_status = String.Empty; 
			_giro_to = String.Empty; 
			_giro_from = String.Empty; 
			_giro_cair_date = DateTime.MinValue; 
			_giro_ammount = 0; 
			_modified_by = String.Empty; 
			_modified_date = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TGiro(
			decimal giro_id)
			: this()
		{
			_giro_id = giro_id;
			_currency_id = String.Empty;
			_bank_id = String.Empty;
			_giro_no = String.Empty;
			_pi_hutang_id = 0;
			_giro_out_date = DateTime.MinValue;
			_giro_maturity_date = DateTime.MinValue;
			_giro_status = String.Empty;
			_giro_to = String.Empty;
			_giro_from = String.Empty;
			_giro_cair_date = DateTime.MinValue;
			_giro_ammount = 0;
			_modified_by = String.Empty;
			_modified_date = DateTime.MinValue;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTGiro
        {

					internal decimal GiroId;

					internal string CurrencyId;

					internal string BankId;

					internal string GiroNo;

					internal decimal PiHutangId;

					internal DateTime GiroOutDate;

					internal DateTime GiroMaturityDate;

					internal string GiroStatus;

					internal string GiroTo;

					internal string GiroFrom;

					internal DateTime GiroCairDate;

					internal decimal GiroAmmount;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTGiro _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.GiroId = this.GiroId;	
				
				
					
					this._clone.CurrencyId = this.CurrencyId;	
				
				
					
					this._clone.BankId = this.BankId;	
				
				
					
					this._clone.GiroNo = this.GiroNo;	
				
				
					
					this._clone.PiHutangId = this.PiHutangId;	
				
				
					
					this._clone.GiroOutDate = this.GiroOutDate;	
				
				
					
					this._clone.GiroMaturityDate = this.GiroMaturityDate;	
				
				
					
					this._clone.GiroStatus = this.GiroStatus;	
				
				
					
					this._clone.GiroTo = this.GiroTo;	
				
				
					
					this._clone.GiroFrom = this.GiroFrom;	
				
				
					
					this._clone.GiroCairDate = this.GiroCairDate;	
				
				
					
					this._clone.GiroAmmount = this.GiroAmmount;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.GiroId = this._clone.GiroId;	
				
				
					
					this.CurrencyId = this._clone.CurrencyId;	
				
				
					
					this.BankId = this._clone.BankId;	
				
				
					
					this.GiroNo = this._clone.GiroNo;	
				
				
					
					this.PiHutangId = this._clone.PiHutangId;	
				
				
					
					this.GiroOutDate = this._clone.GiroOutDate;	
				
				
					
					this.GiroMaturityDate = this._clone.GiroMaturityDate;	
				
				
					
					this.GiroStatus = this._clone.GiroStatus;	
				
				
					
					this.GiroTo = this._clone.GiroTo;	
				
				
					
					this.GiroFrom = this._clone.GiroFrom;	
				
				
					
					this.GiroCairDate = this._clone.GiroCairDate;	
				
				
					
					this.GiroAmmount = this._clone.GiroAmmount;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTGiro();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual decimal GiroId
		{
			get
			{ 
				return _giro_id;
			}
			set
			{
				_giro_id = value;
			}

		}
			
		public virtual string CurrencyId
		{
			get
			{ 
				return _currency_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CurrencyId", value, value.ToString());
				
				_currency_id = value;
			}
		}
			
		public virtual string BankId
		{
			get
			{ 
				return _bank_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for BankId", value, value.ToString());
				
				_bank_id = value;
			}
		}
			
		public virtual string GiroNo
		{
			get
			{ 
				return _giro_no;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for GiroNo", value, value.ToString());
				
				_giro_no = value;
			}
		}
			
		public virtual decimal PiHutangId
		{
			get
			{ 
				return _pi_hutang_id;
			}
			set
			{
				_pi_hutang_id = value;
			}

		}
			
		public virtual DateTime GiroOutDate
		{
			get
			{ 
				return _giro_out_date;
			}
			set
			{
				_giro_out_date = value;
			}

		}
			
		public virtual DateTime GiroMaturityDate
		{
			get
			{ 
				return _giro_maturity_date;
			}
			set
			{
				_giro_maturity_date = value;
			}

		}
			
		public virtual string GiroStatus
		{
			get
			{ 
				return _giro_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for GiroStatus", value, value.ToString());
				
				_giro_status = value;
			}
		}
			
		public virtual string GiroTo
		{
			get
			{ 
				return _giro_to;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for GiroTo", value, value.ToString());
				
				_giro_to = value;
			}
		}
			
		public virtual string GiroFrom
		{
			get
			{ 
				return _giro_from;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for GiroFrom", value, value.ToString());
				
				_giro_from = value;
			}
		}
			
		public virtual DateTime GiroCairDate
		{
			get
			{ 
				return _giro_cair_date;
			}
			set
			{
				_giro_cair_date = value;
			}

		}
			
		public virtual decimal GiroAmmount
		{
			get
			{ 
				return _giro_ammount;
			}
			set
			{
				_giro_ammount = value;
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
			TGiro castObj = (TGiro)obj; 
			return ( castObj != null ) &&
				( this._giro_id == castObj.GiroId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _giro_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TGiro other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._giro_id == other.GiroId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_giro_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_currency_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_bank_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_giro_no.ToString()); 
			sb.Append("|");						
						
			sb.Append(_pi_hutang_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_giro_out_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_giro_maturity_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_giro_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_giro_to.ToString()); 
			sb.Append("|");						
						
			sb.Append(_giro_from.ToString()); 
			sb.Append("|");						
						
			sb.Append(_giro_cair_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_giro_ammount.ToString()); 
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
		
				public const string GiroId = "GiroId";
				
				public const string CurrencyId = "CurrencyId";
				
				public const string BankId = "BankId";
				
				public const string GiroNo = "GiroNo";
				
				public const string PiHutangId = "PiHutangId";
				
				public const string GiroOutDate = "GiroOutDate";
				
				public const string GiroMaturityDate = "GiroMaturityDate";
				
				public const string GiroStatus = "GiroStatus";
				
				public const string GiroTo = "GiroTo";
				
				public const string GiroFrom = "GiroFrom";
				
				public const string GiroCairDate = "GiroCairDate";
				
				public const string GiroAmmount = "GiroAmmount";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
