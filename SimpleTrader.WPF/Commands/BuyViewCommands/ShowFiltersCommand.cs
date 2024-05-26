using System.Threading.Tasks;
using SimpleTrader.WPF.Controls;
using SimpleTrader.WPF.ViewModels;
using Wpf.Ui;

namespace SimpleTrader.WPF.Commands.BuyViewCommands
{
    public class ShowFiltersCommand: AsyncCommandBase
    {
        private IContentDialogService _dialogService;
        private BuyViewModel _viewModel;
        
        public ShowFiltersCommand(IContentDialogService dialogService,BuyViewModel viewModel)
        {
            _dialogService = dialogService;
            _viewModel = viewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            var showFiltersDialog = new ShowFiltersDialog(_dialogService.GetDialogHost(),_viewModel);

            _ = await showFiltersDialog.ShowAsync();
        }
    }
}