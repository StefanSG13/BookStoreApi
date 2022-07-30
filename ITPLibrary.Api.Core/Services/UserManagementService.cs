using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Data.Models;
using ITPLibrary.Api.Data.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Services
{
    public class UserManagementService : IServices.IUserManagementService
    {
        private readonly IUserManagementRepository _userManagement;
        private readonly IMapper _mapper;

        public UserManagementService(IUserManagementRepository userManagement,
            IMapper mapper)
        {
            _userManagement = userManagement;
            _mapper = mapper;
        }

        public void Register(UserDto userDto)
        {
            _userManagement.Register(_mapper.Map<User>(userDto));
        }
    }
}
