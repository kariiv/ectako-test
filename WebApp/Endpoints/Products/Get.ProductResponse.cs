using EctakoTest.WebApp.Endpoints.ProductGroups;

namespace EctakoTest.WebApp.Endpoints.Products;

public class GetProductResponse : BaseResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double? Price { get; set; }
    public double? PriceWithVat { get; set; }
    public double? VatRate { get; set; }
    public int? GroupId { get; set; }
    public GetProductGroupResponse? Group { get; set; }
    public IEnumerable<GetProductStoreResponse>? Stores { get; set; }
}