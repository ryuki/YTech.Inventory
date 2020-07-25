using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class TTransactionService: IEquatable<TTransactionService>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _transaction_id; 
		private string _service_first_condition; 
		private DateTime _service_request_date; 
		private DateTime _service_start_work; 
		private DateTime _service_end_work; 
		private string _service_pic; 
		private string _service_type; 
		private string _service_complain; 
		private string _service_desc; 
		private decimal _service_charge; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public TTransactionService()
		{
			_transaction_id = 0; 
			_service_first_condition = String.Empty; 
			_service_request_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_service_start_work = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_service_end_work = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
			_service_pic = String.Empty; 
			_service_type = String.Empty; 
			_service_complain = String.Empty; 
			_service_desc = String.Empty; 
			_service_charge = 0; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TTransactionService(
			decimal transaction_id)
			: this()
		{
			_transaction_id = transaction_id;
			_service_first_condition = String.Empty;
			_service_request_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_service_start_work = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_service_end_work = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
			_service_pic = String.Empty;
			_service_type = String.Empty;
			_service_complain = String.Empty;
			_service_desc = String.Empty;
			_service_charge = 0;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTTransactionService
        {

					internal decimal TransactionId;

					internal string ServiceFirstCondition;

					internal DateTime ServiceRequestDate;

					internal DateTime ServiceStartWork;

					internal DateTime ServiceEndWork;

					internal string ServicePic;

					internal string ServiceType;

					internal string ServiceComplain;

					internal string ServiceDesc;

					internal decimal ServiceCharge;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructTTransactionService _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.TransactionId = this.TransactionId;	
				
				
					
					this._clone.ServiceFirstCondition = this.ServiceFirstCondition;	
				
				
					
					this._clone.ServiceRequestDate = this.ServiceRequestDate;	
				
				
					
					this._clone.ServiceStartWork = this.ServiceStartWork;	
				
				
					
					this._clone.ServiceEndWork = this.ServiceEndWork;	
				
				
					
					this._clone.ServicePic = this.ServicePic;	
				
				
					
					this._clone.ServiceType = this.ServiceType;	
				
				
					
					this._clone.ServiceComplain = this.ServiceComplain;	
				
				
					
					this._clone.ServiceDesc = this.ServiceDesc;	
				
				
					
					this._clone.ServiceCharge = this.ServiceCharge;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.TransactionId = this._clone.TransactionId;	
				
				
					
					this.ServiceFirstCondition = this._clone.ServiceFirstCondition;	
				
				
					
					this.ServiceRequestDate = this._clone.ServiceRequestDate;	
				
				
					
					this.ServiceStartWork = this._clone.ServiceStartWork;	
				
				
					
					this.ServiceEndWork = this._clone.ServiceEndWork;	
				
				
					
					this.ServicePic = this._clone.ServicePic;	
				
				
					
					this.ServiceType = this._clone.ServiceType;	
				
				
					
					this.ServiceComplain = this._clone.ServiceComplain;	
				
				
					
					this.ServiceDesc = this._clone.ServiceDesc;	
				
				
					
					this.ServiceCharge = this._clone.ServiceCharge;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTTransactionService();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
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
			
		public virtual string ServiceFirstCondition
		{
			get
			{ 
				return _service_first_condition;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ServiceFirstCondition", value, value.ToString());
				
				_service_first_condition = value;
			}
		}
			
		public virtual DateTime ServiceRequestDate
		{
			get
			{ 
				return _service_request_date;
			}
			set
			{
				_service_request_date = value;
			}

		}
			
		public virtual DateTime ServiceStartWork
		{
			get
			{ 
				return _service_start_work;
			}
			set
			{
				_service_start_work = value;
			}

		}
			
		public virtual DateTime ServiceEndWork
		{
			get
			{ 
				return _service_end_work;
			}
			set
			{
				_service_end_work = value;
			}

		}
			
		public virtual string ServicePic
		{
			get
			{ 
				return _service_pic;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ServicePic", value, value.ToString());
				
				_service_pic = value;
			}
		}
			
		public virtual string ServiceType
		{
			get
			{ 
				return _service_type;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ServiceType", value, value.ToString());
				
				_service_type = value;
			}
		}
			
		public virtual string ServiceComplain
		{
			get
			{ 
				return _service_complain;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ServiceComplain", value, value.ToString());
				
				_service_complain = value;
			}
		}
			
		public virtual string ServiceDesc
		{
			get
			{ 
				return _service_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ServiceDesc", value, value.ToString());
				
				_service_desc = value;
			}
		}
			
		public virtual decimal ServiceCharge
		{
			get
			{ 
				return _service_charge;
			}
			set
			{
				_service_charge = value;
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
			TTransactionService castObj = (TTransactionService)obj; 
			return ( castObj != null ) &&
				( this._transaction_id == castObj.TransactionId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _transaction_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TTransactionService other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._transaction_id == other.TransactionId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_transaction_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_service_first_condition.ToString()); 
			sb.Append("|");						
						
			sb.Append(_service_request_date.ToString()); 
			sb.Append("|");						
						
			sb.Append(_service_start_work.ToString()); 
			sb.Append("|");						
						
			sb.Append(_service_end_work.ToString()); 
			sb.Append("|");						
						
			sb.Append(_service_pic.ToString()); 
			sb.Append("|");						
						
			sb.Append(_service_type.ToString()); 
			sb.Append("|");						
						
			sb.Append(_service_complain.ToString()); 
			sb.Append("|");						
						
			sb.Append(_service_desc.ToString()); 
			sb.Append("|");						
						
			sb.Append(_service_charge.ToString()); 
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
		
				public const string TransactionId = "TransactionId";
				
				public const string ServiceFirstCondition = "ServiceFirstCondition";
				
				public const string ServiceRequestDate = "ServiceRequestDate";
				
				public const string ServiceStartWork = "ServiceStartWork";
				
				public const string ServiceEndWork = "ServiceEndWork";
				
				public const string ServicePic = "ServicePic";
				
				public const string ServiceType = "ServiceType";
				
				public const string ServiceComplain = "ServiceComplain";
				
				public const string ServiceDesc = "ServiceDesc";
				
				public const string ServiceCharge = "ServiceCharge";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
