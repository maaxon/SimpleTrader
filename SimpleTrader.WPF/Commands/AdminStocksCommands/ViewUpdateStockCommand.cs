using System;
using System.Windows.Input;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.State.UpdateStockStore;

namespace SimpleTrader.WPF.Commands.AdminStocksCommands
{
    public class ViewUpdateStockCommand: ICommand
    {
        private IRenavigator _renavigator;
        private UpdateStockStore _stockStore;
        public ViewUpdateStockCommand(IRenavigator renavigator, UpdateStockStore stockStore)
        {
            _renavigator = renavigator;
            _stockStore = stockStore;
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _stockStore.StockId = (int)parameter;
            _renavigator.Renavigate();
        }

        public event EventHandler CanExecuteChanged;
    }
}