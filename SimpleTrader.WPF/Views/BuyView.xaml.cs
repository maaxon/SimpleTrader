using System.Windows;
using System.Windows.Controls;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Views
{
    /// <summary>
    /// Interaction logic for BuyView.xaml
    /// </summary>
    public partial class BuyView : UserControl
    {
        public BuyView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                var viewModel = DataContext as BuyViewModel;
                viewModel.SearchStock();
            }
        }
    }
}
