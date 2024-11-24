using Core.Utilities.Results;
using Experis.Business.Handlers.Lottery.DTOs;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Handlers.Lottery.Commands;

public class CreateLotteryCommand : IRequest<IResult>
{
    public string LotteryName { get; set; }
    public List<WineRequestDto> Wines { get; set; } = new List<WineRequestDto>();


    public class CreateLotteryCommandHandler : IRequestHandler<CreateLotteryCommand, IResult>
    {
        private readonly IMediator _mediator;

        public CreateLotteryCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<IResult> Handle(CreateLotteryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}