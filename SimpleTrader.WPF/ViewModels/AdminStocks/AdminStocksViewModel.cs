using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.Commands.AdminStocksCommands;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.State.UpdateStockStore;
using Wpf.Ui;

namespace SimpleTrader.WPF.ViewModels
{
    public class AdminStocksViewModel: ViewModelBase
    {
        private bool _isLoading;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private IEnumerable<StockDescription> _stockDescriptions;

        public IEnumerable<StockDescription> Stocks
        {
            get => _stockDescriptions;
            set
            {
                _stockDescriptions = value;
                CreateStockCardViewModels(value);
                OnPropertyChanged(nameof(StockCardViewModels));
            }
        }
        
        public List<AdminStockCardViewModel> StockCardViewModels { get; set; }

        private void CreateStockCardViewModels(IEnumerable<StockDescription> descriptions)
        {
            List<AdminStockCardViewModel> stockCardViewModels =new List<AdminStockCardViewModel>();
            foreach (var stock in descriptions)
            {
                stockCardViewModels.Add(new AdminStockCardViewModel(stock, DeleteStockCommand, UpdateStockRenavigation, ShowHistory));
            }

            StockCardViewModels = stockCardViewModels;
            OnPropertyChanged(nameof(StockCardViewModels));
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
                var stocks = Stocks.Where(price => price.Symbol.ToUpper().Contains(Symbol.ToUpper())).ToList();
                CreateStockCardViewModels(stocks);
            }
            else
            {
                CreateStockCardViewModels(Stocks);
            }
        }

        private ICommand LoadStocksCommand { get;  }
        private ICommand DeleteStockCommand { get;  }
        public ICommand CreateStockRenavigation { get;  }
        public ICommand UpdateStockRenavigation { get;  }
        public ICommand ShowHistory { get;  }
        
        AdminStocksViewModel(
            IDataService<StockDescription> dataService,
            IRenavigator create,
            IRenavigator update,
            UpdateStockStore updateStockStore,
            ISnackbarService snackbarService,
            IDataService<AssetTransaction> assetDataService,
            IContentDialogService contentDialogService)
        {
            LoadStocksCommand = new LoadAdminStockCommand(dataService, this);
            DeleteStockCommand = new DeleteStockCommand(dataService, this);
            CreateStockRenavigation = new RenavigateCommand(create);
            UpdateStockRenavigation = new ViewUpdateStockCommand(update,updateStockStore );
            ShowHistory = new ShowHistory(assetDataService,contentDialogService,snackbarService);
        }
        
        public static AdminStocksViewModel LoadAdminStocksViewModel(
            IDataService<StockDescription> dataService, IRenavigator create,
            IRenavigator update,
            UpdateStockStore updateStockStore,
            ISnackbarService snackbarService,
            IDataService<AssetTransaction> assetDataService,
            IContentDialogService contentDialogService)
        {
            var viewModel = new AdminStocksViewModel(dataService, create, update, updateStockStore, snackbarService, assetDataService,contentDialogService);

            viewModel.LoadStocksCommand.Execute(null);
            
            return viewModel;
        }
    }
}