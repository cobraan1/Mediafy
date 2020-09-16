using Mediafy.Shared;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Mediafy.Server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProductDbContext context)
        {
            context.Database.EnsureCreated();

            // Database already contains data, no need to seed it
            if (context.Products.Any())
            {
                return;
            }

            var jsonString = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Products.json"));
            var deserializedProducts = JsonSerializer.Deserialize<List<Product>>(jsonString, 
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

            // Seed the initial setup of SQLite database
            foreach (var deserializedProduct in deserializedProducts)
            {
                context.Products.Add(new Product
                {
                    Name = deserializedProduct.Name,
                    FromPrice = deserializedProduct.FromPrice,
                    Description = deserializedProduct.Description,
                    Image = deserializedProduct.Image,
                    TimesShown = 0
                });
            }

            context.SaveChanges();
        }
        
    }
}