using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class VTotalTransactionDealer: IEquatable<VTotalTransactionDealer>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _transaction_id; 
		private int _gudang_id; 
		private string _currency_id; 
		private decimal _transaction_reference_id; 
		private string _transaction_factur; 
		private string _transaction_by; 
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
		private int _gudang_id_to; 
		private string _location_id; 
		private string _location_id_to; 
		private string _channel_name; 
		private string _channel_name_to; 
		private decimal _transaction_detail_id; 
		private string _item_id; 
		private decimal _quantity; 
		private decimal _price; 
		private decimal _jumlah; 
		private decimal _disc; 
		private decimal _ppn; 
		private decimal _total; 
		private string _description; 
		private DateTime _expired_date; 
		private decimal _commission; 
		private decimal _cost_price; 
		private bool _is_packet; 
		private string _stock_id; 
		private string _item_name; 
		private string _group_name; 
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
		private string _stock_gudang_name; 
		private string _stock_channel_name; 
		private string _colour_desc; 
		private string _finance_name; 
		private string _customer_address; 
		private string _customer_phone; 
		private string _customer_fax; 
		private string _customer_npwp; 
		private string _customer_desc; 		
		#endregion

		#region Constructor

		public VTotalTransactionDealer()
		{
			_transaction_id = 0; 
			_gudang_id = 0; 
			_currency_id = String.Empty; 
			_transaction_reference_id = 0; 
			_transaction_factur = String.Empty; 
			_transaction_by = String.Empty; 
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
			_gudang_id_to = 0; 
			_location_id = String.Empty; 
			_location_id_to = String.Empty; 
			_channel_name = String.Empty; 
			_channel_name_to = String.Empty; 
			_transaction_detail_id = 0; 
			_item_id = String.Empty; 
			_quantity = 0; 
			_price = 0; 
			_jumlah = 0; 
			_disc = 0; 
			_ppn = 0; 
			_total = 0; 
			_description = String.Empty; 
			_expired_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_commission = 0; 
			_cost_price = 0; 
			_is_packet = false; 
			_stock_id = String.Empty; 
			_item_name = String.Empty; 
			_group_name = String.Empty; 
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
			_stock_gudang_name = String.Empty; 
			_stock_channel_name = String.Empty; 
			_colour_desc = String.Empty; 
			_finance_name = String.Empty; 
			_customer_address = String.Empty; 
			_customer_phone = String.Empty; 
			_customer_fax = String.Empty; 
			_customer_npwp = String.Empty; 
			_customer_desc = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public VTotalTransactionDealer(
			decimal transaction_id, 
			string employee_name, 
			string customer_group_name, 
			string gudang_name, 
			string gudang_name_to, 
			string channel_name, 
			string channel_name_to, 
			string customer_address, 
			string customer_phone, 
			string customer_fax, 
			string customer_npwp, 
			string customer_desc)
			: this()
		{
			_transaction_id = transaction_id;
			_gudang_id = 0;
			_currency_id = String.Empty;
			_transaction_reference_id = 0;
			_transaction_factur = String.Empty;
			_transaction_by = String.Empty;
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
			_gudang_id_to = 0;
			_location_id = String.Empty;
			_location_id_to = String.Empty;
			_channel_name = channel_name;
			_channel_name_to = channel_name_to;
			_transaction_detail_id = 0;
			_item_id = String.Empty;
			_quantity = 0;
			_price = 0;
			_jumlah = 0;
			_disc = 0;
			_ppn = 0;
			_total = 0;
			_description = String.Empty;
			_expired_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_commission = 0;
			_cost_price = 0;
			_is_packet = false;
			_stock_id = String.Empty;
			_item_name = String.Empty;
			_group_name = String.Empty;
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
			_stock_gudang_name = String.Empty;
			_stock_channel_name = String.Empty;
			_colour_desc = String.Empty;
			_finance_name = String.Empty;
			_customer_address = customer_address;
			_customer_phone = customer_phone;
			_customer_fax = customer_fax;
			_customer_npwp = customer_npwp;
			_customer_desc = customer_desc;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructVTotalTransactionDealer
        {

					internal decimal TransactionId;

					internal int GudangId;

					internal string CurrencyId;

					internal decimal TransactionReferenceId;

					internal string TransactionFactur;

					internal string TransactionBy;

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

					internal int GudangIdTo;

					internal string LocationId;

					internal string LocationIdTo;

					internal string ChannelName;

					internal string ChannelNameTo;

					internal decimal TransactionDetailId;

					internal string ItemId;

					internal decimal Quantity;

					internal decimal Price;

					internal decimal Jumlah;

					internal decimal Disc;

					internal decimal Ppn;

					internal decimal Total;

					internal string Description;

					internal DateTime ExpiredDate;

					internal decimal Commission;

					internal decimal CostPrice;

					internal bool IsPacket;

					internal string StockId;

					internal string ItemName;

					internal string GroupName;

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

					internal string StockGudangName;

					internal string StockChannelName;

					internal string ColourDesc;

					internal string FinanceName;

					internal string CustomerAddress;

					internal string CustomerPhone;

					internal string CustomerFax;

					internal string CustomerNpwp;

					internal string CustomerDesc;

        }

        StructVTotalTransactionDealer _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.TransactionId = this.TransactionId;	
				
				
					
					this._clone.GudangId = this.GudangId;	
				
				
					
					this._clone.CurrencyId = this.CurrencyId;	
				
				
					
					this._clone.TransactionReferenceId = this.TransactionReferenceId;	
				
				
					
					this._clone.TransactionFactur = this.TransactionFactur;	
				
				
					
					this._clone.TransactionBy = this.TransactionBy;	
				
				
					
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
				
				
					
					this._clone.GudangIdTo = this.GudangIdTo;	
				
				
					
					this._clone.LocationId = this.LocationId;	
				
				
					
					this._clone.LocationIdTo = this.LocationIdTo;	
				
				
					
					this._clone.ChannelName = this.ChannelName;	
				
				
					
					this._clone.ChannelNameTo = this.ChannelNameTo;	
				
				
					
					this._clone.TransactionDetailId = this.TransactionDetailId;	
				
				
					
					this._clone.ItemId = this.ItemId;	
				
				
					
					this._clone.Quantity = this.Quantity;	
				
				
					
					this._clone.Price = this.Price;	
				
				
					
					this._clone.Jumlah = this.Jumlah;	
				
				
					
					this._clone.Disc = this.Disc;	
				
				
					
					this._clone.Ppn = this.Ppn;	
				
				
					
					this._clone.Total = this.Total;	
				
				
					
					this._clone.Description = this.Description;	
				
				
					
					this._clone.ExpiredDate = this.ExpiredDate;	
				
				
					
					this._clone.Commission = this.Commission;	
				
				
					
					this._clone.CostPrice = this.CostPrice;	
				
				
					
					this._clone.IsPacket = this.IsPacket;	
				
				
					
					this._clone.StockId = this.StockId;	
				
				
					
					this._clone.ItemName = this.ItemName;	
				
				
					
					this._clone.GroupName = this.GroupName;	
				
				
					
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
				
				
					
					this._clone.StockGudangName = this.StockGudangName;	
				
				
					
					this._clone.StockChannelName = this.StockChannelName;	
				
				
					
					this._clone.ColourDesc = this.ColourDesc;	
				
				
					
					this._clone.FinanceName = this.FinanceName;	
				
				
					
					this._clone.CustomerAddress = this.CustomerAddress;	
				
				
					
					this._clone.CustomerPhone = this.CustomerPhone;	
				
				
					
					this._clone.CustomerFax = this.CustomerFax;	
				
				
					
					this._clone.CustomerNpwp = this.CustomerNpwp;	
				
				
					
					this._clone.CustomerDesc = this.CustomerDesc;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.TransactionId = this._clone.TransactionId;	
				
				
					
					this.GudangId = this._clone.GudangId;	
				
				
					
					this.CurrencyId = this._clone.CurrencyId;	
				
				
					
					this.TransactionReferenceId = this._clone.TransactionReferenceId;	
				
				
					
					this.TransactionFactur = this._clone.TransactionFactur;	
				
				
					
					this.TransactionBy = this._clone.TransactionBy;	
				
				
					
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
				
				
					
					this.GudangIdTo = this._clone.GudangIdTo;	
				
				
					
					this.LocationId = this._clone.LocationId;	
				
				
					
					this.LocationIdTo = this._clone.LocationIdTo;	
				
				
					
					this.ChannelName = this._clone.ChannelName;	
				
				
					
					this.ChannelNameTo = this._clone.ChannelNameTo;	
				
				
					
					this.TransactionDetailId = this._clone.TransactionDetailId;	
				
				
					
					this.ItemId = this._clone.ItemId;	
				
				
					
					this.Quantity = this._clone.Quantity;	
				
				
					
					this.Price = this._clone.Price;	
				
				
					
					this.Jumlah = this._clone.Jumlah;	
				
				
					
					this.Disc = this._clone.Disc;	
				
				
					
					this.Ppn = this._clone.Ppn;	
				
				
					
					this.Total = this._clone.Total;	
				
				
					
					this.Description = this._clone.Description;	
				
				
					
					this.ExpiredDate = this._clone.ExpiredDate;	
				
				
					
					this.Commission = this._clone.Commission;	
				
				
					
					this.CostPrice = this._clone.CostPrice;	
				
				
					
					this.IsPacket = this._clone.IsPacket;	
				
				
					
					this.StockId = this._clone.StockId;	
				
				
					
					this.ItemName = this._clone.ItemName;	
				
				
					
					this.GroupName = this._clone.GroupName;	
				
				
					
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
				
				
					
					this.StockGudangName = this._clone.StockGudangName;	
				
				
					
					this.StockChannelName = this._clone.StockChannelName;	
				
				
					
					this.ColourDesc = this._clone.ColourDesc;	
				
				
					
					this.FinanceName = this._clone.FinanceName;	
				
				
					
					this.CustomerAddress = this._clone.CustomerAddress;	
				
				
					
					this.CustomerPhone = this._clone.CustomerPhone;	
				
				
					
					this.CustomerFax = this._clone.CustomerFax;	
				
				
					
					this.CustomerNpwp = this._clone.CustomerNpwp;	
				
				
					
					this.CustomerDesc = this._clone.CustomerDesc;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructVTotalTransactionDealer();
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
			
		public virtual string ChannelNameTo
		{
			get
			{ 
				return _channel_name_to;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for ChannelNameTo", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelNameTo", value, value.ToString());
				
				_channel_name_to = value;
			}
		}
			
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
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for GroupName", value, value.ToString());
				
				_group_name = value;
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
			
		public virtual string StockGudangName
		{
			get
			{ 
				return _stock_gudang_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for StockGudangName", value, value.ToString());
				
				_stock_gudang_name = value;
			}
		}
			
		public virtual string StockChannelName
		{
			get
			{ 
				return _stock_channel_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for StockChannelName", value, value.ToString());
				
				_stock_channel_name = value;
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
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ColourDesc", value, value.ToString());
				
				_colour_desc = value;
			}
		}
			
		public virtual string FinanceName
		{
			get
			{ 
				return _finance_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for FinanceName", value, value.ToString());
				
				_finance_name = value;
			}
		}
			
		public virtual string CustomerAddress
		{
			get
			{ 
				return _customer_address;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for CustomerAddress", value, "null");
				
				if(  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerAddress", value, value.ToString());
				
				_customer_address = value;
			}
		}
			
		public virtual string CustomerPhone
		{
			get
			{ 
				return _customer_phone;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for CustomerPhone", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerPhone", value, value.ToString());
				
				_customer_phone = value;
			}
		}
			
		public virtual string CustomerFax
		{
			get
			{ 
				return _customer_fax;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for CustomerFax", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerFax", value, value.ToString());
				
				_customer_fax = value;
			}
		}
			
		public virtual string CustomerNpwp
		{
			get
			{ 
				return _customer_npwp;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for CustomerNpwp", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerNpwp", value, value.ToString());
				
				_customer_npwp = value;
			}
		}
			
		public virtual string CustomerDesc
		{
			get
			{ 
				return _customer_desc;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for CustomerDesc", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CustomerDesc", value, value.ToString());
				
				_customer_desc = value;
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
			VTotalTransactionDealer castObj = (VTotalTransactionDealer)obj; 
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

		public bool Equals(VTotalTransactionDealer other)
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
		
			sb.Append(_transaction_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_gudang_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_currency_id.ToString()); 
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
			sb.Append("|");						
						
			sb.Append(_gudang_id_to.ToString()); 
			sb.Append("|");						
						
			sb.Append(_location_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_location_id_to.ToString()); 
			sb.Append("|");						
						
			sb.Append(_channel_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_channel_name_to.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_detail_id.ToString()); 
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
						
			sb.Append(_stock_gudang_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_stock_channel_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_colour_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_finance_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_address.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_phone.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_fax.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_npwp.ToString()); 
			sb.Append("|");						
						
			sb.Append(_customer_desc.ToString()); 
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string TransactionId = "TransactionId";
				
				public const string GudangId = "GudangId";
				
				public const string CurrencyId = "CurrencyId";
				
				public const string TransactionReferenceId = "TransactionReferenceId";
				
				public const string TransactionFactur = "TransactionFactur";
				
				public const string TransactionBy = "TransactionBy";
				
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
				
				public const string GudangIdTo = "GudangIdTo";
				
				public const string LocationId = "LocationId";
				
				public const string LocationIdTo = "LocationIdTo";
				
				public const string ChannelName = "ChannelName";
				
				public const string ChannelNameTo = "ChannelNameTo";
				
				public const string TransactionDetailId = "TransactionDetailId";
				
				public const string ItemId = "ItemId";
				
				public const string Quantity = "Quantity";
				
				public const string Price = "Price";
				
				public const string Jumlah = "Jumlah";
				
				public const string Disc = "Disc";
				
				public const string Ppn = "Ppn";
				
				public const string Total = "Total";
				
				public const string Description = "Description";
				
				public const string ExpiredDate = "ExpiredDate";
				
				public const string Commission = "Commission";
				
				public const string CostPrice = "CostPrice";
				
				public const string IsPacket = "IsPacket";
				
				public const string StockId = "StockId";
				
				public const string ItemName = "ItemName";
				
				public const string GroupName = "GroupName";
				
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
				
				public const string StockGudangName = "StockGudangName";
				
				public const string StockChannelName = "StockChannelName";
				
				public const string ColourDesc = "ColourDesc";
				
				public const string FinanceName = "FinanceName";
				
				public const string CustomerAddress = "CustomerAddress";
				
				public const string CustomerPhone = "CustomerPhone";
				
				public const string CustomerFax = "CustomerFax";
				
				public const string CustomerNpwp = "CustomerNpwp";
				
				public const string CustomerDesc = "CustomerDesc";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
