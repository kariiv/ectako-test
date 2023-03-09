namespace EctakoTest.WebApp.Endpoints.Products;

public class GetProductStoreResponse : BaseResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
}