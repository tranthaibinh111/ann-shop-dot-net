using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ann_shop_server.Services
{
    public class PostService : IANNService
    {
        public PostModel getPostDetail(int id)
        {
            using (var con = new inventorymanagementEntities())
            {
                var post = con.tbl_Post
                    .Where(x => x.ID == id)
                    .GroupJoin(
                        con.tbl_PostCategory,
                        p => p.CategoryID,
                        c => c.ID,
                        (p, c) => new { p, c }
                    )
                    .SelectMany(
                        x => x.c.DefaultIfEmpty(),
                        (parent, children) => new PostModel()
                        {
                            id = parent.p.ID,
                            title = parent.p.Title,
                            image = parent.p.Image,
                            featured = parent.p.Featured,
                            content = parent.p.Content,
                            categoryName = children != null ? children.Title : String.Empty,
                            categoryID = parent.p.CategoryID,
                            createdDate = parent.p.CreatedDate,
                        }
                    )
                    .FirstOrDefault();
                return post;
            }
        }

        /// <summary>
        /// Lấy danh sách bài viết public thể hiện tại home
        /// </summary>
        /// <param name="postSlug"></param>
        /// <returns></returns>
        public List<PostPublic> getHomePosts()
        {
            using (var con = new inventorymanagementEntities())
            {
                var homePosts = con.PostPublics
                    .Where(x => x.AtHome == true)
                    .OrderByDescending(o => o.ModifiedDate)
                    .ToList();

                return homePosts;
            }
        }

        /// <summary>
        /// Lấy bài viết public theo post slug
        /// </summary>
        /// <param name="postSlug"></param>
        /// <returns></returns>
        public PostPublic getPostPublic(string postSlug)
        {
            using (var con = new inventorymanagementEntities())
            {
                var post = con.PostPublics.Where(x =>
                    x.Action.Equals(FlutterPageNavigation.ViewMore) &&
                    x.ActionValue.Equals(postSlug)
                )
                .FirstOrDefault();

                return post;
            }
        }
    }
}