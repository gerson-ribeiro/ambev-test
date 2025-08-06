using Ambev.DeveloperEvaluation.Application.Categories.UpdateCategory;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    public UpdateProductHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var existingProduct = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existingProduct == null)
            throw new Exception("Product not found");

        existingProduct.Identification = request.Identification;
        existingProduct.Sku = request.Sku;
        existingProduct.BarCode = request.BarCode;
        existingProduct.ImageURL = request.ImageURL;
        existingProduct.Description = request.Description;
        existingProduct.OriginalPrice = request.OriginalPrice;
        existingProduct.Active = request.Active;
        existingProduct.CategoryId = request.Category?.Id ?? request.CategoryId;
        existingProduct.PromotionIds = request.PromotionIds;

        existingProduct.Promotions.Clear();
        foreach (var promo in request.Promotions)
        {
            existingProduct.Promotions.Add(
                new Promotion(promo.Identification,promo.Percent,promo.MaxUnit, promo.MinUnit,promo.ExpirationDate)
            {
                Id = promo.Id
            });
        }

        var updated = await _productRepository.UpdateAsync(existingProduct, cancellationToken);
        if (!updated)
            throw new Exception("Failed to update the product.");

        return _mapper.Map<UpdateProductResult>(existingProduct);
    }
}
