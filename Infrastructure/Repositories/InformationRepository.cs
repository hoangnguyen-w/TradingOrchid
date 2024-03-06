using Application.Common.Dto.Page;
using Application.Interfaces.Informations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InformationRepository : IInformationRepository
{
    private readonly TradingOrchidContext context;
    public InformationRepository(TradingOrchidContext context)
    {
        this.context = context;
    }

    public async Task<List<Information>> GetList(PageDto page)
    {
        try
        {
            var query = context.Informations.AsQueryable();

            return await PagingConfiguration<Information>
                .Get(query
                .Include(i => i.User)
                .Include(a => a.Aution), page);
        }
        catch
        {
            throw;
        }
    }

    public async Task<Information> Detail(int id)
    {
        try
        {
            return await context.Informations
                .Include(i => i.User)
                .Include(i => i.Aution).FirstAsync();
        }
        catch
        {
            throw;
        }
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
}
