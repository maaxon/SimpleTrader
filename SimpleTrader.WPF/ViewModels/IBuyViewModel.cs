using System.ComponentModel;

namespace SimpleTrader.WPF.ViewModels
{
    public interface IBuyViewModel : INotifyPropertyChanged
    {
        string ErrorMessage { set; }
        string StatusMessage { set; }
        string Symbol { get; }
        bool CanBuyStock { get; }
        
        int SharesToBuy { get; }
    }
}