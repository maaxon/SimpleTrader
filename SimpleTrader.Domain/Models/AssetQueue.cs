namespace SimpleTrader.Domain.Models
{
    public class AssetQueue: DomainObject
    {
        public int UserId { get; set; }
        public int Shares { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public string Mode { get; set; }
    }
}