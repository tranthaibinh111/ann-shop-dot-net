using ann_shop_server.Models;
using System.Collections.Generic;

namespace ann_shop_server.Services
{
    public class AngularCategoryService : IANNService
    {
        private readonly CategoryService _category = ANNFactoryService.getInstance<CategoryService>();
        private readonly ProductService _product = ANNFactoryService.getInstance<ProductService>();

        /// <summary>
        /// Lấy thông tin category theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public CategoryModel getCategoryBySlug(string slug)
        {
            return _category.getCategoryBySlug(slug);
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
        /// Lấy tất cả sản phẩm theo bộ lọc
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProducts(CategoryPageFilterModel filter, ref PaginationMetadataModel pagination)
        {
            var productFilter = new ProductFilterModel()
            {
                categorySlug = filter.categorySlug,
                productBadge = filter.productBadge,
                productSort = filter.sort,
                priceMin = filter.priceMin,
                priceMax = filter.priceMax
            };

            return _product.getProducts(productFilter, ref pagination);
        }
    }
}