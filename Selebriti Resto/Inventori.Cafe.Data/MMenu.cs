using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class MMenu: IEquatable<MMenu>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _menu_id; 
		private string _setting_id; 
		private string _menu_name; 
		private string _menu_status; 		
		#endregion

		#region Constructor

		public MMenu()
		{
			_menu_id = 0; 
			_setting_id = String.Empty; 
			_menu_name = String.Empty; 
			_menu_status = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MMenu(
			decimal menu_id, 
			string setting_id)
			: this()
		{
			_menu_id = menu_id;
			_setting_id = setting_id;
			_menu_name = String.Empty;
			_menu_status = String.Empty;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMMenu
        {

					internal decimal MenuId;

					internal string SettingId;

					internal string MenuName;

					internal string MenuStatus;

        }

        StructMMenu _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.MenuId = this.MenuId;	
				
				
					
					this._clone.SettingId = this.SettingId;	
				
				
					
					this._clone.MenuName = this.MenuName;	
				
				
					
					this._clone.MenuStatus = this.MenuStatus;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.MenuId = this._clone.MenuId;	
				
				
					
					this.SettingId = this._clone.SettingId;	
				
				
					
					this.MenuName = this._clone.MenuName;	
				
				
					
					this.MenuStatus = this._clone.MenuStatus;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMMenu();
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
			
		public virtual string MenuName
		{
			get
			{ 
				return _menu_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for MenuName", value, value.ToString());
				
				_menu_name = value;
			}
		}
			
		public virtual string MenuStatus
		{
			get
			{ 
				return _menu_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for MenuStatus", value, value.ToString());
				
				_menu_status = value;
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
			MMenu castObj = (MMenu)obj; 
			return ( castObj != null ) &&
				( this._menu_id == castObj.MenuId ) &&
				( this._setting_id == castObj.SettingId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _menu_id.GetHashCode();
			hash = 27 ^ hash ^ _setting_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MMenu other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._menu_id == other.MenuId ) &&
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
						
			sb.Append(_setting_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_menu_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_menu_status.ToString()); 
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string MenuId = "MenuId";
				
				public const string SettingId = "SettingId";
				
				public const string MenuName = "MenuName";
				
				public const string MenuStatus = "MenuStatus";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
