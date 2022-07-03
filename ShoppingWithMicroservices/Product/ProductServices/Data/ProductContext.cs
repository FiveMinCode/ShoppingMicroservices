using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProductServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Data
{
    public class ProductContext : IProductContext
    {
        public IMongoCollection<Product> Products { get; }
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:Databasename"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            ProductContextSeedData.SeedData(Products);
        }
    }
}
