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
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email.Equals(email));
            }catch 
            {
                throw;
            }
        }

        public async Task Insert(User user)
        {
            try
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
