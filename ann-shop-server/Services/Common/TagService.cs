using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class TagService : IANNService
    {
        #region Lấy thông tin về tag
        /// <summary>
        /// Lấy thông tin category theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public TagModel getTagBySlug(string slug)
        {
            using (var con = new inventorymanagementEntities())
            {
                var tag = con.Tags
                    .Where(x => !String.IsNullOrEmpty(slug) && x.Slug == slug)
                    .Select(x => new TagModel()
                    {
                        id = x.ID,
                        name = x.Name,
                        slug = x.Slug
                    })
                    .FirstOrDefault();

                return tag;
            }
        }
        #endregion
    }
}