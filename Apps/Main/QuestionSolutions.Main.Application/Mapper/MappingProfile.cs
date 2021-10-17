using System.Collections.Generic;
using AutoMapper;
using QuestionSolutions.Main.Application.Queries.Category.GetAll;
using QuestionSolutions.Main.Application.Queries.Category.GetById;
using QuestionSolutions.Main.Domain.Shcemas.CORE.CategoryAggregates;

namespace QuestionSolutions.Main.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category,CategoryGetByIdDto>();
            CreateMap<Category, CategoryGetAllDto>();
            CreateMap<Commands.Category.Insert.Command, Category>();
            CreateMap<Commands.Category.Update.Command, Category>();
        }
    }
}