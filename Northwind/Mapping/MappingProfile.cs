using AutoMapper;
using Northwind.Controllers.Resources;
using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Supplier, SupplierResource>();
            CreateMap<Product, ProductResource>();
        }
    }
}
