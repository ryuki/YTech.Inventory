using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class VStokCard: IEquatable<VStokCard>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _stok_card_id; 
		private string _item_id; 
		private int _gudang_id; 
		private DateTime _stok_card_date; 
		private decimal _transaction_id; 
		private bool _stok_card_status; 
		private decimal _stok_card_quantity; 
		private decimal _stok_card_saldo; 
		private string _stok_card_pic; 
		private string _modified_by; 
		private DateTime _modified_date; 
		private string _item_name; 
		private string _transaction_factur; 
		private string _gudang_name; 		
		#endregion

		#region Constructor

		public VStokCard()
		{
			_stok_card_id = 0; 
			_item_id = String.Empty; 
			_gudang_id = 0; 
			_stok_card_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_transaction_id = 0; 
			_stok_card_status = false; 
			_stok_card_quantity = 0; 
			_stok_card_saldo = 0; 
			_stok_card_pic = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_item_name = String.Empty; 
			_transaction_factur = String.Empty; 
			_gudang_name = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public VStokCard(
			decimal stok_card_id, 
			string transaction_factur, 
			string gudang_name)
			: this()
		{
			_stok_card_id = stok_card_id;
			_item_id = String.Empty;
			_gudang_id = 0;
			_stok_card_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_transaction_id = 0;
			_stok_card_status = false;
			_stok_card_quantity = 0;
			_stok_card_saldo = 0;
			_stok_card_pic = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_item_name = String.Empty;
			_transaction_factur = transaction_factur;
			_gudang_name = gudang_name;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructVStokCard
        {

					internal decimal StokCardId;

					internal string ItemId;

					internal int GudangId;

					internal DateTime StokCardDate;

					internal decimal TransactionId;

					internal bool StokCardStatus;

					internal decimal StokCardQuantity;

					internal decimal StokCardSaldo;

					internal string StokCardPic;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

					internal string ItemName;

					internal string TransactionFactur;

					internal string GudangName;

        }

        StructVStokCard _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.StokCardId = this.StokCardId;	
				
				
					
					this._clone.ItemId = this.ItemId;	
				
				
					
					this._clone.GudangId = this.GudangId;	
				
				
					
					this._clone.StokCardDate = this.StokCardDate;	
				
				
					
					this._clone.TransactionId = this.TransactionId;	
				
				
					
					this._clone.StokCardStatus = this.StokCardStatus;	
				
				
					
					this._clone.StokCardQuantity = this.StokCardQuantity;	
				
				
					
					this._clone.StokCardSaldo = this.StokCardSaldo;	
				
				
					
					this._clone.StokCardPic = this.StokCardPic;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
				
					
					this._clone.ItemName = this.ItemName;	
				
				
					
					this._clone.TransactionFactur = this.TransactionFactur;	
				
				
					
					this._clone.GudangName = this.GudangName;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.StokCardId = this._clone.StokCardId;	
				
				
					
					this.ItemId = this._clone.ItemId;	
				
				
					
					this.GudangId = this._clone.GudangId;	
				
				
					
					this.StokCardDate = this._clone.StokCardDate;	
				
				
					
					this.TransactionId = this._clone.TransactionId;	
				
				
					
					this.StokCardStatus = this._clone.StokCardStatus;	
				
				
					
					this.StokCardQuantity = this._clone.StokCardQuantity;	
				
				
					
					this.StokCardSaldo = this._clone.StokCardSaldo;	
				
				
					
					this.StokCardPic = this._clone.StokCardPic;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
				
					
					this.ItemName = this._clone.ItemName;	
				
				
					
					this.TransactionFactur = this._clone.TransactionFactur;	
				
				
					
					this.GudangName = this._clone.GudangName;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructVStokCard();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual decimal StokCardId
		{
			get
			{ 
				return _stok_card_id;
			}
			set
			{
				_stok_card_id = value;
			}

		}
			
		public virtual string ItemId
		{
			get
			{ 
				return _item_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ItemId", value, value.ToString());
				
				_item_id = value;
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
			
		public virtual DateTime StokCardDate
		{
			get
			{ 
				return _stok_card_date;
			}
			set
			{
				_stok_card_date = value;
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
			
		public virtual bool StokCardStatus
		{
			get
			{ 
				return _stok_card_status;
			}
			set
			{
				_stok_card_status = value;
			}

		}
			
		public virtual decimal StokCardQuantity
		{
			get
			{ 
				return _stok_card_quantity;
			}
			set
			{
				_stok_card_quantity = value;
			}

		}
			
		public virtual decimal StokCardSaldo
		{
			get
			{ 
				return _stok_card_saldo;
			}
			set
			{
				_stok_card_saldo = value;
			}

		}
			
		public virtual string StokCardPic
		{
			get
			{ 
				return _stok_card_pic;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for StokCardPic", value, value.ToString());
				
				_stok_card_pic = value;
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
			
		public virtual string ItemName
		{
			get
			{ 
				return _item_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ItemName", value, value.ToString());
				
				_item_name = value;
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
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for TransactionFactur", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionFactur", value, value.ToString());
				
				_transaction_factur = value;
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
			VStokCard castObj = (VStokCard)obj; 
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

		public bool Equals(VStokCard other)
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
		
			sb.Append(_stok_card_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_gudang_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stok_card_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stok_card_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stok_card_quantity.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stok_card_saldo.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stok_card_pic.ToString()); 
			sb.Append("|");						
						
			sb.Append(_modified_by.ToString()); 
			sb.Append("|");						
						
			sb.Append(_modified_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_factur.ToString()); 
			sb.Append("|");						
						
			sb.Append(_gudang_name.ToString()); 
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string StokCardId = "StokCardId";
				
				public const string ItemId = "ItemId";
				
				public const string GudangId = "GudangId";
				
				public const string StokCardDate = "StokCardDate";
				
				public const string TransactionId = "TransactionId";
				
				public const string StokCardStatus = "StokCardStatus";
				
				public const string StokCardQuantity = "StokCardQuantity";
				
				public const string StokCardSaldo = "StokCardSaldo";
				
				public const string StokCardPic = "StokCardPic";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
				public const string ItemName = "ItemName";
				
				public const string TransactionFactur = "TransactionFactur";
				
				public const string GudangName = "GudangName";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
