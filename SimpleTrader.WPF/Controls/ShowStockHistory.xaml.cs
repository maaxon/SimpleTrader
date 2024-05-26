using System.Collections.Generic;
using System.Windows.Controls;
using SimpleTrader.Domain.Models;
using Wpf.Ui.Controls;

namespace SimpleTrader.WPF.Controls
{
    public partial class ShowStockHistory : ContentDialog
    {
        public IEnumerable<AssetTransaction> Assets { get; }
        public ShowStockHistory(ContentPresenter contentPresenter, IEnumerable<AssetTransaction> assets)
            : base(contentPresenter)
        {
            InitializeComponent();
            DataContext = assets;
        }
    }
}