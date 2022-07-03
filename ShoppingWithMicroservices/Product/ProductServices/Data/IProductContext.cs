using MongoDB.Driver;
using ProductServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Data
{
    public interface IProductContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
