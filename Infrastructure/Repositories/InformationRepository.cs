﻿using Application.Common.Dto.Page;
using Application.Common.Paging;
using Application.Interfaces.Informations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task Insert(Information information)
        {
            try
            {
                context.Informations.Add(information);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Information>> GetAll(PageDto page)
        {
            try
            {
                var query = context.Informations.AsQueryable();

                return await PagingConfiguration<Information>
                    .Get(query.Include(c => c.Aution), page);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Information>> GetByID(int id)
        {
            try
            {
                return await context.Informations
                    .Where(r => r.InformationID == id)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Information>> Search(string search)
        {
            try
            {
                return await context.Informations
                    .Where(r => r.InformationTitle.Trim().ToLower().Contains(search.Trim().ToLower()) ||
                                r.Aution.AutionTitle.Trim().ToLower().Contains(search.Trim().ToLower()))
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
