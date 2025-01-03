using kokshengoj.Application.Users.Common;
using MediatR;

namespace kokshengoj.Application.Users.Queries.Login
{
    public record UserLoginQuery(string userAccount, string userPassword) : IRequest<UserSafetyResult?>;
}
