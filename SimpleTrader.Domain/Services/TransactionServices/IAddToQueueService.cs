using System.Threading.Tasks;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.TransactionServices
{
    public interface IAddToQueueService
    {
        Task<Account> AddStockToQueue(Account seller, string symbol, int shares,double price,string mode);
    }
}