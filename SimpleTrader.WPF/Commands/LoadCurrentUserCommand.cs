using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
    public class LoadCurrentUserCommand:AsyncCommandBase
    {
        private IDataService<Account> _dataService;
        private UserViewModel _viewModel;
        public LoadCurrentUserCommand(IDataService<Account> dataService, UserViewModel viewModel)
        {
            _dataService = dataService;
            _viewModel = viewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.IsLoading = true;
            try
            {
                Account account = await _dataService.Get((int)parameter);
                _viewModel.CurrentAccount = account;
                _viewModel.IsLoading = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
        }
    }
}