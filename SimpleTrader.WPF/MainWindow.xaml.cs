using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.Translation;
using SimpleTrader.WPF.ViewModels;
using Wpf.Ui;

namespace SimpleTrader.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ICommand SwitchLanguage
        {
            get;
            set;
        }

        public ICommand SwitchTheme
        {
            get;
            set;
        }
      
        public MainWindow(object dataContext)
        {
            InitializeComponent();
           
            DataContext = dataContext;
            
            
        }

        public MainWindow(MainViewModel dataContext,ISnackbarService snackbarService, IContentDialogService contentDialogService)
        {
            InitializeComponent();
           
            DataContext = dataContext;
            
            dataContext.Window = this;
            
            snackbarService.SetSnackbarPresenter(SnackbarPresenter);
            contentDialogService.SetDialogHost(RootContentDialog);
        }
  
    }
}
