using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class MUser: IEquatable<MUser>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _user_name; 
		private string _user_password; 
		private bool _user_status; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MUser()
		{
			_user_name = String.Empty; 
			_user_password = String.Empty; 
			_user_status = false; 
			_modified_by = String.Empty; 
			_modified_date = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MUser(
			string user_name)
			: this()
		{
			_user_name = user_name;
			_user_password = String.Empty;
			_user_status = false;
			_modified_by = String.Empty;
			_modified_date = DateTime.MinValue;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMUser
        {

					internal string UserName;

					internal string UserPassword;

					internal bool UserStatus;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMUser _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.UserName = this.UserName;	
				
				
					
					this._clone.UserPassword = this.UserPassword;	
				
				
					
					this._clone.UserStatus = this.UserStatus;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.UserName = this._clone.UserName;	
				
				
					
					this.UserPassword = this._clone.UserPassword;	
				
				
					
					this.UserStatus = this._clone.UserStatus;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMUser();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
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
			
		public virtual string UserPassword
		{
			get
			{ 
				return _user_password;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for UserPassword", value, value.ToString());
				
				_user_password = value;
			}
		}
			
		public virtual bool UserStatus
		{
			get
			{ 
				return _user_status;
			}
			set
			{
				_user_status = value;
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
			MUser castObj = (MUser)obj; 
			return ( castObj != null ) &&
				( this._user_name == castObj.UserName );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _user_name.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MUser other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._user_name == other.UserName );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_user_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_user_password.ToString()); 
			sb.Append("|");						
						
			sb.Append(_user_status.ToString()); 
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
		
				public const string UserName = "UserName";
				
				public const string UserPassword = "UserPassword";
				
				public const string UserStatus = "UserStatus";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
