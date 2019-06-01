using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ann_shop_server.Services
{
    public class ProductService: Service<ProductService>
    {
        private List<int> getCategoryChild(inventorymanagementEntities con, int parentID)
        {
            var result = new List<int>();
            result.Add(parentID);

            var child = con.tbl_Category
                .Where(x => x.ParentID.Value == parentID)
                .Select(x => x.ID)
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

        public ProductPageModel getProducts(int categoryID, int pageNumber, int pageSize)
        {
            using (var con = new inventorymanagementEntities())
            {
                var source = con.tbl_Product.OrderBy(o => o.ID);

                if (categoryID != 0)
                {
                    // Trường hợp đặt biệt: Đối ưng đệ quy cho sql server
                    var categories = new List<int>();
                    categories.AddRange(getCategoryChild(con, categoryID));

                    source = source
                        .Where(x => categories.Contains(x.CategoryID.Value))
                        .OrderBy(o => o.ID);
                }
                // Get's No of Rows Count
                int count = source.Count();

                // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1
                int CurrentPage = pageNumber;

                // Parameter is passed from Query string if it is null then it default Value will be pageSize:20
                int PageSize = pageSize;

                // Display TotalCount to Records to User  
                int TotalCount = count;

                // Calculating Totalpage by Dividing (No of Records / Pagesize)
                int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

                // Returns List of Customer after applying Paging
                var data = source
                    .Skip((CurrentPage - 1) * PageSize)
                    .Take(PageSize);

                var stockService = StockService.Instance;
                var stockFilter = con.tbl_StockManager
                    .Join(
                        data,
                        s => s.ParentID,
                        d => d.ID,
                        (s, d) => s
                    )
                    .OrderBy(x => new { x.ParentID, x.ProductID, x.ProductVariableID })
                    .ToList();
                var stocks = stockService.getQuantities(stockFilter);

                var categories = con.tbl_Category
                    .Join(
                        data,
                        c => c.ID,
                        d => d.CategoryID.Value,
                        (c, d) => new
                        {
                            productID = d.ID,
                            categoryName = c.CategoryName
                        }
                    )
                    .OrderBy(x => x.productID)
                    .ToList();

                var products = data.OrderBy(x => x.ID).ToList()
                    .Join(
                        categories,
                        pro => pro.ID,
                        cat => cat.productID,
                        (pro, cat) => new ProductDetailPageModel()
                        {
                            id = pro.ID,
                            categoryID = pro.CategoryID.Value,
                            categoryName = cat.categoryName,
                            name = pro.ProductTitle,
                            sku = pro.ProductSKU,
                            materials = pro.Materials,
                            regularPrice = pro.Regular_Price.HasValue ? pro.Regular_Price.Value : 0,
                            retailPrice = pro.Regular_Price.HasValue ? pro.Retail_Price.Value : 0,
                            images = new List<string>() { imageURL + "/uploads/images/8438-33d76f7e-d7e9-4659-a1c0-4426b191c22c.jpeg" }
                        }
                    )
                    .GroupJoin(
                        stocks,
                        pro => pro.id,
                        info => info.id,
                        (pro, info) => new { pro, info }
                    )
                    .SelectMany(
                        x => x.info.DefaultIfEmpty(),
                        (parent, child) => new ProductDetailPageModel()
                        {
                            id = parent.pro.id,
                            categoryID = parent.pro.categoryID,
                            categoryName = parent.pro.categoryName,
                            name = parent.pro.name,
                            sku = parent.pro.sku,
                            availability = child != null ? child.availability : false,
                            materials = parent.pro.materials,
                            regularPrice = parent.pro.regularPrice,
                            retailPrice = parent.pro.retailPrice,
                            images = parent.pro.images
                        }
                    )
                    .OrderBy(o => o.id)
                    .ToList();

                // if CurrentPage is greater than 1 means it has previousPage
                var previousPage = CurrentPage > 1 ? "Yes" : "No";

                // if TotalPages is greater than CurrentPage means it has nextPage
                var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

                // Object which we are going to send in header
                var paginationMetadata = new PaginationMetadataModel()
                {
                    totalCount = TotalCount,
                    pageSize = PageSize,
                    currentPage = CurrentPage,
                    totalPages = TotalPages,
                    previousPage = previousPage,
                    nextPage = nextPage
                };

                return new ProductPageModel()
                {
                    paginationMetadata = paginationMetadata,
                    data = products
                };
            }
        }
    }
}