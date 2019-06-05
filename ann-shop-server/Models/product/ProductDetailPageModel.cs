using System.Collections.Generic;

namespace ann_shop_server.Models
{
    public class ProductDetailPageModel : ProductModel
    {
        public IEnumerable<VariableModel> colors { get; set; } = new List<VariableModel>();
        public IEnumerable<VariableModel> sizes { get; set; } = new List<VariableModel>();
        public IEnumerable<string> images { get; set; } = new List<string>();
        public string content { get; set; }
    }
}