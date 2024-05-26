using System;
using System.Linq;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.ViewModels;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace SimpleTrader.WPF.Commands.QueueCommands
{
    public class RemoveFromQueueCommand: AsyncCommandBase
    {
        private IDataService<AssetQueue> _queueService;
        private IDataService<Account> _accountService;
        private IAccountStore _accountStore;
        private ISnackbarService _snackbarService;
        private AssetsQueueViewModel _viewModel;
        public RemoveFromQueueCommand(
            IDataService<AssetQueue> queueService,
            IDataService<Account> accountService,
            IAccountStore accountStore,
            ISnackbarService snackbarService,
            AssetsQueueViewModel assetsQueueViewModel)
        {
            _queueService = queueService;
            _snackbarService = snackbarService;
            _accountService = accountService;
            _accountStore = accountStore;
            _viewModel = assetsQueueViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var assetQueueItem = (AssetQueue)parameter;
                var transaction = new AssetTransaction()
                {
                    Account = _accountStore.CurrentAccount,
                    Asset = new Asset() { PricePerShare = 0, Symbol = assetQueueItem.Symbol },
                    DateProcessed = DateTime.Now,
                    IsPurchase = true,
                    Shares = assetQueueItem.Shares
                };
                _accountStore.CurrentAccount.AssetTransactions.Add(transaction);
                await _accountService.Update(_accountStore.CurrentAccount.Id, _accountStore.CurrentAccount);
                await _queueService.Delete(assetQueueItem.Id);
                var queue = _viewModel.Queue;
                queue.Remove(assetQueueItem);
                _viewModel.Queue = queue;
                
                _snackbarService.Show(
                    "Caution",
                    $"{assetQueueItem.Shares} Shares of {assetQueueItem.Symbol} removed from queue",
                    ControlAppearance.Caution,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(2)
                );
            }
            catch (Exception e)
            {
                _snackbarService.Show(
                    "Error",
                    $"Check your internet connection",
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(3)
                );
            }
        }
    }
}