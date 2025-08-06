using Ambev.DeveloperEvaluation.Application.Promotions.CreatePromotion;
using Ambev.DeveloperEvaluation.Application.Promotions.GetPromotion;
using Ambev.DeveloperEvaluation.Application.Promotions.UpdatePromotion;
using Ambev.DeveloperEvaluation.Domain.Entities.Queries;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Categories.CreateCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Categories.ListCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Promotions.CreatePromotions;
using Ambev.DeveloperEvaluation.WebApi.Features.Promotions.GetPromotions;
using Ambev.DeveloperEvaluation.WebApi.Features.Promotions.ListPromotions;
using Ambev.DeveloperEvaluation.WebApi.Features.Promotions.UpdatePromotions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Promotions;

[ApiController]
[Route("api/[controller]")]
public class PromotionController : BaseController
{
    public PromotionController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<ListPromotionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListPromotions([FromQuery] ListPromotionRequest request, CancellationToken cancellationToken)
    {
        var validator = new ListPromotionRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var query = _mapper.Map<ListPromotionQuery>(request);
        var response = await _mediator.Send(query, cancellationToken);

        var items = _mapper.Map<List<ListPromotionItemResponse>>(response.Items);
        return OkPaginated(new PaginatedList<ListPromotionItemResponse>(items, response.TotalCount!.Value, response.CurrentPage!.Value, response.PageSize!.Value));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<ListPromotionItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPromotion([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetPromotionRequest { Id = id };
        var validator = new GetPromotionRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var query = _mapper.Map<GetPromotionQuery>(request);
        var response = await _mediator.Send(query, cancellationToken);
        if (response == null)
        {
            return NotFound(new ApiResponse
            {
                Success = false,
                Message = "Promotion not found"
            });
        }
        return Ok(_mapper.Map<ListPromotionItemResponse>(response));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<ListPromotionItemResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreatePromotion([FromBody] CreatePromotionRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreatePromotionRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreatePromotionCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        return Created(string.Empty, new ApiResponse
        {
            Success = true,
            Message = "Promotion created successfully",
        });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdatePromotion([FromRoute] Guid id, [FromBody] UpdatePromotionRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdatePromotionRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        var command = _mapper.Map<UpdatePromotionCommand>(request);
        command.Id = id;
        var response = await _mediator.Send(command, cancellationToken);
        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Promotion updated successfully",
        });
    }

}
