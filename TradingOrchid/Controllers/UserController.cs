using Application.Common.Dto.Authen;
using Application.Common.Dto.Exception;
using Application.Common.Dto.Page;
using Application.Interfaces.Users;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TradingOrchid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController
            (IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("GetAll")]
        public async Task<ActionResult<List<User>>> GetAll(PageDto page)
        {
            var list = await userService.GetAll(page);

            if (list == null)
            {
                throw new MyException("Không tìm thấy.", 404);
            }

            return Ok(list);
        }


        [HttpGet("Search/{search}")]
        public async Task<ActionResult<User>> Search(string search)
        {
            var list = await userService.Search(search);
            return Ok(list);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(RegisterDto registerDto)
        {
            await userService.Register(registerDto);
            throw new MyException("Thành công.", 200);
        }


        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditUser(int id)
        {
            await userService.Edit(id);
            throw new MyException("Thành công.", 200);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await userService.Delete(id);
            throw new MyException("Thành công.", 200);
        }
    }
}
