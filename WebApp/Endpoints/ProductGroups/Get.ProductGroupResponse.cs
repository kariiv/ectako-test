namespace EctakoTest.WebApp.Endpoints.ProductGroups;

public class GetProductGroupResponse : BaseResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public GetProductGroupParentResponse? Parent { get; set; }
    
    public IEnumerable<GetProductGroupChildResponse>? Children { get; set; }
}