using System.ComponentModel.DataAnnotations;

namespace EctakoTest.WebApp.Endpoints.Products;

public class CreateProductRequest : BaseResponse
{
    [Required]
    [MinLength(3), MaxLength(255)]
    public string? Name { get; set; }
    [Range(0, Double.MaxValue)]
    public double? Price { get; set; }
    [Range(0, Double.MaxValue)]
    public double? PriceWithVat { get; set; }
    [Range(0, Double.MaxValue)]
    public double? VatRate { get; set; }
    [Required]
    [Range(1, Int32.MaxValue)]
    public int GroupId { get; set; }
    public IEnumerable<CreateProductStoreRequest>? Stores { get; set; }
}