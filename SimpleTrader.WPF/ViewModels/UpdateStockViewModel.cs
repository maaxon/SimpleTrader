using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.Commands.AdminStocksCommands;
using SimpleTrader.WPF.State.UpdateStockStore;
using Wpf.Ui;

namespace SimpleTrader.WPF.ViewModels
{
    public class UpdateStockViewModel: ViewModelBase
    {
        public ICommand UpdateStockCommand { get; }
        private ICommand LoadStockCommand { get; }
        
        public string Symbol { get; set; }
        public double Price { get; set; }
        public string CompanyName { get; set; }
        public string Exchange { get; set; }
        public string Description { get; set; }

        public int SelectedExchange { get; set; }
        public int Id { get; set; }

        private int SelectedIndex()
        {
            switch (Exchange)
            {
                case "Nasdaq":
                    return 0;
                case "Dow Jones":
                    return 1;
                case "S&amp;P 500":
                    return 2;
                default:
                    return 0;
            }
        }
        
        private string _img;

        public string Img
        {
            get => _img;
            set
            {
                _img = value;
                OnPropertyChanged(nameof(Img));
            }
        }
        
        private UpdateStockViewModel(IDataService<StockDescription> dataService,ISnackbarService snackbarService)
        {
            UpdateStockCommand = new UpdateStockCommand(dataService, this, snackbarService);
            LoadStockCommand = new LoadUpdatingStockCommand(dataService, this);
            SelectedExchange = SelectedIndex();
        }

        public static UpdateStockViewModel LoadUpdateStockViewModel(
            IDataService<StockDescription> dataService,
            UpdateStockStore stockStore,
            ISnackbarService snackbarService)
        {
            var viewModel = new UpdateStockViewModel(dataService,snackbarService);
            viewModel.LoadStockCommand.Execute(stockStore.StockId);
            return viewModel;
        }
    }
}