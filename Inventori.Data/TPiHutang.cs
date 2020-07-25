using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class TPiHutang: IEquatable<TPiHutang>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _pi_hutang_id; 
		private string _pi_hutang_status; 
		private decimal _transaction_id; 
		private string _sub_account_id; 
		private string _pi_hutang_pic; 
		private DateTime _pi_hutang_date; 
		private DateTime _pi_hutang_jatuh_tempo; 
		private decimal _pi_hutang_jumlah; 
		private decimal _pi_hutang_dibayar; 
		private decimal _pi_hutang_retur; 
		private decimal _pi_hutang_sisa; 
		private DateTime _pi_hutang_lunas_date; 
		private decimal _pi_hutang_credit_long; 
		private string _pi_hutang_desc; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TPiHutang()
		{
			_pi_hutang_id = 0; 
			_pi_hutang_status = String.Empty; 
			_transaction_id = 0; 
			_sub_account_id = String.Empty; 
			_pi_hutang_pic = String.Empty; 
			_pi_hutang_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_pi_hutang_jatuh_tempo = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_pi_hutang_jumlah = 0; 
			_pi_hutang_dibayar = 0; 
			_pi_hutang_retur = 0; 
			_pi_hutang_sisa = 0; 
			_pi_hutang_lunas_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_pi_hutang_credit_long = 0; 
			_pi_hutang_desc = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TPiHutang(
			decimal pi_hutang_id)
			: this()
		{
			_pi_hutang_id = pi_hutang_id;
			_pi_hutang_status = String.Empty;
			_transaction_id = 0;
			_sub_account_id = String.Empty;
			_pi_hutang_pic = String.Empty;
			_pi_hutang_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_pi_hutang_jatuh_tempo = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_pi_hutang_jumlah = 0;
			_pi_hutang_dibayar = 0;
			_pi_hutang_retur = 0;
			_pi_hutang_sisa = 0;
			_pi_hutang_lunas_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_pi_hutang_credit_long = 0;
			_pi_hutang_desc = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTPiHutang
        {

					internal decimal PiHutangId;

					internal string PiHutangStatus;

					internal decimal TransactionId;

					internal string SubAccountId;

					internal string PiHutangPic;

					internal DateTime PiHutangDate;

					internal DateTime PiHutangJatuhTempo;

					internal decimal PiHutangJumlah;

					internal decimal PiHutangDibayar;

					internal decimal PiHutangRetur;

					internal decimal PiHutangSisa;

					internal DateTime PiHutangLunasDate;

					internal decimal PiHutangCreditLong;

					internal string PiHutangDesc;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTPiHutang _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.PiHutangId = this.PiHutangId;	
				
				
					
					this._clone.PiHutangStatus = this.PiHutangStatus;	
				
				
					
					this._clone.TransactionId = this.TransactionId;	
				
				
					
					this._clone.SubAccountId = this.SubAccountId;	
				
				
					
					this._clone.PiHutangPic = this.PiHutangPic;	
				
				
					
					this._clone.PiHutangDate = this.PiHutangDate;	
				
				
					
					this._clone.PiHutangJatuhTempo = this.PiHutangJatuhTempo;	
				
				
					
					this._clone.PiHutangJumlah = this.PiHutangJumlah;	
				
				
					
					this._clone.PiHutangDibayar = this.PiHutangDibayar;	
				
				
					
					this._clone.PiHutangRetur = this.PiHutangRetur;	
				
				
					
					this._clone.PiHutangSisa = this.PiHutangSisa;	
				
				
					
					this._clone.PiHutangLunasDate = this.PiHutangLunasDate;	
				
				
					
					this._clone.PiHutangCreditLong = this.PiHutangCreditLong;	
				
				
					
					this._clone.PiHutangDesc = this.PiHutangDesc;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.PiHutangId = this._clone.PiHutangId;	
				
				
					
					this.PiHutangStatus = this._clone.PiHutangStatus;	
				
				
					
					this.TransactionId = this._clone.TransactionId;	
				
				
					
					this.SubAccountId = this._clone.SubAccountId;	
				
				
					
					this.PiHutangPic = this._clone.PiHutangPic;	
				
				
					
					this.PiHutangDate = this._clone.PiHutangDate;	
				
				
					
					this.PiHutangJatuhTempo = this._clone.PiHutangJatuhTempo;	
				
				
					
					this.PiHutangJumlah = this._clone.PiHutangJumlah;	
				
				
					
					this.PiHutangDibayar = this._clone.PiHutangDibayar;	
				
				
					
					this.PiHutangRetur = this._clone.PiHutangRetur;	
				
				
					
					this.PiHutangSisa = this._clone.PiHutangSisa;	
				
				
					
					this.PiHutangLunasDate = this._clone.PiHutangLunasDate;	
				
				
					
					this.PiHutangCreditLong = this._clone.PiHutangCreditLong;	
				
				
					
					this.PiHutangDesc = this._clone.PiHutangDesc;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTPiHutang();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
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
			
		public virtual string PiHutangStatus
		{
			get
			{ 
				return _pi_hutang_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for PiHutangStatus", value, value.ToString());
				
				_pi_hutang_status = value;
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
			
		public virtual string PiHutangPic
		{
			get
			{ 
				return _pi_hutang_pic;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for PiHutangPic", value, value.ToString());
				
				_pi_hutang_pic = value;
			}
		}
			
		public virtual DateTime PiHutangDate
		{
			get
			{ 
				return _pi_hutang_date;
			}
			set
			{
				_pi_hutang_date = value;
			}

		}
			
		public virtual DateTime PiHutangJatuhTempo
		{
			get
			{ 
				return _pi_hutang_jatuh_tempo;
			}
			set
			{
				_pi_hutang_jatuh_tempo = value;
			}

		}
			
		public virtual decimal PiHutangJumlah
		{
			get
			{ 
				return _pi_hutang_jumlah;
			}
			set
			{
				_pi_hutang_jumlah = value;
			}

		}
			
		public virtual decimal PiHutangDibayar
		{
			get
			{ 
				return _pi_hutang_dibayar;
			}
			set
			{
				_pi_hutang_dibayar = value;
			}

		}
			
		public virtual decimal PiHutangRetur
		{
			get
			{ 
				return _pi_hutang_retur;
			}
			set
			{
				_pi_hutang_retur = value;
			}

		}
			
		public virtual decimal PiHutangSisa
		{
			get
			{ 
				return _pi_hutang_sisa;
			}
			set
			{
				_pi_hutang_sisa = value;
			}

		}
			
		public virtual DateTime PiHutangLunasDate
		{
			get
			{ 
				return _pi_hutang_lunas_date;
			}
			set
			{
				_pi_hutang_lunas_date = value;
			}

		}
			
		public virtual decimal PiHutangCreditLong
		{
			get
			{ 
				return _pi_hutang_credit_long;
			}
			set
			{
				_pi_hutang_credit_long = value;
			}

		}
			
		public virtual string PiHutangDesc
		{
			get
			{ 
				return _pi_hutang_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 2147483647)
					throw new ArgumentOutOfRangeException("Invalid value for PiHutangDesc", value, value.ToString());
				
				_pi_hutang_desc = value;
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
			TPiHutang castObj = (TPiHutang)obj; 
			return ( castObj != null ) &&
				( this._pi_hutang_id == castObj.PiHutangId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _pi_hutang_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TPiHutang other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._pi_hutang_id == other.PiHutangId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_pi_hutang_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_pi_hutang_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_sub_account_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_pi_hutang_pic.ToString()); 
			sb.Append("|");						
						
			sb.Append(_pi_hutang_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_pi_hutang_jatuh_tempo.ToString()); 
			sb.Append("|");						
						
			sb.Append(_pi_hutang_jumlah.ToString()); 
			sb.Append("|");						
						
			sb.Append(_pi_hutang_dibayar.ToString()); 
			sb.Append("|");						
						
			sb.Append(_pi_hutang_retur.ToString()); 
			sb.Append("|");						
						
			sb.Append(_pi_hutang_sisa.ToString()); 
			sb.Append("|");						
						
			sb.Append(_pi_hutang_lunas_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_pi_hutang_credit_long.ToString()); 
			sb.Append("|");						
						
			sb.Append(_pi_hutang_desc.ToString()); 
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
		
				public const string PiHutangId = "PiHutangId";
				
				public const string PiHutangStatus = "PiHutangStatus";
				
				public const string TransactionId = "TransactionId";
				
				public const string SubAccountId = "SubAccountId";
				
				public const string PiHutangPic = "PiHutangPic";
				
				public const string PiHutangDate = "PiHutangDate";
				
				public const string PiHutangJatuhTempo = "PiHutangJatuhTempo";
				
				public const string PiHutangJumlah = "PiHutangJumlah";
				
				public const string PiHutangDibayar = "PiHutangDibayar";
				
				public const string PiHutangRetur = "PiHutangRetur";
				
				public const string PiHutangSisa = "PiHutangSisa";
				
				public const string PiHutangLunasDate = "PiHutangLunasDate";
				
				public const string PiHutangCreditLong = "PiHutangCreditLong";
				
				public const string PiHutangDesc = "PiHutangDesc";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
