using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
    public class LoadPricesCommand: AsyncCommandBase
    {
        
        private readonly BuyViewModel _viewModel;
        private readonly IStockPriceService _stockPriceService;
        private readonly IDataService<StockDescription> _dataService;
        public LoadPricesCommand(BuyViewModel buyViewModel, IStockPriceService stockPriceService, IDataService<StockDescription> dataService)
        {
            _viewModel = buyViewModel;
            _stockPriceService = stockPriceService;
            _dataService = dataService;
        }

     
        
      
        

        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.IsLoading = true;
            try
            {
                var stocks = await _dataService.GetAll();
                _viewModel.StockPrice = stocks.ToList();
                _viewModel.IsLoading = false;
            }
            catch (InvalidSymbolException)
            {
                _viewModel.ErrorMessage = "Symbol does not exist.";
            }
            catch (Exception)
            {
                _viewModel.ErrorMessage = "Failed to get symbol information.";
            }
        }
        
    }
}