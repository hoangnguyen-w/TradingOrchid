using Application.Common.Dto.Information;
using Application.Interfaces.Informations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InformationRepository : IInformationRepository
    {
        private readonly TradingOrchidContext context;
        public InformationRepository(TradingOrchidContext context)
        {
            this.context = context;
        }

        public Task CreateImage()
        {
            throw new NotImplementedException();
        }

        public Task<Information> FindIDToResult(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Information>> GetAll(InformationViewDTO informationViewDTO)
        {
            /*try
            {
                *//*return await context.Informations.Join(context.Autions, i => i.AutionID, a => a.AutionID, (i, a) => new
                {
                });*//*
                return informationViewDTO;
            }
            catch
            {
                throw;
            }*/
            return await context.Informations.ToListAsync();
        }

        public Task<List<Information>> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Information>> Search(string search)
        {
            throw new NotImplementedException();
        }
    }
}
