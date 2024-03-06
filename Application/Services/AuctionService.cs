using Application.Common.Dto.Auction;
using Application.Common.Dto.Page;
using Application.Interfaces.Autions;
using Application.Interfaces.Informations;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository auctionRepository;
        private readonly IInformationRepository informationRepository;
        private readonly IMapper mapper;

        public AuctionService
            (IAuctionRepository auctionRepository, IMapper mapper,
            IInformationRepository informationRepository)
        {
            this.auctionRepository = auctionRepository;
            this.informationRepository = informationRepository;
            this.mapper = mapper;
        }

        public async Task<List<ListAuctionDto>> GetListAuction(PageDto page)
        {
            try
            {
                return mapper.Map<List<ListAuctionDto>>
                    (await informationRepository.GetList(page));
            }
            catch
            {
                throw;
            }
        }

        /*public async Task<> DetailAuction(int id)
        {
            try
            {
                return mapper.Map<>
            }
            catch
            {
                throw;
            }
        }*/

        public async Task RegisterAuction(CreateAuctionDto createAuctionDto)
        {
            try
            {
                var auction = mapper.Map<Aution>(createAuctionDto);
                var auctionId = await auctionRepository.Insert(auction);
                var information = mapper.Map<Information>(createAuctionDto);
                information.AutionID = auctionId;
                await informationRepository.Insert(information);
            }
            catch
            {
                throw;
            }
        }
    }
}
