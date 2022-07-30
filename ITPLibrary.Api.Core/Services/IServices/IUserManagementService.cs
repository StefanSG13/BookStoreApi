using ITPLibrary.Api.Core.Dtos;

namespace ITPLibrary.Api.Core.Services.IServices
{
    public interface IUserManagementService
    {
        void Register(UserDto userDto);
        public UserDto Get(string email);
    }
}