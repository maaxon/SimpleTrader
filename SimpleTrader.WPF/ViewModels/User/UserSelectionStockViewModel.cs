using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;
using SimpleTrader.WPF.Commands;

namespace SimpleTrader.WPF.ViewModels
{
    public class UserSelectionStockViewModel: ViewModelBase
    {
        
        private string _symbol="";

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

        private List<StockDescription> _searchResultSymbol;
        public List<StockDescription> SearchResult
        {
            get => _searchResultSymbol;
            set
            {
                _searchResultSymbol = value;
                MakeModels(value);
                OnPropertyChanged(nameof(SearchResult));
                OnPropertyChanged(nameof(StockModels));
            }
        }

        public void SearchStock()
        {
            if (CanSearchSymbol)
            {
                var stocks = SearchResult.Where(price => price.Symbol.ToUpper().Contains(Symbol.ToUpper())).ToList();
                MakeModels(stocks);
            }
            else
            {
                MakeModels(SearchResult);
            }
            OnPropertyChanged(nameof(StockModels));
        }
        
        private void MakeModels(List<StockDescription> results)
        {
            List<UserStockCard> models = new List<UserStockCard>();
            foreach (var model in results)
            {
                models.Add(new UserStockCard(model.Symbol, model.Price,AddStock));
            }

            StockModels = models;
        }
        
        
        
        public List<UserStockCard> StockModels { get; set; }

        private ICommand AddStock { get; }
        
        public UserSelectionStockViewModel(List<StockDescription> descriptions,ICommand command)
        {
            AddStock = command;
            SearchResult = descriptions;
        }
    }
}