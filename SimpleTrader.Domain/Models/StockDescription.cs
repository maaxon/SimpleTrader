namespace SimpleTrader.Domain.Models
{
    public class StockDescription : DomainObject
    {
        public string Symbol { get; set; }
        public double Price { get; set; }
        public string CompanyName { get; set; }
        public string Exchange { get; set; }
        public string Description { get; set; }
        
        public string Img { get; set; }
    }
}