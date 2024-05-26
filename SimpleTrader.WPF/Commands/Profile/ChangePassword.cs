using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.ViewModels;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace SimpleTrader.WPF.Commands
{
   
    
    public class ChangePassword: AsyncCommandBase
    {
        private readonly IDataService<Account> _dataService;
        private readonly IAccountStore _accountStore;
        private readonly PortfolioViewModel _viewModel;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ISnackbarService _snackbarService;
        public ChangePassword(IDataService<Account> dataService,
            IAccountStore accountStore,
            PortfolioViewModel viewModel,
            IPasswordHasher passwordHasher,
            ISnackbarService snackbarService)
        {
            _dataService = dataService;
            _accountStore = accountStore;
            _viewModel = viewModel;
            _passwordHasher = passwordHasher;
            _snackbarService = snackbarService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                if (string.IsNullOrEmpty(_viewModel.Password))
                {
                    throw new Exception("Check password for validity");
                }
                var account = _accountStore.CurrentAccount;
                account.AccountHolder.PasswordHash = _passwordHasher.HashPassword(_viewModel.Password);
                _accountStore.CurrentAccount = await _dataService.Update(account.Id, account);
                _viewModel.Password = "";
                
                
                _snackbarService.Show(
                    "Success",
                    $"Password changed successfully",
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