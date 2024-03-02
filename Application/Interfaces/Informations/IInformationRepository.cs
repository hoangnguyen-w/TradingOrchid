using Application.Common.Dto.Information;
using Application.Common.Dto.Role;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Informations
{
    public interface IInformationRepository
    {
        Task<List<Information>> GetAll(InformationViewDTO informationViewDTO);

        Task<List<Information>> GetByID(int id);

        Task<Information> FindIDToResult(int id);

        Task<List<Information>> Search(string search);

        Task CreateImage();
    }
}
