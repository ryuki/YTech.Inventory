using System;
using System.Collections.Generic;


namespace Inventori.Contractor.Data
{
	[Serializable]
	public class TContractorSetting: IEquatable<TContractorSetting>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _setting_id; 
		private string _giro_delete_pin; 
		private string _po_delete_pin; 
		private byte[] _logo_image; 
		private string _company_name_font; 
		private string _company_name_colour; 
		private int _company_name_font_height; 		
		#endregion

		#region Constructor

		public TContractorSetting()
		{
			_setting_id = String.Empty; 
			_giro_delete_pin = String.Empty; 
			_po_delete_pin = String.Empty; 
			_logo_image = new byte[]{}; 
			_company_name_font = String.Empty; 
			_company_name_colour = String.Empty; 
			_company_name_font_height = 0; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TContractorSetting(
			string setting_id)
			: this()
		{
			_setting_id = setting_id;
			_giro_delete_pin = String.Empty;
			_po_delete_pin = String.Empty;
			_logo_image = null;
			_company_name_font = String.Empty;
			_company_name_colour = String.Empty;
			_company_name_font_height = 0;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTContractorSetting
        {

					internal string SettingId;

					internal string GiroDeletePin;

					internal string PoDeletePin;

					internal byte[] LogoImage;

					internal string CompanyNameFont;

					internal string CompanyNameColour;

					internal int CompanyNameFontHeight;

        }

        StructTContractorSetting _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.SettingId = this.SettingId;	
				
				
					
					this._clone.GiroDeletePin = this.GiroDeletePin;	
				
				
					
					this._clone.PoDeletePin = this.PoDeletePin;	
				
				
					
					this._clone.LogoImage = this.LogoImage;	
				
				
					
					this._clone.CompanyNameFont = this.CompanyNameFont;	
				
				
					
					this._clone.CompanyNameColour = this.CompanyNameColour;	
				
				
					
					this._clone.CompanyNameFontHeight = this.CompanyNameFontHeight;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.SettingId = this._clone.SettingId;	
				
				
					
					this.GiroDeletePin = this._clone.GiroDeletePin;	
				
				
					
					this.PoDeletePin = this._clone.PoDeletePin;	
				
				
					
					this.LogoImage = this._clone.LogoImage;	
				
				
					
					this.CompanyNameFont = this._clone.CompanyNameFont;	
				
				
					
					this.CompanyNameColour = this._clone.CompanyNameColour;	
				
				
					
					this.CompanyNameFontHeight = this._clone.CompanyNameFontHeight;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTContractorSetting();
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
			
		public virtual string GiroDeletePin
		{
			get
			{ 
				return _giro_delete_pin;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for GiroDeletePin", value, value.ToString());
				
				_giro_delete_pin = value;
			}
		}
			
		public virtual string PoDeletePin
		{
			get
			{ 
				return _po_delete_pin;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for PoDeletePin", value, value.ToString());
				
				_po_delete_pin = value;
			}
		}
			
		public virtual byte[] LogoImage
		{
			get
			{ 
				return _logo_image;
			}
			set
			{
				_logo_image = value;
			}

		}
			
		public virtual string CompanyNameFont
		{
			get
			{ 
				return _company_name_font;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CompanyNameFont", value, value.ToString());
				
				_company_name_font = value;
			}
		}
			
		public virtual string CompanyNameColour
		{
			get
			{ 
				return _company_name_colour;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CompanyNameColour", value, value.ToString());
				
				_company_name_colour = value;
			}
		}
			
		public virtual int CompanyNameFontHeight
		{
			get
			{ 
				return _company_name_font_height;
			}
			set
			{
				_company_name_font_height = value;
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
			TContractorSetting castObj = (TContractorSetting)obj; 
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

		public bool Equals(TContractorSetting other)
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
						
			sb.Append(_giro_delete_pin.ToString()); 
			sb.Append("|");						
						
			sb.Append(_po_delete_pin.ToString()); 
			sb.Append("|");						
						
			sb.Append(_logo_image.ToString()); 
			sb.Append("|");						
						
			sb.Append(_company_name_font.ToString()); 
			sb.Append("|");						
						
			sb.Append(_company_name_colour.ToString()); 
			sb.Append("|");						
						
			sb.Append(_company_name_font_height.ToString()); 
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string SettingId = "SettingId";
				
				public const string GiroDeletePin = "GiroDeletePin";
				
				public const string PoDeletePin = "PoDeletePin";
				
				public const string LogoImage = "LogoImage";
				
				public const string CompanyNameFont = "CompanyNameFont";
				
				public const string CompanyNameColour = "CompanyNameColour";
				
				public const string CompanyNameFontHeight = "CompanyNameFontHeight";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
