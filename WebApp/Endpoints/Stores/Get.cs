using AutoMapper;
using EctakoTest.Core.Interfaces.services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EctakoTest.WebApp.Endpoints.Stores;

public class Get : BaseController
{
    private readonly IStoreService _service;
    private readonly IMapper _mapper;

    public Get(IStoreService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [SwaggerOperation(
        Summary = "Get a Store by Id",
        OperationId = "stores.get-by-id",
        Tags = new[] { "Stores" })
    ]
    [HttpGet("{id}")]
    public async Task<ActionResult<GetStoreResponse>> HandleAsync(int id, CancellationToken cancellationToken)
    {
        var getById = await _service.GetAsync(id, cancellationToken);
        if (getById is null) return NotFound();
        return _mapper.Map<GetStoreResponse>(getById);
    }
}