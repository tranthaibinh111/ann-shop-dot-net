using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterPostService: PostService
    {
        private readonly PostCategoryService _postCategory = ANNFactoryService.getInstance<PostCategoryService>();

        /// <summary>
        /// Lấy danh sách post public tại màn hình home
        /// </summary>
        /// <returns></returns>
        public new List<FlutterBannerModel> getHomePosts()
        {
            var homePosts = base.getHomePosts();

            if (homePosts == null || homePosts.Count == 0)
                return null;

            return homePosts
                .Select(x => new FlutterBannerModel() {
                    action = x.Action,
                    name = x.Title,
                    actionValue = x.Action == FlutterPageNavigation.ViewMore ? "post/" + x.ActionValue : x.ActionValue,
                    image = x.Thumbnail,
                    message = x.Summary,
                    createdDate = x.CreatedDate
                })
                .ToList();
        }

        public List<FlutterPostCardModel> getPosts(FlutterPostFilterModel filter, ref PaginationMetadataModel pagination)
        {
            using (var con = new inventorymanagementEntities())
            {
                var posts = con.PostPublics.Where(x => x.IsPolicy == filter.isPolicy);

                if (!String.IsNullOrEmpty(filter.categorySlug))
                {
                    var categories = _postCategory.getPostCategoryChild(filter.categorySlug);

                    if (categories == null || categories.Count() == 0)
                        return null;

                    var categoriesID = categories.Select(x => x.id).ToList();
                    posts = posts.Where(p => categoriesID.Contains(p.CategoryID));
                }

                var data = posts
                    .OrderByDescending(o => o.ModifiedDate)
                    .Select(x => new FlutterPostCardModel()
                    {
                        action = x.Action,
                        name = x.Title,
                        actionValue = x.Action == FlutterPageNavigation.ViewMore ? (x.IsPolicy ? "policy/" : "post/") + x.ActionValue : x.ActionValue,
                        image = x.Thumbnail,
                        message = x.Summary,
                        createdDate = x.ModifiedDate
                    })
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
        }

        public FlutterPostModel getPostBySlug(string slug)
        {
            if (String.IsNullOrEmpty(slug))
                return null;

            var post = base.getPostPublic(slug);

            if (post == null)
                return null;

            return new FlutterPostModel()
            {
                title = post.Title,
                content = post.Content,
                createdDate = post.CreatedDate
            };
        }
    }
}