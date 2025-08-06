using Ambev.DeveloperEvaluation.Application.Categories.CreateCategory;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Categories.UpdateCategory;

public class UpdateCategoryProfile : Profile
{
    public UpdateCategoryProfile()
    {
        CreateMap<UpdateCategoryCommand, Category>();
        CreateMap<Category, UpdateCategoryResult>();
    }
}
