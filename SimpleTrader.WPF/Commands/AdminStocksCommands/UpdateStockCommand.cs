using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace SimpleTrader.WPF.Commands.AdminStocksCommands
{
    public class UpdateStockCommand: AsyncCommandBase
    {
        private readonly IDataService<StockDescription> _dataService;
        private readonly UpdateStockViewModel _viewModel;
        private readonly ISnackbarService _snackbarService;

        public UpdateStockCommand(IDataService<StockDescription> dataService, UpdateStockViewModel viewModel, ISnackbarService snackbarService)
        {
            _dataService = dataService;
            _viewModel = viewModel;
            _snackbarService = snackbarService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                if (string.IsNullOrEmpty(_viewModel.Description) || 
                    string.IsNullOrEmpty(_viewModel.Symbol ) || 
                    string.IsNullOrEmpty(_viewModel.CompanyName ) || 
                    string.IsNullOrEmpty(_viewModel.Img ) ||
                    _viewModel.Price < 1
                   )
                {
                    throw new Exception("check fields for validity");
                }
                var stock = new StockDescription
                {
                    Description = _viewModel.Description,
                    Price = _viewModel.Price,
                    Symbol = _viewModel.Symbol,
                    CompanyName = _viewModel.CompanyName,
                    Exchange = _viewModel.Exchange,
                    Img = _viewModel.Img
                };
                await _dataService.Update((int)parameter,stock);
                _snackbarService.Show(
                    "Success",
                    $"Stock has been updated",
                    ControlAppearance.Success,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(4)
                );
            }
            catch (Exception e)
            {
                _snackbarService.Show(
                    "Error",
                    $"{e.Message}",
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(4)
                );
            }
        }
    }
}