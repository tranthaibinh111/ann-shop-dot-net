using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterCouponService : CouponService
    {
        /// <summary>
        /// Lấy danh sách các trường trình đăng chạy khuyến mãi
        /// </summary>
        /// <returns></returns>
        public List<FlutterPromotionModel> getPromotions(string phone)
        {
            return base.getCoupons(phone)
                .Select(x => new FlutterPromotionModel()
                {
                    name = x.Name,
                    code = x.Code,
                    startDate = x.StartDate,
                    endDate = x.EndDate
                })
                .ToList();
        }

        /// <summary>
        /// Lấy danh sách các mã khuyến mãi còn hiệu lực
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public new List<FlutterCouponModel> getCustomerCoupon(string phone)
        {
            var coupons = base.getCustomerCoupon(phone);

            if (coupons != null && coupons.Count > 0)
            {
                using (var con = new inventorymanagementEntities())
                {
                    var data = coupons.Join(
                        con.Coupons,
                        c => c.CouponID,
                        p => p.ID,
                        (c, p) => new FlutterCouponModel()
                        {
                            code = p.Code,
                            value = p.Value,
                            startDate = c.StartDate,
                            endDate = c.EndDate
                        }
                    ).ToList();

                    return data;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Lấy coupon
        /// </summary>
        /// <param name="code"></param>
        /// <param name="phone"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public FlutterCouponModel getCoupon(string code, string phone, out string message)
        {
            message = String.Empty;

            using (var con = new inventorymanagementEntities())
            {
                var promotion = base.getCoupon(code);

                if (promotion == null)
                {
                    message = "Không tìm thấy chương trình khuyến mãi";
                    return null;
                }

                // Kiểm tra xem khách hàng đã lấy mã coupon chưa
                if (base.existCustomerCoupon(promotion.ID, phone))
                {
                    message = "Bạn đã được cấp mã khuyến mãi rồi.";
                    return null;
                }

                if (!base.checkExpired(promotion))
                {
                    message = "Chương trình đã hết thời gian khuyến mãi";
                    return null;
                }

                // Insert Customer Coupon 
                var now = DateTime.Now;
                var customerCoupon = new CustomerCoupon()
                {
                    CustomerID = 0,
                    Phone = phone,
                    CouponID = promotion.ID,
                    StartDate = now,
                    EndDate = promotion.EndDate,
                    Active = true,
                    CreatedDate = now,
                    ModifiedDate = now
                };
                base.createCustomerCoupon(customerCoupon);

                return new FlutterCouponModel()
                {
                    code = promotion.Code,
                    value = promotion.Value,
                    startDate = now,
                    endDate = promotion.EndDate
                };
            }
        }
    }
}