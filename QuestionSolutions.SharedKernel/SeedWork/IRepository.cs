namespace QuestionSolutions.SharedKernel.SeedWork
{
    public interface IRepository<TEntity> where TEntity : class
    {

    }

    public interface IRepository<TEntity, TId> where TEntity : class where TId : struct
    {

    }

    public interface IRepository
    {

    }
}