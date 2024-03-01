using Domain.Entities;

namespace Application.Interfaces.Users
{
    public interface IUserRepositoy
    {
        Task<User> GetUserByEmail(string email);
        Task Create(User user);
    }
}
