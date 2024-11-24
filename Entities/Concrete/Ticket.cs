using Core.Entities;

namespace Entities.Concrete;

public class Ticket : IEntity
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public int BoughtTicket { get; set; }
}