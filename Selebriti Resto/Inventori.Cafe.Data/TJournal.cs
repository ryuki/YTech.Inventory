using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class TJournal: IEquatable<TJournal>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _journal_id; 
		private string _account_id; 
		private string _sub_account_id; 
		private decimal _transaction_id; 
		private string _voucher_no; 
		private string _journal_pic; 
		private DateTime _journal_date; 
		private decimal _journal_jumlah; 
		private string _journal_status; 
		private string _journal_desc; 
		private decimal _account_saldo; 
		private decimal _sub_accont_saldo; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TJournal()
		{
			_journal_id = 0; 
			_account_id = String.Empty; 
			_sub_account_id = String.Empty; 
			_transaction_id = 0; 
			_voucher_no = String.Empty; 
			_journal_pic = String.Empty; 
			_journal_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_journal_jumlah = 0; 
			_journal_status = String.Empty; 
			_journal_desc = String.Empty; 
			_account_saldo = 0; 
			_sub_accont_saldo = 0; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TJournal(
			decimal journal_id)
			: this()
		{
			_journal_id = journal_id;
			_account_id = String.Empty;
			_sub_account_id = String.Empty;
			_transaction_id = 0;
			_voucher_no = String.Empty;
			_journal_pic = String.Empty;
			_journal_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_journal_jumlah = 0;
			_journal_status = String.Empty;
			_journal_desc = String.Empty;
			_account_saldo = 0;
			_sub_accont_saldo = 0;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTJournal
        {

					internal decimal JournalId;

					internal string AccountId;

					internal string SubAccountId;

					internal decimal TransactionId;

					internal string VoucherNo;

					internal string JournalPic;

					internal DateTime JournalDate;

					internal decimal JournalJumlah;

					internal string JournalStatus;

					internal string JournalDesc;

					internal decimal AccountSaldo;

					internal decimal SubAccontSaldo;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTJournal _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.JournalId = this.JournalId;	
				
				
					
					this._clone.AccountId = this.AccountId;	
				
				
					
					this._clone.SubAccountId = this.SubAccountId;	
				
				
					
					this._clone.TransactionId = this.TransactionId;	
				
				
					
					this._clone.VoucherNo = this.VoucherNo;	
				
				
					
					this._clone.JournalPic = this.JournalPic;	
				
				
					
					this._clone.JournalDate = this.JournalDate;	
				
				
					
					this._clone.JournalJumlah = this.JournalJumlah;	
				
				
					
					this._clone.JournalStatus = this.JournalStatus;	
				
				
					
					this._clone.JournalDesc = this.JournalDesc;	
				
				
					
					this._clone.AccountSaldo = this.AccountSaldo;	
				
				
					
					this._clone.SubAccontSaldo = this.SubAccontSaldo;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.JournalId = this._clone.JournalId;	
				
				
					
					this.AccountId = this._clone.AccountId;	
				
				
					
					this.SubAccountId = this._clone.SubAccountId;	
				
				
					
					this.TransactionId = this._clone.TransactionId;	
				
				
					
					this.VoucherNo = this._clone.VoucherNo;	
				
				
					
					this.JournalPic = this._clone.JournalPic;	
				
				
					
					this.JournalDate = this._clone.JournalDate;	
				
				
					
					this.JournalJumlah = this._clone.JournalJumlah;	
				
				
					
					this.JournalStatus = this._clone.JournalStatus;	
				
				
					
					this.JournalDesc = this._clone.JournalDesc;	
				
				
					
					this.AccountSaldo = this._clone.AccountSaldo;	
				
				
					
					this.SubAccontSaldo = this._clone.SubAccontSaldo;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTJournal();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual decimal JournalId
		{
			get
			{ 
				return _journal_id;
			}
			set
			{
				_journal_id = value;
			}

		}
			
		public virtual string AccountId
		{
			get
			{ 
				return _account_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for AccountId", value, value.ToString());
				
				_account_id = value;
			}
		}
			
		public virtual string SubAccountId
		{
			get
			{ 
				return _sub_account_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SubAccountId", value, value.ToString());
				
				_sub_account_id = value;
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
			
		public virtual string VoucherNo
		{
			get
			{ 
				return _voucher_no;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for VoucherNo", value, value.ToString());
				
				_voucher_no = value;
			}
		}
			
		public virtual string JournalPic
		{
			get
			{ 
				return _journal_pic;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for JournalPic", value, value.ToString());
				
				_journal_pic = value;
			}
		}
			
		public virtual DateTime JournalDate
		{
			get
			{ 
				return _journal_date;
			}
			set
			{
				_journal_date = value;
			}

		}
			
		public virtual decimal JournalJumlah
		{
			get
			{ 
				return _journal_jumlah;
			}
			set
			{
				_journal_jumlah = value;
			}

		}
			
		public virtual string JournalStatus
		{
			get
			{ 
				return _journal_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for JournalStatus", value, value.ToString());
				
				_journal_status = value;
			}
		}
			
		public virtual string JournalDesc
		{
			get
			{ 
				return _journal_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for JournalDesc", value, value.ToString());
				
				_journal_desc = value;
			}
		}
			
		public virtual decimal AccountSaldo
		{
			get
			{ 
				return _account_saldo;
			}
			set
			{
				_account_saldo = value;
			}

		}
			
		public virtual decimal SubAccontSaldo
		{
			get
			{ 
				return _sub_accont_saldo;
			}
			set
			{
				_sub_accont_saldo = value;
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
			TJournal castObj = (TJournal)obj; 
			return ( castObj != null ) &&
				( this._journal_id == castObj.JournalId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _journal_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TJournal other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._journal_id == other.JournalId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_journal_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_account_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_sub_account_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_voucher_no.ToString()); 
			sb.Append("|");						
						
			sb.Append(_journal_pic.ToString()); 
			sb.Append("|");						
						
			sb.Append(_journal_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_journal_jumlah.ToString()); 
			sb.Append("|");						
						
			sb.Append(_journal_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_journal_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_account_saldo.ToString()); 
			sb.Append("|");						
						
			sb.Append(_sub_accont_saldo.ToString()); 
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
		
				public const string JournalId = "JournalId";
				
				public const string AccountId = "AccountId";
				
				public const string SubAccountId = "SubAccountId";
				
				public const string TransactionId = "TransactionId";
				
				public const string VoucherNo = "VoucherNo";
				
				public const string JournalPic = "JournalPic";
				
				public const string JournalDate = "JournalDate";
				
				public const string JournalJumlah = "JournalJumlah";
				
				public const string JournalStatus = "JournalStatus";
				
				public const string JournalDesc = "JournalDesc";
				
				public const string AccountSaldo = "AccountSaldo";
				
				public const string SubAccontSaldo = "SubAccontSaldo";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
