using AutoMapper;
using EctakoTest.Core.Entities.ProductAggregate;
using EctakoTest.Core.Interfaces.services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EctakoTest.WebApp.Endpoints.Products;

public class Create : BaseController
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;

    public Create(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [SwaggerOperation(
        Summary = "Create a Product",
        OperationId = "products.create",
        Tags = new[] { "Products" })
    ]
    [HttpPost]
    public async Task<ActionResult<GetProductResponse>> HandleAsync([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        var result = await _service.CreateAsync(product, cancellationToken);
        return CreatedAtRoute("Products_Get", new { id = result.Id }, _mapper.Map<GetProductResponse>(result));
    }
}