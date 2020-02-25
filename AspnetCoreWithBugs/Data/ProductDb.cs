using AspnetCoreWithBugs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreWithBugs.Data
{
    public static class ProductDb
    {
        //public static async Task<Product> GetProductById(int id, ProductContext context)
        //{
        //    Product p = await (from product in context.Product
        //                       where product.ProductId)
        //}

        public static async Task<Product> Create(Product p, ProductContext context)
        {
            await context.AddAsync(p);
            await context.SaveChangesAsync();

            return p;
        }





    }
}
