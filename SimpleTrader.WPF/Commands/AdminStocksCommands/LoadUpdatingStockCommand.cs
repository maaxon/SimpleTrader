using System;
using System.Globalization;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands.AdminStocksCommands
{
    public class LoadUpdatingStockCommand: AsyncCommandBase
    {
        private IDataService<StockDescription> _dataService;
        private UpdateStockViewModel _viewModel;
        public LoadUpdatingStockCommand(IDataService<StockDescription> dataService, UpdateStockViewModel viewModel)
        {
            _dataService = dataService;
            _viewModel = viewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var stock = await _dataService.Get((int)parameter);
                _viewModel.Description = stock.Description;
                _viewModel.Symbol = stock.Symbol;
                _viewModel.Exchange = stock.Exchange;
                _viewModel.Price = stock.Price;
                _viewModel.CompanyName = stock.CompanyName;
                _viewModel.Id = stock.Id;
                _viewModel.Img = stock.Img;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}