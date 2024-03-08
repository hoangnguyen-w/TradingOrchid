using Application.Common.Dto.Comment;
using Application.Common.Dto.Exception;
using Application.Common.Dto.Page;
using Application.Interfaces.Comments;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TradingOrchid.Controllers
{
    [Route("trading-orchid/[controller]")]
    [ApiController]
    [Authorize(Roles = "Customer, Staff, Manager, Orchid Owner")]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        public CommentController
            (ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<List<Comment>>> GetAll(PageDto page)
        {
            var list = await commentService.GetAll(page);

            if (list == null)
            {
                throw new MyException("Không tìm thấy.", 404);
            }

            return Ok(list);
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(CreateCommentDTO createCommentDTO)
        {
            await commentService.Create(createCommentDTO);
            throw new MyException("Thành công.", 200);
        }

    }
}
