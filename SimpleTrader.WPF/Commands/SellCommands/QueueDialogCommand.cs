using System.ComponentModel;
using System.Threading.Tasks;
using SimpleTrader.WPF.Controls;
using SimpleTrader.WPF.ViewModels;
using Wpf.Ui;

namespace SimpleTrader.WPF.Commands.SellCommands
{
    public class QueueDialogCommand: AsyncCommandBase
    {
        private readonly IContentDialogService _dialogService;
        private readonly SellViewModel _viewModel;
        public QueueDialogCommand(IContentDialogService dialogService, SellViewModel viewModel)
        {
            _dialogService = dialogService;
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }
        
        public override bool CanExecute(object parameter)
        {
            return _viewModel.CanSellStock && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var showFiltersDialog = new ShowAddQueueDialog(_dialogService.GetDialogHost(),_viewModel);

            _ = await showFiltersDialog.ShowAsync();
        }
        
        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SellViewModel.CanSellStock))
            {
                OnCanExecuteChanged();
            }
        }
    }
}