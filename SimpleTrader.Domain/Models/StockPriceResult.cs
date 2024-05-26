namespace SimpleTrader.FinancialModelingPrepAPI.Results
{
    public class StockPriceResult
    {
        public double Price { get; set; }
        public string Symbol { get; set; }

        public StockPriceResult(string symbol, double price)
        {
            Price = price;
            Symbol = symbol;
        }
    }
}
