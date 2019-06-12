using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ann_shop_server.Services
{
    public class ProductCategoryService : Service<ProductCategoryService>
    {
        public IEnumerable<ProductCategoryModel> getCategoryChild(inventorymanagementEntities con, ProductCategoryModel parent)
        {
            var result = new List<ProductCategoryModel>();
            result.Add(parent);

            var child = con.tbl_Category
                .Where(x => x.ParentID.Value == parent.id)
                .Select(x => new ProductCategoryModel() {
                    id = x.ID,
                    title = x.CategoryName,
                    description = x.CategoryDescription
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

        public IEnumerable<ProductCategoryModel> getCategoryChild(inventorymanagementEntities con, string categorySlug)
        {
            var parent = con.tbl_Category
                .Where(x => x.Slug == categorySlug)
                .Select(x => new ProductCategoryModel()
                {
                    id = x.ID,
                    title = x.CategoryName,
                    description = x.CategoryDescription
                })
                .FirstOrDefault();
            if (parent != null)
            {
                return getCategoryChild(con, parent);
            }
            else
            {
                return new List<ProductCategoryModel>();
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
                        description = x.CategoryDescription
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
                        child = child
                    };
                }
                else
                {
                    return new ProductCategoryPageModel();
                }
            }
        }
    }
}