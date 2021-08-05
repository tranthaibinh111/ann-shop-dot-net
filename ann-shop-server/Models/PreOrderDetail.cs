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
    
    public partial class PreOrderDetail
    {
        public long PreOrderId { get; set; }
        public long Id { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> VariationId { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal CostOfGoods { get; set; }
        public decimal Price { get; set; }
        public Nullable<decimal> OldPrice { get; set; }
        public int Quantity { get; set; }
        public Nullable<decimal> TotalCostOfGoods { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public byte[] Timestamp { get; set; }
        public decimal Discount { get; set; }
    
        public virtual PreOrder PreOrder { get; set; }
        public virtual tbl_Product tbl_Product { get; set; }
        public virtual tbl_ProductVariable tbl_ProductVariable { get; set; }
    }
}
