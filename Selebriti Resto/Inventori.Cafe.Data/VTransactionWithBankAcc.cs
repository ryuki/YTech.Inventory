using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class VTransactionWithBankAcc: IEquatable<VTransactionWithBankAcc>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _bank_id; 
		private string _supplier_account_no; 
		private string _supplier_account_name; 
		private decimal _transaction_id; 
		private string _currency_id; 
		private int _gudang_id; 
		private decimal _transaction_reference_id; 
		private string _transaction_factur; 
		private string _transaction_by; 
		private string _transaction_by_name; 
		private DateTime _transaction_date; 
		private decimal _transaction_sub_total; 
		private decimal _transaction_disc; 
		private bool _transaction_use_ppn; 
		private decimal _transaction_ppn; 
		private decimal _transaction_paid; 
		private decimal _transaction_grand_total; 
		private decimal _transaction_sisa; 
		private string _transaction_status; 
		private string _transaction_desk; 
		private string _transaction_desc; 
		private string _employee_id; 
		private string _transaction_payment; 
		private decimal _transaction_commision; 
		private string _customer_name; 
		private string _supplier_name; 
		private string _pelapor_name; 
		private string _employee_name2; 
		private string _employee_name; 
		private string _customer_group_name; 
		private string _gudang_name; 
		private string _gudang_name_to; 
		private string _transaction_by_address; 
		private string _transaction_by_phone; 
		private string _transaction_desc2; 
		private string _employee_id2; 
		private decimal _transaction_potongan; 		
		#endregion

		#region Constructor

		public VTransactionWithBankAcc()
		{
			_bank_id = String.Empty; 
			_supplier_account_no = String.Empty; 
			_supplier_account_name = String.Empty; 
			_transaction_id = 0; 
			_currency_id = String.Empty; 
			_gudang_id = 0; 
			_transaction_reference_id = 0; 
			_transaction_factur = String.Empty; 
			_transaction_by = String.Empty; 
			_transaction_by_name = String.Empty; 
			_transaction_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_transaction_sub_total = 0; 
			_transaction_disc = 0; 
			_transaction_use_ppn = false; 
			_transaction_ppn = 0; 
			_transaction_paid = 0; 
			_transaction_grand_total = 0; 
			_transaction_sisa = 0; 
			_transaction_status = String.Empty; 
			_transaction_desk = String.Empty; 
			_transaction_desc = String.Empty; 
			_employee_id = String.Empty; 
			_transaction_payment = String.Empty; 
			_transaction_commision = 0; 
			_customer_name = String.Empty; 
			_supplier_name = String.Empty; 
			_pelapor_name = String.Empty; 
			_employee_name2 = String.Empty; 
			_employee_name = String.Empty; 
			_customer_group_name = String.Empty; 
			_gudang_name = String.Empty; 
			_gudang_name_to = String.Empty; 
			_transaction_by_address = String.Empty; 
			_transaction_by_phone = String.Empty; 
			_transaction_desc2 = String.Empty; 
			_employee_id2 = String.Empty; 
			_transaction_potongan = 0; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public VTransactionWithBankAcc(
			string bank_id, 
			string supplier_account_no, 
			string supplier_account_name, 
			decimal transaction_id, 
			string employee_name, 
			string customer_group_name, 
			string gudang_name, 
			string gudang_name_to)
			: this()
		{
			_bank_id = bank_id;
			_supplier_account_no = supplier_account_no;
			_supplier_account_name = supplier_account_name;
			_transaction_id = transaction_id;
			_currency_id = String.Empty;
			_gudang_id = 0;
			_transaction_reference_id = 0;
			_transaction_factur = String.Empty;
			_transaction_by = String.Empty;
			_transaction_by_name = String.Empty;
			_transaction_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_transaction_sub_total = 0;
			_transaction_disc = 0;
			_transaction_use_ppn = false;
			_transaction_ppn = 0;
			_transaction_paid = 0;
			_transaction_grand_total = 0;
			_transaction_sisa = 0;
			_transaction_status = String.Empty;
			_transaction_desk = String.Empty;
			_transaction_desc = String.Empty;
			_employee_id = String.Empty;
			_transaction_payment = String.Empty;
			_transaction_commision = 0;
			_customer_name = String.Empty;
			_supplier_name = String.Empty;
			_pelapor_name = String.Empty;
			_employee_name2 = String.Empty;
			_employee_name = employee_name;
			_customer_group_name = customer_group_name;
			_gudang_name = gudang_name;
			_gudang_name_to = gudang_name_to;
			_transaction_by_address = String.Empty;
			_transaction_by_phone = String.Empty;
			_transaction_desc2 = String.Empty;
			_employee_id2 = String.Empty;
			_transaction_potongan = 0;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructVTransactionWithBankAcc
        {

					internal string BankId;

					internal string SupplierAccountNo;

					internal string SupplierAccountName;

					internal decimal TransactionId;

					internal string CurrencyId;

					internal int GudangId;

					internal decimal TransactionReferenceId;

					internal string TransactionFactur;

					internal string TransactionBy;

					internal string TransactionByName;

					internal DateTime TransactionDate;

					internal decimal TransactionSubTotal;

					internal decimal TransactionDisc;

					internal bool TransactionUsePpn;

					internal decimal TransactionPpn;

					internal decimal TransactionPaid;

					internal decimal TransactionGrandTotal;

					internal decimal TransactionSisa;

					internal string TransactionStatus;

					internal string TransactionDesk;

					internal string TransactionDesc;

					internal string EmployeeId;

					internal string TransactionPayment;

					internal decimal TransactionCommision;

					internal string CustomerName;

					internal string SupplierName;

					internal string PelaporName;

					internal string EmployeeName2;

					internal string EmployeeName;

					internal string CustomerGroupName;

					internal string GudangName;

					internal string GudangNameTo;

					internal string TransactionByAddress;

					internal string TransactionByPhone;

					internal string TransactionDesc2;

					internal string EmployeeId2;

					internal decimal TransactionPotongan;

        }

        StructVTransactionWithBankAcc _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.BankId = this.BankId;	
				
				
					
					this._clone.SupplierAccountNo = this.SupplierAccountNo;	
				
				
					
					this._clone.SupplierAccountName = this.SupplierAccountName;	
				
				
					
					this._clone.TransactionId = this.TransactionId;	
				
				
					
					this._clone.CurrencyId = this.CurrencyId;	
				
				
					
					this._clone.GudangId = this.GudangId;	
				
				
					
					this._clone.TransactionReferenceId = this.TransactionReferenceId;	
				
				
					
					this._clone.TransactionFactur = this.TransactionFactur;	
				
				
					
					this._clone.TransactionBy = this.TransactionBy;	
				
				
					
					this._clone.TransactionByName = this.TransactionByName;	
				
				
					
					this._clone.TransactionDate = this.TransactionDate;	
				
				
					
					this._clone.TransactionSubTotal = this.TransactionSubTotal;	
				
				
					
					this._clone.TransactionDisc = this.TransactionDisc;	
				
				
					
					this._clone.TransactionUsePpn = this.TransactionUsePpn;	
				
				
					
					this._clone.TransactionPpn = this.TransactionPpn;	
				
				
					
					this._clone.TransactionPaid = this.TransactionPaid;	
				
				
					
					this._clone.TransactionGrandTotal = this.TransactionGrandTotal;	
				
				
					
					this._clone.TransactionSisa = this.TransactionSisa;	
				
				
					
					this._clone.TransactionStatus = this.TransactionStatus;	
				
				
					
					this._clone.TransactionDesk = this.TransactionDesk;	
				
				
					
					this._clone.TransactionDesc = this.TransactionDesc;	
				
				
					
					this._clone.EmployeeId = this.EmployeeId;	
				
				
					
					this._clone.TransactionPayment = this.TransactionPayment;	
				
				
					
					this._clone.TransactionCommision = this.TransactionCommision;	
				
				
					
					this._clone.CustomerName = this.CustomerName;	
				
				
					
					this._clone.SupplierName = this.SupplierName;	
				
				
					
					this._clone.PelaporName = this.PelaporName;	
				
				
					
					this._clone.EmployeeName2 = this.EmployeeName2;	
				
				
					
					this._clone.EmployeeName = this.EmployeeName;	
				
				
					
					this._clone.CustomerGroupName = this.CustomerGroupName;	
				
				
					
					this._clone.GudangName = this.GudangName;	
				
				
					
					this._clone.GudangNameTo = this.GudangNameTo;	
				
				
					
					this._clone.TransactionByAddress = this.TransactionByAddress;	
				
				
					
					this._clone.TransactionByPhone = this.TransactionByPhone;	
				
				
					
					this._clone.TransactionDesc2 = this.TransactionDesc2;	
				
				
					
					this._clone.EmployeeId2 = this.EmployeeId2;	
				
				
					
					this._clone.TransactionPotongan = this.TransactionPotongan;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.BankId = this._clone.BankId;	
				
				
					
					this.SupplierAccountNo = this._clone.SupplierAccountNo;	
				
				
					
					this.SupplierAccountName = this._clone.SupplierAccountName;	
				
				
					
					this.TransactionId = this._clone.TransactionId;	
				
				
					
					this.CurrencyId = this._clone.CurrencyId;	
				
				
					
					this.GudangId = this._clone.GudangId;	
				
				
					
					this.TransactionReferenceId = this._clone.TransactionReferenceId;	
				
				
					
					this.TransactionFactur = this._clone.TransactionFactur;	
				
				
					
					this.TransactionBy = this._clone.TransactionBy;	
				
				
					
					this.TransactionByName = this._clone.TransactionByName;	
				
				
					
					this.TransactionDate = this._clone.TransactionDate;	
				
				
					
					this.TransactionSubTotal = this._clone.TransactionSubTotal;	
				
				
					
					this.TransactionDisc = this._clone.TransactionDisc;	
				
				
					
					this.TransactionUsePpn = this._clone.TransactionUsePpn;	
				
				
					
					this.TransactionPpn = this._clone.TransactionPpn;	
				
				
					
					this.TransactionPaid = this._clone.TransactionPaid;	
				
				
					
					this.TransactionGrandTotal = this._clone.TransactionGrandTotal;	
				
				
					
					this.TransactionSisa = this._clone.TransactionSisa;	
				
				
					
					this.TransactionStatus = this._clone.TransactionStatus;	
				
				
					
					this.TransactionDesk = this._clone.TransactionDesk;	
				
				
					
					this.TransactionDesc = this._clone.TransactionDesc;	
				
				
					
					this.EmployeeId = this._clone.EmployeeId;	
				
				
					
					this.TransactionPayment = this._clone.TransactionPayment;	
				
				
					
					this.TransactionCommision = this._clone.TransactionCommision;	
				
				
					
					this.CustomerName = this._clone.CustomerName;	
				
				
					
					this.SupplierName = this._clone.SupplierName;	
				
				
					
					this.PelaporName = this._clone.PelaporName;	
				
				
					
					this.EmployeeName2 = this._clone.EmployeeName2;	
				
				
					
					this.EmployeeName = this._clone.EmployeeName;	
				
				
					
					this.CustomerGroupName = this._clone.CustomerGroupName;	
				
				
					
					this.GudangName = this._clone.GudangName;	
				
				
					
					this.GudangNameTo = this._clone.GudangNameTo;	
				
				
					
					this.TransactionByAddress = this._clone.TransactionByAddress;	
				
				
					
					this.TransactionByPhone = this._clone.TransactionByPhone;	
				
				
					
					this.TransactionDesc2 = this._clone.TransactionDesc2;	
				
				
					
					this.EmployeeId2 = this._clone.EmployeeId2;	
				
				
					
					this.TransactionPotongan = this._clone.TransactionPotongan;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructVTransactionWithBankAcc();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string BankId
		{
			get
			{ 
				return _bank_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for BankId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for BankId", value, value.ToString());
				
				_bank_id = value;
			}
		}
			
		public virtual string SupplierAccountNo
		{
			get
			{ 
				return _supplier_account_no;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for SupplierAccountNo", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierAccountNo", value, value.ToString());
				
				_supplier_account_no = value;
			}
		}
			
		public virtual string SupplierAccountName
		{
			get
			{ 
				return _supplier_account_name;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for SupplierAccountName", value, "null");
				
				if(  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierAccountName", value, value.ToString());
				
				_supplier_account_name = value;
			}
		}
			
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
			
		public virtual string CustomerName
		{
			get
			{ 
				return _customer_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerName", value, value.ToString());
				
				_customer_name = value;
			}
		}
			
		public virtual string SupplierName
		{
			get
			{ 
				return _supplier_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierName", value, value.ToString());
				
				_supplier_name = value;
			}
		}
			
		public virtual string PelaporName
		{
			get
			{ 
				return _pelapor_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for PelaporName", value, value.ToString());
				
				_pelapor_name = value;
			}
		}
			
		public virtual string EmployeeName2
		{
			get
			{ 
				return _employee_name2;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeeName2", value, value.ToString());
				
				_employee_name2 = value;
			}
		}
			
		public virtual string EmployeeName
		{
			get
			{ 
				return _employee_name;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for EmployeeName", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for EmployeeName", value, value.ToString());
				
				_employee_name = value;
			}
		}
			
		public virtual string CustomerGroupName
		{
			get
			{ 
				return _customer_group_name;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for CustomerGroupName", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerGroupName", value, value.ToString());
				
				_customer_group_name = value;
			}
		}
			
		public virtual string GudangName
		{
			get
			{ 
				return _gudang_name;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for GudangName", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for GudangName", value, value.ToString());
				
				_gudang_name = value;
			}
		}
			
		public virtual string GudangNameTo
		{
			get
			{ 
				return _gudang_name_to;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for GudangNameTo", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for GudangNameTo", value, value.ToString());
				
				_gudang_name_to = value;
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
			VTransactionWithBankAcc castObj = (VTransactionWithBankAcc)obj; 
			return castObj.GetHashCode() == this.GetHashCode();
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			return this.GetType().FullName.GetHashCode();
				
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(VTransactionWithBankAcc other)
		{
			if (other == this)
				return true;
		
			return other.GetHashCode() == this.GetHashCode();
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_bank_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_account_no.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_account_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_currency_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_gudang_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_reference_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_factur.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_by.ToString()); 
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
						
			sb.Append(_transaction_paid.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_grand_total.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_sisa.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_desk.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_payment.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_commision.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_pelapor_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_name2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_group_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_gudang_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_gudang_name_to.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_by_address.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_by_phone.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_desc2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_employee_id2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_potongan.ToString()); 
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string BankId = "BankId";
				
				public const string SupplierAccountNo = "SupplierAccountNo";
				
				public const string SupplierAccountName = "SupplierAccountName";
				
				public const string TransactionId = "TransactionId";
				
				public const string CurrencyId = "CurrencyId";
				
				public const string GudangId = "GudangId";
				
				public const string TransactionReferenceId = "TransactionReferenceId";
				
				public const string TransactionFactur = "TransactionFactur";
				
				public const string TransactionBy = "TransactionBy";
				
				public const string TransactionByName = "TransactionByName";
				
				public const string TransactionDate = "TransactionDate";
				
				public const string TransactionSubTotal = "TransactionSubTotal";
				
				public const string TransactionDisc = "TransactionDisc";
				
				public const string TransactionUsePpn = "TransactionUsePpn";
				
				public const string TransactionPpn = "TransactionPpn";
				
				public const string TransactionPaid = "TransactionPaid";
				
				public const string TransactionGrandTotal = "TransactionGrandTotal";
				
				public const string TransactionSisa = "TransactionSisa";
				
				public const string TransactionStatus = "TransactionStatus";
				
				public const string TransactionDesk = "TransactionDesk";
				
				public const string TransactionDesc = "TransactionDesc";
				
				public const string EmployeeId = "EmployeeId";
				
				public const string TransactionPayment = "TransactionPayment";
				
				public const string TransactionCommision = "TransactionCommision";
				
				public const string CustomerName = "CustomerName";
				
				public const string SupplierName = "SupplierName";
				
				public const string PelaporName = "PelaporName";
				
				public const string EmployeeName2 = "EmployeeName2";
				
				public const string EmployeeName = "EmployeeName";
				
				public const string CustomerGroupName = "CustomerGroupName";
				
				public const string GudangName = "GudangName";
				
				public const string GudangNameTo = "GudangNameTo";
				
				public const string TransactionByAddress = "TransactionByAddress";
				
				public const string TransactionByPhone = "TransactionByPhone";
				
				public const string TransactionDesc2 = "TransactionDesc2";
				
				public const string EmployeeId2 = "EmployeeId2";
				
				public const string TransactionPotongan = "TransactionPotongan";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
