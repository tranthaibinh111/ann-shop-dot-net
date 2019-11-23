using ann_shop_server.Models;
using ann_shop_server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

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
        /// Lấy tất cả sản phẩm theo slug category
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="sort"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProductListByCategorySort(string categorySlug, int sort, ref PaginationMetadataModel pagination)
        {
            return ProductService.Instance.getProductListByCategorySort(categorySlug, sort, ref pagination);
        }

        /// <summary>
        /// Lấy tất cả sản phẩm có chứa từ khóa
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProductListBySort(int sort, ref PaginationMetadataModel pagination)
        {
            return ProductService.Instance.getProductListBySort(sort, ref pagination);
        }

        /// <summary>
        /// Lấy tất cả sản phẩm order theo slug category
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="productBadge"></param>
        /// <param name="sort"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProductListByCategoryPreOrderSort(string categorySlug, string productBadge, int sort, ref PaginationMetadataModel pagination)
        {
            return ProductService.Instance.getProductListByCategoryPreOrderSort(categorySlug, productBadge, sort, ref pagination);
        }

        /// <summary>
        /// Lấy tất cả sản phẩm order
        /// </summary>
        /// <param name="productBadge"></param>
        /// <param name="sort"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProductListByPreOrderSort(string productBadge, int sort, ref PaginationMetadataModel pagination)
        {
            return ProductService.Instance.getProductListByPreOrderSort(productBadge, sort, ref pagination);
        }
    }
}