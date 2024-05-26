using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.State.StockStore;

namespace SimpleTrader.WPF.ViewModels
{
    public class StockCardViewModel:ViewModelBase
    {
       
        
        public ICommand PreviewStock { get; set; }
        public string Symbol { get; set; }
        public string Company { get; set; }
        public string Exchange { get; set; }
        public double Price { get; set; }

        public StockCardViewModel(IRenavigator renavigator,StockStore stockStore ,StockDescription stockPrice)
        {
            PreviewStock = new ViewStockCommand(renavigator,stockStore);
            Symbol = stockPrice.Symbol;
            Price = stockPrice.Price;
            Company = stockPrice.CompanyName;
            Exchange = stockPrice.Exchange;
        }
    }
}