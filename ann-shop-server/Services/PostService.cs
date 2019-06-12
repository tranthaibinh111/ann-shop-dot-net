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
                var data = con.tbl_Post.Where(x => x.ID == id).FirstOrDefault();

                var category = con.tbl_PostCategory.Where(x => x.ID == data.CategoryID).FirstOrDefault();

                PostModel post = new PostModel();

                post.id = data.ID;
                post.title = data.Title;
                post.image = data.Image;
                post.featured = data.Featured;
                post.content = data.Content;
                post.categoryName = category.Title;
                post.categoryID = data.CategoryID;
                post.createdDate = data.CreatedDate;

                return post;
            }
        }
    }
}