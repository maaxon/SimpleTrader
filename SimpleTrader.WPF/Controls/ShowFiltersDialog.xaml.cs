using System.Windows;
using System.Windows.Controls;
using SimpleTrader.WPF.ViewModels;
using Wpf.Ui.Controls;
using TextBlock = System.Windows.Controls.TextBlock;

namespace SimpleTrader.WPF.Controls
{
    public partial class ShowFiltersDialog : ContentDialog
    {
        private BuyViewModel _viewModel;
        public ShowFiltersDialog(ContentPresenter contentPresenter, BuyViewModel viewModel)
            : base(contentPresenter)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = viewModel;
        }

        protected override void OnButtonClick(ContentDialogButton button)
        {
            _viewModel.FilterCommand.Execute(_viewModel); 
            base.OnButtonClick(button);
           
        }
    }
}