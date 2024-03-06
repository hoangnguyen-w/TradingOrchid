using Application.Common.Dto.Page;
using Domain.Entities;

namespace Application.Interfaces.Informations
{
    public interface IInformationRepository
    {
        Task<List<Information>> GetList(PageDto page);
        Task<Information> Detail(int id);
        Task Insert(Information information);
    }
}
