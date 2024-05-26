using System;
using System.Windows.Input;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.Commands.Profile
{
    public class LogOut: ICommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;
        public LogOut(IAuthenticator authenticator,IRenavigator renavigator)
        {
            _renavigator = renavigator;
            _authenticator = authenticator;
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _authenticator.Logout();
            _renavigator.Renavigate();
        }

        public event EventHandler CanExecuteChanged;
    }
}