namespace EctakoTest.WebApp.Endpoints.ProductGroups;

public class GetProductGroupChildResponse : BaseResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public IEnumerable<GetProductGroupChildResponse>? Children { get; set; }
}