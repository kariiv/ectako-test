using AutoMapper;
using EctakoTest.Core.Entities.ProductAggregate;
using EctakoTest.Core.Entities.StoreAggregate;
using EctakoTest.WebApp.Endpoints.ProductGroups;
using EctakoTest.WebApp.Endpoints.Products;
using EctakoTest.WebApp.Endpoints.Stores;

namespace EctakoTest.WebApp.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductStoreRequest, Store>();
        CreateMap<Product, GetProductResponse>();
        CreateMap<Product, GetStoreProductResponse>();
        CreateMap<CreateProductRequest, Product>();
        CreateMap<ProductGroup, GetProductGroupResponse>();
        CreateMap<ProductGroup, GetProductGroupParentResponse>();
        CreateMap<ProductGroup, GetProductGroupChildResponse>();
        CreateMap<Store, GetProductStoreResponse>();
        CreateMap<Store, GetStoreResponse>();
    }
}