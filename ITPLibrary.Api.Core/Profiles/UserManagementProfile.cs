using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ITPLibrary.Api.Core.Profiles
{
    public class UserManagementProfile : Profile
    {
        public UserManagementProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
