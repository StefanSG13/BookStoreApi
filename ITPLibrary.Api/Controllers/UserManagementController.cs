using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Core.Services;
using ITPLibrary.Api.Core.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITPLibrary.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Register([FromBody]UserDto userDto)
        {
            if (userDto.ConfirmPassword != userDto.Password)
                return Conflict("ConfirmPassword is different from Password");
            if(_userManagementService.Get(userDto.Email)!=null)
                return Conflict("Email already exists");
            _userManagementService.Register(userDto);
            var uri = new Uri("https://myUri.com");
            return Created(uri,userDto);
        }

    }
}
