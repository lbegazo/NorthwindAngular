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

            CreateMap<Feature, KeyValuePairResource>();

            CreateMap<Category, CategoryResource>();

            CreateMap<Category, KeyValuePairResource>();

            CreateMap<Product, ProductResource>()
                .ForMember(pr => pr.Features, opt => opt.MapFrom(p => p.Features.Select(f => f.FeatureId)));

            CreateMap<Supplier, SupplierResource>()
                .ForMember(sr => sr.Contact,
                            opt => opt.MapFrom(s => new ContactResource
                            {
                                Name = s.ContactName,
                                Email = s.ContactEmail,
                                Title = s.ContactTitle
                            }));


            #endregion From Domain class to Api Resource

            #region From Api Resource to Domain class

            CreateMap<ProductResource, Product>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Category, opt => opt.Ignore())
                .ForMember(p => p.Features, opt => opt.Ignore())
                .AfterMap((pr, p) =>
                {
                    #region Por Eliminar

                    //Delete Features
                    //var removedFeatures = new List<ProductFeature>();
                    //foreach (var feature in p.Features)
                    //{
                    //    if (!pr.Features.Contains(feature.FeatureId))
                    //    {
                    //        removedFeatures.Add(feature);
                    //    }
                    //}
                    //foreach (var f in removedFeatures)
                    //    p.Features.Remove(f);

                    //Add new Feature
                    //foreach (var id in pr.Features)
                    //{
                    //    if (!p.Features.Any(f => f.FeatureId == id))
                    //    {
                    //        p.Features.Add(new ProductFeature { FeatureId = id });
                    //    }
                    //}

                    #endregion Por Eliminar
                    var removedFeatures = p.Features.Where(feature => !pr.Features.Contains(feature.FeatureId)).ToList();
                    foreach (var f in removedFeatures)
                        p.Features.Remove(f);

                    var addFeatures = pr.Features.Where(fr => !p.Features.Any(f => f.FeatureId == fr))
                                        .Select(fr => new ProductFeature { FeatureId = fr }).ToList();
                    foreach (var f in addFeatures)
                        p.Features.Add(f);
                });

            CreateMap<KeyValuePairResource, Category>();

            CreateMap<SupplierResource, Supplier>()
                .ForMember(s => s.Id, opt => opt.Ignore())
                .ForMember(s => s.ContactName, opt => opt.MapFrom(sr => sr.Contact.Name))
                .ForMember(s => s.ContactTitle, opt => opt.MapFrom(sr => sr.Contact.Title))
                .ForMember(s => s.ContactEmail, opt => opt.MapFrom(sr => sr.Contact.Email));

            #endregion From Api Resource to Domain class

        }
    }
}
