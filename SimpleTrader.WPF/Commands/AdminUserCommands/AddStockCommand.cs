using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace SimpleTrader.WPF.Commands.AdminUserCommands
{
    public class AddStockCommand:AsyncCommandBase
    {
        private readonly IDataService<Account> _dataService;
        private readonly int _accountId;
        private readonly ISnackbarService _snackbarService;
        public AddStockCommand(IDataService<Account> dataService,int accountId,ISnackbarService snackbarService)
        {
            _dataService = dataService;
            _accountId = accountId;
            _snackbarService = snackbarService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var asset = (Asset)parameter;
                var account = await _dataService.Get(_accountId);
                var transaction = new AssetTransaction()
                {
                    Account = account,
                    Asset = asset,
                    DateProcessed = DateTime.Now,
                    Shares = 1,
                    IsPurchase = true
                };
                account.AssetTransactions.Add(transaction);
                await _dataService.Update(_accountId, account);
                _snackbarService.Show(
                    "Success",
                    $"Successfully added {asset.Symbol}",
                    ControlAppearance.Success,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(4)
                );
            }
            catch (Exception e)
            {
                _snackbarService.Show(
                    "Error",
                    $"Some error occured",
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(4)
                );
                Console.WriteLine(e);
                throw;
            }
        }
    }
}