using AspnetCoreWithBugs.Models;
using Microsoft.EntityFrameworkCore;
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

        public static async Task Delete(Product p, ProductContext context)
        {
            await context.AddAsync(p);
            context.Entry(p).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public static async Task<Product> Edit(Product p, ProductContext context)
        {
            await context.AddAsync(p);
            context.Entry(p).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return p;
        }

        public static async Task<int> GetNumProduct(ProductContext context)
        {
            return await context.Product.CountAsync();
        }

        public static async Task<List<Product>> GetProductByPage(ProductContext context, int pageNum, int PageSize)
        {
            const int Pageoffset = 1;

            List<Product> products =
                await context.Product
                             .OrderBy(p => p.ProductId)
                             .Skip(PageSize * (pageNum - Pageoffset))
                             .Take(PageSize)
                             .ToListAsync();
            return products;
        }
    }
}
