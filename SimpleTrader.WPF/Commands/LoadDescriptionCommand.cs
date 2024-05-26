using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
    public class LoadDescriptionCommand: AsyncCommandBase
    {
        private readonly StockViewModel _stockViewModel;
        private readonly IStockDescriptionService _stockDescriptionService;

        public LoadDescriptionCommand(StockViewModel stockViewModel, IStockDescriptionService stockDescriptionService)
        {
            _stockDescriptionService = stockDescriptionService;
            _stockViewModel = stockViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _stockViewModel.IsLoading = true;
            try
            {
                _stockViewModel.Description =  await _stockDescriptionService.GetStockDescription(parameter as string);
                _stockViewModel.StockPriceChanges =
                    await _stockDescriptionService.GetStockPriceChanges(parameter as string);
                _stockViewModel.IsLoading = false;
            }
            catch (Exception e)
            {
                _stockViewModel.IsLoading = false;
            }
        }

    }
}