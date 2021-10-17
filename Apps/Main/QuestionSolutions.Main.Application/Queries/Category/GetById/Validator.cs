using System.Data;
using FluentValidation;
using QuestionSolutions.SharedKernel.MediatR.Abstractions;

namespace QuestionSolutions.Main.Application.Queries.Category.GetById
{
    public class Validator : ValidatorBase<Query>
    {
        public Validator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}