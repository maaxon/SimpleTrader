using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Accounts;

namespace SimpleTrader.WPF.ViewModels
{
    public class SearchViewModel :ViewModelBase, ISearchSymbolViewModel, IBuyViewModel
    {
        private string _symbol="";
        public List<string> buff = new List<string>(){""};
        public int buffIdx = 0;
        public string Symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                _symbol = value;
                buff.Add(value);
                buffIdx++;
                OnPropertyChanged(nameof(Symbol));
                OnPropertyChanged(nameof(CanSearchSymbol));
            }
        }
        
    

        

        public bool CanSearchSymbol => !string.IsNullOrEmpty(Symbol);

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

        private double _stockPrice;
        public double StockPrice
        {
            get
            {
                return _stockPrice;
            }
            set
            {
                _stockPrice = value;
                OnPropertyChanged(nameof(StockPrice));
                OnPropertyChanged(nameof(TotalPrice));
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

        public bool CanBuyStock => SharesToBuy > 0;

        public double TotalPrice
        {
            get
            {
                return SharesToBuy * StockPrice;
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

        public ICommand SearchSymbolCommand { get; set; }
        public ICommand BuyStockCommand { get; set; }
        
        public ICommand Undo { get; }
        public ICommand Redo { get; }

        public SearchViewModel(IStockPriceService stockPriceService, IBuyStockService buyStockService, IAccountStore accountStore)
        {
            ErrorMessageViewModel = new MessageViewModel();
            StatusMessageViewModel = new MessageViewModel();

            SearchSymbolCommand = new SearchSymbolCommand(this, stockPriceService);
           // BuyStockCommand = new BuyStockCommand(this, buyStockService, accountStore);
            Undo = new UndoCommand(this);
            Redo = new RedoCommand(this);
        }

        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();
            StatusMessageViewModel.Dispose();

            base.Dispose();
        }
    }
}