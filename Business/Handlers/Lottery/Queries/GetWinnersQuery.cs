using Core.Utilities.Results;
using Experis.Business.Handlers.Lottery.DTOs;
using MediatR;

namespace Experis.Business.Handlers.Lottery.Queries;

public class GetWinnersQuery : IRequest<IDataResult<GetWinnersResponseDto>>
{
    public int LotteryId { get; set; }

    public class GetWinnersQueryHandler : IRequestHandler<GetWinnersQuery, IDataResult<GetWinnersResponseDto>>
    {
        public Task<IDataResult<GetWinnersResponseDto>> Handle(GetWinnersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}