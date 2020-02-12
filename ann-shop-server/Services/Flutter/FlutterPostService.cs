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
            content.AppendLine("<img src='https://ann.com.vn/wp-content/uploads/23.png' class='attachment-full size-full basel-lazy-load basel-lazy-none wp-post-image basel-loaded' alt=''data-basel-src='https://ann.com.vn/wp-content/uploads/23.png' srcset=' width='474' height='329'>");
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
            content.AppendLine("<p><img class='wp-image-211129 aligncenter lazy-loaded' src='https://ann.com.vn/wp-content/uploads/4a.png' data-lazy-type='image' data-src='https://ann.com.vn/wp-content/uploads/4a.png' alt='' width='629' height='372'><noscript><img class='wp-image-211129 aligncenter' src='https://ann.com.vn/wp-content/uploads/4a.png' alt='' width='629' height='372'/></noscript></p>");
            content.AppendLine("<p><i><span style='font-weight: 400'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Một số lưu ý khi </span></i><b><i>bán thời trang nữ online</i></b></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Như các bạn đã biết, ngày nay việc bán hàng online đã không còn xa lạ đối với nhiều người, đặc biệt là các bạn trẻ khi mới bắt đầu tập tành kinh doanh. Tuy nhiên, cùng là hình thức bán hàng online, thế nhưng lại có bạn thành công có bạn lại thất bại. Vậy điều gì đã làm nên sự thành công đó? Chúng ta hãy cùng nhau tìm hiểu về các vấn đề cần nên lưu ý để đi đến sự thành công.&nbsp;</span></p>");
            content.AppendLine("<p><span style='font-size: 18pt'><b><i>Nguồn vốn đầu tư</i></b></span></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Kinh doanh bao giờ đòi hỏi cũng cần có vốn, có thể ít hoặc nhiều tùy theo từng hình thức kinh doanh. Riêng đối với bán quần áo nữ online bạn không cần phải bỏ ra quá nhiều vốn. Vì khi có vốn bạn mới có thể tự duy trì, tìm kiếm nguồn hàng và chuẩn bị cho kế hoạch quảng cáo của mình. Điều quan trọng nhất là bạn cần phải nhạy bén trong việc xoay chuyển nguồn dòng tiền mà không bị thiếu hụt.</span></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Lưu ý, đối với hình thức kinh doanh nhỏ bạn chỉ nên nhập sỉ một lượng hàng hóa nhỏ khi mới bắt đầu. Với số vốn bỏ ra chỉ cần từ 1-3 triệu hoặc vài chục triệu, tùy theo quy mô và thương hiệu mà bạn muốn xây dựng.&nbsp;</span></p>");
            content.AppendLine("<p><span style='font-size: 18pt'><b><i>Tìm kiếm nguồn hàng chất lượng</i></b></span></p>");
            content.AppendLine("<p><img class='wp-image-211130 aligncenter lazy-loaded' src='https://ann.com.vn/wp-content/uploads/4b.png' data-lazy-type='image' data-src='https://ann.com.vn/wp-content/uploads/4b.png' alt='' width='615' height='381'><noscript><img class=' wp-image-211130 aligncenter' src='https://ann.com.vn/wp-content/uploads/4b.png' alt='' width='615' height='381'/></noscript></p>");
            content.AppendLine("<p><i><span style='font-weight: 400'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Tìm kiếm nguồn hàng chất lượng</span></i></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Tìm kiếm nguồn hàng cũng là một trong những vấn đề quyết định về sự thành công của bạn. Với nguồn hàng bạn có được với mức giá tốt chất lượng cao thì sẽ thu về lợi nhuận như mong muốn và mang đến lòng tin cho người sử dụng. Lưu ý, để có thể nhập quần áo giá rẻ chất lượng bạn có thể tìm kiếm nguồn hàng từ Quảng Châu, Trung Quốc, Đài Loan.</span></p>");
            content.AppendLine("<p><span style='font-weight: 400'>Đồng thời, để có thể an tâm hơn bạn có thể so sánh giá và chất lượng từ nhiều nguồn hàng khác nhau và cân nhắc trông sự lựa chọn của mình. Tuy nhiên, bạn chỉ nhập hàng với một số lượng nhỏ bạn có thể tìm kiếm ở các khu vực gần và chọn cho mình một vài sản phẩm đẹp nhất để bán. Như thế, vừa có thể tiết kiệm chi phí, vừa không phải ôm hàng với số lượng lớn.&nbsp;</span></p>");
            content.AppendLine("<p><span style='font-size: 18pt'><b><i>Quảng cáo thương hiệu, hàng hóa</i></b></span></p>");
            content.AppendLine("<p><img class='lazy-hidden  wp-image-211131 aligncenter' src='//ann.com.vn/wp-content/plugins/a3-lazy-load/assets/images/lazy_placeholder.gif' data-lazy-type='image' data-src='https://ann.com.vn/wp-content/uploads/4c.png' alt='' width='570' height='477'><noscript><img class=' wp-image-211131 aligncenter' src='https://ann.com.vn/wp-content/uploads/4c.png' alt='' width='570' height='477'/></noscript></p>");
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
                categorySlug = "buon-ban",
                title = "Buôn bán quần áo nữ online cần lưu ý những gì?",
                action = "view_more",
                actionValue = "buon-ban-quan-ao-nu-online-can-luu-y-nhung-gi",
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

            return new NewsModel()
            {
                categorySlug = "kinh-nghiem",
                title = "Kinh nghiệm mở shop quần áo nam online ít vốn cho người mới bắt đầu",
                action = "show_web",
                actionValue = "https://ann.com.vn/kinh-nghiem-mo-shop-quan-ao-nam-online-it-von-cho-nguoi-moi-bat-dau.html",
                avatar = "https://ann.com.vn/wp-content/uploads/2b.png",
                summary = summary,
                content = String.Empty,
                createdDate = DateTime.Now
            };
        }


        /// <summary>
        /// May áo thun đồng phục
        /// </summary>
        /// <returns></returns>
        private NewsModel getPost3()
        {
            var content = new StringBuilder();
            content.AppendLine("<p><strong>Xưởng Áo Thun ANN</strong>&nbsp;nhận đặt may áo thun đồng phục giá rẻ chất lượng tốt (thực chất là giá sỉ). Sản phẩm áo thun đồng phục giá rẻ của chúng tôi rất phù hợp cho cửa hàng, văn phòng công sở, trường học, các hoạt động du lịch, vui chơi, giải trí,…</p>");
            content.AppendLine("<p>Quý khách có nhu cầu may áo thun đồng phục, hãy liên hệ ngay Xưởng sỉ áo thun ANN nhé!</p>");
            content.AppendLine("<p>Chúng tôi nhận đặt may đồng phục số lượng từ 30 cái – 5.000 cái, <strong>ANN</strong> sẽ may theo mẫu của quý khách và trả hàng trong vòng 10 ngày (đơn từ 1.000 cái thời gian sẽ lâu hơn).</p>");
            content.AppendLine("<p><span style='color: #ff0000;'>Lưu ý, Xưởng mình chỉ nhận đặt may áo thun, không nhận các loại áo khác (như sơ mi, áo khoác, quần, áo bảo hộ…).</span></p>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-ca-sau-co-co.jpg' alt='Xưởng may áo thun đồng phục giá rẻ tại TPHCM - Xưởng Sỉ Áo Thun ANN'>");
            content.AppendLine("<h2>Tại sao nên đặt may áo thun đồng phục tại Xưởng may áo thun ANN?</h2>");
            content.AppendLine("<p>So với việc đặt làm áo thun đồng phục tại các công ty may đồng phục khác, thì chúng tôi có lợi thế là <strong>cung cấp áo thun giá sỉ</strong> cho quý khách (xin nhắc lại là giá sỉ). Bởi vì ngoài áo thun đồng phục ra thì chúng tôi cung cấp hàng nghìn mặt hàng thời trang giá sỉ nam nữ trên toàn quốc. Chắc chắn là sẽ có giá tận gốc đi kèm với chất lượng đảm bảo.</p>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/may-ao-thun-dong-phuc-co-co.jpg'>");
            content.AppendLine("<p>Ngoài ra, chúng tôi tính riêng giá áo nam và áo nữ, so với các địa chỉ khác luôn tính chung giá áo nam nữ. Hơn nữa, nếu quý khách đặt may áo thun đồng phục giá rẻ số lượng lớn thì sẽ được chiết khấu theo bảng chiết khấu trên giá sỉ của chúng tôi. Ưu đãi thật hấp dẫn đúng không nào?</p>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/o-dong-phuc-nhan-vien-samsung-viet-nam-tphcm-tan-binh.jpg' alt='Áo thun đồng phục giá sỉ tận gốc xưởng may áo thun ANN'>");
            content.AppendLine("<p><strong>ANN.COM.VN</strong> chuyên cung cấp áo thun vải thun cá sấu (chất liệu 65% cotton, 35% Poli) và vải thun cá mập (100% cotton). Hai loại vải này rất được ưa chuộng để may áo đồng phục, vì nó có độ dày vừa phải, độ co giãn 4 chiều, thấm hút mồ hôi tốt.</p>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/chon-chat-lieu-cho-ao-thun-dong-phuc-1.jpg' alt='Vải thun cá mập 100% cotton'>");
            content.AppendLine("<p>ANN chuyên thêu vi tính logo, chữ, hình ảnh trên áo, vì vải cá sấu (hoặc cá mập) phù hợp với thêu hơn so với in. Chúng tôi sẽ tính giá thêu riêng so với giá áo.</p>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/vai-thun-ca-sau-cotton.jpg' alt='Áo đồng phục vải thun cá sấu 65% cotton, co giãn 4 chiều'>");
            content.AppendLine("<h3>Bảng giá áo đồng phục và giá thêu vi tính:</h3>");
            content.AppendLine("<p>Giá áo thun vải cá sấu 65% cotton (giá áo trơn, chưa tính tiền logo):</p>");
            content.AppendLine("<ul>");
            content.AppendLine("<li>Dưới 30 cái: chúng tôi chỉ bán áo thun thành phẩm, có logo thương hiệu thời trang quốc tế,… xem thêm mẫu và giá sỉ&nbsp;<a href='https://bosiquanao.net/c/quan-ao-nam/ao-thun-nam/ao-thun-nam-ca-sau/' target='_blank' rel='noopener noreferrer'>tại đây</a>.</li>");
            content.AppendLine("<li><span style='color: #ff0000;'>30 cái: áo nam 85.000đ – áo nữ 65.000đ.</span></li>");
            content.AppendLine("<li><span style='color: #ff0000;'>100 cái: áo nam 82.000đ – áo nữ 62.000đ.</span></li>");
            content.AppendLine("<li><span style='color: #ff0000;'>500 cái: áo nam 78.000đ – áo nữ 58.000đ.</span></li>");
            content.AppendLine("<li><span style='color: #ff0000;'>1.000 cái: áo nam 76.000đ – áo nữ 56.000đ.</span></li>");
            content.AppendLine("</ul>");
            content.AppendLine("<p>Giá áo thun vải cá mập 100% cotton (giá áo trơn, chưa tính tiền logo):</p>");
            content.AppendLine("<ul>");
            content.AppendLine("<li><span style='color: #ff0000;'>30 cái: áo nam 120.000đ – áo nữ 110.000đ.</span></li>");
            content.AppendLine("<li><span style='color: #ff0000;'>100 cái: áo nam 115.000đ – áo nữ 105.000đ.</span></li>");
            content.AppendLine("<li><span style='color: #ff0000;'>500 cái: áo nam 110.000đ – áo nữ 100.000đ.</span></li>");
            content.AppendLine("<li><span style='color: #ff0000;'>1.000 cái: áo nam 105.000đ – áo nữ 95.000đ.</span></li>");
            content.AppendLine("</ul>");
            content.AppendLine("<p>Giá thêu logo: liên hệ để được báo giá chi tiết</p>");
            content.AppendLine("<p>Lưu ý, bảng giá này chưa bao gồm 10% thuế VAT và chỉ áo dụng cho 1 đơn hàng đặt 1 lần, không cộng dồn nhiều lần.</p>");
            content.AppendLine("<h3>Quy trình đặt may áo thun đồng phục giá rẻ</h3>");
            content.AppendLine("<p>Bước 1: quý khách gửi mẫu áo đồng phục, số lượng từng size, yêu cầu thiết kế,… cho chúng tôi.</p>");
            content.AppendLine("<p>Bước 2: chúng tôi thiết kế, chốt yêu cầu của quý khách và gửi hóa đơn thanh toán cho quý khách.</p>");
            content.AppendLine("<p>Bước 3: quý khách đặt cọc 50% hóa đơn, chúng tôi sẽ tiến hành may và báo thời gian hoàn thành đơn hàng cho quý khách.</p>");
            content.AppendLine("<p>Bước 4: sau khi đơn hàng thành công, quý khách thanh toán 50% hóa đơn còn lại. ANN sẽ gửi hàng đến địa chỉ của quý khách (miễn phí giao nội ô TP.HCM).</p>");
            content.AppendLine("<h3>Thông tin liên hệ đặt hàng</h3>");
            content.AppendLine("<p>Địa chỉ: 68 Đường C12, Phường 13, Tân Bình, TP. HCM <a title='Xem bản đồ' rel='nofollow' href='https://khohangsiann.com/lien-he'>(xem bản đồ)</a></p>");
            content.AppendLine("<p>Zalo: <a href='https://zalo.me/0918567409' class='zalo-0918567409' id='zalonow' target='_blank' rel='nofollow'>0918567409</a> - <a href='https://zalo.me/0913268406' class='zalo-0913268406' id='zalonow' target='_blank' rel='nofollow'>0913268406</a> - <a href='https://zalo.me/0936786404' class='zalo-0936786404' id='zalonow' target='_blank' rel='nofollow'>0936786404</a> - <a href='https://zalo.me/0918569400' class='zalo-0918569400' id='zalonow' target='_blank' rel='nofollow'>0918569400</a></p>");
            content.AppendLine("<p>Facebook: <a href='https://m.me/bosiquanao.net' target='_blank' rel='nofollow'>bấm vào đây</a></p>");
            content.AppendLine("<p>Làm việc: 8h30 - 19h30 (Thứ 2 - Thứ 7) ; 8h30 - 17h (Chủ Nhật) </p>");
            content.AppendLine("<p>Nếu quý khách còn phân vân nơi nào nhận đặt may áo thun đồng phục giá rẻ và tốt nhất TP. HCM thì không cần phải tìm kiếm nữa. <strong>ANN.COM.VN</strong> chính là nơi thích hợp cho quý khách nhất. Ngoài áo thun đồng phục giá rẻ, chúng tôi còn rất nhiều sản phẩm quần áo giá sỉ khác, quý khách tha hồ lựa chọn nhé!</p>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao_thun_dong_phuc_31_master.jpg' alt='Áo thun đồng phục có cổ'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao_thun_dong_phuc_42_master.jpg' alt='Áo thun đồng phục có cổ'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao_thun_dong_phuc_44_master.jpg' alt='Áo thun đồng phục có cổ'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao_thun_dong_phuc_45.jpg' alt='Áo thun đồng phục có cổ'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao_thun_dong_phuc_55_master.jpg' alt='Xưởng may áo thun đồng phục'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/dong-phuc-ao-thun-66.jpg' alt='Xưởng may áo thun đồng phục'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/dong-phuc-ao-thun-70.jpg' alt='Xưởng may áo thun đồng phục'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/dong-phuc-ao-thun-52.jpg' alt='Đặt may áo thun đồng phục cá sấu'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-cong-ty-lenovo-mat-truoc.jpg'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-spa.jpg' alt='Đặt may áo thun đồng phục cá sấu'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-gia-re.jpg' alt='Đặt may áo thun đồng phục cá sấu'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-gia-re-2.jpg' alt='Đặt may áo thun đồng phục cá sấu'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-cong-ty-b2be-mat-truoc1.jpg' alt='Làm áo thun đồng phục công ty'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-cua-hang-lotteria-mat-truoc.jpg' alt='Làm áo thun đồng phục công ty'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-xe-vespa-mat-truoc.jpg' alt='Làm áo thun đồng phục công ty'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-ngan-hang-ocean-bank-mat-truoc.jpg' alt='Làm áo thun đồng phục công ty'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-cong-ty-wondo-mat-truoc.jpg' alt='Áo thun đồng phục giá rẻ'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-cong-ty-damco-truoc.jpg'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-cong-ty-king-pro-mat-truoc.jpg' alt='Áo thun đồng phục giá rẻ'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-cong-ty-takira-mat-truoc.jpg' alt='Áo thun đồng phục tphcm'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-cong-ty-aia-mat-truoc.jpg' alt='Áo thun đồng phục tphcm'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-cong-ty-hls-mat-truoc.jpg' alt='Áo thun đồng phục tphcm'>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/ao-thun-dong-phuc-cong-ty-mercedes-benz-mat-truoc.jpg' alt='Áo thun đồng phục tphcm'>");
            content.AppendLine("<p>Chân thành cảm ơn quý khách!</p>");

            return new NewsModel()
            {
                categorySlug = "buon-ban",
                title = "May áo thun đồng phục",
                action = "view_more",
                actionValue = "may-ao-thun-dong-phuc",
                avatar = String.Empty,
                summary = String.Empty,
                content = content.ToString(),
                createdDate = new DateTime(2020, 02, 06),
            };
        }

        /// <summary>
        /// Sỉ gel rửa tay khô 24h
        /// </summary>
        /// <returns></returns>
        private NewsModel getPost4()
        {
            var content = new StringBuilder();
            content.AppendLine("<p><span style='color: #ff0000;'><strong>♻️ Cập nhật ngày 7/2/2020:</strong> hơn <strong>85.000</strong> sản phẩm đã được phân phối ra thị trường. Hiện nay, nguồn hàng đang dần cạn kiệt và đang được gấp rút sản xuất. Quý khách sỉ và các đại lý lên đơn sớm để được ưu tiên nhập hàng ạ!</span></p>");
            content.AppendLine("<p>☎ Mọi chi tiết vui lòng liên hệ hotline <strong><span style='color: #ff0000;'>0913268406 – 0918567409</span> </strong>hoặc các kênh đặt hàng bên dưới!</p>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/si-gel-rua-tay-kho-24h-1.jpg' alt='Sỉ gel rửa tay khô 24h Thiên Nhiên Việt' />");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/si-gel-rua-tay-kho-24h-2.jpg' alt='Sỉ nước rửa tay khô 24h Thiên Nhiên Việt' />");
            content.AppendLine("<p>✌️ Xin chào!</p>");
            content.AppendLine("<p>💢 Như mọi người đã thấy, tình hình dịch cúm viêm phổi Corona ngày càng diễn biến phức tạp. Ngoài trang bị cho mình những chiếc khẩu trang y tế, thì mọi người cần phải vệ sinh cá nhân cho sạch sẽ, nhất là đôi tay của chúng ta. Vì vậy một sản phẩm dung dịch vệ sinh tay là rất cần thiết.</p>");
            content.AppendLine("<p>👉 <strong>Gel rửa tay khô khử trùng 24h Thiên Nhiên Việt</strong> – là sản phẩm hiệu quả mà chúng tôi muốn giới thiệu cho các bạn.</p>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/z1729132506426_913cedef50777ad41c3a77fc0d7b451b.jpg' alt='Gel rửa tay khử trùng 24h thương hiệu Thiên Nhiên Việt'>");
            content.AppendLine("<p>☘ Gel rửa tay khô khử trùng 24h có xuất xứ Việt Nam.</p>");
            content.AppendLine("<p>☘ Sản phẩm có kích thước nhỏ gọn – di động, rất thích hợp mang theo bên người.</p>");
            content.AppendLine("<p>☘ Với thành phần chính từ thiên nhiên như: nha đam, gừng, sả, chanh, hành tây, tỏi… Gel rửa tay khô khử trùng có khả năng <strong>loại bỏ 99,99% vi khuẩn</strong> và các tác nhân gây bệnh bám trên da tay.</p>");
            content.AppendLine("<p>☘&nbsp;Một sự tiện lợi vô cùng trong cách sử dụng là bạn chỉ cần xoa gel trên tay trong <strong>1 – 2 phút</strong>, mà không cần rửa lại với nước hay xà phòng. Đảm bảo hiệu quả tức thời và tiện dụng.</p>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/z1729132497068_9baba2d7a536f0c17ceb02a69ae34b26.jpg' alt='Nước rửa tay khô 24h - Diệt khuẩn 99,99%'>");
            content.AppendLine("<p>💕 Với mong muốn đưa sản phẩm đến tay người tiêu dùng càng nhiều càng tốt, vì vậy chúng tôi định giá sản phẩm rất hợp lý.</p>");
            content.AppendLine("<p>💕 Giá bán lẻ bình ổn chỉ <span style='color: #ff0000;'><strong>65.000đ/chai</strong></span>. Dung tích 120ml, bạn có thể dùng liên tục trong 10 – 14 ngày.</p>");
            content.AppendLine("<p>🍀 Chúng tôi là Tổng phân phối sỉ chính thức, khách nhập hàng vui lòng liên hệ để biết giá sỉ tận gốc.</p>");
            content.AppendLine("<p>☘ Chúng tôi không bán lẻ, chỉ phân phối sỉ.</p>");
            content.AppendLine("<p>☘ Bán sỉ đơn đầu từ 10 chai. Đơn sau lấy từ 5 chai có ngay giá sỉ. Liên hệ để biết giá sỉ gel rửa tay khô!</p>");
            content.AppendLine("<p><img src='https://khohangsiann.com/wp-content/uploads/camketchatluong.jpg'></p>");
            content.AppendLine("<p>☎ Mọi chi tiết vui lòng liên hệ hotline <strong><span style='color: #ff0000;'>0913268406 – 0918567409</span> </strong>hoặc các kênh đặt hàng bên dưới:</p>");
            content.AppendLine("<p><a href='https://m.me/bosiquanao.net' class='add-btn facebook-btn' id='messengernow' target='_blank' rel='nofollow'><span class='icon-span'><i class='icon-btn icon-facebook'></i></span>Kết bạn Facebook</a></p>");
            content.AppendLine("<p><a href='https://zalo.me/0936786404' class='add-btn zalo-btn' id='zalonow' target='_blank' rel='nofollow'><span class='icon-span'><i class='icon-btn icon-zalo'></i></span>Kết bạn Zalo 1: 0936786404</a></p>");
            content.AppendLine("<p><a href='https://zalo.me/0913268406' class='add-btn zalo-btn' id='zalonow' target='_blank' rel='nofollow'><span class='icon-span'><i class='icon-btn icon-zalo'></i></span>Kết bạn Zalo 2: 0913268406</a></p>");
            content.AppendLine("<p><a href='https://zalo.me/0918567409' class='add-btn zalo-btn' id='zalonow' target='_blank' rel='nofollow'><span class='icon-span'><i class='icon-btn icon-zalo'></i></span>Kết bạn Zalo 3: 0918567409</a></p>");
            content.AppendLine("<p><a href='https://zalo.me/0918569400' class='add-btn zalo-btn' id='zalonow' target='_blank' rel='nofollow'><span class='icon-span'><i class='icon-btn icon-zalo'></i></span>Kết bạn Zalo 4: 0918569400</a></p>");
            content.AppendLine("<br>");
            content.AppendLine("<p>Địa chỉ: 68 Đường C12, Phường 13, Tân Bình, TP. HCM <a title='Xem bản đồ' rel='nofollow' href='https://khohangsiann.com/lien-he'>(xem bản đồ)</a></p>");
            content.AppendLine("<p>Làm việc: 8h30 - 19h30 (Thứ 2 - Thứ 7) ; 8h30 - 17h (Chủ Nhật) </p>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/corona158061058270159249636.jpg'>");
            content.AppendLine("<h3>Nước rửa tay khô đang cực kỳ khan hiếm trên toàn quốc</h3>");
            content.AppendLine("<p>– Hiện nay nhu cầu của người dân về nước rửa tay khô diệt khuẩn đang ngày càng cao độ và được dự báo trong những ngày sắp tới nó còn diễn ra nguy cấp hơn khi nước ta vào tâm dịch bùng phát.</p>");
            content.AppendLine("<img src='https://khohangsiann.com/wp-content/uploads/vna_potal_tp_ho_chi_minh_chu_dong_phong_chong_benh_viem_duong_ho_hap_cap_do_chung_moi_cua_virus_corona_224628171_stand_1.jpg'>");
            content.AppendLine("<p>– Những ngày vừa qua công ty đã phải huy động thêm rất nhiều nhân lực để tăng ca đẩy nhanh tiến độ sản xuất nước rửa tay khô nhưng vẫn không đủ để đáp ứng được nhu cầu của người dân ngày càng nhiều.</p>");
            content.AppendLine("<p><img src='https://khohangsiann.com/wp-content/uploads/nuocruatay15807213334371296547800.jpg'></p>");
            content.AppendLine("<p>– Theo tìm hiểu, được biết hiện nay hơn 90% các hiệu thuoc đang cháy hoặc không có hàng nước rửa tay diệt khuẩn để bán và cung cấp cho người dân.</p>");
            content.AppendLine("<p><img src='https://khohangsiann.com/wp-content/uploads/philippinescorona1580616169956789234225.jpg'></p>");
            content.AppendLine("<p>Tin nhắn Khuyến cáo của Bộ Y Tế:</p>");
            content.AppendLine("<p><img src='https://khohangsiann.com/wp-content/uploads/z1729404590457_c8907bcd366de1c7c857987086c4f1cc.jpg'></p>");

            return new NewsModel()
            {
                categorySlug = "buon-ban",
                title = "Sỉ gel rửa tay khô 24h",
                action = "view_more",
                actionValue = "si-gel-rua-tay-kho-24h",
                avatar = String.Empty,
                summary = String.Empty,
                content = content.ToString(),
                createdDate = new DateTime(2020, 02, 07),
            };
        }

        /// <summary>
        /// Chính sách bán sỉ
        /// </summary>
        /// <returns></returns>
        private NewsModel getWholesalePolicy()
        {
            var content = new StringBuilder();
            content.AppendLine("<img alt='Chính sách bỏ sỉ quần áo' src='http://xuongann.com/uploads/ban-hang/2-chinh-sach.png?v=09092019'>");

            return new NewsModel()
            {
                categorySlug = "chinh-sach",
                title = "Chính sách bán sỉ",
                action = "view_more",
                actionValue = "chinh-sach-ban-si",
                avatar = String.Empty,
                summary = String.Empty,
                content = content.ToString(),
                createdDate = new DateTime(2020, 02, 06),
            };
        }

        /// <summary>
        /// Chính sách chiết khấu
        /// </summary>
        /// <returns></returns>
        private NewsModel getDiscountPolicy()
        {
            var content = new StringBuilder();
            content.AppendLine("<img alt='Chính sách chiết khấu' src='http://xuongann.com/uploads/ban-hang/3-chiet-khau.png?v=09092019'>");

            return new NewsModel()
            {
                categorySlug = "chinh-sach",
                title = "Chính sách chiết khấu",
                action = "view_more",
                actionValue = "chinh-sach-chiet-khau",
                avatar = String.Empty,
                summary = String.Empty,
                content = content.ToString(),
                createdDate = new DateTime(2020, 02, 06),
            };
        }

        /// <summary>
        /// Chính sách vận chuyển
        /// </summary>
        /// <returns></returns>
        private NewsModel getDeliveryPolicy()
        {
            var content = new StringBuilder();
            content.AppendLine("<img alt='Chính sách vận chuyển' src='http://xuongann.com/uploads/ban-hang/5-ship.png?v=09092019'>");

            return new NewsModel()
            {
                categorySlug = "chinh-sach",
                title = "Chính sách vận chuyển",
                action = "view_more",
                actionValue = "chinh-sach-van-chuyen",
                avatar = String.Empty,
                summary = String.Empty,
                content = content.ToString(),
                createdDate = new DateTime(2020, 02, 06),
            };
        }

        /// <summary>
        /// Chính sách đổi trả
        /// </summary>
        /// <returns></returns>
        private NewsModel getRefundPolicy()
        {
            var content = new StringBuilder();
            content.AppendLine("<img alt='Quy định đổi trả' src='http://xuongann.com/uploads/ban-hang/6-doi-tra.png?v=09092019'>");

            return new NewsModel()
            {
                categorySlug = "chinh-sach",
                title = "Chính sách đổi trả",
                action = "view_more",
                actionValue = "chinh-sach-doi-tra",
                avatar = String.Empty,
                summary = String.Empty,
                content = content.ToString(),
                createdDate = new DateTime(2020, 02, 06),
            };
        }

        /// <summary>
        /// Chính sách bảo mật thông tin
        /// </summary>
        /// <returns></returns>
        private NewsModel getInformationSecurityPolicy()
        {
            var content = new StringBuilder();
            content.AppendLine("<h3>a) Mục đích thu thập thông tin khách hàng</h3>");
            content.AppendLine("<p>Để sử dụng được các dịch vụ của <strong>ANN.COM.VN (Hộ kinh doanh ANN)</strong>, Quý khách phải đăng ký tài khoản và cung cấp một số thông tin như: <span style='color: #ff0000;'>họ tên, số điện thoại, địa chỉ và một số thông tin khác</span>. Phần thủ tục đăng k‎ý này nhằm giúp chúng tôi xác định phần thanh toán và giao hàng chính xác cho người nhận. Bạn có thể chọn không cung cấp cho chúng tôi một số thông tin nhất định (email, số điện thoại khác), nhưng khi đó bạn sẽ không thể hưởng được một số tiện ích mà những tính năng của chúng tôi cung cấp.</p>");
            content.AppendLine("<p>Chúng tôi cũng lưu trữ bất kỳ thông tin nào bạn nhập trên website hoặc gửi đến <strong>ann.com.vn</strong>. Những thông tin đó sẽ được sử dụng cho mục đích phản hồi yêu cầu của khách hàng, đưa ra những gợi ý‎&nbsp;phù hợp cho từng khách hàng khi mua sắm tại ann.com.vn, giao hàng đến địa chỉ của khách hàng, nâng cao chất lượng hàng hóa dịch vụ và liên lạc với bạn khi cần.</p>");
            content.AppendLine("<h3>b) Phạm vi sử dụng thông tin</h3>");
            content.AppendLine("<p>Mục đích của việc thu thập thông tin là nhằm xây dựng <strong>ann.com.vn</strong> trở thành một website thương mại điện tử bán hàng mang lại nhiều tiện ích nhất cho khách hàng. Vì thế, việc sử dụng thông tin sẽ phục vụ những hoạt động sau:</p>");
            content.AppendLine("<ul>");
            content.AppendLine("<li>Giao hàng đến địa chỉ cho quý khách đã đặt hàng trên website</li>");
            content.AppendLine("<li>Cung cấp&nbsp;thông tin liên quan đến sản phẩm</li>");
            content.AppendLine("<li>Nâng cao chất lượng dịch vụ khách hàng của <strong>ann.com.vn</strong></li>");
            content.AppendLine("<li>Giải quyết các vấn đề phát sinh liên quan đến việc sử dụng sản phẩm</li>");
            content.AppendLine("</ul>");
            content.AppendLine("<h3>c) Thời gian lưu trữ thông tin</h3>");
            content.AppendLine("<p>Thông tin của khách hàng sẽ được lưu trữ 2 năm trừ khi có yêu cầu khác của cơ quan nhà nước. Mọi thông tin chúng tôi cam kết sẽ bảo mật hoàn toàn, chỉ sử dụng trong phạm vi đã nêu ở mục b.</p>");
            content.AppendLine("<h3>d) Những người hoặc tổ chức có thể được tiếp cận với thông tin bảo mật</h3>");
            content.AppendLine("<ul>");
            content.AppendLine("<li>Các bộ phận của Hộ kinh doanh ANN liên quan đến việc hỗ trợ và thực hiện tạo hóa đơn cho khách hàng.</li>");
            content.AppendLine("<li>Trong trường hợp có yêu cầu của pháp luật: Chúng tôi có trách nhiệm hợp tác cung cấp thông tin cá nhân khách hàng khi có yêu cầu từ cơ quan tư pháp.</li>");
            content.AppendLine("</ul>");
            content.AppendLine("<h3>e) Địa chỉ của đơn vị thu thập và quản lý thông tin</h3>");
            content.AppendLine("<p><strong>Hộ kinh doanh ANN</strong></p>");
            content.AppendLine("<p><em>Địa chỉ: 68 Đường C12, Phường 13, Tân Bình, TP. HCM</em></p>");
            content.AppendLine("<p><em>Điện thoại: 0914615408</em></p>");
            content.AppendLine("<p><em>Email: tranyenngoc9x@gmail.com</em></p>");
            content.AppendLine("<h3>f) Phương thức và công cụ để người tiêu dùng tiếp cận và chỉnh sửa dữ liệu</h3>");
            content.AppendLine("<p>Khách hàng có quyền tự kiểm tra, cập nhật, điều chỉnh hoặc hủy bỏ thông tin cá nhân của mình bằng cách liên hệ với Ban quản trị website (cụ thể là chủ hộ kinh doanh ANN) thực hiện việc này.</p>");
            content.AppendLine("<p>Khách hàng có quyền gửi khiếu nại về nội dung bảo mật thông tin đề nghị liên hệ Ban quản trị của website. Khi tiếp nhận những phản hồi này, chúng tôi sẽ xác nhận lại thông tin, trường hợp đúng như phản ánh của thành viên tùy theo mức độ, chúng tôi sẽ có những biện pháp xử lý kịp thời.</p>");
            content.AppendLine("<h3>g) Cơ chế tiếp nhận và giải quyết khiếu nại của người tiêu dùng</h3>");
            content.AppendLine("<p>Khi phát hiện thông tin cá nhân của mình bị sử dụng sai mục đích hoặc phạm vi, người dùng có quyền gởi email khiếu nại đến <em>tranyenngoc9x@gmail.com</em> với các thông tin, chứng cứ liên quan tới việc này. Chúng tôi cam kết sẽ phản hồi ngay lập tức trong vòng 48 tiếng để cùng Người dùng thống nhất phương án giải quyết.</p>");
            content.AppendLine("<p>– Quy trình giải quyết tranh chấp, khiếu nại:</p>");
            content.AppendLine("<p>+ Mọi tranh chấp phát sinh giữa Hộ kinh doanh ANN và khách hàng sẽ được giải quyết trên cơ sở thương lượng. Trường hợp không đạt được thỏa thuận như mong muốn, một trong hai bên có quyền đưa vụ việc ra Tòa án nhân dân có thẩm quyền để giải quyết.</p>");
            content.AppendLine("<p>+ Khi không giải quyết được qua thương lượng, hòa giải như trên, bên bị vi phạm tập hợp các chứng cứ như email, tin nhắn … và liên lạc với Hộ kinh doanh ANN, Chúng tôi sẽ liên lạc lại với người khiếu nại để giải quyết.</p>");
            content.AppendLine("<p>+ Nếu vụ việc vượt quá thẩm quyền của mình, Hộ kinh doanh ANN sẽ đề nghị chuyển vụ việc cho các cơ quan chức năng có thẩm quyền. Trong trường hợp này, Hộ kinh doanh ANN vẫn phối hợp hỗ trợ để bảo vệ tốt nhất bên bị vi phạm.</p>");
            content.AppendLine("<p><strong>Dưới đây là quy trình giải quyết tranh chấp, khiếu nại cụ thể:</strong></p>");
            content.AppendLine("<p>Khi phát sinh tranh chấp hoặc khiếu nại, trước hết bên bị vi phạm sẽ liên lạc bên kia để khiếu nại, trao đổi và tìm ra phương pháp tự giải quyết trên cơ sở thương lượng, hòa giải.</p>");
            content.AppendLine("<p>ann.com.vn có trách nhiệm tiếp nhận khiếu nại và hỗ trợ khách hàng liên quan đến giao dịch tại Website. Khi phát sinh tranh chấp, ann.com.vn đề cao giải pháp thương lượng, hòa giải giữa các bên nhằm duy trì sự tin cậy của khách hàng vào chất lượng của chúng tôi và thực hiện theo các bước sau:</p>");
            content.AppendLine("<p><strong>Bước 1:</strong> Khách hàng khiếu nại về hàng hóa qua email: <em>tranyenngoc9x@gmail.com</em>, khách hàng có thể phản ánh trực tiếp đến đến ban quản trị.</p>");
            content.AppendLine("<p><strong>Bước 2:</strong> ann.com.vn sẽ tiếp nhận các khiếu nại của khách hàng, tùy theo tính chất và mức độ của khiếu nại thì bên Website sẽ có những biện pháp cụ thể hộ trợ khách hàng để giải quyết.</p>");
            content.AppendLine("<p><strong>Bước 3:</strong> Trong trường nằm ngoài khả năng và thẩm quyền của Website thì ban quản trị sẽ yêu cầu người mua đưa vụ việc này ra cơ quan nhà nước có thẩm quyền giải quyết theo pháp luật</p>");
            content.AppendLine("<p>Người mua gửi khiếu nại tại địa chỉ:</p>");
            content.AppendLine("<p><strong>Hộ kinh doanh ANN</strong></p>");
            content.AppendLine("<p><em>Địa chỉ: 68 Đường C12, Phường 13, Tân Bình, TP. HCM</em></p>");
            content.AppendLine("<p><em>Điện thoại: 0914615408</em></p>");
            content.AppendLine("<p><em>Email: tranyenngoc9x@gmail.com</em></p>");

            return new NewsModel()
            {
                categorySlug = "chinh-sach",
                title = "Chính sách bảo mật thông tin",
                action = "view_more",
                actionValue = "chinh-sach-bao-mat-thong-tin",
                avatar = String.Empty,
                summary = String.Empty,
                content = content.ToString(),
                createdDate = new DateTime(2020, 02, 06),
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
                action = post1.action,
                name = post1.title,
                actionValue = post1.actionValue,
                image = post1.avatar,
                message = post1.summary,
                createdDate = post1.createdDate
            });

            // Kinh nghiệm mở shop quần áo nam online ít vốn cho người mới bắt đầu
            var post2 = getPost2();
            result.Add(new FlutterBannerModel()
            {
                action = post2.action,
                name = post2.title,
                actionValue = post2.actionValue,
                image = post2.avatar,
                message = post2.summary,
                createdDate = post2.createdDate
            });

            return result.Select(x => {
                if (x.action == "view_more")
                    x.actionValue = "post/" + x.actionValue;

                return x;
            }).ToList();
        }

        public List<FlutterPostCardModel> getPosts(FlutterPostFilterModel filter, ref PaginationMetadataModel pagination)
        {
            var posts = new List<NewsModel>()
            {
                getPost1(),
                getPost2(),
                getPost3(),
                getPost4(),
                getWholesalePolicy(),
                getDiscountPolicy(),
                getDeliveryPolicy(),
                getRefundPolicy(),
                getInformationSecurityPolicy()
            }
            .ToList();

            if (!String.IsNullOrEmpty(filter.categorySlug))
            {
                // Trường hợp lấy cá bài viết
                if (filter.categorySlug != "chinh-sach")
                    posts = posts
                        .Where(x => x.categorySlug != "chinh-sach")
                        .Where(x => x.categorySlug.Trim().ToLower() == filter.categorySlug.Trim().ToLower())
                        .ToList();
                else
                    posts = posts.Where(x => x.categorySlug.Trim().ToLower() == filter.categorySlug.Trim().ToLower()).ToList();
            }
            else
            {
                posts = posts.Where(x => x.categorySlug != "chinh-sach").ToList();
            }

            var data = posts
            .Select(x => new FlutterPostCardModel()
            {
                action = x.action,
                name = x.title,
                actionValue = x.action == "view_more" ? "post/" + x.actionValue : x.actionValue,
                image = x.avatar,
                message = x.summary,
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
                getPost2(),
                getPost3(),
                getPost4(),
                getInformationSecurityPolicy(),
                getRefundPolicy(),
                getDeliveryPolicy(),
                getDiscountPolicy(),
                getWholesalePolicy()
            }
            .Where(x => x.action == "view_more")
            .Where(x => x.actionValue == slug)
            .Select(x => new FlutterPostModel()
            {
                title = x.title,
                content = x.content,
                createdDate = x.createdDate
            })
            .ToList();

            return data.FirstOrDefault();
        }
    }
}