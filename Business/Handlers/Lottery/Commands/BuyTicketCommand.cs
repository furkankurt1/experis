using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Handlers.Lottery.Commands;

public class BuyTicketCommand : IRequest<IResult>
{
    public int LotteryId { get; set; }
    public int TicketId { get; set; }

    public class BuyTicketCommandHandler : IRequestHandler<BuyTicketCommand, IResult>
    {
        private readonly IMediator _mediator;

        public BuyTicketCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<IResult> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}