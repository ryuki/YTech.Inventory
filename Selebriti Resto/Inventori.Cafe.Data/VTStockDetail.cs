using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class VTStockDetail: IEquatable<VTStockDetail>, System.ComponentModel.IEditableObject
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
		private string _stock_desc1; 
		private string _stock_desc2; 
		private string _stock_desc3; 
		private bool _stock_is_available; 
		private string _modified_by; 
		private DateTime _modified_date; 
		private string _gudang_name; 
		private string _channel_name; 
		private string _colour_desc; 
		private string _item_name; 		
		#endregion

		#region Constructor

		public VTStockDetail()
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
			_stock_desc1 = String.Empty; 
			_stock_desc2 = String.Empty; 
			_stock_desc3 = String.Empty; 
			_stock_is_available = false; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_gudang_name = String.Empty; 
			_channel_name = String.Empty; 
			_colour_desc = String.Empty; 
			_item_name = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public VTStockDetail(
			string stock_id, 
			string item_id, 
			string gudang_name, 
			string channel_name, 
			string colour_desc, 
			string item_name)
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
			_stock_desc1 = String.Empty;
			_stock_desc2 = String.Empty;
			_stock_desc3 = String.Empty;
			_stock_is_available = false;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_gudang_name = gudang_name;
			_channel_name = channel_name;
			_colour_desc = colour_desc;
			_item_name = item_name;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructVTStockDetail
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

					internal string StockDesc1;

					internal string StockDesc2;

					internal string StockDesc3;

					internal bool StockIsAvailable;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

					internal string GudangName;

					internal string ChannelName;

					internal string ColourDesc;

					internal string ItemName;

        }

        StructVTStockDetail _clone;
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
				
				
					
					this._clone.StockDesc1 = this.StockDesc1;	
				
				
					
					this._clone.StockDesc2 = this.StockDesc2;	
				
				
					
					this._clone.StockDesc3 = this.StockDesc3;	
				
				
					
					this._clone.StockIsAvailable = this.StockIsAvailable;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
				
					
					this._clone.GudangName = this.GudangName;	
				
				
					
					this._clone.ChannelName = this.ChannelName;	
				
				
					
					this._clone.ColourDesc = this.ColourDesc;	
				
				
					
					this._clone.ItemName = this.ItemName;	
				
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
				
				
					
					this.StockDesc1 = this._clone.StockDesc1;	
				
				
					
					this.StockDesc2 = this._clone.StockDesc2;	
				
				
					
					this.StockDesc3 = this._clone.StockDesc3;	
				
				
					
					this.StockIsAvailable = this._clone.StockIsAvailable;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
				
					
					this.GudangName = this._clone.GudangName;	
				
				
					
					this.ChannelName = this._clone.ChannelName;	
				
				
					
					this.ColourDesc = this._clone.ColourDesc;	
				
				
					
					this.ItemName = this._clone.ItemName;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructVTStockDetail();
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
			VTStockDetail castObj = (VTStockDetail)obj; 
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

		public bool Equals(VTStockDetail other)
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
						
			sb.Append(_stock_desc1.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_desc2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_desc3.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_is_available.ToString()); 
			sb.Append("|");						
						
			sb.Append(_modified_by.ToString()); 
			sb.Append("|");						
						
			sb.Append(_modified_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_gudang_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_channel_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_colour_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_name.ToString()); 
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
				
				public const string StockDesc1 = "StockDesc1";
				
				public const string StockDesc2 = "StockDesc2";
				
				public const string StockDesc3 = "StockDesc3";
				
				public const string StockIsAvailable = "StockIsAvailable";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
				public const string GudangName = "GudangName";
				
				public const string ChannelName = "ChannelName";
				
				public const string ColourDesc = "ColourDesc";
				
				public const string ItemName = "ItemName";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
