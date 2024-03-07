﻿using Application.Common.Dto.Page;
using Domain.Entities;

namespace Application.Interfaces.Informations
{
    public interface IInformationRepository
    {
        Task<List<Information>> GetAll(PageDto page);

        Task Insert(Information information);

        Task<List<Information>> GetByID(int id);

        Task<Information> FindIDToResult(int id);

        Task<List<Information>> Search(string search);

        Task CreateImage();
    }
}
