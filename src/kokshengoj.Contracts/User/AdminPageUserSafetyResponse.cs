using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kokshengoj.Contracts.User
{
    public record AdminPageUserSafetyResponse(
        int Id,
        string userName,
        string userAccount,
        string userAvatar,
        int gender,
        string userRole,
        int isDelete,
        DateTime createTime,
        DateTime updateTime,
        string token);
}
