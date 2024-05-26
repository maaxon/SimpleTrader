using System.Windows.Controls;
using SimpleTrader.WPF.ViewModels;
using Wpf.Ui.Controls;

namespace SimpleTrader.WPF.Controls
{
    public partial class SearchStock : ContentDialog
    {
        private UserViewModel _viewModel;
        public SearchStock(ContentPresenter contentPresenter,ViewModelBase context,UserViewModel viewModel):
            base(contentPresenter)
        {
            InitializeComponent();
            DataContext = context;
            _viewModel = viewModel;
        }
        
        protected override void OnButtonClick(ContentDialogButton button)
        {
            _viewModel.LoadUserCommand.Execute(_viewModel.CurrentAccount.Id); 
            base.OnButtonClick(button);
           
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var control = (UserSelectionStockViewModel)DataContext;
            control.SearchStock();
        }
    }
}