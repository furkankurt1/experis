using Core.Entities;

namespace Entities.Concrete;

public class Lottery : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Wine> Wine { get; set; }
}