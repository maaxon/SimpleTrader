﻿using System.Windows.Controls;

namespace SimpleTrader.WPF.Controls
{
    /// <summary>
    /// Interaction logic for SearchSymbolResultPanel.xaml
    /// </summary>
    public partial class SearchSymbolResultPanel : UserControl
    {
        public string Symbol { get; set; } 
        public SearchSymbolResultPanel()
        {
           
            InitializeComponent();
            
        }
    }
}
