using System;
using System.Windows.Input;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
    public class UndoCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;
        private SearchViewModel _searchViewModel;
        public UndoCommand(SearchViewModel searchViewModel)
        {
            _searchViewModel = searchViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_searchViewModel.buff.Count > 1 && _searchViewModel.buffIdx > 0)
            {
                _searchViewModel.buffIdx--;
                _searchViewModel.Symbol = _searchViewModel.buff[_searchViewModel.buffIdx];
                _searchViewModel.buffIdx--;
                _searchViewModel.buff.RemoveAt(_searchViewModel.buff.Count-1);
            }
        }
    }
}