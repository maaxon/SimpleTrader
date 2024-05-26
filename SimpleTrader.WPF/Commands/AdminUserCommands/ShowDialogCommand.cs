using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.Commands.AdminUserCommands;
using SimpleTrader.WPF.Controls;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.Views;
using Wpf.Ui;
using Wpf.Ui.Extensions;

namespace SimpleTrader.WPF.Commands
{
    public class ShowDialogCommand: AsyncCommandBase
    {
        private readonly IDataService<StockDescription> _stockService;
        private readonly IContentDialogService _dialogService;
        private readonly IDataService<Account> _accountService;
        private readonly int _accountId;
        private readonly UserViewModel _viewModel;
        private readonly ISnackbarService _snackbarService;
        public ShowDialogCommand(IDataService<StockDescription> stockService,
            IDataService<Account> accountService,
            IContentDialogService dialogService,
            int accountId,
            UserViewModel viewModel,
                ISnackbarService snackbarService
            )
        {
            _stockService =stockService;
            _dialogService = dialogService;
            _accountService = accountService;
            _accountId = accountId;
            _viewModel = viewModel;
            _snackbarService = snackbarService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            var command = new AddStockCommand(_accountService,_accountId, _snackbarService);
            IEnumerable<StockDescription> descriptions = await _stockService.GetAll();
            var viewModel = new UserSelectionStockViewModel(descriptions.ToList(), command);
            var dialog = new SearchStock(_dialogService.GetDialogHost(),viewModel,_viewModel);
            _ = await dialog.ShowAsync();
        }
    }
}