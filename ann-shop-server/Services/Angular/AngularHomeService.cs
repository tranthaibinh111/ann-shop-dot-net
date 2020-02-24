using ann_shop_server.Models;
using ann_shop_server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class AngularHomeService : IANNService
    {
        private readonly ProductService _product = ANNFactoryService.getInstance<ProductService>();

        /// <summary>
        /// Lấy product theo bộ lọc
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProducts(HomePageFilterModel filter, ref PaginationMetadataModel pagination)
        {
            var productFilter = new ProductFilterModel()
            {
                categorySlug = filter.categorySlug,
                categorySlugList = filter.categorySlugList,
                productSort = filter.sort
            };

            return _product.getProducts(productFilter, ref pagination);
        }
    }
}