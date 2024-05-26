using System.Windows.Controls;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Views
{
    public partial class AssetQueueView : UserControl
    {
        public AssetQueueView()
        {
            InitializeComponent();
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataContext != null)
            {
                var viewModel = DataContext as AssetsQueueViewModel;
                viewModel.SearchStock();
            }
        }
    }
}