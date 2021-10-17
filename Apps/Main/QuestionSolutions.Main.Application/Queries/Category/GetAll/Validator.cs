using System.Data;
using FluentValidation;
using QuestionSolutions.SharedKernel.MediatR.Abstractions;

namespace QuestionSolutions.Main.Application.Queries.Category.GetAll
{
    public class Validator : ValidatorBase<Query>
    {
        public Validator()
        {
        }
    }
}