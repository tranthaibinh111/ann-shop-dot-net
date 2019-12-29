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
        #region Danh mục Quần áo nữ
        /// <summary>
        /// Lấy category Đồ bộ nữ
        /// </summary>
        /// <returns></returns>
        public FlutterCategoryModel getWomenOutfit()
        {
            // Đồ bộ nữ
            var womenOutfit = createCategoryBySlug("do-bo-nu");
            if (womenOutfit == null)
                return null;

            // Đồ bộ nữ có sẳn
            var stockIn = (FlutterCategoryModel)womenOutfit.Clone();
            stockIn.name = "Đồ bộ nữ có sẳn";
            stockIn.icon = "/assets/images/categories/new-product.png";
            stockIn.description = "Hàng có sẳn ở kho";
            stockIn.filter.productBadge = (int)ProductBadge.stockIn;

            // Đồ bộ nữ order
            var order = (FlutterCategoryModel)womenOutfit.Clone();
            order.name = "Đồ bộ nữ order";
            order.icon = "/assets/images/categories/order-product.png";
            order.description = "Không có sẳn ở kho";
            order.filter.productBadge = (int)ProductBadge.order;

            // Đồ bộ nữ sale
            var sale = (FlutterCategoryModel)womenOutfit.Clone();
            sale.name = "Đồ bộ nữ sale";
            sale.icon = "/assets/images/categories/sale-product.png";
            sale.description = "Tất cả đồ bộ nữ sale";
            sale.filter.productBadge = (int)ProductBadge.sale;

            // Đồ bộ sỉ dưới 100k
            var price100 = (FlutterCategoryModel)womenOutfit.Clone();
            price100.name = "Đồ bộ sỉ dưới 100k";
            price100.icon = "/assets/images/categories/price-filter.png";
            price100.description = String.Empty;
            price100.filter.priceMax = 99000;

            // Đồ bộ sỉ từ 100k - 125k
            var price100_125 = (FlutterCategoryModel)womenOutfit.Clone();
            price100_125.name = "Đồ bộ sỉ từ 100k - 125k";
            price100_125.icon = "/assets/images/categories/price-filter.png";
            price100_125.description = String.Empty;
            price100_125.filter.priceMin = 100000;
            price100_125.filter.priceMax = 125000;

            // Đồ bộ sỉ từ 125k - 150k
            var price125_150 = (FlutterCategoryModel)womenOutfit.Clone();
            price125_150.name = "Đồ bộ sỉ từ 125k - 150k";
            price125_150.icon = "/assets/images/categories/price-filter.png";
            price125_150.description = String.Empty;
            price125_150.filter.priceMin = 126000;
            price125_150.filter.priceMax = 150000;

            // Đồ bộ sỉ trên 150k
            var price150 = (FlutterCategoryModel)womenOutfit.Clone();
            price150.name = "Đồ bộ sỉ trên 150k";
            price150.icon = "/assets/images/categories/price-filter.png";
            price150.description = String.Empty;
            price150.filter.priceMin = 151000;

            womenOutfit.children = new List<FlutterCategoryModel>()
            {
                stockIn,
                order,
                sale,
                price100,
                price100_125,
                price125_150,
                price150
            };

            return womenOutfit;
        }

        /// <summary>
        /// Lấy category Váy đầm nữ
        /// </summary>
        /// <returns></returns>
        public FlutterCategoryModel getWomenDresses()
        {
            // Váy đầm nữ
            var womenDresses = createCategoryBySlug("vay-dam");

            // Váy đầm có sẵn
            var stockIn = (FlutterCategoryModel)womenDresses.Clone();
            stockIn.name = "Váy đầm có sẵn";
            stockIn.icon = "/assets/images/categories/new-product.png";
            stockIn.description = "Hàng có sẳn ở kho";
            stockIn.filter.productBadge = (int)ProductBadge.stockIn;

            // Váy đầm order
            var order = (FlutterCategoryModel)womenDresses.Clone();
            order.name = "Váy đầm order";
            order.icon = "/assets/images/categories/order-product.png";
            order.description = "Không có sẳn ở kho";
            order.filter.productBadge = (int)ProductBadge.order;

            // Váy đầm sale
            var sale = (FlutterCategoryModel)womenDresses.Clone();
            sale.name = "Váy đầm sale";
            sale.icon = "/assets/images/categories/sale-product.png";
            sale.description = "Tất cả váy đầm sale";
            sale.filter.productBadge = (int)ProductBadge.sale;

            // Váy đầm sỉ dưới 125k
            var price125 = (FlutterCategoryModel)womenDresses.Clone();
            price125.name = "Váy đầm sỉ dưới 125k";
            price125.icon = "/assets/images/categories/price-filter.png";
            price125.description = String.Empty;
            price125.filter.priceMax = 124000;

            // Váy đầm sỉ từ 125k - 150k
            var price125_150 = (FlutterCategoryModel)womenDresses.Clone();
            price125_150.name = "Váy đầm sỉ từ 125k - 150k";
            price125_150.icon = "/assets/images/categories/price-filter.png";
            price125_150.description = String.Empty;
            price125_150.filter.priceMin = 125000;
            price125_150.filter.priceMax = 150000;

            // Váy đầm sỉ trên 150k
            var price150 = (FlutterCategoryModel)womenDresses.Clone();
            price150.name = "Váy đầm sỉ trên 150k";
            price150.icon = "/assets/images/categories/price-filter.png";
            price150.description = String.Empty;
            price150.filter.priceMin = 151000;

            womenDresses.children = new List<FlutterCategoryModel>()
            {
                stockIn,
                order,
                sale,
                price125,
                price125_150,
                price150
            };

            return womenDresses;
        }

        /// <summary>
        /// Lấy category Quần áo nữ
        /// </summary>
        /// <returns></returns>
        public FlutterCategoryModel getWomenClothes()
        {
            // Quần áo nữ
            var womenClothes = createCategoryBySlug("quan-ao-nu");

            // Quần áo nữ có sẵn
            var stockIn = (FlutterCategoryModel)womenClothes.Clone();
            stockIn.name = "Quần áo nữ có sẵn";
            stockIn.icon = "/assets/images/categories/new-product.png";
            stockIn.description = String.Empty;
            stockIn.filter.productBadge = (int)ProductBadge.stockIn;

            // Quần áo nữ order
            var order = (FlutterCategoryModel)womenClothes.Clone();
            order.name = "Quần áo nữ order";
            order.icon = "/assets/images/categories/order-product.png";
            order.description = String.Empty;
            order.filter.productBadge = (int)ProductBadge.order;

            // Quần áo nữ sale
            var sale = (FlutterCategoryModel)womenClothes.Clone();
            sale.name = "Quần áo nữ sale";
            sale.icon = "/assets/images/categories/sale-product.png";
            sale.description = String.Empty;
            sale.filter.productBadge = (int)ProductBadge.sale;

            womenClothes.children = new List<FlutterCategoryModel>();
            // Quần áo nữ big size
            womenClothes.children.Add(createCategoryByTag("Quần áo nữ big size",
                                                          "/assets/images/categories/big-size.png",
                                                          "quan-ao-nu-big-size"));
            // Đồ bộ nữ
            womenClothes.children.Add(getWomenOutfit());
            // Váy đầm
            womenClothes.children.Add(getWomenDresses());
            // Áo thun nữ, Quần nữ, Áo sơ mi nữ, Đồ lót nữ, Áo khoác nữ, Áo dài cách tân
            womenClothes.children.AddRange(
                createCategoryBySlugs(new List<string>() {
                    "ao-thun-nu",
                    "quan-nu",
                    "ao-so-mi-nu",
                    "do-lot-nu",
                    "ao-khoac-nu",
                    "ao-dai-cach-tan"
                })
            );
            // Quần áo nữ có sẵn
            womenClothes.children.Add(stockIn);
            // Quần áo nữ order
            womenClothes.children.Add(order);
            // Quần áo nữ sale
            womenClothes.children.Add(sale);

            return womenClothes;
        }
        #endregion
        
        #region Danh mục Quần áo nam
        /// <summary>
        /// Lấy category Áo thung nam
        /// </summary>
        /// <returns></returns>
        public FlutterCategoryModel getMenTShirt()
        {
            // Áo thun nam
            var menTShirt = createCategoryBySlug("ao-thun-nam");
            if (menTShirt == null)
                return null;

            // Áo thun nam có sẳn
            var stockIn = (FlutterCategoryModel)menTShirt.Clone();
            stockIn.name = "Áo thun nam có sẳn";
            stockIn.icon = "/assets/images/categories/new-product.png";
            stockIn.description = "Hàng có sẳn ở kho";
            stockIn.filter.productBadge = (int)ProductBadge.stockIn;

            // Áo thun nam order
            var order = (FlutterCategoryModel)menTShirt.Clone();
            order.name = "Áo thun nam order";
            order.icon = "/assets/images/categories/order-product.png";
            order.description = "Không có sẳn ở kho";
            order.filter.productBadge = (int)ProductBadge.order;

            menTShirt.children = new List<FlutterCategoryModel>()
            {
                stockIn,
                order
            };

            return menTShirt;
        }

        /// <summary>
        /// Lấy category Quần áo nam
        /// </summary>
        /// <returns></returns>
        public FlutterCategoryModel getMenClothes()
        {
            // Quần áo nam
            var menClothes = createCategoryBySlug("quan-ao-nam");

            // Quần áo nam có sẵn
            var stockIn = (FlutterCategoryModel)menClothes.Clone();
            stockIn.name = "Quần áo nam có sẵn";
            stockIn.icon = "/assets/images/categories/new-product.png";
            stockIn.description = String.Empty;
            stockIn.filter.productBadge = (int)ProductBadge.stockIn;

            // Quần áo nam order
            var order = (FlutterCategoryModel)menClothes.Clone();
            order.name = "Quần áo nam order";
            order.icon = "/assets/images/categories/order-product.png";
            order.description = String.Empty;
            order.filter.productBadge = (int)ProductBadge.order;

            // Quần áo nam sale
            var sale = (FlutterCategoryModel)menClothes.Clone();
            sale.name = "Quần áo nam sale";
            sale.icon = "/assets/images/categories/sale-product.png";
            sale.description = String.Empty;
            sale.filter.productBadge = (int)ProductBadge.sale;

            menClothes.children = new List<FlutterCategoryModel>();
            // Áo thun nam
            menClothes.children.Add(getMenTShirt());
            // Quần nam, Áo khoác nam, Sơ mi nam, Quần lót nam, Set bộ nam
            menClothes.children.AddRange(
                createCategoryBySlugs(new List<string>() {
                    "quan-nam",
                    "ao-khoac-nam",
                    "ao-so-mi-nam",
                    "quan-lot-nam",
                    "set-bo-nam"
                })
            );
            // Quần áo nam có sẵn
            menClothes.children.Add(stockIn);
            // Quần áo nam order
            menClothes.children.Add(order);
            // Quần áo nam sale
            menClothes.children.Add(sale);

            return menClothes;
        }
        #endregion

        #region Danh mục nước hoa
        public FlutterCategoryModel getPerfume()
        {
            // Đồ bộ nữ
            var perfume = createCategoryBySlug("nuoc-hoa");
            if (perfume == null)
                return null;

            // Loại chai 20ml giá 30k
            var price30 = (FlutterCategoryModel)perfume.Clone();
            price30.name = "Loại chai 20ml giá 30k";
            price30.icon = "/assets/images/categories/price-filter.png";
            price30.description = String.Empty;
            price30.filter.priceMax = 30000;

            // Loại chai táo 20ml sỉ 35k
            var price35 = (FlutterCategoryModel)perfume.Clone();
            price35.name = "Loại chai 20ml giá 35k";
            price35.icon = "/assets/images/categories/price-filter.png";
            price35.description = String.Empty;
            price35.filter.priceMin = 31000;
            price35.filter.priceMax = 35000;

            // Loại chai ống giá sỉ 49k
            var price49 = (FlutterCategoryModel)perfume.Clone();
            price49.name = "Loại chai ống giá sỉ 49k";
            price49.icon = "/assets/images/categories/price-filter.png";
            price49.description = String.Empty;
            price49.filter.priceMin = 36000;
            price49.filter.priceMax = 49000;

            // Loại chai 50ml sỉ 135k
            var price135 = (FlutterCategoryModel)perfume.Clone();
            price135.name = "Loại chai 50ml sỉ 135k";
            price135.icon = "/assets/images/categories/price-filter.png";
            price135.description = String.Empty;
            price135.filter.priceMin = 135000;
            price135.filter.priceMax = 135000;

            // Loại full size nhiều giá
            var priceAll = (FlutterCategoryModel)perfume.Clone();
            priceAll.name = "Loại full size nhiều giá";
            priceAll.icon = "/assets/images/categories/price-filter.png";
            priceAll.description = String.Empty;
            priceAll.filter.priceMin = 50000;
            priceAll.filter.priceMax = 400000;

            perfume.children = new List<FlutterCategoryModel>()
            {
                price30,
                price35,
                price49,
                price135,
                priceAll
            };

            return perfume;
        }
        #endregion

        /// <summary>
        /// Lấy danh sách các danh mục home
        /// </summary>
        /// <returns></returns>
        public List<FlutterCategoryModel> getHomeCategories()
        {
            var result = new List<FlutterCategoryModel>();

            // Bao lì xì
            var redEnvelop = createCategoryBySlug("bao-li-xi-tet");
            if (redEnvelop != null)
                result.Add(redEnvelop);

            // Đồ bộ nữ
            var womenOutfit = getWomenOutfit();
            if (womenOutfit != null)
                result.Add(womenOutfit);

            // Váy đầm
            var womenDresses = getWomenDresses();
            if (womenDresses != null)
                result.Add(womenDresses);

            // Áo thun nữ, Áo sơ mi nữ, Áo dài cách tân, Quần nữ, Đồ lót nữ, Áo khoác nữ
            result.AddRange(
                createCategoryBySlugs(new List<string>() {
                    "ao-thun-nu",
                    "ao-so-mi-nu",
                    "ao-dai-cach-tan",
                    "quan-nu",
                    "do-lot-nu",
                    "ao-khoac-nu"
                })
            );

            // Quần áo nữ order / sale
            var womenClothes = getWomenClothes();
            if (womenClothes != null)
            {
                // Order
                var womenClothesOrder = (FlutterCategoryModel)womenClothes.Clone();
                womenClothesOrder.name = String.Format("{0} (hàng order)", womenClothesOrder.name);
                womenClothesOrder.description = String.Empty;
                womenClothesOrder.filter.productBadge = (int)ProductBadge.order;
                result.Add(womenClothesOrder);
                // Sale
                var womenClothesSale = (FlutterCategoryModel)womenClothes.Clone();
                womenClothesSale.name = String.Format("{0} (hàng sale)", womenClothesSale.name);
                womenClothesSale.description = String.Empty;
                womenClothesSale.filter.productBadge = (int)ProductBadge.sale;
                result.Add(womenClothesSale);
            }

            var menTShirt = getMenTShirt();
            if (menTShirt != null)
                result.Add(menTShirt);

            // Sơ mi nam, Áo khoác nam, Quần nam, Quần lót nam, Set bộ nam
            result.AddRange(
                createCategoryBySlugs(new List<string>() {
                    "ao-so-mi-nam",
                    "ao-khoac-nam",
                    "quan-nam",
                    "quan-lot-nam",
                    "do-lot-nu",
                    "ao-khoac-nu",
                    "set-bo-nam"
                })
            );

            // Quần áo nữ order / sale
            var menClothes = getMenClothes();
            if (menClothes != null)
            {
                // Order
                var menClothesOrder = (FlutterCategoryModel)menClothes.Clone();
                menClothesOrder.name = String.Format("{0} (hàng order)", menClothesOrder.name);
                menClothesOrder.description = String.Empty;
                menClothesOrder.filter.productBadge = (int)ProductBadge.order;
                result.Add(menClothesOrder);
                // Sale
                var menClothesSale = (FlutterCategoryModel)menClothes.Clone();
                menClothesSale.name = String.Format("{0} (hàng sale)", menClothesSale.name);
                menClothesSale.description = String.Empty;
                menClothesSale.filter.productBadge = (int)ProductBadge.sale;
                result.Add(menClothesSale);
            }

            var perfume = getPerfume();

            if (perfume != null)
                result.Add(perfume);

            return result;
        }

        /// <summary>
        /// Lấy danh sách các danh mục jome
        /// </summary>
        /// <returns></returns>
        public List<FlutterCategoryModel> getCategories()
        {
            var result = new List<FlutterCategoryModel>();

            var womenClothes = getWomenClothes();
            var menClothes = getMenClothes();

            #region Hàng có sẵn mới về
            var productStockInNews = new FlutterCategoryModel()
            {
                name = "Hàng có sẵn mới về",
                icon = "/assets/images/categories/new-product.png",
                description = "Hàng có sẳn ở kho",
                filter = new FlutterProductFilterModel() { productBadge = (int)ProductBadge.stockIn, productSort = (int)ProductSortKind.ProductNew }
            };
            #endregion

            #region Hàng order mới về
            var productOrderNews = new FlutterCategoryModel()
            {
                name = "Hàng order mới về",
                icon = "/assets/images/categories/order-product.png",
                description = "Không có sẳn ở kho",
                filter = new FlutterProductFilterModel() { productBadge = (int)ProductBadge.order, productSort = (int)ProductSortKind.ProductNew }
            };
            #endregion

            #region Hàng sale
            var productSale = new FlutterCategoryModel()
            {
                name = "Hàng sale",
                icon = "/assets/images/categories/sale-product.png",
                description = "Tất cả hàng sale",
                filter = new FlutterProductFilterModel() { productBadge = (int)ProductBadge.sale, productSort = (int)ProductSortKind.ProductNew },
                children = new List<FlutterCategoryModel>()
            };

            // Quần áo nữ sale
            if (womenClothes != null)
            {
                var womenClothesSale = (FlutterCategoryModel)womenClothes.Clone();
                womenClothesSale.name = "Quần áo nữ sale";
                womenClothesSale.icon = "/assets/images/categories/category-18.jpg";
                womenClothesSale.description = "Tất cả quần áo nữ sale";
                womenClothesSale.filter.productBadge = (int)ProductBadge.sale;

                productSale.children.Add(womenClothesSale);
            }

            // Quần áo nam sale
            if (menClothes != null)
            {
                var menClothesSale = (FlutterCategoryModel)menClothes.Clone();
                menClothesSale.name = "Quần áo nam sale";
                menClothesSale.icon = "/assets/images/categories/category-2.jpg";
                menClothesSale.description = "Tất cả quần áo nam sale";
                menClothesSale.filter.productBadge = (int)ProductBadge.sale;

                productSale.children.Add(menClothesSale);
            }
            #endregion

            // Hàng mới về
            var productNews = new FlutterCategoryModel()
            {
                name = "Hàng mới về",
                icon = "/assets/images/categories/new-product.png",
                description = "Tất cả hàng mới về",
                filter = new FlutterProductFilterModel() { productSort = (int)ProductSortKind.ProductNew },
                children = new List<FlutterCategoryModel>()
                {
                    productStockInNews,
                    productOrderNews,
                    productSale
                }
            };
            result.Add(productNews);

            // Hàng sale
            result.Add(productSale);

            // Quần áo nữ
            if (womenClothes != null)
                result.Add(womenClothes);

            // Quần áo nam
            if (menClothes != null)
                result.Add(menClothes);

            // Nước hoa
            var perfume = getPerfume();

            if (perfume != null)
                result.Add(perfume);

            // Bao lì xì
            var redEnvelope = createCategoryBySlug("bao-li-xi-tet");

            if (redEnvelope != null)
                result.Add(redEnvelope);

            return result;
        }
        #endregion

        #region Khởi tạo danh mục
        /// <summary>
        /// Khởi tạo category cho block product
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public FlutterCategoryModel createCategoryBlockProduct(string slug)
        {
            using (var con = new inventorymanagementEntities())
            {
                var parent = con.tbl_Category
                    .Where(x =>
                        (!String.IsNullOrEmpty(slug) && x.Slug == slug) ||
                        (String.IsNullOrEmpty(slug) && x.CategoryLevel == 0)
                    )
                    .Select(x => new {
                        id = x.ID,
                        name = x.CategoryName,
                        slug = x.Slug,
                        icon = x.Icon,
                        description = x.CategoryDescription
                    })
                    .FirstOrDefault();

                if (parent != null)
                {
                    var children = con.tbl_Category
                        .Where(x => x.ParentID == parent.id)
                        .OrderBy(o => o.ID)
                        .Select(x => new FlutterCategoryModel()
                        {
                            name = x.CategoryName,
                            icon = x.Icon,
                            description = x.CategoryDescription,
                            filter = new FlutterProductFilterModel() { categorySlug = x.Slug, productSort = (int)ProductSortKind.ProductNew }
                        })
                        .ToList();

                    var result = new FlutterCategoryModel()
                    {
                        name = parent.name,
                        icon = parent.icon,
                        description = parent.description,
                        filter = new FlutterProductFilterModel()
                        {
                            categorySlug = parent.slug,
                            productSort = (int)ProductSortKind.ProductNew
                        },
                        children = children.Count > 0 ? children : null
                    };

                    return result;
                }

                return null;
            }
        }

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
                name = title,
                icon = String.Empty,
                description = String.Empty,
                filter = new FlutterProductFilterModel() { categorySlugList = slugs, productSort = (int)ProductSortKind.ProductNew },
            };

            // Tạo category con
            var children = new List<FlutterCategoryModel>();
            foreach (var item in slugs)
            {
                var child = createCategoryBlockProduct(item);
                if (child != null)
                    children.Add(new FlutterCategoryModel()
                    {
                        name = child.name,
                        icon = child.icon,
                        description = child.description,
                        filter = new FlutterProductFilterModel()
                        {
                            categorySlug = child.filter.categorySlug,
                            productSort = (int)ProductSortKind.ProductNew
                        }
                    });
            }
            
            if (children.Count > 0)
                result.children = children;

            return result;
        }

        public FlutterCategoryModel createCategoryByTag(string title, string icon, string tagSlug)
        {
            return new FlutterCategoryModel()
            {
                name = title,
                icon = icon,
                description = String.Empty,
                filter = new FlutterProductFilterModel()
                {
                    tagSlug = tagSlug,
                    productSort = (int)ProductSortKind.ProductNew
                }
            };
        }

        /// <summary>
        /// Khởi tạo category từ slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public FlutterCategoryModel createCategoryBySlug(string slug)
        {
            using (var con = new inventorymanagementEntities())
            {
                if (String.IsNullOrEmpty(slug))
                    return null;

                var category = con.tbl_Category.Where(x => x.Slug.Trim().ToLower() == slug.Trim().ToLower()).FirstOrDefault();

                // Kiểm tra xem có tồn tại hay không
                if (category == null)
                    return null;

                return new FlutterCategoryModel()
                {
                    name = category.CategoryName,
                    icon = category.Icon,
                    description = category.CategoryDescription,
                    filter = new FlutterProductFilterModel()
                    {
                        categorySlug = slug.Trim().ToLower(),
                        productSort = (int)ProductSortKind.ProductNew
                    },
                };
            }
        }

        /// <summary>
        /// Khởi tạo danh sách category từ danh sách slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public List<FlutterCategoryModel> createCategoryBySlugs(List<string> slugs)
        {
            var result = new List<FlutterCategoryModel>();

            foreach (var item in slugs)
            {
                var data = createCategoryBySlug(item);

                if (data != null)
                    result.Add(data);
            }

            return result;
        }
        #endregion
    }
}