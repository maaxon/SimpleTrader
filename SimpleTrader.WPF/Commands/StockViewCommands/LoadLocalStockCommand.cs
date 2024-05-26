using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands.StockViewCommands
{
    public class LoadLocalStockCommand: AsyncCommandBase
    {
        private StockViewModel _viewModel;
        private IStockDescriptionDataService _dataService;

        public LoadLocalStockCommand(StockViewModel viewModel,IStockDescriptionDataService dataService)
        {
            _viewModel = viewModel;
            _dataService = dataService;
        }
        
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var stock =await _dataService.GetBySymbol((string)parameter);
                _viewModel.LocalDescription = stock;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
        }
    }
}