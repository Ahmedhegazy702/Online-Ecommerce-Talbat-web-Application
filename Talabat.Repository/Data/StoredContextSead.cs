using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entites;
using Talabat.Repository.Data.Config;

namespace Talabat.Repository.Data
{
    public static class StoredContextSead
    {
        public static async Task SeedAsync(StoreContext dbcontext)
        {
            if (dbcontext.ProductBrands.Count()==0)
            {
                var brandsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands?.Count() > 0)
                {
                    foreach (var brand in brands)
                        await dbcontext.Set<ProductBrand>().AddAsync(brand);
                    await dbcontext.SaveChangesAsync();
                }
            }


            if (dbcontext.ProductCategories.Count() == 0)
            {
                var categoryData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoryData);
                if (categories?.Count() > 0)
                {
                    foreach (var category in categories)
                        await dbcontext.Set<ProductCategory>().AddAsync(category);
                    await dbcontext.SaveChangesAsync();
                }
            }



            if (dbcontext.Products.Count() == 0)
            {
                var productsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products?.Count() > 0)
                {
                    foreach (var product in products)
                        await dbcontext.Set<Product>().AddAsync(product);
                    await dbcontext.SaveChangesAsync();
                }
            }
        }
    }
}

