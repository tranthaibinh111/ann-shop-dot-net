using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class NotificationService: IANNService
    {
        #region Khuyến mãi
        /// <summary>
        /// Lấy những nhóm khuyến mãi cho số điện thoại này
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public List<GroupNotifyPromotion> getGroupNotifyPromotion(string phone)
        {
            using (var con = new inventorymanagementEntities())
            {
                var groupsUser = con.UserNotifyPromotions
                    .Where(x => x.Phone == phone)
                    .Select(x => x.GroupID)
                    .Distinct()
                    .ToList();
                var groupsNotify = con.GroupNotifyPromotions
                    .Where(x => x.AllUser == true || groupsUser.Contains(x.ID))
                    .ToList();

                return groupsNotify;
            }
        }

        /// <summary>
        /// Lấy thông tin khuyến mãi dựa theo số điện thoại và slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public NotifyPromotion getNotifyPromotionBySlug(string phone, string slug)
        {
            using (var con = new inventorymanagementEntities())
            {
                var groupsNotify = getGroupNotifyPromotion(phone);

                if (groupsNotify == null || groupsNotify.Count == 0)
                    return null;

                var groupsNotifyID = getGroupNotifyPromotion(phone).Select(x => x.ID).Distinct().ToList();

                var notifyPromotion = con.NotifyPromotions
                    .Where(x => x.Action == FlutterPageNavigation.ViewMore)
                    .Where(x => x.ActionValue == slug)
                    .Where(x => groupsNotifyID.Contains(x.GroupID))
                    .FirstOrDefault();

                return notifyPromotion;
            }
        }
        #endregion

        #region Hoạt động
        /// <summary>
        /// Lấy thông tin hoạt động dựa theo số điện thoài và slug
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="slug"></param>
        /// <returns></returns>
        public NotifyUser getNotifyUserBySlug(string phone, string slug)
        {
            using (var con = new inventorymanagementEntities())
            {
                var notifyUser = con.NotifyUsers
                    .Where(x => x.Action == FlutterPageNavigation.ViewMore)
                    .Where(x => x.ActionValue == slug)
                    .Where(x => x.Phone == phone)
                    .FirstOrDefault();

                return notifyUser;
            }
        }
        #endregion

        #region Tin tức
        /// <summary>
        /// Lấy danh sách thông báo tại màn hình home
        /// </summary>
        /// <returns></returns>
        public List<NotifyNew> getHomeNotification()
        {
            using (var con = new inventorymanagementEntities())
            {
                var homeNews = con.NotifyNews
                    .Where(x => x.AtHome == true)
                    .OrderByDescending(x => x.ModifiedDate)
                    .Skip(0)
                    .Take(4)
                    .ToList();

                return homeNews;
            }
        }

        /// <summary>
        /// Lấy thông tin tin tức theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public NotifyNew getNotifyNewsBySlug(string slug)
        {
            using (var con = new inventorymanagementEntities())
            {
                var notifyNews = con.NotifyNews
                    .Where(x => x.Action == FlutterPageNavigation.ViewMore)
                    .Where(x => x.ActionValue == slug)
                    .FirstOrDefault();

                return notifyNews;
            }
        }
        #endregion
    }
}