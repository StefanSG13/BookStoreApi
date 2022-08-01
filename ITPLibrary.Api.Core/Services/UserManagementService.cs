using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Data;
using ITPLibrary.Api.Data.Models;
using ITPLibrary.Api.Data.Repositories.IRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Services
{
    public class UserManagementService : IServices.IUserManagementService
    {
        private readonly IUserManagementRepository _userManagement;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserManagementService(IUserManagementRepository userManagement,
            IMapper mapper, IConfiguration configuration)
        {
            _userManagement = userManagement;
            _mapper = mapper;
            _configuration = configuration;
        }

        public void Register(UserDto userDto)
        {
            _userManagement.Register(_mapper.Map<User>(userDto));
        }

        public UserDto Get(string email)
        {
            return _mapper.Map<UserDto>(_userManagement.GetFirstOrDefault(email));
        }

        public AuthResponseDto GetToken(AuthRequestDto authRequestDto)
        {
            var user = _userManagement.GetFirstOrDefault(authRequestDto.Email);
            if (user == null)
                return null;
            if (user.Password != authRequestDto.Passwrod)
            {
                return null;
            }

            var jwtKey = _configuration.GetSection("JwtSettings").GetSection("Key").Value;
            var keyBytes = Encoding.ASCII.GetBytes(jwtKey);


            var tokenHandler = new JwtSecurityTokenHandler();

            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Email)
                }),
                Expires = DateTime.UtcNow.AddSeconds(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes),SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(descriptor);
            AuthResponseDto responseDto = new AuthResponseDto();
            responseDto.Token = tokenHandler.WriteToken(token);
            return responseDto;
        }

        public void RecoverPassword(UserDto user)
        {
            EmailSender.SendEmailAsync(user.Email, "Password from book store.", "this is ur password: "+user.Password);
        }
    }
}
