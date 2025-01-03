using kokshengoj.Application.Common.Models;
using MediatR;

namespace kokshengoj.Application.Users.Commands.Register
{
    public record UserRegisterCommand(string userAccount, string userPassword, string checkPassword) : IRequest<BaseResponse<int>>;
}
