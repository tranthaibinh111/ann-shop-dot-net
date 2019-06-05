using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public enum VariableType
    {
        Color = 1,
        Size = 2
    };

    public class VariableModel
    {
        public int key { get; set; }
        public string name { get; set; }
    }
}