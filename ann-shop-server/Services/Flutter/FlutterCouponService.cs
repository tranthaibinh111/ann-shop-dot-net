using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterCouponService : Service<FlutterCouponService>
    {
        private CouponService _service = CouponService.Instance;

        /// <summary>
        /// Lấy danh sách các trường trình đăng chạy khuyến mãi
        /// </summary>
        /// <returns></returns>
        public List<FlutterPromotionModel> getPromotions()
        {
            var promotion1 = new FlutterPromotionModel()
            {
                name = "Nhận mã khuyến mãi cho khách hàng mới",
                code = "NEWUSER",
                startDate = new DateTime(2020, 2, 1),
                endDate = new DateTime(2020, 5, 31)
            };

            var promotion2 = new FlutterPromotionModel()
            {
                name = "Nhận mã khuyến mãi cho khách hàng review app",
                code = "REVIEWAPP",
                startDate = new DateTime(2020, 2, 1),
                endDate = new DateTime(2020, 5, 31)
            };

            var promitons = new List<FlutterPromotionModel>();
            promitons.Add(promotion1);
            promitons.Add(promotion2);

            return promitons;
        }

        /// <summary>
        /// Lấy danh sách các mã khuyến mãi còn hiệu lực
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public List<FlutterCouponModel> getCustomerCoupon(string phone)
        {
            var coupons = _service.getCustomerCoupon(phone);

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
                var promotion = _service.getCoupon(code);

                if (promotion == null)
                {
                    message = "Không tìm thấy chương trình khuyến mãi";
                    return null;
                }

                // Kiểm tra xem khách hàng đã lấy mã coupon chưa
                if (_service.existCustomerCoupon(promotion.ID, phone))
                {
                    message = "Bạn đã được cấp mã khuyến mãi rồi.";
                    return null;
                }

                if (!_service.checkExpired(promotion))
                {
                    message = "Chương trình đã hết thời gian khuyến mãi";
                    return null;
                }

                // Insert Customer Coupon 
                var now = DateTime.Now;
                var customerCoupon = new CustomerCoupon()
                {
                    CustomerID = 0,
                    CouponID = promotion.ID,
                    StartDate = now,
                    EndDate = promotion.EndDate,
                    Active = true,
                    CreatedDate = now,
                    ModifiedDate = now
                };
                _service.createCustomerCoupon(customerCoupon);

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