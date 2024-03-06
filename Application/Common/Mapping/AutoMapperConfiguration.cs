using Application.Common.Dto.Auction;
using Application.Common.Dto.Authen;
using AutoMapper;
using Domain.Entities;
using System.Globalization;

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

            CreateMap<CreateAuctionDto, Aution>()
                .ForMember(des => des.BidID, obj => obj.Ignore())
                .ForMember(des => des.AutionTitle, obj => obj.MapFrom(src => src.Title))
                .ForMember(des => des.AutionDescription, obj => obj.MapFrom(src => src.Description))
                .ForMember(des => des.Status, obj => obj.MapFrom(src => 1))
                .ForMember(des => des.StartingBid, obj => obj.MapFrom(src =>
                DateTime.ParseExact(src.StartingBid, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(des => des.DateOpened, obj => obj.MapFrom(src => 
                DateTime.ParseExact(src.DateOpen, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(des => des.DateClosed, obj => obj.MapFrom(src =>
                DateTime.ParseExact(src.DateClose, "dd/MM/yyyy", CultureInfo.InvariantCulture)));

            CreateMap<CreateAuctionDto, Information>()
                .ForMember(des => des.Image, obj => obj.MapFrom(src => src.Image))
                .ForMember(des => des.InformationCreateDate, obj => obj.MapFrom(src => DateTime.Now))
                .ForMember(des => des.Status, obj => obj.MapFrom(src => 1));

            CreateMap<Information, ListAuctionDto>()
                .ForMember(des => des.AutionTitle, obj => obj.MapFrom(src => src.Aution!.AutionTitle))
                .ForMember(des => des.AutionDescription, obj => obj.MapFrom(src => src.Aution!.AutionDescription))
                .ForMember(des => des.DateOpened, obj => obj.MapFrom(src => src.Aution!.DateOpened.ToString()))
                .ForMember(des => des.DateClosed, obj => obj.MapFrom(src => src.Aution!.DateClosed.ToString()))
                .ForMember(des => des.StartingBid, obj => obj.MapFrom(src => src.Aution!.StartingBid))
                .ForMember(des => des.MaxBid, obj => obj.MapFrom(src => src.Aution!.MaxBid))
                .ForMember(des => des.Image, obj => obj.MapFrom(src => src.Image))
                .ForMember(des => des.Email, obj => obj.MapFrom(src => src.User.Email));
        }
    }
}
