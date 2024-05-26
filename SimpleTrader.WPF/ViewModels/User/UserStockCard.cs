using System.Windows.Input;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.WPF.ViewModels
{
    public class UserStockCard: ViewModelBase
    {
        public string Symbol => Asset.Symbol;
        public double Price => Asset.PricePerShare;
        public ICommand AddStock { get; }
        public Asset Asset { get; }

        public UserStockCard(string symbol, double price,ICommand command)
        {
            AddStock = command;
            Asset = new Asset() { PricePerShare = price, Symbol = symbol };
        }
    }
}