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
    
    public partial class tbl_CheckWarehouseDetail
    {
        public int ID { get; set; }
        public Nullable<int> AgentID { get; set; }
        public Nullable<int> CheckwarehouseID { get; set; }
        public Nullable<int> ProductVariableID { get; set; }
        public Nullable<double> Quantity_DB { get; set; }
        public Nullable<double> Quantity_Input { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
