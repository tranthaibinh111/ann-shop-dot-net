using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Models
{
    public sealed class FlutterPageNavigation
    {
        /// <summary>
        /// value: slug of product (ao-ca-sau)
        /// => view product detail
        /// </summary>
        public static string Product { get { return "product"; } }
        /// <summary>
        /// value: slug of category (quan-ao-nu)
        /// => View list of product by category
        /// </summary>
        public static string Category { get { return "category"; } }
        /// <summary>
        /// value: slug of product tag 
        /// => View list of product by tag
        /// </summary>
        public static string ProductTag { get { return "product_tag"; } }
        /// <summary>
        /// value: slug of product search 
        /// => View list of product by search
        /// </summary>
        public static string ProductSearch { get { return "product_search"; } }
        /// <summary>
        /// value: web url (http://xuongann.com/)
        //  => Show web
        /// </summary>
        public static string ShowWeb { get { return "show_web"; } }
        /// <summary>
        /// value: Screen name (home, category...)
        /// go to screen
        /// </summary>
        public static string GoToScreen { get { return "go_to_screen"; } }
        /// <summary>
        /// Show text lấy lên từ API
        /// </summary>
        public static string ViewMore { get { return "view_more"; } }
        /// <summary>
        /// value: web url (http://xuongann.com/)
        /// => Show web on browser
        /// </summary>
        public static string OpenBrowser { get { return "open_browser"; } }
    }
}