using AutoMapper;
using EctakoTest.Core.Interfaces.services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EctakoTest.WebApp.Endpoints.Stores;

public class List : BaseController
{
    private readonly IStoreService _service;
    private readonly IMapper _mapper;

    public List(IStoreService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [SwaggerOperation(
        Summary = "Get all Stores",
        OperationId = "stores.get-all",
        Tags = new[] { "Stores" })
    ]
    [HttpGet]
    public async Task<IEnumerable<GetStoreResponse>> HandleAsync(CancellationToken cancellationToken)
    {
        var listAll = await _service.GetAllAsync(cancellationToken);
        return listAll.Select(i => _mapper.Map<GetStoreResponse>(i));
    }
}