using ann_shop_server.Models;
using ann_shop_server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public class CouponService: Service<CouponService>
    {
        /// <summary>
        /// Lấy các chương trình khuyến mãi còn hiệu lực
        /// </summary>
        /// <returns></returns>
        public List<Coupon> getCoupons(string phone)
        {
            using (var con = new inventorymanagementEntities())
            {
                var now = DateTime.Now.Date;
                var currentDate = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

                var receivededCouponID = con.CustomerCoupons
                    .Where(x => x.Phone == phone)
                    .Select(x => x.CouponID)
                    .ToList();

                var coupons = con.Coupons
                    .Where(x => x.Active == true)
                    .Where(x => x.EndDate >= currentDate);

                if (receivededCouponID != null || receivededCouponID.Count > 0)
                {
                    coupons = coupons.Where(x => receivededCouponID.Contains(x.ID));
                }

                return coupons.OrderBy(o => o.EndDate).ToList();
            }
        }

        /// <summary>
        /// Lấy phiếu khuyến mãi theo mã code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Coupon getCoupon(string code)
        {
            using (var con = new inventorymanagementEntities())
            {
                return con.Coupons
                    .Where(x => x.Code == code)
                    .Where(x => x.Active == true)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Kiểm tra phiếu có hết hạn chưa
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns></returns>
        public bool checkExpired(Coupon coupon)
        {
            var now = DateTime.Now;

            if (coupon.StartDate > now || coupon.EndDate < now)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Lấy các phiểu khuyển mãi của user còn hiệu lục
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public List<CustomerCoupon> getCustomerCoupon(string phone)
        {
            using (var con = new inventorymanagementEntities())
            {
                var coupons = con.CustomerCoupons
                    .Where(x => x.Phone == phone)
                    .Where(x => x.Active == true)
                    .OrderBy(o => o.EndDate)
                    .ToList();

                return coupons;
            }
        }

        /// <summary>
        /// Kiểu tra xem user với phiếu khuyến mãi có tồn tại chưa
        /// </summary>
        /// <param name="couponID"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool existCustomerCoupon(int couponID, string phone)
        {
            using (var con = new inventorymanagementEntities())
            {
                var customerCoupon = con.CustomerCoupons
                    .Where(x => x.CouponID == couponID)
                    .Where(x => x.Phone == phone)
                    .FirstOrDefault();

                return customerCoupon != null;
            }
        }

        /// <summary>
        /// Khởi tạo phiếu khuyến mãi cho khách hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public CustomerCoupon createCustomerCoupon(CustomerCoupon data)
        {
            using (var con = new inventorymanagementEntities())
            {
                con.CustomerCoupons.Add(data);
                con.SaveChanges();

                return data;
            }
        }
    }
}