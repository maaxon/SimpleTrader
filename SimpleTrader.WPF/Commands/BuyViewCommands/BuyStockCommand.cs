using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace SimpleTrader.WPF.Commands
{
    public class BuyStockCommand : AsyncCommandBase
    {
        private readonly StockViewModel _buyViewModel;
        private readonly IBuyStockService _buyStockService;
        private readonly IAccountStore _accountStore;
        private readonly ISnackbarService _snackbarService;

        public BuyStockCommand(StockViewModel buyViewModel,
            IBuyStockService buyStockService,
            IAccountStore accountStore,
            ISnackbarService snackbarService)
        {
            _buyViewModel = buyViewModel;
            _buyStockService = buyStockService;
            _accountStore = accountStore;
            _snackbarService = snackbarService;
            _buyViewModel.PropertyChanged += BuyViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _buyViewModel.CanBuyStock && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _buyViewModel.StatusMessage = string.Empty;
            _buyViewModel.ErrorMessage = string.Empty;

            try
            {
                string symbol = _buyViewModel.Symbol;
                int shares = _buyViewModel.SharesToBuy;
                Account account = await _buyStockService.BuyStock(_accountStore.CurrentAccount, symbol, shares);

                _accountStore.CurrentAccount = account;
                _snackbarService.Show(
                    "Success",
                    $"Successfully purchased {shares} shares of {symbol}.",
                    ControlAppearance.Success,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(4)
                );
                
            }
            catch(InsufficientFundsException)
            {
                _snackbarService.Show(
                    "Error",
                    $"Account has insufficient funds. Please transfer more money into your account.",
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(4)
                );
            }
            catch(InvalidSymbolException)
            {
                _snackbarService.Show(
                    "Error",
                    "Symbol does not exist.",
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(4)
                );
            }
            catch (Exception)
            {
                _snackbarService.Show(
                    "Error",
                    $"Transaction failed.",
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(4)
                );
            }
        }

        private void BuyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(StockViewModel.CanBuyStock))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
