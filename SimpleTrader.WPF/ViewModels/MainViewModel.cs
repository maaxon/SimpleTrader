using System.Windows;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Factories;
using System.Windows.Input;
using SimpleTrader.WPF.Translation;
using Wpf.Ui;
using Wpf.Ui.Appearance;

namespace SimpleTrader.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ISimpleTraderViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public bool IsAdmin => _authenticator.IsAdmin;
        public bool IsBlocked => _authenticator.IsBlocked;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; }
        public Window Window { get; set; }

        private void SetSettings()
        {
            if (_authenticator.CurrentAccount == null) return;
            var lang  = _authenticator.CurrentAccount.AccountHolder.Lang;
            ChangeLanguage.SwitchLanguage(Window, lang);
            var currentTheme = _authenticator.CurrentAccount.AccountHolder.Theme; 
            var themeService = new ThemeService();
            switch (currentTheme)
            {
                case "Dark":
                    themeService.SetTheme(ApplicationTheme.Dark);
                    return;
                case "Light":
                    themeService.SetTheme(ApplicationTheme.Light);
                    break;
            }
        }
       
      

        public MainViewModel(INavigator navigator, ISimpleTraderViewModelFactory viewModelFactory, IAuthenticator authenticator)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;

            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);

            
        }

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
            OnPropertyChanged(nameof(IsAdmin));
            OnPropertyChanged(nameof(IsBlocked));
            SetSettings();
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public override void Dispose()
        {
            _navigator.StateChanged -= Navigator_StateChanged;
            _authenticator.StateChanged -= Authenticator_StateChanged;

            base.Dispose();
        }
    }
}
