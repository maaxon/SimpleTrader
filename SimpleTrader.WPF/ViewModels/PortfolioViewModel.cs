using System;
using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.AspNet.Identity;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.Commands.Profile;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.State.Assets;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.State.StockStore;
using Wpf.Ui;

namespace SimpleTrader.WPF.ViewModels
{
    public class PortfolioViewModel : ViewModelBase
    {
        public ICommand SwitchThemeCommand { get; set; }
        public ICommand SwitchLanguage { get; set; }
        public ICommand AddBalanceCommand { get; set; }
        private IDataService<Account> _accountDataService;
        private IAccountStore _accountStore;
        public List<UserCardViewModel> Dict { get; set; } = new List<UserCardViewModel>();
        
        public string ThemeName
        {
            get => _accountStore.CurrentAccount.AccountHolder.Theme;
            set => OnPropertyChanged(nameof(ThemeName));
        }
        
        public string Lang
        {
            get => _accountStore.CurrentAccount.AccountHolder.Lang;
            set => OnPropertyChanged(nameof(Lang));
        }

        public string Img
        {
            get { return _accountStore.CurrentAccount.AccountHolder.Img; }
            set { OnPropertyChanged(nameof(Img));}
        }


        private string _username;
        public string UserName
        {
            get=> _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        private string _email;
        public string Email
        {
            get=>_email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private string _password;
        public string Password
        {
            get=> _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        

        private double _balance;

        public double AccountBalance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(AccountBalance));
            }
        }

        private double _add = 0;

        public double Add
        {
            get => _add;
            set
            {
                if (value > 0)
                {
                     _add = value;
                     
                }
                else
                {
                    _add = 0;
                }
                OnPropertyChanged(nameof(Add));
            }
        }
        
        public ICommand SwitchLang { get; }
        public ICommand ChangeUserName { get; }
        public ICommand ChangeEmail { get; }
        public ICommand ChangePassword { get; }
        public ICommand ChangeImg { get; }
        public ICommand LogOut { get; }

        public PortfolioViewModel(IDataService<Account> accountDataService,
            IAccountStore accountStore, IPasswordHasher passwordHasher, ISnackbarService snackbarService,IAuthenticator authenticator,IRenavigator renavigator)
        {
            _accountDataService = accountDataService;
            _accountStore = accountStore;
            AccountBalance = _accountStore.CurrentAccount.Balance;
            SwitchThemeCommand = new SwitchThemeCommand(this, accountDataService,accountStore);
            AddBalanceCommand = new AddBalanceCommand(accountDataService, accountStore,this);
            SwitchLang = new SwitchLanguageCommand(this, accountDataService, accountStore);
            ChangeUserName = new ChangeUserName(accountDataService, accountStore, this,snackbarService);
            ChangeEmail = new ChangeEmail(accountDataService, accountStore, this,snackbarService);
            ChangePassword = new ChangePassword(accountDataService, accountStore, this, passwordHasher,snackbarService);
            LogOut = new LogOut(authenticator, renavigator);
            ChangeImg = new ChangeImg(accountDataService, accountStore, this, snackbarService);
            _username = _accountStore.CurrentAccount.AccountHolder.Username;
            _email = _accountStore.CurrentAccount.AccountHolder.Email;
        }
        

      
    }
}
