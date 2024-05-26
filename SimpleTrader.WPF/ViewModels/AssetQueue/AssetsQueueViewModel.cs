using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.Commands.QueueCommands;
using SimpleTrader.WPF.State.Accounts;
using Wpf.Ui;

namespace SimpleTrader.WPF.ViewModels
{
    public class AssetsQueueViewModel: ViewModelBase
    {

        private bool _isLoading;

        public bool IsLoading
        {
            get=>_isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        
        private List<AssetQueue> _queue;

        public List<AssetQueue> Queue
        {
            get=>_queue;
            set
            {
                _queue = value;
                ReloadItems(value);
            }
        }

        private string _symbol;
        public string Symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                _symbol = value;
                OnPropertyChanged(nameof(Symbol));
                OnPropertyChanged(nameof(CanSearchSymbol));
            }
        }

        public bool CanSearchSymbol => !string.IsNullOrEmpty(Symbol);

        public void SearchStock()
        {
            if (CanSearchSymbol)
            {
                var stocks = Queue.Where(price => price.Symbol.ToUpper().Contains(Symbol.ToUpper())).ToList();
                ReloadItems(stocks);
            }
            else
            {
                ReloadItems(Queue);
            }
        }

        public List<QueueItemViewModel> Items { get; set; }
        
        private void ReloadItems(List<AssetQueue> queue)
        {
            Items = queue.Select(item => new QueueItemViewModel(item, RemoveFromQueue)).ToList();
            OnPropertyChanged(nameof(Items));
        }

        private readonly ICommand LoadQueue;
        private readonly ICommand RemoveFromQueue;
        
        private AssetsQueueViewModel(IDataService<AssetQueue> queueService,
            IDataService<Account> accountService,
            IAccountStore accountStore,
            IStockPriceService stockPriceService,
            ISnackbarService snackbarService
            )
        {
            LoadQueue = new LoadQueueCommand(queueService,accountService,accountStore,
                stockPriceService,snackbarService,this);
            RemoveFromQueue = new RemoveFromQueueCommand(queueService, accountService, accountStore,
                snackbarService, this);
        }
        
        public static AssetsQueueViewModel LoadStockViewModel(IDataService<AssetQueue> queueService,
            IDataService<Account> accountService,
            IAccountStore accountStore,
            IStockPriceService stockPriceService,
            ISnackbarService snackbarService)
        {
            var viewModel = new AssetsQueueViewModel(queueService,accountService,accountStore,
                stockPriceService,snackbarService);

            viewModel.LoadQueue.Execute(null);
            return viewModel;
        }
    }
}