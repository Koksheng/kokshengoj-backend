﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kokshengoj.Contracts.User
{
    public record UserLoginRequest(string userAccount, string userPassword);
}
