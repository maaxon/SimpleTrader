using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.ViewModels;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace SimpleTrader.WPF.Commands.Profile
{
    public class ChangeImg: AsyncCommandBase
    {
        private readonly IDataService<Account> _dataService;
        private readonly IAccountStore _accountStore;
        private readonly PortfolioViewModel _viewModel;
        private readonly ISnackbarService _snackbarService;
        public ChangeImg(IDataService<Account> dataService,
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
                if (string.IsNullOrEmpty(_viewModel.Img))
                {
                    throw new Exception("Check img for validity");
                }
                var img = (string)parameter;
                var account = _accountStore.CurrentAccount;
                account.AccountHolder.Img = img;
                _viewModel.Img = img;
                _accountStore.CurrentAccount = account;
                _accountStore.CurrentAccount = await _dataService.Update(account.Id, account);
                _snackbarService.Show(
                    "Success",
                    $"Img changed",
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