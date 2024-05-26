using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.AuthenticationServices;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.ViewModels;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace SimpleTrader.WPF.Commands
{
   
    
    public class ChangeEmail: AsyncCommandBase
    {
        private readonly IDataService<Account> _dataService;
        private readonly IAccountStore _accountStore;
        private readonly PortfolioViewModel _viewModel;
        private readonly ISnackbarService _snackbarService;
        public ChangeEmail(IDataService<Account> dataService,
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
                if (string.IsNullOrEmpty(_viewModel.Email))
                {
                    throw new Exception("Check email for validity");
                }
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(_viewModel.Email);
                if (!match.Success)
                {
                    throw new FormatException();
                }
                var account = _accountStore.CurrentAccount;
                account.AccountHolder.Email = _viewModel.Email;
                _accountStore.CurrentAccount = await _dataService.Update(account.Id, account);
                _snackbarService.Show(
                    "Success",
                    $"Email changed to {account.AccountHolder.Email}",
                    ControlAppearance.Success,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(2)
                );
            }
            catch (FormatException)
            {
                _snackbarService.Show(
                    "Error",
                    $"check email for validity",
                    ControlAppearance.Danger,
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