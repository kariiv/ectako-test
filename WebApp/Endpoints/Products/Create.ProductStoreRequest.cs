using System.ComponentModel.DataAnnotations;

namespace EctakoTest.WebApp.Endpoints.Products;

public class CreateProductStoreRequest : BaseResponse
{
    [Required]
    public int Id { get; set; }
}