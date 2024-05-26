namespace SimpleTrader.Domain.Models
{
    public class ChangeAssetAmount
    {
       public string Symbol { get; set; }
       public double Price { get; set; }
       public int Inc { get; set; }
       public int Dec { get; set; }
    }
}