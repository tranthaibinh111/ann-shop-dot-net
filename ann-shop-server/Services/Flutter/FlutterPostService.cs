using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterPostService: Service<FlutterPostService>
    {
        #region Hard code Test
        /// <summary>
        /// Buôn bán quần áo nữ online cần lưu ý những gì?
        /// </summary>
        /// <returns></returns>
        private NewsModel getPost1()
        {
            var summary = String.Empty;
            summary += "Kinh doanh online được xem là giải pháp tối ưu đối với nhiều người và rất phù hợp với những ai có nguồn vốn thấp. Đặc biệt, mua bán quần áo nữ online đang là xu hướng chung đối với nhiều bạn trẻ. Tuy nhiên, để mở shop bán thời trang nữ online đó không phải là đều đơn giản bởi nó đòi hỏi cần phải phụ thuộc vào...";

            var content = new StringBuilder();
            content.AppendLine("<header class='entry-header'>");
            content.AppendLine("<figure id='carousel-810' class='entry-thumbnail' data-owl-carousel=' data-hide_pagination_control='yes' data-desktop='1' data-desktop_small='1' data-tablet='1' data-mobile='1'>");
            content.AppendLine("<img src='https://ann.com.vn/wp-content/uploads/23.png' class='attachment-full size-full basel-lazy-load basel-lazy-none wp-post-image basel-loaded' alt=' data-basel-src='https://ann.com.vn/wp-content/uploads/23.png' srcset=' width='474' height='329'>");
            content.AppendLine("</figure>");
            content.AppendLine("<div class='post-date' onclick='if (!window.__cfRLUnblockHandlers) return false; '>");
            content.AppendLine("<span class='post-date-day'>");
            content.AppendLine("26 </span>");
            content.AppendLine("<span class='post-date-month'>");
            content.AppendLine("Th12 </span>");
            content.AppendLine("</div>");
            content.AppendLine("<div class='post-mask'>");
            content.AppendLine("<div class='meta-post-categories'><a href='https://ann.com.vn/khong-phan-loai' rel='category tag'>Chưa được phân loại</a></div>");
            content.AppendLine("<h1 class='entry-title'>Buôn bán quần áo nữ online cần lưu ý những gì?</h1>");
            content.AppendLine("<div class='entry-meta basel-entry-meta'>");
            content.AppendLine("<ul class='entry-meta-list'>");
            content.AppendLine("<li class='modified-date'><time class='updated' datetime='2019-12-26T11:42:27+07:00'>26/12/2019</time></li>");
            content.AppendLine("<li class='meta-author'>");
            content.AppendLine("Posted by <a href='https://ann.com.vn/author/content-bs' rel='author'>");
            content.AppendLine("<span class='vcard author author_name'>");
            content.AppendLine("<span class='fn'>BS Content</span>");
            content.AppendLine("</span>");
            content.AppendLine("</a>");
            content.AppendLine("</li>");
            content.AppendLine("<li class='meta-tags'><a href='https://ann.com.vn/chu-de/buon-ban-quan-ao-nu-online-can-luu-y-nhung-gi' rel='tag'>Buôn bán quần áo nữ online cần lưu ý những gì?</a></li>");
            content.AppendLine("</ul>");
            content.AppendLine("</div>");
            content.AppendLine("</div>");
            content.AppendLine("</header>");
            content.AppendLine("<div class='entry-content'>");
            content.AppendLine("<p><i><span style='font-weight: 400'>Kinh doanh online được xem là giải pháp tối ưu đối với nhiều người và rất phù hợp với những ai có nguồn vốn thấp. Đặc biệt, mua </span></i><a href='https://ann.com.vn/quan-ao-nu-gia-si'><b><i>bán quần áo nữ online</i></b></a><i><span style='font-weight: 400'> đang là xu hướng chung đối với nhiều bạn trẻ. Tuy nhiên, để mở shop bán thời trang nữ online đó không phải là đều đơn giản bởi nó đòi hỏi cần phải phụ thuộc vào nhiều yếu tố khác nhau. Đồng thời, để quá trình kinh doanh của bạn trở nên hiệu quả, bạn cần nên có những lưu ý cần thiết ngay khi bắt đầu tham gia.&nbsp;</span></i></p>");
            content.AppendLine("<p><span style='font-size: 18pt'><b>Một số vấn đề cần quan tâm khi bán quần áo nữ online</b></span></p>");
            content.AppendLine("<p><img class='wp-image-211129 aligncenter lazy-loaded' src='https://ann.com.vn/wp-content/uploads/4a.png' data-lazy-type='image' data-src='https://ann.com.vn/wp-content/uploads/4a.png' alt=' width='629' height='372'><noscript><img class='wp-image-211129 aligncenter' src='https://ann.com.vn/wp-content/uploads/4a.png' alt=' width='629' height='372'/></noscript></p>");
            content.AppendLine("<p><i><span style='font-weight: 400'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Một số lưu ý khi </span></i><b><i>bán thời trang nữ online</i></b></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Như các bạn đã biết, ngày nay việc bán hàng online đã không còn xa lạ đối với nhiều người, đặc biệt là các bạn trẻ khi mới bắt đầu tập tành kinh doanh. Tuy nhiên, cùng là hình thức bán hàng online, thế nhưng lại có bạn thành công có bạn lại thất bại. Vậy điều gì đã làm nên sự thành công đó? Chúng ta hãy cùng nhau tìm hiểu về các vấn đề cần nên lưu ý để đi đến sự thành công.&nbsp;</span></p>");
            content.AppendLine("<p><span style='font-size: 18pt'><b><i>Nguồn vốn đầu tư</i></b></span></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Kinh doanh bao giờ đòi hỏi cũng cần có vốn, có thể ít hoặc nhiều tùy theo từng hình thức kinh doanh. Riêng đối với bán quần áo nữ online bạn không cần phải bỏ ra quá nhiều vốn. Vì khi có vốn bạn mới có thể tự duy trì, tìm kiếm nguồn hàng và chuẩn bị cho kế hoạch quảng cáo của mình. Điều quan trọng nhất là bạn cần phải nhạy bén trong việc xoay chuyển nguồn dòng tiền mà không bị thiếu hụt.</span></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Lưu ý, đối với hình thức kinh doanh nhỏ bạn chỉ nên nhập sỉ một lượng hàng hóa nhỏ khi mới bắt đầu. Với số vốn bỏ ra chỉ cần từ 1-3 triệu hoặc vài chục triệu, tùy theo quy mô và thương hiệu mà bạn muốn xây dựng.&nbsp;</span></p>");
            content.AppendLine("<p><span style='font-size: 18pt'><b><i>Tìm kiếm nguồn hàng chất lượng</i></b></span></p>");
            content.AppendLine("<p><img class='wp-image-211130 aligncenter lazy-loaded' src='https://ann.com.vn/wp-content/uploads/4b.png' data-lazy-type='image' data-src='https://ann.com.vn/wp-content/uploads/4b.png' alt=' width='615' height='381'><noscript><img class=' wp-image-211130 aligncenter' src='https://ann.com.vn/wp-content/uploads/4b.png' alt=' width='615' height='381'/></noscript></p>");
            content.AppendLine("<p><i><span style='font-weight: 400'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Tìm kiếm nguồn hàng chất lượng</span></i></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Tìm kiếm nguồn hàng cũng là một trong những vấn đề quyết định về sự thành công của bạn. Với nguồn hàng bạn có được với mức giá tốt chất lượng cao thì sẽ thu về lợi nhuận như mong muốn và mang đến lòng tin cho người sử dụng. Lưu ý, để có thể nhập quần áo giá rẻ chất lượng bạn có thể tìm kiếm nguồn hàng từ Quảng Châu, Trung Quốc, Đài Loan.</span></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Đồng thời, để có thể an tâm hơn bạn có thể so sánh giá và chất lượng từ nhiều nguồn hàng khác nhau và cân nhắc trông sự lựa chọn của mình. Tuy nhiên, bạn chỉ nhập hàng với một số lượng nhỏ bạn có thể tìm kiếm ở các khu vực gần và chọn cho mình một vài sản phẩm đẹp nhất để bán. Như thế, vừa có thể tiết kiệm chi phí, vừa không phải ôm hàng với số lượng lớn.&nbsp;</span></p>");
            content.AppendLine("<p><span style='font-size: 18pt'><b><i>Quảng cáo thương hiệu, hàng hóa</i></b></span></p>");
            content.AppendLine("<p><img class='lazy-hidden  wp-image-211131 aligncenter' src='//ann.com.vn/wp-content/plugins/a3-lazy-load/assets/images/lazy_placeholder.gif' data-lazy-type='image' data-src='https://ann.com.vn/wp-content/uploads/4c.png' alt=' width='570' height='477'><noscript><img class=' wp-image-211131 aligncenter' src='https://ann.com.vn/wp-content/uploads/4c.png' alt=' width='570' height='477'/></noscript></p>");
            content.AppendLine("<p><i><span style='font-weight: 400'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Quảng cáo hàng hóa</span></i></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Một trong những khó khăn thường gặp phải khi bán hàng online là có quá nhiều đối thủ cạnh tranh. Tuy nhiên, nếu bạn có thể sở hữu hàng hóa chất lượng giá tốt thì bạn hoàn toàn có thể an tâm về điều đó. Bên cạnh đó, để có thể mở rộng thương hiệu và tăng lượng tiếp cận đối với shop bạn có thể chạy quảng cáo. Như thế, sẽ giúp bạn thương hiệu của bạn sẽ được nhiều người biết đến hơn, tăng lượng tương tác và khả năng bán được hàng cao.</span></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Lưu ý, khi quảng cáo bạn cần nên chuẩn bị cho shop online của bạn với các hình ảnh, nội dung thu hút hoặc mức giá hấp dẫn. Chẳng những thế, để thu hút khách hàng bạn có thể thêm các hình thức khuyến mãi. Song, bạn cũng nên tìm hiểu và nghiên cứu đối thủ cạnh tranh để phát huy lợi thế và khắc phục các điểm hạn chế.&nbsp;</span></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Qua bài chia sẻ trên về một số lưu ý cần thiết khi bán quần áo nữ online, mong rằng có thể hỗ trợ tốt cho bạn trong việc kinh doanh. Đồng thời, nếu bạn đang gặp khó khăn về nguồn hàng, bạn cũng có thể liên hệ với chúng tôi. ANN.COM.VN luôn sẵn sàng đồng hành cùng bạn và mang đến cho bạn với nguồn hàng chất lượng giá tốt.&nbsp;</span></p>");
            content.AppendLine("<p>&nbsp;</p>");
            content.AppendLine("</div>");
            content.AppendLine("<div class='liner-continer'>");
            content.AppendLine("<span class='left-line'></span>");
            content.AppendLine("<ul class='social-icons text-center icons-design-circle icons-size-small social-share '>");
            content.AppendLine("<li class='social-facebook'><a rel='nofollow' href='https://www.facebook.com/sharer/sharer.php?u=https://ann.com.vn/buon-ban-quan-ao-nu-online-can-luu-y-nhung-gi.html' target='_blank' class='><i class='fa fa-facebook'></i><span class='basel-social-icon-name'>Facebook</span></a></li>");
            content.AppendLine("<li class='social-twitter'><a rel='nofollow' href='https://twitter.com/share?url=https://ann.com.vn/buon-ban-quan-ao-nu-online-can-luu-y-nhung-gi.html' target='_blank' class='><i class='fa fa-twitter'></i><span class='basel-social-icon-name'>Twitter</span></a></li>");
            content.AppendLine("<li class='social-email'><a rel='nofollow' href='mailto:?subject=Check%20this%20https://ann.com.vn/buon-ban-quan-ao-nu-online-can-luu-y-nhung-gi.html' target='_blank' class='><i class='fa fa-envelope'></i><span class='basel-social-icon-name'>Email</span></a></li>");
            content.AppendLine("<li class='social-pinterest'><a rel='nofollow' href='https://pinterest.com/pin/create/button/?url=https://ann.com.vn/buon-ban-quan-ao-nu-online-can-luu-y-nhung-gi.html&amp;media=https://ann.com.vn/wp-content/uploads/23.png' target='_blank' class='><i class='fa fa-pinterest'></i><span class='basel-social-icon-name'>Pinterest</span></a></li>");
            content.AppendLine("<li class='social-linkedin'><a rel='nofollow' href='https://www.linkedin.com/shareArticle?mini=true&amp;url=https://ann.com.vn/buon-ban-quan-ao-nu-online-can-luu-y-nhung-gi.html' target='_blank' class='><i class='fa fa-linkedin'></i><span class='basel-social-icon-name'>LinkedIn</span></a></li>");
            content.AppendLine("</ul>");
            content.AppendLine("<span class='right-line'></span>");
            content.AppendLine("</div>");

            return new NewsModel()
            {
                title = "Buôn bán quần áo nữ online cần lưu ý những gì?",
                slug = "buon-ban-quan-ao-nu-online-can-luu-y-nhung-gi",
                avatar = "https://ann.com.vn/wp-content/uploads/23.png",
                summary = summary,
                content = content.ToString(),
                createdDate = DateTime.Now
            };
        }


        /// <summary>
        /// Thông báo thời gian làm việc
        /// </summary>
        /// <returns></returns>
        private NewsModel getPost2()
        {
            var summary = String.Empty;
            summary += "Quần áo, thời trang nam luôn là lĩnh vực chưa bao giờ bị bỏ quên. Tuy nhiên, nó luôn cập nhật và thay đổi một cách liên tục theo mùa, xu hướng và trào lưu. Vì thế, khi muốn kinh doanh lĩnh vực này bạn nên có kinh nghiệm mở shop quần áo nam online để có thể mang đến hiệu quả cao, cũng như hạn chế được các...";

            var content = new StringBuilder();
            content.AppendLine("<header class='entry-header'>");
            content.AppendLine("<figure id='carousel-739' class='entry-thumbnail' data-owl-carousel=' data-hide_pagination_control='yes' data-desktop='1' data-desktop_small='1' data-tablet='1' data-mobile='1'>");
            content.AppendLine("<img src='https://ann.com.vn/wp-content/uploads/2b.png' class='attachment-full size-full basel-lazy-load basel-lazy-none wp-post-image basel-loaded' alt=' data-basel-src='https://ann.com.vn/wp-content/uploads/2b.png' srcset=' width='602' height='446'>");
            content.AppendLine("</figure>");
            content.AppendLine("<div class='post-date' onclick='if (!window.__cfRLUnblockHandlers) return false; '>");
            content.AppendLine("<span class='post-date-day'>");
            content.AppendLine("26 </span>");
            content.AppendLine("<span class='post-date-month'>");
            content.AppendLine("Th12 </span>");
            content.AppendLine("</div>");
            content.AppendLine("<div class='post-mask'>");
            content.AppendLine("<div class='meta-post-categories'><a href='https://ann.com.vn/khong-phan-loai' rel='category tag'>Chưa được phân loại</a></div>");
            content.AppendLine("<h1 class='entry-title'>Kinh nghiệm mở shop quần áo nam online ít vốn cho người mới bắt đầu</h1>");
            content.AppendLine("<div class='entry-meta basel-entry-meta'>");
            content.AppendLine("<ul class='entry-meta-list'>");
            content.AppendLine("<li class='modified-date'><time class='updated' datetime='2019-12-26T11:02:14+07:00'>26/12/2019</time></li>");
            content.AppendLine("<li class='meta-author'>");
            content.AppendLine("Posted by <a href='https://ann.com.vn/author/content-bs' rel='author'>");
            content.AppendLine("<span class='vcard author author_name'>");
            content.AppendLine("<span class='fn'>BS Content</span>");
            content.AppendLine("</span>");
            content.AppendLine("</a>");
            content.AppendLine("</li>");
            content.AppendLine("<li class='meta-tags'><a href='https://ann.com.vn/chu-de/kinh-nghiem-mo-shop-quan-ao-nam-online-it-von-cho-nguoi-moi-bat-dau' rel='tag'>Kinh nghiệm mở shop quần áo nam online ít vốn cho người mới bắt đầu</a></li>");
            content.AppendLine("</ul>");
            content.AppendLine("</div>");
            content.AppendLine("</div>");
            content.AppendLine("</header>");
            content.AppendLine("<div class='entry-content'>");
            content.AppendLine("<p><i><span style='font-weight: 400'>Quần áo, thời trang nam luôn là lĩnh vực chưa bao giờ bị bỏ quên. Tuy nhiên, nó luôn cập nhật và thay đổi một cách liên tục theo mùa, xu hướng và trào lưu. Vì thế, khi muốn kinh doanh lĩnh vực này bạn nên có </span></i><a href='https://ann.com.vn/bo-si-quan-ao-nam-nu-gia-xuong-may-tphcm'><b><i>kinh nghiệm mở shop quần áo nam</i></b></a><i><span style='font-weight: 400'> online để có thể mang đến hiệu quả cao, cũng như hạn chế được các vấn đề có thể gặp phải. Đặc biệt, với những ai mới bắt đầu thì đây chắc hẳn là bài học kinh nghiệm đáng để bạn quan tâm.&nbsp;</span></i></p>");
            content.AppendLine("<p><img class='size-full wp-image-211125 aligncenter lazy-loaded' src='https://ann.com.vn/wp-content/uploads/3a.png' data-lazy-type='image' data-src='https://ann.com.vn/wp-content/uploads/3a.png' alt=' width='557' height='361'><noscript><img class='size-full wp-image-211125 aligncenter' src='https://ann.com.vn/wp-content/uploads/3a.png' alt=' width='557' height='361'/></noscript></p>");
            content.AppendLine("<p><i><span style='font-weight: 400'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Kinh nghiệm mở shop quần áo nam online</span></i></p>");
            content.AppendLine("<p><span style='font-size: 18pt'><b>Lên ý tưởng về cửa hàng</b></span></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Phác thảo ý tưởng là một trong những vấn đề quan trọng không nên bỏ qua. Có thể nói, đây là tiền đề để bạn có thể thực hiện các bước tiếp theo. Ở phần này bạn cần làm rõ với các thông tin cần có như: tên cửa hàng, phong cách thiết kế, đối tượng khách hàng, mục đích hướng đến, mục tiêu phát triển trong 5 năm, …</span></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Lưu ý, bạn cần nên cân nhắc trong việc chọn tên cửa hàng bởi nó nói lên loại mặt hàng muốn bán. Đồng thời, bạn cần nên cân nhắc trong việc lựa chọn xu hướng, quần áo của bạn nhằm mang đến cho khách hàng cảm giác gì: sự trẻ trung, trưởng thành, mạnh mẽ, cá tính hay sự chững chạc,…&nbsp;</span></p>");
            content.AppendLine("<p><span style='font-size: 18pt'><b>Tiến hành lập kế hoạch kinh doanh</b></span></p>");
            content.AppendLine("<p><img class='lazy-hidden size-full wp-image-211126 aligncenter' src='//ann.com.vn/wp-content/plugins/a3-lazy-load/assets/images/lazy_placeholder.gif' data-lazy-type='image' data-src='https://ann.com.vn/wp-content/uploads/3b.png' alt=' width='561' height='373'><noscript><img class='size-full wp-image-211126 aligncenter' src='https://ann.com.vn/wp-content/uploads/3b.png' alt=' width='561' height='373'/></noscript></p>");
            content.AppendLine("<p><i><span style='font-weight: 400'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Lập kế hoạch kinh doanh</span></i></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Lập kế hoạch kinh doanh là cách để giúp bạn có thể dự đoán được các vấn đề cũng như mục tiêu mà bạn hướng đến. Từ đó, giúp công việc của bạn trở nên suôn sẻ hơn và tránh được các rắc rối có thể gặp phải. Đồng thời, dựa trên kế hoặc bạn có thể các định rõ hướng đi và các giai đoạn cần thực hiện. Ở giai đoạn này bạn cần nên xác định được các vấn đề sau:</span></p>");
            content.AppendLine("<ul>");
            content.AppendLine("<li style='font-weight: 400'><span style='font-weight: 400'>Xác định loại mô hình kinh doanh shop thời trang nam</span></li>");
            content.AppendLine("<li style='font-weight: 400'><span style='font-weight: 400'>Xác định được đối tượng khách hàng mục tiêu mà bạn muốn hướng đến</span></li>");
            content.AppendLine("<li style='font-weight: 400'><span style='font-weight: 400'>Cần nghiên cứu thị trường và phân khúc đối tượng khách hàng</span></li>");
            content.AppendLine("<li style='font-weight: 400'><span style='font-weight: 400'>Xác định nguồn vốn mà bạn muốn bỏ ra&nbsp;</span></li>");
            content.AppendLine("<li style='font-weight: 400'><span style='font-weight: 400'>Tìm kiếm nguồn cung cấp quần áo nam uy tín, chất lượng&nbsp;</span></li>");
            content.AppendLine("</ul>");
            content.AppendLine("<p><span style='font-size: 18pt'><b>Xác định vị trí shop ( lập web, facebook, …)</b></span></p>");
            content.AppendLine("<p><img class='lazy-hidden  wp-image-211127 aligncenter' src='//ann.com.vn/wp-content/plugins/a3-lazy-load/assets/images/lazy_placeholder.gif' data-lazy-type='image' data-src='https://ann.com.vn/wp-content/uploads/3c.png' alt=' width='555' height='333'><noscript><img class=' wp-image-211127 aligncenter' src='https://ann.com.vn/wp-content/uploads/3c.png' alt=' width='555' height='333'/></noscript></p>");
            content.AppendLine("<p><i><span style='font-weight: 400'>Xác định vị trí kinh doanh online&nbsp;</span></i></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Cần nên xác định rõ vị trí mà bạn muốn mở shop online, có thể là: website,&nbsp; facebook,.. Riêng với những ai có ít vốn bạn có thể kinh doanh shop thời trang nam trên page.&nbsp;</span></p>");
            content.AppendLine("<p><span style='font-size: 18pt'><b>Thiết kế shop online</b></span></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Cũng giống như các cửa hàng truyền thống, việc mở shop online đòi hỏi bạn cũng cần nên thiết kế đẹp mắt. Với một trang web, trang page bắt mắt sẽ là giúp bạn nhận được điểm cộng từ phía khách hàng. Đồng thời, dù là shop online bạn cũng cần nên thường xuyên cập nhật với những sản phẩm về mẫu quần áo nam đẹp để tăng khả năng tiếp cận đối với khách hàng.&nbsp;</span></p>");
            content.AppendLine("<p><span style='font-size: 18pt'><b>Giới thiệu quảng bá thương hiệu&nbsp;</b></span></p>");
            content.AppendLine("<p><img class='lazy-hidden size-full wp-image-211128 aligncenter' src='//ann.com.vn/wp-content/plugins/a3-lazy-load/assets/images/lazy_placeholder.gif' data-lazy-type='image' data-src='https://ann.com.vn/wp-content/uploads/3d.png' alt=' width='558' height='401'><noscript><img class='size-full wp-image-211128 aligncenter' src='https://ann.com.vn/wp-content/uploads/3d.png' alt=' width='558' height='401'/></noscript></p>");
            content.AppendLine("<p><i><span style='font-weight: 400'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Giới thiệu quảng bá thương hiệu</span></i></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Đối với shop online thì làm thế nào để quảng bá được hình ảnh thương hiệu của mình? Bạn có thể chạy quảng cáo cho thương hiệu của mình. Tuy nhiên, để việc quảng cáo có thể mang đến hiệu quả cao bạn nên chọn chuẩn bị với một trang page đẹp, quần áo phù hợp xu hướng, thiết kế mới,… Đồng thời, bạn cũng cần nên biết một chút về thủ thuật quảng cáo để có thể tối ưu chi phí nhưng lại hiệu quả cao. Thông qua việc quảng cáo sẽ giúp shop của bạn có thể tiếp cận hơn với nhiều, giúp tăng khả năng tương tác và mua hàng cao.&nbsp;</span></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Bằng những <a href='https://ann.com.vn/quan-ao-nam-gia-si'><strong>kinh nghiệm mở shop quần áo nam online</strong></a> trên, hy vọng có thể mang đến với bạn những kiến thức cần thiết và bổ ích. Bên cạnh đó, để có thể hiểu rõ hơn hoặc đang gặp khó khăn trong việc tìm kiếm nhà cung cấp, bạn có thể liên hệ với ANN.COM.VN để được hỗ trợ, tư vấn tốt nhất.&nbsp;</span></p>");
            content.AppendLine("</div>");
            content.AppendLine("<div class='liner-continer'>");
            content.AppendLine("<span class='left-line'></span>");
            content.AppendLine("<ul class='social-icons text-center icons-design-circle icons-size-small social-share '>");
            content.AppendLine("<li class='social-facebook'><a rel='nofollow' href='https://www.facebook.com/sharer/sharer.php?u=https://ann.com.vn/kinh-nghiem-mo-shop-quan-ao-nam-online-it-von-cho-nguoi-moi-bat-dau.html' target='_blank' class='><i class='fa fa-facebook'></i><span class='basel-social-icon-name'>Facebook</span></a></li>");
            content.AppendLine("<li class='social-twitter'><a rel='nofollow' href='https://twitter.com/share?url=https://ann.com.vn/kinh-nghiem-mo-shop-quan-ao-nam-online-it-von-cho-nguoi-moi-bat-dau.html' target='_blank' class='><i class='fa fa-twitter'></i><span class='basel-social-icon-name'>Twitter</span></a></li>");
            content.AppendLine("<li class='social-email'><a rel='nofollow' href='mailto:?subject=Check%20this%20https://ann.com.vn/kinh-nghiem-mo-shop-quan-ao-nam-online-it-von-cho-nguoi-moi-bat-dau.html' target='_blank' class='><i class='fa fa-envelope'></i><span class='basel-social-icon-name'>Email</span></a></li>");
            content.AppendLine("<li class='social-pinterest'><a rel='nofollow' href='https://pinterest.com/pin/create/button/?url=https://ann.com.vn/kinh-nghiem-mo-shop-quan-ao-nam-online-it-von-cho-nguoi-moi-bat-dau.html&amp;media=https://ann.com.vn/wp-content/uploads/2b.png' target='_blank' class='><i class='fa fa-pinterest'></i><span class='basel-social-icon-name'>Pinterest</span></a></li>");
            content.AppendLine("<li class='social-linkedin'><a rel='nofollow' href='https://www.linkedin.com/shareArticle?mini=true&amp;url=https://ann.com.vn/kinh-nghiem-mo-shop-quan-ao-nam-online-it-von-cho-nguoi-moi-bat-dau.html' target='_blank' class='><i class='fa fa-linkedin'></i><span class='basel-social-icon-name'>LinkedIn</span></a></li>");
            content.AppendLine("</ul>");
            content.AppendLine("<span class='right-line'></span>");
            content.AppendLine("</div>");

            return new NewsModel()
            {
                title = "Kinh nghiệm mở shop quần áo nam online ít vốn cho người mới bắt đầu",
                slug = "kinh-nghiem-mo-shop-quan-ao-nam-online-it-von-cho-nguoi-moi-bat-dau",
                avatar = "https://ann.com.vn/wp-content/uploads/2b.png",
                summary = summary,
                content = summary,
                createdDate = DateTime.Now
            };
        }
        #endregion

        /// <summary>
        /// Lấy danh sách newsletter dạng banner
        /// </summary>
        /// <returns></returns>
        public List<FlutterBannerModel> getHomePosts()
        {
            var result = new List<FlutterBannerModel>();

            // Thông báo đổi hàng cuối năm
            var post1 = getPost1();
            result.Add(new FlutterBannerModel()
            {
                action = "category",
                name = post1.title,
                actionValue = post1.slug,
                image = post1.avatar,
                message = post1.summary,
                createdDate = post1.createdDate
            });

            // Kinh nghiệm mở shop quần áo nam online ít vốn cho người mới bắt đầu
            var post2 = getPost2();
            result.Add(new FlutterBannerModel()
            {
                action = "category",
                name = post2.title,
                actionValue = post2.slug,
                image = post2.avatar,
                message = post2.summary,
                createdDate = post2.createdDate
            });

            return result;
        }

        public List<FlutterPostCardModel> getPosts(ref PaginationMetadataModel pagination)
        {
            var data = new List<NewsModel>()
            {
                getPost1(),
                getPost2()
            }
            .Select(x => new FlutterPostCardModel()
            {
                title = x.title,
                slug = x.slug,
                avatar = x.avatar,
                summary = x.summary,
                createdDate = x.createdDate
            })
            .OrderByDescending(o => o.createdDate)
            .ToList();

            // Lấy tổng số record sản phẩm
            pagination.totalCount = data.Count();

            // Calculating Totalpage by Dividing (No of Records / Pagesize)
            pagination.totalPages = (int)Math.Ceiling(pagination.totalCount / (double)pagination.pageSize);

            var result = data
                .Skip((pagination.currentPage - 1) * pagination.pageSize)
                .Take(pagination.pageSize)
                .ToList();

            // if CurrentPage is greater than 1 means it has previousPage
            pagination.previousPage = pagination.currentPage > 1 ? "Yes" : "No";

            // if TotalPages is greater than CurrentPage means it has nextPage
            pagination.nextPage = pagination.currentPage < pagination.totalPages ? "Yes" : "No";

            return result;
        }


        public FlutterPostModel getPostBySlug(string slug)
        {
            if (String.IsNullOrEmpty(slug))
                return null;

            var data = new List<NewsModel>()
            {
                getPost1(),
                getPost2()
            }
            .Select(x => new FlutterPostModel()
            {
                title = x.title,
                slug = x.slug,
                content = x.content,
                createdDate = x.createdDate
            })
            .ToList();

            return data.Where(x => x.slug == slug).FirstOrDefault();
        }
    }
}