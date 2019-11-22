using ann_shop_server.Models;
using ann_shop_server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ann_shop_server.Services
{
    public class ProductPageService : Service<ProductPageService>
    {
        /// <summary>
        /// Lấy thông tin sản phẩm theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public ProductModel getProductByCategory(string slug)
        {
            return ProductService.Instance.getProductByCategory(slug);
        }

        /// <summary>
        /// Lấy thông tin các sản phẩm con
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductRelatedModel> getProductRelatedBySlug(string slug, ref PaginationMetadataModel pagination)
        {
            return ProductService.Instance.getProductRelatedBySlug(slug, ref pagination);
        }

        /// <summary>
        /// Trà về hình ảnh tưởng chưng cho biến thể
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="variables"></param>
        /// <returns></returns>
        public string getImageWithVariable(int productID, int color, int size)
        {
            return ProductService.Instance.getImageWithVariable(productID, color, size);
        }

        /// <summary>
        /// Lấy danh sách hình ảnh của sản phẩm
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public List<string> getAdvertisementImages(int productID)
        {
            return ProductService.Instance.getAdvertisementImages(productID);
        }
    }
}