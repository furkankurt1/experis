using Core.Entities;

namespace Entities.Concrete;

public class Wine : IEntity
{
    public int Id { get; set; }
    public Lottery Lottery { get; set; }
    public int LotteryId { get; set; }

    public string WineName { get; set; }
    public decimal Price { get; set; }
}