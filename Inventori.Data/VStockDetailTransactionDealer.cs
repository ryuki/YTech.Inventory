using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class VStockDetailTransactionDealer: IEquatable<VStockDetailTransactionDealer>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _stock_id; 
		private int _gudang_id; 
		private string _item_id; 
		private string _locaton_id; 
		private string _stock_barcode_id; 
		private string _stock_in_by; 
		private DateTime _stock_date_in; 
		private decimal _stock_price_in; 
		private string _stock_out_by; 
		private DateTime _stock_date_out; 
		private decimal _stock_price_out; 
		private string _stock_desc2; 
		private string _stock_desc1; 
		private string _stock_desc3; 
		private bool _stock_is_available; 
		private string _gudang_name; 
		private string _channel_name; 
		private string _colour_desc; 
		private string _item_name; 
		private decimal _transaction_id; 
		private string _transaction_factur; 
		private string _transaction_by; 
		private string _customer_name; 
		private string _supplier_name; 
		private decimal _transaction_potongan; 
		private string _transaction_status; 
		private decimal _transaction_paid; 
		private DateTime _transaction_date; 		
		#endregion

		#region Constructor

		public VStockDetailTransactionDealer()
		{
			_stock_id = String.Empty; 
			_gudang_id = 0; 
			_item_id = String.Empty; 
			_locaton_id = String.Empty; 
			_stock_barcode_id = String.Empty; 
			_stock_in_by = String.Empty; 
			_stock_date_in = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_stock_price_in = 0; 
			_stock_out_by = String.Empty; 
			_stock_date_out = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_stock_price_out = 0; 
			_stock_desc2 = String.Empty; 
			_stock_desc1 = String.Empty; 
			_stock_desc3 = String.Empty; 
			_stock_is_available = false; 
			_gudang_name = String.Empty; 
			_channel_name = String.Empty; 
			_colour_desc = String.Empty; 
			_item_name = String.Empty; 
			_transaction_id = 0; 
			_transaction_factur = String.Empty; 
			_transaction_by = String.Empty; 
			_customer_name = String.Empty; 
			_supplier_name = String.Empty; 
			_transaction_potongan = 0; 
			_transaction_status = String.Empty; 
			_transaction_paid = 0; 
			_transaction_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public VStockDetailTransactionDealer(
			string stock_id, 
			string item_id, 
			string gudang_name, 
			string channel_name, 
			string colour_desc, 
			string item_name, 
			decimal transaction_id, 
			string transaction_factur, 
			string transaction_by, 
			string customer_name, 
			string supplier_name, 
			decimal transaction_potongan, 
			string transaction_status, 
			decimal transaction_paid, 
			DateTime transaction_date)
			: this()
		{
			_stock_id = stock_id;
			_gudang_id = 0;
			_item_id = item_id;
			_locaton_id = String.Empty;
			_stock_barcode_id = String.Empty;
			_stock_in_by = String.Empty;
			_stock_date_in = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_stock_price_in = 0;
			_stock_out_by = String.Empty;
			_stock_date_out = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_stock_price_out = 0;
			_stock_desc2 = String.Empty;
			_stock_desc1 = String.Empty;
			_stock_desc3 = String.Empty;
			_stock_is_available = false;
			_gudang_name = gudang_name;
			_channel_name = channel_name;
			_colour_desc = colour_desc;
			_item_name = item_name;
			_transaction_id = transaction_id;
			_transaction_factur = transaction_factur;
			_transaction_by = transaction_by;
			_customer_name = customer_name;
			_supplier_name = supplier_name;
			_transaction_potongan = transaction_potongan;
			_transaction_status = transaction_status;
			_transaction_paid = transaction_paid;
			_transaction_date = transaction_date;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructVStockDetailTransactionDealer
        {

					internal string StockId;

					internal int GudangId;

					internal string ItemId;

					internal string LocatonId;

					internal string StockBarcodeId;

					internal string StockInBy;

					internal DateTime StockDateIn;

					internal decimal StockPriceIn;

					internal string StockOutBy;

					internal DateTime StockDateOut;

					internal decimal StockPriceOut;

					internal string StockDesc2;

					internal string StockDesc1;

					internal string StockDesc3;

					internal bool StockIsAvailable;

					internal string GudangName;

					internal string ChannelName;

					internal string ColourDesc;

					internal string ItemName;

					internal decimal TransactionId;

					internal string TransactionFactur;

					internal string TransactionBy;

					internal string CustomerName;

					internal string SupplierName;

					internal decimal TransactionPotongan;

					internal string TransactionStatus;

					internal decimal TransactionPaid;

					internal DateTime TransactionDate;

        }

        StructVStockDetailTransactionDealer _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.StockId = this.StockId;	
				
				
					
					this._clone.GudangId = this.GudangId;	
				
				
					
					this._clone.ItemId = this.ItemId;	
				
				
					
					this._clone.LocatonId = this.LocatonId;	
				
				
					
					this._clone.StockBarcodeId = this.StockBarcodeId;	
				
				
					
					this._clone.StockInBy = this.StockInBy;	
				
				
					
					this._clone.StockDateIn = this.StockDateIn;	
				
				
					
					this._clone.StockPriceIn = this.StockPriceIn;	
				
				
					
					this._clone.StockOutBy = this.StockOutBy;	
				
				
					
					this._clone.StockDateOut = this.StockDateOut;	
				
				
					
					this._clone.StockPriceOut = this.StockPriceOut;	
				
				
					
					this._clone.StockDesc2 = this.StockDesc2;	
				
				
					
					this._clone.StockDesc1 = this.StockDesc1;	
				
				
					
					this._clone.StockDesc3 = this.StockDesc3;	
				
				
					
					this._clone.StockIsAvailable = this.StockIsAvailable;	
				
				
					
					this._clone.GudangName = this.GudangName;	
				
				
					
					this._clone.ChannelName = this.ChannelName;	
				
				
					
					this._clone.ColourDesc = this.ColourDesc;	
				
				
					
					this._clone.ItemName = this.ItemName;	
				
				
					
					this._clone.TransactionId = this.TransactionId;	
				
				
					
					this._clone.TransactionFactur = this.TransactionFactur;	
				
				
					
					this._clone.TransactionBy = this.TransactionBy;	
				
				
					
					this._clone.CustomerName = this.CustomerName;	
				
				
					
					this._clone.SupplierName = this.SupplierName;	
				
				
					
					this._clone.TransactionPotongan = this.TransactionPotongan;	
				
				
					
					this._clone.TransactionStatus = this.TransactionStatus;	
				
				
					
					this._clone.TransactionPaid = this.TransactionPaid;	
				
				
					
					this._clone.TransactionDate = this.TransactionDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.StockId = this._clone.StockId;	
				
				
					
					this.GudangId = this._clone.GudangId;	
				
				
					
					this.ItemId = this._clone.ItemId;	
				
				
					
					this.LocatonId = this._clone.LocatonId;	
				
				
					
					this.StockBarcodeId = this._clone.StockBarcodeId;	
				
				
					
					this.StockInBy = this._clone.StockInBy;	
				
				
					
					this.StockDateIn = this._clone.StockDateIn;	
				
				
					
					this.StockPriceIn = this._clone.StockPriceIn;	
				
				
					
					this.StockOutBy = this._clone.StockOutBy;	
				
				
					
					this.StockDateOut = this._clone.StockDateOut;	
				
				
					
					this.StockPriceOut = this._clone.StockPriceOut;	
				
				
					
					this.StockDesc2 = this._clone.StockDesc2;	
				
				
					
					this.StockDesc1 = this._clone.StockDesc1;	
				
				
					
					this.StockDesc3 = this._clone.StockDesc3;	
				
				
					
					this.StockIsAvailable = this._clone.StockIsAvailable;	
				
				
					
					this.GudangName = this._clone.GudangName;	
				
				
					
					this.ChannelName = this._clone.ChannelName;	
				
				
					
					this.ColourDesc = this._clone.ColourDesc;	
				
				
					
					this.ItemName = this._clone.ItemName;	
				
				
					
					this.TransactionId = this._clone.TransactionId;	
				
				
					
					this.TransactionFactur = this._clone.TransactionFactur;	
				
				
					
					this.TransactionBy = this._clone.TransactionBy;	
				
				
					
					this.CustomerName = this._clone.CustomerName;	
				
				
					
					this.SupplierName = this._clone.SupplierName;	
				
				
					
					this.TransactionPotongan = this._clone.TransactionPotongan;	
				
				
					
					this.TransactionStatus = this._clone.TransactionStatus;	
				
				
					
					this.TransactionPaid = this._clone.TransactionPaid;	
				
				
					
					this.TransactionDate = this._clone.TransactionDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructVStockDetailTransactionDealer();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string StockId
		{
			get
			{ 
				return _stock_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for StockId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for StockId", value, value.ToString());
				
				_stock_id = value;
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
			
		public virtual string ItemId
		{
			get
			{ 
				return _item_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for ItemId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ItemId", value, value.ToString());
				
				_item_id = value;
			}
		}
			
		public virtual string LocatonId
		{
			get
			{ 
				return _locaton_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for LocatonId", value, value.ToString());
				
				_locaton_id = value;
			}
		}
			
		public virtual string StockBarcodeId
		{
			get
			{ 
				return _stock_barcode_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for StockBarcodeId", value, value.ToString());
				
				_stock_barcode_id = value;
			}
		}
			
		public virtual string StockInBy
		{
			get
			{ 
				return _stock_in_by;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for StockInBy", value, value.ToString());
				
				_stock_in_by = value;
			}
		}
			
		public virtual DateTime StockDateIn
		{
			get
			{ 
				return _stock_date_in;
			}
			set
			{
				_stock_date_in = value;
			}

		}
			
		public virtual decimal StockPriceIn
		{
			get
			{ 
				return _stock_price_in;
			}
			set
			{
				_stock_price_in = value;
			}

		}
			
		public virtual string StockOutBy
		{
			get
			{ 
				return _stock_out_by;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for StockOutBy", value, value.ToString());
				
				_stock_out_by = value;
			}
		}
			
		public virtual DateTime StockDateOut
		{
			get
			{ 
				return _stock_date_out;
			}
			set
			{
				_stock_date_out = value;
			}

		}
			
		public virtual decimal StockPriceOut
		{
			get
			{ 
				return _stock_price_out;
			}
			set
			{
				_stock_price_out = value;
			}

		}
			
		public virtual string StockDesc2
		{
			get
			{ 
				return _stock_desc2;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for StockDesc2", value, value.ToString());
				
				_stock_desc2 = value;
			}
		}
			
		public virtual string StockDesc1
		{
			get
			{ 
				return _stock_desc1;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for StockDesc1", value, value.ToString());
				
				_stock_desc1 = value;
			}
		}
			
		public virtual string StockDesc3
		{
			get
			{ 
				return _stock_desc3;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for StockDesc3", value, value.ToString());
				
				_stock_desc3 = value;
			}
		}
			
		public virtual bool StockIsAvailable
		{
			get
			{ 
				return _stock_is_available;
			}
			set
			{
				_stock_is_available = value;
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
			
		public virtual string ChannelName
		{
			get
			{ 
				return _channel_name;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for ChannelName", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelName", value, value.ToString());
				
				_channel_name = value;
			}
		}
			
		public virtual string ColourDesc
		{
			get
			{ 
				return _colour_desc;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for ColourDesc", value, "null");
				
				if(  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ColourDesc", value, value.ToString());
				
				_colour_desc = value;
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
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for ItemName", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ItemName", value, value.ToString());
				
				_item_name = value;
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
			
		public virtual string TransactionBy
		{
			get
			{ 
				return _transaction_by;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for TransactionBy", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionBy", value, value.ToString());
				
				_transaction_by = value;
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
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for CustomerName", value, "null");
				
				if(  value.Length > 50)
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
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for SupplierName", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SupplierName", value, value.ToString());
				
				_supplier_name = value;
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
			
		public virtual string TransactionStatus
		{
			get
			{ 
				return _transaction_status;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for TransactionStatus", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionStatus", value, value.ToString());
				
				_transaction_status = value;
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
			VStockDetailTransactionDealer castObj = (VStockDetailTransactionDealer)obj; 
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

		public bool Equals(VStockDetailTransactionDealer other)
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
		
			sb.Append(_stock_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_gudang_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_locaton_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_barcode_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_in_by.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_date_in.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_price_in.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_out_by.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_date_out.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_price_out.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_desc2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_desc1.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_desc3.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_is_available.ToString()); 
			sb.Append("|");						
						
			sb.Append(_gudang_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_channel_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_colour_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_factur.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_by.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_supplier_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_potongan.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_paid.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_date.ToString()); 
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string StockId = "StockId";
				
				public const string GudangId = "GudangId";
				
				public const string ItemId = "ItemId";
				
				public const string LocatonId = "LocatonId";
				
				public const string StockBarcodeId = "StockBarcodeId";
				
				public const string StockInBy = "StockInBy";
				
				public const string StockDateIn = "StockDateIn";
				
				public const string StockPriceIn = "StockPriceIn";
				
				public const string StockOutBy = "StockOutBy";
				
				public const string StockDateOut = "StockDateOut";
				
				public const string StockPriceOut = "StockPriceOut";
				
				public const string StockDesc2 = "StockDesc2";
				
				public const string StockDesc1 = "StockDesc1";
				
				public const string StockDesc3 = "StockDesc3";
				
				public const string StockIsAvailable = "StockIsAvailable";
				
				public const string GudangName = "GudangName";
				
				public const string ChannelName = "ChannelName";
				
				public const string ColourDesc = "ColourDesc";
				
				public const string ItemName = "ItemName";
				
				public const string TransactionId = "TransactionId";
				
				public const string TransactionFactur = "TransactionFactur";
				
				public const string TransactionBy = "TransactionBy";
				
				public const string CustomerName = "CustomerName";
				
				public const string SupplierName = "SupplierName";
				
				public const string TransactionPotongan = "TransactionPotongan";
				
				public const string TransactionStatus = "TransactionStatus";
				
				public const string TransactionPaid = "TransactionPaid";
				
				public const string TransactionDate = "TransactionDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
