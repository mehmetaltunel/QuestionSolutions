using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestionSolutions.SharedKernel.SeedWork
{
    public interface IRepository<TEntity> where TEntity : class
    {

    }

    public interface IRepository<TEntity, TId> where TEntity : class where TId : struct
    {
        Task<TId> InsertAsync(TEntity input);
        Task<bool> UpdateAsync(TEntity input);
        Task<bool> DeleteAsync(long Id);
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TId id);        
    }

    public interface IRepository
    {
    
    }
}