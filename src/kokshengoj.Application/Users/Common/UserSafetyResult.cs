using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kokshengoj.Application.Users.Common
{
    public record UserSafetyResult(
        int Id,
        string userName,
        string userAccount,
        string userAvatar,
        int gender,
        string userRole,
        DateTime createTime,
        DateTime updateTime,
        int isDelete,
        string token);
}
