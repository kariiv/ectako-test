using AutoMapper;
using EctakoTest.Core.Interfaces.services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EctakoTest.WebApp.Endpoints.ProductGroups;

public class List : BaseController
{
    private readonly IProductGroupService _service;
    private readonly IMapper _mapper;

    public List(IProductGroupService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [SwaggerOperation(
        Summary = "Get all Product Groups",
        OperationId = "product-groups.get-all",
        Tags = new[] { "Product Groups" })
    ]
    [HttpGet]
    public async Task<IEnumerable<GetProductGroupResponse>> HandleAsync(CancellationToken cancellationToken)
    {
        var listAll = await _service.GetAsTreeAsync(cancellationToken);
        return listAll.Select(i => _mapper.Map<GetProductGroupResponse>(i));
    }
}