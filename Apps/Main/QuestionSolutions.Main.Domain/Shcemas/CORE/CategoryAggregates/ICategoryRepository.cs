using System.Threading.Tasks;
using QuestionSolutions.SharedKernel.SeedWork;

namespace QuestionSolutions.Main.Domain.Shcemas.CORE.CategoryAggregates
{
    public interface ICategoryRepository : IRepository<Category, long>
    {
        
    }
}