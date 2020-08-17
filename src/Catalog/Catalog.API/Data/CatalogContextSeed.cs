using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreConfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            return new List<Product>()
            {
                 new Product()
                 {
                     Name = "Iphone X",
                     Summary = "Apple INC",
                     Description = "Premium Phone",
                     ImageFile = "Iphonex.jpg",
                     Price = 67000,
                     Category = "Smart Phone"
                 },
                  new Product()
                 {
                     Name = "Iphone XR",
                     Summary = "Apple INC",
                     Description = "Premium Phone",
                     ImageFile = "Iphonex.jpg",
                     Price = 62000,
                     Category = "Smart Phone"
                 }

            };
        }
    }
}