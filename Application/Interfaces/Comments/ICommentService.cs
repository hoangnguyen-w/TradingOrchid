using Application.Common.Dto.Comment;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Comments
{
    public interface ICommentService
    {
        Task<List<CreateCommentDTO>> GetAll();

        Task Create(CreateCommentDTO createCommentDTO);
    }
}
