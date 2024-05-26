using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
    public class LoadAdminStockCommand: AsyncCommandBase
    {
        private readonly IDataService<StockDescription> _dataService;
        private readonly AdminStocksViewModel _viewModel;

        public LoadAdminStockCommand(IDataService<StockDescription> dataService, AdminStocksViewModel viewModel)
        {
            _dataService = dataService;
            _viewModel = viewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.IsLoading = true;
            try
            {
                _viewModel.Stocks = await _dataService.GetAll();
                _viewModel.IsLoading = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}