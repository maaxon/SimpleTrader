using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Views
{
    public partial class StockView : UserControl
    {
        private string Symbol { get; set; }

      

        public StockView()
        {
            InitializeComponent();
            SizeChanged += MainWindow_Resize;
            
        }
        

        private void MainWindow_Resize(object sender, System.EventArgs e)
        {
            if (DataContext != null)
            {
                var viewModel = DataContext as StockViewModel;
                if (ActualWidth > 1250)
                {
                    viewModel.ShowChart = true;
                    
                }
                else
                {
                    viewModel.ShowChart = false;
                }
            }
            
        }
     
    }
}