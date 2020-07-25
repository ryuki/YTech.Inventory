using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class VTransactionDetailDealer: IEquatable<VTransactionDetailDealer>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _transaction_detail_id; 
		private decimal _transaction_id; 
		private string _item_id; 
		private decimal _quantity; 
		private decimal _price; 
		private decimal _jumlah; 
		private decimal _disc; 
		private decimal _ppn; 
		private decimal _total; 
		private string _modified_by; 
		private DateTime _modified_date; 
		private string _description; 
		private DateTime _expired_date; 
		private decimal _commission; 
		private decimal _cost_price; 
		private bool _is_packet; 
		private string _stock_id; 
		private string _item_name; 
		private string _group_name; 
		private int _gudang_id; 
		private string _location_id; 
		private string _stock_barcode_id; 
		private string _stock_in_by; 
		private DateTime _stock_date_in; 
		private decimal _stock_price_in; 
		private string _stock_out_by; 
		private DateTime _stock_date_out; 
		private decimal _stock_price_out; 
		private string _stock_desc1; 
		private string _stock_desc2; 
		private string _stock_desc3; 
		private bool _stock_is_available; 
		private string _gudang_name; 
		private string _channel_name; 
		private string _colour_desc; 		
		#endregion

		#region Constructor

		public VTransactionDetailDealer()
		{
			_transaction_detail_id = 0; 
			_transaction_id = 0; 
			_item_id = String.Empty; 
			_quantity = 0; 
			_price = 0; 
			_jumlah = 0; 
			_disc = 0; 
			_ppn = 0; 
			_total = 0; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_description = String.Empty; 
			_expired_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_commission = 0; 
			_cost_price = 0; 
			_is_packet = false; 
			_stock_id = String.Empty; 
			_item_name = String.Empty; 
			_group_name = String.Empty; 
			_gudang_id = 0; 
			_location_id = String.Empty; 
			_stock_barcode_id = String.Empty; 
			_stock_in_by = String.Empty; 
			_stock_date_in = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_stock_price_in = 0; 
			_stock_out_by = String.Empty; 
			_stock_date_out = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_stock_price_out = 0; 
			_stock_desc1 = String.Empty; 
			_stock_desc2 = String.Empty; 
			_stock_desc3 = String.Empty; 
			_stock_is_available = false; 
			_gudang_name = String.Empty; 
			_channel_name = String.Empty; 
			_colour_desc = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public VTransactionDetailDealer(
			decimal transaction_detail_id, 
			string group_name, 
			int gudang_id, 
			string location_id, 
			string stock_barcode_id, 
			string stock_in_by, 
			DateTime stock_date_in, 
			decimal stock_price_in, 
			string stock_out_by, 
			DateTime stock_date_out, 
			decimal stock_price_out, 
			string stock_desc1, 
			string stock_desc2, 
			string stock_desc3, 
			bool stock_is_available, 
			string gudang_name, 
			string channel_name, 
			string colour_desc)
			: this()
		{
			_transaction_detail_id = transaction_detail_id;
			_transaction_id = 0;
			_item_id = String.Empty;
			_quantity = 0;
			_price = 0;
			_jumlah = 0;
			_disc = 0;
			_ppn = 0;
			_total = 0;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_description = String.Empty;
			_expired_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_commission = 0;
			_cost_price = 0;
			_is_packet = false;
			_stock_id = String.Empty;
			_item_name = String.Empty;
			_group_name = group_name;
			_gudang_id = gudang_id;
			_location_id = location_id;
			_stock_barcode_id = stock_barcode_id;
			_stock_in_by = stock_in_by;
			_stock_date_in = stock_date_in;
			_stock_price_in = stock_price_in;
			_stock_out_by = stock_out_by;
			_stock_date_out = stock_date_out;
			_stock_price_out = stock_price_out;
			_stock_desc1 = stock_desc1;
			_stock_desc2 = stock_desc2;
			_stock_desc3 = stock_desc3;
			_stock_is_available = stock_is_available;
			_gudang_name = gudang_name;
			_channel_name = channel_name;
			_colour_desc = colour_desc;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructVTransactionDetailDealer
        {

					internal decimal TransactionDetailId;

					internal decimal TransactionId;

					internal string ItemId;

					internal decimal Quantity;

					internal decimal Price;

					internal decimal Jumlah;

					internal decimal Disc;

					internal decimal Ppn;

					internal decimal Total;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

					internal string Description;

					internal DateTime ExpiredDate;

					internal decimal Commission;

					internal decimal CostPrice;

					internal bool IsPacket;

					internal string StockId;

					internal string ItemName;

					internal string GroupName;

					internal int GudangId;

					internal string LocationId;

					internal string StockBarcodeId;

					internal string StockInBy;

					internal DateTime StockDateIn;

					internal decimal StockPriceIn;

					internal string StockOutBy;

					internal DateTime StockDateOut;

					internal decimal StockPriceOut;

					internal string StockDesc1;

					internal string StockDesc2;

					internal string StockDesc3;

					internal bool StockIsAvailable;

					internal string GudangName;

					internal string ChannelName;

					internal string ColourDesc;

        }

        StructVTransactionDetailDealer _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.TransactionDetailId = this.TransactionDetailId;	
				
				
					
					this._clone.TransactionId = this.TransactionId;	
				
				
					
					this._clone.ItemId = this.ItemId;	
				
				
					
					this._clone.Quantity = this.Quantity;	
				
				
					
					this._clone.Price = this.Price;	
				
				
					
					this._clone.Jumlah = this.Jumlah;	
				
				
					
					this._clone.Disc = this.Disc;	
				
				
					
					this._clone.Ppn = this.Ppn;	
				
				
					
					this._clone.Total = this.Total;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
				
					
					this._clone.Description = this.Description;	
				
				
					
					this._clone.ExpiredDate = this.ExpiredDate;	
				
				
					
					this._clone.Commission = this.Commission;	
				
				
					
					this._clone.CostPrice = this.CostPrice;	
				
				
					
					this._clone.IsPacket = this.IsPacket;	
				
				
					
					this._clone.StockId = this.StockId;	
				
				
					
					this._clone.ItemName = this.ItemName;	
				
				
					
					this._clone.GroupName = this.GroupName;	
				
				
					
					this._clone.GudangId = this.GudangId;	
				
				
					
					this._clone.LocationId = this.LocationId;	
				
				
					
					this._clone.StockBarcodeId = this.StockBarcodeId;	
				
				
					
					this._clone.StockInBy = this.StockInBy;	
				
				
					
					this._clone.StockDateIn = this.StockDateIn;	
				
				
					
					this._clone.StockPriceIn = this.StockPriceIn;	
				
				
					
					this._clone.StockOutBy = this.StockOutBy;	
				
				
					
					this._clone.StockDateOut = this.StockDateOut;	
				
				
					
					this._clone.StockPriceOut = this.StockPriceOut;	
				
				
					
					this._clone.StockDesc1 = this.StockDesc1;	
				
				
					
					this._clone.StockDesc2 = this.StockDesc2;	
				
				
					
					this._clone.StockDesc3 = this.StockDesc3;	
				
				
					
					this._clone.StockIsAvailable = this.StockIsAvailable;	
				
				
					
					this._clone.GudangName = this.GudangName;	
				
				
					
					this._clone.ChannelName = this.ChannelName;	
				
				
					
					this._clone.ColourDesc = this.ColourDesc;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.TransactionDetailId = this._clone.TransactionDetailId;	
				
				
					
					this.TransactionId = this._clone.TransactionId;	
				
				
					
					this.ItemId = this._clone.ItemId;	
				
				
					
					this.Quantity = this._clone.Quantity;	
				
				
					
					this.Price = this._clone.Price;	
				
				
					
					this.Jumlah = this._clone.Jumlah;	
				
				
					
					this.Disc = this._clone.Disc;	
				
				
					
					this.Ppn = this._clone.Ppn;	
				
				
					
					this.Total = this._clone.Total;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
				
					
					this.Description = this._clone.Description;	
				
				
					
					this.ExpiredDate = this._clone.ExpiredDate;	
				
				
					
					this.Commission = this._clone.Commission;	
				
				
					
					this.CostPrice = this._clone.CostPrice;	
				
				
					
					this.IsPacket = this._clone.IsPacket;	
				
				
					
					this.StockId = this._clone.StockId;	
				
				
					
					this.ItemName = this._clone.ItemName;	
				
				
					
					this.GroupName = this._clone.GroupName;	
				
				
					
					this.GudangId = this._clone.GudangId;	
				
				
					
					this.LocationId = this._clone.LocationId;	
				
				
					
					this.StockBarcodeId = this._clone.StockBarcodeId;	
				
				
					
					this.StockInBy = this._clone.StockInBy;	
				
				
					
					this.StockDateIn = this._clone.StockDateIn;	
				
				
					
					this.StockPriceIn = this._clone.StockPriceIn;	
				
				
					
					this.StockOutBy = this._clone.StockOutBy;	
				
				
					
					this.StockDateOut = this._clone.StockDateOut;	
				
				
					
					this.StockPriceOut = this._clone.StockPriceOut;	
				
				
					
					this.StockDesc1 = this._clone.StockDesc1;	
				
				
					
					this.StockDesc2 = this._clone.StockDesc2;	
				
				
					
					this.StockDesc3 = this._clone.StockDesc3;	
				
				
					
					this.StockIsAvailable = this._clone.StockIsAvailable;	
				
				
					
					this.GudangName = this._clone.GudangName;	
				
				
					
					this.ChannelName = this._clone.ChannelName;	
				
				
					
					this.ColourDesc = this._clone.ColourDesc;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructVTransactionDetailDealer();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual decimal TransactionDetailId
		{
			get
			{ 
				return _transaction_detail_id;
			}
			set
			{
				_transaction_detail_id = value;
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
			
		public virtual decimal Quantity
		{
			get
			{ 
				return _quantity;
			}
			set
			{
				_quantity = value;
			}

		}
			
		public virtual decimal Price
		{
			get
			{ 
				return _price;
			}
			set
			{
				_price = value;
			}

		}
			
		public virtual decimal Jumlah
		{
			get
			{ 
				return _jumlah;
			}
			set
			{
				_jumlah = value;
			}

		}
			
		public virtual decimal Disc
		{
			get
			{ 
				return _disc;
			}
			set
			{
				_disc = value;
			}

		}
			
		public virtual decimal Ppn
		{
			get
			{ 
				return _ppn;
			}
			set
			{
				_ppn = value;
			}

		}
			
		public virtual decimal Total
		{
			get
			{ 
				return _total;
			}
			set
			{
				_total = value;
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
			
		public virtual string Description
		{
			get
			{ 
				return _description;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				
				_description = value;
			}
		}
			
		public virtual DateTime ExpiredDate
		{
			get
			{ 
				return _expired_date;
			}
			set
			{
				_expired_date = value;
			}

		}
			
		public virtual decimal Commission
		{
			get
			{ 
				return _commission;
			}
			set
			{
				_commission = value;
			}

		}
			
		public virtual decimal CostPrice
		{
			get
			{ 
				return _cost_price;
			}
			set
			{
				_cost_price = value;
			}

		}
			
		public virtual bool IsPacket
		{
			get
			{ 
				return _is_packet;
			}
			set
			{
				_is_packet = value;
			}

		}
			
		public virtual string StockId
		{
			get
			{ 
				return _stock_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for StockId", value, value.ToString());
				
				_stock_id = value;
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
			
		public virtual string GroupName
		{
			get
			{ 
				return _group_name;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for GroupName", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for GroupName", value, value.ToString());
				
				_group_name = value;
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
			
		public virtual string LocationId
		{
			get
			{ 
				return _location_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for LocationId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for LocationId", value, value.ToString());
				
				_location_id = value;
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
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for StockBarcodeId", value, "null");
				
				if(  value.Length > 50)
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
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for StockInBy", value, "null");
				
				if(  value.Length > 50)
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
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for StockOutBy", value, "null");
				
				if(  value.Length > 50)
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
			
		public virtual string StockDesc1
		{
			get
			{ 
				return _stock_desc1;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for StockDesc1", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for StockDesc1", value, value.ToString());
				
				_stock_desc1 = value;
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
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for StockDesc2", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for StockDesc2", value, value.ToString());
				
				_stock_desc2 = value;
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
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for StockDesc3", value, "null");
				
				if(  value.Length > 50)
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
			VTransactionDetailDealer castObj = (VTransactionDetailDealer)obj; 
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

		public bool Equals(VTransactionDetailDealer other)
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
		
			sb.Append(_transaction_detail_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_quantity.ToString()); 
			sb.Append("|");						
						
			sb.Append(_price.ToString()); 
			sb.Append("|");						
						
			sb.Append(_jumlah.ToString()); 
			sb.Append("|");						
						
			sb.Append(_disc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_ppn.ToString()); 
			sb.Append("|");						
						
			sb.Append(_total.ToString()); 
			sb.Append("|");						
						
			sb.Append(_modified_by.ToString()); 
			sb.Append("|");						
						
			sb.Append(_modified_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_description.ToString()); 
			sb.Append("|");						
						
			sb.Append(_expired_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_commission.ToString()); 
			sb.Append("|");						
						
			sb.Append(_cost_price.ToString()); 
			sb.Append("|");						
						
			sb.Append(_is_packet.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_group_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_gudang_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_location_id.ToString()); 
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
						
			sb.Append(_stock_desc1.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_desc2.ToString()); 
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
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string TransactionDetailId = "TransactionDetailId";
				
				public const string TransactionId = "TransactionId";
				
				public const string ItemId = "ItemId";
				
				public const string Quantity = "Quantity";
				
				public const string Price = "Price";
				
				public const string Jumlah = "Jumlah";
				
				public const string Disc = "Disc";
				
				public const string Ppn = "Ppn";
				
				public const string Total = "Total";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
				public const string Description = "Description";
				
				public const string ExpiredDate = "ExpiredDate";
				
				public const string Commission = "Commission";
				
				public const string CostPrice = "CostPrice";
				
				public const string IsPacket = "IsPacket";
				
				public const string StockId = "StockId";
				
				public const string ItemName = "ItemName";
				
				public const string GroupName = "GroupName";
				
				public const string GudangId = "GudangId";
				
				public const string LocationId = "LocationId";
				
				public const string StockBarcodeId = "StockBarcodeId";
				
				public const string StockInBy = "StockInBy";
				
				public const string StockDateIn = "StockDateIn";
				
				public const string StockPriceIn = "StockPriceIn";
				
				public const string StockOutBy = "StockOutBy";
				
				public const string StockDateOut = "StockDateOut";
				
				public const string StockPriceOut = "StockPriceOut";
				
				public const string StockDesc1 = "StockDesc1";
				
				public const string StockDesc2 = "StockDesc2";
				
				public const string StockDesc3 = "StockDesc3";
				
				public const string StockIsAvailable = "StockIsAvailable";
				
				public const string GudangName = "GudangName";
				
				public const string ChannelName = "ChannelName";
				
				public const string ColourDesc = "ColourDesc";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
