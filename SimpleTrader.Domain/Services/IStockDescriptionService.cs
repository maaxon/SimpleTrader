using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services
{
    public interface IStockDescriptionService
    {
        Task<ApiStockDescription> GetStockDescription(string symbol);
        Task<List<StockPriceChanges>> GetStockPriceChanges(string symbol);
    }
}