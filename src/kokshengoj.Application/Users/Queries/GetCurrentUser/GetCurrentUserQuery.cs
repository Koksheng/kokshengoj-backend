using kokshengoj.Application.Users.Common;
using MediatR;

namespace kokshengoj.Application.Users.Queries.GetCurrentUser
{
    public record GetCurrentUserQuery(string userState) : IRequest<UserSafetyResult>;
}
