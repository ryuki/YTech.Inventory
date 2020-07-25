using System;
using System.Collections.Generic;


namespace Inventori.Data
{
	[Serializable]
	public class MItemType: IEquatable<MItemType>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private int _item_type_id; 
		private string _item_type_name; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public MItemType()
		{
			_item_type_id = 0; 
			_item_type_name = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public MItemType(
			int item_type_id)
			: this()
		{
			_item_type_id = item_type_id;
			_item_type_name = String.Empty;
			_modified_by = String.Empty;
			_modified_date = DateTime.MinValue;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructMItemType
        {

					internal int ItemTypeId;

					internal string ItemTypeName;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructMItemType _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.ItemTypeId = this.ItemTypeId;	
				
				
					
					this._clone.ItemTypeName = this.ItemTypeName;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.ItemTypeId = this._clone.ItemTypeId;	
				
				
					
					this.ItemTypeName = this._clone.ItemTypeName;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructMItemType();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual int ItemTypeId
		{
			get
			{ 
				return _item_type_id;
			}
			set
			{
				_item_type_id = value;
			}

		}
			
		public virtual string ItemTypeName
		{
			get
			{ 
				return _item_type_name;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ItemTypeName", value, value.ToString());
				
				_item_type_name = value;
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
			MItemType castObj = (MItemType)obj; 
			return ( castObj != null ) &&
				( this._item_type_id == castObj.ItemTypeId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _item_type_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(MItemType other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._item_type_id == other.ItemTypeId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_item_type_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_type_name.ToString()); 
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
		
				public const string ItemTypeId = "ItemTypeId";
				
				public const string ItemTypeName = "ItemTypeName";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
