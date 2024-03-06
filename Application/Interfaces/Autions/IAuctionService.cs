using Application.Common.Dto.Auction;
using Application.Common.Dto.Page;

namespace Application.Interfaces.Autions
{
    public interface IAuctionService
    {
        Task<List<ListAuctionDto>> GetListAuction(PageDto page);
        Task RegisterAuction(CreateAuctionDto createAuctionDto);
    }
}
