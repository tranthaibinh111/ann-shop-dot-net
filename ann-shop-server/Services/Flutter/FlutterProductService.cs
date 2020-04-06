using ann_shop_server.Models;
using ann_shop_server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterProductService : ProductService
    {
        #region Lấy danh sách sản phẩm
        /// <summary>
        /// Lấy danh sách sản phẩm theo filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<FlutterProductCardModel> getProducts(FlutterProductFilterModel filter, ref PaginationMetadataModel pagination)
        {
            using (var con = new inventorymanagementEntities())
            {
                var source = con.tbl_Product
                    .Select(x => new
                    {
                        categoryID = x.CategoryID.HasValue ? x.CategoryID.Value : 0,
                        productID = x.ID,
                        sku = x.ProductSKU,
                        title = x.ProductTitle,
                        unSignedTitle = x.UnSignedTitle,
                        slug = x.Slug,
                        materials = x.Materials,
                        preOrder = x.PreOrder,
                        availability = false,
                        avatar = x.ProductImage,
                        regularPrice = x.Regular_Price.HasValue ? x.Regular_Price.Value : 0,
                        oldPrice = x.Old_Price.HasValue ? x.Old_Price.Value : 0,
                        retailPrice = x.Retail_Price.HasValue ? x.Retail_Price.Value : 0,
                        webPublish = x.WebPublish.HasValue ? x.WebPublish.Value : false,
                        webUpdate = x.WebUpdate,
                    });

                #region Lọc sản phẩm
                #region Lọc sản phẩm theo text search
                if (!String.IsNullOrEmpty(filter.productSKU))
                {
                    // Lọc trước những sản phẩm con có chứa productSKU
                    var variableFilter = con.tbl_ProductVariable.Where(x =>
                            x.SKU.Trim().ToLower().StartsWith(filter.productSKU.Trim().ToLower())
                        )
                        .Select(x => new {
                            productID = x.ProductID.Value,
                            sku = x.SKU
                        });

                    var productFilter = source.Select(x => new {
                            productID = x.productID,
                            sku = x.sku
                        })
                        .GroupJoin(
                            variableFilter,
                            p => p.productID,
                            v => v.productID,
                            (p, v) => new { product = p, variable = v }
                        )
                        .SelectMany(
                            x => x.variable.DefaultIfEmpty(),
                            (parent, child) => new {
                                productID = parent.product.productID,
                                productSKU = parent.product.sku,
                                variableSKU = child != null ? child.sku : ""
                            }
                        )
                        .Where(x => 
                            x.productSKU.Trim().ToLower() == filter.productSKU.Trim().ToLower() ||
                            x.variableSKU.Trim().ToLower() == filter.productSKU.Trim().ToLower()
                        )
                        .Select(x => new { productID = x.productID, sku = x.productSKU })
                        .Distinct();

                    source = source.Join(productFilter, s => s.productID, f => f.productID, (s, f) => s);
                }
                else if (!String.IsNullOrEmpty(filter.productSearch))
                {
                    source = source
                        .Where(x =>
                            (
                                (
                                    x.sku.Trim().Length >= filter.productSearch.Trim().Length &&
                                    x.sku.Trim().ToLower().StartsWith(filter.productSearch.Trim().ToLower())
                                ) ||
                                (
                                     x.sku.Trim().Length < filter.productSearch.Trim().Length &&
                                    filter.productSearch.Trim().ToLower().StartsWith(x.sku.Trim().ToLower())
                                )
                            ) ||
                            x.title.Trim().ToLower().Contains(filter.productSearch.Trim().ToLower()) ||
                            x.unSignedTitle.Trim().ToLower().Contains(filter.productSearch.Trim().ToLower())
                        );
                }
                else
                {
                    // Trường hợp không phải là search thì kiểm tra điều web public
                    source = source.Where(x => x.webPublish == true);
                }
                #endregion

                #region Lọc sản phẩm theo tag slug
                if (!String.IsNullOrEmpty(filter.tagSlug))
                {
                    var tags = con.Tags.Where(x => x.Slug == filter.tagSlug.Trim().ToLower());
                    var prodTags = con.ProductTags
                        .Join(
                            tags,
                            pt => pt.TagID,
                            t => t.ID,
                            (pt, t) => pt
                        );

                    source = source
                        .Join(
                            prodTags,
                            p => p.productID,
                            t => t.ProductID,
                            (p, t) => p
                        );
                }
                #endregion

                #region Lấy theo preOrder (hang-co-san | hang-order)
                if (filter.productBadge > 0)
                {
                    switch (filter.productBadge)
                    {
                        case (int)ProductBadge.stockIn:
                            source = source.Where(x => x.preOrder == false);
                            break;
                        case (int)ProductBadge.order:
                            source = source.Where(x => x.preOrder == true);
                            break;
                        case (int)ProductBadge.sale:
                            source = source.Where(x => x.oldPrice > 0);
                            break;
                        default:
                            break;
                    }
                }
                #endregion

                #region Lấy theo wholesale price
                if (filter.priceMin > 0)
                {
                    source = source.Where(x => x.regularPrice >= filter.priceMin);
                }
                if (filter.priceMax > 0)
                {
                    source = source.Where(x => x.regularPrice <= filter.priceMax);
                }
                #endregion

                #region Lấy theo category slug
                if (!String.IsNullOrEmpty(filter.categorySlug))
                {
                    var categories = _category.getCategoryChild(filter.categorySlug);

                    if (categories == null || categories.Count == 0)
                        return null;

                    var categoryIDs = categories.Select(x => x.id).OrderByDescending(o => o).ToList();
                    source = source.Where(x => categoryIDs.Contains(x.categoryID));
                }
                #endregion

                #region Lấy theo category slug
                if (filter.categorySlugList != null && filter.categorySlugList.Count > 0)
                {
                    var categories = new List<CategoryModel>();

                    foreach (var categorySlug in filter.categorySlugList)
                    {
                        var categoryChilds = _category.getCategoryChild(categorySlug);

                        if (categoryChilds == null || categoryChilds.Count == 0)
                            continue;

                        categories.AddRange(categoryChilds);
                    }

                    if (categories == null || categories.Count == 0)
                        return null;

                    var categoryIDs = categories.Select(x => x.id).Distinct().OrderByDescending(o => o).ToList();
                    source = source.Where(x => categoryIDs.Contains(x.categoryID));
                }
                #endregion

                #region Lấy thông tin sản phẩm và stock
                var stockFilter = con.tbl_StockManager
                    .Join(
                        source,
                        s => s.ParentID,
                        d => d.productID,
                        (s, d) => s
                    )
                    .ToList();
                var stocks = _stock.getQuantities(stockFilter);
                #endregion

                #region Lấy sản phẩm đạt yêu cầu
                var data = source
                    .ToList()
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
                    .Select(x => new { x.product, x.stock });

                // Trường hợp không phải là search thì kiểm tra điều kiện stock
                if (String.IsNullOrEmpty(filter.productSKU) && String.IsNullOrEmpty(filter.productSearch))
                {
                    data = data.Where(x =>
                        x.product.preOrder ||
                        x.stock == null ||
                        (
                            x.stock != null &&
                            x.stock.quantity >= (x.product.categoryID == 44 ? 1 : 5)
                        )
                    );
                }
                #endregion
                #endregion

                #region Thực hiện sắp xếp sản phẩm
                if (filter.productSort == (int)ProductSortKind.PriceAsc)
                {
                    data = data.OrderBy(o => o.product.regularPrice);
                }
                else if (filter.productSort == (int)ProductSortKind.PriceDesc)
                {
                    data = data.OrderByDescending(o => o.product.regularPrice);
                }
                else if (filter.productSort == (int)ProductSortKind.ModelNew)
                {
                    data = data.OrderByDescending(o => o.product.productID);
                }
                else if (filter.productSort == (int)ProductSortKind.ProductNew)
                {
                    data = data.OrderByDescending(o => o.product.webUpdate);
                }
                else
                {
                    data = data.OrderByDescending(o => o.product.webUpdate);
                }
                #endregion

                #region Thực hiện phân trang
                // Lấy tổng số record sản phẩm
                pagination.totalCount = data.Count();

                // Calculating Totalpage by Dividing (No of Records / Pagesize)
                pagination.totalPages = (int)Math.Ceiling(pagination.totalCount / (double)pagination.pageSize);

                // Returns List of product after applying Paging
                var result = data
                    .Select(x => new FlutterProductCardModel()
                    {
                        productID = x.product.productID,
                        sku = x.product.sku,
                        name = x.product.title,
                        slug = x.product.slug,
                        materials = x.product.materials,
                        badge = x.stock == null ? ProductBadge.warehousing :
                            (x.product.oldPrice > 0 ? ProductBadge.sale :
                                (x.product.preOrder ? ProductBadge.order :
                                    (x.stock.availability ? ProductBadge.stockIn : ProductBadge.stockOut))),
                        availability = x.stock != null ? x.stock.availability : x.product.availability,
                        avatar = Thumbnail.getURL(x.product.avatar, Thumbnail.Size.Small),
                        
                        regularPrice = x.product.regularPrice,
                        oldPrice = x.product.oldPrice,
                        retailPrice = x.product.retailPrice
                    })
                    .Skip((pagination.currentPage - 1) * pagination.pageSize)
                    .Take(pagination.pageSize)
                    .ToList();

                result = result.Select(x =>
                {
                    x.images = base.getImageListByProduct(x.productID, Thumbnail.Size.Large).Skip(0).Take(8).ToList();
                    return x;
                }).ToList();

                // if CurrentPage is greater than 1 means it has previousPage
                pagination.previousPage = pagination.currentPage > 1 ? "Yes" : "No";

                // if TotalPages is greater than CurrentPage means it has nextPage
                pagination.nextPage = pagination.currentPage < pagination.totalPages ? "Yes" : "No";
                #endregion

                return result;
            }
        }
        #endregion

        #region Lấy thông tin sản phẩm
        #region Lấy thông tin sản phẩm theo slug
        /// <summary>
        /// Lấy thông tin sản phẩm theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public new FlutterProductModel getProductBySlug(string slug)
        {
            var data = base.getProductBySlug(slug);
            
            if (data != null)
            {
                var images = new List<FlutterCarouselModel>();

                foreach (var url in data.images)
                {
                    var imageOrigin = ANNImage.extractImage(url);

                    if (!String.IsNullOrEmpty(imageOrigin))
                    {
                        images.Add(new FlutterCarouselModel()
                        {
                            origin = Thumbnail.getURL(imageOrigin, Thumbnail.Size.Source),
                            feature = Thumbnail.getURL(imageOrigin, Thumbnail.Size.Large),
                            thumbnail = Thumbnail.getURL(imageOrigin, Thumbnail.Size.Micro),
                        });
                    }
                }

                var product = new FlutterProductModel()
                {
                    productID = data.id,
                    categoryName = data.categoryName,
                    categorySlug = data.categorySlug,
                    name = data.name,
                    slug = data.slug,
                    sku = data.sku,
                    avatar = Thumbnail.getURL(data.avatar, Thumbnail.Size.Source),
                    carousel = images.Count > 0 ? images : null,
                    colors = data.colors,
                    sizes = data.sizes,
                    materials = data.materials,
                    regularPrice = data.regularPrice,
                    oldPrice = data.oldPrice,
                    retailPrice = data.retailPrice,
                    badge = data.badge,
                    tags = data.tags,
                    discounts = new List<FlutterDiscountModel>()
                    {
                        new FlutterDiscountModel() { name = "Dưới 30 cái", price = data.regularPrice },
                        new FlutterDiscountModel() { name = "Từ 30 cái", price = data.regularPrice - 3000},
                        new FlutterDiscountModel() { name = "Từ 50 cái", price = data.regularPrice - 5000},
                        new FlutterDiscountModel() { name = "Từ 70 cái", price = data.regularPrice - 7000},
                        new FlutterDiscountModel() { name = "Từ 100 cái", price = data.regularPrice - 10000},
                        new FlutterDiscountModel() { name = "Từ 200 cái", price = data.regularPrice - 12000},
                        new FlutterDiscountModel() { name = "Từ 500 cái", price = data.regularPrice - 15000},
                    },
                    content = data.content,
                };

                return product;
            }

            return null;
        }
        #endregion

        #region Lấy thông tin quảng cáo sản phẩm
        /// <summary>
        /// Lấy thông tin quảng cáo sản phẩm
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public string getAdvertisementContent(int productID, FlutterCopyModel setting)
        {
            using (var con = new inventorymanagementEntities())
            {
                string[] zaloShop = { "0918567409", "0913268406", "0936786404", "0918569400" };

                var product = con.tbl_Product.Where(x => x.ID == productID).FirstOrDefault();

                if (product == null)
                    return null;

                // Khởi tạo nội dung quảng cáo
                var content = new StringBuilder();

                if (setting.showSKU && setting.showProductName)
                {
                    content.AppendLine(String.Format("🔰 {0} - {1}", product.ProductSKU, product.ProductTitle));
                    content.AppendLine();
                    content.AppendLine();
                }
                else if(setting.showSKU && !setting.showProductName)
                {
                    content.AppendLine(String.Format("🔰 {0}", product.ProductSKU));
                    content.AppendLine();
                    content.AppendLine();
                }
                else if (!setting.showSKU && setting.showProductName)
                {
                    content.AppendLine(String.Format("🔰 {0}", product.ProductTitle));
                    content.AppendLine();
                    content.AppendLine();
                }
                if (!String.IsNullOrEmpty(setting.shopPhone) && zaloShop.Contains(setting.shopPhone))
                {
                    content.AppendLine(String.Format("📌 Giá sỉ: {0:N0}k", product.Regular_Price.Value / 1000));
                    content.AppendLine();
                    content.AppendLine(String.Format("📌 Giá lẻ: {0:N0}k", product.Retail_Price.Value / 1000));
                }
                else
                {
                    content.AppendLine(String.Format("📌 #{0:N0}k", (product.Regular_Price.HasValue ? product.Regular_Price.Value + setting.increntPrice : setting.increntPrice) / 1000));
                }

                content.AppendLine();
                content.AppendLine();
                content.AppendLine(String.Format("☘ {0}", product.Materials));
                content.AppendLine();
                content.AppendLine();
                content.AppendLine(String.Format("☘ {0}", String.IsNullOrEmpty(product.ProductContent) ? String.Empty : Regex.Replace(product.ProductContent, @"<.*?>", String.Empty)));

                var colors = base.getColors(productID);
                if (colors.Count > 0)
                {
                    var strColor = String.Empty;
                    foreach (var item in colors)
                    {
                        if (!Regex.Match(item.name, @"^Mẫu.*$").Success)
                            strColor += String.Format(" {0};", item.name);
                    }

                    if (!String.IsNullOrEmpty(strColor))
                    {
                        content.AppendLine();
                        content.AppendLine();
                        content.AppendLine(String.Format("📚 Màu: {0}", strColor));
                    }
                }

                var size = base.getSizes(productID);
                if (size.Count > 0)
                {
                    var strSize = String.Empty;
                    foreach (var item in size)
                    {
                        if (!Regex.Match(item.name, @"^Mẫu.*$").Success)
                            strSize += String.Format(" {0};", item.name);
                    }

                    if (!String.IsNullOrEmpty(strSize))
                    {
                        content.AppendLine();
                        content.AppendLine();
                        content.AppendLine(String.Format("📚 Size: {0}", strSize));
                    }
                }

                if (!String.IsNullOrEmpty(setting.shopPhone) && !zaloShop.Contains(setting.shopPhone))
                {
                    content.AppendLine();
                    content.AppendLine();
                    content.AppendLine(String.Format("📞 {0}", setting.shopPhone));
                }
                if (!String.IsNullOrEmpty(setting.shopAddress) && !zaloShop.Contains(setting.shopPhone))
                {
                    content.AppendLine();
                    content.AppendLine(String.Format("🏠 {0}", setting.shopAddress));
                }

                if (zaloShop.Contains(setting.shopPhone) && product.ID % 5 == 0)
                {
                    content.AppendLine();
                    content.AppendLine();
                    content.AppendLine(String.Format("📞 Hotline/Zalo: {0}", setting.shopPhone));
                    content.AppendLine();
                    content.AppendLine(String.Format("🏠 68 Đường C12, P. 13, Tân Bình, TP.HCM"));
                }
                return HttpUtility.HtmlDecode(content.ToString());
            }
        }
        #endregion
        #endregion
    }
}