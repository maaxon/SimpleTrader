using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.Commands.StockViewCommands;
using SimpleTrader.WPF.Helpers;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.State.StockStore;
using Wpf.Ui;

namespace SimpleTrader.WPF.ViewModels
{
    public class StockViewModel:ViewModelBase, IBuyViewModel
    {
        private string _symbol;
        
        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        
        private ICommand LoadStockCommand { get; }
        public ICommand BuyStockCommand { get; }

        private bool _showChart = false;
        
        public bool ShowChart
        {
            get => _showChart;
            set
            {
                _showChart = value;
                OnPropertyChanged(nameof(ShowChart));
            }
        }
        public string Symbol
        {
            get { return Description.Symbol; }
        }

        private ApiStockDescription _stockDescription;

        public ApiStockDescription Description
        {
            get => _stockDescription; 
            set
            {
                _stockDescription = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        
        private StockDescription _localDesc;
        public StockDescription LocalDescription
        {
            get => _localDesc; 
            set
            {
                _localDesc = value;
                Candlestick = new Candlestick(value.Price);
                OnPropertyChanged(nameof(LocalDescription));
                OnPropertyChanged(nameof(Candlestick));
            }
        }

        public Candlestick Candlestick { get; set; } = new Candlestick();
        
        private List<StockPriceChanges> _stockPriceChanges;

        public List<StockPriceChanges> StockPriceChanges
        {
            get => _stockPriceChanges; 
            set
            {
                _stockPriceChanges = value;
              //  if (LocalDescription != null)
               // {
               //     value[460].High = LocalDescription.Price;
               // }
               // Candlestick = new Candlestick(value);
                OnPropertyChanged(nameof(StockPriceChanges));
            }
        }
        
        
        private int _sharesToBuy;
        public int SharesToBuy
        {
            get
            {
                return _sharesToBuy;
            }
            set
            {
                _sharesToBuy = value;
                OnPropertyChanged(nameof(SharesToBuy));
                OnPropertyChanged(nameof(TotalPrice));
                OnPropertyChanged(nameof(CanBuyStock));
            }
        }
        
        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public MessageViewModel StatusMessageViewModel { get; }

        public string StatusMessage
        {
            set => StatusMessageViewModel.Message = value;
        }
        
        
        public bool CanBuyStock => SharesToBuy > 0;

        public double TotalPrice
        {
            get
            {
                if (!IsLoading)
                {
                    return SharesToBuy * LocalDescription.Price;
                }

                return 0;
            }
        }

        private readonly IStockDescriptionService _stockDescriptionService;
        
        private ICommand LoadLocal { get; }

        public StockViewModel(IStockDescriptionService stockDescriptionService,
            IBuyStockService buyStockService,
            IAccountStore accountStore,
            IStockDescriptionDataService dataService,
            ISnackbarService snackbarService)
        {
            ErrorMessageViewModel = new MessageViewModel();
            StatusMessageViewModel = new MessageViewModel();
            LoadStockCommand = new LoadDescriptionCommand(this,stockDescriptionService);
            BuyStockCommand = new BuyStockCommand(this, buyStockService, accountStore,snackbarService);
            LoadLocal = new LoadLocalStockCommand(this,dataService);
        }
        
        
        
        public static StockViewModel LoadStockViewModel(IStockDescriptionService stockDescriptionService,
            StockStore stockStore,
            IBuyStockService buyStockService,
            IAccountStore accountStore,
            IStockDescriptionDataService dataService,
            ISnackbarService snackbarService)
        {
            StockViewModel stockViewModel = new StockViewModel(stockDescriptionService,buyStockService,accountStore,dataService,snackbarService);

            stockViewModel.LoadStockCommand.Execute(stockStore.CurrentAsset);
            stockViewModel.LoadLocal.Execute(stockStore.CurrentAsset);
            return stockViewModel;
        }
        
     
        
        public override void Dispose()
        {
           
            ErrorMessageViewModel.Dispose();
            StatusMessageViewModel.Dispose();
            base.Dispose();
        }
    }
}