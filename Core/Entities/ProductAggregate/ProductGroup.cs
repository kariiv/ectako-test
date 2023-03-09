namespace EctakoTest.Core.Entities.ProductAggregate;

public class ProductGroup : BaseEntity
{
    public string Name { get; set; }
    
    public int? ParentId { get; set; }
    public ProductGroup? Parent { get; set; }
    
    public IEnumerable<ProductGroup> Children => _children.AsEnumerable();
    private readonly List<ProductGroup> _children = new ();
    
    public IEnumerable<Product> Products => _products.AsEnumerable();
    private readonly List<Product> _products = new ();

    public ProductGroup(string name)
    {
        Name = name;
    }
}