using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.ViewModels;
using Wpf.Ui;
using Wpf.Ui.Appearance;
namespace SimpleTrader.WPF.Commands
{
    public class SwitchThemeCommand:AsyncCommandBase
    {
        private PortfolioViewModel _viewModel;
        private ThemeService _themeService;
        private IDataService<Account> _dataService;
        private IAccountStore _store;

        public SwitchThemeCommand(PortfolioViewModel portfolioViewModel,IDataService<Account> dataService,
            IAccountStore store)
        {
            _viewModel = portfolioViewModel;
            _themeService = new ThemeService();
            _store = store;
            _dataService = dataService;
        }
        

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var currentTheme = (string)parameter;
                _store.CurrentAccount.AccountHolder.Theme = currentTheme;
                await _dataService.Update(_store.CurrentAccount.Id, _store.CurrentAccount);
                _viewModel.ThemeName = currentTheme;
                switch (currentTheme)
                {
                    case "Dark":
                        _themeService.SetTheme(ApplicationTheme.Dark);
                        break;
                    case "Light":
                        _themeService.SetTheme(ApplicationTheme.Light);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        
       
    }
    }
