using System;
using System.Windows.Input;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.State.StockStore;
using SimpleTrader.WPF.State.UsersStore;

namespace SimpleTrader.WPF.Commands
{
    public class ViewUserCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly IRenavigator _renavigator;
        private readonly UsersStore _store;

        public ViewUserCommand(IRenavigator renavigator, UsersStore store)
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
            _store.UserId = (int)parameter;
            _renavigator.Renavigate();
        }
    }
}