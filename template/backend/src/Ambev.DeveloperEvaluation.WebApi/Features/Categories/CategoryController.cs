using Ambev.DeveloperEvaluation.Application.Categories.CreateCategory;
using Ambev.DeveloperEvaluation.Application.Categories.GetCategory;
using Ambev.DeveloperEvaluation.Application.Categories.ListCategory;
using Ambev.DeveloperEvaluation.Application.Categories.UpdateCategory;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Domain.Entities.Queries;
using Ambev.DeveloperEvaluation.Domain.Entities.Results;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Categories.CreateCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Categories.GetCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Categories.ListCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Categories.UpdateCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : BaseController
{
    public CategoryController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCategoryResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCategoryRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        var command = _mapper.Map<CreateCategoryCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        return Created(string.Empty, new ApiResponse
        {
            Success = true,
            Message = "Category created successfully"
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetCategoryResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCategories([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetCategoryRequest { Id = id };
        var validator = new GetCategoryRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var query = _mapper.Map<GetCategoryQuery>(request);
        var response = await _mediator.Send(query, cancellationToken);

        return Ok(_mapper.Map<GetCategoryResponse>(response));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCategoryRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateCategoryCommand>(request);
        command.Id = id;
        var response = await _mediator.Send(command, cancellationToken);
        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Category updated successfully"
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<ListSaleItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllCategories([FromQuery] ListCategoryRequest request, CancellationToken cancellationToken)
    {
        var query = _mapper.Map<ListCategoryQuery>(request);
        ListCategoryResult response = await _mediator.Send(query, cancellationToken);

        if (response == null || response.Items.Count <= 0)
        {
            return NotFound(new ApiResponse
            {
                Success = false,
                Message = "No categories found"
            });
        }

        var items = _mapper.Map<List<ListSaleItemResponse>>(response.Items);
        return OkPaginated(new PaginatedList<ListSaleItemResponse>(items, response.TotalCount, response.CurrentPage, response.PageSize));
    }
}
