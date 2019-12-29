using ann_shop_server.Models;
using ann_shop_server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class ProductService : Service<ProductService>
    {
        #region Product Sort
        /// <summary>
        /// Product Sort
        /// </summary>
        /// <returns></returns>
        public List<ProductSortModel> getProductSort()
        {
            var sort = new List<ProductSortModel>() {
                new ProductSortModel() { key = ((int)ProductSortKind.ProductNew).ToString(), name = "Mới nhập kho"},
                new ProductSortModel() { key = ((int)ProductSortKind.PriceAsc).ToString(), name = "Giá tăng dần"},
                new ProductSortModel() { key = ((int)ProductSortKind.PriceDesc).ToString(), name = "Giá giảm dần"},
                new ProductSortModel() { key = ((int)ProductSortKind.ModelNew).ToString(), name = "Mẩu mới nhất"},
            };

            return sort;
        }
        #endregion

        #region Lấy danh sách sản phẩm
        #region Lấy thông tin biến thể màu 
        /// <summary>
        /// Lấy thông tin biến thể màu
        /// </summary>
        /// <param name="productIDs"></param>
        /// <returns></returns>
        private List<ColorModel> getColors(List<int> productIDs)
        {
            using (var con = new inventorymanagementEntities())
            {
                var variables = con.tbl_Product.Where(x => productIDs.Contains(x.ID))
                    .Join(
                        con.tbl_ProductVariable,
                        p => p.ID,
                        v => v.ProductID,
                        (p, v) => new { productID = p.ID, productVariableID = v.ID }
                    )
                    .Join(
                        con.tbl_ProductVariableValue,
                        p => p.productVariableID,
                        v => v.ProductVariableID,
                        (p, v) => new
                        {
                            productID = p.productID,
                            variableValueID = v.VariableValueID.HasValue ? v.VariableValueID.Value : 0
                        }
                    )
                    .GroupBy(x => new { x.productID, x.variableValueID })
                    .Select(x => new { productID = x.Key.productID, variableValueID = x.Key.variableValueID })
                    .Join(
                        con.tbl_VariableValue.Where(x => x.VariableID == (int)VariableType.Color),
                        p => p.variableValueID,
                        v => v.ID,
                        (p, v) => new ColorModel()
                        {
                            productID = p.productID,
                            id = v.ID,
                            name = v.VariableValue
                        }
                    )
                    .OrderBy(o => o.id)
                    .ToList();

                return variables;
            }
        }
        #endregion

        #region Lấy thông tin biến size
        /// <summary>
        /// Lấy thông tin biến size
        /// </summary>
        /// <param name="productIDs"></param>
        /// <returns></returns>
        private List<SizeModel> getSizes(List<int> productIDs)
        {
            using (var con = new inventorymanagementEntities())
            {
                var variables = con.tbl_Product.Where(x => productIDs.Contains(x.ID))
                    .Join(
                        con.tbl_ProductVariable,
                        p => p.ID,
                        v => v.ProductID,
                        (p, v) => new { productID = p.ID, productVariableID = v.ID }
                    )
                    .Join(
                        con.tbl_ProductVariableValue,
                        p => p.productVariableID,
                        v => v.ProductVariableID,
                        (p, v) => new
                        {
                            productID = p.productID,
                            variableValueID = v.VariableValueID.HasValue ? v.VariableValueID.Value : 0
                        }
                    )
                    .GroupBy(x => new { x.productID, x.variableValueID })
                    .Select(x => new { productID = x.Key.productID, variableValueID = x.Key.variableValueID })
                    .Join(
                        con.tbl_VariableValue.Where(x => x.VariableID == (int)VariableType.Size),
                        p => p.variableValueID,
                        v => v.ID,
                        (p, v) => new SizeModel()
                        {
                            productID = p.productID,
                            id = v.ID,
                            name = v.VariableValue
                        }
                    )
                    .OrderBy(o => o.id)
                    .ToList();

                return variables;
            }
        }
        #endregion

        #region Lấy danh sách sản phẩm theo điều kiện filter
        private List<ProductCardModel> getProducts(ProductFilterModel filter, ref PaginationMetadataModel pagination)
        {
            using (var con = new inventorymanagementEntities())
            {
                var source = con.tbl_Product
                    .Select(x => new {
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
                        content = x.ProductContent,
                        webPublish = x.WebPublish.HasValue ? x.WebPublish.Value : false,
                        webUpdate = x.WebUpdate,
                    });

                #region Lọc sản phẩm
                #region Lọc sản phẩm theo text search
                if (!String.IsNullOrEmpty(filter.productSearch))
                {
                    source = source
                        .Where(x =>
                            x.sku.Trim().ToLower().StartsWith(filter.productSearch.Trim().ToLower()) ||
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
                if (!String.IsNullOrEmpty(filter.productBadge))
                {
                    switch (filter.productBadge)
                    {
                        case "hang-co-san":
                            source = source.Where(x => x.preOrder == false);
                            break;
                        case "hang-order":
                            source = source.Where(x => x.preOrder == true);
                            break;
                        case "hang-sale":
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
                    var categories = CategoryService.Instance.getCategoryChild(filter.categorySlug);

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
                        var categoryChilds = CategoryService.Instance.getCategoryChild(categorySlug);

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
                var stocks = StockService.Instance.getQuantities(stockFilter);
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
                if (String.IsNullOrEmpty(filter.productSearch))
                {
                    data = data.Where(x =>
                        x.product.preOrder ||
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
                    .Select(x => new ProductCardModel()
                    {
                        productID = x.product.productID,
                        sku = x.product.sku,
                        name = x.product.title,
                        slug = x.product.slug,
                        materials = x.product.materials,
                        badge = x.product.oldPrice > 0 ? ProductBadge.sale :
                            (
                                x.product.preOrder ? ProductBadge.order :
                                   (x.stock != null && x.stock.availability ? ProductBadge.stockIn : ProductBadge.stockOut)
                            )
                        ,
                        availability = x.stock != null ? x.stock.availability : x.product.availability,
                        thumbnails = Thumbnail.getALL(x.product.avatar),
                        regularPrice = x.product.regularPrice,
                        oldPrice = x.product.oldPrice,
                        retailPrice = x.product.retailPrice,
                        content = x.product.content
                    })
                    .Skip((pagination.currentPage - 1) * pagination.pageSize)
                    .Take(pagination.pageSize)
                    .ToList();

                // if CurrentPage is greater than 1 means it has previousPage
                pagination.previousPage = pagination.currentPage > 1 ? "Yes" : "No";

                // if TotalPages is greater than CurrentPage means it has nextPage
                pagination.nextPage = pagination.currentPage < pagination.totalPages ? "Yes" : "No";
                #endregion

                #region Lấy thông tin variable
                var colors = getColors(result.Select(x => x.productID).ToList());
                var sizes = getSizes(result.Select(x => x.productID).ToList());

                foreach (var prod in result)
                {
                    prod.colors = colors.Where(x => x.productID == prod.productID).ToList();
                    prod.sizes = sizes.Where(x => x.productID == prod.productID).ToList();
                }
                #endregion

                return result;
            }
        }
        #endregion

        #region Phân trang sản phẩm theo filter của trang category
        /// <summary>
        /// Phân trang sản phẩm theo filter của trang category 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProducts(CategoryPageFilterModel category, ref PaginationMetadataModel pagination)
        {
            var filter = new ProductFilterModel()
            {
                categorySlug = category.categorySlug,
                productBadge = category.productBadge,
                productSort = category.sort,
                priceMin = category.priceMin,
                priceMax = category.priceMax
            };

            return getProducts(filter, ref pagination);
        }
        #endregion

        #region Phân trang sản phẩm theo filter của trang home
        /// <summary>
        /// Phân trang sản phẩm theo filter của trang home
        /// </summary>
        /// <param name="home"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProducts(HomePageFilterModel home, ref PaginationMetadataModel pagination)
        {
            var filter = new ProductFilterModel()
            {
                categorySlug = home.categorySlug,
                categorySlugList = home.categorySlugList,
                productSort = home.sort
            };

            return getProducts(filter, ref pagination);
        }
        #endregion

        #region Phân trang sản phẩm theo filter của trang tìm kiếm sản phẩm
        /// <summary>
        /// Phân trang sản phẩm theo filter của trang tìm kiếm sản phẩm
        /// </summary>
        /// <param name="searchProduct"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProducts(SearchProductFilterModel searchProduct, ref PaginationMetadataModel pagination)
        {
            var filter = new ProductFilterModel()
            {
                productSearch = searchProduct.search,
                productSort = searchProduct.sort
            };

            return getProducts(filter, ref pagination);
        }
        #endregion

        #region Phân trang sản phẩm theo filter của trang tag
        /// <summary>
        /// Phân trang sản phẩm theo filter của trang tag
        /// </summary>
        /// <param name="categorySlug"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProducts(TagPageFilterModel tag, ref PaginationMetadataModel pagination)
        {
            var filter = new ProductFilterModel()
            {
                tagSlug = tag.tagSlug,
                priceMin = tag.priceMin,
                priceMax = tag.priceMax,
                productSort = tag.sort
            };

            return getProducts(filter, ref pagination);
        }
        #endregion
        #endregion

        #region Lấy thông tin sản phẩm
        #region Lấy danh sách màu của sản phẩm
        /// <summary>
        /// Lấy thông tin biến thể màu
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public List<ColorModel> getColors(int productID)
        {
            return getColors(new List<int>() { productID });
        }
        #endregion

        #region Lấy danh sách size của sản phẩm
        /// <summary>
        /// Lấy thông tin biến size
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public List<SizeModel> getSizes(int productID)
        {
            return getSizes(new List<int>() { productID });
        }
        #endregion

        #region Lấy danh sách hình ảnh của sản phẩm
        /// <summary>
        /// Lấy danh sách hình ảnh của sản phẩm
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public List<string> getImageListByProduct(int productID, Thumbnail.Size size = Thumbnail.Size.Source)
        {
            using (var con = new inventorymanagementEntities())
            {
                // Lấy hình ảnh của sản phẩm cha
                var imageProduct = con.tbl_Product
                    .Where(x => x.ID == productID)
                    .Where(x => !String.IsNullOrEmpty(x.ProductImage))
                    .Select(x => new { image = x.ProductImage })
                    .ToList();
                // Lấy hình anh trong bảng image
                var imageSource = con.tbl_ProductImage.Where(x => x.ProductID == productID)
                    .Select(x => new { image = x.ProductImage })
                    .ToList();

                var images = imageProduct
                    .Union(imageSource)
                    .Select(x => x.image)
                    .Distinct()
                    .ToList();

                if (images.Count == 0)
                {
                    return new List<string>() { Thumbnail.getURL(String.Empty, size) };
                }
                else
                {
                    return images.Select(x => Thumbnail.getURL(x, size)).ToList();
                }
            }
        }
        #endregion

        #region Lấy danh sách tag của sản phẩm
        /// <summary>
        /// Lấy danh sách tag của sản phẩm
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        private List<TagModel> getTagListByProduct(int productID)
        {
            using (var con = new inventorymanagementEntities())
            {
                // Lấy hình ảnh của sản phẩm cha
                var tags = con.ProductTags
                    .Where(x => x.ProductID == productID)
                    .Where(x => x.ProductVariableID == 0)
                    .Join(
                        con.Tags,
                        pt => pt.TagID,
                        t => t.ID,
                        (pt, t) => new TagModel()
                        {
                            id = t.ID,
                            name = t.Name,
                            slug = t.Slug
                        }
                    )
                    .ToList();

                return tags;
            }
        }
        #endregion

        #region Lấy thông tin sản phẩm theo slug
        /// <summary>
        /// Lấy thông tin sản phẩm theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public ProductModel getProductByCategory(string slug)
        {
            using (var con = new inventorymanagementEntities())
            {
                // Kiểm tra có sản phẩm không
                var data = con.tbl_Product.Where(x => x.Slug == slug);

                if (data.FirstOrDefault() == null)
                    return null;

                // Lấy ID sản phẩm
                var id = data.FirstOrDefault().ID;

                // Get quantity
                var stockFilter = con.tbl_StockManager
                    .Join(
                        data,
                        s => s.ParentID,
                        d => d.ID,
                        (s, d) => s
                    )
                    .OrderBy(x => new { x.ParentID, x.ProductID, x.ProductVariableID })
                    .ToList();
                var stocks = StockService.Instance.getQuantities(stockFilter);

                // Get info variable
                var colors = getColors(id);
                var sizes = getSizes(id);

                // Get images of product
                var images = getImageListByProduct(id);

                // Get tags of product
                var tags = getTagListByProduct(id);

                // Xuất thông tin cơ bản của sản phẩm
                var products = data.Where(x => x.CategoryID.HasValue)
                    .Join(
                        con.tbl_Category,
                        pro => pro.CategoryID.Value,
                        cat => cat.ID,
                        (p, c) => new
                        {
                            id = p.ID,
                            categoryName = c.CategoryName,
                            categorySlug = c.Slug,
                            name = p.ProductTitle,
                            sku = p.ProductSKU,
                            avatar = p.ProductImage,
                            materials = p.Materials,
                            regularPrice = p.Regular_Price.HasValue ? p.Regular_Price.Value : 0,
                            oldPrice = p.Old_Price.HasValue ? p.Old_Price.Value : 0,
                            retailPrice = p.Retail_Price.HasValue ? p.Retail_Price.Value : 0,
                            content = p.ProductContent,
                            slug = p.Slug,
                            preOrder = p.PreOrder
                        }
                    )
                    .OrderBy(x => x.id)
                    .ToList();

                // Lấy tất cả thông tin về sản phẩm
                var result = products
                    .GroupJoin(
                        stocks,
                        pro => pro.id,
                        info => info.productID,
                        (pro, info) => new { pro, info }
                    )
                    .SelectMany(
                        x => x.info.DefaultIfEmpty(),
                        (parent, child) => new ProductModel()
                        {
                            id = parent.pro.id,
                            categorySlug = parent.pro.categorySlug,
                            categoryName = parent.pro.categoryName,
                            name = parent.pro.name,
                            sku = parent.pro.sku,
                            avatar = parent.pro.avatar,
                            thumbnails = Thumbnail.getALL(parent.pro.avatar),
                            materials = parent.pro.materials,
                            regularPrice = parent.pro.regularPrice,
                            oldPrice = parent.pro.oldPrice,
                            retailPrice = parent.pro.retailPrice,
                            content = parent.pro.content,
                            slug = parent.pro.slug,
                            images = images,
                            colors = colors,
                            sizes = sizes,
                            badge = parent.pro.oldPrice > 0 ? ProductBadge.sale :
                                (
                                    parent.pro.preOrder ?
                                    ProductBadge.order :
                                    (
                                        child == null ?
                                            ProductBadge.stockOut :
                                            (child.availability ? ProductBadge.stockIn : ProductBadge.stockOut)
                                    )
                                ),
                            tags = tags
                        }
                    )
                    .OrderBy(o => o.id)
                    .ToList();

                return result.FirstOrDefault();
            }
        }
        #endregion

        #region Đặt tên cho sản phẩm con theo color - màu
        /// <summary>
        /// Đặt tên cho sản phẩm con theo color - màu
        /// </summary>
        /// <param name="color"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private string getVariableName(string color, string size)
        {
            var strColor = !String.IsNullOrEmpty(color) ? String.Format("-{0}", color) : String.Empty;
            var strSize = !String.IsNullOrEmpty(size) ? String.Format("-{0}", size) : String.Empty;
            var result = String.Concat(strColor, strSize);

            if (!String.IsNullOrEmpty(result) && result.Length > 1)
            {
                return result.Substring(1);
            }
            else
            {
                return String.Empty;
            }
        }
        #endregion

        #region Lấy thông tin các sản phẩm con
        /// <summary>
        /// Lấy thông tin các sản phẩm con
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductRelatedModel> getProductRelatedBySlug(string slug, ref PaginationMetadataModel pagination)
        {
            using (var con = new inventorymanagementEntities())
            {
                // Kiểm tra có sản phẩm không
                var product = con.tbl_Product.Where(x => x.Slug == slug).FirstOrDefault();

                if (product == null)
                    return null;

                // Returns List of Customer after applying Paging
                var source = con.tbl_ProductVariable
                    .Where(x => x.ProductID == product.ID)
                    .OrderBy(o => o.ID);

                // Display TotalCount to Records to Product
                pagination.totalCount = source.Count();

                // Calculating Totalpage by Dividing (No of Records / Pagesize)
                pagination.totalPages = (int)Math.Ceiling(pagination.totalCount / (double)pagination.pageSize);

                // if CurrentPage is greater than 1 means it has previousPage
                pagination.previousPage = pagination.currentPage > 1 ? "Yes" : "No";

                // if TotalPages is greater than CurrentPage means it has nextPage
                pagination.nextPage = pagination.currentPage < pagination.totalPages ? "Yes" : "No";

                // Returns List of Customer after applying Paging
                var data = source
                    .Skip((pagination.currentPage - 1) * pagination.pageSize)
                    .Take(pagination.pageSize);

                // Get quantity
                var stockFilter = con.tbl_StockManager
                    .Join(
                        data,
                        s => new { productID = s.ParentID.Value, productVariableID = s.ProductVariableID.Value },
                        d => new { productID = d.ProductID.Value, productVariableID = d.ID },
                        (s, d) => s
                    )
                    .OrderBy(x => new { x.ParentID, x.ProductID, x.ProductVariableID })
                    .ToList();

                var stocks = StockService.Instance.getProductVariableQuantities(stockFilter);

                // Get info variable of product
                var infoVariable = data
                    .GroupJoin(
                        con.tbl_ProductVariableValue,
                        d => d.ID,
                        v => v.ProductVariableID,
                        (d, v) => new { d, v }
                    )
                    .SelectMany(
                        x => x.v.DefaultIfEmpty(),
                        (parent, child) => new
                        {
                            id = parent.d.ID,
                            variableID = child != null ? child.VariableValueID : 0
                        }
                    )
                    .GroupJoin(
                        con.tbl_VariableValue,
                        d => d.variableID,
                        v => v.ID,
                        (d, v) => new { d, v }
                    )
                    .SelectMany(
                        x => x.v.DefaultIfEmpty(),
                        (parent, child) => new
                        {
                            id = parent.d.id,
                            variableID = child != null ? child.VariableID : 0,
                            variableName = child != null ? child.VariableValue : String.Empty
                        }
                    )
                    .Select(x => new
                    {
                        id = x.id,
                        color = x.variableID == 1 ? x.variableName : String.Empty,
                        size = x.variableID == 2 ? x.variableName : String.Empty,
                    }
                    )
                    .GroupBy(x => x.id)
                    .Select(g => new
                    {
                        id = g.Key,
                        color = g.Max(x => x.color),
                        size = g.Max(x => x.size)
                    }
                    );

                var productVariable = data
                    .Join(
                        infoVariable,
                        d => d.ID,
                        v => v.id,
                        (d, v) => new
                        {
                            id = d.ID,
                            sku = d.SKU,
                            avatar = d.Image,
                            color = v.color,
                            size = v.size,
                        }
                    )
                    .ToList();

                var result = productVariable
                    .GroupJoin(
                        stocks,
                        pv => pv.sku,
                        s => s.sku,
                        (pv, s) => new { productVariable = pv, stock = s }
                    )
                    .SelectMany(
                        x => x.stock.DefaultIfEmpty(),
                        (parent, child) => new { productVariable = parent.productVariable, stock = child }
                    )
                    .Select(x => new ProductRelatedModel()
                    {
                        id = x.productVariable.id,
                        name = getVariableName(x.productVariable.color, x.productVariable.size),
                        sku = x.productVariable.sku,
                        avatar = Thumbnail.getURL(x.productVariable.avatar, Thumbnail.Size.Source),
                        badge = product.Old_Price.HasValue && product.Old_Price.Value > 0 ? ProductBadge.sale :
                            (
                                product.PreOrder ? ProductBadge.order :
                                (
                                    x.stock == null ? ProductBadge.stockOut :
                                        (x.stock.availability ? ProductBadge.stockIn : ProductBadge.stockOut)
                                )
                            )
                    })
                    .OrderBy(x => x.id)
                    .ToList();

                return result;
            }
        }
        #endregion

        #region Trà về hình ảnh tưởng chưng cho biến thể
        /// <summary>
        /// Trà về hình ảnh tưởng chưng cho biến thể
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="variables"></param>
        /// <returns></returns>
        public string getImageWithVariable(int productID, int color, int size)
        {
            if (color == 0 && size == 0)
                return null;

            using (var con = new inventorymanagementEntities())
            {
                var productVariable = con.tbl_ProductVariable
                    .Where(x => x.ProductID == productID)
                    .Select(x => new
                    {
                        productVariableID = x.ID,
                        avatar = x.Image
                    });

                var colors = productVariable
                    .Join(
                        con.tbl_ProductVariableValue.Where(x => x.VariableValueID.Value == color),
                        p => p.productVariableID,
                        vv => vv.ProductVariableID.Value,
                        (p, vv) => new { productVariableID = p.productVariableID }
                    );

                var sizes = productVariable
                    .Join(
                        con.tbl_ProductVariableValue.Where(x => x.VariableValueID.Value == size),
                        p => p.productVariableID,
                        vv => vv.ProductVariableID.Value,
                        (p, vv) => new { productVariableID = p.productVariableID }
                    );

                var images = productVariable;

                if (color > 0)
                    images = images.Join(colors, i => i.productVariableID, c => c.productVariableID, (i, c) => i);
                if (size > 0)
                    images = images.Join(sizes, i => i.productVariableID, s => s.productVariableID, (i, s) => i);

                return images.ToList().Select(x => Thumbnail.getURL(x.avatar, Thumbnail.Size.Source)).FirstOrDefault();
            }
        }
        #endregion

        #region Lấy danh sách hình ảnh của sản phẩm dùng cho download image
        /// <summary>
        /// Lấy danh sách hình ảnh của sản phẩm dùng cho download image
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public List<string> getAdvertisementImages(int productID)
        {
            using (var con = new inventorymanagementEntities())
            {
                // Lấy hình ảnh của sản phẩm cha
                var imageProduct = con.tbl_Product
                    .Where(x => x.ID == productID)
                    .Where(x => !String.IsNullOrEmpty(x.ProductImage))
                    .Select(x => new { image = x.ProductImage })
                    .ToList();
                // Lấy hình ảnh đại diện của các sản phẩm con
                var imageProductVariable = con.tbl_ProductVariable
                    .Where(x => x.ProductID == productID)
                    .Where(x => !String.IsNullOrEmpty(x.Image))
                    .Select(x => new { image = x.Image })
                    .ToList();
                // Lấy hình anh trong bảng image
                var imageSource = con.tbl_ProductImage.Where(x => x.ProductID == productID)
                    .Select(x => new { image = x.ProductImage })
                    .ToList();

                var images = imageProduct
                    .Union(imageProductVariable)
                    .Union(imageSource)
                    .Select(x => x.image)
                    .Distinct()
                    .ToList();

                if (images.Count == 0)
                {
                    return null;
                }
                else
                {
                    return images.Select(x => Thumbnail.getURL(x, Thumbnail.Size.Source)).ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}