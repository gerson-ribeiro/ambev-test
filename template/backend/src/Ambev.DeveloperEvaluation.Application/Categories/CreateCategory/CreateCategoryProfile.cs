using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Categories.CreateCategory;

public class CreateCategoryProfile : Profile
{
    public CreateCategoryProfile()
    {
        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<Category, CreateCategoryResult>();
    }
}
