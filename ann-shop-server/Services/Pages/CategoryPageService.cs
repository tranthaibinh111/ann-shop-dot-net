using ann_shop_server.Models;
using System.Collections.Generic;

namespace ann_shop_server.Services
{
    public class CategoryPageService : Service<CategoryPageService>
    {
        /// <summary>
        /// Lấy thông tin category theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public CategoryModel getCategoryBySlug(string slug)
        {
            return CategoryService.Instance.getCategoryBySlug(slug);
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
        /// Lấy tất cả sản phẩm theo bộ lọc
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProducts(CategoryPageFilterModel filter, ref PaginationMetadataModel pagination)
        {
            return ProductService.Instance.getProducts(filter, ref pagination);
        }
    }
}