using kokshengoj.Domain.Common.Models;

namespace kokshengoj.Domain.UserAggregate.Events
{
    public record UserCreated(User User) : IDomainEvent;
}
