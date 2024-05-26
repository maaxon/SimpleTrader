using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands.AdminStocksCommands
{
    public class DeleteStockCommand: AsyncCommandBase
    {
        private AdminStocksViewModel _viewModel;
        private IDataService<StockDescription> _dataService;
        public DeleteStockCommand(IDataService<StockDescription> dataService, AdminStocksViewModel viewModel)
        {
            _viewModel = viewModel;
            _dataService = dataService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.IsLoading = true;
            try
            {
                var res = await _dataService.Delete((int)parameter);
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