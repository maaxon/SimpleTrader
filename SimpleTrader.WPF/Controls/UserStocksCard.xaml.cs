using System.Windows;
using System.Windows.Controls;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Controls
{
    public partial class UserStocksCard : UserControl
    {
        public UserStocksCard()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (UserStockCardViewModel)DataContext;
            viewModel.Dec();
        }
        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            var viewModel = (UserStockCardViewModel)DataContext;
            viewModel.Inc();
        }
        
        private void ButtonBase_OnClick3(object sender, RoutedEventArgs e)
        {
            var viewModel = (UserStockCardViewModel)DataContext;
            viewModel.ShowShareChanging();
        }

        
    }
}