using ann_shop_server.Models;
using ann_shop_server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class ImageService: Service<ImageService>
    {
        public List<string> getByProduct(int productID)
        {
            using (var con = new inventorymanagementEntities())
            {
                var data = con.tbl_Product.Where(x => x.ID == productID);
                var productVariable = data
                    .Join(
                        con.tbl_ProductVariable,
                        p => p.ID,
                        v => v.ProductID,
                        (p, v) => v
                    );
                var productImage = data
                    .Join(
                        con.tbl_ProductImage,
                        p => p.ID,
                        i => i.ProductID,
                        (p, i) => new { p, i}
                    )
                    .Where(x => x.i.ProductImage != x.p.ProductImage)
                    .Select(x => x.i)
                    .Join(
                        productVariable,
                        i => i.ProductID,
                        v => v.ProductID,
                        (i, v) => new { i, v }
                    )
                    .Where(x => x.i.ProductImage != x.v.Image)
                    .Select(x => x.i);

                var images = data.Select(x => new { index = 1, image = x.ProductImage })
                    .Union(productVariable.Select(x => new { index = 2, image = x.Image }))
                    .Union(productImage.Select(x => new { index = 3, image = x.ProductImage }))
                    .OrderBy(x => x.index)
                    .Select(x => x.image)
                    .ToList();

                return images.Select(x => Thumbnail.getURL(x, Thumbnail.Size.Source)).ToList();
            }
        }

        public string getByProductVariable(int productID, List<int> variables)
        {
            using (var con = new inventorymanagementEntities())
            {
                var variableValues = con.tbl_ProductVariableValue
                    .Where(x => variables.Contains(x.VariableValueID.Value));

                var images = con.tbl_Product.Where(x => x.ID == productID)
                    .Join(
                        con.tbl_ProductVariable,
                        p => p.ID,
                        v => v.ProductID,
                        (p, v) => new { productVariableID = v.ID, image = v.Image }
                    )
                    .Join(
                        variableValues,
                        p => p.productVariableID,
                        v => v.ProductVariableID,
                        (p, v) => p
                    )
                    .ToList();

                return images.Select(x => Thumbnail.getURL(x.image, Thumbnail.Size.Source)).FirstOrDefault();
            }
        }
    }
}