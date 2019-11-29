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
        /// <summary>
        /// Lấy producttheo bộ lọc
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProducts(HomePageFilterModel filter, ref PaginationMetadataModel pagination)
        {
            return ProductService.Instance.getProducts(filter, ref pagination);
        }
    }
}