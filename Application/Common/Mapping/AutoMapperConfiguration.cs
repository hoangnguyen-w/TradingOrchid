using Application.Common.Dto.Authen;
using Application.Common.Dto.Comment;
using Application.Common.Dto.User;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapping
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            //Login
            CreateMap<User, Token>()
                .ForMember(des => des.UserName, obj => obj.MapFrom(src => src.UserName))
                .ForMember(des => des.Role, obj => obj.MapFrom(src => src.Role.RoleName));
            CreateMap<RegisterDto, User>()
                .ForMember(des => des.PasswordHash, obj => obj.Ignore())
                .ForMember(des => des.PasswordSalt, obj => obj.Ignore())
                .ForMember(des => des.Status, obj => obj.MapFrom(src => true))
                .ForMember(des => des.RoleID, obj => obj.MapFrom(src => 1))
                .ForMember(des => des.WalletBalance, obj => obj.MapFrom(src => 0));

            CreateMap<User, ViewInformationUserDTO> ()
                .ForMember(des => des.UserName, obj => obj.MapFrom(src => src.UserName))
                .ForMember(des => des.Email, obj => obj.MapFrom(src => src.Email))
                .ForMember(des => des.WalletBalance, obj => obj.MapFrom(src => src.WalletBalance))
                .ForMember(des => des.Phone, obj => obj.MapFrom(src => src.Phone))
                .ForMember(des => des.RoleName , obj => obj.MapFrom(src => src.Role.RoleName));

            CreateMap<Comment, CreateCommentDTO>()
                .ForMember(des => des.CommentMsg, obj => obj.MapFrom(src => src.CommentMsg))
                .ForMember(des => des.UserID, obj => obj.MapFrom(src => src.User.UserName));

            CreateMap<CreateCommentDTO, Comment>()
                .ForMember(des => des.CommentMsg, obj => obj.MapFrom(src => src.CommentMsg))
                .ForMember(des => des.UserID, obj => obj.MapFrom(src => src.UserID))
                .ForMember(des => des.InformationID, obj => obj.MapFrom(src => src.InformationID))
                .ForMember(des => des.IsCheckBool, obj => obj.MapFrom(src => true))
                .ForMember(des => des.CreateDate, obj => obj.MapFrom(src => DateTime.Now));

        }
    }
}
