﻿using ann_shop_server.Models;
using ann_shop_server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class AngularSearchProductService : IANNService
    {
        private readonly ProductService _product = ANNFactoryService.getInstance<ProductService>();

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
        public List<ProductSortModel> getProductSort()
        {
            return _product.getProductSort();
        }

        /// <summary>
        /// Lấy tất cả sản phẩm theo từ khóa
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<ProductCardModel> getProducts(SearchProductFilterModel filter, ref PaginationMetadataModel pagination)
        {
            var productFilter = new ProductFilterModel()
            {
                productSearch = filter.search,
                productSort = filter.sort
            };

            return _product.getProducts(productFilter, ref pagination);
        }
        #endregion
    }
}