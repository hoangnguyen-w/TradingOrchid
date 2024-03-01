using Application.Common.Dto.Authen;

namespace Application.Interfaces.Users
{
    public interface IUserService
    {
        Task<Token> Login(LoginDto loginDto);
        Task Register(RegisterDto registerDto);
    }
}
