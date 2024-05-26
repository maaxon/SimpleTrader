using System;
using System.Collections.Generic;
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
    public class LoadQueueCommand: AsyncCommandBase
    {
        private IDataService<AssetQueue> _queueService;
        private IDataService<Account> _accountService;
        private IAccountStore _accountStore;
        private IStockPriceService _stockPriceService;
        private ISnackbarService _snackbarService;
        private AssetsQueueViewModel _viewModel;
        private string log = "";

        public LoadQueueCommand(IDataService<AssetQueue> queueService,
            IDataService<Account> accountService,
            IAccountStore accountStore,
            IStockPriceService stockPriceService,
            ISnackbarService snackbarService,
            AssetsQueueViewModel assetsQueueViewModel)
        {
            _queueService = queueService;
            _snackbarService = snackbarService;
            _stockPriceService = stockPriceService;
            _accountService = accountService;
            _accountStore = accountStore;
            _viewModel = assetsQueueViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.IsLoading = true;
            try
            {
                var queue = await _queueService.GetAll();
                queue = queue.Where(q => q.UserId == _accountStore.CurrentAccount.Id);
                _viewModel.Queue = await SellStocks(queue);
                _viewModel.IsLoading = false;
                if (!string.IsNullOrEmpty(log))
                {
                     _snackbarService.Show(
                                        "Success",
                                        $"Sold {log}",
                                        ControlAppearance.Success,
                                        new SymbolIcon(SymbolRegular.Fluent24),
                                        TimeSpan.FromSeconds(4)
                                    );
                }
               

            }
            catch (Exception e)
            {
                _viewModel.IsLoading = false;
                _snackbarService.Show(
                    "Error",
                    $"Check your internet connection",
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(3)
                );
            }
        }

        private async Task<List<AssetQueue>> SellStocks(IEnumerable<AssetQueue> queue)
        {
            var transactions = new List<AssetTransaction>();
            double sum = 0;
            var updatedQueue = new List<AssetQueue>();
            foreach (var asset in queue)
            {
                var price = await _stockPriceService.GetPrice(asset.Symbol);
                if ((asset.Mode == "High" && price > asset.Price) ||
                    (asset.Mode == "Low" &&  price <  asset.Price))
                {
                    log += $"{asset.Symbol}-{asset.Shares}";
                    var transaction = new AssetTransaction() { Asset = new Asset()
                            {PricePerShare = price,Symbol = asset.Symbol},
                        Account = _accountStore.CurrentAccount,
                        IsPurchase = false,
                        DateProcessed = DateTime.Now,
                        Shares = asset.Shares
                    };
                    sum += asset.Shares * price;
                    transactions.Add(transaction);
                    await _queueService.Delete(asset.Id);
                }
                else
                {
                    updatedQueue.Add(asset);
                }
                
            }
            _accountStore.CurrentAccount.AssetTransactions = _accountStore.CurrentAccount.AssetTransactions.Concat(transactions).ToList();
            _accountStore.CurrentAccount.Balance += sum;
            await _accountService.Update(_accountStore.CurrentAccount.Id, _accountStore.CurrentAccount);
            return updatedQueue;
        }
        
        
    }
}