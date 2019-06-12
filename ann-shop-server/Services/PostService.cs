using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ann_shop_server.Services
{
    public class PostService : Service<PostService>
    {

        public PostModel getPostDetail(int id)
        {
            using (var con = new inventorymanagementEntities())
            {
                var post = con.tbl_Post
                    .Where(x => x.ID == id)
                    .GroupJoin(
                        con.tbl_Category,
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
                            categoryName = children != null ? children.CategoryName : String.Empty,
                            categoryID = parent.p.CategoryID,
                            createdDate = parent.p.CreatedDate,
                        }
                    )
                    .FirstOrDefault();
                return post;
            }
        }
    }
}