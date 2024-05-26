using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.Translation;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Views
{
    /// <summary>
    /// Interaction logic for PortfolioView.xaml
    /// </summary>
    public partial class PortfolioView : UserControl
    {
        public ICommand SwitchLanguage { get; set; }
        public PortfolioView()
        {
            InitializeComponent();

           
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            var viewModel = (PortfolioViewModel)DataContext;
            ChangeLanguage.SwitchLanguage(window,"Rus");
        }
        
        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            var viewModel = (PortfolioViewModel)DataContext;
            ChangeLanguage.SwitchLanguage(window,"Eng");
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();  
            op.Title = "Select a picture";  
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +  
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +  
                        "Portable Network Graphic (*.png)|*.png";  
            if (op.ShowDialog() == true)
            {
                var viewModel = (PortfolioViewModel)DataContext;
                var uri = new Uri(op.FileName).ToString();
                viewModel.ChangeImg.Execute(uri);
            }  

        }
    }
}
