﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimpleTrader.WPF.Controls
{
    /// <summary>
    /// Interaction logic for AssetListing.xaml
    /// </summary>
    public partial class AssetListing : UserControl
    {
        public AssetListing()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
