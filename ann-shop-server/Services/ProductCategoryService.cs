using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ann_shop_server.Services
{
    public class ProductCategoryService : Service<ProductCategoryService>
    {
        public List<ProductCategoryModel> getCategoryChild(inventorymanagementEntities con, ProductCategoryModel parent)
        {
            var result = new List<ProductCategoryModel>();
            result.Add(parent);

            var child = con.tbl_Category
                .Where(x => x.ParentID.Value == parent.id)
                .Select(x => new ProductCategoryModel() {
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

        public List<ProductCategoryModel> getCategoryChild(inventorymanagementEntities con, string categorySlug)
        {
            var parent = con.tbl_Category
                .Where(x => x.Slug == categorySlug)
                .Select(x => new ProductCategoryModel()
                {
                    id = x.ID,
                    title = x.CategoryName,
                    description = x.CategoryDescription,
                    slug = x.Slug
                    
                })
                .FirstOrDefault();
            if (parent != null)
            {
                return getCategoryChild(con, parent);
            }
            else
            {
                return null;
            }
        }

        public ProductCategoryPageModel getProductCategoryDetail(string slug)
        {
            using (var con = new inventorymanagementEntities())
            {
                var parent = con.tbl_Category
                    .Where(x => x.Slug == slug)
                    .Select(x => new ProductCategoryModel()
                    {
                        id = x.ID,
                        title = x.CategoryName,
                        description = x.CategoryDescription,
                        slug = x.Slug
                    })
                    .FirstOrDefault();

                if (parent != null)
                {
                    var child = getCategoryChild(con, parent);

                    return new ProductCategoryPageModel()
                    {
                        id = parent.id,
                        title = parent.title,
                        description = parent.description,
                        slug = parent.slug,
                        child = child
                    };
                }
                else
                {
                    return null;
                }
            }
        }
    }
}