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
    
    public partial class CheckWarehouse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public bool Active { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
