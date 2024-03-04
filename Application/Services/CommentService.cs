using Application.Common.Dto.Authen;
using Application.Common.Dto.Comment;
using Application.Common.Dto.Exception;
using Application.Common.Dto.User;
using Application.Interfaces.Comments;
using Application.Interfaces.Users;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;
        public CommentService
            (ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }


        public async Task Create(CreateCommentDTO createCommentDTO)
        {
            try
            {
                var cmt = mapper.Map<CreateCommentDTO, Comment>(createCommentDTO,
                opt => opt.AfterMap((src, des) =>
                {
                    des.CommentMsg = src.CommentMsg;
                    des.UserID = src.UserID;
                    //des.CreateDate = DateTime.Now;
                    //des.IsCheckBool = true;
                    des.InformationID = src.InformationID;
                }));

                await commentRepository.Create(cmt);
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }

            public async Task<List<ViewCommentDTO>> GetAll()
        {
            try
            {
                var cmt = mapper.Map<List<ViewCommentDTO>>(await commentRepository.GetAll()); 
                return cmt;

            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }
    }
}
