using ann_shop_server.Models;
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
                var imageProduct = data.Select(x => x.ProductImage);
                var imageProductVariable = data
                    .Join(
                        con.tbl_ProductVariable,
                        p => p.ID,
                        v => v.ProductID,
                        (p, v) => v.Image
                    );

                var imageProductImage = data
                    .Join(
                        con.tbl_ProductImage,
                        p => p.ID,
                        i => i.ProductID,
                        (p, i) => i.ProductImage
                    );

                var images = imageProduct.Union(imageProductVariable).Union(imageProductImage).ToList();

                return images;
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
                    .Select(x => x.image)
                    .ToList();

                return images.FirstOrDefault();
            }
        }
    }
}