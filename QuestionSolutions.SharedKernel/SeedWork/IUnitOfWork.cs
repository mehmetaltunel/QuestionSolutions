using System;
using System.Data;
using QuestionSolutions.SharedKernel.SeedWork.Contexes;

namespace QuestionSolutions.SharedKernel.SeedWork
{
    public interface IUnitOfWork<out T> : IDisposable where T : IDbContext
    {
        T Context { get; }
        void OpenConnection     ();
        void CloseConnection    ();
        void BeginTransaction   (IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void CommitTransaction  ();
        void RollbackTransaction();
    }
}