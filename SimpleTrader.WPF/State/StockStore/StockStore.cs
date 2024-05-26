using System;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.WPF.State.StockStore
{
    public class StockStore: IStockStore
    {
        private string _currentAsset;
        public string CurrentAsset
        {
            get
            {
                return _currentAsset;
            }
            set
            {
                _currentAsset = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;

    }
}