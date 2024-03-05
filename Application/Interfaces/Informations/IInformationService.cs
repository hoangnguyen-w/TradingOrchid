using Application.Common.Dto.Information;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Informations
{
    public interface IInformationService
    {
        Task<List<InformationViewDTO>> GetAll();

        Task<List<InformationViewDTO>> GetByID(int id);

        Task<List<InformationViewDTO>> Search(string search);

        Task CreateImage();
    }
}
