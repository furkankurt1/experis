using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;

namespace Business.Handlers.Lottery.Queries;

public class GetAllLotteriesQuery : IRequest<IDataResult<IEnumerable<Entities.Concrete.Lottery>>>
{
    public class GetAllLotteriesIdQueryHandler : IRequestHandler<GetAllLotteriesQuery, IDataResult<IEnumerable<Entities.Concrete.Lottery>>>
    {
        private readonly IMediator _mediator;
        private readonly ILotteryRepository _ticketRepository;

        public GetAllLotteriesIdQueryHandler(IMediator mediator, ILotteryRepository ticketRepository)
        {
            _mediator = mediator;
            _ticketRepository = ticketRepository;
        }


        public async Task<IDataResult<IEnumerable<Entities.Concrete.Lottery>>> Handle(GetAllLotteriesQuery request, CancellationToken cancellationToken)
        {
            var allLotteries = await _ticketRepository.GetListAsync();
            return new SuccessDataResult<IEnumerable<Entities.Concrete.Lottery>>(allLotteries);
        }
    }
}