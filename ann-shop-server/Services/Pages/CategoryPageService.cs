using ann_shop_server.Models;
using ann_shop_server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ann_shop_server.Services
{
    public class CategoryPageService : Service<CategoryPageService>
    {
        #region get
        /// <summary>
        /// Lấy thông tin category theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public CategoryCategoryModel getCategory(string slug)
        {
            using (var con = new inventorymanagementEntities())
            {
                var parent = con.tbl_Category
                    .Where(x =>
                        (!String.IsNullOrEmpty(slug) && x.Slug == slug) ||
                        (String.IsNullOrEmpty(slug) && x.CategoryLevel == 0)
                    )
                    .Select(x => new CategoryCategoryModel()
                    {
                        name = x.CategoryName,
                        slug = x.Slug
                    })
                    .FirstOrDefault();

                return parent;
            }
        }

        /// <summary>
        /// Lấy dữ liệu cho drop list sort
        /// </summary>
        /// <returns></returns>
        public List<CategorySortModel> getSort()
        {
            var sort = new List<CategorySortModel>() {
                new CategorySortModel() { key = ((int)CategorySort.ProductNew).ToString(), name = "Mới nhập kho"},
                new CategorySortModel() { key = ((int)CategorySort.PriceAsc).ToString(), name = "Giá tăng dần"},
                new CategorySortModel() { key = ((int)CategorySort.PriceDesc).ToString(), name = "Giá giảm dần"},
                new CategorySortModel() { key = ((int)CategorySort.ModelNew).ToString(), name = "Mẩu mới nhất"},
            };

            return sort;
        }

        /// <summary>
        /// Lấy tất cả sản phẩm thuộc nhánh slug
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<CategoryProductModel> getProduct(string slug, int sort, ref PaginationMetadataModel pagination)
        {
            using (var con = new inventorymanagementEntities())
            {
                var source = con.tbl_Product.Where(x => x.PreOrder || x.WebPublish == true);

                #region Lọc sản phẩm theo category
                if (!String.IsNullOrEmpty(slug))
                {
                    var categories = CategoryService.Instance.getCategoryChild(slug);

                    if (categories == null || categories.Count == 0)
                        return null;

                    var categoryIDs = categories.Select(x => x.id).OrderByDescending(o => o).ToList();

                    source = source.Where(x => categoryIDs.Contains(x.CategoryID.Value));
                }
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
                            webPublish = p.WebPublish.HasValue ? p.WebPublish.Value : false,
                            webUpdate = p.WebUpdate,
                            slug = p.Slug,
                            preOrder = p.PreOrder
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
                    .Where(x =>
                        x.product.preOrder ||
                        (
                            x.product.webPublish &&
                            x.stock != null &&
                            x.stock.quantity >= 5
                        )
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
                        slug = x.product.slug,
                        preOrder = x.product.preOrder
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
                        name = x.title,
                        sku = x.sku,
                        thumbnails = x.thumbnails,
                        regularPrice = x.regularPrice,
                        retailPrice = x.retailPrice,
                        materials = x.materials,
                        slug = x.slug,
                        badge = x.preOrder ? ProductBadge.order : (x.availability ? ProductBadge.stockIn : ProductBadge.stockOut)
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

        /// <summary>
        /// Lấy tất cả sản phẩm có chứa từ khóa
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<CategoryProductModel> getProduct(int sort, ref PaginationMetadataModel pagination)
        {
            using (var con = new inventorymanagementEntities())
            {
                var source = con.tbl_Product.Where(x => x.PreOrder || x.WebPublish == true);

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
                            webPublish = p.WebPublish.HasValue ? p.WebPublish.Value : false,
                            webUpdate = p.WebUpdate,
                            slug = p.Slug,
                            preOrder = p.PreOrder
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
                    .Where(x =>
                        x.product.preOrder ||
                        (
                            x.product.webPublish &&
                            x.stock != null &&
                            x.stock.quantity >= 5
                        )
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
                        slug = x.product.slug,
                        preOrder = x.product.preOrder
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
                        name = x.title,
                        sku = x.sku,
                        thumbnails = x.thumbnails,
                        regularPrice = x.regularPrice,
                        retailPrice = x.retailPrice,
                        materials = x.materials,
                        slug = x.slug,
                        badge = x.preOrder ? ProductBadge.order : (x.availability ? ProductBadge.stockIn : ProductBadge.stockOut)
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