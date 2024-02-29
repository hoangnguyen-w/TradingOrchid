using Application.Common.Dto;
using Domain.Entities;

namespace Application.Interfaces.Users
{
    public interface IUserService
    {
        Task<User> login(LoginDto loginDto);
    }
}
