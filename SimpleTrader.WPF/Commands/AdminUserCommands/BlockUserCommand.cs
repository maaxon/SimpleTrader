using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands.AdminUserCommands
{
    public class BlockUserCommand:AsyncCommandBase
    {
        private readonly IDataService<Account> _dataService;
        private readonly UserViewModel _viewModel;

        public BlockUserCommand(IDataService<Account> dataService, UserViewModel viewModel)
        {
            _dataService = dataService;
            _viewModel = viewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.IsLoading = true;
            try
            {
                var id = _viewModel.CurrentAccount.Id;
                var changedAccount = _viewModel.CurrentAccount;
                var role = _viewModel.CurrentAccount.AccountHolder.Role;
                changedAccount.AccountHolder.Role = role switch
                {
                    "user" => "blocked",
                    "blocked" => "user",
                    _ => changedAccount.AccountHolder.Role
                };
                var account  = await _dataService.Update(id,changedAccount);
                _viewModel.CurrentAccount = account;
                _viewModel.IsLoading = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _viewModel.IsLoading = false;
            }
        }
    }
}