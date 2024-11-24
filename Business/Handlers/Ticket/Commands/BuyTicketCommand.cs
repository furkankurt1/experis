using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Validation;
using DataAccess.Abstract;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Handlers.Ticket.Commands;

public class BuyTicketCommand : IRequest<IResult>
{
    public int LotteryId { get; set; }
    public int TicketId { get; set; }

    public class BuyTicketCommandHandler : IRequestHandler<BuyTicketCommand, IResult>
    {
        private readonly IMediator _mediator;
        private readonly ITicketRepository _ticketRepository;

        public BuyTicketCommandHandler(IMediator mediator, ITicketRepository ticketRepository)
        {
            _mediator = mediator;
            _ticketRepository = ticketRepository;
        }

        public async Task<IResult> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationRules.RunAsync();


            if (!validationResult.Success)
            {
                return validationResult;
            }

            var businessResult = await BusinessRules.RunAsync();

            if (!businessResult.Success)
            {
                return businessResult;
            }

            return new SuccessResult();
        }
    }
}