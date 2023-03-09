using System.ComponentModel.DataAnnotations;

namespace EctakoTest.WebApp.Endpoints.Products;

public class CreateProductRequest : BaseResponse
{
    [Required]
    public string? Name { get; set; }
    public double? Price { get; set; }
    public double? PriceWithVat { get; set; }
    public double? VatRate { get; set; }
    [Required]
    [Range(1, Int32.MaxValue)]
    public int GroupId { get; set; }
    public IEnumerable<CreateProductStoreRequest>? Stores { get; set; }
}