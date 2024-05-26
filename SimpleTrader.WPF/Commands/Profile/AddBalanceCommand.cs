using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.Views;

namespace SimpleTrader.WPF.Commands
{
    public class AddBalanceCommand: AsyncCommandBase
    {
        private IDataService<Account> _dataService;
        private IAccountStore _accountStore;
        private PortfolioViewModel _viewModel;
        public AddBalanceCommand(IDataService<Account> accountDataService,IAccountStore accountStore,PortfolioViewModel viewModel)
        {
            _dataService = accountDataService;
            _accountStore = accountStore;
            _viewModel = viewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                _accountStore.CurrentAccount.Balance += (double)parameter;
                Account account = await _dataService.Update(_accountStore.CurrentAccount.Id,_accountStore.CurrentAccount);
                _viewModel.AccountBalance = _accountStore.CurrentAccount.Balance;
                _viewModel.Add = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
        }
    }
}