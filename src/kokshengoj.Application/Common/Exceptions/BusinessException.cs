﻿using kokshengoj.Application.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kokshengoj.Application.Common.Exceptions
{
    public class BusinessException : Exception
    {
        private readonly int _code;
        private readonly string _description;

        public int Code => _code;
        public string Description => _description;

        public BusinessException(string message, int code, string description) : base(message)
        {
            _code = code;
            _description = description;
        }

        public BusinessException(ErrorCode errorCode) : base(errorCode.Message)
        {
            _code = errorCode.Code;
            _description = errorCode.Description;
        }

        public BusinessException(ErrorCode errorCode, string description) : base(errorCode.Message)
        {
            _code = errorCode.Code;
            _description = description;
        }
    }
}
