using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterPostCategoryService : Service<FlutterPostCategoryService>
    {
        public List<FlutterPostCategoryModel> getCategories()
        {
            var result = new List<FlutterPostCategoryModel>();

            // Blog Tất cả
            var allBlog = new FlutterPostCategoryModel()
            {
                name = "Tất cả"
            };
            result.Add(allBlog);

            // Blog buôn bán
            var saleBlog = new FlutterPostCategoryModel()
            {
                name = "Buôn bán",
                filter = new FlutterPostFilterModel()
                {
                    categorySlug = "buon-ban"
                }
            };
            result.Add(saleBlog);

            // Blog kinh nghiệm
            var experienceBlog = new FlutterPostCategoryModel()
            {
                name = "Kinh nghiệm",
                filter = new FlutterPostFilterModel()
                {
                    categorySlug = "kinh-nghiem"
                }
            };
            result.Add(experienceBlog);

            return result;
        }
    }
}