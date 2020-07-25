using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class TCommission: IEquatable<TCommission>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _commission_id; 
		private decimal _transaction_id; 
		private string _transaction_factur_no; 
		private string _share_to; 
		private string _commission_pic; 
		private decimal _commission_value; 
		private DateTime _commission_date; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TCommission()
		{
			_commission_id = 0; 
			_transaction_id = 0; 
			_transaction_factur_no = String.Empty; 
			_share_to = String.Empty; 
			_commission_pic = String.Empty; 
			_commission_value = 0; 
			_commission_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TCommission(
			decimal commission_id)
			: this()
		{
			_commission_id = commission_id;
			_transaction_id = 0;
			_transaction_factur_no = String.Empty;
			_share_to = String.Empty;
			_commission_pic = String.Empty;
			_commission_value = 0;
			_commission_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTCommission
        {

					internal decimal CommissionId;

					internal decimal TransactionId;

					internal string TransactionFacturNo;

					internal string ShareTo;

					internal string CommissionPic;

					internal decimal CommissionValue;

					internal DateTime CommissionDate;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTCommission _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.CommissionId = this.CommissionId;	
				
				
					
					this._clone.TransactionId = this.TransactionId;	
				
				
					
					this._clone.TransactionFacturNo = this.TransactionFacturNo;	
				
				
					
					this._clone.ShareTo = this.ShareTo;	
				
				
					
					this._clone.CommissionPic = this.CommissionPic;	
				
				
					
					this._clone.CommissionValue = this.CommissionValue;	
				
				
					
					this._clone.CommissionDate = this.CommissionDate;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.CommissionId = this._clone.CommissionId;	
				
				
					
					this.TransactionId = this._clone.TransactionId;	
				
				
					
					this.TransactionFacturNo = this._clone.TransactionFacturNo;	
				
				
					
					this.ShareTo = this._clone.ShareTo;	
				
				
					
					this.CommissionPic = this._clone.CommissionPic;	
				
				
					
					this.CommissionValue = this._clone.CommissionValue;	
				
				
					
					this.CommissionDate = this._clone.CommissionDate;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTCommission();
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
			
		public virtual decimal TransactionId
		{
			get
			{ 
				return _transaction_id;
			}
			set
			{
				_transaction_id = value;
			}

		}
			
		public virtual string TransactionFacturNo
		{
			get
			{ 
				return _transaction_factur_no;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TransactionFacturNo", value, value.ToString());
				
				_transaction_factur_no = value;
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
			
		public virtual string CommissionPic
		{
			get
			{ 
				return _commission_pic;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for CommissionPic", value, value.ToString());
				
				_commission_pic = value;
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
			
		public virtual DateTime CommissionDate
		{
			get
			{ 
				return _commission_date;
			}
			set
			{
				_commission_date = value;
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
			TCommission castObj = (TCommission)obj; 
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

		public bool Equals(TCommission other)
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
						
			sb.Append(_transaction_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_transaction_factur_no.ToString()); 
			sb.Append("|");						
						
			sb.Append(_share_to.ToString()); 
			sb.Append("|");						
						
			sb.Append(_commission_pic.ToString()); 
			sb.Append("|");						
						
			sb.Append(_commission_value.ToString()); 
			sb.Append("|");						
						
			sb.Append(_commission_date.ToString()); 
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
		
				public const string CommissionId = "CommissionId";
				
				public const string TransactionId = "TransactionId";
				
				public const string TransactionFacturNo = "TransactionFacturNo";
				
				public const string ShareTo = "ShareTo";
				
				public const string CommissionPic = "CommissionPic";
				
				public const string CommissionValue = "CommissionValue";
				
				public const string CommissionDate = "CommissionDate";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
