namespace FourthPharos.Domain.Models;

public interface IOwned
{
    Guid OwnerId { get; }
}
