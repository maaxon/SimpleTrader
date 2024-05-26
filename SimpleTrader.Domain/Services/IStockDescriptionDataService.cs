using System.Threading.Tasks;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services
{
    public interface IStockDescriptionDataService
    {
        Task<StockDescription> GetBySymbol(string symbol);
    }
}