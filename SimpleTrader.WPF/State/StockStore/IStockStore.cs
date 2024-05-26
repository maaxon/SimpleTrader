using System;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.WPF.State.StockStore
{
    public interface IStockStore
    {
        
            string CurrentAsset { get; set; }
            event Action StateChanged;
        
    }
}