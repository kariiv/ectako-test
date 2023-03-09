using Ardalis.GuardClauses;
using EctakoTest.Core.Entities.StoreAggregate;

namespace EctakoTest.Core.Entities.ProductAggregate;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public double? Price { get; set; }
    public double? PriceWithVat { get; set; }
    public double? VatRate { get; set; }
    
    public ProductGroup? Group { get; set; }
    public int GroupId { get; set; }
    
    public IEnumerable<Store> Stores => _stores.AsEnumerable();
    private readonly List<Store> _stores = new ();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    

    public void UpdateDetails(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }
    public Store AddStore(Store store)
    {
        Guard.Against.Null(store, nameof(store));
        
        _stores.Add(store);
        return store;
    }
    public void SetStores(IEnumerable<Store> stores)
    {
        _stores.RemoveRange(0, _stores.Count);
        foreach (var store in stores)
            AddStore(store);
    }
    
    public void UpdatePricing(double price, double priceWithVat, double vatRate)
    {
        Price = price;
        PriceWithVat = priceWithVat;
        VatRate = vatRate;
        
        CalculateTax();
    }

    public void CalculateTax()
    {
        Guard.Against.UnknownTax(Price, VatRate, PriceWithVat);

        if (VatRate is null && Price is not null && PriceWithVat is not null)
            VatRate = (PriceWithVat- Price) * 100 / Price;
        else if (PriceWithVat is null && Price is not null && VatRate is not null)
            PriceWithVat = Price + Price * VatRate/100;
        else if (Price is null && PriceWithVat is not null && VatRate is not null)
            Price = PriceWithVat * 100/ (100 + VatRate);

        Guard.Against.MissMatchTax(Price, VatRate, PriceWithVat);
    }
}