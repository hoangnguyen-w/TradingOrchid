using Application.Common.Dto.Comment;
using Application.Common.Dto.Exception;
using Application.Interfaces.Comments;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TradingOrchid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        public CommentController
            (ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Comment>>> GetAll()
        {
            var list = await commentService.GetAll();

            if (list == null)
            {
                throw new MyException("Không tìm thấy.", 404);
            }

            return Ok(list);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(CreateCommentDTO createCommentDTO)
        {
            await commentService.Create(createCommentDTO);
            throw new MyException("Thành công.", 200);
        }

    }
}
