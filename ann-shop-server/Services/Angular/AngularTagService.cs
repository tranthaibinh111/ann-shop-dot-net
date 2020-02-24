using ann_shop_server.Models;
using System.Collections.Generic;

namespace ann_shop_server.Services
{
    public class AngularTagService : IANNService
    {
        private readonly ProductService _product = ANNFactoryService.getInstance<ProductService>();
        private readonly TagService _tag = ANNFactoryService.getInstance<TagService>();
        
        /// <summary>
        /// Lấy thông tin tag theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public TagModel getTagBySlug(string slug)
        {
            return _tag.getTagBySlug(slug);
        }

        /// <summary>
        /// Lấy dữ liệu cho drop list sort
        /// </summary>
        /// <returns></returns>
        public List<ProductSortModel> getProductSort()
        {
            return _product.getProductSort();
        }

        /// <summary>
        /// Lấy tất cả sản phẩm theo filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProducts(TagPageFilterModel filter, ref PaginationMetadataModel pagination)
        {
            var productFilter = new ProductFilterModel()
            {
                tagSlug = filter.tagSlug,
                priceMin = filter.priceMin,
                priceMax = filter.priceMax,
                productSort = filter.sort
            };

            return _product.getProducts(productFilter, ref pagination);
        }
    }
}