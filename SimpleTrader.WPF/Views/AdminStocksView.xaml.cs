using System.Windows;
using System.Windows.Controls;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Views
{
    public partial class AdminStocksView : UserControl
    {
        public AdminStocksView()
        {
            InitializeComponent();
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                var viewModel = (AdminStocksViewModel)DataContext;
                viewModel.SearchStock();
            }
        }
    }
}