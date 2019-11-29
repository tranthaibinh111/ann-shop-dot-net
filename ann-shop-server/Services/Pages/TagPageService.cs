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
        /// Lấy tất cả sản phẩm theo slug category
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="sort"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProductListByTagSort(string tagSlug, int sort, ref PaginationMetadataModel pagination)
        {
            return ProductService.Instance.getProductListByTagSort(tagSlug, sort, ref pagination);
        }
    }
}