namespace EctakoTest.WebApp.Endpoints.Stores;

public class GetStoreResponse : BaseResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public IEnumerable<GetStoreProductResponse>? Products { get; set; }
}