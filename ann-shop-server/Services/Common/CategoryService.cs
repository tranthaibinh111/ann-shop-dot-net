using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class CategoryService : IANNService
    {
        #region Lấy danh sách dạnh mục con dựa theo danh mục cha
        /// <summary>
        /// Thực thi đệ quy để lấy tất cả category theo nhánh parent
        /// </summary>
        /// <param name="con"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private List<CategoryModel> getCategoryChild(inventorymanagementEntities con, CategoryModel parent)
        {
            var result = new List<CategoryModel>();
            result.Add(parent);

            var child = con.tbl_Category
                .Where(x => x.ParentID.Value == parent.id)
                .Select(x => new CategoryModel()
                {
                    id = x.ID,
                    name = x.CategoryName,
                    description = x.CategoryDescription,
                    slug = x.Slug
                })
                .ToList();

            if (child.Count > 0)
            {
                foreach (var id in child)
                {
                    result.AddRange(getCategoryChild(con, id));
                }
            }

            return result;
        }

        /// <summary>
        /// Tìm các category thuộc nhánh slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public List<CategoryModel> getCategoryChild(string slug)
        {
            using (var con = new inventorymanagementEntities())
            {
                var parent = con.tbl_Category
                    .Where(x =>
                        (!String.IsNullOrEmpty(slug) && x.Slug == slug) ||
                        (String.IsNullOrEmpty(slug) && x.CategoryLevel == 0)
                    )
                    .Select(x => new CategoryModel()
                    {
                        id = x.ID,
                        name = x.CategoryName,
                        description = x.CategoryDescription,
                        slug = x.Slug
                    })
                    .FirstOrDefault();
                if (parent != null)
                    return getCategoryChild(con, parent);
                else
                    return null;
            }
        }
        #endregion

        #region Lấy thông tin về danh mục
        /// <summary>
        /// Lấy thông tin category theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public CategoryModel getCategoryBySlug(string slug)
        {
            using (var con = new inventorymanagementEntities())
            {
                var parent = con.tbl_Category
                    .Where(x =>
                        (!String.IsNullOrEmpty(slug) && x.Slug == slug) ||
                        (String.IsNullOrEmpty(slug) && x.CategoryLevel == 0)
                    )
                    .Select(x => new CategoryModel()
                    {
                        id = x.ID,
                        name = x.CategoryName,
                        slug = x.Slug,
                        description = x.CategoryDescription
                    })
                    .FirstOrDefault();

                return parent;
            }
        }
        #endregion
    }
}