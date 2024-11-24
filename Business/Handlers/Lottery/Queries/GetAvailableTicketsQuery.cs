using Core.Utilities.Results;
using Experis.Business.Handlers.Lottery.DTOs;
using MediatR;

namespace Experis.Business.Handlers.Lottery.Queries;

public class GetAvailableTicketsQuery : IRequest<IDataResult<GetAvaiableTicketsResponseDto>>
{
    public int LotteryId { get; set; }

    public class GetAvailableTicketsQueryHandler : IRequestHandler<GetAvailableTicketsQuery, IDataResult<GetAvaiableTicketsResponseDto>>
    {
        public Task<IDataResult<GetAvaiableTicketsResponseDto>> Handle(GetAvailableTicketsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}