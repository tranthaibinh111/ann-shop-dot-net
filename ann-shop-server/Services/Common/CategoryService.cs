﻿using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class CategoryService : Service<CategoryService>
    {
        /// <summary>
        /// Thực thi đệ quy để lấy tất cả category theo nhánh parent
        /// </summary>
        /// <param name="con"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public List<CategoryModel> getCategoryChild(inventorymanagementEntities con, CategoryModel parent)
        {
            var result = new List<CategoryModel>();
            result.Add(parent);

            var child = con.tbl_Category
                .Where(x => x.ParentID.Value == parent.id)
                .Select(x => new CategoryModel()
                {
                    id = x.ID,
                    title = x.CategoryName,
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
                        title = x.CategoryName,
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
    }
}