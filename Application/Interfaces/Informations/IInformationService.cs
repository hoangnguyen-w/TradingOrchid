using Application.Common.Dto.Information;
using Application.Common.Dto.Page;
using Domain.Entities;

namespace Application.Interfaces.Informations
{
    public interface IInformationService
    {
        Task<List<InformationViewDTO>> GetAll(PageDto page);

        Task<List<InformationViewDTO>> GetByID(int id);

        Task<List<InformationViewDTO>> Search(string search);

    }
}
