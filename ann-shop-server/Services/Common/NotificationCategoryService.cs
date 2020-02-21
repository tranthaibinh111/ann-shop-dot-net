using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class NotificationCategoryService: Service<NotificationCategoryService>
    {
        #region Lấy danh sách dạnh mục post con dựa theo danh mục post cha
        /// <summary>
        /// Thực thi đệ quy để lấy tất cả post category theo nhánh parent
        /// </summary>
        /// <param name="con"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private List<NotificationCategoryModel> getPostCategoryChild(inventorymanagementEntities con, NotificationCategoryModel parent)
        {
            var result = new List<NotificationCategoryModel>();
            result.Add(parent);

            var child = con.PostCategories
                .Where(x => x.ParentID == parent.id)
                .Select(x => new NotificationCategoryModel()
                {
                    id = x.ID,
                    name = x.Name,
                    description = x.Description,
                    slug = x.Slug
                })
                .ToList();

            if (child.Count > 0)
            {
                foreach (var id in child)
                {
                    result.AddRange(getPostCategoryChild(con, id));
                }
            }

            return result;
        }

        /// <summary>
        /// Tìm các post category thuộc nhánh slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public List<NotificationCategoryModel> getPostCategoryChild(string slug)
        {
            using (var con = new inventorymanagementEntities())
            {
                var parent = con.PostCategories
                    .Where(x =>
                        (!String.IsNullOrEmpty(slug) && x.Slug == slug) ||
                        (String.IsNullOrEmpty(slug) && x.Level == 0)
                    )
                    .Select(x => new NotificationCategoryModel()
                    {
                        id = x.ID,
                        name = x.Name,
                        description = x.Description,
                        slug = x.Slug
                    })
                    .FirstOrDefault();
                if (parent != null)
                    return getPostCategoryChild(con, parent);
                else
                    return null;
            }
        }
        #endregion

        #region Lấy thông tin về danh mục post
        /// <summary>
        /// Lấy thông tin post category theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public NotificationCategoryModel getPostCategoryBySlug(string slug)
        {
            using (var con = new inventorymanagementEntities())
            {
                var parent = con.PostCategories
                    .Where(x =>
                        (!String.IsNullOrEmpty(slug) && x.Slug == slug)
                    )
                    .Select(x => new NotificationCategoryModel()
                    {
                        id = x.ID,
                        name = x.Name,
                        slug = x.Slug,
                        description = x.Description
                    })
                    .FirstOrDefault();

                return parent;
            }
        }
        #endregion
    }
}