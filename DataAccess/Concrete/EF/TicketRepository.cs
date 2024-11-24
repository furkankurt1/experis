using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EF;

public class TicketRepository: EfEntityRepositoryBase<Ticket, ProjectDbContext>, ITicketRepository
{
    public TicketRepository(ProjectDbContext context) : base(context) { }
}