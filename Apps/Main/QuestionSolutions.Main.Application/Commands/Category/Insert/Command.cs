using QuestionSolutions.SharedKernel.MediatR.Command;

namespace QuestionSolutions.Main.Application.Commands.Category.Insert
{
    public class Command : ICommand
    {
        public string Name { get; set; }
        public long ParentId { get; set; }
    }
}