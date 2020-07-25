using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class TLog: IEquatable<TLog>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _log_id; 
		private DateTime _log_date; 
		private string _log_user; 
		private string _log_comp_name; 
		private string _log_ip; 
		private string _log_action; 
		private string _log_table; 
		private string _log_desc; 		
		#endregion

		#region Constructor

		public TLog()
		{
			_log_id = 0; 
			_log_date = DateTime.MinValue; 
			_log_user = String.Empty; 
			_log_comp_name = String.Empty; 
			_log_ip = String.Empty; 
			_log_action = String.Empty; 
			_log_table = String.Empty; 
			_log_desc = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TLog(
			decimal log_id)
			: this()
		{
			_log_id = log_id;
			_log_date = DateTime.MinValue;
			_log_user = String.Empty;
			_log_comp_name = String.Empty;
			_log_ip = String.Empty;
			_log_action = String.Empty;
			_log_table = String.Empty;
			_log_desc = String.Empty;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTLog
        {

					internal decimal LogId;

					internal DateTime LogDate;

					internal string LogUser;

					internal string LogCompName;

					internal string LogIp;

					internal string LogAction;

					internal string LogTable;

					internal string LogDesc;

        }

        StructTLog _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.LogId = this.LogId;	
				
				
					
					this._clone.LogDate = this.LogDate;	
				
				
					
					this._clone.LogUser = this.LogUser;	
				
				
					
					this._clone.LogCompName = this.LogCompName;	
				
				
					
					this._clone.LogIp = this.LogIp;	
				
				
					
					this._clone.LogAction = this.LogAction;	
				
				
					
					this._clone.LogTable = this.LogTable;	
				
				
					
					this._clone.LogDesc = this.LogDesc;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.LogId = this._clone.LogId;	
				
				
					
					this.LogDate = this._clone.LogDate;	
				
				
					
					this.LogUser = this._clone.LogUser;	
				
				
					
					this.LogCompName = this._clone.LogCompName;	
				
				
					
					this.LogIp = this._clone.LogIp;	
				
				
					
					this.LogAction = this._clone.LogAction;	
				
				
					
					this.LogTable = this._clone.LogTable;	
				
				
					
					this.LogDesc = this._clone.LogDesc;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTLog();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual decimal LogId
		{
			get
			{ 
				return _log_id;
			}
			set
			{
				_log_id = value;
			}

		}
			
		public virtual DateTime LogDate
		{
			get
			{ 
				return _log_date;
			}
			set
			{
				_log_date = value;
			}

		}
			
		public virtual string LogUser
		{
			get
			{ 
				return _log_user;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for LogUser", value, value.ToString());
				
				_log_user = value;
			}
		}
			
		public virtual string LogCompName
		{
			get
			{ 
				return _log_comp_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for LogCompName", value, value.ToString());
				
				_log_comp_name = value;
			}
		}
			
		public virtual string LogIp
		{
			get
			{ 
				return _log_ip;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for LogIp", value, value.ToString());
				
				_log_ip = value;
			}
		}
			
		public virtual string LogAction
		{
			get
			{ 
				return _log_action;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for LogAction", value, value.ToString());
				
				_log_action = value;
			}
		}
			
		public virtual string LogTable
		{
			get
			{ 
				return _log_table;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for LogTable", value, value.ToString());
				
				_log_table = value;
			}
		}
			
		public virtual string LogDesc
		{
			get
			{ 
				return _log_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 2147483647)
					throw new ArgumentOutOfRangeException("Invalid value for LogDesc", value, value.ToString());
				
				_log_desc = value;
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
			TLog castObj = (TLog)obj; 
			return ( castObj != null ) &&
				( this._log_id == castObj.LogId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _log_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TLog other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._log_id == other.LogId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_log_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_log_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_log_user.ToString()); 
			sb.Append("|");						
						
			sb.Append(_log_comp_name.ToString()); 
			sb.Append("|");						
						
			sb.Append(_log_ip.ToString()); 
			sb.Append("|");						
						
			sb.Append(_log_action.ToString()); 
			sb.Append("|");						
						
			sb.Append(_log_table.ToString()); 
			sb.Append("|");						
						
			sb.Append(_log_desc.ToString()); 
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string LogId = "LogId";
				
				public const string LogDate = "LogDate";
				
				public const string LogUser = "LogUser";
				
				public const string LogCompName = "LogCompName";
				
				public const string LogIp = "LogIp";
				
				public const string LogAction = "LogAction";
				
				public const string LogTable = "LogTable";
				
				public const string LogDesc = "LogDesc";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
