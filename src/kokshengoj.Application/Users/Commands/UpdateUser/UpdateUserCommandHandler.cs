using AutoMapper;
using kokshengoj.Application.Common.Constants;
using kokshengoj.Application.Common.Exceptions;
using kokshengoj.Application.Common.Interfaces.Persistence;
using kokshengoj.Application.Common.Interfaces.Services;
using kokshengoj.Application.Common.Models;
using kokshengoj.Application.Common.Utils;
using kokshengoj.Domain.UserAggregate;
using MediatR;

namespace kokshengoj.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler :
        IRequestHandler<UpdateUserCommand, BaseResponse<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<BaseResponse<int>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            int id = command.id;
            string userState = command.userState;

            // 1. Verify User using userId in userState
            var safetyUser = await _currentUserService.GetCurrentUserAsync(userState);

            // 2. get the to be deleted item using id
            User user = await _userRepository.GetUser(id);
            if (user == null)
            {
                throw new BusinessException(ErrorCode.NOT_FOUND_ERROR, "User not found.");
            }

            // 3. Only admin is allowed to delete
            var isAdmin = await _currentUserService.IsAdminAsync(safetyUser);
            if (!isAdmin)
            {
                throw new BusinessException(ErrorCode.NO_AUTH_ERROR, "User does not have permission to delete this user.");
            }

            // 4. Map the updated data to the existing entity
            _mapper.Map(command, user);
            user.updateTime = DateTime.Now;

            // 5. Persist the updated entity
            var result = await _userRepository.Update(user);

            if (result == 1)
            {
                return ResultUtils.success(data: user.Id.Value);
            }
            else
            {
                throw new BusinessException(ErrorCode.OPERATION_ERROR);
            }
        }
    }
}
