using Catalog.API.Entities;
using Catalog.API.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data.Interfaces
{
    public class CatelogContext : ICatalogContext
    {
        public CatelogContext(ICatelogDatabaseSettings dbsettings)
        {
            var client = new MongoClient(dbsettings.ConnectionString);
            var database = client.GetDatabase(dbsettings.DatabaseName);
            Products = database.GetCollection<Product>(dbsettings.CollectionName);
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
