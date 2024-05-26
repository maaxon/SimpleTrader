using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.State.UsersStore;

namespace SimpleTrader.WPF.ViewModels
{
    public class UsersViewModel: ViewModelBase
    {
        private IEnumerable<Account> _accounts;

        public IEnumerable<Account> Accounts
        {
            get => _accounts;
            set
            {
                _accounts = value;
                LoadViewModels(value);
                OnPropertyChanged(nameof(Accounts));
            }
        }
        
        public List<UserCardViewModel> UserViewModels { get; set; }

        private void LoadViewModels(IEnumerable<Account> accounts)
        {
            List<UserCardViewModel> userViewModels = new List<UserCardViewModel>();
            foreach (var account in _accounts)
            {
                userViewModels.Add(new UserCardViewModel(account, _renavigator, _usersStore));
            }

            UserViewModels = userViewModels;
        }

        public List<UserCardViewModel> ActiveUsers => UserViewModels.Where(m => m.Role.Equals("USER")).ToList();
        public List<UserCardViewModel> BlockedUsers => UserViewModels.Where(m => m.Role.Equals("BLOCKED")).ToList();

        private bool _isLoading = true;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        
        public ICommand LoadUsersCommand { get; }

        private IRenavigator _renavigator;
        private UsersStore _usersStore;

        public UsersViewModel(IDataService<Account> dataService, IRenavigator renavigator, UsersStore usersStore)
        {
            LoadUsersCommand = new LoadUsersCommand(dataService, this);
            _renavigator = renavigator;
            _usersStore = usersStore;
        }

        public static UsersViewModel LoadUsersViewModel(IDataService<Account> accountDataService, IRenavigator renavigator, UsersStore usersStore)
        {
            UsersViewModel usersViewModel = new UsersViewModel(accountDataService,renavigator,usersStore);
            usersViewModel.LoadUsersCommand.Execute(null);
            
            return usersViewModel;
        }
    }
}