using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class TReference: IEquatable<TReference>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private decimal _reference_id; 
		private string _reference_type; 
		private string _next_id; 
		private string _reference_desc; 		
		#endregion

		#region Constructor

		public TReference()
		{
			_reference_id = 0; 
			_reference_type = String.Empty; 
			_next_id = String.Empty; 
			_reference_desc = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public TReference(
			decimal reference_id)
			: this()
		{
			_reference_id = reference_id;
			_reference_type = String.Empty;
			_next_id = String.Empty;
			_reference_desc = String.Empty;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructTReference
        {

					internal decimal ReferenceId;

					internal string ReferenceType;

					internal string NextId;

					internal string ReferenceDesc;

        }

        StructTReference _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.ReferenceId = this.ReferenceId;	
				
				
					
					this._clone.ReferenceType = this.ReferenceType;	
				
				
					
					this._clone.NextId = this.NextId;	
				
				
					
					this._clone.ReferenceDesc = this.ReferenceDesc;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.ReferenceId = this._clone.ReferenceId;	
				
				
					
					this.ReferenceType = this._clone.ReferenceType;	
				
				
					
					this.NextId = this._clone.NextId;	
				
				
					
					this.ReferenceDesc = this._clone.ReferenceDesc;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructTReference();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual decimal ReferenceId
		{
			get
			{ 
				return _reference_id;
			}
			set
			{
				_reference_id = value;
			}

		}
			
		public virtual string ReferenceType
		{
			get
			{ 
				return _reference_type;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ReferenceType", value, value.ToString());
				
				_reference_type = value;
			}
		}
			
		public virtual string NextId
		{
			get
			{ 
				return _next_id;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for NextId", value, value.ToString());
				
				_next_id = value;
			}
		}
			
		public virtual string ReferenceDesc
		{
			get
			{ 
				return _reference_desc;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ReferenceDesc", value, value.ToString());
				
				_reference_desc = value;
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
			TReference castObj = (TReference)obj; 
			return ( castObj != null ) &&
				( this._reference_id == castObj.ReferenceId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _reference_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(TReference other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._reference_id == other.ReferenceId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_reference_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_reference_type.ToString()); 
			sb.Append("|");						
						
			sb.Append(_next_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_reference_desc.ToString()); 
			return sb.ToString();
		}
		#endregion // End Override ToString
	
	
	#region ColumnNames Class
	public class ColumnNames
	{
		
				public const string ReferenceId = "ReferenceId";
				
				public const string ReferenceType = "ReferenceType";
				
				public const string NextId = "NextId";
				
				public const string ReferenceDesc = "ReferenceDesc";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
