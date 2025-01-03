using AutoMapper;
using kokshengoj.Application.Common.Constants;
using kokshengoj.Application.Common.Exceptions;
using kokshengoj.Application.Common.Models;
using kokshengoj.Application.Common.Utils;
using kokshengoj.Application.Users.Commands.Register;
using kokshengoj.Application.Users.Commands.UpdateUser;
using kokshengoj.Application.Users.Queries.GetCurrentUser;
using kokshengoj.Application.Users.Queries.ListUserByPage;
using kokshengoj.Application.Users.Queries.Login;
using kokshengoj.Contracts.User;
using kokshengoj.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kokshengoj.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _mediator;
        //private const string USER_LOGIN_STATE = "userLoginState";
        private readonly IMapper _mapper;

        public UserController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<BaseResponse<int>> userRegister(UserRegisterRequest request)
        {
            var command = _mapper.Map<UserRegisterCommand>(request);
            return await _mediator.Send(command);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<BaseResponse<UserSafetyResponse>?> userLogin(UserLoginRequest request)
        {
            //var query = new UserLoginQuery(request.userAccount, request.userPassword);
            var query = _mapper.Map<UserLoginQuery>(request);
            var safetyUser = await _mediator.Send(query);

            // Convert user object to JSON string
            var serializedSafetyUser = JsonConvert.SerializeObject(safetyUser);

            // add user into session
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString(ApplicationConstants.USER_LOGIN_STATE)))
            {
                HttpContext.Session.SetString(ApplicationConstants.USER_LOGIN_STATE, serializedSafetyUser);
            }

            // map UserSafetyResult to UserSafetyResponse
            var response = _mapper.Map<UserSafetyResponse>(safetyUser);
            return ResultUtils.success(response);
        }

        [HttpPost]
        //[Authorize]
        public async Task<BaseResponse<int>> userLogout()
        {
            var userState = HttpContext.Session.GetString(ApplicationConstants.USER_LOGIN_STATE);
            if (string.IsNullOrWhiteSpace(userState))
            {
                throw new BusinessException(ErrorCode.PARAMS_ERROR, "session里找不到用户状态");
            }
            HttpContext.Session.Remove(ApplicationConstants.USER_LOGIN_STATE);
            //return 1;
            return ResultUtils.success(1);
        }

        [HttpGet]
        //[Authorize]
        public async Task<BaseResponse<UserSafetyResponse>?> getCurrentUser()
        {
            var userState = HttpContext.Session.GetString(ApplicationConstants.USER_LOGIN_STATE);

            var query = new GetCurrentUserQuery(userState);
            var currentSafetyUser = await _mediator.Send(query);

            // map UserSafetyResult to UserSafetyResponse
            var response = _mapper.Map<UserSafetyResponse>(currentSafetyUser);

            return ResultUtils.success(response);
        }

        [HttpPost]
        public async Task<BaseResponse<int>> updateUser(UpdateUserRequest request)
        {
            if (request == null)
            {
                throw new BusinessException(ErrorCode.PARAMS_ERROR);
            }

            var userState = HttpContext.Session.GetString(ApplicationConstants.USER_LOGIN_STATE);

            var command = _mapper.Map<UpdateUserCommand>(request);
            // Assign the userState
            command = command with { userState = userState };
            return await _mediator.Send(command);
        }

        [HttpGet("list/page")]
        public async Task<BaseResponse<PaginatedList<AdminPageUserSafetyResponse>>> listUserByPage([FromQuery] QueryUserRequest request)
        {
            if (request == null)
            {
                throw new BusinessException(ErrorCode.PARAMS_ERROR);
            }

            var query = _mapper.Map<ListUserByPageQuery>(request);
            var result = await _mediator.Send(query);

            var response = _mapper.Map<PaginatedList<AdminPageUserSafetyResponse>>(result);

            return ResultUtils.success(response);
        }
    }
}
