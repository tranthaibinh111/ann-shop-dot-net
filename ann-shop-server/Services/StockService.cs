using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class StockService : Service<StockService>
    {
        public IEnumerable<StockModel> getQuantities(List<tbl_StockManager> stock)
        {
            var result = stock
                    .Select(x => new
                    {
                        parentID = x.ParentID.Value,
                        productID = x.ProductID.Value,
                        productVariableID = x.ProductVariableID.Value,
                        createDate = x.CreatedDate
                    })
                    .GroupBy(x => new { x.parentID, x.productID, x.productVariableID })
                    .Select(g => new
                    {
                        parentID = g.Key.parentID,
                        productID = g.Key.productID,
                        productVariableID = g.Key.productVariableID,
                        doneAt = g.Max(x => x.createDate)
                    })
                    .Join(
                        stock,
                        last => new
                        {
                            parentID = last.parentID,
                            productID = last.productID,
                            productVariableID = last.productVariableID,
                            doneAt = last.doneAt
                        },
                        rec => new
                        {
                            parentID = rec.ParentID.Value,
                            productID = rec.ProductID.Value,
                            productVariableID = rec.ProductVariableID.Value,
                            doneAt = rec.CreatedDate
                        },
                        (last, rec) => new
                        {
                            parentID = last.parentID,
                            quantityCurrent = rec.QuantityCurrent.HasValue ? rec.QuantityCurrent.Value : 0
                        }
                    )
                    .GroupBy(x => x.parentID)
                    .Select(g => new StockModel()
                    {
                        productID = g.Key,
                        quantity = g.Sum(x => Convert.ToInt32(x.quantityCurrent)) ,
                        availability = g.Sum(x => x.quantityCurrent) > 0 ? true : false
                    })
                    .OrderBy(x => x.productID)
                    .ToList();

            return result;
        }
    }
}