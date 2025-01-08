using kokshengoj.Domain.Common.Models;

namespace kokshengoj.Domain.QuestionAggregate.Events
{
    public record QuestionCreated(Question Question) : IDomainEvent;
}
