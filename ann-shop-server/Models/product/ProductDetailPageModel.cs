using System.Collections.Generic;

namespace ann_shop_server.Models
{
    public class ProductDetailPageModel : ProductModel
    {
        public List<VariableModel> colors { get; set; } = new List<VariableModel>();
        public List<VariableModel> sizes { get; set; } = new List<VariableModel>();
        public List<string> images { get; set; } = new List<string>();
        public string content { get; set; }
    }
}