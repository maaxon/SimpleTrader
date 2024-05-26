using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands.AdminUserCommands
{
    public class ChangeAmount: AsyncCommandBase
    {
        private readonly IDataService<Account> _dataService;
        private readonly UserViewModel _viewModel;
        public ChangeAmount(IDataService<Account> dataService, UserViewModel viewModel)
        {
            _dataService = dataService;
            _viewModel = viewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var change = (ChangeAssetAmount)parameter;
                var account = _viewModel.CurrentAccount;
                if (change.Inc - change.Dec != 0)
                {
                    var isPurchase = change.Inc - change.Dec > 0;
                    var shares = isPurchase ? change.Inc - change.Dec : change.Dec - change.Inc;
                    var transaction = new AssetTransaction()
                    {
                        Account = account,
                        Asset = new Asset(){PricePerShare = change.Price,Symbol = change.Symbol},
                        DateProcessed = DateTime.Now,
                        Shares = shares,
                        IsPurchase = isPurchase
                    };
                    account.AssetTransactions.Add(transaction);
                    _viewModel.CurrentAccount = await _dataService.Update(account.Id, account);
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}