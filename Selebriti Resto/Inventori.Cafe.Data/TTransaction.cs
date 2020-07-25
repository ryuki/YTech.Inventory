using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class TTransaction: IEquatable<TTransaction>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _transaction_id; 
		private string _currency_id; 
		private int _gudang_id; 
		private int _gudang_id_to; 
		private string _location_id; 
		private string _location_id_to; 
		private decimal _transaction_reference_id; 
		private string _transaction_factur; 
		private string _transaction_by; 
		private string _transaction_by_address; 
		private string _transaction_by_phone; 
		private string _transaction_by_name; 
		private DateTime _transaction_date; 
		private decimal _transaction_sub_total; 
		private decimal _transaction_disc; 
		private bool _transaction_use_ppn; 
		private decimal _transaction_ppn; 
		private decimal _transaction_grand_total; 
		private decimal _transaction_paid; 
		private decimal _transaction_sisa; 
		private string _transaction_status; 
		private string _transaction_desk; 
		private string _transaction_desc; 
		private string _transaction_desc2; 
		private string _employee_id; 
		private string _employee_id2; 
		private string _transaction_payment; 
		private decimal _transaction_commision; 
		private decimal _transaction_potongan; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TTransaction()
		{
			_transaction_id = 0; 
			_currency_id = String.Empty; 
			_gudang_id = 0; 
			_gudang_id_to = 0; 
			_location_id = String.Empty; 
			_location_id_to = String.Empty; 
			_transaction_reference_id = 0; 
			_transaction_factur = String.Empty; 
			_transaction_by = String.Empty; 
			_transaction_by_address = String.Empty; 
			_transaction_by_phone = String.Empty; 
			_transaction_by_name = String.Empty; 
			_transaction_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_transaction_sub_total = 0; 
			_transaction_disc = 0; 
			_transaction_use_ppn = false; 
			_transaction_ppn = 0; 
			_transaction_grand_total = 0; 
			_transaction_paid = 0; 
			_transaction_sisa = 0; 
			_transaction_status = String.Empty; 
			_transaction_desk = String.Empty; 
			_transaction_desc = String.Empty; 
			_transaction_desc2 = String.Empty; 
			_employee_id = String.Empty; 
			_employee_id2 = String.Empty; 
			_transaction_payment = String.Empty; 
			_transaction_commision = 0; 
			_transaction_potongan = 0; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TTransaction(
			decimal transaction_id)
			: this()
		{
			_transaction_id = transaction_id;
			_currency_id = String.Empty;
			_gudang_id = 0;
			_gudang_id_to = 0;
			_location_id = String.Empty;
			_location_id_to = String.Empty;
			_transaction_reference_id = 0;
			_transaction_factur = String.Empty;
			_transaction_by = String.Empty;
			_transaction_by_address = String.Empty;
			_transaction_by_phone = String.Empty;
			_transaction_by_name = String.Empty;
			_transaction_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_transaction_sub_total = 0;
			_transaction_disc = 0;
			_transaction_use_ppn = false;
			_transaction_ppn = 0;
			_transaction_grand_total = 0;
			_transaction_paid = 0;
			_transaction_sisa = 0;
			_transaction_status = String.Empty;
			_transaction_desk = String.Empty;
			_transaction_desc = String.Empty;
			_transaction_desc2 = String.Empty;
			_employee_id = String.Empty;
			_employee_id2 = String.Empty;
			_transaction_payment = String.Empty;
			_transaction_commision = 0;
			_transaction_potongan = 0;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTTransaction
        {

					internal decimal TransactionId;

					internal string CurrencyId;

					internal int GudangId;

					internal int GudangIdTo;

					internal string LocationId;

					internal string LocationIdTo;

					internal decimal TransactionReferenceId;

					internal string TransactionFactur;

					internal string TransactionBy;

					internal string TransactionByAddress;

					internal string TransactionByPhone;

					internal string TransactionByName;

					internal DateTime TransactionDate;

					internal decimal TransactionSubTotal;

					internal decimal TransactionDisc;

					internal bool TransactionUsePpn;

					internal decimal TransactionPpn;

					internal decimal TransactionGrandTotal;

					internal decimal TransactionPaid;

					internal decimal TransactionSisa;

					internal string TransactionStatus;

					internal string TransactionDesk;

					internal string TransactionDesc;

					internal string TransactionDesc2;

					internal string EmployeeId;

					internal string EmployeeId2;

					internal string TransactionPayment;

					internal decimal TransactionCommision;

					internal decimal TransactionPotongan;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTTransaction _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.TransactionId = this.TransactionId;	
				
				
					
					this._clone.CurrencyId = this.CurrencyId;	
				
				
					
					this._clone.GudangId = this.GudangId;	
				
				
					
					this._clone.GudangIdTo = this.GudangIdTo;	
				
				
					
					this._clone.LocationId = this.LocationId;	
				
				
					
					this._clone.LocationIdTo = this.LocationIdTo;	
				
				
					
					this._clone.TransactionReferenceId = this.TransactionReferenceId;	
				
				
					
					this._clone.TransactionFactur = this.TransactionFactur;	
				
				
					
					this._clone.TransactionBy = this.TransactionBy;	
				
				
					
					this._clone.TransactionByAddress = this.TransactionByAddress;	
				
				
					
					this._clone.TransactionByPhone = this.TransactionByPhone;	
				
				
					
					this._clone.TransactionByName = this.TransactionByName;	
				
				
					
					this._clone.TransactionDate = this.TransactionDate;	
				
				
					
					this._clone.TransactionSubTotal = this.TransactionSubTotal;	
				
				
					
					this._clone.TransactionDisc = this.TransactionDisc;	
				
				
					
					this._clone.TransactionUsePpn = this.TransactionUsePpn;	
				
				
					
					this._clone.TransactionPpn = this.TransactionPpn;	
				
				
					
					this._clone.TransactionGrandTotal = this.TransactionGrandTotal;	
				
				
					
					this._clone.TransactionPaid = this.TransactionPaid;	
				
				
					
					this._clone.TransactionSisa = this.TransactionSisa;	
				
				
					
					this._clone.TransactionStatus = this.TransactionStatus;	
				
				
					
					this._clone.TransactionDesk = this.TransactionDesk;	
				
				
					
					this._clone.TransactionDesc = this.TransactionDesc;	
				
				
					
					this._clone.TransactionDesc2 = this.TransactionDesc2;	
				
				
					
					this._clone.EmployeeId = this.EmployeeId;	
				
				
					
					this._clone.EmployeeId2 = this.EmployeeId2;	
				
				
					
					this._clone.TransactionPayment = this.TransactionPayment;	
				
				
					
					this._clone.TransactionCommision = this.TransactionCommision;	
				
				
					
					this._clone.TransactionPotongan = this.TransactionPotongan;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.TransactionId = this._clone.TransactionId;	
				
				
					
					this.CurrencyId = this._clone.CurrencyId;	
				
				
					
					this.GudangId = this._clone.GudangId;	
				
				
					
					this.GudangIdTo = this._clone.GudangIdTo;	
				
				
					
					this.LocationId = this._clone.LocationId;	
				
				
					
					this.LocationIdTo = this._clone.LocationIdTo;	
				
				
					
					this.TransactionReferenceId = this._clone.TransactionReferenceId;	
				
				
					
					this.TransactionFactur = this._clone.TransactionFactur;	
				
				
					
					this.TransactionBy = this._clone.TransactionBy;	
				
				
					
					this.TransactionByAddress = this._clone.TransactionByAddress;	
				
				
					
					this.TransactionByPhone = this._clone.TransactionByPhone;	
				
				
					
					this.TransactionByName = this._clone.TransactionByName;	
				
				
					
					this.TransactionDate = this._clone.TransactionDate;	
				
				
					
					this.TransactionSubTotal = this._clone.TransactionSubTotal;	
				
				
					
					this.TransactionDisc = this._clone.TransactionDisc;	
				
				
					
					this.TransactionUsePpn = this._clone.TransactionUsePpn;	
				
				
					
					this.TransactionPpn = this._clone.TransactionPpn;	
				
				
					
					this.TransactionGrandTotal = this._clone.TransactionGrandTotal;	
				
				
					
					this.TransactionPaid = this._clone.TransactionPaid;	
				
				
					
					this.TransactionSisa = this._clone.TransactionSisa;	
				
				
					
					this.TransactionStatus = this._clone.TransactionStatus;	
				
				
					
					this.TransactionDesk = this._clone.TransactionDesk;	
				
				
					
					this.TransactionDesc = this._clone.TransactionDesc;	
				
				
					
					this.TransactionDesc2 = this._clone.TransactionDesc2;	
				
				
					
					this.EmployeeId = this._clone.EmployeeId;	
				
				
					
					this.EmployeeId2 = this._clone.EmployeeId2;	
				
				
					
					this.TransactionPayment = this._clone.TransactionPayment;	
				
				
					
					this.TransactionCommision = this._clone.TransactionCommision;	
				
				
					
					this.TransactionPotongan = this._clone.TransactionPotongan;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTTransaction();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual decimal TransactionId
		{
			get
			{ 
				return _transaction_id;
			}
			set
			{
				_transaction_id = value;
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
			
		public virtual int GudangId
		{
			get
			{ 
				return _gudang_id;
			}
			set
			{
				_gudang_id = value;
			}

		}
			
		public virtual int GudangIdTo
		{
			get
			{ 
				return _gudang_id_to;
			}
			set
			{
				_gudang_id_to = value;
			}

		}
			
		public virtual string LocationId
		{
			get
			{ 
				return _location_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for LocationId", value, value.ToString());
				
				_location_id = value;
			}
		}
			
		public virtual string LocationIdTo
		{
			get
			{ 
				return _location_id_to;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for LocationIdTo", value, value.ToString());
				
				_location_id_to = value;
			}
		}
			
		public virtual decimal TransactionReferenceId
		{
			get
			{ 
				return _transaction_reference_id;
			}
			set
			{
				_transaction_reference_id = value;
			}

		}
			
		public virtual string TransactionFactur
		{
			get
			{ 
				return _transaction_factur;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionFactur", value, value.ToString());
				
				_transaction_factur = value;
			}
		}
			
		public virtual string TransactionBy
		{
			get
			{ 
				return _transaction_by;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionBy", value, value.ToString());
				
				_transaction_by = value;
			}
		}
			
		public virtual string TransactionByAddress
		{
			get
			{ 
				return _transaction_by_address;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionByAddress", value, value.ToString());
				
				_transaction_by_address = value;
			}
		}
			
		public virtual string TransactionByPhone
		{
			get
			{ 
				return _transaction_by_phone;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionByPhone", value, value.ToString());
				
				_transaction_by_phone = value;
			}
		}
			
		public virtual string TransactionByName
		{
			get
			{ 
				return _transaction_by_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionByName", value, value.ToString());
				
				_transaction_by_name = value;
			}
		}
			
		public virtual DateTime TransactionDate
		{
			get
			{ 
				return _transaction_date;
			}
			set
			{
				_transaction_date = value;
			}

		}
			
		public virtual decimal TransactionSubTotal
		{
			get
			{ 
				return _transaction_sub_total;
			}
			set
			{
				_transaction_sub_total = value;
			}

		}
			
		public virtual decimal TransactionDisc
		{
			get
			{ 
				return _transaction_disc;
			}
			set
			{
				_transaction_disc = value;
			}

		}
			
		public virtual bool TransactionUsePpn
		{
			get
			{ 
				return _transaction_use_ppn;
			}
			set
			{
				_transaction_use_ppn = value;
			}

		}
			
		public virtual decimal TransactionPpn
		{
			get
			{ 
				return _transaction_ppn;
			}
			set
			{
				_transaction_ppn = value;
			}

		}
			
		public virtual decimal TransactionGrandTotal
		{
			get
			{ 
				return _transaction_grand_total;
			}
			set
			{
				_transaction_grand_total = value;
			}

		}
			
		public virtual decimal TransactionPaid
		{
			get
			{ 
				return _transaction_paid;
			}
			set
			{
				_transaction_paid = value;
			}

		}
			
		public virtual decimal TransactionSisa
		{
			get
			{ 
				return _transaction_sisa;
			}
			set
			{
				_transaction_sisa = value;
			}

		}
			
		public virtual string TransactionStatus
		{
			get
			{ 
				return _transaction_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionStatus", value, value.ToString());
				
				_transaction_status = value;
			}
		}
			
		public virtual string TransactionDesk
		{
			get
			{ 
				return _transaction_desk;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionDesk", value, value.ToString());
				
				_transaction_desk = value;
			}
		}
			
		public virtual string TransactionDesc
		{
			get
			{ 
				return _transaction_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionDesc", value, value.ToString());
				
				_transaction_desc = value;
			}
		}
			
		public virtual string TransactionDesc2
		{
			get
			{ 
				return _transaction_desc2;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionDesc2", value, value.ToString());
				
				_transaction_desc2 = value;
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
			
		public virtual string EmployeeId2
		{
			get
			{ 
				return _employee_id2;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeeId2", value, value.ToString());
				
				_employee_id2 = value;
			}
		}
			
		public virtual string TransactionPayment
		{
			get
			{ 
				return _transaction_payment;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionPayment", value, value.ToString());
				
				_transaction_payment = value;
			}
		}
			
		public virtual decimal TransactionCommision
		{
			get
			{ 
				return _transaction_commision;
			}
			set
			{
				_transaction_commision = value;
			}

		}
			
		public virtual decimal TransactionPotongan
		{
			get
			{ 
				return _transaction_potongan;
			}
			set
			{
				_transaction_potongan = value;
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
			TTransaction castObj = (TTransaction)obj; 
			return ( castObj != null ) &&
				( this._transaction_id == castObj.TransactionId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _transaction_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TTransaction other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._transaction_id == other.TransactionId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_transaction_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_currency_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_gudang_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_gudang_id_to.ToString()); 
			sb.Append("|");						
						
			sb.Append(_location_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_location_id_to.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_reference_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_factur.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_by.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_by_address.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_by_phone.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_by_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_sub_total.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_disc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_use_ppn.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_ppn.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_grand_total.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_paid.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_sisa.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_desk.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_desc2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_id2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_payment.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_commision.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_potongan.ToString()); 
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
		
				public const string TransactionId = "TransactionId";
				
				public const string CurrencyId = "CurrencyId";
				
				public const string GudangId = "GudangId";
				
				public const string GudangIdTo = "GudangIdTo";
				
				public const string LocationId = "LocationId";
				
				public const string LocationIdTo = "LocationIdTo";
				
				public const string TransactionReferenceId = "TransactionReferenceId";
				
				public const string TransactionFactur = "TransactionFactur";
				
				public const string TransactionBy = "TransactionBy";
				
				public const string TransactionByAddress = "TransactionByAddress";
				
				public const string TransactionByPhone = "TransactionByPhone";
				
				public const string TransactionByName = "TransactionByName";
				
				public const string TransactionDate = "TransactionDate";
				
				public const string TransactionSubTotal = "TransactionSubTotal";
				
				public const string TransactionDisc = "TransactionDisc";
				
				public const string TransactionUsePpn = "TransactionUsePpn";
				
				public const string TransactionPpn = "TransactionPpn";
				
				public const string TransactionGrandTotal = "TransactionGrandTotal";
				
				public const string TransactionPaid = "TransactionPaid";
				
				public const string TransactionSisa = "TransactionSisa";
				
				public const string TransactionStatus = "TransactionStatus";
				
				public const string TransactionDesk = "TransactionDesk";
				
				public const string TransactionDesc = "TransactionDesc";
				
				public const string TransactionDesc2 = "TransactionDesc2";
				
				public const string EmployeeId = "EmployeeId";
				
				public const string EmployeeId2 = "EmployeeId2";
				
				public const string TransactionPayment = "TransactionPayment";
				
				public const string TransactionCommision = "TransactionCommision";
				
				public const string TransactionPotongan = "TransactionPotongan";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
