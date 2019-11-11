using ann_shop_server.Models;
using ann_shop_server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ann_shop_server.Services
{
    public class ProductPageService : Service<ProductPageService>
    {
        #region get
        #region Lấy thông tin sản phẩm theo slug
        /// <summary>
        /// Lấy thông tin sản phẩm theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public ProductProductModel getProduct(string slug)
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
                var images = getImages(id);

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
                        (parent, child) => new ProductProductModel()
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
                            retailPrice = parent.pro.retailPrice,
                            content = parent.pro.content,
                            slug = parent.pro.slug,
                            images = images,
                            colors = colors,
                            sizes = sizes,
                            badge = parent.pro.preOrder ? 
                                ProductBadge.order : 
                                (
                                    child == null ? 
                                        ProductBadge.stockOut : 
                                        (child.availability ? ProductBadge.stockIn : ProductBadge.stockOut)
                                )
                        }
                    )
                    .OrderBy(o => o.id)
                    .ToList();

                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// Lấy danh sách hình ảnh của sản phẩm
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        private List<string> getImages(int productID)
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
                    return new List<string>() { Thumbnail.getURL(String.Empty, Thumbnail.Size.Source) };
                }
                else
                {
                    return images.Select(x => Thumbnail.getURL(x, Thumbnail.Size.Source)).ToList();
                }
            }
        }

        /// <summary>
        /// Lấy thông tin biến thể màu
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private List<ProductColorModel> getColors(int parentID)
        {
            using (var con = new inventorymanagementEntities())
            {
                var variables = con.tbl_Product.Where(x => x.ID == parentID)
                    .Join(
                        con.tbl_ProductVariable,
                        p => p.ID,
                        v => v.ProductID,
                        (p, v) => v
                    )
                    .Join(
                        con.tbl_ProductVariableValue,
                        p => p.ID,
                        v => v.ProductVariableID,
                        (p, v) => new
                        {
                            VariableValueID = v.VariableValueID.HasValue ? v.VariableValueID.Value : 0
                        }
                    )
                    .GroupBy(x => x.VariableValueID)
                    .Select(x => new { VariableValueID = x.Key })
                    .Join(
                        con.tbl_VariableValue.Where(x => x.VariableID == (int)VariableType.Color),
                        p => p.VariableValueID,
                        v => v.ID,
                        (p, v) => v
                    )
                    .OrderBy(o => o.ID)
                    .Select(x => new ProductColorModel()
                    {
                        id = x.ID,
                        name = x.VariableValue
                    }
                    )
                    .ToList();

                return variables;
            }
        }

        /// <summary>
        /// Lấy thông tin biến size
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private List<ProductSizeModel> getSizes(int parentID)
        {
            using (var con = new inventorymanagementEntities())
            {
                var variables = con.tbl_Product.Where(x => x.ID == parentID)
                    .Join(
                        con.tbl_ProductVariable,
                        p => p.ID,
                        v => v.ProductID,
                        (p, v) => v
                    )
                    .Join(
                        con.tbl_ProductVariableValue,
                        p => p.ID,
                        v => v.ProductVariableID,
                        (p, v) => new
                        {
                            VariableValueID = v.VariableValueID.HasValue ? v.VariableValueID.Value : 0
                        }
                    )
                    .GroupBy(x => x.VariableValueID)
                    .Select(x => new { VariableValueID = x.Key })
                    .Join(
                        con.tbl_VariableValue.Where(x => x.VariableID == (int)VariableType.Size),
                        p => p.VariableValueID,
                        v => v.ID,
                        (p, v) => v
                    )
                    .OrderBy(o => o.ID)
                    .Select(x => new ProductSizeModel()
                    {
                        id = x.ID,
                        name = x.VariableValue
                    }
                    )
                    .ToList();

                return variables;
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
        public List<ProductRelatedModel> getProductRelated(string slug, ref PaginationMetadataModel pagination)
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
                        badge = product.PreOrder ? 
                            ProductBadge.order : 
                            (
                                x.stock == null ?
                                    ProductBadge.stockOut :
                                    (x.stock.availability ? ProductBadge.stockIn : ProductBadge.stockOut)
                            )
                    })
                    .OrderBy(x => x.id)
                    .ToList();

                return result;
            }
        }

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

        /// <summary>
        /// Trà về hình ảnh tưởng chưng cho biến thể
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="variables"></param>
        /// <returns></returns>
        public string getImageWithVariable(int productID, int color, int size)
        {
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

        /// <summary>
        /// Lấy danh sách hình ảnh của sản phẩm
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
    }
}