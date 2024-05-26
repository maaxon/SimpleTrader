using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
    public class LoadUsersCommand: AsyncCommandBase
    {
        private IDataService<Account> _dataService;
        private UsersViewModel _viewModel;
        public LoadUsersCommand(IDataService<Account> accountDataService, UsersViewModel viewModel)
        {
            _dataService = accountDataService;
            _viewModel = viewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                _viewModel.IsLoading = true;
                IEnumerable<Account> accounts = await _dataService.GetAll();
                _viewModel.Accounts = accounts;
                _viewModel.IsLoading = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}