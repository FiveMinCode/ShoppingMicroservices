using AutoMapper;
using ProductServices.Dto;
using ProductServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Mapper
{
    public class ProductMapper: Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
