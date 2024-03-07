using Application.Common.Dto.Exception;
using Application.Common.Dto.Page;
using Application.Interfaces.Informations;
using Application.Interfaces.Users;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TradingOrchid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : Controller
    {
        private readonly IInformationService informationService;

        public InformationController(IInformationService informationService)
        {
            this.informationService = informationService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<User>>> GetAll(PageDto page)
        {
            var list = await informationService.GetAll(page);

            if (list == null)
            {
                throw new MyException("Không tìm thấy.", 404);
            }

            return Ok(list);
        }


        [HttpGet("Search/{search}")]
        public async Task<ActionResult<User>> Search(string search)
        {
            var list = await informationService.Search(search);
            return Ok(list);
        }


        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<User>> GetByID(int id)
        {
            var list = await informationService.GetByID(id);
            return Ok(list);
        }
    }
}
