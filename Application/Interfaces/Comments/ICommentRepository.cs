using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Comments
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAll();

        Task Create(Comment comment);
    }
}
