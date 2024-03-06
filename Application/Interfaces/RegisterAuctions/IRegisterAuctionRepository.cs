using Domain.Entities;

namespace Application.Interfaces.RegisterAuctions
{
    public interface IRegisterAuctionRepository
    {
        Task Insert(RegisterAuction registerAuction);
    }
}
