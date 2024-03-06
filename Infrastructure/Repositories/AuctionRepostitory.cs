using Application.Common.Dto.Exception;
using Application.Interfaces.Auctions;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class AuctionRepostitory : IAuctionRepository
    {
        private readonly TradingOrchidContext context;
        public AuctionRepostitory(TradingOrchidContext context)
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

        public async Task RegisterBid(float bid, int auctionId, int userId)
        {
            try
            {
                var auction = context.Autions
                    .FirstOrDefault(a => a.AutionID == auctionId);

                if (auction is not null)
                {
                    var registerAuc = new RegisterAuction()
                    {
                        BidID = auction!.AutionID,
                        Price = auction.StartingBid,
                        Deposit = bid,
                        UserID = userId
                    };

                    auction.StartingBid = bid;
                    context.Add(registerAuc);
                    context.Update(auction);
                    await context.SaveChangesAsync();
                }
                else
                {
                    throw new MyException("Đơn đấu giá không tồn tại.", 404);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
