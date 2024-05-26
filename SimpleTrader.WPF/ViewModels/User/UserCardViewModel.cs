using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.State.UsersStore;

namespace SimpleTrader.WPF.ViewModels
{
    public class UserCardViewModel:ViewModelBase
    {
        public Account Account { get; set; }
        public ICommand RenavigateCommand { get; set; }

        public string Role => Account.AccountHolder.Role.ToUpper();
        
        public UserCardViewModel(Account account, IRenavigator renavigator, UsersStore usersStore)
        {
            Account = account;
            RenavigateCommand = new ViewUserCommand(renavigator, usersStore);
        }
    }
}