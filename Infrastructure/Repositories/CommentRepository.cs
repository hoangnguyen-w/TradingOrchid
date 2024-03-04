using Application.Common.Dto.Comment;
using Application.Interfaces.Comments;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly TradingOrchidContext context;
        public CommentRepository(TradingOrchidContext context)
        {
            this.context = context;
        }

        public async Task Create(Comment comment)
        {
            try
            {
                context.Comments.Add(comment);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Comment>> GetAll()
        {
            try
            {
                return await context.Comments
                    .Include(c => c.User)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
