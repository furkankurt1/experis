using Business.Handlers.Lottery.DTOs;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Handlers.Lottery.Commands
{
    public class CreateLotteryCommand : IRequest<IResult>
    {
        public string LotteryName { get; set; }
        public List<WineRequestDto> Wines { get; set; } = new List<WineRequestDto>();

        public class CreateLotteryCommandHandler : IRequestHandler<CreateLotteryCommand, IResult>
        {
            private readonly IMediator _mediator;
            private readonly ILotteryRepository _lotteryRepository;

            public CreateLotteryCommandHandler(IMediator mediator, ILotteryRepository lotteryRepository)
            {
                _mediator = mediator;
                _lotteryRepository = lotteryRepository;
            }

            // We normally should use AOP in here for checking cross-cutting concerns such as validation, authorization, logging, etc.
            public async Task<IResult> Handle(CreateLotteryCommand request, CancellationToken cancellationToken)
            {
                var validationResult = await ValidationRules.RunAsync(ValidateWineNamesAndPrices(request.Wines), ValidateTotalWinePrice(request.Wines),
                    ValidateLotteryName(request.LotteryName), ValidateWines(request.Wines)
                );

                if (!validationResult.Success)
                {
                    return validationResult;
                }

                var businessResult = await BusinessRules.RunAsync(CheckIfLotteryNameExists(request.LotteryName));

                if (!businessResult.Success)
                {
                    return businessResult;
                }

                var lottery = new Entities.Concrete.Lottery
                {
                    Name = request.LotteryName,
                    Wine = request.Wines.Select(w => new Wine
                    {
                        WineName = w.Name,
                        Price = w.Price
                    }).ToList()
                };

                _lotteryRepository.Add(lottery);
                await _lotteryRepository.SaveChangesAsync();

                return new SuccessResult("Lottery created successfully.");
            }


            #region Business Rules

            private async Task<IResult> CheckIfLotteryNameExists(string requestLotteryName)
            {
                var result = await _lotteryRepository.GetAsync(x => x.Name == requestLotteryName);
                if (result == null)
                {
                    return new SuccessResult();
                }

                return new ErrorResult(Messages.LotteryIsAlreadyExists);
            }

            #endregion


            #region Validation

            private Task<IResult> ValidateTotalWinePrice(List<WineRequestDto> wines)
            {
                var totalPrice = wines.Sum(wine => wine.Price);

                if (totalPrice > 1000)
                {
                    return Task.FromResult<IResult>(new ErrorResult(Messages.TotalWinePriceExceedsLimit));
                }

                return Task.FromResult<IResult>(new SuccessResult());
            }

            private Task<IResult> ValidateLotteryName(string lotteryName)
            {
                if (string.IsNullOrWhiteSpace(lotteryName) || lotteryName.Length < 5 || lotteryName.Length > 100)
                {
                    return Task.FromResult<IResult>(new ErrorResult(Messages.LotteryNameInvalid));
                }

                return Task.FromResult<IResult>(new SuccessResult());
            }

            private Task<IResult> ValidateWines(List<WineRequestDto> wines)
            {
                foreach (var wine in wines)
                {
                    if (string.IsNullOrWhiteSpace(wine.Name) || wine.Name.Length < 5 || wine.Name.Length > 100)
                    {
                        return Task.FromResult<IResult>(new ErrorResult(Messages.WineNameInvalid));
                    }

                    if (wine.Price < 1 || wine.Price > 1000)
                    {
                        return Task.FromResult<IResult>(new ErrorResult(Messages.WinePriceInvalid));
                    }
                }

                return Task.FromResult<IResult>(new SuccessResult());
            }

            private Task<IResult> ValidateWineNamesAndPrices(List<WineRequestDto> wines)
            {
                // Eğer yalnızca bir şarap varsa, kontrolü atla
                if (wines.Count == 1)
                {
                    return Task.FromResult<IResult>(new SuccessResult());
                }

                // Check for duplicate names
                var duplicateNames = wines.GroupBy(w => w.Name)
                    .Where(group => group.Count() > 1)
                    .Select(group => group.Key)
                    .ToList();

                if (duplicateNames.Any())
                {
                    return Task.FromResult<IResult>(new ErrorResult(Messages.WineNamesMustBeUnique));
                }

                var maxPrice = wines.Max(w => w.Price);
                if (wines.Count(w => w.Price == maxPrice) == wines.Count)
                {
                    return Task.FromResult<IResult>(new ErrorResult(Messages.AtLeastOneWineMustHaveHigherPrice));
                }

                return Task.FromResult<IResult>(new SuccessResult());
            }


            #endregion
        }
    }
}