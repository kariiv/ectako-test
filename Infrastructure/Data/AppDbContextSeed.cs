using EctakoTest.Core.Entities.ProductAggregate;
using EctakoTest.Core.Entities.StoreAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EctakoTest.Infrastructure.Data;

public class AppDbContextSeed
{
    
    private readonly AppDbContext _dbContext;
    private readonly ILoggerFactory _loggerFactory;

    public AppDbContextSeed(AppDbContext dbContext, ILoggerFactory loggerFactory)
    {
        _dbContext = dbContext;
        _loggerFactory = loggerFactory;
    }
    
    public async Task SeedAsync(bool migrate, int retry = 0)
    {
        try
        {
            if (migrate) _dbContext.Database.Migrate();
            
            var stores = GetPreconfiguredStores().ToArray();
            if (!await _dbContext.Stores.AnyAsync())
            {
                await _dbContext.Stores.AddRangeAsync(stores);
                await _dbContext.SaveChangesAsync();
            }
            if (!await _dbContext.ProductGroups.AnyAsync())
            {
                await _dbContext.ProductGroups.AddRangeAsync(GetPreconfiguredProductGroups());
                await _dbContext.SaveChangesAsync();
            }
            if (!await _dbContext.Products.AnyAsync())
            {
                await _dbContext.Products.AddRangeAsync(GetPreconfiguredProducts(stores[0], stores[1], stores[2]));
                await _dbContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            if (retry == 0) throw ex;
            
            var log = _loggerFactory.CreateLogger<AppDbContextSeed>();
            log.LogError(ex.Message);
            await SeedAsync(false, retry - 1);
        }
    }
    static IEnumerable<Store> GetPreconfiguredStores()
    {
        return new List<Store>
        {
            new ("Riivik Production"),
            new ("Go Groceries"),
            new ("Walk a Walk Home")
        };
    }
    static IEnumerable<Product> GetPreconfiguredProducts(Store s1, Store s2, Store s3)
    {
        var product1 = new Product
        {
            Id = 1,
            Name = "Majonees",
            GroupId = 5,
            Price = 100,
            PriceWithVat = 120,
            VatRate = 20
        };
        product1.AddStore(s3);
        product1.AddStore(s2);
        
        var product2 = new Product
        {
            Id = 2,
            Name = "SolidJS Is The Best!",
            GroupId = 2,
            Price = 1000,
            PriceWithVat = 1200,
            VatRate = 20
        };
        product2.AddStore(s1);
        
        var product3 = new Product
        {
            Id = 3,
            Name = "Chicken 500g",
            GroupId = 12,
            Price = 10,
            PriceWithVat = 11,
            VatRate = 10
        };
        product3.AddStore(s3);
        
        return new List<Product>
        {
            product1,
            product2,
            product3,
        };
    }
    static IEnumerable<ProductGroup> GetPreconfiguredProductGroups()
    {
        return new List<ProductGroup>
        {
            new ("IT") { Id = 1 },
            new ("Software")  { Id = 2, ParentId = 1 },
            new ("Hardware")  { Id = 3, ParentId = 1 },
            new ("Software service")  { Id = 4, ParentId = 1  },
            new ("Food")  { Id = 5 },
            new ("Vegetable")  { Id = 7, ParentId = 5 },
            new ("Milk products")  { Id = 8, ParentId = 5 },
            new ("Lactose free")  { Id = 9, ParentId = 8 },
            new ("Meat")  { Id = 10 },
            new ("Pork")  { Id = 11, ParentId = 10},
            new ("Chicken")  { Id = 12, ParentId = 10 },
        };
    }
}