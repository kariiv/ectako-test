using EctakoTest.Core.Entities.ProductAggregate;
using EctakoTest.Core.Exceptions;

namespace Ardalis.GuardClauses;

public static class ProductGuards
{
    public static void UnknownTax(this IGuardClause guardClause, double? price, double? vatRate, double? priceWithVat)
    {
        IEnumerable<bool> priceVatAttributes = new []{ price != null, vatRate != null, priceWithVat != null };
        if (priceVatAttributes.Count(a => a) < 2)
            throw new UnknownTaxException($"At least two of the following must be present: {nameof(Product.Price)}, {nameof(Product.VatRate)}, {nameof(Product.PriceWithVat)}");
    }
    
    public static void MissMatchTax(this IGuardClause guardClause, double? price, double? vatRate, double? priceWithVat)
    {
        IEnumerable<bool> priceVatAttributes = new []{ price != null, vatRate != null, priceWithVat != null };
        if (priceVatAttributes.Count(a => a) != 3) return;
        
        if (Math.Abs(price!.Value + price.Value * (vatRate!.Value / 100) - priceWithVat!.Value) >= 0.01)
            throw new UnknownTaxException("Price and VAT values not match!");
    }
}