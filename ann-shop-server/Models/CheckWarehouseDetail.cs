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
    
    public partial class CheckWarehouseDetail
    {
        public int ID { get; set; }
        public int CheckWarehouseID { get; set; }
        public int ProductID { get; set; }
        public int ProductVariableID { get; set; }
        public string ProductSKU { get; set; }
        public int QuantityOld { get; set; }
        public Nullable<int> QuantityNew { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
