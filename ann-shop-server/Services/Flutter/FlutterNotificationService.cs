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
        #region  Hard code Test
        /// <summary>
        /// Thông báo đổi hàng cuối năm
        /// </summary>
        /// <returns></returns>
        private NotificationModel getNotification1()
        {
            var summary = String.Empty;
            summary += "😻 Nói thẳng luôn, chỉ có ANN mới dám làm điều này!\n";
            summary += "🌼🌸🌺 Bên kho em nhận đổi trả hàng đến ngày nghỉ tết luôn (15h ngày 21/1/2020) và qua Tết vẫn nhận đổi trả hàng của năm nay luôn nhé mọi người!\n";
            summary += "👉 Mọi năm thì tháng cuối năm ANN không nhận đổi trả hàng và qua năm mới không nhận đổi hàng của năm cũ. Nhưng năm nay ANN 'chơi lớn' thật rồi... ông giáo ạ, à không quý khách ạ! 😜";

            var content = new StringBuilder();
            content.AppendLine("<p style='text-align: center;'><img alt='Đổi hàng cuối năm' src='http://xuongann.com/uploads/doi-hang-cuoi-nam/doi-hang-cuoi-nam-2.png'></p>");
            content.AppendLine("<p> 😻 Nói thẳng luôn, chỉ có ANN mới dám làm điều này!</p>");
            content.AppendLine("<p> 🌼🌸🌺 Bên kho em nhận đổi trả hàng đến ngày nghỉ tết luôn (15h ngày 21/1/2020) và qua Tết vẫn nhận đổi trả hàng của năm nay luôn nhé mọi người!</p>");
            content.AppendLine("<p> 👉 Mọi năm thì tháng cuối năm ANN không nhận đổi trả hàng và qua năm mới không nhận đổi hàng của năm cũ. Nhưng năm nay ANN 'chơi lớn' thật rồi... ông giáo ạ, à không quý khách ạ! 😜</p><p ☘ Vẫn là quy định đổi hàng trong 30 ngày kể từ ngày mua hàng (bao gồm ngày nghĩ tết).</p><p 🤝 ANN đã chấp nhận 'chơi lớn' với khách hàng rồi thì mọi người vui lòng 'chơi đẹp' giúp bên em nha! Hàng gì bán chậm hoặc bị lỗi thì tranh thủ đổi càng sớm càng tốt, chứ đừng 'ngâm' quá hạn là bên em không nhận được đâu á!</p>");
            content.AppendLine("<p> 🏵️🌻🌺 Chúc mọi người một mùa Tết bán hàng đắt 'mệt xỉu', và năm mới 'tiền tài danh vọng' điều có đủ hết nha!</p>");

            return new NotificationModel()
            {
                kind = "notification",
                title = "Thông báo đổi hàng cuối năm",
                action = "view_more",
                actionValue = "doi-hang-cuoi-nam",
                avatar = "/uploads/doi-hang-cuoi-nam/doi-hang-cuoi-nam-3.png",
                summary = summary,
                content = content.ToString(),
                createdDate = DateTime.Now
            };
        }

        /// <summary>
        /// Thông báo thời gian làm việc
        /// </summary>
        /// <returns></returns>
        private NotificationModel getNotification2()
        {
            var summary = String.Empty;
            summary += "Chúng tôi xin hướng dẫn cách share sản phẩm lên Facebook";

            return new NotificationModel()
            {
                kind = "news",
                title = "Hướng share sản phẩm lên Facebook",
                action = "show_web",
                actionValue = "http://xuongann.com",
                avatar = String.Empty,
                summary = summary,
                content = summary,
                createdDate = DateTime.Now
            };
        }

        /// <summary>
        /// Thông báo thời gian làm việc
        /// </summary>
        /// <returns></returns>
        private NotificationModel getNotification3()
        {
            var summary = String.Empty;
            summary += "Nhằm cảm ơn sụ ủng hộ và quan tâm khách hàng với công ty chúng tôi.\n";
            summary += "Nay công ty ANN xin đưa ra một loạt các chương trình khuyên mãi siêu khủng.\n";
            summary += "Nào cùng click vào để xem các chương trình khuyến mãi nè!.\n";


            return new NotificationModel()
            {
                kind = "promotion",
                title = "Thông báo khuyến mãi",
                action = "show_web",
                actionValue = "http://xuongann.com",
                avatar = "https://ann.com.vn/wp-content/uploads/quan-ao-tet-2020.jpg",
                summary = summary,
                content = String.Empty,
                createdDate = DateTime.Now
            };
        }
        #endregion

        public List<FlutterBannerModel> getHomeNotification()
        {
            var result = new List<FlutterBannerModel>();

            // Thông báo đổi hàng cuối năm
            var notification1 = getNotification1();
            result.Add(new FlutterBannerModel()
            {
                action = notification1.action,
                name = notification1.title,
                actionValue = notification1.actionValue,
                image = notification1.avatar,
                message = notification1.summary,
                createdDate = notification1.createdDate
            });

            // Thông báo thời gian làm việc
            var notification2 = getNotification2();
            result.Add(new FlutterBannerModel()
            {
                action = notification2.action,
                name = notification2.title,
                actionValue = notification2.actionValue,
                image = notification2.avatar,
                message = notification2.summary,
                createdDate = notification2.createdDate
            });

            // Thông báo khuyến mãi tri ân khách hàng
            var notification3 = getNotification3();
            result.Add(new FlutterBannerModel()
            {
                action = notification3.action,
                name = notification3.title,
                actionValue = notification3.actionValue,
                image = notification3.avatar,
                message = notification3.summary,
                createdDate = notification3.createdDate
            });

            return result.Select(x => {
                if (x.action == "view_more")
                    x.actionValue = "notification/" + x.actionValue;

                return x;
            }).ToList(); ;
        }

        public List<FlutterNotificationCardModel> getNotifications(FlutterNotificationFilterModel filter, ref PaginationMetadataModel pagination)
        {
            var data = new List<NotificationModel>()
            {
                getNotification1(),
                getNotification2(),
                getNotification3()
            }
            .ToList();

            // Lọc theo thể lại thông báo
            if (!String.IsNullOrEmpty(filter.kind))
            {
                data = data.Where(x => x.kind.Trim().ToLower() == filter.kind.Trim().ToLower()).ToList();
            }

            // Lấy tổng số record sản phẩm
            pagination.totalCount = data.Count();

            // Calculating Totalpage by Dividing (No of Records / Pagesize)
            pagination.totalPages = (int)Math.Ceiling(pagination.totalCount / (double)pagination.pageSize);

            var result = data
                .Select(x => new FlutterNotificationCardModel()
                {
                    kind = x.kind,
                    action = x.action,
                    name = x.title,
                    actionValue = x.action == "view_more" ? "notification/" + x.actionValue : x.actionValue,
                    image = x.avatar,
                    message = x.summary,
                    createdDate = x.createdDate
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


        public FlutterNotificationModel getNotificationBySlug (string slug)
        {
            if (String.IsNullOrEmpty(slug))
                return null;

            var data = new List<NotificationModel>()
            {
                getNotification1(),
                getNotification2(),
                getNotification3()
            }
            .Where(x => x.action == "view_more")
            .Where(x => x.actionValue == slug)
            .Select(x => new FlutterNotificationModel()
            {
                title = x.title,
                content = x.content,
                createdDate = x.createdDate
            })
            .FirstOrDefault();

            return data;
        }
    }
}