using System;
using System.Windows.Input;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
    public class FilterStocksCommand:ICommand
    {
        private BuyViewModel _buyViewModel;
        public FilterStocksCommand(BuyViewModel buyViewModel)
        {
            _buyViewModel = buyViewModel;
        }
        
        public event EventHandler CanExecuteChanged;
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _buyViewModel.FilterCards();
        }
    }
}