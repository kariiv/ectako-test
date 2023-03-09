using AutoMapper;
using EctakoTest.Core.Interfaces.services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EctakoTest.WebApp.Endpoints.Products;

public class List : BaseController
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;

    public List(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [SwaggerOperation(
        Summary = "Get all Products",
        OperationId = "products.get-all",
        Tags = new[] { "Products" })
    ]
    [HttpGet]
    public async Task<IEnumerable<GetProductResponse>> HandleAsync(CancellationToken cancellationToken)
    {
        var listAll = await _service.GetAllAsync(cancellationToken);
        return listAll.Select(i => _mapper.Map<GetProductResponse>(i));
    }
}