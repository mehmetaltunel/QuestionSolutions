using AutoMapper;
using QuestionSolutions.Main.Application.Queries.Category.GetById;
using QuestionSolutions.Main.Domain.Shcemas.Main.CategoryAggregates;

namespace QuestionSolutions.Main.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category,CategoryGetByIdDto>();
        }
    }
}