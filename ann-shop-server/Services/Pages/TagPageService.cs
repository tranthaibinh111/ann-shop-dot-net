using ann_shop_server.Models;
using System.Collections.Generic;

namespace ann_shop_server.Services
{
    public class TagPageService : Service<TagPageService>
    {
        /// <summary>
        /// Lấy thông tin tag theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public TagModel getTagBySlug(string slug)
        {
            return TagService.Instance.getTagBySlug(slug);
        }

        /// <summary>
        /// Lấy dữ liệu cho drop list sort
        /// </summary>
        /// <returns></returns>
        public List<ProductSortModel> getProductSort()
        {
            return ProductService.Instance.getProductSort();
        }

        /// <summary>
        /// Lấy tất cả sản phẩm theo filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProducts(TagPageFilterModel filter, ref PaginationMetadataModel pagination)
        {
            return ProductService.Instance.getProducts(filter, ref pagination);
        }
    }
}