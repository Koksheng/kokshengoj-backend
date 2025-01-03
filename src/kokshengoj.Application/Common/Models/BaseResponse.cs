using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kokshengoj.Application.Common.Models
{
    public record BaseResponse<T>(int code, T data, string message = "", string description = "")
    {

    };
}
