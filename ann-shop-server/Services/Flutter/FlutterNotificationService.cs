using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterNotificationService: Service<FlutterNotificationService>
    {
        private NotificationService _service = NotificationService.Instance;
        private NotificationCategoryService _categoryService = NotificationCategoryService.Instance;

        /// <summary>
        /// Lấy thông báo tin tức mới tại home
        /// </summary>
        /// <returns></returns>
        public List<FlutterBannerModel> getHomeNotification()
        {
            var result = _service.getHomeNotification()
                .Select(x => new FlutterBannerModel()
                {
                    action = x.Action,
                    name = x.Title,
                    actionValue = x.Action == FlutterPageNavigation.ViewMore ? "notification/news/" + x.ActionValue : x.ActionValue,
                    image = x.Thumbnail,
                    message = x.Summary,
                    createdDate = x.CreatedDate
                })
                .ToList();

            return result;
        }

        /// <summary>
        /// Lấy thông báo khuyến mải tại bảng NotifyPromition
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        private List<FlutterNotificationCardModel> getNotifyPromotionList(FlutterNotificationFilterModel filter, ref PaginationMetadataModel pagination)
        {
            using (var con = new inventorymanagementEntities())
            {
                var notifyPromotions = con.NotifyPromotions.Where(x => 1 == 1);

                if (!String.IsNullOrEmpty(filter.categorySlug))
                {
                    var categories = _categoryService.getPostCategoryChild(filter.categorySlug);

                    if (categories == null || categories.Count == 0)
                        return null;

                    var categoriesID = categories.Select(x => x.id).ToList();
                    notifyPromotions = notifyPromotions.Where(x => categoriesID.Contains(x.ID));
                }

                if (!String.IsNullOrEmpty(filter.phone))
                {
                    var groupsNotifyPromotion = _service.getGroupNotifyPromotion(filter.phone);

                    if (groupsNotifyPromotion == null || groupsNotifyPromotion.Count == 0)
                        return null;

                    var groupsID = groupsNotifyPromotion.Select(x => x.ID).ToList();
                    notifyPromotions = notifyPromotions.Where(x => groupsID.Contains(x.GroupID));
                }
                // Lấy tổng số record sản phẩm
                pagination.totalCount = notifyPromotions.Count();

                // Calculating Totalpage by Dividing (No of Records / Pagesize)
                pagination.totalPages = (int)Math.Ceiling(pagination.totalCount / (double)pagination.pageSize);

                var result = notifyPromotions
                    .OrderByDescending(o => o.ModifiedDate)
                    .Select(x => new FlutterNotificationCardModel()
                    {
                        kind = filter.kind,
                        action = x.Action,
                        name = x.Title,
                        actionValue = x.Action == FlutterPageNavigation.ViewMore ? "notification/promotion/" + x.ActionValue : x.ActionValue,
                        image = x.Thumbnail,
                        message = x.Summary,
                        createdDate = x.CreatedDate
                    })
                    .Skip((pagination.currentPage - 1) * pagination.pageSize)
                    .Take(pagination.pageSize)
                    .ToList();

                // if CurrentPage is greater than 1 means it has previousPage
                pagination.previousPage = pagination.currentPage > 1 ? "Yes" : "No";

                // if TotalPages is greater than CurrentPage means it has nextPage
                pagination.nextPage = pagination.currentPage < pagination.totalPages ? "Yes" : "No";

                return result;
            }
        }

        /// <summary>
        /// Lấy thông báo về các hoạt động của user tại NotifyUser
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        private List<FlutterNotificationCardModel> getNotifyUserList(FlutterNotificationFilterModel filter, ref PaginationMetadataModel pagination)
        {
            using (var con = new inventorymanagementEntities())
            {
                var notifyUsers = con.NotifyUsers.Where(x => 1 == 1);

                if (!String.IsNullOrEmpty(filter.categorySlug))
                {
                    var categories = _categoryService.getPostCategoryChild(filter.categorySlug);

                    if (categories == null || categories.Count == 0)
                        return null;

                    var categoriesID = categories.Select(x => x.id).ToList();
                    notifyUsers = notifyUsers.Where(x => categoriesID.Contains(x.ID));
                }

                if (!String.IsNullOrEmpty(filter.phone))
                    notifyUsers = notifyUsers.Where(x => x.Phone == filter.phone);
                // Lấy tổng số record sản phẩm
                pagination.totalCount = notifyUsers.Count();

                // Calculating Totalpage by Dividing (No of Records / Pagesize)
                pagination.totalPages = (int)Math.Ceiling(pagination.totalCount / (double)pagination.pageSize);

                var result = notifyUsers
                    .OrderByDescending(o => o.ModifiedDate)
                    .Select(x => new FlutterNotificationCardModel()
                    {
                        kind = filter.kind,
                        action = x.Action,
                        name = x.Title,
                        actionValue = x.Action == FlutterPageNavigation.ViewMore ? "notification/user/" + x.ActionValue : x.ActionValue,
                        image = x.Thumbnail,
                        message = x.Summary,
                        createdDate = x.CreatedDate
                    })
                    .Skip((pagination.currentPage - 1) * pagination.pageSize)
                    .Take(pagination.pageSize)
                    .ToList();

                // if CurrentPage is greater than 1 means it has previousPage
                pagination.previousPage = pagination.currentPage > 1 ? "Yes" : "No";

                // if TotalPages is greater than CurrentPage means it has nextPage
                pagination.nextPage = pagination.currentPage < pagination.totalPages ? "Yes" : "No";

                return result;
            }
        }

        /// <summary>
        /// Lấy thông báo về các tin tức mới tại NotifyNews
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        private List<FlutterNotificationCardModel> getNotifyNewsList(FlutterNotificationFilterModel filter, ref PaginationMetadataModel pagination)
        {
            using (var con = new inventorymanagementEntities())
            {
                var notifyNews = con.NotifyNews.Where(x => 1 == 1);

                if (!String.IsNullOrEmpty(filter.categorySlug))
                {
                    var categories = _categoryService.getPostCategoryChild(filter.categorySlug);

                    if (categories == null || categories.Count == 0)
                        return null;

                    var categoriesID = categories.Select(x => x.id).ToList();
                    notifyNews = notifyNews.Where(x => categoriesID.Contains(x.ID));
                }

                // Lấy tổng số record sản phẩm
                pagination.totalCount = notifyNews.Count();

                // Calculating Totalpage by Dividing (No of Records / Pagesize)
                pagination.totalPages = (int)Math.Ceiling(pagination.totalCount / (double)pagination.pageSize);

                var result = notifyNews
                    .OrderByDescending(o => o.ModifiedDate)
                    .Select(x => new FlutterNotificationCardModel()
                    {
                        kind = filter.kind,
                        action = x.Action,
                        name = x.Title,
                        actionValue = x.Action == FlutterPageNavigation.ViewMore ? "notification/news/" + x.ActionValue : x.ActionValue,
                        image = x.Thumbnail,
                        message = x.Summary,
                        createdDate = x.CreatedDate
                    })
                    .Skip((pagination.currentPage - 1) * pagination.pageSize)
                    .Take(pagination.pageSize)
                    .ToList();

                // if CurrentPage is greater than 1 means it has previousPage
                pagination.previousPage = pagination.currentPage > 1 ? "Yes" : "No";

                // if TotalPages is greater than CurrentPage means it has nextPage
                pagination.nextPage = pagination.currentPage < pagination.totalPages ? "Yes" : "No";

                return result;
            }
        }

        /// <summary>
        /// Lấy tổng hợp các thông báo
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<FlutterNotificationCardModel> getNotifications(FlutterNotificationFilterModel filter, ref PaginationMetadataModel pagination)
        {
            if (String.IsNullOrEmpty(filter.kind))
            {
                #region Tổng hợp các thông báo
                using (var con = new inventorymanagementEntities())
                {
                    var notifications = con.Notifications.Where(x => 1 == 1);

                    if (!String.IsNullOrEmpty(filter.phone))
                    {
                        notifications = notifications.Where(x =>
                            (x.Kind == NotificationKind.Promotion && (x.Phone == null || x.Phone == filter.phone)) ||
                            (x.Kind == NotificationKind.Notification && x.Phone == filter.phone) ||
                            x.Kind == NotificationKind.News
                        );
                    }

                    // Lấy tổng số record sản phẩm
                    pagination.totalCount = notifications.Count();

                    // Calculating Totalpage by Dividing (No of Records / Pagesize)
                    pagination.totalPages = (int)Math.Ceiling(pagination.totalCount / (double)pagination.pageSize);

                    var data = notifications
                        .OrderByDescending(o => o.ModifiedDate)
                        .Skip((pagination.currentPage - 1) * pagination.pageSize)
                        .Take(pagination.pageSize);

                    // if CurrentPage is greater than 1 means it has previousPage
                    pagination.previousPage = pagination.currentPage > 1 ? "Yes" : "No";

                    // if TotalPages is greater than CurrentPage means it has nextPage
                    pagination.nextPage = pagination.currentPage < pagination.totalPages ? "Yes" : "No";


                    #region Lấy thông báo khuyến mãi
                    var notifyPromotions = data.Where(x => x.Kind == NotificationKind.Promotion)
                        .Join(
                            con.NotifyPromotions,
                            d => d.NotifyID,
                            p => p.ID,
                            (d, p) => new {
                                kind = d.Kind,
                                notifyID = p.ID,
                                action = p.Action,
                                name = p.Title,
                                actionValue = p.Action == FlutterPageNavigation.ViewMore ? "notification/promotion/" + p.ActionValue : p.ActionValue,
                                image = p.Thumbnail,
                                message = p.Summary,
                                createdDate = p.CreatedDate
                            }
                        )
                        .ToList();
                    #endregion

                    #region Lấy thông báo hoạt động của user
                    var notifyUsers = data.Where(x => x.Kind == NotificationKind.Notification)
                        .Join(
                            con.NotifyUsers,
                            d => d.NotifyID,
                            p => p.ID,
                            (d, p) => new {
                                kind = d.Kind,
                                notifyID = p.ID,
                                action = p.Action,
                                name = p.Title,
                                actionValue = p.Action == FlutterPageNavigation.ViewMore ? "notification/user/" + p.ActionValue : p.ActionValue,
                                image = p.Thumbnail,
                                message = p.Summary,
                                createdDate = p.CreatedDate
                            }
                        )
                        .ToList();
                    #endregion

                    #region Lấy thông báo tin tức
                    var notifyNews = data.Where(x => x.Kind == NotificationKind.News)
                        .Join(
                            con.NotifyNews,
                            d => d.NotifyID,
                            p => p.ID,
                            (d, p) => new {
                                kind = d.Kind,
                                notifyID = p.ID,
                                action = p.Action,
                                name = p.Title,
                                actionValue = p.Action == FlutterPageNavigation.ViewMore ? "notification/news/" + p.ActionValue : p.ActionValue,
                                image = p.Thumbnail,
                                message = p.Summary,
                                createdDate = p.CreatedDate
                            }
                        )
                        .ToList();
                    #endregion

                    #region Lấy thông tin của tất cả thông báo
                    var result = data.ToList()
                        .GroupJoin(
                            notifyPromotions,
                            d => new { kind = d.Kind, notifyID = d.NotifyID },
                            p => new { kind = p.kind, notifyID = p.notifyID },
                            (d, p) => new { notify = d, promotion = p}
                        )
                        .SelectMany(
                            x => x.promotion.DefaultIfEmpty(),
                            (parent, child) => new { notify = parent.notify, promotion = child }
                        )
                        .GroupJoin(
                            notifyUsers,
                            temp => new { kind = temp.notify.Kind, notifyID = temp.notify.NotifyID },
                            u => new { kind = u.kind, notifyID = u.notifyID },
                            (temp, u) => new { notify = temp.notify, promotion = temp.promotion, user = u }
                        )
                        .SelectMany(
                            x => x.user.DefaultIfEmpty(),
                            (parent, child) => new { notify = parent.notify, promotion = parent.promotion, user = child }
                        )
                        .GroupJoin(
                            notifyNews,
                            temp => new { kind = temp.notify.Kind, notifyID = temp.notify.NotifyID },
                            n => new { kind = n.kind, notifyID = n.notifyID },
                            (temp, n) => new { notify = temp.notify, promotion = temp.promotion, user = temp.user, news = n }
                        )
                        .SelectMany(
                            x => x.news.DefaultIfEmpty(),
                            (parent, child) => new { notify = parent.notify, promotion = parent.promotion, user = parent.user, news = child }
                        )
                        .Select(x => {
                            var kind = x.notify.Kind;

                            if (x.notify.Kind == NotificationKind.Promotion && x.promotion != null)
                            {
                                return new FlutterNotificationCardModel()
                                {
                                    kind = x.promotion.kind,
                                    action = x.promotion.action,
                                    name = x.promotion.name,
                                    actionValue = x.promotion.actionValue,
                                    image = x.promotion.image,
                                    message = x.promotion.message,
                                    createdDate = x.promotion.createdDate
                                };
                            }

                            if (x.notify.Kind == NotificationKind.Notification && x.user != null)
                            {
                                return new FlutterNotificationCardModel()
                                {
                                    kind = x.user.kind,
                                    action = x.user.action,
                                    name = x.user.name,
                                    actionValue = x.user.actionValue,
                                    image = x.user.image,
                                    message = x.user.message,
                                    createdDate = x.user.createdDate
                                };
                            }

                            if (x.notify.Kind == NotificationKind.News && x.news != null)
                            {
                                return new FlutterNotificationCardModel()
                                {
                                    kind = x.news.kind,
                                    action = x.news.action,
                                    name = x.news.name,
                                    actionValue = x.news.actionValue,
                                    image = x.news.image,
                                    message = x.news.message,
                                    createdDate = x.news.createdDate
                                };
                            }

                            return new FlutterNotificationCardModel()
                            {
                                kind = x.notify.Kind,
                                action = String.Empty,
                                name = String.Empty,
                                actionValue = String.Empty,
                                image = String.Empty,
                                message = String.Empty,
                                createdDate = DateTime.Now
                            };
                        })
                        .ToList();
                    #endregion

                    return result;
                }
                #endregion
            }
            else if (filter.kind == NotificationKind.Promotion)
            {
                return getNotifyPromotionList(filter, ref pagination);
            }
            else if (filter.kind == NotificationKind.Notification)
            {
                return getNotifyUserList(filter, ref pagination);
            }
            else if (filter.kind == NotificationKind.News)
            {
                return getNotifyNewsList(filter, ref pagination);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Lấy thông tin khuyến mãi dựa theo số điện thoại và slug
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="slug"></param>
        /// <returns></returns>
        public FlutterNotificationModel getNotifyPromotionBySlug(string phone, string slug)
        {
            if (String.IsNullOrEmpty(phone) || String.IsNullOrEmpty(slug))
                return null;

            var promotion = _service.getNotifyPromotionBySlug(phone, slug);

            if (promotion == null)
                return null;

            return new FlutterNotificationModel()
            {
                title = promotion.Title,
                content = promotion.Content,
                createdDate = promotion.CreatedDate
            };
        }

        /// <summary>
        /// Lấy thông tin hoạt động dựa theo số điện thoài và slug
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="slug"></param>
        /// <returns></returns>
        public FlutterNotificationModel getNotifyUserBySlug(string phone, string slug)
        {
            if (String.IsNullOrEmpty(phone) || String.IsNullOrEmpty(slug))
                return null;

            var notifyUser = _service.getNotifyUserBySlug(phone, slug);

            if (notifyUser == null)
                return null;

            return new FlutterNotificationModel()
            {
                title = notifyUser.Title,
                content = notifyUser.Content,
                createdDate = notifyUser.CreatedDate
            };
        }

        /// <summary>
        /// Lấy thông tin tin tức theo slug
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="slug"></param>
        /// <returns></returns>
        public FlutterNotificationModel getNotifyNewsBySlug(string slug)
        {
            if (String.IsNullOrEmpty(slug))
                return null;

            var news = _service.getNotifyNewsBySlug(slug);

            if (news == null)
                return null;

            return new FlutterNotificationModel()
            {
                title = news.Title,
                content = news.Content,
                createdDate = news.CreatedDate
            };
        }
    }
}