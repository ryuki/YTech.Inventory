using System;
using System.Collections.Generic;


namespace Inventori.Cafe.Data
{
	[Serializable]
	public class ItemGudangStok: IEquatable<ItemGudangStok>, System.ComponentModel.IEditableObject
	{

		#region Private Members

		private string _item_id; 
		private int _gudang_id; 
		private decimal _item_stok; 
		private decimal _item_min_stok; 
		private decimal _item_max_stok; 
		private string _item_position; 
		private string _modified_by; 
		private DateTime _modified_date; 		
		#endregion

		#region Constructor

		public ItemGudangStok()
		{
			_item_id = String.Empty; 
			_gudang_id = 0; 
			_item_stok = 0; 
			_item_min_stok = 0; 
			_item_max_stok = 0; 
			_item_position = String.Empty; 
			_modified_by = String.Empty; 
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public ItemGudangStok(
			string item_id, 
			int gudang_id)
			: this()
		{
			_item_id = item_id;
			_gudang_id = gudang_id;
			_item_stok = 0;
			_item_min_stok = 0;
			_item_max_stok = 0;
			_item_position = String.Empty;
			_modified_by = String.Empty;
			_modified_date = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
		}
		#endregion // End Constructor

	
		
		#region IEditableObject Members

        struct StructItemGudangStok
        {

					internal string ItemId;

					internal int GudangId;

					internal decimal ItemStok;

					internal decimal ItemMinStok;

					internal decimal ItemMaxStok;

					internal string ItemPosition;

					internal string ModifiedBy;

					internal DateTime ModifiedDate;

        }

        StructItemGudangStok _clone;
        bool _IsInEdit = false;

        public virtual void BeginEdit()
        {
            if (!_IsInEdit)
            {
			
				
					
					this._clone.ItemId = this.ItemId;	
				
				
					
					this._clone.GudangId = this.GudangId;	
				
				
					
					this._clone.ItemStok = this.ItemStok;	
				
				
					
					this._clone.ItemMinStok = this.ItemMinStok;	
				
				
					
					this._clone.ItemMaxStok = this.ItemMaxStok;	
				
				
					
					this._clone.ItemPosition = this.ItemPosition;	
				
				
					
					this._clone.ModifiedBy = this.ModifiedBy;	
				
				
					
					this._clone.ModifiedDate = this.ModifiedDate;	
				
                this._IsInEdit = true;
            }
        }

        public virtual void CancelEdit()
        {
            if (_IsInEdit)
            {
                
				
					
					this.ItemId = this._clone.ItemId;	
				
				
					
					this.GudangId = this._clone.GudangId;	
				
				
					
					this.ItemStok = this._clone.ItemStok;	
				
				
					
					this.ItemMinStok = this._clone.ItemMinStok;	
				
				
					
					this.ItemMaxStok = this._clone.ItemMaxStok;	
				
				
					
					this.ItemPosition = this._clone.ItemPosition;	
				
				
					
					this.ModifiedBy = this._clone.ModifiedBy;	
				
				
					
					this.ModifiedDate = this._clone.ModifiedDate;	
				
                this._IsInEdit = false;
            }
        }

        public virtual void EndEdit()
        {
            if (_IsInEdit)
            {
                this._clone = new StructItemGudangStok();
                this._IsInEdit = false;
            }
        }

        #endregion //IEditable Members
	
	
	
		#region Public Properties
			
		public virtual string ItemId
		{
			get
			{ 
				return _item_id;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for ItemId", value, "null");
				
				if(  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ItemId", value, value.ToString());
				
				_item_id = value;
			}
		}
			
		public virtual int GudangId
		{
			get
			{ 
				return _gudang_id;
			}
			set
			{
				_gudang_id = value;
			}

		}
			
		public virtual decimal ItemStok
		{
			get
			{ 
				return _item_stok;
			}
			set
			{
				_item_stok = value;
			}

		}
			
		public virtual decimal ItemMinStok
		{
			get
			{ 
				return _item_min_stok;
			}
			set
			{
				_item_min_stok = value;
			}

		}
			
		public virtual decimal ItemMaxStok
		{
			get
			{ 
				return _item_max_stok;
			}
			set
			{
				_item_max_stok = value;
			}

		}
			
		public virtual string ItemPosition
		{
			get
			{ 
				return _item_position;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for ItemPosition", value, value.ToString());
				
				_item_position = value;
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
			ItemGudangStok castObj = (ItemGudangStok)obj; 
			return ( castObj != null ) &&
				( this._item_id == castObj.ItemId ) &&
				( this._gudang_id == castObj.GudangId );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _item_id.GetHashCode();
			hash = 27 ^ hash ^ _gudang_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public bool Equals(ItemGudangStok other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._item_id == other.ItemId ) &&
				( this._gudang_id == other.GudangId );
				   
		}

		#endregion
		
#region ToString
		/// <summary>
		/// ToString
		/// </summary>
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
		
			sb.Append(_item_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_gudang_id.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_stok.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_min_stok.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_max_stok.ToString()); 
			sb.Append("|");						
						
			sb.Append(_item_position.ToString()); 
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
		
				public const string ItemId = "ItemId";
				
				public const string GudangId = "GudangId";
				
				public const string ItemStok = "ItemStok";
				
				public const string ItemMinStok = "ItemMinStok";
				
				public const string ItemMaxStok = "ItemMaxStok";
				
				public const string ItemPosition = "ItemPosition";
				
				public const string ModifiedBy = "ModifiedBy";
				
				public const string ModifiedDate = "ModifiedDate";
				
	}	
	#endregion //end of ColumnNames
	
		}
}
