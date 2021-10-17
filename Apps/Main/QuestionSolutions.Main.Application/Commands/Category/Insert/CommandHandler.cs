using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using QuestionSolutions.Main.Domain;
using QuestionSolutions.SharedKernel.MediatR.Command;
using QuestionSolutions.SharedKernel.MediatR.Models;
using QuestionSolutions.SharedKernel.SeedWork;

namespace QuestionSolutions.Main.Application.Commands.Category.Insert
{
    public class CommandHandler : CommandHandlerBase<Command>
    {
        private readonly IUnitOfWorkFactory<IMainDbContext> _unitOfWorkFactory;
        //private readonly UserContextAccessor _userContextAccessor;
        private readonly IMapper _mapper;
        public CommandHandler(IUnitOfWorkFactory<IMainDbContext> unitOfWorkFactory, IMapper mapper/*, UserContextAccessor accessor*/)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _mapper = mapper;
            // _userContextAccessor = userContextAccessor;
        }

        protected override async Task<Result> HandleAsync(Command request, CancellationToken cancellationToken)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(true, true))
            {
                var insert = await unitOfWork.Context.CORE.Category.InsertAsync(_mapper.Map<Domain.Shcemas.CORE.CategoryAggregates.Category>(request));
                unitOfWork.CommitTransaction();
                unitOfWork.CloseConnection();
                return  Result<long>.WithSuccess(insert);
            }
        }
    }
}