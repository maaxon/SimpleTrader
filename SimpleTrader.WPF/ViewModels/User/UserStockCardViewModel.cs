using System.Windows.Input;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.WPF.ViewModels
{
    public class UserStockCardViewModel:ViewModelBase
    {
        private int _shares;
        public string Symbol { get; set; }
        public int Shares => _shares + _add - _dec;
        
        public double Price { get; set; }

        private int _add = 0;
        private int _dec = 0;
        
        public void Inc()
        {
            _add++;
            AssetAmount.Inc = _add;
            OnPropertyChanged(nameof(Shares));
        }
        
        public void Dec()
        {
            if (Shares>0)
            {
                _dec++;
                AssetAmount.Inc = _dec;
                SetAssetAmount();
                OnPropertyChanged(nameof(Shares));
            }
        }
        
        public bool ShowControlls { get; set; }

        public void ShowShareChanging()
        {
            ShowControlls = !ShowControlls;
            OnPropertyChanged(nameof(ShowControlls));
        }
        
        public ChangeAssetAmount AssetAmount { get; set; }

        public void SetAssetAmount()
        {
            var asset = new ChangeAssetAmount()
                { Dec = _dec, Inc = _add, Price = Price, Symbol = Symbol };
            AssetAmount = asset;
            OnPropertyChanged(nameof(AssetAmount));
        }
        
        public ICommand ChangeAmount { get; }

        public UserStockCardViewModel(string symbol, int shares, double price,ICommand command)
        {
            Symbol = symbol;
            _shares = shares;
            Price = price;
            ChangeAmount = command;
            SetAssetAmount();
        }
    }
}