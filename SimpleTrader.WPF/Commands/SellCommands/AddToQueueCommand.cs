using System;
using System.ComponentModel;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands.SellCommands
{
    public class AddToQueueCommand: AsyncCommandBase
    {
         private readonly SellViewModel _viewModel;
        private readonly IAddToQueueService _queueService;
        private readonly IAccountStore _accountStore;

        public AddToQueueCommand(SellViewModel viewModel, IAddToQueueService addToQueueService, IAccountStore accountStore)
        {
            _viewModel = viewModel;
            _queueService =addToQueueService;
            _accountStore = accountStore;

            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.CanSellStock && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.StatusMessage = string.Empty;
            _viewModel.ErrorMessage = string.Empty;
            
            try
            {
                if (_viewModel.UserPrice < 1)
                {
                    throw new Exception();
                }
                var symbol = _viewModel.Symbol;
                var mode = _viewModel.Mode;
                var shares = _viewModel.SharesToSell;
                var price = _viewModel.UserPrice;
                var account = await _queueService.
                    AddStockToQueue(_accountStore.CurrentAccount,symbol,shares,price,mode);

                _accountStore.CurrentAccount = account;

                _viewModel.SearchResultSymbol = string.Empty;
                _viewModel.SharesToSell = 0;
                _viewModel.StatusMessage = $"Successfully added to queue {shares} shares of {symbol}.";
            }
            catch (InsufficientSharesException ex)
            {
                _viewModel.ErrorMessage = $"Account has insufficient shares. You only have {ex.AccountShares} shares.";
            }
            catch (InvalidSymbolException)
            {
                _viewModel.ErrorMessage = "Symbol does not exist.";
            }
            catch (Exception)
            {
                _viewModel.ErrorMessage = "Transaction failed.";
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SellViewModel.CanSellStock))
            {
                OnCanExecuteChanged();
            }
        }
    }
}