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
    
    public partial class PostPublic
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string CategorySlug { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Action { get; set; }
        public string ActionValue { get; set; }
        public bool AtHome { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsPolicy { get; set; }
    }
}