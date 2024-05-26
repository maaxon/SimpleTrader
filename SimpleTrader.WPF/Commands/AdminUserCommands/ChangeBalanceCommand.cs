using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands.AdminUserCommands
{
    public class ChangeBalanceCommand: AsyncCommandBase
    {
        private IDataService<Account> _dataService;
        private UserViewModel _viewModel;
        public ChangeBalanceCommand(IDataService<Account> accountDataService,UserViewModel viewModel)
        {
            _dataService = accountDataService;
            _viewModel = viewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var change = (double)parameter;
                if ( _viewModel.CurrentAccount.Balance + change>0)
                {
                    _viewModel.CurrentAccount.Balance += change;
                }
                else
                {
                    
                    _viewModel.CurrentAccount.Balance = 0;
                }
                Account account = await _dataService.Update(_viewModel.CurrentAccount.Id,_viewModel.CurrentAccount);
                _viewModel.CurrentAccount = account;
                _viewModel.Add = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
        }
    }
}