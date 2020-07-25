using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class TCafeSetting: IEquatable<TCafeSetting>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _setting_id; 
		private string _exported_dir; 
		private string _discount_password; 
		private string _telp_no_saran_kritik; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TCafeSetting()
		{
			_setting_id = String.Empty; 
			_exported_dir = String.Empty; 
			_discount_password = String.Empty; 
			_telp_no_saran_kritik = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TCafeSetting(
			string setting_id)
			: this()
		{
			_setting_id = setting_id;
			_exported_dir = String.Empty;
			_discount_password = String.Empty;
			_telp_no_saran_kritik = String.Empty;
			_modified_by = String.Empty;
			_modified_date = DateTime.MinValue;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTCafeSetting
        {

					internal string SettingId;

					internal string ExportedDir;

					internal string DiscountPassword;

					internal string TelpNoSaranKritik;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTCafeSetting _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.SettingId = this.SettingId;	
				
				
					
					this._clone.ExportedDir = this.ExportedDir;	
				
				
					
					this._clone.DiscountPassword = this.DiscountPassword;	
				
				
					
					this._clone.TelpNoSaranKritik = this.TelpNoSaranKritik;	
				
				
					
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
				
				
					
					this.ExportedDir = this._clone.ExportedDir;	
				
				
					
					this.DiscountPassword = this._clone.DiscountPassword;	
				
				
					
					this.TelpNoSaranKritik = this._clone.TelpNoSaranKritik;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTCafeSetting();
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
			
		public virtual string ExportedDir
		{
			get
			{ 
				return _exported_dir;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ExportedDir", value, value.ToString());
				
				_exported_dir = value;
			}
		}
			
		public virtual string DiscountPassword
		{
			get
			{ 
				return _discount_password;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for DiscountPassword", value, value.ToString());
				
				_discount_password = value;
			}
		}
			
		public virtual string TelpNoSaranKritik
		{
			get
			{ 
				return _telp_no_saran_kritik;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TelpNoSaranKritik", value, value.ToString());
				
				_telp_no_saran_kritik = value;
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
			TCafeSetting castObj = (TCafeSetting)obj; 
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

		public bool Equals(TCafeSetting other)
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
						
			sb.Append(_exported_dir.ToString()); 
			sb.Append("|");						
						
			sb.Append(_discount_password.ToString()); 
			sb.Append("|");						
						
			sb.Append(_telp_no_saran_kritik.ToString()); 
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
				
				public const string ExportedDir = "ExportedDir";
				
				public const string DiscountPassword = "DiscountPassword";
				
				public const string TelpNoSaranKritik = "TelpNoSaranKritik";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
