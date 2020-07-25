using System;
using System.Collections.Generic;


namespace Inventori.Billiard.Data
{
	[Serializable]
	public class TBilliardSetting: IEquatable<TBilliardSetting>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _setting_id; 
		private int _biliard_item_hour_from1; 
		private int _biliard_item_hour_to1; 
		private decimal _biliard_item_price; 
		private decimal _biliard_item_price_vip; 
		private decimal _biliard_item_price_mini; 
		private int _biliard_item_hour_from2; 
		private int _biliard_item_hour_to2; 
		private decimal _biliard_item_price2; 
		private decimal _biliard_item_price_vip2; 
		private decimal _biliard_item_price_mini2; 
		private int _biliard_item_hour_from3; 
		private int _biliard_item_hour_to3; 
		private decimal _biliard_item_price3; 
		private decimal _biliard_item_price_vip3; 
		private decimal _biliard_item_price_mini3; 
		private bool _use_referee; 
		private decimal _calculate_time; 
		private decimal _tolerance_time; 
		private decimal _quit_timeout; 
		private decimal _minimum_play; 
		private decimal _fullfill_price; 
		private decimal _referee_bonus; 
		private int _back_color; 
		private int _desk_back_color; 
		private string _desk_font_name; 
		private decimal _desk_font_size; 
		private bool _desk_font_bold; 
		private bool _desk_font_italic; 
		private bool _desk_font_underline; 
		private int _desk_font_color; 
		private int _desk_width; 
		private int _desk_height; 
		private int _desk_back_color1; 
		private string _desk_font_name1; 
		private decimal _desk_font_size1; 
		private bool _desk_font_bold1; 
		private bool _desk_font_italic1; 
		private bool _desk_font_underline1; 
		private int _desk_font_color1; 
		private int _desk_width1; 
		private int _desk_height1; 
		private int _desk_back_color2; 
		private string _desk_font_name2; 
		private decimal _desk_font_size2; 
		private bool _desk_font_bold2; 
		private bool _desk_font_italic2; 
		private bool _desk_font_underline2; 
		private int _desk_font_color2; 
		private int _desk_width2; 
		private int _desk_height2; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TBilliardSetting()
		{
			_setting_id = String.Empty; 
			_biliard_item_hour_from1 = 0; 
			_biliard_item_hour_to1 = 0; 
			_biliard_item_price = 0; 
			_biliard_item_price_vip = 0; 
			_biliard_item_price_mini = 0; 
			_biliard_item_hour_from2 = 0; 
			_biliard_item_hour_to2 = 0; 
			_biliard_item_price2 = 0; 
			_biliard_item_price_vip2 = 0; 
			_biliard_item_price_mini2 = 0; 
			_biliard_item_hour_from3 = 0; 
			_biliard_item_hour_to3 = 0; 
			_biliard_item_price3 = 0; 
			_biliard_item_price_vip3 = 0; 
			_biliard_item_price_mini3 = 0; 
			_use_referee = false; 
			_calculate_time = 0; 
			_tolerance_time = 0; 
			_quit_timeout = 0; 
			_minimum_play = 0; 
			_fullfill_price = 0; 
			_referee_bonus = 0; 
			_back_color = 0; 
			_desk_back_color = 0; 
			_desk_font_name = String.Empty; 
			_desk_font_size = 0; 
			_desk_font_bold = false; 
			_desk_font_italic = false; 
			_desk_font_underline = false; 
			_desk_font_color = 0; 
			_desk_width = 0; 
			_desk_height = 0; 
			_desk_back_color1 = 0; 
			_desk_font_name1 = String.Empty; 
			_desk_font_size1 = 0; 
			_desk_font_bold1 = false; 
			_desk_font_italic1 = false; 
			_desk_font_underline1 = false; 
			_desk_font_color1 = 0; 
			_desk_width1 = 0; 
			_desk_height1 = 0; 
			_desk_back_color2 = 0; 
			_desk_font_name2 = String.Empty; 
			_desk_font_size2 = 0; 
			_desk_font_bold2 = false; 
			_desk_font_italic2 = false; 
			_desk_font_underline2 = false; 
			_desk_font_color2 = 0; 
			_desk_width2 = 0; 
			_desk_height2 = 0; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TBilliardSetting(
			string setting_id)
			: this()
		{
			_setting_id = setting_id;
			_biliard_item_hour_from1 = 0;
			_biliard_item_hour_to1 = 0;
			_biliard_item_price = 0;
			_biliard_item_price_vip = 0;
			_biliard_item_price_mini = 0;
			_biliard_item_hour_from2 = 0;
			_biliard_item_hour_to2 = 0;
			_biliard_item_price2 = 0;
			_biliard_item_price_vip2 = 0;
			_biliard_item_price_mini2 = 0;
			_biliard_item_hour_from3 = 0;
			_biliard_item_hour_to3 = 0;
			_biliard_item_price3 = 0;
			_biliard_item_price_vip3 = 0;
			_biliard_item_price_mini3 = 0;
			_use_referee = false;
			_calculate_time = 0;
			_tolerance_time = 0;
			_quit_timeout = 0;
			_minimum_play = 0;
			_fullfill_price = 0;
			_referee_bonus = 0;
			_back_color = 0;
			_desk_back_color = 0;
			_desk_font_name = String.Empty;
			_desk_font_size = 0;
			_desk_font_bold = false;
			_desk_font_italic = false;
			_desk_font_underline = false;
			_desk_font_color = 0;
			_desk_width = 0;
			_desk_height = 0;
			_desk_back_color1 = 0;
			_desk_font_name1 = String.Empty;
			_desk_font_size1 = 0;
			_desk_font_bold1 = false;
			_desk_font_italic1 = false;
			_desk_font_underline1 = false;
			_desk_font_color1 = 0;
			_desk_width1 = 0;
			_desk_height1 = 0;
			_desk_back_color2 = 0;
			_desk_font_name2 = String.Empty;
			_desk_font_size2 = 0;
			_desk_font_bold2 = false;
			_desk_font_italic2 = false;
			_desk_font_underline2 = false;
			_desk_font_color2 = 0;
			_desk_width2 = 0;
			_desk_height2 = 0;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTBilliardSetting
        {

					internal string SettingId;

					internal int BiliardItemHourFrom1;

					internal int BiliardItemHourTo1;

					internal decimal BiliardItemPrice;

					internal decimal BiliardItemPriceVip;

					internal decimal BiliardItemPriceMini;

					internal int BiliardItemHourFrom2;

					internal int BiliardItemHourTo2;

					internal decimal BiliardItemPrice2;

					internal decimal BiliardItemPriceVip2;

					internal decimal BiliardItemPriceMini2;

					internal int BiliardItemHourFrom3;

					internal int BiliardItemHourTo3;

					internal decimal BiliardItemPrice3;

					internal decimal BiliardItemPriceVip3;

					internal decimal BiliardItemPriceMini3;

					internal bool UseReferee;

					internal decimal CalculateTime;

					internal decimal ToleranceTime;

					internal decimal QuitTimeout;

					internal decimal MinimumPlay;

					internal decimal FullfillPrice;

					internal decimal RefereeBonus;

					internal int BackColor;

					internal int DeskBackColor;

					internal string DeskFontName;

					internal decimal DeskFontSize;

					internal bool DeskFontBold;

					internal bool DeskFontItalic;

					internal bool DeskFontUnderline;

					internal int DeskFontColor;

					internal int DeskWidth;

					internal int DeskHeight;

					internal int DeskBackColor1;

					internal string DeskFontName1;

					internal decimal DeskFontSize1;

					internal bool DeskFontBold1;

					internal bool DeskFontItalic1;

					internal bool DeskFontUnderline1;

					internal int DeskFontColor1;

					internal int DeskWidth1;

					internal int DeskHeight1;

					internal int DeskBackColor2;

					internal string DeskFontName2;

					internal decimal DeskFontSize2;

					internal bool DeskFontBold2;

					internal bool DeskFontItalic2;

					internal bool DeskFontUnderline2;

					internal int DeskFontColor2;

					internal int DeskWidth2;

					internal int DeskHeight2;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTBilliardSetting _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.SettingId = this.SettingId;	
				
				
					
					this._clone.BiliardItemHourFrom1 = this.BiliardItemHourFrom1;	
				
				
					
					this._clone.BiliardItemHourTo1 = this.BiliardItemHourTo1;	
				
				
					
					this._clone.BiliardItemPrice = this.BiliardItemPrice;	
				
				
					
					this._clone.BiliardItemPriceVip = this.BiliardItemPriceVip;	
				
				
					
					this._clone.BiliardItemPriceMini = this.BiliardItemPriceMini;	
				
				
					
					this._clone.BiliardItemHourFrom2 = this.BiliardItemHourFrom2;	
				
				
					
					this._clone.BiliardItemHourTo2 = this.BiliardItemHourTo2;	
				
				
					
					this._clone.BiliardItemPrice2 = this.BiliardItemPrice2;	
				
				
					
					this._clone.BiliardItemPriceVip2 = this.BiliardItemPriceVip2;	
				
				
					
					this._clone.BiliardItemPriceMini2 = this.BiliardItemPriceMini2;	
				
				
					
					this._clone.BiliardItemHourFrom3 = this.BiliardItemHourFrom3;	
				
				
					
					this._clone.BiliardItemHourTo3 = this.BiliardItemHourTo3;	
				
				
					
					this._clone.BiliardItemPrice3 = this.BiliardItemPrice3;	
				
				
					
					this._clone.BiliardItemPriceVip3 = this.BiliardItemPriceVip3;	
				
				
					
					this._clone.BiliardItemPriceMini3 = this.BiliardItemPriceMini3;	
				
				
					
					this._clone.UseReferee = this.UseReferee;	
				
				
					
					this._clone.CalculateTime = this.CalculateTime;	
				
				
					
					this._clone.ToleranceTime = this.ToleranceTime;	
				
				
					
					this._clone.QuitTimeout = this.QuitTimeout;	
				
				
					
					this._clone.MinimumPlay = this.MinimumPlay;	
				
				
					
					this._clone.FullfillPrice = this.FullfillPrice;	
				
				
					
					this._clone.RefereeBonus = this.RefereeBonus;	
				
				
					
					this._clone.BackColor = this.BackColor;	
				
				
					
					this._clone.DeskBackColor = this.DeskBackColor;	
				
				
					
					this._clone.DeskFontName = this.DeskFontName;	
				
				
					
					this._clone.DeskFontSize = this.DeskFontSize;	
				
				
					
					this._clone.DeskFontBold = this.DeskFontBold;	
				
				
					
					this._clone.DeskFontItalic = this.DeskFontItalic;	
				
				
					
					this._clone.DeskFontUnderline = this.DeskFontUnderline;	
				
				
					
					this._clone.DeskFontColor = this.DeskFontColor;	
				
				
					
					this._clone.DeskWidth = this.DeskWidth;	
				
				
					
					this._clone.DeskHeight = this.DeskHeight;	
				
				
					
					this._clone.DeskBackColor1 = this.DeskBackColor1;	
				
				
					
					this._clone.DeskFontName1 = this.DeskFontName1;	
				
				
					
					this._clone.DeskFontSize1 = this.DeskFontSize1;	
				
				
					
					this._clone.DeskFontBold1 = this.DeskFontBold1;	
				
				
					
					this._clone.DeskFontItalic1 = this.DeskFontItalic1;	
				
				
					
					this._clone.DeskFontUnderline1 = this.DeskFontUnderline1;	
				
				
					
					this._clone.DeskFontColor1 = this.DeskFontColor1;	
				
				
					
					this._clone.DeskWidth1 = this.DeskWidth1;	
				
				
					
					this._clone.DeskHeight1 = this.DeskHeight1;	
				
				
					
					this._clone.DeskBackColor2 = this.DeskBackColor2;	
				
				
					
					this._clone.DeskFontName2 = this.DeskFontName2;	
				
				
					
					this._clone.DeskFontSize2 = this.DeskFontSize2;	
				
				
					
					this._clone.DeskFontBold2 = this.DeskFontBold2;	
				
				
					
					this._clone.DeskFontItalic2 = this.DeskFontItalic2;	
				
				
					
					this._clone.DeskFontUnderline2 = this.DeskFontUnderline2;	
				
				
					
					this._clone.DeskFontColor2 = this.DeskFontColor2;	
				
				
					
					this._clone.DeskWidth2 = this.DeskWidth2;	
				
				
					
					this._clone.DeskHeight2 = this.DeskHeight2;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.SettingId = this._clone.SettingId;	
				
				
					
					this.BiliardItemHourFrom1 = this._clone.BiliardItemHourFrom1;	
				
				
					
					this.BiliardItemHourTo1 = this._clone.BiliardItemHourTo1;	
				
				
					
					this.BiliardItemPrice = this._clone.BiliardItemPrice;	
				
				
					
					this.BiliardItemPriceVip = this._clone.BiliardItemPriceVip;	
				
				
					
					this.BiliardItemPriceMini = this._clone.BiliardItemPriceMini;	
				
				
					
					this.BiliardItemHourFrom2 = this._clone.BiliardItemHourFrom2;	
				
				
					
					this.BiliardItemHourTo2 = this._clone.BiliardItemHourTo2;	
				
				
					
					this.BiliardItemPrice2 = this._clone.BiliardItemPrice2;	
				
				
					
					this.BiliardItemPriceVip2 = this._clone.BiliardItemPriceVip2;	
				
				
					
					this.BiliardItemPriceMini2 = this._clone.BiliardItemPriceMini2;	
				
				
					
					this.BiliardItemHourFrom3 = this._clone.BiliardItemHourFrom3;	
				
				
					
					this.BiliardItemHourTo3 = this._clone.BiliardItemHourTo3;	
				
				
					
					this.BiliardItemPrice3 = this._clone.BiliardItemPrice3;	
				
				
					
					this.BiliardItemPriceVip3 = this._clone.BiliardItemPriceVip3;	
				
				
					
					this.BiliardItemPriceMini3 = this._clone.BiliardItemPriceMini3;	
				
				
					
					this.UseReferee = this._clone.UseReferee;	
				
				
					
					this.CalculateTime = this._clone.CalculateTime;	
				
				
					
					this.ToleranceTime = this._clone.ToleranceTime;	
				
				
					
					this.QuitTimeout = this._clone.QuitTimeout;	
				
				
					
					this.MinimumPlay = this._clone.MinimumPlay;	
				
				
					
					this.FullfillPrice = this._clone.FullfillPrice;	
				
				
					
					this.RefereeBonus = this._clone.RefereeBonus;	
				
				
					
					this.BackColor = this._clone.BackColor;	
				
				
					
					this.DeskBackColor = this._clone.DeskBackColor;	
				
				
					
					this.DeskFontName = this._clone.DeskFontName;	
				
				
					
					this.DeskFontSize = this._clone.DeskFontSize;	
				
				
					
					this.DeskFontBold = this._clone.DeskFontBold;	
				
				
					
					this.DeskFontItalic = this._clone.DeskFontItalic;	
				
				
					
					this.DeskFontUnderline = this._clone.DeskFontUnderline;	
				
				
					
					this.DeskFontColor = this._clone.DeskFontColor;	
				
				
					
					this.DeskWidth = this._clone.DeskWidth;	
				
				
					
					this.DeskHeight = this._clone.DeskHeight;	
				
				
					
					this.DeskBackColor1 = this._clone.DeskBackColor1;	
				
				
					
					this.DeskFontName1 = this._clone.DeskFontName1;	
				
				
					
					this.DeskFontSize1 = this._clone.DeskFontSize1;	
				
				
					
					this.DeskFontBold1 = this._clone.DeskFontBold1;	
				
				
					
					this.DeskFontItalic1 = this._clone.DeskFontItalic1;	
				
				
					
					this.DeskFontUnderline1 = this._clone.DeskFontUnderline1;	
				
				
					
					this.DeskFontColor1 = this._clone.DeskFontColor1;	
				
				
					
					this.DeskWidth1 = this._clone.DeskWidth1;	
				
				
					
					this.DeskHeight1 = this._clone.DeskHeight1;	
				
				
					
					this.DeskBackColor2 = this._clone.DeskBackColor2;	
				
				
					
					this.DeskFontName2 = this._clone.DeskFontName2;	
				
				
					
					this.DeskFontSize2 = this._clone.DeskFontSize2;	
				
				
					
					this.DeskFontBold2 = this._clone.DeskFontBold2;	
				
				
					
					this.DeskFontItalic2 = this._clone.DeskFontItalic2;	
				
				
					
					this.DeskFontUnderline2 = this._clone.DeskFontUnderline2;	
				
				
					
					this.DeskFontColor2 = this._clone.DeskFontColor2;	
				
				
					
					this.DeskWidth2 = this._clone.DeskWidth2;	
				
				
					
					this.DeskHeight2 = this._clone.DeskHeight2;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTBilliardSetting();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string SettingId
		{
			get
			{ 
				return _setting_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for SettingId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SettingId", value, value.ToString());
				
				_setting_id = value;
			}
		}
			
		public virtual int BiliardItemHourFrom1
		{
			get
			{ 
				return _biliard_item_hour_from1;
			}
			set
			{
				_biliard_item_hour_from1 = value;
			}

		}
			
		public virtual int BiliardItemHourTo1
		{
			get
			{ 
				return _biliard_item_hour_to1;
			}
			set
			{
				_biliard_item_hour_to1 = value;
			}

		}
			
		public virtual decimal BiliardItemPrice
		{
			get
			{ 
				return _biliard_item_price;
			}
			set
			{
				_biliard_item_price = value;
			}

		}
			
		public virtual decimal BiliardItemPriceVip
		{
			get
			{ 
				return _biliard_item_price_vip;
			}
			set
			{
				_biliard_item_price_vip = value;
			}

		}
			
		public virtual decimal BiliardItemPriceMini
		{
			get
			{ 
				return _biliard_item_price_mini;
			}
			set
			{
				_biliard_item_price_mini = value;
			}

		}
			
		public virtual int BiliardItemHourFrom2
		{
			get
			{ 
				return _biliard_item_hour_from2;
			}
			set
			{
				_biliard_item_hour_from2 = value;
			}

		}
			
		public virtual int BiliardItemHourTo2
		{
			get
			{ 
				return _biliard_item_hour_to2;
			}
			set
			{
				_biliard_item_hour_to2 = value;
			}

		}
			
		public virtual decimal BiliardItemPrice2
		{
			get
			{ 
				return _biliard_item_price2;
			}
			set
			{
				_biliard_item_price2 = value;
			}

		}
			
		public virtual decimal BiliardItemPriceVip2
		{
			get
			{ 
				return _biliard_item_price_vip2;
			}
			set
			{
				_biliard_item_price_vip2 = value;
			}

		}
			
		public virtual decimal BiliardItemPriceMini2
		{
			get
			{ 
				return _biliard_item_price_mini2;
			}
			set
			{
				_biliard_item_price_mini2 = value;
			}

		}
			
		public virtual int BiliardItemHourFrom3
		{
			get
			{ 
				return _biliard_item_hour_from3;
			}
			set
			{
				_biliard_item_hour_from3 = value;
			}

		}
			
		public virtual int BiliardItemHourTo3
		{
			get
			{ 
				return _biliard_item_hour_to3;
			}
			set
			{
				_biliard_item_hour_to3 = value;
			}

		}
			
		public virtual decimal BiliardItemPrice3
		{
			get
			{ 
				return _biliard_item_price3;
			}
			set
			{
				_biliard_item_price3 = value;
			}

		}
			
		public virtual decimal BiliardItemPriceVip3
		{
			get
			{ 
				return _biliard_item_price_vip3;
			}
			set
			{
				_biliard_item_price_vip3 = value;
			}

		}
			
		public virtual decimal BiliardItemPriceMini3
		{
			get
			{ 
				return _biliard_item_price_mini3;
			}
			set
			{
				_biliard_item_price_mini3 = value;
			}

		}
			
		public virtual bool UseReferee
		{
			get
			{ 
				return _use_referee;
			}
			set
			{
				_use_referee = value;
			}

		}
			
		public virtual decimal CalculateTime
		{
			get
			{ 
				return _calculate_time;
			}
			set
			{
				_calculate_time = value;
			}

		}
			
		public virtual decimal ToleranceTime
		{
			get
			{ 
				return _tolerance_time;
			}
			set
			{
				_tolerance_time = value;
			}

		}
			
		public virtual decimal QuitTimeout
		{
			get
			{ 
				return _quit_timeout;
			}
			set
			{
				_quit_timeout = value;
			}

		}
			
		public virtual decimal MinimumPlay
		{
			get
			{ 
				return _minimum_play;
			}
			set
			{
				_minimum_play = value;
			}

		}
			
		public virtual decimal FullfillPrice
		{
			get
			{ 
				return _fullfill_price;
			}
			set
			{
				_fullfill_price = value;
			}

		}
			
		public virtual decimal RefereeBonus
		{
			get
			{ 
				return _referee_bonus;
			}
			set
			{
				_referee_bonus = value;
			}

		}
			
		public virtual int BackColor
		{
			get
			{ 
				return _back_color;
			}
			set
			{
				_back_color = value;
			}

		}
			
		public virtual int DeskBackColor
		{
			get
			{ 
				return _desk_back_color;
			}
			set
			{
				_desk_back_color = value;
			}

		}
			
		public virtual string DeskFontName
		{
			get
			{ 
				return _desk_font_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DeskFontName", value, value.ToString());
				
				_desk_font_name = value;
			}
		}
			
		public virtual decimal DeskFontSize
		{
			get
			{ 
				return _desk_font_size;
			}
			set
			{
				_desk_font_size = value;
			}

		}
			
		public virtual bool DeskFontBold
		{
			get
			{ 
				return _desk_font_bold;
			}
			set
			{
				_desk_font_bold = value;
			}

		}
			
		public virtual bool DeskFontItalic
		{
			get
			{ 
				return _desk_font_italic;
			}
			set
			{
				_desk_font_italic = value;
			}

		}
			
		public virtual bool DeskFontUnderline
		{
			get
			{ 
				return _desk_font_underline;
			}
			set
			{
				_desk_font_underline = value;
			}

		}
			
		public virtual int DeskFontColor
		{
			get
			{ 
				return _desk_font_color;
			}
			set
			{
				_desk_font_color = value;
			}

		}
			
		public virtual int DeskWidth
		{
			get
			{ 
				return _desk_width;
			}
			set
			{
				_desk_width = value;
			}

		}
			
		public virtual int DeskHeight
		{
			get
			{ 
				return _desk_height;
			}
			set
			{
				_desk_height = value;
			}

		}
			
		public virtual int DeskBackColor1
		{
			get
			{ 
				return _desk_back_color1;
			}
			set
			{
				_desk_back_color1 = value;
			}

		}
			
		public virtual string DeskFontName1
		{
			get
			{ 
				return _desk_font_name1;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DeskFontName1", value, value.ToString());
				
				_desk_font_name1 = value;
			}
		}
			
		public virtual decimal DeskFontSize1
		{
			get
			{ 
				return _desk_font_size1;
			}
			set
			{
				_desk_font_size1 = value;
			}

		}
			
		public virtual bool DeskFontBold1
		{
			get
			{ 
				return _desk_font_bold1;
			}
			set
			{
				_desk_font_bold1 = value;
			}

		}
			
		public virtual bool DeskFontItalic1
		{
			get
			{ 
				return _desk_font_italic1;
			}
			set
			{
				_desk_font_italic1 = value;
			}

		}
			
		public virtual bool DeskFontUnderline1
		{
			get
			{ 
				return _desk_font_underline1;
			}
			set
			{
				_desk_font_underline1 = value;
			}

		}
			
		public virtual int DeskFontColor1
		{
			get
			{ 
				return _desk_font_color1;
			}
			set
			{
				_desk_font_color1 = value;
			}

		}
			
		public virtual int DeskWidth1
		{
			get
			{ 
				return _desk_width1;
			}
			set
			{
				_desk_width1 = value;
			}

		}
			
		public virtual int DeskHeight1
		{
			get
			{ 
				return _desk_height1;
			}
			set
			{
				_desk_height1 = value;
			}

		}
			
		public virtual int DeskBackColor2
		{
			get
			{ 
				return _desk_back_color2;
			}
			set
			{
				_desk_back_color2 = value;
			}

		}
			
		public virtual string DeskFontName2
		{
			get
			{ 
				return _desk_font_name2;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DeskFontName2", value, value.ToString());
				
				_desk_font_name2 = value;
			}
		}
			
		public virtual decimal DeskFontSize2
		{
			get
			{ 
				return _desk_font_size2;
			}
			set
			{
				_desk_font_size2 = value;
			}

		}
			
		public virtual bool DeskFontBold2
		{
			get
			{ 
				return _desk_font_bold2;
			}
			set
			{
				_desk_font_bold2 = value;
			}

		}
			
		public virtual bool DeskFontItalic2
		{
			get
			{ 
				return _desk_font_italic2;
			}
			set
			{
				_desk_font_italic2 = value;
			}

		}
			
		public virtual bool DeskFontUnderline2
		{
			get
			{ 
				return _desk_font_underline2;
			}
			set
			{
				_desk_font_underline2 = value;
			}

		}
			
		public virtual int DeskFontColor2
		{
			get
			{ 
				return _desk_font_color2;
			}
			set
			{
				_desk_font_color2 = value;
			}

		}
			
		public virtual int DeskWidth2
		{
			get
			{ 
				return _desk_width2;
			}
			set
			{
				_desk_width2 = value;
			}

		}
			
		public virtual int DeskHeight2
		{
			get
			{ 
				return _desk_height2;
			}
			set
			{
				_desk_height2 = value;
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
			TBilliardSetting castObj = (TBilliardSetting)obj; 
			return ( castObj != null ) &&
				( this._setting_id == castObj.SettingId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _setting_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TBilliardSetting other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._setting_id == other.SettingId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_setting_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_biliard_item_hour_from1.ToString()); 
			sb.Append("|");						
						
			sb.Append(_biliard_item_hour_to1.ToString()); 
			sb.Append("|");						
						
			sb.Append(_biliard_item_price.ToString()); 
			sb.Append("|");						
						
			sb.Append(_biliard_item_price_vip.ToString()); 
			sb.Append("|");						
						
			sb.Append(_biliard_item_price_mini.ToString()); 
			sb.Append("|");						
						
			sb.Append(_biliard_item_hour_from2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_biliard_item_hour_to2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_biliard_item_price2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_biliard_item_price_vip2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_biliard_item_price_mini2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_biliard_item_hour_from3.ToString()); 
			sb.Append("|");						
						
			sb.Append(_biliard_item_hour_to3.ToString()); 
			sb.Append("|");						
						
			sb.Append(_biliard_item_price3.ToString()); 
			sb.Append("|");						
						
			sb.Append(_biliard_item_price_vip3.ToString()); 
			sb.Append("|");						
						
			sb.Append(_biliard_item_price_mini3.ToString()); 
			sb.Append("|");						
						
			sb.Append(_use_referee.ToString()); 
			sb.Append("|");						
						
			sb.Append(_calculate_time.ToString()); 
			sb.Append("|");						
						
			sb.Append(_tolerance_time.ToString()); 
			sb.Append("|");						
						
			sb.Append(_quit_timeout.ToString()); 
			sb.Append("|");						
						
			sb.Append(_minimum_play.ToString()); 
			sb.Append("|");						
						
			sb.Append(_fullfill_price.ToString()); 
			sb.Append("|");						
						
			sb.Append(_referee_bonus.ToString()); 
			sb.Append("|");						
						
			sb.Append(_back_color.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_back_color.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_size.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_bold.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_italic.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_underline.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_color.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_width.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_height.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_back_color1.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_name1.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_size1.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_bold1.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_italic1.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_underline1.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_color1.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_width1.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_height1.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_back_color2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_name2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_size2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_bold2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_italic2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_underline2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_font_color2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_width2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_desk_height2.ToString()); 
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
		
				public const string SettingId = "SettingId";
				
				public const string BiliardItemHourFrom1 = "BiliardItemHourFrom1";
				
				public const string BiliardItemHourTo1 = "BiliardItemHourTo1";
				
				public const string BiliardItemPrice = "BiliardItemPrice";
				
				public const string BiliardItemPriceVip = "BiliardItemPriceVip";
				
				public const string BiliardItemPriceMini = "BiliardItemPriceMini";
				
				public const string BiliardItemHourFrom2 = "BiliardItemHourFrom2";
				
				public const string BiliardItemHourTo2 = "BiliardItemHourTo2";
				
				public const string BiliardItemPrice2 = "BiliardItemPrice2";
				
				public const string BiliardItemPriceVip2 = "BiliardItemPriceVip2";
				
				public const string BiliardItemPriceMini2 = "BiliardItemPriceMini2";
				
				public const string BiliardItemHourFrom3 = "BiliardItemHourFrom3";
				
				public const string BiliardItemHourTo3 = "BiliardItemHourTo3";
				
				public const string BiliardItemPrice3 = "BiliardItemPrice3";
				
				public const string BiliardItemPriceVip3 = "BiliardItemPriceVip3";
				
				public const string BiliardItemPriceMini3 = "BiliardItemPriceMini3";
				
				public const string UseReferee = "UseReferee";
				
				public const string CalculateTime = "CalculateTime";
				
				public const string ToleranceTime = "ToleranceTime";
				
				public const string QuitTimeout = "QuitTimeout";
				
				public const string MinimumPlay = "MinimumPlay";
				
				public const string FullfillPrice = "FullfillPrice";
				
				public const string RefereeBonus = "RefereeBonus";
				
				public const string BackColor = "BackColor";
				
				public const string DeskBackColor = "DeskBackColor";
				
				public const string DeskFontName = "DeskFontName";
				
				public const string DeskFontSize = "DeskFontSize";
				
				public const string DeskFontBold = "DeskFontBold";
				
				public const string DeskFontItalic = "DeskFontItalic";
				
				public const string DeskFontUnderline = "DeskFontUnderline";
				
				public const string DeskFontColor = "DeskFontColor";
				
				public const string DeskWidth = "DeskWidth";
				
				public const string DeskHeight = "DeskHeight";
				
				public const string DeskBackColor1 = "DeskBackColor1";
				
				public const string DeskFontName1 = "DeskFontName1";
				
				public const string DeskFontSize1 = "DeskFontSize1";
				
				public const string DeskFontBold1 = "DeskFontBold1";
				
				public const string DeskFontItalic1 = "DeskFontItalic1";
				
				public const string DeskFontUnderline1 = "DeskFontUnderline1";
				
				public const string DeskFontColor1 = "DeskFontColor1";
				
				public const string DeskWidth1 = "DeskWidth1";
				
				public const string DeskHeight1 = "DeskHeight1";
				
				public const string DeskBackColor2 = "DeskBackColor2";
				
				public const string DeskFontName2 = "DeskFontName2";
				
				public const string DeskFontSize2 = "DeskFontSize2";
				
				public const string DeskFontBold2 = "DeskFontBold2";
				
				public const string DeskFontItalic2 = "DeskFontItalic2";
				
				public const string DeskFontUnderline2 = "DeskFontUnderline2";
				
				public const string DeskFontColor2 = "DeskFontColor2";
				
				public const string DeskWidth2 = "DeskWidth2";
				
				public const string DeskHeight2 = "DeskHeight2";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
