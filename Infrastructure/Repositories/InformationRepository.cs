using Application.Common.Dto.Comment;
using Application.Common.Dto.Exception;
using Application.Common.Dto.Information;
using Application.Interfaces.Comments;
using Application.Interfaces.Informations;
using AutoMapper;
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

        public async Task<List<Information>> GetAll()
        {
            try
            {
                return await context.Informations
                    .Include(c => c.Aution)
                    .ToListAsync();
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
                                r.Aution.RegisterAuction.User.UserName.Trim().ToLower().Contains(search.Trim().ToLower()) ||
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
