using System;

namespace SimpleTrader.WPF.State.UpdateStockStore
{
    public class UpdateStockStore: IUpdateStockStore
    {
        private int _stockId;
        public int StockId
        {
            get => _stockId;
            set
            {
                _stockId = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}