using System;
using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.Commands.AdminStocksCommands;
using Wpf.Ui;

namespace SimpleTrader.WPF.ViewModels
{
    public class CreateStockViewModel: ViewModelBase
    {
        public ICommand CreateStockCommand { get; }
        
        public string Symbol { get; set; }


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
        
        private double _price;
        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            } 
        }
        public string CompanyName { get; set; }
        public string Exchange { get; set; }
        public string Description { get; set; }

        public void UpdateFields()
        {
            OnPropertyChanged(Symbol);
            OnPropertyChanged(nameof(CompanyName));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(Exchange));
        }

        
        public CreateStockViewModel(IDataService<StockDescription> dataService, ISnackbarService snackbarService)
        {
            CreateStockCommand = new CreateStockCommand(dataService, this, snackbarService);
            
        }
    }
}