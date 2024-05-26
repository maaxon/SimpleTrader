using System;
using System.Windows.Input;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
    public class RedoCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;
        private SearchViewModel _searchViewModel;
        public RedoCommand(SearchViewModel searchViewModel)
        {
            _searchViewModel = searchViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_searchViewModel.buff.Count > 1 && _searchViewModel.buffIdx < _searchViewModel.buff.Count -1)
            {
                _searchViewModel.Symbol = _searchViewModel.buff[_searchViewModel.buffIdx+1];
                _searchViewModel.buff.RemoveAt(_searchViewModel.buff.Count-1);
            }
        }
    }
}