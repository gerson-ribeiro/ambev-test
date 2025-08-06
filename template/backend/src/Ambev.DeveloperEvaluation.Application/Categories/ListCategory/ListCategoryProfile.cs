using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.Results;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Categories.ListCategory;

public class ListCategoryProfile: Profile
{
    public ListCategoryProfile()
    {
        CreateMap<Category, ListCategoryItemResult>();
        CreateMap<Promotion, ListPromotionResult>();
    }
}
