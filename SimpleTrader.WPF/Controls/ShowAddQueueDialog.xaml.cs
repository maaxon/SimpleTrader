using System.Windows;
using System.Windows.Controls;
using SimpleTrader.WPF.ViewModels;
using Wpf.Ui.Controls;

namespace SimpleTrader.WPF.Controls
{
    public partial class ShowAddQueueDialog : ContentDialog
    {
        private SellViewModel _viewModel;
        public ShowAddQueueDialog(ContentPresenter contentPresenter, SellViewModel viewModel)
        : base(contentPresenter)
        {
            _viewModel = viewModel;
            InitializeComponent();
            DataContext = viewModel;
        }
        
        protected override void OnButtonClick(ContentDialogButton button)
        {
            _viewModel.AddToQueueCommand.Execute(null);
            base.OnButtonClick(button);
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.Mode = "High";
        }

        private void MenuItem_OnClick2(object sender, RoutedEventArgs e)
        {
            _viewModel.Mode = "Low";
        }
    }
}