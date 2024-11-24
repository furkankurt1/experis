using Business.Handlers.Lottery.DTOs;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;

namespace Business.Handlers.Ticket.Queires;

public class GetAvailableTicketsQuery : IRequest<IDataResult<GetAvaiableTicketsResponseDto>>
{
    public class GetAvailableTicketsQueryHandler : IRequestHandler<GetAvailableTicketsQuery, IDataResult<GetAvaiableTicketsResponseDto>>
    {
        private readonly IMediator _mediator;
        private readonly ITicketRepository _ticketRepository;

        public GetAvailableTicketsQueryHandler(ITicketRepository ticketRepository, IMediator mediator)
        {
            _ticketRepository = ticketRepository;
            _mediator = mediator;
        }


        public async Task<IDataResult<GetAvaiableTicketsResponseDto>> Handle(GetAvailableTicketsQuery request, CancellationToken cancellationToken)
        {
            var allLotteries = await _ticketRepository.GetListAsync();

            return new SuccessDataResult<GetAvaiableTicketsResponseDto>();
        }
    }
}