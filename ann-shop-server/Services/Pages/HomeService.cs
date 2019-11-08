using ann_shop_server.Models;
using ann_shop_server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services.Pages
{
    public class HomeService : Service<HomeService>
    {
        #region Get
        public List<HomeProductModel> getProducts(string categorySlug, ref PaginationMetadataModel pagination)
        {
            using (var con = new inventorymanagementEntities())
            {
                var source = con.tbl_Product.Where(x => x.WebPublish == true);

                if (String.IsNullOrEmpty(categorySlug))
                    return null;

                // Check category có tồn tại hay không
                List<ProductCategoryModel> categories = CategoryService.Instance.getCategoryChild(categorySlug);

                if (categories == null || categories.Count == 0)
                    return null;

                var categoryIDs = categories.Select(x => x.id).OrderByDescending(o => o).ToList();

                source = source.Where(x => categoryIDs.Contains(x.CategoryID.Value));

                var stockFilter = con.tbl_StockManager
                    .Join(
                        source,
                        s => s.ParentID,
                        d => d.ID,
                        (s, d) => s
                    )
                    .ToList();
                var stocks = StockService.Instance.getQuantities(stockFilter);

                var products = source.Where(x => x.CategoryID.HasValue)
                    .Join(
                        con.tbl_Category,
                        pro => pro.CategoryID.Value,
                        cat => cat.ID,
                        (p, c) => new
                        {
                            productID = p.ID,
                            title = p.ProductTitle,
                            sku = p.ProductSKU,
                            avatar = p.ProductImage,
                            regularPrice = p.Regular_Price.HasValue ? p.Regular_Price.Value : 0,
                            retailPrice = p.Retail_Price.HasValue ? p.Retail_Price.Value : 0,
                            slug = p.Slug
                        }
                    )
                    .ToList();

                var data = products
                    .GroupJoin(
                        stocks,
                        pro => pro.productID,
                        info => info.productID,
                        (pro, info) => new { pro, info }
                    )
                    .SelectMany(
                        x => x.info.DefaultIfEmpty(),
                        (parent, child) => new { product = parent.pro, stock = child }
                    )
                    .Where(x => x.stock != null && x.stock.availability )
                    .Select(x => new HomeProductModel()
                    {
                        id = x.product.productID,
                        title = x.product.title,
                        sku = x.product.sku,
                        thumbnails = Thumbnail.getALL(x.product.avatar),
                        regularPrice = x.product.regularPrice,
                        retailPrice = x.product.retailPrice,
                        slug = x.product.slug
                    });

                // Lấy tổng số record sản phẩm
                pagination.totalCount = data.Count();

                // Calculating Totalpage by Dividing (No of Records / Pagesize)
                pagination.totalPages = (int)Math.Ceiling(pagination.totalCount / (double)pagination.pageSize);

                // Returns List of product after applying Paging
                var result = data
                    .Skip((pagination.currentPage - 1) * pagination.pageSize)
                    .Take(pagination.pageSize)
                    .ToList();

                // if CurrentPage is greater than 1 means it has previousPage
                pagination.previousPage = pagination.currentPage > 1 ? "Yes" : "No";

                // if TotalPages is greater than CurrentPage means it has nextPage
                pagination.nextPage = pagination.currentPage < pagination.totalPages ? "Yes" : "No";

                return result;
            }
        }
        #endregion
    }
}