using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterPostCategoryService : Service<FlutterPostCategoryService>
    {
        private PostCategoryService _service = PostCategoryService.Instance;

        public List<FlutterPostCategoryModel> getCategories()
        {
            var postCategories = _service.getPostCategoryAtPost();

            if (postCategories != null && postCategories.Count > 0)
            {
                var result = new List<FlutterPostCategoryModel>();

                // Blog Tất cả
                var allBlog = new FlutterPostCategoryModel()
                {
                    name = "Tất cả"
                };

                if (postCategories.Count == 1)
                {
                    result.Add(allBlog);
                }

                foreach (var catory in postCategories)
                {
                    result.Add(new FlutterPostCategoryModel()
                    {
                        name = catory.name,
                        filter = new FlutterPostFilterModel()
                        {
                            categorySlug = catory.slug
                        }
                    });
                }

                return result;
            }

            return null;
        }
    }
}