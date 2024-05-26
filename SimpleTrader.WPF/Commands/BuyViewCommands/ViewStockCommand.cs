using System;
using System.Windows;
using System.Windows.Input;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.State.StockStore;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Factories;

namespace SimpleTrader.WPF.Commands
{
    public class ViewStockCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly IRenavigator _renavigator;
        private readonly StockStore _store;

        public ViewStockCommand(IRenavigator renavigator, StockStore store)
        {
            _store = store;
            _renavigator = renavigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _store.CurrentAsset = parameter as string;
            _renavigator.Renavigate();
        }
        
    }
}