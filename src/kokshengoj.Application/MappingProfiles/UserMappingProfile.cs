using AutoMapper;
using kokshengoj.Application.Common.Models;
using kokshengoj.Application.MappingProfiles.Common;
using kokshengoj.Domain.UserAggregate.ValueObjects;
using kokshengoj.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kokshengoj.Contracts.User;
using kokshengoj.Application.Users.Commands.Register;
using kokshengoj.Application.Users.Queries.Login;
using kokshengoj.Application.Users.Common;
using kokshengoj.Application.Users.Queries.ListUserByPage;
using kokshengoj.Application.Users.Commands.UpdateUser;

namespace kokshengoj.Application.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            // !!!!!!!!!!!!!! Type conversion configuration for UserId to int !!!!!!!!!!!!!!
            CreateMap<UserId, int>().ConvertUsing(src => src.Value);

            // UserController
            CreateMap<UserRegisterRequest, UserRegisterCommand>();
            CreateMap<UserLoginRequest, UserLoginQuery>();

            //UserRegisterCommandHandler
            CreateMap<UserRegisterCommand, User>();
            CreateMap<User, UserSafetyResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))  // Mapping UserId.Value to Id
                .ForCtorParam("token", opt => opt.MapFrom(src => string.Empty));
            CreateMap<UserSafetyResult, UserSafetyResponse>();

            // List User By Page
            CreateMap<QueryUserRequest, ListUserByPageQuery>()
               .ForMember(dest => dest.Current, opt => opt.MapFrom(src => src.current))
               .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.pageSize))
               .ForMember(dest => dest.SortField, opt => opt.MapFrom(src => src.sortField))
               .ForMember(dest => dest.SortOrder, opt => opt.MapFrom(src => src.sortOrder));
            CreateMap<ListUserByPageQuery, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id > 0 ? UserId.Create(src.Id) : null)); // Adjust based on how UserId is created
            CreateMap<UserSafetyResult, AdminPageUserSafetyResponse>();

            // Update
            CreateMap<UpdateUserRequest, UpdateUserCommand>()
                .ForCtorParam("userState", opt => opt.MapFrom(src => string.Empty));
            CreateMap<UpdateUserCommand, User>();

            // Mapping for PaginatedList<UserSafetyResult> to PaginatedList<UserSafetyResponse>
            CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>)).ConvertUsing(typeof(PaginatedListTypeConverter<,>));

            //// Get User Access Key & Secret Key
            //CreateMap<UserSafetyResult, UserDevKeyResponse>();

        }
    }
}
