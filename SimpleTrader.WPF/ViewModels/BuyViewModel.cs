using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Accounts;
using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.WPF.Commands.BuyViewCommands;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.State.StockStore;
using Wpf.Ui;

namespace SimpleTrader.WPF.ViewModels
{
    public class BuyViewModel : ViewModelBase
    {
       

        private List<StockDescription> _stockPrice;

        public List<StockDescription> StockPrice
        {
            get => _stockPrice;
            set
            {
                _stockPrice = value;
               
                ResetCards(value);
                OnPropertyChanged(nameof(StockPrice));
              
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
                var stocks = StockPrice.Where(price => price.Symbol.ToUpper().Contains(Symbol.ToUpper())).ToList();
                ResetCards(stocks);
            }
            else
            {
                ResetCards(StockPrice);
            }
        }

        private string _searchResultSymbol = string.Empty;
        public string SearchResultSymbol
        {
            get
            {
                return _searchResultSymbol;
            }
            set
            {
                _searchResultSymbol = value;
                OnPropertyChanged(nameof(SearchResultSymbol));
            }
        }

        private List<StockCardViewModel> _cardViewModels = new List<StockCardViewModel>();

        public List<StockCardViewModel> cardViewModels
        {
            get { return _cardViewModels; }
            set
            {
                _cardViewModels = value;
                OnPropertyChanged(nameof(cardViewModels));
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

        public ICommand FilterCommand { get; set; }
        public ICommand LoadStocksCommand { get; set; }
        
        private bool _isLoading = false;
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

        private readonly IRenavigator _renavigator;
        private readonly StockStore _stockStore;
        
        public int Min { get; set; }
        public int Max { get; set; }
        
      

        public void FilterCards()
        {
            if (Max > 0)
            {
                var stockPrices= StockPrice.FindAll(price => price.Price > Min && price.Price < Max);
                ResetCards(stockPrices);
            }
            else
            {
                var stockPrices= StockPrice.FindAll(price => price.Price > Min);
                ResetCards(stockPrices);
            }
        }
        
        public void ResetCards(List<StockDescription> stockPrices)
        {
            List<StockCardViewModel> models = new List<StockCardViewModel>();
            foreach (var stock in stockPrices)
            {
                models.Add(new StockCardViewModel(_renavigator,_stockStore,stock));
            }

            cardViewModels = models;
        }
        
        public ICommand ShowFilters { get;  }
        
        public BuyViewModel(IStockPriceService stockPriceService,
            IRenavigator renavigator,
            StockStore stockStore,
            IDataService<StockDescription> dataService,
            IContentDialogService dialogService)
        {
            ErrorMessageViewModel = new MessageViewModel();
            StatusMessageViewModel = new MessageViewModel();
            _renavigator = renavigator;
            _stockStore = stockStore;

            FilterCommand = new FilterStocksCommand(this);
            LoadStocksCommand = new LoadPricesCommand(this, stockPriceService,dataService);
            ShowFilters = new ShowFiltersCommand(dialogService,this);
        }

        public static BuyViewModel LoadBuyViewModel(
            IStockPriceService stockPriceService,
            IRenavigator renavigator,
            StockStore stockStore,
            IDataService<StockDescription> dataService,
            IContentDialogService dialogService)
        {
            BuyViewModel buyViewModel = new BuyViewModel(stockPriceService, renavigator, stockStore,dataService,dialogService);

            buyViewModel.LoadStocksCommand.Execute(null);
            
            return buyViewModel;
        }

        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();
            StatusMessageViewModel.Dispose();

            base.Dispose();
        }
    }
}
