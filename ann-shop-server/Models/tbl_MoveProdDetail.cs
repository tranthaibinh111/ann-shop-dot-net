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
    
    public partial class tbl_MoveProdDetail
    {
        public int ID { get; set; }
        public Nullable<int> MoveProID { get; set; }
        public string SKU { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> ProductVariableID { get; set; }
        public Nullable<int> ProductType { get; set; }
        public string ProductVariableDescription { get; set; }
        public Nullable<double> QuantiySend { get; set; }
        public Nullable<double> QuantityReceive { get; set; }
        public string Note { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ProductVariableName { get; set; }
        public string ProductVariableValue { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public Nullable<bool> IsCount { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
