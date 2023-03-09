using AutoMapper;
using EctakoTest.Core.Interfaces.services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EctakoTest.WebApp.Endpoints.Products;

public class Get : BaseController
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;

    public Get(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [SwaggerOperation(
        Summary = "Get a Product by Id",
        OperationId = "products.get-by-id",
        Tags = new[] { "Products" })
    ]
    [HttpGet("{id}", Name = "[namespace]_[controller]")]
    public async Task<ActionResult<GetProductResponse>> HandleAsync(int id, CancellationToken cancellationToken)
    {
        var getById = await _service.GetAsync(id, cancellationToken);
        if (getById is null) return NotFound();
        return _mapper.Map<GetProductResponse>(getById);
    }
}