using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using QuestionSolutions.Main.Domain;
using QuestionSolutions.SharedKernel.Accessors;
using QuestionSolutions.SharedKernel.MediatR.Models;
using QuestionSolutions.SharedKernel.MediatR.Query;
using QuestionSolutions.SharedKernel.SeedWork;

namespace QuestionSolutions.Main.Application.Queries.Category.GetById
{
    public class QueryHandler : QueryHandlerBase<Query,CategoryGetByIdDto>
    {
        private readonly IUnitOfWorkFactory<IMainDbContext> _unitOfWorkFactory;
        //private readonly UserContextAccessor _userContextAccessor;
        private readonly IMapper _mapper;
        public QueryHandler(IUnitOfWorkFactory<IMainDbContext> unitOfWorkFactory, IMapper mapper/*, UserContextAccessor accessor*/)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _mapper = mapper;
            // _userContextAccessor = userContextAccessor;
        }

        protected override async Task<Result<CategoryGetByIdDto>> HandleAsync(Query request,
            CancellationToken cancellationToken)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(true, false))
            {
                var res = await unitOfWork.Context.Main.Category.GetByIdAsync(request.Id);
                unitOfWork.CloseConnection();
                return Result<CategoryGetByIdDto>.WithSuccess(_mapper.Map<CategoryGetByIdDto>(res));
            }
        }
    }
}