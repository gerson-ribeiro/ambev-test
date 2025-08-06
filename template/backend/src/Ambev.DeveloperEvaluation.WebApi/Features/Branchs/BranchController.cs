using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;
using Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch;
using Ambev.DeveloperEvaluation.Application.Categories.GetCategory;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.UpdateBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Categories.GetCategory;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs;

[ApiController]
[Route("api/[controller]")]
public class BranchController : BaseController
{
    public BranchController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetBranchResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBranchById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetBranchRequest { Id = id };
        var validator = new GetBranchRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var query = _mapper.Map<GetBranchQuery>(request);
        var response = await _mediator.Send(query, cancellationToken);

        return Ok(_mapper.Map<GetBranchResponse>(response));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBranch([FromBody] CreateBranchRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateBranchRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateBranchCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        return Created(string.Empty, new ApiResponse
        {
            Success = true,
            Message = "Branch created successfully",
        });
    }

    [HttpPut]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateBranchResponse>), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateBranch([FromBody] UpdateBranchRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateBranchRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateBranchCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return NoContent();
    }

}
