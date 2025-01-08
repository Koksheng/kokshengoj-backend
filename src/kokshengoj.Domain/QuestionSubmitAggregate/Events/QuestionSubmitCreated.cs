using kokshengoj.Domain.Common.Models;

namespace kokshengoj.Domain.QuestionSubmitAggregate.Events
{
    public record QuestionSubmitCreated(QuestionSubmit QuestionSubmit) : IDomainEvent;
}
