using Application.Interfaces.RegisterAuctions;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class RegisterAuctionRepository : IRegisterAuctionRepository
    {
        private readonly TradingOrchidContext context;
        public RegisterAuctionRepository(TradingOrchidContext context)
        {
            this.context = context;
        }

        public async Task Insert(RegisterAuction registerAuction)
        {
            try
            {
                context.RegisterAuctions.Add(registerAuction);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
