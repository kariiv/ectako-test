using Ardalis.GuardClauses;
using EctakoTest.Core.Entities.ProductAggregate;

namespace EctakoTest.Core.Entities.StoreAggregate;

public class Store : BaseEntity
{
    public string Name { get; set; }
    
    public IEnumerable<Product> Products => _products.AsEnumerable();
    private readonly List<Product> _products = new ();
    
    public Store()
    {
        // AutoMapper requirement
    }
    
    public Store(string name)
    {
        Name = name;
    }
    
    public Product AddProduct(Product product)
    {
        Guard.Against.Null(product, nameof(product));
        
        _products.Add(product);
        return product;
    }
    public void SetProducts(IEnumerable<Product> products)
    {
        _products.RemoveRange(0, _products.Count);
        foreach (var product in products)
            AddProduct(product);
    }
}