using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace SimpleTrader.WPF.Commands.AdminStocksCommands
{
    public class CreateStockCommand: AsyncCommandBase
    {
        private IDataService<StockDescription> _dataService;
        private CreateStockViewModel _viewModel;
        private ISnackbarService _snackbarService;
        public CreateStockCommand(IDataService<StockDescription> dataService,
            CreateStockViewModel viewModel,
            ISnackbarService snackbarService)
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

                await _dataService.Create(stock);
                
                _snackbarService.Show(
                    "Success",
                    $"Stock {stock.Symbol} added to database",
                    ControlAppearance.Success,
                    new SymbolIcon(SymbolRegular.Fluent24),
                    TimeSpan.FromSeconds(4)
                );

                _viewModel.Description = "";
                _viewModel.Price = 0;
                _viewModel.Symbol= "";
                 _viewModel.CompanyName= "";
                 _viewModel.Exchange= "";
                 _viewModel.Img= "";
                 
                 _viewModel.UpdateFields();
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