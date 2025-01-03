using kokshengoj.Application.Common.Constants;
using kokshengoj.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kokshengoj.Application.Common.Utils
{
    public class ResultUtils
    {
        public static BaseResponse<T> success<T>(T data)
        {
            return new BaseResponse<T>(0, data, "ok");
        }
        public static BaseResponse<T> error<T>(ErrorCode errorCode, string message)
        {
            return new BaseResponse<T>(errorCode.Code, default(T), message, errorCode.Description);
        }
        public static BaseResponse<T> error<T>(int code, T data, string message, string description)
        {
            return new BaseResponse<T>(code, default(T), message, description);
        }
    }
}
