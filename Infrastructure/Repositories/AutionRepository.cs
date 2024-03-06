using Application.Interfaces.Autions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AutionRepository : IAuctionRepository
    {
        private readonly TradingOrchidContext context;
        public AutionRepository(TradingOrchidContext context)
        {
            this.context = context;
        }

        public async Task<int> Insert(Aution aution)
        {
            try
            {
                context.Add(aution);
                await context.SaveChangesAsync();
                return context.Autions
                    .OrderByDescending(x => x.AutionID)
                    .Select(x => x.AutionID).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
    }
}
