using System;

namespace SimpleTrader.WPF.State.UpdateStockStore
{
    public interface IUpdateStockStore
    {
        int StockId { get; set; }
        event Action StateChanged;
    }
}