using SimpleTrader.WPF.ViewModels;
using System;

namespace SimpleTrader.WPF.State.Navigators
{
    public enum ViewType
    {
        Login,
        Home,
        Portfolio,
        Buy,
        Sell,
        Users,
        Search,
        AdminStocks,
        AssetQueue
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}
