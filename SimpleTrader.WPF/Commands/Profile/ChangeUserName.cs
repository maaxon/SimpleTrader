using System;
using System.Net.Mail;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.Views;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace SimpleTrader.WPF.Commands
{
    public class ChangeUserName: AsyncCommandBase
    {
        private readonly IDataService<Account> _dataService;
        private readonly IAccountStore _accountStore;
        private readonly PortfolioViewModel _viewModel;
        private readonly ISnackbarService _snackbarService;
        public ChangeUserName(IDataService<Account> dataService,
            IAccountStore accountStore,
            PortfolioViewModel viewModel,
            ISnackbarService snackbarService)
        {
            _dataService = dataService;
            _accountStore = accountStore;
            _viewModel = viewModel;
            _snackbarService = snackbarService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                if (string.IsNullOrEmpty(_viewModel.UserName))
                {
                    throw new Exception("Check username for validity");
                }
                
                var account = _accountStore.CurrentAccount;
                account.AccountHolder.Username = _viewModel.UserName;
                _accountStore.CurrentAccount = await _dataService.Update(account.Id, account);
                _snackbarService.Show(
                    "Success",
                    $"User name changed to {account.AccountHolder.Username}",
                    ControlAppearance.Success,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(2)
                );
            }
            catch (Exception e)
            {
                _snackbarService.Show(
                    "Error",
                    $"{e.Message}",
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(2)
                );
            }
        }
    }
}