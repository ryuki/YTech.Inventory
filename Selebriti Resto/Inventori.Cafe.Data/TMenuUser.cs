using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class TMenuUser: IEquatable<TMenuUser>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _menu_id; 
		private string _user_name; 
		private string _setting_id; 
		private bool _has_access; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TMenuUser()
		{
			_menu_id = 0; 
			_user_name = String.Empty; 
			_setting_id = String.Empty; 
			_has_access = false; 
			_modified_by = String.Empty; 
			_modified_date = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TMenuUser(
			decimal menu_id, 
			string user_name, 
			string setting_id)
			: this()
		{
			_menu_id = menu_id;
			_user_name = user_name;
			_setting_id = setting_id;
			_has_access = false;
			_modified_by = String.Empty;
			_modified_date = DateTime.MinValue;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTMenuUser
        {

					internal decimal MenuId;

					internal string UserName;

					internal string SettingId;

					internal bool HasAccess;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTMenuUser _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.MenuId = this.MenuId;	
				
				
					
					this._clone.UserName = this.UserName;	
				
				
					
					this._clone.SettingId = this.SettingId;	
				
				
					
					this._clone.HasAccess = this.HasAccess;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.MenuId = this._clone.MenuId;	
				
				
					
					this.UserName = this._clone.UserName;	
				
				
					
					this.SettingId = this._clone.SettingId;	
				
				
					
					this.HasAccess = this._clone.HasAccess;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTMenuUser();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual decimal MenuId
		{
			get
			{ 
				return _menu_id;
			}
			set
			{
				_menu_id = value;
			}

		}
			
		public virtual string UserName
		{
			get
			{ 
				return _user_name;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for UserName", value, "null");
				
				if(  value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for UserName", value, value.ToString());
				
				_user_name = value;
			}
		}
			
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
			
		public virtual bool HasAccess
		{
			get
			{ 
				return _has_access;
			}
			set
			{
				_has_access = value;
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
			TMenuUser castObj = (TMenuUser)obj; 
			return ( castObj != null ) &&
				( this._menu_id == castObj.MenuId ) &&
				( this._user_name == castObj.UserName ) &&
				( this._setting_id == castObj.SettingId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _menu_id.GetHashCode();
			hash = 27 ^ hash ^ _user_name.GetHashCode();
			hash = 27 ^ hash ^ _setting_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TMenuUser other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._menu_id == other.MenuId ) &&
				( this._user_name == other.UserName ) &&
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
		
			sb.Append(_menu_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_user_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_setting_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_has_access.ToString()); 
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
		
				public const string MenuId = "MenuId";
				
				public const string UserName = "UserName";
				
				public const string SettingId = "SettingId";
				
				public const string HasAccess = "HasAccess";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
