﻿using AutoMapper;
using kokshengoj.Application.Common.Constants;
using kokshengoj.Application.Common.Exceptions;
using kokshengoj.Application.Common.Interfaces.Persistence;
using kokshengoj.Application.Common.Models;
using kokshengoj.Application.Common.Utils;
using kokshengoj.Application.Services.Common;
using kokshengoj.Domain.UserAggregate;
using MediatR;

namespace kokshengoj.Application.Users.Commands.Register
{
    public class UserRegisterCommandHandler :
        IRequestHandler<UserRegisterCommand, BaseResponse<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserRegisterCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<int>> Handle(UserRegisterCommand command, CancellationToken cancellationToken)
        {
            string userAccount = command.userAccount;
            string userPassword = command.userPassword;
            string checkPassword = command.checkPassword;
            // 1. Verify in UserRegisterCommandValidator, so here dont need to verify again

            // userAccount cant existed
            var user = await _userRepository.GetUserByUserAccount(userAccount);
            if (user != null)
            {
                if (user.isDelete == false)
                    throw new BusinessException(ErrorCode.EXISTED_ERROR, "用户账户已有注册记录");
            }

            // 2. 加密 (.net core IdentityUser will encrypt themself
            string hashedPassword = EncryptionService.EncryptPassword(userPassword);
            //string hashedAccessKey = EncryptionService.EncryptAccessKey(userAccount);
            //string hashedSecretKey = EncryptionService.EncryptSecretKey(userAccount);

            // 3. Insert User to DB

            User newUser = _mapper.Map<User>(command);
            newUser.userName = "new_userName";
            newUser.userAvatar = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRpy6bicoFta2pSa5I3U1mKbUQPEB7Hxobc0oVEKp2YZknVoJlq0CjgtrbxEFSM4O6F8Dg&usqp=CAU";
            newUser.gender = 1;
            newUser.userRole = "user"; // default 'user', or 'admin'
            newUser.userPassword = hashedPassword;
            //newUser.accessKey = hashedAccessKey;
            //newUser.secretKey = hashedSecretKey;
            newUser.createTime = DateTime.Now;
            newUser.isDelete = false;

            int result = await _userRepository.CreateUser(newUser);

            if (result == 0)
                throw new BusinessException(ErrorCode.SYSTEM_ERROR, "注册失败，数据库错误");

            return ResultUtils.success(newUser.Id.Value);
        }
    }
}
