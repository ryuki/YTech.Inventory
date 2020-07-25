using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class MCommissionShare: IEquatable<MCommissionShare>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _share_id; 
		private decimal _commission_id; 
		private string _share_to; 
		private decimal _share_value; 
		private string _share_desc; 		
		#endregion

		#region Constructor

		public MCommissionShare()
		{
			_share_id = 0; 
			_commission_id = 0; 
			_share_to = String.Empty; 
			_share_value = 0; 
			_share_desc = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MCommissionShare(
			decimal share_id)
			: this()
		{
			_share_id = share_id;
			_commission_id = 0;
			_share_to = String.Empty;
			_share_value = 0;
			_share_desc = String.Empty;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMCommissionShare
        {

					internal decimal ShareId;

					internal decimal CommissionId;

					internal string ShareTo;

					internal decimal ShareValue;

					internal string ShareDesc;

        }

        StructMCommissionShare _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.ShareId = this.ShareId;	
				
				
					
					this._clone.CommissionId = this.CommissionId;	
				
				
					
					this._clone.ShareTo = this.ShareTo;	
				
				
					
					this._clone.ShareValue = this.ShareValue;	
				
				
					
					this._clone.ShareDesc = this.ShareDesc;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.ShareId = this._clone.ShareId;	
				
				
					
					this.CommissionId = this._clone.CommissionId;	
				
				
					
					this.ShareTo = this._clone.ShareTo;	
				
				
					
					this.ShareValue = this._clone.ShareValue;	
				
				
					
					this.ShareDesc = this._clone.ShareDesc;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMCommissionShare();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual decimal ShareId
		{
			get
			{ 
				return _share_id;
			}
			set
			{
				_share_id = value;
			}

		}
			
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
			
		public virtual string ShareTo
		{
			get
			{ 
				return _share_to;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ShareTo", value, value.ToString());
				
				_share_to = value;
			}
		}
			
		public virtual decimal ShareValue
		{
			get
			{ 
				return _share_value;
			}
			set
			{
				_share_value = value;
			}

		}
			
		public virtual string ShareDesc
		{
			get
			{ 
				return _share_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ShareDesc", value, value.ToString());
				
				_share_desc = value;
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
			MCommissionShare castObj = (MCommissionShare)obj; 
			return ( castObj != null ) &&
				( this._share_id == castObj.ShareId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _share_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MCommissionShare other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._share_id == other.ShareId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_share_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_commission_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_share_to.ToString()); 
			sb.Append("|");						
						
			sb.Append(_share_value.ToString()); 
			sb.Append("|");						
						
			sb.Append(_share_desc.ToString()); 
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string ShareId = "ShareId";
				
				public const string CommissionId = "CommissionId";
				
				public const string ShareTo = "ShareTo";
				
				public const string ShareValue = "ShareValue";
				
				public const string ShareDesc = "ShareDesc";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
