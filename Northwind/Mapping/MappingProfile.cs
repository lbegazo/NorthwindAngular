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
            #region From Domain class to Api Resource

            CreateMap<Category, CategoryResource>();
            CreateMap<Supplier, SupplierResource>();

            CreateMap<Product, ProductResource>()
                .ForMember(pr => pr.Features, opt => opt.MapFrom(p => p.Features.Select(f => f.FeatureId)));

            CreateMap<Supplier, SupplierResource>()
                .ForMember(sr => sr.Contact, opt => opt.MapFrom(s => new ContactResource { Name = s.CompanyName, Email = s.ContactEmail, Title = s.ContactTitle }));

            #endregion From Domain class to Api Resource

            #region From Api Resource to Domain class

            CreateMap<ProductResource, Product>()
                .ForMember( p => p.Features, 
                            opt => opt.MapFrom(pr => pr.Features.Select(id => new ProductFeature { FeatureId = id })));

            CreateMap<SupplierResource, Supplier>()
                .ForMember(s => s.ContactName, opt => opt.MapFrom(sr => sr.Contact.Name))
                .ForMember(s => s.ContactTitle, opt => opt.MapFrom(sr => sr.Contact.Title))
                .ForMember(s => s.ContactEmail, opt => opt.MapFrom(sr => sr.Contact.Email));

            #endregion From Api Resource to Domain class

        }
    }
}
