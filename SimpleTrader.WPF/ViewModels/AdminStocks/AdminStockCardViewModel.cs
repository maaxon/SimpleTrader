using System.Windows.Input;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.WPF.ViewModels
{
    public class AdminStockCardViewModel: StockDescription
    {
        public ICommand DeleteStockCommand { get; }
        public ICommand UpdateStockCommand { get; }
        public ICommand ShowHistory { get;  }
        public AdminStockCardViewModel(StockDescription description,
            ICommand deleteStockCommand,
            ICommand updateStockCommand,
            ICommand showHistory
            )
        {
            Symbol = description.Symbol;
            Price = description.Price;
            Id = description.Id;
            CompanyName = description.CompanyName;
            Exchange = description.Exchange;
            Description = description.Description;

            UpdateStockCommand = updateStockCommand;
            DeleteStockCommand = deleteStockCommand;
            ShowHistory = showHistory;
        }
    }
}