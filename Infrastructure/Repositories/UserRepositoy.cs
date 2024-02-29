using TradingOrchid.Model.Entity;
using Application.Interfaces.Users;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepositoy : IUserRepositoy
    {
        private readonly TradingOrchidContext context;
        public UserRepositoy(TradingOrchidContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                return await context.Users
                    .FirstOrDefaultAsync(u => u.Email.Equals(email));
            }catch (Exception ex)
            {
                throw;
            }
        }
    }
}
