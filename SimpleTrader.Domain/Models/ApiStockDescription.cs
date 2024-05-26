namespace SimpleTrader.Domain.Models
{
    public class ApiStockDescription:StockDescription
    {
        public string Image { get; set; }
        public double Changes { get; set; }
    }
}