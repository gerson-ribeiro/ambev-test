﻿using Ambev.DeveloperEvaluation.Application.Promotions.GetPromotion;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Categories.GetCategory;

public class GetCategoryProfile : Profile
{
    public GetCategoryProfile()
    {
        CreateMap<Category, GetCategoryResult>();
        CreateMap<Promotion, GetPromotionResult>();
    }
}
