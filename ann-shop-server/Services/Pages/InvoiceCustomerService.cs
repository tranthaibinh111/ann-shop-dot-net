using ann_shop_server.Models;
using ann_shop_server.Models.Pages.InvoiceCustomer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ann_shop_server.Services.Pages
{
    public class InvoiceCustomerService : Service<InvoiceCustomerService>
    {
        /// <summary>
        /// Lấy thông tin khách hàng
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public CustomerModel getCustomer(int customerID)
        {
            using (var con = new inventorymanagementEntities())
            {
                return con.tbl_Customer
                    .Where(x => x.ID == customerID)
                    .Select(x => new CustomerModel()
                    {
                        id = x.ID,
                        fullName = x.CustomerName,
                        phone = !String.IsNullOrEmpty(x.CustomerPhone) ? x.CustomerPhone : x.CustomerPhone2
                    })
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Kiểm tra xem khách hàng có mã đơn hàng này không
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public bool checkExistOrder(int orderID, int customerID)
        {
            using (var con = new inventorymanagementEntities())
            {
                var order = con.tbl_Order
                    .Where(x => x.ID == orderID)
                    .Where(x => x.CustomerID == customerID)
                    .FirstOrDefault();

                return order != null;
            }
        }

        #region get
        /// <summary>
        /// Lấy thông những sản phẩm đã đặt hàng
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public List<OrderItemModel> getOrderItems(int orderID)
        {
            using (var con = new inventorymanagementEntities())
            {
                #region Lấy thông chi tiết của đơn hàng
                var orderItems = con.tbl_OrderDetail
                    .Where(x => x.OrderID.HasValue && x.OrderID.Value == orderID)
                    .Select(x => new {
                        orderItemID = x.ID,
                        productID = x.ProductID.Value,
                        productVariableID = x.ProductVariableID.Value,
                        sku = x.SKU,
                        price = x.Price.HasValue ? x.Price.Value : 0,
                        quantity = x.Quantity.HasValue ? x.Quantity.Value : 0 
                    });
                #endregion

                #region Lấy thông tin sản phẩm
                // Lấy ID, SubID và SKU của sản phẩm đặt hàng
                var productFilter = orderItems
                    .GroupBy(g => new
                    {
                        productID = g.productID,
                        productVariableID = g.productVariableID,
                        sku = g.sku
                    })
                    .Select(x => new
                    {
                        productID = x.Key.productID,
                        productVariableID = x.Key.productVariableID,
                        sku = x.Key.sku
                    });

                // Lấy thông tin sản phẩm cha
                var products = con.tbl_Product
                    .Join(
                        productFilter.Where(x => x.productVariableID == 0),
                        p => p.ID,
                        o => o.productID,
                        (p, o) => new {
                            productID = p.ID,
                            productVariableID = 0,
                            sku = p.ProductSKU,
                            title = p.ProductTitle,
                            avatar = p.ProductImage,
                            color = String.Empty,
                            size = String.Empty
                        });

                // Lấy thông tin sản phẩm con
                var productVariables = con.tbl_ProductVariable
                    .Join(
                        productFilter.Where(x => x.productVariableID != 0),
                        pv => pv.ID,
                        o => o.productVariableID,
                        (pv, o) => pv
                    )
                    .Join(
                        con.tbl_Product,
                        pv => pv.ProductID.Value,
                        p => p.ID,
                        (pv, p) => new {
                            productID = p.ID,
                            productVariableID = pv.ID,
                            sku = pv.SKU,
                            title = p.ProductTitle,
                            avatar = pv.Image,
                            color = String.Empty,
                            size = String.Empty
                        }
                    );

                var variableColor = con.tbl_ProductVariableValue
                    .Join(
                        productVariables,
                        v => v.ProductVariableID.Value,
                        p => p.productVariableID,
                        (v, p) => v
                    )
                    .Join(
                        con.tbl_VariableValue.Where(x => x.VariableID == 1),
                        pv => pv.VariableValueID,
                        v => v.ID,
                        (pv, v) => new
                        {
                            productVariableID = pv.ProductVariableID,
                            colorName = v.VariableValue
                        }
                    );

                var variableSize = con.tbl_ProductVariableValue
                    .Join(
                        productVariables,
                        v => v.ProductVariableID.Value,
                        p => p.productVariableID,
                        (v, p) => v
                    )
                    .Join(
                        con.tbl_VariableValue.Where(x => x.VariableID == 2),
                        pv => pv.VariableValueID,
                        v => v.ID,
                        (pv, v) => new
                        {
                            productVariableID = pv.ProductVariableID,
                            sizeName = v.VariableValue
                        }
                    );

                productVariables = productVariables
                    .GroupJoin(
                        variableColor,
                        p => p.productVariableID,
                        c => c.productVariableID,
                        (p, c) => new { product = p, color = c }
                    )
                    .SelectMany(
                        x => x.color.DefaultIfEmpty(),
                        (parent, child) => new { product = parent.product, color = child }
                    )
                    .GroupJoin(
                        variableSize,
                        temp => temp.product.productVariableID,
                        s => s.productVariableID,
                        (temp, s) => new { product = temp.product, color = temp.color, size = s }
                    )
                    .SelectMany(
                        x => x.size.DefaultIfEmpty(),
                        (parent, child) => new { product = parent.product, color = parent.color, size = child }
                    )
                    .Select(x => new
                    {
                        productID = x.product.productID,
                        productVariableID = x.product.productVariableID,
                        sku = x.product.sku,
                        title = x.product.title,
                        avatar = x.product.avatar,
                        color = x.color != null ? x.color.colorName : String.Empty,
                        size = x.size != null ? x.size.sizeName : String.Empty
                    });
                #endregion

                var data = orderItems
                    .GroupJoin(
                        products,
                        o => new {
                            productID = o.productID,
                            productVariableID = o.productVariableID
                        },
                        p => new {
                            productID = p.productID,
                            productVariableID = 0
                        },
                        (o, p) => new { orderItem = o, product = p }
                    )
                    .SelectMany(
                        x => x.product.DefaultIfEmpty(),
                        (parent, child) => new { orderItem = parent.orderItem, product = child }
                    )
                    .GroupJoin(
                        productVariables,
                        temp1 => new { productID = temp1.orderItem.productID, productVariableID = temp1.orderItem.productVariableID },
                        pv => new { productID = 0, productVariableID = pv.productVariableID },
                        (temp1, pv) => new { orderItem = temp1.orderItem, product = temp1.product, productVariable = pv }
                    )
                    .SelectMany(
                        x => x.productVariable.DefaultIfEmpty(),
                        (parent, child) => new { orderItem = parent.orderItem, product = parent.product, productVariable = child }
                    )
                    .ToList();

                return data.Select(x =>
                {
                    var product = new Models.Pages.InvoiceCustomer.ProductModel();

                    if (x.product != null && x.productVariable == null)
                    {
                        product.productID = x.product.productID;
                        product.productVariableID = 0;
                        product.sku = x.product.sku;
                        product.title = x.product.title;
                        product.avatar = x.product.avatar;
                        product.color = x.product.color;
                        product.size = x.product.size;
                    }
                    else
                    {
                        product.productID = x.productVariable.productID;
                        product.productVariableID = x.productVariable.productVariableID;
                        product.sku = x.productVariable.sku;
                        product.title = x.productVariable.title;
                        product.avatar = x.productVariable.avatar;
                        product.color = x.productVariable.color;
                        product.size = x.productVariable.size;
                    }

                    return new OrderItemModel()
                    {
                        id = x.orderItem.orderItemID,
                        product = product,
                        price = x.orderItem.price,
                        quantity = Convert.ToInt32(x.orderItem.quantity),
                        totalPrice = x.orderItem.price * x.orderItem.quantity
                    };
                }).ToList();
            }
        }

        /// <summary>
        /// Lấy thông tin đơn hàng
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public OrderModel getOrder(int orderID, int customer)
        {
            using (var con = new inventorymanagementEntities())
            {
                var order = con.tbl_Order
                    .Where(x => x.ID == orderID)
                    .Where(x => x.CustomerID == customer)
                    .FirstOrDefault();
                
                // Trường hợp đơn hàng không phải của khách
                if (order == null)
                    return null;

                var quantity = con.tbl_OrderDetail.Where(x => x.OrderID == order.ID).Count();
                var priceNotDiscount = Convert.ToDouble(order.TotalPriceNotDiscount);
                var discountPerItem = Convert.ToDouble(order.DiscountPerProduct);
                var discount = Convert.ToDouble(order.TotalDiscount);
                var feeShipping = Convert.ToDouble(order.FeeShipping);
                var priceDiscount = priceNotDiscount - discount;

                // Lấy thông tin hàng đổi trả
                var refund = con.tbl_RefundGoods
                    .Where(x => order.RefundsGoodsID.HasValue && x.ID == order.RefundsGoodsID)
                    .Select(x => new
                    {
                        id = x.ID,
                        refundMoney = x.TotalPrice
                    })
                    .ToList()
                    .Select(x => new RefundModel()
                    {
                        id = x.id,
                        refundMoney = Convert.ToDouble(x.refundMoney)
                    })
                    .FirstOrDefault();

                var remainderMoney = refund != null ? priceDiscount - refund.refundMoney : priceDiscount;

                // Lấy thông tin các loại phí khác
                var feeOthers = con.Fees.Where(x => x.OrderID == order.ID)
                    .Join(
                        con.FeeTypes,
                        f => f.FeeTypeID,
                        t => t.ID,
                        (f, t) => new { fee = f, type = t }
                    )
                    .Select(x => new FeeOtherModel()
                    {
                        uuid = x.fee.UUID,
                        feeName = x.type.Name,
                        feePrice = (double)x.fee.FeePrice,
                    })
                    .ToList();

                var price = remainderMoney + Convert.ToDouble(order.FeeShipping) + feeOthers.Sum(s => s.feePrice);

                return new OrderModel()
                {
                    id = order.ID,
                    createdDate = order.CreatedDate.Value,
                    dateDone = order.DateDone,
                    staffName = order.CreatedBy,
                    quantity = quantity,
                    priceNotDiscount = priceNotDiscount,
                    discountPerItem = discountPerItem,
                    discount = discount,
                    priceDiscount = priceDiscount,
                    refund = refund,
                    remainderMoney = remainderMoney,
                    feeShipping = feeShipping,
                    feeOthers = feeOthers,
                    price = price
                };
            }
        }
        #endregion
    }
}