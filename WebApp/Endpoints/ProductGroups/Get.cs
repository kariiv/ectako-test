using AutoMapper;
using EctakoTest.Core.Interfaces.services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EctakoTest.WebApp.Endpoints.ProductGroups;

public class Get : BaseController
{
    private readonly IProductGroupService _service;
    private readonly IMapper _mapper;

    public Get(IProductGroupService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [SwaggerOperation(
        Summary = "Get a Product Group by Id",
        OperationId = "product-groups.get-by-id",
        Tags = new[] { "Product Groups" })
    ]
    [HttpGet("{id}")]
    public async Task<ActionResult<GetProductGroupResponse>> HandleAsync(int id, CancellationToken cancellationToken)
    {
        var getById = await _service.GetAsync(id, cancellationToken);
        if (getById is null) return NotFound();
        return _mapper.Map<GetProductGroupResponse>(getById);
    }
}