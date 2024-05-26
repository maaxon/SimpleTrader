using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;

namespace SimpleTrader.EntityFramework.Services
{
    public class StockDescriptionDataService: IDataService<StockDescription>, IStockDescriptionDataService
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;
        private readonly NonQueryDataService<StockDescription> _nonQueryDataService;
        
        public StockDescriptionDataService(SimpleTraderDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<StockDescription>(contextFactory);
        }
          public async Task<StockDescription> Create(StockDescription entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<StockDescription> Get(int id)
        {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
            {
                StockDescription entity = await context.StockDescriptions
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }
        
        

        public async Task<IEnumerable<StockDescription>> GetAll()
        {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<StockDescription> entities = await context.StockDescriptions
                       .ToListAsync();
                return entities;
            }
        }

        public async Task<StockDescription> GetBySymbol(string symbol)
        {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.StockDescriptions
                    .FirstOrDefaultAsync(s => s.Symbol == symbol);
            }
        }

        public async Task<StockDescription> Update(int id, StockDescription entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}