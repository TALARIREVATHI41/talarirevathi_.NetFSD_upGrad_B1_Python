using ElearningPlatform.DTOs;

namespace ElearningPlatform.Services
{
    public interface IUserService
    {
        Task<UserDto> Register(UserDto dto);
        Task<UserDto> GetById(int id);
        Task<bool> Update(int id, UserDto dto);
    }
}