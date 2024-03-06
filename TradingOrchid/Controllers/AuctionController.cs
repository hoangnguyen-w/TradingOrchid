using Application.Common.Dto.Auction;
using Application.Common.Dto.Exception;
using Application.Common.Dto.Page;
using Application.Interfaces.Autions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TradingOrchid.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAuctionService auctionService;
        public AuctionController
            (IConfiguration configuration, IAuctionService auctionService)
        {
            _configuration = configuration;
            this.auctionService = auctionService;
        }

        [HttpPost("list-auction")]
        public async Task<IActionResult> RegisterAuction([FromBody] PageDto page)
        {
            var list = await auctionService.GetListAuction(page);
            return Ok(list);
        }

        //[Authorize(Roles = "Staff")]
        [HttpPost("create-auction")]
        public async Task<IActionResult> RegisterAuction([FromBody] CreateAuctionDto requset)
        {
            await auctionService.RegisterAuction(requset);
            throw new MyException("Thành công.", 200);
        }
    }
}
