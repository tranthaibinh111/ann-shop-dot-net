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
    
    public partial class ViewOrder
    {
        public string Phone { get; set; }
        public long Id { get; set; }
        public int Status { get; set; }
        public Nullable<long> PreOrderId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public byte[] Timestamp { get; set; }
    
        public virtual PreOrder PreOrder { get; set; }
        public virtual tbl_Order tbl_Order { get; set; }
    }
}
