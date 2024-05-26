using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.TransactionServices
{
    public class AddToQueueService: IAddToQueueService
    {
        private readonly IDataService<AssetQueue> _dataService;
        private readonly IDataService<Account> _accountService;

        public AddToQueueService(IDataService<AssetQueue> dataService, IDataService<Account> accountService)
        {
            _dataService = dataService;
            _accountService = accountService;
        }
        
        public async Task<Account> AddStockToQueue(Account seller, string symbol, int shares,double price,string mode)
        {
            int accountShares = GetAccountSharesForSymbol(seller, symbol);
            if(accountShares < shares)
            {
                throw new InsufficientSharesException(symbol, accountShares, shares);
            }
            

            seller.AssetTransactions.Add(new AssetTransaction()
            {
                Account = seller,
                Asset = new Asset()
                {
                    PricePerShare = 0,
                    Symbol = symbol
                },
                DateProcessed = DateTime.Now,
                IsPurchase = false,
                Shares = shares
            });

            var queue = new AssetQueue() { Price = price, Symbol = symbol, UserId = seller.Id,Shares = shares,Mode = mode};

            await _accountService.Update(seller.Id, seller);
            await _dataService.Create(queue);
           
            return seller;
        }
        
        private int GetAccountSharesForSymbol(Account seller, string symbol)
        {
            IEnumerable<AssetTransaction> accountTransactionsForSymbol = seller.AssetTransactions.Where(a => a.Asset.Symbol == symbol);
            
            return accountTransactionsForSymbol.Sum(a => a.IsPurchase ? a.Shares : -a.Shares);
        }
    }
}