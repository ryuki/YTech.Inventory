using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class MCommission: IEquatable<MCommission>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _commission_id; 
		private string _commission_status; 
		private decimal _commission_value; 
		private string _commission_desc; 		
		#endregion

		#region Constructor

		public MCommission()
		{
			_commission_id = 0; 
			_commission_status = String.Empty; 
			_commission_value = 0; 
			_commission_desc = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MCommission(
			decimal commission_id)
			: this()
		{
			_commission_id = commission_id;
			_commission_status = String.Empty;
			_commission_value = 0;
			_commission_desc = String.Empty;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMCommission
        {

					internal decimal CommissionId;

					internal string CommissionStatus;

					internal decimal CommissionValue;

					internal string CommissionDesc;

        }

        StructMCommission _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.CommissionId = this.CommissionId;	
				
				
					
					this._clone.CommissionStatus = this.CommissionStatus;	
				
				
					
					this._clone.CommissionValue = this.CommissionValue;	
				
				
					
					this._clone.CommissionDesc = this.CommissionDesc;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.CommissionId = this._clone.CommissionId;	
				
				
					
					this.CommissionStatus = this._clone.CommissionStatus;	
				
				
					
					this.CommissionValue = this._clone.CommissionValue;	
				
				
					
					this.CommissionDesc = this._clone.CommissionDesc;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMCommission();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual decimal CommissionId
		{
			get
			{ 
				return _commission_id;
			}
			set
			{
				_commission_id = value;
			}

		}
			
		public virtual string CommissionStatus
		{
			get
			{ 
				return _commission_status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CommissionStatus", value, value.ToString());
				
				_commission_status = value;
			}
		}
			
		public virtual decimal CommissionValue
		{
			get
			{ 
				return _commission_value;
			}
			set
			{
				_commission_value = value;
			}

		}
			
		public virtual string CommissionDesc
		{
			get
			{ 
				return _commission_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CommissionDesc", value, value.ToString());
				
				_commission_desc = value;
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
			MCommission castObj = (MCommission)obj; 
			return ( castObj != null ) &&
				( this._commission_id == castObj.CommissionId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _commission_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MCommission other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._commission_id == other.CommissionId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_commission_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_commission_status.ToString()); 
			sb.Append("|");						
						
			sb.Append(_commission_value.ToString()); 
			sb.Append("|");						
						
			sb.Append(_commission_desc.ToString()); 
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string CommissionId = "CommissionId";
				
				public const string CommissionStatus = "CommissionStatus";
				
				public const string CommissionValue = "CommissionValue";
				
				public const string CommissionDesc = "CommissionDesc";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
