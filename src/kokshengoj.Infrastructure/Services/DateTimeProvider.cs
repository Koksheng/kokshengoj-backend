using kokshengoj.Application.Common.Interfaces.Services;

namespace kokshengoj.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
