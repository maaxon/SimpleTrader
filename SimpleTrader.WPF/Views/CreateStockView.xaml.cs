using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Views
{
    public partial class CreateStockView : UserControl
    {
        public CreateStockView()
        {
            InitializeComponent();
        }

     

        private void ComboBox_OnDropDownClosed(object sender, EventArgs e)
        {
            var box = (ComboBox)sender;
            var item = (TextBlock)box.SelectedItem;
            var viewModel = (CreateStockViewModel)DataContext;
            viewModel.Exchange = item.Text;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)  
        {  
            OpenFileDialog op = new OpenFileDialog();  
            op.Title = "Select a picture";  
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +  
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +  
                        "Portable Network Graphic (*.png)|*.png";  
          
                if (op.ShowDialog() == true)
                {
                    var viewModel = (CreateStockViewModel)DataContext;
                    var uri = new Uri(op.FileName).ToString();
                    viewModel.Img = uri;
                }  
              

        }  
        
      
    }
}