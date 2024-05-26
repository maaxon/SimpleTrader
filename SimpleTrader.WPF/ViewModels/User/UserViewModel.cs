using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.Commands.AdminUserCommands;
using SimpleTrader.WPF.Controls;
using SimpleTrader.WPF.State.UsersStore;
using Wpf.Ui;

namespace SimpleTrader.WPF.ViewModels
{
    public class UserViewModel:ViewModelBase
    {
        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public IEnumerable<UserStockCardViewModel> Cards => GetCards();

        private IEnumerable<UserStockCardViewModel> GetCards()
        {
            IEnumerable<UserStockCardViewModel> assetViewModels = _account.AssetTransactions
                    .GroupBy(t => t.Asset.Symbol)
                    .Select(g => 
                        new UserStockCardViewModel(g.Key,
                            g.Sum(a => a.IsPurchase ? a.Shares : -a.Shares),
                        g.Select(a=> a.Asset.PricePerShare).Max(),ChangeStockAmount))
                    .Where(a => a.Shares > 0)
                    .OrderByDescending(a => a.Shares);
            return assetViewModels;
        }

        public ICommand LoadUserCommand { get; }

        private Account _account;
        public Account CurrentAccount
        {
            get => _account;
            set
            {
                _account = value;
                OnPropertyChanged(nameof(CurrentAccount));
                OnPropertyChanged(nameof(Role));
                OnPropertyChanged(nameof(Balance));
                OnPropertyChanged(nameof(IsEmptyList));
                OnPropertyChanged(nameof(Cards));
            }
        }

        public string Name => CurrentAccount.AccountHolder.Username;
        public string Email => CurrentAccount.AccountHolder.Email;
        public string Img => CurrentAccount.AccountHolder.Img;
        public string Role => CurrentAccount.AccountHolder.Role.ToUpper();

        public bool IsEmptyList => CurrentAccount.AssetTransactions.Count < 1;

        public double Balance => CurrentAccount.Balance;

        private double _add;
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
                OnPropertyChanged(nameof(NegativeAdd));
                OnPropertyChanged(nameof(Add));
            }
        }

        public double NegativeAdd => -1 * Add;
        
        public ICommand ShowDialog { get; }
        public ICommand BlockUser { get; }
        public ICommand ChangeBalance { get; }
        public ICommand ChangeStockAmount { get; }

        private UserViewModel(IDataService<Account> dataService,
            IDataService<StockDescription> stockService,
            IContentDialogService dialogService,
            int accountId,
            ISnackbarService snackbarService
            )
        {
            LoadUserCommand = new LoadCurrentUserCommand(dataService, this);
            ShowDialog = new ShowDialogCommand(stockService,
                dataService,
                dialogService,
                accountId,
                this,
                snackbarService
                );
            BlockUser = new BlockUserCommand(dataService, this);
            ChangeBalance = new ChangeBalanceCommand(dataService, this);
            ChangeStockAmount = new ChangeAmount(dataService, this);
        }
        

        public static UserViewModel LoadUserViewModel(IDataService<Account> dataService, UsersStore usersStore,
            IDataService<StockDescription> stockService,
            IContentDialogService dialogService,
            ISnackbarService snackbarService)
        {
            var viewModel = new UserViewModel(dataService,stockService,dialogService,usersStore.UserId,snackbarService);
            viewModel.LoadUserCommand.Execute(usersStore.UserId);
            return viewModel;
        }
    }
}