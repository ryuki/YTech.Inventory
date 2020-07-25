using System;
using System.Collections.Generic;


namespace Inventori.GrosirMitra.Data
{
	[Serializable]
	public class TGrosirSetting: IEquatable<TGrosirSetting>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _setting_id; 
		private int _default_piutang_credit_long; 
		private string _discount_pin; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TGrosirSetting()
		{
			_setting_id = String.Empty; 
			_default_piutang_credit_long = 0; 
			_discount_pin = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TGrosirSetting(
			string setting_id)
			: this()
		{
			_setting_id = setting_id;
			_default_piutang_credit_long = 0;
			_discount_pin = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTGrosirSetting
        {

					internal string SettingId;

					internal int DefaultPiutangCreditLong;

					internal string DiscountPin;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTGrosirSetting _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.SettingId = this.SettingId;	
				
				
					
					this._clone.DefaultPiutangCreditLong = this.DefaultPiutangCreditLong;	
				
				
					
					this._clone.DiscountPin = this.DiscountPin;	
				
				
					
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
				
				
					
					this.DefaultPiutangCreditLong = this._clone.DefaultPiutangCreditLong;	
				
				
					
					this.DiscountPin = this._clone.DiscountPin;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTGrosirSetting();
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
			
		public virtual int DefaultPiutangCreditLong
		{
			get
			{ 
				return _default_piutang_credit_long;
			}
			set
			{
				_default_piutang_credit_long = value;
			}

		}
			
		public virtual string DiscountPin
		{
			get
			{ 
				return _discount_pin;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DiscountPin", value, value.ToString());
				
				_discount_pin = value;
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
			TGrosirSetting castObj = (TGrosirSetting)obj; 
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

		public bool Equals(TGrosirSetting other)
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
						
			sb.Append(_default_piutang_credit_long.ToString()); 
			sb.Append("|");						
						
			sb.Append(_discount_pin.ToString()); 
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
				
				public const string DefaultPiutangCreditLong = "DefaultPiutangCreditLong";
				
				public const string DiscountPin = "DiscountPin";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
