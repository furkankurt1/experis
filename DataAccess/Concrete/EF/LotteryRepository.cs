
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EF;

public class LotteryRepository: EfEntityRepositoryBase<Lottery, ProjectDbContext>, ILotteryRepository
{
    public LotteryRepository(ProjectDbContext context) : base(context)
    {
    }
}