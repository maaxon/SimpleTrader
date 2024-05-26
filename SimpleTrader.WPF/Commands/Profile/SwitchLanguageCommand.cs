using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.ViewModels;
using Wpf.Ui;

namespace SimpleTrader.WPF.Commands
{
    public class SwitchLanguageCommand : AsyncCommandBase
    {
        private PortfolioViewModel _viewModel;
        private IDataService<Account> _dataService;
        private IAccountStore _store;
       
        public SwitchLanguageCommand(PortfolioViewModel portfolioViewModel,IDataService<Account> dataService,
            IAccountStore store)
        {
            _viewModel = portfolioViewModel;
            _store = store;
            _dataService = dataService;
        }
        
        

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var lang = (string)parameter;
                _store.CurrentAccount.AccountHolder.Lang = lang;
                await _dataService.Update(_store.CurrentAccount.Id, _store.CurrentAccount);
                _viewModel.Lang = lang;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}