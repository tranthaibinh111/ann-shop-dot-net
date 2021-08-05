//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ann_shop_server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_ProductVariable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_ProductVariable()
        {
            this.PreOrderDetails = new HashSet<PreOrderDetail>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ParentSKU { get; set; }
        public string SKU { get; set; }
        public Nullable<double> Stock { get; set; }
        public Nullable<int> StockStatus { get; set; }
        public Nullable<double> Regular_Price { get; set; }
        public Nullable<double> CostOfGood { get; set; }
        public string Image { get; set; }
        public Nullable<bool> ManageStock { get; set; }
        public Nullable<bool> IsHidden { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public Nullable<double> RetailPrice { get; set; }
        public Nullable<double> MinimumInventoryLevel { get; set; }
        public Nullable<double> MaximumInventoryLevel { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public string SupplierName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PreOrderDetail> PreOrderDetails { get; set; }
    }
}
