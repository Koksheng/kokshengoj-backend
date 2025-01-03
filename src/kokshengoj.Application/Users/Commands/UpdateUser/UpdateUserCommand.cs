using kokshengoj.Application.Common.Models;
using MediatR;

namespace kokshengoj.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(
        int id,
        string userName,
        //string userAccount,
        string userAvatar,
        int gender,
        string userRole,
        int isDelete,
        string userState
        ) : IRequest<BaseResponse<int>>;
}
