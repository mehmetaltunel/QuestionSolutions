using QuestionSolutions.SharedKernel.MediatR.Command;

namespace QuestionSolutions.Main.Application.Commands.Category.Update
{
    public class Command : ICommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
    }
}