﻿using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ann_shop_server.Services
{
    public class ProductService : Service<ProductService>
    {
        public ProductPageModel getProducts(int categoryID, int pageNumber, int pageSize, string search)
        {
            using (var con = new inventorymanagementEntities())
            {
                var source = con.tbl_Product.Where(x => x.WebPublish == true).OrderByDescending(o => o.ID);

                if (categoryID != 0)
                {
                    // Trường hợp đặt biệt: Đối ưng đệ quy cho sql server
                    var categories = new List<ProductCategoryModel>();
                    categories.AddRange(ProductCategoryService.Instance.getCategoryChild(con, categoryID));
                    var categoryIDs = categories.Select(x => x.id).OrderByDescending(o => o).ToList();

                    source = source
                        .Where(x => x.WebPublish == true)
                        .Where(x => categoryIDs.Contains(x.CategoryID.Value))
                        .OrderByDescending(o => o.ID);
                }

                if (!String.IsNullOrEmpty(search))
                {
                    source = con.tbl_Product
                        .Where(x => x.ProductSKU.Contains(search) || x.ProductTitle.Contains(search))
                        .OrderByDescending(o => o.ID);
                }

                // Get's No of Rows Count
                int count = source.Count();

                // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1
                int CurrentPage = pageNumber;

                // Parameter is passed from Query string if it is null then it default Value will be pageSize:20
                int PageSize = pageSize;

                // Display TotalCount to Records to User  
                int TotalCount = count;

                // Calculating Totalpage by Dividing (No of Records / Pagesize)
                int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

                // Returns List of Customer after applying Paging
                var data = source
                    .Skip((CurrentPage - 1) * PageSize)
                    .Take(PageSize);

                var stockFilter = con.tbl_StockManager
                    .Join(
                        data,
                        s => s.ParentID,
                        d => d.ID,
                        (s, d) => s
                    )
                    .OrderByDescending(x => new { x.ParentID, x.ProductID, x.ProductVariableID })
                    .ToList();
                var stocks = StockService.Instance.getQuantities(stockFilter);

                var products = data.Where(x => x.CategoryID.HasValue)
                    .Join(
                        con.tbl_Category,
                        pro => pro.CategoryID.Value,
                        cat => cat.ID,
                        (p, c) => new ProductModel()
                        {
                            id = p.ID,
                            categoryID = p.CategoryID.Value,
                            categoryName = c.CategoryName,
                            name = p.ProductTitle,
                            sku = p.ProductSKU,
                            materials = p.Materials,
                            avatar = p.ProductImage,
                            regularPrice = p.Regular_Price.HasValue ? p.Regular_Price.Value : 0,
                            retailPrice = p.Retail_Price.HasValue ? p.Retail_Price.Value : 0,
                        }
                    )
                    .OrderByDescending(x => x.id)
                    .ToList();

                products = products
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
                            categoryID = parent.pro.categoryID,
                            categoryName = parent.pro.categoryName,
                            name = parent.pro.name,
                            sku = parent.pro.sku,
                            materials = parent.pro.materials,
                            avatar = parent.pro.avatar,
                            quantity = child != null ? child.quantity : 0,
                            availability = child != null ? child.availability : false,
                            regularPrice = parent.pro.regularPrice,
                            retailPrice = parent.pro.retailPrice
                        }
                    )
                    .OrderByDescending(o => o.id)
                    .ToList();

                // if CurrentPage is greater than 1 means it has previousPage
                var previousPage = CurrentPage > 1 ? "Yes" : "No";

                // if TotalPages is greater than CurrentPage means it has nextPage
                var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

                // Object which we are going to send in header
                var paginationMetadata = new PaginationMetadataModel()
                {
                    totalCount = TotalCount,
                    pageSize = PageSize,
                    currentPage = CurrentPage,
                    totalPages = TotalPages,
                    previousPage = previousPage,
                    nextPage = nextPage
                };

                return new ProductPageModel()
                {
                    paginationMetadata = paginationMetadata,
                    data = products
                };
            }
        }

        private string getVariableName(string sku, string color, string size)
        {
            var strColor = !String.IsNullOrEmpty(color) ? String.Format("-{0}", color) : String.Empty;
            var strSize = !String.IsNullOrEmpty(size) ? String.Format("-{0}", size) : String.Empty;

            return String.Concat(sku, strColor, strSize);
        }


        public ProductRelatedPageModel getProductRelated(int parentID, int pageNumber, int pageSize)
        {
            using (var con = new inventorymanagementEntities())
            {
                // Returns List of Customer after applying Paging
                var source = con.tbl_ProductVariable.Where(x => x.ProductID == parentID).OrderBy(o => o.ID);

                // Get's No of Rows Count
                int count = source.Count();

                // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1
                int CurrentPage = pageNumber;

                // Parameter is passed from Query string if it is null then it default Value will be pageSize:20
                int PageSize = pageSize;

                // Display TotalCount to Records to User  
                int TotalCount = count;

                // Calculating Totalpage by Dividing (No of Records / Pagesize)
                int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

                // Returns List of Customer after applying Paging
                var data = source
                    .Skip((CurrentPage - 1) * PageSize)
                    .Take(PageSize);

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

                var productVariable = con.tbl_Product.Where(x => x.ID == parentID)
                    .Join(
                        data,
                        p => p.ID,
                        v => v.ProductID,
                        (p, v) => new
                        {
                            id = v.ID,
                            categoryID = p.CategoryID.Value,
                            sku = v.SKU,
                            avatar = v.Image,
                            materials = p.Materials,
                            regularPrice = v.Regular_Price.HasValue ? v.Regular_Price.Value : 0,
                            retailPrice = v.RetailPrice.HasValue ? v.RetailPrice.Value : 0
                        }
                    )
                    .Join(
                        infoVariable,
                        d => d.id,
                        v => v.id,
                        (d, v) => new ProductVariableModel()
                        {
                            id = d.id,
                            categoryID = d.categoryID,
                            sku = d.sku,
                            color = v.color,
                            size = v.size,
                            avatar = d.avatar,
                            materials = d.materials,
                            regularPrice = d.regularPrice,
                            retailPrice = d.retailPrice
                        }
                    )
                    .ToList();

                productVariable = productVariable
                    .Select(x => new ProductVariableModel()
                        {
                            id = x.id,
                            categoryID = x.categoryID,
                            name = getVariableName(x.sku, x.color, x.size),
                            sku = x.sku,
                            color = x.color,
                            size = x.size,
                            avatar = x.avatar,
                            materials = x.materials,
                            regularPrice = x.regularPrice,
                            retailPrice = x.retailPrice
                        }
                    )
                    .OrderBy(x => x.id)
                    .ToList();

                // if CurrentPage is greater than 1 means it has previousPage
                var previousPage = CurrentPage > 1 ? "Yes" : "No";

                // if TotalPages is greater than CurrentPage means it has nextPage
                var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

                // Object which we are going to send in header
                var paginationMetadata = new PaginationMetadataModel()
                {
                    totalCount = TotalCount,
                    pageSize = PageSize,
                    currentPage = CurrentPage,
                    totalPages = TotalPages,
                    previousPage = previousPage,
                    nextPage = nextPage
                };

                return new ProductRelatedPageModel()
                {
                    paginationMetadata = paginationMetadata,
                    data = productVariable
                };
            }
        }

        public ProductDetailPageModel getProductDetail(int id)
        {
            using (var con = new inventorymanagementEntities())
            {
                // Returns List of Customer after applying Paging
                var data = con.tbl_Product.Where(x => x.ID == id);

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
                var colors = VariableService.Instance.getVariables(id, (int)VariableType.Color);
                var sizes = VariableService.Instance.getVariables(id, (int)VariableType.Size);

                // Get images of product
                var images = ImageService.Instance.getByProduct(id);

                var products = data.Where(x => x.CategoryID.HasValue)
                    .Join(
                        con.tbl_Category,
                        pro => pro.CategoryID.Value,
                        cat => cat.ID,
                        (p, c) => new ProductDetailPageModel()
                        {
                            id = p.ID,
                            categoryID = p.CategoryID.Value,
                            categoryName = c.CategoryName,
                            name = p.ProductTitle,
                            sku = p.ProductSKU,
                            materials = p.Materials,
                            regularPrice = p.Regular_Price.HasValue ? p.Regular_Price.Value : 0,
                            retailPrice = p.Retail_Price.HasValue ? p.Retail_Price.Value : 0,
                            content = p.ProductContent
                        }
                    )
                    .OrderBy(x => x.id)
                    .ToList();

                products = products
                    .GroupJoin(
                        stocks,
                        pro => pro.id,
                        info => info.productID,
                        (pro, info) => new { pro, info }
                    )
                    .SelectMany(
                        x => x.info.DefaultIfEmpty(),
                        (parent, child) => new ProductDetailPageModel()
                        {
                            id = parent.pro.id,
                            categoryID = parent.pro.categoryID,
                            categoryName = parent.pro.categoryName,
                            name = parent.pro.name,
                            sku = parent.pro.sku,
                            colors = colors,
                            sizes = sizes,
                            materials = parent.pro.materials,
                            images = images,
                            quantity = child != null ? child.quantity : 0,
                            availability = child != null ? child.availability : false,
                            regularPrice = parent.pro.regularPrice,
                            retailPrice = parent.pro.retailPrice,
                            content = parent.pro.content
                        }
                    )
                    .OrderBy(o => o.id)
                    .ToList();

                return products.FirstOrDefault();
            }
        }

        public string getImageWithVariable(int productID, List<int> variables)
        {
            return ImageService.Instance.getByProductVariable(productID, variables);
        }
    }
}