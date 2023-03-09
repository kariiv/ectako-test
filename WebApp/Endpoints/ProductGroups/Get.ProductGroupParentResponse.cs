namespace EctakoTest.WebApp.Endpoints.ProductGroups;

public class GetProductGroupParentResponse : BaseResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public GetProductGroupParentResponse? Parent { get; set; }
}