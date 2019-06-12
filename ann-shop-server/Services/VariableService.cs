using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class VariableService: Service<VariableService>
    {
        public List<VariableModel> getVariables(int parentID, int kindID)
        {
            using (var con = new inventorymanagementEntities())
            {
                var variables = con.tbl_Product.Where(x => x.ID == parentID)
                    .Join(
                        con.tbl_ProductVariable,
                        p => p.ID,
                        v => v.ProductID,
                        (p, v) => v
                    )
                    .Join(
                        con.tbl_ProductVariableValue,
                        p => p.ID,
                        v => v.ProductVariableID,
                        (p, v) => new
                        {
                            VariableValueID = v.VariableValueID.HasValue ? v.VariableValueID.Value : 0
                        }
                    )
                    .GroupBy(x => x.VariableValueID)
                    .Select(x => new { VariableValueID = x.Key })
                    .Join(
                        con.tbl_VariableValue.Where(x => x.VariableID == kindID),
                        p => p.VariableValueID,
                        v => v.ID,
                        (p, v) => v
                    )
                    .OrderBy(o => o.ID)
                    .Select(x => new VariableModel()
                        {
                            key = x.ID,
                            name = x.VariableValue
                        }
                    )
                    .ToList();

                return variables;
            }
        }
    }
}