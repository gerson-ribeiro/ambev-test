using Ambev.DeveloperEvaluation.ORM.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;    
    private readonly IMapper _mapper;

    public CreateSaleHandler(ISaleRepository saleRepository, IProductRepository productRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }
    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = _mapper.Map<Domain.Entities.Sale>(request);

        #region Apply Promotions
        foreach (var saleItem in sale.Items)
        {
            var product = await _productRepository.GetByIdAsync(saleItem.ProductId, cancellationToken);
            if (product.Promotions.Count > 0)
            {
                var promotions = product.Promotions.OrderByDescending(p => p.Percent);
                foreach (var promo in promotions)
                {
                    if (saleItem.Quantity >= promo.MinUnit && saleItem.Quantity <= promo?.MaxUnit)
                    {
                        saleItem.UnitPrice = product.OriginalPrice - (product.OriginalPrice * promo.Percent / 100);
                    }
                }
            }
            else
            {
                saleItem.UnitPrice = product.OriginalPrice;

            }
        }
        sale.Total = sale.Items.Sum(i => i.UnitPrice);
        #endregion

        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
        
        return _mapper.Map<CreateSaleResult>(createdSale);
    }
}
