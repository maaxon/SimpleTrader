using System;
using System.Linq;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.Controls;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace SimpleTrader.WPF.Commands.AdminStocksCommands
{
    public class ShowHistory: AsyncCommandBase
    {
        private IDataService<AssetTransaction> _dataService;
        private IContentDialogService _contentDialogService;
        private ISnackbarService _snackbarService;
        
        public ShowHistory(IDataService<AssetTransaction> dataService,
            IContentDialogService contentDialogService,
            ISnackbarService snackbarService)
        {
            _snackbarService = snackbarService;
            _dataService = dataService;
            _contentDialogService = contentDialogService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var assets = await _dataService.GetAll();
                assets = assets.Where(a => a.Asset.Symbol.Equals((string)parameter));
                var showFiltersDialog = new ShowStockHistory(_contentDialogService.GetDialogHost(),assets);

                _ = await showFiltersDialog.ShowAsync();
            }
            catch (Exception e)
            {
                _snackbarService.Show(
                    "Fail",
                    $"Failed to load history",
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(4)
                );
            }
        }
    }
}