using System.Threading.Tasks;
using QuestionSolutions.SharedKernel.SeedWork;

namespace QuestionSolutions.Main.Domain.Shcemas.Main.CategoryAggregates
{
    public interface ICategoryRepository : IRepository
    {
        Task<Category> GetByIdAsync(long id);
    }
}