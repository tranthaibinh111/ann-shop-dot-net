using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterCategoryService: Service<FlutterCategoryService>
    {
        #region Lấy thông tin về danh mục
        /// <summary>
        /// Lấy thông tin category theo slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public FlutterCategoryModel getCategoryBySlug(string slug)
        {
            using (var con = new inventorymanagementEntities())
            {
                var parent = con.tbl_Category
                    .Where(x =>
                        (!String.IsNullOrEmpty(slug) && x.Slug == slug) ||
                        (String.IsNullOrEmpty(slug) && x.CategoryLevel == 0)
                    )
                    .Select(x => new FlutterCategoryModel()
                    {
                        id = x.ID,
                        name = x.CategoryName,
                        slug = x.Slug,
                        icon = x.Icon,
                        description = x.CategoryDescription,
                        filter = new FlutterProductFilterModel() { categorySlug = x.Slug, productSort = (int)ProductSortKind.ProductNew }
                    })
                    .FirstOrDefault();

                if (parent != null)
                {
                    var children = con.tbl_Category
                        .Where(x => x.ParentID == parent.id)
                        .Select(x => new FlutterCategoryModel()
                        {
                            id = x.ID,
                            name = x.CategoryName,
                            slug = x.Slug,
                            icon = x.Icon,
                            description = x.CategoryDescription,
                            filter = new FlutterProductFilterModel() { categorySlug = x.Slug, productSort = (int)ProductSortKind.ProductNew }
                        })
                        .OrderBy(o => o.id)
                        .ToList();

                    if (children.Count > 0)
                    {
                        parent.children = new List<FlutterCategoryModel>();
                        parent.children.AddRange(children);
                    }
                }

                return parent;
            }
        }

        /// <summary>
        /// Lấy danh sách category theo danh sách slug
        /// </summary>
        /// <param name="slugs"></param>
        /// <returns></returns>
        public List<FlutterCategoryModel> getCategoryBySlug(List<string> slugs)
        {
            var result = new List<FlutterCategoryModel>();

            foreach (var item in slugs)
            {
                var data = getCategoryBySlug(item);

                if (data != null)
                    result.Add(data);
            }

            return result;
        }

        /// <summary>
        /// Lấy danh sách các danh mục
        /// </summary>
        /// <returns></returns>
        public List<FlutterCategoryModel> getCategories()
        {
            var result = getCategoryBySlug(new List<string> {
                "bao-li-xi-tet",
                "do-bo-nu",
                "vay-dam",
                "ao-thun-nu",
                "ao-so-mi-nu",
                "ao-dai-cach-tan",
                "quan-nu",
                "do-lot-nu",
                "ao-khoac-nu",
                "quan-ao-nu",
                "ao-thun-nam",
                "ao-so-mi-nam",
                "ao-khoac-nam",
                "quan-nam",
                "quan-lot-nam",
                "set-bo-nam",
                "quan-ao-nam",
                "nuoc-hoa"
            });

            return result;
        }
        #endregion

        #region Khởi tạo danh mục
        /// <summary>
        /// Khởi tạo một danh mục từ danh sách slug
        /// </summary>
        /// <param name="title"></param>
        /// <param name="slugs"></param>
        /// <returns></returns>
        public FlutterCategoryModel createCategoryBySlugs(string title, List<string> slugs)
        {
            var result = new FlutterCategoryModel()
            {
                id = 0,
                name = title,
                slug = String.Empty,
                icon = String.Empty,
                description = String.Empty,
                filter = new FlutterProductFilterModel() { categorySlugList = slugs, productSort = (int)ProductSortKind.ProductNew },
            };

            // Tạo category con
            var children = new List<FlutterCategoryModel>();
            foreach (var item in slugs)
            {
                var child = getCategoryBySlug(item);
                if (child != null)
                    children.Add(new FlutterCategoryModel()
                    {
                        id = child.id,
                        name = child.name,
                        slug = child.slug,
                        icon = child.icon,
                        description = child.description,
                        filter = new FlutterProductFilterModel() { categorySlug = child.slug, productSort = (int)ProductSortKind.ProductNew }
                    });
            }
            
            if (children.Count > 0)
                result.children = children;

            return result;
        }
        #endregion
    }
}