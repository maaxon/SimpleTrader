using System;
using System.Windows;
using System.Windows.Input;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.State.StockStore;

namespace SimpleTrader.WPF.ViewModels
{
    public class AssetViewModel : ViewModelBase
    {
        public ICommand PreviewStock{ get; set; }
        public string Symbol { get; }
        public int Shares { get; }
        public AssetViewModel(string symbol, int shares)
        {
            Symbol = symbol;
            Shares= shares;
             
            
        }
        
        public AssetViewModel(string symbol, int shares,IRenavigator renavigator,StockStore stockStore): this(symbol,shares)
        {
            if (renavigator != null)
            {
                PreviewStock =new ViewStockCommand(renavigator,stockStore);
            }
        }
    }
}
