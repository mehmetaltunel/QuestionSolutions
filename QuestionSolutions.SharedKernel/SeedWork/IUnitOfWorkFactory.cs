using QuestionSolutions.SharedKernel.SeedWork.Contexes;

namespace QuestionSolutions.SharedKernel.SeedWork
{
    public interface IUnitOfWorkFactory<T> where T : class, IDbContext
    {
        UnitOfWork<T> Create();
        
        UnitOfWork<T> Create(bool openConnection, bool startTransaction);
    }
}