using QuestionSolutions.Main.Domain;
using QuestionSolutions.SharedKernel.SeedWork;
using Microsoft.Extensions.Configuration;

namespace QuestionSolutions.Main.Infrastructure
{
    public class MainUnitOfWorkFactory : IUnitOfWorkFactory<IMainDbContext>
    {
        private readonly IConfiguration _configuration;

        public MainUnitOfWorkFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public UnitOfWork<IMainDbContext> Create()
        {
            var s = _configuration.GetConnectionString("postgresql");
            return new UnitOfWork<IMainDbContext>(new MainDbContext(s, _configuration.GetValue<int>("ErpDBCommandTimeout")));
        }

        public UnitOfWork<IMainDbContext> Create(bool openConnection, bool startTransaction)
        {
            var unitOfWork = Create();

            if (openConnection)
            {
                unitOfWork.OpenConnection();
            }

            if (startTransaction)
            {
                unitOfWork.BeginTransaction();
            }

            return unitOfWork;
        }
    }

}