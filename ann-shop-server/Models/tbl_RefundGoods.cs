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
    
    public partial class tbl_RefundGoods
    {
        public int ID { get; set; }
        public Nullable<int> AgentID { get; set; }
        public string TotalPrice { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<double> TotalQuantity { get; set; }
        public string TotalRefundFee { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string AgentName { get; set; }
        public string RefundNote { get; set; }
        public Nullable<int> OrderSaleID { get; set; }
    }
}
