using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class MSetting: IEquatable<MSetting>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _setting_id; 
		private string _company_name; 
		private string _company_address; 
		private string _company_address2; 
		private string _company_city; 
		private string _company_telp; 
		private string _company_fax; 
		private string _company_npwp; 
		private DateTime _company_pkp_date; 
		private byte[] _company_logo; 
		private bool _auto_print_sales; 
		private bool _auto_backup; 
		private string _backup_dir; 
		private string _factur_no_format; 
		private int _factur_no_length; 
		private decimal _factur_no_next; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MSetting()
		{
			_setting_id = String.Empty; 
			_company_name = String.Empty; 
			_company_address = String.Empty; 
			_company_address2 = String.Empty; 
			_company_city = String.Empty; 
			_company_telp = String.Empty; 
			_company_fax = String.Empty; 
			_company_npwp = String.Empty; 
			_company_pkp_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_company_logo = new byte[]{}; 
			_auto_print_sales = false; 
			_auto_backup = false; 
			_backup_dir = String.Empty; 
			_factur_no_format = String.Empty; 
			_factur_no_length = 0; 
			_factur_no_next = 0; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MSetting(
			string setting_id)
			: this()
		{
			_setting_id = setting_id;
			_company_name = String.Empty;
			_company_address = String.Empty;
			_company_address2 = String.Empty;
			_company_city = String.Empty;
			_company_telp = String.Empty;
			_company_fax = String.Empty;
			_company_npwp = String.Empty;
			_company_pkp_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_company_logo = null;
			_auto_print_sales = false;
			_auto_backup = false;
			_backup_dir = String.Empty;
			_factur_no_format = String.Empty;
			_factur_no_length = 0;
			_factur_no_next = 0;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMSetting
        {

					internal string SettingId;

					internal string CompanyName;

					internal string CompanyAddress;

					internal string CompanyAddress2;

					internal string CompanyCity;

					internal string CompanyTelp;

					internal string CompanyFax;

					internal string CompanyNpwp;

					internal DateTime CompanyPkpDate;

					internal byte[] CompanyLogo;

					internal bool AutoPrintSales;

					internal bool AutoBackup;

					internal string BackupDir;

					internal string FacturNoFormat;

					internal int FacturNoLength;

					internal decimal FacturNoNext;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMSetting _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.SettingId = this.SettingId;	
				
				
					
					this._clone.CompanyName = this.CompanyName;	
				
				
					
					this._clone.CompanyAddress = this.CompanyAddress;	
				
				
					
					this._clone.CompanyAddress2 = this.CompanyAddress2;	
				
				
					
					this._clone.CompanyCity = this.CompanyCity;	
				
				
					
					this._clone.CompanyTelp = this.CompanyTelp;	
				
				
					
					this._clone.CompanyFax = this.CompanyFax;	
				
				
					
					this._clone.CompanyNpwp = this.CompanyNpwp;	
				
				
					
					this._clone.CompanyPkpDate = this.CompanyPkpDate;	
				
				
					
					this._clone.CompanyLogo = this.CompanyLogo;	
				
				
					
					this._clone.AutoPrintSales = this.AutoPrintSales;	
				
				
					
					this._clone.AutoBackup = this.AutoBackup;	
				
				
					
					this._clone.BackupDir = this.BackupDir;	
				
				
					
					this._clone.FacturNoFormat = this.FacturNoFormat;	
				
				
					
					this._clone.FacturNoLength = this.FacturNoLength;	
				
				
					
					this._clone.FacturNoNext = this.FacturNoNext;	
				
				
					
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
				
				
					
					this.CompanyName = this._clone.CompanyName;	
				
				
					
					this.CompanyAddress = this._clone.CompanyAddress;	
				
				
					
					this.CompanyAddress2 = this._clone.CompanyAddress2;	
				
				
					
					this.CompanyCity = this._clone.CompanyCity;	
				
				
					
					this.CompanyTelp = this._clone.CompanyTelp;	
				
				
					
					this.CompanyFax = this._clone.CompanyFax;	
				
				
					
					this.CompanyNpwp = this._clone.CompanyNpwp;	
				
				
					
					this.CompanyPkpDate = this._clone.CompanyPkpDate;	
				
				
					
					this.CompanyLogo = this._clone.CompanyLogo;	
				
				
					
					this.AutoPrintSales = this._clone.AutoPrintSales;	
				
				
					
					this.AutoBackup = this._clone.AutoBackup;	
				
				
					
					this.BackupDir = this._clone.BackupDir;	
				
				
					
					this.FacturNoFormat = this._clone.FacturNoFormat;	
				
				
					
					this.FacturNoLength = this._clone.FacturNoLength;	
				
				
					
					this.FacturNoNext = this._clone.FacturNoNext;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMSetting();
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
			
		public virtual string CompanyName
		{
			get
			{ 
				return _company_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CompanyName", value, value.ToString());
				
				_company_name = value;
			}
		}
			
		public virtual string CompanyAddress
		{
			get
			{ 
				return _company_address;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CompanyAddress", value, value.ToString());
				
				_company_address = value;
			}
		}
			
		public virtual string CompanyAddress2
		{
			get
			{ 
				return _company_address2;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CompanyAddress2", value, value.ToString());
				
				_company_address2 = value;
			}
		}
			
		public virtual string CompanyCity
		{
			get
			{ 
				return _company_city;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CompanyCity", value, value.ToString());
				
				_company_city = value;
			}
		}
			
		public virtual string CompanyTelp
		{
			get
			{ 
				return _company_telp;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CompanyTelp", value, value.ToString());
				
				_company_telp = value;
			}
		}
			
		public virtual string CompanyFax
		{
			get
			{ 
				return _company_fax;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CompanyFax", value, value.ToString());
				
				_company_fax = value;
			}
		}
			
		public virtual string CompanyNpwp
		{
			get
			{ 
				return _company_npwp;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CompanyNpwp", value, value.ToString());
				
				_company_npwp = value;
			}
		}
			
		public virtual DateTime CompanyPkpDate
		{
			get
			{ 
				return _company_pkp_date;
			}
			set
			{
				_company_pkp_date = value;
			}

		}
			
		public virtual byte[] CompanyLogo
		{
			get
			{ 
				return _company_logo;
			}
			set
			{
				_company_logo = value;
			}

		}
			
		public virtual bool AutoPrintSales
		{
			get
			{ 
				return _auto_print_sales;
			}
			set
			{
				_auto_print_sales = value;
			}

		}
			
		public virtual bool AutoBackup
		{
			get
			{ 
				return _auto_backup;
			}
			set
			{
				_auto_backup = value;
			}

		}
			
		public virtual string BackupDir
		{
			get
			{ 
				return _backup_dir;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for BackupDir", value, value.ToString());
				
				_backup_dir = value;
			}
		}
			
		public virtual string FacturNoFormat
		{
			get
			{ 
				return _factur_no_format;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for FacturNoFormat", value, value.ToString());
				
				_factur_no_format = value;
			}
		}
			
		public virtual int FacturNoLength
		{
			get
			{ 
				return _factur_no_length;
			}
			set
			{
				_factur_no_length = value;
			}

		}
			
		public virtual decimal FacturNoNext
		{
			get
			{ 
				return _factur_no_next;
			}
			set
			{
				_factur_no_next = value;
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
			MSetting castObj = (MSetting)obj; 
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

		public bool Equals(MSetting other)
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
						
			sb.Append(_company_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_company_address.ToString()); 
			sb.Append("|");						
						
			sb.Append(_company_address2.ToString()); 
			sb.Append("|");						
						
			sb.Append(_company_city.ToString()); 
			sb.Append("|");						
						
			sb.Append(_company_telp.ToString()); 
			sb.Append("|");						
						
			sb.Append(_company_fax.ToString()); 
			sb.Append("|");						
						
			sb.Append(_company_npwp.ToString()); 
			sb.Append("|");						
						
			sb.Append(_company_pkp_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_company_logo.ToString()); 
			sb.Append("|");						
						
			sb.Append(_auto_print_sales.ToString()); 
			sb.Append("|");						
						
			sb.Append(_auto_backup.ToString()); 
			sb.Append("|");						
						
			sb.Append(_backup_dir.ToString()); 
			sb.Append("|");						
						
			sb.Append(_factur_no_format.ToString()); 
			sb.Append("|");						
						
			sb.Append(_factur_no_length.ToString()); 
			sb.Append("|");						
						
			sb.Append(_factur_no_next.ToString()); 
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
				
				public const string CompanyName = "CompanyName";
				
				public const string CompanyAddress = "CompanyAddress";
				
				public const string CompanyAddress2 = "CompanyAddress2";
				
				public const string CompanyCity = "CompanyCity";
				
				public const string CompanyTelp = "CompanyTelp";
				
				public const string CompanyFax = "CompanyFax";
				
				public const string CompanyNpwp = "CompanyNpwp";
				
				public const string CompanyPkpDate = "CompanyPkpDate";
				
				public const string CompanyLogo = "CompanyLogo";
				
				public const string AutoPrintSales = "AutoPrintSales";
				
				public const string AutoBackup = "AutoBackup";
				
				public const string BackupDir = "BackupDir";
				
				public const string FacturNoFormat = "FacturNoFormat";
				
				public const string FacturNoLength = "FacturNoLength";
				
				public const string FacturNoNext = "FacturNoNext";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
