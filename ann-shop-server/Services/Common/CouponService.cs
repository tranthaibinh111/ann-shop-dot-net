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

        public bool checkExpired(Coupon coupon)
        {
            var now = DateTime.Now;

            if (coupon.StartDate > now || coupon.EndDate < now)
                return false;
            else
                return true;
        }

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