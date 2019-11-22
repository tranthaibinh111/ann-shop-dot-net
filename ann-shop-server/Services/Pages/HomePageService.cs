using ann_shop_server.Models;
using ann_shop_server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services.Pages
{
    public class HomePageService : Service<HomePageService>
    {
        public List<ProductCardModel> getProductListByCategory(string categorySlug, ref PaginationMetadataModel pagination)
        {
            return ProductService.Instance.getProductListByCategory(categorySlug, ref pagination);
        }
    }
}