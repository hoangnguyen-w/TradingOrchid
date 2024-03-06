using Domain.Entities;

namespace Application.Interfaces.Autions
{
    public interface IAuctionRepository
    {
        Task<int> Insert(Aution aution);
    }
}
