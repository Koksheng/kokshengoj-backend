﻿using AutoMapper;
using kokshengoj.Application.Common.Constants;
using kokshengoj.Application.Common.Exceptions;
using kokshengoj.Application.Common.Interfaces.Persistence;
using kokshengoj.Application.Common.Interfaces.Services;
using kokshengoj.Application.Users.Common;
using MediatR;

namespace kokshengoj.Application.Users.Queries.GetCurrentUser
{
    public class GetCurrentUserQueryHandler :
        IRequestHandler<GetCurrentUserQuery, UserSafetyResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetCurrentUserQueryHandler(IUserRepository userRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<UserSafetyResult> Handle(GetCurrentUserQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new BusinessException(ErrorCode.PARAMS_ERROR);
            }
            string userState = query.userState;
            //// 1. get user by id
            ////var loggedInUser = JsonConvert.DeserializeObject<User>(userState);
            //var loggedInUser = JsonConvert.DeserializeObject<UserSafetyResult>(userState);
            //var user = await _userRepository.GetUser(loggedInUser.Id);

            //if (user == null || user.isDelete)
            //{
            //    //return null;
            //    throw new BusinessException(ErrorCode.NULL_ERROR, "找不到该用户");
            //}
            //// 3. 用户脱敏 desensitization
            //UserSafetyResult safetyUser = _mapper.Map<UserSafetyResult>(user);
            ////UserSafetyResponse safetyUser = await GetSafetyUser(user);
            ////var safetyUser = await _userRepository.GetSafetyUser(user);
            ////safetyUser.IsAdmin = await verifyIsAdminRoleAsync();
            ////return safetyUser;

            if (userState == null)
                return null;

            var safetyUser = await _currentUserService.GetCurrentUserAsync(userState);

            return safetyUser;
        }
    }
}
