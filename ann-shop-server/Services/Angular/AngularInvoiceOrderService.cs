using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ann_shop_server.Services
{
    public class AngularInvoiceOrderService : IANNService
    {
        /// <summary>
        /// Lấy thông tin khách hàng
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public InvoiceOrderCustomerModel getCustomer(int customerID)
        {
            using (var con = new inventorymanagementEntities())
            {
                return con.tbl_Customer
                    .Where(x => x.ID == customerID)
                    .Select(x => new InvoiceOrderCustomerModel()
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
        public List<InvoiceOrderOrderItemModel> getOrderItems(int orderID)
        {
            using (var con = new inventorymanagementEntities())
            {
                #region Lấy triết khấu mặc định
                var defaultDiscount = con.tbl_Order
                    .Where(x => x.ID == orderID)
                    .Select(x => x.DiscountPerProduct.HasValue ? x.DiscountPerProduct.Value : 0)
                    .SingleOrDefault();
                #endregion

                #region Lấy thông chi tiết của đơn hàng
                var orderItems = con.tbl_OrderDetail
                    .Where(x => x.OrderID.HasValue && x.OrderID.Value == orderID)
                    .Select(x => new {
                        orderItemID = x.ID,
                        productID = x.ProductID.Value,
                        productVariableID = x.ProductVariableID.Value,
                        sku = x.SKU,
                        price = x.Price.HasValue ? x.Price.Value : 0,
                        discount = x.DiscountPrice.HasValue ? x.DiscountPrice.Value : 0,
                        quantity = x.Quantity.HasValue ? (int)x.Quantity.Value : 0
                    });
                #endregion

                #region Cập nhật yêu cầu của khách hàng
                // Lấy tất cả yêu cầu của khách hàng
                var requirement = con.CustomerEditOrders
                    .Where(x => x.OrderID == orderID)
                    .Select(x => new {
                        orderItemID = x.OrderItemID,
                        productID = x.ProductID,
                        productVariableID = x.ProductVariableID,
                        sku = x.SKU,
                        price = x.Price,
                        discount = 0D,
                        quantity = x.Quantity,
                        status = x.Status,
                        createdDate = x.CreatedDate
                    });

                if (requirement.Count() > 0)
                {
                    // Lấy ra yêu cầu cuối cùng của khách hàng
                    var requirementLast = requirement
                        .GroupBy(g => new {
                            status = g.status,
                            productID = g.productID,
                            productVariableID = g.productVariableID,
                            sku = g.sku
                        })
                        .Select(x => new
                        {
                            status = x.Key.status,
                            productID = x.Key.productID,
                            productVariableID = x.Key.productVariableID,
                            sku = x.Key.sku,
                            createdDate = x.Max(m => m.createdDate)
                        });

                    var requirementExcute = requirement
                        .Join(
                            requirementLast,
                            r => new
                            {
                                status = r.status,
                                productID = r.productID,
                                productVariableID = r.productVariableID,
                                createdDate = r.createdDate
                            },
                            l => new
                            {
                                status = l.status,
                                productID = l.productID,
                                productVariableID = l.productVariableID,
                                createdDate = l.createdDate
                            },
                            (r, l) => r
                        );

                    // Thực thi yêu cầu thêm sản phẩm
                    var requirementAdd = requirementExcute.Where(x => x.status == CustomerRequirement.Add);

                    if (requirementAdd.Count() > 0)
                    {
                        var orderItemAdd = requirementExcute
                          .Where(x => x.status == CustomerRequirement.Add)
                          .Select(x => new
                          {
                              orderItemID = x.orderItemID,
                              productID = x.productID,
                              productVariableID = x.productVariableID,
                              sku = x.sku,
                              price = x.price,
                              discount = 0D,
                              quantity = x.quantity,
                          });

                        orderItems = orderItems.Union(orderItemAdd);
                    }

                    // Thực thi yêu cầu chỉnh sửa
                    var requirementEdit = requirementExcute.Where(x => x.status == CustomerRequirement.Edit);
                    if (requirementEdit.Count() > 0)
                        orderItems = orderItems
                            .GroupJoin(
                                requirementEdit,
                                i => i.sku,
                                r => r.sku,
                                (i, r) => new { orderItem = i, requirement = r }
                            )
                            .SelectMany(
                                x => x.requirement.DefaultIfEmpty(),
                                (parent, child) => new
                                {
                                    orderItemID = parent.orderItem.orderItemID,
                                    productID = parent.orderItem.productID,
                                    productVariableID = parent.orderItem.productVariableID,
                                    sku = parent.orderItem.sku,
                                    price = child != null ? child.price : parent.orderItem.price,
                                    discount = 0D,
                                    quantity = child != null ? child.quantity : parent.orderItem.quantity,
                                }
                            );

                    // Thực thi yêu cầu xóa
                    var requirementDelete = requirementExcute.Where(x => x.status == CustomerRequirement.Delete);

                    if (requirementDelete.Count() > 0)
                    {
                        // Tìm ra những order item loại bỏ
                        var orderItemRemove = orderItems
                            .Join(
                                requirementDelete.Where(x => x.status == CustomerRequirement.Delete),
                                i => i.sku,
                                r => r.sku,
                                (i, r) => i
                            );

                        // Thực thi loại bỏ
                        orderItems = orderItems.Except(orderItemRemove);
                    }
                }
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
                        p => p.ProductSKU,
                        o => o.sku,
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
                        pv => pv.SKU,
                        o => o.sku,
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

                #region Dữ liệu triết xuất
                var data = orderItems
                    .GroupJoin(
                        products,
                        o => o.sku,
                        p => p.sku,
                        (o, p) => new { orderItem = o, product = p }
                    )
                    .SelectMany(
                        x => x.product.DefaultIfEmpty(),
                        (parent, child) => new { orderItem = parent.orderItem, product = child }
                    )
                    .GroupJoin(
                        productVariables,
                        temp1 => temp1.orderItem.sku,
                        pv => pv.sku,
                        (temp1, pv) => new { orderItem = temp1.orderItem, product = temp1.product, productVariable = pv }
                    )
                    .SelectMany(
                        x => x.productVariable.DefaultIfEmpty(),
                        (parent, child) => new { orderItem = parent.orderItem, product = parent.product, productVariable = child }
                    )
                    .ToList();
                #endregion

                return data.Select(x =>
                {
                    var product = new InvoiceOrderProductModel();

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

                    return new InvoiceOrderOrderItemModel()
                    {
                        id = x.orderItem.orderItemID,
                        product = product,
                        price = x.orderItem.price,
                        quantity = Convert.ToInt32(x.orderItem.quantity),
                        discount = x.orderItem.discount > 0 ? x.orderItem.discount : defaultDiscount,
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
        public InvoiceOrderOrderModel getOrder(int orderID, int customer)
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
                    .Select(x => new InvoiceOrderRefundModel()
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
                    .Select(x => new InvoiceOrderFeeOtherModel()
                    {
                        uuid = x.fee.UUID,
                        feeName = x.type.Name,
                        feePrice = (double)x.fee.FeePrice,
                    })
                    .ToList();

                var price = remainderMoney + Convert.ToDouble(order.FeeShipping) + feeOthers.Sum(s => s.feePrice);

                return new InvoiceOrderOrderModel()
                {
                    id = order.ID,
                    kind = order.OrderType.Value,
                    createdDate = order.CreatedDate.Value,
                    dateDone = order.DateDone,
                    staffName = order.CreatedBy,
                    quantity = quantity,
                    priceNotDiscount = priceNotDiscount,
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

        #region create
        public CustomerEditOrder addRequirement(int customerID, int orderID, InvoiceOrderOrderItemModel orderItem, int requirementKind)
        {
            try
            {
                using (var con = new inventorymanagementEntities())
                {
                    var requirement = new CustomerEditOrder()
                    {
                        OrderID = orderID,
                        OrderItemID = orderItem.id,
                        ProductID = orderItem.product.productID,
                        ProductVariableID = orderItem.product.productVariableID,
                        SKU = orderItem.product.sku,
                        Quantity = orderItem.quantity,
                        Price = orderItem.price,
                        TotalPrice = orderItem.totalPrice,
                        Status = requirementKind,
                        CustomerID = customerID,
                        CreatedDate = DateTime.Now
                    };

                    con.CustomerEditOrders.Add(requirement);
                    con.SaveChanges();

                    return requirement;
                }
            }
            catch (Exception)
            {
                throw new Exception("Xảy ra lỗi trong quá trình khởi tạo yêu cầu của khách hàng");
            }
        }

        public List<CustomerEditOrder> addRequirement(int customerID, int orderID, List<InvoiceOrderOrderItemModel> orderItems, int requirementKind)
        {
            try
            {
                using (var con = new inventorymanagementEntities())
                {
                    var index = 0;
                    var result = new List<CustomerEditOrder>();

                    foreach (var item in orderItems)
                    {
                        ++index;
                        var requirement = new CustomerEditOrder()
                        {
                            OrderID = orderID,
                            OrderItemID = item.id,
                            ProductID = item.product.productID,
                            ProductVariableID = item.product.productVariableID,
                            SKU = item.product.sku,
                            Quantity = item.quantity,
                            Price = item.price,
                            TotalPrice = item.totalPrice,
                            Status = requirementKind,
                            CustomerID = customerID,
                            CreatedDate = DateTime.Now
                        };

                        result.Add(requirement);
                        con.CustomerEditOrders.Add(requirement);

                        if (index >= 100)
                        {
                            index = 0;
                            con.SaveChanges();
                        }
                    }

                    if(index > 0)
                        con.SaveChanges();

                    return result;
                }
            }
            catch (Exception)
            {
                throw new Exception("Xảy ra lỗi trong quá trình khởi tạo yêu cầu của khách hàng");
            }
        }
        #endregion
    }
}