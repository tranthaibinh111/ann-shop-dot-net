using ann_shop_server.Models;
using ann_shop_server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services.Searches
{
    public class SearchProductService : Service<SearchProductService>
    {
        #region Modal tìm kiếm sản phẩm để đặt hàng
        public List<SearchProductOrderedModel> getProductOrdered(int orderType, string sku)
        {
            if (String.IsNullOrEmpty(sku))
                return new List<SearchProductOrderedModel>();

            using (var con = new inventorymanagementEntities())
            {
                sku = sku.Trim().ToLower();

                #region Tìm xem có phải sản phẩm đơn thể
                var products = con.tbl_Product
                    .Where(x => x.ProductStyle == ProductStyle.NoVariable)
                    .Where(x => x.ProductSKU.Trim().ToLower().Contains(sku))
                    .Select(x => new SearchProductOrderedModel
                    {
                        productID = x.ID,
                        productVariableID = 0,
                        sku = x.ProductSKU,
                        title = x.ProductTitle,
                        avatar = x.ProductImage,
                        color = String.Empty,
                        size = String.Empty,
                        price = orderType == OrderType.Retail ? 
                            (x.Retail_Price.HasValue ? x.Retail_Price.Value : 0) : 
                            (x.Regular_Price.HasValue ? x.Regular_Price.Value : 0),
                       createdDate = x.CreatedDate.Value
                    });
                #endregion

                #region Tìm xem có phải sản phẩm biến thể không
                var productVariables = con.tbl_ProductVariable
                    .Where(x => x.SKU.Trim().ToLower().Contains(sku))
                    .Join(
                        con.tbl_Product.Where(x => x.ProductStyle == ProductStyle.Variable),
                        pv => pv.ProductID,
                        p => p.ID,
                        (pv, p) => new SearchProductOrderedModel
                        {
                            productID = p.ID,
                            productVariableID = pv.ID,
                            sku = pv.SKU,
                            title = p.ProductTitle,
                            avatar = pv.Image,
                            color = String.Empty,
                            size = String.Empty,
                            price = orderType == OrderType.Retail ?
                                (pv.RetailPrice.HasValue ? pv.RetailPrice.Value : 0) :
                                (pv.Regular_Price.HasValue ? pv.Regular_Price.Value : 0),
                            createdDate = pv.CreatedDate.Value
                        }
                    );

                var productVariableValue = con.tbl_ProductVariableValue
                    .Join(
                        productVariables,
                        pvv => pvv.ProductVariableID,
                        pv => pv.productVariableID,
                        (pvv, pv) => pvv
                    )
                    .Join(
                        con.tbl_VariableValue,
                        pvv => pvv.VariableValueID,
                        vv => vv.ID,
                        (pvv, vv) => new
                        {
                            productVariableID = pvv.ProductVariableID,
                            variableID = vv.VariableID,
                            variableValue = vv.VariableValue
                        }
                    );

                var color = productVariableValue
                    .Where(x => x.variableID == VariableKind.Color)
                    .Select(x => new {
                        productVariableID = x.productVariableID,
                        name = x.variableValue
                    });
                var size = productVariableValue
                    .Where(x => x.variableID == VariableKind.Size)
                    .Select(x => new {
                        productVariableID = x.productVariableID,
                        name = x.variableValue
                    });

                productVariables = productVariables
                    .GroupJoin(
                        color,
                        pv => pv.productVariableID,
                        c => c.productVariableID,
                        (pv, c) => new { product = pv, color = c }
                    )
                    .SelectMany(
                        x => x.color.DefaultIfEmpty(),
                        (parent, child) => new { product = parent.product, color = child }
                    )
                    .GroupJoin(
                        size,
                        temp => temp.product.productVariableID,
                        s => s.productVariableID,
                        (temp, s) => new { product = temp.product, color = temp.color, size = s }
                    )
                    .SelectMany(
                        x => x.size.DefaultIfEmpty(),
                        (parent, child) => new { product = parent.product, color = parent.color, size = child }
                    )
                    .Select(x => new SearchProductOrderedModel
                    {
                        productID = x.product.productID,
                        productVariableID = x.product.productVariableID,
                        sku = x.product.sku,
                        title = x.product.title,
                        avatar = x.product.avatar,
                        color = x.color != null ? x.color.name : String.Empty,
                        size = x.size != null ? x.size.name : String.Empty,
                        price = x.product.price,
                        createdDate = x.product.createdDate
                    });
                #endregion

                var data = products
                    .Union(productVariables)
                    .OrderByDescending(o => o.createdDate)
                    .ToList();

                return data;
            }
        }
        #endregion

        #region Màn hình tìm kiếm sản phẩm
        /// <summary>
        /// Lấy dữ liệu cho drop list sort
        /// </summary>
        /// <returns></returns>
        public List<SearchProductSortModel> getSearchProductSort()
        {
            var sort = new List<SearchProductSortModel>() {
                new SearchProductSortModel() { key = ((int)SearchProductSort.ProductNew).ToString(), name = "Mới nhập kho"},
                new SearchProductSortModel() { key = ((int)SearchProductSort.PriceAsc).ToString(), name = "Giá tăng dần"},
                new SearchProductSortModel() { key = ((int)SearchProductSort.PriceDesc).ToString(), name = "Giá giảm dần"},
                new SearchProductSortModel() { key = ((int)SearchProductSort.ModelNew).ToString(), name = "Mẩu mới nhất"},
            };

            return sort;
        }

        /// <summary>
        /// Lấy tất cả sản phẩm có chứa từ khóa
        /// </summary>
        /// <param name="search"></param>
        /// <param name="sort"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<CategoryProductModel> getSearchProductProduct(string search, int sort, ref PaginationMetadataModel pagination)
        {
            using (var con = new inventorymanagementEntities())
            {
                var source = con.tbl_Product.Where(x => x.WebPublish == true);

                #region Lọc sản phẩm theo text search
                source = con.tbl_Product
                    .Where(x =>
                        x.ProductSKU.StartsWith(search) ||
                        x.ProductTitle.StartsWith(search) ||
                        x.UnSignedTitle.StartsWith(search)
                    );
                #endregion

                #region Tính toán số lượng có trong kho hàng
                var stockFilter = con.tbl_StockManager
                    .Join(
                        source,
                        s => s.ParentID,
                        d => d.ID,
                        (s, d) => s
                    )
                    .ToList();
                var stocks = StockService.Instance.getQuantities(stockFilter);
                #endregion

                #region Xuất thông tin về sản phẩm
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
                            availability = false,
                            materials = p.Materials,
                            webUpdate = p.WebUpdate,
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
                    .Select(x => new
                    {
                        productID = x.product.productID,
                        title = x.product.title,
                        sku = x.product.sku,
                        thumbnails = Thumbnail.getALL(x.product.avatar),
                        regularPrice = x.product.regularPrice,
                        retailPrice = x.product.retailPrice,
                        availability = x.stock != null ? x.stock.availability : x.product.availability,
                        materials = x.product.materials,
                        webUpdate = x.product.webUpdate,
                        slug = x.product.slug
                    });
                #endregion

                #region Thực hiện sắp xếp sản phẩm
                if (sort == (int)CategorySort.PriceAsc)
                {
                    data = data.OrderBy(o => o.regularPrice);
                }
                else if (sort == (int)CategorySort.PriceDesc)
                {
                    data = data.OrderByDescending(o => o.regularPrice);
                }
                else if (sort == (int)CategorySort.ModelNew)
                {
                    data = data.OrderByDescending(o => o.productID);
                }
                else if (sort == (int)CategorySort.ProductNew)
                {
                    data = data.OrderByDescending(o => o.webUpdate);
                }
                else
                {
                    data = data.OrderByDescending(o => o.webUpdate);
                }
                #endregion

                #region Tính toán phân trang
                // Lấy tổng số record sản phẩm
                pagination.totalCount = data.Count();

                // Calculating Totalpage by Dividing (No of Records / Pagesize)
                pagination.totalPages = (int)Math.Ceiling(pagination.totalCount / (double)pagination.pageSize);

                // Returns List of product after applying Paging
                var result = data
                    .Select(x => new CategoryProductModel()
                    {
                        id = x.productID,
                        title = x.title,
                        sku = x.sku,
                        thumbnails = x.thumbnails,
                        regularPrice = x.regularPrice,
                        retailPrice = x.retailPrice,
                        availability = x.availability,
                        materials = x.materials,
                        slug = x.slug
                    })
                    .Skip((pagination.currentPage - 1) * pagination.pageSize)
                    .Take(pagination.pageSize)
                    .ToList();

                // if CurrentPage is greater than 1 means it has previousPage
                pagination.previousPage = pagination.currentPage > 1 ? "Yes" : "No";

                // if TotalPages is greater than CurrentPage means it has nextPage
                pagination.nextPage = pagination.currentPage < pagination.totalPages ? "Yes" : "No";
                #endregion

                return result;
            }
        }
        #endregion
    }
}